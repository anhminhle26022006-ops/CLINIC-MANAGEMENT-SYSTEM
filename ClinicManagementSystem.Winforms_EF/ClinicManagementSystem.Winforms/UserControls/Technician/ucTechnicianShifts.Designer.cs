namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianShifts
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
            this.viewHostPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnReg = new System.Windows.Forms.Button();
            this.pnlStatsGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatTotal = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatTotalNum = new System.Windows.Forms.Label();
            this.lblStatTotalTitle = new System.Windows.Forms.Label();
            this.pnlStatActive = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatActiveNum = new System.Windows.Forms.Label();
            this.lblStatActiveTitle = new System.Windows.Forms.Label();
            this.pnlStatHours = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatHoursNum = new System.Windows.Forms.Label();
            this.lblStatHoursTitle = new System.Windows.Forms.Label();
            this.pnlCalendar = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblCalendarTitle = new System.Windows.Forms.Label();
            this.pnlDaysContainer = new System.Windows.Forms.Panel();
            this.pnlDay1 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate1 = new System.Windows.Forms.Label();
            this.lblDayName1 = new System.Windows.Forms.Label();
            this.btnShift1 = new System.Windows.Forms.Button();
            this.lblRoom1 = new System.Windows.Forms.Label();
            this.lblDept1 = new System.Windows.Forms.Label();
            this.pnlDay2 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate2 = new System.Windows.Forms.Label();
            this.lblDayName2 = new System.Windows.Forms.Label();
            this.btnShift2 = new System.Windows.Forms.Button();
            this.lblRoom2 = new System.Windows.Forms.Label();
            this.lblDept2 = new System.Windows.Forms.Label();
            this.pnlDay3 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate3 = new System.Windows.Forms.Label();
            this.lblDayName3 = new System.Windows.Forms.Label();
            this.btnShift3 = new System.Windows.Forms.Button();
            this.lblRoom3 = new System.Windows.Forms.Label();
            this.lblDept3 = new System.Windows.Forms.Label();
            this.pnlDay4 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate4 = new System.Windows.Forms.Label();
            this.lblDayName4 = new System.Windows.Forms.Label();
            this.btnShift4 = new System.Windows.Forms.Button();
            this.lblRoom4 = new System.Windows.Forms.Label();
            this.lblDept4 = new System.Windows.Forms.Label();
            this.pnlDay5 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate5 = new System.Windows.Forms.Label();
            this.lblDayName5 = new System.Windows.Forms.Label();
            this.btnShift5 = new System.Windows.Forms.Button();
            this.lblRoom5 = new System.Windows.Forms.Label();
            this.lblDept5 = new System.Windows.Forms.Label();
            this.pnlDay6 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate6 = new System.Windows.Forms.Label();
            this.lblDayName6 = new System.Windows.Forms.Label();
            this.btnShift6 = new System.Windows.Forms.Button();
            this.lblRoom6 = new System.Windows.Forms.Label();
            this.lblDept6 = new System.Windows.Forms.Label();
            this.pnlDay7 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblDayDate7 = new System.Windows.Forms.Label();
            this.lblDayName7 = new System.Windows.Forms.Label();
            this.btnShift7 = new System.Windows.Forms.Button();
            this.lblRoom7 = new System.Windows.Forms.Label();
            this.lblDept7 = new System.Windows.Forms.Label();
            this.pnlListPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.flpShiftsTable = new System.Windows.Forms.FlowLayoutPanel();
            this.viewHostPanel.SuspendLayout();
            this.pnlStatsGrid.SuspendLayout();
            this.pnlStatTotal.SuspendLayout();
            this.pnlStatActive.SuspendLayout();
            this.pnlStatHours.SuspendLayout();
            this.pnlCalendar.SuspendLayout();
            this.pnlDaysContainer.SuspendLayout();
            this.pnlDay1.SuspendLayout();
            this.pnlDay2.SuspendLayout();
            this.pnlDay3.SuspendLayout();
            this.pnlDay4.SuspendLayout();
            this.pnlDay5.SuspendLayout();
            this.pnlDay6.SuspendLayout();
            this.pnlDay7.SuspendLayout();
            this.pnlListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.pnlListPanel);
            this.viewHostPanel.Controls.Add(this.pnlCalendar);
            this.viewHostPanel.Controls.Add(this.pnlStatsGrid);
            this.viewHostPanel.Controls.Add(this.btnReg);
            this.viewHostPanel.Controls.Add(this.lblSubtitle);
            this.viewHostPanel.Controls.Add(this.lblTitle);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 744);
            this.viewHostPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lịch Làm Việc";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(500, 28);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Xem ca trực và phòng khám được phân công của Kỹ thuật viên";
            // 
            // btnReg
            // 
            this.btnReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReg.FlatAppearance.BorderSize = 0;
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnReg.ForeColor = System.Drawing.Color.White;
            this.btnReg.Location = new System.Drawing.Point(1040, 24);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(180, 42);
            this.btnReg.TabIndex = 2;
            this.btnReg.Text = "Đăng ký ca mới";
            this.btnReg.UseVisualStyleBackColor = false;
            // 
            // pnlStatsGrid
            // 
            this.pnlStatsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatsGrid.ColumnCount = 3;
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlStatsGrid.Controls.Add(this.pnlStatTotal, 0, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatActive, 1, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatHours, 2, 0);
            this.pnlStatsGrid.Location = new System.Drawing.Point(24, 96);
            this.pnlStatsGrid.Name = "pnlStatsGrid";
            this.pnlStatsGrid.RowCount = 1;
            this.pnlStatsGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatsGrid.Size = new System.Drawing.Size(1196, 110);
            this.pnlStatsGrid.TabIndex = 3;
            // 
            // pnlStatTotal
            // 
            this.pnlStatTotal.BackColor = System.Drawing.Color.White;
            this.pnlStatTotal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatTotal.Controls.Add(this.lblStatTotalNum);
            this.pnlStatTotal.Controls.Add(this.lblStatTotalTitle);
            this.pnlStatTotal.CornerRadius = 8;
            this.pnlStatTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatTotal.FillColor = System.Drawing.Color.White;
            this.pnlStatTotal.Location = new System.Drawing.Point(0, 0);
            this.pnlStatTotal.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatTotal.Name = "pnlStatTotal";
            this.pnlStatTotal.Size = new System.Drawing.Size(384, 110);
            this.pnlStatTotal.TabIndex = 0;
            // 
            // lblStatTotalNum
            // 
            this.lblStatTotalNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatTotalNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblStatTotalNum.Location = new System.Drawing.Point(92, 58);
            this.lblStatTotalNum.Name = "lblStatTotalNum";
            this.lblStatTotalNum.Size = new System.Drawing.Size(160, 34);
            this.lblStatTotalNum.TabIndex = 1;
            this.lblStatTotalNum.Text = "0";
            // 
            // lblStatTotalTitle
            // 
            this.lblStatTotalTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatTotalTitle.Location = new System.Drawing.Point(92, 30);
            this.lblStatTotalTitle.Name = "lblStatTotalTitle";
            this.lblStatTotalTitle.Size = new System.Drawing.Size(210, 24);
            this.lblStatTotalTitle.TabIndex = 0;
            this.lblStatTotalTitle.Text = "Tổng ca đăng ký";
            // 
            // pnlStatActive
            // 
            this.pnlStatActive.BackColor = System.Drawing.Color.White;
            this.pnlStatActive.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatActive.Controls.Add(this.lblStatActiveNum);
            this.pnlStatActive.Controls.Add(this.lblStatActiveTitle);
            this.pnlStatActive.CornerRadius = 8;
            this.pnlStatActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatActive.FillColor = System.Drawing.Color.White;
            this.pnlStatActive.Location = new System.Drawing.Point(398, 0);
            this.pnlStatActive.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatActive.Name = "pnlStatActive";
            this.pnlStatActive.Size = new System.Drawing.Size(384, 110);
            this.pnlStatActive.TabIndex = 1;
            // 
            // lblStatActiveNum
            // 
            this.lblStatActiveNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatActiveNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblStatActiveNum.Location = new System.Drawing.Point(92, 58);
            this.lblStatActiveNum.Name = "lblStatActiveNum";
            this.lblStatActiveNum.Size = new System.Drawing.Size(160, 34);
            this.lblStatActiveNum.TabIndex = 1;
            this.lblStatActiveNum.Text = "1";
            // 
            // lblStatActiveTitle
            // 
            this.lblStatActiveTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatActiveTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatActiveTitle.Location = new System.Drawing.Point(92, 30);
            this.lblStatActiveTitle.Name = "lblStatActiveTitle";
            this.lblStatActiveTitle.Size = new System.Drawing.Size(210, 24);
            this.lblStatActiveTitle.TabIndex = 0;
            this.lblStatActiveTitle.Text = "Ca đang trực";
            // 
            // pnlStatHours
            // 
            this.pnlStatHours.BackColor = System.Drawing.Color.White;
            this.pnlStatHours.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatHours.Controls.Add(this.lblStatHoursNum);
            this.pnlStatHours.Controls.Add(this.lblStatHoursTitle);
            this.pnlStatHours.CornerRadius = 8;
            this.pnlStatHours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatHours.FillColor = System.Drawing.Color.White;
            this.pnlStatHours.Location = new System.Drawing.Point(796, 0);
            this.pnlStatHours.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatHours.Name = "pnlStatHours";
            this.pnlStatHours.Size = new System.Drawing.Size(400, 110);
            this.pnlStatHours.TabIndex = 2;
            // 
            // lblStatHoursNum
            // 
            this.lblStatHoursNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatHoursNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblStatHoursNum.Location = new System.Drawing.Point(92, 58);
            this.lblStatHoursNum.Name = "lblStatHoursNum";
            this.lblStatHoursNum.Size = new System.Drawing.Size(160, 34);
            this.lblStatHoursNum.TabIndex = 1;
            this.lblStatHoursNum.Text = "0h";
            // 
            // lblStatHoursTitle
            // 
            this.lblStatHoursTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatHoursTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatHoursTitle.Location = new System.Drawing.Point(92, 30);
            this.lblStatHoursTitle.Name = "lblStatHoursTitle";
            this.lblStatHoursTitle.Size = new System.Drawing.Size(210, 24);
            this.lblStatHoursTitle.TabIndex = 0;
            this.lblStatHoursTitle.Text = "Giờ hoàn thành";
            // 
            // pnlCalendar
            // 
            this.pnlCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCalendar.BackColor = System.Drawing.Color.White;
            this.pnlCalendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlCalendar.Controls.Add(this.pnlDaysContainer);
            this.pnlCalendar.Controls.Add(this.lblCalendarTitle);
            this.pnlCalendar.CornerRadius = 8;
            this.pnlCalendar.FillColor = System.Drawing.Color.White;
            this.pnlCalendar.Location = new System.Drawing.Point(24, 222);
            this.pnlCalendar.Name = "pnlCalendar";
            this.pnlCalendar.Size = new System.Drawing.Size(1196, 290);
            this.pnlCalendar.TabIndex = 4;
            // 
            // lblCalendarTitle
            // 
            this.lblCalendarTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblCalendarTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCalendarTitle.Location = new System.Drawing.Point(18, 18);
            this.lblCalendarTitle.Name = "lblCalendarTitle";
            this.lblCalendarTitle.Size = new System.Drawing.Size(420, 28);
            this.lblCalendarTitle.TabIndex = 0;
            this.lblCalendarTitle.Text = "Lịch làm việc tuần này";
            // 
            // pnlDaysContainer
            // 
            this.pnlDaysContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDaysContainer.Controls.Add(this.pnlDay7);
            this.pnlDaysContainer.Controls.Add(this.pnlDay6);
            this.pnlDaysContainer.Controls.Add(this.pnlDay5);
            this.pnlDaysContainer.Controls.Add(this.pnlDay4);
            this.pnlDaysContainer.Controls.Add(this.pnlDay3);
            this.pnlDaysContainer.Controls.Add(this.pnlDay2);
            this.pnlDaysContainer.Controls.Add(this.pnlDay1);
            this.pnlDaysContainer.Location = new System.Drawing.Point(18, 60);
            this.pnlDaysContainer.Name = "pnlDaysContainer";
            this.pnlDaysContainer.Size = new System.Drawing.Size(1160, 210);
            this.pnlDaysContainer.TabIndex = 1;
            // 
            // pnlDay1
            // 
            this.pnlDay1.BackColor = System.Drawing.Color.White;
            this.pnlDay1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay1.Controls.Add(this.lblDept1);
            this.pnlDay1.Controls.Add(this.lblRoom1);
            this.pnlDay1.Controls.Add(this.btnShift1);
            this.pnlDay1.Controls.Add(this.lblDayName1);
            this.pnlDay1.Controls.Add(this.lblDayDate1);
            this.pnlDay1.CornerRadius = 8;
            this.pnlDay1.FillColor = System.Drawing.Color.White;
            this.pnlDay1.Location = new System.Drawing.Point(4, 4);
            this.pnlDay1.Name = "pnlDay1";
            this.pnlDay1.Size = new System.Drawing.Size(150, 200);
            this.pnlDay1.TabIndex = 0;
            // 
            // lblDayDate1
            // 
            this.lblDayDate1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate1.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate1.Name = "lblDayDate1";
            this.lblDayDate1.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate1.TabIndex = 0;
            this.lblDayDate1.Text = "dd/MM";
            // 
            // lblDayName1
            // 
            this.lblDayName1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName1.Location = new System.Drawing.Point(80, 10);
            this.lblDayName1.Name = "lblDayName1";
            this.lblDayName1.Size = new System.Drawing.Size(60, 22);
            this.lblDayName1.TabIndex = 1;
            this.lblDayName1.Text = "Thứ 2";
            this.lblDayName1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift1
            // 
            this.btnShift1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.btnShift1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift1.FlatAppearance.BorderSize = 0;
            this.btnShift1.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.btnShift1.Location = new System.Drawing.Point(10, 36);
            this.btnShift1.Name = "btnShift1";
            this.btnShift1.Size = new System.Drawing.Size(130, 28);
            this.btnShift1.TabIndex = 2;
            this.btnShift1.Text = "Sáng";
            this.btnShift1.UseVisualStyleBackColor = false;
            // 
            // lblRoom1
            // 
            this.lblRoom1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblRoom1.Location = new System.Drawing.Point(10, 68);
            this.lblRoom1.Name = "lblRoom1";
            this.lblRoom1.Size = new System.Drawing.Size(130, 18);
            this.lblRoom1.TabIndex = 3;
            this.lblRoom1.Text = "Phòng khám 101";
            // 
            // lblDept1
            // 
            this.lblDept1.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept1.Location = new System.Drawing.Point(10, 88);
            this.lblDept1.Name = "lblDept1";
            this.lblDept1.Size = new System.Drawing.Size(130, 36);
            this.lblDept1.TabIndex = 4;
            this.lblDept1.Text = "Khoa Nội";
            // 
            // pnlDay2
            // 
            this.pnlDay2.BackColor = System.Drawing.Color.White;
            this.pnlDay2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay2.Controls.Add(this.lblDept2);
            this.pnlDay2.Controls.Add(this.lblRoom2);
            this.pnlDay2.Controls.Add(this.btnShift2);
            this.pnlDay2.Controls.Add(this.lblDayName2);
            this.pnlDay2.Controls.Add(this.lblDayDate2);
            this.pnlDay2.CornerRadius = 8;
            this.pnlDay2.FillColor = System.Drawing.Color.White;
            this.pnlDay2.Location = new System.Drawing.Point(168, 4);
            this.pnlDay2.Name = "pnlDay2";
            this.pnlDay2.Size = new System.Drawing.Size(150, 200);
            this.pnlDay2.TabIndex = 1;
            // 
            // lblDayDate2
            // 
            this.lblDayDate2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate2.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate2.Name = "lblDayDate2";
            this.lblDayDate2.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate2.TabIndex = 0;
            this.lblDayDate2.Text = "dd/MM";
            // 
            // lblDayName2
            // 
            this.lblDayName2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName2.Location = new System.Drawing.Point(80, 10);
            this.lblDayName2.Name = "lblDayName2";
            this.lblDayName2.Size = new System.Drawing.Size(60, 22);
            this.lblDayName2.TabIndex = 1;
            this.lblDayName2.Text = "Thứ 3";
            this.lblDayName2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift2
            // 
            this.btnShift2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.btnShift2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift2.FlatAppearance.BorderSize = 0;
            this.btnShift2.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.btnShift2.Location = new System.Drawing.Point(10, 36);
            this.btnShift2.Name = "btnShift2";
            this.btnShift2.Size = new System.Drawing.Size(130, 28);
            this.btnShift2.TabIndex = 2;
            this.btnShift2.Text = "Chiều";
            this.btnShift2.UseVisualStyleBackColor = false;
            // 
            // lblRoom2
            // 
            this.lblRoom2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblRoom2.Location = new System.Drawing.Point(10, 68);
            this.lblRoom2.Name = "lblRoom2";
            this.lblRoom2.Size = new System.Drawing.Size(130, 18);
            this.lblRoom2.TabIndex = 3;
            this.lblRoom2.Text = "Phòng khám 102";
            // 
            // lblDept2
            // 
            this.lblDept2.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept2.Location = new System.Drawing.Point(10, 88);
            this.lblDept2.Name = "lblDept2";
            this.lblDept2.Size = new System.Drawing.Size(130, 36);
            this.lblDept2.TabIndex = 4;
            this.lblDept2.Text = "Khoa Nội";
            // 
            // pnlDay3
            // 
            this.pnlDay3.BackColor = System.Drawing.Color.White;
            this.pnlDay3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay3.Controls.Add(this.lblDept3);
            this.pnlDay3.Controls.Add(this.lblRoom3);
            this.pnlDay3.Controls.Add(this.btnShift3);
            this.pnlDay3.Controls.Add(this.lblDayName3);
            this.pnlDay3.Controls.Add(this.lblDayDate3);
            this.pnlDay3.CornerRadius = 8;
            this.pnlDay3.FillColor = System.Drawing.Color.White;
            this.pnlDay3.Location = new System.Drawing.Point(332, 4);
            this.pnlDay3.Name = "pnlDay3";
            this.pnlDay3.Size = new System.Drawing.Size(150, 200);
            this.pnlDay3.TabIndex = 2;
            // 
            // lblDayDate3
            // 
            this.lblDayDate3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate3.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate3.Name = "lblDayDate3";
            this.lblDayDate3.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate3.TabIndex = 0;
            this.lblDayDate3.Text = "dd/MM";
            // 
            // lblDayName3
            // 
            this.lblDayName3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName3.Location = new System.Drawing.Point(80, 10);
            this.lblDayName3.Name = "lblDayName3";
            this.lblDayName3.Size = new System.Drawing.Size(60, 22);
            this.lblDayName3.TabIndex = 1;
            this.lblDayName3.Text = "Thứ 4";
            this.lblDayName3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift3
            // 
            this.btnShift3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.btnShift3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift3.FlatAppearance.BorderSize = 0;
            this.btnShift3.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.btnShift3.Location = new System.Drawing.Point(10, 36);
            this.btnShift3.Name = "btnShift3";
            this.btnShift3.Size = new System.Drawing.Size(130, 28);
            this.btnShift3.TabIndex = 2;
            this.btnShift3.Text = "Sáng";
            this.btnShift3.UseVisualStyleBackColor = false;
            // 
            // lblRoom3
            // 
            this.lblRoom3.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblRoom3.Location = new System.Drawing.Point(10, 68);
            this.lblRoom3.Name = "lblRoom3";
            this.lblRoom3.Size = new System.Drawing.Size(130, 18);
            this.lblRoom3.TabIndex = 3;
            this.lblRoom3.Text = "Phòng khám 201";
            // 
            // lblDept3
            // 
            this.lblDept3.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept3.Location = new System.Drawing.Point(10, 88);
            this.lblDept3.Name = "lblDept3";
            this.lblDept3.Size = new System.Drawing.Size(130, 36);
            this.lblDept3.TabIndex = 4;
            this.lblDept3.Text = "Khoa Tim mạch";
            // 
            // pnlDay4
            // 
            this.pnlDay4.BackColor = System.Drawing.Color.White;
            this.pnlDay4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay4.Controls.Add(this.lblDept4);
            this.pnlDay4.Controls.Add(this.lblRoom4);
            this.pnlDay4.Controls.Add(this.btnShift4);
            this.pnlDay4.Controls.Add(this.lblDayName4);
            this.pnlDay4.Controls.Add(this.lblDayDate4);
            this.pnlDay4.CornerRadius = 8;
            this.pnlDay4.FillColor = System.Drawing.Color.White;
            this.pnlDay4.Location = new System.Drawing.Point(496, 4);
            this.pnlDay4.Name = "pnlDay4";
            this.pnlDay4.Size = new System.Drawing.Size(150, 200);
            this.pnlDay4.TabIndex = 3;
            // 
            // lblDayDate4
            // 
            this.lblDayDate4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate4.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate4.Name = "lblDayDate4";
            this.lblDayDate4.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate4.TabIndex = 0;
            this.lblDayDate4.Text = "dd/MM";
            // 
            // lblDayName4
            // 
            this.lblDayName4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName4.Location = new System.Drawing.Point(80, 10);
            this.lblDayName4.Name = "lblDayName4";
            this.lblDayName4.Size = new System.Drawing.Size(60, 22);
            this.lblDayName4.TabIndex = 1;
            this.lblDayName4.Text = "Thứ 5";
            this.lblDayName4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift4
            // 
            this.btnShift4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(249)))), ((int)(((byte)(195)))));
            this.btnShift4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift4.FlatAppearance.BorderSize = 0;
            this.btnShift4.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.btnShift4.Location = new System.Drawing.Point(10, 36);
            this.btnShift4.Name = "btnShift4";
            this.btnShift4.Size = new System.Drawing.Size(130, 28);
            this.btnShift4.TabIndex = 2;
            this.btnShift4.Text = "Chiều";
            this.btnShift4.UseVisualStyleBackColor = false;
            // 
            // lblRoom4
            // 
            this.lblRoom4.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblRoom4.Location = new System.Drawing.Point(10, 68);
            this.lblRoom4.Name = "lblRoom4";
            this.lblRoom4.Size = new System.Drawing.Size(130, 18);
            this.lblRoom4.TabIndex = 3;
            this.lblRoom4.Text = "Phòng khám 103";
            // 
            // lblDept4
            // 
            this.lblDept4.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept4.Location = new System.Drawing.Point(10, 88);
            this.lblDept4.Name = "lblDept4";
            this.lblDept4.Size = new System.Drawing.Size(130, 36);
            this.lblDept4.TabIndex = 4;
            this.lblDept4.Text = "Khoa Nội";
            // 
            // pnlDay5
            // 
            this.pnlDay5.BackColor = System.Drawing.Color.White;
            this.pnlDay5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay5.Controls.Add(this.lblDept5);
            this.pnlDay5.Controls.Add(this.lblRoom5);
            this.pnlDay5.Controls.Add(this.btnShift5);
            this.pnlDay5.Controls.Add(this.lblDayName5);
            this.pnlDay5.Controls.Add(this.lblDayDate5);
            this.pnlDay5.CornerRadius = 8;
            this.pnlDay5.FillColor = System.Drawing.Color.White;
            this.pnlDay5.Location = new System.Drawing.Point(660, 4);
            this.pnlDay5.Name = "pnlDay5";
            this.pnlDay5.Size = new System.Drawing.Size(150, 200);
            this.pnlDay5.TabIndex = 4;
            // 
            // lblDayDate5
            // 
            this.lblDayDate5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate5.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate5.Name = "lblDayDate5";
            this.lblDayDate5.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate5.TabIndex = 0;
            this.lblDayDate5.Text = "dd/MM";
            // 
            // lblDayName5
            // 
            this.lblDayName5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName5.Location = new System.Drawing.Point(80, 10);
            this.lblDayName5.Name = "lblDayName5";
            this.lblDayName5.Size = new System.Drawing.Size(60, 22);
            this.lblDayName5.TabIndex = 1;
            this.lblDayName5.Text = "Thứ 6";
            this.lblDayName5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift5
            // 
            this.btnShift5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnShift5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift5.FlatAppearance.BorderSize = 0;
            this.btnShift5.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnShift5.Location = new System.Drawing.Point(10, 36);
            this.btnShift5.Name = "btnShift5";
            this.btnShift5.Size = new System.Drawing.Size(130, 28);
            this.btnShift5.TabIndex = 2;
            this.btnShift5.Text = "Trống";
            this.btnShift5.UseVisualStyleBackColor = false;
            // 
            // lblRoom5
            // 
            this.lblRoom5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblRoom5.Location = new System.Drawing.Point(10, 68);
            this.lblRoom5.Name = "lblRoom5";
            this.lblRoom5.Size = new System.Drawing.Size(130, 18);
            this.lblRoom5.TabIndex = 3;
            this.lblRoom5.Text = "-";
            // 
            // lblDept5
            // 
            this.lblDept5.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept5.Location = new System.Drawing.Point(10, 88);
            this.lblDept5.Name = "lblDept5";
            this.lblDept5.Size = new System.Drawing.Size(130, 36);
            this.lblDept5.TabIndex = 4;
            this.lblDept5.Text = "-";
            // 
            // pnlDay6
            // 
            this.pnlDay6.BackColor = System.Drawing.Color.White;
            this.pnlDay6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay6.Controls.Add(this.lblDept6);
            this.pnlDay6.Controls.Add(this.lblRoom6);
            this.pnlDay6.Controls.Add(this.btnShift6);
            this.pnlDay6.Controls.Add(this.lblDayName6);
            this.pnlDay6.Controls.Add(this.lblDayDate6);
            this.pnlDay6.CornerRadius = 8;
            this.pnlDay6.FillColor = System.Drawing.Color.White;
            this.pnlDay6.Location = new System.Drawing.Point(824, 4);
            this.pnlDay6.Name = "pnlDay6";
            this.pnlDay6.Size = new System.Drawing.Size(150, 200);
            this.pnlDay6.TabIndex = 5;
            // 
            // lblDayDate6
            // 
            this.lblDayDate6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate6.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate6.Name = "lblDayDate6";
            this.lblDayDate6.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate6.TabIndex = 0;
            this.lblDayDate6.Text = "dd/MM";
            // 
            // lblDayName6
            // 
            this.lblDayName6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName6.Location = new System.Drawing.Point(80, 10);
            this.lblDayName6.Name = "lblDayName6";
            this.lblDayName6.Size = new System.Drawing.Size(60, 22);
            this.lblDayName6.TabIndex = 1;
            this.lblDayName6.Text = "Thứ 7";
            this.lblDayName6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift6
            // 
            this.btnShift6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnShift6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift6.FlatAppearance.BorderSize = 0;
            this.btnShift6.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnShift6.Location = new System.Drawing.Point(10, 36);
            this.btnShift6.Name = "btnShift6";
            this.btnShift6.Size = new System.Drawing.Size(130, 28);
            this.btnShift6.TabIndex = 2;
            this.btnShift6.Text = "Trống";
            this.btnShift6.UseVisualStyleBackColor = false;
            // 
            // lblRoom6
            // 
            this.lblRoom6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblRoom6.Location = new System.Drawing.Point(10, 68);
            this.lblRoom6.Name = "lblRoom6";
            this.lblRoom6.Size = new System.Drawing.Size(130, 18);
            this.lblRoom6.TabIndex = 3;
            this.lblRoom6.Text = "-";
            // 
            // lblDept6
            // 
            this.lblDept6.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept6.Location = new System.Drawing.Point(10, 88);
            this.lblDept6.Name = "lblDept6";
            this.lblDept6.Size = new System.Drawing.Size(130, 36);
            this.lblDept6.TabIndex = 4;
            this.lblDept6.Text = "-";
            // 
            // pnlDay7
            // 
            this.pnlDay7.BackColor = System.Drawing.Color.White;
            this.pnlDay7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlDay7.Controls.Add(this.lblDept7);
            this.pnlDay7.Controls.Add(this.lblRoom7);
            this.pnlDay7.Controls.Add(this.btnShift7);
            this.pnlDay7.Controls.Add(this.lblDayName7);
            this.pnlDay7.Controls.Add(this.lblDayDate7);
            this.pnlDay7.CornerRadius = 8;
            this.pnlDay7.FillColor = System.Drawing.Color.White;
            this.pnlDay7.Location = new System.Drawing.Point(988, 4);
            this.pnlDay7.Name = "pnlDay7";
            this.pnlDay7.Size = new System.Drawing.Size(150, 200);
            this.pnlDay7.TabIndex = 6;
            // 
            // lblDayDate7
            // 
            this.lblDayDate7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDayDate7.Location = new System.Drawing.Point(10, 10);
            this.lblDayDate7.Name = "lblDayDate7";
            this.lblDayDate7.Size = new System.Drawing.Size(60, 22);
            this.lblDayDate7.TabIndex = 0;
            this.lblDayDate7.Text = "dd/MM";
            // 
            // lblDayName7
            // 
            this.lblDayName7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblDayName7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDayName7.Location = new System.Drawing.Point(80, 10);
            this.lblDayName7.Name = "lblDayName7";
            this.lblDayName7.Size = new System.Drawing.Size(60, 22);
            this.lblDayName7.TabIndex = 1;
            this.lblDayName7.Text = "CN";
            this.lblDayName7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnShift7
            // 
            this.btnShift7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnShift7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShift7.FlatAppearance.BorderSize = 0;
            this.btnShift7.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnShift7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnShift7.Location = new System.Drawing.Point(10, 36);
            this.btnShift7.Name = "btnShift7";
            this.btnShift7.Size = new System.Drawing.Size(130, 28);
            this.btnShift7.TabIndex = 2;
            this.btnShift7.Text = "Trống";
            this.btnShift7.UseVisualStyleBackColor = false;
            // 
            // lblRoom7
            // 
            this.lblRoom7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoom7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblRoom7.Location = new System.Drawing.Point(10, 68);
            this.lblRoom7.Name = "lblRoom7";
            this.lblRoom7.Size = new System.Drawing.Size(130, 18);
            this.lblRoom7.TabIndex = 3;
            this.lblRoom7.Text = "-";
            // 
            // lblDept7
            // 
            this.lblDept7.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblDept7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDept7.Location = new System.Drawing.Point(10, 88);
            this.lblDept7.Name = "lblDept7";
            this.lblDept7.Size = new System.Drawing.Size(130, 36);
            this.lblDept7.TabIndex = 4;
            this.lblDept7.Text = "-";
            // 
            // pnlListPanel
            // 
            this.pnlListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListPanel.BackColor = System.Drawing.Color.White;
            this.pnlListPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlListPanel.Controls.Add(this.flpShiftsTable);
            this.pnlListPanel.Controls.Add(this.lblListTitle);
            this.pnlListPanel.CornerRadius = 8;
            this.pnlListPanel.FillColor = System.Drawing.Color.White;
            this.pnlListPanel.Location = new System.Drawing.Point(24, 528);
            this.pnlListPanel.Name = "pnlListPanel";
            this.pnlListPanel.Size = new System.Drawing.Size(1196, 200);
            this.pnlListPanel.TabIndex = 5;
            // 
            // lblListTitle
            // 
            this.lblListTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblListTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblListTitle.Location = new System.Drawing.Point(18, 18);
            this.lblListTitle.Name = "lblListTitle";
            this.lblListTitle.Size = new System.Drawing.Size(420, 28);
            this.lblListTitle.TabIndex = 0;
            this.lblListTitle.Text = "Danh sách ca trực chi tiết";
            // 
            // flpShiftsTable
            // 
            this.flpShiftsTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpShiftsTable.AutoScroll = true;
            this.flpShiftsTable.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpShiftsTable.Location = new System.Drawing.Point(18, 60);
            this.flpShiftsTable.Name = "flpShiftsTable";
            this.flpShiftsTable.Size = new System.Drawing.Size(1160, 125);
            this.flpShiftsTable.TabIndex = 1;
            this.flpShiftsTable.WrapContents = false;
            // 
            // ucTechnicianShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianShifts";
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.ucTechnicianShifts_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianShifts_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlStatsGrid.ResumeLayout(false);
            this.pnlStatTotal.ResumeLayout(false);
            this.pnlStatActive.ResumeLayout(false);
            this.pnlStatHours.ResumeLayout(false);
            this.pnlCalendar.ResumeLayout(false);
            this.pnlDaysContainer.ResumeLayout(false);
            this.pnlDay1.ResumeLayout(false);
            this.pnlDay2.ResumeLayout(false);
            this.pnlDay3.ResumeLayout(false);
            this.pnlDay4.ResumeLayout(false);
            this.pnlDay5.ResumeLayout(false);
            this.pnlDay6.ResumeLayout(false);
            this.pnlDay7.ResumeLayout(false);
            this.pnlListPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TableLayoutPanel pnlStatsGrid;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatTotal;
        private System.Windows.Forms.Label lblStatTotalNum;
        private System.Windows.Forms.Label lblStatTotalTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatActive;
        private System.Windows.Forms.Label lblStatActiveNum;
        private System.Windows.Forms.Label lblStatActiveTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatHours;
        private System.Windows.Forms.Label lblStatHoursNum;
        private System.Windows.Forms.Label lblStatHoursTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlCalendar;
        private System.Windows.Forms.Label lblCalendarTitle;
        private System.Windows.Forms.Panel pnlDaysContainer;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay1;
        private System.Windows.Forms.Label lblDayDate1;
        private System.Windows.Forms.Label lblDayName1;
        private System.Windows.Forms.Button btnShift1;
        private System.Windows.Forms.Label lblRoom1;
        private System.Windows.Forms.Label lblDept1;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay2;
        private System.Windows.Forms.Label lblDayDate2;
        private System.Windows.Forms.Label lblDayName2;
        private System.Windows.Forms.Button btnShift2;
        private System.Windows.Forms.Label lblRoom2;
        private System.Windows.Forms.Label lblDept2;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay3;
        private System.Windows.Forms.Label lblDayDate3;
        private System.Windows.Forms.Label lblDayName3;
        private System.Windows.Forms.Button btnShift3;
        private System.Windows.Forms.Label lblRoom3;
        private System.Windows.Forms.Label lblDept3;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay4;
        private System.Windows.Forms.Label lblDayDate4;
        private System.Windows.Forms.Label lblDayName4;
        private System.Windows.Forms.Button btnShift4;
        private System.Windows.Forms.Label lblRoom4;
        private System.Windows.Forms.Label lblDept4;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay5;
        private System.Windows.Forms.Label lblDayDate5;
        private System.Windows.Forms.Label lblDayName5;
        private System.Windows.Forms.Button btnShift5;
        private System.Windows.Forms.Label lblRoom5;
        private System.Windows.Forms.Label lblDept5;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay6;
        private System.Windows.Forms.Label lblDayDate6;
        private System.Windows.Forms.Label lblDayName6;
        private System.Windows.Forms.Button btnShift6;
        private System.Windows.Forms.Label lblRoom6;
        private System.Windows.Forms.Label lblDept6;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlDay7;
        private System.Windows.Forms.Label lblDayDate7;
        private System.Windows.Forms.Label lblDayName7;
        private System.Windows.Forms.Button btnShift7;
        private System.Windows.Forms.Label lblRoom7;
        private System.Windows.Forms.Label lblDept7;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlListPanel;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.FlowLayoutPanel flpShiftsTable;
    }
}
