namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucImagingRequestItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        private Label lblType;
        private Label lblNote;

        public ComboBox cboImagingType;
        public TextBox txtNote;

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
            lblType = new Label();
            cboImagingType = new ComboBox();
            lblNote = new Label();
            txtNote = new TextBox();
            btnDelete = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Controls.Add(lblType);
            pnlMain.Controls.Add(cboImagingType);
            pnlMain.Controls.Add(lblNote);
            pnlMain.Controls.Add(txtNote);
            pnlMain.Controls.Add(btnDelete);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(650, 120);
            pnlMain.TabIndex = 0;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(15, 15);
            lblType.Name = "lblType";
            lblType.Size = new Size(110, 20);
            lblType.TabIndex = 0;
            lblType.Text = "Loại chẩn đoán";
            // 
            // cboImagingType
            // 
            cboImagingType.Location = new Point(15, 40);
            cboImagingType.Name = "cboImagingType";
            cboImagingType.Size = new Size(161, 28);
            cboImagingType.TabIndex = 1;
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Location = new Point(215, 15);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(112, 20);
            lblNote.TabIndex = 2;
            lblNote.Text = "Ghi chú yêu cầu";
            // 
            // txtNote
            // 
            txtNote.Location = new Point(215, 38);
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(306, 27);
            txtNote.TabIndex = 3;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(548, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(50, 50);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "🗑";
            // 
            // ucImagingRequestItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "ucImagingRequestItem";
            Size = new Size(650, 120);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
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
