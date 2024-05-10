namespace ParkingLotManagementt.UC_Controls
{
    partial class UC_ContractFromVehicle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ContractFromVehicle));
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.flowPnContract = new System.Windows.Forms.FlowLayoutPanel();
            this.lblReceptionDate = new System.Windows.Forms.Label();
            this.lblNotice = new System.Windows.Forms.Label();
            this.lblDateDelivery = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.contractFromTimeLine1 = new ParkingLotManagementt.UC_Controls.ContractFromTimeLine();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.flowPnContract.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(289, 13);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(60, 51);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 2;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // flowPnContract
            // 
            this.flowPnContract.Controls.Add(this.contractFromTimeLine1);
            this.flowPnContract.Location = new System.Drawing.Point(147, 135);
            this.flowPnContract.Name = "flowPnContract";
            this.flowPnContract.Size = new System.Drawing.Size(345, 154);
            this.flowPnContract.TabIndex = 4;
            // 
            // lblReceptionDate
            // 
            this.lblReceptionDate.AutoSize = true;
            this.lblReceptionDate.BackColor = System.Drawing.Color.Transparent;
            this.lblReceptionDate.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceptionDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(110)))), ((int)(((byte)(114)))));
            this.lblReceptionDate.Location = new System.Drawing.Point(366, 44);
            this.lblReceptionDate.Name = "lblReceptionDate";
            this.lblReceptionDate.Size = new System.Drawing.Size(69, 20);
            this.lblReceptionDate.TabIndex = 275;
            this.lblReceptionDate.Text = "Time line";
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.Transparent;
            this.lblNotice.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotice.ForeColor = System.Drawing.Color.Red;
            this.lblNotice.Location = new System.Drawing.Point(333, 70);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(277, 45);
            this.lblNotice.TabIndex = 276;
            this.lblNotice.Text = "*";
            // 
            // lblDateDelivery
            // 
            this.lblDateDelivery.AutoSize = true;
            this.lblDateDelivery.BackColor = System.Drawing.Color.Transparent;
            this.lblDateDelivery.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDelivery.ForeColor = System.Drawing.Color.Red;
            this.lblDateDelivery.Location = new System.Drawing.Point(333, 115);
            this.lblDateDelivery.Name = "lblDateDelivery";
            this.lblDateDelivery.Size = new System.Drawing.Size(14, 17);
            this.lblDateDelivery.TabIndex = 277;
            this.lblDateDelivery.Text = "*";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2Panel1.Location = new System.Drawing.Point(-13, 32);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(200, 5);
            this.guna2Panel1.TabIndex = 278;
            // 
            // contractFromTimeLine1
            // 
            this.contractFromTimeLine1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.contractFromTimeLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contractFromTimeLine1.Location = new System.Drawing.Point(3, 3);
            this.contractFromTimeLine1.Name = "contractFromTimeLine1";
            this.contractFromTimeLine1.Size = new System.Drawing.Size(345, 151);
            this.contractFromTimeLine1.TabIndex = 3;
            // 
            // UC_ContractFromVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.lblDateDelivery);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.lblReceptionDate);
            this.Controls.Add(this.flowPnContract);
            this.Controls.Add(this.guna2CirclePictureBox1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_ContractFromVehicle";
            this.Size = new System.Drawing.Size(613, 318);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.flowPnContract.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private ContractFromTimeLine contractFromTimeLine1;
        private System.Windows.Forms.FlowLayoutPanel flowPnContract;
        private System.Windows.Forms.Label lblReceptionDate;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label lblDateDelivery;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
