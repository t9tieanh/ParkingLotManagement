using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Worker_DTO
    {
        private string workerId;
        private string fullName;
        private string address;
        private MemoryStream picture;
        private string type;
        private ParkArea_DTO myParkArea;
        private Account_DTO account;
        private bool status;
        public Worker_DTO(string workerId, string fullName, string address, MemoryStream picture1, string type, ParkArea_DTO parkAreaId,bool status,Account_DTO account)
        {
            WorkerId = workerId;
            FullName = fullName;
            Address = address;
            Picture = picture1;
            Type = type;
            ParkArea = parkAreaId;
            Account = account;
            Status = status;
        }
        public Worker_DTO(string workerId, string fullName, string address, MemoryStream picture1, string type, ParkArea_DTO parkAreaId)
        {
            WorkerId = workerId;
            FullName = fullName;
            Address = address;
            Picture = picture1;
            Type = type;
            ParkArea = parkAreaId;
        }
        public Worker_DTO(string workerId, string fullName)
        {
            WorkerId = workerId;
            FullName = fullName;
        }
        public Worker_DTO() { }
        public string WorkerId { get => workerId; set => workerId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string Address { get => address; set => address = value; }
        public MemoryStream Picture { get => picture; set => picture = value; }
        public string Type { get => type; set => type = value; }
        public ParkArea_DTO ParkArea { get => myParkArea; set => myParkArea = value; }
        public Account_DTO Account { get => account; set => account = value; }
        public bool Status { get => status; set => status = value; }

        public override string ToString()
        {
            return WorkerId + " " + fullName;
        }
    }
}
