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
    public class Schedule_BUL
    {
        public static List<Schedule_DTO> GetSchedule()
        {
            return Schedule_DAL.GetSchedule();
        }
        public static Schedule_DTO GetSchedule(string scheduleId)
        {
            return Schedule_DAL.GetSchedule(scheduleId);
        }

        public static bool InsertSchedule(Schedule_DTO newSchedule)
        {
            return Schedule_DAL.InsertSchedule(newSchedule);
        }

        public static List<Schedule_DTO> GetSchedule(DateTime dateStart, DateTime dateEnd)
        {
            return Schedule_DAL.GetSchedule(dateStart, dateEnd);
        }

        public static bool CheckInWorker(string scheduleId)
        {
            return Schedule_DAL.CheckInWorker(scheduleId);
        }
    }
}
