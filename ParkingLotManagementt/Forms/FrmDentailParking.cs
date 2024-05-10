using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class FrmDentailParking : Form
    {
        private Parking_DTO myParking;
        private Fee_DTO myFee = BUL.Fee_BUL.GetFee(); 
        private void SetMyParking ()
        {
            txtParkingID.Text = myParking.ParkingId;
            txtCheckIn.Text = myParking.CheckIn.ToString("yyyy-MM-dd HH:mm:ss");
            if (myParking.CheckOut == DateTime.MinValue)
            {
                txtCheckOut.Text = "The car is still in the parking lot !";
                txtPrice.Text = "The car is still in the parking lot !";
                TimeSpan duration = DateTime.Now - myParking.CheckIn;
                txtTime.Text = duration.TotalHours.ToString();
            }
            else
            {
                txtCheckOut.Text = myParking.CheckOut.ToString("yyyy-MM-dd HH:mm:ss");
                TimeSpan duration = myParking.CheckOut - myParking.CheckIn;
                txtTime.Text = duration.TotalHours.ToString();
                txtPrice.Text = myFee.FeeCalculation((int)duration.TotalHours, myParking.ParkArea.Type).ToString();
            }
            txtModelVehicle.Text = myParking.Vehicle.Model;
            txtTypeVehicle.Text = myParking.Vehicle.Type;
            txtIdVehicle.Text = myParking.Vehicle.VehicleId;
            try
            {
                picAvatarCar.Image = myParking.Vehicle.PictureVehicle == null ? picAvatarCar.Image : Image.FromStream( myParking.Vehicle.PictureVehicle);
                picCustomerImage.Image = myParking.Vehicle.PictureCustomer == null ? picCustomerImage.Image : Image.FromStream(myParking.Vehicle.PictureCustomer);
            }
            catch
            {
                return;
            }
        }
        public FrmDentailParking(Parking_DTO myParking)
        {
            InitializeComponent();
            this.myParking = myParking;
            SetMyParking ();    
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region code giao diện 
        /// <summary>
        /// code thanh panel trượt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion 
    }
}
