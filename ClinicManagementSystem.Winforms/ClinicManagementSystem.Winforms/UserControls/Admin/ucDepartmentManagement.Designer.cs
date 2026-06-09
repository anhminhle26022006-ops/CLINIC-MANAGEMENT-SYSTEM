using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucDepartmentManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelOuter = new Panel();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnAdd = new Button();
            panelKPI = new Panel();
            panelToolbar = new Panel();
            txtSearch = new TextBox();
            panelCards = new FlowLayoutPanel();
            lblPaging = new Label();

            panelOuter.SuspendLayout();
            panelHeader.SuspendLayout();
            panelToolbar.SuspendLayout();
            SuspendLayout();

            // ── panelOuter ──
            panelOuter.Dock = DockStyle.Fill;
            panelOuter.BackColor = Color.FromArgb(247, 249, 252);
            panelOuter.Padding = new Padding(30, 25, 30, 20);
            panelOuter.Controls.Add(panelCards);
            panelOuter.Controls.Add(panelToolbar);
            panelOuter.Controls.Add(panelKPI);
            panelOuter.Controls.Add(panelHeader);
            panelOuter.Controls.Add(lblPaging);

            // ── panelHeader ──
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 88;
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAdd);
            panelHeader.Resize += panelHeader_Resize;

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 6);
            lblTitle.Text = "Quản lý Chuyên khoa";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(2, 48);
            lblSubtitle.Text = "Quản lý các chuyên khoa và phòng ban y tế";

            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(47, 94, 240);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.Location = new Point(900, 18);
            btnAdd.Size = new Size(210, 46);
            btnAdd.Text = "+ Thêm chuyên khoa";
            btnAdd.Click += btnAdd_Click;

            // ── panelKPI ──
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Height = 120;
            panelKPI.Padding = new Padding(0, 8, 0, 8);
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Resize += panelKPI_Resize;

            cardTotal = MakeKpiCard("Tổng chuyên khoa", "0",
                Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254));
            cardDoctors = MakeKpiCard("Tổng bác sĩ", "0",
                Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229));
            cardPatients = MakeKpiCard("Tổng bệnh nhân", "0",
                Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254));
            cardToday = MakeKpiCard("Lịch hôm nay", "0",
                Color.FromArgb(234, 88, 12), Color.FromArgb(254, 215, 170));

            panelKPI.Controls.AddRange(new Control[]
            {
                cardTotal, cardDoctors, cardPatients, cardToday
            });

            // ── panelToolbar ──
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Height = 56;
            panelToolbar.BackColor = Color.Transparent;
            panelToolbar.Padding = new Padding(0, 10, 0, 10);
            panelToolbar.Controls.Add(txtSearch);

            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(107, 114, 128);
            txtSearch.Location = new Point(0, 12);
            txtSearch.Size = new Size(400, 32);
            txtSearch.PlaceholderText = "🔍  Tìm kiếm chuyên khoa...";
            txtSearch.TextChanged += txtSearch_TextChanged;

            // ── panelCards ──
            panelCards.Dock = DockStyle.Fill;
            panelCards.AutoScroll = true;
            panelCards.BackColor = Color.Transparent;
            panelCards.FlowDirection = FlowDirection.LeftToRight;
            panelCards.WrapContents = true;
            panelCards.Padding = new Padding(0, 8, 0, 8);

            // ── lblPaging ──
            lblPaging.Dock = DockStyle.Bottom;
            lblPaging.Height = 28;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblPaging.Text = "Đang tải...";

            // ── Form ──
            Controls.Add(panelOuter);
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Size = new System.Drawing.Size(1200, 800);

            panelOuter.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            ResumeLayout(false);
        }

        private Panel MakeKpiCard(string title, string value, Color fg, Color bg)
        {
            var card = new Panel
            {
                BackColor = bg,
                Size = new Size(260, 90),
                Margin = new Padding(0, 0, 16, 0)
            };
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fg,
                AutoSize = true,
                Location = new Point(16, 14)
            });
            card.Controls.Add(new Label
            {
                Text = value,
                Tag = "value",
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = fg,
                AutoSize = true,
                Location = new Point(16, 38)
            });
            return card;
        }

        private void panelHeader_Resize(object sender, System.EventArgs e)
        {
            if (btnAdd != null)
                btnAdd.Location = new Point(panelHeader.Width - btnAdd.Width, 20);
        }

        private Panel panelOuter, panelHeader, panelKPI, panelToolbar;
        private FlowLayoutPanel panelCards;
        private Label lblTitle, lblSubtitle, lblPaging;
        private Button btnAdd;
        private TextBox txtSearch;
        internal Panel cardTotal, cardDoctors, cardPatients, cardToday;
    }
}