namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucRoomCard
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
            label2 = new Label();
            label3 = new Label();
            helpProvider1 = new HelpProvider();
            panel1 = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            button2 = new Button();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(53, 28);
            label1.TabIndex = 0;
            label1.Text = "P.101";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 40);
            label2.Name = "label2";
            label2.Size = new Size(135, 20);
            label2.TabIndex = 1;
            label2.Text = "BS. Nguyễn Thị Lan";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 60);
            label3.Name = "label3";
            label3.Size = new Size(132, 20);
            label3.TabIndex = 2;
            label3.Text = "Sáng (7:00 - 12:00)";
            label3.UseWaitCursor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 255, 192);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(17, 92);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 125);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkGreen;
            label4.Location = new Point(17, 10);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 0;
            label4.Text = "Bệnh nhân hiện tại";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 40);
            label5.Name = "label5";
            label5.Size = new Size(143, 28);
            label5.TabIndex = 1;
            label5.Text = "Trần Văn Minh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 78);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 2;
            label6.Text = "STT: A015";
            // 
            // button1
            // 
            button1.BackColor = Color.LightCyan;
            button1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.RoyalBlue;
            button1.Location = new Point(64, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "Nội Khoa";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightCyan;
            button2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.RoyalBlue;
            button2.Location = new Point(293, 43);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Chờ bác sĩ";
            button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkOrange;
            label7.Location = new Point(34, 229);
            label7.Name = "label7";
            label7.Size = new Size(24, 28);
            label7.TabIndex = 4;
            label7.Text = "5";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkGreen;
            label8.Location = new Point(134, 229);
            label8.Name = "label8";
            label8.Size = new Size(24, 28);
            label8.TabIndex = 5;
            label8.Text = "8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(14, 257);
            label9.Name = "label9";
            label9.Size = new Size(64, 17);
            label9.TabIndex = 6;
            label9.Text = "Đang chờ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(108, 257);
            label10.Name = "label10";
            label10.Size = new Size(75, 17);
            label10.TabIndex = 7;
            label10.Text = "Hoàn thành";
            // 
            // ucRoomCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucRoomCard";
            Size = new Size(449, 296);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private HelpProvider helpProvider1;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button button1;
        private Button button2;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}
