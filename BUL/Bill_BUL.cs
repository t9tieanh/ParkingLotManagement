using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public class Bill_BUL
    {
        // dùng cho thống kê contract 
        public static double RevenueBillMonth(int month)
        {
            return Bill_DAL.RevenueBillMonth (month);
        }
    }
}
