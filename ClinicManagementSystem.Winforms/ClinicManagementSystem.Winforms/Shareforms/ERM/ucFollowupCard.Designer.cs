using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucFollowupCard
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblDateTitle;
        private Label lblDate;

        private Label lblDoctorTitle;
        private Label lblDoctor;

        private Label lblContentTitle;
        private Label lblContent;
        private Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblDateTitle = new Label();
            lblDate = new Label();
            lblDoctorTitle = new Label();
            lblDoctor = new Label();
            lblContentTitle = new Label();
            lblContent = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDateTitle.Location = new Point(20, 20);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(133, 23);
            lblDateTitle.TabIndex = 0;
            lblDateTitle.Text = "Ngày tái khám:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 10F);
            lblDate.Location = new Point(160, 20);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(96, 23);
            lblDate.TabIndex = 1;
            lblDate.Text = "20/05/2026";
            // 
            // lblDoctorTitle
            // 
            lblDoctorTitle.AutoSize = true;
            lblDoctorTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoctorTitle.Location = new Point(20, 55);
            lblDoctorTitle.Name = "lblDoctorTitle";
            lblDoctorTitle.Size = new Size(60, 23);
            lblDoctorTitle.TabIndex = 2;
            lblDoctorTitle.Text = "Bác sĩ:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI", 10F);
            lblDoctor.Location = new Point(160, 55);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(111, 23);
            lblDoctor.TabIndex = 3;
            lblDoctor.Text = "BS Trần Minh";
            // 
            // lblContentTitle
            // 
            lblContentTitle.AutoSize = true;
            lblContentTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContentTitle.Location = new Point(20, 90);
            lblContentTitle.Name = "lblContentTitle";
            lblContentTitle.Size = new Size(90, 23);
            lblContentTitle.TabIndex = 4;
            lblContentTitle.Text = "Nội dung:";
            // 
            // lblContent
            // 
            lblContent.Font = new Font("Segoe UI", 10F);
            lblContent.Location = new Point(160, 90);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(1333, 50);
            lblContent.TabIndex = 5;
            lblContent.Text = "Tái khám đánh giá đáp ứng điều trị sau 7 ngày.";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.Orange;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.White;
            lblStatus.Location = new Point(1373, 25);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(120, 35);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Sắp tới";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucFollowupCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblDateTitle);
            Controls.Add(lblDate);
            Controls.Add(lblDoctorTitle);
            Controls.Add(lblDoctor);
            Controls.Add(lblContentTitle);
            Controls.Add(lblContent);
            Controls.Add(lblStatus);
            Name = "ucFollowupCard";
            Size = new Size(1520, 171);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}