using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_ServiceForAdminView : UserControl
    {
        private Service_DTO MyService;
        /// <summary>
        /// hàm bổ trợ cho time (int) -> string 
        /// </summary>
        /// <param name="time">số tiếng cho dịch vụ</param>
        private string TimeString(int time)
        {
            if (time < 24)
                return time + " Hour" + (time == 1 ? "" : "s"); // pluralize "Hour" if time is not 1
            else if (time >= 24 && time < 168)
                return (time / 24) + " Day" + (time / 24 == 1 ? "" : "s"); // convert to days and pluralize if necessary
            else if (time >= 168 && time < 720)
                return (time / 168) + " Week" + (time / 168 == 1 ? "" : "s"); // convert to weeks and pluralize if necessary
            else
                return (time / 720) + " Month" + (time / 720 == 1 ? "" : "s"); // convert to months and pluralize if necessary
        }
        private void setService()
        {
            lblIdService.Text = MyService.ServiceId;
            lblPrice.Text = MyService.Price.ToString();
            lblNameService.Text = MyService.NameService;

            lblTimeService.Text = "Time for service: " + TimeString(MyService.Time);
            lblDecription.Text = MyService.Description;
        }
        public UC_ServiceForAdminView()
        {
            InitializeComponent();
        }
        public UC_ServiceForAdminView(Service_DTO myService)
        {
            InitializeComponent();
            MyService = myService;
            setService();
        }
    }
}
