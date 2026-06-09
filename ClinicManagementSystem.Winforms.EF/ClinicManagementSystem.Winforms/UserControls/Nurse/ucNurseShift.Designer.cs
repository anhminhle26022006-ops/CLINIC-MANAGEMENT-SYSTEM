using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseShift
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootPanel = new Panel();
            statsPanel = new Panel();
            cardTotal = new Panel();
            lblTotalTitle = new Label();
            lblTotalShifts = new Label();
            cardToday = new Panel();
            lblTodayTitle = new Label();
            lblTodayShiftCount = new Label();
            cardHours = new Panel();
            lblHoursTitle = new Label();
            lblHours = new Label();
            toolbarPanel = new Panel();
            btnPrevWeek = new Button();
            dtpWeek = new DateTimePicker();
            btnNextWeek = new Button();
            btnRefresh = new Button();
            shiftCard = new Panel();
            dgvShifts = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colShift = new DataGridViewTextBoxColumn();
            colTime = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblShiftTitle = new Label();
            assignmentCard = new Panel();
            dgvAssignments = new DataGridView();
            colTask = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colPriority = new DataGridViewTextBoxColumn();
            colTaskStatus = new DataGridViewTextBoxColumn();
            lblAssignmentTitle = new Label();
            rootPanel.SuspendLayout();
            statsPanel.SuspendLayout();
            cardTotal.SuspendLayout();
            cardToday.SuspendLayout();
            cardHours.SuspendLayout();
            toolbarPanel.SuspendLayout();
            shiftCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvShifts).BeginInit();
            assignmentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.BackColor = Color.FromArgb(246, 248, 252);
            rootPanel.Controls.Add(assignmentCard);
            rootPanel.Controls.Add(shiftCard);
            rootPanel.Controls.Add(toolbarPanel);
            rootPanel.Controls.Add(statsPanel);
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Name = "rootPanel";
            rootPanel.Padding = new Padding(28, 22, 28, 28);
            rootPanel.Size = new Size(1180, 820);
            rootPanel.TabIndex = 0;
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.Transparent;
            statsPanel.Controls.Add(cardTotal);
            statsPanel.Controls.Add(cardToday);
            statsPanel.Controls.Add(cardHours);
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Location = new Point(28, 22);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(1124, 104);
            statsPanel.TabIndex = 0;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.White;
            cardTotal.Controls.Add(lblTotalTitle);
            cardTotal.Controls.Add(lblTotalShifts);
            cardTotal.Location = new Point(0, 0);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(280, 86);
            cardTotal.TabIndex = 0;
            cardTotal.Paint += Card_Paint;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Font = new Font("Segoe UI", 9.5F);
            lblTotalTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotalTitle.Location = new Point(18, 14);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(190, 22);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "Tổng ca trong tuần";
            // 
            // lblTotalShifts
            // 
            lblTotalShifts.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalShifts.ForeColor = Color.FromArgb(37, 99, 235);
            lblTotalShifts.Location = new Point(18, 34);
            lblTotalShifts.Name = "lblTotalShifts";
            lblTotalShifts.Size = new Size(120, 46);
            lblTotalShifts.TabIndex = 1;
            lblTotalShifts.Text = "0";
            // 
            // cardToday
            // 
            cardToday.BackColor = Color.FromArgb(240, 253, 244);
            cardToday.Controls.Add(lblTodayTitle);
            cardToday.Controls.Add(lblTodayShiftCount);
            cardToday.Location = new Point(298, 0);
            cardToday.Name = "cardToday";
            cardToday.Size = new Size(280, 86);
            cardToday.TabIndex = 1;
            cardToday.Paint += Card_Paint;
            // 
            // lblTodayTitle
            // 
            lblTodayTitle.Font = new Font("Segoe UI", 9.5F);
            lblTodayTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblTodayTitle.Location = new Point(18, 14);
            lblTodayTitle.Name = "lblTodayTitle";
            lblTodayTitle.Size = new Size(190, 22);
            lblTodayTitle.TabIndex = 0;
            lblTodayTitle.Text = "Ca hôm nay";
            // 
            // lblTodayShiftCount
            // 
            lblTodayShiftCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTodayShiftCount.ForeColor = Color.FromArgb(22, 163, 74);
            lblTodayShiftCount.Location = new Point(18, 34);
            lblTodayShiftCount.Name = "lblTodayShiftCount";
            lblTodayShiftCount.Size = new Size(120, 46);
            lblTodayShiftCount.TabIndex = 1;
            lblTodayShiftCount.Text = "0";
            // 
            // cardHours
            // 
            cardHours.BackColor = Color.FromArgb(255, 251, 235);
            cardHours.Controls.Add(lblHoursTitle);
            cardHours.Controls.Add(lblHours);
            cardHours.Location = new Point(596, 0);
            cardHours.Name = "cardHours";
            cardHours.Size = new Size(280, 86);
            cardHours.TabIndex = 2;
            cardHours.Paint += Card_Paint;
            // 
            // lblHoursTitle
            // 
            lblHoursTitle.Font = new Font("Segoe UI", 9.5F);
            lblHoursTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblHoursTitle.Location = new Point(18, 14);
            lblHoursTitle.Name = "lblHoursTitle";
            lblHoursTitle.Size = new Size(190, 22);
            lblHoursTitle.TabIndex = 0;
            lblHoursTitle.Text = "Giờ làm trong tuần";
            // 
            // lblHours
            // 
            lblHours.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblHours.ForeColor = Color.FromArgb(217, 119, 6);
            lblHours.Location = new Point(18, 34);
            lblHours.Name = "lblHours";
            lblHours.Size = new Size(140, 46);
            lblHours.TabIndex = 1;
            lblHours.Text = "0h";
            // 
            // toolbarPanel
            // 
            toolbarPanel.BackColor = Color.White;
            toolbarPanel.Controls.Add(btnPrevWeek);
            toolbarPanel.Controls.Add(dtpWeek);
            toolbarPanel.Controls.Add(btnNextWeek);
            toolbarPanel.Controls.Add(btnRefresh);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(28, 126);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(1124, 66);
            toolbarPanel.TabIndex = 1;
            toolbarPanel.Paint += Card_Paint;
            // 
            // btnPrevWeek
            // 
            btnPrevWeek.BackColor = Color.White;
            btnPrevWeek.Cursor = Cursors.Hand;
            btnPrevWeek.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnPrevWeek.FlatStyle = FlatStyle.Flat;
            btnPrevWeek.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnPrevWeek.Location = new Point(18, 16);
            btnPrevWeek.Name = "btnPrevWeek";
            btnPrevWeek.Size = new Size(94, 34);
            btnPrevWeek.TabIndex = 0;
            btnPrevWeek.Text = "Tuần trước";
            btnPrevWeek.UseVisualStyleBackColor = false;
            btnPrevWeek.Click += btnPrevWeek_Click;
            // 
            // dtpWeek
            // 
            dtpWeek.Font = new Font("Segoe UI", 10F);
            dtpWeek.Format = DateTimePickerFormat.Short;
            dtpWeek.Location = new Point(126, 17);
            dtpWeek.Name = "dtpWeek";
            dtpWeek.Size = new Size(160, 30);
            dtpWeek.TabIndex = 1;
            dtpWeek.ValueChanged += dtpWeek_ValueChanged;
            // 
            // btnNextWeek
            // 
            btnNextWeek.BackColor = Color.White;
            btnNextWeek.Cursor = Cursors.Hand;
            btnNextWeek.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnNextWeek.FlatStyle = FlatStyle.Flat;
            btnNextWeek.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNextWeek.Location = new Point(302, 16);
            btnNextWeek.Name = "btnNextWeek";
            btnNextWeek.Size = new Size(94, 34);
            btnNextWeek.TabIndex = 2;
            btnNextWeek.Text = "Tuần sau";
            btnNextWeek.UseVisualStyleBackColor = false;
            btnNextWeek.Click += btnNextWeek_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(986, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(108, 36);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // shiftCard
            // 
            shiftCard.BackColor = Color.White;
            shiftCard.Controls.Add(dgvShifts);
            shiftCard.Controls.Add(lblShiftTitle);
            shiftCard.Dock = DockStyle.Top;
            shiftCard.Location = new Point(28, 192);
            shiftCard.Name = "shiftCard";
            shiftCard.Size = new Size(1124, 310);
            shiftCard.TabIndex = 2;
            shiftCard.Paint += Card_Paint;
            // 
            // dgvShifts
            // 
            dgvShifts.AllowUserToAddRows = false;
            dgvShifts.AllowUserToDeleteRows = false;
            dgvShifts.BackgroundColor = Color.White;
            dgvShifts.BorderStyle = BorderStyle.None;
            dgvShifts.ColumnHeadersHeight = 44;
            dgvShifts.Columns.AddRange(new DataGridViewColumn[] { colDate, colShift, colTime, colDepartment, colRoom, colStatus });
            dgvShifts.Dock = DockStyle.Fill;
            dgvShifts.Location = new Point(0, 54);
            dgvShifts.Name = "dgvShifts";
            dgvShifts.RowHeadersVisible = false;
            dgvShifts.RowHeadersWidth = 51;
            dgvShifts.RowTemplate.Height = 48;
            dgvShifts.Size = new Size(1124, 256);
            dgvShifts.TabIndex = 1;
            // 
            // colDate
            // 
            colDate.FillWeight = 14F;
            colDate.HeaderText = "NGÀY";
            colDate.Name = "colDate";
            // 
            // colShift
            // 
            colShift.FillWeight = 16F;
            colShift.HeaderText = "CA";
            colShift.Name = "colShift";
            // 
            // colTime
            // 
            colTime.FillWeight = 16F;
            colTime.HeaderText = "GIỜ";
            colTime.Name = "colTime";
            // 
            // colDepartment
            // 
            colDepartment.FillWeight = 22F;
            colDepartment.HeaderText = "KHOA";
            colDepartment.Name = "colDepartment";
            // 
            // colRoom
            // 
            colRoom.FillWeight = 14F;
            colRoom.HeaderText = "PHÒNG";
            colRoom.Name = "colRoom";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 14F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Name = "colStatus";
            // 
            // lblShiftTitle
            // 
            lblShiftTitle.Dock = DockStyle.Top;
            lblShiftTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblShiftTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblShiftTitle.Location = new Point(0, 0);
            lblShiftTitle.Name = "lblShiftTitle";
            lblShiftTitle.Padding = new Padding(22, 14, 0, 0);
            lblShiftTitle.Size = new Size(1124, 54);
            lblShiftTitle.TabIndex = 0;
            lblShiftTitle.Text = "Danh sách ca trực";
            // 
            // assignmentCard
            // 
            assignmentCard.BackColor = Color.White;
            assignmentCard.Controls.Add(dgvAssignments);
            assignmentCard.Controls.Add(lblAssignmentTitle);
            assignmentCard.Dock = DockStyle.Fill;
            assignmentCard.Location = new Point(28, 502);
            assignmentCard.Name = "assignmentCard";
            assignmentCard.Size = new Size(1124, 290);
            assignmentCard.TabIndex = 3;
            assignmentCard.Paint += Card_Paint;
            // 
            // dgvAssignments
            // 
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.AllowUserToDeleteRows = false;
            dgvAssignments.BackgroundColor = Color.White;
            dgvAssignments.BorderStyle = BorderStyle.None;
            dgvAssignments.ColumnHeadersHeight = 44;
            dgvAssignments.Columns.AddRange(new DataGridViewColumn[] { colTask, colPatient, colPriority, colTaskStatus });
            dgvAssignments.Dock = DockStyle.Fill;
            dgvAssignments.Location = new Point(0, 54);
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.RowHeadersVisible = false;
            dgvAssignments.RowHeadersWidth = 51;
            dgvAssignments.RowTemplate.Height = 48;
            dgvAssignments.Size = new Size(1124, 236);
            dgvAssignments.TabIndex = 1;
            // 
            // colTask
            // 
            colTask.FillWeight = 38F;
            colTask.HeaderText = "CÔNG VIỆC";
            colTask.Name = "colTask";
            // 
            // colPatient
            // 
            colPatient.FillWeight = 26F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.Name = "colPatient";
            // 
            // colPriority
            // 
            colPriority.FillWeight = 16F;
            colPriority.HeaderText = "ƯU TIÊN";
            colPriority.Name = "colPriority";
            // 
            // colTaskStatus
            // 
            colTaskStatus.FillWeight = 18F;
            colTaskStatus.HeaderText = "TRẠNG THÁI";
            colTaskStatus.Name = "colTaskStatus";
            // 
            // lblAssignmentTitle
            // 
            lblAssignmentTitle.Dock = DockStyle.Top;
            lblAssignmentTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAssignmentTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblAssignmentTitle.Location = new Point(0, 0);
            lblAssignmentTitle.Name = "lblAssignmentTitle";
            lblAssignmentTitle.Padding = new Padding(22, 14, 0, 0);
            lblAssignmentTitle.Size = new Size(1124, 54);
            lblAssignmentTitle.TabIndex = 0;
            lblAssignmentTitle.Text = "Phân công trong tuần";
            // 
            // ucNurseShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 252);
            Controls.Add(rootPanel);
            Name = "ucNurseShift";
            Size = new Size(1180, 820);
            rootPanel.ResumeLayout(false);
            statsPanel.ResumeLayout(false);
            cardTotal.ResumeLayout(false);
            cardToday.ResumeLayout(false);
            cardHours.ResumeLayout(false);
            toolbarPanel.ResumeLayout(false);
            shiftCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvShifts).EndInit();
            assignmentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            ResumeLayout(false);
        }

        private Panel rootPanel;
        private Panel statsPanel;
        private Panel cardTotal;
        private Panel cardToday;
        private Panel cardHours;
        private Label lblTotalTitle;
        private Label lblTotalShifts;
        private Label lblTodayTitle;
        private Label lblTodayShiftCount;
        private Label lblHoursTitle;
        private Label lblHours;
        private Panel toolbarPanel;
        private Button btnPrevWeek;
        private DateTimePicker dtpWeek;
        private Button btnNextWeek;
        private Button btnRefresh;
        private Panel shiftCard;
        private DataGridView dgvShifts;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colShift;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colStatus;
        private Label lblShiftTitle;
        private Panel assignmentCard;
        private DataGridView dgvAssignments;
        private DataGridViewTextBoxColumn colTask;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colPriority;
        private DataGridViewTextBoxColumn colTaskStatus;
        private Label lblAssignmentTitle;
    }
}
