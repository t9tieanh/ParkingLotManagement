using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ParkArea_DAL
    {
        private static List<ParkArea_DTO> GetParkArea(DataTable dt)
        {
            List<ParkArea_DTO> myPark = new List<ParkArea_DTO>();
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string parkAreaId = dt.Rows[i][0].ToString();
                    string address = dt.Rows[i][1].ToString();
                    int capacity = Convert.ToInt32 (dt.Rows[i][2].ToString());
                    string type = dt.Rows[i][3].ToString();
                    //id địa chỉ dung lượng type
                    myPark.Add(new ParkArea_DTO (parkAreaId,address,capacity,type));
                }
            }
            return myPark;
        }
        public static ParkArea_DTO GetParkArea(string parkAreaId, bool isParkArea)
        {
            DataTable dt = MyDB.GetDataTable("SELECT PARKAREAID, ADDRESS, CAPACITY, Type " +
                "FROM PARKAREA " +
                $"WHERE PARKAREAID = '{parkAreaId}'");
            return GetParkArea(dt)[0];
        }
        public static List<ParkArea_DTO> GetParkArea()
        {
            DataTable dt = MyDB.GetDataTable("SELECT PARKAREAID, ADDRESS, CAPACITY, Type " +
                "FROM PARKAREA " +
                "WHERE STATUS = 1");
            return GetParkArea (dt);
        }

        public static List<ParkArea_DTO> GetParkArea(string type)
        {
            DataTable dt = MyDB.GetDataTable("SELECT PARKAREAID, ADDRESS, CAPACITY, Type FROM PARKAREA " +
                $"WHERE TYPE = N'{type}' AND STATUS = 1");
            return GetParkArea(dt);
        }
        public static bool InsertParkArea (ParkArea_DTO newParkArea)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO PARKAREA VALUES (@PARKAREAID, @ADDRESS, @CAPACITY, @Type, @STATUS)";
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", newParkArea.ParkAreaId);
            sqlCommand.Parameters.AddWithValue("@ADDRESS", newParkArea.Address);
            sqlCommand.Parameters.AddWithValue("@CAPACITY", newParkArea.Capacity);
            sqlCommand.Parameters.AddWithValue("@Type", newParkArea.Type);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        /// <summary>
        /// check xem Address đã tồn tại hay chưa 
        /// </summary>
        /// <returns></returns>
        public static bool checkAddress (string Address)
        {
            string querry = "SELECT COUNT(*) FROM PARKAREA " +
                $"WHERE ADDRESS = N'{Address}' AND STATUS = 1";
            int count = MyDB.ExecuteScalar(querry); 
            if (count > 0) return false;
            return true;
        }
        public static bool DeleteParkArea (string parkAreaId)
        {
            // check xem còn hợp đồng với parkArea này không
            if (Contract_DAL.CheckContractParkArea(parkAreaId)) return false; // còn hợp đồng thì không thể xóa 
            // set lại thông tin các worker 
            DAL.Worker_DAL.UpdateWokerParkAreaId(parkAreaId);
            // tiến hành xóa parkArea
            string query = $"UPDATE PARKAREA SET STATUS = 0 WHERE PARKAREAID = N'{parkAreaId}'" ;
            return MyDB.ExecuteNonQuery(query);
        }
        /// <summary>
        /// chỉ cho phép sửa dung lượng của bãi giữ xe 
        /// </summary>
        /// <param name="parkArea"></param>
        /// <returns></returns>
        public static bool UpdateParkArea(ParkArea_DTO parkArea)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE PARKAREA SET CAPACITY = @CAPACITY WHERE PARKAREAID = @PARKAREAID";
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", parkArea.ParkAreaId);
            sqlCommand.Parameters.AddWithValue("@CAPACITY", parkArea.Capacity);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
