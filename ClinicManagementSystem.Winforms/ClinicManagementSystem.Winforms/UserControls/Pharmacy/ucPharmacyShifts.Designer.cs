using System;
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
            pnlLegend = new RoundedPanel();
            lblLegendRejected = new Label();
            lblLegendApproved = new Label();
            lblLegendChange = new Label();
            lblLegendScheduled = new Label();
            lblLegend = new Label();
            pnlSchedule = new RoundedPanel();
            calendarGrid = new TableLayoutPanel();
            lblMon = new Label();
            lblTue = new Label();
            lblWed = new Label();
            lblThu = new Label();
            lblFri = new Label();
            lblSat = new Label();
            lblSun = new Label();
            pnlMon = new Panel();
            btnShiftMon = new Button();
            pnlTue = new Panel();
            btnShiftTue = new Button();
            pnlWed = new Panel();
            btnShiftWed = new Button();
            pnlThu = new Panel();
            btnShiftThu = new Button();
            pnlFri = new Panel();
            btnShiftFri = new Button();
            pnlSat = new Panel();
            btnShiftSat = new Button();
            pnlSun = new Panel();
            btnShiftSun = new Button();
            btnMonth = new Button();
            btnWeek = new Button();
            btnDay = new Button();
            btnToday = new Button();
            btnNext = new Button();
            lblWeek = new Label();
            btnPrev = new Button();
            lblTabHistory = new Label();
            lblTabSchedule = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlTotal = new RoundedPanel();
            lblTotalIcon = new Label();
            lblTotalFoot = new Label();
            lblTotalValue = new Label();
            lblTotalTitle = new Label();
            pnlRequests = new RoundedPanel();
            lblRequestsIcon = new Label();
            lblRequestsFoot = new Label();
            lblRequestsValue = new Label();
            lblRequestsTitle = new Label();
            pnlApproved = new RoundedPanel();
            lblApprovedIcon = new Label();
            lblApprovedFoot = new Label();
            lblApprovedValue = new Label();
            lblApprovedTitle = new Label();
            lblSubheading = new Label();
            lblHeading = new Label();
            pnlShiftItem = new RoundedPanel();
            lblShiftRoom = new Label();
            lblShiftTime = new Label();
            lblShiftCode = new Label();
            viewHostPanel.SuspendLayout();
            pnlLegend.SuspendLayout();
            pnlSchedule.SuspendLayout();
            calendarGrid.SuspendLayout();
            pnlMon.SuspendLayout();
            pnlTue.SuspendLayout();
            pnlWed.SuspendLayout();
            pnlThu.SuspendLayout();
            pnlFri.SuspendLayout();
            pnlSat.SuspendLayout();
            pnlSun.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlTotal.SuspendLayout();
            pnlRequests.SuspendLayout();
            pnlApproved.SuspendLayout();
            pnlShiftItem.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = true;
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlLegend);
            viewHostPanel.Controls.Add(pnlSchedule);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Controls.Add(lblSubheading);
            viewHostPanel.Controls.Add(lblHeading);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(5, 6, 5, 6);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(2133, 1800);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlLegend
            // 
            pnlLegend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlLegend.BackColor = Color.White;
            pnlLegend.BorderColor = Color.FromArgb(229, 231, 235);
            pnlLegend.BorderWidth = 1;
            pnlLegend.Controls.Add(lblLegendRejected);
            pnlLegend.Controls.Add(lblLegendApproved);
            pnlLegend.Controls.Add(lblLegendChange);
            pnlLegend.Controls.Add(lblLegendScheduled);
            pnlLegend.Controls.Add(lblLegend);
            pnlLegend.CornerRadius = 8;
            pnlLegend.FillColor = Color.White;
            pnlLegend.Location = new Point(41, 1516);
            pnlLegend.Margin = new Padding(5, 6, 5, 6);
            pnlLegend.Name = "pnlLegend";
            pnlLegend.Size = new Size(2050, 116);
            pnlLegend.TabIndex = 0;
            // 
            // lblLegendRejected
            // 
            lblLegendRejected.Font = new Font("Segoe UI", 10F);
            lblLegendRejected.ForeColor = Color.FromArgb(75, 85, 99);
            lblLegendRejected.Location = new Point(926, 32);
            lblLegendRejected.Margin = new Padding(5, 0, 5, 0);
            lblLegendRejected.Name = "lblLegendRejected";
            lblLegendRejected.Size = new Size(206, 52);
            lblLegendRejected.TabIndex = 0;
            lblLegendRejected.Text = "■  Từ chối";
            lblLegendRejected.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLegendApproved
            // 
            lblLegendApproved.Font = new Font("Segoe UI", 10F);
            lblLegendApproved.ForeColor = Color.FromArgb(75, 85, 99);
            lblLegendApproved.Location = new Point(703, 32);
            lblLegendApproved.Margin = new Padding(5, 0, 5, 0);
            lblLegendApproved.Name = "lblLegendApproved";
            lblLegendApproved.Size = new Size(206, 52);
            lblLegendApproved.TabIndex = 1;
            lblLegendApproved.Text = "■  Đã duyệt";
            lblLegendApproved.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLegendChange
            // 
            lblLegendChange.Font = new Font("Segoe UI", 10F);
            lblLegendChange.ForeColor = Color.FromArgb(75, 85, 99);
            lblLegendChange.Location = new Point(463, 32);
            lblLegendChange.Margin = new Padding(5, 0, 5, 0);
            lblLegendChange.Name = "lblLegendChange";
            lblLegendChange.Size = new Size(223, 52);
            lblLegendChange.TabIndex = 2;
            lblLegendChange.Text = "■  Chờ đổi ca";
            lblLegendChange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLegendScheduled
            // 
            lblLegendScheduled.Font = new Font("Segoe UI", 10F);
            lblLegendScheduled.ForeColor = Color.FromArgb(75, 85, 99);
            lblLegendScheduled.Location = new Point(223, 32);
            lblLegendScheduled.Margin = new Padding(5, 0, 5, 0);
            lblLegendScheduled.Name = "lblLegendScheduled";
            lblLegendScheduled.Size = new Size(223, 52);
            lblLegendScheduled.TabIndex = 3;
            lblLegendScheduled.Text = "■  Đã lên lịch";
            lblLegendScheduled.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLegend
            // 
            lblLegend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLegend.ForeColor = Color.FromArgb(55, 65, 81);
            lblLegend.Location = new Point(38, 32);
            lblLegend.Margin = new Padding(5, 0, 5, 0);
            lblLegend.Name = "lblLegend";
            lblLegend.Size = new Size(171, 52);
            lblLegend.TabIndex = 4;
            lblLegend.Text = "Trạng thái:";
            lblLegend.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSchedule
            // 
            pnlSchedule.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSchedule.BackColor = Color.White;
            pnlSchedule.BorderColor = Color.FromArgb(229, 231, 235);
            pnlSchedule.BorderWidth = 1;
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
            pnlSchedule.CornerRadius = 8;
            pnlSchedule.FillColor = Color.White;
            pnlSchedule.Location = new Point(41, 548);
            pnlSchedule.Margin = new Padding(5, 6, 5, 6);
            pnlSchedule.Name = "pnlSchedule";
            pnlSchedule.Size = new Size(2050, 920);
            pnlSchedule.TabIndex = 1;
            // 
            // calendarGrid
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
            calendarGrid.Location = new Point(38, 300);
            calendarGrid.Margin = new Padding(5, 6, 5, 6);
            calendarGrid.Name = "calendarGrid";
            calendarGrid.RowCount = 2;
            calendarGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
            calendarGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            calendarGrid.Size = new Size(1975, 540);
            calendarGrid.TabIndex = 0;
            // 
            // lblMon
            // 
            lblMon.BackColor = Color.White;
            lblMon.Dock = DockStyle.Fill;
            lblMon.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMon.ForeColor = Color.FromArgb(75, 85, 99);
            lblMon.Location = new Point(6, 1);
            lblMon.Margin = new Padding(5, 0, 5, 0);
            lblMon.Name = "lblMon";
            lblMon.Size = new Size(271, 160);
            lblMon.TabIndex = 0;
            lblMon.Text = "T2\r\n1";
            lblMon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTue
            // 
            lblTue.BackColor = Color.White;
            lblTue.Dock = DockStyle.Fill;
            lblTue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTue.ForeColor = Color.FromArgb(75, 85, 99);
            lblTue.Location = new Point(288, 1);
            lblTue.Margin = new Padding(5, 0, 5, 0);
            lblTue.Name = "lblTue";
            lblTue.Size = new Size(271, 160);
            lblTue.TabIndex = 1;
            lblTue.Text = "T3\r\n2";
            lblTue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWed
            // 
            lblWed.BackColor = Color.White;
            lblWed.Dock = DockStyle.Fill;
            lblWed.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWed.ForeColor = Color.FromArgb(75, 85, 99);
            lblWed.Location = new Point(570, 1);
            lblWed.Margin = new Padding(5, 0, 5, 0);
            lblWed.Name = "lblWed";
            lblWed.Size = new Size(271, 160);
            lblWed.TabIndex = 2;
            lblWed.Text = "T4\r\n3";
            lblWed.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblThu
            // 
            lblThu.BackColor = Color.White;
            lblThu.Dock = DockStyle.Fill;
            lblThu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblThu.ForeColor = Color.FromArgb(75, 85, 99);
            lblThu.Location = new Point(852, 1);
            lblThu.Margin = new Padding(5, 0, 5, 0);
            lblThu.Name = "lblThu";
            lblThu.Size = new Size(271, 160);
            lblThu.TabIndex = 3;
            lblThu.Text = "T5\r\n4";
            lblThu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFri
            // 
            lblFri.BackColor = Color.White;
            lblFri.Dock = DockStyle.Fill;
            lblFri.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFri.ForeColor = Color.FromArgb(75, 85, 99);
            lblFri.Location = new Point(1134, 1);
            lblFri.Margin = new Padding(5, 0, 5, 0);
            lblFri.Name = "lblFri";
            lblFri.Size = new Size(271, 160);
            lblFri.TabIndex = 4;
            lblFri.Text = "T6\r\n5";
            lblFri.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSat
            // 
            lblSat.BackColor = Color.FromArgb(239, 246, 255);
            lblSat.Dock = DockStyle.Fill;
            lblSat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSat.ForeColor = Color.FromArgb(75, 85, 99);
            lblSat.Location = new Point(1416, 1);
            lblSat.Margin = new Padding(5, 0, 5, 0);
            lblSat.Name = "lblSat";
            lblSat.Size = new Size(271, 160);
            lblSat.TabIndex = 5;
            lblSat.Text = "T7\r\n6";
            lblSat.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSun
            // 
            lblSun.BackColor = Color.White;
            lblSun.Dock = DockStyle.Fill;
            lblSun.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblSun.ForeColor = Color.FromArgb(75, 85, 99);
            lblSun.Location = new Point(1698, 1);
            lblSun.Margin = new Padding(5, 0, 5, 0);
            lblSun.Name = "lblSun";
            lblSun.Size = new Size(271, 160);
            lblSun.TabIndex = 6;
            lblSun.Text = "CN\r\n7";
            lblSun.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMon
            // 
            pnlMon.Controls.Add(btnShiftMon);
            pnlMon.Dock = DockStyle.Fill;
            pnlMon.Location = new Point(6, 168);
            pnlMon.Margin = new Padding(5, 6, 5, 6);
            pnlMon.Name = "pnlMon";
            pnlMon.Padding = new Padding(17, 20, 17, 20);
            pnlMon.Size = new Size(271, 365);
            pnlMon.TabIndex = 7;
            // 
            // btnShiftMon
            // 
            btnShiftMon.Location = new Point(0, 0);
            btnShiftMon.Margin = new Padding(5, 6, 5, 6);
            btnShiftMon.Name = "btnShiftMon";
            btnShiftMon.Size = new Size(129, 46);
            btnShiftMon.TabIndex = 0;
            // 
            // pnlTue
            // 
            pnlTue.Controls.Add(btnShiftTue);
            pnlTue.Dock = DockStyle.Fill;
            pnlTue.Location = new Point(288, 168);
            pnlTue.Margin = new Padding(5, 6, 5, 6);
            pnlTue.Name = "pnlTue";
            pnlTue.Padding = new Padding(17, 20, 17, 20);
            pnlTue.Size = new Size(271, 365);
            pnlTue.TabIndex = 8;
            // 
            // btnShiftTue
            // 
            btnShiftTue.Location = new Point(0, 0);
            btnShiftTue.Margin = new Padding(5, 6, 5, 6);
            btnShiftTue.Name = "btnShiftTue";
            btnShiftTue.Size = new Size(129, 46);
            btnShiftTue.TabIndex = 0;
            // 
            // pnlWed
            // 
            pnlWed.Controls.Add(btnShiftWed);
            pnlWed.Dock = DockStyle.Fill;
            pnlWed.Location = new Point(570, 168);
            pnlWed.Margin = new Padding(5, 6, 5, 6);
            pnlWed.Name = "pnlWed";
            pnlWed.Padding = new Padding(17, 20, 17, 20);
            pnlWed.Size = new Size(271, 365);
            pnlWed.TabIndex = 9;
            // 
            // btnShiftWed
            // 
            btnShiftWed.Location = new Point(0, 0);
            btnShiftWed.Margin = new Padding(5, 6, 5, 6);
            btnShiftWed.Name = "btnShiftWed";
            btnShiftWed.Size = new Size(129, 46);
            btnShiftWed.TabIndex = 0;
            // 
            // pnlThu
            // 
            pnlThu.Controls.Add(btnShiftThu);
            pnlThu.Dock = DockStyle.Fill;
            pnlThu.Location = new Point(852, 168);
            pnlThu.Margin = new Padding(5, 6, 5, 6);
            pnlThu.Name = "pnlThu";
            pnlThu.Padding = new Padding(17, 20, 17, 20);
            pnlThu.Size = new Size(271, 365);
            pnlThu.TabIndex = 10;
            // 
            // btnShiftThu
            // 
            btnShiftThu.Location = new Point(0, 0);
            btnShiftThu.Margin = new Padding(5, 6, 5, 6);
            btnShiftThu.Name = "btnShiftThu";
            btnShiftThu.Size = new Size(129, 46);
            btnShiftThu.TabIndex = 0;
            // 
            // pnlFri
            // 
            pnlFri.Controls.Add(btnShiftFri);
            pnlFri.Dock = DockStyle.Fill;
            pnlFri.Location = new Point(1134, 168);
            pnlFri.Margin = new Padding(5, 6, 5, 6);
            pnlFri.Name = "pnlFri";
            pnlFri.Padding = new Padding(17, 20, 17, 20);
            pnlFri.Size = new Size(271, 365);
            pnlFri.TabIndex = 11;
            // 
            // btnShiftFri
            // 
            btnShiftFri.Location = new Point(0, 0);
            btnShiftFri.Margin = new Padding(5, 6, 5, 6);
            btnShiftFri.Name = "btnShiftFri";
            btnShiftFri.Size = new Size(129, 46);
            btnShiftFri.TabIndex = 0;
            // 
            // pnlSat
            // 
            pnlSat.Controls.Add(btnShiftSat);
            pnlSat.Dock = DockStyle.Fill;
            pnlSat.Location = new Point(1416, 168);
            pnlSat.Margin = new Padding(5, 6, 5, 6);
            pnlSat.Name = "pnlSat";
            pnlSat.Padding = new Padding(17, 20, 17, 20);
            pnlSat.Size = new Size(271, 365);
            pnlSat.TabIndex = 12;
            // 
            // btnShiftSat
            // 
            btnShiftSat.Location = new Point(0, 0);
            btnShiftSat.Margin = new Padding(5, 6, 5, 6);
            btnShiftSat.Name = "btnShiftSat";
            btnShiftSat.Size = new Size(129, 46);
            btnShiftSat.TabIndex = 0;
            // 
            // pnlSun
            // 
            pnlSun.Controls.Add(btnShiftSun);
            pnlSun.Dock = DockStyle.Fill;
            pnlSun.Location = new Point(1698, 168);
            pnlSun.Margin = new Padding(5, 6, 5, 6);
            pnlSun.Name = "pnlSun";
            pnlSun.Padding = new Padding(17, 20, 17, 20);
            pnlSun.Size = new Size(271, 365);
            pnlSun.TabIndex = 13;
            // 
            // btnShiftSun
            // 
            btnShiftSun.Location = new Point(0, 0);
            btnShiftSun.Margin = new Padding(5, 6, 5, 6);
            btnShiftSun.Name = "btnShiftSun";
            btnShiftSun.Size = new Size(129, 46);
            btnShiftSun.TabIndex = 0;
            // 
            // btnMonth
            // 
            btnMonth.BackColor = Color.FromArgb(243, 244, 246);
            btnMonth.Cursor = Cursors.Hand;
            btnMonth.FlatAppearance.BorderSize = 0;
            btnMonth.FlatStyle = FlatStyle.Flat;
            btnMonth.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnMonth.ForeColor = Color.FromArgb(31, 41, 55);
            btnMonth.Location = new Point(1896, 172);
            btnMonth.Margin = new Padding(5, 6, 5, 6);
            btnMonth.Name = "btnMonth";
            btnMonth.Size = new Size(120, 80);
            btnMonth.TabIndex = 1;
            btnMonth.Text = "Tháng";
            btnMonth.UseVisualStyleBackColor = false;
            // 
            // btnWeek
            // 
            btnWeek.BackColor = Color.FromArgb(47, 94, 240);
            btnWeek.Cursor = Cursors.Hand;
            btnWeek.FlatAppearance.BorderSize = 0;
            btnWeek.FlatStyle = FlatStyle.Flat;
            btnWeek.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnWeek.ForeColor = Color.White;
            btnWeek.Location = new Point(1759, 172);
            btnWeek.Margin = new Padding(5, 6, 5, 6);
            btnWeek.Name = "btnWeek";
            btnWeek.Size = new Size(120, 80);
            btnWeek.TabIndex = 2;
            btnWeek.Text = "Tuần";
            btnWeek.UseVisualStyleBackColor = false;
            // 
            // btnDay
            // 
            btnDay.BackColor = Color.FromArgb(243, 244, 246);
            btnDay.Cursor = Cursors.Hand;
            btnDay.FlatAppearance.BorderSize = 0;
            btnDay.FlatStyle = FlatStyle.Flat;
            btnDay.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDay.ForeColor = Color.FromArgb(31, 41, 55);
            btnDay.Location = new Point(1622, 172);
            btnDay.Margin = new Padding(5, 6, 5, 6);
            btnDay.Name = "btnDay";
            btnDay.Size = new Size(120, 80);
            btnDay.TabIndex = 3;
            btnDay.Text = "Ngày";
            btnDay.UseVisualStyleBackColor = false;
            // 
            // btnToday
            // 
            btnToday.BackColor = Color.FromArgb(47, 94, 240);
            btnToday.Cursor = Cursors.Hand;
            btnToday.FlatAppearance.BorderSize = 0;
            btnToday.FlatStyle = FlatStyle.Flat;
            btnToday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnToday.ForeColor = Color.White;
            btnToday.Location = new Point(710, 172);
            btnToday.Margin = new Padding(5, 6, 5, 6);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(154, 80);
            btnToday.TabIndex = 4;
            btnToday.Text = "Hôm nay";
            btnToday.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.White;
            btnNext.Cursor = Cursors.Hand;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNext.ForeColor = Color.FromArgb(31, 41, 55);
            btnNext.Location = new Point(600, 176);
            btnNext.Margin = new Padding(5, 6, 5, 6);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(62, 72);
            btnNext.TabIndex = 5;
            btnNext.Text = "›";
            btnNext.UseVisualStyleBackColor = false;
            // 
            // lblWeek
            // 
            lblWeek.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblWeek.ForeColor = Color.FromArgb(17, 24, 39);
            lblWeek.Location = new Point(147, 172);
            lblWeek.Margin = new Padding(5, 0, 5, 0);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(446, 80);
            lblWeek.TabIndex = 6;
            lblWeek.Text = "Tuần 1, Tháng 6 2026";
            lblWeek.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.White;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPrev.ForeColor = Color.FromArgb(31, 41, 55);
            btnPrev.Location = new Point(58, 176);
            btnPrev.Margin = new Padding(5, 6, 5, 6);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(62, 72);
            btnPrev.TabIndex = 7;
            btnPrev.Text = "‹";
            btnPrev.UseVisualStyleBackColor = false;
            // 
            // lblTabHistory
            // 
            lblTabHistory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTabHistory.ForeColor = Color.FromArgb(75, 85, 99);
            lblTabHistory.Location = new Point(1063, 36);
            lblTabHistory.Margin = new Padding(5, 0, 5, 0);
            lblTabHistory.Name = "lblTabHistory";
            lblTabHistory.Size = new Size(617, 68);
            lblTabHistory.TabIndex = 8;
            lblTabHistory.Text = "◷  Lịch sử đổi ca";
            lblTabHistory.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTabSchedule
            // 
            lblTabSchedule.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTabSchedule.ForeColor = Color.FromArgb(47, 94, 240);
            lblTabSchedule.Location = new Point(377, 36);
            lblTabSchedule.Margin = new Padding(5, 0, 5, 0);
            lblTabSchedule.Name = "lblTabSchedule";
            lblTabSchedule.Size = new Size(617, 68);
            lblTabSchedule.TabIndex = 9;
            lblTabSchedule.Text = "▣  Lịch làm việc";
            lblTabSchedule.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 3;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.Controls.Add(pnlTotal, 0, 0);
            pnlStatsGrid.Controls.Add(pnlRequests, 1, 0);
            pnlStatsGrid.Controls.Add(pnlApproved, 2, 0);
            pnlStatsGrid.Location = new Point(41, 252);
            pnlStatsGrid.Margin = new Padding(5, 6, 5, 6);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(2050, 240);
            pnlStatsGrid.TabIndex = 2;
            // 
            // pnlTotal
            // 
            pnlTotal.BackColor = Color.White;
            pnlTotal.BorderColor = Color.FromArgb(229, 231, 235);
            pnlTotal.BorderWidth = 1;
            pnlTotal.Controls.Add(lblTotalIcon);
            pnlTotal.Controls.Add(lblTotalFoot);
            pnlTotal.Controls.Add(lblTotalValue);
            pnlTotal.Controls.Add(lblTotalTitle);
            pnlTotal.CornerRadius = 8;
            pnlTotal.Dock = DockStyle.Fill;
            pnlTotal.FillColor = Color.White;
            pnlTotal.Location = new Point(0, 0);
            pnlTotal.Margin = new Padding(0, 0, 31, 0);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(652, 240);
            pnlTotal.TabIndex = 0;
            // 
            // lblTotalIcon
            // 
            lblTotalIcon.BackColor = Color.FromArgb(219, 234, 254);
            lblTotalIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalIcon.ForeColor = Color.FromArgb(47, 94, 240);
            lblTotalIcon.Location = new Point(528, 68);
            lblTotalIcon.Margin = new Padding(5, 0, 5, 0);
            lblTotalIcon.Name = "lblTotalIcon";
            lblTotalIcon.Size = new Size(99, 116);
            lblTotalIcon.TabIndex = 0;
            lblTotalIcon.Text = "▣";
            lblTotalIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalFoot
            // 
            lblTotalFoot.Font = new Font("Segoe UI", 9F);
            lblTotalFoot.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalFoot.Location = new Point(38, 192);
            lblTotalFoot.Margin = new Padding(5, 0, 5, 0);
            lblTotalFoot.Name = "lblTotalFoot";
            lblTotalFoot.Size = new Size(274, 33);
            lblTotalFoot.TabIndex = 1;
            lblTotalFoot.Text = "Tháng này";
            lblTotalFoot.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalValue
            // 
            lblTotalValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(17, 24, 39);
            lblTotalValue.Location = new Point(38, 116);
            lblTotalValue.Margin = new Padding(5, 0, 5, 0);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(137, 84);
            lblTotalValue.TabIndex = 2;
            lblTotalValue.Text = "1";
            lblTotalValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Font = new Font("Segoe UI", 10F);
            lblTotalTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblTotalTitle.Location = new Point(38, 52);
            lblTotalTitle.Margin = new Padding(5, 0, 5, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(377, 48);
            lblTotalTitle.TabIndex = 3;
            lblTotalTitle.Text = "Tổng số ca";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlRequests
            // 
            pnlRequests.BackColor = Color.White;
            pnlRequests.BorderColor = Color.FromArgb(229, 231, 235);
            pnlRequests.BorderWidth = 1;
            pnlRequests.Controls.Add(lblRequestsIcon);
            pnlRequests.Controls.Add(lblRequestsFoot);
            pnlRequests.Controls.Add(lblRequestsValue);
            pnlRequests.Controls.Add(lblRequestsTitle);
            pnlRequests.CornerRadius = 8;
            pnlRequests.Dock = DockStyle.Fill;
            pnlRequests.FillColor = Color.White;
            pnlRequests.Location = new Point(683, 0);
            pnlRequests.Margin = new Padding(0, 0, 31, 0);
            pnlRequests.Name = "pnlRequests";
            pnlRequests.Size = new Size(652, 240);
            pnlRequests.TabIndex = 1;
            // 
            // lblRequestsIcon
            // 
            lblRequestsIcon.BackColor = Color.FromArgb(254, 249, 195);
            lblRequestsIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRequestsIcon.ForeColor = Color.FromArgb(202, 138, 4);
            lblRequestsIcon.Location = new Point(528, 68);
            lblRequestsIcon.Margin = new Padding(5, 0, 5, 0);
            lblRequestsIcon.Name = "lblRequestsIcon";
            lblRequestsIcon.Size = new Size(99, 116);
            lblRequestsIcon.TabIndex = 0;
            lblRequestsIcon.Text = "↻";
            lblRequestsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRequestsFoot
            // 
            lblRequestsFoot.Font = new Font("Segoe UI", 9F);
            lblRequestsFoot.ForeColor = Color.FromArgb(107, 114, 128);
            lblRequestsFoot.Location = new Point(38, 192);
            lblRequestsFoot.Margin = new Padding(5, 0, 5, 0);
            lblRequestsFoot.Name = "lblRequestsFoot";
            lblRequestsFoot.Size = new Size(274, 33);
            lblRequestsFoot.TabIndex = 1;
            lblRequestsFoot.Text = "Đang chờ duyệt";
            lblRequestsFoot.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRequestsValue
            // 
            lblRequestsValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRequestsValue.ForeColor = Color.FromArgb(17, 24, 39);
            lblRequestsValue.Location = new Point(38, 116);
            lblRequestsValue.Margin = new Padding(5, 0, 5, 0);
            lblRequestsValue.Name = "lblRequestsValue";
            lblRequestsValue.Size = new Size(137, 84);
            lblRequestsValue.TabIndex = 2;
            lblRequestsValue.Text = "0";
            lblRequestsValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRequestsTitle
            // 
            lblRequestsTitle.Font = new Font("Segoe UI", 10F);
            lblRequestsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblRequestsTitle.Location = new Point(38, 52);
            lblRequestsTitle.Margin = new Padding(5, 0, 5, 0);
            lblRequestsTitle.Name = "lblRequestsTitle";
            lblRequestsTitle.Size = new Size(377, 48);
            lblRequestsTitle.TabIndex = 3;
            lblRequestsTitle.Text = "Yêu cầu đổi ca";
            lblRequestsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlApproved
            // 
            pnlApproved.BackColor = Color.White;
            pnlApproved.BorderColor = Color.FromArgb(229, 231, 235);
            pnlApproved.BorderWidth = 1;
            pnlApproved.Controls.Add(lblApprovedIcon);
            pnlApproved.Controls.Add(lblApprovedFoot);
            pnlApproved.Controls.Add(lblApprovedValue);
            pnlApproved.Controls.Add(lblApprovedTitle);
            pnlApproved.CornerRadius = 8;
            pnlApproved.Dock = DockStyle.Fill;
            pnlApproved.FillColor = Color.White;
            pnlApproved.Location = new Point(1366, 0);
            pnlApproved.Margin = new Padding(0);
            pnlApproved.Name = "pnlApproved";
            pnlApproved.Size = new Size(684, 240);
            pnlApproved.TabIndex = 2;
            // 
            // lblApprovedIcon
            // 
            lblApprovedIcon.BackColor = Color.FromArgb(220, 252, 231);
            lblApprovedIcon.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblApprovedIcon.ForeColor = Color.FromArgb(34, 139, 74);
            lblApprovedIcon.Location = new Point(528, 68);
            lblApprovedIcon.Margin = new Padding(5, 0, 5, 0);
            lblApprovedIcon.Name = "lblApprovedIcon";
            lblApprovedIcon.Size = new Size(99, 116);
            lblApprovedIcon.TabIndex = 0;
            lblApprovedIcon.Text = "◷";
            lblApprovedIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblApprovedFoot
            // 
            lblApprovedFoot.Font = new Font("Segoe UI", 9F);
            lblApprovedFoot.ForeColor = Color.FromArgb(107, 114, 128);
            lblApprovedFoot.Location = new Point(38, 192);
            lblApprovedFoot.Margin = new Padding(5, 0, 5, 0);
            lblApprovedFoot.Name = "lblApprovedFoot";
            lblApprovedFoot.Size = new Size(274, 33);
            lblApprovedFoot.TabIndex = 1;
            lblApprovedFoot.Text = "Tháng này";
            lblApprovedFoot.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblApprovedValue
            // 
            lblApprovedValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblApprovedValue.ForeColor = Color.FromArgb(17, 24, 39);
            lblApprovedValue.Location = new Point(38, 116);
            lblApprovedValue.Margin = new Padding(5, 0, 5, 0);
            lblApprovedValue.Name = "lblApprovedValue";
            lblApprovedValue.Size = new Size(137, 84);
            lblApprovedValue.TabIndex = 2;
            lblApprovedValue.Text = "0";
            lblApprovedValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblApprovedTitle
            // 
            lblApprovedTitle.Font = new Font("Segoe UI", 10F);
            lblApprovedTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblApprovedTitle.Location = new Point(38, 52);
            lblApprovedTitle.Margin = new Padding(5, 0, 5, 0);
            lblApprovedTitle.Name = "lblApprovedTitle";
            lblApprovedTitle.Size = new Size(377, 48);
            lblApprovedTitle.TabIndex = 3;
            lblApprovedTitle.Text = "Đã được duyệt";
            lblApprovedTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSubheading
            // 
            lblSubheading.Font = new Font("Segoe UI", 10F);
            lblSubheading.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubheading.Location = new Point(41, 132);
            lblSubheading.Margin = new Padding(5, 0, 5, 0);
            lblSubheading.Name = "lblSubheading";
            lblSubheading.Size = new Size(789, 56);
            lblSubheading.TabIndex = 3;
            lblSubheading.Text = "Xem lịch làm việc và yêu cầu đổi ca";
            lblSubheading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHeading
            // 
            lblHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHeading.ForeColor = Color.FromArgb(17, 24, 39);
            lblHeading.Location = new Point(41, 48);
            lblHeading.Margin = new Padding(5, 0, 5, 0);
            lblHeading.Name = "lblHeading";
            lblHeading.Size = new Size(720, 80);
            lblHeading.TabIndex = 4;
            lblHeading.Text = "Quản lý ca làm việc";
            lblHeading.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlShiftItem
            // 
            pnlShiftItem.BackColor = Color.FromArgb(219, 234, 254);
            pnlShiftItem.BorderColor = Color.FromArgb(147, 197, 253);
            pnlShiftItem.BorderWidth = 1;
            pnlShiftItem.Controls.Add(lblShiftRoom);
            pnlShiftItem.Controls.Add(lblShiftTime);
            pnlShiftItem.Controls.Add(lblShiftCode);
            pnlShiftItem.CornerRadius = 8;
            pnlShiftItem.FillColor = Color.FromArgb(219, 234, 254);
            pnlShiftItem.Location = new Point(10, 14);
            pnlShiftItem.Name = "pnlShiftItem";
            pnlShiftItem.Size = new Size(140, 84);
            pnlShiftItem.TabIndex = 0;
            pnlShiftItem.Visible = false;
            // 
            // lblShiftRoom
            // 
            lblShiftRoom.Font = new Font("Segoe UI", 8.5F);
            lblShiftRoom.ForeColor = Color.FromArgb(55, 65, 81);
            lblShiftRoom.Location = new Point(10, 56);
            lblShiftRoom.Name = "lblShiftRoom";
            lblShiftRoom.Size = new Size(110, 20);
            lblShiftRoom.TabIndex = 0;
            lblShiftRoom.Text = "Nhà thuốc";
            lblShiftRoom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftTime
            // 
            lblShiftTime.Font = new Font("Segoe UI", 8.5F);
            lblShiftTime.ForeColor = Color.FromArgb(55, 65, 81);
            lblShiftTime.Location = new Point(10, 34);
            lblShiftTime.Name = "lblShiftTime";
            lblShiftTime.Size = new Size(110, 20);
            lblShiftTime.TabIndex = 1;
            lblShiftTime.Text = "08:00 - 18:00";
            lblShiftTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftCode
            // 
            lblShiftCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftCode.ForeColor = Color.FromArgb(17, 24, 39);
            lblShiftCode.Location = new Point(10, 8);
            lblShiftCode.Name = "lblShiftCode";
            lblShiftCode.Size = new Size(110, 22);
            lblShiftCode.TabIndex = 2;
            lblShiftCode.Text = "CA-DS-001";
            lblShiftCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucPharmacyShifts
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucPharmacyShifts";
            Size = new Size(2133, 1800);
            Load += ucPharmacyShifts_Load;
            Resize += ucPharmacyShifts_Resize;
            viewHostPanel.ResumeLayout(false);
            pnlLegend.ResumeLayout(false);
            pnlSchedule.ResumeLayout(false);
            calendarGrid.ResumeLayout(false);
            pnlMon.ResumeLayout(false);
            pnlTue.ResumeLayout(false);
            pnlWed.ResumeLayout(false);
            pnlThu.ResumeLayout(false);
            pnlFri.ResumeLayout(false);
            pnlSat.ResumeLayout(false);
            pnlSun.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
            pnlRequests.ResumeLayout(false);
            pnlApproved.ResumeLayout(false);
            pnlShiftItem.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupShiftDayButton(Button button)
        {
            button.BackColor = Color.FromArgb(219, 234, 254);
            button.Cursor = Cursors.Hand;
            button.Dock = DockStyle.Top;
            button.FlatAppearance.BorderColor = Color.FromArgb(147, 197, 253);
            button.FlatAppearance.BorderSize = 1;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            button.ForeColor = Color.FromArgb(17, 24, 39);
            button.Height = 86;
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.UseVisualStyleBackColor = false;
            button.Visible = false;
        }

        private void AdjustPharmacyShiftLayout()
        {
            if (viewHostPanel == null || viewHostPanel.ClientSize.Width <= 0 || viewHostPanel.ClientSize.Height <= 0)
            {
                return;
            }

            int pad = 24;
            int width = Math.Max(900, viewHostPanel.ClientSize.Width - pad * 2);

            lblHeading.Location = new Point(pad, 22);
            lblHeading.Size = new Size(Math.Max(360, width - 220), 38);
            lblSubheading.Location = new Point(pad, 62);
            lblSubheading.Size = new Size(Math.Max(360, width - 220), 26);

            pnlStatsGrid.Location = new Point(pad, 112);
            pnlStatsGrid.Size = new Size(width, 112);
            AdjustShiftStatCards();

            pnlSchedule.Location = new Point(pad, 248);
            int legendHeight = 54;
            int scheduleHeight = Math.Max(430, viewHostPanel.ClientSize.Height - pnlSchedule.Top - legendHeight - pad * 2);
            pnlSchedule.Size = new Size(width, scheduleHeight);

            lblTabSchedule.Location = new Point(22, 16);
            lblTabSchedule.Size = new Size(180, 32);
            lblTabHistory.Location = new Point(220, 16);
            lblTabHistory.Size = new Size(180, 32);

            btnPrev.Location = new Point(24, 70);
            lblWeek.Location = new Point(70, 68);
            lblWeek.Size = new Size(Math.Max(260, width / 3), 40);
            btnNext.Location = new Point(lblWeek.Right + 8, 70);
            btnToday.Location = new Point(btnNext.Right + 18, 68);

            btnMonth.Location = new Point(width - 92, 68);
            btnWeek.Location = new Point(btnMonth.Left - 82, 68);
            btnDay.Location = new Point(btnWeek.Left - 82, 68);

            calendarGrid.Location = new Point(22, 128);
            calendarGrid.Size = new Size(Math.Max(720, width - 44), Math.Max(260, pnlSchedule.ClientSize.Height - 150));
            calendarGrid.RowStyles[0].Height = 64;

            pnlLegend.Location = new Point(pad, pnlSchedule.Bottom + 12);
            pnlLegend.Size = new Size(width, legendHeight);

            ResizeShiftDayButtons();
        }

        private void AdjustShiftStatCards()
        {
            AdjustShiftStatCard(pnlTotal, lblTotalTitle, lblTotalValue, lblTotalFoot, lblTotalIcon);
            AdjustShiftStatCard(pnlRequests, lblRequestsTitle, lblRequestsValue, lblRequestsFoot, lblRequestsIcon);
            AdjustShiftStatCard(pnlApproved, lblApprovedTitle, lblApprovedValue, lblApprovedFoot, lblApprovedIcon);
        }

        private void AdjustShiftStatCard(RoundedPanel panel, Label title, Label value, Label foot, Label icon)
        {
            int iconSize = 54;
            icon.Size = new Size(iconSize, iconSize);
            icon.Location = new Point(Math.Max(190, panel.ClientSize.Width - iconSize - 24), 31);

            int textWidth = Math.Max(140, icon.Left - 44);
            title.Location = new Point(22, 20);
            title.Size = new Size(textWidth, 24);
            value.Location = new Point(22, 48);
            value.Size = new Size(textWidth, 38);
            foot.Location = new Point(22, 84);
            foot.Size = new Size(textWidth, 22);
        }

        private void ResizeShiftDayButtons()
        {
            foreach (Button button in ShiftButtons)
            {
                button.Height = Math.Max(72, Math.Min(96, calendarGrid.Height / 3));
            }
        }

        private void BindShiftStats(int totalShifts, int pendingRequests, int approvedThisMonth)
        {
            lblTotalValue.Text = totalShifts.ToString();
            lblRequestsValue.Text = pendingRequests.ToString();
            lblApprovedValue.Text = approvedThisMonth.ToString();
        }

        private void BindWeekLabel(DateTime weekStart)
        {
            DateTime weekEnd = weekStart.AddDays(6);
            lblWeek.Text = weekStart.ToString("dd/MM") + " - " + weekEnd.ToString("dd/MM/yyyy");
        }

        private void BindShiftDay(int index, DateTime day, string shiftCode, string timeText, string departmentText, bool hasShift)
        {
            Label header = DayHeaders[index];
            Button button = ShiftButtons[index];
            Panel body = DayBodies[index];
            bool isToday = day.Date == DateTime.Today.Date;

            header.Text = DayName(index) + "\r\n" + day.Day;
            header.BackColor = isToday ? Color.FromArgb(239, 246, 255) : Color.White;
            body.BackColor = isToday ? Color.FromArgb(248, 251, 255) : Color.White;

            button.Visible = hasShift;
            if (!hasShift)
            {
                button.Text = string.Empty;
                return;
            }

            button.Text = shiftCode + "\r\n" + timeText + "\r\n" + departmentText;
        }

        private string DayName(int index)
        {
            string[] names = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            return names[index];
        }

        private Label[] DayHeaders => new[] { lblMon, lblTue, lblWed, lblThu, lblFri, lblSat, lblSun };

        private Panel[] DayBodies => new[] { pnlMon, pnlTue, pnlWed, pnlThu, pnlFri, pnlSat, pnlSun };

        private Button[] ShiftButtons => new[] { btnShiftMon, btnShiftTue, btnShiftWed, btnShiftThu, btnShiftFri, btnShiftSat, btnShiftSun };



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
        private Button btnShiftMon;
        private Button btnShiftTue;
        private Button btnShiftWed;
        private Button btnShiftThu;
        private Button btnShiftFri;
        private Button btnShiftSat;
        private Button btnShiftSun;
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
