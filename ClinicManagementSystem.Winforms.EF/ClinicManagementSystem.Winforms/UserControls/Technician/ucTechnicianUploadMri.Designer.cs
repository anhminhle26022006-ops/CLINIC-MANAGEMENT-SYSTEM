namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianUploadMri
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.viewHostPanel = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlContainer = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblSelectRequestTitle = new System.Windows.Forms.Label();
            this.cboMRIRequests = new System.Windows.Forms.ComboBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.picMRIPreview = new System.Windows.Forms.PictureBox();
            this.lblMRINoteTitle = new System.Windows.Forms.Label();
            this.txtMRINote = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.viewHostPanel.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMRIPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.pnlContainer);
            this.viewHostPanel.Controls.Add(this.lblSubtitle);
            this.viewHostPanel.Controls.Add(this.lblTitle);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 744);
            this.viewHostPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(760, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tải lên phim MRI/X-Ray";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(900, 28);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Chụp phim chẩn đoán và tải ảnh kết quả phim lên hệ thống";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlContainer.CornerRadius = 8;
            this.pnlContainer.Controls.Add(this.btnSubmit);
            this.pnlContainer.Controls.Add(this.txtMRINote);
            this.pnlContainer.Controls.Add(this.lblMRINoteTitle);
            this.pnlContainer.Controls.Add(this.picMRIPreview);
            this.pnlContainer.Controls.Add(this.btnSelectFile);
            this.pnlContainer.Controls.Add(this.cboMRIRequests);
            this.pnlContainer.Controls.Add(this.lblSelectRequestTitle);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(24, 96);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1196, 600);
            this.pnlContainer.TabIndex = 2;
            // 
            // lblSelectRequestTitle
            // 
            this.lblSelectRequestTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelectRequestTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblSelectRequestTitle.Location = new System.Drawing.Point(24, 24);
            this.lblSelectRequestTitle.Name = "lblSelectRequestTitle";
            this.lblSelectRequestTitle.Size = new System.Drawing.Size(300, 22);
            this.lblSelectRequestTitle.TabIndex = 0;
            this.lblSelectRequestTitle.Text = "Chọn yêu cầu chụp phim:";
            // 
            // cboMRIRequests
            // 
            this.cboMRIRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMRIRequests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMRIRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMRIRequests.FormattingEnabled = true;
            this.cboMRIRequests.Location = new System.Drawing.Point(24, 50);
            this.cboMRIRequests.Name = "cboMRIRequests";
            this.cboMRIRequests.Size = new System.Drawing.Size(1148, 28);
            this.cboMRIRequests.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnSelectFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFile.FlatAppearance.BorderSize = 0;
            this.btnSelectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFile.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSelectFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnSelectFile.Location = new System.Drawing.Point(24, 100);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(160, 36);
            this.btnSelectFile.TabIndex = 2;
            this.btnSelectFile.Text = "Chọn tệp phim...";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            // 
            // picMRIPreview
            // 
            this.picMRIPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.picMRIPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMRIPreview.Location = new System.Drawing.Point(24, 150);
            this.picMRIPreview.Name = "picMRIPreview";
            this.picMRIPreview.Size = new System.Drawing.Size(300, 240);
            this.picMRIPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMRIPreview.TabIndex = 3;
            this.picMRIPreview.TabStop = false;
            // 
            // lblMRINoteTitle
            // 
            this.lblMRINoteTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMRINoteTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblMRINoteTitle.Location = new System.Drawing.Point(360, 100);
            this.lblMRINoteTitle.Name = "lblMRINoteTitle";
            this.lblMRINoteTitle.Size = new System.Drawing.Size(300, 22);
            this.lblMRINoteTitle.TabIndex = 4;
            this.lblMRINoteTitle.Text = "Kết luận / Ghi chú kỹ thuật viên:";
            // 
            // txtMRINote
            // 
            this.txtMRINote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMRINote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMRINote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMRINote.Location = new System.Drawing.Point(360, 130);
            this.txtMRINote.Multiline = true;
            this.txtMRINote.Name = "txtMRINote";
            this.txtMRINote.Size = new System.Drawing.Size(812, 260);
            this.txtMRINote.TabIndex = 5;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(24, 420);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(1148, 44);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Tải lên kết quả & Hoàn thành";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // ucTechnicianUploadMri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianUploadMri";
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.ucTechnicianUploadMri_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianUploadMri_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMRIPreview)).EndInit();
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlContainer;
        private System.Windows.Forms.Label lblSelectRequestTitle;
        private System.Windows.Forms.ComboBox cboMRIRequests;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.PictureBox picMRIPreview;
        private System.Windows.Forms.Label lblMRINoteTitle;
        private System.Windows.Forms.TextBox txtMRINote;
        private System.Windows.Forms.Button btnSubmit;
    }
}
