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
    public partial class UC_Vehicle : UserControl
    {
        private Vehical_DTO myVehicle;
        private void SetMyVehicle ()
        {
            lblNameVehicle.Text = myVehicle.VehicalId;
            lblModel.Text = myVehicle.Model;
            lblType.Text = myVehicle.Type;
            picPicture.Image = (myVehicle.Picture != null) ? Image.FromStream (myVehicle.Picture) : picPicture.Image;
        }
        public UC_Vehicle()
        {
            InitializeComponent();
        }
        public UC_Vehicle(Vehical_DTO vehical)
        {
            InitializeComponent();
            myVehicle = vehical;
            SetMyVehicle();
        }
    }
}
