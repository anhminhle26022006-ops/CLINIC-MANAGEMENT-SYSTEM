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
            cboMedicine = new ComboBox();
            lblDosage = new Label();
            txtDosage = new TextBox();
            lblFrequency = new Label();
            cboFrequency = new ComboBox();
            lblQuantity = new Label();
            numQuantity = new NumericUpDown();
            lblInstruction = new Label();
            txtInstruction = new TextBox();
            btnDelete = new Button();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
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
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(757, 170);
            pnlMain.TabIndex = 0;
            // 
            // lblMedicine
            // 
            lblMedicine.AutoSize = true;
            lblMedicine.Location = new Point(15, 15);
            lblMedicine.Name = "lblMedicine";
            lblMedicine.Size = new Size(73, 20);
            lblMedicine.TabIndex = 0;
            lblMedicine.Text = "Tên thuốc";
            // 
            // cboMedicine
            // 
            cboMedicine.Location = new Point(15, 40);
            cboMedicine.Name = "cboMedicine";
            cboMedicine.Size = new Size(260, 28);
            cboMedicine.TabIndex = 1;
            // 
            // lblDosage
            // 
            lblDosage.AutoSize = true;
            lblDosage.Location = new Point(295, 15);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(74, 20);
            lblDosage.TabIndex = 2;
            lblDosage.Text = "Liều dùng";
            // 
            // txtDosage
            // 
            txtDosage.Location = new Point(295, 40);
            txtDosage.Name = "txtDosage";
            txtDosage.Size = new Size(94, 27);
            txtDosage.TabIndex = 3;
            // 
            // lblFrequency
            // 
            lblFrequency.AutoSize = true;
            lblFrequency.Location = new Point(408, 15);
            lblFrequency.Name = "lblFrequency";
            lblFrequency.Size = new Size(64, 20);
            lblFrequency.TabIndex = 4;
            lblFrequency.Text = "Tần suất";
            // 
            // cboFrequency
            // 
            cboFrequency.Location = new Point(408, 38);
            cboFrequency.Name = "cboFrequency";
            cboFrequency.Size = new Size(89, 28);
            cboFrequency.TabIndex = 5;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(521, 15);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(69, 20);
            lblQuantity.TabIndex = 6;
            lblQuantity.Text = "Số lượng";
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(521, 38);
            numQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(80, 27);
            numQuantity.TabIndex = 7;
            numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Location = new Point(15, 85);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(141, 20);
            lblInstruction.TabIndex = 8;
            lblInstruction.Text = "Hướng dẫn sử dụng";
            // 
            // txtInstruction
            // 
            txtInstruction.Location = new Point(15, 110);
            txtInstruction.Multiline = true;
            txtInstruction.Name = "txtInstruction";
            txtInstruction.Size = new Size(530, 45);
            txtInstruction.TabIndex = 9;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(254, 226, 226);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(551, 105);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(50, 50);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "🗑";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // ucPrescriptionItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucPrescriptionItem";
            Size = new Size(650, 170);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
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
