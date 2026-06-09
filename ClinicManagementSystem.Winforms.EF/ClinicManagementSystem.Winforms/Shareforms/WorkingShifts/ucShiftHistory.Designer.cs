namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    partial class ucShiftHistory
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
            label1 = new Label();
            lblRequestHour = new Label();
            lblStatus = new Label();
            panel1 = new Panel();
            lbltimewanttochange = new Label();
            lblShiftWant = new Label();
            label2 = new Label();
            panel2 = new Panel();
            lbltimereturn = new Label();
            lblShiftReturn = new Label();
            label3 = new Label();
            label4 = new Label();
            lblreason = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 13);
            label1.Name = "label1";
            label1.Size = new Size(68, 28);
            label1.TabIndex = 0;
            label1.Text = "Đổi ca";
            // 
            // lblRequestHour
            // 
            lblRequestHour.AutoSize = true;
            lblRequestHour.BackColor = Color.White;
            lblRequestHour.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequestHour.Location = new Point(20, 13);
            lblRequestHour.Name = "lblRequestHour";
            lblRequestHour.Size = new Size(288, 28);
            lblRequestHour.TabIndex = 1;
            lblRequestHour.Text = "Yêu cầu lúc: 14:00:00 28/5/2026";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.LemonChiffon;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.DarkGoldenrod;
            lblStatus.Location = new Point(1020, 13);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(102, 28);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Chờ duyệt";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Pink;
            panel1.Controls.Add(lbltimewanttochange);
            panel1.Controls.Add(lblShiftWant);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(504, 158);
            panel1.TabIndex = 3;
            // 
            // lbltimewanttochange
            // 
            lbltimewanttochange.AutoSize = true;
            lbltimewanttochange.BackColor = Color.Pink;
            lbltimewanttochange.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbltimewanttochange.Location = new Point(17, 95);
            lbltimewanttochange.Name = "lbltimewanttochange";
            lbltimewanttochange.Size = new Size(226, 28);
            lbltimewanttochange.TabIndex = 4;
            lbltimewanttochange.Text = "4/6/2026 • 08:00 - 16:00";
            // 
            // lblShiftWant
            // 
            lblShiftWant.AutoSize = true;
            lblShiftWant.BackColor = Color.Pink;
            lblShiftWant.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShiftWant.Location = new Point(17, 50);
            lblShiftWant.Name = "lblShiftWant";
            lblShiftWant.Size = new Size(107, 28);
            lblShiftWant.TabIndex = 5;
            lblShiftWant.Text = "CA-LT-004";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Pink;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(17, 10);
            label2.Name = "label2";
            label2.Size = new Size(134, 28);
            label2.TabIndex = 4;
            label2.Text = "Ca muốn đổi:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightCyan;
            panel2.Controls.Add(lbltimereturn);
            panel2.Controls.Add(lblShiftReturn);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(585, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(537, 158);
            panel2.TabIndex = 4;
            // 
            // lbltimereturn
            // 
            lbltimereturn.AutoSize = true;
            lbltimereturn.BackColor = Color.LightCyan;
            lbltimereturn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbltimereturn.Location = new Point(22, 97);
            lbltimereturn.Name = "lbltimereturn";
            lbltimereturn.Size = new Size(226, 28);
            lbltimereturn.TabIndex = 6;
            lbltimereturn.Text = "4/6/2026 • 14:00 - 22:00";
            // 
            // lblShiftReturn
            // 
            lblShiftReturn.AutoSize = true;
            lblShiftReturn.BackColor = Color.LightCyan;
            lblShiftReturn.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblShiftReturn.Location = new Point(22, 52);
            lblShiftReturn.Name = "lblShiftReturn";
            lblShiftReturn.Size = new Size(106, 28);
            lblShiftReturn.TabIndex = 6;
            lblShiftReturn.Text = "CA-LT-005";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightCyan;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(22, 12);
            label3.Name = "label3";
            label3.Size = new Size(118, 28);
            label3.TabIndex = 6;
            label3.Text = "Ca nhận về:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 28);
            label4.TabIndex = 5;
            label4.Text = "Lý do:";
            // 
            // lblreason
            // 
            lblreason.BackColor = Color.White;
            lblreason.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblreason.Location = new Point(20, 42);
            lblreason.Name = "lblreason";
            lblreason.Size = new Size(1116, 88);
            lblreason.TabIndex = 6;
            lblreason.Text = "Có việc gia đình cần giải quyết vào buổi sáng ngày 04/06. Con tôi có lễ tốt nghiệp ở trường và tôi rất muốn tham dự.";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(panel5, 0, 2);
            tableLayoutPanel1.Controls.Add(panel6, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.9629631F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.9629631F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 44.4444466F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 29.6296272F));
            tableLayoutPanel1.Size = new Size(1164, 494);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Controls.Add(lblStatus);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1158, 58);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblRequestHour);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 67);
            panel4.Name = "panel4";
            panel4.Size = new Size(1158, 58);
            panel4.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(panel2);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 131);
            panel5.Name = "panel5";
            panel5.Size = new Size(1158, 213);
            panel5.TabIndex = 2;
            // 
            // panel6
            // 
            panel6.Controls.Add(label4);
            panel6.Controls.Add(lblreason);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 350);
            panel6.Name = "panel6";
            panel6.Size = new Size(1158, 141);
            panel6.TabIndex = 3;
            // 
            // ucShiftHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            Name = "ucShiftHistory";
            Size = new Size(1164, 494);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lblRequestHour;
        private Label lblStatus;
        private Panel panel1;
        private Label lbltimewanttochange;
        private Label lblShiftWant;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Label lbltimereturn;
        private Label lblShiftReturn;
        private Label label4;
        private Label lblreason;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
    }
}
