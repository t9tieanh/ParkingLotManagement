using DTO;
using ParkingLotManagementt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.UC_Controls
{
    public partial class UC_VehicleForRentForCustomer : UserControl
    {
        private frmMainCustomer frmCustomer;
        private RentalManagement_DTO rentalManagement;
        private Contract_DTO myContract;
        private void SetRentalManagement ()
        {
            lblNameCar.Text = rentalManagement.MyContract.MyVehical.VehicalId;
            lblModelVehicle.Text = rentalManagement.MyContract.MyVehical.Model;
            lblTTType.Text = rentalManagement.MyContract.MyVehical.Type;
            picVehicleImage.Image = Image.FromStream(rentalManagement.MyContract.MyVehical.Picture);
        }
        public UC_VehicleForRentForCustomer()
        {
            InitializeComponent();
        }
        public UC_VehicleForRentForCustomer(RentalManagement_DTO myRentalManagement, Contract_DTO myContract,frmMainCustomer customer)
        {
            InitializeComponent();
            rentalManagement = myRentalManagement;
            this.myContract = myContract;
            this.frmCustomer = customer;
            SetRentalManagement ();
        }

        private void btnRentThisVehicle_Click(object sender, EventArgs e)
        {
            /*// thêm hợp đồng 
            if (!BUL.Contract_BUL.InsertContractBorrow(myContract))
            {
                MessageBox.Show("Thất bại"); //test thôi nha
                return;
            }
            //
            Tuple<RentalManagement_DTO, RentalManagement_DTO> newRentalManagement =
                rentalManagement.rentChange(myContract.ReceiptDate, myContract.DeliveryDate);
            if (!BUL.RentalManagement_BUL.DeleteRentalManagement(rentalManagement.IdRentalManagement))
            {
                MessageBox.Show("Thất bại"); //test thôi nha
                return;
            }
            BUL.RentalManagement_BUL.InsertRentalManagement(newRentalManagement.Item1);
            BUL.RentalManagement_BUL.InsertRentalManagement(newRentalManagement.Item2);
            MessageBox.Show("Thành công rùi !");
            frmCustomer.loadVehicleForRent();*/
            new CreateContractBorrow(this.myContract, this.rentalManagement).ShowDialog();
            frmCustomer.LoadVehicleForRent();
        }
    }
}
