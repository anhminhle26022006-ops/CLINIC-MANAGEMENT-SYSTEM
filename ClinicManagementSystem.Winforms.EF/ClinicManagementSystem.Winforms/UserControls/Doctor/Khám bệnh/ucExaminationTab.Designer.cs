namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucExaminationTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Label lblSymptom;
        public Label lblDiagnosis;
        public Label lblConclusion;
        public Label lblNote;

        public TextBox txtSymptom;
        public TextBox txtDiagnosis;
        public TextBox txtConclusion;
        public TextBox txtNote;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblSymptom = new Label();
            lblDiagnosis = new Label();
            lblConclusion = new Label();
            lblNote = new Label();
            txtSymptom = new TextBox();
            txtDiagnosis = new TextBox();
            txtConclusion = new TextBox();
            txtNote = new TextBox();
            SuspendLayout();
            // 
            // lblSymptom
            // 
            lblSymptom.Location = new Point(10, 10);
            lblSymptom.Name = "lblSymptom";
            lblSymptom.Size = new Size(100, 23);
            lblSymptom.TabIndex = 0;
            lblSymptom.Text = "Triệu chứng";
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.Location = new Point(10, 125);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(100, 23);
            lblDiagnosis.TabIndex = 2;
            lblDiagnosis.Text = "Chẩn đoán";
            // 
            // lblConclusion
            // 
            lblConclusion.Location = new Point(10, 240);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(100, 23);
            lblConclusion.TabIndex = 4;
            lblConclusion.Text = "Kết luận";
            // 
            // lblNote
            // 
            lblNote.Location = new Point(10, 355);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(100, 23);
            lblNote.TabIndex = 6;
            lblNote.Text = "Ghi chú";
            // 
            // txtSymptom
            // 
            txtSymptom.Location = new Point(10, 35);
            txtSymptom.Multiline = true;
            txtSymptom.Name = "txtSymptom";
            txtSymptom.Size = new Size(574, 87);
            txtSymptom.TabIndex = 1;
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.Location = new Point(10, 150);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.Size = new Size(574, 87);
            txtDiagnosis.TabIndex = 3;
            // 
            // txtConclusion
            // 
            txtConclusion.Location = new Point(10, 265);
            txtConclusion.Multiline = true;
            txtConclusion.Name = "txtConclusion";
            txtConclusion.Size = new Size(574, 87);
            txtConclusion.TabIndex = 5;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(10, 381);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(574, 80);
            txtNote.TabIndex = 7;
            // 
            // ucExaminationTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSymptom);
            Controls.Add(txtSymptom);
            Controls.Add(lblDiagnosis);
            Controls.Add(txtDiagnosis);
            Controls.Add(lblConclusion);
            Controls.Add(txtConclusion);
            Controls.Add(lblNote);
            Controls.Add(txtNote);
            Name = "ucExaminationTab";
            Size = new Size(613, 492);
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
