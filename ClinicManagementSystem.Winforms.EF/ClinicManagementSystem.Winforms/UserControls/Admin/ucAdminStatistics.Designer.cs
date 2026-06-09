namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucAdminStatistics
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            outerScroll = new Panel();
            contentFlow = new FlowLayoutPanel();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblMonth = new Label();
            dtpMonth = new DateTimePicker();
            btnRefresh = new Button();
            kpiFlow = new Panel();
            cardPatients = new Panel();
            lblTotalPatientsTitle = new Label();
            lblTotalPatientsValue = new Label();
            lblPatientTrend = new Label();
            lblPatientsIcon = new Label();
            cardAppointments = new Panel();
            lblMonthlyAppointmentsTitle = new Label();
            lblMonthlyAppointmentsValue = new Label();
            lblAppointmentTrend = new Label();
            lblAppointmentsIcon = new Label();
            cardRevenue = new Panel();
            lblMonthlyRevenueTitle = new Label();
            lblMonthlyRevenueValue = new Label();
            lblRevenueTrend = new Label();
            lblRevenueIcon = new Label();
            cardToday = new Panel();
            lblTodayAppointmentsTitle = new Label();
            lblTodayAppointmentsValue = new Label();
            lblTodayStatus = new Label();
            lblTodayIcon = new Label();
            cardStaff = new Panel();
            lblActiveStaffTitle = new Label();
            lblActiveStaffValue = new Label();
            lblMedicineStatus = new Label();
            lblStaffIcon = new Label();
            chartFlow = new FlowLayoutPanel();
            patientChartCard = new Panel();
            lblPatientChartTitle = new Label();
            pnlPatientChart = new Panel();
            revenueChartCard = new Panel();
            lblRevenueChartTitle = new Label();
            pnlRevenueChart = new Panel();
            insightFlow = new FlowLayoutPanel();
            appointmentCard = new Panel();
            dgvAppointments = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblAppointmentTitle = new Label();
            sidePanel = new Panel();
            medicineCard = new Panel();
            medicineFlow = new FlowLayoutPanel();
            lblMedicineTitle = new Label();
            departmentCard = new Panel();
            departmentFlow = new FlowLayoutPanel();
            lblDepartmentTitle = new Label();
            queueCard = new Panel();
            queueFlow = new FlowLayoutPanel();
            lblQueueTitle = new Label();
            outerScroll.SuspendLayout();
            contentFlow.SuspendLayout();
            headerPanel.SuspendLayout();
            kpiFlow.SuspendLayout();
            cardPatients.SuspendLayout();
            cardAppointments.SuspendLayout();
            cardRevenue.SuspendLayout();
            cardToday.SuspendLayout();
            cardStaff.SuspendLayout();
            chartFlow.SuspendLayout();
            patientChartCard.SuspendLayout();
            revenueChartCard.SuspendLayout();
            insightFlow.SuspendLayout();
            appointmentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            sidePanel.SuspendLayout();
            medicineCard.SuspendLayout();
            departmentCard.SuspendLayout();
            queueCard.SuspendLayout();
            SuspendLayout();
            // 
            // outerScroll
            // 
            outerScroll.AutoScroll = true;
            outerScroll.BackColor = Color.FromArgb(247, 249, 252);
            outerScroll.Controls.Add(contentFlow);
            outerScroll.Dock = DockStyle.Fill;
            outerScroll.Location = new Point(0, 0);
            outerScroll.Name = "outerScroll";
            outerScroll.Size = new Size(1280, 840);
            outerScroll.TabIndex = 0;
            outerScroll.Resize += outerScroll_Resize;
            // 
            // contentFlow
            // 
            contentFlow.AutoSize = true;
            contentFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            contentFlow.BackColor = Color.FromArgb(247, 249, 252);
            contentFlow.Controls.Add(headerPanel);
            contentFlow.Controls.Add(kpiFlow);
            contentFlow.Controls.Add(chartFlow);
            contentFlow.Controls.Add(insightFlow);
            contentFlow.Dock = DockStyle.Top;
            contentFlow.FlowDirection = FlowDirection.TopDown;
            contentFlow.Location = new Point(0, 0);
            contentFlow.Name = "contentFlow";
            contentFlow.Padding = new Padding(28, 24, 28, 32);
            contentFlow.Size = new Size(1259, 1090);
            contentFlow.TabIndex = 0;
            contentFlow.WrapContents = false;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(247, 249, 252);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblMonth);
            headerPanel.Controls.Add(dtpMonth);
            headerPanel.Controls.Add(btnRefresh);
            headerPanel.Location = new Point(28, 24);
            headerPanel.Margin = new Padding(0, 0, 0, 20);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1200, 74);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, -3);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(197, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Thống kê";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(4, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(350, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Tổng quan số liệu hoạt động phòng khám";
            // 
            // lblMonth
            // 
            lblMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblMonth.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMonth.ForeColor = Color.FromArgb(75, 85, 99);
            lblMonth.Location = new Point(761, 18);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(58, 32);
            lblMonth.TabIndex = 2;
            lblMonth.Text = "Tháng";
            lblMonth.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpMonth
            // 
            dtpMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpMonth.CustomFormat = "MM/yyyy";
            dtpMonth.Font = new Font("Segoe UI", 10F);
            dtpMonth.Format = DateTimePickerFormat.Custom;
            dtpMonth.Location = new Point(825, 17);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.ShowUpDown = true;
            dtpMonth.Size = new Size(140, 30);
            dtpMonth.TabIndex = 3;
            dtpMonth.ValueChanged += dtpMonth_ValueChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(984, 13);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(216, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Làm mới dữ liệu";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // kpiFlow
            // 
            kpiFlow.BackColor = Color.FromArgb(247, 249, 252);
            kpiFlow.Controls.Add(cardPatients);
            kpiFlow.Controls.Add(cardAppointments);
            kpiFlow.Controls.Add(cardRevenue);
            kpiFlow.Controls.Add(cardToday);
            kpiFlow.Controls.Add(cardStaff);
            kpiFlow.Location = new Point(28, 118);
            kpiFlow.Margin = new Padding(0, 0, 0, 22);
            kpiFlow.Name = "kpiFlow";
            kpiFlow.Size = new Size(1200, 150);
            kpiFlow.TabIndex = 1;
            // 
            // cardPatients
            // 
            cardPatients.BackColor = Color.FromArgb(239, 246, 255);
            cardPatients.Controls.Add(lblTotalPatientsTitle);
            cardPatients.Controls.Add(lblTotalPatientsValue);
            cardPatients.Controls.Add(lblPatientTrend);
            cardPatients.Controls.Add(lblPatientsIcon);
            cardPatients.Location = new Point(0, 0);
            cardPatients.Margin = new Padding(0, 0, 16, 16);
            cardPatients.Name = "cardPatients";
            cardPatients.Size = new Size(224, 134);
            cardPatients.TabIndex = 0;
            cardPatients.Paint += Card_Paint;
            // 
            // lblTotalPatientsTitle
            // 
            lblTotalPatientsTitle.Font = new Font("Segoe UI", 9F);
            lblTotalPatientsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalPatientsTitle.Location = new Point(16, 14);
            lblTotalPatientsTitle.Name = "lblTotalPatientsTitle";
            lblTotalPatientsTitle.Size = new Size(135, 24);
            lblTotalPatientsTitle.TabIndex = 0;
            lblTotalPatientsTitle.Text = "Tổng bệnh nhân";
            // 
            // lblTotalPatientsValue
            // 
            lblTotalPatientsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalPatientsValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblTotalPatientsValue.Location = new Point(16, 46);
            lblTotalPatientsValue.Name = "lblTotalPatientsValue";
            lblTotalPatientsValue.Size = new Size(120, 57);
            lblTotalPatientsValue.TabIndex = 1;
            lblTotalPatientsValue.Text = "0";
            // 
            // lblPatientTrend
            // 
            lblPatientTrend.Font = new Font("Segoe UI", 8.5F);
            lblPatientTrend.ForeColor = Color.FromArgb(100, 116, 139);
            lblPatientTrend.Location = new Point(16, 103);
            lblPatientTrend.Name = "lblPatientTrend";
            lblPatientTrend.Size = new Size(190, 22);
            lblPatientTrend.TabIndex = 2;
            lblPatientTrend.Text = "Đang cập nhật";
            // 
            // lblPatientsIcon
            // 
            lblPatientsIcon.BackColor = Color.White;
            lblPatientsIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPatientsIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblPatientsIcon.Location = new Point(162, 22);
            lblPatientsIcon.Name = "lblPatientsIcon";
            lblPatientsIcon.Size = new Size(46, 46);
            lblPatientsIcon.TabIndex = 3;
            lblPatientsIcon.Text = "BN";
            lblPatientsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardAppointments
            // 
            cardAppointments.BackColor = Color.FromArgb(236, 253, 245);
            cardAppointments.Controls.Add(lblMonthlyAppointmentsTitle);
            cardAppointments.Controls.Add(lblMonthlyAppointmentsValue);
            cardAppointments.Controls.Add(lblAppointmentTrend);
            cardAppointments.Controls.Add(lblAppointmentsIcon);
            cardAppointments.Location = new Point(240, 0);
            cardAppointments.Margin = new Padding(0, 0, 16, 16);
            cardAppointments.Name = "cardAppointments";
            cardAppointments.Size = new Size(224, 134);
            cardAppointments.TabIndex = 1;
            cardAppointments.Paint += Card_Paint;
            // 
            // lblMonthlyAppointmentsTitle
            // 
            lblMonthlyAppointmentsTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyAppointmentsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblMonthlyAppointmentsTitle.Location = new Point(16, 14);
            lblMonthlyAppointmentsTitle.Name = "lblMonthlyAppointmentsTitle";
            lblMonthlyAppointmentsTitle.Size = new Size(145, 24);
            lblMonthlyAppointmentsTitle.TabIndex = 0;
            lblMonthlyAppointmentsTitle.Text = "Lịch khám tháng này";
            // 
            // lblMonthlyAppointmentsValue
            // 
            lblMonthlyAppointmentsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMonthlyAppointmentsValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblMonthlyAppointmentsValue.Location = new Point(16, 46);
            lblMonthlyAppointmentsValue.Name = "lblMonthlyAppointmentsValue";
            lblMonthlyAppointmentsValue.Size = new Size(120, 57);
            lblMonthlyAppointmentsValue.TabIndex = 1;
            lblMonthlyAppointmentsValue.Text = "0";
            // 
            // lblAppointmentTrend
            // 
            lblAppointmentTrend.Font = new Font("Segoe UI", 8.5F);
            lblAppointmentTrend.ForeColor = Color.FromArgb(100, 116, 139);
            lblAppointmentTrend.Location = new Point(16, 103);
            lblAppointmentTrend.Name = "lblAppointmentTrend";
            lblAppointmentTrend.Size = new Size(190, 22);
            lblAppointmentTrend.TabIndex = 2;
            lblAppointmentTrend.Text = "Đang cập nhật";
            // 
            // lblAppointmentsIcon
            // 
            lblAppointmentsIcon.BackColor = Color.White;
            lblAppointmentsIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAppointmentsIcon.ForeColor = Color.FromArgb(5, 150, 105);
            lblAppointmentsIcon.Location = new Point(162, 22);
            lblAppointmentsIcon.Name = "lblAppointmentsIcon";
            lblAppointmentsIcon.Size = new Size(46, 46);
            lblAppointmentsIcon.TabIndex = 3;
            lblAppointmentsIcon.Text = "LK";
            lblAppointmentsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardRevenue
            // 
            cardRevenue.BackColor = Color.FromArgb(250, 245, 255);
            cardRevenue.Controls.Add(lblMonthlyRevenueTitle);
            cardRevenue.Controls.Add(lblMonthlyRevenueValue);
            cardRevenue.Controls.Add(lblRevenueTrend);
            cardRevenue.Controls.Add(lblRevenueIcon);
            cardRevenue.Location = new Point(480, 0);
            cardRevenue.Margin = new Padding(0, 0, 16, 16);
            cardRevenue.Name = "cardRevenue";
            cardRevenue.Size = new Size(224, 134);
            cardRevenue.TabIndex = 2;
            cardRevenue.Paint += Card_Paint;
            // 
            // lblMonthlyRevenueTitle
            // 
            lblMonthlyRevenueTitle.Font = new Font("Segoe UI", 9F);
            lblMonthlyRevenueTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblMonthlyRevenueTitle.Location = new Point(16, 14);
            lblMonthlyRevenueTitle.Name = "lblMonthlyRevenueTitle";
            lblMonthlyRevenueTitle.Size = new Size(145, 24);
            lblMonthlyRevenueTitle.TabIndex = 0;
            lblMonthlyRevenueTitle.Text = "Doanh thu tháng này";
            // 
            // lblMonthlyRevenueValue
            // 
            lblMonthlyRevenueValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMonthlyRevenueValue.ForeColor = Color.FromArgb(147, 51, 234);
            lblMonthlyRevenueValue.Location = new Point(16, 46);
            lblMonthlyRevenueValue.Name = "lblMonthlyRevenueValue";
            lblMonthlyRevenueValue.Size = new Size(120, 57);
            lblMonthlyRevenueValue.TabIndex = 1;
            lblMonthlyRevenueValue.Text = "0";
            // 
            // lblRevenueTrend
            // 
            lblRevenueTrend.Font = new Font("Segoe UI", 8.5F);
            lblRevenueTrend.ForeColor = Color.FromArgb(100, 116, 139);
            lblRevenueTrend.Location = new Point(16, 103);
            lblRevenueTrend.Name = "lblRevenueTrend";
            lblRevenueTrend.Size = new Size(190, 22);
            lblRevenueTrend.TabIndex = 2;
            lblRevenueTrend.Text = "Đang cập nhật";
            // 
            // lblRevenueIcon
            // 
            lblRevenueIcon.BackColor = Color.White;
            lblRevenueIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRevenueIcon.ForeColor = Color.FromArgb(147, 51, 234);
            lblRevenueIcon.Location = new Point(162, 22);
            lblRevenueIcon.Name = "lblRevenueIcon";
            lblRevenueIcon.Size = new Size(46, 46);
            lblRevenueIcon.TabIndex = 3;
            lblRevenueIcon.Text = "DT";
            lblRevenueIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardToday
            // 
            cardToday.BackColor = Color.FromArgb(255, 247, 237);
            cardToday.Controls.Add(lblTodayAppointmentsTitle);
            cardToday.Controls.Add(lblTodayAppointmentsValue);
            cardToday.Controls.Add(lblTodayStatus);
            cardToday.Controls.Add(lblTodayIcon);
            cardToday.Location = new Point(720, 0);
            cardToday.Margin = new Padding(0, 0, 16, 16);
            cardToday.Name = "cardToday";
            cardToday.Size = new Size(224, 134);
            cardToday.TabIndex = 3;
            cardToday.Paint += Card_Paint;
            // 
            // lblTodayAppointmentsTitle
            // 
            lblTodayAppointmentsTitle.Font = new Font("Segoe UI", 9F);
            lblTodayAppointmentsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblTodayAppointmentsTitle.Location = new Point(16, 14);
            lblTodayAppointmentsTitle.Name = "lblTodayAppointmentsTitle";
            lblTodayAppointmentsTitle.Size = new Size(145, 24);
            lblTodayAppointmentsTitle.TabIndex = 0;
            lblTodayAppointmentsTitle.Text = "Lịch khám hôm nay";
            // 
            // lblTodayAppointmentsValue
            // 
            lblTodayAppointmentsValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTodayAppointmentsValue.ForeColor = Color.FromArgb(234, 88, 12);
            lblTodayAppointmentsValue.Location = new Point(16, 46);
            lblTodayAppointmentsValue.Name = "lblTodayAppointmentsValue";
            lblTodayAppointmentsValue.Size = new Size(120, 57);
            lblTodayAppointmentsValue.TabIndex = 1;
            lblTodayAppointmentsValue.Text = "0";
            // 
            // lblTodayStatus
            // 
            lblTodayStatus.Font = new Font("Segoe UI", 8.5F);
            lblTodayStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblTodayStatus.Location = new Point(18, 103);
            lblTodayStatus.Name = "lblTodayStatus";
            lblTodayStatus.Size = new Size(190, 22);
            lblTodayStatus.TabIndex = 2;
            lblTodayStatus.Text = "Đang cập nhật";
            // 
            // lblTodayIcon
            // 
            lblTodayIcon.BackColor = Color.White;
            lblTodayIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTodayIcon.ForeColor = Color.FromArgb(234, 88, 12);
            lblTodayIcon.Location = new Point(162, 22);
            lblTodayIcon.Name = "lblTodayIcon";
            lblTodayIcon.Size = new Size(46, 46);
            lblTodayIcon.TabIndex = 3;
            lblTodayIcon.Text = "HN";
            lblTodayIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardStaff
            // 
            cardStaff.BackColor = Color.FromArgb(240, 253, 250);
            cardStaff.Controls.Add(lblActiveStaffTitle);
            cardStaff.Controls.Add(lblActiveStaffValue);
            cardStaff.Controls.Add(lblMedicineStatus);
            cardStaff.Controls.Add(lblStaffIcon);
            cardStaff.Location = new Point(960, 0);
            cardStaff.Margin = new Padding(0, 0, 16, 16);
            cardStaff.Name = "cardStaff";
            cardStaff.Size = new Size(224, 134);
            cardStaff.TabIndex = 4;
            cardStaff.Paint += Card_Paint;
            // 
            // lblActiveStaffTitle
            // 
            lblActiveStaffTitle.Font = new Font("Segoe UI", 9F);
            lblActiveStaffTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblActiveStaffTitle.Location = new Point(16, 14);
            lblActiveStaffTitle.Name = "lblActiveStaffTitle";
            lblActiveStaffTitle.Size = new Size(145, 24);
            lblActiveStaffTitle.TabIndex = 0;
            lblActiveStaffTitle.Text = "Nhân sự hoạt động";
            // 
            // lblActiveStaffValue
            // 
            lblActiveStaffValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblActiveStaffValue.ForeColor = Color.FromArgb(15, 118, 110);
            lblActiveStaffValue.Location = new Point(16, 46);
            lblActiveStaffValue.Name = "lblActiveStaffValue";
            lblActiveStaffValue.Size = new Size(120, 57);
            lblActiveStaffValue.TabIndex = 1;
            lblActiveStaffValue.Text = "0";
            // 
            // lblMedicineStatus
            // 
            lblMedicineStatus.Font = new Font("Segoe UI", 8.5F);
            lblMedicineStatus.ForeColor = Color.FromArgb(100, 116, 139);
            lblMedicineStatus.Location = new Point(18, 103);
            lblMedicineStatus.Name = "lblMedicineStatus";
            lblMedicineStatus.Size = new Size(190, 22);
            lblMedicineStatus.TabIndex = 2;
            lblMedicineStatus.Text = "Đang cập nhật";
            // 
            // lblStaffIcon
            // 
            lblStaffIcon.BackColor = Color.White;
            lblStaffIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStaffIcon.ForeColor = Color.FromArgb(15, 118, 110);
            lblStaffIcon.Location = new Point(162, 22);
            lblStaffIcon.Name = "lblStaffIcon";
            lblStaffIcon.Size = new Size(46, 46);
            lblStaffIcon.TabIndex = 3;
            lblStaffIcon.Text = "NS";
            lblStaffIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chartFlow
            // 
            chartFlow.BackColor = Color.FromArgb(247, 249, 252);
            chartFlow.Controls.Add(patientChartCard);
            chartFlow.Controls.Add(revenueChartCard);
            chartFlow.Location = new Point(28, 290);
            chartFlow.Margin = new Padding(0, 0, 0, 22);
            chartFlow.Name = "chartFlow";
            chartFlow.Size = new Size(1200, 330);
            chartFlow.TabIndex = 2;
            // 
            // patientChartCard
            // 
            patientChartCard.BackColor = Color.White;
            patientChartCard.Controls.Add(lblPatientChartTitle);
            patientChartCard.Controls.Add(pnlPatientChart);
            patientChartCard.Location = new Point(0, 0);
            patientChartCard.Margin = new Padding(0, 0, 20, 0);
            patientChartCard.Name = "patientChartCard";
            patientChartCard.Size = new Size(590, 330);
            patientChartCard.TabIndex = 0;
            patientChartCard.Paint += Card_Paint;
            // 
            // lblPatientChartTitle
            // 
            lblPatientChartTitle.Dock = DockStyle.Top;
            lblPatientChartTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPatientChartTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientChartTitle.Location = new Point(0, 0);
            lblPatientChartTitle.Name = "lblPatientChartTitle";
            lblPatientChartTitle.Padding = new Padding(24, 18, 0, 0);
            lblPatientChartTitle.Size = new Size(590, 58);
            lblPatientChartTitle.TabIndex = 0;
            lblPatientChartTitle.Text = "Bệnh nhân mới theo tháng";
            // 
            // pnlPatientChart
            // 
            pnlPatientChart.BackColor = Color.White;
            pnlPatientChart.Dock = DockStyle.Fill;
            pnlPatientChart.Location = new Point(0, 0);
            pnlPatientChart.Name = "pnlPatientChart";
            pnlPatientChart.Padding = new Padding(22, 0, 22, 16);
            pnlPatientChart.Size = new Size(590, 330);
            pnlPatientChart.TabIndex = 1;
            pnlPatientChart.Paint += pnlPatientChart_Paint;
            // 
            // revenueChartCard
            // 
            revenueChartCard.BackColor = Color.White;
            revenueChartCard.Controls.Add(lblRevenueChartTitle);
            revenueChartCard.Controls.Add(pnlRevenueChart);
            revenueChartCard.Location = new Point(610, 0);
            revenueChartCard.Margin = new Padding(0);
            revenueChartCard.Name = "revenueChartCard";
            revenueChartCard.Size = new Size(590, 330);
            revenueChartCard.TabIndex = 1;
            revenueChartCard.Paint += Card_Paint;
            // 
            // lblRevenueChartTitle
            // 
            lblRevenueChartTitle.Dock = DockStyle.Top;
            lblRevenueChartTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRevenueChartTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblRevenueChartTitle.Location = new Point(0, 0);
            lblRevenueChartTitle.Name = "lblRevenueChartTitle";
            lblRevenueChartTitle.Padding = new Padding(24, 18, 0, 0);
            lblRevenueChartTitle.Size = new Size(590, 58);
            lblRevenueChartTitle.TabIndex = 0;
            lblRevenueChartTitle.Text = "Doanh thu theo tháng";
            // 
            // pnlRevenueChart
            // 
            pnlRevenueChart.BackColor = Color.White;
            pnlRevenueChart.Dock = DockStyle.Fill;
            pnlRevenueChart.Location = new Point(0, 0);
            pnlRevenueChart.Name = "pnlRevenueChart";
            pnlRevenueChart.Padding = new Padding(22, 0, 22, 16);
            pnlRevenueChart.Size = new Size(590, 330);
            pnlRevenueChart.TabIndex = 1;
            pnlRevenueChart.Paint += pnlRevenueChart_Paint;
            // 
            // insightFlow
            // 
            insightFlow.BackColor = Color.FromArgb(247, 249, 252);
            insightFlow.Controls.Add(appointmentCard);
            insightFlow.Controls.Add(sidePanel);
            insightFlow.Location = new Point(28, 642);
            insightFlow.Margin = new Padding(0);
            insightFlow.Name = "insightFlow";
            insightFlow.Size = new Size(1200, 416);
            insightFlow.TabIndex = 3;
            // 
            // appointmentCard
            // 
            appointmentCard.BackColor = Color.White;
            appointmentCard.Controls.Add(dgvAppointments);
            appointmentCard.Controls.Add(lblAppointmentTitle);
            appointmentCard.Location = new Point(0, 0);
            appointmentCard.Margin = new Padding(0, 0, 20, 0);
            appointmentCard.Name = "appointmentCard";
            appointmentCard.Size = new Size(760, 416);
            appointmentCard.TabIndex = 0;
            appointmentCard.Paint += Card_Paint;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(75, 85, 99);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(243, 244, 246);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(75, 85, 99);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAppointments.ColumnHeadersHeight = 42;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colTime, colPatient, colDoctor, colDepartment, colStatus });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(31, 41, 55);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAppointments.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.EnableHeadersVisualStyles = false;
            dgvAppointments.GridColor = Color.FromArgb(229, 231, 235);
            dgvAppointments.Location = new Point(0, 58);
            dgvAppointments.MultiSelect = false;
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.RowTemplate.Height = 46;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(760, 358);
            dgvAppointments.TabIndex = 1;
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            // 
            // colTime
            // 
            colTime.FillWeight = 11F;
            colTime.HeaderText = "GIỜ";
            colTime.MinimumWidth = 60;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colPatient
            // 
            colPatient.FillWeight = 24F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.MinimumWidth = 120;
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 24F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.MinimumWidth = 120;
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colDepartment
            // 
            colDepartment.FillWeight = 22F;
            colDepartment.HeaderText = "CHUYÊN KHOA";
            colDepartment.MinimumWidth = 120;
            colDepartment.Name = "colDepartment";
            colDepartment.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 19F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.MinimumWidth = 110;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblAppointmentTitle
            // 
            lblAppointmentTitle.Dock = DockStyle.Top;
            lblAppointmentTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAppointmentTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblAppointmentTitle.Location = new Point(0, 0);
            lblAppointmentTitle.Name = "lblAppointmentTitle";
            lblAppointmentTitle.Padding = new Padding(24, 18, 0, 0);
            lblAppointmentTitle.Size = new Size(760, 58);
            lblAppointmentTitle.TabIndex = 0;
            lblAppointmentTitle.Text = "Lịch khám hôm nay";
            // 
            // sidePanel
            // 
            sidePanel.BackColor = Color.FromArgb(247, 249, 252);
            sidePanel.Controls.Add(medicineCard);
            sidePanel.Controls.Add(departmentCard);
            sidePanel.Controls.Add(queueCard);
            sidePanel.Location = new Point(780, 0);
            sidePanel.Margin = new Padding(0);
            sidePanel.Name = "sidePanel";
            sidePanel.Size = new Size(420, 416);
            sidePanel.TabIndex = 1;
            // 
            // medicineCard
            // 
            medicineCard.BackColor = Color.White;
            medicineCard.Controls.Add(medicineFlow);
            medicineCard.Controls.Add(lblMedicineTitle);
            medicineCard.Location = new Point(0, 292);
            medicineCard.Name = "medicineCard";
            medicineCard.Size = new Size(420, 124);
            medicineCard.TabIndex = 2;
            medicineCard.Paint += Card_Paint;
            // 
            // medicineFlow
            // 
            medicineFlow.BackColor = Color.White;
            medicineFlow.Dock = DockStyle.Fill;
            medicineFlow.FlowDirection = FlowDirection.TopDown;
            medicineFlow.Location = new Point(0, 44);
            medicineFlow.Name = "medicineFlow";
            medicineFlow.Padding = new Padding(18, 0, 18, 12);
            medicineFlow.Size = new Size(420, 80);
            medicineFlow.TabIndex = 1;
            medicineFlow.WrapContents = false;
            // 
            // lblMedicineTitle
            // 
            lblMedicineTitle.Dock = DockStyle.Top;
            lblMedicineTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMedicineTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedicineTitle.Location = new Point(0, 0);
            lblMedicineTitle.Name = "lblMedicineTitle";
            lblMedicineTitle.Padding = new Padding(18, 12, 0, 0);
            lblMedicineTitle.Size = new Size(420, 44);
            lblMedicineTitle.TabIndex = 0;
            lblMedicineTitle.Text = "Thuốc sắp hết";
            // 
            // departmentCard
            // 
            departmentCard.BackColor = Color.White;
            departmentCard.Controls.Add(departmentFlow);
            departmentCard.Controls.Add(lblDepartmentTitle);
            departmentCard.Location = new Point(0, 144);
            departmentCard.Name = "departmentCard";
            departmentCard.Size = new Size(420, 128);
            departmentCard.TabIndex = 1;
            departmentCard.Paint += Card_Paint;
            // 
            // departmentFlow
            // 
            departmentFlow.BackColor = Color.White;
            departmentFlow.Dock = DockStyle.Fill;
            departmentFlow.FlowDirection = FlowDirection.TopDown;
            departmentFlow.Location = new Point(0, 44);
            departmentFlow.Name = "departmentFlow";
            departmentFlow.Padding = new Padding(18, 0, 18, 12);
            departmentFlow.Size = new Size(420, 84);
            departmentFlow.TabIndex = 1;
            departmentFlow.WrapContents = false;
            // 
            // lblDepartmentTitle
            // 
            lblDepartmentTitle.Dock = DockStyle.Top;
            lblDepartmentTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDepartmentTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblDepartmentTitle.Location = new Point(0, 0);
            lblDepartmentTitle.Name = "lblDepartmentTitle";
            lblDepartmentTitle.Padding = new Padding(18, 12, 0, 0);
            lblDepartmentTitle.Size = new Size(420, 44);
            lblDepartmentTitle.TabIndex = 0;
            lblDepartmentTitle.Text = "Chuyên khoa nổi bật";
            // 
            // queueCard
            // 
            queueCard.BackColor = Color.White;
            queueCard.Controls.Add(queueFlow);
            queueCard.Controls.Add(lblQueueTitle);
            queueCard.Location = new Point(0, 0);
            queueCard.Name = "queueCard";
            queueCard.Size = new Size(420, 124);
            queueCard.TabIndex = 0;
            queueCard.Paint += Card_Paint;
            // 
            // queueFlow
            // 
            queueFlow.BackColor = Color.White;
            queueFlow.Dock = DockStyle.Fill;
            queueFlow.Location = new Point(0, 44);
            queueFlow.Name = "queueFlow";
            queueFlow.Padding = new Padding(18, 0, 18, 12);
            queueFlow.Size = new Size(420, 80);
            queueFlow.TabIndex = 1;
            queueFlow.WrapContents = false;
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.Dock = DockStyle.Top;
            lblQueueTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblQueueTitle.Location = new Point(0, 0);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Padding = new Padding(18, 12, 0, 0);
            lblQueueTitle.Size = new Size(420, 44);
            lblQueueTitle.TabIndex = 0;
            lblQueueTitle.Text = "Hàng đợi khám";
            // 
            // ucAdminStatistics
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(outerScroll);
            Font = new Font("Segoe UI", 9F);
            Name = "ucAdminStatistics";
            Size = new Size(1280, 840);
            Load += ucAdminStatistics_Load;
            outerScroll.ResumeLayout(false);
            outerScroll.PerformLayout();
            contentFlow.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            kpiFlow.ResumeLayout(false);
            cardPatients.ResumeLayout(false);
            cardAppointments.ResumeLayout(false);
            cardRevenue.ResumeLayout(false);
            cardToday.ResumeLayout(false);
            cardStaff.ResumeLayout(false);
            chartFlow.ResumeLayout(false);
            patientChartCard.ResumeLayout(false);
            revenueChartCard.ResumeLayout(false);
            insightFlow.ResumeLayout(false);
            appointmentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            sidePanel.ResumeLayout(false);
            medicineCard.ResumeLayout(false);
            departmentCard.ResumeLayout(false);
            queueCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private void AddQueueChip(string title, int value, Color valueColor, Color backgroundColor)
        {
            Panel chip = new Panel
            {
                BackColor = backgroundColor,
                Margin = new Padding(0, 0, 10, 0),
                Size = new Size(86, 58)
            };

            chip.Controls.Add(new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location = new Point(8, 6),
                Size = new Size(70, 18),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            });

            chip.Controls.Add(new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = valueColor,
                Location = new Point(8, 24),
                Size = new Size(70, 28),
                Text = FormatNumber(value),
                TextAlign = ContentAlignment.MiddleLeft
            });

            queueFlow.Controls.Add(chip);
        }

        private Control CreateInfoRow(string title, string value)
        {
            Panel row = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 6),
                Size = new Size(360, 22)
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(0, 0),
                Size = new Size(230, 22),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(235, 0),
                Size = new Size(125, 22),
                Text = value,
                TextAlign = ContentAlignment.MiddleRight
            });

            return row;
        }

        private Panel outerScroll;
        private FlowLayoutPanel contentFlow;
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblMonth;
        private DateTimePicker dtpMonth;
        private Button btnRefresh;
        private Panel kpiFlow;
        private Panel cardPatients;
        private Panel cardAppointments;
        private Panel cardRevenue;
        private Panel cardToday;
        private Panel cardStaff;
        private Label lblTotalPatientsTitle;
        private Label lblTotalPatientsValue;
        private Label lblPatientsIcon;
        private Label lblMonthlyAppointmentsTitle;
        private Label lblMonthlyAppointmentsValue;
        private Label lblAppointmentsIcon;
        private Label lblMonthlyRevenueTitle;
        private Label lblMonthlyRevenueValue;
        private Label lblRevenueIcon;
        private Label lblTodayAppointmentsTitle;
        private Label lblTodayAppointmentsValue;
        private Label lblTodayIcon;
        private Label lblActiveStaffTitle;
        private Label lblActiveStaffValue;
        private Label lblStaffIcon;
        private Label lblPatientTrend;
        private Label lblAppointmentTrend;
        private Label lblRevenueTrend;
        private Label lblTodayStatus;
        private Label lblMedicineStatus;
        private FlowLayoutPanel chartFlow;
        private Panel patientChartCard;
        private Panel revenueChartCard;
        private Label lblPatientChartTitle;
        private Label lblRevenueChartTitle;
        private Panel pnlPatientChart;
        private Panel pnlRevenueChart;
        private FlowLayoutPanel insightFlow;
        private Panel appointmentCard;
        private Label lblAppointmentTitle;
        private DataGridView dgvAppointments;
        private DataGridViewTextBoxColumn colTime;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colStatus;
        private Panel sidePanel;
        private Panel queueCard;
        private Label lblQueueTitle;
        private FlowLayoutPanel queueFlow;
        private Panel departmentCard;
        private Label lblDepartmentTitle;
        private FlowLayoutPanel departmentFlow;
        private Panel medicineCard;
        private Label lblMedicineTitle;
        private FlowLayoutPanel medicineFlow;
    }
}
