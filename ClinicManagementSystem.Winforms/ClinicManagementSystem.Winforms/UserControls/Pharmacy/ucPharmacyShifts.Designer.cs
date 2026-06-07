using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucPharmacyShifts
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

        private void InitializeComponent()
        {
            viewHostPanel = new RoundedPanel();
            lblHeading = new Label();
            lblSubheading = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlTotal = new RoundedPanel();
            lblTotalTitle = new Label();
            lblTotalValue = new Label();
            lblTotalFoot = new Label();
            lblTotalIcon = new Label();
            pnlRequests = new RoundedPanel();
            lblRequestsTitle = new Label();
            lblRequestsValue = new Label();
            lblRequestsFoot = new Label();
            lblRequestsIcon = new Label();
            pnlApproved = new RoundedPanel();
            lblApprovedTitle = new Label();
            lblApprovedValue = new Label();
            lblApprovedFoot = new Label();
            lblApprovedIcon = new Label();
            pnlSchedule = new RoundedPanel();
            lblTabSchedule = new Label();
            lblTabHistory = new Label();
            btnPrev = new Button();
            lblWeek = new Label();
            btnNext = new Button();
            btnToday = new Button();
            btnDay = new Button();
            btnWeek = new Button();
            btnMonth = new Button();
            calendarGrid = new TableLayoutPanel();
            lblMon = new Label();
            lblTue = new Label();
            lblWed = new Label();
            lblThu = new Label();
            lblFri = new Label();
            lblSat = new Label();
            lblSun = new Label();
            pnlMon = new Panel();
            pnlTue = new Panel();
            pnlWed = new Panel();
            pnlThu = new Panel();
            pnlFri = new Panel();
            pnlSat = new Panel();
            pnlSun = new Panel();
            pnlShiftItem = new RoundedPanel();
            lblShiftCode = new Label();
            lblShiftTime = new Label();
            lblShiftRoom = new Label();
            pnlLegend = new RoundedPanel();
            lblLegend = new Label();
            lblLegendScheduled = new Label();
            lblLegendChange = new Label();
            lblLegendApproved = new Label();
            lblLegendRejected = new Label();
            viewHostPanel.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlTotal.SuspendLayout();
            pnlRequests.SuspendLayout();
            pnlApproved.SuspendLayout();
            pnlSchedule.SuspendLayout();
            calendarGrid.SuspendLayout();
            pnlTue.SuspendLayout();
            pnlShiftItem.SuspendLayout();
            pnlLegend.SuspendLayout();
            SuspendLayout();
            ConfigureCard(viewHostPanel, Color.FromArgb(247, 249, 252), Color.FromArgb(247, 249, 252));
            viewHostPanel.AutoScroll = true;
            viewHostPanel.Controls.Add(pnlLegend);
            viewHostPanel.Controls.Add(pnlSchedule);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Controls.Add(lblSubheading);
            viewHostPanel.Controls.Add(lblHeading);
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.Size = new Size(1244, 900);
            SetupLabel(lblHeading, "Quản lý ca làm việc", 18F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 24, 24, 420, 40);
            SetupLabel(lblSubheading, "Xem lịch làm việc và yêu cầu đổi ca", 10F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 24, 66, 460, 28);
            // 
            // stats
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 3;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.Controls.Add(pnlTotal, 0, 0);
            pnlStatsGrid.Controls.Add(pnlRequests, 1, 0);
            pnlStatsGrid.Controls.Add(pnlApproved, 2, 0);
            pnlStatsGrid.Location = new Point(24, 126);
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1196, 120);
            SetupStatCard(pnlTotal, lblTotalIcon, lblTotalTitle, lblTotalValue, lblTotalFoot, "▣", "Tổng số ca", "1", "Tháng này", Color.FromArgb(47, 94, 240), Color.FromArgb(219, 234, 254), new Padding(0, 0, 18, 0));
            SetupStatCard(pnlRequests, lblRequestsIcon, lblRequestsTitle, lblRequestsValue, lblRequestsFoot, "↻", "Yêu cầu đổi ca", "0", "Đang chờ duyệt", Color.FromArgb(202, 138, 4), Color.FromArgb(254, 249, 195), new Padding(0, 0, 18, 0));
            SetupStatCard(pnlApproved, lblApprovedIcon, lblApprovedTitle, lblApprovedValue, lblApprovedFoot, "◷", "Đã được duyệt", "0", "Tháng này", Color.FromArgb(34, 139, 74), Color.FromArgb(220, 252, 231), new Padding(0));
            // 
            // schedule panel
            // 
            ConfigureCard(pnlSchedule, Color.White, Color.FromArgb(229, 231, 235));
            pnlSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSchedule.Controls.Add(calendarGrid);
            pnlSchedule.Controls.Add(btnMonth);
            pnlSchedule.Controls.Add(btnWeek);
            pnlSchedule.Controls.Add(btnDay);
            pnlSchedule.Controls.Add(btnToday);
            pnlSchedule.Controls.Add(btnNext);
            pnlSchedule.Controls.Add(lblWeek);
            pnlSchedule.Controls.Add(btnPrev);
            pnlSchedule.Controls.Add(lblTabHistory);
            pnlSchedule.Controls.Add(lblTabSchedule);
            pnlSchedule.Location = new Point(24, 274);
            pnlSchedule.Size = new Size(1196, 460);
            SetupLabel(lblTabSchedule, "▣  Lịch làm việc", 11F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 220, 18, 360, 34, ContentAlignment.MiddleCenter);
            SetupLabel(lblTabHistory, "◷  Lịch sử đổi ca", 11F, FontStyle.Bold, Color.FromArgb(75, 85, 99), 620, 18, 360, 34, ContentAlignment.MiddleCenter);
            btnPrev.Text = "‹";
            SetupNavButton(btnPrev, 34, 88, 36, 36, Color.White, Color.FromArgb(31, 41, 55));
            SetupLabel(lblWeek, "Tuần 1, Tháng 6 2026", 15F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 86, 86, 260, 40);
            btnNext.Text = "›";
            SetupNavButton(btnNext, 350, 88, 36, 36, Color.White, Color.FromArgb(31, 41, 55));
            SetupNavButton(btnToday, 414, 86, 90, 40, Color.FromArgb(47, 94, 240), Color.White);
            btnToday.Text = "Hôm nay";
            SetupNavButton(btnDay, 946, 86, 70, 40, Color.FromArgb(243, 244, 246), Color.FromArgb(31, 41, 55));
            btnDay.Text = "Ngày";
            SetupNavButton(btnWeek, 1026, 86, 70, 40, Color.FromArgb(47, 94, 240), Color.White);
            btnWeek.Text = "Tuần";
            SetupNavButton(btnMonth, 1106, 86, 70, 40, Color.FromArgb(243, 244, 246), Color.FromArgb(31, 41, 55));
            btnMonth.Text = "Tháng";
            // 
            // calendar
            // 
            calendarGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            calendarGrid.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            calendarGrid.ColumnCount = 7;
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857F));
            calendarGrid.Controls.Add(lblMon, 0, 0);
            calendarGrid.Controls.Add(lblTue, 1, 0);
            calendarGrid.Controls.Add(lblWed, 2, 0);
            calendarGrid.Controls.Add(lblThu, 3, 0);
            calendarGrid.Controls.Add(lblFri, 4, 0);
            calendarGrid.Controls.Add(lblSat, 5, 0);
            calendarGrid.Controls.Add(lblSun, 6, 0);
            calendarGrid.Controls.Add(pnlMon, 0, 1);
            calendarGrid.Controls.Add(pnlTue, 1, 1);
            calendarGrid.Controls.Add(pnlWed, 2, 1);
            calendarGrid.Controls.Add(pnlThu, 3, 1);
            calendarGrid.Controls.Add(pnlFri, 4, 1);
            calendarGrid.Controls.Add(pnlSat, 5, 1);
            calendarGrid.Controls.Add(pnlSun, 6, 1);
            calendarGrid.Location = new Point(22, 150);
            calendarGrid.RowCount = 2;
            calendarGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            calendarGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            calendarGrid.Size = new Size(1152, 270);
            SetupDayHeader(lblMon, "T2\r\n1");
            SetupDayHeader(lblTue, "T3\r\n2");
            SetupDayHeader(lblWed, "T4\r\n3");
            SetupDayHeader(lblThu, "T5\r\n4");
            SetupDayHeader(lblFri, "T6\r\n5");
            SetupDayHeader(lblSat, "T7\r\n6");
            lblSat.BackColor = Color.FromArgb(239, 246, 255);
            SetupDayHeader(lblSun, "CN\r\n7");
            pnlTue.Controls.Add(pnlShiftItem);
            ConfigureCard(pnlShiftItem, Color.FromArgb(219, 234, 254), Color.FromArgb(147, 197, 253));
            pnlShiftItem.Controls.Add(lblShiftRoom);
            pnlShiftItem.Controls.Add(lblShiftTime);
            pnlShiftItem.Controls.Add(lblShiftCode);
            pnlShiftItem.Location = new Point(10, 14);
            pnlShiftItem.Size = new Size(140, 84);
            SetupLabel(lblShiftCode, "CA-DS-001", 9F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 10, 8, 110, 22);
            SetupLabel(lblShiftTime, "08:00 - 18:00", 8.5F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 10, 34, 110, 20);
            SetupLabel(lblShiftRoom, "Nhà thuốc", 8.5F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 10, 56, 110, 20);
            // 
            // legend
            // 
            ConfigureCard(pnlLegend, Color.White, Color.FromArgb(229, 231, 235));
            pnlLegend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLegend.Controls.Add(lblLegendRejected);
            pnlLegend.Controls.Add(lblLegendApproved);
            pnlLegend.Controls.Add(lblLegendChange);
            pnlLegend.Controls.Add(lblLegendScheduled);
            pnlLegend.Controls.Add(lblLegend);
            pnlLegend.Location = new Point(24, 758);
            pnlLegend.Size = new Size(1196, 58);
            SetupLabel(lblLegend, "Trạng thái:", 10F, FontStyle.Bold, Color.FromArgb(55, 65, 81), 22, 16, 100, 26);
            SetupLabel(lblLegendScheduled, "■  Đã lên lịch", 10F, FontStyle.Regular, Color.FromArgb(75, 85, 99), 130, 16, 130, 26);
            SetupLabel(lblLegendChange, "■  Chờ đổi ca", 10F, FontStyle.Regular, Color.FromArgb(75, 85, 99), 270, 16, 130, 26);
            SetupLabel(lblLegendApproved, "■  Đã duyệt", 10F, FontStyle.Regular, Color.FromArgb(75, 85, 99), 410, 16, 120, 26);
            SetupLabel(lblLegendRejected, "■  Từ chối", 10F, FontStyle.Regular, Color.FromArgb(75, 85, 99), 540, 16, 120, 26);
            // 
            // ucPharmacyShifts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "ucPharmacyShifts";
            Size = new Size(1244, 900);
            viewHostPanel.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
            pnlRequests.ResumeLayout(false);
            pnlApproved.ResumeLayout(false);
            pnlSchedule.ResumeLayout(false);
            calendarGrid.ResumeLayout(false);
            pnlTue.ResumeLayout(false);
            pnlShiftItem.ResumeLayout(false);
            pnlLegend.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureCard(RoundedPanel panel, Color fill, Color border)
        {
            panel.BackColor = fill;
            panel.BorderColor = border;
            panel.CornerRadius = 8;
            panel.FillColor = fill;
        }

        private static void SetupLabel(Label label, string text, float size, FontStyle style, Color color, int x, int y, int width, int height, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            label.Font = new Font("Segoe UI", size, style);
            label.ForeColor = color;
            label.Location = new Point(x, y);
            label.Size = new Size(width, height);
            label.Text = text;
            label.TextAlign = align;
        }

        private static void SetupStatCard(RoundedPanel panel, Label icon, Label title, Label value, Label foot, string iconText, string titleText, string valueText, string footText, Color accent, Color iconBack, Padding margin)
        {
            ConfigureCard(panel, Color.White, Color.FromArgb(229, 231, 235));
            panel.Dock = DockStyle.Fill;
            panel.Margin = margin;
            panel.Controls.Add(icon);
            panel.Controls.Add(foot);
            panel.Controls.Add(value);
            panel.Controls.Add(title);
            SetupLabel(title, titleText, 10F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 22, 26, 220, 24);
            SetupLabel(value, valueText, 24F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 22, 58, 80, 42);
            SetupLabel(foot, footText, 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 22, 96, 160, 24);
            SetupLabel(icon, iconText, 24F, FontStyle.Bold, accent, 308, 34, 58, 58, ContentAlignment.MiddleCenter);
            icon.BackColor = iconBack;
        }

        private static void SetupNavButton(Button button, int x, int y, int width, int height, Color back, Color fore)
        {
            button.BackColor = back;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.ForeColor = fore;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.UseVisualStyleBackColor = false;
        }

        private static void SetupDayHeader(Label label, string text)
        {
            label.BackColor = Color.White;
            label.Dock = DockStyle.Fill;
            label.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(75, 85, 99);
            label.Text = text;
            label.TextAlign = ContentAlignment.MiddleCenter;
        }

        private RoundedPanel viewHostPanel;
        private Label lblHeading;
        private Label lblSubheading;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlTotal;
        private Label lblTotalTitle;
        private Label lblTotalValue;
        private Label lblTotalFoot;
        private Label lblTotalIcon;
        private RoundedPanel pnlRequests;
        private Label lblRequestsTitle;
        private Label lblRequestsValue;
        private Label lblRequestsFoot;
        private Label lblRequestsIcon;
        private RoundedPanel pnlApproved;
        private Label lblApprovedTitle;
        private Label lblApprovedValue;
        private Label lblApprovedFoot;
        private Label lblApprovedIcon;
        private RoundedPanel pnlSchedule;
        private Label lblTabSchedule;
        private Label lblTabHistory;
        private Button btnPrev;
        private Label lblWeek;
        private Button btnNext;
        private Button btnToday;
        private Button btnDay;
        private Button btnWeek;
        private Button btnMonth;
        private TableLayoutPanel calendarGrid;
        private Label lblMon;
        private Label lblTue;
        private Label lblWed;
        private Label lblThu;
        private Label lblFri;
        private Label lblSat;
        private Label lblSun;
        private Panel pnlMon;
        private Panel pnlTue;
        private Panel pnlWed;
        private Panel pnlThu;
        private Panel pnlFri;
        private Panel pnlSat;
        private Panel pnlSun;
        private RoundedPanel pnlShiftItem;
        private Label lblShiftCode;
        private Label lblShiftTime;
        private Label lblShiftRoom;
        private RoundedPanel pnlLegend;
        private Label lblLegend;
        private Label lblLegendScheduled;
        private Label lblLegendChange;
        private Label lblLegendApproved;
        private Label lblLegendRejected;
    }
}
