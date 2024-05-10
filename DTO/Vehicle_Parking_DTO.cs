using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vehicle_Parking_DTO
    {
        private string vehicleId;
        private MemoryStream pictureCustomer;
        private MemoryStream pictureVehicle;
        private string model;
        string type; // xe đạp xe máy xe hơi 

        public Vehicle_Parking_DTO(string vehicleId, MemoryStream pictureCustomer, MemoryStream pictureVehicle, string model, string type)
        {
            VehicleId = vehicleId;
            PictureCustomer = pictureCustomer;
            PictureVehicle = pictureVehicle;
            Model = model;
            Type = type;
        }

        public string VehicleId { get => vehicleId; set => vehicleId = value; }
        public MemoryStream PictureCustomer { get => pictureCustomer; set => pictureCustomer = value; }
        public MemoryStream PictureVehicle { get => pictureVehicle; set => pictureVehicle = value; }
        public string Model { get => model; set => model = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return VehicleId + " " + Model +" " + Type;
        }
    }
}
