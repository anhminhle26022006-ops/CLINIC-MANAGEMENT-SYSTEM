using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucPharmacyPrescriptionQueueCard
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
            rootPanel = new RoundedPanel();
            lblTime = new Label();
            lblItemCount = new Label();
            lblPrescriptionCode = new Label();
            lblDoctor = new Label();
            lblPatientName = new Label();
            lblStatus = new Label();
            pnlAccent = new Panel();
            rootPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.BorderColor = Color.FromArgb(229, 231, 235);
            rootPanel.BorderWidth = 1;
            rootPanel.Controls.Add(lblTime);
            rootPanel.Controls.Add(lblItemCount);
            rootPanel.Controls.Add(lblPrescriptionCode);
            rootPanel.Controls.Add(lblDoctor);
            rootPanel.Controls.Add(lblPatientName);
            rootPanel.Controls.Add(lblStatus);
            rootPanel.Controls.Add(pnlAccent);
            rootPanel.CornerRadius = 8;
            rootPanel.Cursor = Cursors.Hand;
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.FillColor = Color.White;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Margin = new Padding(0);
            rootPanel.Name = "rootPanel";
            rootPanel.Size = new Size(360, 104);
            rootPanel.TabIndex = 0;
            rootPanel.Click += Card_Click;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.Cursor = Cursors.Hand;
            lblTime.Font = new Font("Segoe UI", 9F);
            lblTime.ForeColor = Color.FromArgb(100, 116, 139);
            lblTime.Location = new Point(240, 69);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(82, 35);
            lblTime.TabIndex = 6;
            lblTime.Text = "11:30";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            lblTime.Click += Card_Click;
            // 
            // lblItemCount
            // 
            lblItemCount.Cursor = Cursors.Hand;
            lblItemCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemCount.ForeColor = Color.FromArgb(47, 94, 240);
            lblItemCount.Location = new Point(146, 69);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(86, 35);
            lblItemCount.TabIndex = 5;
            lblItemCount.Text = "2 thuốc";
            lblItemCount.TextAlign = ContentAlignment.MiddleLeft;
            lblItemCount.Click += Card_Click;
            // 
            // lblPrescriptionCode
            // 
            lblPrescriptionCode.Cursor = Cursors.Hand;
            lblPrescriptionCode.Font = new Font("Segoe UI", 9F);
            lblPrescriptionCode.ForeColor = Color.FromArgb(100, 116, 139);
            lblPrescriptionCode.Location = new Point(18, 69);
            lblPrescriptionCode.Name = "lblPrescriptionCode";
            lblPrescriptionCode.Size = new Size(116, 35);
            lblPrescriptionCode.TabIndex = 4;
            lblPrescriptionCode.Text = "Mã toa: #2";
            lblPrescriptionCode.TextAlign = ContentAlignment.MiddleLeft;
            lblPrescriptionCode.Click += Card_Click;
            // 
            // lblDoctor
            // 
            lblDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDoctor.AutoEllipsis = true;
            lblDoctor.Cursor = Cursors.Hand;
            lblDoctor.Font = new Font("Segoe UI", 9F);
            lblDoctor.ForeColor = Color.FromArgb(100, 116, 139);
            lblDoctor.Location = new Point(20, 42);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(305, 26);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "BS: BS Trần Minh";
            lblDoctor.TextAlign = ContentAlignment.MiddleLeft;
            lblDoctor.Click += Card_Click;
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientName.AutoEllipsis = true;
            lblPatientName.Cursor = Cursors.Hand;
            lblPatientName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientName.Location = new Point(20, 4);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(178, 34);
            lblPatientName.TabIndex = 2;
            lblPatientName.Text = "Nguyễn Văn A";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            lblPatientName.Click += Card_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.BackColor = Color.FromArgb(254, 249, 195);
            lblStatus.Cursor = Cursors.Hand;
            lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
            lblStatus.Location = new Point(206, 10);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(116, 28);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Chờ cấp phát";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Click += Card_Click;
            // 
            // pnlAccent
            // 
            pnlAccent.BackColor = Color.FromArgb(245, 158, 11);
            pnlAccent.Dock = DockStyle.Left;
            pnlAccent.Location = new Point(0, 0);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(4, 104);
            pnlAccent.TabIndex = 0;
            pnlAccent.Click += Card_Click;
            // 
            // ucPharmacyPrescriptionQueueCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(rootPanel);
            Margin = new Padding(0, 0, 0, 12);
            Name = "ucPharmacyPrescriptionQueueCard";
            Size = new Size(360, 104);
            Resize += ucPharmacyPrescriptionQueueCard_Resize;
            rootPanel.ResumeLayout(false);
            ResumeLayout(false);
            ApplyQueueCardBackColors(Color.White);
        }

        private void ucPharmacyPrescriptionQueueCard_Resize(object sender, System.EventArgs e)
        {
            AdjustQueueCardLayout();
        }

        private void AdjustQueueCardLayout()
        {
            int width = rootPanel.ClientSize.Width;
            if (width <= 0)
            {
                return;
            }

            lblStatus.Left = System.Math.Max(190, width - 132);
            lblPatientName.Width = System.Math.Max(120, lblStatus.Left - lblPatientName.Left - 12);
            lblDoctor.Width = System.Math.Max(180, width - lblDoctor.Left - 16);
            lblTime.Left = System.Math.Max(230, width - lblTime.Width - 16);
            lblItemCount.Left = System.Math.Min(lblItemCount.Left, lblTime.Left - lblItemCount.Width - 12);
            lblPrescriptionCode.Width = System.Math.Max(90, lblItemCount.Left - lblPrescriptionCode.Left - 8);
        }

        private void ApplyQueueCardBackColors(Color cardBack)
        {
            lblPatientName.BackColor = cardBack;
            lblDoctor.BackColor = cardBack;
            lblPrescriptionCode.BackColor = cardBack;
            lblItemCount.BackColor = cardBack;
            lblTime.BackColor = cardBack;
        }

        private void SetStatus(string status)
        {
            string normalized = string.IsNullOrWhiteSpace(status) ? "Chờ cấp phát" : status;
            bool waiting = normalized == "Chờ cấp phát" || normalized == "Pending";
            bool completed = normalized == "Đã cấp phát" || normalized == "Completed" || normalized == "Dispensed";

            if (completed)
            {
                lblStatus.Text = "Đã cấp phát";
                lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                pnlAccent.BackColor = Color.FromArgb(34, 197, 94);
                return;
            }

            if (waiting)
            {
                lblStatus.Text = "Chờ cấp phát";
                lblStatus.BackColor = Color.FromArgb(254, 249, 195);
                lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
                pnlAccent.BackColor = Color.FromArgb(245, 158, 11);
                return;
            }

            lblStatus.Text = "Đang chuẩn bị";
            lblStatus.BackColor = Color.FromArgb(219, 234, 254);
            lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
            pnlAccent.BackColor = Color.FromArgb(47, 94, 240);
        }

        private void ApplySelectedState(bool selected)
        {
            rootPanel.BorderColor = selected ? Color.FromArgb(47, 94, 240) : Color.FromArgb(229, 231, 235);
            rootPanel.BorderWidth = selected ? 2 : 1;
            rootPanel.FillColor = selected ? Color.FromArgb(248, 251, 255) : Color.White;
            ApplyQueueCardBackColors(selected ? Color.FromArgb(248, 251, 255) : Color.White);
            rootPanel.Invalidate();
        }

        private RoundedPanel rootPanel;
        private Panel pnlAccent;
        private Label lblStatus;
        private Label lblPatientName;
        private Label lblDoctor;
        private Label lblPrescriptionCode;
        private Label lblItemCount;
        private Label lblTime;
    }
}
