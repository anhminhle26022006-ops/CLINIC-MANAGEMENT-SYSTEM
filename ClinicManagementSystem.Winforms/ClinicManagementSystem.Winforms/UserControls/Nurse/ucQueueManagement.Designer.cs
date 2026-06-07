namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucQueueManagement
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(18, 18);
            panel1.Name = "panel1";
            panel1.Size = new Size(1338, 49);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Silver;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(283, 42);
            button1.TabIndex = 0;
            button1.Text = "Tất cả khoa";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Silver;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(292, 4);
            button2.Name = "button2";
            button2.Size = new Size(286, 42);
            button2.TabIndex = 1;
            button2.Text = "Nội khoa";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Silver;
            button3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.Location = new Point(584, 4);
            button3.Name = "button3";
            button3.Size = new Size(264, 42);
            button3.TabIndex = 1;
            button3.Text = "Ngoại khoa";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Silver;
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(854, 4);
            button4.Name = "button4";
            button4.Size = new Size(258, 42);
            button4.TabIndex = 1;
            button4.Text = "Tim mạch";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Silver;
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(1118, 3);
            button5.Name = "button5";
            button5.Size = new Size(217, 42);
            button5.TabIndex = 1;
            button5.Text = "Nhi khoa";
            button5.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(18, 86);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1338, 144);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.PeachPuff;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(18, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(390, 144);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightCyan;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(492, 86);
            panel3.Name = "panel3";
            panel3.Size = new Size(390, 144);
            panel3.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(192, 255, 192);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(966, 86);
            panel4.Name = "panel4";
            panel4.Size = new Size(390, 144);
            panel4.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.OrangeRed;
            label1.Location = new Point(3, 38);
            label1.Name = "label1";
            label1.Size = new Size(87, 23);
            label1.TabIndex = 4;
            label1.Text = "Đang chờ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 5;
            label2.Text = "Đang khám";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(3, 38);
            label3.Name = "label3";
            label3.Size = new Size(177, 23);
            label3.TabIndex = 5;
            label3.Text = "Hoàn thành hôm nay";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.OrangeRed;
            label4.Location = new Point(3, 70);
            label4.Name = "label4";
            label4.Size = new Size(60, 46);
            label4.TabIndex = 4;
            label4.Text = "10";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.RoyalBlue;
            label5.Location = new Point(3, 70);
            label5.Name = "label5";
            label5.Size = new Size(40, 46);
            label5.TabIndex = 5;
            label5.Text = "3";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DarkGreen;
            label6.Location = new Point(3, 70);
            label6.Name = "label6";
            label6.Size = new Size(60, 46);
            label6.TabIndex = 5;
            label6.Text = "27";
            // 
            // ucQueueManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Name = "ucQueueManagement";
            Size = new Size(1371, 824);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label4;
        private Label label1;
        private Label label5;
        private Label label2;
        private Label label6;
        private Label label3;
    }
}
