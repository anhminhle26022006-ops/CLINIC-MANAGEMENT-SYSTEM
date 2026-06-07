namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucPatientRecordRow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientCode = new System.Windows.Forms.Label();
            this.lblPatientAgeGender = new System.Windows.Forms.Label();
            this.lblChevron = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAvatar
            // 
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(14, 30);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(48, 48);
            this.lblAvatar.TabIndex = 0;
            this.lblAvatar.Text = "N";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientName
            // 
            this.lblPatientName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientName.AutoEllipsis = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblPatientName.Location = new System.Drawing.Point(78, 14);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(362, 32);
            this.lblPatientName.TabIndex = 1;
            this.lblPatientName.Text = "Nguyễn Văn A";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPatientCode
            // 
            this.lblPatientCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientCode.AutoEllipsis = true;
            this.lblPatientCode.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPatientCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPatientCode.Location = new System.Drawing.Point(78, 48);
            this.lblPatientCode.Name = "lblPatientCode";
            this.lblPatientCode.Size = new System.Drawing.Size(362, 24);
            this.lblPatientCode.TabIndex = 2;
            this.lblPatientCode.Text = "PT001";
            this.lblPatientCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPatientAgeGender
            // 
            this.lblPatientAgeGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPatientAgeGender.AutoEllipsis = true;
            this.lblPatientAgeGender.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientAgeGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPatientAgeGender.Location = new System.Drawing.Point(78, 72);
            this.lblPatientAgeGender.Name = "lblPatientAgeGender";
            this.lblPatientAgeGender.Size = new System.Drawing.Size(362, 26);
            this.lblPatientAgeGender.TabIndex = 3;
            this.lblPatientAgeGender.Text = "26 tuổi - Nam";
            this.lblPatientAgeGender.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChevron
            // 
            this.lblChevron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChevron.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblChevron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblChevron.Location = new System.Drawing.Point(454, 37);
            this.lblChevron.Name = "lblChevron";
            this.lblChevron.Size = new System.Drawing.Size(28, 36);
            this.lblChevron.TabIndex = 4;
            this.lblChevron.Text = ">";
            this.lblChevron.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPatientRecordRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblChevron);
            this.Controls.Add(this.lblPatientAgeGender);
            this.Controls.Add(this.lblPatientCode);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblAvatar);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ucPatientRecordRow";
            this.Size = new System.Drawing.Size(500, 108);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientCode;
        private System.Windows.Forms.Label lblPatientAgeGender;
        private System.Windows.Forms.Label lblChevron;
    }
}
