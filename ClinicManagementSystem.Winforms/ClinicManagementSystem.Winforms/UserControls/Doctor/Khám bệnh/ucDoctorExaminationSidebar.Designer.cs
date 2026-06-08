namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucDoctorExaminationSidebar
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;

        private Label lblClinic;
        private Label lblDoctor;
        private Label lblDate;
        private Label lblProgress;

        private TableLayoutPanel tblMain;

        private Panel pnlWaitingColumn;
        private Panel pnlExamColumn;
        private Panel pnlHistoryColumn;

        private Panel pnlQueueHeader;
        private Label lblQueueCount;
        private FlowLayoutPanel flpWaitingPatients;

        private Panel pnlPatientInfo;
        public Label lblPatientName;
        public Label lblPatientInfo;
        public Label lblBMITitle;
        public Label lblBMI;

        private Panel pnlVitalSigns;
        private FlowLayoutPanel flpVitalSigns;

        private Panel pnlTabs;
        private Button btnExamination;
        private Button btnPrescription;
        private Button btnLab;
        private Button btnImaging;

        private Panel pnlTabContent;

        private Panel pnlBottomButtons;
        private Button btnCancel;
        private Button btnFollowUp;
        private Button btnComplete;

        private FlowLayoutPanel flpHistory;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblClinic = new Label();
            lblDoctor = new Label();
            lblDate = new Label();
            lblProgress = new Label();
            tblMain = new TableLayoutPanel();
            pnlWaitingColumn = new Panel();
            flpWaitingPatients = new FlowLayoutPanel();
            pnlQueueHeader = new Panel();
            lblQueueCount = new Label();
            pnlExamColumn = new Panel();
            pnlTabContent = new Panel();
            pnlBottomButtons = new Panel();
            btnCancel = new Button();
            btnFollowUp = new Button();
            btnComplete = new Button();
            pnlTabs = new Panel();
            btnExamination = new Button();
            btnPrescription = new Button();
            btnLab = new Button();
            btnImaging = new Button();
            pnlVitalSigns = new Panel();
            flpVitalSigns = new FlowLayoutPanel();
            pnlPatientInfo = new Panel();
            lblPatientName = new Label();
            lblPatientInfo = new Label();
            lblBMITitle = new Label();
            lblBMI = new Label();
            pnlHistoryColumn = new Panel();
            flpHistory = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            tblMain.SuspendLayout();
            pnlWaitingColumn.SuspendLayout();
            pnlQueueHeader.SuspendLayout();
            pnlExamColumn.SuspendLayout();
            pnlBottomButtons.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlVitalSigns.SuspendLayout();
            pnlPatientInfo.SuspendLayout();
            pnlHistoryColumn.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblClinic);
            pnlHeader.Controls.Add(lblDoctor);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblProgress);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(20);
            pnlHeader.Size = new Size(1545, 90);
            pnlHeader.TabIndex = 1;
            // 
            // lblClinic
            // 
            lblClinic.AutoSize = true;
            lblClinic.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblClinic.Location = new Point(20, 10);
            lblClinic.Name = "lblClinic";
            lblClinic.Size = new Size(395, 32);
            lblClinic.TabIndex = 0;
            lblClinic.Text = "PHÒNG KHÁM P203 - TIM MẠCH";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Font = new Font("Segoe UI", 10F);
            lblDoctor.Location = new Point(22, 42);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(193, 23);
            lblDoctor.TabIndex = 1;
            lblDoctor.Text = "BS. Nguyễn Thành Nam";
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.AutoSize = true;
            lblDate.Location = new Point(2245, 15);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "08/06/2026";
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(2245, 45);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(105, 20);
            lblProgress.TabIndex = 3;
            lblProgress.Text = "Đã khám: 5/20";
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 3;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblMain.Controls.Add(pnlWaitingColumn, 0, 0);
            tblMain.Controls.Add(pnlExamColumn, 1, 0);
            tblMain.Controls.Add(pnlHistoryColumn, 2, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 90);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMain.Size = new Size(1545, 644);
            tblMain.TabIndex = 0;
            // 
            // pnlWaitingColumn
            // 
            pnlWaitingColumn.Controls.Add(flpWaitingPatients);
            pnlWaitingColumn.Controls.Add(pnlQueueHeader);
            pnlWaitingColumn.Dock = DockStyle.Fill;
            pnlWaitingColumn.Location = new Point(3, 3);
            pnlWaitingColumn.Name = "pnlWaitingColumn";
            pnlWaitingColumn.Padding = new Padding(10);
            pnlWaitingColumn.Size = new Size(380, 638);
            pnlWaitingColumn.TabIndex = 0;
            // 
            // flpWaitingPatients
            // 
            flpWaitingPatients.AutoScroll = true;
            flpWaitingPatients.Dock = DockStyle.Fill;
            flpWaitingPatients.FlowDirection = FlowDirection.TopDown;
            flpWaitingPatients.Location = new Point(10, 80);
            flpWaitingPatients.Name = "flpWaitingPatients";
            flpWaitingPatients.Size = new Size(360, 548);
            flpWaitingPatients.TabIndex = 0;
            flpWaitingPatients.WrapContents = false;
            // 
            // pnlQueueHeader
            // 
            pnlQueueHeader.BackColor = Color.FromArgb(230, 244, 255);
            pnlQueueHeader.Controls.Add(lblQueueCount);
            pnlQueueHeader.Dock = DockStyle.Top;
            pnlQueueHeader.Location = new Point(10, 10);
            pnlQueueHeader.Name = "pnlQueueHeader";
            pnlQueueHeader.Size = new Size(360, 70);
            pnlQueueHeader.TabIndex = 1;
            // 
            // lblQueueCount
            // 
            lblQueueCount.AutoSize = true;
            lblQueueCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQueueCount.Location = new Point(15, 22);
            lblQueueCount.Name = "lblQueueCount";
            lblQueueCount.Size = new Size(193, 25);
            lblQueueCount.TabIndex = 0;
            lblQueueCount.Text = "Hàng chờ khám (12)";
            // 
            // pnlExamColumn
            // 
            pnlExamColumn.Controls.Add(pnlTabContent);
            pnlExamColumn.Controls.Add(pnlBottomButtons);
            pnlExamColumn.Controls.Add(pnlTabs);
            pnlExamColumn.Controls.Add(pnlVitalSigns);
            pnlExamColumn.Controls.Add(pnlPatientInfo);
            pnlExamColumn.Dock = DockStyle.Fill;
            pnlExamColumn.Location = new Point(389, 3);
            pnlExamColumn.Name = "pnlExamColumn";
            pnlExamColumn.Padding = new Padding(10);
            pnlExamColumn.Size = new Size(766, 638);
            pnlExamColumn.TabIndex = 1;
            // 
            // pnlTabContent
            // 
            pnlTabContent.Dock = DockStyle.Fill;
            pnlTabContent.Location = new Point(10, 300);
            pnlTabContent.Name = "pnlTabContent";
            pnlTabContent.Size = new Size(746, 258);
            pnlTabContent.TabIndex = 0;
            // 
            // pnlBottomButtons
            // 
            pnlBottomButtons.Controls.Add(btnCancel);
            pnlBottomButtons.Controls.Add(btnFollowUp);
            pnlBottomButtons.Controls.Add(btnComplete);
            pnlBottomButtons.Dock = DockStyle.Bottom;
            pnlBottomButtons.Location = new Point(10, 558);
            pnlBottomButtons.Name = "pnlBottomButtons";
            pnlBottomButtons.Size = new Size(746, 70);
            pnlBottomButtons.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(50, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 40);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Hủy";
            // 
            // btnFollowUp
            // 
            btnFollowUp.BackColor = Color.NavajoWhite;
            btnFollowUp.Location = new Point(235, 15);
            btnFollowUp.Name = "btnFollowUp";
            btnFollowUp.Size = new Size(212, 40);
            btnFollowUp.TabIndex = 1;
            btnFollowUp.Text = "Tạo lịch tái khám";
            btnFollowUp.UseVisualStyleBackColor = false;
            // 
            // btnComplete
            // 
            btnComplete.BackColor = Color.FromArgb(192, 255, 192);
            btnComplete.Location = new Point(482, 15);
            btnComplete.Name = "btnComplete";
            btnComplete.Size = new Size(241, 40);
            btnComplete.TabIndex = 2;
            btnComplete.Text = "Hoàn thành khám";
            btnComplete.UseVisualStyleBackColor = false;
            // 
            // pnlTabs
            // 
            pnlTabs.Controls.Add(btnExamination);
            pnlTabs.Controls.Add(btnPrescription);
            pnlTabs.Controls.Add(btnLab);
            pnlTabs.Controls.Add(btnImaging);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(10, 250);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Size = new Size(746, 50);
            pnlTabs.TabIndex = 2;
            // 
            // btnExamination
            // 
            btnExamination.Location = new Point(0, 8);
            btnExamination.Name = "btnExamination";
            btnExamination.Size = new Size(184, 36);
            btnExamination.TabIndex = 0;
            btnExamination.Text = "Khám bệnh";
            // 
            // btnPrescription
            // 
            btnPrescription.Location = new Point(190, 7);
            btnPrescription.Name = "btnPrescription";
            btnPrescription.Size = new Size(152, 35);
            btnPrescription.TabIndex = 1;
            btnPrescription.Text = "Kê toa";
            // 
            // btnLab
            // 
            btnLab.Location = new Point(348, 6);
            btnLab.Name = "btnLab";
            btnLab.Size = new Size(163, 36);
            btnLab.TabIndex = 2;
            btnLab.Text = "Xét nghiệm";
            // 
            // btnImaging
            // 
            btnImaging.Location = new Point(517, 8);
            btnImaging.Name = "btnImaging";
            btnImaging.Size = new Size(188, 34);
            btnImaging.TabIndex = 3;
            btnImaging.Text = "CĐHA";
            // 
            // pnlVitalSigns
            // 
            pnlVitalSigns.Controls.Add(flpVitalSigns);
            pnlVitalSigns.Dock = DockStyle.Top;
            pnlVitalSigns.Location = new Point(10, 130);
            pnlVitalSigns.Name = "pnlVitalSigns";
            pnlVitalSigns.Padding = new Padding(10);
            pnlVitalSigns.Size = new Size(746, 120);
            pnlVitalSigns.TabIndex = 3;
            // 
            // flpVitalSigns
            // 
            flpVitalSigns.AutoScroll = true;
            flpVitalSigns.Dock = DockStyle.Fill;
            flpVitalSigns.Location = new Point(10, 10);
            flpVitalSigns.Name = "flpVitalSigns";
            flpVitalSigns.Size = new Size(726, 100);
            flpVitalSigns.TabIndex = 0;
            flpVitalSigns.WrapContents = false;
            // 
            // pnlPatientInfo
            // 
            pnlPatientInfo.BackColor = Color.White;
            pnlPatientInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlPatientInfo.Controls.Add(lblPatientName);
            pnlPatientInfo.Controls.Add(lblPatientInfo);
            pnlPatientInfo.Controls.Add(lblBMITitle);
            pnlPatientInfo.Controls.Add(lblBMI);
            pnlPatientInfo.Dock = DockStyle.Top;
            pnlPatientInfo.Location = new Point(10, 10);
            pnlPatientInfo.Name = "pnlPatientInfo";
            pnlPatientInfo.Size = new Size(746, 120);
            pnlPatientInfo.TabIndex = 4;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPatientName.Location = new Point(81, 15);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(128, 32);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Trần Thị B";
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.AutoSize = true;
            lblPatientInfo.Font = new Font("Segoe UI", 10F);
            lblPatientInfo.ForeColor = Color.DimGray;
            lblPatientInfo.Location = new Point(81, 55);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new Size(288, 23);
            lblPatientInfo.TabIndex = 1;
            lblPatientInfo.Text = "BN001235 • 32 tuổi • Nữ • STT: A007";
            // 
            // lblBMITitle
            // 
            lblBMITitle.AutoSize = true;
            lblBMITitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBMITitle.Location = new Point(562, 15);
            lblBMITitle.Name = "lblBMITitle";
            lblBMITitle.Size = new Size(42, 23);
            lblBMITitle.TabIndex = 2;
            lblBMITitle.Text = "BMI";
            // 
            // lblBMI
            // 
            lblBMI.AutoSize = true;
            lblBMI.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBMI.ForeColor = Color.FromArgb(37, 99, 235);
            lblBMI.Location = new Point(548, 55);
            lblBMI.Name = "lblBMI";
            lblBMI.Size = new Size(77, 41);
            lblBMI.TabIndex = 3;
            lblBMI.Text = "21.5";
            // 
            // pnlHistoryColumn
            // 
            pnlHistoryColumn.Controls.Add(flpHistory);
            pnlHistoryColumn.Dock = DockStyle.Fill;
            pnlHistoryColumn.Location = new Point(1161, 3);
            pnlHistoryColumn.Name = "pnlHistoryColumn";
            pnlHistoryColumn.Padding = new Padding(10);
            pnlHistoryColumn.Size = new Size(381, 638);
            pnlHistoryColumn.TabIndex = 2;
            // 
            // flpHistory
            // 
            flpHistory.AutoScroll = true;
            flpHistory.Dock = DockStyle.Fill;
            flpHistory.FlowDirection = FlowDirection.TopDown;
            flpHistory.Location = new Point(10, 10);
            flpHistory.Name = "flpHistory";
            flpHistory.Size = new Size(361, 618);
            flpHistory.TabIndex = 0;
            flpHistory.WrapContents = false;
            // 
            // ucDoctorExaminationSidebar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tblMain);
            Controls.Add(pnlHeader);
            Name = "ucDoctorExaminationSidebar";
            Size = new Size(1545, 734);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tblMain.ResumeLayout(false);
            pnlWaitingColumn.ResumeLayout(false);
            pnlQueueHeader.ResumeLayout(false);
            pnlQueueHeader.PerformLayout();
            pnlExamColumn.ResumeLayout(false);
            pnlBottomButtons.ResumeLayout(false);
            pnlTabs.ResumeLayout(false);
            pnlVitalSigns.ResumeLayout(false);
            pnlPatientInfo.ResumeLayout(false);
            pnlPatientInfo.PerformLayout();
            pnlHistoryColumn.ResumeLayout(false);
            ResumeLayout(false);
        }
        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }
}
