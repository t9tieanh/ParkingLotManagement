using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Fee_DTO
    {
        private double feeCar;
        private double feeMoto;
        private double feeBicycle;

        public Fee_DTO(double feeCar, double feeMoto, double feeBicycle)
        {
            FeeCar = feeCar;
            FeeMoto = feeMoto;
            FeeBicycle = feeBicycle;
        }
        public double FeeCalculation (int hour, string typeVehicle)
        {
            double fee;
            if (typeVehicle == "Car") fee = feeCar;
            else if (typeVehicle == "Moto") fee = feeMoto;
            else fee = feeBicycle;
            if (hour == 0) return fee;
            if (hour <= 24 )
            {
                return fee;
            }
            else if (hour > 24 && hour <= 168)
            {
                return (hour/24) * 2 * fee; // phạt khi để quá 24 giờ 
            }
            else if (hour > 168 && hour < 720)
            {
                return (hour/168) * 4 * fee;
                 // phạt khi để quá 1 tuần 
            }
            return (hour/720) * 8 * fee; // phạt khi xe để quá 1 tháng 
        }

        public override string ToString()
        {
            return "feeMoto :" + feeMoto + "\n" + "feeCar: " + FeeCar +"\n" +"feeBicycle" + feeBicycle ;
        }

        public double FeeCar { get => feeCar; set => feeCar = value; }
        public double FeeMoto { get => feeMoto; set => feeMoto = value; }
        public double FeeBicycle { get => feeBicycle; set => feeBicycle = value; }
    }
}
