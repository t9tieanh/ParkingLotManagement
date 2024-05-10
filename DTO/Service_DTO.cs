using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Service_DTO
    {
        private string serviceId;
        private string nameService;
        private string description;
        private double price;
        private string type; // maintenance, wash, rent, borrow 
        private bool status;
        private string typeVehical;  // dịch vụ này dành cho xe loại nào
        private int time; // số tiếng cho dịch vụ 
        public Service_DTO(string serviceId, string nameService, string description, double price, string type, bool status)
        {
            ServiceId = serviceId;
            NameService = nameService;
            Description = description;
            Price = price;
            Type = type;
            Status = status;
        }
        public Service_DTO(string serviceId, string nameService , string type)
        {
            ServiceId = serviceId;
            NameService = nameService;
            Type = type;
        }
        public Service_DTO(string serviceId, string nameService, string description, double price, string type, bool status,int time)
        {
            ServiceId = serviceId;
            NameService = nameService;
            Description = description;
            Price = price;
            Type = type;
            Status = status;
            Time = time; 
        }
        public Service_DTO(string serviceId, string nameService, string description, double price, string type, string typeVehical,int time)
        {
            ServiceId = serviceId;
            NameService = nameService;
            Description = description;
            Price = price;
            Type = type;
            TypeVehical = typeVehical;
            Time = time;
        }

        public Service_DTO(string serviceId)
        {
            ServiceId = serviceId;
        }

        public string ServiceId { get => serviceId; set => serviceId = value.Trim(); }
        public string NameService { get => nameService; set => nameService = value.Trim(); }
        public string Description { get => description; set => description = value.Trim(); }
        public double Price { get => price; set => price = value; }
        public string Type { get => type; set => type = value.Trim(); }
        public bool Status { get => status; set => status = value; }
        public string TypeVehical { get => typeVehical; set => typeVehical = value; }
        public int Time { get => time; set => time = value; }

        public override string ToString()
        {
            return "Service " + nameService;
        }
    }
}
