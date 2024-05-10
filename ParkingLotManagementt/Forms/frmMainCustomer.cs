using BUL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace ParkingLotManagementt.Forms
{
    public partial class frmMainCustomer : Form
    {
        private Customer_DTO customer;
        private void SetCustomer ()
        {
            lblNameCustomer.Text = customer.FullName;
            lblIdCustomer.Text = customer.CustomerId;
            picCustomerAvatar.Image = (customer.Picture != null) ? Image.FromStream(customer.Picture) : picCustomerAvatar.Image;
            // set data cho panel Infomation 
            txtCustomerID.Text = customer.CustomerId;
            txtFullname.Text = customer.FullName;
            txtPhone.Text = customer.Phone;
            txtAddress.Text = customer.Address;
            txtUsername.Text = customer.Account.UserName;
            txtEmail.Text = customer.Account.Email;
            picAvatarCustomer.Image = (customer.Picture != null) ? Image.FromStream(customer.Picture) : picAvatarCustomer.Image;
        }
        public frmMainCustomer(Customer_DTO customer)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.customer = customer;
            SetCustomer();
            //
            dtpkHireDate.Value = DateTime.Now.Date;
            LoadService();
            LoadVehicleForRentAvailable();
        }
        #region code giao diện 
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            pnSettingCustomer.Hide();
            pnService.Show();
        }
        #endregion 
        // Đi đến dịch vụ
        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmCreateContractCustomer(customer).ShowDialog();
            this.Show();
        }
        #region Sự kiện xem và thay đổi thông tin khi click vào ảnh đại diện
        private void picCustomerAvatar_Click(object sender, EventArgs e)
        {
            pnService.Hide();
            pnSettingCustomer.Show();
        }

        #endregion

        // code cho phần mượn xe 
        private string GetTypeVehicleForRent()
        {
            string typeVehicle = "";
            if (rbtnBicycle.Checked) typeVehicle = rbtnBicycle.Text;
            else if (rbtnCar.Checked)
                typeVehicle = rbtnCar.Text;
            else typeVehicle = rbtnMotobike.Text;
            return typeVehicle;
        }
        private void LoadService ()
        {
            string typeVehicle = GetTypeVehicleForRent();
            cbServiceRent.DataSource = BUL.Service_BUL.GetService(typeVehicle,"borrow");
            cbServiceRent.DisplayMember = "NameService";
        }
        public void LoadVehicleForRent ()
        {
            flowServiceRentCar.Controls.Clear();
            string typeVehicle = GetTypeVehicleForRent();
            int time = ((Service_DTO)cbServiceRent.SelectedValue).Time;
            List<RentalManagement_DTO> rentals = BUL.RentalManagement_BUL.GetRentalManagement(typeVehicle,dtpkHireDate.Value,dtpkHireDate.Value.AddHours(time));
            foreach (RentalManagement_DTO rental in rentals)
            {
                var contractBorrow = new Contract_DTO (customer, dtpkHireDate.Value, dtpkHireDate.Value.AddHours(time), rental.MyContract.MyVehical, (Service_DTO)cbServiceRent.SelectedValue,rental.MyContract.MyParkArea,0);
                flowServiceRentCar.Controls.Add(new UC_Controls.UC_VehicleForRentForCustomer(rental,contractBorrow,this)); 
            }
        }
        public void LoadVehicleForRentAvailable ()
        {
            flowServiceRentCarAvailable.Controls.Clear();
            List<RentalManagement_DTO> rentals = BUL.RentalManagement_BUL.GetRentalManagement();
            foreach (RentalManagement_DTO rental in rentals)
            {
                if (rental.StartDay.Date == rental.EndDay.Date)
                    continue;
                flowServiceRentCarAvailable.Controls.Add(new UC_Controls.UC_VehicleForRentAvailableForCustomer(rental));
            }
        }
        public void LoadVehicleForRentAvailable(string typeVehicle)
        {
            flowServiceRentCarAvailable.Controls.Clear();
            List<RentalManagement_DTO> rentals = BUL.RentalManagement_BUL.GetRentalManagement(typeVehicle);
            foreach (RentalManagement_DTO rental in rentals)
            {
                if (rental.StartDay.Date == rental.EndDay.Date)
                    continue;
                flowServiceRentCarAvailable.Controls.Add(new UC_Controls.UC_VehicleForRentAvailableForCustomer(rental));
            }
        }
        private void rbtnBicycle_CheckedChanged(object sender, EventArgs e)
        {
            LoadService ();
        }

        private void rbtnMotobike_CheckedChanged(object sender, EventArgs e)
        {
            LoadService();
        }

        private void rbtnCar_CheckedChanged(object sender, EventArgs e)
        {
            LoadService() ;
        }

        private void cbServiceRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVehicleForRent ();
        }
        /// <summary>
        /// nút xem contract của khách hàng 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMyContract_Click(object sender, EventArgs e)
        {
            new frmContractCustomer(customer).ShowDialog();
        }

        private void cbModelVehicleRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbModelVehicleRental.Text == "All")
            {
                LoadVehicleForRentAvailable();
                return;
            }
            else LoadVehicleForRentAvailable(cbModelVehicleRental.Text);
        }
        private void dtpkHireDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpkHireDate.Value.Date == DateTime.Now.Date)
            {
                LoadService();
                return;
            }
            if (dtpkHireDate.Value.Date < DateTime.Now)
            {
                lblNoticeRent.Text = "Invalid time!";
                dtpkHireDate.Value = DateTime.Now;
                return;
            }
            LoadService();
        }
        #region code cho phần chỉnh sửa thông tin customer 
        private bool CheckInput ()
        {
            error.Clear();
            bool wasError = true;
            if (!InputCheck.CheckInput.Name(txtFullname.Text))
            {
                error.SetError(txtFullname, "Name not valid");
                wasError = false;   
            }
            if (!InputCheck.CheckInput.IsValidPhoneNumber(txtPhone.Text))
            {
                error.SetError(txtPhone, "Phone not valid");
                wasError = false;
            }
            if (!InputCheck.CheckInput.AddressIsValid(txtAddress.Text))
            {
                error.SetError(txtAddress, "Address not valid");
                wasError = false;   
            }
            return wasError;
        }
        private void lblChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn file PNG";

            // Thiết lập bộ lọc để chỉ hiển thị file PNG
            openFileDialog.Filter = "PNG Files|*.png";

            // Thiết lập loại file mặc định
            openFileDialog.DefaultExt = "png";

            // Cho phép chọn nhiều file
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog(); // chọn chỗ lưu
            if (result == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                picAvatarCustomer.ImageLocation = filePath;
            }
        }
        private void GetCustomer ()
        {
            if (!CheckInput()) return;
            customer.FullName = txtFullname.Text;
            customer.Phone = txtPhone.Text;
            customer.Address = txtAddress.Text;
            //customer.Picture = picAvatarCustomer
            MemoryStream picCustomer = new MemoryStream();
            picAvatarCustomer.Image.Save(picCustomer, picAvatarCustomer.Image.RawFormat);
            customer.Picture = picCustomer;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            GetCustomer();
            if (!Customer_BUL.UpdateCustomer(customer))
            {
                lblNotice.Text = "(error system) Customer information has not been edited, please try again !";
                return;
            }
            lblNotice.Text = "Edited information successfully!";
            SetCustomer();
        }
        #endregion
        private bool tick;
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tick) pbxNotice.Image = Resource1.ogs_parking_lots_221;
            else
                pbxNotice.Image = Resource1._1695288013_untitled_design_min;
            tick = !tick;
        }
    }
}
