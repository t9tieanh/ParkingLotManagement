using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class frmCreateContract : Form
    {
        private Contract_DTO myContract;
        private int timeSpan = 0; // khoảng thời gian thực hiện hợp đồng, biến này sẽ được set sau khi chọn service 
        private bool checkInfoVehicle()
        {
            lblNoticeVehicle.Text = "";
            error.Clear();
            bool kq = true;
            if (!InputCheck.CheckInput.Name(txtIDVehicle.Text))
            {
                error.SetError(txtIDVehicle, "Invalid vehicle name!");
                kq = false;
            }
            if (!InputCheck.CheckInput.Name(txtModelVehicle.Text))
            {
                error.SetError(txtModelVehicle, "Invalid vehicle model!");
                kq = false;
            }
            return kq;
        }
        private bool GetVehicle()
        {
            if (!checkInfoVehicle()) return false;
            if (BUL.Vehicle_BUL.checkVehicle(txtIDVehicle.Text.Trim()))
            {
                MemoryStream picVehicleStream = new MemoryStream();
                picVehicle.Image.Save(picVehicleStream, picVehicle.Image.RawFormat);

                myContract.MyVehical = new Vehical_DTO(txtIDVehicle.Text
                    , txtModelVehicle.Text, cbTypeVehicle.Text,
                    picVehicleStream, 0);
                lblNoticeParkArea.Text = "";
                LoadParkArea(); // load các park area hợp lý cho xe chọn 
                return true;
            }
            lblNoticeVehicle.Text = "The vehicle already exists under another contract or is in the yard as a vehicle hold";
            return false;
        }
        public frmCreateContract()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        public frmCreateContract(Customer_DTO myCustomer)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            myContract = new Contract_DTO(myCustomer);
            // không cho người dùng chọn thời gian kết thúc contract -> hệ thống tự tính toán 
            dtpkDateFinish.Enabled = false;
        }
        #region code cho giao diện 
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
        private void pnTop_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void picExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmServiceForCustomer_Load(object sender, EventArgs e)
        {
            pnChooseService.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderTwo.BorderColor = Color.FromArgb(241, 241, 243);
            pnDate.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderThree.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseParkArea.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderFour.BorderColor = Color.FromArgb(241, 241, 243);

            lblNextXChooseService.Show();

            lblSkipInfoCar.Hide();
            lblNextDate.Hide();
            lblSkipChooseService.Hide();
            lblNextParkArea.Hide();
            lblSkipDate.Hide();
            lblFinish.Hide();

            processCompleted.Value = 0;
            lblValueCompleted.Text = "0%";
        }
        #endregion
        // Hoàn tất đăng ký thông tin xe
        private List<ContractDetail_DTO> GetContractDetail(List<Service_DTO> service_s)
        {
            List<ContractDetail_DTO> contractDetail = new List<ContractDetail_DTO>();
            foreach (Service_DTO service in service_s)
            {
                contractDetail.Add(new ContractDetail_DTO(new Contract_DTO(myContract.ContractId), new Service_DTO(service.ServiceId)));
            }
            return contractDetail;
        }
        // load những service đã chọn 
        private void loadService(List<Service_DTO> service_s)
        {
            lblNoticeMyservice.Text = "";
            flowService.Controls.Clear();
            if (service_s.Count == 0)
            {
                lblNoticeMyservice.Text = "You have not selected a service yet1!";
                return;
            }
            timeSpan = 0; // tính khoảng thời gian thực hiện hợp đồng 
            foreach (Service_DTO service in service_s)
            {
                flowService.Controls.Add(new UC_Controls.UC_Service(service));
                timeSpan += service.Time;
            }
        }
        /// <summary>
        /// check input vehicle
        /// </summary>
        private void lblNextXChooseService_Click(object sender, EventArgs e)
        {
            if (!GetVehicle()) return;
            // Khi điền xong thông tin sẽ mở luôn form để chọn dịch vụ cho xe
            this.Hide();
            var selectService = new frmChooseService(myContract.MyVehical.Type);
            selectService.ShowDialog();
            //
            myContract.MyContractDetail = GetContractDetail(selectService.Service_Selected);
            loadService(selectService.Service_Selected);
            //
            this.Show();
            #region design
            lblSkipInfoCar.Show();
            lblNextDate.Show();

            lblNextXChooseService.Hide();
            lblSkipChooseService.Hide();
            lblNextParkArea.Hide();
            lblSkipDate.Hide();
            lblFinish.Hide();


            pnInfoCar.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderOne.BorderColor = Color.FromArgb(241, 241, 243);
            pnDate.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderThree.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseParkArea.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderFour.BorderColor = Color.FromArgb(241, 241, 243);

            pnChooseService.BorderColor = Color.FromArgb(255, 234, 167);
            pnUnderTwo.BorderColor = Color.FromArgb(255, 234, 167);

            processCompleted.Value = 25;
            lblValueCompleted.Text = "25%";
            #endregion 
        }
        #region design
        // Quay lại chỉnh sửa thông tin xe
        private void lblSkipInfoCar_Click(object sender, EventArgs e)
        {
            lblNextXChooseService.Show();

            lblSkipInfoCar.Hide();
            lblNextDate.Hide();
            lblSkipChooseService.Hide();
            lblNextParkArea.Hide();
            lblSkipDate.Hide();
            lblFinish.Hide();

            pnInfoCar.BorderColor = Color.FromArgb(162, 155, 254);
            pnUnderOne.BorderColor = Color.FromArgb(162, 155, 254);

            pnChooseService.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderTwo.BorderColor = Color.FromArgb(241, 241, 243);
            pnDate.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderThree.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseParkArea.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderFour.BorderColor = Color.FromArgb(241, 241, 243);

            processCompleted.Value = 0;
            lblValueCompleted.Text = "0%";
        }

        // Hoàn tất chọn dịch vụ
        private void lblNextDate_Click(object sender, EventArgs e)
        {
            lblSkipChooseService.Show();
            lblNextParkArea.Show();

            lblSkipInfoCar.Hide();
            lblNextDate.Hide();
            lblNextXChooseService.Hide();
            lblSkipDate.Hide();
            lblFinish.Hide();

            pnInfoCar.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderOne.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseService.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderTwo.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseParkArea.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderFour.BorderColor = Color.FromArgb(241, 241, 243);

            pnDate.BorderColor = Color.FromArgb(255, 118, 117);
            pnUnderThree.BorderColor = Color.FromArgb(255, 118, 117);

            processCompleted.Value = 50;
            lblValueCompleted.Text = "50%";
        }



        // Quay lại để chọn dịch vụ
        private void lblSkipChooseService_Click(object sender, EventArgs e)
        {
            lblNextXChooseService_Click(sender, e);
        }



        // Hoàn tất chọn ngày hợp lệ
        private void lblNextParkArea_Click(object sender, EventArgs e)
        {
            // get date cho contract
            myContract.ReceiptDate = dtpkDateStart.Value;
            myContract.DeliveryDate = dtpkDateFinish.Value;

            lblSkipChooseService.Hide();
            lblNextParkArea.Hide();

            lblSkipInfoCar.Hide();
            lblNextDate.Hide();
            lblNextXChooseService.Hide();
            lblSkipDate.Show();
            lblFinish.Show();


            pnInfoCar.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderOne.BorderColor = Color.FromArgb(241, 241, 243);
            pnDate.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderThree.BorderColor = Color.FromArgb(241, 241, 243);
            pnChooseService.BorderColor = Color.FromArgb(241, 241, 243);
            pnUnderTwo.BorderColor = Color.FromArgb(241, 241, 243);

            pnChooseParkArea.BorderColor = Color.FromArgb(0, 184, 148);
            pnUnderFour.BorderColor = Color.FromArgb(0, 184, 148);

            processCompleted.Value = 75;
            lblValueCompleted.Text = "75%";
        }


        // Quay lại chọn ngày
        private void lblPreDate_Click(object sender, EventArgs e)
        {
            lblNextDate_Click(sender, e);
        }

        // Hoàn tất tất cả
        private void lblFinish_Click(object sender, EventArgs e)
        {
            #region
            lblSkipDate.Hide();
            lblFinish.Hide();

            pnInfoCar.BorderColor = Color.FromArgb(162, 155, 254);
            pnUnderOne.BorderColor = Color.FromArgb(162, 155, 254);

            pnChooseService.BorderColor = Color.FromArgb(255, 234, 167);
            pnUnderTwo.BorderColor = Color.FromArgb(255, 234, 167);

            pnDate.BorderColor = Color.FromArgb(255, 118, 117);
            pnUnderThree.BorderColor = Color.FromArgb(255, 118, 117);

            pnChooseParkArea.BorderColor = Color.FromArgb(0, 184, 148);
            pnUnderFour.BorderColor = Color.FromArgb(0, 184, 148);

            processCompleted.Value = 100;
            lblValueCompleted.Text = "100%";
            #endregion
        }
        #endregion
        private bool isUserInteraction = true; // Sử dụng cờ để kiểm tra xem sự kiện là do người dùng tương tác hay không

        private void dtpkDateStart_ValueChanged(object sender, EventArgs e)
        {
            if (!isUserInteraction)
            {
                return; // Tránh xử lý sự kiện khi không phải là do người dùng tương tác
            }

            lblNoticeDate.Text = "!";
            if (dtpkDateStart.Value < DateTime.Now)
            {
                lblNoticeDate.Text = "Invalid time!, StartTime > now and Start Time < Finish Time";
                isUserInteraction = false; // Tạm ngừng sự kiện để tránh vòng lặp
                dtpkDateStart.Value = DateTime.Now;
                isUserInteraction = true; // Kích hoạt lại sự kiện
                return;
            }
            dtpkDateFinish.Value = dtpkDateStart.Value.AddHours(timeSpan);
        }

        private void LoadParkArea()
        {
            cbChoosePark.DataSource = BUL.ParkArea_BUL.GetParkArea(myContract.MyVehical.Type);
            cbChoosePark.DisplayMember = "Address";
        }
        private void btnCreateContract_Click(object sender, EventArgs e)
        {
            if (BUL.Contract_BUL.InsertContract(myContract))
            {
                MessageBox.Show("The contract creation has been completed and is awaiting admin approval!", "Notice",
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.Close();
            }
            else
                MessageBox.Show("contract creation failed!", "Notice",
                   MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void cbChoosePark_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnLoadParkUC.Controls.Clear();
            pnLoadParkUC.Controls.Add(new UC_Controls.UC_ParkArea((ParkArea_DTO)cbChoosePark.SelectedValue));
            lblParkIDChoose.Text = ((ParkArea_DTO)cbChoosePark.SelectedValue).ParkAreaId;
            // get park area 
            myContract.MyParkArea = (ParkArea_DTO)cbChoosePark.SelectedValue;
        }
        /// <summary>
        /// nút import ảnh vehicle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblChooseImage_Click(object sender, EventArgs e)
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
                picVehicle.ImageLocation = filePath;
            }
        }
    }
}
