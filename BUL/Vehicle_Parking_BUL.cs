using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    internal class Vehicle_Parking_BUL
    {
        public static bool InsertVehiclePaking(Vehicle_Parking_DTO newVehicleParking)
        {
            return DAL.Vehicle_Parking_DAL.InsertVehicleParking(newVehicleParking);
        }
    }
}
