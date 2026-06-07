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
            panel1 = new Panel();
            ShiftId = new Label();
            lblWho = new Label();
            lblhour = new Label();
            lbllocation = new Label();
            lblDepartment = new Label();
            lblStatus = new Label();
            flpDayShifts.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // flpDayShifts
            // 
            flpDayShifts.Controls.Add(panel1);
            flpDayShifts.Dock = DockStyle.Fill;
            flpDayShifts.FlowDirection = FlowDirection.TopDown;
            flpDayShifts.Location = new Point(0, 0);
            flpDayShifts.Name = "flpDayShifts";
            flpDayShifts.Size = new Size(776, 317);
            flpDayShifts.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblDepartment);
            panel1.Controls.Add(lbllocation);
            panel1.Controls.Add(lblhour);
            panel1.Controls.Add(lblWho);
            panel1.Controls.Add(ShiftId);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(773, 314);
            panel1.TabIndex = 0;
            // 
            // ShiftId
            // 
            ShiftId.AutoSize = true;
            ShiftId.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShiftId.Location = new Point(20, 28);
            ShiftId.Name = "ShiftId";
            ShiftId.Size = new Size(80, 35);
            ShiftId.TabIndex = 0;
            ShiftId.Text = "label1";
            // 
            // lblWho
            // 
            lblWho.AutoSize = true;
            lblWho.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWho.Location = new Point(20, 94);
            lblWho.Name = "lblWho";
            lblWho.Size = new Size(65, 28);
            lblWho.TabIndex = 1;
            lblWho.Text = "label1";
            // 
            // lblhour
            // 
            lblhour.AutoSize = true;
            lblhour.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblhour.Location = new Point(20, 162);
            lblhour.Name = "lblhour";
            lblhour.Size = new Size(65, 28);
            lblhour.TabIndex = 2;
            lblhour.Text = "label1";
            // 
            // lbllocation
            // 
            lbllocation.AutoSize = true;
            lbllocation.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbllocation.Location = new Point(20, 244);
            lbllocation.Name = "lbllocation";
            lbllocation.Size = new Size(65, 28);
            lbllocation.TabIndex = 3;
            lbllocation.Text = "label1";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDepartment.Location = new Point(392, 162);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(65, 28);
            lblDepartment.TabIndex = 4;
            lblDepartment.Text = "label1";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.AliceBlue;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(568, 35);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(65, 28);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "label1";
            // 
            // ucDayView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpDayShifts);
            Name = "ucDayView";
            Size = new Size(776, 317);
            flpDayShifts.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpDayShifts;
        private Panel panel1;
        private Label ShiftId;
        private Label lblhour;
        private Label lblWho;
        private Label lblStatus;
        private Label lblDepartment;
        private Label lbllocation;
    }
}
