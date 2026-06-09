namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianOverview
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
            this.pnlStatsGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatLab = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatLabNum = new System.Windows.Forms.Label();
            this.lblStatLabTitle = new System.Windows.Forms.Label();
            this.pnlStatScan = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatScanNum = new System.Windows.Forms.Label();
            this.lblStatScanTitle = new System.Windows.Forms.Label();
            this.pnlStatCompleted = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatCompletedNum = new System.Windows.Forms.Label();
            this.lblStatCompletedTitle = new System.Windows.Forms.Label();
            this.pnlStatProcessing = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatProcessingNum = new System.Windows.Forms.Label();
            this.lblStatProcessingTitle = new System.Windows.Forms.Label();
            this.pnlShift = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblShiftTitle = new System.Windows.Forms.Label();
            this.lblShiftBadge = new System.Windows.Forms.Label();
            this.pnlShiftBox = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblShiftName = new System.Windows.Forms.Label();
            this.lblShiftTodayText = new System.Windows.Forms.Label();
            this.lblShiftRoom = new System.Windows.Forms.Label();
            this.lblShiftDept = new System.Windows.Forms.Label();
            this.btnViewWeek = new System.Windows.Forms.Button();
            this.btnRegisterShift = new System.Windows.Forms.Button();
            this.lblShiftFooter = new System.Windows.Forms.Label();
            this.pnlColumns = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLabRequests = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblLabTitle = new System.Windows.Forms.Label();
            this.flpLabPending = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlImagingQueue = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblImagingTitle = new System.Windows.Forms.Label();
            this.flpScanPending = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlQuickActions = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblActionsTitle = new System.Windows.Forms.Label();
            this.pnlActionGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlActLab = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblActLabDesc = new System.Windows.Forms.Label();
            this.lblActLabTitle = new System.Windows.Forms.Label();
            this.pnlActScan = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblActScanDesc = new System.Windows.Forms.Label();
            this.lblActScanTitle = new System.Windows.Forms.Label();
            this.pnlActPdf = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblActPdfDesc = new System.Windows.Forms.Label();
            this.lblActPdfTitle = new System.Windows.Forms.Label();
            this.pnlActResult = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblActResultDesc = new System.Windows.Forms.Label();
            this.lblActResultTitle = new System.Windows.Forms.Label();
            this.viewHostPanel.SuspendLayout();
            this.pnlStatsGrid.SuspendLayout();
            this.pnlStatLab.SuspendLayout();
            this.pnlStatScan.SuspendLayout();
            this.pnlStatCompleted.SuspendLayout();
            this.pnlStatProcessing.SuspendLayout();
            this.pnlShift.SuspendLayout();
            this.pnlShiftBox.SuspendLayout();
            this.pnlColumns.SuspendLayout();
            this.pnlLabRequests.SuspendLayout();
            this.pnlImagingQueue.SuspendLayout();
            this.pnlQuickActions.SuspendLayout();
            this.pnlActionGrid.SuspendLayout();
            this.pnlActLab.SuspendLayout();
            this.pnlActScan.SuspendLayout();
            this.pnlActPdf.SuspendLayout();
            this.pnlActResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.AutoScroll = true;
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.pnlQuickActions);
            this.viewHostPanel.Controls.Add(this.pnlColumns);
            this.viewHostPanel.Controls.Add(this.pnlShift);
            this.viewHostPanel.Controls.Add(this.pnlStatsGrid);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 744);
            this.viewHostPanel.TabIndex = 0;
            // 
            // pnlStatsGrid
            // 
            this.pnlStatsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStatsGrid.ColumnCount = 4;
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.Controls.Add(this.pnlStatLab, 0, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatScan, 1, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatCompleted, 2, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatProcessing, 3, 0);
            this.pnlStatsGrid.Location = new System.Drawing.Point(24, 24);
            this.pnlStatsGrid.Name = "pnlStatsGrid";
            this.pnlStatsGrid.RowCount = 1;
            this.pnlStatsGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatsGrid.Size = new System.Drawing.Size(1196, 150);
            this.pnlStatsGrid.TabIndex = 0;
            // 
            // pnlStatLab
            // 
            this.pnlStatLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlStatLab.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.pnlStatLab.Controls.Add(this.lblStatLabNum);
            this.pnlStatLab.Controls.Add(this.lblStatLabTitle);
            this.pnlStatLab.CornerRadius = 12;
            this.pnlStatLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatLab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlStatLab.Location = new System.Drawing.Point(0, 0);
            this.pnlStatLab.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatLab.Name = "pnlStatLab";
            this.pnlStatLab.Size = new System.Drawing.Size(285, 150);
            this.pnlStatLab.TabIndex = 0;
            // 
            // lblStatLabNum
            // 
            this.lblStatLabNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatLabNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(34)))), ((int)(((byte)(206)))));
            this.lblStatLabNum.Location = new System.Drawing.Point(24, 82);
            this.lblStatLabNum.Name = "lblStatLabNum";
            this.lblStatLabNum.Size = new System.Drawing.Size(120, 38);
            this.lblStatLabNum.TabIndex = 1;
            this.lblStatLabNum.Text = "0";
            // 
            // lblStatLabTitle
            // 
            this.lblStatLabTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatLabTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(34)))), ((int)(((byte)(206)))));
            this.lblStatLabTitle.Location = new System.Drawing.Point(24, 118);
            this.lblStatLabTitle.Name = "lblStatLabTitle";
            this.lblStatLabTitle.Size = new System.Drawing.Size(260, 24);
            this.lblStatLabTitle.TabIndex = 0;
            this.lblStatLabTitle.Text = "Yêu cầu XN chờ";
            // 
            // pnlStatScan
            // 
            this.pnlStatScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlStatScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.pnlStatScan.Controls.Add(this.lblStatScanNum);
            this.pnlStatScan.Controls.Add(this.lblStatScanTitle);
            this.pnlStatScan.CornerRadius = 12;
            this.pnlStatScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatScan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlStatScan.Location = new System.Drawing.Point(299, 0);
            this.pnlStatScan.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatScan.Name = "pnlStatScan";
            this.pnlStatScan.Size = new System.Drawing.Size(285, 150);
            this.pnlStatScan.TabIndex = 1;
            // 
            // lblStatScanNum
            // 
            this.lblStatScanNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatScanNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblStatScanNum.Location = new System.Drawing.Point(24, 82);
            this.lblStatScanNum.Name = "lblStatScanNum";
            this.lblStatScanNum.Size = new System.Drawing.Size(120, 38);
            this.lblStatScanNum.TabIndex = 1;
            this.lblStatScanNum.Text = "0";
            // 
            // lblStatScanTitle
            // 
            this.lblStatScanTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatScanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblStatScanTitle.Location = new System.Drawing.Point(24, 118);
            this.lblStatScanTitle.Name = "lblStatScanTitle";
            this.lblStatScanTitle.Size = new System.Drawing.Size(260, 24);
            this.lblStatScanTitle.TabIndex = 0;
            this.lblStatScanTitle.Text = "Hàng đợi chụp ảnh";
            // 
            // pnlStatCompleted
            // 
            this.pnlStatCompleted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlStatCompleted.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(247)))), ((int)(((byte)(208)))));
            this.pnlStatCompleted.Controls.Add(this.lblStatCompletedNum);
            this.pnlStatCompleted.Controls.Add(this.lblStatCompletedTitle);
            this.pnlStatCompleted.CornerRadius = 12;
            this.pnlStatCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatCompleted.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlStatCompleted.Location = new System.Drawing.Point(598, 0);
            this.pnlStatCompleted.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatCompleted.Name = "pnlStatCompleted";
            this.pnlStatCompleted.Size = new System.Drawing.Size(285, 150);
            this.pnlStatCompleted.TabIndex = 2;
            // 
            // lblStatCompletedNum
            // 
            this.lblStatCompletedNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatCompletedNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblStatCompletedNum.Location = new System.Drawing.Point(24, 82);
            this.lblStatCompletedNum.Name = "lblStatCompletedNum";
            this.lblStatCompletedNum.Size = new System.Drawing.Size(120, 38);
            this.lblStatCompletedNum.TabIndex = 1;
            this.lblStatCompletedNum.Text = "0";
            // 
            // lblStatCompletedTitle
            // 
            this.lblStatCompletedTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatCompletedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblStatCompletedTitle.Location = new System.Drawing.Point(24, 118);
            this.lblStatCompletedTitle.Name = "lblStatCompletedTitle";
            this.lblStatCompletedTitle.Size = new System.Drawing.Size(260, 24);
            this.lblStatCompletedTitle.TabIndex = 0;
            this.lblStatCompletedTitle.Text = "Đã hoàn thành hôm nay";
            // 
            // pnlStatProcessing
            // 
            this.pnlStatProcessing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlStatProcessing.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(170)))));
            this.pnlStatProcessing.Controls.Add(this.lblStatProcessingNum);
            this.pnlStatProcessing.Controls.Add(this.lblStatProcessingTitle);
            this.pnlStatProcessing.CornerRadius = 12;
            this.pnlStatProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatProcessing.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlStatProcessing.Location = new System.Drawing.Point(897, 0);
            this.pnlStatProcessing.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatProcessing.Name = "pnlStatProcessing";
            this.pnlStatProcessing.Size = new System.Drawing.Size(299, 150);
            this.pnlStatProcessing.TabIndex = 3;
            // 
            // lblStatProcessingNum
            // 
            this.lblStatProcessingNum.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblStatProcessingNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.lblStatProcessingNum.Location = new System.Drawing.Point(24, 82);
            this.lblStatProcessingNum.Name = "lblStatProcessingNum";
            this.lblStatProcessingNum.Size = new System.Drawing.Size(120, 38);
            this.lblStatProcessingNum.TabIndex = 1;
            this.lblStatProcessingNum.Text = "0";
            // 
            // lblStatProcessingTitle
            // 
            this.lblStatProcessingTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatProcessingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.lblStatProcessingTitle.Location = new System.Drawing.Point(24, 118);
            this.lblStatProcessingTitle.Name = "lblStatProcessingTitle";
            this.lblStatProcessingTitle.Size = new System.Drawing.Size(260, 24);
            this.lblStatProcessingTitle.TabIndex = 0;
            this.lblStatProcessingTitle.Text = "Đang xử lý";
            // 
            // pnlShift
            // 
            this.pnlShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShift.BackColor = System.Drawing.Color.White;
            this.pnlShift.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlShift.Controls.Add(this.lblShiftFooter);
            this.pnlShift.Controls.Add(this.btnRegisterShift);
            this.pnlShift.Controls.Add(this.btnViewWeek);
            this.pnlShift.Controls.Add(this.pnlShiftBox);
            this.pnlShift.Controls.Add(this.lblShiftBadge);
            this.pnlShift.Controls.Add(this.lblShiftTitle);
            this.pnlShift.CornerRadius = 8;
            this.pnlShift.FillColor = System.Drawing.Color.White;
            this.pnlShift.Location = new System.Drawing.Point(24, 192);
            this.pnlShift.Name = "pnlShift";
            this.pnlShift.Size = new System.Drawing.Size(1196, 260);
            this.pnlShift.TabIndex = 1;
            // 
            // lblShiftTitle
            // 
            this.lblShiftTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblShiftTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblShiftTitle.Location = new System.Drawing.Point(18, 18);
            this.lblShiftTitle.Name = "lblShiftTitle";
            this.lblShiftTitle.Size = new System.Drawing.Size(420, 28);
            this.lblShiftTitle.TabIndex = 0;
            this.lblShiftTitle.Text = "Ca làm việc hôm nay";
            // 
            // lblShiftBadge
            // 
            this.lblShiftBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblShiftBadge.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblShiftBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblShiftBadge.Location = new System.Drawing.Point(1078, 18);
            this.lblShiftBadge.Name = "lblShiftBadge";
            this.lblShiftBadge.Size = new System.Drawing.Size(94, 26);
            this.lblShiftBadge.TabIndex = 1;
            this.lblShiftBadge.Text = "Đang trực";
            this.lblShiftBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlShiftBox
            // 
            this.pnlShiftBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShiftBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlShiftBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.pnlShiftBox.Controls.Add(this.lblShiftDept);
            this.pnlShiftBox.Controls.Add(this.lblShiftRoom);
            this.pnlShiftBox.Controls.Add(this.lblShiftTodayText);
            this.pnlShiftBox.Controls.Add(this.lblShiftName);
            this.pnlShiftBox.CornerRadius = 8;
            this.pnlShiftBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.pnlShiftBox.Location = new System.Drawing.Point(22, 70);
            this.pnlShiftBox.Name = "pnlShiftBox";
            this.pnlShiftBox.Size = new System.Drawing.Size(1150, 88);
            this.pnlShiftBox.TabIndex = 2;
            // 
            // lblShiftName
            // 
            this.lblShiftName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblShiftName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblShiftName.Location = new System.Drawing.Point(18, 18);
            this.lblShiftName.Name = "lblShiftName";
            this.lblShiftName.Size = new System.Drawing.Size(90, 30);
            this.lblShiftName.TabIndex = 0;
            this.lblShiftName.Text = "Trống";
            // 
            // lblShiftTodayText
            // 
            this.lblShiftTodayText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblShiftTodayText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblShiftTodayText.Location = new System.Drawing.Point(114, 24);
            this.lblShiftTodayText.Name = "lblShiftTodayText";
            this.lblShiftTodayText.Size = new System.Drawing.Size(160, 22);
            this.lblShiftTodayText.TabIndex = 1;
            this.lblShiftTodayText.Text = "(Hôm nay)";
            // 
            // lblShiftRoom
            // 
            this.lblShiftRoom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblShiftRoom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblShiftRoom.Location = new System.Drawing.Point(22, 55);
            this.lblShiftRoom.Name = "lblShiftRoom";
            this.lblShiftRoom.Size = new System.Drawing.Size(180, 24);
            this.lblShiftRoom.TabIndex = 2;
            this.lblShiftRoom.Text = "-";
            // 
            // lblShiftDept
            // 
            this.lblShiftDept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShiftDept.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblShiftDept.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblShiftDept.Location = new System.Drawing.Point(900, 55);
            this.lblShiftDept.Name = "lblShiftDept";
            this.lblShiftDept.Size = new System.Drawing.Size(240, 24);
            this.lblShiftDept.TabIndex = 3;
            this.lblShiftDept.Text = "-";
            this.lblShiftDept.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnViewWeek
            // 
            this.btnViewWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.btnViewWeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewWeek.FlatAppearance.BorderSize = 0;
            this.btnViewWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewWeek.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnViewWeek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnViewWeek.Location = new System.Drawing.Point(22, 174);
            this.btnViewWeek.Name = "btnViewWeek";
            this.btnViewWeek.Size = new System.Drawing.Size(560, 36);
            this.btnViewWeek.TabIndex = 3;
            this.btnViewWeek.Text = "Xem lịch tuần";
            this.btnViewWeek.UseVisualStyleBackColor = false;
            // 
            // btnRegisterShift
            // 
            this.btnRegisterShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegisterShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnRegisterShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegisterShift.FlatAppearance.BorderSize = 0;
            this.btnRegisterShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterShift.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnRegisterShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnRegisterShift.Location = new System.Drawing.Point(612, 174);
            this.btnRegisterShift.Name = "btnRegisterShift";
            this.btnRegisterShift.Size = new System.Drawing.Size(560, 36);
            this.btnRegisterShift.TabIndex = 4;
            this.btnRegisterShift.Text = "Đăng ký ca mới";
            this.btnRegisterShift.UseVisualStyleBackColor = false;
            // 
            // lblShiftFooter
            // 
            this.lblShiftFooter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblShiftFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblShiftFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblShiftFooter.Location = new System.Drawing.Point(500, 220);
            this.lblShiftFooter.Name = "lblShiftFooter";
            this.lblShiftFooter.Size = new System.Drawing.Size(210, 22);
            this.lblShiftFooter.TabIndex = 5;
            this.lblShiftFooter.Text = "Quản lý ca làm việc nhanh chóng";
            this.lblShiftFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlColumns
            // 
            this.pnlColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColumns.ColumnCount = 2;
            this.pnlColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlColumns.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlColumns.Controls.Add(this.pnlImagingQueue, 1, 0);
            this.pnlColumns.Controls.Add(this.pnlLabRequests, 0, 0);
            this.pnlColumns.Location = new System.Drawing.Point(24, 468);
            this.pnlColumns.Name = "pnlColumns";
            this.pnlColumns.RowCount = 1;
            this.pnlColumns.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlColumns.Size = new System.Drawing.Size(1196, 340);
            this.pnlColumns.TabIndex = 2;
            // 
            // pnlLabRequests
            // 
            this.pnlLabRequests.BackColor = System.Drawing.Color.White;
            this.pnlLabRequests.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlLabRequests.Controls.Add(this.flpLabPending);
            this.pnlLabRequests.Controls.Add(this.lblLabTitle);
            this.pnlLabRequests.CornerRadius = 8;
            this.pnlLabRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLabRequests.FillColor = System.Drawing.Color.White;
            this.pnlLabRequests.Location = new System.Drawing.Point(0, 0);
            this.pnlLabRequests.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlLabRequests.Name = "pnlLabRequests";
            this.pnlLabRequests.Size = new System.Drawing.Size(584, 340);
            this.pnlLabRequests.TabIndex = 0;
            // 
            // lblLabTitle
            // 
            this.lblLabTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLabTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblLabTitle.Location = new System.Drawing.Point(18, 18);
            this.lblLabTitle.Name = "lblLabTitle";
            this.lblLabTitle.Size = new System.Drawing.Size(420, 28);
            this.lblLabTitle.TabIndex = 0;
            this.lblLabTitle.Text = "Yêu cầu Xét nghiệm";
            // 
            // flpLabPending
            // 
            this.flpLabPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpLabPending.AutoScroll = true;
            this.flpLabPending.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLabPending.Location = new System.Drawing.Point(18, 64);
            this.flpLabPending.Name = "flpLabPending";
            this.flpLabPending.Size = new System.Drawing.Size(548, 258);
            this.flpLabPending.TabIndex = 1;
            this.flpLabPending.WrapContents = false;
            // 
            // pnlImagingQueue
            // 
            this.pnlImagingQueue.BackColor = System.Drawing.Color.White;
            this.pnlImagingQueue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlImagingQueue.Controls.Add(this.flpScanPending);
            this.pnlImagingQueue.Controls.Add(this.lblImagingTitle);
            this.pnlImagingQueue.CornerRadius = 8;
            this.pnlImagingQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImagingQueue.FillColor = System.Drawing.Color.White;
            this.pnlImagingQueue.Location = new System.Drawing.Point(598, 0);
            this.pnlImagingQueue.Margin = new System.Windows.Forms.Padding(0);
            this.pnlImagingQueue.Name = "pnlImagingQueue";
            this.pnlImagingQueue.Size = new System.Drawing.Size(598, 340);
            this.pnlImagingQueue.TabIndex = 1;
            // 
            // lblImagingTitle
            // 
            this.lblImagingTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblImagingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblImagingTitle.Location = new System.Drawing.Point(18, 18);
            this.lblImagingTitle.Name = "lblImagingTitle";
            this.lblImagingTitle.Size = new System.Drawing.Size(420, 28);
            this.lblImagingTitle.TabIndex = 0;
            this.lblImagingTitle.Text = "Hàng đợi Chụp ảnh";
            // 
            // flpScanPending
            // 
            this.flpScanPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpScanPending.AutoScroll = true;
            this.flpScanPending.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpScanPending.Location = new System.Drawing.Point(18, 64);
            this.flpScanPending.Name = "flpScanPending";
            this.flpScanPending.Size = new System.Drawing.Size(562, 258);
            this.flpScanPending.TabIndex = 1;
            this.flpScanPending.WrapContents = false;
            // 
            // pnlQuickActions
            // 
            this.pnlQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuickActions.BackColor = System.Drawing.Color.White;
            this.pnlQuickActions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlQuickActions.Controls.Add(this.pnlActionGrid);
            this.pnlQuickActions.Controls.Add(this.lblActionsTitle);
            this.pnlQuickActions.CornerRadius = 8;
            this.pnlQuickActions.FillColor = System.Drawing.Color.White;
            this.pnlQuickActions.Location = new System.Drawing.Point(24, 824);
            this.pnlQuickActions.Name = "pnlQuickActions";
            this.pnlQuickActions.Size = new System.Drawing.Size(1196, 180);
            this.pnlQuickActions.TabIndex = 3;
            // 
            // lblActionsTitle
            // 
            this.lblActionsTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblActionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActionsTitle.Location = new System.Drawing.Point(18, 18);
            this.lblActionsTitle.Name = "lblActionsTitle";
            this.lblActionsTitle.Size = new System.Drawing.Size(420, 28);
            this.lblActionsTitle.TabIndex = 0;
            this.lblActionsTitle.Text = "Hành động nhanh";
            // 
            // pnlActionGrid
            // 
            this.pnlActionGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlActionGrid.ColumnCount = 4;
            this.pnlActionGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlActionGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlActionGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlActionGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlActionGrid.Controls.Add(this.pnlActResult, 3, 0);
            this.pnlActionGrid.Controls.Add(this.pnlActPdf, 2, 0);
            this.pnlActionGrid.Controls.Add(this.pnlActScan, 1, 0);
            this.pnlActionGrid.Controls.Add(this.pnlActLab, 0, 0);
            this.pnlActionGrid.Location = new System.Drawing.Point(22, 58);
            this.pnlActionGrid.Name = "pnlActionGrid";
            this.pnlActionGrid.RowCount = 1;
            this.pnlActionGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlActionGrid.Size = new System.Drawing.Size(1150, 110);
            this.pnlActionGrid.TabIndex = 1;
            // 
            // pnlActLab
            // 
            this.pnlActLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlActLab.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlActLab.Controls.Add(this.lblActLabDesc);
            this.pnlActLab.Controls.Add(this.lblActLabTitle);
            this.pnlActLab.CornerRadius = 8;
            this.pnlActLab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActLab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActLab.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlActLab.Location = new System.Drawing.Point(0, 0);
            this.pnlActLab.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlActLab.Name = "pnlActLab";
            this.pnlActLab.Size = new System.Drawing.Size(273, 110);
            this.pnlActLab.TabIndex = 0;
            // 
            // lblActLabTitle
            // 
            this.lblActLabTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblActLabTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActLabTitle.Location = new System.Drawing.Point(22, 42);
            this.lblActLabTitle.Name = "lblActLabTitle";
            this.lblActLabTitle.Size = new System.Drawing.Size(210, 28);
            this.lblActLabTitle.TabIndex = 0;
            this.lblActLabTitle.Text = "Nhận yêu cầu XN";
            // 
            // lblActLabDesc
            // 
            this.lblActLabDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActLabDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblActLabDesc.Location = new System.Drawing.Point(22, 68);
            this.lblActLabDesc.Name = "lblActLabDesc";
            this.lblActLabDesc.Size = new System.Drawing.Size(210, 22);
            this.lblActLabDesc.TabIndex = 1;
            this.lblActLabDesc.Text = "Xem danh sách";
            // 
            // pnlActScan
            // 
            this.pnlActScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlActScan.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlActScan.Controls.Add(this.lblActScanDesc);
            this.pnlActScan.Controls.Add(this.lblActScanTitle);
            this.pnlActScan.CornerRadius = 8;
            this.pnlActScan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActScan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActScan.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlActScan.Location = new System.Drawing.Point(287, 0);
            this.pnlActScan.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlActScan.Name = "pnlActScan";
            this.pnlActScan.Size = new System.Drawing.Size(273, 110);
            this.pnlActScan.TabIndex = 1;
            // 
            // lblActScanTitle
            // 
            this.lblActScanTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblActScanTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActScanTitle.Location = new System.Drawing.Point(22, 42);
            this.lblActScanTitle.Name = "lblActScanTitle";
            this.lblActScanTitle.Size = new System.Drawing.Size(210, 28);
            this.lblActScanTitle.TabIndex = 0;
            this.lblActScanTitle.Text = "Chụp ảnh";
            // 
            // lblActScanDesc
            // 
            this.lblActScanDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActScanDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblActScanDesc.Location = new System.Drawing.Point(22, 68);
            this.lblActScanDesc.Name = "lblActScanDesc";
            this.lblActScanDesc.Size = new System.Drawing.Size(210, 22);
            this.lblActScanDesc.TabIndex = 1;
            this.lblActScanDesc.Text = "Tải phim MRI/X-Ray";
            // 
            // pnlActPdf
            // 
            this.pnlActPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlActPdf.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlActPdf.Controls.Add(this.lblActPdfDesc);
            this.pnlActPdf.Controls.Add(this.lblActPdfTitle);
            this.pnlActPdf.CornerRadius = 8;
            this.pnlActPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActPdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActPdf.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlActPdf.Location = new System.Drawing.Point(574, 0);
            this.pnlActPdf.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlActPdf.Name = "pnlActPdf";
            this.pnlActPdf.Size = new System.Drawing.Size(273, 110);
            this.pnlActPdf.TabIndex = 2;
            // 
            // lblActPdfTitle
            // 
            this.lblActPdfTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblActPdfTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActPdfTitle.Location = new System.Drawing.Point(22, 42);
            this.lblActPdfTitle.Name = "lblActPdfTitle";
            this.lblActPdfTitle.Size = new System.Drawing.Size(210, 28);
            this.lblActPdfTitle.TabIndex = 0;
            this.lblActPdfTitle.Text = "Tải kết quả";
            // 
            // lblActPdfDesc
            // 
            this.lblActPdfDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActPdfDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblActPdfDesc.Location = new System.Drawing.Point(22, 68);
            this.lblActPdfDesc.Name = "lblActPdfDesc";
            this.lblActPdfDesc.Size = new System.Drawing.Size(210, 22);
            this.lblActPdfDesc.TabIndex = 1;
            this.lblActPdfDesc.Text = "Tải lên tệp PDF";
            // 
            // pnlActResult
            // 
            this.pnlActResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlActResult.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlActResult.Controls.Add(this.lblActResultDesc);
            this.pnlActResult.Controls.Add(this.lblActResultTitle);
            this.pnlActResult.CornerRadius = 8;
            this.pnlActResult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlActResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActResult.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(237)))));
            this.pnlActResult.Location = new System.Drawing.Point(861, 0);
            this.pnlActResult.Margin = new System.Windows.Forms.Padding(0);
            this.pnlActResult.Name = "pnlActResult";
            this.pnlActResult.Size = new System.Drawing.Size(289, 110);
            this.pnlActResult.TabIndex = 3;
            // 
            // lblActResultTitle
            // 
            this.lblActResultTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblActResultTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblActResultTitle.Location = new System.Drawing.Point(22, 42);
            this.lblActResultTitle.Name = "lblActResultTitle";
            this.lblActResultTitle.Size = new System.Drawing.Size(210, 28);
            this.lblActResultTitle.TabIndex = 0;
            this.lblActResultTitle.Text = "Duyệt kết quả";
            // 
            // lblActResultDesc
            // 
            this.lblActResultDesc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActResultDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblActResultDesc.Location = new System.Drawing.Point(22, 68);
            this.lblActResultDesc.Name = "lblActResultDesc";
            this.lblActResultDesc.Size = new System.Drawing.Size(210, 22);
            this.lblActResultDesc.TabIndex = 1;
            this.lblActResultDesc.Text = "Nhập kết quả chỉ số";
            // 
            // ucTechnicianOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianOverview";
            this.Size = new System.Drawing.Size(1244, 1000);
            this.Load += new System.EventHandler(this.ucTechnicianOverview_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianOverview_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlStatsGrid.ResumeLayout(false);
            this.pnlStatLab.ResumeLayout(false);
            this.pnlStatScan.ResumeLayout(false);
            this.pnlStatCompleted.ResumeLayout(false);
            this.pnlStatProcessing.ResumeLayout(false);
            this.pnlShift.ResumeLayout(false);
            this.pnlShiftBox.ResumeLayout(false);
            this.pnlColumns.ResumeLayout(false);
            this.pnlLabRequests.ResumeLayout(false);
            this.pnlImagingQueue.ResumeLayout(false);
            this.pnlQuickActions.ResumeLayout(false);
            this.pnlActionGrid.ResumeLayout(false);
            this.pnlActLab.ResumeLayout(false);
            this.pnlActScan.ResumeLayout(false);
            this.pnlActPdf.ResumeLayout(false);
            this.pnlActResult.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.TableLayoutPanel pnlStatsGrid;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatLab;
        private System.Windows.Forms.Label lblStatLabNum;
        private System.Windows.Forms.Label lblStatLabTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatScan;
        private System.Windows.Forms.Label lblStatScanNum;
        private System.Windows.Forms.Label lblStatScanTitle;
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
        private System.Windows.Forms.Button btnRegisterShift;
        private System.Windows.Forms.Label lblShiftFooter;
        private System.Windows.Forms.TableLayoutPanel pnlColumns;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlLabRequests;
        private System.Windows.Forms.Label lblLabTitle;
        private System.Windows.Forms.FlowLayoutPanel flpLabPending;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlImagingQueue;
        private System.Windows.Forms.Label lblImagingTitle;
        private System.Windows.Forms.FlowLayoutPanel flpScanPending;
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
