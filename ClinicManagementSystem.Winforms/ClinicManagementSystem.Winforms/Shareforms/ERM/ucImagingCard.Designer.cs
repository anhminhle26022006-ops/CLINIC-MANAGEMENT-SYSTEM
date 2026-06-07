namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucImagingCard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDate;

        private System.Windows.Forms.Label lblDoctorTitle;
        private System.Windows.Forms.Label lblDoctor;

        private System.Windows.Forms.Label lblConclusionTitle;
        private System.Windows.Forms.Label lblConclusion;

        private System.Windows.Forms.PictureBox picPreview;

        private System.Windows.Forms.Button btnViewImage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDateTitle = new Label();
            lblDate = new Label();
            lblDoctorTitle = new Label();
            lblDoctor = new Label();
            lblConclusionTitle = new Label();
            lblConclusion = new Label();
            picPreview = new PictureBox();
            btnViewImage = new Button();
            ((System.ComponentModel.ISupportInitialize)picPreview).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(106, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "MRI Brain";
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateTitle.Location = new Point(15, 60);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(50, 20);
            lblDateTitle.TabIndex = 1;
            lblDateTitle.Text = "Ngày:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(80, 60);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "07/06/2026";
            // 
            // lblDoctorTitle
            // 
            lblDoctorTitle.AutoSize = true;
            lblDoctorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDoctorTitle.Location = new Point(250, 60);
            lblDoctorTitle.Name = "lblDoctorTitle";
            lblDoctorTitle.Size = new Size(31, 20);
            lblDoctorTitle.TabIndex = 3;
            lblDoctorTitle.Text = "BS:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(300, 60);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(95, 20);
            lblDoctor.TabIndex = 4;
            lblDoctor.Text = "BS Trần Minh";
            // 
            // lblConclusionTitle
            // 
            lblConclusionTitle.AutoSize = true;
            lblConclusionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConclusionTitle.Location = new Point(15, 100);
            lblConclusionTitle.Name = "lblConclusionTitle";
            lblConclusionTitle.Size = new Size(71, 20);
            lblConclusionTitle.TabIndex = 5;
            lblConclusionTitle.Text = "Kết luận:";
            // 
            // lblConclusion
            // 
            lblConclusion.Location = new Point(15, 125);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(700, 50);
            lblConclusion.TabIndex = 6;
            lblConclusion.Text = "Không phát hiện bất thường nội sọ.";
            // 
            // picPreview
            // 
            picPreview.BackColor = Color.Gainsboro;
            picPreview.BorderStyle = BorderStyle.FixedSingle;
            picPreview.Location = new Point(3, 190);
            picPreview.Name = "picPreview";
            picPreview.Size = new Size(1525, 203);
            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
            picPreview.TabIndex = 7;
            picPreview.TabStop = false;
            // 
            // btnViewImage
            // 
            btnViewImage.BackColor = Color.RoyalBlue;
            btnViewImage.ForeColor = Color.White;
            btnViewImage.Location = new Point(1398, 135);
            btnViewImage.Name = "btnViewImage";
            btnViewImage.Size = new Size(120, 40);
            btnViewImage.TabIndex = 8;
            btnViewImage.Text = "Xem ảnh";
            btnViewImage.UseVisualStyleBackColor = false;
            // 
            // ucImagingCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblTitle);
            Controls.Add(lblDateTitle);
            Controls.Add(lblDate);
            Controls.Add(lblDoctorTitle);
            Controls.Add(lblDoctor);
            Controls.Add(lblConclusionTitle);
            Controls.Add(lblConclusion);
            Controls.Add(picPreview);
            Controls.Add(btnViewImage);
            Name = "ucImagingCard";
            Size = new Size(1531, 396);
            ((System.ComponentModel.ISupportInitialize)picPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}