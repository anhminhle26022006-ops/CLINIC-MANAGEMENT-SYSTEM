namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseOverview
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
        ///             private Label lblRoomsCount;
        private Label lblWaitingVitalCount;
        private Label lblCompletedCount;
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            lblWaitingVitalCount = new Label();
            panel2 = new Panel();
            label3 = new Label();
            lblCompletedCount = new Label();
            label2 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label5 = new Label();
            lblAlertCount = new Label();
            panel4 = new Panel();
            label7 = new Label();
            lblRoomsCount = new Label();
            roundedPanel1 = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            button2 = new Button();
            button1 = new Button();
            label12 = new Label();
            panel5 = new Panel();
            label14 = new Label();
            label13 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            panel6 = new Panel();
            button4 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label18 = new Label();
            panel7 = new Panel();
            panel9 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label20 = new Label();
            panel8 = new Panel();
            button3 = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label19 = new Label();
            panel10 = new Panel();
            panel13 = new Panel();
            label28 = new Label();
            label26 = new Label();
            panel14 = new Panel();
            label29 = new Label();
            label27 = new Label();
            panel12 = new Panel();
            label25 = new Label();
            label24 = new Label();
            panel11 = new Panel();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            roundedPanel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel13.SuspendLayout();
            panel14.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightCyan;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblWaitingVitalCount);
            panel1.Location = new Point(48, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 202);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(3, 133);
            label1.Name = "label1";
            label1.Size = new Size(144, 23);
            label1.TabIndex = 3;
            label1.Text = "Chờ đo sinh hiệu";
            // 
            // lblWaitingVitalCount
            // 
            lblWaitingVitalCount.AutoSize = true;
            lblWaitingVitalCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWaitingVitalCount.ForeColor = Color.RoyalBlue;
            lblWaitingVitalCount.Location = new Point(3, 87);
            lblWaitingVitalCount.Name = "lblWaitingVitalCount";
            lblWaitingVitalCount.Size = new Size(40, 46);
            lblWaitingVitalCount.TabIndex = 5;
            lblWaitingVitalCount.Text = "0";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 255, 192);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblCompletedCount);
            panel2.Location = new Point(443, 32);
            panel2.Name = "panel2";
            panel2.Size = new Size(370, 202);
            panel2.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(3, 133);
            label3.Name = "label3";
            label3.Size = new Size(177, 23);
            label3.TabIndex = 3;
            label3.Text = "Hoàn thành hôm nay";
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.AutoSize = true;
            lblCompletedCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompletedCount.ForeColor = Color.DarkGreen;
            lblCompletedCount.Location = new Point(3, 87);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(40, 46);
            lblCompletedCount.TabIndex = 5;
            lblCompletedCount.Text = "0";
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MistyRose;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(lblAlertCount);
            panel3.Location = new Point(1224, 32);
            panel3.Name = "panel3";
            panel3.Size = new Size(346, 202);
            panel3.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(3, 133);
            label5.Name = "label5";
            label5.Size = new Size(135, 23);
            label5.TabIndex = 3;
            label5.Text = "Cảnh báo chỉ số";
            // 
            // lblAlertCount
            // 
            lblAlertCount.AutoSize = true;
            lblAlertCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAlertCount.ForeColor = Color.Red;
            lblAlertCount.Location = new Point(3, 87);
            lblAlertCount.Name = "lblAlertCount";
            lblAlertCount.Size = new Size(40, 46);
            lblAlertCount.TabIndex = 5;
            lblAlertCount.Text = "0";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(192, 192, 255);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(lblRoomsCount);
            panel4.Location = new Point(834, 32);
            panel4.Name = "panel4";
            panel4.Size = new Size(371, 202);
            panel4.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Indigo;
            label7.Location = new Point(3, 133);
            label7.Name = "label7";
            label7.Size = new Size(162, 23);
            label7.TabIndex = 3;
            label7.Text = "Phòng đang hỗ trợ";
            // 
            // lblRoomsCount
            // 
            lblRoomsCount.AutoSize = true;
            lblRoomsCount.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoomsCount.ForeColor = Color.Indigo;
            lblRoomsCount.Location = new Point(3, 87);
            lblRoomsCount.Name = "lblRoomsCount";
            lblRoomsCount.Size = new Size(40, 46);
            lblRoomsCount.TabIndex = 5;
            lblRoomsCount.Text = "0";
            // 
            // roundedPanel1
            // 
            roundedPanel1.BorderColor = Color.FromArgb(229, 231, 235);
            roundedPanel1.BorderWidth = 1;
            roundedPanel1.Controls.Add(label17);
            roundedPanel1.Controls.Add(label16);
            roundedPanel1.Controls.Add(label15);
            roundedPanel1.Controls.Add(button2);
            roundedPanel1.Controls.Add(button1);
            roundedPanel1.Controls.Add(label12);
            roundedPanel1.Controls.Add(panel5);
            roundedPanel1.Controls.Add(label9);
            roundedPanel1.CornerRadius = 8;
            roundedPanel1.FillColor = Color.White;
            roundedPanel1.Location = new Point(48, 272);
            roundedPanel1.Name = "roundedPanel1";
            roundedPanel1.Size = new Size(1522, 356);
            roundedPanel1.TabIndex = 7;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(786, 324);
            label17.Name = "label17";
            label17.Size = new Size(130, 20);
            label17.TabIndex = 7;
            label17.Text = "ca trong tuần này";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.Teal;
            label16.Location = new Point(756, 324);
            label16.Name = "label16";
            label16.Size = new Size(21, 20);
            label16.TabIndex = 6;
            label16.Text = "...";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(714, 324);
            label15.Name = "label15";
            label15.Size = new Size(36, 20);
            label15.TabIndex = 5;
            label15.Text = "Còn";
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(789, 257);
            button2.Name = "button2";
            button2.Size = new Size(696, 48);
            button2.TabIndex = 4;
            button2.Text = "Đổi ca";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Azure;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Teal;
            button1.Location = new Point(25, 257);
            button1.Name = "button1";
            button1.Size = new Size(740, 48);
            button1.TabIndex = 3;
            button1.Text = "Xem lịch tuần";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.PaleGreen;
            label12.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.ForestGreen;
            label12.Location = new Point(1394, 19);
            label12.Name = "label12";
            label12.Size = new Size(91, 23);
            label12.TabIndex = 2;
            label12.Text = "Đang trực";
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightCyan;
            panel5.Controls.Add(label14);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label10);
            panel5.ForeColor = SystemColors.ControlText;
            panel5.Location = new Point(25, 73);
            panel5.Name = "panel5";
            panel5.Size = new Size(1460, 150);
            panel5.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.Teal;
            label14.Location = new Point(1021, 97);
            label14.Name = "label14";
            label14.Size = new Size(50, 23);
            label14.TabIndex = 3;
            label14.Text = "Khoa";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Teal;
            label13.Location = new Point(20, 97);
            label13.Name = "label13";
            label13.Size = new Size(61, 23);
            label13.TabIndex = 2;
            label13.Text = "Phòng";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Teal;
            label11.Location = new Point(102, 24);
            label11.Name = "label11";
            label11.Size = new Size(94, 23);
            label11.TabIndex = 1;
            label11.Text = "(Hôm nay)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Teal;
            label10.Location = new Point(20, 16);
            label10.Name = "label10";
            label10.Size = new Size(76, 31);
            label10.TabIndex = 0;
            label10.Text = "Trống";
            label10.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Teal;
            label9.Location = new Point(25, 19);
            label9.Name = "label9";
            label9.Size = new Size(288, 38);
            label9.TabIndex = 0;
            label9.Text = "Ca làm việc hôm nay";
            label9.Click += label9_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(button4);
            panel6.Controls.Add(flowLayoutPanel1);
            panel6.Controls.Add(label18);
            panel6.Location = new Point(48, 649);
            panel6.Name = "panel6";
            panel6.Size = new Size(1522, 343);
            panel6.TabIndex = 8;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.RoyalBlue;
            button4.Location = new Point(1355, 19);
            button4.Name = "button4";
            button4.Size = new Size(130, 33);
            button4.TabIndex = 5;
            button4.Text = "Xem chi tiết";
            button4.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(45, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1440, 241);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.Black;
            label18.Location = new Point(45, 21);
            label18.Name = "label18";
            label18.Size = new Size(283, 31);
            label18.TabIndex = 1;
            label18.Text = "Phòng khám đang hỗ trợ";
            // 
            // panel7
            // 
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(panel8);
            panel7.Location = new Point(48, 1014);
            panel7.Name = "panel7";
            panel7.Size = new Size(1522, 344);
            panel7.TabIndex = 9;
            // 
            // panel9
            // 
            panel9.BackColor = Color.White;
            panel9.Controls.Add(flowLayoutPanel3);
            panel9.Controls.Add(label20);
            panel9.Location = new Point(798, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(724, 344);
            panel9.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Location = new Point(50, 72);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(637, 245);
            flowLayoutPanel3.TabIndex = 4;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(50, 17);
            label20.Name = "label20";
            label20.Size = new Size(309, 31);
            label20.TabIndex = 3;
            label20.Text = "Cảnh báo chỉ số bất thường";
            // 
            // panel8
            // 
            panel8.BackColor = Color.White;
            panel8.Controls.Add(button3);
            panel8.Controls.Add(flowLayoutPanel2);
            panel8.Controls.Add(label19);
            panel8.Location = new Point(0, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(724, 344);
            panel8.TabIndex = 0;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.RoyalBlue;
            button3.Location = new Point(552, 23);
            button3.Name = "button3";
            button3.Size = new Size(130, 33);
            button3.TabIndex = 4;
            button3.Text = "Đo sinh hiệu";
            button3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(45, 72);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(637, 245);
            flowLayoutPanel2.TabIndex = 3;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(45, 17);
            label19.Name = "label19";
            label19.Size = new Size(308, 31);
            label19.TabIndex = 2;
            label19.Text = "Danh sách chờ đo sinh hiệu";
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.Controls.Add(panel13);
            panel10.Controls.Add(panel14);
            panel10.Controls.Add(panel12);
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(label21);
            panel10.Controls.Add(flowLayoutPanel4);
            panel10.Location = new Point(48, 1396);
            panel10.Name = "panel10";
            panel10.Size = new Size(1522, 251);
            panel10.TabIndex = 10;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(192, 192, 255);
            panel13.Controls.Add(label28);
            panel13.Controls.Add(label26);
            panel13.Location = new Point(783, 72);
            panel13.Name = "panel13";
            panel13.Size = new Size(336, 153);
            panel13.TabIndex = 1;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.Indigo;
            label28.Location = new Point(131, 50);
            label28.Name = "label28";
            label28.Size = new Size(78, 28);
            label28.TabIndex = 4;
            label28.Text = "Lịch sử";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.Indigo;
            label26.Location = new Point(131, 87);
            label26.Name = "label26";
            label26.Size = new Size(88, 20);
            label26.TabIndex = 3;
            label26.Text = "Sinh hiệu cũ";
            // 
            // panel14
            // 
            panel14.BackColor = Color.MistyRose;
            panel14.Controls.Add(label29);
            panel14.Controls.Add(label27);
            panel14.Location = new Point(1149, 72);
            panel14.Name = "panel14";
            panel14.Size = new Size(336, 153);
            panel14.TabIndex = 1;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.ForeColor = Color.Red;
            label29.Location = new Point(137, 50);
            label29.Name = "label29";
            label29.Size = new Size(85, 28);
            label29.TabIndex = 3;
            label29.Text = "Biểu đồ";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label27.ForeColor = Color.Red;
            label27.Location = new Point(112, 87);
            label27.Name = "label27";
            label27.Size = new Size(132, 20);
            label27.TabIndex = 2;
            label27.Text = "Thay đổi xu hướng";
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(192, 255, 192);
            panel12.Controls.Add(label25);
            panel12.Controls.Add(label24);
            panel12.Location = new Point(414, 72);
            panel12.Name = "panel12";
            panel12.Size = new Size(336, 153);
            panel12.TabIndex = 1;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.DarkGreen;
            label25.Location = new Point(109, 87);
            label25.Name = "label25";
            label25.Size = new Size(109, 20);
            label25.TabIndex = 2;
            label25.Text = "Xem danh sách";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.DarkGreen;
            label24.Location = new Point(109, 50);
            label24.Name = "label24";
            label24.Size = new Size(103, 28);
            label24.TabIndex = 1;
            label24.Text = "Hàng chờ";
            // 
            // panel11
            // 
            panel11.BackColor = Color.LightCyan;
            panel11.Controls.Add(label23);
            panel11.Controls.Add(label22);
            panel11.Location = new Point(45, 72);
            panel11.Name = "panel11";
            panel11.Size = new Size(336, 153);
            panel11.TabIndex = 0;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.RoyalBlue;
            label23.Location = new Point(110, 87);
            label23.Name = "label23";
            label23.Size = new Size(109, 20);
            label23.TabIndex = 1;
            label23.Text = "Ghi nhận chỉ số";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.RoyalBlue;
            label22.Location = new Point(100, 50);
            label22.Name = "label22";
            label22.Size = new Size(131, 28);
            label22.TabIndex = 0;
            label22.Text = "Đo sinh hiệu";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(45, 22);
            label21.Name = "label21";
            label21.Size = new Size(209, 31);
            label21.TabIndex = 3;
            label21.Text = "Hành động nhanh";
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Location = new Point(45, 72);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(1440, 153);
            flowLayoutPanel4.TabIndex = 0;
            // 
            // ucNurseOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(panel10);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(roundedPanel1);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ucNurseOverview";
            Size = new Size(1595, 2280);
            Load += ucNurseOverview_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            roundedPanel1.ResumeLayout(false);
            roundedPanel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private Panel panel3;
        private Label label5;
        private Label lblAlertCount;
        private Panel panel4;
        private Label label7;
        private Label lblRoomsCount;
        private Forms.RoundedPanel roundedPanel1;
        private Label label9;
        private Panel panel5;
        private Label label10;
        private Label label12;
        private Label label11;
        private Label label13;
        private Label label14;
        private Button button1;
        private Button button2;
        private Label label16;
        private Label label15;
        private Label label17;
        private Panel panel6;
        private Label label18;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel7;
        private Panel panel9;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label20;
        private Panel panel8;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label19;
        private Panel panel10;
        private Panel panel13;
        private Panel panel14;
        private Panel panel12;
        private Panel panel11;
        private Label label23;
        private Label label22;
        private Label label21;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label28;
        private Label label26;
        private Label label29;
        private Label label27;
        private Label label25;
        private Label label24;
        private Button button3;
        private Button button4;
    }
}
