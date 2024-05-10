using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RentalManagement_DTO
    {
        private string idRentalManagement; 
        private Contract_DTO myContract;
        private DateTime startDay; 
        private DateTime endDay;
        public RentalManagement_DTO(string idRentailManagement, Contract_DTO contract, DateTime startDay, DateTime endDay)
        {
            IdRentalManagement = idRentailManagement ;
            MyContract = contract;
            StartDay = startDay;
            EndDay = endDay;
        }
        public RentalManagement_DTO(Contract_DTO contract, DateTime startDay, DateTime endDay)
        {
            IdRentalManagement = contract.ContractId + startDay.ToString("yyyy-MM-dd HH:mm:ss") + endDay.ToString("yyyy-MM-dd HH:mm:ss"); ;
            MyContract = contract;
            StartDay = startDay;
            EndDay = endDay;
        }
        public Tuple<RentalManagement_DTO, RentalManagement_DTO> rentChange (DateTime startDay, DateTime endDay)
        {
            var rental1 = new RentalManagement_DTO (myContract,StartDay,startDay);
            var rental2 = new RentalManagement_DTO(myContract, endDay, EndDay);
            return Tuple.Create(rental1, rental2);
        }
        public string IdRentalManagement { get => idRentalManagement; set => idRentalManagement = value.Trim (); }
        public Contract_DTO MyContract { get => myContract; set => myContract = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public DateTime EndDay { get => endDay; set => endDay = value; }
    }
}
