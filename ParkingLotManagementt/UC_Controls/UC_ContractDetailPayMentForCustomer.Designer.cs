namespace ParkingLotManagementt.UC_Controls
{
    partial class UC_ContractDetailPayMentForCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ContractDetailPayMentForCustomer));
            this.lblNameService = new System.Windows.Forms.Label();
            this.guna2PictureBox4 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnTrangtri_4 = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNameService
            // 
            this.lblNameService.AutoSize = true;
            this.lblNameService.BackColor = System.Drawing.Color.Transparent;
            this.lblNameService.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameService.ForeColor = System.Drawing.Color.Black;
            this.lblNameService.Location = new System.Drawing.Point(17, 27);
            this.lblNameService.Name = "lblNameService";
            this.lblNameService.Size = new System.Drawing.Size(112, 20);
            this.lblNameService.TabIndex = 262;
            this.lblNameService.Text = "Name Service";
            // 
            // guna2PictureBox4
            // 
            this.guna2PictureBox4.BorderRadius = 10;
            this.guna2PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2PictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox4.Image")));
            this.guna2PictureBox4.ImageRotate = 0F;
            this.guna2PictureBox4.Location = new System.Drawing.Point(340, 2);
            this.guna2PictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2PictureBox4.Name = "guna2PictureBox4";
            this.guna2PictureBox4.Size = new System.Drawing.Size(27, 24);
            this.guna2PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox4.TabIndex = 263;
            this.guna2PictureBox4.TabStop = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(309, 29);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(33, 20);
            this.lblPrice.TabIndex = 264;
            this.lblPrice.Text = "19$";
            // 
            // pnTrangtri_4
            // 
            this.pnTrangtri_4.BackColor = System.Drawing.Color.White;
            this.pnTrangtri_4.FillColor = System.Drawing.Color.White;
            this.pnTrangtri_4.ForeColor = System.Drawing.Color.Crimson;
            this.pnTrangtri_4.Location = new System.Drawing.Point(0, 56);
            this.pnTrangtri_4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnTrangtri_4.Name = "pnTrangtri_4";
            this.pnTrangtri_4.Size = new System.Drawing.Size(384, 4);
            this.pnTrangtri_4.TabIndex = 270;
            // 
            // UC_ContractDetailPayMentForCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnTrangtri_4);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.guna2PictureBox4);
            this.Controls.Add(this.lblNameService);
            this.Name = "UC_ContractDetailPayMentForCustomer";
            this.Size = new System.Drawing.Size(384, 62);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox4;
        private System.Windows.Forms.Label lblNameService;
        private System.Windows.Forms.Label lblPrice;
        private Guna.UI2.WinForms.Guna2Panel pnTrangtri_4;
    }
}
