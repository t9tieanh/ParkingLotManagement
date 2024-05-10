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
    public class Manager_DAL
    {
        private static List<DTO.Manager_DTO> GetManager (DataTable dt)
        {
            List<DTO.Manager_DTO> managers = new List<DTO.Manager_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string ManagerId = row[0]?.ToString();
                    string FullName = row[1]?.ToString();
                    byte[] pic = row[2] != DBNull.Value ? (byte[])row[2] : null;
                    MemoryStream Picture = pic != null ? new MemoryStream(pic) : null;
                    string Phone = row[3]?.ToString();
                    bool status = Convert.ToBoolean(row[4].ToString());
                    Account_DTO myAccount = null;
                    if (status)
                        myAccount = Account_DAL.GetAccouts(ManagerId, "Manager");
                    string parkAreaID = row[5] != DBNull.Value ? row[5].ToString() : null ;
                    ParkArea_DTO myParkArea = null;
                    if (parkAreaID != null)
                        myParkArea = ParkArea_DAL.GetParkArea(parkAreaID, true);
                    managers.Add(new Manager_DTO(ManagerId,FullName,Picture,Phone,status,myAccount,myParkArea));
                }
            }
            return managers;
        }
        public static Manager_DTO GetManager (string managerId)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM MANAGER WHERE ManagerId = '{managerId}' ");
            return GetManager (dt)[0];
        }
        public static List<DTO.Manager_DTO> GetManager ()
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM MANAGER ");
            return GetManager (dt);
        }

        #region Update Manager
        public static bool InsertManager (Manager_DTO manager)
        {
            if (!Account_DAL.InsertAccount(manager.Account))
                return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO MANAGER VALUES (@MANAGERID, @FULLNAME, @PICTURE, @PHONE , @STATUS, @PARKAREAID)";
            sqlCommand.Parameters.AddWithValue("@MANAGERID", manager.ManagerId);
            sqlCommand.Parameters.AddWithValue("@FULLNAME", manager.FullName);
            sqlCommand.Parameters.AddWithValue("@PHONE", manager.Phone);
            sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = manager.Picture.ToArray();
            sqlCommand.Parameters.AddWithValue("@STATUS", manager.Status);
            if (manager.ParkArea != null) 
                sqlCommand.Parameters.AddWithValue("@PARKAREAID", manager.ParkArea.ParkAreaId);
            else
                sqlCommand.Parameters.AddWithValue("@PARKAREAID", DBNull.Value);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool UpdateManager (Manager_DTO manager)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE MANAGER SET FULLNAME = @FULLNAME, PICTURE = @PICTURE, PHONE = @PHONE, PARKAREAID = @PARKAREAID  WHERE MANAGERID = @MANAGERID";
            sqlCommand.Parameters.AddWithValue("@MANAGERID", manager.ManagerId);
            sqlCommand.Parameters.AddWithValue("@FULLNAME",manager.FullName);
            sqlCommand.Parameters.AddWithValue("@PHONE", manager.Phone);
            sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = manager.Picture.ToArray();
            if (manager.ParkArea != null)
                sqlCommand.Parameters.AddWithValue("@PARKAREAID", manager.ParkArea.ParkAreaId);
            else
                sqlCommand.Parameters.AddWithValue("@PARKAREAID", DBNull.Value);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool DeleteManager (Manager_DTO manager)
        {
            if (!Account_DAL.DeleteAccount(manager.Account))
                return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM MANAGER WHERE MANAGERID = @MANAGERID";
            sqlCommand.Parameters.AddWithValue("@MANAGERID", manager.ManagerId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}
