namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucLabTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public Label lblTitle;

        public Button btnAddLab;

        public FlowLayoutPanel flpLabs;
        private System.ComponentModel.IContainer components = null;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAddLab = new Button();
            flpLabs = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(180, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Yêu cầu xét nghiệm";
            // 
            // btnAddLab
            // 
            btnAddLab.Location = new Point(514, 10);
            btnAddLab.Name = "btnAddLab";
            btnAddLab.Size = new Size(170, 35);
            btnAddLab.TabIndex = 1;
            btnAddLab.Text = "+ Thêm xét nghiệm";
            // 
            // flpLabs
            // 
            flpLabs.AutoScroll = true;
            flpLabs.FlowDirection = FlowDirection.TopDown;
            flpLabs.Location = new Point(10, 60);
            flpLabs.Name = "flpLabs";
            flpLabs.Size = new Size(674, 455);
            flpLabs.TabIndex = 2;
            flpLabs.WrapContents = false;
            // 
            // ucLabTab
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTitle);
            Controls.Add(btnAddLab);
            Controls.Add(flpLabs);
            Name = "ucLabTab";
            Size = new Size(713, 540);
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
