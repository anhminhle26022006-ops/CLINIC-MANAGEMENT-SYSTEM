using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucEmployeeManagement
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
            btnAddEmployee = new Button();
            panelKPI = new Panel();
            panelFilter = new Panel();
            txtSearch = new TextBox();
            cboChucVu = new ComboBox();
            cardGrid = new Panel();
            dgvEmployees = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            sp1 = new Panel();
            sp2 = new Panel();
            panelHeader.SuspendLayout();
            panelFilter.SuspendLayout();
            cardGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            panelPaging.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAddEmployee);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(30, 25);
            panelHeader.Margin = new Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1221, 88);
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
            lblTitle.Size = new Size(331, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Nhân viên";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(358, 28);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý toàn bộ nhân viên phòng khám";
            // 
            // btnAddEmployee
            // 
            btnAddEmployee.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddEmployee.BackColor = Color.FromArgb(47, 94, 240);
            btnAddEmployee.Cursor = Cursors.Hand;
            btnAddEmployee.FlatAppearance.BorderSize = 0;
            btnAddEmployee.FlatStyle = FlatStyle.Flat;
            btnAddEmployee.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddEmployee.ForeColor = Color.White;
            btnAddEmployee.Location = new Point(971, 19);
            btnAddEmployee.Margin = new Padding(4, 4, 4, 4);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(200, 50);
            btnAddEmployee.TabIndex = 2;
            btnAddEmployee.Text = "+ Thêm nhân viên";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(30, 113);
            panelKPI.Margin = new Padding(4, 4, 4, 4);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(1221, 138);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;
            cardBacSi = MakeKpiCard("Bác sĩ", "0", Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254));
            cardYTa = MakeKpiCard("Y tá", "0", Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229));
            cardDuocSi = MakeKpiCard("Dược sĩ", "0", Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254));
            cardKyThuat = MakeKpiCard("Kỹ thuật viên", "0", Color.FromArgb(234, 88, 12), Color.FromArgb(254, 215, 170));
            cardLeTan = MakeKpiCard("Lễ tân", "0", Color.FromArgb(219, 39, 119), Color.FromArgb(252, 231, 243));
            panelKPI.Controls.Add(cardBacSi);
            panelKPI.Controls.Add(cardYTa);
            panelKPI.Controls.Add(cardDuocSi);
            panelKPI.Controls.Add(cardKyThuat);
            panelKPI.Controls.Add(cardLeTan);
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(txtSearch);
            panelFilter.Controls.Add(cboChucVu);

            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(30, 266);
            panelFilter.Margin = new Padding(4, 4, 4, 4);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1221, 75);
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
            txtSearch.PlaceholderText = "  Tìm nhân viên theo tên hoặc mã...";
            txtSearch.Size = new Size(475, 27);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Segoe UI", 10F);
            cboChucVu.Items.AddRange(new object[] { "Tất cả chức vụ", "Doctor", "Nurse", "Pharmacist", "Technician", "Receptionist" });
            cboChucVu.SelectedIndex = 0;
            cboChucVu.Location = new Point(525, 20);
            cboChucVu.Margin = new Padding(4, 4, 4, 4);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(249, 36);
            cboChucVu.TabIndex = 1;
            cboChucVu.SelectedIndexChanged += cboChucVu_SelectedIndexChanged;

            // 
            // cardGrid
            // 
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvEmployees);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Location = new Point(30, 356);
            cardGrid.Margin = new Padding(4, 4, 4, 4);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(1221, 703);
            cardGrid.TabIndex = 0;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEmployees.ColumnHeadersHeight = 44;
            dgvEmployees.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.Font = new Font("Segoe UI", 9.5F);
            dgvEmployees.GridColor = Color.FromArgb(229, 231, 235);
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.Margin = new Padding(4, 4, 4, 4);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 62;
            dgvEmployees.RowTemplate.Height = 56;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1221, 658);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            dgvEmployees.CellFormatting += dgvEmployees_CellFormatting;
            dgvEmployees.CellPainting += dgvEmployees_CellPainting;
            // Columns
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCode", HeaderText = "MÃ NV", FillWeight = 9 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colName", HeaderText = "HỌ TÊN", FillWeight = 20 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colChucVu", HeaderText = "CHỨC VỤ", FillWeight = 12 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colKhoa", HeaderText = "CHUYÊN KHOA", FillWeight = 14 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colContact", HeaderText = "LIÊN HỆ", FillWeight = 18 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "TRẠNG THÁI", FillWeight = 12 });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colView", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEdit", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvEmployees.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDelete", HeaderText = "THAO TÁC", FillWeight = 5, ReadOnly = true });
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 658);
            panelPaging.Margin = new Padding(4, 4, 4, 4);
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(1221, 45);
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
            sp1.Size = new Size(1221, 15);
            sp1.TabIndex = 3;
            // 
            // sp2
            // 
            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(30, 341);
            sp2.Margin = new Padding(4, 4, 4, 4);
            sp2.Name = "sp2";
            sp2.Size = new Size(1221, 15);
            sp2.TabIndex = 1;
            // 
            // ucEmployeeManagement
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
            Name = "ucEmployeeManagement";
            Padding = new Padding(30, 25, 30, 25);
            Size = new Size(1281, 1084);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private Panel MakeKpiCard(string title, string value, Color valueColor, Color bgColor)
        {
            var card = new Panel { BackColor = bgColor, Size = new Size(180, 90) };
            card.Paint += new PaintEventHandler(this.PanelRoundedBorder);
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = valueColor,
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
        private Button btnAddEmployee;
        private Panel panelKPI;
        private Panel cardBacSi, cardYTa, cardDuocSi, cardKyThuat, cardLeTan;
        private Panel panelFilter;
        private TextBox txtSearch;
        private ComboBox cboChucVu;
        private Panel cardGrid;
        private DataGridView dgvEmployees;
        private Panel panelPaging;
        private Label lblPaging;
        private Panel sp1, sp2;
    }
}