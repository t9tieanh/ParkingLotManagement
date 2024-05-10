namespace ParkingLotManagementt.Forms
{
    partial class frmService
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmService));
            this.picMinimize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picExit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picChooseService = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblService = new System.Windows.Forms.Label();
            this.flowServiceForCar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnApply = new Guna.UI2.WinForms.Guna2Button();
            this.picSeachService = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtDateOfContract = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbServiceRent = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnRentService = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNotice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ToggleSwitchRent = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.uC_ServiceRentCar = new ParkingLotManagementt.UC_Controls.UC_ServiceRentCar();
            this.uC_Service1 = new ParkingLotManagementt.UC_Controls.UC_ServiceForCustomer();
            this.uC_Service2 = new ParkingLotManagementt.UC_Controls.UC_ServiceForCustomer();
            this.uC_Service3 = new ParkingLotManagementt.UC_Controls.UC_ServiceForCustomer();
            this.uC_Service4 = new ParkingLotManagementt.UC_Controls.UC_ServiceForCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChooseService)).BeginInit();
            this.flowServiceForCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeachService)).BeginInit();
            this.pnTop.SuspendLayout();
            this.pnRentService.SuspendLayout();
            this.SuspendLayout();
            // 
            // picMinimize
            // 
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.FillColor = System.Drawing.Color.Yellow;
            this.picMinimize.ImageRotate = 0F;
            this.picMinimize.Location = new System.Drawing.Point(838, 5);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.TabIndex = 16;
            this.picMinimize.TabStop = false;
            this.picMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // picExit
            // 
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.FillColor = System.Drawing.Color.Red;
            this.picExit.ImageRotate = 0F;
            this.picExit.Location = new System.Drawing.Point(863, 5);
            this.picExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picExit.Name = "picExit";
            this.picExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picExit.Size = new System.Drawing.Size(18, 16);
            this.picExit.TabIndex = 17;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picChooseService
            // 
            this.picChooseService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChooseService.FillColor = System.Drawing.Color.Transparent;
            this.picChooseService.Image = ((System.Drawing.Image)(resources.GetObject("picChooseService.Image")));
            this.picChooseService.ImageRotate = 0F;
            this.picChooseService.Location = new System.Drawing.Point(10, 31);
            this.picChooseService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picChooseService.Name = "picChooseService";
            this.picChooseService.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picChooseService.Size = new System.Drawing.Size(80, 72);
            this.picChooseService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picChooseService.TabIndex = 19;
            this.picChooseService.TabStop = false;
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblService.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblService.Location = new System.Drawing.Point(96, 77);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(194, 19);
            this.lblService.TabIndex = 20;
            this.lblService.Text = "All service for your car";
            // 
            // flowServiceForCar
            // 
            this.flowServiceForCar.AutoScroll = true;
            this.flowServiceForCar.BackColor = System.Drawing.Color.White;
            this.flowServiceForCar.Controls.Add(this.uC_Service1);
            this.flowServiceForCar.Controls.Add(this.uC_Service2);
            this.flowServiceForCar.Controls.Add(this.uC_Service3);
            this.flowServiceForCar.Controls.Add(this.uC_Service4);
            this.flowServiceForCar.Location = new System.Drawing.Point(11, 107);
            this.flowServiceForCar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowServiceForCar.Name = "flowServiceForCar";
            this.flowServiceForCar.Size = new System.Drawing.Size(850, 405);
            this.flowServiceForCar.TabIndex = 21;
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(92)))), ((int)(((byte)(231)))));
            this.btnApply.BorderRadius = 10;
            this.btnApply.BorderThickness = 1;
            this.btnApply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApply.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnApply.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.White;
            this.btnApply.Location = new System.Drawing.Point(743, 70);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(113, 34);
            this.btnApply.TabIndex = 22;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // picSeachService
            // 
            this.picSeachService.BackColor = System.Drawing.Color.White;
            this.picSeachService.Image = global::ParkingLotManagementt.Properties.Resources.ico_search;
            this.picSeachService.ImageRotate = 0F;
            this.picSeachService.Location = new System.Drawing.Point(527, 35);
            this.picSeachService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picSeachService.Name = "picSeachService";
            this.picSeachService.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picSeachService.Size = new System.Drawing.Size(28, 26);
            this.picSeachService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSeachService.TabIndex = 24;
            this.picSeachService.TabStop = false;
            // 
            // txtDateOfContract
            // 
            this.txtDateOfContract.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(214)))), ((int)(((byte)(229)))));
            this.txtDateOfContract.BorderRadius = 5;
            this.txtDateOfContract.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDateOfContract.DefaultText = "";
            this.txtDateOfContract.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDateOfContract.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDateOfContract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDateOfContract.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDateOfContract.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDateOfContract.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtDateOfContract.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDateOfContract.Location = new System.Drawing.Point(326, 33);
            this.txtDateOfContract.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateOfContract.Name = "txtDateOfContract";
            this.txtDateOfContract.PasswordChar = '\0';
            this.txtDateOfContract.PlaceholderText = "Search for contract time";
            this.txtDateOfContract.SelectedText = "";
            this.txtDateOfContract.Size = new System.Drawing.Size(238, 31);
            this.txtDateOfContract.TabIndex = 23;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnTop.Controls.Add(this.picExit);
            this.pnTop.Controls.Add(this.picMinimize);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(884, 26);
            this.pnTop.TabIndex = 25;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.label1.Location = new System.Drawing.Point(12, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 19);
            this.label1.TabIndex = 27;
            this.label1.Text = "You can rent us a car";
            // 
            // cbServiceRent
            // 
            this.cbServiceRent.BackColor = System.Drawing.Color.Transparent;
            this.cbServiceRent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbServiceRent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbServiceRent.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbServiceRent.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbServiceRent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbServiceRent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbServiceRent.ItemHeight = 20;
            this.cbServiceRent.Location = new System.Drawing.Point(15, 556);
            this.cbServiceRent.Name = "cbServiceRent";
            this.cbServiceRent.Size = new System.Drawing.Size(333, 26);
            this.cbServiceRent.TabIndex = 28;
            this.cbServiceRent.SelectedIndexChanged += new System.EventHandler(this.cbServiceRent_SelectedIndexChanged);
            // 
            // pnRentService
            // 
            this.pnRentService.Controls.Add(this.uC_ServiceRentCar);
            this.pnRentService.Location = new System.Drawing.Point(58, 603);
            this.pnRentService.Name = "pnRentService";
            this.pnRentService.Size = new System.Drawing.Size(756, 144);
            this.pnRentService.TabIndex = 29;
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(474, 528);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(15, 18);
            this.lblNotice.TabIndex = 30;
            this.lblNotice.Text = "!...";
            // 
            // ToggleSwitchRent
            // 
            this.ToggleSwitchRent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ToggleSwitchRent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ToggleSwitchRent.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitchRent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.ToggleSwitchRent.Location = new System.Drawing.Point(205, 529);
            this.ToggleSwitchRent.Name = "ToggleSwitchRent";
            this.ToggleSwitchRent.Size = new System.Drawing.Size(35, 20);
            this.ToggleSwitchRent.TabIndex = 31;
            this.ToggleSwitchRent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.ToggleSwitchRent.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.ToggleSwitchRent.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitchRent.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.ToggleSwitchRent.CheckedChanged += new System.EventHandler(this.ToggleSwitchRent_CheckedChanged);
            // 
            // uC_ServiceRentCar
            // 
            this.uC_ServiceRentCar.BackColor = System.Drawing.Color.White;
            this.uC_ServiceRentCar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uC_ServiceRentCar.Location = new System.Drawing.Point(25, 4);
            this.uC_ServiceRentCar.Margin = new System.Windows.Forms.Padding(2, 16, 2, 16);
            this.uC_ServiceRentCar.MyService = null;
            this.uC_ServiceRentCar.Name = "uC_ServiceRentCar";
            this.uC_ServiceRentCar.Size = new System.Drawing.Size(756, 144);
            this.uC_ServiceRentCar.TabIndex = 26;
            // 
            // uC_Service1
            // 
            this.uC_Service1.BackColor = System.Drawing.Color.White;
            this.uC_Service1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.uC_Service1.Location = new System.Drawing.Point(4, 3);
            this.uC_Service1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uC_Service1.MyService = null;
            this.uC_Service1.Name = "uC_Service1";
            this.uC_Service1.Size = new System.Drawing.Size(275, 159);
            this.uC_Service1.TabIndex = 0;
            // 
            // uC_Service2
            // 
            this.uC_Service2.BackColor = System.Drawing.Color.White;
            this.uC_Service2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.uC_Service2.Location = new System.Drawing.Point(287, 3);
            this.uC_Service2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uC_Service2.MyService = null;
            this.uC_Service2.Name = "uC_Service2";
            this.uC_Service2.Size = new System.Drawing.Size(275, 159);
            this.uC_Service2.TabIndex = 1;
            // 
            // uC_Service3
            // 
            this.uC_Service3.BackColor = System.Drawing.Color.White;
            this.uC_Service3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.uC_Service3.Location = new System.Drawing.Point(570, 3);
            this.uC_Service3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uC_Service3.MyService = null;
            this.uC_Service3.Name = "uC_Service3";
            this.uC_Service3.Size = new System.Drawing.Size(275, 159);
            this.uC_Service3.TabIndex = 2;
            // 
            // uC_Service4
            // 
            this.uC_Service4.BackColor = System.Drawing.Color.White;
            this.uC_Service4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.uC_Service4.Location = new System.Drawing.Point(4, 168);
            this.uC_Service4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.uC_Service4.MyService = null;
            this.uC_Service4.Name = "uC_Service4";
            this.uC_Service4.Size = new System.Drawing.Size(275, 159);
            this.uC_Service4.TabIndex = 3;
            // 
            // frmService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(884, 774);
            this.Controls.Add(this.ToggleSwitchRent);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.pnRentService);
            this.Controls.Add(this.cbServiceRent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.picSeachService);
            this.Controls.Add(this.txtDateOfContract);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.flowServiceForCar);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.picChooseService);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmService";
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChooseService)).EndInit();
            this.flowServiceForCar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSeachService)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.pnRentService.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picMinimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picExit;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picChooseService;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.FlowLayoutPanel flowServiceForCar;
        private UC_Controls.UC_ServiceForCustomer uC_Service1;
        private UC_Controls.UC_ServiceForCustomer uC_Service2;
        private UC_Controls.UC_ServiceForCustomer uC_Service3;
        private UC_Controls.UC_ServiceForCustomer uC_Service4;
        private Guna.UI2.WinForms.Guna2Button btnApply;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picSeachService;
        private Guna.UI2.WinForms.Guna2TextBox txtDateOfContract;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbServiceRent;
        private Guna.UI2.WinForms.Guna2Panel pnRentService;
        private UC_Controls.UC_ServiceRentCar uC_ServiceRentCar;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNotice;
        private Guna.UI2.WinForms.Guna2ToggleSwitch ToggleSwitchRent;
    }
}