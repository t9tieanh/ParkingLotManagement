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
    public partial class UC_VehicleForViewContractFrm : UserControl
    {
        private Vehical_DTO myVehicle;
        private void SetMyVehicle()
        {
            lblNameVehicle.Text = myVehicle.VehicalId;
            lblModel.Text = myVehicle.Model;
            lblType.Text = myVehicle.Type;
            picPicture.Image = (myVehicle.Picture != null) ? Image.FromStream(myVehicle.Picture) : picPicture.Image;
        }
        public UC_VehicleForViewContractFrm (Vehical_DTO myVehicle)
        {
            InitializeComponent();
            this.myVehicle = myVehicle;
            SetMyVehicle();
        }

        private void btnViewContractHistory_Click(object sender, EventArgs e)
        {
            new frmVehicleAndContract(myVehicle).ShowDialog();
        }
    }
}
