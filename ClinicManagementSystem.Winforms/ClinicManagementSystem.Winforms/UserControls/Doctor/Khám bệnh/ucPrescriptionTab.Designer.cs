namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucPrescriptionTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label lblTitle;

        public Button btnAddMedicine;

        public FlowLayoutPanel flpMedicines;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAddMedicine = new Button();
            flpMedicines = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(141, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Danh sách thuốc";
            // 
            // btnAddMedicine
            // 
            btnAddMedicine.BackColor = Color.DeepSkyBlue;
            btnAddMedicine.Location = new Point(510, 10);
            btnAddMedicine.Name = "btnAddMedicine";
            btnAddMedicine.Size = new Size(140, 35);
            btnAddMedicine.TabIndex = 1;
            btnAddMedicine.Text = "+ Thêm thuốc";
            btnAddMedicine.UseVisualStyleBackColor = false;
            // 
            // flpMedicines
            // 
            flpMedicines.AutoScroll = true;
            flpMedicines.FlowDirection = FlowDirection.TopDown;
            flpMedicines.Location = new Point(10, 60);
            flpMedicines.Name = "flpMedicines";
            flpMedicines.Size = new Size(658, 352);
            flpMedicines.TabIndex = 2;
            flpMedicines.WrapContents = false;
            // 
            // ucPrescriptionTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Controls.Add(btnAddMedicine);
            Controls.Add(flpMedicines);
            Name = "ucPrescriptionTab";
            Size = new Size(697, 446);
            ResumeLayout(false);
            PerformLayout();
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>


        #endregion
    }
}
