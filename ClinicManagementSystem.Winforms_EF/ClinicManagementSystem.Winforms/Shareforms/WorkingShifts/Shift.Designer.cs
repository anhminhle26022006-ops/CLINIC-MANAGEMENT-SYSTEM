namespace ClinicManagementSystem.Winforms.Shareforms
{
    partial class Shift
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            cardTotalShift = new Panel();
            cardPendingRequest = new Panel();
            cardApprovedRequest = new Panel();
            lblTitle1 = new Label();
            lblCount1 = new Label();
            lblDescription1 = new Label();
            lblDescription2 = new Label();
            lblCount2 = new Label();
            lblTitle2 = new Label();
            lblDescription3 = new Label();
            lblCount3 = new Label();
            lblTitle3 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            panel2 = new Panel();
            panel3 = new Panel();
            btnSchedule = new Button();
            btnHistory = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            btnNext = new Button();
            btnPrev = new Button();
            btnToday = new Button();
            btnDay = new Button();
            btnWeek = new Button();
            btnMonth = new Button();
            lblCurrentPeriod = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            cardTotalShift.SuspendLayout();
            cardPendingRequest.SuspendLayout();
            cardApprovedRequest.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 89F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 143F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            tableLayoutPanel1.Size = new Size(1498, 727);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1492, 83);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 14);
            label1.Name = "label1";
            label1.Size = new Size(219, 31);
            label1.TabIndex = 0;
            label1.Text = "Quản lý ca làm việc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 45);
            label2.Name = "label2";
            label2.Size = new Size(289, 25);
            label2.TabIndex = 1;
            label2.Text = "Xem lịch làm việc và yêu cầu đổi ca";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(cardTotalShift, 0, 0);
            tableLayoutPanel2.Controls.Add(cardPendingRequest, 1, 0);
            tableLayoutPanel2.Controls.Add(cardApprovedRequest, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 92);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1492, 137);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // cardTotalShift
            // 
            cardTotalShift.BackColor = Color.AliceBlue;
            cardTotalShift.Controls.Add(lblDescription1);
            cardTotalShift.Controls.Add(lblCount1);
            cardTotalShift.Controls.Add(lblTitle1);
            cardTotalShift.Dock = DockStyle.Fill;
            cardTotalShift.Location = new Point(3, 3);
            cardTotalShift.Name = "cardTotalShift";
            cardTotalShift.Size = new Size(491, 131);
            cardTotalShift.TabIndex = 0;
            // 
            // cardPendingRequest
            // 
            cardPendingRequest.BackColor = Color.LemonChiffon;
            cardPendingRequest.Controls.Add(lblDescription2);
            cardPendingRequest.Controls.Add(lblCount2);
            cardPendingRequest.Controls.Add(lblTitle2);
            cardPendingRequest.Dock = DockStyle.Fill;
            cardPendingRequest.Location = new Point(500, 3);
            cardPendingRequest.Name = "cardPendingRequest";
            cardPendingRequest.Size = new Size(491, 131);
            cardPendingRequest.TabIndex = 1;
            // 
            // cardApprovedRequest
            // 
            cardApprovedRequest.BackColor = Color.Honeydew;
            cardApprovedRequest.Controls.Add(lblDescription3);
            cardApprovedRequest.Controls.Add(lblCount3);
            cardApprovedRequest.Controls.Add(lblTitle3);
            cardApprovedRequest.Dock = DockStyle.Fill;
            cardApprovedRequest.Location = new Point(997, 3);
            cardApprovedRequest.Name = "cardApprovedRequest";
            cardApprovedRequest.Size = new Size(492, 131);
            cardApprovedRequest.TabIndex = 2;
            // 
            // lblTitle1
            // 
            lblTitle1.AutoSize = true;
            lblTitle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle1.Location = new Point(214, 14);
            lblTitle1.Name = "lblTitle1";
            lblTitle1.Size = new Size(65, 28);
            lblTitle1.TabIndex = 0;
            lblTitle1.Text = "label3";
            // 
            // lblCount1
            // 
            lblCount1.AutoSize = true;
            lblCount1.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblCount1.Location = new Point(189, 42);
            lblCount1.Name = "lblCount1";
            lblCount1.Size = new Size(114, 46);
            lblCount1.TabIndex = 1;
            lblCount1.Text = "label4";
            // 
            // lblDescription1
            // 
            lblDescription1.AutoSize = true;
            lblDescription1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription1.Location = new Point(214, 87);
            lblDescription1.Name = "lblDescription1";
            lblDescription1.Size = new Size(65, 28);
            lblDescription1.TabIndex = 2;
            lblDescription1.Text = "label5";
            // 
            // lblDescription2
            // 
            lblDescription2.AutoSize = true;
            lblDescription2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription2.Location = new Point(208, 87);
            lblDescription2.Name = "lblDescription2";
            lblDescription2.Size = new Size(65, 28);
            lblDescription2.TabIndex = 5;
            lblDescription2.Text = "label5";
            // 
            // lblCount2
            // 
            lblCount2.AutoSize = true;
            lblCount2.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblCount2.Location = new Point(183, 42);
            lblCount2.Name = "lblCount2";
            lblCount2.Size = new Size(114, 46);
            lblCount2.TabIndex = 4;
            lblCount2.Text = "label4";
            // 
            // lblTitle2
            // 
            lblTitle2.AutoSize = true;
            lblTitle2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle2.Location = new Point(208, 14);
            lblTitle2.Name = "lblTitle2";
            lblTitle2.Size = new Size(65, 28);
            lblTitle2.TabIndex = 3;
            lblTitle2.Text = "label3";
            // 
            // lblDescription3
            // 
            lblDescription3.AutoSize = true;
            lblDescription3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDescription3.Location = new Point(217, 87);
            lblDescription3.Name = "lblDescription3";
            lblDescription3.Size = new Size(65, 28);
            lblDescription3.TabIndex = 8;
            lblDescription3.Text = "label5";
            // 
            // lblCount3
            // 
            lblCount3.AutoSize = true;
            lblCount3.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblCount3.Location = new Point(192, 42);
            lblCount3.Name = "lblCount3";
            lblCount3.Size = new Size(112, 46);
            lblCount3.TabIndex = 7;
            lblCount3.Text = "label7";
            // 
            // lblTitle3
            // 
            lblTitle3.AutoSize = true;
            lblTitle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle3.Location = new Point(217, 14);
            lblTitle3.Name = "lblTitle3";
            lblTitle3.Size = new Size(65, 28);
            lblTitle3.TabIndex = 6;
            lblTitle3.Text = "label3";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.White;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel5, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 235);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 322F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanel3.Size = new Size(1492, 489);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(panel2, 0, 0);
            tableLayoutPanel4.Controls.Add(panel3, 1, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(1486, 48);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnSchedule);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(737, 42);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnHistory);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(746, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(737, 42);
            panel3.TabIndex = 1;
            // 
            // btnSchedule
            // 
            btnSchedule.Dock = DockStyle.Fill;
            btnSchedule.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSchedule.Location = new Point(0, 0);
            btnSchedule.Name = "btnSchedule";
            btnSchedule.Size = new Size(737, 42);
            btnSchedule.TabIndex = 0;
            btnSchedule.Text = "Lịch làm việc";
            btnSchedule.UseVisualStyleBackColor = true;
            // 
            // btnHistory
            // 
            btnHistory.Dock = DockStyle.Fill;
            btnHistory.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHistory.Location = new Point(0, 0);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(737, 42);
            btnHistory.TabIndex = 0;
            btnHistory.Text = "Lịch sử đổi ca";
            btnHistory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 7;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 603F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel5.Controls.Add(btnNext, 2, 0);
            tableLayoutPanel5.Controls.Add(btnPrev, 0, 0);
            tableLayoutPanel5.Controls.Add(btnDay, 4, 0);
            tableLayoutPanel5.Controls.Add(btnWeek, 5, 0);
            tableLayoutPanel5.Controls.Add(btnMonth, 6, 0);
            tableLayoutPanel5.Controls.Add(lblCurrentPeriod, 1, 0);
            tableLayoutPanel5.Controls.Add(btnToday, 3, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 57);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Size = new Size(1486, 59);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // btnNext
            // 
            btnNext.Dock = DockStyle.Fill;
            btnNext.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNext.Location = new Point(513, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(54, 53);
            btnNext.TabIndex = 0;
            btnNext.Text = ">";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Dock = DockStyle.Fill;
            btnPrev.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrev.Location = new Point(3, 3);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(54, 53);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnToday
            // 
            btnToday.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnToday.BackColor = Color.RoyalBlue;
            btnToday.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnToday.ForeColor = Color.White;
            btnToday.Location = new Point(573, 3);
            btnToday.Name = "btnToday";
            btnToday.Size = new Size(197, 53);
            btnToday.TabIndex = 2;
            btnToday.Text = "Hôm nay";
            btnToday.UseVisualStyleBackColor = false;
            // 
            // btnDay
            // 
            btnDay.Dock = DockStyle.Fill;
            btnDay.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDay.Location = new Point(1176, 3);
            btnDay.Name = "btnDay";
            btnDay.Size = new Size(94, 53);
            btnDay.TabIndex = 3;
            btnDay.Text = "Ngày";
            btnDay.UseVisualStyleBackColor = true;
            // 
            // btnWeek
            // 
            btnWeek.Dock = DockStyle.Fill;
            btnWeek.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnWeek.Location = new Point(1276, 3);
            btnWeek.Name = "btnWeek";
            btnWeek.Size = new Size(94, 53);
            btnWeek.TabIndex = 4;
            btnWeek.Text = "Tuần ";
            btnWeek.UseVisualStyleBackColor = true;
            // 
            // btnMonth
            // 
            btnMonth.Dock = DockStyle.Fill;
            btnMonth.Font = new Font("Segoe UI Semibold", 13.2000008F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMonth.Location = new Point(1376, 3);
            btnMonth.Name = "btnMonth";
            btnMonth.Size = new Size(107, 53);
            btnMonth.TabIndex = 5;
            btnMonth.Text = "Tháng";
            btnMonth.UseVisualStyleBackColor = true;
            // 
            // lblCurrentPeriod
            // 
            lblCurrentPeriod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblCurrentPeriod.AutoSize = true;
            lblCurrentPeriod.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblCurrentPeriod.Location = new Point(63, 0);
            lblCurrentPeriod.Name = "lblCurrentPeriod";
            lblCurrentPeriod.Size = new Size(84, 59);
            lblCurrentPeriod.TabIndex = 6;
            lblCurrentPeriod.Text = "label3";
            lblCurrentPeriod.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Shift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Shift";
            Size = new Size(1498, 727);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            cardTotalShift.ResumeLayout(false);
            cardTotalShift.PerformLayout();
            cardPendingRequest.ResumeLayout(false);
            cardPendingRequest.PerformLayout();
            cardApprovedRequest.ResumeLayout(false);
            cardApprovedRequest.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel cardTotalShift;
        private Panel cardPendingRequest;
        private Panel cardApprovedRequest;
        private Label lblDescription1;
        private Label lblCount1;
        private Label lblTitle1;
        private Label lblDescription2;
        private Label lblCount2;
        private Label lblTitle2;
        private Label lblDescription3;
        private Label lblCount3;
        private Label lblTitle3;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private Panel panel2;
        private Button btnSchedule;
        private Panel panel3;
        private Button btnHistory;
        private TableLayoutPanel tableLayoutPanel5;
        private Button btnNext;
        private Button btnPrev;
        private Button btnToday;
        private Button btnDay;
        private Button btnWeek;
        private Button btnMonth;
        private Label lblCurrentPeriod;
    }
}
