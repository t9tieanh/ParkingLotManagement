using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class ContractDetail_BUL
    {
        /// <summary>
        /// cập nhật worker
        /// </summary>
        /// <param name="newConTractDetail"></param>
        /// <returns></returns>
        public static bool UpdateContractDetailWorker(ContractDetail_DTO newConTractDetail,string idWorker)
        {
            return DAL.ContractDetail_DAL.UpdateContractDetailWorker(newConTractDetail, idWorker);
        }
        /// <summary>
        /// lấy dữ liệu của từng contractDetail mà worker được phân công 
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public static List<ContractDetail_DTO> GetContractDetail(Worker_DTO worker, int status)
        {
            return DAL.ContractDetail_DAL.GetContractDetail(worker,status);
        }
        /// <summary>
        /// dành cho worker dùng 
        /// </summary>
        /// <param name="newConTractDetail"></param>
        /// <returns></returns>
        public static bool UpdateContractDetailStatus(ContractDetail_DTO newConTractDetail)
        {
            return DAL.ContractDetail_DAL.UpdateContractDetailStatus(newConTractDetail);
        }
    }
}
