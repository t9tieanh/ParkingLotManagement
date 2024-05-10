using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Worker_DAL
    {
        #region
        /// <summary>
        /// get Worker 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private static List<DTO.Worker_DTO> GetWorker(DataTable dt)
        {
            List<DTO.Worker_DTO> myWorker = new List<DTO.Worker_DTO>();
            if (dt != null)
            {
                /*for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string WorkerID = dt.Rows[i][0].ToString();
                    string FullName = dt.Rows[i][1].ToString();
                    string Address = dt.Rows[i][2].ToString();
                    byte[] pic = (byte[])dt.Rows[i][3];
                    MemoryStream Picture = new MemoryStream(pic);
                    string Type = dt.Rows[i][4].ToString();
                    string ParkAreaId = dt.Rows[i][5].ToString();
                    string AddressParkArea = dt.Rows[i][6].ToString();
                    bool status = Convert.ToBoolean(dt.Rows[i][7].ToString());
                    Account_DTO myAccount = null;
                    if (status)
                        myAccount = Account_DAL.GetAccouts(WorkerID, "Worker");

                    myWorker.Add(new DTO.Worker_DTO(WorkerID, FullName, Address, Picture, Type, new ParkArea_DTO(ParkAreaId, AddressParkArea), status, myAccount));
                }*/
                foreach (DataRow row in dt.Rows)
                {
                    string WorkerID = row[0].ToString();
                    string FullName = row[1].ToString();
                    string Address = row[2].ToString();

                    byte[] pic = row[3] != DBNull.Value ? (byte[])row[3] : null;
                    MemoryStream Picture = pic != null ? new MemoryStream(pic) : null;

                    string Type = row[4].ToString();
                    string ParkAreaId =  row[5] == null ? null : row[5].ToString();
                    ParkArea_DTO myParkArea = null;
                    if (ParkAreaId != null)
                    {
                        myParkArea = DAL.ParkArea_DAL.GetParkArea(ParkAreaId,true);
                    }
                    bool status = Convert.ToBoolean(row[6].ToString());
                    Account_DTO myAccount = null;
                    if (status)
                        myAccount = Account_DAL.GetAccouts(WorkerID, "Worker");
                    myWorker.Add(new DTO.Worker_DTO(WorkerID, FullName, Address, Picture, Type, myParkArea, status, myAccount));
                }
            }
            return myWorker;
        }
        public static Worker_DTO GetWorker(string workerId)
        {
            /*string querry = "SELECT WORKERID AS [ID Worker], FULLNAME AS [Full Name] " +
                ",WORKER.ADDRESS AS [Address], Picture,Worker.Type AS [Worker Type], WORKER.PARKAREAID AS [Workplace], PARKAREA.Address, WORKER.STATUS " +
                "FROM WORKER, PARKAREA " +
                $" WHERE WORKER.workerId = '{workerId}' AND WORKER.PARKAREAID = PARKAREA.PARKAREAID";
            DataTable dt = MyDB.GetDataTable(querry);

            var workers = GetWorker(dt);
            if (workers.Count == 0) 
                return new Worker_DTO();
            else return workers[0];*/
            string querry = $"SELECT * FROM WORKER WHERE WORKERID = '{workerId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            var Workerlst = GetWorker(dt);
            if (Workerlst.Count == 0)
                return null;
            return Workerlst[0];
        }
        public static List<DTO.Worker_DTO> GetWorker()
        {
            string querry = "SELECT * FROM WORKER WHERE STATUS = 1";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        }
        public static List<DTO.Worker_DTO> GetWorker(string type, string parkArea)
        {
            string querry = $"SELECT * FROM WORKER WHERE TYPE = '{type}' AND PARKAREAID = '{parkArea}' AND STATUS = 1";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        }
        public static List<DTO.Worker_DTO> GetWorker(ParkArea_DTO myParkArea)
        {
            string querry = $"SELECT * FROM WORKER WHERE PARKAREAID = '{myParkArea.ParkAreaId}' AND STATUS = 1";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        }

        public static List<DTO.Worker_DTO> GetWorkerWithTypeAndParkArea(string type, string parkAreaId)
        {
            string querry = $"SELECT * FROM WORKER WHERE  TYPE = '{type}' AND STATUS = 1 AND ParkAreaID = {parkAreaId} ";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        }
        public static List<DTO.Worker_DTO> GetWorkerWithType(string type)
        {
            string querry = $"SELECT * FROM WORKER WHERE  TYPE = '{type}' AND STATUS = 1 ";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        }

        public static List <Worker_DTO> SearchWorker (string field, string value) 
        {
            string querry = $"SELECT * FROM WORKER WHERE {field} LIKE '%{value}%' AND STATUS = 1";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetWorker(dt);
        } 
        public static DataTable GetDataWorker()
        {
            string querry = "SELECT WORKERID AS [ID Worker], FULLNAME AS [Full Name] " +
                 ",WORKER.ADDRESS AS [Address], Picture,Worker.Type AS [Worker Type], WORKER.PARKAREAID AS [Workplace], PARKAREA.Address " +
                 "FROM WORKER, PARKAREA " +
                 " WHERE WORKER.STATUS = 1 AND WORKER.PARKAREAID = PARKAREA.PARKAREAID";
            DataTable dt = MyDB.GetDataTable(querry);
            return dt;
        }
        #endregion


        #region Add worker
        public static bool InsertWorker(Worker_DTO newWorker)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO WORKER VALUES (@WORKERID, @FULLNAME, @ADDRESS, @PICTURE, @TYPE, @PARKAREAID, @STATUS)";
            sqlCommand.Parameters.AddWithValue("@WORKERID", newWorker.WorkerId);
            sqlCommand.Parameters.AddWithValue("@FULLNAME", newWorker.FullName);
            sqlCommand.Parameters.AddWithValue("@ADDRESS", newWorker.Address);
            sqlCommand.Parameters.AddWithValue("@TYPE", newWorker.Type);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", newWorker.ParkArea.ParkAreaId);
            sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = newWorker.Picture.ToArray();
            if (!MyDB.ExecuteNonQuery(sqlCommand)) 
                return false;
            Account_DAL.InsertAccount(newWorker.Account);
            return true;
        }
        #endregion

        #region Update Worker
        public static bool UpdateWorker(Worker_DTO newWorker)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE WORKER SET FULLNAME = @FULLNAME, ADDRESS = @ADDRESS, PICTURE = @PICTURE, TYPE = @TYPE, PARKAREAID = @PARKAREAID WHERE WORKERID = @WORKERID";
            sqlCommand.Parameters.AddWithValue("@WORKERID", newWorker.WorkerId);
            sqlCommand.Parameters.AddWithValue("@FULLNAME", newWorker.FullName);
            sqlCommand.Parameters.AddWithValue("@ADDRESS", newWorker.Address);
            sqlCommand.Parameters.AddWithValue("@TYPE", newWorker.Type);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", newWorker.ParkArea.ParkAreaId);
            sqlCommand.Parameters.Add("@PICTURE", SqlDbType.Image).Value = newWorker.Picture.ToArray();
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion


        #region Delete worker
        public static bool DeleteWorker(Worker_DTO myWorker)
        {
            if (!Account_DAL.DeleteAccount(myWorker.Account))
                return false;
            string query = $"UPDATE WORKER SET STATUS = 0 WHERE WORKERID = '{myWorker.WorkerId}'";
            if (!MyDB.ExecuteNonQuery(query)) return false;
            return true;
        }
        #endregion

        #region tiến hành update ParkAreaId = null cho worker (sử dụng khi xóa bãi giữ xe)
        public static bool UpdateWokerParkAreaId (string parkAreaId)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE WORKER SET PARKAREAID = @PARKAREAID WHERE PARKAREAID = '{parkAreaId}'";
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", DBNull.Value);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion
    }
}
