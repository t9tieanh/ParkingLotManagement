using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Schedule_DAL
    {
        private static List<Schedule_DTO> GetSchedule(DataTable dt)
        {
            List<Schedule_DTO> mySchedule = new List<Schedule_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string scheduleId = row[0].ToString();

                    string workerId = row[1].ToString();
                    Worker_DTO myWorker = Worker_DAL.GetWorker(workerId);

                    string dayOfWeek = row[2].ToString();
                    string shift = row[3].ToString();
                    int status = Int32.Parse(row[4].ToString());
                    
                    DateTime dateStart = Convert.ToDateTime(row[5].ToString());
                    DateTime dateEnd = Convert.ToDateTime(row[6].ToString());
                    
                    mySchedule.Add(new Schedule_DTO(scheduleId, myWorker, dayOfWeek, shift, status, dateStart, dateEnd));
                }
            }
            return mySchedule;
        }
        public static List<Schedule_DTO> GetSchedule()
        {
            string querry = "SELECT * FROM Schedule";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetSchedule(dt);
        }

        public static List<Schedule_DTO> GetSchedule(DateTime dateStart, DateTime dateEnd)
        {
            string query = $"SELECT * FROM Schedule WHERE DateStart >= '{dateStart:yyyy-MM-dd}' AND DateEnd <= '{dateEnd:yyyy-MM-dd}'";
            DataTable dt = MyDB.GetDataTable(query);
            return GetSchedule(dt);
        }

        public static Schedule_DTO GetSchedule(string scheduleId)
        {
            string querry = $"SELECT * FROM Schedule WHERE ScheduleID = '{scheduleId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetSchedule(dt)[0];
        }

        public static bool CheckInWorker(string scheduleId)
        {
            string querry = $"UPDATE Schedule SET Status = 1 WHERE ScheduleID = '{scheduleId}'";
            return MyDB.ExecuteNonQuery(querry);
        }

        public static bool InsertSchedule(Schedule_DTO newSchedule)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO Schedule VALUES (@ScheduleID, @WorkerID, @DayOfWeek, @Shift, @Status, @DateStart, @DateEnd)";
            sqlCommand.Parameters.AddWithValue("@ScheduleID", newSchedule.ScheduleID);
            sqlCommand.Parameters.AddWithValue("@WorkerID", newSchedule.WorkerID.WorkerId);
            sqlCommand.Parameters.AddWithValue("@DayOfWeek", newSchedule.DayOfWeek);
            sqlCommand.Parameters.AddWithValue("@Shift", newSchedule.Shift);
            sqlCommand.Parameters.AddWithValue("@Status", newSchedule.Status);
            sqlCommand.Parameters.AddWithValue("@DateStart", newSchedule.DateStart.ToString("yyyy-MM-dd HH:mm:ss"));
            sqlCommand.Parameters.AddWithValue("@DateEnd", newSchedule.DateEnd.ToString("yyyy-MM-dd HH:mm:ss"));
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
