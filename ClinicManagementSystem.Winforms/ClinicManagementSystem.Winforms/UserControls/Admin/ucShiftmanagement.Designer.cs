using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucShiftManagement
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
            btnAddShift = new Button();
            panelKPI = new Panel();
            cardOnDuty = new Panel();
            lblOnDutyTitle = new Label();
            lblOnDutyValue = new Label();
            lblOnDutyIcon = new Label();
            cardMorning = new Panel();
            lblMorningTitle = new Label();
            lblMorningValue = new Label();
            lblMorningIcon = new Label();
            cardAfternoon = new Panel();
            lblAfternoonTitle = new Label();
            lblAfternoonValue = new Label();
            lblAfternoonIcon = new Label();
            cardNight = new Panel();
            lblNightTitle = new Label();
            lblNightValue = new Label();
            lblNightIcon = new Label();
            panelFilter = new Panel();
            dtpDate = new DateTimePicker();
            cboEmployee = new ComboBox();
            panelViewBtns = new Panel();
            btnViewDay = new Button();
            btnViewWeek = new Button();
            btnViewMonth = new Button();
            cardGrid = new Panel();
            dgvShifts = new DataGridView();
            panelPaging = new Panel();
            lblPaging = new Label();
            sp1 = new Panel();
            sp2 = new Panel();
            panelHeader.SuspendLayout();
            panelKPI.SuspendLayout();
            cardOnDuty.SuspendLayout();
            cardMorning.SuspendLayout();
            cardAfternoon.SuspendLayout();
            cardNight.SuspendLayout();
            panelFilter.SuspendLayout();
            panelViewBtns.SuspendLayout();
            cardGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShifts).BeginInit();
            panelPaging.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAddShift);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(24, 20);
            panelHeader.Margin = new Padding(2);
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
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý ca làm việc";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 40);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(314, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Lên lịch trực cho toàn bộ nhân viên y tế";
            // 
            // btnAddShift
            // 
            btnAddShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddShift.BackColor = Color.FromArgb(47, 94, 240);
            btnAddShift.Cursor = Cursors.Hand;
            btnAddShift.FlatAppearance.BorderSize = 0;
            btnAddShift.FlatStyle = FlatStyle.Flat;
            btnAddShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddShift.ForeColor = Color.White;
            btnAddShift.Location = new Point(777, 15);
            btnAddShift.Margin = new Padding(2);
            btnAddShift.Name = "btnAddShift";
            btnAddShift.Size = new Size(160, 40);
            btnAddShift.TabIndex = 2;
            btnAddShift.Text = "+ Thêm ca trực";
            btnAddShift.UseVisualStyleBackColor = false;
            btnAddShift.Click += btnAddShift_Click;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Controls.Add(cardOnDuty);
            panelKPI.Controls.Add(cardMorning);
            panelKPI.Controls.Add(cardAfternoon);
            panelKPI.Controls.Add(cardNight);
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(24, 90);
            panelKPI.Margin = new Padding(2);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(977, 110);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;
            // 
            // cardOnDuty
            // 
            cardOnDuty.BackColor = Color.FromArgb(219, 234, 254);
            cardOnDuty.Controls.Add(lblOnDutyTitle);
            cardOnDuty.Controls.Add(lblOnDutyValue);
            cardOnDuty.Controls.Add(lblOnDutyIcon);
            cardOnDuty.Location = new Point(0, 11);
            cardOnDuty.Margin = new Padding(2);
            cardOnDuty.Name = "cardOnDuty";
            cardOnDuty.Size = new Size(176, 80);
            cardOnDuty.TabIndex = 0;
            cardOnDuty.Paint += PanelRoundedBorder;
            // 
            // lblOnDutyTitle
            // 
            lblOnDutyTitle.Font = new Font("Segoe UI", 9F);
            lblOnDutyTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblOnDutyTitle.Location = new Point(13, 11);
            lblOnDutyTitle.Margin = new Padding(2, 0, 2, 0);
            lblOnDutyTitle.Name = "lblOnDutyTitle";
            lblOnDutyTitle.Size = new Size(106, 19);
            lblOnDutyTitle.TabIndex = 0;
            lblOnDutyTitle.Text = "Đang trực hôm nay";
            // 
            // lblOnDutyValue
            // 
            lblOnDutyValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblOnDutyValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblOnDutyValue.Location = new Point(13, 30);
            lblOnDutyValue.Margin = new Padding(2, 0, 2, 0);
            lblOnDutyValue.Name = "lblOnDutyValue";
            lblOnDutyValue.Size = new Size(88, 44);
            lblOnDutyValue.TabIndex = 1;
            lblOnDutyValue.Text = "0";
            // 
            // lblOnDutyIcon
            // 
            lblOnDutyIcon.BackColor = Color.White;
            lblOnDutyIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOnDutyIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblOnDutyIcon.Location = new Point(126, 18);
            lblOnDutyIcon.Margin = new Padding(2, 0, 2, 0);
            lblOnDutyIcon.Name = "lblOnDutyIcon";
            lblOnDutyIcon.Size = new Size(37, 37);
            lblOnDutyIcon.TabIndex = 2;
            lblOnDutyIcon.Text = "TT";
            lblOnDutyIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardMorning
            // 
            cardMorning.BackColor = Color.FromArgb(209, 250, 229);
            cardMorning.Controls.Add(lblMorningTitle);
            cardMorning.Controls.Add(lblMorningValue);
            cardMorning.Controls.Add(lblMorningIcon);
            cardMorning.Location = new Point(189, 11);
            cardMorning.Margin = new Padding(2);
            cardMorning.Name = "cardMorning";
            cardMorning.Size = new Size(176, 80);
            cardMorning.TabIndex = 1;
            cardMorning.Paint += PanelRoundedBorder;
            // 
            // lblMorningTitle
            // 
            lblMorningTitle.Font = new Font("Segoe UI", 9F);
            lblMorningTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblMorningTitle.Location = new Point(13, 11);
            lblMorningTitle.Margin = new Padding(2, 0, 2, 0);
            lblMorningTitle.Name = "lblMorningTitle";
            lblMorningTitle.Size = new Size(104, 19);
            lblMorningTitle.TabIndex = 0;
            lblMorningTitle.Text = "Ca sáng";
            // 
            // lblMorningValue
            // 
            lblMorningValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMorningValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblMorningValue.Location = new Point(13, 30);
            lblMorningValue.Margin = new Padding(2, 0, 2, 0);
            lblMorningValue.Name = "lblMorningValue";
            lblMorningValue.Size = new Size(88, 44);
            lblMorningValue.TabIndex = 1;
            lblMorningValue.Text = "0";
            // 
            // lblMorningIcon
            // 
            lblMorningIcon.BackColor = Color.White;
            lblMorningIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMorningIcon.ForeColor = Color.FromArgb(5, 150, 105);
            lblMorningIcon.Location = new Point(126, 18);
            lblMorningIcon.Margin = new Padding(2, 0, 2, 0);
            lblMorningIcon.Name = "lblMorningIcon";
            lblMorningIcon.Size = new Size(37, 37);
            lblMorningIcon.TabIndex = 2;
            lblMorningIcon.Text = "SA";
            lblMorningIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardAfternoon
            // 
            cardAfternoon.BackColor = Color.FromArgb(254, 215, 170);
            cardAfternoon.Controls.Add(lblAfternoonTitle);
            cardAfternoon.Controls.Add(lblAfternoonValue);
            cardAfternoon.Controls.Add(lblAfternoonIcon);
            cardAfternoon.Location = new Point(378, 11);
            cardAfternoon.Margin = new Padding(2);
            cardAfternoon.Name = "cardAfternoon";
            cardAfternoon.Size = new Size(176, 80);
            cardAfternoon.TabIndex = 2;
            cardAfternoon.Paint += PanelRoundedBorder;
            // 
            // lblAfternoonTitle
            // 
            lblAfternoonTitle.Font = new Font("Segoe UI", 9F);
            lblAfternoonTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblAfternoonTitle.Location = new Point(13, 11);
            lblAfternoonTitle.Margin = new Padding(2, 0, 2, 0);
            lblAfternoonTitle.Name = "lblAfternoonTitle";
            lblAfternoonTitle.Size = new Size(104, 19);
            lblAfternoonTitle.TabIndex = 0;
            lblAfternoonTitle.Text = "Ca chiều";
            // 
            // lblAfternoonValue
            // 
            lblAfternoonValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAfternoonValue.ForeColor = Color.FromArgb(234, 88, 12);
            lblAfternoonValue.Location = new Point(13, 30);
            lblAfternoonValue.Margin = new Padding(2, 0, 2, 0);
            lblAfternoonValue.Name = "lblAfternoonValue";
            lblAfternoonValue.Size = new Size(88, 44);
            lblAfternoonValue.TabIndex = 1;
            lblAfternoonValue.Text = "0";
            // 
            // lblAfternoonIcon
            // 
            lblAfternoonIcon.BackColor = Color.White;
            lblAfternoonIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAfternoonIcon.ForeColor = Color.FromArgb(234, 88, 12);
            lblAfternoonIcon.Location = new Point(126, 18);
            lblAfternoonIcon.Margin = new Padding(2, 0, 2, 0);
            lblAfternoonIcon.Name = "lblAfternoonIcon";
            lblAfternoonIcon.Size = new Size(37, 37);
            lblAfternoonIcon.TabIndex = 2;
            lblAfternoonIcon.Text = "CH";
            lblAfternoonIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardNight
            // 
            cardNight.BackColor = Color.FromArgb(237, 233, 254);
            cardNight.Controls.Add(lblNightTitle);
            cardNight.Controls.Add(lblNightValue);
            cardNight.Controls.Add(lblNightIcon);
            cardNight.Location = new Point(566, 11);
            cardNight.Margin = new Padding(2);
            cardNight.Name = "cardNight";
            cardNight.Size = new Size(176, 80);
            cardNight.TabIndex = 3;
            cardNight.Paint += PanelRoundedBorder;
            // 
            // lblNightTitle
            // 
            lblNightTitle.Font = new Font("Segoe UI", 9F);
            lblNightTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblNightTitle.Location = new Point(13, 11);
            lblNightTitle.Margin = new Padding(2, 0, 2, 0);
            lblNightTitle.Name = "lblNightTitle";
            lblNightTitle.Size = new Size(104, 19);
            lblNightTitle.TabIndex = 0;
            lblNightTitle.Text = "Ca tối";
            // 
            // lblNightValue
            // 
            lblNightValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblNightValue.ForeColor = Color.FromArgb(124, 58, 237);
            lblNightValue.Location = new Point(13, 30);
            lblNightValue.Margin = new Padding(2, 0, 2, 0);
            lblNightValue.Name = "lblNightValue";
            lblNightValue.Size = new Size(88, 44);
            lblNightValue.TabIndex = 1;
            lblNightValue.Text = "0";
            // 
            // lblNightIcon
            // 
            lblNightIcon.BackColor = Color.White;
            lblNightIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNightIcon.ForeColor = Color.FromArgb(124, 58, 237);
            lblNightIcon.Location = new Point(126, 18);
            lblNightIcon.Margin = new Padding(2, 0, 2, 0);
            lblNightIcon.Name = "lblNightIcon";
            lblNightIcon.Size = new Size(37, 37);
            lblNightIcon.TabIndex = 2;
            lblNightIcon.Text = "TO";
            lblNightIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFilter
            // 
            panelFilter.BackColor = Color.White;
            panelFilter.Controls.Add(dtpDate);
            panelFilter.Controls.Add(cboEmployee);
            panelFilter.Controls.Add(panelViewBtns);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(24, 212);
            panelFilter.Margin = new Padding(2);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(977, 60);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += PanelRoundedBorder;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(16, 18);
            dtpDate.Margin = new Padding(2);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(161, 30);
            dtpDate.TabIndex = 0;
            dtpDate.ValueChanged += dtpDate_ValueChanged;
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Font = new Font("Segoe UI", 10F);
            cboEmployee.Location = new Point(192, 16);
            cboEmployee.Margin = new Padding(2);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(200, 31);
            cboEmployee.TabIndex = 1;
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
            // 
            // panelViewBtns
            // 
            panelViewBtns.BackColor = Color.Transparent;
            panelViewBtns.Controls.Add(btnViewDay);
            panelViewBtns.Controls.Add(btnViewWeek);
            panelViewBtns.Controls.Add(btnViewMonth);
            panelViewBtns.Location = new Point(408, 14);
            panelViewBtns.Margin = new Padding(2);
            panelViewBtns.Name = "panelViewBtns";
            panelViewBtns.Size = new Size(202, 30);
            panelViewBtns.TabIndex = 2;
            // 
            // btnViewDay
            // 
            btnViewDay.BackColor = Color.FromArgb(37, 99, 235);
            btnViewDay.Cursor = Cursors.Hand;
            btnViewDay.FlatAppearance.BorderSize = 0;
            btnViewDay.FlatStyle = FlatStyle.Flat;
            btnViewDay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewDay.ForeColor = Color.White;
            btnViewDay.Location = new Point(0, 0);
            btnViewDay.Margin = new Padding(2);
            btnViewDay.Name = "btnViewDay";
            btnViewDay.Size = new Size(64, 29);
            btnViewDay.TabIndex = 0;
            btnViewDay.Text = "Ngày";
            btnViewDay.UseVisualStyleBackColor = false;
            // 
            // btnViewWeek
            // 
            btnViewWeek.BackColor = Color.White;
            btnViewWeek.Cursor = Cursors.Hand;
            btnViewWeek.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnViewWeek.FlatStyle = FlatStyle.Flat;
            btnViewWeek.Font = new Font("Segoe UI", 9.5F);
            btnViewWeek.ForeColor = Color.FromArgb(55, 65, 81);
            btnViewWeek.Location = new Point(67, 0);
            btnViewWeek.Margin = new Padding(2);
            btnViewWeek.Name = "btnViewWeek";
            btnViewWeek.Size = new Size(64, 29);
            btnViewWeek.TabIndex = 1;
            btnViewWeek.Text = "Tuần";
            btnViewWeek.UseVisualStyleBackColor = false;
            // 
            // btnViewMonth
            // 
            btnViewMonth.BackColor = Color.White;
            btnViewMonth.Cursor = Cursors.Hand;
            btnViewMonth.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnViewMonth.FlatStyle = FlatStyle.Flat;
            btnViewMonth.Font = new Font("Segoe UI", 9.5F);
            btnViewMonth.ForeColor = Color.FromArgb(55, 65, 81);
            btnViewMonth.Location = new Point(134, 0);
            btnViewMonth.Margin = new Padding(2);
            btnViewMonth.Name = "btnViewMonth";
            btnViewMonth.Size = new Size(64, 29);
            btnViewMonth.TabIndex = 2;
            btnViewMonth.Text = "Tháng";
            btnViewMonth.UseVisualStyleBackColor = false;
            // 
            // cardGrid
            // 
            cardGrid.BackColor = Color.White;
            cardGrid.Controls.Add(dgvShifts);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Location = new Point(24, 284);
            cardGrid.Margin = new Padding(0);
            cardGrid.Name = "cardGrid";
            cardGrid.Size = new Size(977, 583);
            cardGrid.TabIndex = 0;
            // 
            // dgvShifts
            // 
            dgvShifts.AllowUserToAddRows = false;
            dgvShifts.AllowUserToDeleteRows = false;
            dgvShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShifts.BackgroundColor = Color.White;
            dgvShifts.BorderStyle = BorderStyle.None;
            dgvShifts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvShifts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvShifts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvShifts.ColumnHeadersHeight = 44;
            dgvShifts.Cursor = Cursors.Hand;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvShifts.DefaultCellStyle = dataGridViewCellStyle2;
            dgvShifts.Dock = DockStyle.Fill;
            dgvShifts.EnableHeadersVisualStyles = false;
            dgvShifts.GridColor = Color.FromArgb(229, 231, 235);
            dgvShifts.Location = new Point(0, 0);
            dgvShifts.Margin = new Padding(2);
            dgvShifts.Name = "dgvShifts";
            dgvShifts.ReadOnly = true;
            dgvShifts.RowHeadersVisible = false;
            dgvShifts.RowHeadersWidth = 51;
            dgvShifts.RowTemplate.Height = 56;
            dgvShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShifts.Size = new Size(977, 547);
            dgvShifts.TabIndex = 0;
            dgvShifts.CellClick += dgvShifts_CellClick;
            dgvShifts.CellContentClick += dgvShifts_CellContentClick;
            dgvShifts.CellFormatting += dgvShifts_CellFormatting;
            dgvShifts.CellPainting += dgvShifts_CellPainting;
            // 
            // panelPaging
            // 
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Location = new Point(0, 547);
            panelPaging.Margin = new Padding(2);
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
            lblPaging.Margin = new Padding(2, 0, 2, 0);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(0, 20);
            lblPaging.TabIndex = 0;
            // 
            // sp1
            // 
            sp1.BackColor = Color.Transparent;
            sp1.Dock = DockStyle.Top;
            sp1.Location = new Point(24, 200);
            sp1.Margin = new Padding(2);
            sp1.Name = "sp1";
            sp1.Size = new Size(977, 12);
            sp1.TabIndex = 3;
            // 
            // sp2
            // 
            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Location = new Point(24, 272);
            sp2.Margin = new Padding(2);
            sp2.Name = "sp2";
            sp2.Size = new Size(977, 12);
            sp2.TabIndex = 1;
            // 
            // ucShiftManagement
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
            Margin = new Padding(2);
            Name = "ucShiftManagement";
            Padding = new Padding(24, 20, 24, 0);
            Size = new Size(1025, 867);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelKPI.ResumeLayout(false);
            cardOnDuty.ResumeLayout(false);
            cardMorning.ResumeLayout(false);
            cardAfternoon.ResumeLayout(false);
            cardNight.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelViewBtns.ResumeLayout(false);
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShifts).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private void panelHeader_Resize(object sender, System.EventArgs e)
        {
            if (btnAddShift != null)
                btnAddShift.Location = new Point(panelHeader.Width - btnAddShift.Width, 19);
        }

        private void PanelRoundedBorder(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            var p = sender as Panel;
            using (var pen = new System.Drawing.Pen(Color.FromArgb(229, 231, 235), 1))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
            }
        }

        // ── Fields ────────────────────────────────────────────────────
        private Panel panelHeader, panelKPI, panelFilter, panelViewBtns, cardGrid, panelPaging;
        private Panel sp1, sp2;
        private Label lblTitle, lblSubtitle, lblPaging;
        private Button btnAddShift, btnViewDay, btnViewWeek, btnViewMonth;
        private DateTimePicker dtpDate;
        private ComboBox cboEmployee;
        private DataGridView dgvShifts;
        internal Panel cardOnDuty, cardMorning, cardAfternoon, cardNight;
        private Label lblOnDutyTitle, lblOnDutyValue, lblOnDutyIcon;
        private Label lblMorningTitle, lblMorningValue, lblMorningIcon;
        private Label lblAfternoonTitle, lblAfternoonValue, lblAfternoonIcon;
        private Label lblNightTitle, lblNightValue, lblNightIcon;
    }
}
