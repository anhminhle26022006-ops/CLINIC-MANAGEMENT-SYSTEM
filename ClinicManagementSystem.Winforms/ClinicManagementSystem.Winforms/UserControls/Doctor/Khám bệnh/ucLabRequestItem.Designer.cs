namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    partial class ucLabRequestItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMain;

        private Label lblType;
        private Label lblNote;

        public ComboBox cboLabType;
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
            lblNote = new Label();

            cboLabType = new ComboBox();
            txtNote = new TextBox();

            btnDelete = new Button();
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            SuspendLayout();

            Size = new Size(700, 120);

            pnlMain.Dock = DockStyle.Fill;
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.BackColor = Color.White;

            lblType.Text = "Loại xét nghiệm";
            lblType.Location = new Point(15, 15);
            lblType.AutoSize = true;

            cboLabType.Location = new Point(15, 40);
            cboLabType.Size = new Size(250, 30);

            lblNote.Text = "Ghi chú yêu cầu";
            lblNote.Location = new Point(290, 15);
            lblNote.AutoSize = true;

            txtNote.Location = new Point(290, 40);
            txtNote.Size = new Size(330, 30);

            btnDelete.Text = "🗑";
            btnDelete.Size = new Size(50, 50);
            btnDelete.Location = new Point(635, 30);

            pnlMain.Controls.Add(lblType);
            pnlMain.Controls.Add(cboLabType);

            pnlMain.Controls.Add(lblNote);
            pnlMain.Controls.Add(txtNote);

            pnlMain.Controls.Add(btnDelete);

            Controls.Add(pnlMain);

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
