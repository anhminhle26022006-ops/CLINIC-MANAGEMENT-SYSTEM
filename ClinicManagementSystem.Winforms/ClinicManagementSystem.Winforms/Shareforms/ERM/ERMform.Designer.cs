namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ERMform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlHeader = new Panel();
            dtfrom = new DateTimePicker();
            dtto = new DateTimePicker();
            lblBloodType = new Label();
            lblGender = new Label();
            lblAge = new Label();
            lblPatientCode = new Label();
            label1 = new Label();
            lblPatientName = new Label();
            picPatient = new PictureBox();
            pnlTabBar = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnOverview = new Button();
            btnHistory = new Button();
            btnPrescription = new Button();
            btnLab = new Button();
            btnImaging = new Button();
            btnBilling = new Button();
            btnFollowup = new Button();
            pnlContent = new Panel();
            ucOverview1 = new ucOverview();
            ucHistory1 = new ucHistory();
            ucPrescription1 = new ucPrescription();
            ucLab1 = new ucLab();
            ucImaging1 = new ucImaging();
            ucBilling1 = new ucBilling();
            ucFollowup1 = new ucFollowup();
            tableLayoutPanel1.SuspendLayout();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPatient).BeginInit();
            pnlTabBar.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            pnlContent.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pnlHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlTabBar, 0, 1);
            tableLayoutPanel1.Controls.Add(pnlContent, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 90F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 294F));
            tableLayoutPanel1.Size = new Size(1485, 642);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.RoyalBlue;
            pnlHeader.Controls.Add(dtfrom);
            pnlHeader.Controls.Add(dtto);
            pnlHeader.Controls.Add(lblBloodType);
            pnlHeader.Controls.Add(lblGender);
            pnlHeader.Controls.Add(lblAge);
            pnlHeader.Controls.Add(lblPatientCode);
            pnlHeader.Controls.Add(label1);
            pnlHeader.Controls.Add(lblPatientName);
            pnlHeader.Controls.Add(picPatient);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1479, 84);
            pnlHeader.TabIndex = 0;
            // 
            // dtfrom
            // 
            dtfrom.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtfrom.Location = new Point(807, 24);
            dtfrom.Name = "dtfrom";
            dtfrom.Size = new Size(269, 27);
            dtfrom.TabIndex = 9;
            // 
            // dtto
            // 
            dtto.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtto.Location = new Point(1172, 24);
            dtto.Name = "dtto";
            dtto.Size = new Size(264, 27);
            dtto.TabIndex = 8;
            // 
            // lblBloodType
            // 
            lblBloodType.AutoSize = true;
            lblBloodType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBloodType.ForeColor = Color.White;
            lblBloodType.Location = new Point(580, 43);
            lblBloodType.Name = "lblBloodType";
            lblBloodType.Size = new Size(146, 28);
            lblBloodType.TabIndex = 6;
            lblBloodType.Text = "Nhóm máu: A+";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGender.ForeColor = Color.White;
            lblGender.Location = new Point(489, 43);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(54, 28);
            lblGender.TabIndex = 5;
            lblGender.Text = "Nam";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAge.ForeColor = Color.White;
            lblAge.Location = new Point(376, 43);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(74, 28);
            lblAge.TabIndex = 4;
            lblAge.Text = "45 tuổi";
            // 
            // lblPatientCode
            // 
            lblPatientCode.AutoSize = true;
            lblPatientCode.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPatientCode.ForeColor = Color.White;
            lblPatientCode.Location = new Point(222, 43);
            lblPatientCode.Name = "lblPatientCode";
            lblPatientCode.Size = new Size(104, 28);
            lblPatientCode.TabIndex = 3;
            lblPatientCode.Text = "BN001234";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(141, 43);
            label1.Name = "label1";
            label1.Size = new Size(75, 28);
            label1.TabIndex = 2;
            label1.Text = "Mã BN:";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientName.ForeColor = Color.White;
            lblPatientName.Location = new Point(141, 6);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(143, 28);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Nguyễn Văn A";
            // 
            // picPatient
            // 
            picPatient.Image = Properties.Resources.istockphoto_1147248235_170667a;
            picPatient.Location = new Point(0, 0);
            picPatient.Name = "picPatient";
            picPatient.Size = new Size(122, 81);
            picPatient.SizeMode = PictureBoxSizeMode.Zoom;
            picPatient.TabIndex = 0;
            picPatient.TabStop = false;
            // 
            // pnlTabBar
            // 
            pnlTabBar.Controls.Add(flowLayoutPanel1);
            pnlTabBar.Dock = DockStyle.Fill;
            pnlTabBar.Location = new Point(3, 93);
            pnlTabBar.Name = "pnlTabBar";
            pnlTabBar.Size = new Size(1479, 42);
            pnlTabBar.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnOverview);
            flowLayoutPanel1.Controls.Add(btnHistory);
            flowLayoutPanel1.Controls.Add(btnPrescription);
            flowLayoutPanel1.Controls.Add(btnLab);
            flowLayoutPanel1.Controls.Add(btnImaging);
            flowLayoutPanel1.Controls.Add(btnBilling);
            flowLayoutPanel1.Controls.Add(btnFollowup);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1479, 42);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnOverview
            // 
            btnOverview.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOverview.Image = Properties.Resources.Screenshot_2026_06_07_161359;
            btnOverview.ImageAlign = ContentAlignment.MiddleLeft;
            btnOverview.Location = new Point(3, 3);
            btnOverview.Name = "btnOverview";
            btnOverview.Size = new Size(238, 42);
            btnOverview.TabIndex = 0;
            btnOverview.Text = "Tổng quan";
            btnOverview.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistory.Image = Properties.Resources.Screenshot_2026_06_07_161557;
            btnHistory.ImageAlign = ContentAlignment.MiddleLeft;
            btnHistory.Location = new Point(247, 3);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(225, 42);
            btnHistory.TabIndex = 1;
            btnHistory.Text = "Lịch sử khám";
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // btnPrescription
            // 
            btnPrescription.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrescription.Image = Properties.Resources.Screenshot_2026_06_07_161822;
            btnPrescription.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrescription.Location = new Point(478, 3);
            btnPrescription.Name = "btnPrescription";
            btnPrescription.Size = new Size(193, 42);
            btnPrescription.TabIndex = 3;
            btnPrescription.Text = "Toa thuốc";
            btnPrescription.UseVisualStyleBackColor = true;
            // 
            // btnLab
            // 
            btnLab.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLab.Image = Properties.Resources.Screenshot_2026_06_07_161958;
            btnLab.ImageAlign = ContentAlignment.MiddleLeft;
            btnLab.Location = new Point(677, 3);
            btnLab.Name = "btnLab";
            btnLab.Size = new Size(204, 42);
            btnLab.TabIndex = 4;
            btnLab.Text = "Xét nghiệm";
            btnLab.UseVisualStyleBackColor = true;
            // 
            // btnImaging
            // 
            btnImaging.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnImaging.Image = Properties.Resources.Screenshot_2026_06_07_162153;
            btnImaging.ImageAlign = ContentAlignment.MiddleLeft;
            btnImaging.Location = new Point(887, 3);
            btnImaging.Name = "btnImaging";
            btnImaging.Size = new Size(290, 42);
            btnImaging.TabIndex = 5;
            btnImaging.Text = "Chuẩn doán hình ảnh";
            btnImaging.UseVisualStyleBackColor = true;
            // 
            // btnBilling
            // 
            btnBilling.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBilling.Image = Properties.Resources.Screenshot_2026_06_07_162321;
            btnBilling.ImageAlign = ContentAlignment.MiddleLeft;
            btnBilling.Location = new Point(1183, 3);
            btnBilling.Name = "btnBilling";
            btnBilling.Size = new Size(180, 42);
            btnBilling.TabIndex = 6;
            btnBilling.Text = "Thanh toán";
            btnBilling.UseVisualStyleBackColor = true;
            // 
            // btnFollowup
            // 
            btnFollowup.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFollowup.Image = Properties.Resources.Screenshot_2026_06_07_162425;
            btnFollowup.ImageAlign = ContentAlignment.MiddleLeft;
            btnFollowup.Location = new Point(3, 51);
            btnFollowup.Name = "btnFollowup";
            btnFollowup.Size = new Size(178, 39);
            btnFollowup.TabIndex = 2;
            btnFollowup.Text = "Tái khám";
            btnFollowup.UseVisualStyleBackColor = true;
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(ucFollowup1);
            pnlContent.Controls.Add(ucBilling1);
            pnlContent.Controls.Add(ucImaging1);
            pnlContent.Controls.Add(ucLab1);
            pnlContent.Controls.Add(ucPrescription1);
            pnlContent.Controls.Add(ucHistory1);
            pnlContent.Controls.Add(ucOverview1);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(3, 141);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1479, 498);
            pnlContent.TabIndex = 2;
            // 
            // ucOverview1
            // 
            ucOverview1.Dock = DockStyle.Fill;
            ucOverview1.Location = new Point(0, 0);
            ucOverview1.Name = "ucOverview1";
            ucOverview1.Size = new Size(1479, 498);
            ucOverview1.TabIndex = 0;
            // 
            // ucHistory1
            // 
            ucHistory1.Dock = DockStyle.Fill;
            ucHistory1.Location = new Point(0, 0);
            ucHistory1.Name = "ucHistory1";
            ucHistory1.Size = new Size(1479, 498);
            ucHistory1.TabIndex = 1;
            // 
            // ucPrescription1
            // 
            ucPrescription1.BackColor = Color.White;
            ucPrescription1.Dock = DockStyle.Fill;
            ucPrescription1.Location = new Point(0, 0);
            ucPrescription1.Name = "ucPrescription1";
            ucPrescription1.Size = new Size(1479, 498);
            ucPrescription1.TabIndex = 2;
            // 
            // ucLab1
            // 
            ucLab1.Dock = DockStyle.Fill;
            ucLab1.Location = new Point(0, 0);
            ucLab1.Name = "ucLab1";
            ucLab1.Size = new Size(1479, 498);
            ucLab1.TabIndex = 3;
            // 
            // ucImaging1
            // 
            ucImaging1.Dock = DockStyle.Fill;
            ucImaging1.Location = new Point(0, 0);
            ucImaging1.Name = "ucImaging1";
            ucImaging1.Size = new Size(1479, 498);
            ucImaging1.TabIndex = 4;
            // 
            // ucBilling1
            // 
            ucBilling1.Dock = DockStyle.Fill;
            ucBilling1.Location = new Point(0, 0);
            ucBilling1.Name = "ucBilling1";
            ucBilling1.Size = new Size(1479, 498);
            ucBilling1.TabIndex = 5;
            // 
            // ucFollowup1
            // 
            ucFollowup1.Dock = DockStyle.Fill;
            ucFollowup1.Location = new Point(0, 0);
            ucFollowup1.Name = "ucFollowup1";
            ucFollowup1.Size = new Size(1479, 498);
            ucFollowup1.TabIndex = 6;
            // 
            // ERMform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1485, 642);
            Controls.Add(tableLayoutPanel1);
            Name = "ERMform";
            Text = "ERMform";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPatient).EndInit();
            pnlTabBar.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlHeader;
        private Panel pnlTabBar;
        private Panel pnlContent;
        private PictureBox picPatient;
        private Label lblPatientName;
        private Label lblBloodType;
        private Label lblGender;
        private Label lblAge;
        private Label lblPatientCode;
        private Label label1;
        private DateTimePicker dtfrom;
        private DateTimePicker dtto;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnOverview;
        private Button btnHistory;
        private Button btnPrescription;
        private Button btnLab;
        private Button btnImaging;
        private Button btnBilling;
        private Button btnFollowup;
        private ucHistory ucHistory1;
        private ucOverview ucOverview1;
        private ucLab ucLab1;
        private ucPrescription ucPrescription1;
        private ucFollowup ucFollowup1;
        private ucBilling ucBilling1;
        private ucImaging ucImaging1;
    }
}