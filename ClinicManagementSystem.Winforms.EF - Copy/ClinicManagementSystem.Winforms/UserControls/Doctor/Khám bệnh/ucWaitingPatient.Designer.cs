namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucWaitingPatient
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlContainer;

        public Label lblPatientName;
        public Label lblAppointmentTime;
        public Label lblAgeGender;
        public Label lblAllergy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlContainer = new Panel();

            lblPatientName = new Label();
            lblAppointmentTime = new Label();
            lblAgeGender = new Label();
            lblAllergy = new Label();

            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            SuspendLayout();

            //====================================
            // USERCONTROL
            //====================================

            BackColor = Color.Transparent;
            Size = new Size(260, 110);
            Margin = new Padding(0, 0, 0, 10);

            //====================================
            // PANEL
            //====================================

            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.BackColor = Color.White;
            pnlContainer.Padding = new Padding(12);
            pnlContainer.BorderStyle = BorderStyle.FixedSingle;
            pnlContainer.Cursor = Cursors.Hand;

            //====================================
            // NAME
            //====================================

            lblPatientName.AutoSize = true;
            lblPatientName.Font =
                new Font("Segoe UI", 10F, FontStyle.Bold);

            lblPatientName.Text = "Nguyễn Văn A";
            lblPatientName.Location = new Point(12, 10);

            //====================================
            // TIME
            //====================================

            lblAppointmentTime.AutoSize = true;
            lblAppointmentTime.Font =
                new Font("Segoe UI", 9F);

            lblAppointmentTime.ForeColor =
                Color.DimGray;

            lblAppointmentTime.Text = "08:00";
            lblAppointmentTime.Location =
                new Point(12, 38);

            //====================================
            // AGE GENDER
            //====================================

            lblAgeGender.AutoSize = true;
            lblAgeGender.Font =
                new Font("Segoe UI", 9F);

            lblAgeGender.Text =
                "Nam • 30 tuổi";

            lblAgeGender.Location =
                new Point(12, 60);

            //====================================
            // ALLERGY
            //====================================

            lblAllergy.AutoSize = true;

            lblAllergy.Font =
                new Font("Segoe UI", 8.5F,
                    FontStyle.Bold);

            lblAllergy.ForeColor =
                Color.Firebrick;

            lblAllergy.Text =
                "Dị ứng: Penicillin";

            lblAllergy.Location =
                new Point(12, 82);

            pnlContainer.Controls.Add(lblPatientName);
            pnlContainer.Controls.Add(lblAppointmentTime);
            pnlContainer.Controls.Add(lblAgeGender);
            pnlContainer.Controls.Add(lblAllergy);

            Controls.Add(pnlContainer);

            ResumeLayout(false);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
     

        #endregion
    }
}
