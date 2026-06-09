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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnAddEmployee = new Button();
            panelKPI = new Panel();
            cardBacSi = new Panel();
            lblBacSiTitle = new Label();
            lblBacSiValue = new Label();
            lblBacSiIcon = new Label();
            cardYTa = new Panel();
            lblYTaTitle = new Label();
            lblYTaValue = new Label();
            lblYTaIcon = new Label();
            cardDuocSi = new Panel();
            lblDuocSiTitle = new Label();
            lblDuocSiValue = new Label();
            lblDuocSiIcon = new Label();
            cardKyThuat = new Panel();
            lblKyThuatTitle = new Label();
            lblKyThuatValue = new Label();
            lblKyThuatIcon = new Label();
            cardLeTan = new Panel();
            lblLeTanTitle = new Label();
            lblLeTanValue = new Label();
            lblLeTanIcon = new Label();
            panelFilter = new Panel();
            txtSearch = new TextBox();
            cboChucVu = new ComboBox();
            cardGrid = new Panel();
            dgvEmployees = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            sp1 = new Panel();
            sp2 = new Panel();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            panelHeader.SuspendLayout();
            panelKPI.SuspendLayout();
            cardBacSi.SuspendLayout();
            cardYTa.SuspendLayout();
            cardDuocSi.SuspendLayout();
            cardKyThuat.SuspendLayout();
            cardLeTan.SuspendLayout();
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
            panelHeader.Location = new Point(24, 20);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(977, 70);
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
            lblTitle.Size = new Size(277, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý Nhân viên";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 40);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(316, 23);
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
            btnAddEmployee.Location = new Point(739, 15);
            btnAddEmployee.Name = "btnAddEmployee";
            btnAddEmployee.Size = new Size(198, 40);
            btnAddEmployee.TabIndex = 2;
            btnAddEmployee.Text = "+ Thêm nhân viên";
            btnAddEmployee.UseVisualStyleBackColor = false;
            btnAddEmployee.Click += btnAddEmployee_Click;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Controls.Add(cardBacSi);
            panelKPI.Controls.Add(cardYTa);
            panelKPI.Controls.Add(cardDuocSi);
            panelKPI.Controls.Add(cardKyThuat);
            panelKPI.Controls.Add(cardLeTan);
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(24, 90);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(977, 110);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;
            // 
            // cardBacSi
            // 
            cardBacSi.BackColor = Color.FromArgb(219, 234, 254);
            cardBacSi.Controls.Add(lblBacSiTitle);
            cardBacSi.Controls.Add(lblBacSiValue);
            cardBacSi.Controls.Add(lblBacSiIcon);
            cardBacSi.Location = new Point(0, 11);
            cardBacSi.Margin = new Padding(0, 0, 13, 0);
            cardBacSi.Name = "cardBacSi";
            cardBacSi.Size = new Size(176, 80);
            cardBacSi.TabIndex = 0;
            cardBacSi.Paint += PanelRoundedBorder;
            // 
            // lblBacSiTitle
            // 
            lblBacSiTitle.Font = new Font("Segoe UI", 9F);
            lblBacSiTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblBacSiTitle.Location = new Point(13, 11);
            lblBacSiTitle.Margin = new Padding(2, 0, 2, 0);
            lblBacSiTitle.Name = "lblBacSiTitle";
            lblBacSiTitle.Size = new Size(104, 19);
            lblBacSiTitle.TabIndex = 0;
            lblBacSiTitle.Text = "Bác sĩ";
            // 
            // lblBacSiValue
            // 
            lblBacSiValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBacSiValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblBacSiValue.Location = new Point(16, 30);
            lblBacSiValue.Margin = new Padding(2, 0, 2, 0);
            lblBacSiValue.Name = "lblBacSiValue";
            lblBacSiValue.Size = new Size(96, 44);
            lblBacSiValue.TabIndex = 1;
            lblBacSiValue.Text = "0";
            // 
            // lblBacSiIcon
            // 
            lblBacSiIcon.BackColor = Color.White;
            lblBacSiIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBacSiIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblBacSiIcon.Location = new Point(126, 18);
            lblBacSiIcon.Margin = new Padding(2, 0, 2, 0);
            lblBacSiIcon.Name = "lblBacSiIcon";
            lblBacSiIcon.Size = new Size(37, 37);
            lblBacSiIcon.TabIndex = 2;
            lblBacSiIcon.Text = "BS";
            lblBacSiIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardYTa
            // 
            cardYTa.BackColor = Color.FromArgb(209, 250, 229);
            cardYTa.Controls.Add(lblYTaTitle);
            cardYTa.Controls.Add(lblYTaValue);
            cardYTa.Controls.Add(lblYTaIcon);
            cardYTa.Location = new Point(189, 11);
            cardYTa.Margin = new Padding(0, 0, 13, 0);
            cardYTa.Name = "cardYTa";
            cardYTa.Size = new Size(176, 80);
            cardYTa.TabIndex = 1;
            cardYTa.Paint += PanelRoundedBorder;
            // 
            // lblYTaTitle
            // 
            lblYTaTitle.Font = new Font("Segoe UI", 9F);
            lblYTaTitle.ForeColor = Color.FromArgb(5, 150, 105);
            lblYTaTitle.Location = new Point(13, 11);
            lblYTaTitle.Margin = new Padding(2, 0, 2, 0);
            lblYTaTitle.Name = "lblYTaTitle";
            lblYTaTitle.Size = new Size(104, 19);
            lblYTaTitle.TabIndex = 0;
            lblYTaTitle.Text = "Y tá";
            // 
            // lblYTaValue
            // 
            lblYTaValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblYTaValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblYTaValue.Location = new Point(13, 30);
            lblYTaValue.Margin = new Padding(2, 0, 2, 0);
            lblYTaValue.Name = "lblYTaValue";
            lblYTaValue.Size = new Size(96, 44);
            lblYTaValue.TabIndex = 1;
            lblYTaValue.Text = "0";
            // 
            // lblYTaIcon
            // 
            lblYTaIcon.BackColor = Color.White;
            lblYTaIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblYTaIcon.ForeColor = Color.FromArgb(5, 150, 105);
            lblYTaIcon.Location = new Point(126, 18);
            lblYTaIcon.Margin = new Padding(2, 0, 2, 0);
            lblYTaIcon.Name = "lblYTaIcon";
            lblYTaIcon.Size = new Size(37, 37);
            lblYTaIcon.TabIndex = 2;
            lblYTaIcon.Text = "YT";
            lblYTaIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardDuocSi
            // 
            cardDuocSi.BackColor = Color.FromArgb(237, 233, 254);
            cardDuocSi.Controls.Add(lblDuocSiTitle);
            cardDuocSi.Controls.Add(lblDuocSiValue);
            cardDuocSi.Controls.Add(lblDuocSiIcon);
            cardDuocSi.Location = new Point(378, 11);
            cardDuocSi.Margin = new Padding(0, 0, 13, 0);
            cardDuocSi.Name = "cardDuocSi";
            cardDuocSi.Size = new Size(176, 80);
            cardDuocSi.TabIndex = 2;
            cardDuocSi.Paint += PanelRoundedBorder;
            // 
            // lblDuocSiTitle
            // 
            lblDuocSiTitle.Font = new Font("Segoe UI", 9F);
            lblDuocSiTitle.ForeColor = Color.FromArgb(124, 58, 237);
            lblDuocSiTitle.Location = new Point(13, 11);
            lblDuocSiTitle.Margin = new Padding(2, 0, 2, 0);
            lblDuocSiTitle.Name = "lblDuocSiTitle";
            lblDuocSiTitle.Size = new Size(104, 19);
            lblDuocSiTitle.TabIndex = 0;
            lblDuocSiTitle.Text = "Dược sĩ";
            // 
            // lblDuocSiValue
            // 
            lblDuocSiValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDuocSiValue.ForeColor = Color.FromArgb(124, 58, 237);
            lblDuocSiValue.Location = new Point(13, 30);
            lblDuocSiValue.Margin = new Padding(2, 0, 2, 0);
            lblDuocSiValue.Name = "lblDuocSiValue";
            lblDuocSiValue.Size = new Size(96, 44);
            lblDuocSiValue.TabIndex = 1;
            lblDuocSiValue.Text = "0";
            // 
            // lblDuocSiIcon
            // 
            lblDuocSiIcon.BackColor = Color.White;
            lblDuocSiIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDuocSiIcon.ForeColor = Color.FromArgb(124, 58, 237);
            lblDuocSiIcon.Location = new Point(126, 18);
            lblDuocSiIcon.Margin = new Padding(2, 0, 2, 0);
            lblDuocSiIcon.Name = "lblDuocSiIcon";
            lblDuocSiIcon.Size = new Size(37, 37);
            lblDuocSiIcon.TabIndex = 2;
            lblDuocSiIcon.Text = "DS";
            lblDuocSiIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardKyThuat
            // 
            cardKyThuat.BackColor = Color.FromArgb(254, 215, 170);
            cardKyThuat.Controls.Add(lblKyThuatTitle);
            cardKyThuat.Controls.Add(lblKyThuatValue);
            cardKyThuat.Controls.Add(lblKyThuatIcon);
            cardKyThuat.Location = new Point(566, 11);
            cardKyThuat.Margin = new Padding(0, 0, 13, 0);
            cardKyThuat.Name = "cardKyThuat";
            cardKyThuat.Size = new Size(176, 80);
            cardKyThuat.TabIndex = 3;
            cardKyThuat.Paint += PanelRoundedBorder;
            // 
            // lblKyThuatTitle
            // 
            lblKyThuatTitle.Font = new Font("Segoe UI", 9F);
            lblKyThuatTitle.ForeColor = Color.FromArgb(234, 88, 12);
            lblKyThuatTitle.Location = new Point(13, 11);
            lblKyThuatTitle.Margin = new Padding(2, 0, 2, 0);
            lblKyThuatTitle.Name = "lblKyThuatTitle";
            lblKyThuatTitle.Size = new Size(104, 19);
            lblKyThuatTitle.TabIndex = 0;
            lblKyThuatTitle.Text = "Kỹ thuật viên";
            // 
            // lblKyThuatValue
            // 
            lblKyThuatValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKyThuatValue.ForeColor = Color.FromArgb(234, 88, 12);
            lblKyThuatValue.Location = new Point(13, 30);
            lblKyThuatValue.Margin = new Padding(2, 0, 2, 0);
            lblKyThuatValue.Name = "lblKyThuatValue";
            lblKyThuatValue.Size = new Size(96, 44);
            lblKyThuatValue.TabIndex = 1;
            lblKyThuatValue.Text = "0";
            // 
            // lblKyThuatIcon
            // 
            lblKyThuatIcon.BackColor = Color.White;
            lblKyThuatIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKyThuatIcon.ForeColor = Color.FromArgb(234, 88, 12);
            lblKyThuatIcon.Location = new Point(126, 18);
            lblKyThuatIcon.Margin = new Padding(2, 0, 2, 0);
            lblKyThuatIcon.Name = "lblKyThuatIcon";
            lblKyThuatIcon.Size = new Size(37, 37);
            lblKyThuatIcon.TabIndex = 2;
            lblKyThuatIcon.Text = "KT";
            lblKyThuatIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardLeTan
            // 
            cardLeTan.BackColor = Color.FromArgb(252, 231, 243);
            cardLeTan.Controls.Add(lblLeTanTitle);
            cardLeTan.Controls.Add(lblLeTanValue);
            cardLeTan.Controls.Add(lblLeTanIcon);
            cardLeTan.Location = new Point(755, 11);
            cardLeTan.Margin = new Padding(0, 0, 13, 0);
            cardLeTan.Name = "cardLeTan";
            cardLeTan.Size = new Size(176, 80);
            cardLeTan.TabIndex = 4;
            cardLeTan.Paint += PanelRoundedBorder;
            // 
            // lblLeTanTitle
            // 
            lblLeTanTitle.Font = new Font("Segoe UI", 9F);
            lblLeTanTitle.ForeColor = Color.FromArgb(219, 39, 119);
            lblLeTanTitle.Location = new Point(13, 11);
            lblLeTanTitle.Margin = new Padding(2, 0, 2, 0);
            lblLeTanTitle.Name = "lblLeTanTitle";
            lblLeTanTitle.Size = new Size(104, 19);
            lblLeTanTitle.TabIndex = 0;
            lblLeTanTitle.Text = "Lễ tân";
            // 
            // lblLeTanValue
            // 
            lblLeTanValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLeTanValue.ForeColor = Color.FromArgb(219, 39, 119);
            lblLeTanValue.Location = new Point(13, 30);
            lblLeTanValue.Margin = new Padding(2, 0, 2, 0);
            lblLeTanValue.Name = "lblLeTanValue";
            lblLeTanValue.Size = new Size(96, 44);
            lblLeTanValue.TabIndex = 1;
            lblLeTanValue.Text = "0";
            // 
            // lblLeTanIcon
            // 
            lblLeTanIcon.BackColor = Color.White;
            lblLeTanIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLeTanIcon.ForeColor = Color.FromArgb(219, 39, 119);
            lblLeTanIcon.Location = new Point(126, 18);
            lblLeTanIcon.Margin = new Padding(2, 0, 2, 0);
            lblLeTanIcon.Name = "lblLeTanIcon";
            lblLeTanIcon.Size = new Size(37, 37);
            lblLeTanIcon.TabIndex = 2;
            lblLeTanIcon.Text = "LT";
            lblLeTanIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(txtSearch);
            panelFilter.Controls.Add(cboChucVu);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(24, 212);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(977, 60);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += PanelRoundedBorder;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(16, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "  Tìm nhân viên theo tên hoặc mã...";
            txtSearch.Size = new Size(380, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // cboChucVu
            // 
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChucVu.Font = new Font("Segoe UI", 10F);
            cboChucVu.Items.AddRange(new object[] { "Tất cả chức vụ", "Doctor", "Nurse", "Pharmacist", "Technician", "Receptionist" });
            cboChucVu.Location = new Point(420, 16);
            cboChucVu.Name = "cboChucVu";
            cboChucVu.Size = new Size(200, 31);
            cboChucVu.TabIndex = 1;
            cboChucVu.SelectedIndexChanged += cboChucVu_SelectedIndexChanged;
            // 
            // cardGrid
            // 
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvEmployees);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Location = new Point(24, 284);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(977, 563);
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvEmployees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvEmployees.ColumnHeadersHeight = 44;
            dgvEmployees.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dgvEmployees.Cursor = Cursors.Hand;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvEmployees.DefaultCellStyle = dataGridViewCellStyle4;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.EnableHeadersVisualStyles = false;
            dgvEmployees.Font = new Font("Segoe UI", 9.5F);
            dgvEmployees.GridColor = Color.FromArgb(229, 231, 235);
            dgvEmployees.Location = new Point(0, 0);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 62;
            dgvEmployees.RowTemplate.Height = 56;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(977, 527);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.CellClick += dgvEmployees_CellClick;
            dgvEmployees.CellFormatting += dgvEmployees_CellFormatting;
            dgvEmployees.CellPainting += dgvEmployees_CellPainting;
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 527);
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(977, 36);
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
            sp1.Size = new Size(977, 12);
            sp1.TabIndex = 3;
            // 
            // sp2
            // 
            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(24, 272);
            sp2.Name = "sp2";
            sp2.Size = new Size(977, 12);
            sp2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // ucEmployeeManagement
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
            Name = "ucEmployeeManagement";
            Padding = new Padding(24, 20, 24, 20);
            Size = new Size(1025, 867);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelKPI.ResumeLayout(false);
            cardBacSi.ResumeLayout(false);
            cardYTa.ResumeLayout(false);
            cardDuocSi.ResumeLayout(false);
            cardKyThuat.ResumeLayout(false);
            cardLeTan.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelHeader;
        private Label lblTitle, lblSubtitle;
        private Button btnAddEmployee;
        private Panel panelKPI;
        private Panel cardBacSi, cardYTa, cardDuocSi, cardKyThuat, cardLeTan;
        private Label lblBacSiTitle, lblBacSiValue, lblBacSiIcon;
        private Label lblYTaTitle, lblYTaValue, lblYTaIcon;
        private Label lblDuocSiTitle, lblDuocSiValue, lblDuocSiIcon;
        private Label lblKyThuatTitle, lblKyThuatValue, lblKyThuatIcon;
        private Label lblLeTanTitle, lblLeTanValue, lblLeTanIcon;
        private Panel panelFilter;
        private TextBox txtSearch;
        private ComboBox cboChucVu;
        private Panel cardGrid;
        private DataGridView dgvEmployees;
        private Panel panelPaging;
        private Label lblPaging;
        private Panel sp1, sp2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}
