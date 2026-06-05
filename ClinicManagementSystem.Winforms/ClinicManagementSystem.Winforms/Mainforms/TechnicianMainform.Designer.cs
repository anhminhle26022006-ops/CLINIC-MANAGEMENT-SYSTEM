namespace ClinicManagementSystem.Winforms.UserControls
{
    partial class TechnicianMainform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnNavSeederTool = new Button();
            btnNavShifts = new Button();
            btnNavRecords = new Button();
            btnNavLabResult = new Button();
            btnNavUploadPDF = new Button();
            btnNavUploadMRI = new Button();
            btnNavRequests = new Button();
            btnNavOverview = new Button();
            lblBrandSub = new Label();
            lblBrand = new Label();
            lblLogo = new Label();
            btnClose = new Button();
            panelTopbar = new Panel();
            lblAvatar = new Label();
            lblUserEmail = new Label();
            lblUserName = new Label();
            lblNotifDot = new Label();
            lblBell = new Label();
            txtGlobalSearch = new TextBox();
            lblPageSubtitle = new Label();
            lblPageTitle = new Label();
            contentPanel = new Panel();
            panelSidebar.SuspendLayout();
            panelTopbar.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.White;
            panelSidebar.BorderStyle = BorderStyle.FixedSingle;
            panelSidebar.Controls.Add(btnLogout);
            panelSidebar.Controls.Add(btnNavSeederTool);
            panelSidebar.Controls.Add(btnNavShifts);
            panelSidebar.Controls.Add(btnNavRecords);
            panelSidebar.Controls.Add(btnNavLabResult);
            panelSidebar.Controls.Add(btnNavUploadPDF);
            panelSidebar.Controls.Add(btnNavUploadMRI);
            panelSidebar.Controls.Add(btnNavRequests);
            panelSidebar.Controls.Add(btnNavOverview);
            panelSidebar.Controls.Add(lblBrandSub);
            panelSidebar.Controls.Add(lblBrand);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Controls.Add(btnClose);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(274, 1093);
            panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.White;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(220, 38, 38);
            btnLogout.Location = new Point(14, 1012);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(245, 56);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNavSeederTool
            // 
            btnNavSeederTool.BackColor = Color.White;
            btnNavSeederTool.Cursor = Cursors.Hand;
            btnNavSeederTool.FlatAppearance.BorderSize = 0;
            btnNavSeederTool.FlatStyle = FlatStyle.Flat;
            btnNavSeederTool.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavSeederTool.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavSeederTool.Location = new Point(14, 533);
            btnNavSeederTool.Margin = new Padding(3, 4, 3, 4);
            btnNavSeederTool.Name = "btnNavSeederTool";
            btnNavSeederTool.Padding = new Padding(18, 0, 0, 0);
            btnNavSeederTool.Size = new Size(245, 59);
            btnNavSeederTool.TabIndex = 11;
            btnNavSeederTool.Text = "Seeder Tool (Test)";
            btnNavSeederTool.TextAlign = ContentAlignment.MiddleLeft;
            btnNavSeederTool.UseVisualStyleBackColor = false;
            btnNavSeederTool.Click += btnNavSeederTool_Click;
            // 
            // btnNavShifts
            // 
            btnNavShifts.BackColor = Color.White;
            btnNavShifts.Cursor = Cursors.Hand;
            btnNavShifts.FlatAppearance.BorderSize = 0;
            btnNavShifts.FlatStyle = FlatStyle.Flat;
            btnNavShifts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavShifts.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavShifts.Location = new Point(14, 472);
            btnNavShifts.Margin = new Padding(3, 4, 3, 4);
            btnNavShifts.Name = "btnNavShifts";
            btnNavShifts.Padding = new Padding(18, 0, 0, 0);
            btnNavShifts.Size = new Size(245, 59);
            btnNavShifts.TabIndex = 10;
            btnNavShifts.Text = "Ca làm việc";
            btnNavShifts.TextAlign = ContentAlignment.MiddleLeft;
            btnNavShifts.UseVisualStyleBackColor = false;
            btnNavShifts.Click += btnNavShifts_Click;
            // 
            // btnNavRecords
            // 
            btnNavRecords.BackColor = Color.White;
            btnNavRecords.Cursor = Cursors.Hand;
            btnNavRecords.FlatAppearance.BorderSize = 0;
            btnNavRecords.FlatStyle = FlatStyle.Flat;
            btnNavRecords.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavRecords.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavRecords.Location = new Point(14, 411);
            btnNavRecords.Margin = new Padding(3, 4, 3, 4);
            btnNavRecords.Name = "btnNavRecords";
            btnNavRecords.Padding = new Padding(18, 0, 0, 0);
            btnNavRecords.Size = new Size(245, 59);
            btnNavRecords.TabIndex = 9;
            btnNavRecords.Text = "Hồ sơ bệnh án";
            btnNavRecords.TextAlign = ContentAlignment.MiddleLeft;
            btnNavRecords.UseVisualStyleBackColor = false;
            btnNavRecords.Click += btnNavRecords_Click;
            // 
            // btnNavLabResult
            // 
            btnNavLabResult.BackColor = Color.White;
            btnNavLabResult.Cursor = Cursors.Hand;
            btnNavLabResult.FlatAppearance.BorderSize = 0;
            btnNavLabResult.FlatStyle = FlatStyle.Flat;
            btnNavLabResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavLabResult.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavLabResult.Location = new Point(14, 349);
            btnNavLabResult.Margin = new Padding(3, 4, 3, 4);
            btnNavLabResult.Name = "btnNavLabResult";
            btnNavLabResult.Padding = new Padding(18, 0, 0, 0);
            btnNavLabResult.Size = new Size(245, 59);
            btnNavLabResult.TabIndex = 8;
            btnNavLabResult.Text = "Nhập kết quả Lab";
            btnNavLabResult.TextAlign = ContentAlignment.MiddleLeft;
            btnNavLabResult.UseVisualStyleBackColor = false;
            btnNavLabResult.Click += btnNavLabResult_Click;
            // 
            // btnNavUploadPDF
            // 
            btnNavUploadPDF.BackColor = Color.White;
            btnNavUploadPDF.Cursor = Cursors.Hand;
            btnNavUploadPDF.FlatAppearance.BorderSize = 0;
            btnNavUploadPDF.FlatStyle = FlatStyle.Flat;
            btnNavUploadPDF.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavUploadPDF.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavUploadPDF.Location = new Point(14, 288);
            btnNavUploadPDF.Margin = new Padding(3, 4, 3, 4);
            btnNavUploadPDF.Name = "btnNavUploadPDF";
            btnNavUploadPDF.Padding = new Padding(18, 0, 0, 0);
            btnNavUploadPDF.Size = new Size(245, 59);
            btnNavUploadPDF.TabIndex = 7;
            btnNavUploadPDF.Text = "Tải lên PDF";
            btnNavUploadPDF.TextAlign = ContentAlignment.MiddleLeft;
            btnNavUploadPDF.UseVisualStyleBackColor = false;
            btnNavUploadPDF.Click += btnNavUploadPDF_Click;
            // 
            // btnNavUploadMRI
            // 
            btnNavUploadMRI.BackColor = Color.White;
            btnNavUploadMRI.Cursor = Cursors.Hand;
            btnNavUploadMRI.FlatAppearance.BorderSize = 0;
            btnNavUploadMRI.FlatStyle = FlatStyle.Flat;
            btnNavUploadMRI.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavUploadMRI.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavUploadMRI.Location = new Point(14, 227);
            btnNavUploadMRI.Margin = new Padding(3, 4, 3, 4);
            btnNavUploadMRI.Name = "btnNavUploadMRI";
            btnNavUploadMRI.Padding = new Padding(18, 0, 0, 0);
            btnNavUploadMRI.Size = new Size(245, 59);
            btnNavUploadMRI.TabIndex = 6;
            btnNavUploadMRI.Text = "Tải lên MRI/X-Ray";
            btnNavUploadMRI.TextAlign = ContentAlignment.MiddleLeft;
            btnNavUploadMRI.UseVisualStyleBackColor = false;
            btnNavUploadMRI.Click += btnNavUploadMRI_Click;
            // 
            // btnNavRequests
            // 
            btnNavRequests.BackColor = Color.White;
            btnNavRequests.Cursor = Cursors.Hand;
            btnNavRequests.FlatAppearance.BorderSize = 0;
            btnNavRequests.FlatStyle = FlatStyle.Flat;
            btnNavRequests.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavRequests.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavRequests.Location = new Point(14, 165);
            btnNavRequests.Margin = new Padding(3, 4, 3, 4);
            btnNavRequests.Name = "btnNavRequests";
            btnNavRequests.Padding = new Padding(18, 0, 0, 0);
            btnNavRequests.Size = new Size(245, 59);
            btnNavRequests.TabIndex = 5;
            btnNavRequests.Text = "Xét nghiệm";
            btnNavRequests.TextAlign = ContentAlignment.MiddleLeft;
            btnNavRequests.UseVisualStyleBackColor = false;
            btnNavRequests.Click += btnNavRequests_Click;
            // 
            // btnNavOverview
            // 
            btnNavOverview.BackColor = Color.FromArgb(239, 246, 255);
            btnNavOverview.Cursor = Cursors.Hand;
            btnNavOverview.FlatAppearance.BorderSize = 0;
            btnNavOverview.FlatStyle = FlatStyle.Flat;
            btnNavOverview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavOverview.ForeColor = Color.FromArgb(47, 94, 240);
            btnNavOverview.Location = new Point(14, 104);
            btnNavOverview.Margin = new Padding(3, 4, 3, 4);
            btnNavOverview.Name = "btnNavOverview";
            btnNavOverview.Padding = new Padding(18, 0, 0, 0);
            btnNavOverview.Size = new Size(245, 59);
            btnNavOverview.TabIndex = 4;
            btnNavOverview.Text = "Tổng quan";
            btnNavOverview.TextAlign = ContentAlignment.MiddleLeft;
            btnNavOverview.UseVisualStyleBackColor = false;
            btnNavOverview.Click += btnNavOverview_Click;
            // 
            // lblBrandSub
            // 
            lblBrandSub.AutoSize = true;
            lblBrandSub.Font = new Font("Segoe UI", 8.5F);
            lblBrandSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblBrandSub.Location = new Point(83, 60);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(91, 20);
            lblBrandSub.TabIndex = 3;
            lblBrandSub.Text = "Phòng khám";
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(17, 24, 39);
            lblBrand.Location = new Point(82, 24);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(164, 35);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "HealthCare+";
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.FromArgb(47, 94, 240);
            lblLogo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(25, 27);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(43, 51);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "H+";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 13F);
            btnClose.Location = new Point(229, 57);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 43);
            btnClose.TabIndex = 0;
            btnClose.Text = "x";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // panelTopbar
            // 
            panelTopbar.BackColor = Color.White;
            panelTopbar.BorderStyle = BorderStyle.FixedSingle;
            panelTopbar.Controls.Add(lblAvatar);
            panelTopbar.Controls.Add(lblUserEmail);
            panelTopbar.Controls.Add(lblUserName);
            panelTopbar.Controls.Add(lblNotifDot);
            panelTopbar.Controls.Add(lblBell);
            panelTopbar.Controls.Add(txtGlobalSearch);
            panelTopbar.Controls.Add(lblPageSubtitle);
            panelTopbar.Controls.Add(lblPageTitle);
            panelTopbar.Dock = DockStyle.Top;
            panelTopbar.Location = new Point(274, 0);
            panelTopbar.Margin = new Padding(3, 4, 3, 4);
            panelTopbar.Name = "panelTopbar";
            panelTopbar.Size = new Size(1422, 101);
            panelTopbar.TabIndex = 1;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAvatar.BackColor = Color.FromArgb(47, 94, 240);
            lblAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(1358, 27);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(43, 51);
            lblAvatar.TabIndex = 7;
            lblAvatar.Text = "K";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserEmail
            // 
            lblUserEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserEmail.Font = new Font("Segoe UI", 8.5F);
            lblUserEmail.ForeColor = Color.FromArgb(107, 114, 128);
            lblUserEmail.Location = new Point(1210, 53);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(135, 24);
            lblUserEmail.TabIndex = 6;
            lblUserEmail.Text = "tech@phongkham.vn";
            lblUserEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(17, 24, 39);
            lblUserName.Location = new Point(1210, 27);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(135, 27);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "Kỹ thuật viên";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNotifDot
            // 
            lblNotifDot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNotifDot.BackColor = Color.FromArgb(239, 68, 68);
            lblNotifDot.Location = new Point(1166, 25);
            lblNotifDot.Name = "lblNotifDot";
            lblNotifDot.Size = new Size(9, 11);
            lblNotifDot.TabIndex = 4;
            // 
            // lblBell
            // 
            lblBell.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBell.Font = new Font("Segoe UI", 16F);
            lblBell.ForeColor = Color.FromArgb(75, 85, 99);
            lblBell.Location = new Point(1135, 24);
            lblBell.Name = "lblBell";
            lblBell.Size = new Size(39, 53);
            lblBell.TabIndex = 3;
            lblBell.Text = "!";
            lblBell.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtGlobalSearch
            // 
            txtGlobalSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtGlobalSearch.BorderStyle = BorderStyle.FixedSingle;
            txtGlobalSearch.Font = new Font("Segoe UI", 10F);
            txtGlobalSearch.Location = new Point(867, 29);
            txtGlobalSearch.Margin = new Padding(3, 4, 3, 4);
            txtGlobalSearch.Name = "txtGlobalSearch";
            txtGlobalSearch.Size = new Size(247, 30);
            txtGlobalSearch.TabIndex = 2;
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.AutoSize = true;
            lblPageSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblPageSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblPageSubtitle.Location = new Point(23, 56);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(166, 21);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Xin chào, Kỹ thuật viên";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageTitle.Location = new Point(21, 21);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(138, 32);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Tổng quan";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(247, 249, 252);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(274, 101);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1422, 992);
            contentPanel.TabIndex = 2;
            contentPanel.Resize += contentPanel_Resize;
            // 
            // ucTechnicianDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(contentPanel);
            Controls.Add(panelTopbar);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucTechnicianDashboard";
            Size = new Size(1696, 1093);
            Load += ucTechnicianDashboard_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelTopbar.ResumeLayout(false);
            panelTopbar.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNavRecords;
        private System.Windows.Forms.Button btnNavShifts;
        private System.Windows.Forms.Button btnNavRequests;
        private System.Windows.Forms.Button btnNavOverview;
        private System.Windows.Forms.Button btnNavUploadMRI;
        private System.Windows.Forms.Button btnNavUploadPDF;
        private System.Windows.Forms.Button btnNavLabResult;
        private System.Windows.Forms.Button btnNavSeederTool;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTopbar;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblNotifDot;
        private System.Windows.Forms.Label lblBell;
        private System.Windows.Forms.TextBox txtGlobalSearch;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel contentPanel;
    }
}


