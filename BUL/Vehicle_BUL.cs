using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Vehicle_BUL
    {
        public static bool checkVehicle(string vehicleId)
        {
            return DAL.Vehical_DAL.checkVehicle (vehicleId);
        }
        public static Vehical_DTO GetMyVehicle(string vehicleId)
        {
            return Vehical_DAL.GetMyVehicle (vehicleId);
        }
        /// <summary>
        /// lấy những xe có trong hợp đồng có serviceType = ServiceType 
        /// ví dụ lấy những xe có hợp đồng thuê mượn 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Vehical_DTO> GetMyVehicleForContract(string ServiceType)
        {
            return Vehical_DAL.GetMyVehicleForContract (ServiceType);
        }
        /// <summary>
        /// lấy những xe đang nằm dưới quyền quản lý của công ty 
        /// </summary>
        /// <returns></returns>
        public static List<Vehical_DTO> GetMyVehicleForContract()
        {
            return Vehical_DAL.GetMyVehicleForContract();
        }
    }
}
