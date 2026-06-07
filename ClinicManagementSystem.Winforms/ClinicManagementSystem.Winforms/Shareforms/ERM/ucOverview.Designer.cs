namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucOverview
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlPersonalInfo = new Panel();
            label1 = new Label();
            lblNumphone = new Label();
            lblemail = new Label();
            lbladdress = new Label();
            lblBHYT = new Label();
            pnlEmergency = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            pnlPersonalInfo.SuspendLayout();
            pnlEmergency.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(pnlPersonalInfo, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlEmergency, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1505, 664);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlPersonalInfo
            // 
            pnlPersonalInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlPersonalInfo.Controls.Add(lblBHYT);
            pnlPersonalInfo.Controls.Add(lbladdress);
            pnlPersonalInfo.Controls.Add(lblemail);
            pnlPersonalInfo.Controls.Add(lblNumphone);
            pnlPersonalInfo.Controls.Add(label1);
            pnlPersonalInfo.Dock = DockStyle.Fill;
            pnlPersonalInfo.Location = new Point(3, 3);
            pnlPersonalInfo.Name = "pnlPersonalInfo";
            pnlPersonalInfo.Size = new Size(746, 326);
            pnlPersonalInfo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(23, 21);
            label1.Name = "label1";
            label1.Size = new Size(215, 28);
            label1.TabIndex = 0;
            label1.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // lblNumphone
            // 
            lblNumphone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNumphone.Image = Properties.Resources.Screenshot_2026_06_07_163352;
            lblNumphone.ImageAlign = ContentAlignment.MiddleLeft;
            lblNumphone.Location = new Point(23, 61);
            lblNumphone.Name = "lblNumphone";
            lblNumphone.Size = new Size(464, 62);
            lblNumphone.TabIndex = 1;
            lblNumphone.Text = "0901234567";
            lblNumphone.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblemail
            // 
            lblemail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblemail.Image = Properties.Resources.Screenshot_2026_06_07_163707;
            lblemail.ImageAlign = ContentAlignment.MiddleLeft;
            lblemail.Location = new Point(36, 123);
            lblemail.Name = "lblemail";
            lblemail.Size = new Size(451, 62);
            lblemail.TabIndex = 2;
            lblemail.Text = "nguyenvana@email.com";
            lblemail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbladdress
            // 
            lbladdress.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbladdress.Image = Properties.Resources.Screenshot_2026_06_07_164022;
            lbladdress.ImageAlign = ContentAlignment.MiddleLeft;
            lbladdress.Location = new Point(36, 185);
            lbladdress.Name = "lbladdress";
            lbladdress.Size = new Size(534, 62);
            lbladdress.TabIndex = 3;
            lbladdress.Text = "123 Đường Lê Lợi, Quận 1, TP.HCM";
            lbladdress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBHYT
            // 
            lblBHYT.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBHYT.Image = Properties.Resources.Screenshot_2026_06_07_164139;
            lblBHYT.ImageAlign = ContentAlignment.MiddleLeft;
            lblBHYT.Location = new Point(36, 247);
            lblBHYT.Name = "lblBHYT";
            lblBHYT.Size = new Size(451, 62);
            lblBHYT.TabIndex = 4;
            lblBHYT.Text = "DN47580012345678";
            lblBHYT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlEmergency
            // 
            pnlEmergency.BackColor = Color.MistyRose;
            pnlEmergency.Controls.Add(label3);
            pnlEmergency.Controls.Add(label2);
            pnlEmergency.Dock = DockStyle.Fill;
            pnlEmergency.Location = new Point(755, 3);
            pnlEmergency.Name = "pnlEmergency";
            pnlEmergency.Size = new Size(747, 326);
            pnlEmergency.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(32, 22);
            label2.Name = "label2";
            label2.Size = new Size(188, 28);
            label2.TabIndex = 5;
            label2.Text = "LIÊN HỆ KHẨN CẤP";
            // 
            // label3
            // 
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Image = Properties.Resources.Screenshot_2026_06_07_163352;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(32, 79);
            label3.Name = "label3";
            label3.Size = new Size(464, 62);
            label3.TabIndex = 5;
            label3.Text = "0901234568";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LemonChiffon;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 335);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 326);
            panel1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(24, 23);
            label4.Name = "label4";
            label4.Size = new Size(82, 28);
            label4.TabIndex = 6;
            label4.Text = "DỊ ỨNG";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Yellow;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(24, 72);
            label5.Name = "label5";
            label5.Size = new Size(93, 140);
            label5.TabIndex = 5;
            label5.Text = "Penicillin\r\n\r\nHải sản\r\n\r\nPhấn hoa";
            // 
            // ucOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ucOverview";
            Size = new Size(1505, 664);
            tableLayoutPanel1.ResumeLayout(false);
            pnlPersonalInfo.ResumeLayout(false);
            pnlPersonalInfo.PerformLayout();
            pnlEmergency.ResumeLayout(false);
            pnlEmergency.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlPersonalInfo;
        private Label label1;
        private Label lbladdress;
        private Label lblemail;
        private Label lblNumphone;
        private Label lblBHYT;
        private Panel pnlEmergency;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Label label5;
        private Label label4;
    }
}
