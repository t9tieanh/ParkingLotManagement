
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer_DTO
    {
        private string customerId;
        private string fullName;
        private string address;
        private string phone;
        private MemoryStream picture;
        private bool status;
        private Account_DTO account;
        public Customer_DTO(string customerId, string fullName)
        {
            CustomerId = customerId;
            FullName = fullName;
        }
        public Customer_DTO(string customerName)
        {
            FullName = customerName ;
        }
        public Customer_DTO(string customerId, string fullName, MemoryStream Picture)
        {
            CustomerId = customerId;
            FullName = fullName;
            this.Picture = Picture;
        }
        public Customer_DTO(string customerId, string fullName, string address, string phone, MemoryStream picture, bool status,Account_DTO account)
        {
            CustomerId = customerId;
            FullName = fullName;
            Address = address;
            Phone = phone;
            Picture = picture;
            Status = status;
            Account = account;
        }

        public string CustomerId { get => customerId; set => customerId = value.Trim(); }
        public string FullName { get => fullName; set => fullName = value.Trim(); }
        public string Address { get => address; set => address = value.Trim(); }
        public string Phone { get => phone; set => phone = value.Trim(); }
        public MemoryStream Picture { get => picture; set => picture = value; }
        public bool Status { get => status; set => status = value; }
        public Account_DTO Account { get => account; set => account = value; }

        public override string ToString()
        {
            return "Customer " + customerId + fullName;
        }
    }
}
