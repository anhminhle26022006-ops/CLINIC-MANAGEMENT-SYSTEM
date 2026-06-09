using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucUserManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnAddUser = new Button();
            panelKPI = new Panel();
            cardTotal = new Panel();
            lblTotalTitle = new Label();
            lblTotalValue = new Label();
            lblTotalIcon = new Label();
            cardActive = new Panel();
            lblActiveTitle = new Label();
            lblActiveValue = new Label();
            lblActiveIcon = new Label();
            cardLocked = new Panel();
            lblLockedTitle = new Label();
            lblLockedValue = new Label();
            lblLockedIcon = new Label();
            cardNew = new Panel();
            lblNewTitle = new Label();
            lblNewValue = new Label();
            lblNewIcon = new Label();
            panelFilter = new Panel();
            txtSearch = new TextBox();
            cboRole = new ComboBox();
            cardGrid = new Panel();
            dgvUsers = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            sp1 = new Panel();
            sp2 = new Panel();
            panelHeader.SuspendLayout();
            panelKPI.SuspendLayout();
            cardTotal.SuspendLayout();
            cardActive.SuspendLayout();
            cardLocked.SuspendLayout();
            cardNew.SuspendLayout();
            panelFilter.SuspendLayout();
            cardGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            panelPaging.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAddUser);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(24, 20);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1090, 70);
            panelHeader.TabIndex = 5;
            panelHeader.Resize += panelHeader_Resize;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(269, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Tài khoản";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(346, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý tài khoản đăng nhập cho nhân viên";
            // 
            // btnAddUser
            // 
            btnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUser.BackColor = Color.FromArgb(47, 94, 240);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(890, 15);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(160, 40);
            btnAddUser.TabIndex = 2;
            btnAddUser.Text = "+ Thêm tài khoản";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Controls.Add(cardTotal);
            panelKPI.Controls.Add(cardActive);
            panelKPI.Controls.Add(cardLocked);
            panelKPI.Controls.Add(cardNew);
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(24, 90);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(1090, 110);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.White;
            cardTotal.Controls.Add(lblTotalTitle);
            cardTotal.Controls.Add(lblTotalValue);
            cardTotal.Controls.Add(lblTotalIcon);
            cardTotal.Location = new Point(0, 11);
            cardTotal.Margin = new Padding(0, 0, 13, 0);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(176, 80);
            cardTotal.TabIndex = 0;
            cardTotal.Paint += PanelRoundedBorder;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Font = new Font("Segoe UI", 9F);
            lblTotalTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalTitle.Location = new Point(13, 11);
            lblTotalTitle.Margin = new Padding(2, 0, 2, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(104, 19);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "Tổng tài khoản";
            // 
            // lblTotalValue
            // 
            lblTotalValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(17, 24, 39);
            lblTotalValue.Location = new Point(16, 30);
            lblTotalValue.Margin = new Padding(2, 0, 2, 0);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(96, 44);
            lblTotalValue.TabIndex = 1;
            lblTotalValue.Text = "0";
            // 
            // lblTotalIcon
            // 
            lblTotalIcon.BackColor = Color.FromArgb(243, 244, 246);
            lblTotalIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalIcon.ForeColor = Color.FromArgb(17, 24, 39);
            lblTotalIcon.Location = new Point(126, 18);
            lblTotalIcon.Margin = new Padding(2, 0, 2, 0);
            lblTotalIcon.Name = "lblTotalIcon";
            lblTotalIcon.Size = new Size(37, 37);
            lblTotalIcon.TabIndex = 2;
            lblTotalIcon.Text = "TK";
            lblTotalIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardActive
            // 
            cardActive.BackColor = Color.White;
            cardActive.Controls.Add(lblActiveTitle);
            cardActive.Controls.Add(lblActiveValue);
            cardActive.Controls.Add(lblActiveIcon);
            cardActive.Location = new Point(189, 11);
            cardActive.Margin = new Padding(0, 0, 13, 0);
            cardActive.Name = "cardActive";
            cardActive.Size = new Size(176, 80);
            cardActive.TabIndex = 1;
            cardActive.Paint += PanelRoundedBorder;
            // 
            // lblActiveTitle
            // 
            lblActiveTitle.Font = new Font("Segoe UI", 9F);
            lblActiveTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblActiveTitle.Location = new Point(13, 11);
            lblActiveTitle.Margin = new Padding(2, 0, 2, 0);
            lblActiveTitle.Name = "lblActiveTitle";
            lblActiveTitle.Size = new Size(104, 19);
            lblActiveTitle.TabIndex = 0;
            lblActiveTitle.Text = "Đang hoạt động";
            // 
            // lblActiveValue
            // 
            lblActiveValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblActiveValue.ForeColor = Color.FromArgb(22, 163, 74);
            lblActiveValue.Location = new Point(13, 30);
            lblActiveValue.Margin = new Padding(2, 0, 2, 0);
            lblActiveValue.Name = "lblActiveValue";
            lblActiveValue.Size = new Size(96, 44);
            lblActiveValue.TabIndex = 1;
            lblActiveValue.Text = "0";
            // 
            // lblActiveIcon
            // 
            lblActiveIcon.BackColor = Color.FromArgb(220, 252, 231);
            lblActiveIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActiveIcon.ForeColor = Color.FromArgb(22, 163, 74);
            lblActiveIcon.Location = new Point(126, 18);
            lblActiveIcon.Margin = new Padding(2, 0, 2, 0);
            lblActiveIcon.Name = "lblActiveIcon";
            lblActiveIcon.Size = new Size(37, 37);
            lblActiveIcon.TabIndex = 2;
            lblActiveIcon.Text = "HD";
            lblActiveIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardLocked
            // 
            cardLocked.BackColor = Color.White;
            cardLocked.Controls.Add(lblLockedTitle);
            cardLocked.Controls.Add(lblLockedValue);
            cardLocked.Controls.Add(lblLockedIcon);
            cardLocked.Location = new Point(378, 11);
            cardLocked.Margin = new Padding(0, 0, 13, 0);
            cardLocked.Name = "cardLocked";
            cardLocked.Size = new Size(176, 80);
            cardLocked.TabIndex = 2;
            cardLocked.Paint += PanelRoundedBorder;
            // 
            // lblLockedTitle
            // 
            lblLockedTitle.Font = new Font("Segoe UI", 9F);
            lblLockedTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblLockedTitle.Location = new Point(13, 11);
            lblLockedTitle.Margin = new Padding(2, 0, 2, 0);
            lblLockedTitle.Name = "lblLockedTitle";
            lblLockedTitle.Size = new Size(104, 19);
            lblLockedTitle.TabIndex = 0;
            lblLockedTitle.Text = "Tạm khóa";
            // 
            // lblLockedValue
            // 
            lblLockedValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLockedValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblLockedValue.Location = new Point(13, 30);
            lblLockedValue.Margin = new Padding(2, 0, 2, 0);
            lblLockedValue.Name = "lblLockedValue";
            lblLockedValue.Size = new Size(96, 44);
            lblLockedValue.TabIndex = 1;
            lblLockedValue.Text = "0";
            // 
            // lblLockedIcon
            // 
            lblLockedIcon.BackColor = Color.FromArgb(254, 226, 226);
            lblLockedIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLockedIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblLockedIcon.Location = new Point(126, 18);
            lblLockedIcon.Margin = new Padding(2, 0, 2, 0);
            lblLockedIcon.Name = "lblLockedIcon";
            lblLockedIcon.Size = new Size(37, 37);
            lblLockedIcon.TabIndex = 2;
            lblLockedIcon.Text = "KH";
            lblLockedIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardNew
            // 
            cardNew.BackColor = Color.White;
            cardNew.Controls.Add(lblNewTitle);
            cardNew.Controls.Add(lblNewValue);
            cardNew.Controls.Add(lblNewIcon);
            cardNew.Location = new Point(566, 11);
            cardNew.Margin = new Padding(0, 0, 13, 0);
            cardNew.Name = "cardNew";
            cardNew.Size = new Size(208, 80);
            cardNew.TabIndex = 3;
            cardNew.Paint += PanelRoundedBorder;
            // 
            // lblNewTitle
            // 
            lblNewTitle.Font = new Font("Segoe UI", 9F);
            lblNewTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblNewTitle.Location = new Point(13, 11);
            lblNewTitle.Margin = new Padding(2, 0, 2, 0);
            lblNewTitle.Name = "lblNewTitle";
            lblNewTitle.Size = new Size(128, 19);
            lblNewTitle.TabIndex = 0;
            lblNewTitle.Text = "Tài khoản mới (tháng này)";
            // 
            // lblNewValue
            // 
            lblNewValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblNewValue.ForeColor = Color.FromArgb(47, 94, 240);
            lblNewValue.Location = new Point(13, 30);
            lblNewValue.Margin = new Padding(2, 0, 2, 0);
            lblNewValue.Name = "lblNewValue";
            lblNewValue.Size = new Size(96, 44);
            lblNewValue.TabIndex = 1;
            lblNewValue.Text = "0";
            // 
            // lblNewIcon
            // 
            lblNewIcon.BackColor = Color.FromArgb(219, 234, 254);
            lblNewIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNewIcon.ForeColor = Color.FromArgb(47, 94, 240);
            lblNewIcon.Location = new Point(158, 18);
            lblNewIcon.Margin = new Padding(2, 0, 2, 0);
            lblNewIcon.Name = "lblNewIcon";
            lblNewIcon.Size = new Size(37, 37);
            lblNewIcon.TabIndex = 2;
            lblNewIcon.Text = "MO";
            lblNewIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(txtSearch);
            panelFilter.Controls.Add(cboRole);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(24, 212);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1090, 60);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += PanelRoundedBorder;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(16, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Tìm kiếm theo tên, username, email...";
            txtSearch.Size = new Size(380, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Items.AddRange(new object[] { "Tất cả vai trò", "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" });
            cboRole.Location = new Point(420, 16);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(200, 31);
            cboRole.TabIndex = 1;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // cardGrid
            // 
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvUsers);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Location = new Point(24, 284);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(1090, 563);
            cardGrid.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.ColumnHeadersHeight = 44;
            dgvUsers.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.Font = new Font("Segoe UI", 9.5F);
            dgvUsers.GridColor = Color.FromArgb(229, 231, 235);
            dgvUsers.Location = new Point(0, 0);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.RowTemplate.Height = 52;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1090, 527);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            dgvUsers.CellFormatting += dgvUsers_CellFormatting;
            dgvUsers.CellPainting += dgvUsers_CellPainting;
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 527);
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(1090, 36);
            panelPaging.TabIndex = 1;
            // 
            // lblPaging
            // 
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.Location = new Point(12, 10);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(0, 20);
            lblPaging.TabIndex = 0;
            // 
            // sp1
            // 
            sp1.BackColor = Color.Transparent;
            sp1.Dock = DockStyle.Top;
            sp1.Location = new Point(24, 200);
            sp1.Name = "sp1";
            sp1.Size = new Size(1090, 12);
            sp1.TabIndex = 3;
            // 
            // sp2
            // 
            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(24, 272);
            sp2.Name = "sp2";
            sp2.Size = new Size(1090, 12);
            sp2.TabIndex = 1;
            // 
            // ucUserManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(cardGrid);
            Controls.Add(sp2);
            Controls.Add(panelFilter);
            Controls.Add(sp1);
            Controls.Add(panelKPI);
            Controls.Add(panelHeader);
            Name = "ucUserManagement";
            Padding = new Padding(24, 20, 24, 20);
            Size = new Size(1138, 867);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelKPI.ResumeLayout(false);
            cardTotal.ResumeLayout(false);
            cardActive.ResumeLayout(false);
            cardLocked.ResumeLayout(false);
            cardNew.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle, lblSubtitle;
        private Button btnAddUser;
        private Panel panelKPI;
        private Panel cardTotal, cardActive, cardLocked, cardNew;
        private Label lblTotalTitle, lblTotalValue, lblTotalIcon;
        private Label lblActiveTitle, lblActiveValue, lblActiveIcon;
        private Label lblLockedTitle, lblLockedValue, lblLockedIcon;
        private Label lblNewTitle, lblNewValue, lblNewIcon;
        private Panel panelFilter;
        private TextBox txtSearch;
        private ComboBox cboRole;
        private Panel cardGrid;
        private DataGridView dgvUsers;
        private Panel panelPaging;
        private Label lblPaging;
        private Panel sp1, sp2;
    }
}
