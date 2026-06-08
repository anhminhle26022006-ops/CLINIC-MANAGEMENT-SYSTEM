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
            DataGridViewCellStyle hStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle rStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle altStyle = new DataGridViewCellStyle();

            // ── Instantiate controls ─────────────────────────────────
            outerScroll = new Panel();
            mainFlow = new FlowLayoutPanel();

            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.WrapContents = false;
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnRefresh = new Button();
            kpiFlow = new FlowLayoutPanel();
            apptCard = new Panel();
            lblApptTitle = new Label();
            dgvAppointments = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDept = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            medCard = new Panel();
            lblMedTitle = new Label();
            panelMedicineList = new FlowLayoutPanel();
            deptCard = new Panel();
            lblDeptTitle = new Label();
            panelDeptCards = new FlowLayoutPanel();
            queueCard = new Panel();
            lblQueueTitle = new Label();
            panelQueueCards = new FlowLayoutPanel();

            outerScroll.SuspendLayout();
            mainFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();

            // ════════════════════════════════════════════════════════════
            //  outerScroll  — scrollable container
            // ════════════════════════════════════════════════════════════
            outerScroll.Dock = DockStyle.Fill;
            outerScroll.AutoScroll = true;
            outerScroll.BackColor = Color.FromArgb(245, 247, 250);
            outerScroll.Controls.Add(mainFlow);

            // When container resizes → stretch mainFlow + all children
            outerScroll.Resize += (s, e) =>
            {
                int inner =
                    outerScroll.ClientSize.Width
                    - mainFlow.Padding.Left
                    - mainFlow.Padding.Right
                    - 20;

                foreach (Control c in mainFlow.Controls)
                {
                    c.Width = inner;
                }

                ResizeKpi(inner);
            };

            // ════════════════════════════════════════════════════════════
            //  mainFlow  — vertical stack
            // ════════════════════════════════════════════════════════════
            mainFlow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Dock = DockStyle.Top;
            mainFlow.Width = outerScroll.ClientSize.Width;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.WrapContents = false;
            mainFlow.BackColor = Color.FromArgb(245, 247, 250);
            mainFlow.Padding = new Padding(28, 24, 28, 32);
            mainFlow.Controls.AddRange(new Control[] { panelHeader, kpiFlow, apptCard, medCard, deptCard, queueCard });
            mainFlow.AutoSize = true;
            mainFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // ════════════════════════════════════════════════════════════
            //  Header
            // ════════════════════════════════════════════════════════════
            panelHeader.Height = 72;
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Margin = new Padding(0, 0, 0, 20);
            panelHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnRefresh });
            panelHeader.Resize += (s, e) =>
            {
                if (btnRefresh != null)
                    btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width, 16);
            };

            lblTitle.Text = "Tổng quan";
            lblTitle.Font =
    new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 2);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "Xin chào, Quản trị viên";
            lblSubtitle.Font = new Font("Segoe UI", 10.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 44);
            lblSubtitle.AutoSize = true;

            btnRefresh.Text = "🔄  Làm mới";
            btnRefresh.Font = new Font("Segoe UI", 9.5F);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.BackColor = Color.White;
            btnRefresh.ForeColor = Color.FromArgb(37, 99, 235);
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.Size = new Size(126, 38);
            btnRefresh.Location = new Point(900, 16);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += btnRefresh_Click;

            // ════════════════════════════════════════════════════════════
            //  KPI row  — 5 colored cards
            // ════════════════════════════════════════════════════════════
            kpiFlow.Height = 180;
            kpiFlow.BackColor = Color.Transparent;
            kpiFlow.FlowDirection = FlowDirection.LeftToRight;
            kpiFlow.WrapContents = false;
            kpiFlow.Margin = new Padding(0, 0, 0, 20);
            kpiFlow.Padding = new Padding(0);

            cardPatients = MakeKpi("0", "Tổng bệnh nhân", "👤", Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254));
            cardAppointments = MakeKpi("0", "Lịch khám hôm nay", "📅", Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254));
            cardWaiting = MakeKpi("0", "Bệnh nhân chờ khám", "⏰", Color.FromArgb(234, 88, 12), Color.FromArgb(255, 237, 213));
            cardEmployees = MakeKpi("0", "Tổng nhân viên", "🩺", Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229));
            cardMedicine = MakeKpi("0", "Thuốc sắp hết", "💊", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 226, 226));
            kpiFlow.Controls.AddRange(new Control[] { cardPatients, cardAppointments, cardWaiting, cardEmployees, cardMedicine });

            // ════════════════════════════════════════════════════════════
            //  Appointment card
            // ════════════════════════════════════════════════════════════
            apptCard.Height = 500;
            apptCard.BackColor = Color.White;
            apptCard.Margin = new Padding(0, 0, 0, 20);
            apptCard.Padding = new Padding(0);
            ApplyCardStyle(apptCard);
            apptCard.Controls.Add(dgvAppointments);
            apptCard.Controls.Add(lblApptTitle);   // Top → renders above DGV

            lblApptTitle.Text = "Lịch khám hôm nay";
            lblApptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblApptTitle.Dock = DockStyle.Top;
            lblApptTitle.Height = 54;
            lblApptTitle.Padding = new Padding(24, 16, 0, 0);

            // DataGridView
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.AutoGenerateColumns = false;
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.ReadOnly = true;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.RowTemplate.Height = 54;
            dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointments.GridColor = Color.FromArgb(243, 244, 246);

            hStyle.BackColor = Color.FromArgb(249, 250, 251);
            hStyle.ForeColor = Color.FromArgb(107, 114, 128);
            hStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            hStyle.Padding = new Padding(14, 0, 0, 0);
            dgvAppointments.ColumnHeadersDefaultCellStyle = hStyle;
            dgvAppointments.ColumnHeadersHeight = 44;
            dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAppointments.EnableHeadersVisualStyles = false;

            rStyle.Font = new Font("Segoe UI", 9.5F);
            rStyle.ForeColor = Color.FromArgb(55, 65, 81);
            rStyle.Padding = new Padding(14, 0, 0, 0);
            rStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            rStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvAppointments.DefaultCellStyle = rStyle;

            altStyle.BackColor = Color.FromArgb(250, 251, 252);
            altStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            altStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvAppointments.AlternatingRowsDefaultCellStyle = altStyle;

            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;

            colTime.Name = "colTime";
            colTime.HeaderText = "GIỜ KHÁM";
            colTime.FillWeight = 10;
            colTime.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colTime.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);

            colPatient.Name = "colPatient";
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.FillWeight = 24;

            colDoctor.Name = "colDoctor";
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.FillWeight = 24;

            colDept.Name = "colDept";
            colDept.HeaderText = "CHUYÊN KHOA";
            colDept.FillWeight = 22;

            colStatus.Name = "colStatus";
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.FillWeight = 15;

            dgvAppointments.Columns.AddRange(colTime, colPatient, colDoctor, colDept, colStatus);

            // ════════════════════════════════════════════════════════════
            //  Medicine card
            // ════════════════════════════════════════════════════════════
            medCard.Height = 380;
            medCard.BackColor = Color.White;
            medCard.Margin = new Padding(0, 0, 0, 20);
            ApplyCardStyle(medCard);
            medCard.Controls.Add(panelMedicineList);
            medCard.Controls.Add(lblMedTitle);

            lblMedTitle.Text = "Thuốc sắp hết";
            lblMedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMedTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedTitle.Dock = DockStyle.Top;
            lblMedTitle.Height = 54;
            lblMedTitle.Padding = new Padding(24, 16, 0, 0);

            panelMedicineList.Dock = DockStyle.Fill;
            panelMedicineList.BackColor = Color.White;
            panelMedicineList.FlowDirection = FlowDirection.TopDown;
            panelMedicineList.WrapContents = false;
            panelMedicineList.AutoScroll = false;
            panelMedicineList.Padding = new Padding(20, 4, 20, 12);

            // ════════════════════════════════════════════════════════════
            //  Dept card
            // ════════════════════════════════════════════════════════════
            deptCard.Height = 196;
            deptCard.BackColor = Color.White;
            deptCard.Margin = new Padding(0, 0, 0, 20);
            ApplyCardStyle(deptCard);
            deptCard.Controls.Add(panelDeptCards);
            deptCard.Controls.Add(lblDeptTitle);

            lblDeptTitle.Text = "Nhân viên theo chuyên khoa";
            lblDeptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblDeptTitle.Dock = DockStyle.Top;
            lblDeptTitle.Height = 54;
            lblDeptTitle.Padding = new Padding(24, 16, 0, 0);

            panelDeptCards.Dock = DockStyle.Fill;
            panelDeptCards.BackColor = Color.White;
            panelDeptCards.WrapContents = false;
            panelDeptCards.AutoScroll = false;
            panelDeptCards.Padding = new Padding(20, 4, 20, 12);
            panelDeptCards.Resize += (s, e) =>
            {
                int avail = panelDeptCards.ClientSize.Width
                            - panelDeptCards.Padding.Horizontal;

                int w = (avail - 36) / 4;

                foreach (Control c in panelDeptCards.Controls)
                {
                    c.Width = w;
                    c.Height = 105;
                    c.Margin = new Padding(0, 0, 12, 0);
                }
            };

            // ════════════════════════════════════════════════════════════
            //  Queue card
            // ════════════════════════════════════════════════════════════
            queueCard.Height = 196; 
            queueCard.BackColor = Color.White;
            queueCard.Margin = new Padding(0, 0, 0, 20);
            ApplyCardStyle(queueCard);
            queueCard.Controls.Add(panelQueueCards);
            queueCard.Controls.Add(lblQueueTitle);

            lblQueueTitle.Text = "Bệnh nhân chờ khám";
            lblQueueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblQueueTitle.Dock = DockStyle.Top;
            lblQueueTitle.Height = 54;
            lblQueueTitle.Padding = new Padding(24, 16, 0, 0);

            panelQueueCards.Dock = DockStyle.Fill;
            panelQueueCards.BackColor = Color.White;
            panelQueueCards.FlowDirection = FlowDirection.LeftToRight;
            panelQueueCards.WrapContents = false;
            panelQueueCards.Padding = new Padding(20, 4, 20, 12);

            cardWaitingQ = MakeQueue("Đang chờ", "0", Color.FromArgb(234, 88, 12), Color.FromArgb(255, 247, 237));
            cardInProgressQ = MakeQueue("Đang khám", "0", Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            cardDoneQ = MakeQueue("Hoàn thành", "0", Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            cardCancelledQ = MakeQueue("Hủy", "0", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
            panelQueueCards.Controls.AddRange(new Control[] { cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ });

            panelQueueCards.Resize += (s, e) =>
            {
                var cards = new[] { cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ };
                int avail = panelQueueCards.ClientSize.Width - panelQueueCards.Padding.Horizontal;
                int w = (avail - 36) / 4;
                if (w <= 0) return;

         
                foreach (var c in cards) { c.Width = w; c.Height = 120; c.Margin = new Padding(0, 0, 12, 0); }
            };

            // ════════════════════════════════════════════════════════════
            //  UserControl root
            // ════════════════════════════════════════════════════════════
            Controls.Add(outerScroll);
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Size = new Size(1280, 900);
            Name = "ucAdminDashboard";

            outerScroll.ResumeLayout(false);
            mainFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }

        // ════════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════════

        /// <summary>Resize KPI cards to fill available width equally.</summary>
        private void ResizeKpi(int totalWidth)
        {
            var cards = new[] { cardPatients, cardAppointments, cardWaiting, cardEmployees, cardMedicine };
            int gap = 14, w = (totalWidth - gap * 4) / 5;
            if (w <= 0) return;
            kpiFlow.Height = 180;
            foreach (var c in cards) { c.Width = w; c.Height = 128; c.Margin = new Padding(0, 0, gap, 0); }
        }

        /// <summary>
        /// KPI card: icon (top-left) → large number → title label (bottom).
        /// Layout matches Figma: icon at top, value in middle, title at bottom.
        /// </summary>
        private Panel MakeKpi(string value, string title, string icon, Color fg, Color bg)
        {
            var p = new Panel { BackColor = bg, Size = new Size(220, 128), Margin = new Padding(0, 0, 14, 0) };

            p.Controls.Add(new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 16F),
                ForeColor = fg,
                Location = new Point(20, 14),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 36F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(18, 42),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = title,
                Tag = "title",
                Font = new Font("Segoe UI", 9F),
                ForeColor = fg,
                Location = new Point(20, 130),
                AutoSize = true
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

            p.Controls.Add(new Label
            {
                Text = title,
                Tag = "title",
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = fg,
                Location = new Point(20, 16),
                AutoSize = true
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 28F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(20, 44),
                AutoSize = true
            });
            return p;
        }

        /// <summary>
        /// Adds a subtle border + very light box-shadow effect via Paint event.
        /// WinForms has no built-in border-radius; this draws a 1px border.
        /// </summary>
        private void ApplyCardStyle(Panel p)
        {
            p.Paint += (s, e) =>
            {
                var panel = (Panel)s;
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (var pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                    g.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            };
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