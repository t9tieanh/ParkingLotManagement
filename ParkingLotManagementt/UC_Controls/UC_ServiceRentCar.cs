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
    public partial class UC_ServiceRentCar : UserControl
    {
        Service_DTO myService;

        public Service_DTO MyService { get => myService; set => myService = value; }

        private void setService()
        {
            lblIdCar.Text = MyService.ServiceId;
            lblPrice.Text = MyService.Price.ToString();
            lblNameCar.Text = MyService.NameService;
            // lblDecription.Text = MyService.Description;
            if (myService.TypeVehical == "Moto") picVehicleImage.Image = Resource1.bike;
            else if (myService.TypeVehical == "Car") picVehicleImage.Image = picVehicleImage.Image;
            else picVehicleImage.Image = Resource1.rent;
        }
        public UC_ServiceRentCar()
        {
            InitializeComponent();
        }
        public UC_ServiceRentCar(Service_DTO myService)
        {
            InitializeComponent();
            this.myService = myService;
            setService();
        }
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

        private void pnServiceRentCar_MouseHover(object sender, EventArgs e)
        {
            pnServiceRentCar.BorderColor = Color.FromArgb(232, 67, 147);
        }

        private void pnServiceRentCar_MouseLeave(object sender, EventArgs e)
        {
            pnServiceRentCar.BorderColor = Color.White;
        }
    }
}
