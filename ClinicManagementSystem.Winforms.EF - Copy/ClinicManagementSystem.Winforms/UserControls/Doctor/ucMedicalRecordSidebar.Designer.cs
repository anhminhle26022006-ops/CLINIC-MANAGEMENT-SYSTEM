using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucMedicalRecordSidebar : UserControl
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;

        private FlowLayoutPanel pnlStats;

        private Panel pnlTotal;
        private Panel pnlToday;
        private Panel pnlWeek;
        private Panel pnlTracking;

        private Label lblTotal;
        private Label lblToday;
        private Label lblWeek;
        private Label lblTracking;

        private Panel pnlFilter;

        private TextBox txtSearch;
        private DateTimePicker dtFrom;
        private DateTimePicker dtTo;
        private ComboBox cboStatus;

        private DataGridView dgvRecords;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblSubTitle = new Label();
            pnlStats = new FlowLayoutPanel();
            pnlTotal = new Panel();
            lblTotal = new Label();
            pnlToday = new Panel();
            lblToday = new Label();
            pnlWeek = new Panel();
            lblWeek = new Label();
            pnlTracking = new Panel();
            lblTracking = new Label();
            pnlFilter = new Panel();
            txtSearch = new TextBox();
            dtFrom = new DateTimePicker();
            dtTo = new DateTimePicker();
            cboStatus = new ComboBox();
            dgvRecords = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            btnView = new DataGridViewButtonColumn();
            pnlHeader.SuspendLayout();
            pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1496, 90);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(137, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BỆNH ÁN";
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(20, 50);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(217, 20);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Xem lại hồ sơ bệnh án đã khám";
            // 
            // pnlStats
            // 
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(0, 90);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(10);
            pnlStats.Size = new Size(1496, 90);
            pnlStats.TabIndex = 2;
            pnlStats.WrapContents = false;
            // 
            // pnlTotal
            // 
            pnlTotal.Location = new Point(0, 0);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(200, 100);
            pnlTotal.TabIndex = 0;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(0, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(100, 23);
            lblTotal.TabIndex = 0;
            // 
            // pnlToday
            // 
            pnlToday.Location = new Point(0, 0);
            pnlToday.Name = "pnlToday";
            pnlToday.Size = new Size(200, 100);
            pnlToday.TabIndex = 0;
            // 
            // lblToday
            // 
            lblToday.Location = new Point(0, 0);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(100, 23);
            lblToday.TabIndex = 0;
            // 
            // pnlWeek
            // 
            pnlWeek.Location = new Point(0, 0);
            pnlWeek.Name = "pnlWeek";
            pnlWeek.Size = new Size(200, 100);
            pnlWeek.TabIndex = 0;
            // 
            // lblWeek
            // 
            lblWeek.Location = new Point(0, 0);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(100, 23);
            lblWeek.TabIndex = 0;
            // 
            // pnlTracking
            // 
            pnlTracking.Location = new Point(0, 0);
            pnlTracking.Name = "pnlTracking";
            pnlTracking.Size = new Size(200, 100);
            pnlTracking.TabIndex = 0;
            // 
            // lblTracking
            // 
            lblTracking.Location = new Point(0, 0);
            lblTracking.Name = "lblTracking";
            lblTracking.Size = new Size(100, 23);
            lblTracking.TabIndex = 0;
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.White;
            pnlFilter.Controls.Add(txtSearch);
            pnlFilter.Controls.Add(dtFrom);
            pnlFilter.Controls.Add(dtTo);
            pnlFilter.Controls.Add(cboStatus);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(0, 180);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(10);
            pnlFilter.Size = new Size(1496, 70);
            pnlFilter.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(10, 20);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm mã bệnh án / bệnh nhân...";
            txtSearch.Size = new Size(660, 27);
            txtSearch.TabIndex = 0;
            // 
            // dtFrom
            // 
            dtFrom.Location = new Point(696, 20);
            dtFrom.Name = "dtFrom";
            dtFrom.Size = new Size(266, 27);
            dtFrom.TabIndex = 1;
            // 
            // dtTo
            // 
            dtTo.Location = new Point(968, 20);
            dtTo.Name = "dtTo";
            dtTo.Size = new Size(270, 27);
            dtTo.TabIndex = 2;
            // 
            // cboStatus
            // 
            cboStatus.Items.AddRange(new object[] { "Tất cả", "Hoàn thành", "Đang theo dõi" });
            cboStatus.Location = new Point(1262, 19);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(150, 28);
            cboStatus.TabIndex = 3;
            // 
            // dgvRecords
            // 
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
            dgvRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecords.BackgroundColor = Color.White;
            dgvRecords.ColumnHeadersHeight = 29;
            dgvRecords.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, btnView });
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.Location = new Point(0, 250);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.RowHeadersVisible = false;
            dgvRecords.RowHeadersWidth = 51;
            dgvRecords.RowTemplate.Height = 35;
            dgvRecords.Size = new Size(1496, 461);
            dgvRecords.TabIndex = 0;
            dgvRecords.CellClick += dgvRecords_CellClick;
            dgvRecords.CellFormatting += dgvRecords_CellFormatting;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã bệnh án";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Ngày khám";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Bệnh nhân";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Chẩn đoán";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Bác sĩ";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // btnView
            // 
            btnView.HeaderText = "Thao tác";
            btnView.MinimumWidth = 6;
            btnView.Name = "btnView";
            btnView.Text = "Xem ERM";
            btnView.UseColumnTextForButtonValue = true;
            // 
            // ucMedicalRecordSidebar
            // 
            Controls.Add(dgvRecords);
            Controls.Add(pnlFilter);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            Name = "ucMedicalRecordSidebar";
            Size = new Size(1496, 711);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            ResumeLayout(false);

            pnlStats.Controls.Add(
    CreateCard(pnlTotal, "Tổng bệnh án", lblTotal));

            pnlStats.Controls.Add(
                CreateCard(pnlToday, "Hôm nay", lblToday));

            pnlStats.Controls.Add(
                CreateCard(pnlWeek, "7 ngày gần đây", lblWeek));

            pnlStats.Controls.Add(
                CreateCard(pnlTracking, "Đang theo dõi", lblTracking));
        }

        private Panel CreateCard(Panel panel, string title, Label valueLabel)
        {
            panel.Width = 250;
            panel.Height = 70;
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;

            Label lbl = new Label();
            lbl.Text = title;
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.Location = new Point(10, 10);
            lbl.AutoSize = true;

            valueLabel.Text = "0";
            valueLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            valueLabel.ForeColor = Color.RoyalBlue;
            valueLabel.Location = new Point(10, 30);
            valueLabel.AutoSize = true;

            panel.Controls.Add(lbl);
            panel.Controls.Add(valueLabel);

            return panel;
        }
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewButtonColumn btnView;
    }
}
