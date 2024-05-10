using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RentalManagement_DAL
    {
        private static List<RentalManagement_DTO> GetRentalManagement(DataTable dt)
        {
            List<RentalManagement_DTO> rentalManagements = new List<RentalManagement_DTO>();
            foreach (DataRow row in dt.Rows)
            {
                string rentalManagement = row[0].ToString();
                string ContractId = row[1].ToString();
                DateTime startDate = (DateTime) row[2];
                DateTime endDate = (DateTime)row[3];    
                var myContract = DAL.Contract_DAL.GetContract(ContractId);
                rentalManagements.Add(new RentalManagement_DTO(rentalManagement,myContract,startDate,endDate));
            }
            return rentalManagements;
        }
        /// <summary>
        /// lấy rentailmanaagerment để xác nhận hợp đồng cho khách (hàm này admin dùng)
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <param name="startDay"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static RentalManagement_DTO GetRentalManagementForAdmin (string idVehicle, DateTime startDay, DateTime endDate)
        {
            string querry = "SELECT RentalManagement.IdRentalManagement, RentalManagement.ContractID, RentalManagement.AvailableStartDay, RentalManagement.AvailableEndDay  " +
                "FROM [Contract] INNER JOIN RentalManagement ON Contract.ContractID = RentalManagement.ContractID " +
                $"WHERE Contract.VehicleID = '{idVehicle}' and RentalManagement.AvailableStartDay <= '{startDay.ToString("yyyy-MM-dd")}' and RentalManagement.AvailableEndDay >= '{endDate.ToString("yyyy-MM-dd")}'";
            var lstRentail = GetRentalManagement(MyDB.GetDataTable(querry));
            if (lstRentail.Count == 0)
                return null;
            else return lstRentail[0];
        }
        /// <summary>
        /// lấy tất cả rentailmanagerment có sẵn trong công ty
        /// </summary>
        /// <param name="idVehicle"></param>
        /// <param name="startDay"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<RentalManagement_DTO> GetRentalManagement ()
        {
            string querry = "SELECT * " +
                "FROM RentalManagement ";
                /*$"WHERE AvailableStartDay <= '{startDay.ToString("yyyy-MM-dd")}' AND AvailableEndDay >= '{endDate.ToString("yyyy-MM-dd")}' AND   " +
                "RentalManagement.ContractID = ANY (" +
                                                    $"SELECT Contract.ContractID FROM Contract JOIN Vehicle ON Contract.VehicleID = Vehicle.VehicleID WHERE Vehicle.Type = '{type}')";*/
            return GetRentalManagement(MyDB.GetDataTable(querry));
        }
        public static List<RentalManagement_DTO> GetRentalManagement(string typeVehicle)
        {
            string querry = "SELECT * " +
                "FROM RentalManagement WHERE " +
                "RentalManagement.ContractID = ANY (" +
                $"SELECT Contract.ContractID FROM Contract JOIN Vehicle ON Contract.VehicleID = Vehicle.VehicleID WHERE Vehicle.Type = '{typeVehicle}')";
            /*$"WHERE AvailableStartDay <= '{startDay.ToString("yyyy-MM-dd")}' AND AvailableEndDay >= '{endDate.ToString("yyyy-MM-dd")}' AND   " +
            "RentalManagement.ContractID = ANY (" +
                                                $"SELECT Contract.ContractID FROM Contract JOIN Vehicle ON Contract.VehicleID = Vehicle.VehicleID WHERE Vehicle.Type = '{type}')";*/
            return GetRentalManagement(MyDB.GetDataTable(querry));
        }
        public static List <RentalManagement_DTO> GetRentalManagement (string type,DateTime startDay, DateTime endDate) 
        {
            /*string querry = "SELECT * FROM " +
                $"WHERE StartDay <= '{startDay.ToString("yyyy-MM-dd")}' and EndDay >= '{endDate.ToString("yyyy-MM-dd")}' " +
                $"AND Vehicle.Type = N'{type}' ";*/
            string querry = "SELECT * " +
                "FROM RentalManagement " +
                $"WHERE AvailableStartDay <= '{startDay.ToString("yyyy-MM-dd")}' AND AvailableEndDay >= '{endDate.ToString("yyyy-MM-dd")}' AND   " +
                "RentalManagement.ContractID = ANY (" +
                                                    $"SELECT Contract.ContractID FROM Contract JOIN Vehicle ON Contract.VehicleID = Vehicle.VehicleID WHERE Vehicle.Type = '{type}')";
            return GetRentalManagement(MyDB.GetDataTable(querry));
        }
        public static bool InsertRentalManagement (RentalManagement_DTO newRentalManagement)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO RentalManagement VALUES (@IdRentalManagement, @ContractID, @StartDay, @EndDay)";
            sqlCommand.Parameters.AddWithValue("@IdRentalManagement", newRentalManagement.IdRentalManagement);
            sqlCommand.Parameters.AddWithValue("@ContractID", newRentalManagement.MyContract.ContractId);
            sqlCommand.Parameters.AddWithValue("@StartDay", newRentalManagement.StartDay.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@EndDay", newRentalManagement.EndDay.ToString("yyyy-MM-dd"));
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool DeleteRentalManagement(string idRentalManagement)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM RentalManagement WHERE IdRentalManagement = @IdRentalManagement";
            sqlCommand.Parameters.AddWithValue("@IdRentalManagement", idRentalManagement);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        /// <summary>
        /// dùng để xác nhận hợp đồng 
        /// </summary>
        /// <param name="myContract"></param>
        /// <returns></returns>
        public static bool DeleteRentalManagement(Contract_DTO myContract)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM RentalManagement WHERE ContractID = @ContractID";
            sqlCommand.Parameters.AddWithValue("@ContractID", myContract.ContractId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
