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
    public class Contract_BUL
    {
        public static bool InsertContract(Contract_DTO newContract)
        {
            return DAL.Contract_DAL.InsertContract(newContract);
        }
        public static bool InsertContractBorrow(Contract_DTO newContract)
        {
            return DAL.Contract_DAL.InsertContractBorrow(newContract);
        }
        #region Add ContractDetail
        /*public static bool InsertContractDetail(ContractDetail_DTO newConTractDetail, bool isServiceRenter)
        {
            return DAL.Contract_DAL.InsertContractDetail(newConTractDetail, isServiceRenter);
        }*/
        #endregion

        // lấy các contract đã xác nhận
        public static List<Contract_DTO> GetContract(int status)
        {
            return DAL.Contract_DAL.GetContract(status);
        }
        // dùng cho việc xác nhận hợp đồng form main admin
        public static Contract_DTO GetContract(string contractId)
        {
            return Contract_DAL.GetContract(contractId);
        }
        public static bool ConfirmContract(Contract_DTO myContract)
        {
            return DAL.Contract_DAL.ConfirmContract(myContract);
        }
        /// <summary>
        /// lấy những hợp đồng thuộc về customer 
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        public static List<Contract_DTO> GetContractCustomer (Customer_DTO customer, int status)
        {
            return DAL.Contract_DAL.GetContract(customer,status);
        }
        /// <summary>
        /// lấy những hợp đồng thuộc về parkArea
        /// </summary>
        /// <param name="parkArea"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Contract_DTO> GetContract(ParkArea_DTO parkArea, int status)
        {
            return Contract_DAL.GetContract(parkArea, status);
        }
        // dùng datetime chống cháy (lấy những hợp đồng có trong tháng time )
        public static List<Contract_DTO> GetContract(DateTime start)
        {
            return Contract_DAL.GetContract(start);
        }
        // lấy những hợp đồng có xe là vehicle
        public static List<Contract_DTO> GetContract(Vehical_DTO vehical)
        {
            return Contract_DAL.GetContract(vehical);
        }
        public static List<Contract_DTO> GetContract(Vehical_DTO vehical, DateTime start, DateTime end)
        {
            return Contract_DAL.GetContract(vehical,start,end);
        }
        // lấy số lượng hợp đồng có status = status trong tháng 
        public static int CountContractStatus(int status, int month)
        {
            return Contract_DAL.CountContractStatus (status,month);
        }
        /// <summary>
        /// xác nhận hợp đồng đã xong và sẵn sàng giao cho khách 
        /// </summary>
        /// <param name="myContract"></param>
        /// <returns></returns>
        public static bool ConfirmContractCompletion(Contract_DTO myContract)
        {
            return  DAL.Contract_DAL.ConfirmContractCompletion(myContract);
        }
        // sử dụng bởi customer khi contract chưa được xác nhận bởi admin 
        public static bool DeleteContract(Contract_DTO myContract)
        {
            return DAL.Contract_DAL.DeleteContract(myContract);
        }
        // khách hàng xác nhận thanh toán cho contract -> status = 3 
        public static bool ContractPayment(Contract_DTO myContract,Bill_DTO myBill)
        {
            return Contract_DAL.ContractPayment(myContract,myBill);
        }
        /// <summary>
        /// tìm kiếm những hợp đồng của khách hàng có tên là ...
        /// </summary>
        /// <param name="fullNameCustomer"></param>
        /// <returns></returns>
        public static List<Contract_DTO> SearchContract(Customer_DTO myCustomer)
        {
            return Contract_DAL.SearchContract(myCustomer);
        }
        public static List<Contract_DTO> SearchContract(Vehical_DTO myVehicle)
        {
            return Contract_DAL.SearchContract(myVehicle);
        }
        // thống kê cho contract 
        public static int CountContractType(string typeService,int month)
        {
            return Contract_DAL.CountContractType(typeService,month);
        }
        public static int CountContractMonth(int month)
        {
            return Contract_DAL.CountContractMonth(month);
        }
        //
    }
}
