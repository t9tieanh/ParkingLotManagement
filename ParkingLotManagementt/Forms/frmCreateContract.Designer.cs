namespace ParkingLotManagementt.Forms
{
    partial class frmCreateContract
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateContract));
            this.pnUnderOne = new Guna.UI2.WinForms.Guna2Panel();
            this.pnChooseService = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoticeMyservice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblTTmyservice = new System.Windows.Forms.Label();
            this.flowService = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.lblSkipInfoCar = new System.Windows.Forms.Label();
            this.picChooseService = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnDate = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNoticeDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpkDateStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpkDateFinish = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblDateDead = new System.Windows.Forms.Label();
            this.lblDateStart = new System.Windows.Forms.Label();
            this.lblNextParkArea = new System.Windows.Forms.Label();
            this.lblSkipChooseService = new System.Windows.Forms.Label();
            this.picDate = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnChooseParkArea = new Guna.UI2.WinForms.Guna2Panel();
            this.pnLoadParkUC = new Guna.UI2.WinForms.Guna2Panel();
            this.uC_ParkArea1 = new ParkingLotManagementt.UC_Controls.UC_ParkArea();
            this.cbChoosePark = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblParkIDChoose = new System.Windows.Forms.Label();
            this.lblParkID = new System.Windows.Forms.Label();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblSkipDate = new System.Windows.Forms.Label();
            this.picParking = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.btnCreateContract = new Guna.UI2.WinForms.Guna2Button();
            this.pnInfoCar = new Guna.UI2.WinForms.Guna2Panel();
            this.picVehicle = new System.Windows.Forms.PictureBox();
            this.lblNoticeVehicle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cbTypeVehicle = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtModelVehicle = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIDVehicle = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblType = new System.Windows.Forms.Label();
            this.lblChooseImage = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblCarID = new System.Windows.Forms.Label();
            this.lblNextXChooseService = new System.Windows.Forms.Label();
            this.picYourCar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnUnderTwo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnUnderThree = new Guna.UI2.WinForms.Guna2Panel();
            this.pnUnderFour = new Guna.UI2.WinForms.Guna2Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.processCompleted = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.lblValueCompleted = new System.Windows.Forms.Label();
            this.picMinimize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picExit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblNoticeParkArea = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pnChooseService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChooseService)).BeginInit();
            this.pnDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDate)).BeginInit();
            this.pnChooseParkArea.SuspendLayout();
            this.pnLoadParkUC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picParking)).BeginInit();
            this.pnInfoCar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYourCar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // pnUnderOne
            // 
            this.pnUnderOne.BackColor = System.Drawing.Color.Transparent;
            this.pnUnderOne.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(155)))), ((int)(((byte)(254)))));
            this.pnUnderOne.BorderRadius = 10;
            this.pnUnderOne.BorderThickness = 2;
            this.pnUnderOne.Location = new System.Drawing.Point(23, 70);
            this.pnUnderOne.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnUnderOne.Name = "pnUnderOne";
            this.pnUnderOne.Size = new System.Drawing.Size(284, 525);
            this.pnUnderOne.TabIndex = 16;
            // 
            // pnChooseService
            // 
            this.pnChooseService.BackColor = System.Drawing.Color.White;
            this.pnChooseService.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.pnChooseService.BorderRadius = 10;
            this.pnChooseService.BorderThickness = 2;
            this.pnChooseService.Controls.Add(this.lblNoticeMyservice);
            this.pnChooseService.Controls.Add(this.lblTTmyservice);
            this.pnChooseService.Controls.Add(this.flowService);
            this.pnChooseService.Controls.Add(this.lblNextDate);
            this.pnChooseService.Controls.Add(this.lblSkipInfoCar);
            this.pnChooseService.Controls.Add(this.picChooseService);
            this.pnChooseService.Location = new System.Drawing.Point(332, 70);
            this.pnChooseService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnChooseService.Name = "pnChooseService";
            this.pnChooseService.Size = new System.Drawing.Size(284, 525);
            this.pnChooseService.TabIndex = 16;
            // 
            // lblNoticeMyservice
            // 
            this.lblNoticeMyservice.AutoSize = false;
            this.lblNoticeMyservice.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticeMyservice.ForeColor = System.Drawing.Color.Red;
            this.lblNoticeMyservice.Location = new System.Drawing.Point(14, 478);
            this.lblNoticeMyservice.Name = "lblNoticeMyservice";
            this.lblNoticeMyservice.Size = new System.Drawing.Size(247, 17);
            this.lblNoticeMyservice.TabIndex = 19;
            this.lblNoticeMyservice.Text = "!...";
            // 
            // lblTTmyservice
            // 
            this.lblTTmyservice.AutoSize = true;
            this.lblTTmyservice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTTmyservice.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTmyservice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblTTmyservice.Location = new System.Drawing.Point(11, 27);
            this.lblTTmyservice.Name = "lblTTmyservice";
            this.lblTTmyservice.Size = new System.Drawing.Size(80, 17);
            this.lblTTmyservice.TabIndex = 18;
            this.lblTTmyservice.Text = "My service";
            // 
            // flowService
            // 
            this.flowService.AutoScroll = true;
            this.flowService.Location = new System.Drawing.Point(14, 57);
            this.flowService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowService.Name = "flowService";
            this.flowService.Size = new System.Drawing.Size(254, 409);
            this.flowService.TabIndex = 15;
            // 
            // lblNextDate
            // 
            this.lblNextDate.AutoSize = true;
            this.lblNextDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblNextDate.Location = new System.Drawing.Point(228, 498);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(47, 19);
            this.lblNextDate.TabIndex = 0;
            this.lblNextDate.Text = "Next";
            this.lblNextDate.Click += new System.EventHandler(this.lblNextDate_Click);
            // 
            // lblSkipInfoCar
            // 
            this.lblSkipInfoCar.AutoSize = true;
            this.lblSkipInfoCar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSkipInfoCar.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipInfoCar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblSkipInfoCar.Location = new System.Drawing.Point(8, 498);
            this.lblSkipInfoCar.Name = "lblSkipInfoCar";
            this.lblSkipInfoCar.Size = new System.Drawing.Size(43, 19);
            this.lblSkipInfoCar.TabIndex = 0;
            this.lblSkipInfoCar.Text = "Skip";
            this.lblSkipInfoCar.Click += new System.EventHandler(this.lblSkipInfoCar_Click);
            // 
            // picChooseService
            // 
            this.picChooseService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChooseService.FillColor = System.Drawing.Color.Transparent;
            this.picChooseService.Image = global::ParkingLotManagementt.Properties.Resources.ico_your_service;
            this.picChooseService.ImageRotate = 0F;
            this.picChooseService.Location = new System.Drawing.Point(232, 12);
            this.picChooseService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picChooseService.Name = "picChooseService";
            this.picChooseService.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picChooseService.Size = new System.Drawing.Size(36, 32);
            this.picChooseService.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picChooseService.TabIndex = 14;
            this.picChooseService.TabStop = false;
            this.picChooseService.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // pnDate
            // 
            this.pnDate.BackColor = System.Drawing.Color.White;
            this.pnDate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.pnDate.BorderRadius = 10;
            this.pnDate.BorderThickness = 2;
            this.pnDate.Controls.Add(this.lblNoticeDate);
            this.pnDate.Controls.Add(this.dtpkDateStart);
            this.pnDate.Controls.Add(this.dtpkDateFinish);
            this.pnDate.Controls.Add(this.lblDateDead);
            this.pnDate.Controls.Add(this.lblDateStart);
            this.pnDate.Controls.Add(this.lblNextParkArea);
            this.pnDate.Controls.Add(this.lblSkipChooseService);
            this.pnDate.Controls.Add(this.picDate);
            this.pnDate.Location = new System.Drawing.Point(655, 70);
            this.pnDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnDate.Name = "pnDate";
            this.pnDate.Size = new System.Drawing.Size(284, 525);
            this.pnDate.TabIndex = 16;
            // 
            // lblNoticeDate
            // 
            this.lblNoticeDate.AutoSize = false;
            this.lblNoticeDate.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticeDate.ForeColor = System.Drawing.Color.Red;
            this.lblNoticeDate.Location = new System.Drawing.Point(17, 403);
            this.lblNoticeDate.Name = "lblNoticeDate";
            this.lblNoticeDate.Size = new System.Drawing.Size(247, 47);
            this.lblNoticeDate.TabIndex = 18;
            this.lblNoticeDate.Text = "!...";
            // 
            // dtpkDateStart
            // 
            this.dtpkDateStart.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.dtpkDateStart.BorderRadius = 5;
            this.dtpkDateStart.BorderThickness = 1;
            this.dtpkDateStart.Checked = true;
            this.dtpkDateStart.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.dtpkDateStart.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.dtpkDateStart.ForeColor = System.Drawing.Color.White;
            this.dtpkDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpkDateStart.Location = new System.Drawing.Point(14, 143);
            this.dtpkDateStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkDateStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpkDateStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpkDateStart.Name = "dtpkDateStart";
            this.dtpkDateStart.Size = new System.Drawing.Size(253, 43);
            this.dtpkDateStart.TabIndex = 15;
            this.dtpkDateStart.Value = new System.DateTime(2024, 4, 6, 18, 48, 5, 260);
            this.dtpkDateStart.ValueChanged += new System.EventHandler(this.dtpkDateStart_ValueChanged);
            // 
            // dtpkDateFinish
            // 
            this.dtpkDateFinish.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.dtpkDateFinish.BorderRadius = 5;
            this.dtpkDateFinish.BorderThickness = 1;
            this.dtpkDateFinish.Checked = true;
            this.dtpkDateFinish.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.dtpkDateFinish.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.dtpkDateFinish.ForeColor = System.Drawing.Color.White;
            this.dtpkDateFinish.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpkDateFinish.Location = new System.Drawing.Point(14, 302);
            this.dtpkDateFinish.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpkDateFinish.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpkDateFinish.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpkDateFinish.Name = "dtpkDateFinish";
            this.dtpkDateFinish.Size = new System.Drawing.Size(253, 43);
            this.dtpkDateFinish.TabIndex = 15;
            this.dtpkDateFinish.Value = new System.DateTime(2024, 4, 6, 18, 48, 5, 260);
            // 
            // lblDateDead
            // 
            this.lblDateDead.AutoSize = true;
            this.lblDateDead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDateDead.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDead.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDateDead.Location = new System.Drawing.Point(14, 279);
            this.lblDateDead.Name = "lblDateDead";
            this.lblDateDead.Size = new System.Drawing.Size(219, 17);
            this.lblDateDead.TabIndex = 17;
            this.lblDateDead.Text = "Choose date want to complete";
            // 
            // lblDateStart
            // 
            this.lblDateStart.AutoSize = true;
            this.lblDateStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDateStart.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDateStart.Location = new System.Drawing.Point(14, 122);
            this.lblDateStart.Name = "lblDateStart";
            this.lblDateStart.Size = new System.Drawing.Size(140, 17);
            this.lblDateStart.TabIndex = 17;
            this.lblDateStart.Text = "Choose date is start";
            // 
            // lblNextParkArea
            // 
            this.lblNextParkArea.AutoSize = true;
            this.lblNextParkArea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextParkArea.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextParkArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblNextParkArea.Location = new System.Drawing.Point(224, 498);
            this.lblNextParkArea.Name = "lblNextParkArea";
            this.lblNextParkArea.Size = new System.Drawing.Size(47, 19);
            this.lblNextParkArea.TabIndex = 0;
            this.lblNextParkArea.Text = "Next";
            this.lblNextParkArea.Click += new System.EventHandler(this.lblNextParkArea_Click);
            // 
            // lblSkipChooseService
            // 
            this.lblSkipChooseService.AutoSize = true;
            this.lblSkipChooseService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSkipChooseService.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipChooseService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblSkipChooseService.Location = new System.Drawing.Point(8, 498);
            this.lblSkipChooseService.Name = "lblSkipChooseService";
            this.lblSkipChooseService.Size = new System.Drawing.Size(43, 19);
            this.lblSkipChooseService.TabIndex = 0;
            this.lblSkipChooseService.Text = "Skip";
            this.lblSkipChooseService.Click += new System.EventHandler(this.lblSkipChooseService_Click);
            // 
            // picDate
            // 
            this.picDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDate.FillColor = System.Drawing.Color.Transparent;
            this.picDate.Image = global::ParkingLotManagementt.Properties.Resources.ico_your_date;
            this.picDate.ImageRotate = 0F;
            this.picDate.Location = new System.Drawing.Point(228, 12);
            this.picDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDate.Name = "picDate";
            this.picDate.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picDate.Size = new System.Drawing.Size(36, 32);
            this.picDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDate.TabIndex = 14;
            this.picDate.TabStop = false;
            this.picDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // pnChooseParkArea
            // 
            this.pnChooseParkArea.BackColor = System.Drawing.Color.White;
            this.pnChooseParkArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.pnChooseParkArea.BorderRadius = 10;
            this.pnChooseParkArea.BorderThickness = 2;
            this.pnChooseParkArea.Controls.Add(this.lblNoticeParkArea);
            this.pnChooseParkArea.Controls.Add(this.pnLoadParkUC);
            this.pnChooseParkArea.Controls.Add(this.cbChoosePark);
            this.pnChooseParkArea.Controls.Add(this.lblParkIDChoose);
            this.pnChooseParkArea.Controls.Add(this.lblParkID);
            this.pnChooseParkArea.Controls.Add(this.lblFinish);
            this.pnChooseParkArea.Controls.Add(this.lblSkipDate);
            this.pnChooseParkArea.Controls.Add(this.picParking);
            this.pnChooseParkArea.Location = new System.Drawing.Point(975, 70);
            this.pnChooseParkArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnChooseParkArea.Name = "pnChooseParkArea";
            this.pnChooseParkArea.Size = new System.Drawing.Size(284, 525);
            this.pnChooseParkArea.TabIndex = 16;
            // 
            // pnLoadParkUC
            // 
            this.pnLoadParkUC.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(206)))), ((int)(((byte)(201)))));
            this.pnLoadParkUC.BorderRadius = 5;
            this.pnLoadParkUC.BorderThickness = 1;
            this.pnLoadParkUC.Controls.Add(this.uC_ParkArea1);
            this.pnLoadParkUC.Location = new System.Drawing.Point(18, 169);
            this.pnLoadParkUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnLoadParkUC.Name = "pnLoadParkUC";
            this.pnLoadParkUC.Size = new System.Drawing.Size(253, 314);
            this.pnLoadParkUC.TabIndex = 19;
            // 
            // uC_ParkArea1
            // 
            this.uC_ParkArea1.BackColor = System.Drawing.Color.White;
            this.uC_ParkArea1.Location = new System.Drawing.Point(10, 8);
            this.uC_ParkArea1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uC_ParkArea1.MyParkArea = null;
            this.uC_ParkArea1.Name = "uC_ParkArea1";
            this.uC_ParkArea1.Size = new System.Drawing.Size(236, 303);
            this.uC_ParkArea1.TabIndex = 0;
            // 
            // cbChoosePark
            // 
            this.cbChoosePark.BackColor = System.Drawing.Color.Transparent;
            this.cbChoosePark.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbChoosePark.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChoosePark.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbChoosePark.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbChoosePark.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.cbChoosePark.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbChoosePark.ItemHeight = 30;
            this.cbChoosePark.Location = new System.Drawing.Point(18, 124);
            this.cbChoosePark.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbChoosePark.Name = "cbChoosePark";
            this.cbChoosePark.Size = new System.Drawing.Size(254, 36);
            this.cbChoosePark.TabIndex = 18;
            this.cbChoosePark.SelectedIndexChanged += new System.EventHandler(this.cbChoosePark_SelectedIndexChanged);
            // 
            // lblParkIDChoose
            // 
            this.lblParkIDChoose.AutoSize = true;
            this.lblParkIDChoose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblParkIDChoose.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParkIDChoose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblParkIDChoose.Location = new System.Drawing.Point(116, 91);
            this.lblParkIDChoose.Name = "lblParkIDChoose";
            this.lblParkIDChoose.Size = new System.Drawing.Size(54, 19);
            this.lblParkIDChoose.TabIndex = 17;
            this.lblParkIDChoose.Text = "None";
            // 
            // lblParkID
            // 
            this.lblParkID.AutoSize = true;
            this.lblParkID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblParkID.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParkID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblParkID.Location = new System.Drawing.Point(18, 93);
            this.lblParkID.Name = "lblParkID";
            this.lblParkID.Size = new System.Drawing.Size(94, 17);
            this.lblParkID.TabIndex = 17;
            this.lblParkID.Text = "ID chooosed";
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFinish.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblFinish.Location = new System.Drawing.Point(215, 498);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(53, 19);
            this.lblFinish.TabIndex = 0;
            this.lblFinish.Text = "Finish";
            this.lblFinish.Click += new System.EventHandler(this.lblFinish_Click);
            // 
            // lblSkipDate
            // 
            this.lblSkipDate.AutoSize = true;
            this.lblSkipDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSkipDate.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkipDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblSkipDate.Location = new System.Drawing.Point(8, 498);
            this.lblSkipDate.Name = "lblSkipDate";
            this.lblSkipDate.Size = new System.Drawing.Size(43, 19);
            this.lblSkipDate.TabIndex = 0;
            this.lblSkipDate.Text = "Skip";
            this.lblSkipDate.Click += new System.EventHandler(this.lblPreDate_Click);
            // 
            // picParking
            // 
            this.picParking.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picParking.FillColor = System.Drawing.Color.Transparent;
            this.picParking.Image = global::ParkingLotManagementt.Properties.Resources.ico_your_parking;
            this.picParking.ImageRotate = 0F;
            this.picParking.Location = new System.Drawing.Point(228, 12);
            this.picParking.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picParking.Name = "picParking";
            this.picParking.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picParking.Size = new System.Drawing.Size(36, 32);
            this.picParking.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picParking.TabIndex = 14;
            this.picParking.TabStop = false;
            this.picParking.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // btnCreateContract
            // 
            this.btnCreateContract.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateContract.BorderColor = System.Drawing.Color.White;
            this.btnCreateContract.BorderRadius = 10;
            this.btnCreateContract.BorderThickness = 1;
            this.btnCreateContract.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateContract.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCreateContract.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCreateContract.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCreateContract.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.btnCreateContract.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateContract.ForeColor = System.Drawing.Color.White;
            this.btnCreateContract.Location = new System.Drawing.Point(1143, 619);
            this.btnCreateContract.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCreateContract.Name = "btnCreateContract";
            this.btnCreateContract.Size = new System.Drawing.Size(128, 39);
            this.btnCreateContract.TabIndex = 19;
            this.btnCreateContract.Text = "To contract";
            this.btnCreateContract.Click += new System.EventHandler(this.btnCreateContract_Click);
            // 
            // pnInfoCar
            // 
            this.pnInfoCar.BackColor = System.Drawing.Color.White;
            this.pnInfoCar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(155)))), ((int)(((byte)(254)))));
            this.pnInfoCar.BorderRadius = 10;
            this.pnInfoCar.BorderThickness = 2;
            this.pnInfoCar.Controls.Add(this.picVehicle);
            this.pnInfoCar.Controls.Add(this.lblNoticeVehicle);
            this.pnInfoCar.Controls.Add(this.cbTypeVehicle);
            this.pnInfoCar.Controls.Add(this.txtModelVehicle);
            this.pnInfoCar.Controls.Add(this.txtIDVehicle);
            this.pnInfoCar.Controls.Add(this.lblType);
            this.pnInfoCar.Controls.Add(this.lblChooseImage);
            this.pnInfoCar.Controls.Add(this.lblModel);
            this.pnInfoCar.Controls.Add(this.lblCarID);
            this.pnInfoCar.Controls.Add(this.lblNextXChooseService);
            this.pnInfoCar.Controls.Add(this.picYourCar);
            this.pnInfoCar.Location = new System.Drawing.Point(11, 70);
            this.pnInfoCar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnInfoCar.Name = "pnInfoCar";
            this.pnInfoCar.Size = new System.Drawing.Size(284, 525);
            this.pnInfoCar.TabIndex = 16;
            // 
            // picVehicle
            // 
            this.picVehicle.Image = ((System.Drawing.Image)(resources.GetObject("picVehicle.Image")));
            this.picVehicle.Location = new System.Drawing.Point(12, 57);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(100, 96);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 163;
            this.picVehicle.TabStop = false;
            // 
            // lblNoticeVehicle
            // 
            this.lblNoticeVehicle.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticeVehicle.ForeColor = System.Drawing.Color.Red;
            this.lblNoticeVehicle.Location = new System.Drawing.Point(15, 448);
            this.lblNoticeVehicle.Name = "lblNoticeVehicle";
            this.lblNoticeVehicle.Size = new System.Drawing.Size(18, 18);
            this.lblNoticeVehicle.TabIndex = 162;
            this.lblNoticeVehicle.Text = "! ...";
            // 
            // cbTypeVehicle
            // 
            this.cbTypeVehicle.BackColor = System.Drawing.Color.Transparent;
            this.cbTypeVehicle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTypeVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeVehicle.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeVehicle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeVehicle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbTypeVehicle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTypeVehicle.ItemHeight = 20;
            this.cbTypeVehicle.Items.AddRange(new object[] {
            "Bicycle",
            "Moto",
            "Car"});
            this.cbTypeVehicle.Location = new System.Drawing.Point(12, 403);
            this.cbTypeVehicle.Name = "cbTypeVehicle";
            this.cbTypeVehicle.Size = new System.Drawing.Size(254, 26);
            this.cbTypeVehicle.StartIndex = 0;
            this.cbTypeVehicle.TabIndex = 161;
            // 
            // txtModelVehicle
            // 
            this.txtModelVehicle.Animated = true;
            this.txtModelVehicle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.txtModelVehicle.BorderRadius = 6;
            this.txtModelVehicle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtModelVehicle.DefaultText = "";
            this.txtModelVehicle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtModelVehicle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtModelVehicle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModelVehicle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtModelVehicle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModelVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelVehicle.ForeColor = System.Drawing.Color.DarkGray;
            this.txtModelVehicle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtModelVehicle.Location = new System.Drawing.Point(12, 302);
            this.txtModelVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelVehicle.Name = "txtModelVehicle";
            this.txtModelVehicle.PasswordChar = '\0';
            this.txtModelVehicle.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtModelVehicle.PlaceholderText = "ex. Nguyễn Văn A";
            this.txtModelVehicle.SelectedText = "";
            this.txtModelVehicle.Size = new System.Drawing.Size(254, 27);
            this.txtModelVehicle.TabIndex = 160;
            // 
            // txtIDVehicle
            // 
            this.txtIDVehicle.Animated = true;
            this.txtIDVehicle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.txtIDVehicle.BorderRadius = 6;
            this.txtIDVehicle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDVehicle.DefaultText = "";
            this.txtIDVehicle.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDVehicle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDVehicle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDVehicle.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDVehicle.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDVehicle.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIDVehicle.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDVehicle.Location = new System.Drawing.Point(12, 218);
            this.txtIDVehicle.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDVehicle.Name = "txtIDVehicle";
            this.txtIDVehicle.PasswordChar = '\0';
            this.txtIDVehicle.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtIDVehicle.PlaceholderText = "ex. 101";
            this.txtIDVehicle.SelectedText = "";
            this.txtIDVehicle.Size = new System.Drawing.Size(258, 27);
            this.txtIDVehicle.TabIndex = 159;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblType.Location = new System.Drawing.Point(12, 366);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(39, 17);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";
            // 
            // lblChooseImage
            // 
            this.lblChooseImage.AutoSize = true;
            this.lblChooseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblChooseImage.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblChooseImage.Location = new System.Drawing.Point(124, 122);
            this.lblChooseImage.Name = "lblChooseImage";
            this.lblChooseImage.Size = new System.Drawing.Size(109, 17);
            this.lblChooseImage.TabIndex = 0;
            this.lblChooseImage.Text = "Choose image";
            this.lblChooseImage.Click += new System.EventHandler(this.lblChooseImage_Click);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblModel.Location = new System.Drawing.Point(12, 282);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(52, 17);
            this.lblModel.TabIndex = 0;
            this.lblModel.Text = "Model";
            // 
            // lblCarID
            // 
            this.lblCarID.AutoSize = true;
            this.lblCarID.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblCarID.Location = new System.Drawing.Point(12, 198);
            this.lblCarID.Name = "lblCarID";
            this.lblCarID.Size = new System.Drawing.Size(163, 17);
            this.lblCarID.TabIndex = 0;
            this.lblCarID.Text = "Seri number of your car";
            // 
            // lblNextXChooseService
            // 
            this.lblNextXChooseService.AutoSize = true;
            this.lblNextXChooseService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextXChooseService.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextXChooseService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.lblNextXChooseService.Location = new System.Drawing.Point(231, 498);
            this.lblNextXChooseService.Name = "lblNextXChooseService";
            this.lblNextXChooseService.Size = new System.Drawing.Size(47, 19);
            this.lblNextXChooseService.TabIndex = 0;
            this.lblNextXChooseService.Text = "Next";
            this.lblNextXChooseService.Click += new System.EventHandler(this.lblNextXChooseService_Click);
            // 
            // picYourCar
            // 
            this.picYourCar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picYourCar.FillColor = System.Drawing.Color.Transparent;
            this.picYourCar.Image = global::ParkingLotManagementt.Properties.Resources.ico_your_car_info;
            this.picYourCar.ImageRotate = 0F;
            this.picYourCar.Location = new System.Drawing.Point(235, 12);
            this.picYourCar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picYourCar.Name = "picYourCar";
            this.picYourCar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picYourCar.Size = new System.Drawing.Size(36, 32);
            this.picYourCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picYourCar.TabIndex = 14;
            this.picYourCar.TabStop = false;
            this.picYourCar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // pnUnderTwo
            // 
            this.pnUnderTwo.BackColor = System.Drawing.Color.Transparent;
            this.pnUnderTwo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(234)))), ((int)(((byte)(167)))));
            this.pnUnderTwo.BorderRadius = 10;
            this.pnUnderTwo.BorderThickness = 2;
            this.pnUnderTwo.Location = new System.Drawing.Point(344, 70);
            this.pnUnderTwo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnUnderTwo.Name = "pnUnderTwo";
            this.pnUnderTwo.Size = new System.Drawing.Size(284, 525);
            this.pnUnderTwo.TabIndex = 16;
            // 
            // pnUnderThree
            // 
            this.pnUnderThree.BackColor = System.Drawing.Color.Transparent;
            this.pnUnderThree.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(118)))), ((int)(((byte)(117)))));
            this.pnUnderThree.BorderRadius = 10;
            this.pnUnderThree.BorderThickness = 2;
            this.pnUnderThree.Location = new System.Drawing.Point(667, 70);
            this.pnUnderThree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnUnderThree.Name = "pnUnderThree";
            this.pnUnderThree.Size = new System.Drawing.Size(284, 525);
            this.pnUnderThree.TabIndex = 16;
            // 
            // pnUnderFour
            // 
            this.pnUnderFour.BackColor = System.Drawing.Color.Transparent;
            this.pnUnderFour.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.pnUnderFour.BorderRadius = 10;
            this.pnUnderFour.BorderThickness = 2;
            this.pnUnderFour.Location = new System.Drawing.Point(987, 70);
            this.pnUnderFour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnUnderFour.Name = "pnUnderFour";
            this.pnUnderFour.Size = new System.Drawing.Size(284, 525);
            this.pnUnderFour.TabIndex = 16;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.btnExit.BorderRadius = 10;
            this.btnExit.BorderThickness = 2;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(11, 619);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 39);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // processCompleted
            // 
            this.processCompleted.Location = new System.Drawing.Point(133, 637);
            this.processCompleted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.processCompleted.Name = "processCompleted";
            this.processCompleted.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.processCompleted.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.processCompleted.Size = new System.Drawing.Size(1001, 4);
            this.processCompleted.TabIndex = 17;
            this.processCompleted.Text = "guna2ProgressBar1";
            this.processCompleted.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.processCompleted.Value = 75;
            // 
            // lblValueCompleted
            // 
            this.lblValueCompleted.AutoSize = true;
            this.lblValueCompleted.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValueCompleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblValueCompleted.Location = new System.Drawing.Point(1093, 610);
            this.lblValueCompleted.Name = "lblValueCompleted";
            this.lblValueCompleted.Size = new System.Drawing.Size(44, 19);
            this.lblValueCompleted.TabIndex = 0;
            this.lblValueCompleted.Text = "75%";
            // 
            // picMinimize
            // 
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.FillColor = System.Drawing.Color.Yellow;
            this.picMinimize.ImageRotate = 0F;
            this.picMinimize.Location = new System.Drawing.Point(1235, 5);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.TabIndex = 14;
            this.picMinimize.TabStop = false;
            this.picMinimize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // picExit
            // 
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.FillColor = System.Drawing.Color.Red;
            this.picExit.ImageRotate = 0F;
            this.picExit.Location = new System.Drawing.Point(1259, 5);
            this.picExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picExit.Name = "picExit";
            this.picExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picExit.Size = new System.Drawing.Size(18, 16);
            this.picExit.TabIndex = 15;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnTop.Controls.Add(this.picMinimize);
            this.pnTop.Controls.Add(this.picExit);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1283, 26);
            this.pnTop.TabIndex = 26;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown_1);
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // lblNoticeParkArea
            // 
            this.lblNoticeParkArea.AutoSize = false;
            this.lblNoticeParkArea.BackColor = System.Drawing.Color.Transparent;
            this.lblNoticeParkArea.ForeColor = System.Drawing.Color.Red;
            this.lblNoticeParkArea.Location = new System.Drawing.Point(15, 27);
            this.lblNoticeParkArea.Name = "lblNoticeParkArea";
            this.lblNoticeParkArea.Size = new System.Drawing.Size(207, 47);
            this.lblNoticeParkArea.TabIndex = 19;
            this.lblNoticeParkArea.Text = "Please select your vehicle type so the system can choose the right parking spot f" +
    "or you";
            // 
            // frmServiceForCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1283, 667);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.btnCreateContract);
            this.Controls.Add(this.processCompleted);
            this.Controls.Add(this.pnChooseParkArea);
            this.Controls.Add(this.pnDate);
            this.Controls.Add(this.lblValueCompleted);
            this.Controls.Add(this.pnChooseService);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnUnderFour);
            this.Controls.Add(this.pnUnderThree);
            this.Controls.Add(this.pnUnderTwo);
            this.Controls.Add(this.pnInfoCar);
            this.Controls.Add(this.pnUnderOne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmServiceForCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmServiceForCustomer";
            this.Load += new System.EventHandler(this.frmServiceForCustomer_Load);
            this.pnChooseService.ResumeLayout(false);
            this.pnChooseService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChooseService)).EndInit();
            this.pnDate.ResumeLayout(false);
            this.pnDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDate)).EndInit();
            this.pnChooseParkArea.ResumeLayout(false);
            this.pnChooseParkArea.PerformLayout();
            this.pnLoadParkUC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picParking)).EndInit();
            this.pnInfoCar.ResumeLayout(false);
            this.pnInfoCar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picYourCar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox picMinimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picExit;
        private Guna.UI2.WinForms.Guna2Panel pnUnderOne;
        private Guna.UI2.WinForms.Guna2Panel pnChooseService;
        private Guna.UI2.WinForms.Guna2Panel pnDate;
        private Guna.UI2.WinForms.Guna2Panel pnChooseParkArea;
        private Guna.UI2.WinForms.Guna2Button btnCreateContract;
        private Guna.UI2.WinForms.Guna2Panel pnInfoCar;
        private Guna.UI2.WinForms.Guna2Panel pnUnderTwo;
        private Guna.UI2.WinForms.Guna2Panel pnUnderThree;
        private Guna.UI2.WinForms.Guna2Panel pnUnderFour;
        private System.Windows.Forms.Label lblNextDate;
        private System.Windows.Forms.Label lblSkipInfoCar;
        private System.Windows.Forms.Label lblNextParkArea;
        private System.Windows.Forms.Label lblSkipChooseService;
        private System.Windows.Forms.Label lblSkipDate;
        private System.Windows.Forms.Label lblNextXChooseService;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picYourCar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picChooseService;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picDate;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picParking;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblCarID;
        private System.Windows.Forms.Label lblChooseImage;
        private Guna.UI2.WinForms.Guna2TextBox txtModelVehicle;
        private Guna.UI2.WinForms.Guna2TextBox txtIDVehicle;
        private Guna.UI2.WinForms.Guna2ProgressBar processCompleted;
        private System.Windows.Forms.Label lblValueCompleted;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.FlowLayoutPanel flowService;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private Guna.UI2.WinForms.Guna2ComboBox cbTypeVehicle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoticeVehicle;
        private System.Windows.Forms.PictureBox picVehicle;
        private System.Windows.Forms.Label lblParkIDChoose;
        private System.Windows.Forms.Label lblParkID;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkDateStart;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkDateFinish;
        private System.Windows.Forms.Label lblDateDead;
        private System.Windows.Forms.Label lblDateStart;
        private Guna.UI2.WinForms.Guna2ComboBox cbChoosePark;
        private Guna.UI2.WinForms.Guna2Panel pnLoadParkUC;
        private UC_Controls.UC_ParkArea uC_ParkArea1;
        private System.Windows.Forms.Label lblTTmyservice;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoticeDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoticeMyservice;
        private System.Windows.Forms.ErrorProvider error;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoticeParkArea;
    }
}