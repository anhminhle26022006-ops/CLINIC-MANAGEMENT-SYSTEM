namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianRequestGroupCard
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
            pnlAccent = new Panel();
            lblAvatar = new Label();
            lblPatientName = new Label();
            lblMeta = new Label();
            lblDate = new Label();
            pnlServiceContainer = new Panel();
            flpServiceRows = new FlowLayoutPanel();
            pnlServiceContainer.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAccent
            // 
            pnlAccent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlAccent.BackColor = Color.FromArgb(187, 247, 208);
            pnlAccent.Location = new Point(0, 0);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(2, 217);
            pnlAccent.TabIndex = 0;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(37, 99, 235);
            lblAvatar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(26, 26);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(48, 48);
            lblAvatar.TabIndex = 1;
            lblAvatar.Text = "N";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientName.AutoEllipsis = true;
            lblPatientName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(15, 23, 42);
            lblPatientName.Location = new Point(78, 18);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(692, 34);
            lblPatientName.TabIndex = 2;
            lblPatientName.Text = "Nguyễn Văn A";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMeta
            // 
            lblMeta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMeta.AutoEllipsis = true;
            lblMeta.Font = new Font("Segoe UI", 9F);
            lblMeta.ForeColor = Color.FromArgb(100, 116, 139);
            lblMeta.Location = new Point(78, 54);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(692, 39);
            lblMeta.TabIndex = 3;
            lblMeta.Text = "Mã BN: BN001 | Bác sĩ chỉ định: BS. Nguyễn Văn Minh";
            lblMeta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Font = new Font("Segoe UI", 8.5F);
            lblDate.ForeColor = Color.FromArgb(100, 116, 139);
            lblDate.Location = new Point(780, 24);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(220, 26);
            lblDate.TabIndex = 4;
            lblDate.Text = "06/06/2026 05:00";
            lblDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlServiceContainer
            // 
            pnlServiceContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlServiceContainer.BackColor = Color.FromArgb(249, 250, 251);
            pnlServiceContainer.Controls.Add(flpServiceRows);
            pnlServiceContainer.Location = new Point(22, 96);
            pnlServiceContainer.Name = "pnlServiceContainer";
            pnlServiceContainer.Size = new Size(982, 78);
            pnlServiceContainer.TabIndex = 5;
            // 
            // flpServiceRows
            // 
            flpServiceRows.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flpServiceRows.BackColor = Color.Transparent;
            flpServiceRows.FlowDirection = FlowDirection.TopDown;
            flpServiceRows.Location = new Point(0, 0);
            flpServiceRows.Margin = new Padding(0);
            flpServiceRows.Name = "flpServiceRows";
            flpServiceRows.Size = new Size(982, 78);
            flpServiceRows.TabIndex = 0;
            flpServiceRows.WrapContents = false;
            // 
            // ucTechnicianRequestGroupCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            Controls.Add(pnlServiceContainer);
            Controls.Add(lblDate);
            Controls.Add(lblMeta);
            Controls.Add(lblPatientName);
            Controls.Add(lblAvatar);
            Controls.Add(pnlAccent);
            Name = "ucTechnicianRequestGroupCard";
            Size = new Size(1026, 217);
            Resize += ucTechnicianRequestGroupCard_Resize;
            pnlServiceContainer.ResumeLayout(false);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlAccent;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnlServiceContainer;
        private System.Windows.Forms.FlowLayoutPanel flpServiceRows;
    }
}
