namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucPreviousVisitCard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        public Label lblHeader;

        public Label lblDate;
        public Label lblDiagnosis;
        public Label lblDoctor;
        public Label lblMedicine;

        private void InitializeComponent()
        {
            pnlMain = new Panel();

            lblHeader = new Label();

            lblDate = new Label();
            lblDiagnosis = new Label();
            lblDoctor = new Label();
            lblMedicine = new Label();

            SuspendLayout();

            pnlMain.Dock = DockStyle.Fill;

            pnlMain.BackColor =
                Color.White;

            pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            lblHeader.Text =
                "LẦN KHÁM TRƯỚC";

            lblHeader.Dock =
                DockStyle.Top;

            lblHeader.Height = 35;

            lblHeader.TextAlign =
                ContentAlignment.MiddleLeft;

            lblHeader.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold);

            lblHeader.BackColor =
                Color.FromArgb(243, 232, 255);

            lblDate.Location =
                new Point(15, 50);

            lblDate.AutoSize = true;

            lblDate.Text =
                "15/05/2026";

            lblDiagnosis.Location =
                new Point(15, 80);

            lblDiagnosis.Size =
                new Size(260, 40);

            lblDiagnosis.Text =
                "Tăng huyết áp độ I";

            lblDoctor.Location =
                new Point(15, 125);

            lblDoctor.AutoSize = true;

            lblDoctor.Text =
                "BS Nguyễn Thành Nam";

            lblMedicine.Location =
                new Point(15, 155);

            lblMedicine.Size =
                new Size(260, 40);

            lblMedicine.Text =
                "Amlodipine 5mg";

            pnlMain.Controls.Add(lblHeader);
            pnlMain.Controls.Add(lblDate);
            pnlMain.Controls.Add(lblDiagnosis);
            pnlMain.Controls.Add(lblDoctor);
            pnlMain.Controls.Add(lblMedicine);

            Controls.Add(pnlMain);

            Name = "ucPreviousVisitCard";

            Size = new Size(300, 220);

            ResumeLayout(false);
        }
    }
}