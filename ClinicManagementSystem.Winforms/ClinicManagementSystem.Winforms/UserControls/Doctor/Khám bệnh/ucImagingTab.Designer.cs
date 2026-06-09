namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucImagingTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public Label lblTitle;

        public Button btnAddImaging;

        public FlowLayoutPanel flpImagings;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnAddImaging = new Button();
            flpImagings = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(10, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(182, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Yêu cầu chẩn đoán hình ảnh";
            // 
            // btnAddImaging
            // 
            btnAddImaging.Location = new Point(429, 10);
            btnAddImaging.Name = "btnAddImaging";
            btnAddImaging.Size = new Size(150, 35);
            btnAddImaging.TabIndex = 1;
            btnAddImaging.Text = "+ Thêm yêu cầu";
            // 
            // flpImagings
            // 
            flpImagings.AutoScroll = true;
            flpImagings.FlowDirection = FlowDirection.TopDown;
            flpImagings.Location = new Point(10, 60);
            flpImagings.Name = "flpImagings";
            flpImagings.Size = new Size(569, 429);
            flpImagings.TabIndex = 2;
            flpImagings.WrapContents = false;
            // 
            // ucImagingTab
            // 
            Controls.Add(lblTitle);
            Controls.Add(btnAddImaging);
            Controls.Add(flpImagings);
            Name = "ucImagingTab";
            Size = new Size(605, 515);
            ResumeLayout(false);
        }
    }
}
