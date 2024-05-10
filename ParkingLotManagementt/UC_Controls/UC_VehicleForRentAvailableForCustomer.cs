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
    public partial class UC_VehicleForRentAvailableForCustomer : UserControl
    {
        private RentalManagement_DTO rentalManagement;
        private void SetRentalManagement()
        {
            lblNameCar.Text = rentalManagement.MyContract.MyVehical.VehicalId;
            lblModelVehicle.Text = rentalManagement.MyContract.MyVehical.Model;
            lblType.Text = rentalManagement.MyContract.MyVehical.Type;
            picVehicleImage.Image = Image.FromStream(rentalManagement.MyContract.MyVehical.Picture);
            lblAvailableTime.Text = rentalManagement.StartDay.ToString("yyyy-MM-dd") + " - " + rentalManagement.EndDay.ToString("yyyy-MM-dd");
        }
        public UC_VehicleForRentAvailableForCustomer()
        {
            InitializeComponent();
        }
        public UC_VehicleForRentAvailableForCustomer(RentalManagement_DTO myRentalManagement)
        {
            InitializeComponent();
            rentalManagement = myRentalManagement;
            SetRentalManagement();
        }
    }
}
