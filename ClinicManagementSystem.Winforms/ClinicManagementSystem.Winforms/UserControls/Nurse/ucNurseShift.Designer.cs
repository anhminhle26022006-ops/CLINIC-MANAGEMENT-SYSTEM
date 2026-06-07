namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseShift
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
            ucTechnicianShifts1 = new ClinicManagementSystem.Winforms.UserControls.Technician.ucTechnicianShifts();
            SuspendLayout();
            // 
            // ucTechnicianShifts1
            // 
            ucTechnicianShifts1.BackColor = Color.FromArgb(247, 249, 252);
            ucTechnicianShifts1.Font = new Font("Segoe UI", 9F);
            ucTechnicianShifts1.Location = new Point(0, 0);
            ucTechnicianShifts1.Margin = new Padding(3, 4, 3, 4);
            ucTechnicianShifts1.Name = "ucTechnicianShifts1";
            ucTechnicianShifts1.Size = new Size(1372, 989);
            ucTechnicianShifts1.TabIndex = 4;
            ucTechnicianShifts1.Load += ucTechnicianShifts1_Load;
            // 
            // ucNurseShift
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ucTechnicianShifts1);
            Name = "ucNurseShift";
            Size = new Size(1374, 992);
            ResumeLayout(false);
        }

        #endregion

        private Technician.ucTechnicianShifts ucTechnicianShifts1;
    }
}
