using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ParkingLotManagementt.Forms
{
    public partial class TestSchedule : Form
    {
        public TestSchedule()
        {
            InitializeComponent();
            timeSchedule.Start();
            
        }

        private void timeSchedule_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            lblRealTime.Text = "Time now: " + now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void AddControl(Guna2Panel panel)
        {
            Guna2HtmlLabel lblTime = new Guna2HtmlLabel();
            lblTime.Location = new Point(31, 32);
            lblTime.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            lblTime.AutoSize = true;
            lblTime.Text = "6:00 - 12:00";

            Guna2HtmlLabel lblTitle = new Guna2HtmlLabel();
            lblTitle.Location = new Point(31, 80);
            lblTitle.Font = new Font("Century Gothic", 8, FontStyle.Bold);
            lblTitle.AutoSize = true;
            lblTitle.Text = "Work with";

            Guna2HtmlLabel lblPeople = new Guna2HtmlLabel();
            lblPeople.Location = new Point(31, 105);
            lblPeople.Font = new Font("Century Gothic", 8, FontStyle.Regular);
            lblPeople.AutoSize = true;
            lblPeople.Text = "Cong Quy";

            // Tạo picture box
            Guna2CirclePictureBox current = new Guna2CirclePictureBox();
            current.Location = new Point(5, 5);
            current.Size = new Size(15, 15);
            current.FillColor = Color.FromArgb(22, 160, 133);

            // Thêm các control vào panel
            panel.Controls.Add(lblTime);
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblPeople);
            panel.Controls.Add(current);
            panel.BackColor = Color.FromArgb(236, 240, 241);
        }

        private void TestSchedule_Load(object sender, EventArgs e)
        {

            AddControl(pnAfterWed);
            AddControl(pnEvenSat);
            AddControl(pnMorningThu);
        }
    }
}
