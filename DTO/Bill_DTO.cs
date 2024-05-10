using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill_DTO
    {
        private string billId;
        private Contract_DTO myContract;
        private DateTime payDate;
        private double paymentAmount;

        public Bill_DTO(string billId, Contract_DTO myContract, DateTime payDate, double paymentAmount)
        {
            BillId = billId;
            MyContract = myContract;
            PayDate = payDate;
            PaymentAmount = paymentAmount;
        }
        public Bill_DTO(string billId, Contract_DTO myContract, DateTime payDate)
        {
            BillId = billId;
            MyContract = myContract;
            PayDate = payDate;
        }
        public Bill_DTO(Contract_DTO myContract, DateTime payDate, double paymentAmount)
        {
            BillId = myContract.ContractId + payDate.ToString("yyyy-MM-dd");
            MyContract = myContract;
            PayDate = payDate;
            PaymentAmount = paymentAmount;  
        }

        public string BillId { get => billId; set => billId = value; }
        public Contract_DTO MyContract { get => myContract; set => myContract = value; }
        public DateTime PayDate { get => payDate; set => payDate = value; }
        public double PaymentAmount { get => paymentAmount; set => paymentAmount = value; }

        public override string ToString()
        {
            return myContract.ContractId  + PayDate.ToString ("yyyy-MM-dd");
        }
    }
}
