using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucShiftRequestManagement
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnCreate = new Button();
            kpiFlow = new FlowLayoutPanel();
            panelWarning = new Panel();
            lblWarning = new Label();
            btnWarningAction = new Button();
            panelTabs = new Panel();
            btnTabOverview = new Button();
            btnTabApproval = new Button();
            btnTabSchedule = new Button();
            lblBadge = new Label();
            panelTabContent = new Panel();

            panelHeader.SuspendLayout();
            SuspendLayout();

            // ── Header ───────────────────────────────────────────────
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 80;
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Padding = new Padding(0, 0, 0, 0);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnCreate);
            panelHeader.Resize += panelHeader_Resize;

            lblTitle.Text = "Quản lý ca làm việc";
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 4);
            lblTitle.AutoSize = true;

            lblSubtitle.Text = "Phân ca và xét duyệt yêu cầu đổi ca";
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 44);
            lblSubtitle.AutoSize = true;

            btnCreate.Text = "+ Tạo ca mới";
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.BackColor = Color.FromArgb(37, 99, 235);
            btnCreate.ForeColor = Color.White;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.Size = new Size(140, 44);
            btnCreate.Location = new Point(900, 18);
            btnCreate.Cursor = Cursors.Hand;

            // ── KPI Cards ─────────────────────────────────────────────
            kpiFlow.Dock = DockStyle.Top;
            kpiFlow.Height = 140;
            kpiFlow.BackColor = Color.Transparent;
            kpiFlow.FlowDirection = FlowDirection.LeftToRight;
            kpiFlow.WrapContents = false;
            kpiFlow.Margin = new Padding(0, 0, 0, 12);
            kpiFlow.Padding = new Padding(0);
            kpiFlow.AutoScroll = false;

            cardTotal = MakeKpiCard("Tổng số ca", "0", "+12% so với tháng trước", Color.FromArgb(37, 99, 235), Color.White, true, "📅");
            cardPending = MakeKpiCard("Chờ duyệt", "0", "Yêu cầu đổi ca cần xử lý", Color.FromArgb(161, 98, 7), Color.FromArgb(254, 249, 195), false, "🕐");
            cardApproved = MakeKpiCard("Đã duyệt", "0", "Tháng này", Color.FromArgb(22, 163, 74), Color.White, true, "✅");
            cardRejected = MakeKpiCard("Từ chối", "0", "Tháng này", Color.FromArgb(220, 38, 38), Color.White, true, "❌");

            kpiFlow.Controls.AddRange(new Control[] { cardTotal, cardPending, cardApproved, cardRejected });
            kpiFlow.Resize += kpiFlow_Resize;

            // ── Warning Banner ────────────────────────────────────────
            panelWarning.Dock = DockStyle.Top;
            panelWarning.Height = 60;
            panelWarning.BackColor = Color.FromArgb(254, 252, 232);
            panelWarning.Margin = new Padding(0, 0, 0, 8);
            panelWarning.Visible = false;
            panelWarning.Controls.Add(lblWarning);
            panelWarning.Controls.Add(btnWarningAction);
            panelWarning.Paint += panelWarning_Paint;
            panelWarning.Resize += panelWarning_Resize;

            lblWarning.Text = "⚠  Có yêu cầu đổi ca đang chờ duyệt";
            lblWarning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(161, 98, 7);
            lblWarning.Location = new Point(16, 10);
            lblWarning.AutoSize = true;
            lblWarning.Tag = "main";

            var lblWarningSub = new Label
            {
                Text = "Vui lòng xem xét và phê duyệt các yêu cầu để nhân viên có thể sắp xếp công việc",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(161, 98, 7),
                Location = new Point(16, 32),
                AutoSize = true
            };
            panelWarning.Controls.Add(lblWarningSub);

            btnWarningAction.Text = "Xem ngay";
            btnWarningAction.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnWarningAction.BackColor = Color.FromArgb(161, 98, 7);
            btnWarningAction.ForeColor = Color.White;
            btnWarningAction.FlatStyle = FlatStyle.Flat;
            btnWarningAction.FlatAppearance.BorderSize = 0;
            btnWarningAction.Size = new Size(90, 38);
            btnWarningAction.Location = new Point(900, 10);
            btnWarningAction.Cursor = Cursors.Hand;
            btnWarningAction.Click += btnWarningAction_Click;

            // ── Tab Strip ─────────────────────────────────────────────
            panelTabs.Dock = DockStyle.Top;
            panelTabs.Height = 52;
            panelTabs.BackColor = Color.White;
            panelTabs.Controls.Add(btnTabOverview);
            panelTabs.Controls.Add(btnTabApproval);
            panelTabs.Controls.Add(btnTabSchedule);
            panelTabs.Controls.Add(lblBadge);
            panelTabs.Paint += panelTabs_Paint;

            btnTabOverview.Text = "👥  Tổng quan";
            btnTabOverview.Font = new Font("Segoe UI", 10F);
            btnTabOverview.ForeColor = Color.FromArgb(37, 99, 235);
            btnTabOverview.BackColor = Color.White;
            btnTabOverview.FlatStyle = FlatStyle.Flat;
            btnTabOverview.FlatAppearance.BorderSize = 0;
            btnTabOverview.Size = new Size(160, 50);
            btnTabOverview.Location = new Point(0, 0);
            btnTabOverview.Cursor = Cursors.Hand;
            btnTabOverview.Tag = "active";
            btnTabOverview.Click += btnTabOverview_Click;

            btnTabApproval.Text = "✅  Duyệt đổi ca";
            btnTabApproval.Font = new Font("Segoe UI", 10F);
            btnTabApproval.ForeColor = Color.FromArgb(107, 114, 128);
            btnTabApproval.BackColor = Color.White;
            btnTabApproval.FlatStyle = FlatStyle.Flat;
            btnTabApproval.FlatAppearance.BorderSize = 0;
            btnTabApproval.Size = new Size(160, 50);
            btnTabApproval.Location = new Point(164, 0);
            btnTabApproval.Cursor = Cursors.Hand;
            btnTabApproval.Click += btnTabApproval_Click;

            btnTabSchedule.Text = "📅  Lịch làm việc";
            btnTabSchedule.Font = new Font("Segoe UI", 10F);
            btnTabSchedule.ForeColor = Color.FromArgb(107, 114, 128);
            btnTabSchedule.BackColor = Color.White;
            btnTabSchedule.FlatStyle = FlatStyle.Flat;
            btnTabSchedule.FlatAppearance.BorderSize = 0;
            btnTabSchedule.Size = new Size(160, 50);
            btnTabSchedule.Location = new Point(328, 0);
            btnTabSchedule.Cursor = Cursors.Hand;
            btnTabSchedule.Click += btnTabSchedule_Click;

            lblBadge.Text = "0";
            lblBadge.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblBadge.ForeColor = Color.White;
            lblBadge.BackColor = Color.FromArgb(220, 38, 38);
            lblBadge.Size = new Size(18, 18);
            lblBadge.Location = new Point(306, 8);
            lblBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblBadge.Visible = false;

            // ── Tab Content ───────────────────────────────────────────
            panelTabContent.Dock = DockStyle.Fill;
            panelTabContent.BackColor = Color.FromArgb(247, 249, 252);

            // ── UserControl ───────────────────────────────────────────
            // Thứ tự NGƯỢC: cái add sau hiện ở trên với DockStyle.Top
            Controls.Add(panelTabContent);  // Fill - add trước
            Controls.Add(panelTabs);        // Top - gần Fill nhất
            Controls.Add(panelWarning);     // Top
            Controls.Add(kpiFlow);          // Top
            Controls.Add(panelHeader);      // Top - add cuối = hiện trên cùng

            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Padding = new Padding(30, 20, 30, 0);
            Size = new Size(1280, 900);
            Name = "ucShiftRequestManagement";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private Panel MakeKpiCard(string title, string value, string sub, Color accent, Color bg, bool hasBorder, string icon)
        {
            var card = new Panel { BackColor = bg, Size = new Size(280, 120), Margin = new Padding(0, 0, 16, 0) };
            if (hasBorder)
                card.Paint += KpiCard_Paint;

            // Icon box
            var iconBox = new Panel
            {
                Size = new Size(44, 44),
                BackColor = Color.FromArgb(219, 234, 254),
                Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right,
                Location = new Point(card.Width - 60, 16)
            };
            iconBox.Controls.Add(new Label { Text = icon, Font = new Font("Segoe UI", 14F), ForeColor = accent, Location = new Point(8, 8), AutoSize = true });

            card.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 9F), ForeColor = Color.FromArgb(107, 114, 128), Location = new Point(16, 16), AutoSize = true });
            card.Controls.Add(new Label { Text = value, Tag = "value", Font = new Font("Segoe UI", 28F, FontStyle.Bold), ForeColor = accent, Location = new Point(16, 36), AutoSize = true });
            card.Controls.Add(new Label { Text = sub, Tag = "sub", Font = new Font("Segoe UI", 8.5F), ForeColor = Color.FromArgb(107, 114, 128), Location = new Point(16, 92), AutoSize = true });
            card.Controls.Add(iconBox);
            return card;
        }

        // Fields
        private Panel panelHeader, panelWarning, panelTabs, panelTabContent;
        private FlowLayoutPanel kpiFlow;
        private Label lblTitle, lblSubtitle, lblWarning, lblBadge;
        private Button btnCreate, btnWarningAction;
        private Button btnTabOverview, btnTabApproval, btnTabSchedule;
        internal Panel cardTotal, cardPending, cardApproved, cardRejected;
    }
}
