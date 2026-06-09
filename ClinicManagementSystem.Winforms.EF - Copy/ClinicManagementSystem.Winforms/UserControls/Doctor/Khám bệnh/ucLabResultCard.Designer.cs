namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucLabResultCard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        public Label lblTitle;
        public Label lblStatus;
        public Label lblDate;

        public Label lblWBC;
        public Label lblRBC;
        public Label lblHGB;

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblTitle = new Label();
            lblStatus = new Label();
            lblDate = new Label();
            lblWBC = new Label();
            lblRBC = new Label();
            lblHGB = new Label();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblStatus);
            pnlMain.Controls.Add(lblDate);
            pnlMain.Controls.Add(lblWBC);
            pnlMain.Controls.Add(lblRBC);
            pnlMain.Controls.Add(lblHGB);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(300, 220);
            pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(185, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Xét nghiệm máu";
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.ForestGreen;
            lblStatus.Location = new Point(15, 45);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(100, 23);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Hoàn thành";
            // 
            // lblDate
            // 
            lblDate.Location = new Point(15, 70);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 23);
            lblDate.TabIndex = 2;
            lblDate.Text = "15/05/2026";
            // 
            // lblWBC
            // 
            lblWBC.Location = new Point(15, 110);
            lblWBC.Name = "lblWBC";
            lblWBC.Size = new Size(100, 23);
            lblWBC.TabIndex = 3;
            lblWBC.Text = "WBC : 7.2";
            // 
            // lblRBC
            // 
            lblRBC.Location = new Point(15, 140);
            lblRBC.Name = "lblRBC";
            lblRBC.Size = new Size(100, 23);
            lblRBC.TabIndex = 4;
            lblRBC.Text = "RBC : 5.1";
            // 
            // lblHGB
            // 
            lblHGB.Location = new Point(15, 170);
            lblHGB.Name = "lblHGB";
            lblHGB.Size = new Size(100, 23);
            lblHGB.TabIndex = 5;
            lblHGB.Text = "HGB : 15.2";
            // 
            // ucLabResultCard
            // 
            Controls.Add(pnlMain);
            Name = "ucLabResultCard";
            Size = new Size(300, 220);
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}