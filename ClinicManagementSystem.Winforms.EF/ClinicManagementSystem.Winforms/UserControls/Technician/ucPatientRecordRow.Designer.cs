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
            lblAvatar = new Label();
            lblPatientName = new Label();
            lblPatientCode = new Label();
            lblPatientAgeGender = new Label();
            lblChevron = new Label();
            SuspendLayout();
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(37, 99, 235);
            lblAvatar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(14, 30);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(48, 48);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "N";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientName.AutoEllipsis = true;
            lblPatientName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            lblPatientName.Location = new Point(78, 14);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(362, 39);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Nguyễn Văn A";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientCode
            // 
            lblPatientCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientCode.AutoEllipsis = true;
            lblPatientCode.Font = new Font("Segoe UI", 8.5F);
            lblPatientCode.ForeColor = Color.FromArgb(100, 116, 139);
            lblPatientCode.Location = new Point(78, 54);
            lblPatientCode.Name = "lblPatientCode";
            lblPatientCode.Size = new Size(362, 24);
            lblPatientCode.TabIndex = 2;
            lblPatientCode.Text = "PT001";
            lblPatientCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientAgeGender
            // 
            lblPatientAgeGender.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientAgeGender.AutoEllipsis = true;
            lblPatientAgeGender.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPatientAgeGender.ForeColor = Color.FromArgb(100, 116, 139);
            lblPatientAgeGender.Location = new Point(78, 87);
            lblPatientAgeGender.Name = "lblPatientAgeGender";
            lblPatientAgeGender.Size = new Size(362, 26);
            lblPatientAgeGender.TabIndex = 3;
            lblPatientAgeGender.Text = "26 tuổi - Nam";
            lblPatientAgeGender.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblChevron
            // 
            lblChevron.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblChevron.Font = new Font("Segoe UI", 16F);
            lblChevron.ForeColor = Color.FromArgb(156, 163, 175);
            lblChevron.Location = new Point(454, 37);
            lblChevron.Name = "lblChevron";
            lblChevron.Size = new Size(28, 36);
            lblChevron.TabIndex = 4;
            lblChevron.Text = ">";
            lblChevron.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucPatientRecordRow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 250, 251);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblChevron);
            Controls.Add(lblPatientAgeGender);
            Controls.Add(lblPatientCode);
            Controls.Add(lblPatientName);
            Controls.Add(lblAvatar);
            Cursor = Cursors.Hand;
            Name = "ucPatientRecordRow";
            Size = new Size(500, 129);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientCode;
        private System.Windows.Forms.Label lblPatientAgeGender;
        private System.Windows.Forms.Label lblChevron;
    }
}
