namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucVitalSignCard1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlCard;

        public Label lblTitle;
        public Label lblValue;
        public Label lblUnit;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlCard = new Panel();

            lblTitle = new Label();
            lblValue = new Label();
            lblUnit = new Label();

            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            SuspendLayout();

            //====================================
            // USERCONTROL
            //====================================

            Size = new Size(120, 85);

            //====================================
            // CARD
            //====================================

            pnlCard.Dock = DockStyle.Fill;

            pnlCard.BackColor =
                Color.FromArgb(248, 250, 252);

            pnlCard.BorderStyle =
                BorderStyle.FixedSingle;

            //====================================
            // TITLE
            //====================================

            lblTitle.Text = "Huyết áp";

            lblTitle.Font =
                new Font("Segoe UI", 8.5F);

            lblTitle.ForeColor =
                Color.DimGray;

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(10, 10);

            //====================================
            // VALUE
            //====================================

            lblValue.Text = "118/75";

            lblValue.Font =
                new Font("Segoe UI",
                    12F,
                    FontStyle.Bold);

            lblValue.AutoSize = true;

            lblValue.Location =
                new Point(10, 30);

            //====================================
            // UNIT
            //====================================

            lblUnit.Text = "mmHg";

            lblUnit.Font =
                new Font("Segoe UI", 8F);

            lblUnit.AutoSize = true;

            lblUnit.ForeColor =
                Color.Gray;

            lblUnit.Location =
                new Point(10, 58);

            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblValue);
            pnlCard.Controls.Add(lblUnit);

            Controls.Add(pnlCard);

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
