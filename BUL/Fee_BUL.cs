using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Fee_BUL
    {
        public static bool UpdateFeeMoto(Fee_DTO myFee)
        {
            return Fee_DAL.UpdateFeeMoto(myFee);
        }
        public static Fee_DTO GetFee()
        {
            return Fee_DAL.GetFee();
        }
    }
}
