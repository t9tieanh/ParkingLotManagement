namespace ParkingLotManagementt.Forms
{
    partial class frmDetailCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDetailCustomer));
            this.picExit = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.pnTop = new Guna.UI2.WinForms.Guna2Panel();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.picMinimize = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.txtAddressCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtFullNameWorker = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtIDWorker = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnTrangtri_1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTrangtri_2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnTrangtri_3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPhoneCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            this.pnTrangtri_4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
            this.SuspendLayout();
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.FillColor = System.Drawing.Color.Red;
            this.picExit.ImageRotate = 0F;
            this.picExit.Location = new System.Drawing.Point(534, 4);
            this.picExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picExit.Name = "picExit";
            this.picExit.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picExit.Size = new System.Drawing.Size(20, 20);
            this.picExit.TabIndex = 15;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // pnTop
            // 
            this.pnTop.BackgroundImage = global::ParkingLotManagementt.Properties.Resources.pic_bg_1;
            this.pnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnTop.BorderColor = System.Drawing.Color.Silver;
            this.pnTop.BorderRadius = 10;
            this.pnTop.BorderThickness = 1;
            this.pnTop.Controls.Add(this.picMinimize);
            this.pnTop.Controls.Add(this.picExit);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(560, 168);
            this.pnTop.TabIndex = 145;
            this.pnTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAvatar.Image = global::ParkingLotManagementt.Properties.Resources.pic_avatar;
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(21, 187);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(100, 100);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 157;
            this.picAvatar.TabStop = false;
            // 
            // picMinimize
            // 
            this.picMinimize.BackColor = System.Drawing.Color.Transparent;
            this.picMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMinimize.FillColor = System.Drawing.Color.Yellow;
            this.picMinimize.ImageRotate = 0F;
            this.picMinimize.Location = new System.Drawing.Point(508, 4);
            this.picMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMinimize.Name = "picMinimize";
            this.picMinimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picMinimize.Size = new System.Drawing.Size(20, 20);
            this.picMinimize.TabIndex = 14;
            this.picMinimize.TabStop = false;
            // 
            // txtAddressCustomer
            // 
            this.txtAddressCustomer.Animated = true;
            this.txtAddressCustomer.BorderColor = System.Drawing.Color.White;
            this.txtAddressCustomer.BorderRadius = 6;
            this.txtAddressCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddressCustomer.DefaultText = "";
            this.txtAddressCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddressCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddressCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddressCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddressCustomer.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtAddressCustomer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressCustomer.ForeColor = System.Drawing.Color.DarkGray;
            this.txtAddressCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddressCustomer.Location = new System.Drawing.Point(21, 467);
            this.txtAddressCustomer.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtAddressCustomer.Name = "txtAddressCustomer";
            this.txtAddressCustomer.PasswordChar = '\0';
            this.txtAddressCustomer.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtAddressCustomer.PlaceholderText = "ex. TpHcm";
            this.txtAddressCustomer.SelectedText = "";
            this.txtAddressCustomer.Size = new System.Drawing.Size(500, 40);
            this.txtAddressCustomer.TabIndex = 161;
            // 
            // txtFullNameWorker
            // 
            this.txtFullNameWorker.Animated = true;
            this.txtFullNameWorker.BorderColor = System.Drawing.Color.White;
            this.txtFullNameWorker.BorderRadius = 6;
            this.txtFullNameWorker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullNameWorker.DefaultText = "";
            this.txtFullNameWorker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullNameWorker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullNameWorker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullNameWorker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullNameWorker.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtFullNameWorker.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullNameWorker.ForeColor = System.Drawing.Color.DarkGray;
            this.txtFullNameWorker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullNameWorker.Location = new System.Drawing.Point(21, 340);
            this.txtFullNameWorker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtFullNameWorker.Name = "txtFullNameWorker";
            this.txtFullNameWorker.PasswordChar = '\0';
            this.txtFullNameWorker.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtFullNameWorker.PlaceholderText = "ex. Nguyễn Văn A";
            this.txtFullNameWorker.SelectedText = "";
            this.txtFullNameWorker.Size = new System.Drawing.Size(500, 40);
            this.txtFullNameWorker.TabIndex = 160;
            // 
            // txtIDWorker
            // 
            this.txtIDWorker.Animated = true;
            this.txtIDWorker.BorderColor = System.Drawing.Color.White;
            this.txtIDWorker.BorderRadius = 6;
            this.txtIDWorker.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDWorker.DefaultText = "";
            this.txtIDWorker.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtIDWorker.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtIDWorker.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDWorker.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtIDWorker.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtIDWorker.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDWorker.ForeColor = System.Drawing.Color.DarkGray;
            this.txtIDWorker.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtIDWorker.Location = new System.Drawing.Point(176, 194);
            this.txtIDWorker.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtIDWorker.Name = "txtIDWorker";
            this.txtIDWorker.PasswordChar = '\0';
            this.txtIDWorker.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtIDWorker.PlaceholderText = "ex. 101";
            this.txtIDWorker.ReadOnly = true;
            this.txtIDWorker.SelectedText = "";
            this.txtIDWorker.Size = new System.Drawing.Size(345, 40);
            this.txtIDWorker.TabIndex = 159;
            // 
            // pnTrangtri_1
            // 
            this.pnTrangtri_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.pnTrangtri_1.Location = new System.Drawing.Point(176, 232);
            this.pnTrangtri_1.Name = "pnTrangtri_1";
            this.pnTrangtri_1.Size = new System.Drawing.Size(345, 2);
            this.pnTrangtri_1.TabIndex = 165;
            // 
            // pnTrangtri_2
            // 
            this.pnTrangtri_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.pnTrangtri_2.Location = new System.Drawing.Point(21, 378);
            this.pnTrangtri_2.Name = "pnTrangtri_2";
            this.pnTrangtri_2.Size = new System.Drawing.Size(500, 2);
            this.pnTrangtri_2.TabIndex = 165;
            // 
            // pnTrangtri_3
            // 
            this.pnTrangtri_3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.pnTrangtri_3.Location = new System.Drawing.Point(21, 505);
            this.pnTrangtri_3.Name = "pnTrangtri_3";
            this.pnTrangtri_3.Size = new System.Drawing.Size(500, 2);
            this.pnTrangtri_3.TabIndex = 165;
            // 
            // txtPhoneCustomer
            // 
            this.txtPhoneCustomer.Animated = true;
            this.txtPhoneCustomer.BorderColor = System.Drawing.Color.White;
            this.txtPhoneCustomer.BorderRadius = 6;
            this.txtPhoneCustomer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhoneCustomer.DefaultText = "";
            this.txtPhoneCustomer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhoneCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhoneCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneCustomer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhoneCustomer.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtPhoneCustomer.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneCustomer.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPhoneCustomer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhoneCustomer.Location = new System.Drawing.Point(21, 594);
            this.txtPhoneCustomer.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPhoneCustomer.Name = "txtPhoneCustomer";
            this.txtPhoneCustomer.PasswordChar = '\0';
            this.txtPhoneCustomer.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPhoneCustomer.PlaceholderText = "ex. +84";
            this.txtPhoneCustomer.SelectedText = "";
            this.txtPhoneCustomer.Size = new System.Drawing.Size(500, 40);
            this.txtPhoneCustomer.TabIndex = 161;
            // 
            // pnTrangtri_4
            // 
            this.pnTrangtri_4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.pnTrangtri_4.Location = new System.Drawing.Point(21, 632);
            this.pnTrangtri_4.Name = "pnTrangtri_4";
            this.pnTrangtri_4.Size = new System.Drawing.Size(500, 2);
            this.pnTrangtri_4.TabIndex = 165;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.White;
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnSave.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(351, 692);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 49);
            this.btnSave.TabIndex = 166;
            this.btnSave.Text = "Save";
            // 
            // frmProfileCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 790);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pnTrangtri_4);
            this.Controls.Add(this.pnTrangtri_3);
            this.Controls.Add(this.pnTrangtri_2);
            this.Controls.Add(this.pnTrangtri_1);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.txtPhoneCustomer);
            this.Controls.Add(this.txtAddressCustomer);
            this.Controls.Add(this.txtFullNameWorker);
            this.Controls.Add(this.txtIDWorker);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProfileCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProfileCustomer";
            this.Load += new System.EventHandler(this.frmProfileCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox picExit;
        private Guna.UI2.WinForms.Guna2Panel pnTop;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picMinimize;
        private Guna.UI2.WinForms.Guna2TextBox txtAddressCustomer;
        private Guna.UI2.WinForms.Guna2TextBox txtFullNameWorker;
        private Guna.UI2.WinForms.Guna2TextBox txtIDWorker;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_1;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_2;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_3;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneCustomer;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_4;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}