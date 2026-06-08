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
            panelHeader.Location = new Point(30, 25);
            panelHeader.Margin = new Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1362, 88);
            panelHeader.TabIndex = 5;
            panelHeader.Resize += panelHeader_Resize;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(321, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Tài khoản";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(390, 28);
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
            btnAddUser.Location = new Point(1112, 19);
            btnAddUser.Margin = new Padding(4, 4, 4, 4);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(200, 50);
            btnAddUser.TabIndex = 2;
            btnAddUser.Text = "+ Thêm tài khoản";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(30, 113);
            panelKPI.Margin = new Padding(4, 4, 4, 4);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(1362, 138);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;
            cardTotal = MakeKpiCard(
    "Tổng tài khoản",
    "0",
    Color.FromArgb(17, 24, 39));

            cardActive = MakeKpiCard(
                "Đang hoạt động",
                "0",
                Color.FromArgb(22, 163, 74));

            cardLocked = MakeKpiCard(
                "Tạm khóa",
                "0",
                Color.FromArgb(220, 38, 38));

            cardNew = MakeKpiCard(
                "Tài khoản mới (tháng này)",
                "0",
                Color.FromArgb(47, 94, 240));

            panelKPI.Controls.Add(cardTotal);
            panelKPI.Controls.Add(cardActive);
            panelKPI.Controls.Add(cardLocked);
            panelKPI.Controls.Add(cardNew);
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(txtSearch);
            panelFilter.Controls.Add(cboRole);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(30, 266);
            panelFilter.Margin = new Padding(4, 4, 4, 4);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1362, 75);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += PanelRoundedBorder;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(20, 22);
            txtSearch.Margin = new Padding(4, 4, 4, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Tìm kiếm theo tên, username, email...";
            txtSearch.Size = new Size(475, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Items.AddRange(new object[] { "Tất cả vai trò", "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" });
            cboRole.Location = new Point(525, 20);
            cboRole.Margin = new Padding(4, 4, 4, 4);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(249, 36);
            cboRole.TabIndex = 1;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // cardGrid
            // 
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvUsers);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Location = new Point(30, 356);
            cardGrid.Margin = new Padding(4, 4, 4, 4);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(1362, 703);
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
            dgvUsers.Margin = new Padding(4, 4, 4, 4);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 62;
            dgvUsers.RowTemplate.Height = 52;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1362, 658);
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
            panelPaging.Location = new Point(0, 658);
            panelPaging.Margin = new Padding(4, 4, 4, 4);
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(1362, 45);
            panelPaging.TabIndex = 1;
            // 
            // lblPaging
            // 
            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.Location = new Point(15, 12);
            lblPaging.Margin = new Padding(4, 0, 4, 0);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(0, 25);
            lblPaging.TabIndex = 0;
            // 
            // sp1
            // 
            sp1.BackColor = Color.Transparent;
            sp1.Dock = DockStyle.Top;
            sp1.Location = new Point(30, 251);
            sp1.Margin = new Padding(4, 4, 4, 4);
            sp1.Name = "sp1";
            sp1.Size = new Size(1362, 15);
            sp1.TabIndex = 3;
            // 
            // sp2
            // 
            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(30, 341);
            sp2.Margin = new Padding(4, 4, 4, 4);
            sp2.Name = "sp2";
            sp2.Size = new Size(1362, 15);
            sp2.TabIndex = 1;
            // 
            // ucUserManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(cardGrid);
            Controls.Add(sp2);
            Controls.Add(panelFilter);
            Controls.Add(sp1);
            Controls.Add(panelKPI);
            Controls.Add(panelHeader);
            Margin = new Padding(4, 4, 4, 4);
            Name = "ucUserManagement";
            Padding = new Padding(30, 25, 30, 25);
            Size = new Size(1422, 1084);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private Panel MakeKpiCard(string title, string value, Color valueColor)
        {
            var card = new Panel { BackColor = Color.White, Size = new Size(220, 90) };
            card.Paint += new PaintEventHandler(this.PanelRoundedBorder);
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = true,
                Location = new Point(16, 14)
            });
            card.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = valueColor,
                AutoSize = true,
                Location = new Point(16, 38)
            });
            return card;
        }

        private Panel panelHeader;
        private Label lblTitle, lblSubtitle;
        private Button btnAddUser;
        private Panel panelKPI;
        private Panel cardTotal, cardActive, cardLocked, cardNew;
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