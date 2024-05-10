using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Vehical_DTO
    {
        private string vehicalId;
        private string model; // hãng xe 
        private string type; // kiểu xe (xe đạp/ xe máy/ xe ô tô)
        private MemoryStream picture; // ảnh của xe 

        private int status;
        public Vehical_DTO(string vehicalId)
        {
            VehicalId = vehicalId;
        }
        public Vehical_DTO(string vehicalId, string model, string type, MemoryStream picture)
        {
            VehicalId = vehicalId;
            Model = model;
            Type = type;
            Picture = picture;
        }
        public Vehical_DTO(string vehicalId, string type, MemoryStream picture)
        {
            VehicalId = vehicalId;
            Type = type;
            Picture = picture;
        }
        public Vehical_DTO(string vehicalId, string model, string type, MemoryStream picture, int status)
        {
            VehicalId = vehicalId;
            Model = model;
            Type = type;
            Picture = picture;
            Status = status;
        }

        /*0 : xe không tồn tại 
        1 : xe có trong bãi(dưới dạng cho gửi bình thường)
        2 : xe có trong hợp đồng 
        3 : xe có thể cho thuê 
        ->  trạng thái 2 3 là trạng thái xe đang trong hợp đồng*/

        public string VehicalId { get => vehicalId; set => vehicalId = value; }
        public string Model { get => model; set => model = value; }
        public string Type { get => type; set => type = value; }
        public MemoryStream Picture { get => picture; set => picture = value; }
        public int Status { get => status; set => status = value; }

        public override string ToString()
        {
            return "Vehical" + Type + " " + VehicalId;
        }
    }
}
