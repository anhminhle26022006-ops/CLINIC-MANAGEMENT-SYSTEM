namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    partial class doctordashboard
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
            pnlQuickActions = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            pnlActionGrid = new TableLayoutPanel();
            pnlActResult = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblActResultDesc = new Label();
            lblActResultTitle = new Label();
            pnlActPdf = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblActPdfDesc = new Label();
            lblActPdfTitle = new Label();
            pnlActScan = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblActScanDesc = new Label();
            lblActScanTitle = new Label();
            pnlActLab = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblActLabDesc = new Label();
            lblActLabTitle = new Label();
            lblActionsTitle = new Label();
            pnlShift = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblShiftFooter = new Label();
            btnChangeShift = new Button();
            btnViewWeek = new Button();
            pnlShiftBox = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblShiftDept = new Label();
            lblShiftRoom = new Label();
            lblShiftTodayText = new Label();
            lblShiftName = new Label();
            lblShiftBadge = new Label();
            lblShiftTitle = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlStatLab = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatLabNum = new Label();
            lblTodayAppointment = new Label();
            pnlStatScan = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatScanNum = new Label();
            lblPatientWaiting = new Label();
            pnlStatCompleted = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatCompletedNum = new Label();
            lblStatCompletedTitle = new Label();
            pnlStatProcessing = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            lblStatProcessingNum = new Label();
            lblStatProcessingTitle = new Label();
            viewHostPanel.SuspendLayout();
            pnlQuickActions.SuspendLayout();
            pnlActionGrid.SuspendLayout();
            pnlActResult.SuspendLayout();
            pnlActPdf.SuspendLayout();
            pnlActScan.SuspendLayout();
            pnlActLab.SuspendLayout();
            pnlShift.SuspendLayout();
            pnlShiftBox.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlStatLab.SuspendLayout();
            pnlStatScan.SuspendLayout();
            pnlStatCompleted.SuspendLayout();
            pnlStatProcessing.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = true;
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlQuickActions);
            viewHostPanel.Controls.Add(pnlShift);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(3, 4, 3, 4);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1422, 1333);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlQuickActions
            // 
            pnlQuickActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuickActions.BackColor = Color.White;
            pnlQuickActions.BorderColor = Color.FromArgb(229, 231, 235);
            pnlQuickActions.BorderWidth = 1;
            pnlQuickActions.Controls.Add(pnlActionGrid);
            pnlQuickActions.Controls.Add(lblActionsTitle);
            pnlQuickActions.CornerRadius = 8;
            pnlQuickActions.FillColor = Color.White;
            pnlQuickActions.Location = new Point(27, 893);
            pnlQuickActions.Margin = new Padding(3, 4, 3, 4);
            pnlQuickActions.Name = "pnlQuickActions";
            pnlQuickActions.Size = new Size(1367, 240);
            pnlQuickActions.TabIndex = 3;
            // 
            // pnlActionGrid
            // 
            pnlActionGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlActionGrid.ColumnCount = 4;
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.Controls.Add(pnlActResult, 3, 0);
            pnlActionGrid.Controls.Add(pnlActPdf, 2, 0);
            pnlActionGrid.Controls.Add(pnlActScan, 1, 0);
            pnlActionGrid.Controls.Add(pnlActLab, 0, 0);
            pnlActionGrid.Location = new Point(25, 77);
            pnlActionGrid.Margin = new Padding(3, 4, 3, 4);
            pnlActionGrid.Name = "pnlActionGrid";
            pnlActionGrid.RowCount = 1;
            pnlActionGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlActionGrid.Size = new Size(1314, 147);
            pnlActionGrid.TabIndex = 1;
            // 
            // pnlActResult
            // 
            pnlActResult.BackColor = Color.FromArgb(255, 247, 237);
            pnlActResult.BorderColor = Color.FromArgb(255, 247, 237);
            pnlActResult.BorderWidth = 1;
            pnlActResult.Controls.Add(lblActResultDesc);
            pnlActResult.Controls.Add(lblActResultTitle);
            pnlActResult.CornerRadius = 8;
            pnlActResult.Cursor = Cursors.Hand;
            pnlActResult.Dock = DockStyle.Fill;
            pnlActResult.FillColor = Color.FromArgb(255, 247, 237);
            pnlActResult.Location = new Point(984, 0);
            pnlActResult.Margin = new Padding(0);
            pnlActResult.Name = "pnlActResult";
            pnlActResult.Size = new Size(330, 147);
            pnlActResult.TabIndex = 3;
            // 
            // lblActResultDesc
            // 
            lblActResultDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActResultDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActResultDesc.Location = new Point(25, 91);
            lblActResultDesc.Name = "lblActResultDesc";
            lblActResultDesc.Size = new Size(240, 29);
            lblActResultDesc.TabIndex = 1;
            lblActResultDesc.Text = "Xem toa thuốc";
            // 
            // lblActResultTitle
            // 
            lblActResultTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActResultTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActResultTitle.Location = new Point(25, 56);
            lblActResultTitle.Name = "lblActResultTitle";
            lblActResultTitle.Size = new Size(240, 37);
            lblActResultTitle.TabIndex = 0;
            lblActResultTitle.Text = "Toa thuốc";
            // 
            // pnlActPdf
            // 
            pnlActPdf.BackColor = Color.FromArgb(240, 253, 244);
            pnlActPdf.BorderColor = Color.FromArgb(240, 253, 244);
            pnlActPdf.BorderWidth = 1;
            pnlActPdf.Controls.Add(lblActPdfDesc);
            pnlActPdf.Controls.Add(lblActPdfTitle);
            pnlActPdf.CornerRadius = 8;
            pnlActPdf.Cursor = Cursors.Hand;
            pnlActPdf.Dock = DockStyle.Fill;
            pnlActPdf.FillColor = Color.FromArgb(240, 253, 244);
            pnlActPdf.Location = new Point(656, 0);
            pnlActPdf.Margin = new Padding(0, 0, 16, 0);
            pnlActPdf.Name = "pnlActPdf";
            pnlActPdf.Size = new Size(312, 147);
            pnlActPdf.TabIndex = 2;
            // 
            // lblActPdfDesc
            // 
            lblActPdfDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActPdfDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActPdfDesc.Location = new Point(25, 91);
            lblActPdfDesc.Name = "lblActPdfDesc";
            lblActPdfDesc.Size = new Size(240, 29);
            lblActPdfDesc.TabIndex = 1;
            lblActPdfDesc.Text = "Xem bệnh án";
            // 
            // lblActPdfTitle
            // 
            lblActPdfTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActPdfTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActPdfTitle.Location = new Point(25, 56);
            lblActPdfTitle.Name = "lblActPdfTitle";
            lblActPdfTitle.Size = new Size(240, 37);
            lblActPdfTitle.TabIndex = 0;
            lblActPdfTitle.Text = "Bệnh án";
            // 
            // pnlActScan
            // 
            pnlActScan.BackColor = Color.FromArgb(239, 246, 255);
            pnlActScan.BorderColor = Color.FromArgb(239, 246, 255);
            pnlActScan.BorderWidth = 1;
            pnlActScan.Controls.Add(lblActScanDesc);
            pnlActScan.Controls.Add(lblActScanTitle);
            pnlActScan.CornerRadius = 8;
            pnlActScan.Cursor = Cursors.Hand;
            pnlActScan.Dock = DockStyle.Fill;
            pnlActScan.FillColor = Color.FromArgb(239, 246, 255);
            pnlActScan.Location = new Point(328, 0);
            pnlActScan.Margin = new Padding(0, 0, 16, 0);
            pnlActScan.Name = "pnlActScan";
            pnlActScan.Size = new Size(312, 147);
            pnlActScan.TabIndex = 1;
            // 
            // lblActScanDesc
            // 
            lblActScanDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActScanDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActScanDesc.Location = new Point(25, 91);
            lblActScanDesc.Name = "lblActScanDesc";
            lblActScanDesc.Size = new Size(240, 29);
            lblActScanDesc.TabIndex = 1;
            lblActScanDesc.Text = "Bắt đầu khám bệnh";
            // 
            // lblActScanTitle
            // 
            lblActScanTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActScanTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActScanTitle.Location = new Point(25, 56);
            lblActScanTitle.Name = "lblActScanTitle";
            lblActScanTitle.Size = new Size(240, 37);
            lblActScanTitle.TabIndex = 0;
            lblActScanTitle.Text = "Khám bệnh";
            // 
            // pnlActLab
            // 
            pnlActLab.BackColor = Color.FromArgb(250, 245, 255);
            pnlActLab.BorderColor = Color.FromArgb(250, 245, 255);
            pnlActLab.BorderWidth = 1;
            pnlActLab.Controls.Add(lblActLabDesc);
            pnlActLab.Controls.Add(lblActLabTitle);
            pnlActLab.CornerRadius = 8;
            pnlActLab.Cursor = Cursors.Hand;
            pnlActLab.Dock = DockStyle.Fill;
            pnlActLab.FillColor = Color.FromArgb(250, 245, 255);
            pnlActLab.Location = new Point(0, 0);
            pnlActLab.Margin = new Padding(0, 0, 16, 0);
            pnlActLab.Name = "pnlActLab";
            pnlActLab.Size = new Size(312, 147);
            pnlActLab.TabIndex = 0;
            // 
            // lblActLabDesc
            // 
            lblActLabDesc.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblActLabDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActLabDesc.Location = new Point(25, 91);
            lblActLabDesc.Name = "lblActLabDesc";
            lblActLabDesc.Size = new Size(240, 29);
            lblActLabDesc.TabIndex = 1;
            lblActLabDesc.Text = "Xem danh sách";
            // 
            // lblActLabTitle
            // 
            lblActLabTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActLabTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActLabTitle.Location = new Point(25, 56);
            lblActLabTitle.Name = "lblActLabTitle";
            lblActLabTitle.Size = new Size(240, 37);
            lblActLabTitle.TabIndex = 0;
            lblActLabTitle.Text = "Lịch khám";
            // 
            // lblActionsTitle
            // 
            lblActionsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblActionsTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActionsTitle.Location = new Point(21, 24);
            lblActionsTitle.Name = "lblActionsTitle";
            lblActionsTitle.Size = new Size(480, 37);
            lblActionsTitle.TabIndex = 0;
            lblActionsTitle.Text = "Hành động nhanh";
            // 
            // pnlShift
            // 
            pnlShift.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShift.BackColor = Color.White;
            pnlShift.BorderColor = Color.FromArgb(229, 231, 235);
            pnlShift.BorderWidth = 1;
            pnlShift.Controls.Add(lblShiftFooter);
            pnlShift.Controls.Add(btnChangeShift);
            pnlShift.Controls.Add(btnViewWeek);
            pnlShift.Controls.Add(pnlShiftBox);
            pnlShift.Controls.Add(lblShiftBadge);
            pnlShift.Controls.Add(lblShiftTitle);
            pnlShift.CornerRadius = 8;
            pnlShift.FillColor = Color.White;
            pnlShift.Location = new Point(27, 256);
            pnlShift.Margin = new Padding(3, 4, 3, 4);
            pnlShift.Name = "pnlShift";
            pnlShift.Size = new Size(1367, 347);
            pnlShift.TabIndex = 1;
            // 
            // lblShiftFooter
            // 
            lblShiftFooter.Anchor = AnchorStyles.Top;
            lblShiftFooter.Font = new Font("Segoe UI", 9F);
            lblShiftFooter.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftFooter.Location = new Point(571, 293);
            lblShiftFooter.Name = "lblShiftFooter";
            lblShiftFooter.Size = new Size(240, 29);
            lblShiftFooter.TabIndex = 5;
            lblShiftFooter.Text = "Quản lý ca làm việc nhanh chóng";
            lblShiftFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnChangeShift
            // 
            btnChangeShift.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeShift.BackColor = Color.FromArgb(243, 244, 246);
            btnChangeShift.Cursor = Cursors.Hand;
            btnChangeShift.FlatAppearance.BorderSize = 0;
            btnChangeShift.FlatStyle = FlatStyle.Flat;
            btnChangeShift.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChangeShift.ForeColor = Color.FromArgb(17, 24, 39);
            btnChangeShift.Location = new Point(699, 232);
            btnChangeShift.Margin = new Padding(3, 4, 3, 4);
            btnChangeShift.Name = "btnChangeShift";
            btnChangeShift.Size = new Size(640, 48);
            btnChangeShift.TabIndex = 4;
            btnChangeShift.Text = "Đổi ca";
            btnChangeShift.UseVisualStyleBackColor = false;
            // 
            // btnViewWeek
            // 
            btnViewWeek.BackColor = Color.FromArgb(239, 246, 255);
            btnViewWeek.Cursor = Cursors.Hand;
            btnViewWeek.FlatAppearance.BorderSize = 0;
            btnViewWeek.FlatStyle = FlatStyle.Flat;
            btnViewWeek.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewWeek.ForeColor = Color.FromArgb(47, 94, 240);
            btnViewWeek.Location = new Point(25, 232);
            btnViewWeek.Margin = new Padding(3, 4, 3, 4);
            btnViewWeek.Name = "btnViewWeek";
            btnViewWeek.Size = new Size(640, 48);
            btnViewWeek.TabIndex = 3;
            btnViewWeek.Text = "Xem lịch tuần";
            btnViewWeek.UseVisualStyleBackColor = false;
            // 
            // pnlShiftBox
            // 
            pnlShiftBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShiftBox.BackColor = Color.FromArgb(219, 234, 254);
            pnlShiftBox.BorderColor = Color.FromArgb(191, 219, 254);
            pnlShiftBox.BorderWidth = 1;
            pnlShiftBox.Controls.Add(lblShiftDept);
            pnlShiftBox.Controls.Add(lblShiftRoom);
            pnlShiftBox.Controls.Add(lblShiftTodayText);
            pnlShiftBox.Controls.Add(lblShiftName);
            pnlShiftBox.CornerRadius = 8;
            pnlShiftBox.FillColor = Color.FromArgb(219, 234, 254);
            pnlShiftBox.Location = new Point(25, 93);
            pnlShiftBox.Margin = new Padding(3, 4, 3, 4);
            pnlShiftBox.Name = "pnlShiftBox";
            pnlShiftBox.Size = new Size(1314, 117);
            pnlShiftBox.TabIndex = 2;
            // 
            // lblShiftDept
            // 
            lblShiftDept.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblShiftDept.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftDept.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftDept.Location = new Point(1029, 73);
            lblShiftDept.Name = "lblShiftDept";
            lblShiftDept.Size = new Size(274, 32);
            lblShiftDept.TabIndex = 3;
            lblShiftDept.Text = "-";
            lblShiftDept.TextAlign = ContentAlignment.TopRight;
            // 
            // lblShiftRoom
            // 
            lblShiftRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftRoom.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftRoom.Location = new Point(25, 73);
            lblShiftRoom.Name = "lblShiftRoom";
            lblShiftRoom.Size = new Size(206, 32);
            lblShiftRoom.TabIndex = 2;
            lblShiftRoom.Text = "-";
            // 
            // lblShiftTodayText
            // 
            lblShiftTodayText.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblShiftTodayText.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftTodayText.Location = new Point(130, 32);
            lblShiftTodayText.Name = "lblShiftTodayText";
            lblShiftTodayText.Size = new Size(183, 29);
            lblShiftTodayText.TabIndex = 1;
            lblShiftTodayText.Text = "(Hôm nay)";
            // 
            // lblShiftName
            // 
            lblShiftName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblShiftName.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftName.Location = new Point(21, 24);
            lblShiftName.Name = "lblShiftName";
            lblShiftName.Size = new Size(103, 40);
            lblShiftName.TabIndex = 0;
            lblShiftName.Text = "Trống";
            // 
            // lblShiftBadge
            // 
            lblShiftBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblShiftBadge.BackColor = Color.FromArgb(220, 252, 231);
            lblShiftBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblShiftBadge.ForeColor = Color.FromArgb(34, 139, 74);
            lblShiftBadge.Location = new Point(1232, 24);
            lblShiftBadge.Name = "lblShiftBadge";
            lblShiftBadge.Size = new Size(107, 35);
            lblShiftBadge.TabIndex = 1;
            lblShiftBadge.Text = "Đang trực";
            lblShiftBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShiftTitle
            // 
            lblShiftTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblShiftTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblShiftTitle.Location = new Point(21, 24);
            lblShiftTitle.Name = "lblShiftTitle";
            lblShiftTitle.Size = new Size(480, 37);
            lblShiftTitle.TabIndex = 0;
            lblShiftTitle.Text = "Ca làm việc hôm nay";
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 4;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.Controls.Add(pnlStatLab, 0, 0);
            pnlStatsGrid.Controls.Add(pnlStatScan, 1, 0);
            pnlStatsGrid.Controls.Add(pnlStatCompleted, 2, 0);
            pnlStatsGrid.Controls.Add(pnlStatProcessing, 3, 0);
            pnlStatsGrid.Location = new Point(27, 32);
            pnlStatsGrid.Margin = new Padding(3, 4, 3, 4);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1367, 200);
            pnlStatsGrid.TabIndex = 0;
            // 
            // pnlStatLab
            // 
            pnlStatLab.BackColor = Color.FromArgb(250, 245, 255);
            pnlStatLab.BorderColor = Color.FromArgb(233, 213, 255);
            pnlStatLab.BorderWidth = 1;
            pnlStatLab.Controls.Add(lblStatLabNum);
            pnlStatLab.Controls.Add(lblTodayAppointment);
            pnlStatLab.CornerRadius = 12;
            pnlStatLab.Dock = DockStyle.Fill;
            pnlStatLab.FillColor = Color.FromArgb(250, 245, 255);
            pnlStatLab.Location = new Point(0, 0);
            pnlStatLab.Margin = new Padding(0, 0, 16, 0);
            pnlStatLab.Name = "pnlStatLab";
            pnlStatLab.Size = new Size(325, 200);
            pnlStatLab.TabIndex = 0;
            // 
            // lblStatLabNum
            // 
            lblStatLabNum.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblStatLabNum.ForeColor = Color.FromArgb(126, 34, 206);
            lblStatLabNum.Location = new Point(27, 109);
            lblStatLabNum.Name = "lblStatLabNum";
            lblStatLabNum.Size = new Size(137, 51);
            lblStatLabNum.TabIndex = 1;
            lblStatLabNum.Text = "0";
            // 
            // lblTodayAppointment
            // 
            lblTodayAppointment.Font = new Font("Segoe UI", 9.5F);
            lblTodayAppointment.ForeColor = Color.FromArgb(126, 34, 206);
            lblTodayAppointment.Location = new Point(27, 157);
            lblTodayAppointment.Name = "lblTodayAppointment";
            lblTodayAppointment.Size = new Size(297, 32);
            lblTodayAppointment.TabIndex = 0;
            lblTodayAppointment.Text = "Lịch hẹn hôm nay";
            // 
            // pnlStatScan
            // 
            pnlStatScan.BackColor = Color.FromArgb(239, 246, 255);
            pnlStatScan.BorderColor = Color.FromArgb(191, 219, 254);
            pnlStatScan.BorderWidth = 1;
            pnlStatScan.Controls.Add(lblStatScanNum);
            pnlStatScan.Controls.Add(lblPatientWaiting);
            pnlStatScan.CornerRadius = 12;
            pnlStatScan.Dock = DockStyle.Fill;
            pnlStatScan.FillColor = Color.FromArgb(239, 246, 255);
            pnlStatScan.Location = new Point(341, 0);
            pnlStatScan.Margin = new Padding(0, 0, 16, 0);
            pnlStatScan.Name = "pnlStatScan";
            pnlStatScan.Size = new Size(325, 200);
            pnlStatScan.TabIndex = 1;
            // 
            // lblStatScanNum
            // 
            lblStatScanNum.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblStatScanNum.ForeColor = Color.FromArgb(47, 94, 240);
            lblStatScanNum.Location = new Point(27, 109);
            lblStatScanNum.Name = "lblStatScanNum";
            lblStatScanNum.Size = new Size(137, 51);
            lblStatScanNum.TabIndex = 1;
            lblStatScanNum.Text = "0";
            // 
            // lblPatientWaiting
            // 
            lblPatientWaiting.Font = new Font("Segoe UI", 9.5F);
            lblPatientWaiting.ForeColor = Color.FromArgb(47, 94, 240);
            lblPatientWaiting.Location = new Point(27, 157);
            lblPatientWaiting.Name = "lblPatientWaiting";
            lblPatientWaiting.Size = new Size(297, 32);
            lblPatientWaiting.TabIndex = 0;
            lblPatientWaiting.Text = "Bệnh nhân chờ";
            // 
            // pnlStatCompleted
            // 
            pnlStatCompleted.BackColor = Color.FromArgb(240, 253, 244);
            pnlStatCompleted.BorderColor = Color.FromArgb(187, 247, 208);
            pnlStatCompleted.BorderWidth = 1;
            pnlStatCompleted.Controls.Add(lblStatCompletedNum);
            pnlStatCompleted.Controls.Add(lblStatCompletedTitle);
            pnlStatCompleted.CornerRadius = 12;
            pnlStatCompleted.Dock = DockStyle.Fill;
            pnlStatCompleted.FillColor = Color.FromArgb(240, 253, 244);
            pnlStatCompleted.Location = new Point(682, 0);
            pnlStatCompleted.Margin = new Padding(0, 0, 16, 0);
            pnlStatCompleted.Name = "pnlStatCompleted";
            pnlStatCompleted.Size = new Size(325, 200);
            pnlStatCompleted.TabIndex = 2;
            // 
            // lblStatCompletedNum
            // 
            lblStatCompletedNum.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblStatCompletedNum.ForeColor = Color.FromArgb(34, 139, 74);
            lblStatCompletedNum.Location = new Point(27, 109);
            lblStatCompletedNum.Name = "lblStatCompletedNum";
            lblStatCompletedNum.Size = new Size(137, 51);
            lblStatCompletedNum.TabIndex = 1;
            lblStatCompletedNum.Text = "0";
            // 
            // lblStatCompletedTitle
            // 
            lblStatCompletedTitle.Font = new Font("Segoe UI", 9.5F);
            lblStatCompletedTitle.ForeColor = Color.FromArgb(34, 139, 74);
            lblStatCompletedTitle.Location = new Point(27, 157);
            lblStatCompletedTitle.Name = "lblStatCompletedTitle";
            lblStatCompletedTitle.Size = new Size(297, 32);
            lblStatCompletedTitle.TabIndex = 0;
            lblStatCompletedTitle.Text = "Đã hoàn thành hôm nay";
            // 
            // pnlStatProcessing
            // 
            pnlStatProcessing.BackColor = Color.FromArgb(255, 247, 237);
            pnlStatProcessing.BorderColor = Color.FromArgb(254, 215, 170);
            pnlStatProcessing.BorderWidth = 1;
            pnlStatProcessing.Controls.Add(lblStatProcessingNum);
            pnlStatProcessing.Controls.Add(lblStatProcessingTitle);
            pnlStatProcessing.CornerRadius = 12;
            pnlStatProcessing.Dock = DockStyle.Fill;
            pnlStatProcessing.FillColor = Color.FromArgb(255, 247, 237);
            pnlStatProcessing.Location = new Point(1023, 0);
            pnlStatProcessing.Margin = new Padding(0);
            pnlStatProcessing.Name = "pnlStatProcessing";
            pnlStatProcessing.Size = new Size(344, 200);
            pnlStatProcessing.TabIndex = 3;
            // 
            // lblStatProcessingNum
            // 
            lblStatProcessingNum.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblStatProcessingNum.ForeColor = Color.FromArgb(234, 88, 12);
            lblStatProcessingNum.Location = new Point(27, 109);
            lblStatProcessingNum.Name = "lblStatProcessingNum";
            lblStatProcessingNum.Size = new Size(137, 51);
            lblStatProcessingNum.TabIndex = 1;
            lblStatProcessingNum.Text = "0";
            // 
            // lblStatProcessingTitle
            // 
            lblStatProcessingTitle.Font = new Font("Segoe UI", 9.5F);
            lblStatProcessingTitle.ForeColor = Color.FromArgb(234, 88, 12);
            lblStatProcessingTitle.Location = new Point(27, 157);
            lblStatProcessingTitle.Name = "lblStatProcessingTitle";
            lblStatProcessingTitle.Size = new Size(297, 32);
            lblStatProcessingTitle.TabIndex = 0;
            lblStatProcessingTitle.Text = "Đang xử lý";
            // 
            // doctordashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "doctordashboard";
            Size = new Size(1422, 1333);
            viewHostPanel.ResumeLayout(false);
            pnlQuickActions.ResumeLayout(false);
            pnlActionGrid.ResumeLayout(false);
            pnlActResult.ResumeLayout(false);
            pnlActPdf.ResumeLayout(false);
            pnlActScan.ResumeLayout(false);
            pnlActLab.ResumeLayout(false);
            pnlShift.ResumeLayout(false);
            pnlShiftBox.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlStatLab.ResumeLayout(false);
            pnlStatScan.ResumeLayout(false);
            pnlStatCompleted.ResumeLayout(false);
            pnlStatProcessing.ResumeLayout(false);
            ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.TableLayoutPanel pnlStatsGrid;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatLab;
        private System.Windows.Forms.Label lblStatLabNum;
        private System.Windows.Forms.Label lblTodayAppointment;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatScan;
        private System.Windows.Forms.Label lblStatScanNum;
        private System.Windows.Forms.Label lblPatientWaiting;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatCompleted;
        private System.Windows.Forms.Label lblStatCompletedNum;
        private System.Windows.Forms.Label lblStatCompletedTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatProcessing;
        private System.Windows.Forms.Label lblStatProcessingNum;
        private System.Windows.Forms.Label lblStatProcessingTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlShift;
        private System.Windows.Forms.Label lblShiftTitle;
        private System.Windows.Forms.Label lblShiftBadge;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlShiftBox;
        private System.Windows.Forms.Label lblShiftName;
        private System.Windows.Forms.Label lblShiftTodayText;
        private System.Windows.Forms.Label lblShiftRoom;
        private System.Windows.Forms.Label lblShiftDept;
        private System.Windows.Forms.Button btnViewWeek;
        private System.Windows.Forms.Button btnChangeShift;
        private System.Windows.Forms.Label lblShiftFooter;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlQuickActions;
        private System.Windows.Forms.Label lblActionsTitle;
        private System.Windows.Forms.TableLayoutPanel pnlActionGrid;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlActLab;
        private System.Windows.Forms.Label lblActLabDesc;
        private System.Windows.Forms.Label lblActLabTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlActScan;
        private System.Windows.Forms.Label lblActScanDesc;
        private System.Windows.Forms.Label lblActScanTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlActPdf;
        private System.Windows.Forms.Label lblActPdfDesc;
        private System.Windows.Forms.Label lblActPdfTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlActResult;
        private System.Windows.Forms.Label lblActResultDesc;
        private System.Windows.Forms.Label lblActResultTitle;
    }
}
