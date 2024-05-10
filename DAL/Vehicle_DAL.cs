using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Contracts;

namespace DAL
{
    public class Vehical_DAL
    {
        private static List<Vehical_DTO> GetMyVehicle (DataTable dt)
        {
            List <Vehical_DTO> myVehicle = new List<Vehical_DTO> ();
            foreach (DataRow row in dt.Rows)
            {
                string VehicleId = row[0].ToString();
                string Model = row[1].ToString();
                string Type = row[2].ToString();
                byte[] pic = (byte[])row[3];
                MemoryStream Picture = new MemoryStream(pic);
                int status = Convert.ToInt32(row[4]);
                myVehicle.Add(new Vehical_DTO(VehicleId,Model, Type, Picture, status));
            }
            return myVehicle;
        }
        public static Vehical_DTO GetMyVehicle (string vehicleId)
        {
            string querry = "SELECT * FROM Vehicle" +
                $" WHERE VEHICLEID = N'{vehicleId}' ";
            return GetMyVehicle (MyDB.GetDataTable(querry))[0];
        }
        /// <summary>
        /// lấy những xe có trong hợp đồng có serviceType = ServiceType 
        /// ví dụ lấy những xe có hợp đồng thuê mượn 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List <Vehical_DTO> GetMyVehicleForContract (string ServiceType)
        {
            string query = "SELECT DISTINCT * FROM Vehicle " +
               "WHERE VehicleID IN " +
               "(SELECT DISTINCT Contract.VehicleID " +
               " FROM Contract WHERE ContractID IN " +
               "(SELECT DISTINCT ContractDetail.ContractID FROM ContractDetail, [Service] " +
               $"WHERE ContractDetail.ServiceId = Service.ServiceId AND Service.Type = N'{ServiceType}'))";
            return GetMyVehicle(MyDB.GetDataTable(query));
        }
        /// <summary>
        /// lấy những xe đang nằm dưới quyền quản lý của công ty 
        /// </summary>
        /// <returns></returns>
        public static List<Vehical_DTO> GetMyVehicleForContract()
        {
            /*string query = "SELECT * FROM Vehicle " +
                "WHERE VehicleID IN ( " +
                "SELECT DISTINCT VehicleID " +
                "FROM Contract INNER JOIN RentalManagement ON Contract.ContractID = RentalManagement.ContractID )";*/
            string query = "SELECT * FROM Vehicle Where STATUS = 1";
            return GetMyVehicle(MyDB.GetDataTable(query));
        }

        #region Add Vehical
        public static bool InsertVehicle(Vehical_DTO newVehicle)
        {
            if (!checkVehicle(newVehicle.VehicalId)) return false; // xe đã tồn tại với tư cách đang trong hợp đồng khác hoặc đang giữ xe 
            if (checkVehicleStatus(newVehicle.VehicalId)) 
            {
                // nếu xe chưa từng tồn tại trong bãi 
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "INSERT INTO VEHICLE  VALUES (@VEHICLE, @MODEL, @TYPE, @PICTURE, @STATUS)";
                sqlCommand.Parameters.AddWithValue("@VEHICLE", newVehicle.VehicalId);
                sqlCommand.Parameters.AddWithValue("@MODEL", newVehicle.Model);
                sqlCommand.Parameters.AddWithValue("@TYPE", newVehicle.Type);

                sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = newVehicle.Picture.ToArray();

                sqlCommand.Parameters.AddWithValue("@STATUS", newVehicle.Status);
                return MyDB.ExecuteNonQuery(sqlCommand);
            }
            else
                return UpdateVehicle(newVehicle); // thực hiện update khi xe đã tồn tại trong bãi nhưng có status = 0 (xe đã bị xóa)
        }
        #endregion 
        public static bool checkVehicle (string vehicleId)
        {
            string sql = "SELECT COUNT (*) " +
                "FROM VEHICLE " +
                $"WHERE VEHICLEID = N'{vehicleId}' AND STATUS != 0";
            int count = MyDB.ExecuteScalar(sql);
            if (count > 0) return false;
            return true;
        }

        /// <summary>
        /// check xem vehicle đó đã có trong bãi hay chưa (check với status = 0)
        /// </summary>
        /// <param name="vehicleId"></param>
        /// <returns></returns>
        private static bool checkVehicleStatus (string vehicleId)
        {
            string sql = "SELECT COUNT (*) " +
                "FROM VEHICLE " +
                $"WHERE VEHICLEID = N'{vehicleId}'";
            int count = MyDB.ExecuteScalar(sql);
            if (count > 0) return false;
            return true;
        }
        public static bool UpdateVehicle (Vehical_DTO vehicle)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE VEHICLE SET MODEL = @MODEL, TYPE = @TYPE, PICTURE = @PICTURE, STATUS = @STATUS WHERE VEHICLEID = @VEHICLEID";
            sqlCommand.Parameters.AddWithValue("@MODEL", vehicle.Model);
            sqlCommand.Parameters.AddWithValue("@TYPE", vehicle.Type);
            sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = vehicle.Picture.ToArray();
            sqlCommand.Parameters.AddWithValue("@STATUS", vehicle.Status);
            sqlCommand.Parameters.AddWithValue("@VEHICLEID", vehicle.VehicalId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool DeleteVehicle (string VehicleId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE VEHICLE SET STATUS = 0 WHERE VEHICLEID = @VEHICLEID";
            sqlCommand.Parameters.AddWithValue("@VEHICLEID", VehicleId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
