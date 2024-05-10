using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Vehicle_Parking_DAL
    {
        private static List<Vehicle_Parking_DTO> GetVehicle_Parking(DataTable dt)
        {
            List<Vehicle_Parking_DTO> myVehicle_Parking = new List<Vehicle_Parking_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string vehicleId = row[0]?.ToString();
                    byte[] picCustomer = row[1] != DBNull.Value ? (byte[])row[1] : null;
                    MemoryStream pictureCustomer = picCustomer != null ? new MemoryStream(picCustomer) : null;
                    byte[] picVehicle = row[2] != DBNull.Value ? (byte[])row[2] : null;
                    MemoryStream pictureVehicle = picVehicle != null ? new MemoryStream(picVehicle) : null;
                    string model = row[3]?.ToString();  
                    string type = row[4]?.ToString();
                    myVehicle_Parking.Add(new Vehicle_Parking_DTO(vehicleId,pictureCustomer, pictureVehicle, model, type));
                }
            }
            return myVehicle_Parking;
        }
        public static List<Vehicle_Parking_DTO> GetVehicle_Parking ()
        {
            string querry = "SELECT * FROM Vehicle_Parking";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetVehicle_Parking(dt);
        }
        public static Vehicle_Parking_DTO GetVehicle_Parking(string vehicleId)
        {
            string querry = $"SELECT * FROM Vehicle_Parking WHERE VEHICLEID = '{vehicleId}'";
            DataTable dt = MyDB.GetDataTable(querry);

            if(dt.Rows.Count > 0)
            {
                return GetVehicle_Parking(dt)[0];
            }
            return null;
        }

        private static bool checkVehicleParking(string vehicleId)
        {
            string sql = "SELECT COUNT (*) " +
                "FROM VEHICLE_Parking " +
                $"WHERE VEHICLEID = N'{vehicleId}'";
            int count = MyDB.ExecuteScalar(sql);
            if (count > 0) return false;
            return true;
        }
        public static bool UpdateVehicle(Vehicle_Parking_DTO vehicle)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE [Vehicle_Parking] SET PICTURECUSTOMER = @PICTURECUSTOMER, PICTUREVEHICLE = @PICTUREVEHICLE, MODEL = @MODEL, TYPE = @TYPE WHERE VEHICLEID = @VEHICLEID";
            sqlCommand.Parameters.AddWithValue("@MODEL", vehicle.Model);
            sqlCommand.Parameters.AddWithValue("@TYPE", vehicle.Type);
            sqlCommand.Parameters.Add("@PICTURECUSTOMER", SqlDbType.Image).Value = vehicle.PictureCustomer.ToArray();
            sqlCommand.Parameters.Add("@PICTUREVEHICLE", SqlDbType.Image).Value = vehicle.PictureVehicle.ToArray();
            sqlCommand.Parameters.AddWithValue("@VEHICLEID", vehicle.VehicleId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool InsertVehicleParking(Vehicle_Parking_DTO vehicleParking)
        {
            if (checkVehicleParking(vehicleParking.VehicleId))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "INSERT INTO [Vehicle_Parking] VALUES (@VEHICLEID, @PICTURECUSTOMER, @PICTUREVEHICLE, @MODEL, @TYPE)";
                sqlCommand.Parameters.AddWithValue("@VEHICLEID", vehicleParking.VehicleId);
                sqlCommand.Parameters.AddWithValue("@PICTURECUSTOMER", vehicleParking.PictureCustomer.ToArray());
                sqlCommand.Parameters.AddWithValue("@PICTUREVEHICLE", vehicleParking.PictureVehicle.ToArray());
                sqlCommand.Parameters.AddWithValue("@MODEL", vehicleParking.Model);
                sqlCommand.Parameters.AddWithValue("@TYPE", vehicleParking.Type);
                return MyDB.ExecuteNonQuery(sqlCommand);
            }
            return UpdateVehicle (vehicleParking);
            
        }
    }
}
