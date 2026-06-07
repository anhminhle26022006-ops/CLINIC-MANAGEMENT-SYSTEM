namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    partial class RemindingCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemindingCard));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblPatientCode = new Label();
            lblPatientName = new Label();
            panel3 = new Panel();
            lblStatus = new Label();
            btnAction = new Button();
            panel2 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label9 = new Label();
            tableLayoutPanel8 = new TableLayoutPanel();
            lblCreatedBy = new Label();
            lblReminder = new Label();
            tableLayoutPanel7 = new TableLayoutPanel();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel6 = new TableLayoutPanel();
            lblDoctorName = new Label();
            lblDate = new Label();
            lblNote = new Label();
            lblDiagnosis = new Label();
            label8 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(713, 435);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAction, 0, 2);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.7586212F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65.28735F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1839085F));
            tableLayoutPanel1.Size = new Size(713, 435);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.8496733F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 84.15033F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 94F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Controls.Add(panel3, 2, 0);
            tableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(707, 92);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(lblPatientCode, 0, 1);
            tableLayoutPanel3.Controls.Add(lblPatientName, 0, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(100, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 58.139534F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 41.860466F));
            tableLayoutPanel3.Size = new Size(509, 86);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // lblPatientCode
            // 
            lblPatientCode.AutoSize = true;
            lblPatientCode.Dock = DockStyle.Fill;
            lblPatientCode.Location = new Point(3, 50);
            lblPatientCode.Name = "lblPatientCode";
            lblPatientCode.Size = new Size(503, 36);
            lblPatientCode.TabIndex = 1;
            lblPatientCode.Text = "label3";
            lblPatientCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Dock = DockStyle.Fill;
            lblPatientName.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPatientName.Location = new Point(3, 0);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(503, 50);
            lblPatientName.TabIndex = 0;
            lblPatientName.Text = "lblPatientName";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblStatus);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(615, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(89, 86);
            panel3.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Right;
            lblStatus.Location = new Point(6, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 86);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "label12";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAction
            // 
            btnAction.Dock = DockStyle.Fill;
            btnAction.Location = new Point(3, 384);
            btnAction.Name = "btnAction";
            btnAction.Size = new Size(707, 48);
            btnAction.TabIndex = 2;
            btnAction.Text = "button1";
            btnAction.UseVisualStyleBackColor = true;
            btnAction.Click += btnAction_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel4);
            panel2.Dock = DockStyle.Fill;
            panel2.ForeColor = Color.Black;
            panel2.Location = new Point(3, 101);
            panel2.Name = "panel2";
            panel2.Size = new Size(707, 277);
            panel2.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(label9, 0, 6);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel8, 0, 3);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel7, 0, 2);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel6, 0, 1);
            tableLayoutPanel4.Controls.Add(lblNote, 0, 7);
            tableLayoutPanel4.Controls.Add(lblDiagnosis, 0, 5);
            tableLayoutPanel4.Controls.Add(label8, 0, 4);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 8;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel4.Size = new Size(707, 277);
            tableLayoutPanel4.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 196);
            label9.Name = "label9";
            label9.Size = new Size(701, 30);
            label9.TabIndex = 14;
            label9.Text = "Ghi chú cho lễ tân";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 2;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(lblCreatedBy, 1, 0);
            tableLayoutPanel8.Controls.Add(lblReminder, 0, 0);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 93);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 1;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Size = new Size(701, 24);
            tableLayoutPanel8.TabIndex = 13;
            // 
            // lblCreatedBy
            // 
            lblCreatedBy.AutoSize = true;
            lblCreatedBy.Dock = DockStyle.Fill;
            lblCreatedBy.Location = new Point(353, 0);
            lblCreatedBy.Name = "lblCreatedBy";
            lblCreatedBy.Size = new Size(345, 24);
            lblCreatedBy.TabIndex = 5;
            lblCreatedBy.Text = "label6";
            lblCreatedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReminder
            // 
            lblReminder.AutoSize = true;
            lblReminder.Dock = DockStyle.Fill;
            lblReminder.Location = new Point(3, 0);
            lblReminder.Name = "lblReminder";
            lblReminder.Size = new Size(344, 24);
            lblReminder.TabIndex = 4;
            lblReminder.Text = "label4";
            lblReminder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 2;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.Controls.Add(label4, 1, 0);
            tableLayoutPanel7.Controls.Add(label5, 0, 0);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 63);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 1;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Size = new Size(701, 24);
            tableLayoutPanel7.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(353, 0);
            label4.Name = "label4";
            label4.Size = new Size(345, 24);
            label4.TabIndex = 8;
            label4.Text = "Tạo bởi";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(344, 24);
            label5.TabIndex = 7;
            label5.Text = "Nhắc trước";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 2;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(lblDoctorName, 1, 0);
            tableLayoutPanel6.Controls.Add(lblDate, 0, 0);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(3, 33);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 1;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Size = new Size(701, 24);
            tableLayoutPanel6.TabIndex = 11;
            // 
            // lblDoctorName
            // 
            lblDoctorName.AutoSize = true;
            lblDoctorName.Dock = DockStyle.Fill;
            lblDoctorName.Location = new Point(353, 0);
            lblDoctorName.Name = "lblDoctorName";
            lblDoctorName.Size = new Size(345, 24);
            lblDoctorName.TabIndex = 5;
            lblDoctorName.Text = "lblDoctor";
            lblDoctorName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Dock = DockStyle.Fill;
            lblDate.Location = new Point(3, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(344, 24);
            lblDate.TabIndex = 4;
            lblDate.Text = "label4";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Dock = DockStyle.Fill;
            lblNote.Location = new Point(3, 226);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(701, 51);
            lblNote.TabIndex = 9;
            lblNote.Text = "label11";
            lblNote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Dock = DockStyle.Fill;
            lblDiagnosis.Location = new Point(3, 150);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(701, 46);
            lblDiagnosis.TabIndex = 7;
            lblDiagnosis.Text = "label9";
            lblDiagnosis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 120);
            label8.Name = "label8";
            label8.Size = new Size(701, 30);
            label8.TabIndex = 6;
            label8.Text = "Lý do tái khám";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(label1, 0, 0);
            tableLayoutPanel5.Controls.Add(label2, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(701, 24);
            tableLayoutPanel5.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(344, 24);
            label1.TabIndex = 8;
            label1.Text = "Ngày tái khám";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(353, 0);
            label2.Name = "label2";
            label2.Size = new Size(345, 24);
            label2.TabIndex = 7;
            label2.Text = "Bác sĩ phụ trách";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(91, 86);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // RemindingCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "RemindingCard";
            Size = new Size(713, 435);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label lblPatientCode;
        private Label lblPatientName;
        private Panel panel3;
        private Label lblStatus;
        private Button btnAction;
        private Panel panel2;
        private Label lblDiagnosis;
        private Label lblNote;
        private Label lblDoctorName;
        private Label label8;
        private TableLayoutPanel tableLayoutPanel8;
        private Label lblCreatedBy;
        private Label lblReminder;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel6;
        private Label lblDate;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label9;
        private Label label4;
        private Label label5;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox1;
    }
}
