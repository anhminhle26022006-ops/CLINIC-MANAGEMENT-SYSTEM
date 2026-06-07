namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucPatientHistoryResultCard
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
            lblServiceType = new Label();
            lblMeta = new Label();
            lblResult = new Label();
            lblConclusion = new Label();
            btnOpenFile = new Button();
            SuspendLayout();
            // 
            // lblServiceType
            // 
            lblServiceType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblServiceType.AutoEllipsis = true;
            lblServiceType.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblServiceType.ForeColor = Color.FromArgb(15, 23, 42);
            lblServiceType.Location = new Point(18, 12);
            lblServiceType.Name = "lblServiceType";
            lblServiceType.Size = new Size(814, 30);
            lblServiceType.TabIndex = 0;
            lblServiceType.Text = "Xét nghiệm máu tổng quát";
            lblServiceType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMeta
            // 
            lblMeta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMeta.AutoEllipsis = true;
            lblMeta.Font = new Font("Segoe UI", 8.5F);
            lblMeta.ForeColor = Color.FromArgb(100, 116, 139);
            lblMeta.Location = new Point(18, 44);
            lblMeta.Name = "lblMeta";
            lblMeta.Size = new Size(814, 28);
            lblMeta.TabIndex = 1;
            lblMeta.Text = "Bác sĩ chỉ định: BS. Nguyễn Văn Minh | Ngày: 06/06/2026 05:00";
            lblMeta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblResult
            // 
            lblResult.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblResult.AutoEllipsis = true;
            lblResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblResult.ForeColor = Color.FromArgb(22, 101, 52);
            lblResult.Location = new Point(18, 76);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(814, 38);
            lblResult.TabIndex = 2;
            lblResult.Text = "Kết quả: Báo cáo xét nghiệm PDF tổng hợp.";
            lblResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblConclusion
            // 
            lblConclusion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblConclusion.AutoEllipsis = true;
            lblConclusion.Font = new Font("Segoe UI", 9F);
            lblConclusion.ForeColor = Color.FromArgb(15, 23, 42);
            lblConclusion.Location = new Point(18, 114);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(814, 30);
            lblConclusion.TabIndex = 3;
            lblConclusion.Text = "Kết luận: Không có ghi chú";
            lblConclusion.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOpenFile
            // 
            btnOpenFile.BackColor = Color.FromArgb(37, 99, 235);
            btnOpenFile.Cursor = Cursors.Hand;
            btnOpenFile.FlatAppearance.BorderSize = 0;
            btnOpenFile.FlatStyle = FlatStyle.Flat;
            btnOpenFile.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnOpenFile.ForeColor = Color.White;
            btnOpenFile.Location = new Point(18, 156);
            btnOpenFile.Name = "btnOpenFile";
            btnOpenFile.Size = new Size(160, 38);
            btnOpenFile.TabIndex = 4;
            btnOpenFile.Text = "Mở file PDF";
            btnOpenFile.UseVisualStyleBackColor = false;
            btnOpenFile.Click += btnOpenFile_Click;
            // 
            // ucPatientHistoryResultCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(249, 250, 251);
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(btnOpenFile);
            Controls.Add(lblConclusion);
            Controls.Add(lblResult);
            Controls.Add(lblMeta);
            Controls.Add(lblServiceType);
            Name = "ucPatientHistoryResultCard";
            Size = new Size(850, 217);
            ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.Label lblMeta;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblConclusion;
        private System.Windows.Forms.Button btnOpenFile;
    }
}
