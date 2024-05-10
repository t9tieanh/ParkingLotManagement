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
    public class Customer_BUL
    {
        public static Customer_DTO GetCustomer(string customerId)
        {
            return Customer_DAL.GetCustomer(customerId);
        }
        public static List<Customer_DTO> GetCustomer()
        {
            return DAL.Customer_DAL.GetCustomer();
        }
        public static List<Customer_DTO> SearchCustomer(string customerName)
        {
            return Customer_DAL.SearchCustomer(customerName);
        }
        public static bool InsertCustomer(Customer_DTO myCustomer)
        {
            return Customer_DAL.InsertCustomer(myCustomer);
        }
        public static bool UpdateCustomer(Customer_DTO myCustomer)
        {
            return Customer_DAL.UpdateCustomer(myCustomer);
        }
    }
}
