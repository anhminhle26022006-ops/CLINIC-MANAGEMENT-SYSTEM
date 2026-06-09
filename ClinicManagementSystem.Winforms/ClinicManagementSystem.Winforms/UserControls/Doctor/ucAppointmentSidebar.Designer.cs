namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    partial class ucAppointmentSidebar
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;

        private FlowLayoutPanel pnlStatistics;

        private Panel pnlToday;
        private Panel pnlWaiting;
        private Panel pnlExamining;
        private Panel pnlCompleted;

        private Label lblTodayTitle;
        private Label lblTodayCount;

        private Label lblWaitingTitle;
        private Label lblWaitingCount;

        private Label lblExaminingTitle;
        private Label lblExaminingCount;

        private Label lblCompletedTitle;
        private Label lblCompletedCount;

        private Panel pnlFilter;
        private TextBox txtSearch;
        private DateTimePicker dtpDate;

        private Panel pnlGrid;
        private DataGridView dgvAppointments;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlStatistics = new FlowLayoutPanel();
            pnlToday = new Panel();
            lblTodayTitle = new Label();
            lblTodayCount = new Label();
            pnlWaiting = new Panel();
            lblWaitingTitle = new Label();
            lblWaitingCount = new Label();
            pnlExamining = new Panel();
            lblExaminingTitle = new Label();
            lblExaminingCount = new Label();
            pnlCompleted = new Panel();
            lblCompletedTitle = new Label();
            lblCompletedCount = new Label();
            pnlFilter = new Panel();
            txtSearch = new TextBox();
            dtpDate = new DateTimePicker();
            pnlGrid = new Panel();
            dgvAppointments = new DataGridView();
            btnExamine = new DataGridViewButtonColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            btnExamine = new DataGridViewButtonColumn();
            dataGridViewTextBoxColumn1.Name = "colTime";
            dataGridViewTextBoxColumn1.HeaderText = "Giờ khám";

            dataGridViewTextBoxColumn2.Name = "colPatient";
            dataGridViewTextBoxColumn2.HeaderText = "Bệnh nhân";

            dataGridViewTextBoxColumn3.Name = "colDepartment";
            dataGridViewTextBoxColumn3.HeaderText = "Chuyên khoa";

            dataGridViewTextBoxColumn4.Name = "colVital";
            dataGridViewTextBoxColumn4.HeaderText = "Chỉ số";

            dataGridViewTextBoxColumn5.Name = "colStatus";
            dataGridViewTextBoxColumn5.HeaderText = "Trạng thái";
            
            pnlHeader.SuspendLayout();
            pnlStatistics.SuspendLayout();
            pnlToday.SuspendLayout();
            pnlWaiting.SuspendLayout();
            pnlExamining.SuspendLayout();
            pnlCompleted.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1200, 90);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
            lblTitle.Location = new Point(20, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(177, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lịch khám";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(24, 52);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(235, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Quản lý lịch khám bệnh nhân";
            // 
            // pnlStatistics
            // 
            pnlStatistics.Controls.Add(pnlToday);
            pnlStatistics.Controls.Add(pnlWaiting);
            pnlStatistics.Controls.Add(pnlExamining);
            pnlStatistics.Controls.Add(pnlCompleted);
            pnlStatistics.Dock = DockStyle.Top;
            pnlStatistics.Location = new Point(0, 90);
            pnlStatistics.Name = "pnlStatistics";
            pnlStatistics.Padding = new Padding(15, 10, 15, 10);
            pnlStatistics.Size = new Size(1200, 120);
            pnlStatistics.TabIndex = 2;
            pnlStatistics.WrapContents = false;
            // 
            // pnlToday
            // 
            pnlToday.BackColor = Color.White;
            pnlToday.Controls.Add(lblTodayTitle);
            pnlToday.Controls.Add(lblTodayCount);
            pnlToday.Location = new Point(20, 15);
            pnlToday.Margin = new Padding(5);
            pnlToday.Name = "pnlToday";
            pnlToday.Size = new Size(270, 90);
            pnlToday.TabIndex = 0;
            // 
            // lblTodayTitle
            // 
            lblTodayTitle.AutoSize = true;
            lblTodayTitle.Font = new Font("Segoe UI", 10F);
            lblTodayTitle.ForeColor = Color.Gray;
            lblTodayTitle.Location = new Point(20, 18);
            lblTodayTitle.Name = "lblTodayTitle";
            lblTodayTitle.Size = new Size(79, 23);
            lblTodayTitle.TabIndex = 0;
            lblTodayTitle.Text = "Hôm nay";
            // 
            // lblTodayCount
            // 
            lblTodayCount.AutoSize = true;
            lblTodayCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTodayCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblTodayCount.Location = new Point(18, 35);
            lblTodayCount.Name = "lblTodayCount";
            lblTodayCount.Size = new Size(85, 50);
            lblTodayCount.TabIndex = 1;
            lblTodayCount.Text = "125";
            // 
            // pnlWaiting
            // 
            pnlWaiting.BackColor = Color.White;
            pnlWaiting.Controls.Add(lblWaitingTitle);
            pnlWaiting.Controls.Add(lblWaitingCount);
            pnlWaiting.Location = new Point(300, 15);
            pnlWaiting.Margin = new Padding(5);
            pnlWaiting.Name = "pnlWaiting";
            pnlWaiting.Size = new Size(270, 90);
            pnlWaiting.TabIndex = 1;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.AutoSize = true;
            lblWaitingTitle.Font = new Font("Segoe UI", 10F);
            lblWaitingTitle.ForeColor = Color.Gray;
            lblWaitingTitle.Location = new Point(20, 18);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(119, 23);
            lblWaitingTitle.TabIndex = 0;
            lblWaitingTitle.Text = "Chờ tiếp nhận";
            // 
            // lblWaitingCount
            // 
            lblWaitingCount.AutoSize = true;
            lblWaitingCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWaitingCount.ForeColor = Color.FromArgb(245, 158, 11);
            lblWaitingCount.Location = new Point(18, 35);
            lblWaitingCount.Name = "lblWaitingCount";
            lblWaitingCount.Size = new Size(64, 50);
            lblWaitingCount.TabIndex = 1;
            lblWaitingCount.Text = "42";
            // 
            // pnlExamining
            // 
            pnlExamining.BackColor = Color.White;
            pnlExamining.Controls.Add(lblExaminingTitle);
            pnlExamining.Controls.Add(lblExaminingCount);
            pnlExamining.Location = new Point(580, 15);
            pnlExamining.Margin = new Padding(5);
            pnlExamining.Name = "pnlExamining";
            pnlExamining.Size = new Size(270, 90);
            pnlExamining.TabIndex = 2;
            // 
            // lblExaminingTitle
            // 
            lblExaminingTitle.AutoSize = true;
            lblExaminingTitle.Font = new Font("Segoe UI", 10F);
            lblExaminingTitle.ForeColor = Color.Gray;
            lblExaminingTitle.Location = new Point(20, 18);
            lblExaminingTitle.Name = "lblExaminingTitle";
            lblExaminingTitle.Size = new Size(98, 23);
            lblExaminingTitle.TabIndex = 0;
            lblExaminingTitle.Text = "Đang khám";
            // 
            // lblExaminingCount
            // 
            lblExaminingCount.AutoSize = true;
            lblExaminingCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblExaminingCount.ForeColor = Color.FromArgb(16, 185, 129);
            lblExaminingCount.Location = new Point(18, 35);
            lblExaminingCount.Name = "lblExaminingCount";
            lblExaminingCount.Size = new Size(64, 50);
            lblExaminingCount.TabIndex = 1;
            lblExaminingCount.Text = "18";
            // 
            // pnlCompleted
            // 
            pnlCompleted.BackColor = Color.White;
            pnlCompleted.Controls.Add(lblCompletedTitle);
            pnlCompleted.Controls.Add(lblCompletedCount);
            pnlCompleted.Location = new Point(860, 15);
            pnlCompleted.Margin = new Padding(5);
            pnlCompleted.Name = "pnlCompleted";
            pnlCompleted.Size = new Size(270, 90);
            pnlCompleted.TabIndex = 3;
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.AutoSize = true;
            lblCompletedTitle.Font = new Font("Segoe UI", 10F);
            lblCompletedTitle.ForeColor = Color.Gray;
            lblCompletedTitle.Location = new Point(20, 18);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(101, 23);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Text = "Hoàn thành";
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblCompletedCount.ForeColor = Color.Gray;
            lblCompletedCount.Location = new Point(18, 35);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(64, 50);
            lblCompletedCount.TabIndex = 1;
            lblCompletedCount.Text = "65";
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(dtpDate);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 210);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(20, 15, 20, 15);
            pnlFilter.Size = new Size(1200, 70);
            pnlFilter.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(20, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm bệnh nhân...";
            txtSearch.Size = new Size(775, 30);
            txtSearch.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Location = new Point(829, 18);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(301, 30);
            dtpDate.TabIndex = 1;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvAppointments);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 280);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20);
            pnlGrid.Size = new Size(1200, 470);
            pnlGrid.TabIndex = 0;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToResizeRows = false;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAppointments.ColumnHeadersHeight = 45;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, btnExamine });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAppointments.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.Location = new Point(20, 20);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.RowTemplate.Height = 42;
            dgvAppointments.Size = new Size(1160, 430);
            dgvAppointments.TabIndex = 0;
            // 
            // btnExamine
            // 
            btnExamine.HeaderText = "Thao tác";
            btnExamine.MinimumWidth = 6;
            btnExamine.Name = "btnExamine";
            btnExamine.Text = "Khám";
            btnExamine.UseColumnTextForButtonValue = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // ucAppointmentSidebar
            // 
            BackColor = Color.FromArgb(248, 250, 252);
            Controls.Add(pnlGrid);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStatistics);
            Controls.Add(pnlHeader);
            Name = "ucAppointmentSidebar";
            Size = new Size(1200, 750);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlStatistics.ResumeLayout(false);
            pnlToday.ResumeLayout(false);
            pnlToday.PerformLayout();
            pnlWaiting.ResumeLayout(false);
            pnlWaiting.PerformLayout();
            pnlExamining.ResumeLayout(false);
            pnlExamining.PerformLayout();
            pnlCompleted.ResumeLayout(false);
            pnlCompleted.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewButtonColumn btnExamine;
    }
}
