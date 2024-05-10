using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;
using DAL;
using DTO;
using BUL;
using System.IO;
using static System.Net.WebRequestMethods;
using AForge.Neuro;
using ParkingLotManagementt.Setup;
using System.Drawing.Imaging;
using AForge.Video;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

namespace ParkingLotManagementt.Forms
{
    public partial class frmMainWorkerPaking : Form
    {
        private Fee_DTO fee = Fee_BUL.GetFee(); // lớp này để tính tiền cho xe gửi
        private MemoryStream avatarVehicle = new MemoryStream();
        private MemoryStream avatarCustomer = new MemoryStream();
        Worker_DTO myWorker;

        // Biến kiểm tra xem có phải bãi giữ xe đạp hay không
        bool isBicycleArea;


        private void SetMyWorker()
        {
            isBicycleArea = (myWorker.ParkArea.ParkAreaId != "3") ? false : true;

            lblWorkerID.Text = myWorker.WorkerId;
            txtNameWorker.Text = myWorker.FullName;
            try
            {
                picAvatarOfWorker.Image = (myWorker.Picture != null) ? System.Drawing.Image.FromStream(myWorker.Picture) : picAvatarOfWorker.Image;
                //infor 
                picAvartarCustomer.Image = (myWorker.Picture != null) ? System.Drawing.Image.FromStream(myWorker.Picture) : picAvartarCustomer.Image;
            }
            catch { }
            txtIDWorker.Text = myWorker.WorkerId;
            txtCustomerFullName.Text = myWorker.FullName;
            txtParAreaCustomer.Text = myWorker.ParkArea.Address;
            txtTypeWorker.Text = myWorker.Type;
            txtAddressWorker.Text = myWorker.Address;
            if (myWorker.Account != null)
            {
                txtUserName.Text = myWorker.Account.UserName;
                txtGmail.Text = myWorker.Account.Email;
            }
        }
        public frmMainWorkerPaking(Worker_DTO myWorker)
        {
            InitializeComponent();
            ChangeButton(btnDashboard, btnCalender, btnSetting);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            this.myWorker = myWorker;
            SetMyWorker();

            lblParkAreaID.Text = myWorker.ParkArea.ParkAreaId.ToString();
            txtTypeVehicle.Text = myWorker.ParkArea.Type.ToString();
            lblParkAreaIDForSchedule.Text = myWorker.ParkArea.ParkAreaId.ToString();
            lblWorkerIDForSchedule.Text = myWorker.WorkerId.ToString();


            // set bảng giá 
            lblPriceBicycle.Text = fee.FeeBicycle + "$";
            lblPriceCar.Text = fee.FeeCar + "$";
            lblPriceMoto.Text = fee.FeeMoto + "$";
            //
            // Khởi tạo giá trị
            realTime.Start();
            capture = new Capture();
            isStreaming = false;
            picStartRecord.Hide();
            picRecord.Show();
        }

        

        #region Code giao diện 
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

        // Hàm thay đổi giao diện nút khi click
        private void ChangeButton(Guna2Button btnChoose, Guna2Button btnNotOne, Guna2Button btnNotTwo)
        {
            btnNotOne.ForeColor = Color.FromArgb(9, 132, 227);
            btnNotTwo.ForeColor = Color.FromArgb(9, 132, 227);
            btnNotOne.FillColor = Color.White;
            btnNotTwo.FillColor = Color.White;

            btnChoose.ForeColor = Color.White;
            btnChoose.FillColor = Color.FromArgb(9, 132, 227);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ChangeButton(btnDashboard, btnCalender, btnSetting);
            pnDashboard.Show();
            pnSchedule.Hide();
            pnSetting.Hide();
        }

        private void btnCalender_Click(object sender, EventArgs e)
        {
            ChangeButton(btnCalender, btnDashboard, btnSetting);
            pnDashboard.Hide();
            pnSchedule.Show();
            pnSetting.Hide();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ChangeButton(btnSetting, btnDashboard, btnCalender);
            pnDashboard.Hide();
            pnSetting.Show();
            pnSchedule.Hide();
        }

        // Hàm triển khai real time
        private void realTime_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblRealTime.Text = "Real time: " + now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        #endregion


        #region Phần quản lý khi xe ra vào

        #region Xử lý phần chụp ảnh và nhận ảnh

        bool isStreaming;
        Capture capture;

        // Bật camera
        private void Streaming(object sender, EventArgs e)
        {
            var img = capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            picPreview.Image = bmp;
        }

        // Click load camera (ON/OFF)
        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (!isStreaming)
            {
                Application.Idle += Streaming;
                picRecord.Hide();
                picStartRecord.Show();
                btnLoadCamera.Text = "OFF";
                btnLoadCamera.BorderColor = Color.Red;
                btnLoadCamera.ForeColor = Color.Red;
            }
            else
            {
                Application.Idle -= Streaming;
                picRecord.Show();
                picStartRecord.Hide();
                btnLoadCamera.Text = "ON";
                btnLoadCamera.BorderColor = Color.FromArgb(9, 132, 227);
                btnLoadCamera.ForeColor = Color.FromArgb(9, 132, 227);
            }
            isStreaming = !isStreaming;
            btnCapture.Enabled = isStreaming;
        }

        // Xử lý chụp ảnh cho ảnh khách và xe của khách
        private void btnCapture_Click(object sender, EventArgs e)
        {
            
            try
            {
                picImageFromSystem.Image = (System.Drawing.Image)picPreview.Image.Clone();
                ImagePlate = new clsImagePlate(new Bitmap(picImageFromSystem.Image));

                ImageCodecInfo jpegEncoder = GetEncoder(ImageFormat.Jpeg);
                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                encoderParameters.Param[0] = encoderParameter;
                if (rbtnCustomer.Checked)
                {
                    picImageFromSystem.Image.Save(avatarCustomer, jpegEncoder, encoderParameters);
                    //
                    picCustomerImage.Image =(System.Drawing.Image)picImageFromSystem.Image.Clone();
                }
                else
                {
                    picImageFromSystem.Image.Save(avatarVehicle, jpegEncoder, encoderParameters);
                    //
                    picAvatarCar.Image = (System.Drawing.Image)picImageFromSystem.Image.Clone();
                    LoadDataForParking();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        // Xử lý chọn ảnh từ hệ thống
        private void btnGetImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.InitialDirectory = Application.StartupPath + "\\foreground";
            op.Filter = ("Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG files (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files(*.*)|*.*");
            if (op.ShowDialog() == DialogResult.OK)
            {

                
                try
                {
                    StreamReader bitmap_file_stream = new StreamReader(op.FileName);
                    ImagePlate = new clsImagePlate(new Bitmap(op.FileName));

                    bitmap_file_stream.Close();

                    picImageFromSystem.Image = ImagePlate.IMAGE;
                    if (rbtnCustomer.Checked)
                    {
                        picImageFromSystem.Image.Save(avatarCustomer,picImageFromSystem.Image.RawFormat); 
                        picCustomerImage.Image = (System.Drawing.Image)picImageFromSystem.Image.Clone();
                    }
                    else
                    {
                        picImageFromSystem.Image.Save(avatarVehicle, picImageFromSystem.Image.RawFormat);
                        picAvatarCar.Image = (System.Drawing.Image)picImageFromSystem.Image.Clone();
                        LoadDataForParking();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message);
                }

            }
        }

        // Hàm load dữ liệu (khi đã biết đó là check in hay check out)
        private void LoadDataForParking()
        {
            // Kiểm tra xem nếu bãi hiện tại là xe đạp thì thực hiện lấy id tự động và đưa thẻ cho khách
            if (!isBicycleArea)
            {
                lblLicensePalte.Text = LicenseRevese();
            } 
            else
            {
                lblLicensePalte.Text = "This is bicycle";
            }
            

            // Kiểm tra xe đã tồn tại hay chưa, nếu đúng thì load dữ liệu của xe đã tồn tại
            // và thực hiện check out

            try
            {
                Parking_DTO parking = Parking_BUL.GetParkingToCheckOut(lblLicensePalte.Text);

                if (parking != null)
                {
                    txtParkingID.Text = parking.ParkingId.ToString();
                    txtCheckIn.Text = parking.CheckIn.ToString();
                    txtCheckOut.Text = DateTime.Now.ToString();
                    txtIdVehicle.Text = parking.Vehicle.VehicleId.ToString();
                    txtModelVehicle.Text = parking.Vehicle.Model.ToString();
                    try 
                    {
                        picCustomerImage.Image = System.Drawing.Image.FromStream(parking.Vehicle.PictureCustomer);
                        picAvatarCar.Image = System.Drawing.Image.FromStream(parking.Vehicle.PictureVehicle);
                    }
                    catch {}
                    // tiến hành tính tiền nếu check out
                    TimeSpan duration = parking.CheckOut - parking.CheckIn;
                    double hours = Math.Round(duration.TotalHours, 1);
                    //
                    if (hours <= 24) lblNote.Text = "Nothing !";
                    else if (hours > 24 && hours <= 168) lblNote.Text = "Car sent more than 1 day !";
                    else if (hours > 168 && hours <= 720) lblNote.Text = "Car has been sent for more than 1 week !";
                    else if (hours > 720) lblNote.Text = "Car has been sent for more than 1 month !";
                    //
                    lblTimePark.Text = hours.ToString() + " hours";
                    lblPrice.Text = fee.FeeCalculation((int)hours, myWorker.ParkArea.Type) + "$"; // tính tiền 
                                                                                 //
                }


                // Nếu xe chưa có trong parking thì tiến hành lấy dữ liệu xe từ khách hàng load lên các ô thông tin
                else
                {
                    // Nếu là xe đạp phải gán id khác
                    if (isBicycleArea)
                    {
                        // Tiến hành lấy số lượng parking hiện tại để đặt làm id
                        var capacity = BUL.Parking_BUL.GetParking().Count;
                        txtParkingID.Text = "Park|" + capacity.ToString();
                        txtIdVehicle.Text = capacity.ToString();
                        // Mã số xe sẽ tự nhập
                        //txtIdVehicle.PlaceholderText = "Please enter number of customer";
                        txtIdVehicle.ReadOnly = false;
                    }
                    else
                    {
                        txtParkingID.Text = lblLicensePalte.Text + "|" + lblParkAreaID.Text + "|" + DateTime.Now.ToString();
                        txtIdVehicle.Text = lblLicensePalte.Text;
                        txtIdVehicle.ReadOnly = true;
                    }
                    //txtIdVehicle.ReadOnly = false;
                    txtCheckIn.Text = DateTime.Now.ToString();
                    txtCheckOut.Text = DBNull.Value.ToString();

                    txtModelVehicle.PlaceholderText = "You must enter model car !";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Errol is: " + ex.Message, "Errol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // Lưu ảnh (chưa dùng đến)
        private void btnSave_Click(object sender, EventArgs e)
        {
            var saveFileDiaLog = new SaveFileDialog();
            saveFileDiaLog.Title = "Save your picture";
            if (saveFileDiaLog.ShowDialog() == DialogResult.OK)
            {
                picImageFromSystem.Image.Save(saveFileDiaLog.FileName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Save successful !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        // Lưu ý: Khi thực hiện nhận ảnh và xử lý, kiểm tra biển số xe và thgian checkout trong Parking
        // Nếu chưa có trong Parking thì nghĩa là xe check in
        // Nếu thời gian khác NULL thì xe check out
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            throw new InvalidOperationException("Không tìm thấy encoder phù hợp cho định dạng ảnh này.");
        }


        #region Quá trình lưu dữ liệu của xe và đưa xe vào bãi (Check in)

        private bool InsertParking ()
        {
            try
            {

                DateTime checkInTmp = DateTime.Now;

                DateTime checkOutTmp = DateTime.Now;

                ParkArea_DTO parkArea = myWorker.ParkArea;


                Vehicle_Parking_DTO vehicle = new Vehicle_Parking_DTO(txtIdVehicle.Text, avatarCustomer, avatarVehicle, txtModelVehicle.Text, txtTypeVehicle.Text);


                Parking_DTO parking = new Parking_DTO(txtParkingID.Text, vehicle, parkArea, (checkInTmp), (checkOutTmp));

                return Parking_BUL.InsertParking(parking);
            }
            catch (Exception ex)
            {
                MessageBox.Show("(system error) "+ ex.ToString());
                return false;
            }
        }

        #endregion



        #region Quá trình check out cho xe

        private bool ReleaseParking()
        {
            DateTime checkOut = DateTime.Now;

            if(isBicycleArea)
            {
                return Parking_DAL.SetParkingForCheckOutForBicycle("Park|" + txtIdVehicle.Text, checkOut);
            }
            return Parking_DAL.SetParkingForCheckOut(txtIdVehicle.Text, checkOut);
        }

        #endregion

        #region Xử lý ảnh nhận từ Setup

        clsImagePlate ImagePlate;
        clsLicensePlate LicensePlate;
        clsNetwork Network;


        private string LicenseRevese()
        {
            ImagePlate.Get_Plate();
            LicensePlate = new clsLicensePlate();
            LicensePlate.PLATE = ImagePlate.PLATE;

            LicensePlate.Split(ImagePlate.Plate_Type);

            //recognize
            Network.IMAGEARR = LicensePlate.IMAGEARR;
            int sum = LicensePlate.getsumcharacter();
            Network.recognition(sum, ImagePlate.Plate_Type);
            return Network.LICENSETEXT.Trim();
        }

        #endregion

        

        // Nút checkin
        private void btnAccess_Click(object sender, EventArgs e)
        {
            if (InsertParking())
            {
                MessageBox.Show("Sucessfully for CHECK IN this car !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Errol CHECK IN for this car !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Nút checkout
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (ReleaseParking())
            {
                MessageBox.Show("Sucessfully for CHECK OUT this car !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Errol CHECK OUT for this car !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbtnVehicle_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void rbtnCustomer_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        #endregion


        #region Phần xem lịch làm của bản thân

        private Dictionary<string, List<string>> schedule;
        private List<Worker_DTO> workerList;

        private List<string> workerNames;

        // Tương tác và cập nhật UI
        private Dictionary<string, Guna2Panel> panelMap = new Dictionary<string, Guna2Panel>();

        private void UpdateScheduleUI(Guna2Panel panel, string day, string shift)
        {
            // Lấy ra danh sách nhân viên cho ca đó
            string panelKey = $"pn{shift}{day}";

            var workerNames = schedule.ContainsKey(panelKey) ? schedule[panelKey] : new List<string>();
            // Kiểm tra và làm nổi bậc các ô mà mình được phân công

            try
            {
                if (workerNames.Count > 0 && (workerNames[0] == myWorker.FullName || workerNames[1] == myWorker.FullName))
                {
                    // Tạo labels
                    Guna2HtmlLabel lblTime = new Guna2HtmlLabel();
                    lblTime.Location = new Point(31, 32);
                    lblTime.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                    lblTime.AutoSize = true;

                    if (panel.Name[2].ToString() == "M")
                    {
                        lblTime.Text = "7:00 - 12:00";
                    }
                    else if (panel.Name[2].ToString() == "A")
                    {
                        lblTime.Text = "12:00 - 17:00";
                    }
                    else
                    {
                        lblTime.Text = "17:00 - 22:00";
                    }

                    Guna2HtmlLabel lblTitle = new Guna2HtmlLabel();
                    lblTitle.Location = new Point(65, 70);
                    lblTitle.Font = new Font("Century Gothic", 9, FontStyle.Bold);
                    lblTitle.AutoSize = true;
                    lblTitle.Text = "Shift";

                    Guna2HtmlLabel lblPeopleOne = new Guna2HtmlLabel();
                    lblPeopleOne.Location = new Point(5, 105);
                    lblPeopleOne.Font = new Font("Times New Roman", 8, FontStyle.Regular);
                    lblPeopleOne.AutoSize = true;
                    if (workerNames[0] == myWorker.FullName)
                    {
                        lblPeopleOne.Text = "You with";
                    }
                    else
                    {
                        lblPeopleOne.Text = workerNames[0];
                    }


                    Guna2HtmlLabel lblPeopleTwo = new Guna2HtmlLabel();
                    lblPeopleTwo.Location = new Point(5, 135);
                    lblPeopleTwo.Font = new Font("Times New Roman", 8, FontStyle.Regular);
                    lblPeopleTwo.AutoSize = true;
                    if (workerNames[1] != myWorker.FullName)
                    {
                        lblPeopleTwo.Text = workerNames[1]; ;
                    }
                    else
                    {
                        lblPeopleTwo.Text = "and You";
                    }


                    // Tạo picture box: Nếu màu xanh là đã làm ca này, màu vàng là chưa làm
                    Guna2CirclePictureBox current = new Guna2CirclePictureBox();
                    current.Location = new Point(5, 5);
                    current.Size = new Size(15, 15);
                    current.FillColor = Color.FromArgb(255, 177, 66);



                    // Xóa các control cũ để tránh trùng lặp
                    panel.Controls.Clear();

                    // Thêm các control vào panel
                    panel.Controls.Add(lblTime);
                    panel.Controls.Add(lblTitle);
                    panel.Controls.Add(lblPeopleOne);
                    panel.Controls.Add(lblPeopleTwo);
                    panel.Controls.Add(current);
                }
            }
            catch
            {
                MessageBox.Show("Can't show UI for schedule", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Tiến hành gener vào các panel
        public void RefreshAllPanels()
        {
            UpdateScheduleUI(panelMap["pnMorningMon"], "Mon", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonMon"], "Mon", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningMon"], "Mon", "Evening");

            UpdateScheduleUI(panelMap["pnMorningTue"], "Tue", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonTue"], "Tue", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningTue"], "Tue", "Evening");

            UpdateScheduleUI(panelMap["pnMorningWed"], "Wed", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonWed"], "Wed", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningWed"], "Wed", "Evening");

            UpdateScheduleUI(panelMap["pnMorningThu"], "Thu", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonThu"], "Thu", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningThu"], "Thu", "Evening");

            UpdateScheduleUI(panelMap["pnMorningFri"], "Fri", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonFri"], "Fri", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningFri"], "Fri", "Evening");

            UpdateScheduleUI(panelMap["pnMorningSat"], "Sat", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonSat"], "Sat", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningSat"], "Sat", "Evening");

            UpdateScheduleUI(panelMap["pnMorningSun"], "Sun", "Morning");
            UpdateScheduleUI(panelMap["pnAfternoonSun"], "Sun", "Afternoon");
            UpdateScheduleUI(panelMap["pnEveningSun"], "Sun", "Evening");
        }

        private List<DateTime> GetRangeWeek()
        {
            DateTime selectedDate = dateChoose.Value;

            // Tính ngày thứ Hai của tuần
            int daysUntilMonday = DayOfWeek.Monday - selectedDate.DayOfWeek;
            if (daysUntilMonday > 0) daysUntilMonday -= 7; // Nếu qua thứ Hai tuần sau, trừ đi 7 ngày
            DateTime dateStart = selectedDate.AddDays(daysUntilMonday);

            // Tính ngày Chủ Nhật của tuần
            int daysUntilSunday = DayOfWeek.Sunday - selectedDate.DayOfWeek;
            if (daysUntilSunday < 0) daysUntilSunday += 7; // Nếu đã qua Chủ Nhật, cộng thêm 7 ngày
            DateTime dateEnd = selectedDate.AddDays(daysUntilSunday);

            return new List<DateTime> { dateStart, dateEnd };
        }

        public void GenerateWeeklySchedule()
        {
            var daysOfWeek = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            var shifts = new[] { "Morning", "Afternoon", "Evening" };
            var random = new Random();

            // Khởi tạo schedule
            foreach (var day in daysOfWeek)
            {
                foreach (var shift in shifts)
                {
                    string key = $"pn{shift}{day}";
                    if (!schedule.ContainsKey(key))
                    {
                        schedule[key] = new List<string>();
                    }
                }
            }

            Dictionary<string, string> lastShift = new Dictionary<string, string>();
            Dictionary<string, int[]> shiftCounts = new Dictionary<string, int[]>();
            foreach (var worker in workerNames)
            {
                shiftCounts[worker] = new int[3]; // Khởi tạo mảng đếm ca
                lastShift[worker] = ""; // Khởi tạo ca cuối cùng là trống để lưu nhân viên cuối cùng đã làm việc của ca đó
            }

            foreach (var day in daysOfWeek)
            {
                foreach (var shift in shifts)
                {
                    string scheduleKey = $"pn{shift}{day}";
                    var orderedWorkers = workerNames
                        .Where(worker => lastShift[worker] != scheduleKey && !lastShift[worker].EndsWith(day)) // Loại bỏ người làm ca trước và cùng ngày ca trước
                        .OrderBy(worker => shiftCounts[worker][Array.IndexOf(shifts, shift)])
                        .ThenBy(worker => Guid.NewGuid())
                        .ToList();

                    int neededWorkers = 2; // Số lượng nhân viên cần thiết cho mỗi ca
                    foreach (var worker in orderedWorkers)
                    {
                        if (schedule[scheduleKey].Count >= neededWorkers)
                            break;

                        schedule[scheduleKey].Add(worker);
                        shiftCounts[worker][Array.IndexOf(shifts, shift)]++;
                        lastShift[worker] = shift + day; // Lưu ca làm cuối cùng
                    }
                }
            }
        }



        private void LoadScheduleFromDatabase()
        {
            try
            {
                List<DateTime> rangeWeek = GetRangeWeek();
                DateTime dateStart = rangeWeek[0];
                DateTime dateEnd = rangeWeek[1];

                List<Schedule_DTO> schedulesWorkerFromDb = Schedule_BUL.GetSchedule(dateStart, dateEnd);

                foreach (var panel in panelMap.Values)
                {
                    panel.Controls.Clear();
                }

                foreach (var key in schedule.Keys.ToList())
                {
                    schedule[key] = new List<string>();
                }

                foreach (var scheduleDto in schedulesWorkerFromDb)
                {
                    string panelKey = $"pn{scheduleDto.Shift}{scheduleDto.DayOfWeek}";
                    if (schedule.ContainsKey(panelKey))
                    {
                        schedule[panelKey].Add(scheduleDto.WorkerID.FullName);

                        // Lưu trữ ScheduleID vào Tag của panel: Mỗi khi cập nhạt panel thì IDSchedule cũng sẽ được
                        // cập nhật tương ứng để tiện cho việc đánh ca

                        // Ta cần phải thay đổi Tag ID để lấy chính xác nhân viên thực hiện đánh ca: Vì mỗi ca có 2 người
                        // được random tự động nên Tag kh thể xác định chính xác được ID nên cần hàm thay thế tag cho đúng
                        // với ID của nhân viên đang truy cập

                        string newScheduleID = ReplaceIdInString(scheduleDto.ScheduleID, myWorker.WorkerId);
                        // MessageBox.Show(newScheduleID);
                        panelMap[panelKey].Tag = newScheduleID;
                    }
                }

                RefreshAllPanels();
            }
           catch (Exception ex)
            {
                MessageBox.Show("Can't show UI for schedule", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm thay đổi tag như trên
        public string ReplaceIdInString(string originalString, string newId)
        {
            // Giả sử rằng chuỗi luôn kết thúc bằng dạng ngày tháng là 9 ký tự (Fri20240408)
            int lengthOfDate = 11;

            // Lấy phần ngày tháng từ cuối chuỗi
            string datePart = originalString.Substring(originalString.Length - lengthOfDate, lengthOfDate);

            // Kết hợp ID mới với phần ngày tháng
            return newId + datePart;
        }

        private void dateChoose_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                LoadScheduleFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errol");
            }
        }

        #endregion


        #region Thực hiện đánh ca để điểm danh

        // Giả lập xử lý sự kiện click
        Guna2Panel lastClickPanel = null;

        private void panel_Click(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = sender as Guna2Panel;
            if (lastClickPanel != null)
            {
                lastClickPanel.BorderColor = Color.FromArgb(178, 190, 195);
                lastClickPanel.BackColor = Color.White;
            }
            clickedPanel.BorderColor = Color.FromArgb(64, 73, 94);
            clickedPanel.BackColor = Color.FromArgb(130, 204, 221);
            lastClickPanel = clickedPanel;
        }

        // Đánh ca
        private void btnCheckShift_Click(object sender, EventArgs e)
        {
            // Trường hợp click vào chỗ không có ca của mình
            if(lastClickPanel.Controls.Count == 0)
            {
                MessageBox.Show("Lỗi khi đánh dấu ca. Vui lòng thử lại!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Trường hợp đánh ca nhiều lần
            if(Schedule_BUL.GetSchedule(lastClickPanel.Tag.ToString()).Status == 1)
            {
                MessageBox.Show("Bạn đã đánh ca này rồi!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control control in lastClickPanel.Controls)
                {
                    if (control is Guna2CirclePictureBox current)
                    {
                        current.FillColor = Color.FromArgb(22, 160, 133);
                    }
                }
                return;
            }

            if (lastClickPanel != null && lastClickPanel.Tag != null)
            {
                string scheduleId = lastClickPanel.Tag.ToString();
                bool success = Schedule_BUL.CheckInWorker(scheduleId);
                if (success)
                {
                    MessageBox.Show("Đã đánh dấu vào ca thành công!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    foreach (Control control in lastClickPanel.Controls)
                    {
                        if (control is Guna2CirclePictureBox current)
                        {
                            current.FillColor = Color.FromArgb(22, 160, 133);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi đánh dấu ca. Vui lòng thử lại!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một ca làm việc trước khi đánh dấu!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void frmMainWorkerPaking_Load(object sender, EventArgs e)
        {
            Network = new clsNetwork();
            Network.AutoLoadNetworkChar();
            Network.AutoLoadNetworkNum();



            workerList = Worker_BUL.GetWorkerWithType("Look");

            workerNames = new List<string>();
            foreach (var worker in workerList)
            {
                workerNames.Add(worker.FullName);
            }

            // Khởi tạo schedule sau khi đã có workerNames
            schedule = new Dictionary<string, List<string>>();
            foreach (var name in workerNames)
            {
                schedule[name] = new List<string>();
            }

            #region Map toàn bộ 21 panel vào Dic để cập nhật

            panelMap["pnMorningMon"] = pnMoringMon;
            panelMap["pnAfternoonMon"] = pnAfterMon;
            panelMap["pnEveningMon"] = pnEvenMon;

            panelMap["pnMorningTue"] = pnMorningTue;
            panelMap["pnAfternoonTue"] = pnAfterTue;
            panelMap["pnEveningTue"] = pnEvenTue;

            panelMap["pnMorningWed"] = pnMorningWed;
            panelMap["pnAfternoonWed"] = pnAfterWed;
            panelMap["pnEveningWed"] = pnEvenWed;

            panelMap["pnMorningThu"] = pnMorningThu;
            panelMap["pnAfternoonThu"] = pnAfterThu;
            panelMap["pnEveningThu"] = pnEvenThu;

            panelMap["pnMorningFri"] = pnMorningFri;
            panelMap["pnAfternoonFri"] = pnAfterFri;
            panelMap["pnEveningFri"] = pnEvenFri;

            panelMap["pnMorningSat"] = pnMorningSat;
            panelMap["pnAfternoonSat"] = pnAfterSat;
            panelMap["pnEveningSat"] = pnEvenSat;

            panelMap["pnMorningSun"] = pnMorningSun;
            panelMap["pnAfternoonSun"] = pnAfterSun;
            panelMap["pnEveningSun"] = pnEvenSun;

            #endregion

            GenerateWeeklySchedule();

            picSeachParking.Visible = isBicycleArea ? true : false;
        }

        #region code cho phần chỉnh sửa thông tin 
        private bool CheckInput()
        {
            bool wasError = true;
            if (!InputCheck.CheckInput.Name(txtCustomerFullName.Text))
            {
                wasError = false;
                error.SetError(txtCustomerFullName, "Full name not valid!");
            }
            if (!InputCheck.CheckInput.AddressIsValid(txtAddressWorker.Text)) {
                wasError = false;
                error.SetError(txtAddressWorker, "Address not valid !");
            }
            return wasError;
        }
        private void GetCustomer()
        {
            myWorker.FullName = txtCustomerFullName.Text;
            myWorker.Address = txtAddressWorker.Text;
            MemoryStream picWorker = new MemoryStream();
            picAvartarCustomer.Image.Save(picWorker, picAvartarCustomer.Image.RawFormat);
            myWorker.Picture = picWorker;
        }
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            GetCustomer();
            if (BUL.Worker_BUL.UpdateWorker(myWorker))
            {
                lblNoticeInfo.Text = "Edited information successfully!";
                SetMyWorker();
            }
            else
            {
                lblNoticeInfo.Text = "(system error) failed to edit information";
            }
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
                picAvartarCustomer.ImageLocation = filePath;
            }
        }
        #endregion

        // Tìm kiếm xe đạp trong bãi

        private void picSeachParking_Click(object sender, EventArgs e)
        {

            if(txtIdVehicle.Text == "")
            {
                return;
            }

            try
            {
                var bicycle = BUL.Parking_BUL.GetParking("Park|" + txtIdVehicle.Text,true);
                if (bicycle == null)
                {
                    return;
                }

                txtIdVehicle.Text = bicycle.Vehicle.VehicleId;
                txtParkingID.Text = bicycle.ParkingId;
                txtCheckIn.Text = bicycle.CheckIn.ToString("yyyy-MM-dd HH:mm:ss");
                txtCheckOut.Text = bicycle.CheckOut.ToString("yyyy-MM-dd HH:mm:ss");
                txtTypeVehicle.Text = "Bicycle";
                txtModelVehicle.Text = bicycle.Vehicle.Model;
                picAvatarCar.Image = System.Drawing.Image.FromStream(bicycle.Vehicle.PictureVehicle);
                //
                // tiến hành tính tiền nếu check out
                
                TimeSpan duration = bicycle.CheckOut - bicycle.CheckIn;
                double hours = Math.Round(duration.TotalHours, 1);
                //
                if (hours <= 24) lblNote.Text = "Nothing !";
                else if (hours > 24 && hours <= 168) lblNote.Text = "Car sent more than 1 day !";
                else if (hours > 168 && hours <= 720) lblNote.Text = "Car has been sent for more than 1 week !";
                else if (hours > 720) lblNote.Text = "Car has been sent for more than 1 month !";
                //
                lblTimePark.Text = hours.ToString() + " hours";
                lblPrice.Text = fee.FeeCalculation((int)hours, myWorker.ParkArea.Type) + "$"; // tính tiền 
                                                                                              //
            }
            catch { }
        }
    }
}
