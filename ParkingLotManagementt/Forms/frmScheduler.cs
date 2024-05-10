using BUL;
using DTO;
using Emgu.CV.XFeatures2D;
using Guna.UI2.WinForms;
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
using ZedGraph;

namespace ParkingLotManagementt.Forms
{
    public partial class frmScheduler : Form
    {
        public frmScheduler()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }


        #region Code cho giao diện 
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

        // Giả lập xử lý sự kiện
        Guna2Panel lastClickPanel = null;

        private void panel_Click(object sender, EventArgs e)
        {
            Guna2Panel clickedPanel = sender as Guna2Panel;
            if (lastClickPanel != null)
            {

                lastClickPanel.BorderColor = Color.FromArgb(178, 190, 195);
            }
            clickedPanel.BorderColor = Color.FromArgb(64, 73, 94);
            lastClickPanel = clickedPanel;
        }


        #endregion

        private List<Worker_DTO> workerList;

        private List<string> workerNames;
        private Dictionary<string, List<string>> schedule;
        private int maxShiftsPerDay = 2;

        // Tương tác và cập nhật UI
        private Dictionary<string, Guna2Panel> panelMap = new Dictionary<string, Guna2Panel>();

        private void frmScheduler_Load(object sender, EventArgs e)
        {
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

            // Khởi chạy một số vùng nhớ cần thiết
            GenerateWeeklySchedule();

            #region Map toàn bộ 21 panel vào Dic để cập nhật

            panelMap["pnMorningMon"] = pnMorningMon;
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

            
            // Lấy ra các khu
            GetPartAreaToCb();

        }

        // Tiến hành chọn parkarea trước khi phân ca
        private void GetPartAreaToCb()
        {
            var listParkArea = BUL.ParkArea_BUL.GetParkArea();
            foreach(var park in listParkArea)
            {
                cbParkArea.Items.Add($"{park.ParkAreaId}: {park.Type}");
            }
        }

        #region Phân ca

        // Cập nhật UI khi thực hiện phân ca
        private void UpdateScheduleUI(Guna2Panel panel, string day, string shift)
        {
            // Tạo labels
            Guna2HtmlLabel lblTime = new Guna2HtmlLabel();
            lblTime.Location = new Point(31, 32);
            lblTime.Font = new Font("Century Gothic", 9, FontStyle.Bold);
            lblTime.AutoSize = true;

            if(panel.Name[2].ToString() == "M")
            {
                lblTime.Text = "7:00 - 12:00";
            }
            else if(panel.Name[2].ToString() == "A")
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

            // Lấy ra danh sách nhân viên cho ca đó
            string panelKey = $"pn{shift}{day}";

            var workerNames = schedule.ContainsKey(panelKey) ? schedule[panelKey] : new List<string>();


            Guna2HtmlLabel lblPeopleOne = new Guna2HtmlLabel();
            lblPeopleOne.Location = new Point(5, 105);
            lblPeopleOne.Font = new Font("Times New Roman", 8, FontStyle.Regular);
            lblPeopleOne.AutoSize = true;
            lblPeopleOne.Text = workerNames.Count > 0 ? workerNames[0] : "No Worker Assigned";

            Guna2HtmlLabel lblPeopleTwo = new Guna2HtmlLabel();
            lblPeopleTwo.Location = new Point(5, 135);
            lblPeopleTwo.Font = new Font("Times New Roman", 8, FontStyle.Regular);
            lblPeopleTwo.AutoSize = true;
            lblPeopleTwo.Text = workerNames.Count > 1 ? workerNames[1] : "No Worker Assigned";

            // Tạo picture box
            Guna2CirclePictureBox current = new Guna2CirclePictureBox();
            current.Location = new Point(5, 5);
            current.Size = new Size(15, 15);
            current.FillColor = Color.FromArgb(22, 160, 133);

            // Xóa các control cũ để tránh trùng lặp
            panel.Controls.Clear();

            // Thêm các control vào panel
            panel.Controls.Add(lblTime);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblPeopleOne);
            panel.Controls.Add(lblPeopleTwo);
            panel.Controls.Add(current);
            // panel.BackColor = Color.FromArgb(236, 240, 241);
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

        // Giải thuật phân ca: RR + QHD

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

                    int neededWorkers = maxShiftsPerDay; // Số lượng nhân viên cần thiết cho mỗi ca
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



        private void btnNewSchedule_Click(object sender, EventArgs e)
        {
            // Tiến hành phân ca
            GenerateWeeklySchedule();

            // Load dữ liệu lên các panel
            RefreshAllPanels();
        }

        #endregion


        #region Phần lưu dữ liệu đã phân lên CSDL

        // Hàm tự xác định mốc thời gian bắt đầu và kết thúc một tuần
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

        // Hàm xác định dữ liệu để lưu vào CSDL
        private void SaveSchedule()
        {
            // Tạo Dictionary để ánh xạ FullName đến WorkerID: Dựa vào FullName lấy lại đối tượng
            Dictionary<string, Worker_DTO> nameToIdMap = workerList.ToDictionary(worker => worker.FullName, worker => worker);

            DateTime dateStart = GetRangeWeek()[0];
            DateTime dateEnd = GetRangeWeek()[1];

            var daysOfWeek = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            var shifts = new[] { "Morning", "Afternoon", "Evening" };

            foreach (var day in daysOfWeek)
            {
                foreach (var shift in shifts)
                {
                    string panelKey = $"pn{shift}{day}";
                    foreach (var workerName in schedule[panelKey])
                    {
                        var worker = nameToIdMap[workerName];
                        string scheduleID = worker.WorkerId + day + dateStart.ToString("yyyyMMdd");

                        // Tạo một đối tượng Schedule mới để lưu vào cơ sở dữ liệu
                        Schedule_DTO newSchedule = new Schedule_DTO
                        {
                            ScheduleID = scheduleID,
                            WorkerID = worker,
                            DayOfWeek = day,
                            Shift = shift,
                            Status = 0,
                            DateStart = dateStart,
                            DateEnd = dateEnd
                        };

                        var isCompleted = BUL.Schedule_BUL.InsertSchedule(newSchedule);
                        if(!isCompleted)
                        {
                            MessageBox.Show("Errol for insert schedule !", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            MessageBox.Show("Schedule is saved", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveSchedule();
        }


        #endregion

        #region Phần load dữ liệu khi admin chọn mốc thời giam

        private void LoadScheduleFromDatabase()
        {
            List<DateTime> rangeWeek = GetRangeWeek();
            DateTime dateStart = rangeWeek[0];
            DateTime dateEnd = rangeWeek[1];

            // Giả sử bạn có một phương thức từ BUL để lấy dữ liệu dựa trên khoảng thời gian
            List<Schedule_DTO> schedulesFromDb = Schedule_BUL.GetSchedule(dateStart, dateEnd);
            // MessageBox.Show(schedulesFromDb.Count.ToString());

            // Clear current schedule in the UI
            foreach (var panel in panelMap.Values)
            {
                panel.Controls.Clear();  // Clearing each panel
            }

            // Resetting the schedule dictionary to clear old data
            foreach (var key in schedule.Keys.ToList())
            {
                schedule[key] = new List<string>();
            }

            // Populate UI with new data
            foreach (var scheduleDto in schedulesFromDb)
            {
                string panelKey = $"pn{scheduleDto.Shift}{scheduleDto.DayOfWeek}";
                if (schedule.ContainsKey(panelKey))
                {
                    schedule[panelKey].Add(scheduleDto.WorkerID.FullName);
                }
            }

            RefreshAllPanels();
        }


        #endregion

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

        // Phân ca theo khu
        private void cbParkArea_SelectedValueChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("A");
            string parkAreaId = cbParkArea.Text.Split(':')[0];
            workerList = Worker_BUL.GetWorkerWithTypeAndParkArea("Look", parkAreaId);


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

            // Khởi chạy một số vùng nhớ cần thiết
            GenerateWeeklySchedule();

        }
    }
}
