using BUL;
using DAL;
using DTO;
using MiniExcelLibs.OpenXml;
using MiniSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    /*public class ParkingForPrint
    {
        public static double Renuve ;
        private string vehicleId;
        private string checkIn;
        private string checkOut;
        private double price;

        public ParkingForPrint(string vehicleId, string checkIn, string checkOut, double price)
        {
            VehicleId = vehicleId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            Price = price;
        }

        public string VehicleId { get => vehicleId; set => vehicleId = value; }
        public string CheckIn { get => checkIn; set => checkIn = value; }
        public string CheckOut { get => checkOut; set => checkOut = value; }
        public double Price { get => price; set => price = value; }
    }*/
    public partial class frmViewVehicleEntryAndExitHistory : Form
    {
        private ParkArea_DTO myParkArea;
        private Fee_DTO myFee = BUL.Fee_BUL.GetFee();
        private List<Parking_DTO> parkingSelected = new List<Parking_DTO>(); 
        private List<Parking_DTO> GetParking (bool isCheckIn)
        {
            DateTime dateTime = dtpkTime.Value;
            List<Parking_DTO> Parkings;
            if (isCheckIn)
            {
                Parkings = BUL.Parking_BUL.GetParkingCheckInForAdmin(myParkArea, dateTime);
                lblTotalEnterCar.Text = Parkings.Count.ToString();
            }
            else
            {
                Parkings = BUL.Parking_BUL.GetParkingCheckOutForAdmin(myParkArea, dateTime);
                lblTotalExitCar.Text = Parkings.Count.ToString();
            }
            return Parkings;
        }
        private List<Parking_DTO> GetParking(bool isCheckIn, string VehicleId)
        {
            DateTime dateTime = dtpkTime.Value;
            List<Parking_DTO> Parkings;
            if (isCheckIn)
            {
                Parkings = BUL.Parking_BUL.GetParkingCheckInForAdmin(myParkArea, dateTime, VehicleId);
                lblTotalEnterCar.Text = Parkings.Count.ToString();
            }
            else
            {
                Parkings = BUL.Parking_BUL.GetParkingCheckOutForAdmin(myParkArea, dateTime,VehicleId);
                lblTotalExitCar.Text = Parkings.Count.ToString();
            }
            return Parkings;
        }
        private void LoadParking (bool isCheckIn)
        {
            var Parkings = GetParking(isCheckIn);
            flowPnParking.Controls.Clear ();
            parkingSelected.Clear();

            double renuve = 0;
            foreach (var parking in Parkings)
            {
                flowPnParking.Controls.Add(new UC_Controls.UC_ParkingForAdmin(parking));
                parkingSelected.Add(parking);
                if (!isCheckIn)
                {
                    TimeSpan duration = parking.CheckOut - parking.CheckIn;
                    renuve += myFee.FeeCalculation((int)duration.TotalHours, parking.ParkArea.Type);
                }
            }
            if (!isCheckIn) lblRenvenuetoday.Text = renuve.ToString() + "$";  
        }
        private void LoadParking(bool isCheckIn, string VehicleId)
        {
            var Parkings = GetParking(isCheckIn,VehicleId);
            flowPnParking.Controls.Clear();
            parkingSelected.Clear ();
            foreach (var parking in Parkings)
            {
                parkingSelected.Add(parking);
                flowPnParking.Controls.Add(new UC_Controls.UC_ParkingForAdmin(parking));
            }
        }
        public frmViewVehicleEntryAndExitHistory(ParkArea_DTO myParkArea)
        {
            InitializeComponent();
            this.myParkArea = myParkArea;
            GetParking(true);
            GetParking(false);
            rdCarIn.Checked = !rdCarIn.Checked;
            dtpkTime.Value = DateTime.Now;
            // 
            LoadStatic(cbStatic.Text);
        }

        private void dtpkTime_ValueChanged(object sender, EventArgs e)
        {
            GetParking(true);
            GetParking(false);
            rdCarIn.Checked = !rdCarIn.Checked;
        }

        private void txtSearchVehicle_TextChanged(object sender, EventArgs e)
        {
            LoadParking(rdCarIn.Checked,txtSearchVehicle.Text.Trim()) ;
        }

        private void rdCarIn_CheckedChanged(object sender, EventArgs e)
        {
            LoadParking(true) ;
        }

        private void rdCarOut_CheckedChanged(object sender, EventArgs e)
        {
            LoadParking(false);
        }
        #region code cho phần static
        private void LoadStatic (string criteria)
        {
            chartParking.Series["Month"].Points.Clear();
            string[] months = { "1","2","3","4","5","6","7","8","9","10","11","12"};/*{"Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6",
                       "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"};*/
            chartParking.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            chartParking.ChartAreas[0].AxisY.Title = criteria;
            chartParking.Series["Month"].Color = criteria == "Revenue" ? Color.Red : ColorTranslator.FromHtml("#74b9ff");
            for (int i = 0; i < months.Length; i++)
            {
                if (criteria == "Number Car Enterd")
                    chartParking.Series["Month"].Points.AddXY(months[i], Parking_BUL.GetParkingCheckInForAdmin(myParkArea, i + 1));
                else if (criteria == "Revenue")
                    chartParking.Series["Month"].Points.AddXY(months[i], Parking_BUL.GetParkingRevenueForAdmin(myParkArea, i + 1 ));
                else
                    chartParking.Series["Month"].Points.AddXY(months[i], Parking_BUL.GetParkingCheckOutForAdmin(myParkArea, i + 1));
            }
        }
        private void cbStatic_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatic(cbStatic.Text);
        }
        #endregion
        #region code giao diện 
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
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            txtSearchVehicle.Visible = false;
            rdCarIn.Visible = false;
            rdCarOut.Visible = false;
            Bitmap bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);

            // Vẽ nội dung của form lên bitmap
            this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

            // Hiển thị bitmap trong một hộp thoại xem trước khi in
            using (PrintDocument pd = new PrintDocument())
            {
                pd.PrintPage += (s, ev) =>
                {
                    // Tính tỷ lệ giữa kích thước của hình ảnh và kích thước của trang in
                    float scaleX = (float)ev.PageBounds.Width / bmp.Width;
                    float scaleY = (float)ev.PageBounds.Height / bmp.Height;
                    float scale = Math.Min(scaleX, scaleY);

                    // Tính toán kích thước mới của hình ảnh
                    int newWidth = (int)(bmp.Width * scale);
                    int newHeight = (int)(bmp.Height * scale);

                    // Tính toán vị trí cần vẽ để hình ảnh nằm giữa trang in
                    int x = (ev.PageBounds.Width - newWidth) / 2;
                    int y = (ev.PageBounds.Height - newHeight) / 2;

                    // Vẽ hình ảnh lên tài liệu in với kích thước mới và vị trí mới
                    ev.Graphics.DrawImage(bmp, x, y, newWidth, newHeight);
                };

                PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
                printPreviewDialog1.Document = pd;
                //
                printPreviewDialog1.ShowDialog();
            }
            btnPrint.Visible = true;
            txtSearchVehicle.Visible = true;
            rdCarIn.Visible = true;
            rdCarOut.Visible = true;
        }
        public string PATH_TEMPLATE_Worker = Application.StartupPath + "\\Template\\TemplateParking.docx";
        public string PATH_EXPORT_Worker = Application.StartupPath + "\\export.docx";
        private List<ParkingForPrint> ConvertParking ()
        {
            ParkingForPrint.Renuve = 0;
            List<ParkingForPrint> parkingForPrints = new List<ParkingForPrint>();
            //chuyển đổi dữ liệu 
            foreach (var parking in parkingSelected)
            {
                string checkOut = "";
                double Price = 0;
                if (parking.CheckOut != DateTime.MinValue)
                {
                    TimeSpan duration = parking.CheckOut - parking.CheckIn;
                    Price = myFee.FeeCalculation((int)duration.TotalHours, parking.ParkArea.Type);
                    ParkingForPrint.Renuve += Price;
                    checkOut = parking.CheckOut.ToString();
                }
                else
                    checkOut = "The car has not left the lot yet";
                parkingForPrints.Add(new ParkingForPrint(parking.Vehicle.VehicleId, parking.CheckIn.ToString(), checkOut, Price));
            }
            return parkingForPrints;
        } 
        private void PrintHistoryParking()
        {
            try
            {
                var data = ConvertParking().ToArray();
                // 
                var config = new OpenXmlConfiguration()
                {
                    IgnoreTemplateParameterMissing = false,
                };
                string status = "";
                if (rdCarIn.Checked) status = "In";
                else
                {
                    status = "Out";
                }
                var value = new
                {
                    inorexit = status,
                    Parking = data,
                    date = dtpkTime.Value.ToString("yyyy-MM-dd") ,
                    ParkAreaId = myParkArea.ParkAreaId ,
                    ParkAreaName = myParkArea.Address ,
                    ParkAreaType = myParkArea.Type ,
                    Renuve = ParkingForPrint.Renuve +" $",
                };

                MiniWord.SaveAsByTemplate(PATH_EXPORT_Worker, PATH_TEMPLATE_Worker, value);

                Process.Start(PATH_EXPORT_Worker);
            }
            catch
            {
                MessageBox.Show("export file is being accessed elsewhere", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PrintHistoryParking();
        }
    }
}
