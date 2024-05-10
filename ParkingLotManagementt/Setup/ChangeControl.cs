using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Setup
{
    public static class ChangeControl
    {

        public static void ChangeSizeOfControl(Control control, int x, int y)
        {
            control.Width = x; 
            control.Height = y;
        }

        public static void ChangeLocationOfControl(Control control, int x, int y)
        {
            control.Location = new System.Drawing.Point(x, y);
        }
    }
}
