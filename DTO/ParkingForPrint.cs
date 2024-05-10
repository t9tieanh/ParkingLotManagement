using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ParkingForPrint
    {
        public static double Renuve;
        private string vehicleId;
        private string checkIn;
        private string checkOut;
        private double price;

        public ParkingForPrint(string vehicleId, string checkIn, string checkOut, double price)
        {
            VehicleId = vehicleId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Price = price;
        }

        public string VehicleId { get => vehicleId; set => vehicleId = value; }
        public string CheckIn { get => checkIn; set => checkIn = value; }
        public string CheckOut { get => checkOut; set => checkOut = value; }
        public double Price { get => price; set => price = value; }
    }
}
