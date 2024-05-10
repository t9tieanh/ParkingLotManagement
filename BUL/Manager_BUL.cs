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
    public class Manager_BUL
    {
        public static Manager_DTO GetManager (string managerId)
        {
            return Manager_DAL.GetManager (managerId);
        }
        public static List<Manager_DTO> GetManager()
        {
            return Manager_DAL.GetManager();
        }
        public static bool UpdateManager(Manager_DTO manager)
        {
            return Manager_DAL.UpdateManager (manager);
        }
        public static bool InsertManager(Manager_DTO manager)
        {
            return Manager_DAL.InsertManager (manager);
        }
        public static bool DeleteManager(Manager_DTO manager)
        {
            return Manager_DAL.DeleteManager (manager);
        }
    }
}
