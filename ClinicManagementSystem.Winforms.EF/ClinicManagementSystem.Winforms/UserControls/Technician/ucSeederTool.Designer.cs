namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucSeederTool
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
            viewHostPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            pnlContainer = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            txtSeederLog = new TextBox();
            lblLogTitle = new Label();
            btnSyncApi = new Button();
            btnTestPayOS = new Button();
            btnRunSeed = new Button();
            lblDescription = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            viewHostPanel.SuspendLayout();
            pnlContainer.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlContainer);
            viewHostPanel.Controls.Add(lblSubtitle);
            viewHostPanel.Controls.Add(lblTitle);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(3, 4, 3, 4);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1422, 992);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlContainer
            // 
            pnlContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlContainer.BackColor = Color.White;
            pnlContainer.BorderColor = Color.FromArgb(229, 231, 235);
            pnlContainer.BorderWidth = 1;
            pnlContainer.Controls.Add(txtSeederLog);
            pnlContainer.Controls.Add(lblLogTitle);
            pnlContainer.Controls.Add(btnSyncApi);
            pnlContainer.Controls.Add(btnTestPayOS);
            pnlContainer.Controls.Add(btnRunSeed);
            pnlContainer.Controls.Add(lblDescription);
            pnlContainer.CornerRadius = 8;
            pnlContainer.FillColor = Color.White;
            pnlContainer.Location = new Point(27, 128);
            pnlContainer.Margin = new Padding(3, 4, 3, 4);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1367, 827);
            pnlContainer.TabIndex = 2;
            // 
            // txtSeederLog
            // 
            txtSeederLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSeederLog.BackColor = Color.FromArgb(17, 24, 39);
            txtSeederLog.BorderStyle = BorderStyle.FixedSingle;
            txtSeederLog.Font = new Font("Consolas", 10F);
            txtSeederLog.ForeColor = Color.FromArgb(34, 197, 94);
            txtSeederLog.Location = new Point(27, 291);
            txtSeederLog.Margin = new Padding(3, 4, 3, 4);
            txtSeederLog.Multiline = true;
            txtSeederLog.Name = "txtSeederLog";
            txtSeederLog.ReadOnly = true;
            txtSeederLog.ScrollBars = ScrollBars.Vertical;
            txtSeederLog.Size = new Size(1298, 503);
            txtSeederLog.TabIndex = 5;
            // 
            // lblLogTitle
            // 
            lblLogTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblLogTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblLogTitle.Location = new Point(27, 253);
            lblLogTitle.Name = "lblLogTitle";
            lblLogTitle.Size = new Size(343, 29);
            lblLogTitle.TabIndex = 4;
            lblLogTitle.Text = "Log bảng điều khiển Seeder:";
            // 
            // btnSyncApi
            // 
            btnSyncApi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSyncApi.BackColor = Color.FromArgb(16, 185, 129);
            btnSyncApi.Cursor = Cursors.Hand;
            btnSyncApi.FlatAppearance.BorderSize = 0;
            btnSyncApi.FlatStyle = FlatStyle.Flat;
            btnSyncApi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSyncApi.ForeColor = Color.White;
            btnSyncApi.Location = new Point(27, 165);
            btnSyncApi.Margin = new Padding(3, 4, 3, 4);
            btnSyncApi.Name = "btnSyncApi";
            btnSyncApi.Size = new Size(1298, 64);
            btnSyncApi.TabIndex = 3;
            btnSyncApi.Text = "ĐỒNG BỘ API SHEETDB / SUPABASE";
            btnSyncApi.UseVisualStyleBackColor = false;
            btnSyncApi.Click += btnSyncApi_Click;
            // 
            // btnTestPayOS
            // 
            btnTestPayOS.BackColor = Color.FromArgb(59, 130, 246);
            btnTestPayOS.Cursor = Cursors.Hand;
            btnTestPayOS.FlatAppearance.BorderSize = 0;
            btnTestPayOS.FlatStyle = FlatStyle.Flat;
            btnTestPayOS.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTestPayOS.ForeColor = Color.White;
            btnTestPayOS.Location = new Point(686, 80);
            btnTestPayOS.Margin = new Padding(3, 4, 3, 4);
            btnTestPayOS.Name = "btnTestPayOS";
            btnTestPayOS.Size = new Size(639, 64);
            btnTestPayOS.TabIndex = 2;
            btnTestPayOS.Text = "KIỂM TRA CỔNG THANH TOÁN (PAYOS)";
            btnTestPayOS.UseVisualStyleBackColor = false;
            // 
            // btnRunSeed
            // 
            btnRunSeed.BackColor = Color.FromArgb(239, 68, 68);
            btnRunSeed.Cursor = Cursors.Hand;
            btnRunSeed.FlatAppearance.BorderSize = 0;
            btnRunSeed.FlatStyle = FlatStyle.Flat;
            btnRunSeed.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRunSeed.ForeColor = Color.White;
            btnRunSeed.Location = new Point(27, 80);
            btnRunSeed.Margin = new Padding(3, 4, 3, 4);
            btnRunSeed.Name = "btnRunSeed";
            btnRunSeed.Size = new Size(640, 64);
            btnRunSeed.TabIndex = 1;
            btnRunSeed.Text = "KHỞI TẠO LẠI DỮ LIỆU MẪU (SEED DATABASE)";
            btnRunSeed.UseVisualStyleBackColor = false;
            // 
            // lblDescription
            // 
            lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescription.Font = new Font("Segoe UI", 10F);
            lblDescription.ForeColor = Color.FromArgb(17, 24, 39);
            lblDescription.Location = new Point(27, 32);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(1312, 32);
            lblDescription.TabIndex = 0;
            lblDescription.Text = "Bấm nút bên dưới để dọn sạch bảng và tạo dữ liệu mẫu bệnh nhân, bác sĩ, lịch trực & yêu cầu mới:";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(27, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(1029, 37);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Hệ thống mock dữ liệu mẫu giúp chạy demo nhanh cho đồ án 3 lớp";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(27, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(869, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Công cụ Khởi tạo Cơ sở dữ liệu";
            // 
            // ucSeederTool
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucSeederTool";
            Size = new Size(1422, 992);
            Load += ucSeederTool_Load;
            Resize += ucSeederTool_Resize;
            viewHostPanel.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlContainer.PerformLayout();
            ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlContainer;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnRunSeed;
        private System.Windows.Forms.Button btnTestPayOS;
        private System.Windows.Forms.Button btnSyncApi;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.TextBox txtSeederLog;
    }
}
