namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    partial class ucDayView
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
            flpDayShifts = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpDayShifts
            // 
            flpDayShifts.AutoScroll = true;
            flpDayShifts.Dock = DockStyle.Fill;
            flpDayShifts.FlowDirection = FlowDirection.TopDown;
            flpDayShifts.Location = new Point(0, 0);
            flpDayShifts.Name = "flpDayShifts";
            flpDayShifts.Size = new Size(1227, 317);
            flpDayShifts.TabIndex = 0;
            // 
            // ucDayView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpDayShifts);
            Name = "ucDayView";
            Size = new Size(1227, 317);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDayShifts;
    }
}
