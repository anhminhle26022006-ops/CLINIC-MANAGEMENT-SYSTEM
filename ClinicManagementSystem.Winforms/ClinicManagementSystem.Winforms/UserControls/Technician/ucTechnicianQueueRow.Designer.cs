namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianQueueRow
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
            lblPatientName = new Label();
            lblServiceType = new Label();
            lblDoctor = new Label();
            lblBadge = new Label();
            SuspendLayout();
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientName.AutoEllipsis = true;
            lblPatientName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            lblPatientName.Location = new Point(18, 12);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(518, 40);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Hoàng Văn E";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblServiceType
            // 
            lblServiceType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblServiceType.AutoEllipsis = true;
            lblServiceType.Font = new Font("Segoe UI", 9F);
            lblServiceType.ForeColor = Color.FromArgb(100, 116, 139);
            lblServiceType.Location = new Point(18, 52);
            lblServiceType.Name = "lblServiceType";
            lblServiceType.Size = new Size(390, 41);
            lblServiceType.TabIndex = 1;
            lblServiceType.Text = "Chụp MRI cột sống";
            lblServiceType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoctor
            // 
            lblDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDoctor.AutoEllipsis = true;
            lblDoctor.Font = new Font("Segoe UI", 8.5F);
            lblDoctor.ForeColor = Color.FromArgb(100, 116, 139);
            lblDoctor.Location = new Point(18, 93);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(518, 28);
            lblDoctor.TabIndex = 2;
            lblDoctor.Text = "BS: BS. Trần B";
            lblDoctor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBadge
            // 
            lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBadge.BackColor = Color.FromArgb(254, 249, 195);
            lblBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblBadge.ForeColor = Color.FromArgb(161, 98, 7);
            lblBadge.Location = new Point(418, 40);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(120, 34);
            lblBadge.TabIndex = 3;
            lblBadge.Text = "Chờ chụp";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucTechnicianQueueRow
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 250, 251);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblBadge);
            Controls.Add(lblDoctor);
            Controls.Add(lblServiceType);
            Controls.Add(lblPatientName);
            Name = "ucTechnicianQueueRow";
            Size = new Size(560, 130);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.Label lblBadge;
    }
}
