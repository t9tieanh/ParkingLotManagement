namespace ParkingLotManagementt.Forms
{
    partial class frmDetailWorker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailWorker));
            this.pnBottom = new Guna.UI2.WinForms.Guna2Panel();
            this.picChange = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picAdd = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picDelete = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.lblNotice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblType = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblPartArea = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblAddress = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblFullName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblIDWorker = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtAddressWorker = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbGetParkingArea = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnTypeWorker = new Guna.UI2.WinForms.Guna2Panel();
            this.rbtnWashing = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbtnRepair = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbtnLookAfter = new Guna.UI2.WinForms.Guna2RadioButton();
            this.txtFullNameWorker = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIDWorker = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnImportImage = new Guna.UI2.WinForms.Guna2ImageButton();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.picMaximize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picMinimize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picExit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).BeginInit();
            this.pnInfo.SuspendLayout();
            this.pnTypeWorker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnBottom
            // 
            this.pnBottom.BackColor = System.Drawing.Color.SteelBlue;
            this.pnBottom.Controls.Add(this.picChange);
            this.pnBottom.Controls.Add(this.picAdd);
            this.pnBottom.Controls.Add(this.picDelete);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(0, 611);
            this.pnBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(517, 66);
            this.pnBottom.TabIndex = 13;
            this.pnBottom.Paint += new System.Windows.Forms.PaintEventHandler(this.pnBottom_Paint);
            // 
            // picChange
            // 
            this.picChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picChange.Image = global::ParkingLotManagementt.Properties.Resources.ico_change_white;
            this.picChange.ImageRotate = 0F;
            this.picChange.Location = new System.Drawing.Point(439, 6);
            this.picChange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picChange.Name = "picChange";
            this.picChange.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picChange.Size = new System.Drawing.Size(57, 51);
            this.picChange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picChange.TabIndex = 0;
            this.picChange.TabStop = false;
            this.picChange.Click += new System.EventHandler(this.picChange_Click);
            // 
            // picAdd
            // 
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = global::ParkingLotManagementt.Properties.Resources.ico_add_white;
            this.picAdd.ImageRotate = 0F;
            this.picAdd.Location = new System.Drawing.Point(232, 6);
            this.picAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAdd.Name = "picAdd";
            this.picAdd.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAdd.Size = new System.Drawing.Size(57, 51);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAdd.TabIndex = 0;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // picDelete
            // 
            this.picDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelete.Image = global::ParkingLotManagementt.Properties.Resources.ico_delete;
            this.picDelete.ImageRotate = 0F;
            this.picDelete.Location = new System.Drawing.Point(14, 6);
            this.picDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDelete.Name = "picDelete";
            this.picDelete.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picDelete.Size = new System.Drawing.Size(57, 51);
            this.picDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDelete.TabIndex = 0;
            this.picDelete.TabStop = false;
            this.picDelete.Click += new System.EventHandler(this.picDelete_Click);
            // 
            // pnInfo
            // 
            this.pnInfo.BackColor = System.Drawing.Color.Transparent;
            this.pnInfo.BorderColor = System.Drawing.Color.Silver;
            this.pnInfo.BorderRadius = 10;
            this.pnInfo.BorderThickness = 2;
            this.pnInfo.Controls.Add(this.lblNotice);
            this.pnInfo.Controls.Add(this.lblType);
            this.pnInfo.Controls.Add(this.lblPartArea);
            this.pnInfo.Controls.Add(this.lblAddress);
            this.pnInfo.Controls.Add(this.lblFullName);
            this.pnInfo.Controls.Add(this.lblIDWorker);
            this.pnInfo.Controls.Add(this.txtAddressWorker);
            this.pnInfo.Controls.Add(this.cbGetParkingArea);
            this.pnInfo.Controls.Add(this.pnTypeWorker);
            this.pnInfo.Controls.Add(this.txtFullNameWorker);
            this.pnInfo.Controls.Add(this.txtIDWorker);
            this.pnInfo.FillColor = System.Drawing.Color.White;
            this.pnInfo.Location = new System.Drawing.Point(76, 195);
            this.pnInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnInfo.Name = "pnInfo";
            this.pnInfo.Size = new System.Drawing.Size(341, 413);
            this.pnInfo.TabIndex = 143;
            this.pnInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.pnInfo_Paint);
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(41, 377);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(70, 19);
            this.lblNotice.TabIndex = 159;
            this.lblNotice.Text = "Notice : ...";
            this.lblNotice.Click += new System.EventHandler(this.lblNotice_Click);
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.lblType.Location = new System.Drawing.Point(42, 292);
            this.lblType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(42, 21);
            this.lblType.TabIndex = 158;
            this.lblType.Text = "Type";
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            // 
            // lblPartArea
            // 
            this.lblPartArea.BackColor = System.Drawing.Color.Transparent;
            this.lblPartArea.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.lblPartArea.Location = new System.Drawing.Point(42, 225);
            this.lblPartArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblPartArea.Name = "lblPartArea";
            this.lblPartArea.Size = new System.Drawing.Size(76, 21);
            this.lblPartArea.TabIndex = 158;
            this.lblPartArea.Text = "Part area";
            this.lblPartArea.Click += new System.EventHandler(this.lblPartArea_Click);
            // 
            // lblAddress
            // 
            this.lblAddress.BackColor = System.Drawing.Color.Transparent;
            this.lblAddress.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.lblAddress.Location = new System.Drawing.Point(42, 150);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(70, 21);
            this.lblAddress.TabIndex = 158;
            this.lblAddress.Text = "Address";
            this.lblAddress.Click += new System.EventHandler(this.lblAddress_Click);
            // 
            // lblFullName
            // 
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.lblFullName.Location = new System.Drawing.Point(42, 78);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(82, 21);
            this.lblFullName.TabIndex = 158;
            this.lblFullName.Text = "Full name";
            this.lblFullName.Click += new System.EventHandler(this.lblFullName_Click);
            // 
            // lblIDWorker
            // 
            this.lblIDWorker.BackColor = System.Drawing.Color.Transparent;
            this.lblIDWorker.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDWorker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(156)))), ((int)(((byte)(219)))));
            this.lblIDWorker.Location = new System.Drawing.Point(42, 8);
            this.lblIDWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblIDWorker.Name = "lblIDWorker";
            this.lblIDWorker.Size = new System.Drawing.Size(81, 21);
            this.lblIDWorker.TabIndex = 158;
            this.lblIDWorker.Text = "ID worker";
            this.lblIDWorker.Click += new System.EventHandler(this.lblIDWorker_Click);
            // 
            // txtAddressWorker
            // 
            this.txtAddressWorker.Animated = true;
            this.txtAddressWorker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.txtAddressWorker.BorderRadius = 6;
            this.txtAddressWorker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressWorker.DefaultText = "";
            this.txtAddressWorker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddressWorker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddressWorker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddressWorker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddressWorker.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddressWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtAddressWorker.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAddressWorker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddressWorker.Location = new System.Drawing.Point(42, 177);
            this.txtAddressWorker.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtAddressWorker.Name = "txtAddressWorker";
            this.txtAddressWorker.PasswordChar = '\0';
            this.txtAddressWorker.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAddressWorker.PlaceholderText = "ex. TpHcm";
            this.txtAddressWorker.SelectedText = "";
            this.txtAddressWorker.Size = new System.Drawing.Size(263, 34);
            this.txtAddressWorker.TabIndex = 157;
            this.txtAddressWorker.TextChanged += new System.EventHandler(this.txtAddressWorker_TextChanged);
            // 
            // cbGetParkingArea
            // 
            this.cbGetParkingArea.BackColor = System.Drawing.Color.Transparent;
            this.cbGetParkingArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.cbGetParkingArea.BorderRadius = 6;
            this.cbGetParkingArea.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbGetParkingArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGetParkingArea.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGetParkingArea.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbGetParkingArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cbGetParkingArea.ForeColor = System.Drawing.Color.DarkGray;
            this.cbGetParkingArea.ItemHeight = 30;
            this.cbGetParkingArea.Location = new System.Drawing.Point(42, 249);
            this.cbGetParkingArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbGetParkingArea.Name = "cbGetParkingArea";
            this.cbGetParkingArea.Size = new System.Drawing.Size(264, 36);
            this.cbGetParkingArea.TabIndex = 156;
            this.cbGetParkingArea.SelectedIndexChanged += new System.EventHandler(this.cbGetParkingArea_SelectedIndexChanged);
            // 
            // pnTypeWorker
            // 
            this.pnTypeWorker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.pnTypeWorker.BorderRadius = 6;
            this.pnTypeWorker.BorderThickness = 1;
            this.pnTypeWorker.Controls.Add(this.rbtnWashing);
            this.pnTypeWorker.Controls.Add(this.rbtnRepair);
            this.pnTypeWorker.Controls.Add(this.rbtnLookAfter);
            this.pnTypeWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.pnTypeWorker.Location = new System.Drawing.Point(42, 316);
            this.pnTypeWorker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTypeWorker.Name = "pnTypeWorker";
            this.pnTypeWorker.Size = new System.Drawing.Size(263, 47);
            this.pnTypeWorker.TabIndex = 153;
            this.pnTypeWorker.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTypeWorker_Paint);
            // 
            // rbtnWashing
            // 
            this.rbtnWashing.AutoSize = true;
            this.rbtnWashing.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rbtnWashing.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnWashing.CheckedState.BorderThickness = 2;
            this.rbtnWashing.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnWashing.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbtnWashing.CheckedState.InnerOffset = -4;
            this.rbtnWashing.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnWashing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnWashing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnWashing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.rbtnWashing.Location = new System.Drawing.Point(171, 9);
            this.rbtnWashing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbtnWashing.Name = "rbtnWashing";
            this.rbtnWashing.Size = new System.Drawing.Size(72, 24);
            this.rbtnWashing.TabIndex = 45;
            this.rbtnWashing.Text = "Wash";
            this.rbtnWashing.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbtnWashing.UncheckedState.BorderThickness = 2;
            this.rbtnWashing.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbtnWashing.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbtnWashing.CheckedChanged += new System.EventHandler(this.rbtnWashing_CheckedChanged);
            // 
            // rbtnRepair
            // 
            this.rbtnRepair.AutoSize = true;
            this.rbtnRepair.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rbtnRepair.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnRepair.CheckedState.BorderThickness = 2;
            this.rbtnRepair.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnRepair.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbtnRepair.CheckedState.InnerOffset = -4;
            this.rbtnRepair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnRepair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnRepair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.rbtnRepair.Location = new System.Drawing.Point(82, 9);
            this.rbtnRepair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbtnRepair.Name = "rbtnRepair";
            this.rbtnRepair.Size = new System.Drawing.Size(78, 24);
            this.rbtnRepair.TabIndex = 45;
            this.rbtnRepair.Text = "Repair";
            this.rbtnRepair.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbtnRepair.UncheckedState.BorderThickness = 2;
            this.rbtnRepair.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbtnRepair.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbtnRepair.CheckedChanged += new System.EventHandler(this.rbtnRepair_CheckedChanged);
            // 
            // rbtnLookAfter
            // 
            this.rbtnLookAfter.AutoSize = true;
            this.rbtnLookAfter.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.rbtnLookAfter.Checked = true;
            this.rbtnLookAfter.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnLookAfter.CheckedState.BorderThickness = 2;
            this.rbtnLookAfter.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(153)))), ((int)(((byte)(149)))));
            this.rbtnLookAfter.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbtnLookAfter.CheckedState.InnerOffset = -4;
            this.rbtnLookAfter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtnLookAfter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLookAfter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnLookAfter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.rbtnLookAfter.Location = new System.Drawing.Point(4, 9);
            this.rbtnLookAfter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbtnLookAfter.Name = "rbtnLookAfter";
            this.rbtnLookAfter.Size = new System.Drawing.Size(65, 24);
            this.rbtnLookAfter.TabIndex = 46;
            this.rbtnLookAfter.TabStop = true;
            this.rbtnLookAfter.Text = "Look";
            this.rbtnLookAfter.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbtnLookAfter.UncheckedState.BorderThickness = 2;
            this.rbtnLookAfter.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbtnLookAfter.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbtnLookAfter.CheckedChanged += new System.EventHandler(this.rbtnLookAfter_CheckedChanged);
            // 
            // txtFullNameWorker
            // 
            this.txtFullNameWorker.Animated = true;
            this.txtFullNameWorker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.txtFullNameWorker.BorderRadius = 6;
            this.txtFullNameWorker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullNameWorker.DefaultText = "";
            this.txtFullNameWorker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullNameWorker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullNameWorker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullNameWorker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullNameWorker.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullNameWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtFullNameWorker.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFullNameWorker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullNameWorker.Location = new System.Drawing.Point(42, 105);
            this.txtFullNameWorker.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtFullNameWorker.Name = "txtFullNameWorker";
            this.txtFullNameWorker.PasswordChar = '\0';
            this.txtFullNameWorker.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFullNameWorker.PlaceholderText = "ex. Nguyễn Văn A";
            this.txtFullNameWorker.SelectedText = "";
            this.txtFullNameWorker.Size = new System.Drawing.Size(263, 34);
            this.txtFullNameWorker.TabIndex = 152;
            this.txtFullNameWorker.TextChanged += new System.EventHandler(this.txtFullNameWorker_TextChanged);
            // 
            // txtIDWorker
            // 
            this.txtIDWorker.Animated = true;
            this.txtIDWorker.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(179)))), ((int)(((byte)(255)))));
            this.txtIDWorker.BorderRadius = 6;
            this.txtIDWorker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDWorker.DefaultText = "";
            this.txtIDWorker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDWorker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDWorker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDWorker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDWorker.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDWorker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtIDWorker.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIDWorker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDWorker.Location = new System.Drawing.Point(42, 33);
            this.txtIDWorker.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtIDWorker.Name = "txtIDWorker";
            this.txtIDWorker.PasswordChar = '\0';
            this.txtIDWorker.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtIDWorker.PlaceholderText = "ex. 101";
            this.txtIDWorker.SelectedText = "";
            this.txtIDWorker.Size = new System.Drawing.Size(263, 34);
            this.txtIDWorker.TabIndex = 151;
            this.txtIDWorker.TextChanged += new System.EventHandler(this.txtIDWorker_TextChanged);
            // 
            // btnImportImage
            // 
            this.btnImportImage.BackColor = System.Drawing.Color.Transparent;
            this.btnImportImage.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnImportImage.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnImportImage.Image = ((System.Drawing.Image)(resources.GetObject("btnImportImage.Image")));
            this.btnImportImage.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnImportImage.ImageRotate = 0F;
            this.btnImportImage.ImageSize = new System.Drawing.Size(20, 20);
            this.btnImportImage.Location = new System.Drawing.Point(321, 154);
            this.btnImportImage.Name = "btnImportImage";
            this.btnImportImage.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnImportImage.Size = new System.Drawing.Size(24, 29);
            this.btnImportImage.TabIndex = 158;
            this.btnImportImage.Click += new System.EventHandler(this.btnImportImage_Click);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picAvatar.Image = global::ParkingLotManagementt.Properties.Resources.pic_avatar;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(178, 58);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(138, 124);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 157;
            this.picAvatar.TabStop = false;
            this.picAvatar.Click += new System.EventHandler(this.picAvatar_Click);
            // 
            // pnTop
            // 
            this.pnTop.BackgroundImage = global::ParkingLotManagementt.Properties.Resources.pic_bg_1;
            this.pnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTop.BorderColor = System.Drawing.Color.Silver;
            this.pnTop.BorderRadius = 10;
            this.pnTop.BorderThickness = 1;
            this.pnTop.Controls.Add(this.btnImportImage);
            this.pnTop.Controls.Add(this.picMaximize);
            this.pnTop.Controls.Add(this.picAvatar);
            this.pnTop.Controls.Add(this.picMinimize);
            this.pnTop.Controls.Add(this.picExit);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(517, 182);
            this.pnTop.TabIndex = 14;
            this.pnTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnTop_Paint);
            // 
            // picMaximize
            // 
            this.picMaximize.BackColor = System.Drawing.Color.Transparent;
            this.picMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMaximize.FillColor = System.Drawing.Color.Green;
            this.picMaximize.ImageRotate = 0F;
            this.picMaximize.Location = new System.Drawing.Point(53, 7);
            this.picMaximize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMaximize.Name = "picMaximize";
            this.picMaximize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picMaximize.Size = new System.Drawing.Size(18, 16);
            this.picMaximize.TabIndex = 13;
            this.picMaximize.TabStop = false;
            this.picMaximize.Click += new System.EventHandler(this.picMaximize_Click);
            // 
            // picMinimize
            // 
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.FillColor = System.Drawing.Color.Yellow;
            this.picMinimize.ImageRotate = 0F;
            this.picMinimize.Location = new System.Drawing.Point(30, 7);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picMinimize.Size = new System.Drawing.Size(18, 16);
            this.picMinimize.TabIndex = 14;
            this.picMinimize.TabStop = false;
            this.picMinimize.Click += new System.EventHandler(this.picMinimize_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.FillColor = System.Drawing.Color.Red;
            this.picExit.ImageRotate = 0F;
            this.picExit.Location = new System.Drawing.Point(7, 7);
            this.picExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picExit.Name = "picExit";
            this.picExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picExit.Size = new System.Drawing.Size(18, 16);
            this.picExit.TabIndex = 15;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // frmProfileWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(517, 677);
            this.Controls.Add(this.pnBottom);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmProfileWorker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProfileWorker";
            this.Load += new System.EventHandler(this.frmProfileWorker_Load);
            this.pnBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelete)).EndInit();
            this.pnInfo.ResumeLayout(false);
            this.pnInfo.PerformLayout();
            this.pnTypeWorker.ResumeLayout(false);
            this.pnTypeWorker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel pnBottom;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picMaximize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picMinimize;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picExit;
        private Guna.UI2.WinForms.Guna2Panel pnInfo;
        private Guna.UI2.WinForms.Guna2ComboBox cbGetParkingArea;
        private Guna.UI2.WinForms.Guna2Panel pnTypeWorker;
        private Guna.UI2.WinForms.Guna2RadioButton rbtnWashing;
        private Guna.UI2.WinForms.Guna2RadioButton rbtnRepair;
        private Guna.UI2.WinForms.Guna2RadioButton rbtnLookAfter;
        private Guna.UI2.WinForms.Guna2TextBox txtFullNameWorker;
        private Guna.UI2.WinForms.Guna2TextBox txtIDWorker;
        private Guna.UI2.WinForms.Guna2ImageButton btnImportImage;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picChange;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAdd;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picDelete;
        private Guna.UI2.WinForms.Guna2TextBox txtAddressWorker;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblType;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPartArea;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAddress;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblFullName;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblIDWorker;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNotice;
    }
}