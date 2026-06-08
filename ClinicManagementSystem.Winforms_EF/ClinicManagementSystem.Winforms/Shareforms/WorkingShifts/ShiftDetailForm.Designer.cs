namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    partial class ShiftDetailForm
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
            label1 = new Label();
            label2 = new Label();
            lblCode = new Label();
            label3 = new Label();
            lblStatus = new Label();
            label5 = new Label();
            lblDate = new Label();
            lblhour = new Label();
            label4 = new Label();
            label6 = new Label();
            lblDepartment = new Label();
            label7 = new Label();
            lblLocation = new Label();
            label8 = new Label();
            btnClose = new Button();
            btnChangeShiftRequest = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 20);
            label1.Name = "label1";
            label1.Size = new Size(282, 41);
            label1.TabIndex = 0;
            label1.Text = "Chi tiết ca làm việc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(35, 86);
            label2.Name = "label2";
            label2.Size = new Size(68, 28);
            label2.TabIndex = 1;
            label2.Text = "Mã ca:";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCode.Location = new Point(35, 128);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(103, 28);
            lblCode.TabIndex = 2;
            lblCode.Text = "CA-LT-001";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(345, 86);
            label3.Name = "label3";
            label3.Size = new Size(102, 28);
            label3.TabIndex = 3;
            label3.Text = "Trạng thái:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.AliceBlue;
            lblStatus.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.DarkBlue;
            lblStatus.Location = new Point(345, 128);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(107, 28);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Đã lên lịch";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 196);
            label5.Name = "label5";
            label5.Size = new Size(63, 28);
            label5.TabIndex = 5;
            label5.Text = "Ngày:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDate.Location = new Point(35, 243);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(94, 28);
            lblDate.TabIndex = 6;
            lblDate.Text = "2/6/2026";
            // 
            // lblhour
            // 
            lblhour.AutoSize = true;
            lblhour.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblhour.Location = new Point(345, 196);
            lblhour.Name = "lblhour";
            lblhour.Size = new Size(123, 28);
            lblhour.TabIndex = 7;
            lblhour.Text = "Giờ làm việc:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(345, 243);
            label4.Name = "label4";
            label4.Size = new Size(127, 28);
            label4.TabIndex = 8;
            label4.Text = "08:00 - 16:00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(35, 315);
            label6.Name = "label6";
            label6.Size = new Size(126, 28);
            label6.TabIndex = 9;
            label6.Text = "Khoa/Phòng:";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(35, 362);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(68, 28);
            lblDepartment.TabIndex = 10;
            lblDepartment.Text = "Lễ tân";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(345, 315);
            label7.Name = "label7";
            label7.Size = new Size(57, 28);
            label7.TabIndex = 11;
            label7.Text = "Vị trí:";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocation.Location = new Point(345, 362);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(73, 28);
            lblLocation.TabIndex = 12;
            lblLocation.Text = "Quầy 1";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.AliceBlue;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.DarkBlue;
            label8.Location = new Point(12, 419);
            label8.Name = "label8";
            label8.Size = new Size(538, 28);
            label8.TabIndex = 13;
            label8.Text = "Bạn có thể yêu cầu đổi ca này với đồng nghiệp cùng chức vụ";
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.Location = new Point(23, 467);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(215, 43);
            btnClose.TabIndex = 14;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnChangeShiftRequest
            // 
            btnChangeShiftRequest.BackColor = Color.CornflowerBlue;
            btnChangeShiftRequest.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangeShiftRequest.ForeColor = Color.White;
            btnChangeShiftRequest.Location = new Point(321, 467);
            btnChangeShiftRequest.Name = "btnChangeShiftRequest";
            btnChangeShiftRequest.Size = new Size(215, 43);
            btnChangeShiftRequest.TabIndex = 15;
            btnChangeShiftRequest.Text = "Yêu cầu đổi ca";
            btnChangeShiftRequest.UseVisualStyleBackColor = false;
            // 
            // ShiftDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(561, 522);
            Controls.Add(btnChangeShiftRequest);
            Controls.Add(btnClose);
            Controls.Add(label8);
            Controls.Add(lblLocation);
            Controls.Add(label7);
            Controls.Add(lblDepartment);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(lblhour);
            Controls.Add(lblDate);
            Controls.Add(label5);
            Controls.Add(lblStatus);
            Controls.Add(label3);
            Controls.Add(lblCode);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "ShiftDetailForm";
            Text = "ShiftDetailForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblCode;
        private Label label3;
        private Label lblStatus;
        private Label label5;
        private Label lblDate;
        private Label lblhour;
        private Label label4;
        private Label label6;
        private Label lblDepartment;
        private Label label7;
        private Label lblLocation;
        private Label label8;
        private Button btnClose;
        private Button btnChangeShiftRequest;
    }
}