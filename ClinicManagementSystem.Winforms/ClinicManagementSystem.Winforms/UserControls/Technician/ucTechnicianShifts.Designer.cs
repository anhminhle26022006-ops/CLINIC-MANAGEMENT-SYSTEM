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
            viewHostPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            pnlListPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            flpShiftsTable = new FlowLayoutPanel();
            lblListTitle = new Label();
            pnlCalendar = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            pnlDaysContainer = new Panel();
            pnlDay7 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept7 = new Label();
            lblRoom7 = new Label();
            btnShift7 = new Button();
            lblDayName7 = new Label();
            lblDayDate7 = new Label();
            pnlDay6 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept6 = new Label();
            lblRoom6 = new Label();
            btnShift6 = new Button();
            lblDayName6 = new Label();
            lblDayDate6 = new Label();
            pnlDay5 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept5 = new Label();
            lblRoom5 = new Label();
            btnShift5 = new Button();
            lblDayName5 = new Label();
            lblDayDate5 = new Label();
            pnlDay4 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept4 = new Label();
            lblRoom4 = new Label();
            btnShift4 = new Button();
            lblDayName4 = new Label();
            lblDayDate4 = new Label();
            pnlDay3 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept3 = new Label();
            lblRoom3 = new Label();
            btnShift3 = new Button();
            lblDayName3 = new Label();
            lblDayDate3 = new Label();
            pnlDay2 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept2 = new Label();
            lblRoom2 = new Label();
            btnShift2 = new Button();
            lblDayName2 = new Label();
            lblDayDate2 = new Label();
            pnlDay1 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblDept1 = new Label();
            lblRoom1 = new Label();
            btnShift1 = new Button();
            lblDayName1 = new Label();
            lblDayDate1 = new Label();
            lblCalendarTitle = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlStatTotal = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatTotalNum = new Label();
            lblStatTotalTitle = new Label();
            pnlStatActive = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatActiveNum = new Label();
            lblStatActiveTitle = new Label();
            pnlStatHours = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatHoursNum = new Label();
            lblStatHoursTitle = new Label();
            btnReg = new Button();
            lblSubtitle = new Label();
            lblTitle = new Label();
            viewHostPanel.SuspendLayout();
            pnlListPanel.SuspendLayout();
            pnlCalendar.SuspendLayout();
            pnlDaysContainer.SuspendLayout();
            pnlDay7.SuspendLayout();
            pnlDay6.SuspendLayout();
            pnlDay5.SuspendLayout();
            pnlDay4.SuspendLayout();
            pnlDay3.SuspendLayout();
            pnlDay2.SuspendLayout();
            pnlDay1.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlStatTotal.SuspendLayout();
            pnlStatActive.SuspendLayout();
            pnlStatHours.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlListPanel);
            viewHostPanel.Controls.Add(pnlCalendar);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Controls.Add(btnReg);
            viewHostPanel.Controls.Add(lblSubtitle);
            viewHostPanel.Controls.Add(lblTitle);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(3, 4, 3, 4);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1422, 992);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlListPanel
            // 
            pnlListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlListPanel.BackColor = Color.White;
            pnlListPanel.BorderColor = Color.FromArgb(229, 231, 235);
            pnlListPanel.BorderWidth = 1;
            pnlListPanel.Controls.Add(flpShiftsTable);
            pnlListPanel.Controls.Add(lblListTitle);
            pnlListPanel.CornerRadius = 8;
            pnlListPanel.FillColor = Color.White;
            pnlListPanel.Location = new Point(27, 704);
            pnlListPanel.Margin = new Padding(3, 4, 3, 4);
            pnlListPanel.Name = "pnlListPanel";
            pnlListPanel.Size = new Size(1367, 267);
            pnlListPanel.TabIndex = 5;
            // 
            // flpShiftsTable
            // 
            flpShiftsTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpShiftsTable.AutoScroll = true;
            flpShiftsTable.FlowDirection = FlowDirection.TopDown;
            flpShiftsTable.Location = new Point(21, 80);
            flpShiftsTable.Margin = new Padding(3, 4, 3, 4);
            flpShiftsTable.Name = "flpShiftsTable";
            flpShiftsTable.Size = new Size(1326, 167);
            flpShiftsTable.TabIndex = 1;
            flpShiftsTable.WrapContents = false;
            // 
            // lblListTitle
            // 
            lblListTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblListTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblListTitle.Location = new Point(21, 24);
            lblListTitle.Name = "lblListTitle";
            lblListTitle.Size = new Size(480, 37);
            lblListTitle.TabIndex = 0;
            lblListTitle.Text = "Danh sách ca trực chi tiết";
            // 
            // pnlCalendar
            // 
            pnlCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlCalendar.BackColor = Color.White;
            pnlCalendar.BorderColor = Color.FromArgb(229, 231, 235);
            pnlCalendar.BorderWidth = 1;
            pnlCalendar.Controls.Add(pnlDaysContainer);
            pnlCalendar.Controls.Add(lblCalendarTitle);
            pnlCalendar.CornerRadius = 8;
            pnlCalendar.FillColor = Color.White;
            pnlCalendar.Location = new Point(27, 296);
            pnlCalendar.Margin = new Padding(3, 4, 3, 4);
            pnlCalendar.Name = "pnlCalendar";
            pnlCalendar.Size = new Size(1367, 387);
            pnlCalendar.TabIndex = 4;
            // 
            // pnlDaysContainer
            // 
            pnlDaysContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDaysContainer.Controls.Add(pnlDay7);
            pnlDaysContainer.Controls.Add(pnlDay6);
            pnlDaysContainer.Controls.Add(pnlDay5);
            pnlDaysContainer.Controls.Add(pnlDay4);
            pnlDaysContainer.Controls.Add(pnlDay3);
            pnlDaysContainer.Controls.Add(pnlDay2);
            pnlDaysContainer.Controls.Add(pnlDay1);
            pnlDaysContainer.Location = new Point(21, 80);
            pnlDaysContainer.Margin = new Padding(3, 4, 3, 4);
            pnlDaysContainer.Name = "pnlDaysContainer";
            pnlDaysContainer.Size = new Size(1326, 280);
            pnlDaysContainer.TabIndex = 1;
            pnlDaysContainer.Paint += pnlDaysContainer_Paint;
            // 
            // pnlDay7
            // 
            pnlDay7.BackColor = Color.White;
            pnlDay7.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay7.BorderWidth = 1;
            pnlDay7.Controls.Add(lblDept7);
            pnlDay7.Controls.Add(lblRoom7);
            pnlDay7.Controls.Add(btnShift7);
            pnlDay7.Controls.Add(lblDayName7);
            pnlDay7.Controls.Add(lblDayDate7);
            pnlDay7.CornerRadius = 8;
            pnlDay7.FillColor = Color.White;
            pnlDay7.Location = new Point(1129, 5);
            pnlDay7.Margin = new Padding(3, 4, 3, 4);
            pnlDay7.Name = "pnlDay7";
            pnlDay7.Size = new Size(171, 267);
            pnlDay7.TabIndex = 6;
            // 
            // lblDept7
            // 
            lblDept7.Font = new Font("Segoe UI", 7.5F);
            lblDept7.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept7.Location = new Point(11, 117);
            lblDept7.Name = "lblDept7";
            lblDept7.Size = new Size(149, 48);
            lblDept7.TabIndex = 4;
            lblDept7.Text = "-";
            // 
            // lblRoom7
            // 
            lblRoom7.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom7.ForeColor = Color.FromArgb(107, 114, 128);
            lblRoom7.Location = new Point(11, 91);
            lblRoom7.Name = "lblRoom7";
            lblRoom7.Size = new Size(149, 24);
            lblRoom7.TabIndex = 3;
            lblRoom7.Text = "-";
            // 
            // btnShift7
            // 
            btnShift7.BackColor = Color.FromArgb(243, 244, 246);
            btnShift7.FlatAppearance.BorderSize = 0;
            btnShift7.FlatStyle = FlatStyle.Flat;
            btnShift7.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift7.ForeColor = Color.FromArgb(107, 114, 128);
            btnShift7.Location = new Point(11, 48);
            btnShift7.Margin = new Padding(3, 4, 3, 4);
            btnShift7.Name = "btnShift7";
            btnShift7.Size = new Size(149, 37);
            btnShift7.TabIndex = 2;
            btnShift7.Text = "Trống";
            btnShift7.UseVisualStyleBackColor = false;
            // 
            // lblDayName7
            // 
            lblDayName7.Font = new Font("Segoe UI", 9.5F);
            lblDayName7.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName7.Location = new Point(91, 13);
            lblDayName7.Name = "lblDayName7";
            lblDayName7.Size = new Size(69, 29);
            lblDayName7.TabIndex = 1;
            lblDayName7.Text = "CN";
            lblDayName7.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate7
            // 
            lblDayDate7.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate7.Location = new Point(11, 13);
            lblDayDate7.Name = "lblDayDate7";
            lblDayDate7.Size = new Size(69, 29);
            lblDayDate7.TabIndex = 0;
            lblDayDate7.Text = "dd/MM";
            // 
            // pnlDay6
            // 
            pnlDay6.BackColor = Color.White;
            pnlDay6.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay6.BorderWidth = 1;
            pnlDay6.Controls.Add(lblDept6);
            pnlDay6.Controls.Add(lblRoom6);
            pnlDay6.Controls.Add(btnShift6);
            pnlDay6.Controls.Add(lblDayName6);
            pnlDay6.Controls.Add(lblDayDate6);
            pnlDay6.CornerRadius = 8;
            pnlDay6.FillColor = Color.White;
            pnlDay6.Location = new Point(942, 5);
            pnlDay6.Margin = new Padding(3, 4, 3, 4);
            pnlDay6.Name = "pnlDay6";
            pnlDay6.Size = new Size(171, 267);
            pnlDay6.TabIndex = 5;
            // 
            // lblDept6
            // 
            lblDept6.Font = new Font("Segoe UI", 7.5F);
            lblDept6.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept6.Location = new Point(11, 117);
            lblDept6.Name = "lblDept6";
            lblDept6.Size = new Size(149, 48);
            lblDept6.TabIndex = 4;
            lblDept6.Text = "-";
            // 
            // lblRoom6
            // 
            lblRoom6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom6.ForeColor = Color.FromArgb(107, 114, 128);
            lblRoom6.Location = new Point(11, 91);
            lblRoom6.Name = "lblRoom6";
            lblRoom6.Size = new Size(149, 24);
            lblRoom6.TabIndex = 3;
            lblRoom6.Text = "-";
            // 
            // btnShift6
            // 
            btnShift6.BackColor = Color.FromArgb(243, 244, 246);
            btnShift6.FlatAppearance.BorderSize = 0;
            btnShift6.FlatStyle = FlatStyle.Flat;
            btnShift6.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift6.ForeColor = Color.FromArgb(107, 114, 128);
            btnShift6.Location = new Point(11, 48);
            btnShift6.Margin = new Padding(3, 4, 3, 4);
            btnShift6.Name = "btnShift6";
            btnShift6.Size = new Size(149, 37);
            btnShift6.TabIndex = 2;
            btnShift6.Text = "Trống";
            btnShift6.UseVisualStyleBackColor = false;
            // 
            // lblDayName6
            // 
            lblDayName6.Font = new Font("Segoe UI", 9.5F);
            lblDayName6.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName6.Location = new Point(91, 13);
            lblDayName6.Name = "lblDayName6";
            lblDayName6.Size = new Size(69, 29);
            lblDayName6.TabIndex = 1;
            lblDayName6.Text = "Thứ 7";
            lblDayName6.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate6
            // 
            lblDayDate6.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate6.Location = new Point(11, 13);
            lblDayDate6.Name = "lblDayDate6";
            lblDayDate6.Size = new Size(69, 29);
            lblDayDate6.TabIndex = 0;
            lblDayDate6.Text = "dd/MM";
            // 
            // pnlDay5
            // 
            pnlDay5.BackColor = Color.White;
            pnlDay5.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay5.BorderWidth = 1;
            pnlDay5.Controls.Add(lblDept5);
            pnlDay5.Controls.Add(lblRoom5);
            pnlDay5.Controls.Add(btnShift5);
            pnlDay5.Controls.Add(lblDayName5);
            pnlDay5.Controls.Add(lblDayDate5);
            pnlDay5.CornerRadius = 8;
            pnlDay5.FillColor = Color.White;
            pnlDay5.Location = new Point(754, 5);
            pnlDay5.Margin = new Padding(3, 4, 3, 4);
            pnlDay5.Name = "pnlDay5";
            pnlDay5.Size = new Size(171, 267);
            pnlDay5.TabIndex = 4;
            // 
            // lblDept5
            // 
            lblDept5.Font = new Font("Segoe UI", 7.5F);
            lblDept5.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept5.Location = new Point(11, 117);
            lblDept5.Name = "lblDept5";
            lblDept5.Size = new Size(149, 48);
            lblDept5.TabIndex = 4;
            lblDept5.Text = "-";
            // 
            // lblRoom5
            // 
            lblRoom5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom5.ForeColor = Color.FromArgb(107, 114, 128);
            lblRoom5.Location = new Point(11, 91);
            lblRoom5.Name = "lblRoom5";
            lblRoom5.Size = new Size(149, 24);
            lblRoom5.TabIndex = 3;
            lblRoom5.Text = "-";
            // 
            // btnShift5
            // 
            btnShift5.BackColor = Color.FromArgb(243, 244, 246);
            btnShift5.FlatAppearance.BorderSize = 0;
            btnShift5.FlatStyle = FlatStyle.Flat;
            btnShift5.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift5.ForeColor = Color.FromArgb(107, 114, 128);
            btnShift5.Location = new Point(11, 48);
            btnShift5.Margin = new Padding(3, 4, 3, 4);
            btnShift5.Name = "btnShift5";
            btnShift5.Size = new Size(149, 37);
            btnShift5.TabIndex = 2;
            btnShift5.Text = "Trống";
            btnShift5.UseVisualStyleBackColor = false;
            // 
            // lblDayName5
            // 
            lblDayName5.Font = new Font("Segoe UI", 9.5F);
            lblDayName5.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName5.Location = new Point(91, 13);
            lblDayName5.Name = "lblDayName5";
            lblDayName5.Size = new Size(69, 29);
            lblDayName5.TabIndex = 1;
            lblDayName5.Text = "Thứ 6";
            lblDayName5.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate5
            // 
            lblDayDate5.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate5.Location = new Point(11, 13);
            lblDayDate5.Name = "lblDayDate5";
            lblDayDate5.Size = new Size(69, 29);
            lblDayDate5.TabIndex = 0;
            lblDayDate5.Text = "dd/MM";
            // 
            // pnlDay4
            // 
            pnlDay4.BackColor = Color.White;
            pnlDay4.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay4.BorderWidth = 1;
            pnlDay4.Controls.Add(lblDept4);
            pnlDay4.Controls.Add(lblRoom4);
            pnlDay4.Controls.Add(btnShift4);
            pnlDay4.Controls.Add(lblDayName4);
            pnlDay4.Controls.Add(lblDayDate4);
            pnlDay4.CornerRadius = 8;
            pnlDay4.FillColor = Color.White;
            pnlDay4.Location = new Point(567, 5);
            pnlDay4.Margin = new Padding(3, 4, 3, 4);
            pnlDay4.Name = "pnlDay4";
            pnlDay4.Size = new Size(171, 267);
            pnlDay4.TabIndex = 3;
            // 
            // lblDept4
            // 
            lblDept4.Font = new Font("Segoe UI", 7.5F);
            lblDept4.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept4.Location = new Point(11, 117);
            lblDept4.Name = "lblDept4";
            lblDept4.Size = new Size(149, 48);
            lblDept4.TabIndex = 4;
            lblDept4.Text = "Khoa Nội";
            // 
            // lblRoom4
            // 
            lblRoom4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom4.ForeColor = Color.FromArgb(47, 94, 240);
            lblRoom4.Location = new Point(11, 91);
            lblRoom4.Name = "lblRoom4";
            lblRoom4.Size = new Size(149, 24);
            lblRoom4.TabIndex = 3;
            lblRoom4.Text = "Phòng khám 103";
            // 
            // btnShift4
            // 
            btnShift4.BackColor = Color.FromArgb(254, 249, 195);
            btnShift4.FlatAppearance.BorderSize = 0;
            btnShift4.FlatStyle = FlatStyle.Flat;
            btnShift4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift4.ForeColor = Color.FromArgb(180, 83, 9);
            btnShift4.Location = new Point(11, 48);
            btnShift4.Margin = new Padding(3, 4, 3, 4);
            btnShift4.Name = "btnShift4";
            btnShift4.Size = new Size(149, 37);
            btnShift4.TabIndex = 2;
            btnShift4.Text = "Chiều";
            btnShift4.UseVisualStyleBackColor = false;
            // 
            // lblDayName4
            // 
            lblDayName4.Font = new Font("Segoe UI", 9.5F);
            lblDayName4.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName4.Location = new Point(91, 13);
            lblDayName4.Name = "lblDayName4";
            lblDayName4.Size = new Size(69, 29);
            lblDayName4.TabIndex = 1;
            lblDayName4.Text = "Thứ 5";
            lblDayName4.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate4
            // 
            lblDayDate4.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate4.Location = new Point(11, 13);
            lblDayDate4.Name = "lblDayDate4";
            lblDayDate4.Size = new Size(69, 29);
            lblDayDate4.TabIndex = 0;
            lblDayDate4.Text = "dd/MM";
            // 
            // pnlDay3
            // 
            pnlDay3.BackColor = Color.White;
            pnlDay3.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay3.BorderWidth = 1;
            pnlDay3.Controls.Add(lblDept3);
            pnlDay3.Controls.Add(lblRoom3);
            pnlDay3.Controls.Add(btnShift3);
            pnlDay3.Controls.Add(lblDayName3);
            pnlDay3.Controls.Add(lblDayDate3);
            pnlDay3.CornerRadius = 8;
            pnlDay3.FillColor = Color.White;
            pnlDay3.Location = new Point(379, 5);
            pnlDay3.Margin = new Padding(3, 4, 3, 4);
            pnlDay3.Name = "pnlDay3";
            pnlDay3.Size = new Size(171, 267);
            pnlDay3.TabIndex = 2;
            // 
            // lblDept3
            // 
            lblDept3.Font = new Font("Segoe UI", 7.5F);
            lblDept3.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept3.Location = new Point(11, 117);
            lblDept3.Name = "lblDept3";
            lblDept3.Size = new Size(149, 48);
            lblDept3.TabIndex = 4;
            lblDept3.Text = "Khoa Tim mạch";
            // 
            // lblRoom3
            // 
            lblRoom3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom3.ForeColor = Color.FromArgb(47, 94, 240);
            lblRoom3.Location = new Point(11, 91);
            lblRoom3.Name = "lblRoom3";
            lblRoom3.Size = new Size(149, 24);
            lblRoom3.TabIndex = 3;
            lblRoom3.Text = "Phòng khám 201";
            // 
            // btnShift3
            // 
            btnShift3.BackColor = Color.FromArgb(254, 249, 195);
            btnShift3.FlatAppearance.BorderSize = 0;
            btnShift3.FlatStyle = FlatStyle.Flat;
            btnShift3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift3.ForeColor = Color.FromArgb(180, 83, 9);
            btnShift3.Location = new Point(11, 48);
            btnShift3.Margin = new Padding(3, 4, 3, 4);
            btnShift3.Name = "btnShift3";
            btnShift3.Size = new Size(149, 37);
            btnShift3.TabIndex = 2;
            btnShift3.Text = "Sáng";
            btnShift3.UseVisualStyleBackColor = false;
            btnShift3.Click += btnShift3_Click;
            // 
            // lblDayName3
            // 
            lblDayName3.Font = new Font("Segoe UI", 9.5F);
            lblDayName3.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName3.Location = new Point(91, 13);
            lblDayName3.Name = "lblDayName3";
            lblDayName3.Size = new Size(69, 29);
            lblDayName3.TabIndex = 1;
            lblDayName3.Text = "Thứ 4";
            lblDayName3.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate3
            // 
            lblDayDate3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate3.Location = new Point(11, 13);
            lblDayDate3.Name = "lblDayDate3";
            lblDayDate3.Size = new Size(69, 29);
            lblDayDate3.TabIndex = 0;
            lblDayDate3.Text = "dd/MM";
            // 
            // pnlDay2
            // 
            pnlDay2.BackColor = Color.White;
            pnlDay2.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay2.BorderWidth = 1;
            pnlDay2.Controls.Add(lblDept2);
            pnlDay2.Controls.Add(lblRoom2);
            pnlDay2.Controls.Add(btnShift2);
            pnlDay2.Controls.Add(lblDayName2);
            pnlDay2.Controls.Add(lblDayDate2);
            pnlDay2.CornerRadius = 8;
            pnlDay2.FillColor = Color.White;
            pnlDay2.Location = new Point(192, 5);
            pnlDay2.Margin = new Padding(3, 4, 3, 4);
            pnlDay2.Name = "pnlDay2";
            pnlDay2.Size = new Size(171, 267);
            pnlDay2.TabIndex = 1;
            // 
            // lblDept2
            // 
            lblDept2.Font = new Font("Segoe UI", 7.5F);
            lblDept2.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept2.Location = new Point(11, 117);
            lblDept2.Name = "lblDept2";
            lblDept2.Size = new Size(149, 48);
            lblDept2.TabIndex = 4;
            lblDept2.Text = "Khoa Nội";
            // 
            // lblRoom2
            // 
            lblRoom2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom2.ForeColor = Color.FromArgb(47, 94, 240);
            lblRoom2.Location = new Point(11, 91);
            lblRoom2.Name = "lblRoom2";
            lblRoom2.Size = new Size(149, 24);
            lblRoom2.TabIndex = 3;
            lblRoom2.Text = "Phòng khám 102";
            // 
            // btnShift2
            // 
            btnShift2.BackColor = Color.FromArgb(254, 249, 195);
            btnShift2.FlatAppearance.BorderSize = 0;
            btnShift2.FlatStyle = FlatStyle.Flat;
            btnShift2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift2.ForeColor = Color.FromArgb(180, 83, 9);
            btnShift2.Location = new Point(11, 48);
            btnShift2.Margin = new Padding(3, 4, 3, 4);
            btnShift2.Name = "btnShift2";
            btnShift2.Size = new Size(149, 37);
            btnShift2.TabIndex = 2;
            btnShift2.Text = "Chiều";
            btnShift2.UseVisualStyleBackColor = false;
            // 
            // lblDayName2
            // 
            lblDayName2.Font = new Font("Segoe UI", 9.5F);
            lblDayName2.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName2.Location = new Point(91, 13);
            lblDayName2.Name = "lblDayName2";
            lblDayName2.Size = new Size(69, 29);
            lblDayName2.TabIndex = 1;
            lblDayName2.Text = "Thứ 3";
            lblDayName2.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate2
            // 
            lblDayDate2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate2.Location = new Point(11, 13);
            lblDayDate2.Name = "lblDayDate2";
            lblDayDate2.Size = new Size(69, 29);
            lblDayDate2.TabIndex = 0;
            lblDayDate2.Text = "dd/MM";
            lblDayDate2.Click += lblDayDate2_Click;
            // 
            // pnlDay1
            // 
            pnlDay1.BackColor = Color.White;
            pnlDay1.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDay1.BorderWidth = 1;
            pnlDay1.Controls.Add(lblDept1);
            pnlDay1.Controls.Add(lblRoom1);
            pnlDay1.Controls.Add(btnShift1);
            pnlDay1.Controls.Add(lblDayName1);
            pnlDay1.Controls.Add(lblDayDate1);
            pnlDay1.CornerRadius = 8;
            pnlDay1.FillColor = Color.White;
            pnlDay1.Location = new Point(5, 5);
            pnlDay1.Margin = new Padding(3, 4, 3, 4);
            pnlDay1.Name = "pnlDay1";
            pnlDay1.Size = new Size(171, 267);
            pnlDay1.TabIndex = 0;
            // 
            // lblDept1
            // 
            lblDept1.Font = new Font("Segoe UI", 7.5F);
            lblDept1.ForeColor = Color.FromArgb(107, 114, 128);
            lblDept1.Location = new Point(11, 117);
            lblDept1.Name = "lblDept1";
            lblDept1.Size = new Size(149, 48);
            lblDept1.TabIndex = 4;
            lblDept1.Text = "Khoa Nội";
            // 
            // lblRoom1
            // 
            lblRoom1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRoom1.ForeColor = Color.FromArgb(47, 94, 240);
            lblRoom1.Location = new Point(11, 91);
            lblRoom1.Name = "lblRoom1";
            lblRoom1.Size = new Size(149, 24);
            lblRoom1.TabIndex = 3;
            lblRoom1.Text = "Phòng khám 101";
            // 
            // btnShift1
            // 
            btnShift1.BackColor = Color.FromArgb(254, 249, 195);
            btnShift1.FlatAppearance.BorderSize = 0;
            btnShift1.FlatStyle = FlatStyle.Flat;
            btnShift1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnShift1.ForeColor = Color.FromArgb(180, 83, 9);
            btnShift1.Location = new Point(11, 48);
            btnShift1.Margin = new Padding(3, 4, 3, 4);
            btnShift1.Name = "btnShift1";
            btnShift1.Size = new Size(149, 37);
            btnShift1.TabIndex = 2;
            btnShift1.Text = "Sáng";
            btnShift1.UseVisualStyleBackColor = false;
            // 
            // lblDayName1
            // 
            lblDayName1.Font = new Font("Segoe UI", 9.5F);
            lblDayName1.ForeColor = Color.FromArgb(107, 114, 128);
            lblDayName1.Location = new Point(91, 13);
            lblDayName1.Name = "lblDayName1";
            lblDayName1.Size = new Size(69, 29);
            lblDayName1.TabIndex = 1;
            lblDayName1.Text = "Thứ 2";
            lblDayName1.TextAlign = ContentAlignment.TopRight;
            // 
            // lblDayDate1
            // 
            lblDayDate1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDayDate1.Location = new Point(11, 13);
            lblDayDate1.Name = "lblDayDate1";
            lblDayDate1.Size = new Size(69, 29);
            lblDayDate1.TabIndex = 0;
            lblDayDate1.Text = "dd/MM";
            lblDayDate1.Click += lblDayDate1_Click;
            // 
            // lblCalendarTitle
            // 
            lblCalendarTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblCalendarTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblCalendarTitle.Location = new Point(21, 24);
            lblCalendarTitle.Name = "lblCalendarTitle";
            lblCalendarTitle.Size = new Size(480, 37);
            lblCalendarTitle.TabIndex = 0;
            lblCalendarTitle.Text = "Lịch làm việc tuần này";
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 3;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.Controls.Add(pnlStatTotal, 0, 0);
            pnlStatsGrid.Controls.Add(pnlStatActive, 1, 0);
            pnlStatsGrid.Controls.Add(pnlStatHours, 2, 0);
            pnlStatsGrid.Location = new Point(27, 128);
            pnlStatsGrid.Margin = new Padding(3, 4, 3, 4);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1367, 147);
            pnlStatsGrid.TabIndex = 3;
            // 
            // pnlStatTotal
            // 
            pnlStatTotal.BackColor = Color.White;
            pnlStatTotal.BorderColor = Color.FromArgb(229, 231, 235);
            pnlStatTotal.BorderWidth = 1;
            pnlStatTotal.Controls.Add(lblStatTotalNum);
            pnlStatTotal.Controls.Add(lblStatTotalTitle);
            pnlStatTotal.CornerRadius = 8;
            pnlStatTotal.Dock = DockStyle.Fill;
            pnlStatTotal.FillColor = Color.White;
            pnlStatTotal.Location = new Point(0, 0);
            pnlStatTotal.Margin = new Padding(0, 0, 16, 0);
            pnlStatTotal.Name = "pnlStatTotal";
            pnlStatTotal.Size = new Size(439, 147);
            pnlStatTotal.TabIndex = 0;
            // 
            // lblStatTotalNum
            // 
            lblStatTotalNum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatTotalNum.ForeColor = Color.FromArgb(17, 24, 39);
            lblStatTotalNum.Location = new Point(105, 77);
            lblStatTotalNum.Name = "lblStatTotalNum";
            lblStatTotalNum.Size = new Size(183, 45);
            lblStatTotalNum.TabIndex = 1;
            lblStatTotalNum.Text = "0";
            // 
            // lblStatTotalTitle
            // 
            lblStatTotalTitle.Font = new Font("Segoe UI", 10F);
            lblStatTotalTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatTotalTitle.Location = new Point(105, 40);
            lblStatTotalTitle.Name = "lblStatTotalTitle";
            lblStatTotalTitle.Size = new Size(240, 32);
            lblStatTotalTitle.TabIndex = 0;
            lblStatTotalTitle.Text = "Tổng ca đăng ký";
            // 
            // pnlStatActive
            // 
            pnlStatActive.BackColor = Color.White;
            pnlStatActive.BorderColor = Color.FromArgb(229, 231, 235);
            pnlStatActive.BorderWidth = 1;
            pnlStatActive.Controls.Add(lblStatActiveNum);
            pnlStatActive.Controls.Add(lblStatActiveTitle);
            pnlStatActive.CornerRadius = 8;
            pnlStatActive.Dock = DockStyle.Fill;
            pnlStatActive.FillColor = Color.White;
            pnlStatActive.Location = new Point(455, 0);
            pnlStatActive.Margin = new Padding(0, 0, 16, 0);
            pnlStatActive.Name = "pnlStatActive";
            pnlStatActive.Size = new Size(439, 147);
            pnlStatActive.TabIndex = 1;
            // 
            // lblStatActiveNum
            // 
            lblStatActiveNum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatActiveNum.ForeColor = Color.FromArgb(17, 24, 39);
            lblStatActiveNum.Location = new Point(105, 77);
            lblStatActiveNum.Name = "lblStatActiveNum";
            lblStatActiveNum.Size = new Size(183, 45);
            lblStatActiveNum.TabIndex = 1;
            lblStatActiveNum.Text = "1";
            // 
            // lblStatActiveTitle
            // 
            lblStatActiveTitle.Font = new Font("Segoe UI", 10F);
            lblStatActiveTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatActiveTitle.Location = new Point(105, 40);
            lblStatActiveTitle.Name = "lblStatActiveTitle";
            lblStatActiveTitle.Size = new Size(240, 32);
            lblStatActiveTitle.TabIndex = 0;
            lblStatActiveTitle.Text = "Ca đang trực";
            // 
            // pnlStatHours
            // 
            pnlStatHours.BackColor = Color.White;
            pnlStatHours.BorderColor = Color.FromArgb(229, 231, 235);
            pnlStatHours.BorderWidth = 1;
            pnlStatHours.Controls.Add(lblStatHoursNum);
            pnlStatHours.Controls.Add(lblStatHoursTitle);
            pnlStatHours.CornerRadius = 8;
            pnlStatHours.Dock = DockStyle.Fill;
            pnlStatHours.FillColor = Color.White;
            pnlStatHours.Location = new Point(910, 0);
            pnlStatHours.Margin = new Padding(0);
            pnlStatHours.Name = "pnlStatHours";
            pnlStatHours.Size = new Size(457, 147);
            pnlStatHours.TabIndex = 2;
            // 
            // lblStatHoursNum
            // 
            lblStatHoursNum.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblStatHoursNum.ForeColor = Color.FromArgb(17, 24, 39);
            lblStatHoursNum.Location = new Point(105, 77);
            lblStatHoursNum.Name = "lblStatHoursNum";
            lblStatHoursNum.Size = new Size(183, 45);
            lblStatHoursNum.TabIndex = 1;
            lblStatHoursNum.Text = "0h";
            // 
            // lblStatHoursTitle
            // 
            lblStatHoursTitle.Font = new Font("Segoe UI", 10F);
            lblStatHoursTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblStatHoursTitle.Location = new Point(105, 40);
            lblStatHoursTitle.Name = "lblStatHoursTitle";
            lblStatHoursTitle.Size = new Size(240, 32);
            lblStatHoursTitle.TabIndex = 0;
            lblStatHoursTitle.Text = "Giờ hoàn thành";
            // 
            // btnReg
            // 
            btnReg.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReg.BackColor = Color.FromArgb(47, 94, 240);
            btnReg.Cursor = Cursors.Hand;
            btnReg.FlatAppearance.BorderSize = 0;
            btnReg.FlatStyle = FlatStyle.Flat;
            btnReg.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnReg.ForeColor = Color.White;
            btnReg.Location = new Point(1189, 32);
            btnReg.Margin = new Padding(3, 4, 3, 4);
            btnReg.Name = "btnReg";
            btnReg.Size = new Size(206, 56);
            btnReg.TabIndex = 2;
            btnReg.Text = "Đăng ký ca mới";
            btnReg.UseVisualStyleBackColor = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(27, 75);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(571, 37);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Xem ca trực và phòng khám được phân công của Kỹ thuật viên";
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(27, 32);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(457, 43);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Lịch Làm Việc";
            // 
            // ucTechnicianShifts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucTechnicianShifts";
            Size = new Size(1422, 992);
            Load += ucTechnicianShifts_Load;
            Resize += ucTechnicianShifts_Resize;
            viewHostPanel.ResumeLayout(false);
            pnlListPanel.ResumeLayout(false);
            pnlCalendar.ResumeLayout(false);
            pnlDaysContainer.ResumeLayout(false);
            pnlDay7.ResumeLayout(false);
            pnlDay6.ResumeLayout(false);
            pnlDay5.ResumeLayout(false);
            pnlDay4.ResumeLayout(false);
            pnlDay3.ResumeLayout(false);
            pnlDay2.ResumeLayout(false);
            pnlDay1.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlStatTotal.ResumeLayout(false);
            pnlStatActive.ResumeLayout(false);
            pnlStatHours.ResumeLayout(false);
            ResumeLayout(false);
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
