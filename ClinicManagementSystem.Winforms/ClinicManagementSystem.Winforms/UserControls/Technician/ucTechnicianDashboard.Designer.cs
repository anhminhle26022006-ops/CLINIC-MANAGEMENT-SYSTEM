namespace ClinicManagementSystem.Winforms.UserControls
{
    partial class ucTechnicianDashboard
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNavRecords = new System.Windows.Forms.Button();
            this.btnNavShifts = new System.Windows.Forms.Button();
            this.btnNavRequests = new System.Windows.Forms.Button();
            this.btnNavOverview = new System.Windows.Forms.Button();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelTopbar = new System.Windows.Forms.Panel();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.lblUserEmail = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblNotifDot = new System.Windows.Forms.Label();
            this.lblBell = new System.Windows.Forms.Label();
            this.txtGlobalSearch = new System.Windows.Forms.TextBox();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelTopbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.White;
            this.panelSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnNavRecords);
            this.panelSidebar.Controls.Add(this.btnNavShifts);
            this.panelSidebar.Controls.Add(this.btnNavRequests);
            this.panelSidebar.Controls.Add(this.btnNavOverview);
            this.panelSidebar.Controls.Add(this.lblBrandSub);
            this.panelSidebar.Controls.Add(this.lblBrand);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Controls.Add(this.btnClose);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(240, 820);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.BackColor = System.Drawing.Color.White;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.Location = new System.Drawing.Point(12, 759);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(214, 42);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNavRecords
            // 
            this.btnNavRecords.BackColor = System.Drawing.Color.White;
            this.btnNavRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRecords.FlatAppearance.BorderSize = 0;
            this.btnNavRecords.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRecords.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavRecords.Location = new System.Drawing.Point(12, 228);
            this.btnNavRecords.Name = "btnNavRecords";
            this.btnNavRecords.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavRecords.Size = new System.Drawing.Size(214, 44);
            this.btnNavRecords.TabIndex = 7;
            this.btnNavRecords.Text = "Hồ sơ bệnh án";
            this.btnNavRecords.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRecords.UseVisualStyleBackColor = false;
            this.btnNavRecords.Click += new System.EventHandler(this.btnNavRecords_Click);
            // 
            // btnNavShifts
            // 
            this.btnNavShifts.BackColor = System.Drawing.Color.White;
            this.btnNavShifts.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavShifts.FlatAppearance.BorderSize = 0;
            this.btnNavShifts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavShifts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavShifts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavShifts.Location = new System.Drawing.Point(12, 178);
            this.btnNavShifts.Name = "btnNavShifts";
            this.btnNavShifts.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavShifts.Size = new System.Drawing.Size(214, 44);
            this.btnNavShifts.TabIndex = 6;
            this.btnNavShifts.Text = "Ca làm việc";
            this.btnNavShifts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavShifts.UseVisualStyleBackColor = false;
            this.btnNavShifts.Click += new System.EventHandler(this.btnNavShifts_Click);
            // 
            // btnNavRequests
            // 
            this.btnNavRequests.BackColor = System.Drawing.Color.White;
            this.btnNavRequests.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavRequests.FlatAppearance.BorderSize = 0;
            this.btnNavRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavRequests.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavRequests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavRequests.Location = new System.Drawing.Point(12, 128);
            this.btnNavRequests.Name = "btnNavRequests";
            this.btnNavRequests.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavRequests.Size = new System.Drawing.Size(214, 44);
            this.btnNavRequests.TabIndex = 5;
            this.btnNavRequests.Text = "Xét nghiệm";
            this.btnNavRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavRequests.UseVisualStyleBackColor = false;
            this.btnNavRequests.Click += new System.EventHandler(this.btnNavRequests_Click);
            // 
            // btnNavOverview
            // 
            this.btnNavOverview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.btnNavOverview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavOverview.FlatAppearance.BorderSize = 0;
            this.btnNavOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOverview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNavOverview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnNavOverview.Location = new System.Drawing.Point(12, 78);
            this.btnNavOverview.Name = "btnNavOverview";
            this.btnNavOverview.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnNavOverview.Size = new System.Drawing.Size(214, 44);
            this.btnNavOverview.TabIndex = 4;
            this.btnNavOverview.Text = "Tổng quan";
            this.btnNavOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavOverview.UseVisualStyleBackColor = false;
            this.btnNavOverview.Click += new System.EventHandler(this.btnNavOverview_Click);
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.AutoSize = true;
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblBrandSub.Location = new System.Drawing.Point(73, 45);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(68, 15);
            this.lblBrandSub.TabIndex = 3;
            this.lblBrandSub.Text = "Phòng khám";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblBrand.Location = new System.Drawing.Point(72, 18);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(132, 28);
            this.lblBrand.TabIndex = 2;
            this.lblBrand.Text = "HealthCare+";
            // 
            // lblLogo
            // 
            this.lblLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(22, 20);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(38, 38);
            this.lblLogo.TabIndex = 1;
            this.lblLogo.Text = "H+";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnClose.Location = new System.Drawing.Point(204, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "x";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // panelTopbar
            // 
            this.panelTopbar.BackColor = System.Drawing.Color.White;
            this.panelTopbar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTopbar.Controls.Add(this.lblAvatar);
            this.panelTopbar.Controls.Add(this.lblUserEmail);
            this.panelTopbar.Controls.Add(this.lblUserName);
            this.panelTopbar.Controls.Add(this.lblNotifDot);
            this.panelTopbar.Controls.Add(this.lblBell);
            this.panelTopbar.Controls.Add(this.txtGlobalSearch);
            this.panelTopbar.Controls.Add(this.lblPageSubtitle);
            this.panelTopbar.Controls.Add(this.lblPageTitle);
            this.panelTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopbar.Location = new System.Drawing.Point(240, 0);
            this.panelTopbar.Name = "panelTopbar";
            this.panelTopbar.Size = new System.Drawing.Size(1244, 76);
            this.panelTopbar.TabIndex = 1;
            // 
            // lblAvatar
            // 
            this.lblAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvatar.ForeColor = System.Drawing.Color.White;
            this.lblAvatar.Location = new System.Drawing.Point(1187, 20);
            this.lblAvatar.Name = "lblAvatar";
            this.lblAvatar.Size = new System.Drawing.Size(38, 38);
            this.lblAvatar.TabIndex = 7;
            this.lblAvatar.Text = "K";
            this.lblAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserEmail
            // 
            this.lblUserEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblUserEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblUserEmail.Location = new System.Drawing.Point(1058, 40);
            this.lblUserEmail.Name = "lblUserEmail";
            this.lblUserEmail.Size = new System.Drawing.Size(118, 18);
            this.lblUserEmail.TabIndex = 6;
            this.lblUserEmail.Text = "tech@phongkham.vn";
            this.lblUserEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblUserName.Location = new System.Drawing.Point(1058, 20);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(118, 20);
            this.lblUserName.TabIndex = 5;
            this.lblUserName.Text = "Kỹ thuật viên";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNotifDot
            // 
            this.lblNotifDot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotifDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblNotifDot.Location = new System.Drawing.Point(1019, 19);
            this.lblNotifDot.Name = "lblNotifDot";
            this.lblNotifDot.Size = new System.Drawing.Size(8, 8);
            this.lblNotifDot.TabIndex = 4;
            // 
            // lblBell
            // 
            this.lblBell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBell.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblBell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblBell.Location = new System.Drawing.Point(992, 18);
            this.lblBell.Name = "lblBell";
            this.lblBell.Size = new System.Drawing.Size(34, 40);
            this.lblBell.TabIndex = 3;
            this.lblBell.Text = "!";
            this.lblBell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtGlobalSearch
            // 
            this.txtGlobalSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGlobalSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGlobalSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGlobalSearch.Location = new System.Drawing.Point(758, 22);
            this.txtGlobalSearch.Name = "txtGlobalSearch";
            this.txtGlobalSearch.Size = new System.Drawing.Size(216, 25);
            this.txtGlobalSearch.TabIndex = 2;
            // 
            // lblPageSubtitle
            // 
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(20, 42);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(141, 17);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "Xin chào, Kỹ thuật viên";
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblPageTitle.Location = new System.Drawing.Point(18, 16);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(106, 25);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Tổng quan";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(240, 76);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1244, 744);
            this.contentPanel.TabIndex = 2;
            this.contentPanel.Resize += new System.EventHandler(this.contentPanel_Resize);
            // 
            // ucTechnicianDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Size = new System.Drawing.Size(1484, 820);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panelTopbar);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianDashboard";
            this.Load += new System.EventHandler(this.ucTechnicianDashboard_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelTopbar.ResumeLayout(false);
            this.panelTopbar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNavRecords;
        private System.Windows.Forms.Button btnNavShifts;
        private System.Windows.Forms.Button btnNavRequests;
        private System.Windows.Forms.Button btnNavOverview;
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


