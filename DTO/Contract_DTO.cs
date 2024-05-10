using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contract_DTO
    {
        private string contractId;
        private Customer_DTO customer;
        private DateTime receiptDate;
        private DateTime deliveryDate;
        private ParkArea_DTO myParkArea;
        private Vehical_DTO myVehical;
        private int status; // trạng thái của contract 
        private List<ContractDetail_DTO> myContractDetail = new List<ContractDetail_DTO>();

        public Contract_DTO()
        {
        }
        public Contract_DTO (Customer_DTO customer)
        {
            this.Customer = customer;
            this.ContractId = customer.CustomerId + DateTime.Now.ToString("dd|MM|yyyy|HH|mm|ss");
        }

        public Contract_DTO(string contractId, Customer_DTO customer, DateTime receiptDate, DateTime deliveryDate, ParkArea_DTO myParkArea, Vehical_DTO myVehical, int status)
        {
            ContractId = contractId;
            Customer = customer;
            ReceiptDate = receiptDate;
            DeliveryDate = deliveryDate;
            MyParkArea = myParkArea;
            MyVehical = myVehical;
            Status = status;
        }
        public Contract_DTO (Customer_DTO customer,DateTime receiptDate, DateTime deliveryDate, Vehical_DTO myVehical, Service_DTO service,ParkArea_DTO myParkArea,int status)
        {
            Customer = customer;
            ReceiptDate = receiptDate;
            DeliveryDate = deliveryDate;
            MyVehical = myVehical;
            this.ContractId = customer.CustomerId + DateTime.Now.ToString("dd|MM|yyyy|HH|mm|ss");
            MyContractDetail.Add(new ContractDetail_DTO(this, service)); // dùng bên mượn xe
            MyParkArea = myParkArea;
            Status = status;
        }
        public Contract_DTO(Customer_DTO customer, Vehical_DTO myVehical, Service_DTO service, ParkArea_DTO myParkArea, int status)
        {
            Customer = customer;
            ReceiptDate = DateTime.MinValue;
            DeliveryDate = DateTime.MinValue;
            MyVehical = myVehical;
            this.ContractId = customer.CustomerId + DateTime.Now.ToString("dd|MM|yyyy|HH|mm|ss");
            //MyContractDetail.Add(new ContractDetail_DTO(this, service)); // dùng bên mượn xe
            MyParkArea = myParkArea;
            Status = status;
        }
        public Contract_DTO(string contractId)
        {
            ContractId = contractId;
        }

        public string StatusToString ()
        {
            if (Status == 0) { return "Contract has not been confirmed"; }
            else if (Status == 1) { return "Contract is being performed"; }
            else if (Status == 2) { return "Contract completed and waiting for payment"; }
            else
            {
                return "The contract has been completed";
            }
        }
        public string StatusToColor()
        {
            return Status == 0 ? "#fab1a0" :
                   Status == 1 ? "#fd79a8" :
                   Status == 2 ? "#74b9ff" :
                                 "#55efc4";
        }

        public string ContractId { get => contractId; set => contractId = value.Trim(); }
        public Customer_DTO Customer { get => customer; set => customer = value; }
        public DateTime ReceiptDate { get => receiptDate.Date; set => receiptDate = value.Date; }
        public DateTime DeliveryDate { get => deliveryDate.Date; set => deliveryDate = value.Date; }
        public ParkArea_DTO MyParkArea { get => myParkArea; set => myParkArea = value; }
        public Vehical_DTO MyVehical { get => myVehical; set => myVehical = value; }
        public int Status { get => status; set => status = value; }
        public List<ContractDetail_DTO> MyContractDetail { get => myContractDetail; set => myContractDetail = value; }
        /*0 : trạng thái người dùng đặt hợp đồng và người quản lý chưa xác nhận #fab1a0 #ff7675
        1 : trạng thái admin đã xác nhận hợp đồng và bắt đầu vào làm việc với hợp đồng đó(đã phân công công việc cho worker ): #fd79a8 #e84393
        2 : trạng thái đã xong và chờ customer thanh toán #74b9ff #0984e3
        3 : trạng thái hợp đồng hoàn tất(customer đã thanh toán cho hợp đồng) #55efc4 #00b894*/
    }
}
