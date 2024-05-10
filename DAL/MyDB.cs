using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MyDB
    {
        private static SqlConnection connection = new SqlConnection(@"Data Source=Tieanh19\SQLEXPRESS;Initial Catalog=ParkingLotManagement;Integrated Security=True");
        //private static SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-HQ296\SQLEXPRESS;Initial Catalog=ParkingLotManagement;Integrated Security=True");
          

        public static SqlConnection Connection { get => connection; }
        private static void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        private static void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public static DataTable GetDataTable(string strCommand)
        {
            try
            {
                SqlCommand sqlcommand = new SqlCommand(strCommand);
                sqlcommand.Connection = connection;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlcommand);
                adapter.Fill(dt);
                return dt;
            }   
            catch { return null; }
        }

        public static bool ExecuteNonQuery(string strCommand)
        {
            SqlCommand sqlCommand = new SqlCommand(strCommand);
            return ExecuteNonQuery(sqlCommand);
        }
        public static bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                OpenConnection();
                command.Connection = connection;
                command.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch
            { return false; }
        }
        public static int ExecuteScalar(string querry)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandText = querry;
                int count = (int)sqlCommand.ExecuteScalar();
                CloseConnection();
                return count;
            }
            catch { return 0; }
        }
        public static double ExecuteScalarDouble (string querry)
        {
            try
            {
                OpenConnection();
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandText = querry;
                double count = (double)sqlCommand.ExecuteScalar();
                CloseConnection();
                return count;
            }
            catch { return 0; }
        }
    }
}
