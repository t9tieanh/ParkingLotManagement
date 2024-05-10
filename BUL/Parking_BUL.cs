using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Parking_BUL
    {
        public static bool InsertParking(Parking_DTO newParking)
        {
            return DAL.Parking_DAL.InsertParking(newParking);
        }

        public static Parking_DTO GetParkingToCheckOut(string vehicleId)
        {
            return DAL.Parking_DAL.GetParkingToCheckOut(vehicleId);
        }

        public static bool SetCheckOutTimeForVehicle(string vehicleId, DateTime checkOut)
        {
            return DAL.Parking_DAL.SetParkingForCheckOut(vehicleId, checkOut);
        }
        // dùng cho lấy thông tin 
        public static List<Parking_DTO> GetParkingForAdmin(ParkArea_DTO parkArea)
        {
            return Parking_DAL.GetParkingForAdmin(parkArea);
        }
        public static List<Parking_DTO> GetParkingCheckInForAdmin(ParkArea_DTO parkArea, DateTime start)
        {
            return Parking_DAL.GetParkingCheckInForAdmin (parkArea, start);
        }
        public static List<Parking_DTO> GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, DateTime start)
        {
            return Parking_DAL.GetParkingCheckOutForAdmin (parkArea, start);
        }
        public static List<Parking_DTO> GetParkingCheckInForAdmin(ParkArea_DTO parkArea, DateTime start, string vehicleId)
        {
            return Parking_DAL.GetParkingCheckInForAdmin (parkArea,start,vehicleId);    
        }
        public static List<Parking_DTO> GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, DateTime start, string vehicleId)
        {
            return Parking_DAL.GetParkingCheckOutForAdmin(parkArea, start, vehicleId);
        }
        public static int GetParkingCheckInForAdmin(ParkArea_DTO parkArea, int Month)
        {
            return Parking_DAL.GetParkingCheckInForAdmin(parkArea, Month);
        }
        public static int GetParkingCheckOutForAdmin(ParkArea_DTO parkArea, int Month)
        {
            return Parking_DAL.GetParkingCheckOutForAdmin (parkArea, Month);
        }
        public static double GetParkingRevenueForAdmin(ParkArea_DTO parkArea, int Month)
        {
            return Parking_DAL.GetParkingRevenueForAdmin (parkArea, Month);
        }

        public static List<Parking_DTO> GetParking()
        {
            return DAL.Parking_DAL.GetParking();
        }

        public static Parking_DTO GetParking(string parkingId)
        {
            return DAL.Parking_DAL.GetParking(parkingId);
        }
        public static Parking_DTO GetParking(string parkingId, bool isCheck)
        {
            return DAL.Parking_DAL.GetParking (parkingId, isCheck); 
        }
    }
}
