using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    public class ContractDetail_DAL
    {
        /// <summary>
        /// lấy dữ liệu contractDetail
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="isContract">có lấy dữ liệu của contract hay không </param>
        /// <returns></returns>
        private static List<ContractDetail_DTO> GetContractDetail (DataTable dt, bool isContract)
        {
            List<ContractDetail_DTO> myContractDetail = new List<ContractDetail_DTO>();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string contractId = row[0].ToString();
                    int status = Convert.ToInt32(row[1].ToString());
                    
                    string serviceId = row[2].ToString();
                    Service_DTO myService = DAL.Service_DAL.GetService(serviceId);

                    if ((myService.Type == "rent" || myService.Type == "borrow") && Contract_DAL.GetDateTimeContract(contractId) < DateTime.Now)
                        status = 1;

                    string workerId = row[3].ToString();
                    Worker_DTO myWorker = DAL.Worker_DAL.GetWorker(workerId);

                    ContractDetail_DTO contractDetail = new ContractDetail_DTO(new Contract_DTO (contractId), myWorker, myService ,status);
                    
                    // nếu isContract thì đổi dữ liệu cho contract
                    if (isContract) 
                        contractDetail.Contract = Contract_DAL.GetContract(contractDetail);

                    myContractDetail.Add(contractDetail);
                }
            }
            return myContractDetail;
        }
        public static List<ContractDetail_DTO> GetContractDetail(string contractID)
        {
            string querry = "SELECT ContractID,ContractDetail.Status, ContractDetail.ServiceId, ContractDetail.WorkerID " +
                "FROM ContractDetail LEFT OUTER JOIN Worker ON ContractDetail.WorkerID = Worker.WorkerID , [Service] " +
                $"WHERE Service.ServiceId = ContractDetail.ServiceId AND ContractDetail.ContractID = '{contractID}'";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContractDetail(dt,false);
        }
        public static List<ContractDetail_DTO> GetContractDetail (Worker_DTO worker, int status)
        {
            string querry = "SELECT ContractID,ContractDetail.Status, ContractDetail.ServiceId, ContractDetail.WorkerID " +
                "FROM ContractDetail " +
                $"WHERE ContractDetail.WorkerID = '{worker.WorkerId}' AND STATUS = {status}";
            DataTable dt = MyDB.GetDataTable(querry);
            return GetContractDetail(dt, true);
        }
        #region Add ContractDetail
        /// <summary>
        /// insert đối với các hợp đồng không phải thuộc loại cho thuê xe 
        /// </summary>
        /// <param name="newConTractDetail"></param>
        /// <returns></returns>
        public static bool InsertContractDetail(ContractDetail_DTO newConTractDetail)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO CONTRACTDETAIL VALUES (@CONTRACTDETAILID, @CONTRACTID, @SERVICEID, @WORKERID, @STATUS)";
            sqlCommand.Parameters.AddWithValue("@CONTRACTDETAILID", newConTractDetail.ContractDetailId);
            sqlCommand.Parameters.AddWithValue("@CONTRACTID", newConTractDetail.Contract.ContractId);
            sqlCommand.Parameters.AddWithValue("@SERVICEID", newConTractDetail.Service.ServiceId);
            sqlCommand.Parameters.AddWithValue("@WORKERID", DBNull.Value);
            sqlCommand.Parameters.AddWithValue("@STATUS", 0);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        /// <summary>
        /// dùng cho manager xác nhận contractdetail
        /// </summary>
        /// <param name="newContractDetail"></param>
        /// <returns></returns>
        public static bool ConfirmContractDetail(ContractDetail_DTO newContractDetail)
        {
            if (newContractDetail.Service.Type == "borrow") return false; // hàm này không dùng để xác nhận những contractdetail (công ty cho thuê)
            if (newContractDetail.Service.Type == "rent")
            {
                return DAL.RentalManagement_DAL.InsertRentalManagement(new RentalManagement_DTO(newContractDetail.Contract,
                    newContractDetail.Contract.ReceiptDate, newContractDetail.Contract.DeliveryDate));
            }
            else
                return UpdateContractDetailWorker(newContractDetail, newContractDetail.Worker.WorkerId); // new contractdetail đã được nhận giá trị worker 
        }
        #endregion
        #region update ContractDetail
        /// <summary>
        /// dành cho worker dùng 
        /// </summary>
        /// <param name="newConTractDetail"></param>
        /// <returns></returns>
        public static bool UpdateContractDetailStatus(ContractDetail_DTO newConTractDetail)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "UPDATE CONTRACTDETAIL SET STATUS = 1 WHERE CONTRACTDETAILID = @CONTRACTDETAILID";
            sqlCommand.Parameters.AddWithValue("@CONTRACTDETAILID", newConTractDetail.ContractDetailId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        public static bool UpdateContractDetailWorker(ContractDetail_DTO newConTractDetail, string idWorker)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = $"UPDATE CONTRACTDETAIL SET WORKERID = '{idWorker}' WHERE CONTRACTDETAILID = @CONTRACTDETAILID";
            sqlCommand.Parameters.AddWithValue("@CONTRACTDETAILID", newConTractDetail.ContractDetailId);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
        #endregion 

        /// <summary>
        /// xóa contractdetail -> được gọi từ việc xóa contract
        /// </summary>
        /// <param name="IdContract"></param>
        /// <returns></returns>
        public static bool DeleteContractDetail(string IdContract)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM [ContractDetail] WHERE ContractId = @IdContract";
            sqlCommand.Parameters.AddWithValue("@IdContract", IdContract);
            return MyDB.ExecuteNonQuery(sqlCommand);
        }
    }
}
