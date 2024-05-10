using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Worker_BUL
    {
        public static DTO.Worker_DTO GetWorker(string idWorker)
        {
            return DAL.Worker_DAL.GetWorker(idWorker);
        }
        //
        public static List<DTO.Worker_DTO> GetWorker()
        {
            return DAL.Worker_DAL.GetWorker();
        }
        public static List<DTO.Worker_DTO> GetWorker(string type, string parkArea)
        {
            return DAL.Worker_DAL.GetWorker(type, parkArea);
        }
        public static List<DTO.Worker_DTO> GetWorker(ParkArea_DTO myParkArea)
        {
            return Worker_DAL.GetWorker(myParkArea);
        }
        public static List<Worker_DTO> SearchWorker(string filed, string value)
        {
            return DAL.Worker_DAL.SearchWorker(filed, value);
        }
        public static bool InsertWorker(Worker_DTO newWorker)
        {
            return DAL.Worker_DAL.InsertWorker(newWorker);
        }
        public static bool UpdateWorker(Worker_DTO newWorker)
        {
            return DAL.Worker_DAL.UpdateWorker(newWorker);
        }
        public static DataTable GetDataWorker()
        {
            return DAL.Worker_DAL.GetDataWorker();
        }
        public static bool DeleteWorker(Worker_DTO worker)
        {
            return DAL.Worker_DAL.DeleteWorker(worker);
        }

        public static List<DTO.Worker_DTO> GetWorkerWithType(string type)
        {
            return DAL.Worker_DAL.GetWorkerWithType(type);
        }

        public static List<DTO.Worker_DTO> GetWorkerWithTypeAndParkArea(string type, string parkAeraId)
        {
            return DAL.Worker_DAL.GetWorkerWithTypeAndParkArea(type, parkAeraId);
        }
    }
}
