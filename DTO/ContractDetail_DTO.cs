using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ContractDetail_DTO
    {
        private string contractDetailId;
        private Contract_DTO contract;
        private Service_DTO service;
        private Worker_DTO worker;
        private int status;
        public ContractDetail_DTO(Contract_DTO contract, Worker_DTO worker, Service_DTO service, int status)
        {
            ContractDetailId = contract.ContractId + "|" + service.ServiceId;
            Contract = contract;
            Worker = worker;
            Service = service;
            Status = status;
        }

        public ContractDetail_DTO(Contract_DTO contract, Service_DTO service, int status)
        {
            ContractDetailId = contract.ContractId + "|" + service.ServiceId;
            Contract = contract;
            Service = service;
            Status = status;
        }

        public ContractDetail_DTO(Contract_DTO contract,Service_DTO service)
        {
            ContractDetailId = contract.ContractId + "|" + service.ServiceId;
            Contract = contract;
            Service = service;
        }

        public string ContractDetailId { get => contractDetailId; set => contractDetailId = value.Trim(); }
        public Contract_DTO Contract { get => contract; set => contract = value; }
        public Worker_DTO Worker { get => worker; set => worker = value; }
        public int Status { get => status; set => status = value; }
        public Service_DTO Service { get => service; set => service = value; }
    }
}
