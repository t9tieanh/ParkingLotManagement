using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ParkArea_DTO
    {
        private string parkAreaId;
        private string address;
        private int capacity;
        private string type;

        public ParkArea_DTO(string parkAreaId)
        {
            ParkAreaId = parkAreaId;
        }

        public ParkArea_DTO(string parkAreaId, string address)
        {
            ParkAreaId = parkAreaId;
            Address = address;
        }

        public ParkArea_DTO(string parkAreaId, string address, int capacity, string type)
        {
            ParkAreaId = parkAreaId;
            Address = address;
            Capacity = capacity;
            Type = type;
        }

        public string ParkAreaId { get => parkAreaId; set => parkAreaId = value; }
        public string Address { get => address; set => address = value; }
        public int Capacity { get => capacity; set => capacity = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return "ParkArea " + parkAreaId;
        }
    }
}
