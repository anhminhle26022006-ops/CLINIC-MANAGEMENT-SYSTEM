using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseVitalSigns
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
            panel1 = new Panel();
            btnSaveAndSync = new Button();
            btnCancel = new Button();
            textBox9 = new TextBox();
            label20 = new Label();
            label19 = new Label();
            panel3 = new Panel();
            lblBMI = new Label();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            lstSTT = new ListBox();
            lstSex = new ListBox();
            lstAge = new ListBox();
            lstName = new ListBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            panel2 = new Panel();
            label18 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            label31 = new Label();
            label32 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 0);
            label1.Name = "label1";
            label1.Size = new Size(416, 46);
            label1.TabIndex = 0;
            label1.Text = "Ghi nhận chỉ số sinh hiệu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(13, 46);
            label2.Name = "label2";
            label2.Size = new Size(338, 25);
            label2.TabIndex = 1;
            label2.Text = "Đo và lưu chỉ số sống vào hồ sơ bệnh án";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnSaveAndSync);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(textBox9);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(label19);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(textBox8);
            panel1.Controls.Add(textBox7);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(lstSTT);
            panel1.Controls.Add(lstSex);
            panel1.Controls.Add(lstAge);
            panel1.Controls.Add(lstName);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(textBox6);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label3);
            panel1.ForeColor = SystemColors.ControlText;
            panel1.Location = new Point(13, 83);
            panel1.Name = "panel1";
            panel1.Size = new Size(813, 901);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // btnSaveAndSync
            // 
            btnSaveAndSync.BackColor = Color.LimeGreen;
            btnSaveAndSync.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAndSync.ForeColor = Color.White;
            btnSaveAndSync.Location = new Point(529, 816);
            btnSaveAndSync.Name = "btnSaveAndSync";
            btnSaveAndSync.Size = new Size(246, 49);
            btnSaveAndSync.TabIndex = 43;
            btnSaveAndSync.Text = "Lưu và Đồng bộ với Bác sĩ";
            btnSaveAndSync.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(410, 816);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(109, 49);
            btnCancel.TabIndex = 42;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(17, 719);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(758, 27);
            textBox9.TabIndex = 41;
            textBox9.SizeChanged += textBox9_SizeChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(17, 681);
            label20.Name = "label20";
            label20.Size = new Size(70, 23);
            label20.TabIndex = 40;
            label20.Text = "Ghi chú";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.PaleGreen;
            label19.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.DarkGreen;
            label19.Location = new Point(643, 623);
            label19.Name = "label19";
            label19.Size = new Size(131, 28);
            label19.TabIndex = 39;
            label19.Text = "Bình thường";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblBMI);
            panel3.Location = new Point(17, 614);
            panel3.Name = "panel3";
            panel3.Size = new Size(609, 41);
            panel3.TabIndex = 38;
            // 
            // lblBMI
            // 
            lblBMI.AutoSize = true;
            lblBMI.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBMI.Location = new Point(12, 9);
            lblBMI.Name = "lblBMI";
            lblBMI.Size = new Size(42, 23);
            lblBMI.TabIndex = 37;
            lblBMI.Text = "BMI";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(433, 535);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(321, 27);
            textBox8.TabIndex = 35;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(17, 526);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(321, 27);
            textBox7.TabIndex = 34;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(433, 453);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(321, 27);
            textBox4.TabIndex = 33;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(17, 453);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(321, 27);
            textBox3.TabIndex = 32;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(433, 376);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(321, 27);
            textBox2.TabIndex = 31;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 376);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(321, 27);
            textBox1.TabIndex = 30;
            // 
            // lstSTT
            // 
            lstSTT.FormattingEnabled = true;
            lstSTT.Location = new Point(717, 163);
            lstSTT.Name = "lstSTT";
            lstSTT.Size = new Size(76, 24);
            lstSTT.TabIndex = 29;
            // 
            // lstSex
            // 
            lstSex.FormattingEnabled = true;
            lstSex.Location = new Point(409, 163);
            lstSex.Name = "lstSex";
            lstSex.Size = new Size(76, 24);
            lstSex.TabIndex = 28;
            // 
            // lstAge
            // 
            lstAge.FormattingEnabled = true;
            lstAge.Location = new Point(72, 162);
            lstAge.Name = "lstAge";
            lstAge.Size = new Size(76, 24);
            lstAge.TabIndex = 27;
            // 
            // lstName
            // 
            lstName.FormattingEnabled = true;
            lstName.Location = new Point(154, 113);
            lstName.Name = "lstName";
            lstName.Size = new Size(277, 24);
            lstName.TabIndex = 26;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Red;
            label17.Location = new Point(17, 572);
            label17.Name = "label17";
            label17.Size = new Size(164, 23);
            label17.TabIndex = 25;
            label17.Text = "BMI (Tự động tính)";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(433, 494);
            label16.Name = "label16";
            label16.Size = new Size(123, 23);
            label16.TabIndex = 24;
            label16.Text = "Cân nặng (kg)";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(17, 494);
            label15.Name = "label15";
            label15.Size = new Size(128, 23);
            label15.TabIndex = 23;
            label15.Text = "Chiều cao (cm)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(433, 422);
            label14.Name = "label14";
            label14.Size = new Size(86, 23);
            label14.TabIndex = 22;
            label14.Text = "SpO2 (%)";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(17, 422);
            label13.Name = "label13";
            label13.Size = new Size(169, 23);
            label13.TabIndex = 21;
            label13.Text = "Nhịp thở (lần/phút)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(433, 341);
            label12.Name = "label12";
            label12.Size = new Size(137, 23);
            label12.TabIndex = 20;
            label12.Text = "Nhịp tim (bpm)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(17, 341);
            label11.Name = "label11";
            label11.Size = new Size(114, 23);
            label11.TabIndex = 19;
            label11.Text = "Nhiệt độ (°C)";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(433, 297);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(321, 27);
            textBox6.TabIndex = 18;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(17, 297);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(321, 27);
            textBox5.TabIndex = 17;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(433, 260);
            label10.Name = "label10";
            label10.Size = new Size(106, 23);
            label10.TabIndex = 16;
            label10.Text = "Tâm trương";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(17, 260);
            label9.Name = "label9";
            label9.Size = new Size(81, 23);
            label9.TabIndex = 15;
            label9.Text = "Tâm thu ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(17, 221);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(191, 25);
            label8.TabIndex = 14;
            label8.Text = "Huyết áp (mmHg)     ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(666, 163);
            label7.Name = "label7";
            label7.Size = new Size(45, 23);
            label7.TabIndex = 9;
            label7.Text = "STT:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(318, 163);
            label6.Name = "label6";
            label6.Size = new Size(85, 23);
            label6.TabIndex = 8;
            label6.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 163);
            label5.Name = "label5";
            label5.Size = new Size(49, 23);
            label5.TabIndex = 7;
            label5.Text = "Tuổi:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 114);
            label4.Name = "label4";
            label4.Size = new Size(131, 23);
            label4.TabIndex = 6;
            label4.Text = "Tên bệnh nhân:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(17, 55);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(758, 28);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "--Chọn bệnh nhân--";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(113, 28);
            label3.TabIndex = 4;
            label3.Text = "Bệnh nhân";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label32);
            panel2.Controls.Add(label31);
            panel2.Controls.Add(label30);
            panel2.Controls.Add(label29);
            panel2.Controls.Add(label28);
            panel2.Controls.Add(label27);
            panel2.Controls.Add(label26);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(label18);
            panel2.Location = new Point(848, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(490, 445);
            panel2.TabIndex = 3;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(13, 9);
            label18.Name = "label18";
            label18.Size = new Size(193, 28);
            label18.TabIndex = 5;
            label18.Text = "Chỉ số bình thường";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(50, 81);
            label21.Name = "label21";
            label21.Size = new Size(88, 23);
            label21.TabIndex = 7;
            label21.Text = "Huyết áp:";
            label21.Click += label21_Click;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(50, 136);
            label22.Name = "label22";
            label22.Size = new Size(85, 23);
            label22.TabIndex = 8;
            label22.Text = "Nhiệt độ:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(51, 200);
            label23.Name = "label23";
            label23.Size = new Size(87, 23);
            label23.TabIndex = 9;
            label23.Text = "Nhịp tim:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(48, 260);
            label24.Name = "label24";
            label24.Size = new Size(87, 23);
            label24.TabIndex = 10;
            label24.Text = "Nhịp thở:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.Location = new Point(51, 324);
            label25.Name = "label25";
            label25.Size = new Size(59, 23);
            label25.TabIndex = 11;
            label25.Text = "SpO2:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.Location = new Point(51, 390);
            label26.Name = "label26";
            label26.Size = new Size(47, 23);
            label26.TabIndex = 12;
            label26.Text = "BMI:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(282, 83);
            label27.Name = "label27";
            label27.Size = new Size(157, 20);
            label27.TabIndex = 13;
            label27.Text = "90-120 / 60-80 mmHg";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(347, 136);
            label28.Name = "label28";
            label28.Size = new Size(92, 20);
            label28.TabIndex = 14;
            label28.Text = "36.1 - 37.2°C";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(341, 200);
            label29.Name = "label29";
            label29.Size = new Size(98, 20);
            label29.TabIndex = 15;
            label29.Text = "60 - 100 bpm";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(324, 260);
            label30.Name = "label30";
            label30.Size = new Size(115, 20);
            label30.TabIndex = 16;
            label30.Text = "12 - 20 lần/phút";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(388, 324);
            label31.Name = "label31";
            label31.Size = new Size(51, 20);
            label31.TabIndex = 17;
            label31.Text = "≥ 95%";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(362, 390);
            label32.Name = "label32";
            label32.Size = new Size(77, 20);
            label32.TabIndex = 18;
            label32.Click += label32_Click;
            // 
            // ucNurseVitalSigns
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ucNurseVitalSigns";
            Size = new Size(1427, 999);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Panel panel1;
        private ComboBox comboBox1;
        private Label label3;
        private Panel panel2;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label8;
        private Label label12;
        private Label label11;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label10;
        private Label label9;
        private ListBox lstName;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private ListBox lstSTT;
        private ListBox lstSex;
        private ListBox lstAge;
        private Panel panel3;
        private Label lblBMI;
        private Label label19;
        private TextBox textBox9;
        private Label label20;
        private Button btnSaveAndSync;
        private Button btnCancel;
        private Label label21;
        private Label label18;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
    }
}
