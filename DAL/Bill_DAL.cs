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
    public class Bill_DAL
    {
        /// <summary>
        /// lấy data của Bill từ datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isContractDetail">có lấy các thông tin contractDetail hay không ?</param>
        /// <returns></returns>
        private static List<Bill_DTO> GetBill(DataTable dt)
        {
            List<Bill_DTO> myBill = new List<Bill_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string billId = row[0]?.ToString();
                    string contractId = row[1]?.ToString().Trim();
                    DateTime payDate = (DateTime)row[2];
                    double paymentAmount = (row[3] == DBNull.Value) ? 0 : Convert.ToInt32 (row[3]);
                    // lấy dũ liệu từ contract 
                    var contract = DAL.Contract_DAL.GetContract(contractId);
                    myBill.Add(new Bill_DTO(billId, contract, payDate,paymentAmount));
                }
            }
            return myBill;
        }
        public static Bill_DTO GetBill(string billId)
        {
            string querry = "SELECT * FROM [BILL] WHERE " +
                $" BILL.BILLID = '{billId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetBill (dt)[0];
        }
        public static bool InsertBill (Bill_DTO newBill)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO [BILL]  VALUES (@BILLID, @CONTRACTID, @PAYDATE, @PaymentAmount)";
            sqlCommand.Parameters.AddWithValue("@BILLID", newBill.BillId);
            sqlCommand.Parameters.AddWithValue("@CONTRACTID", newBill.MyContract.ContractId);
            sqlCommand.Parameters.AddWithValue("@PAYDATE", newBill.PayDate.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@PaymentAmount", newBill.PaymentAmount);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        // dùng cho thống kê contract 
        public static double RevenueBillMonth(int month)
        {
            DateTime start = new DateTime(DateTime.Now.Year, month, 1);
            string query = $"SELECT SUM(Bill.PaymentAmount) FROM Bill " +
                $"WHERE Bill.PayDate >= '{start.ToString("yyyy-MM-dd")}' AND Bill.PayDate <= '{start.AddMonths(1).ToString("yyyy-MM-dd")}'";
            double x = MyDB.ExecuteScalarDouble(query);
            return MyDB.ExecuteScalarDouble(query);
        }
    }
}
