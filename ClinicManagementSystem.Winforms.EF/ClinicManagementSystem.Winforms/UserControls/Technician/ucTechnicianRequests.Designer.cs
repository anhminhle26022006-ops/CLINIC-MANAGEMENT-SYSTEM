namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianRequests
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
            this.btnSyncCloud = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlStatsGrid = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStatPending = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatPendingNum = new System.Windows.Forms.Label();
            this.lblStatPendingTitle = new System.Windows.Forms.Label();
            this.pnlStatProcessing = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatProcessingNum = new System.Windows.Forms.Label();
            this.lblStatProcessingTitle = new System.Windows.Forms.Label();
            this.pnlStatCompleted = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatCompletedNum = new System.Windows.Forms.Label();
            this.lblStatCompletedTitle = new System.Windows.Forms.Label();
            this.pnlStatTotal = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblStatTotalNum = new System.Windows.Forms.Label();
            this.lblStatTotalTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.txtRequestSearch = new System.Windows.Forms.TextBox();
            this.comboRequestStatusFilter = new System.Windows.Forms.ComboBox();
            this.flpRequests = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlProcessNote = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblProcessTitle = new System.Windows.Forms.Label();
            this.lblStep1 = new System.Windows.Forms.Label();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.viewHostPanel.SuspendLayout();
            this.pnlStatsGrid.SuspendLayout();
            this.pnlStatPending.SuspendLayout();
            this.pnlStatProcessing.SuspendLayout();
            this.pnlStatCompleted.SuspendLayout();
            this.pnlStatTotal.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlProcessNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.AutoScroll = true;
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.pnlProcessNote);
            this.viewHostPanel.Controls.Add(this.flpRequests);
            this.viewHostPanel.Controls.Add(this.pnlFilter);
            this.viewHostPanel.Controls.Add(this.pnlStatsGrid);
            this.viewHostPanel.Controls.Add(this.lblSubtitle);
            this.viewHostPanel.Controls.Add(this.lblTitle);
            this.viewHostPanel.Controls.Add(this.btnSyncCloud);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1500, 900);
            this.viewHostPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(560, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Xét nghiệm & Chẩn đoán";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(900, 30);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Quản lý danh sách yêu cầu thực hiện cận lâm sàng";
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
            this.pnlStatsGrid.Controls.Add(this.pnlStatPending, 0, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatProcessing, 1, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatCompleted, 2, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlStatTotal, 3, 0);
            this.pnlStatsGrid.Location = new System.Drawing.Point(24, 96);
            this.pnlStatsGrid.Name = "pnlStatsGrid";
            this.pnlStatsGrid.RowCount = 1;
            this.pnlStatsGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatsGrid.Size = new System.Drawing.Size(1452, 104);
            this.pnlStatsGrid.TabIndex = 3;
            // 
            // pnlStatPending
            // 
            this.pnlStatPending.BackColor = System.Drawing.Color.White;
            this.pnlStatPending.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatPending.Controls.Add(this.lblStatPendingNum);
            this.pnlStatPending.Controls.Add(this.lblStatPendingTitle);
            this.pnlStatPending.CornerRadius = 8;
            this.pnlStatPending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatPending.FillColor = System.Drawing.Color.White;
            this.pnlStatPending.Location = new System.Drawing.Point(0, 0);
            this.pnlStatPending.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatPending.Name = "pnlStatPending";
            this.pnlStatPending.Size = new System.Drawing.Size(285, 90);
            this.pnlStatPending.TabIndex = 0;
            // 
            // lblStatPendingNum
            // 
            this.lblStatPendingNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatPendingNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(83)))), ((int)(((byte)(9)))));
            this.lblStatPendingNum.Location = new System.Drawing.Point(16, 48);
            this.lblStatPendingNum.Name = "lblStatPendingNum";
            this.lblStatPendingNum.Size = new System.Drawing.Size(80, 32);
            this.lblStatPendingNum.TabIndex = 1;
            this.lblStatPendingNum.Text = "0";
            // 
            // lblStatPendingTitle
            // 
            this.lblStatPendingTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatPendingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatPendingTitle.Location = new System.Drawing.Point(16, 20);
            this.lblStatPendingTitle.Name = "lblStatPendingTitle";
            this.lblStatPendingTitle.Size = new System.Drawing.Size(180, 22);
            this.lblStatPendingTitle.TabIndex = 0;
            this.lblStatPendingTitle.Text = "Chờ xử lý";
            // 
            // pnlStatProcessing
            // 
            this.pnlStatProcessing.BackColor = System.Drawing.Color.White;
            this.pnlStatProcessing.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatProcessing.Controls.Add(this.lblStatProcessingNum);
            this.pnlStatProcessing.Controls.Add(this.lblStatProcessingTitle);
            this.pnlStatProcessing.CornerRadius = 8;
            this.pnlStatProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatProcessing.FillColor = System.Drawing.Color.White;
            this.pnlStatProcessing.Location = new System.Drawing.Point(299, 0);
            this.pnlStatProcessing.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatProcessing.Name = "pnlStatProcessing";
            this.pnlStatProcessing.Size = new System.Drawing.Size(285, 90);
            this.pnlStatProcessing.TabIndex = 1;
            // 
            // lblStatProcessingNum
            // 
            this.lblStatProcessingNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatProcessingNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblStatProcessingNum.Location = new System.Drawing.Point(16, 48);
            this.lblStatProcessingNum.Name = "lblStatProcessingNum";
            this.lblStatProcessingNum.Size = new System.Drawing.Size(80, 32);
            this.lblStatProcessingNum.TabIndex = 1;
            this.lblStatProcessingNum.Text = "0";
            // 
            // lblStatProcessingTitle
            // 
            this.lblStatProcessingTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatProcessingTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatProcessingTitle.Location = new System.Drawing.Point(16, 20);
            this.lblStatProcessingTitle.Name = "lblStatProcessingTitle";
            this.lblStatProcessingTitle.Size = new System.Drawing.Size(180, 22);
            this.lblStatProcessingTitle.TabIndex = 0;
            this.lblStatProcessingTitle.Text = "Đang xử lý";
            // 
            // pnlStatCompleted
            // 
            this.pnlStatCompleted.BackColor = System.Drawing.Color.White;
            this.pnlStatCompleted.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlStatCompleted.Controls.Add(this.lblStatCompletedNum);
            this.pnlStatCompleted.Controls.Add(this.lblStatCompletedTitle);
            this.pnlStatCompleted.CornerRadius = 8;
            this.pnlStatCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStatCompleted.FillColor = System.Drawing.Color.White;
            this.pnlStatCompleted.Location = new System.Drawing.Point(598, 0);
            this.pnlStatCompleted.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlStatCompleted.Name = "pnlStatCompleted";
            this.pnlStatCompleted.Size = new System.Drawing.Size(285, 90);
            this.pnlStatCompleted.TabIndex = 2;
            // 
            // lblStatCompletedNum
            // 
            this.lblStatCompletedNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatCompletedNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblStatCompletedNum.Location = new System.Drawing.Point(16, 48);
            this.lblStatCompletedNum.Name = "lblStatCompletedNum";
            this.lblStatCompletedNum.Size = new System.Drawing.Size(80, 32);
            this.lblStatCompletedNum.TabIndex = 1;
            this.lblStatCompletedNum.Text = "0";
            // 
            // lblStatCompletedTitle
            // 
            this.lblStatCompletedTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatCompletedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatCompletedTitle.Location = new System.Drawing.Point(16, 20);
            this.lblStatCompletedTitle.Name = "lblStatCompletedTitle";
            this.lblStatCompletedTitle.Size = new System.Drawing.Size(180, 22);
            this.lblStatCompletedTitle.TabIndex = 0;
            this.lblStatCompletedTitle.Text = "Hoàn thành";
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
            this.pnlStatTotal.Location = new System.Drawing.Point(897, 0);
            this.pnlStatTotal.Margin = new System.Windows.Forms.Padding(0);
            this.pnlStatTotal.Name = "pnlStatTotal";
            this.pnlStatTotal.Size = new System.Drawing.Size(299, 90);
            this.pnlStatTotal.TabIndex = 3;
            // 
            // lblStatTotalNum
            // 
            this.lblStatTotalNum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStatTotalNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(34)))), ((int)(((byte)(206)))));
            this.lblStatTotalNum.Location = new System.Drawing.Point(16, 48);
            this.lblStatTotalNum.Name = "lblStatTotalNum";
            this.lblStatTotalNum.Size = new System.Drawing.Size(80, 32);
            this.lblStatTotalNum.TabIndex = 1;
            this.lblStatTotalNum.Text = "0";
            // 
            // lblStatTotalTitle
            // 
            this.lblStatTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatTotalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblStatTotalTitle.Location = new System.Drawing.Point(16, 20);
            this.lblStatTotalTitle.Name = "lblStatTotalTitle";
            this.lblStatTotalTitle.Size = new System.Drawing.Size(180, 22);
            this.lblStatTotalTitle.TabIndex = 0;
            this.lblStatTotalTitle.Text = "Tổng yêu cầu";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlFilter.Controls.Add(this.comboRequestStatusFilter);
            this.pnlFilter.Controls.Add(this.txtRequestSearch);
            this.pnlFilter.CornerRadius = 8;
            this.pnlFilter.FillColor = System.Drawing.Color.White;
            this.pnlFilter.Location = new System.Drawing.Point(24, 214);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1452, 96);
            this.pnlFilter.TabIndex = 4;
            // 
            // txtRequestSearch
            // 
            this.txtRequestSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRequestSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtRequestSearch.Location = new System.Drawing.Point(24, 30);
            this.txtRequestSearch.Name = "txtRequestSearch";
            this.txtRequestSearch.Size = new System.Drawing.Size(670, 25);
            this.txtRequestSearch.TabIndex = 0;
            this.txtRequestSearch.Text = "Tìm kiếm bệnh nhân hoặc tên xét nghiệm...";
            // 
            // comboRequestStatusFilter
            // 
            this.comboRequestStatusFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRequestStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRequestStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboRequestStatusFilter.FormattingEnabled = true;
            this.comboRequestStatusFilter.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Chờ xử lý",
            "Đang xử lý",
            "Hoàn thành"});
            this.comboRequestStatusFilter.Location = new System.Drawing.Point(760, 30);
            this.comboRequestStatusFilter.Name = "comboRequestStatusFilter";
            this.comboRequestStatusFilter.Size = new System.Drawing.Size(668, 26);
            this.comboRequestStatusFilter.TabIndex = 1;
            // 
            // flpRequests
            // 
            this.flpRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpRequests.AutoScroll = true;
            this.flpRequests.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRequests.Location = new System.Drawing.Point(24, 328);
            this.flpRequests.Name = "flpRequests";
            this.flpRequests.Size = new System.Drawing.Size(1452, 390);
            this.flpRequests.TabIndex = 5;
            this.flpRequests.WrapContents = false;
            // 
            // pnlProcessNote
            // 
            this.pnlProcessNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProcessNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlProcessNote.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(254)))));
            this.pnlProcessNote.Controls.Add(this.lblStep3);
            this.pnlProcessNote.Controls.Add(this.lblStep2);
            this.pnlProcessNote.Controls.Add(this.lblStep1);
            this.pnlProcessNote.Controls.Add(this.lblProcessTitle);
            this.pnlProcessNote.CornerRadius = 8;
            this.pnlProcessNote.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.pnlProcessNote.Location = new System.Drawing.Point(24, 736);
            this.pnlProcessNote.Name = "pnlProcessNote";
            this.pnlProcessNote.Size = new System.Drawing.Size(1452, 130);
            this.pnlProcessNote.TabIndex = 6;
            // 
            // lblProcessTitle
            // 
            this.lblProcessTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProcessTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblProcessTitle.Location = new System.Drawing.Point(18, 18);
            this.lblProcessTitle.Name = "lblProcessTitle";
            this.lblProcessTitle.Size = new System.Drawing.Size(400, 24);
            this.lblProcessTitle.TabIndex = 0;
            this.lblProcessTitle.Text = "Quy trình xử lý kết quả";
            // 
            // lblStep1
            // 
            this.lblStep1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStep1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStep1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblStep1.Location = new System.Drawing.Point(18, 48);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(1160, 22);
            this.lblStep1.TabIndex = 1;
            this.lblStep1.Text = "1. Nhận yêu cầu: Kỹ thuật viên nhấp 'Bắt đầu xử lý' để đổi trạng thái sang Đang xử lý.";
            // 
            // lblStep2
            // 
            this.lblStep2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStep2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStep2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblStep2.Location = new System.Drawing.Point(18, 72);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(1160, 22);
            this.lblStep2.TabIndex = 2;
            this.lblStep2.Text = "2. Thực hiện: Kỹ thuật viên tiến hành siêu âm/chụp chiếu hoặc phân tích mẫu sinh hóa.";
            // 
            // lblStep3
            // 
            this.lblStep3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStep3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStep3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.lblStep3.Location = new System.Drawing.Point(18, 96);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(1160, 22);
            this.lblStep3.TabIndex = 3;
            this.lblStep3.Text = "3. Hoàn thành: Tải lên hình ảnh phim (MRI/X-Ray), tệp PDF, hoặc điền số liệu Lab để hoàn thành.";
            // 
            // btnSyncCloud
            // 
            this.btnSyncCloud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSyncCloud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnSyncCloud.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSyncCloud.FlatAppearance.BorderSize = 0;
            this.btnSyncCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSyncCloud.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSyncCloud.ForeColor = System.Drawing.Color.White;
            this.btnSyncCloud.Location = new System.Drawing.Point(1260, 24);
            this.btnSyncCloud.Name = "btnSyncCloud";
            this.btnSyncCloud.Size = new System.Drawing.Size(216, 44);
            this.btnSyncCloud.TabIndex = 7;
            this.btnSyncCloud.Text = "Đồng bộ Cloud";
            this.btnSyncCloud.UseVisualStyleBackColor = false;
            // 
            // ucTechnicianRequests

            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianRequests";
            this.Size = new System.Drawing.Size(1500, 900);
            this.Load += new System.EventHandler(this.ucTechnicianRequests_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianRequests_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlStatsGrid.ResumeLayout(false);
            this.pnlStatPending.ResumeLayout(false);
            this.pnlStatProcessing.ResumeLayout(false);
            this.pnlStatCompleted.ResumeLayout(false);
            this.pnlStatTotal.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlProcessNote.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel pnlStatsGrid;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatPending;
        private System.Windows.Forms.Label lblStatPendingNum;
        private System.Windows.Forms.Label lblStatPendingTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatProcessing;
        private System.Windows.Forms.Label lblStatProcessingNum;
        private System.Windows.Forms.Label lblStatProcessingTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatCompleted;
        private System.Windows.Forms.Label lblStatCompletedNum;
        private System.Windows.Forms.Label lblStatCompletedTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlStatTotal;
        private System.Windows.Forms.Label lblStatTotalNum;
        private System.Windows.Forms.Label lblStatTotalTitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlFilter;
        private System.Windows.Forms.TextBox txtRequestSearch;
        private System.Windows.Forms.ComboBox comboRequestStatusFilter;
        private System.Windows.Forms.FlowLayoutPanel flpRequests;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlProcessNote;
        private System.Windows.Forms.Label lblProcessTitle;
        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.Button btnSyncCloud;
    }
}
