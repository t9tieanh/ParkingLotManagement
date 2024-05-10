using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Parking_DAL
    {
        private static List<Parking_DTO> GetParking(DataTable dt)
        {
            List<Parking_DTO> myParking = new List<Parking_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string parkingId = row[0]?.ToString();

                    string vehicleId = row[1]?.ToString();
                    Vehicle_Parking_DTO myVehicle = Vehicle_Parking_DAL.GetVehicle_Parking(vehicleId);

                    string parkAreaId = row[2]?.ToString();
                    ParkArea_DTO myParkArea = ParkArea_DAL.GetParkArea(parkAreaId,true);

                    DateTime checkIn = (DateTime)row[3];
                    DateTime checkOut = DateTime.Now;
                    //DateTime checkOut = row[4] != null ? (DateTime)row[4] : null;

                    myParking.Add(new Parking_DTO(parkingId, myVehicle, myParkArea, checkIn, checkOut));
                }
            }
            return myParking;
        }
        private static List<Parking_DTO> GetParkingForAdmin (DataTable dt)
        {
            List<Parking_DTO> myParking = new List<Parking_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string parkingId = row[0]?.ToString();

                    string vehicleId = row[1]?.ToString();
                    Vehicle_Parking_DTO myVehicle = Vehicle_Parking_DAL.GetVehicle_Parking(vehicleId);

                    string parkAreaId = row[2]?.ToString();
                    ParkArea_DTO myParkArea = ParkArea_DAL.GetParkArea(parkAreaId, true);

                    DateTime checkIn = (DateTime)row[3];
                    DateTime checkOut = row[4] != DBNull.Value ? (DateTime)row[4] : DateTime.MinValue;

                    myParking.Add(new Parking_DTO(parkingId, myVehicle, myParkArea, checkIn, checkOut));
                }
            }
            return myParking;
        }
        public static Parking_DTO GetParking(string parkingId, bool isCheck)
        {
            string querry = $"SELECT * FROM Parking WHERE ParkingId = '{parkingId}' AND CheckOut Is NULL";
            DataTable dt = MyDB.GetDataTable(querry);
            var parkingLst = GetParking(dt);
            if (parkingLst.Count == 0)
                return null;    
            else return parkingLst[0];
        }
        #region dùng cho admin để xem dữ liệu 
        public static List<Parking_DTO> GetParkingCheckInForAdmin (ParkArea_DTO parkArea, DateTime start)
        {
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckIn > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckIn < '{(start.AddDays(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParkingForAdmin(dt);
        }
        public static List<Parking_DTO> GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, DateTime start)
        {
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckOut > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckOut < '{(start.AddDays(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParkingForAdmin(dt);
        }
        public static List<Parking_DTO> GetParkingCheckInForAdmin(ParkArea_DTO parkArea, DateTime start, string vehicleId)
        {
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckIn > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                $"AND CheckIn < '{(start.AddDays(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND VehicleID LIKE '%{vehicleId}%'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParkingForAdmin(dt);
        }
        public static List<Parking_DTO> GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, DateTime start, string vehicleId)
        {
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckOut > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' " +
                $"AND CheckOut < '{(start.AddDays(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND VehicleID LIKE '%{vehicleId}%'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParkingForAdmin(dt);
        }
        public static List<Parking_DTO> GetParkingForAdmin (ParkArea_DTO parkArea)
        {
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CHECKOUT IS NULL";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParkingForAdmin(dt);
        }
        // DÙNG CHO STATIC 
        public static int GetParkingCheckInForAdmin(ParkArea_DTO parkArea, int Month)
        {
            DateTime start = new DateTime(DateTime.Now.Year, Month, 1);
            string querry = $"SELECT COUNT(*) FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckIn > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckIn < '{(start.AddMonths(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}'";
            return MyDB.ExecuteScalar(querry);
        }
        public static int GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, int Month)
        {
            DateTime start = new DateTime(DateTime.Now.Year, Month, 1);
            string querry = $"SELECT COUNT (*) FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckOut > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckOut < '{start.AddMonths(1).Date.ToString("yyyy-MM-dd HH:mm:ss")}'";
            return MyDB.ExecuteScalar(querry);
        }
        public static double GetParkingRevenueForAdmin(ParkArea_DTO parkArea, int Month)
        {
            Fee_DTO myFee = Fee_DAL.GetFee();
            DateTime start = new DateTime(DateTime.Now.Year, Month, 1);
            string querry = $"SELECT * FROM PARKING WHERE PARKAREAID = '{parkArea.ParkAreaId}' AND CheckOut > '{start.Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckOut < '{(start.AddMonths(1)).Date.ToString("yyyy-MM-dd HH:mm:ss")}' AND CheckOut IS NOT NULL";
            var Parkings = GetParkingForAdmin(MyDB.GetDataTable(querry));
            //var Parkings = GetParkingCheckOutForAdmin(parkArea, Month);
            double renuve = 0;
            foreach (var parking in Parkings)
            {
                TimeSpan duration = parking.CheckOut - parking.CheckIn;
                renuve += myFee.FeeCalculation((int)duration.TotalHours, parking.ParkArea.Type);
            }
            return renuve;
        }

        #endregion
        public static List<Parking_DTO> GetParking()
        {
            string querry = "SELECT * FROM Parking";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParking(dt);
        }
        public static Parking_DTO GetParking(string parkingId)
        {
            string querry = $"SELECT * FROM Parking WHERE ParkingId = '{parkingId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetParking(dt)[0];
        }
        public static Parking_DTO GetParkingToCheckOut(string vehicleId)
        {
            
            Vehicle_Parking_DTO vehicleParking = Vehicle_Parking_DAL.GetVehicle_Parking(vehicleId);
            
            if (vehicleParking == null)
            {
                return null;
            }

            string querry = $"SELECT * FROM Parking WHERE VehicleID = '{vehicleParking.VehicleId}' AND CheckOut IS NULL";
            DataTable dt = MyDB.GetDataTable(querry);

            if(dt.Rows.Count > 0)
            {
                return GetParking(dt)[0];
            }
            return null;
        }

        public static bool SetParkingForCheckOut(string vehicleId, DateTime checkOut)
        {
            string querry = $"UPDATE Parking SET CheckOut = '{checkOut.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE VehicleID = '{vehicleId}'";
            return MyDB.ExecuteNonQuery(querry);
        }

        public static bool SetParkingForCheckOutForBicycle(string vehicleId, DateTime checkOut)
        {
            string querry = $"UPDATE Parking SET CheckOut = '{checkOut.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ParkingId = '{vehicleId}'";
            return MyDB.ExecuteNonQuery(querry);
        }

        public static bool InsertParking(Parking_DTO newParking)
        {
            if(Vehicle_Parking_DAL.InsertVehicleParking(newParking.Vehicle))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "INSERT INTO PARKING VALUES (@PARKINGID, @VEHICLEID, @PARKAREAID, @CHECKIN, @CHECKOUT)";
                sqlCommand.Parameters.AddWithValue("@PARKINGID", newParking.ParkingId);
                sqlCommand.Parameters.AddWithValue("@VEHICLEID", newParking.Vehicle.VehicleId);
                sqlCommand.Parameters.AddWithValue("@PARKAREAID", newParking.ParkArea.ParkAreaId);
                sqlCommand.Parameters.AddWithValue("@CHECKIN", newParking.CheckIn.ToString("yyyy-MM-dd HH:mm:ss"));
                sqlCommand.Parameters.AddWithValue("@CHECKOUT", DBNull.Value);
                return MyDB.ExecuteNonQuery(sqlCommand);
            }
            return false;
        }
    }
}
