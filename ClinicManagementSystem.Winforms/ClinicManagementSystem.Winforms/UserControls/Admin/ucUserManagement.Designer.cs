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

            // panelHeader
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAddUser);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 70;
            panelHeader.Name = "panelHeader";
            panelHeader.Resize += new System.EventHandler(this.panelHeader_Resize);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 4);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Quản lý Tài khoản";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Quản lý tài khoản đăng nhập cho nhân viên";

            btnAddUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUser.BackColor = Color.FromArgb(47, 94, 240);
            btnAddUser.Cursor = Cursors.Hand;
            btnAddUser.FlatAppearance.BorderSize = 0;
            btnAddUser.FlatStyle = FlatStyle.Flat;
            btnAddUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddUser.ForeColor = Color.White;
            btnAddUser.Location = new Point(0, 15);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(160, 40);
            btnAddUser.Text = "+ Thêm tài khoản";
            btnAddUser.UseVisualStyleBackColor = false;
            btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // panelKPI
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Height = 110;
            panelKPI.Name = "panelKPI";
            panelKPI.Resize += new System.EventHandler(this.panelKPI_Resize);

            cardTotal = MakeKpiCard("Tổng tài khoản", "0", Color.FromArgb(17, 24, 39));
            cardActive = MakeKpiCard("Đang hoạt động", "0", Color.FromArgb(22, 163, 74));
            cardLocked = MakeKpiCard("Tạm khóa", "0", Color.FromArgb(220, 38, 38));
            cardNew = MakeKpiCard("Tài khoản mới (tháng)", "0", Color.FromArgb(47, 94, 240));
            panelKPI.Controls.Add(cardTotal);
            panelKPI.Controls.Add(cardActive);
            panelKPI.Controls.Add(cardLocked);
            panelKPI.Controls.Add(cardNew);

            // panelFilter
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(txtSearch);
            panelFilter.Controls.Add(cboRole);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Height = 60;
            panelFilter.Name = "panelFilter";
            panelFilter.Paint += new PaintEventHandler(this.PanelRoundedBorder);

            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(16, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Tìm kiếm theo tên, username, email...";
            txtSearch.Size = new Size(380, 23);
            txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Items.AddRange(new object[] { "Tất cả vai trò", "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" });
            cboRole.Location = new Point(420, 16);
            cboRole.Name = "cboRole";
            cboRole.SelectedIndex = 0;
            cboRole.Size = new Size(200, 28);
            cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);

            // cardGrid
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvUsers);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Name = "cardGrid";

            // dgvUsers — AutoGenerateColumns = false là quan trọng nhất
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersHeight = 44;
            dgvUsers.Cursor = Cursors.Hand;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.Font = new Font("Segoe UI", 9.5F);
            dgvUsers.GridColor = Color.FromArgb(229, 231, 235);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowTemplate.Height = 52;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(107, 114, 128);
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvUsers.CellClick += new DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            dgvUsers.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvUsers_CellFormatting);
            dgvUsers.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvUsers_CellPainting);

            // Đúng 9 cột theo Figma
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colUsername", HeaderText = "USERNAME", DataPropertyName = "Username", FillWeight = 13 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "TÊN HIỂN THỊ", DataPropertyName = "DisplayName", FillWeight = 19 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "VAI TRÒ", DataPropertyName = "RoleName", FillWeight = 13 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail", HeaderText = "EMAIL", DataPropertyName = "Email", FillWeight = 22 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "TRẠNG THÁI", DataPropertyName = "StatusText", FillWeight = 12 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCreated", HeaderText = "NGÀY TẠO", DataPropertyName = "CreatedAtText", FillWeight = 11 });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colView", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEdit", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDelete", HeaderText = "THAO TÁC", FillWeight = 5, ReadOnly = true });

            // panelPaging
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Height = 36;
            panelPaging.Name = "panelPaging";

            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.Location = new Point(12, 10);
            lblPaging.Name = "lblPaging";

            // Spacers
            sp1.BackColor = Color.Transparent;
            sp1.Dock = DockStyle.Top;
            sp1.Height = 12;

            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Height = 12;

            // ucUserManagement
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Dock = DockStyle.Fill;
            Name = "ucUserManagement";
            Padding = new Padding(24, 20, 24, 20);
            Controls.Add(cardGrid);
            Controls.Add(sp2);
            Controls.Add(panelFilter);
            Controls.Add(sp1);
            Controls.Add(panelKPI);
            Controls.Add(panelHeader);

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