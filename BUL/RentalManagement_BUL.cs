using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class RentalManagement_BUL
    {
        public static List<RentalManagement_DTO> GetRentalManagement(string type, DateTime startDay, DateTime endDate)
        {
            return DAL.RentalManagement_DAL.GetRentalManagement (type, startDay, endDate);
        }
        /// <summary>
        /// lấy tất cả rentailmanagerment có sẵn trong công ty
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <param name="startDay"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<RentalManagement_DTO> GetRentalManagement()
        {
            return RentalManagement_DAL.GetRentalManagement();
        }
        public static bool InsertRentalManagement(RentalManagement_DTO newRentalManagement)
        {
            return DAL.RentalManagement_DAL.InsertRentalManagement (newRentalManagement);
        }
        public static bool DeleteRentalManagement(string idRentalManagement)
        {
            return DAL.RentalManagement_DAL.DeleteRentalManagement(idRentalManagement);
        }
        /// <summary>
        /// lấy rentailmanaagerment để xác nhận hợp đồng cho khách (hàm này admin dùng)
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <param name="startDay"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static RentalManagement_DTO GetRentalManagementForAdmin(string idVehicle, DateTime startDay, DateTime endDate)
        {
            return RentalManagement_DAL.GetRentalManagementForAdmin (idVehicle, startDay, endDate);
        }
        public static List<RentalManagement_DTO> GetRentalManagement(string typeVehicle)
        {
            return RentalManagement_DAL.GetRentalManagement(typeVehicle);
        }
    }
}
