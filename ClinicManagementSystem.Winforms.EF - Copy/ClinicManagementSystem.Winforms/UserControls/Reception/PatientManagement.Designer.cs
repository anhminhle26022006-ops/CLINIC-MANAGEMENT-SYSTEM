namespace ClinicManagementSystem.Winforms.UserControls
{
    partial class PatientManagement
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            tableLayoutPanel9 = new TableLayoutPanel();
            cbGender = new ComboBox();
            cbAge = new ComboBox();
            txtSearch = new TextBox();
            panel3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel6 = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            label3 = new Label();
            lbpatienttotal = new Label();
            panel7 = new Panel();
            tableLayoutPanel6 = new TableLayoutPanel();
            label5 = new Label();
            lbnewpatient = new Label();
            panel8 = new Panel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label7 = new Label();
            lbrevisitpatient = new Label();
            panel9 = new Panel();
            tableLayoutPanel8 = new TableLayoutPanel();
            label9 = new Label();
            lbappointment = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            panel5 = new Panel();
            button1 = new Button();
            dgvPatientMana = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel6.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            panel7.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            panel8.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPatientMana).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(928, 794);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(dgvPatientMana, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 71F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(898, 764);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel9);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 166);
            panel2.Name = "panel2";
            panel2.Size = new Size(892, 40);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 3;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel9.Controls.Add(cbGender, 1, 0);
            tableLayoutPanel9.Controls.Add(cbAge, 2, 0);
            tableLayoutPanel9.Controls.Add(txtSearch, 0, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tableLayoutPanel9.Location = new Point(0, 0);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel9.Size = new Size(892, 40);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // cbGender
            // 
            cbGender.Dock = DockStyle.Fill;
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(449, 3);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(217, 30);
            cbGender.TabIndex = 0;
            cbGender.SelectedIndexChanged += FilterChanged;
            // 
            // cbAge
            // 
            cbAge.Dock = DockStyle.Fill;
            cbAge.FormattingEnabled = true;
            cbAge.Location = new Point(672, 3);
            cbAge.Name = "cbAge";
            cbAge.Size = new Size(217, 30);
            cbAge.TabIndex = 1;
            cbAge.SelectedIndexChanged += FilterChanged;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(3, 3);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm bệnh nhân theo tên, mã, hoặc số điện thoại";
            txtSearch.Size = new Size(440, 30);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 74);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 0, 0, 10);
            panel3.Size = new Size(892, 86);
            panel3.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(panel6, 0, 0);
            tableLayoutPanel2.Controls.Add(panel7, 1, 0);
            tableLayoutPanel2.Controls.Add(panel8, 2, 0);
            tableLayoutPanel2.Controls.Add(panel9, 3, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(892, 76);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightSteelBlue;
            panel6.Controls.Add(tableLayoutPanel5);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(5);
            panel6.Size = new Size(217, 70);
            panel6.TabIndex = 0;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Controls.Add(label3, 0, 0);
            tableLayoutPanel5.Controls.Add(lbpatienttotal, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(5, 5);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel5.Size = new Size(207, 60);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(201, 36);
            label3.TabIndex = 0;
            label3.Text = "Tổng bệnh nhân";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbpatienttotal
            // 
            lbpatienttotal.AutoSize = true;
            lbpatienttotal.Dock = DockStyle.Fill;
            lbpatienttotal.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbpatienttotal.ForeColor = Color.Black;
            lbpatienttotal.Location = new Point(3, 36);
            lbpatienttotal.Name = "lbpatienttotal";
            lbpatienttotal.Size = new Size(201, 24);
            lbpatienttotal.TabIndex = 1;
            lbpatienttotal.Text = "label4";
            lbpatienttotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel7
            // 
            panel7.BackColor = Color.LightGoldenrodYellow;
            panel7.Controls.Add(tableLayoutPanel6);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(226, 3);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(5);
            panel7.Size = new Size(217, 70);
            panel7.TabIndex = 1;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel6.Controls.Add(label5, 0, 0);
            tableLayoutPanel6.Controls.Add(lbnewpatient, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(5, 5);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel6.Size = new Size(207, 60);
            tableLayoutPanel6.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(201, 36);
            label5.TabIndex = 0;
            label5.Text = "Bệnh nhân mới";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbnewpatient
            // 
            lbnewpatient.AutoSize = true;
            lbnewpatient.Dock = DockStyle.Fill;
            lbnewpatient.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbnewpatient.ForeColor = Color.Black;
            lbnewpatient.Location = new Point(3, 36);
            lbnewpatient.Name = "lbnewpatient";
            lbnewpatient.Size = new Size(201, 24);
            lbnewpatient.TabIndex = 1;
            lbnewpatient.Text = "label6";
            lbnewpatient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Thistle;
            panel8.Controls.Add(tableLayoutPanel7);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(449, 3);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(217, 70);
            panel8.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel7.Controls.Add(label7, 0, 0);
            tableLayoutPanel7.Controls.Add(lbrevisitpatient, 0, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(5, 5);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel7.Size = new Size(207, 60);
            tableLayoutPanel7.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(201, 36);
            label7.TabIndex = 0;
            label7.Text = "Bệnh nhân tái khám";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbrevisitpatient
            // 
            lbrevisitpatient.AutoSize = true;
            lbrevisitpatient.Dock = DockStyle.Fill;
            lbrevisitpatient.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbrevisitpatient.ForeColor = Color.Black;
            lbrevisitpatient.Location = new Point(3, 36);
            lbrevisitpatient.Name = "lbrevisitpatient";
            lbrevisitpatient.Size = new Size(201, 24);
            lbrevisitpatient.TabIndex = 1;
            lbrevisitpatient.Text = "label8";
            lbrevisitpatient.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.BackColor = Color.LightCyan;
            panel9.Controls.Add(tableLayoutPanel8);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(672, 3);
            panel9.Name = "panel9";
            panel9.Padding = new Padding(5);
            panel9.Size = new Size(217, 70);
            panel9.TabIndex = 3;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel8.Controls.Add(label9, 0, 0);
            tableLayoutPanel8.Controls.Add(lbappointment, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(5, 5);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel8.Size = new Size(207, 60);
            tableLayoutPanel8.TabIndex = 2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 0);
            label9.Name = "label9";
            label9.Size = new Size(201, 36);
            label9.TabIndex = 0;
            label9.Text = "Có lịch hẹn sắp tới";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbappointment
            // 
            lbappointment.AutoSize = true;
            lbappointment.Dock = DockStyle.Fill;
            lbappointment.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbappointment.ForeColor = Color.Black;
            lbappointment.Location = new Point(3, 36);
            lbappointment.Name = "lbappointment";
            lbappointment.Size = new Size(201, 24);
            lbappointment.TabIndex = 1;
            lbappointment.Text = "label10";
            lbappointment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 164F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Controls.Add(panel4, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(892, 65);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(label1, 0, 0);
            tableLayoutPanel4.Controls.Add(label2, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 62.7118645F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 37.2881355F));
            tableLayoutPanel4.Size = new Size(722, 59);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(716, 37);
            label1.TabIndex = 0;
            label1.Text = "Quản lý bệnh nhân";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 37);
            label2.Name = "label2";
            label2.Size = new Size(716, 22);
            label2.TabIndex = 1;
            label2.Text = "Quản lý hồ sơ và thông tin bệnh nhân";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(731, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(158, 59);
            panel4.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(button1);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(158, 59);
            panel5.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumBlue;
            button1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.GhostWhite;
            button1.Location = new Point(0, 13);
            button1.Name = "button1";
            button1.Size = new Size(155, 34);
            button1.TabIndex = 0;
            button1.Text = "+ Thêm bệnh nhân";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvPatientMana
            // 
            dgvPatientMana.BackgroundColor = Color.WhiteSmoke;
            dgvPatientMana.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatientMana.Dock = DockStyle.Fill;
            dgvPatientMana.Location = new Point(3, 212);
            dgvPatientMana.Name = "dgvPatientMana";
            dgvPatientMana.RowHeadersWidth = 51;
            dgvPatientMana.Size = new Size(892, 549);
            dgvPatientMana.TabIndex = 3;
            // 
            // PatientManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "PatientManagement";
            Size = new Size(928, 794);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            panel7.ResumeLayout(false);
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            panel8.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            panel9.ResumeLayout(false);
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPatientMana).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private Label label2;
        private Panel panel6;
        private Panel panel7;
        private Panel panel8;
        private Panel panel9;
        private Panel panel4;
        private Panel panel5;
        private Button button1;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label3;
        private Label lbpatienttotal;
        private TableLayoutPanel tableLayoutPanel6;
        private Label label5;
        private Label lbnewpatient;
        private TableLayoutPanel tableLayoutPanel7;
        private Label label7;
        private Label lbrevisitpatient;
        private TableLayoutPanel tableLayoutPanel8;
        private Label label9;
        private Label lbappointment;
        private TableLayoutPanel tableLayoutPanel9;
        private ComboBox cbGender;
        private ComboBox cbAge;
        private TextBox txtSearch;
        private DataGridView dgvPatientMana;
    }
}
