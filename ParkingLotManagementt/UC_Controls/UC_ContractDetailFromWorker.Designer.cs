namespace ParkingLotManagementt.UC_Controls
{
    partial class UC_ContractDetailFromWorker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ContractDetailFromWorker));
            this.lblTTStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStatus = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.picStatusContractDetail = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnPreview = new Guna.UI2.WinForms.Guna2Button();
            this.picVehicle = new Guna.UI2.WinForms.Guna2PictureBox();
            this.picDescription = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblContractDetailID = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNameOfService = new System.Windows.Forms.Label();
            this.pnTrangtri = new Guna.UI2.WinForms.Guna2Panel();
            this.lable1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picStatusContractDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTTStatus
            // 
            this.lblTTStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblTTStatus.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            this.lblTTStatus.Location = new System.Drawing.Point(24, 68);
            this.lblTTStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTTStatus.Name = "lblTTStatus";
            this.lblTTStatus.Size = new System.Drawing.Size(45, 21);
            this.lblTTStatus.TabIndex = 207;
            this.lblTTStatus.Text = "Status :";
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            this.lblStatus.Location = new System.Drawing.Point(81, 68);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 21);
            this.lblStatus.TabIndex = 208;
            this.lblStatus.Text = "Done";
            // 
            // picStatusContractDetail
            // 
            this.picStatusContractDetail.Image = ((System.Drawing.Image)(resources.GetObject("picStatusContractDetail.Image")));
            this.picStatusContractDetail.ImageRotate = 0F;
            this.picStatusContractDetail.Location = new System.Drawing.Point(151, 67);
            this.picStatusContractDetail.Name = "picStatusContractDetail";
            this.picStatusContractDetail.Size = new System.Drawing.Size(20, 22);
            this.picStatusContractDetail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picStatusContractDetail.TabIndex = 209;
            this.picStatusContractDetail.TabStop = false;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnPreview.BorderRadius = 10;
            this.btnPreview.BorderThickness = 1;
            this.btnPreview.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreview.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreview.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreview.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreview.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(132)))), ((int)(((byte)(227)))));
            this.btnPreview.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.White;
            this.btnPreview.Image = global::ParkingLotManagementt.Properties.Resources.ico_preview_whitye;
            this.btnPreview.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPreview.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPreview.Location = new System.Drawing.Point(255, 81);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(108, 30);
            this.btnPreview.TabIndex = 199;
            this.btnPreview.Text = "Preview";
            this.btnPreview.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // picVehicle
            // 
            this.picVehicle.BorderRadius = 10;
            this.picVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVehicle.Image = ((System.Drawing.Image)(resources.GetObject("picVehicle.Image")));
            this.picVehicle.ImageRotate = 0F;
            this.picVehicle.Location = new System.Drawing.Point(314, 14);
            this.picVehicle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(50, 45);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 204;
            this.picVehicle.TabStop = false;
            // 
            // picDescription
            // 
            this.picDescription.BorderRadius = 10;
            this.picDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDescription.Image = global::ParkingLotManagementt.Properties.Resources.ico_content;
            this.picDescription.ImageRotate = 0F;
            this.picDescription.Location = new System.Drawing.Point(24, 92);
            this.picDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDescription.Name = "picDescription";
            this.picDescription.Size = new System.Drawing.Size(27, 24);
            this.picDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDescription.TabIndex = 203;
            this.picDescription.TabStop = false;
            // 
            // lblContractDetailID
            // 
            this.lblContractDetailID.AutoSize = true;
            this.lblContractDetailID.BackColor = System.Drawing.Color.Transparent;
            this.lblContractDetailID.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContractDetailID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblContractDetailID.Location = new System.Drawing.Point(119, 11);
            this.lblContractDetailID.Name = "lblContractDetailID";
            this.lblContractDetailID.Size = new System.Drawing.Size(53, 17);
            this.lblContractDetailID.TabIndex = 201;
            this.lblContractDetailID.Text = "ID here";
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblDescription.Location = new System.Drawing.Point(57, 96);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(179, 20);
            this.lblDescription.TabIndex = 200;
            this.lblDescription.Text = "Description";
            // 
            // lblNameOfService
            // 
            this.lblNameOfService.AutoSize = true;
            this.lblNameOfService.BackColor = System.Drawing.Color.Transparent;
            this.lblNameOfService.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.lblNameOfService.Location = new System.Drawing.Point(20, 43);
            this.lblNameOfService.Name = "lblNameOfService";
            this.lblNameOfService.Size = new System.Drawing.Size(110, 22);
            this.lblNameOfService.TabIndex = 202;
            this.lblNameOfService.Text = "Name here";
            // 
            // pnTrangtri
            // 
            this.pnTrangtri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(190)))), ((int)(((byte)(195)))));
            this.pnTrangtri.Location = new System.Drawing.Point(377, 11);
            this.pnTrangtri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTrangtri.Name = "pnTrangtri";
            this.pnTrangtri.Size = new System.Drawing.Size(4, 100);
            this.pnTrangtri.TabIndex = 205;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.BackColor = System.Drawing.Color.Transparent;
            this.lable1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lable1.Location = new System.Drawing.Point(21, 11);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(92, 17);
            this.lable1.TabIndex = 206;
            this.lable1.Text = "Contract ID: ";
            // 
            // UC_ContractDetailFromWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picStatusContractDetail);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTTStatus);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.pnTrangtri);
            this.Controls.Add(this.picDescription);
            this.Controls.Add(this.picVehicle);
            this.Controls.Add(this.lblNameOfService);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblContractDetailID);
            this.Controls.Add(this.btnPreview);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UC_ContractDetailFromWorker";
            this.Size = new System.Drawing.Size(390, 119);
            ((System.ComponentModel.ISupportInitialize)(this.picStatusContractDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTTStatus;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStatus;
        private Guna.UI2.WinForms.Guna2PictureBox picStatusContractDetail;
        private Guna.UI2.WinForms.Guna2Button btnPreview;
        private Guna.UI2.WinForms.Guna2PictureBox picVehicle;
        private Guna.UI2.WinForms.Guna2PictureBox picDescription;
        private System.Windows.Forms.Label lblContractDetailID;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNameOfService;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri;
        private System.Windows.Forms.Label lable1;
    }
}
