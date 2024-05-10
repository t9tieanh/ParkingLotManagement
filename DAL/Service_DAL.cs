using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class Service_DAL
    {
        #region các hàm get
        /// <summary>
        /// các hàm get (lấy data)
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<Service_DTO> GetService(DataTable dt)
        {
            List<DTO.Service_DTO> myService = new List<DTO.Service_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string ServiceId = row[0]?.ToString();
                    string NameService = row[1]?.ToString();
                    string Description = row[2]?.ToString();
                    double Price = row[3] != DBNull.Value ? Convert.ToDouble(row[3]) : 0;
                    string Type = row[4]?.ToString();
                    string TypeVehical = row[6]?.ToString();
                    int Time = row[7] != DBNull.Value ? Convert.ToInt32(row[7]) : 0;
                    myService.Add(new Service_DTO(ServiceId, NameService, Description, Price, Type, TypeVehical,Time));
                }
            }
            return myService;
        }
        public static Service_DTO GetService(string ServiceId)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM SERVICE WHERE ServiceId = '{ServiceId}'");
            return GetService(dt)[0];
        }
        public static List<Service_DTO> GetService(string typeVehical, string type)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM SERVICE WHERE TYPEVEHICAL = N'{typeVehical}' AND TYPE = N'{type}' AND STATUS = 1");
            return GetService(dt);
        }
        public static List<Service_DTO> GetServicesByType (string type)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM SERVICE WHERE TYPE = N'{type}' AND STATUS = 1");
            return GetService(dt);
        }
        #endregion
        #region Insert Service
        public static bool InsertService(Service_DTO newService)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO SERVICE VALUES (@ServiceId, @NameService, @Description, @Price, @Type, @STATUS, @TypeVehical, @Time)";
            sqlCommand.Parameters.AddWithValue("@ServiceId", newService.ServiceId);
            sqlCommand.Parameters.AddWithValue("@NameService", newService.NameService);
            sqlCommand.Parameters.AddWithValue("@Description", newService.Description);
            sqlCommand.Parameters.AddWithValue("@Price", newService.Price);
            sqlCommand.Parameters.AddWithValue("@Time", newService.Time);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            sqlCommand.Parameters.AddWithValue("@Type", newService.Type);
            sqlCommand.Parameters.AddWithValue("@TypeVehical", newService.TypeVehical);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion

        #region update Service
        /// <summary>
        /// chỉ chính được giá tiền và mô tả, thời gian của service 
        /// </summary>
        /// <param name="newService"></param>
        /// <returns></returns>
        public static bool UpdateService(Service_DTO newService)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE SERVICE SET PRICE = @PRICE, DESCRIPTION = @DESCRIPTION, TIME = @TIME WHERE SERVICEID = @SERVICEID";
            sqlCommand.Parameters.AddWithValue("@PRICE", newService.Price);
            sqlCommand.Parameters.AddWithValue("@DESCRIPTION", newService.Description);
            sqlCommand.Parameters.AddWithValue("@SERVICEID", newService.ServiceId);
            sqlCommand.Parameters.AddWithValue("@TIME", newService.Time);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion


        #region Delete Service (chưa làm xong)
        public static bool DeleteService(Service_DTO newService)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE SERVICE SET STATUS = 0 WHERE SERVICEID = @SERVICEID";
            sqlCommand.Parameters.AddWithValue("@SERVICEID", newService.ServiceId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}
