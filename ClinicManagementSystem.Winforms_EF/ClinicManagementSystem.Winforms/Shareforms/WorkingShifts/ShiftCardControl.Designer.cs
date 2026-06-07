namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    partial class ShiftCardControl
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
            lblCode = new Label();
            lblTime = new Label();
            lblDepartment = new Label();
            SuspendLayout();
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblCode.Location = new Point(37, 17);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(67, 28);
            lblCode.TabIndex = 0;
            lblCode.Text = "CA001";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(27, 61);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(93, 20);
            lblTime.TabIndex = 1;
            lblTime.Text = "08:00 - 12:00";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(37, 103);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(71, 20);
            lblDepartment.TabIndex = 2;
            lblDepartment.Text = "Khoa Nội";
            // 
            // ShiftCardControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AliceBlue;
            Controls.Add(lblDepartment);
            Controls.Add(lblTime);
            Controls.Add(lblCode);
            Name = "ShiftCardControl";
            Size = new Size(152, 148);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCode;
        private Label lblTime;
        private Label lblDepartment;
    }
}
