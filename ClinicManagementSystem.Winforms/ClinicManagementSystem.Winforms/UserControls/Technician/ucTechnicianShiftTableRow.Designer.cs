namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianShiftTableRow
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblShift = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoEllipsis = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDate.Location = new System.Drawing.Point(18, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(150, 52);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "04/06/2026";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblShift
            // 
            this.lblShift.AutoEllipsis = true;
            this.lblShift.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblShift.Location = new System.Drawing.Point(180, 0);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(90, 52);
            this.lblShift.TabIndex = 1;
            this.lblShift.Text = "Chiều";
            this.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoEllipsis = true;
            this.lblDepartment.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblDepartment.Location = new System.Drawing.Point(290, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(190, 52);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Xét nghiệm";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRoom
            // 
            this.lblRoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoom.AutoEllipsis = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblRoom.Location = new System.Drawing.Point(510, 0);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(322, 52);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "-";
            this.lblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblStatus.Location = new System.Drawing.Point(850, 11);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(138, 30);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Approved";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucTechnicianShiftTableRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRoom);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.lblDate);
            this.Name = "ucTechnicianShiftTableRow";
            this.Size = new System.Drawing.Size(1008, 52);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblStatus;
    }
}
