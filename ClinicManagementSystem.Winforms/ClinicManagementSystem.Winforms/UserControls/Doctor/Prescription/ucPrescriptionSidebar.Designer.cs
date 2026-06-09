namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    partial class ucPrescriptionSidebar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;

        private FlowLayoutPanel flpStats;

        private Panel pnlTotal;
        private Label lblTotalTitle;
        private Label lblTotalValue;

        private Panel pnlToday;
        private Label lblTodayTitle;
        private Label lblTodayValue;

        private Panel pnlWeek;
        private Label lblWeekTitle;
        private Label lblWeekValue;

        private Panel pnlTracking;
        private Label lblTrackingTitle;
        private Label lblTrackingValue;

        private Panel pnlFilter;
        private TextBox txtSearch;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;

        public DataGridView dgvPrescriptions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            pnlTotal = new Panel();
            lblTitle = new Label();
            pnlToday = new Panel();
            lblSubTitle = new Label();
            pnlWeek = new Panel();
            pnlTracking = new Panel();
            flpStats = new FlowLayoutPanel();
            lblTotalTitle = new Label();
            lblTotalValue = new Label();
            lblTodayTitle = new Label();
            lblTodayValue = new Label();
            lblWeekTitle = new Label();
            lblWeekValue = new Label();
            lblTrackingTitle = new Label();
            lblTrackingValue = new Label();
            pnlFilter = new Panel();
            txtSearch = new TextBox();
            dtFrom = new DateTimePicker();
            dtTo = new DateTimePicker();
            dgvPrescriptions = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            btnView = new DataGridViewButtonColumn();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(pnlTotal);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(pnlToday);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Controls.Add(pnlWeek);
            pnlHeader.Controls.Add(pnlTracking);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1264, 80);
            pnlHeader.TabIndex = 3;
            // 
            // pnlTotal
            // 
            pnlTotal.Location = new Point(40, 80);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(200, 100);
            pnlTotal.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(126, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Toa thuốc";
            // 
            // pnlToday
            // 
            pnlToday.Location = new Point(382, 80);
            pnlToday.Name = "pnlToday";
            pnlToday.Size = new Size(200, 100);
            pnlToday.TabIndex = 1;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(18, 42);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(212, 20);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Xem lại lịch sử toa thuốc đã kê";
            // 
            // pnlWeek
            // 
            pnlWeek.Location = new Point(563, 80);
            pnlWeek.Name = "pnlWeek";
            pnlWeek.Size = new Size(200, 100);
            pnlWeek.TabIndex = 2;
            // 
            // pnlTracking
            // 
            pnlTracking.Location = new Point(899, 80);
            pnlTracking.Name = "pnlTracking";
            pnlTracking.Size = new Size(200, 100);
            pnlTracking.TabIndex = 3;
            // 
            // flpStats
            // 
            flpStats.Dock = DockStyle.Top;
            flpStats.Location = new Point(0, 80);
            flpStats.Name = "flpStats";
            flpStats.Padding = new Padding(10);
            flpStats.Size = new Size(1264, 100);
            flpStats.TabIndex = 2;
            flpStats.WrapContents = false;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Location = new Point(0, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(100, 23);
            lblTotalTitle.TabIndex = 0;
            // 
            // lblTotalValue
            // 
            lblTotalValue.Location = new Point(0, 0);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(100, 23);
            lblTotalValue.TabIndex = 0;
            // 
            // lblTodayTitle
            // 
            lblTodayTitle.Location = new Point(0, 0);
            lblTodayTitle.Name = "lblTodayTitle";
            lblTodayTitle.Size = new Size(100, 23);
            lblTodayTitle.TabIndex = 0;
            // 
            // lblTodayValue
            // 
            lblTodayValue.Location = new Point(0, 0);
            lblTodayValue.Name = "lblTodayValue";
            lblTodayValue.Size = new Size(100, 23);
            lblTodayValue.TabIndex = 0;
            // 
            // lblWeekTitle
            // 
            lblWeekTitle.Location = new Point(0, 0);
            lblWeekTitle.Name = "lblWeekTitle";
            lblWeekTitle.Size = new Size(100, 23);
            lblWeekTitle.TabIndex = 0;
            // 
            // lblWeekValue
            // 
            lblWeekValue.Location = new Point(0, 0);
            lblWeekValue.Name = "lblWeekValue";
            lblWeekValue.Size = new Size(100, 23);
            lblWeekValue.TabIndex = 0;
            // 
            // lblTrackingTitle
            // 
            lblTrackingTitle.AutoSize = true;
            lblTrackingTitle.Location = new Point(0, 0);
            lblTrackingTitle.Name = "lblTrackingTitle";
            lblTrackingTitle.Size = new Size(100, 23);
            lblTrackingTitle.TabIndex = 0;
            // 
            // lblTrackingValue
            // 
            lblTrackingValue.Location = new Point(0, 0);
            lblTrackingValue.Name = "lblTrackingValue";
            lblTrackingValue.Size = new Size(100, 23);
            lblTrackingValue.TabIndex = 0;
            // 
            // pnlFilter
            // 
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(dtFrom);
            pnlFilter.Controls.Add(dtTo);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 180);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Size = new Size(1264, 70);
            pnlFilter.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(15, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm bệnh nhân...";
            txtSearch.Size = new Size(609, 27);
            txtSearch.TabIndex = 0;
            // 
            // dtFrom
            // 
            dtFrom.Location = new Point(650, 20);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(279, 27);
            dtFrom.TabIndex = 1;
            // 
            // dtTo
            // 
            dtTo.Location = new Point(967, 18);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(263, 27);
            dtTo.TabIndex = 2;
            // 
            // dgvPrescriptions
            // 
            dgvPrescriptions.AllowUserToAddRows = false;
            dgvPrescriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrescriptions.BackgroundColor = Color.White;
            dgvPrescriptions.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPrescriptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPrescriptions.ColumnHeadersHeight = 29;
            dgvPrescriptions.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, btnView });
            dgvPrescriptions.Dock = DockStyle.Fill;
            dgvPrescriptions.Location = new Point(0, 250);
            dgvPrescriptions.Name = "dgvPrescriptions";
            dgvPrescriptions.RowHeadersVisible = false;
            dgvPrescriptions.RowHeadersWidth = 51;
            dgvPrescriptions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrescriptions.Size = new Size(1264, 398);
            dgvPrescriptions.TabIndex = 0;
            dgvPrescriptions.CellClick += dgvPrescriptions_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Ngày kê";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Bệnh nhân";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Số loại thuốc";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Ghi chú";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // btnView
            // 
            btnView.HeaderText = "Thao tác";
            btnView.MinimumWidth = 6;
            btnView.Name = "btnView";
            btnView.Text = "👁";
            btnView.UseColumnTextForButtonValue = true;
            // 
            // ucPrescriptionSidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(dgvPrescriptions);
            Controls.Add(pnlFilter);
            Controls.Add(flpStats);
            Controls.Add(pnlHeader);
            Name = "ucPrescriptionSidebar";
            Size = new Size(1264, 648);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrescriptions).EndInit();
            ResumeLayout(false);
        }

        private void CreateStatPanel(
            Panel panel,
            Label title,
            Label value,
            string text,
            string count)
        {
            panel.Width = 180;
            panel.Height = 70;
            panel.Margin = new Padding(8);
            panel.BackColor = Color.FromArgb(240, 248, 255);

            title.AutoSize = true;
            title.Location = new Point(15, 12);
            title.Text = text;

            value.AutoSize = true;
            value.Font = new Font(
                "Segoe UI",
                16F,
                FontStyle.Bold
            );
            value.Location = new Point(15, 32);
            value.Text = count;

            panel.Controls.Add(title);
            panel.Controls.Add(value);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewButtonColumn btnView;
    }
}
