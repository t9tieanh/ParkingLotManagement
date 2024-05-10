using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Customer_DAL
    {
        private static List<DTO.Customer_DTO> GetCustomer(DataTable dt)
        {
            List < DTO.Customer_DTO> customers = new List<DTO.Customer_DTO> ();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string CustomerId = row[0]?.ToString();
                    string Fullname = row[1]?.ToString();
                    string Address = row[2]?.ToString();
                    string Phone = row[3]?.ToString();
                    byte[] pic = row[4] != DBNull.Value ? (byte[])row[4] : null;
                    MemoryStream Picture = pic != null ? new MemoryStream(pic) : null;
                    bool status = Convert.ToBoolean(row[5].ToString());
                    Account_DTO myAccount = null;
                    if (status)
                        myAccount = Account_DAL.GetAccouts(CustomerId, "Customer");
                    customers.Add(new Customer_DTO(CustomerId, Fullname, Address, Phone, Picture, status, myAccount));
                }
            }
            return customers;
        }
        public static Customer_DTO GetCustomer(string customerId)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM CUSTOMER WHERE CUSTOMERID = '{customerId}' ");
            return GetCustomer(dt)[0];
        }
        public static List<Customer_DTO> GetCustomer ()
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM CUSTOMER ");
            return GetCustomer(dt);
        }
        public static List<Customer_DTO> SearchCustomer (string customerName)
        {
            DataTable dt = MyDB.GetDataTable($"SELECT * FROM CUSTOMER WHERE FullName LIKE N'%{customerName}%'");
            return GetCustomer(dt);
        }
        public static bool InsertCustomer (Customer_DTO myCustomer)
        {
            if (!Account_DAL.InsertAccount(myCustomer.Account)) return false;
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO CUSTOMER VALUES (@CustomerId, @FullName, @Address, @Phone, @Picture, @STATUS)";
            sqlCommand.Parameters.AddWithValue("@CustomerId", myCustomer.CustomerId);
            sqlCommand.Parameters.AddWithValue("@FullName", myCustomer.FullName);
            sqlCommand.Parameters.AddWithValue("@Address", myCustomer.Address);
            sqlCommand.Parameters.AddWithValue("@Phone", myCustomer.Phone);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            sqlCommand.Parameters.Add("@Picture", SqlDbType.Image).Value = myCustomer.Picture.ToArray();
            if (!MyDB.ExecuteNonQuery(sqlCommand))
                return false;
            Account_DAL.InsertAccount(myCustomer.Account);
            return true;
        }
        public static bool UpdateCustomer (Customer_DTO myCustomer)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE CUSTOMER SET FullName = @FullName, Address = @Address, Phone = @Phone, Picture = @Picture, STATUS = @STATUS WHERE CustomerId = @CustomerId"; 
            sqlCommand.Parameters.AddWithValue("@CustomerId", myCustomer.CustomerId);
            sqlCommand.Parameters.AddWithValue("@FullName", myCustomer.FullName);
            sqlCommand.Parameters.AddWithValue("@Address", myCustomer.Address);
            sqlCommand.Parameters.AddWithValue("@Phone", myCustomer.Phone);
            sqlCommand.Parameters.AddWithValue("@STATUS", true);
            sqlCommand.Parameters.Add("@Picture", SqlDbType.Image).Value = myCustomer.Picture.ToArray();
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
