namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucImagingCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        public Label lblTitle;
        public Label lblDate;
        public Label lblContent;

        public PictureBox picThumbnail;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMain = new Panel();
            lblTitle = new Label();
            lblDate = new Label();
            picThumbnail = new PictureBox();
            lblContent = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(243, 232, 255);
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Controls.Add(lblDate);
            pnlMain.Controls.Add(picThumbnail);
            pnlMain.Controls.Add(lblContent);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(12);
            pnlMain.Size = new Size(300, 220);
            pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(98, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "X-Ray phổi";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 35);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 1;
            lblDate.Text = "14/05/2026";
            // 
            // picThumbnail
            // 
            picThumbnail.BorderStyle = BorderStyle.FixedSingle;
            picThumbnail.Location = new Point(12, 60);
            picThumbnail.Name = "picThumbnail";
            picThumbnail.Size = new Size(260, 90);
            picThumbnail.SizeMode = PictureBoxSizeMode.Zoom;
            picThumbnail.TabIndex = 2;
            picThumbnail.TabStop = false;
            // 
            // lblContent
            // 
            lblContent.Location = new Point(12, 165);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(260, 45);
            lblContent.TabIndex = 3;
            lblContent.Text = "Phổi trong, tim bình thường";
            // 
            // ucImagingCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucImagingCard";
            Size = new Size(300, 220);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picThumbnail).EndInit();
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
