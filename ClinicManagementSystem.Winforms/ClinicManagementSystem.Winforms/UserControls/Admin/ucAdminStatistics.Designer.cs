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
            kpiFlow = new FlowLayoutPanel();
            chartFlow = new FlowLayoutPanel();
            patientChartCard = new Panel();
            lblPatientChartTitle = new Label();
            pnlPatientChart = new Panel();
            revenueChartCard = new Panel();
            lblRevenueChartTitle = new Label();
            pnlRevenueChart = new Panel();
            insightFlow = new FlowLayoutPanel();
            appointmentCard = new Panel();
            lblAppointmentTitle = new Label();
            dgvAppointments = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            sidePanel = new Panel();
            queueCard = new Panel();
            lblQueueTitle = new Label();
            queueFlow = new FlowLayoutPanel();
            departmentCard = new Panel();
            lblDepartmentTitle = new Label();
            departmentFlow = new FlowLayoutPanel();
            medicineCard = new Panel();
            lblMedicineTitle = new Label();
            medicineFlow = new FlowLayoutPanel();
            cardPatients = CreateKpiCard("Tổng bệnh nhân", "BN", Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255), out lblTotalPatientsValue, out lblPatientTrend);
            cardAppointments = CreateKpiCard("Lịch khám tháng này", "LK", Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245), out lblMonthlyAppointmentsValue, out lblAppointmentTrend);
            cardRevenue = CreateKpiCard("Doanh thu tháng này", "DT", Color.FromArgb(147, 51, 234), Color.FromArgb(250, 245, 255), out lblMonthlyRevenueValue, out lblRevenueTrend);
            cardToday = CreateKpiCard("Lịch khám hôm nay", "HN", Color.FromArgb(234, 88, 12), Color.FromArgb(255, 247, 237), out lblTodayAppointmentsValue, out lblTodayStatus);
            cardStaff = CreateKpiCard("Nhân sự hoạt động", "NS", Color.FromArgb(15, 118, 110), Color.FromArgb(240, 253, 250), out lblActiveStaffValue, out lblMedicineStatus);
            outerScroll.SuspendLayout();
            contentFlow.SuspendLayout();
            headerPanel.SuspendLayout();
            chartFlow.SuspendLayout();
            patientChartCard.SuspendLayout();
            revenueChartCard.SuspendLayout();
            insightFlow.SuspendLayout();
            appointmentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            sidePanel.SuspendLayout();
            queueCard.SuspendLayout();
            departmentCard.SuspendLayout();
            medicineCard.SuspendLayout();
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
            contentFlow.Size = new Size(1263, 1090);
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
            lblTitle.Size = new Size(186, 54);
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
            lblSubtitle.Size = new Size(333, 25);
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
            kpiFlow.WrapContents = true;
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
            chartFlow.WrapContents = true;
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
            pnlPatientChart.Location = new Point(0, 58);
            pnlPatientChart.Name = "pnlPatientChart";
            pnlPatientChart.Padding = new Padding(22, 0, 22, 16);
            pnlPatientChart.Size = new Size(590, 272);
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
            pnlRevenueChart.Location = new Point(0, 58);
            pnlRevenueChart.Name = "pnlRevenueChart";
            pnlRevenueChart.Padding = new Padding(22, 0, 22, 16);
            pnlRevenueChart.Size = new Size(590, 272);
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
            insightFlow.WrapContents = true;
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
            chartFlow.ResumeLayout(false);
            patientChartCard.ResumeLayout(false);
            revenueChartCard.ResumeLayout(false);
            insightFlow.ResumeLayout(false);
            appointmentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            sidePanel.ResumeLayout(false);
            queueCard.ResumeLayout(false);
            departmentCard.ResumeLayout(false);
            medicineCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel CreateKpiCard(string title, string iconText, Color accentColor, Color backgroundColor, out Label valueLabel, out Label trendLabel)
        {
            Panel card = new Panel
            {
                BackColor = backgroundColor,
                Margin = new Padding(0, 0, 16, 16),
                Size = new Size(224, 134)
            };
            card.Paint += Card_Paint;

            Label icon = new Label
            {
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(18, 18),
                Size = new Size(46, 36),
                Text = iconText,
                TextAlign = ContentAlignment.MiddleCenter
            };

            valueLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = accentColor,
                Location = new Point(18, 60),
                Size = new Size(188, 38),
                Text = "0"
            };

            Label titleLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(18, 98),
                Size = new Size(188, 22),
                Text = title
            };

            trendLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(18, 118),
                Size = new Size(188, 20),
                Text = "Đang cập nhật"
            };

            card.Controls.Add(icon);
            card.Controls.Add(valueLabel);
            card.Controls.Add(titleLabel);
            card.Controls.Add(trendLabel);
            return card;
        }

        private Panel outerScroll;
        private FlowLayoutPanel contentFlow;
        private Panel headerPanel;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblMonth;
        private DateTimePicker dtpMonth;
        private Button btnRefresh;
        private FlowLayoutPanel kpiFlow;
        private Panel cardPatients;
        private Panel cardAppointments;
        private Panel cardRevenue;
        private Panel cardToday;
        private Panel cardStaff;
        private Label lblTotalPatientsValue;
        private Label lblMonthlyAppointmentsValue;
        private Label lblMonthlyRevenueValue;
        private Label lblTodayAppointmentsValue;
        private Label lblActiveStaffValue;
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
