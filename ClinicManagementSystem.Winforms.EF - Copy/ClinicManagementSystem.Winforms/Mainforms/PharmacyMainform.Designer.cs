using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    partial class PharmacyMainform
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            btnLogout = new Button();
            btnNavShifts = new Button();
            btnNavInventory = new Button();
            btnNavMedicines = new Button();
            btnNavPrescriptions = new Button();
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
            panelSidebar.Controls.Add(btnNavShifts);
            panelSidebar.Controls.Add(btnNavInventory);
            panelSidebar.Controls.Add(btnNavMedicines);
            panelSidebar.Controls.Add(btnNavPrescriptions);
            panelSidebar.Controls.Add(btnNavOverview);
            panelSidebar.Controls.Add(lblBrandSub);
            panelSidebar.Controls.Add(lblBrand);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Controls.Add(btnClose);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(274, 1000);
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
            btnLogout.Location = new Point(14, 924);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(18, 0, 0, 0);
            btnLogout.Size = new Size(245, 56);
            btnLogout.TabIndex = 9;
            btnLogout.Text = "↪  Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNavShifts
            // 
            btnNavShifts.BackColor = Color.White;
            btnNavShifts.Cursor = Cursors.Hand;
            btnNavShifts.FlatAppearance.BorderSize = 0;
            btnNavShifts.FlatStyle = FlatStyle.Flat;
            btnNavShifts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavShifts.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavShifts.Location = new Point(14, 348);
            btnNavShifts.Name = "btnNavShifts";
            btnNavShifts.Padding = new Padding(18, 0, 0, 0);
            btnNavShifts.Size = new Size(245, 52);
            btnNavShifts.TabIndex = 8;
            btnNavShifts.Text = "◷  Ca làm việc";
            btnNavShifts.TextAlign = ContentAlignment.MiddleLeft;
            btnNavShifts.UseVisualStyleBackColor = false;
            btnNavShifts.Click += btnNavShifts_Click;
            // 
            // btnNavInventory
            // 
            btnNavInventory.BackColor = Color.White;
            btnNavInventory.Cursor = Cursors.Hand;
            btnNavInventory.FlatAppearance.BorderSize = 0;
            btnNavInventory.FlatStyle = FlatStyle.Flat;
            btnNavInventory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavInventory.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavInventory.Location = new Point(14, 290);
            btnNavInventory.Name = "btnNavInventory";
            btnNavInventory.Padding = new Padding(18, 0, 0, 0);
            btnNavInventory.Size = new Size(245, 52);
            btnNavInventory.TabIndex = 7;
            btnNavInventory.Text = "□  Quản lý kho";
            btnNavInventory.TextAlign = ContentAlignment.MiddleLeft;
            btnNavInventory.UseVisualStyleBackColor = false;
            btnNavInventory.Click += btnNavInventory_Click;
            // 
            // btnNavMedicines
            // 
            btnNavMedicines.BackColor = Color.White;
            btnNavMedicines.Cursor = Cursors.Hand;
            btnNavMedicines.FlatAppearance.BorderSize = 0;
            btnNavMedicines.FlatStyle = FlatStyle.Flat;
            btnNavMedicines.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavMedicines.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavMedicines.Location = new Point(14, 232);
            btnNavMedicines.Name = "btnNavMedicines";
            btnNavMedicines.Padding = new Padding(18, 0, 0, 0);
            btnNavMedicines.Size = new Size(245, 52);
            btnNavMedicines.TabIndex = 6;
            btnNavMedicines.Text = "◇  Danh mục thuốc";
            btnNavMedicines.TextAlign = ContentAlignment.MiddleLeft;
            btnNavMedicines.UseVisualStyleBackColor = false;
            btnNavMedicines.Click += btnNavMedicines_Click;
            // 
            // btnNavPrescriptions
            // 
            btnNavPrescriptions.BackColor = Color.White;
            btnNavPrescriptions.Cursor = Cursors.Hand;
            btnNavPrescriptions.FlatAppearance.BorderSize = 0;
            btnNavPrescriptions.FlatStyle = FlatStyle.Flat;
            btnNavPrescriptions.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavPrescriptions.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavPrescriptions.Location = new Point(14, 174);
            btnNavPrescriptions.Name = "btnNavPrescriptions";
            btnNavPrescriptions.Padding = new Padding(18, 0, 0, 0);
            btnNavPrescriptions.Size = new Size(245, 52);
            btnNavPrescriptions.TabIndex = 5;
            btnNavPrescriptions.Text = "✚  Toa thuốc";
            btnNavPrescriptions.TextAlign = ContentAlignment.MiddleLeft;
            btnNavPrescriptions.UseVisualStyleBackColor = false;
            btnNavPrescriptions.Click += btnNavPrescriptions_Click;
            // 
            // btnNavOverview
            // 
            btnNavOverview.BackColor = Color.FromArgb(239, 246, 255);
            btnNavOverview.Cursor = Cursors.Hand;
            btnNavOverview.FlatAppearance.BorderSize = 0;
            btnNavOverview.FlatStyle = FlatStyle.Flat;
            btnNavOverview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavOverview.ForeColor = Color.FromArgb(47, 94, 240);
            btnNavOverview.Location = new Point(14, 116);
            btnNavOverview.Name = "btnNavOverview";
            btnNavOverview.Padding = new Padding(18, 0, 0, 0);
            btnNavOverview.Size = new Size(245, 52);
            btnNavOverview.TabIndex = 4;
            btnNavOverview.Text = "▦  Tổng quan";
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
            lblBrandSub.Size = new Size(82, 20);
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
            btnClose.Location = new Point(229, 28);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 43);
            btnClose.TabIndex = 0;
            btnClose.Text = "×";
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
            panelTopbar.Name = "panelTopbar";
            panelTopbar.Size = new Size(1426, 101);
            panelTopbar.TabIndex = 1;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAvatar.BackColor = Color.FromArgb(47, 94, 240);
            lblAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(1362, 27);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(43, 51);
            lblAvatar.TabIndex = 7;
            lblAvatar.Text = "D";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserEmail
            // 
            lblUserEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserEmail.Font = new Font("Segoe UI", 8.5F);
            lblUserEmail.ForeColor = Color.FromArgb(107, 114, 128);
            lblUserEmail.Location = new Point(1210, 53);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(140, 24);
            lblUserEmail.TabIndex = 6;
            lblUserEmail.Text = "pharmacy@phongkham.vn";
            lblUserEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(17, 24, 39);
            lblUserName.Location = new Point(1210, 27);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(140, 27);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "Dược sĩ";
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
            txtGlobalSearch.Location = new Point(850, 31);
            txtGlobalSearch.Name = "txtGlobalSearch";
            txtGlobalSearch.Size = new Size(260, 30);
            txtGlobalSearch.TabIndex = 2;
            txtGlobalSearch.Enter += txtGlobalSearch_Enter;
            txtGlobalSearch.Leave += txtGlobalSearch_Leave;
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.AutoSize = true;
            lblPageSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblPageSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblPageSubtitle.Location = new Point(23, 56);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(115, 21);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Xin chào, Dược sĩ";
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageTitle.Location = new Point(21, 21);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(132, 32);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Tổng quan";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(247, 249, 252);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(274, 101);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1426, 899);
            contentPanel.TabIndex = 2;
            contentPanel.Resize += contentPanel_Resize;
            // 
            // PharmacyMainform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1700, 1000);
            Controls.Add(contentPanel);
            Controls.Add(panelTopbar);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PharmacyMainform";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PharmacyMainform";
            Load += PharmacyMainform_Load;
            panelSidebar.ResumeLayout(false);
            panelSidebar.PerformLayout();
            panelTopbar.ResumeLayout(false);
            panelTopbar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSidebar;
        private Button btnLogout;
        private Button btnNavShifts;
        private Button btnNavInventory;
        private Button btnNavMedicines;
        private Button btnNavPrescriptions;
        private Button btnNavOverview;
        private Label lblBrandSub;
        private Label lblBrand;
        private Label lblLogo;
        private Button btnClose;
        private Panel panelTopbar;
        private Label lblAvatar;
        private Label lblUserEmail;
        private Label lblUserName;
        private Label lblNotifDot;
        private Label lblBell;
        private TextBox txtGlobalSearch;
        private Label lblPageSubtitle;
        private Label lblPageTitle;
        private Panel contentPanel;
    }
}
