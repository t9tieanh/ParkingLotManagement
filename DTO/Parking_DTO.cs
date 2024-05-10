using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Parking_DTO
    {
        private string parkingId;
        private Vehicle_Parking_DTO vehicle;
        private ParkArea_DTO parkArea;
        private DateTime checkIn;
        private DateTime checkOut;

        public Parking_DTO (string parkingId, Vehicle_Parking_DTO vehicle, ParkArea_DTO parkArea, DateTime checkIn, DateTime checkOut)
        {
            ParkingId = parkingId;
            Vehicle = vehicle;
            ParkArea = parkArea;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public string ParkingId { get => parkingId; set => parkingId = value; }
        public Vehicle_Parking_DTO Vehicle { get => vehicle; set => vehicle = value; }
        public ParkArea_DTO ParkArea { get => parkArea; set => parkArea = value; }
        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }

        public override string ToString()
        {
            return parkingId;
        }
    }
}
