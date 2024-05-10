using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmChangePriceParking : Form
    {
        private Fee_DTO myFee = Fee_BUL.GetFee();
        private void LoadFee ()
        {
            lblPriceMoto.Text = myFee.FeeMoto.ToString() + "$";
            lblPriceCar.Text = myFee.FeeCar.ToString() + "$";
            lblPriceBicycle.Text = myFee.FeeBicycle.ToString() + "$";

        }
        public frmChangePriceParking()
        {
            InitializeComponent();
            LoadFee();
        }

        private void lblNote_Click(object sender, EventArgs e)
        {

        }

        private void rdMoto_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdateVehiclePrice.Text = myFee.FeeMoto.ToString();
            lblVehicleTypeUpdate.Text = "Moto";
            lblPriceSelected.Text = myFee.FeeMoto.ToString() + " $";
            lblVehicleType.Text = "Moto";
        }

        private void rdCar_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdateVehiclePrice.Text = myFee.FeeCar.ToString();
            lblVehicleTypeUpdate.Text = "Car";
            lblPriceSelected.Text = myFee.FeeCar.ToString() + " $";
            lblVehicleType.Text = "Car";
        }

        private void rdBicycle_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdateVehiclePrice.Text = myFee.FeeBicycle.ToString();
            lblVehicleTypeUpdate.Text = "Bicycle";
            lblPriceSelected.Text= myFee.FeeBicycle.ToString() + " $";
            lblVehicleType.Text = "Bicycle";
        }
        #region design
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// code thanh panel trượt 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void picBackGround_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
               if (rdBicycle.Checked)
               {
                    myFee.FeeBicycle = Convert.ToDouble(txtUpdateVehiclePrice.Text);
               }
               else if (rdMoto.Checked)
               {
                    myFee.FeeMoto = Convert.ToDouble(txtUpdateVehiclePrice.Text);
               }
               else
               {
                    myFee.FeeCar = Convert.ToDouble (txtUpdateVehiclePrice.Text);
               }
               LoadFee();
            }
            catch
            {
                lblNotice.Text = "Price not valid !";
            }
        }

        private void btnSavePrice_Click(object sender, EventArgs e)
        {
            if (Fee_BUL.UpdateFeeMoto(myFee))
            {
                lblNotice.Text = "Price update successful !";
            }
            else
                lblNotice.Text = "Update failed, please try again";
        }
    }
}
