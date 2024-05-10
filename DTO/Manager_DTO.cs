using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Manager_DTO
    {
        private string managerId;
        private string fullName;
        private MemoryStream picture;
        private string phone;
        private bool status;
        private Account_DTO account;
        private ParkArea_DTO parkArea;

        public Manager_DTO(string managerId, string fullName, MemoryStream picture, string phone, bool status, Account_DTO account, ParkArea_DTO parkArea)
        {
            ManagerId = managerId;
            FullName = fullName;
            Picture = picture;
            Phone = phone;
            Status = status;
            Account = account;
            ParkArea = parkArea;
        }

        /*public Manager_DTO(string managerId, string fullName, MemoryStream picture, string phone, bool status, Account_DTO account)
{
   ManagerId = managerId;
   FullName = fullName;
   Picture = picture;
   Phone = phone;
   Status = status;
   Account = account;
}*/

        public string ManagerId { get => managerId; set => managerId = value.Trim(); }
        public string FullName { get => fullName; set => fullName = value.Trim(); }
        public MemoryStream Picture { get => picture; set => picture = value; }
        public string Phone { get => phone; set => phone = value.Trim(); }
        public bool Status { get => status; set => status = value; }
        public Account_DTO Account { get => account; set => account = value; }
        public ParkArea_DTO ParkArea { get => parkArea; set => parkArea = value; }

        public override string ToString()
        {
            return ManagerId +" - "+ fullName ;
        }
    }
}
