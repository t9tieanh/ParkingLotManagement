using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using System.Collections;
using System.Threading;

namespace DAL
{
    public class Contract_DAL
    {
        /// <summary>
        /// lấy datacontractdetail từ datatable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isContractDetail">có lấy các thông tin contractDetail hay không ?</param>
        /// <returns></returns>
        private static List<Contract_DTO> GetContract(DataTable dt, bool isContractDetail)
        {
            List<Contract_DTO> myContract = new List<Contract_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string ContractId = row[0]?.ToString();
                    string customerId = row[1]?.ToString().Trim();
                    DateTime receipt = (DateTime)row[2];
                    DateTime delivery = (DateTime)row[3];
                    string parkAreaId = row[4]?.ToString();
                    string VehicleId = row[5]?.ToString().Trim();
                    int status = Convert.ToInt32(row[6]?.ToString());

                    // lấy thông tin customer 
                    Customer_DTO myCustomer = DAL.Customer_DAL.GetCustomer(customerId);

                    //lấy thông tin của vehicle 
                    Vehical_DTO myVehicle = DAL.Vehical_DAL.GetMyVehicle(VehicleId);

                    // lấy thông tin của parkarea 
                    ParkArea_DTO parkArea = DAL.ParkArea_DAL.GetParkArea(parkAreaId, true);

                    Contract_DTO contract = new Contract_DTO(ContractId, myCustomer, receipt, delivery
                        , parkArea, myVehicle, status);
                    if (isContractDetail)
                    {
                        contract.MyContractDetail = DAL.ContractDetail_DAL.GetContractDetail(ContractId);
                        foreach (var contractDetail in contract.MyContractDetail)
                            contractDetail.Contract = contract;
                    }
                    myContract.Add(contract);
                }
            }
            return myContract;
        }
        public static Contract_DTO GetContract(string contractId)
        {
            string querry = "SELECT * FROM Contract WHERE " +
                $" CONTRACT.ContractID = '{contractId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true)[0];
        }
        // dùng datetime chống cháy (lấy những hợp đồng có trong tháng time )
        public static List<Contract_DTO> GetContract(DateTime start)
        {
            string querry = "SELECT * FROM Contract WHERE " +
                $" Contract.ReceiptDate >= '{start.ToString("yyyy-MM-dd")}' AND Contract.ReceiptDate <= '{start.AddMonths(1).ToString("yyyy-MM-dd")}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        /// lấy những hợp đồng thuộc về parkArea
        /// </summary>
        /// <param name="parkArea"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<Contract_DTO> GetContract(ParkArea_DTO parkArea, int status)
        {
            string querry = "SELECT * FROM Contract WHERE " +
                $" CONTRACT.PARKAREAID = '{parkArea.ParkAreaId}' AND CONTRACT.STATUS = '{status}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        /// lấy những hợp đồng thuộc về customer 
        /// </summary>
        /// <param name="customer">customer</param>
        /// <returns></returns>
        public static List<Contract_DTO> GetContract(Customer_DTO customer, int status)
        {
            string querry = "SELECT * FROM Contract WHERE " +
                $" CONTRACT.CUSTOMERID = '{customer.CustomerId}' AND CONTRACT.STATUS = '{status}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        public static List<Contract_DTO> GetContract(int status)
        {
            string querry = $"SELECT * FROM Contract WHERE STATUS = {status}";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        ///  lấy những hợp đồng của xe này 
        /// </summary>
        /// <param name="vehical"></param>
        /// <returns></returns>
        public static List<Contract_DTO> GetContract(Vehical_DTO vehical)
        {
            string querry = $"SELECT * FROM Contract WHERE VehicleID = '{vehical.VehicalId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        public static List<Contract_DTO> GetContract(Vehical_DTO vehical, DateTime start, DateTime end)
        {
            string querry = $"SELECT * FROM Contract WHERE VehicleID = '{vehical.VehicalId}' AND ReceiptDate >= '{start.ToString("yyyy-MM-dd")}' AND DeliveryDate <= '{end.ToString("yyyy-MM-dd")}' ";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        /// tìm kiếm những hợp đồng của khách hàng có tên là ...
        /// </summary>
        /// <param name="fullNameCustomer"></param>
        /// <returns></returns>
        public static List<Contract_DTO> SearchContract(Customer_DTO myCustomer)
        {
            string querry = "SELECT * FROM [Contract] " +
                "WHERE Contract.CustomerId IN " +
                "                           (SELECT CustomerId " +
                "                            FROM Customer " +
                $"                            WHERE Customer.FullName LIKE N'%{myCustomer.FullName}%')";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        ///  Tìm những hợp đồng liên quan đến xe
        /// </summary>
        /// <param name="vehical"></param>
        /// <returns></returns>
        public static List<Contract_DTO> SearchContract(Vehical_DTO vehical)
        {
            string querry = $"SELECT * FROM Contract WHERE VehicleID LIKE '%{vehical.VehicalId}%'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, true);
        }
        /// <summary>
        /// dùng cho contractDetail
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeContract(string contractId)
        {
            string querry = $"SELECT DeliveryDate FROM Contract WHERE CONTRACT.ContractID = '{contractId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return ((DateTime)dt.Rows[0][0]).Date;
        }
        // thống kê cho contract 
        public static int CountContractType(string typeService, int month)
        {
            DateTime start = new DateTime(DateTime.Now.Year, month, 1);
            string querry = "SELECT COUNT (*) " +
                "FROM Contract " +
                $"WHERE Contract.ReceiptDate >= '{start.ToString("yyyy-MM-dd")}' AND Contract.ReceiptDate <= '{start.AddMonths(1).ToString("yyyy-MM-dd")}' AND ContractID IN " +
                    "(SELECT DISTINCT ContractDetail.ContractID " +
                    "FROM ContractDetail, [Service] " +
                    $"WHERE ContractDetail.ServiceId = Service.ServiceId AND Service.Type = N'{typeService}')";
            return MyDB.ExecuteScalar(querry);
        }
        public static int CountContractMonth(int month)
        {
            DateTime start = new DateTime(DateTime.Now.Year, month, 1);
            string query = $"SELECT COUNT(*) FROM Contract WHERE Contract.ReceiptDate >= '{start.ToString("yyyy-MM-dd")}' AND Contract.ReceiptDate <= '{start.AddMonths(1).ToString("yyyy-MM-dd")}'";
            return MyDB.ExecuteScalar(query);
        }
        // lấy số lượng hợp đồng có status = status trong tháng 
        public static int CountContractStatus (int status, int month) {
            DateTime start = new DateTime(DateTime.Now.Year, month, 1);
            string query = $"SELECT COUNT(*) FROM Contract WHERE Contract.ReceiptDate >= '{start.ToString("yyyy-MM-dd")}' AND Contract.ReceiptDate <= '{start.AddMonths(1).ToString("yyyy-MM-dd")}' AND STATUS = '{status}'";
            return MyDB.ExecuteScalar(query);
        }
        #region hàm dành riêng cho contractDetail sử dụng để lấy data
        /// <summary>
        /// hàm dưới đây dùng cho contractDetail gọi -> để đổ data contract vào contractDetail
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static Contract_DTO GetContract (ContractDetail_DTO contractDetail)
        {
            string querry = "SELECT * FROM Contract WHERE " +
                 $" CONTRACT.ContractID = '{contractDetail.Contract.ContractId}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContract(dt, false)[0];
        }
        #endregion  

        // dành cho các loại contract trừ contract mượn xe từ công ty -> phải thêm vehicle
        public static bool InsertContract(Contract_DTO newContract)
        {
            //step 1 : thêm vehical 
            if (Vehical_DAL.InsertVehicle(newContract.MyVehical))
            {
                return InsertContractBorrow(newContract);
            }
            return false;
        }
        // dành riêng cho insert Contract mượn xe từ công ty (không cần thêm xe ) 
        public static bool InsertContractBorrow (Contract_DTO newContract)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO [CONTRACT] VALUES (@CONTRACTID, @CUSTOMERID, @RECEIPTDATE, @DELIVERYDATE, @PARKAREAID, @VEHICLEID, @STATUS)";
            sqlCommand.Parameters.AddWithValue("@CONTRACTID", newContract.ContractId);
            sqlCommand.Parameters.AddWithValue("@CUSTOMERID", newContract.Customer.CustomerId);
            sqlCommand.Parameters.AddWithValue("@RECEIPTDATE", newContract.ReceiptDate.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@DELIVERYDATE", newContract.DeliveryDate.ToString("yyyy-MM-dd"));
            sqlCommand.Parameters.AddWithValue("@PARKAREAID", newContract.MyParkArea.ParkAreaId);
            sqlCommand.Parameters.AddWithValue("@VEHICLEID", newContract.MyVehical.VehicalId);
            sqlCommand.Parameters.AddWithValue("@STATUS", newContract.Status);
            if (MyDB.ExecuteNonQuery(sqlCommand))
            {
                foreach (var contractDetail in newContract.MyContractDetail)
                {
                    if (!InsertContractDetail(contractDetail))
                        return false;
                }
                return true;
            }
            return false;
        }

        #region Add ContractDetail
        private static bool InsertContractDetail(ContractDetail_DTO newConTractDetail)
        {
            return ContractDetail_DAL.InsertContractDetail(newConTractDetail);
        }
        #endregion

        #region các hàm check contract cho các lớp xung quanh 
        /// <summary>
        /// check xem còn contract nào thuộc parkareaId còn trong datatable  không 
        /// </summary>
        /// <returns></returns>
        public static bool CheckContractParkArea (string parkAreaId)
        {
            string querry = "SELECT COUNT (*) FROM CONTRACT " +
                $"WHERE CONTRACT.PARKAREAID = '{parkAreaId}'";
            int count = MyDB.ExecuteScalar (querry);
            if (count > 0) return true; // có contract trong khu vực parkArea
            else return false;  
        }
        #endregion
        /// <summary>
        /// cập nhật worker cho các contractdetail có dịch vụ là bảo trì và rửa 
        /// </summary>
        /// <param name="myContract"></param>
        /// <returns></returns>
        public static bool ConfirmContract (Contract_DTO myContract)
        {
            myContract.Status = 1;
            myContract.MyVehical.Status = 1;
            if (!UpdateStatusContract (myContract)) return false;
            if (myContract.MyContractDetail[0].Service.Type == "borrow")
                return true;
            foreach (var contractDetail in myContract.MyContractDetail)
            {
                if (contractDetail.Service.Type != "rent")
                    DAL.ContractDetail_DAL.UpdateContractDetailWorker(contractDetail, contractDetail.Worker.WorkerId);
                else
                    DAL.RentalManagement_DAL.InsertRentalManagement(
                        new RentalManagement_DTO(myContract, myContract.ReceiptDate, myContract.DeliveryDate));
            }
            Vehical_DAL.UpdateVehicle(myContract.MyVehical);
            return true;
        }
        /// <summary>
        /// xác nhận hợp đồng đã xong và sẵn sàng giao cho khách 
        /// </summary>
        /// <param name="myContract"></param>
        /// <returns></returns>
        public static bool ConfirmContractCompletion (Contract_DTO myContract)
        {
            myContract.Status = 2;
            if (myContract.MyContractDetail[0].Service.Type == "rent")
                RentalManagement_DAL.DeleteRentalManagement(myContract);
            return UpdateStatusContract(myContract);
        }
        private static bool UpdateStatusContract (Contract_DTO myContract)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE CONTRACT SET STATUS = @STATUS WHERE CONTRACTID = @CONTRACTID";
            sqlCommand.Parameters.AddWithValue("@CONTRACTID", myContract.ContractId);
            sqlCommand.Parameters.AddWithValue("@STATUS", myContract.Status);
            return MyDB.ExecuteNonQuery (sqlCommand);
        }
        #region
        // sử dụng bởi customer,admin khi contract chưa được xác nhận bởi admin 
        public static bool DeleteContract (Contract_DTO myContract)
        {
            ContractDetail_DAL.DeleteContractDetail(myContract.ContractId); // xóa những contractDetail liên quan
            if (myContract.MyContractDetail[0].Service.Type != "borrow")
            {
                if (!Vehical_DAL.DeleteVehicle(myContract.MyVehical.VehicalId))
                {
                    return false; // xóa không thành công
                }
            }
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM [Contract] WHERE ContractId = @IdContract";
            sqlCommand.Parameters.AddWithValue("@IdContract", myContract.ContractId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }

        #endregion
        // khách hàng xác nhận thanh toán cho contract -> status = 3 
        public static bool ContractPayment (Contract_DTO myContract, Bill_DTO myBill)
        {
            myContract.Status = 3;
            if (!Bill_DAL.InsertBill(myBill)) return false;
            if (myContract.MyContractDetail[0].Service.Type != "borrow")
                Vehical_DAL.DeleteVehicle(myContract.MyVehical.VehicalId); // xóa vehicle ra khỏi hệ thống (set status = 0) nếu không phải là hợp đồng mượn 
            return UpdateStatusContract(myContract);
        }
    }
}
