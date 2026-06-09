namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    partial class frmPrescriptionDetail
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Label lblTitle;

        private Panel pnlPatient;
        private Label lblPatientTitle;
        public Label lblPatientName;

        private Panel pnlDate;
        private Label lblDateTitle;
        public Label lblPrescriptionDate;

        private Panel pnlMedicines;
        private Label lblMedicineTitle;
        public RichTextBox rtbMedicines;

        private Panel pnlNote;
        private Label lblNoteTitle;
        public RichTextBox rtbNote;

        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();

            this.pnlPatient = new Panel();
            this.lblPatientTitle = new Label();
            this.lblPatientName = new Label();

            this.pnlDate = new Panel();
            this.lblDateTitle = new Label();
            this.lblPrescriptionDate = new Label();

            this.pnlMedicines = new Panel();
            this.lblMedicineTitle = new Label();
            this.rtbMedicines = new RichTextBox();

            this.pnlNote = new Panel();
            this.lblNoteTitle = new Label();
            this.rtbNote = new RichTextBox();

            this.btnClose = new Button();

            this.SuspendLayout();

            // ================= FORM =================
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 248, 252);
            this.ClientSize = new Size(700, 720);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Chi tiết toa thuốc";

            // ================= HEADER =================
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 70;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(31, 41, 55);
            this.lblTitle.Location = new Point(20, 20);
            this.lblTitle.Text = "Chi tiết toa thuốc";

            this.pnlHeader.Controls.Add(this.lblTitle);

            // ================= PATIENT =================
            this.pnlPatient.BackColor = Color.White;
            this.pnlPatient.Location = new Point(20, 90);
            this.pnlPatient.Size = new Size(660, 90);

            this.lblPatientTitle.AutoSize = true;
            this.lblPatientTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPatientTitle.ForeColor = Color.DimGray;
            this.lblPatientTitle.Location = new Point(20, 15);
            this.lblPatientTitle.Text = "Bệnh nhân";

            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            this.lblPatientName.Location = new Point(20, 45);
            this.lblPatientName.Text = "Nguyễn Văn A";

            this.pnlPatient.Controls.Add(this.lblPatientTitle);
            this.pnlPatient.Controls.Add(this.lblPatientName);

            // ================= DATE =================
            this.pnlDate.BackColor = Color.White;
            this.pnlDate.Location = new Point(20, 190);
            this.pnlDate.Size = new Size(660, 90);

            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDateTitle.ForeColor = Color.DimGray;
            this.lblDateTitle.Location = new Point(20, 15);
            this.lblDateTitle.Text = "Ngày kê";

            this.lblPrescriptionDate.AutoSize = true;
            this.lblPrescriptionDate.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            this.lblPrescriptionDate.Location = new Point(20, 45);
            this.lblPrescriptionDate.Text = "17/05/2026";

            this.pnlDate.Controls.Add(this.lblDateTitle);
            this.pnlDate.Controls.Add(this.lblPrescriptionDate);

            // ================= MEDICINES =================
            this.pnlMedicines.BackColor = Color.White;
            this.pnlMedicines.Location = new Point(20, 290);
            this.pnlMedicines.Size = new Size(660, 260);

            this.lblMedicineTitle.AutoSize = true;
            this.lblMedicineTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMedicineTitle.ForeColor = Color.DimGray;
            this.lblMedicineTitle.Location = new Point(20, 15);
            this.lblMedicineTitle.Text = "Danh sách thuốc";

            this.rtbMedicines.BorderStyle = BorderStyle.None;
            this.rtbMedicines.Font = new Font("Segoe UI", 10F);
            this.rtbMedicines.Location = new Point(20, 45);
            this.rtbMedicines.Size = new Size(620, 190);
            this.rtbMedicines.ReadOnly = true;
            this.rtbMedicines.BackColor = Color.White;
            this.rtbMedicines.Text = "";

            this.pnlMedicines.Controls.Add(this.lblMedicineTitle);
            this.pnlMedicines.Controls.Add(this.rtbMedicines);

            // ================= NOTE =================
            this.pnlNote.BackColor = Color.White;
            this.pnlNote.Location = new Point(20, 565);
            this.pnlNote.Size = new Size(660, 90);

            this.lblNoteTitle.AutoSize = true;
            this.lblNoteTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblNoteTitle.ForeColor = Color.DimGray;
            this.lblNoteTitle.Location = new Point(20, 12);
            this.lblNoteTitle.Text = "Ghi chú";

            this.rtbNote.BorderStyle = BorderStyle.None;
            this.rtbNote.Font = new Font("Segoe UI", 10F);
            this.rtbNote.Location = new Point(20, 38);
            this.rtbNote.Size = new Size(620, 40);
            this.rtbNote.ReadOnly = true;
            this.rtbNote.BackColor = Color.White;
            this.rtbNote.Text = "";

            this.pnlNote.Controls.Add(this.lblNoteTitle);
            this.pnlNote.Controls.Add(this.rtbNote);

            // ================= BUTTON =================
            this.btnClose.BackColor = Color.FromArgb(37, 99, 235);
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnClose.ForeColor = Color.White;
            this.btnClose.Location = new Point(280, 670);
            this.btnClose.Size = new Size(140, 40);
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.BtnClose_Click);

            // ================= ADD CONTROLS =================
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlNote);
            this.Controls.Add(this.pnlMedicines);
            this.Controls.Add(this.pnlDate);
            this.Controls.Add(this.pnlPatient);
            this.Controls.Add(this.pnlHeader);

            this.ResumeLayout(false);
        }

        #endregion
    }
}