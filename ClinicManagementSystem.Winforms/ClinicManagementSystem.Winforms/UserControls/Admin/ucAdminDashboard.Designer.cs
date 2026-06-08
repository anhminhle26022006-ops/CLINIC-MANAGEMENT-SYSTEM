using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            outerScroll = new Panel();
            mainFlow = new FlowLayoutPanel();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnRefresh = new Button();
            kpiFlow = new FlowLayoutPanel();
            apptCard = new Panel();
            dgvAppointments = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDept = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblApptTitle = new Label();
            medCard = new Panel();
            panelMedicineList = new FlowLayoutPanel();
            lblMedTitle = new Label();
            deptCard = new Panel();
            panelDeptCards = new FlowLayoutPanel();
            lblDeptTitle = new Label();
            queueCard = new Panel();
            panelQueueCards = new FlowLayoutPanel();
            lblQueueTitle = new Label();
            cardPatients = MakeKpi("0", "Tổng bệnh nhân", "BN", Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            cardAppointments = MakeKpi("0", "Lịch khám tháng này", "LK", Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            cardWaiting = MakeKpi("0", "Bệnh nhân đang chờ", "CD", Color.FromArgb(217, 119, 6), Color.FromArgb(255, 251, 235));
            cardEmployees = MakeKpi("0", "Nhân sự hoạt động", "NS", Color.FromArgb(15, 118, 110), Color.FromArgb(240, 253, 250));
            cardMedicine = MakeKpi("0", "Thuốc sắp hết", "TH", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
            cardWaitingQ = MakeQueue("Chờ khám", "0", Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            cardInProgressQ = MakeQueue("Đang khám", "0", Color.FromArgb(217, 119, 6), Color.FromArgb(255, 251, 235));
            cardDoneQ = MakeQueue("Hoàn thành", "0", Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            cardCancelledQ = MakeQueue("Đã hủy", "0", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
            outerScroll.SuspendLayout();
            mainFlow.SuspendLayout();
            panelHeader.SuspendLayout();
            apptCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            medCard.SuspendLayout();
            deptCard.SuspendLayout();
            queueCard.SuspendLayout();
            SuspendLayout();
            // 
            // outerScroll
            // 
            outerScroll.AutoScroll = true;
            outerScroll.BackColor = Color.FromArgb(245, 247, 250);
            outerScroll.Controls.Add(mainFlow);
            outerScroll.Dock = DockStyle.Fill;
            outerScroll.Location = new Point(0, 0);
            outerScroll.Margin = new Padding(2, 2, 2, 2);
            outerScroll.Name = "outerScroll";
            outerScroll.Size = new Size(1024, 720);
            outerScroll.TabIndex = 0;
            outerScroll.Resize += outerScroll_Resize;
            // 
            // mainFlow
            // 
            mainFlow.AutoSize = true;
            mainFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainFlow.BackColor = Color.FromArgb(245, 247, 250);
            mainFlow.Controls.Add(panelHeader);
            mainFlow.Controls.Add(kpiFlow);
            mainFlow.Controls.Add(apptCard);
            mainFlow.Controls.Add(medCard);
            mainFlow.Controls.Add(deptCard);
            mainFlow.Controls.Add(queueCard);
            mainFlow.Dock = DockStyle.Top;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Margin = new Padding(2, 2, 2, 2);
            mainFlow.Name = "mainFlow";
            mainFlow.Padding = new Padding(22, 19, 22, 26);
            mainFlow.Size = new Size(1003, 1361);
            mainFlow.TabIndex = 0;
            mainFlow.WrapContents = false;
            mainFlow.Paint += mainFlow_Paint;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Location = new Point(22, 19);
            panelHeader.Margin = new Padding(0, 0, 0, 16);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(960, 82);
            panelHeader.TabIndex = 0;
            panelHeader.Resize += panelHeader_Resize;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(2, 0);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tổng quan";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(4, 56);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(190, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Xin chào, Quản trị viên";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F);
            btnRefresh.ForeColor = Color.FromArgb(37, 99, 235);
            btnRefresh.Location = new Point(842, 18);
            btnRefresh.Margin = new Padding(2, 2, 2, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(101, 30);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // kpiFlow
            // 
            kpiFlow.BackColor = Color.Transparent;
            kpiFlow.Controls.Add(cardPatients);
            kpiFlow.Controls.Add(cardAppointments);
            kpiFlow.Controls.Add(cardWaiting);
            kpiFlow.Controls.Add(cardEmployees);
            kpiFlow.Controls.Add(cardMedicine);
            kpiFlow.Location = new Point(22, 117);
            kpiFlow.Margin = new Padding(0, 0, 0, 16);
            kpiFlow.Name = "kpiFlow";
            kpiFlow.Size = new Size(960, 150);
            kpiFlow.TabIndex = 1;
            kpiFlow.WrapContents = false;
            // 
            // apptCard
            // 
            apptCard.BackColor = Color.White;
            apptCard.Controls.Add(dgvAppointments);
            apptCard.Controls.Add(lblApptTitle);
            apptCard.Location = new Point(22, 283);
            apptCard.Margin = new Padding(0, 0, 0, 16);
            apptCard.Name = "apptCard";
            apptCard.Size = new Size(960, 360);
            apptCard.TabIndex = 2;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 252);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle2.Padding = new Padding(14, 0, 0, 0);
            dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAppointments.ColumnHeadersHeight = 44;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colTime, colPatient, colDoctor, colDept, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle4.Padding = new Padding(14, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAppointments.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.EnableHeadersVisualStyles = false;
            dgvAppointments.GridColor = Color.FromArgb(243, 244, 246);
            dgvAppointments.Location = new Point(0, 43);
            dgvAppointments.Margin = new Padding(2, 2, 2, 2);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.RowTemplate.Height = 54;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(960, 317);
            dgvAppointments.TabIndex = 0;
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            // 
            // colTime
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(17, 24, 39);
            colTime.DefaultCellStyle = dataGridViewCellStyle3;
            colTime.FillWeight = 10F;
            colTime.HeaderText = "GIỜ KHÁM";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colPatient
            // 
            colPatient.FillWeight = 24F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.MinimumWidth = 6;
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 24F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.MinimumWidth = 6;
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colDept
            // 
            colDept.FillWeight = 22F;
            colDept.HeaderText = "CHUYÊN KHOA";
            colDept.MinimumWidth = 6;
            colDept.Name = "colDept";
            colDept.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 15F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblApptTitle
            // 
            lblApptTitle.Dock = DockStyle.Top;
            lblApptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblApptTitle.Location = new Point(0, 0);
            lblApptTitle.Margin = new Padding(2, 0, 2, 0);
            lblApptTitle.Name = "lblApptTitle";
            lblApptTitle.Padding = new Padding(19, 13, 0, 0);
            lblApptTitle.Size = new Size(960, 43);
            lblApptTitle.TabIndex = 1;
            lblApptTitle.Text = "Lịch khám hôm nay";
            // 
            // medCard
            // 
            medCard.BackColor = Color.White;
            medCard.Controls.Add(panelMedicineList);
            medCard.Controls.Add(lblMedTitle);
            medCard.Location = new Point(22, 659);
            medCard.Margin = new Padding(0, 0, 0, 16);
            medCard.Name = "medCard";
            medCard.Size = new Size(960, 220);
            medCard.TabIndex = 3;
            // 
            // panelMedicineList
            // 
            panelMedicineList.BackColor = Color.White;
            panelMedicineList.Dock = DockStyle.Fill;
            panelMedicineList.FlowDirection = FlowDirection.TopDown;
            panelMedicineList.Location = new Point(0, 43);
            panelMedicineList.Margin = new Padding(2, 2, 2, 2);
            panelMedicineList.Name = "panelMedicineList";
            panelMedicineList.Padding = new Padding(16, 3, 16, 10);
            panelMedicineList.Size = new Size(960, 177);
            panelMedicineList.TabIndex = 0;
            panelMedicineList.WrapContents = false;
            // 
            // lblMedTitle
            // 
            lblMedTitle.Dock = DockStyle.Top;
            lblMedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMedTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedTitle.Location = new Point(0, 0);
            lblMedTitle.Margin = new Padding(2, 0, 2, 0);
            lblMedTitle.Name = "lblMedTitle";
            lblMedTitle.Padding = new Padding(19, 13, 0, 0);
            lblMedTitle.Size = new Size(960, 43);
            lblMedTitle.TabIndex = 1;
            lblMedTitle.Text = "Thuốc sắp hết";
            // 
            // deptCard
            // 
            deptCard.BackColor = Color.White;
            deptCard.Controls.Add(panelDeptCards);
            deptCard.Controls.Add(lblDeptTitle);
            deptCard.Location = new Point(22, 895);
            deptCard.Margin = new Padding(0, 0, 0, 16);
            deptCard.Name = "deptCard";
            deptCard.Size = new Size(960, 170);
            deptCard.TabIndex = 4;
            // 
            // panelDeptCards
            // 
            panelDeptCards.BackColor = Color.White;
            panelDeptCards.Dock = DockStyle.Fill;
            panelDeptCards.Location = new Point(0, 43);
            panelDeptCards.Margin = new Padding(2, 2, 2, 2);
            panelDeptCards.Name = "panelDeptCards";
            panelDeptCards.Padding = new Padding(16, 3, 16, 10);
            panelDeptCards.Size = new Size(960, 127);
            panelDeptCards.TabIndex = 0;
            panelDeptCards.WrapContents = false;
            panelDeptCards.Resize += panelDeptCards_Resize;
            // 
            // lblDeptTitle
            // 
            lblDeptTitle.Dock = DockStyle.Top;
            lblDeptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblDeptTitle.Location = new Point(0, 0);
            lblDeptTitle.Margin = new Padding(2, 0, 2, 0);
            lblDeptTitle.Name = "lblDeptTitle";
            lblDeptTitle.Padding = new Padding(19, 13, 0, 0);
            lblDeptTitle.Size = new Size(960, 43);
            lblDeptTitle.TabIndex = 1;
            lblDeptTitle.Text = "Nhân viên theo chuyên khoa";
            // 
            // queueCard
            // 
            queueCard.BackColor = Color.White;
            queueCard.Controls.Add(panelQueueCards);
            queueCard.Controls.Add(lblQueueTitle);
            queueCard.Location = new Point(22, 1081);
            queueCard.Margin = new Padding(0, 0, 0, 16);
            queueCard.Name = "queueCard";
            queueCard.Size = new Size(960, 170);
            queueCard.TabIndex = 5;
            // 
            // panelQueueCards
            // 
            panelQueueCards.BackColor = Color.White;
            panelQueueCards.Controls.Add(cardWaitingQ);
            panelQueueCards.Controls.Add(cardInProgressQ);
            panelQueueCards.Controls.Add(cardDoneQ);
            panelQueueCards.Controls.Add(cardCancelledQ);
            panelQueueCards.Dock = DockStyle.Fill;
            panelQueueCards.Location = new Point(0, 43);
            panelQueueCards.Margin = new Padding(2, 2, 2, 2);
            panelQueueCards.Name = "panelQueueCards";
            panelQueueCards.Padding = new Padding(16, 3, 16, 10);
            panelQueueCards.Size = new Size(960, 127);
            panelQueueCards.TabIndex = 0;
            panelQueueCards.WrapContents = false;
            panelQueueCards.Resize += panelQueueCards_Resize;
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.Dock = DockStyle.Top;
            lblQueueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblQueueTitle.Location = new Point(0, 0);
            lblQueueTitle.Margin = new Padding(2, 0, 2, 0);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Padding = new Padding(19, 13, 0, 0);
            lblQueueTitle.Size = new Size(960, 43);
            lblQueueTitle.TabIndex = 1;
            lblQueueTitle.Text = "Bệnh nhân chờ khám";
            // 
            // ucAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(outerScroll);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ucAdminDashboard";
            Size = new Size(1024, 720);
            outerScroll.ResumeLayout(false);
            outerScroll.PerformLayout();
            mainFlow.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            apptCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            medCard.ResumeLayout(false);
            deptCard.ResumeLayout(false);
            queueCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ════════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════════

        /// <summary>Resize KPI cards to fill available width equally.</summary>
        private void ResizeKpi(int totalWidth)
        {
            var cards = new[] { cardPatients, cardAppointments, cardWaiting, cardEmployees, cardMedicine };
            int count = 0;
            foreach (var card in cards)
            {
                if (card != null) count++;
            }
            if (count == 0) return;

            int gap = 14, w = (totalWidth - gap * (count - 1)) / count;
            if (w <= 0) return;
            kpiFlow.Height = 180;
            foreach (var c in cards)
            {
                if (c == null) continue;
                c.Width = w;
                c.Height = 128;
                c.Margin = new Padding(0, 0, gap, 0);
            }
        }

        /// <summary>
        /// KPI card: icon (top-left) → large number → title label (bottom).
        /// Layout matches Figma: icon at top, value in middle, title at bottom.
        /// </summary>
        private Panel MakeKpi(string value, string title, string icon, Color fg, Color bg)
        {
            var p = new Panel { BackColor = bg, Size = new Size(180, 128), Margin = new Padding(0, 0, 14, 0) };
            p.Paint += Card_Paint;

            p.Controls.Add(new Label
            {
                Text = icon,
                BackColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(18, 16),
                Size = new Size(44, 34),
                TextAlign = ContentAlignment.MiddleCenter
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(18, 54),
                Size = new Size(145, 42),
                AutoEllipsis = true
            });
            p.Controls.Add(new Label
            {
                Text = title,
                Tag = "title",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(20, 98),
                Size = new Size(145, 24),
                AutoEllipsis = true
            });
            return p;
        }

        /// <summary>
        /// Queue card: title on top, large value below.
        /// Matches Figma queue section.
        /// </summary>
        private Panel MakeQueue(string title, string value, Color fg, Color bg)
        {
            var p = new Panel { BackColor = bg, Size = new Size(240, 106), Margin = new Padding(0, 0, 12, 0) };
            p.Paint += Card_Paint;

            p.Controls.Add(new Label
            {
                Text = title,
                Tag = "title",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = fg,
                Location = new Point(20, 16),
                Size = new Size(190, 24),
                AutoEllipsis = true
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(20, 44),
                Size = new Size(190, 50),
                AutoEllipsis = true
            });
            return p;
        }

        /// <summary>
        /// Adds a subtle border + very light box-shadow effect via Paint event.
        /// WinForms has no built-in border-radius; this draws a 1px border.
        /// </summary>
        private void ApplyCardStyle(Panel p)
        {
            p.Paint += Card_Paint;
        }

        // ════════════════════════════════════════════════════════════════
        //  Fields
        // ════════════════════════════════════════════════════════════════
        private Panel outerScroll;
        private FlowLayoutPanel mainFlow, kpiFlow;
        private Panel panelHeader;
        private Panel apptCard, medCard, deptCard, queueCard;
        private FlowLayoutPanel panelMedicineList, panelDeptCards, panelQueueCards;
        private Label lblTitle, lblSubtitle, lblApptTitle, lblMedTitle, lblDeptTitle, lblQueueTitle;
        private Button btnRefresh;
        private DataGridView dgvAppointments;
        private DataGridViewTextBoxColumn colTime, colPatient, colDoctor, colDept, colStatus;
        internal Panel cardPatients, cardAppointments, cardWaiting, cardEmployees, cardMedicine;
        internal Panel cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ;
    }
}
