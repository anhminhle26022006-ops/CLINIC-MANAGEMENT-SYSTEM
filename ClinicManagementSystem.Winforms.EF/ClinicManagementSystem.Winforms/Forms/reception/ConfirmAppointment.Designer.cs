namespace ClinicManagementSystem.Winforms.Forms.reception
{
    partial class ConfirmAppointment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmAppointment));
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            panel4 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            lbPatient = new Label();
            label5 = new Label();
            lbDepartment = new Label();
            label7 = new Label();
            lnDoctor = new Label();
            label9 = new Label();
            lbRoom = new Label();
            label11 = new Label();
            lbTime = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(568, 493);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(20, 20);
            panel2.Margin = new Padding(10);
            panel2.Name = "panel2";
            panel2.Size = new Size(528, 453);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel4, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 81F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 43F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(528, 453);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(522, 75);
            panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(198, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 75);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 81);
            label1.Name = "label1";
            label1.Size = new Size(522, 50);
            label1.TabIndex = 1;
            label1.Text = "Đặt lịch thành công !";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 131);
            label2.Name = "label2";
            label2.Size = new Size(522, 43);
            label2.TabIndex = 2;
            label2.Text = "Lịch khám đã được tạo và gửi thông báo cho bệnh nhân";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightCyan;
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 177);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(40, 15, 40, 15);
            panel4.Size = new Size(522, 273);
            panel4.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(lbTime, 1, 4);
            tableLayoutPanel2.Controls.Add(label11, 0, 4);
            tableLayoutPanel2.Controls.Add(lbRoom, 1, 3);
            tableLayoutPanel2.Controls.Add(label9, 0, 3);
            tableLayoutPanel2.Controls.Add(lnDoctor, 1, 2);
            tableLayoutPanel2.Controls.Add(label7, 0, 2);
            tableLayoutPanel2.Controls.Add(lbDepartment, 1, 1);
            tableLayoutPanel2.Controls.Add(label5, 0, 1);
            tableLayoutPanel2.Controls.Add(lbPatient, 1, 0);
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(40, 15);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Size = new Size(442, 243);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(215, 48);
            label3.TabIndex = 0;
            label3.Text = "Bệnh nhân:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbPatient
            // 
            lbPatient.AutoSize = true;
            lbPatient.Dock = DockStyle.Fill;
            lbPatient.Location = new Point(224, 0);
            lbPatient.Name = "lbPatient";
            lbPatient.Size = new Size(215, 48);
            lbPatient.TabIndex = 1;
            lbPatient.Text = "label4";
            lbPatient.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 48);
            label5.Name = "label5";
            label5.Size = new Size(215, 48);
            label5.TabIndex = 2;
            label5.Text = "Khoa:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbDepartment
            // 
            lbDepartment.AutoSize = true;
            lbDepartment.Dock = DockStyle.Fill;
            lbDepartment.Location = new Point(224, 48);
            lbDepartment.Name = "lbDepartment";
            lbDepartment.Size = new Size(215, 48);
            lbDepartment.TabIndex = 3;
            lbDepartment.Text = "label6";
            lbDepartment.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 96);
            label7.Name = "label7";
            label7.Size = new Size(215, 48);
            label7.TabIndex = 4;
            label7.Text = "Bác sĩ:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lnDoctor
            // 
            lnDoctor.AutoSize = true;
            lnDoctor.Dock = DockStyle.Fill;
            lnDoctor.Location = new Point(224, 96);
            lnDoctor.Name = "lnDoctor";
            lnDoctor.Size = new Size(215, 48);
            lnDoctor.TabIndex = 5;
            lnDoctor.Text = "label8";
            lnDoctor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Location = new Point(3, 144);
            label9.Name = "label9";
            label9.Size = new Size(215, 48);
            label9.TabIndex = 6;
            label9.Text = "Phòng:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbRoom
            // 
            lbRoom.AutoSize = true;
            lbRoom.Dock = DockStyle.Fill;
            lbRoom.Location = new Point(224, 144);
            lbRoom.Name = "lbRoom";
            lbRoom.Size = new Size(215, 48);
            lbRoom.TabIndex = 7;
            lbRoom.Text = "label10";
            lbRoom.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Dock = DockStyle.Fill;
            label11.Location = new Point(3, 192);
            label11.Name = "label11";
            label11.Size = new Size(215, 51);
            label11.TabIndex = 8;
            label11.Text = "Thời gian:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Dock = DockStyle.Fill;
            lbTime.Location = new Point(224, 192);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(215, 51);
            lbTime.TabIndex = 9;
            lbTime.Text = "label12";
            lbTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // ConfirmAppointment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(568, 493);
            Controls.Add(panel1);
            Name = "ConfirmAppointment";
            Text = "ConfirmAppointment";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lbTime;
        private Label label11;
        private Label lbRoom;
        private Label label9;
        private Label lnDoctor;
        private Label label7;
        private Label lbDepartment;
        private Label label5;
        private Label lbPatient;
        private Label label3;
    }
}