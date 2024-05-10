using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Schedule_DTO
    {
        private string scheduleID;
        private Worker_DTO workerID;
        private string dayOfWeek;
        private string shift;
        private int status;
        private DateTime dateStart;
        private DateTime dateEnd;

        public Schedule_DTO() { }

        public Schedule_DTO(string scheduleID, Worker_DTO workerID, string dayOfWeek, string shift, int status, DateTime dateStart, DateTime dateEnd)
        {
            ScheduleID = scheduleID;
            WorkerID = workerID;
            DayOfWeek = dayOfWeek;
            Shift = shift;
            Status = status;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }

        public string ScheduleID { get => scheduleID; set => scheduleID = value; }
        public Worker_DTO WorkerID { get => workerID; set => workerID = value; }
        public string DayOfWeek { get => dayOfWeek; set => dayOfWeek = value; }
        public string Shift { get => shift; set => shift = value; }
        public int Status { get => status; set => status = value; }
        public DateTime DateStart { get => dateStart; set => dateStart = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }
    }
}
