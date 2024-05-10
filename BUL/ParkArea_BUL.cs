using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ParkArea_BUL
    {
        public static bool InsertParkArea(ParkArea_DTO newParkArea)
        {
            return DAL.ParkArea_DAL.InsertParkArea(newParkArea);
        }
        public static List<ParkArea_DTO> GetParkArea()
        {
            return DAL.ParkArea_DAL.GetParkArea();
        }
        public static List<ParkArea_DTO> GetParkArea(string type)
        {
            return DAL.ParkArea_DAL.GetParkArea(type);
        }
        public static bool checkAddress(string Address)
        {
            return DAL.ParkArea_DAL.checkAddress(Address);
        }
        public static bool DeleteParkArea(string parkAreaId)
        {
            return DAL.ParkArea_DAL.DeleteParkArea(parkAreaId);
        }
        public static bool UpdateParkArea(ParkArea_DTO parkArea)
        {
            return DAL.ParkArea_DAL.UpdateParkArea(parkArea);
        }

        public static ParkArea_DTO GetParkArea(string parkAreaId, bool isParkArea)
        {
            return ParkArea_DAL.GetParkArea(parkAreaId, isParkArea);
        }
    }
}
