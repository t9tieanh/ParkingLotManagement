using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_ServiceForCustomer : UserControl
    {
        private Service_DTO myService;

        public Service_DTO MyService { get => myService; set => myService = value; }

        #region Design

        private int radius = 20;
        [DefaultValue(20)]
        public int Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                this.RecreateRegion();
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private GraphicsPath GetRoundRectagle(Rectangle bounds, int radius)
        {
            float r = radius;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, r, r, 180, 90);
            path.AddArc(bounds.Right - r, bounds.Top, r, r, 270, 90);
            path.AddArc(bounds.Right - r, bounds.Bottom - r, r, r, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void RecreateRegion()
        {
            var bounds = ClientRectangle;
            this.Region = Region.FromHrgn(CreateRoundRectRgn(bounds.Left, bounds.Top,
                bounds.Right, bounds.Bottom, Radius, radius));
            this.Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.RecreateRegion();
        }


        #endregion

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
        private void setService ()
        {
            lblIdService.Text = MyService.ServiceId;
            lblPrice.Text = MyService.Price.ToString();
            lblNameService.Text = MyService.NameService;
             
            lblTimeService.Text = "Time for service: " + TimeString (myService.Time);
            lblDecription.Text = MyService.Description;

            if (myService.TypeVehical == "Moto") picVehicleImage.Image = Resource1.motorcycle;
            else if (myService.TypeVehical == "Car") picVehicleImage.Image = picVehicleImage.Image;
            else picVehicleImage.Image = picVehicleImage.Image = Resource1.bicycle;
        }
        public bool Checked ()
        {
            return chkService.Checked;
        }
        public UC_ServiceForCustomer()
        {
            InitializeComponent();
        }
        public UC_ServiceForCustomer(Service_DTO myService)
        {
            InitializeComponent();
            this.MyService = myService;
            setService();
        }
    }
}
