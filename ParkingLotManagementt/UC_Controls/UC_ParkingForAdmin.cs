using DTO;
using ParkingLotManagementt.Forms;
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
    public partial class UC_ParkingForAdmin : UserControl
    {
        private Parking_DTO parking;
        private void SetParking()
        {
            lblVehicleId.Text = parking.Vehicle.VehicleId;
            lblType.Text = parking.Vehicle.Type;
            lblModel.Text = parking.Vehicle.Model;
            try
            {
                picVehicle.Image = parking.Vehicle.PictureVehicle == null ? picVehicle.Image : Image.FromStream(parking.Vehicle.PictureVehicle);
                picCustomer.Image = parking.Vehicle.PictureCustomer == null ? picCustomer.Image : Image.FromStream(parking.Vehicle.PictureCustomer);
            }
            catch { }
            lblCheckInTime.Text = parking.CheckIn.ToString("yyyy-MM-dd HH:mm:ss");
            if (parking.CheckOut == DateTime.MinValue)
                lblCheckOutTime.Text = "The car is still in the parking lot !";
            else
            {
                lblCheckOutTime.Text = "Check In Time : "+ parking.CheckOut.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public UC_ParkingForAdmin()
        {
            InitializeComponent();
        }
        public UC_ParkingForAdmin(Parking_DTO parking)
        {
            InitializeComponent();
            this.parking = parking; 
            SetParking();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            new FrmDentailParking(parking).ShowDialog();
        }
    }
}
