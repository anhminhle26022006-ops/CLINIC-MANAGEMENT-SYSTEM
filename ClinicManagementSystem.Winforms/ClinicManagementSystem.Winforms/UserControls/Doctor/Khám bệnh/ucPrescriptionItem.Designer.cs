namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucPrescriptionItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        private Label lblMedicine;
        private Label lblDosage;
        private Label lblFrequency;
        private Label lblQuantity;
        private Label lblInstruction;

        public ComboBox cboMedicine;
        public TextBox txtDosage;
        public ComboBox cboFrequency;
        public NumericUpDown numQuantity;
        public TextBox txtInstruction;

        public Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();

            lblMedicine = new Label();
            lblDosage = new Label();
            lblFrequency = new Label();
            lblQuantity = new Label();
            lblInstruction = new Label();

            cboMedicine = new ComboBox();
            txtDosage = new TextBox();
            cboFrequency = new ComboBox();
            numQuantity = new NumericUpDown();
            txtInstruction = new TextBox();

            btnDelete = new Button();
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            ((System.ComponentModel.ISupportInitialize)(numQuantity)).BeginInit();

            SuspendLayout();

            //=================================
            // USERCONTROL
            //=================================

            Size = new Size(720, 170);

            //=================================
            // PANEL
            //=================================

            pnlMain.Dock = DockStyle.Fill;

            pnlMain.BackColor = Color.White;

            pnlMain.BorderStyle =
                BorderStyle.FixedSingle;

            //=================================
            // MEDICINE
            //=================================

            lblMedicine.Text = "Tên thuốc";
            lblMedicine.Location = new Point(15, 15);
            lblMedicine.AutoSize = true;

            cboMedicine.Location =
                new Point(15, 40);

            cboMedicine.Size =
                new Size(260, 30);

            //=================================
            // DOSAGE
            //=================================

            lblDosage.Text = "Liều dùng";
            lblDosage.Location = new Point(295, 15);
            lblDosage.AutoSize = true;

            txtDosage.Location =
                new Point(295, 40);

            txtDosage.Size =
                new Size(120, 30);

            //=================================
            // FREQUENCY
            //=================================

            lblFrequency.Text = "Tần suất";
            lblFrequency.Location = new Point(435, 15);
            lblFrequency.AutoSize = true;

            cboFrequency.Location =
                new Point(435, 40);

            cboFrequency.Size =
                new Size(150, 30);

            //=================================
            // QUANTITY
            //=================================

            lblQuantity.Text = "Số lượng";
            lblQuantity.Location = new Point(605, 15);
            lblQuantity.AutoSize = true;

            numQuantity.Location =
                new Point(605, 40);

            numQuantity.Size =
                new Size(80, 30);

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 1000;

            //=================================
            // INSTRUCTION
            //=================================

            lblInstruction.Text = "Hướng dẫn sử dụng";
            lblInstruction.Location =
                new Point(15, 85);

            lblInstruction.AutoSize = true;

            txtInstruction.Location =
                new Point(15, 110);

            txtInstruction.Multiline = true;

            txtInstruction.Size =
                new Size(610, 45);

            //=================================
            // DELETE
            //=================================

            btnDelete.Text = "🗑";

            btnDelete.Size =
                new Size(50, 50);

            btnDelete.Location =
                new Point(645, 103);

            btnDelete.FlatStyle =
                FlatStyle.Flat;

            btnDelete.BackColor =
                Color.FromArgb(254, 226, 226);

            //=================================
            // ADD
            //=================================

            pnlMain.Controls.Add(lblMedicine);
            pnlMain.Controls.Add(cboMedicine);

            pnlMain.Controls.Add(lblDosage);
            pnlMain.Controls.Add(txtDosage);

            pnlMain.Controls.Add(lblFrequency);
            pnlMain.Controls.Add(cboFrequency);

            pnlMain.Controls.Add(lblQuantity);
            pnlMain.Controls.Add(numQuantity);

            pnlMain.Controls.Add(lblInstruction);
            pnlMain.Controls.Add(txtInstruction);

            pnlMain.Controls.Add(btnDelete);

            Controls.Add(pnlMain);

            ((System.ComponentModel.ISupportInitialize)(numQuantity)).EndInit();

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
