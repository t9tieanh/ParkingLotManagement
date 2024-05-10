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
    public class Service_BUL
    {
        public static List<Service_DTO> GetService(string typeVehical, string type)
        {
            return DAL.Service_DAL.GetService(typeVehical,type);
        }
        public static List<Service_DTO> GetServicesByType(string type)
        {
            return Service_DAL.GetServicesByType(type);
        }
        /// <summary>
        /// chỉ sửa được giá dịch vụ, mô tả, thời gian của dịch vụ đó 
        /// </summary>
        /// <param name="newService"></param>
        /// <returns></returns>
        public static bool UpdateService(Service_DTO newService)
        {
            return DAL.Service_DAL.UpdateService(newService);
        }
        public static bool InsertService(Service_DTO newService)
        {
            return DAL.Service_DAL.InsertService(newService);
        }
        #region Delete Service (chưa làm xong)
        public static bool DeleteService(Service_DTO newService)
        {
            return Service_DAL.DeleteService(newService);
        }
        #endregion
    }
}
