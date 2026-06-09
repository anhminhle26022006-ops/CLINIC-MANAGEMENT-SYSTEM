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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();

            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnAddShift = new Button();
            panelKPI = new Panel();
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
            panelFilter.SuspendLayout();
            panelViewBtns.SuspendLayout();
            cardGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShifts).BeginInit();
            panelPaging.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ───────────────────────────────────────────
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAddShift);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1221, 88);

            panelHeader.TabIndex = 5;
            panelHeader.Resize += panelHeader_Resize;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Quản lý ca làm việc";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Lên lịch trực cho toàn bộ nhân viên y tế";

            btnAddShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddShift.BackColor = Color.FromArgb(47, 94, 240);
            btnAddShift.Cursor = Cursors.Hand;
            btnAddShift.FlatAppearance.BorderSize = 0;
            btnAddShift.FlatStyle = FlatStyle.Flat;
            btnAddShift.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddShift.ForeColor = Color.White;
            btnAddShift.Location = new Point(971, 19);
            btnAddShift.Name = "btnAddShift";
            btnAddShift.Size = new Size(200, 50);
            btnAddShift.Text = "+ Thêm ca trực";
            btnAddShift.UseVisualStyleBackColor = false;
            btnAddShift.Click += btnAddShift_Click;

            // ── panelKPI ──────────────────────────────────────────────
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Name = "panelKPI";

            panelKPI.Size = new Size(1221, 138);
            panelKPI.TabIndex = 4;
            panelKPI.Resize += panelKPI_Resize;

            cardOnDuty = MakeKpiCard("Đang trực hôm nay", "0",
                Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254));
            cardMorning = MakeKpiCard("Ca sáng", "0",
                Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229));
            cardAfternoon = MakeKpiCard("Ca chiều", "0",
                Color.FromArgb(234, 88, 12), Color.FromArgb(254, 215, 170));
            cardNight = MakeKpiCard("Ca tối", "0",
                Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254));

            panelKPI.Controls.Add(cardOnDuty);
            panelKPI.Controls.Add(cardMorning);
            panelKPI.Controls.Add(cardAfternoon);
            panelKPI.Controls.Add(cardNight);

            // ── panelFilter ───────────────────────────────────────────
            panelFilter.BackColor = Color.White;

            panelFilter.Controls.Add(dtpDate);
            panelFilter.Controls.Add(cboEmployee);
            panelFilter.Controls.Add(panelViewBtns);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1221, 75);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += PanelRoundedBorder;

            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Location = new Point(20, 22);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(200, 30);
            dtpDate.ValueChanged += dtpDate_ValueChanged;

            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Font = new Font("Segoe UI", 10F);
            cboEmployee.Location = new Point(240, 20);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(249, 36);
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;

            // View buttons group
            panelViewBtns.BackColor = Color.Transparent;
            panelViewBtns.Location = new Point(510, 18);
            panelViewBtns.Name = "panelViewBtns";
            panelViewBtns.Size = new Size(252, 38);
            panelViewBtns.Controls.Add(btnViewDay);
            panelViewBtns.Controls.Add(btnViewWeek);
            panelViewBtns.Controls.Add(btnViewMonth);

            btnViewDay.BackColor = Color.FromArgb(37, 99, 235);
            btnViewDay.ForeColor = Color.White;
            btnViewDay.FlatStyle = FlatStyle.Flat;
            btnViewDay.FlatAppearance.BorderSize = 0;
            btnViewDay.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewDay.Location = new Point(0, 0);
            btnViewDay.Name = "btnViewDay";
            btnViewDay.Size = new Size(80, 36);
            btnViewDay.Text = "Ngày";
            btnViewDay.Cursor = Cursors.Hand;

            btnViewWeek.BackColor = Color.White;
            btnViewWeek.ForeColor = Color.FromArgb(55, 65, 81);
            btnViewWeek.FlatStyle = FlatStyle.Flat;
            btnViewWeek.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnViewWeek.Font = new Font("Segoe UI", 9.5F);
            btnViewWeek.Location = new Point(84, 0);
            btnViewWeek.Name = "btnViewWeek";
            btnViewWeek.Size = new Size(80, 36);
            btnViewWeek.Text = "Tuần";
            btnViewWeek.Cursor = Cursors.Hand;

            btnViewMonth.BackColor = Color.White;
            btnViewMonth.ForeColor = Color.FromArgb(55, 65, 81);
            btnViewMonth.FlatStyle = FlatStyle.Flat;
            btnViewMonth.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnViewMonth.Font = new Font("Segoe UI", 9.5F);
            btnViewMonth.Location = new Point(168, 0);
            btnViewMonth.Name = "btnViewMonth";
            btnViewMonth.Size = new Size(80, 36);
            btnViewMonth.Text = "Tháng";
            btnViewMonth.Cursor = Cursors.Hand;

            // ── cardGrid ──────────────────────────────────────────────
            cardGrid.BackColor = Color.White;
            cardGrid.Margin = new Padding(-30, 0, -30, 0);
            cardGrid.Controls.Add(dgvShifts);
            cardGrid.Controls.Add(panelPaging);
            cardGrid.Dock = DockStyle.Fill;
            cardGrid.Name = "cardGrid";
            cardGrid.TabIndex = 0;

            // ── dgvShifts ─────────────────────────────────────────────
            dgvShifts.AllowUserToAddRows = false;
            dgvShifts.AllowUserToDeleteRows = false;
            dgvShifts.AutoGenerateColumns = false;
            dgvShifts.BackgroundColor = Color.White;
            dgvShifts.BorderStyle = BorderStyle.None;
            dgvShifts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = Color.FromArgb(249, 250, 251);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.ForeColor = Color.FromArgb(107, 114, 128);
            headerStyle.WrapMode = DataGridViewTriState.True;
            dgvShifts.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvShifts.ColumnHeadersHeight = 44;
            dgvShifts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvShifts.EnableHeadersVisualStyles = false;

            rowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            rowStyle.BackColor = SystemColors.Window;
            rowStyle.Font = new Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = SystemColors.ControlText;
            rowStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            rowStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            rowStyle.WrapMode = DataGridViewTriState.False;
            dgvShifts.DefaultCellStyle = rowStyle;

            dgvShifts.Cursor = Cursors.Hand;
            dgvShifts.Dock = DockStyle.Fill;
            dgvShifts.GridColor = Color.FromArgb(229, 231, 235);
            dgvShifts.Name = "dgvShifts";
            dgvShifts.ReadOnly = true;
            dgvShifts.RowHeadersVisible = false;
            dgvShifts.RowTemplate.Height = 56;
            dgvShifts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvShifts.CellClick += dgvShifts_CellClick;
            dgvShifts.CellFormatting += dgvShifts_CellFormatting;
            dgvShifts.CellPainting += dgvShifts_CellPainting;

            // Columns
            dgvShifts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmpName", HeaderText = "NHÂN VIÊN", FillWeight = 20 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "VAI TRÒ", FillWeight = 12 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDept", HeaderText = "KHOA/PHÒNG", FillWeight = 16 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colShift", HeaderText = "CA TRỰC", FillWeight = 10 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "GIỜ LÀM VIỆC", FillWeight = 14 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoom", HeaderText = "PHÒNG", FillWeight = 9 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colShiftStatus", HeaderText = "TRẠNG THÁI", FillWeight = 12 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEdit", HeaderText = "", FillWeight = 4, ReadOnly = true });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDelete", HeaderText = "THAO TÁC", FillWeight = 4, ReadOnly = true });

            dgvShifts.Columns["colEmpName"].DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5F, FontStyle.Bold);

            // ── panelPaging ───────────────────────────────────────────
            panelPaging.BackColor = Color.White;
            panelPaging.Controls.Add(lblPaging);
            panelPaging.Dock = DockStyle.Bottom;
            panelPaging.Name = "panelPaging";
            panelPaging.Size = new Size(1221, 45);
            panelPaging.TabIndex = 1;

            lblPaging.AutoSize = true;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.Location = new Point(15, 12);
            lblPaging.Name = "lblPaging";

            // ── spacers ───────────────────────────────────────────────
            sp1.BackColor = Color.Transparent;
            sp1.Dock = DockStyle.Top;
            sp1.Name = "sp1";
            sp1.Size = new Size(1221, 15);
            sp1.TabIndex = 3;

            sp2.BackColor = Color.Transparent;
            sp2.Dock = DockStyle.Top;
            sp2.Name = "sp2";
            sp2.Size = new Size(1221, 15);
            sp2.TabIndex = 1;

            // ── ucShiftManagement ─────────────────────────────────────
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(cardGrid);
            Controls.Add(sp2);
            Controls.Add(panelFilter);
            Controls.Add(sp1);
            Controls.Add(panelKPI);
            Controls.Add(panelHeader);
            Padding = new Padding(30, 25, 30, 0);
            Size = new Size(1281, 1084);
            Name = "ucShiftManagement";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelFilter.ResumeLayout(false);
            panelViewBtns.ResumeLayout(false);
            cardGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShifts).EndInit();
            panelPaging.ResumeLayout(false);
            panelPaging.PerformLayout();
            ResumeLayout(false);
        }

        private Panel MakeKpiCard(string title, string value, Color valueColor, Color bgColor)
        {
            var card = new Panel { BackColor = bgColor, Size = new Size(220, 100) };
            card.Paint += new PaintEventHandler(this.PanelRoundedBorder);
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = valueColor,
                AutoSize = true,
                Location = new Point(16, 14)
            });
            card.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 24F, FontStyle.Bold),
                ForeColor = valueColor,
                AutoSize = true,
                Location = new Point(16, 40)
            });
            return card;
        }

        private void panelHeader_Resize(object sender, System.EventArgs e)
        {
            if (btnAddShift != null)
                btnAddShift.Location = new Point(panelHeader.Width - btnAddShift.Width, 19);
        }
        private void PanelRoundedBorder(object sender, PaintEventArgs e)
        {
            if (sender is not Control c) return;
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
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
    }
}
