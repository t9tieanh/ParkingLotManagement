namespace ParkingLotManagementt.Forms
{
    partial class frmPayMentForCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayMentForCustomer));
            this.pnInfomationContract = new Guna.UI2.WinForms.Guna2Panel();
            this.picQR = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPriceTotal = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowPnContractDetail = new System.Windows.Forms.FlowLayoutPanel();
            this.picName = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.pnTrangtri_4 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtContractId = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPayment = new Guna.UI2.WinForms.Guna2Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.guna2Panel25 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel26 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtCustomerID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFullname = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2PictureBox17 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox18 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtPayDate = new Guna.UI2.WinForms.Guna2TextBox();
            this.picExit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.uC_ContractDetailPayMentForCustomer1 = new ParkingLotManagementt.UC_Controls.UC_ContractDetailPayMentForCustomer();
            this.uC_ContractDetailPayMentForCustomer2 = new ParkingLotManagementt.UC_Controls.UC_ContractDetailPayMentForCustomer();
            this.pnInfomationContract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.flowPnContractDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInfomationContract
            // 
            this.pnInfomationContract.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnInfomationContract.BackgroundImage")));
            this.pnInfomationContract.Controls.Add(this.picQR);
            this.pnInfomationContract.Controls.Add(this.label3);
            this.pnInfomationContract.Controls.Add(this.lblPriceTotal);
            this.pnInfomationContract.Controls.Add(this.guna2Panel3);
            this.pnInfomationContract.Controls.Add(this.flowPnContractDetail);
            this.pnInfomationContract.Controls.Add(this.picName);
            this.pnInfomationContract.Controls.Add(this.lblName);
            this.pnInfomationContract.Controls.Add(this.pnTrangtri_4);
            this.pnInfomationContract.Controls.Add(this.txtContractId);
            this.pnInfomationContract.FillColor = System.Drawing.Color.Transparent;
            this.pnInfomationContract.Location = new System.Drawing.Point(0, 0);
            this.pnInfomationContract.Name = "pnInfomationContract";
            this.pnInfomationContract.Size = new System.Drawing.Size(414, 699);
            this.pnInfomationContract.TabIndex = 0;
            this.pnInfomationContract.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnInfomationContract_MouseDown);
            // 
            // picQR
            // 
            this.picQR.ImageRotate = 0F;
            this.picQR.Location = new System.Drawing.Point(11, 390);
            this.picQR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(384, 286);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 277;
            this.picQR.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(15, 369);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(323, 21);
            this.label3.TabIndex = 276;
            this.label3.Text = "You can scan this QR to paying for bill";
            // 
            // lblPriceTotal
            // 
            this.lblPriceTotal.AutoSize = true;
            this.lblPriceTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblPriceTotal.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPriceTotal.ForeColor = System.Drawing.Color.White;
            this.lblPriceTotal.Location = new System.Drawing.Point(349, 365);
            this.lblPriceTotal.Name = "lblPriceTotal";
            this.lblPriceTotal.Size = new System.Drawing.Size(43, 23);
            this.lblPriceTotal.TabIndex = 275;
            this.lblPriceTotal.Text = "19$";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.FillColor = System.Drawing.Color.White;
            this.guna2Panel3.ForeColor = System.Drawing.Color.Crimson;
            this.guna2Panel3.Location = new System.Drawing.Point(11, 346);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(384, 4);
            this.guna2Panel3.TabIndex = 273;
            // 
            // flowPnContractDetail
            // 
            this.flowPnContractDetail.BackColor = System.Drawing.Color.White;
            this.flowPnContractDetail.Controls.Add(this.uC_ContractDetailPayMentForCustomer1);
            this.flowPnContractDetail.Controls.Add(this.uC_ContractDetailPayMentForCustomer2);
            this.flowPnContractDetail.Location = new System.Drawing.Point(11, 74);
            this.flowPnContractDetail.Name = "flowPnContractDetail";
            this.flowPnContractDetail.Size = new System.Drawing.Size(384, 272);
            this.flowPnContractDetail.TabIndex = 272;
            // 
            // picName
            // 
            this.picName.BackColor = System.Drawing.Color.Transparent;
            this.picName.BorderRadius = 10;
            this.picName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picName.Image = global::ParkingLotManagementt.Properties.Resources.ico_name_service;
            this.picName.ImageRotate = 0F;
            this.picName.Location = new System.Drawing.Point(11, 9);
            this.picName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picName.Name = "picName";
            this.picName.Size = new System.Drawing.Size(27, 24);
            this.picName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picName.TabIndex = 271;
            this.picName.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblName.Location = new System.Drawing.Point(43, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(80, 16);
            this.lblName.TabIndex = 270;
            this.lblName.Text = "Id Contract";
            // 
            // pnTrangtri_4
            // 
            this.pnTrangtri_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnTrangtri_4.Location = new System.Drawing.Point(11, 68);
            this.pnTrangtri_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTrangtri_4.Name = "pnTrangtri_4";
            this.pnTrangtri_4.Size = new System.Drawing.Size(384, 2);
            this.pnTrangtri_4.TabIndex = 269;
            // 
            // txtContractId
            // 
            this.txtContractId.Animated = true;
            this.txtContractId.BackColor = System.Drawing.Color.Transparent;
            this.txtContractId.BorderColor = System.Drawing.Color.White;
            this.txtContractId.BorderRadius = 6;
            this.txtContractId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContractId.DefaultText = "";
            this.txtContractId.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContractId.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContractId.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContractId.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContractId.Enabled = false;
            this.txtContractId.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtContractId.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContractId.ForeColor = System.Drawing.Color.DarkGray;
            this.txtContractId.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContractId.Location = new System.Drawing.Point(11, 36);
            this.txtContractId.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtContractId.Name = "txtContractId";
            this.txtContractId.PasswordChar = '\0';
            this.txtContractId.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtContractId.PlaceholderText = "ex. Washing full car";
            this.txtContractId.ReadOnly = true;
            this.txtContractId.SelectedText = "";
            this.txtContractId.Size = new System.Drawing.Size(384, 30);
            this.txtContractId.TabIndex = 268;
            // 
            // btnPayment
            // 
            this.btnPayment.BorderRadius = 15;
            this.btnPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Location = new System.Drawing.Point(486, 509);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(247, 45);
            this.btnPayment.TabIndex = 1;
            this.btnPayment.Text = "Pay";
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label16.Location = new System.Drawing.Point(500, 170);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 20);
            this.label16.TabIndex = 267;
            this.label16.Text = "Your ID";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label17.Location = new System.Drawing.Point(500, 264);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 20);
            this.label17.TabIndex = 268;
            this.label17.Text = "Full name";
            // 
            // guna2Panel25
            // 
            this.guna2Panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.guna2Panel25.Location = new System.Drawing.Point(468, 222);
            this.guna2Panel25.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel25.Name = "guna2Panel25";
            this.guna2Panel25.Size = new System.Drawing.Size(283, 2);
            this.guna2Panel25.TabIndex = 264;
            // 
            // guna2Panel26
            // 
            this.guna2Panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.guna2Panel26.Location = new System.Drawing.Point(468, 314);
            this.guna2Panel26.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel26.Name = "guna2Panel26";
            this.guna2Panel26.Size = new System.Drawing.Size(283, 2);
            this.guna2Panel26.TabIndex = 265;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Animated = true;
            this.txtCustomerID.BorderColor = System.Drawing.Color.White;
            this.txtCustomerID.BorderRadius = 6;
            this.txtCustomerID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerID.DefaultText = "";
            this.txtCustomerID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerID.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtCustomerID.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.txtCustomerID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerID.Location = new System.Drawing.Point(468, 194);
            this.txtCustomerID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.PasswordChar = '\0';
            this.txtCustomerID.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtCustomerID.PlaceholderText = "22110403";
            this.txtCustomerID.ReadOnly = true;
            this.txtCustomerID.SelectedText = "";
            this.txtCustomerID.Size = new System.Drawing.Size(283, 30);
            this.txtCustomerID.TabIndex = 262;
            // 
            // txtFullname
            // 
            this.txtFullname.Animated = true;
            this.txtFullname.BorderColor = System.Drawing.Color.White;
            this.txtFullname.BorderRadius = 6;
            this.txtFullname.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullname.DefaultText = "";
            this.txtFullname.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullname.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullname.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullname.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullname.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtFullname.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.txtFullname.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullname.Location = new System.Drawing.Point(468, 286);
            this.txtFullname.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtFullname.Name = "txtFullname";
            this.txtFullname.PasswordChar = '\0';
            this.txtFullname.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtFullname.PlaceholderText = "Nguyễn Công Quý";
            this.txtFullname.ReadOnly = true;
            this.txtFullname.SelectedText = "";
            this.txtFullname.Size = new System.Drawing.Size(283, 30);
            this.txtFullname.TabIndex = 263;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.label1.Location = new System.Drawing.Point(500, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 274;
            this.label1.Text = "Pay Date";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.guna2Panel2.Location = new System.Drawing.Point(468, 418);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(283, 2);
            this.guna2Panel2.TabIndex = 273;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderRadius = 10;
            this.guna2PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox1.Image = global::ParkingLotManagementt.Properties.Resources.ico_blue_name;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(468, 363);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(27, 24);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 275;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.BackColor = System.Drawing.Color.White;
            this.guna2CirclePictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox2.ErrorImage")));
            this.guna2CirclePictureBox2.FillColor = System.Drawing.Color.IndianRed;
            this.guna2CirclePictureBox2.Image = global::ParkingLotManagementt.Properties.Resources.pic_avatar;
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(468, 68);
            this.guna2CirclePictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(62, 56);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox2.TabIndex = 271;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // guna2PictureBox17
            // 
            this.guna2PictureBox17.BorderRadius = 10;
            this.guna2PictureBox17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox17.Image = global::ParkingLotManagementt.Properties.Resources.ico_id_blue;
            this.guna2PictureBox17.ImageRotate = 0F;
            this.guna2PictureBox17.Location = new System.Drawing.Point(468, 168);
            this.guna2PictureBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox17.Name = "guna2PictureBox17";
            this.guna2PictureBox17.Size = new System.Drawing.Size(27, 24);
            this.guna2PictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox17.TabIndex = 269;
            this.guna2PictureBox17.TabStop = false;
            // 
            // guna2PictureBox18
            // 
            this.guna2PictureBox18.BorderRadius = 10;
            this.guna2PictureBox18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox18.Image = global::ParkingLotManagementt.Properties.Resources.ico_blue_name;
            this.guna2PictureBox18.ImageRotate = 0F;
            this.guna2PictureBox18.Location = new System.Drawing.Point(468, 261);
            this.guna2PictureBox18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox18.Name = "guna2PictureBox18";
            this.guna2PictureBox18.Size = new System.Drawing.Size(27, 24);
            this.guna2PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox18.TabIndex = 270;
            this.guna2PictureBox18.TabStop = false;
            // 
            // txtPayDate
            // 
            this.txtPayDate.Animated = true;
            this.txtPayDate.BorderColor = System.Drawing.Color.White;
            this.txtPayDate.BorderRadius = 6;
            this.txtPayDate.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPayDate.DefaultText = "";
            this.txtPayDate.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPayDate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPayDate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPayDate.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPayDate.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtPayDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.txtPayDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPayDate.Location = new System.Drawing.Point(468, 390);
            this.txtPayDate.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPayDate.Name = "txtPayDate";
            this.txtPayDate.PasswordChar = '\0';
            this.txtPayDate.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPayDate.PlaceholderText = "Nguyễn Công Quý";
            this.txtPayDate.ReadOnly = true;
            this.txtPayDate.SelectedText = "";
            this.txtPayDate.Size = new System.Drawing.Size(283, 30);
            this.txtPayDate.TabIndex = 272;
            // 
            // picExit
            // 
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.FillColor = System.Drawing.Color.Red;
            this.picExit.ImageRotate = 0F;
            this.picExit.Location = new System.Drawing.Point(790, 0);
            this.picExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picExit.Name = "picExit";
            this.picExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picExit.Size = new System.Drawing.Size(18, 16);
            this.picExit.TabIndex = 276;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.Font = new System.Drawing.Font("Segoe UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(465, 453);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(17, 17);
            this.lblNotice.TabIndex = 277;
            this.lblNotice.Text = "...";
            // 
            // uC_ContractDetailPayMentForCustomer1
            // 
            this.uC_ContractDetailPayMentForCustomer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.uC_ContractDetailPayMentForCustomer1.Location = new System.Drawing.Point(3, 4);
            this.uC_ContractDetailPayMentForCustomer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_ContractDetailPayMentForCustomer1.Name = "uC_ContractDetailPayMentForCustomer1";
            this.uC_ContractDetailPayMentForCustomer1.Size = new System.Drawing.Size(372, 62);
            this.uC_ContractDetailPayMentForCustomer1.TabIndex = 0;
            // 
            // uC_ContractDetailPayMentForCustomer2
            // 
            this.uC_ContractDetailPayMentForCustomer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.uC_ContractDetailPayMentForCustomer2.Location = new System.Drawing.Point(3, 74);
            this.uC_ContractDetailPayMentForCustomer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_ContractDetailPayMentForCustomer2.Name = "uC_ContractDetailPayMentForCustomer2";
            this.uC_ContractDetailPayMentForCustomer2.Size = new System.Drawing.Size(372, 62);
            this.uC_ContractDetailPayMentForCustomer2.TabIndex = 1;
            // 
            // frmPayMentForCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(810, 699);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.txtPayDate);
            this.Controls.Add(this.guna2CirclePictureBox2);
            this.Controls.Add(this.guna2PictureBox17);
            this.Controls.Add(this.guna2PictureBox18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.guna2Panel25);
            this.Controls.Add(this.guna2Panel26);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtFullname);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.pnInfomationContract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPayMentForCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPayMentForCustomer";
            this.Load += new System.EventHandler(this.frmPayMentForCustomer_Load);
            this.pnInfomationContract.ResumeLayout(false);
            this.pnInfomationContract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.flowPnContractDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnInfomationContract;
        private Guna.UI2.WinForms.Guna2Button btnPayment;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox17;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel25;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel26;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerID;
        private Guna.UI2.WinForms.Guna2TextBox txtFullname;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.FlowLayoutPanel flowPnContractDetail;
        private Guna.UI2.WinForms.Guna2PictureBox picName;
        private System.Windows.Forms.Label lblName;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_4;
        private Guna.UI2.WinForms.Guna2TextBox txtContractId;
        private UC_Controls.UC_ContractDetailPayMentForCustomer uC_ContractDetailPayMentForCustomer1;
        private UC_Controls.UC_ContractDetailPayMentForCustomer uC_ContractDetailPayMentForCustomer2;
        private System.Windows.Forms.Label lblPriceTotal;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox txtPayDate;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picExit;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox picQR;
    }
}