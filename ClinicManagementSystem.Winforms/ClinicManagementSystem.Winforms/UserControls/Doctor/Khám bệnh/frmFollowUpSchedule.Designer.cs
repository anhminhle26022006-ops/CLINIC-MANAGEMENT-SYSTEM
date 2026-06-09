namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class frmFollowUpSchedule
    {
        /// <summary>
        /// Required designer variable.
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;

        private Panel pnlPatientInfo;
        public Label lblPatientName;
        public Label lblPatientCode;

        private Panel pnlMain;

        private Label lblDateTitle;
        private DateTimePicker dtpFollowUpDate;

        private Label lblReminderTitle;
        private FlowLayoutPanel flpReminderButtons;

        private Button btn1Day;
        private Button btn3Days;
        private Button btn7Days;
        private Button btn14Days;

        private Label lblReasonTitle;
        private TextBox txtReason;

        private Button btnCreate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlPatientInfo = new Panel();
            lblPatientName = new Label();
            lblPatientCode = new Label();
            pnlMain = new Panel();
            lblDateTitle = new Label();
            dtpFollowUpDate = new DateTimePicker();
            lblReminderTitle = new Label();
            flpReminderButtons = new FlowLayoutPanel();
            btn1Day = new Button();
            btn3Days = new Button();
            btn7Days = new Button();
            btn14Days = new Button();
            lblReasonTitle = new Label();
            txtReason = new TextBox();
            btnCreate = new Button();
            pnlHeader.SuspendLayout();
            pnlPatientInfo.SuspendLayout();
            pnlMain.SuspendLayout();
            flpReminderButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(47, 94, 240);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(582, 60);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(249, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO LỊCH TÁI KHÁM";
            // 
            // pnlPatientInfo
            // 
            pnlPatientInfo.BackColor = Color.WhiteSmoke;
            pnlPatientInfo.Controls.Add(lblPatientName);
            pnlPatientInfo.Controls.Add(lblPatientCode);
            pnlPatientInfo.Dock = DockStyle.Top;
            pnlPatientInfo.Location = new Point(0, 60);
            pnlPatientInfo.Name = "pnlPatientInfo";
            pnlPatientInfo.Size = new Size(582, 80);
            pnlPatientInfo.TabIndex = 1;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPatientName.Location = new Point(20, 10);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(147, 28);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "Nguyễn Văn A";
            // 
            // lblPatientCode
            // 
            lblPatientCode.AutoSize = true;
            lblPatientCode.Font = new Font("Segoe UI", 10F);
            lblPatientCode.ForeColor = Color.DimGray;
            lblPatientCode.Location = new Point(20, 40);
            lblPatientCode.Name = "lblPatientCode";
            lblPatientCode.Size = new Size(148, 23);
            lblPatientCode.TabIndex = 1;
            lblPatientCode.Text = "Mã BN: BN001234";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(lblDateTitle);
            pnlMain.Controls.Add(dtpFollowUpDate);
            pnlMain.Controls.Add(lblReminderTitle);
            pnlMain.Controls.Add(flpReminderButtons);
            pnlMain.Controls.Add(lblReasonTitle);
            pnlMain.Controls.Add(txtReason);
            pnlMain.Controls.Add(btnCreate);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 140);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(20);
            pnlMain.Size = new Size(582, 399);
            pnlMain.TabIndex = 0;
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Location = new Point(20, 20);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(108, 20);
            lblDateTitle.TabIndex = 0;
            lblDateTitle.Text = "Ngày tái khám:";
            // 
            // dtpFollowUpDate
            // 
            dtpFollowUpDate.Location = new Point(20, 45);
            dtpFollowUpDate.Name = "dtpFollowUpDate";
            dtpFollowUpDate.Size = new Size(250, 27);
            dtpFollowUpDate.TabIndex = 1;
            // 
            // lblReminderTitle
            // 
            lblReminderTitle.AutoSize = true;
            lblReminderTitle.Location = new Point(20, 85);
            lblReminderTitle.Name = "lblReminderTitle";
            lblReminderTitle.Size = new Size(112, 20);
            lblReminderTitle.TabIndex = 2;
            lblReminderTitle.Text = "Nhắc lịch trước:";
            // 
            // flpReminderButtons
            // 
            flpReminderButtons.Controls.Add(btn1Day);
            flpReminderButtons.Controls.Add(btn3Days);
            flpReminderButtons.Controls.Add(btn7Days);
            flpReminderButtons.Controls.Add(btn14Days);
            flpReminderButtons.Location = new Point(20, 110);
            flpReminderButtons.Name = "flpReminderButtons";
            flpReminderButtons.Size = new Size(520, 45);
            flpReminderButtons.TabIndex = 3;
            // 
            // btn1Day
            // 
            btn1Day.Location = new Point(3, 3);
            btn1Day.Name = "btn1Day";
            btn1Day.Size = new Size(120, 42);
            btn1Day.TabIndex = 0;
            btn1Day.Text = "1 ngày";
            // 
            // btn3Days
            // 
            btn3Days.Location = new Point(129, 3);
            btn3Days.Name = "btn3Days";
            btn3Days.Size = new Size(120, 42);
            btn3Days.TabIndex = 1;
            btn3Days.Text = "3 ngày";
            // 
            // btn7Days
            // 
            btn7Days.Location = new Point(255, 3);
            btn7Days.Name = "btn7Days";
            btn7Days.Size = new Size(120, 42);
            btn7Days.TabIndex = 2;
            btn7Days.Text = "7 ngày";
            // 
            // btn14Days
            // 
            btn14Days.Location = new Point(381, 3);
            btn14Days.Name = "btn14Days";
            btn14Days.Size = new Size(120, 42);
            btn14Days.TabIndex = 3;
            btn14Days.Text = "14 ngày";
            // 
            // lblReasonTitle
            // 
            lblReasonTitle.AutoSize = true;
            lblReasonTitle.Location = new Point(20, 165);
            lblReasonTitle.Name = "lblReasonTitle";
            lblReasonTitle.Size = new Size(108, 20);
            lblReasonTitle.TabIndex = 4;
            lblReasonTitle.Text = "Lý do tái khám:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(20, 190);
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(520, 120);
            txtReason.TabIndex = 5;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(47, 94, 240);
            btnCreate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(20, 330);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(520, 45);
            btnCreate.TabIndex = 6;
            btnCreate.Text = "Tạo lịch tái khám";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // frmFollowUpSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(582, 539);
            Controls.Add(pnlMain);
            Controls.Add(pnlPatientInfo);
            Controls.Add(pnlHeader);
            Name = "frmFollowUpSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo lịch tái khám";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlPatientInfo.ResumeLayout(false);
            pnlPatientInfo.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            flpReminderButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
    }
}