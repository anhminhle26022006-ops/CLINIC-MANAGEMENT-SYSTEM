namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianUploadPdf
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
            this.cboPDFRequests = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblPDFSelectedFile = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.viewHostPanel.SuspendLayout();
            this.pnlContainer.SuspendLayout();
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
            this.lblTitle.Text = "Tải lên kết quả xét nghiệm PDF";
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
            this.lblSubtitle.Text = "Tải tệp PDF kết quả xét nghiệm tổng hợp lưu vào hồ sơ điện tử";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlContainer.CornerRadius = 8;
            this.pnlContainer.Controls.Add(this.btnSubmit);
            this.pnlContainer.Controls.Add(this.lblPDFSelectedFile);
            this.pnlContainer.Controls.Add(this.btnSelect);
            this.pnlContainer.Controls.Add(this.cboPDFRequests);
            this.pnlContainer.Controls.Add(this.lblSelectRequestTitle);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(24, 96);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1196, 400);
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
            this.lblSelectRequestTitle.Text = "Chọn yêu cầu xét nghiệm tổng quát:";
            // 
            // cboPDFRequests
            // 
            this.cboPDFRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPDFRequests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPDFRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPDFRequests.FormattingEnabled = true;
            this.cboPDFRequests.Location = new System.Drawing.Point(24, 50);
            this.cboPDFRequests.Name = "cboPDFRequests";
            this.cboPDFRequests.Size = new System.Drawing.Size(1148, 28);
            this.cboPDFRequests.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.FlatAppearance.BorderSize = 0;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.btnSelect.Location = new System.Drawing.Point(24, 105);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(180, 38);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Chọn tệp PDF...";
            this.btnSelect.UseVisualStyleBackColor = false;
            // 
            // lblPDFSelectedFile
            // 
            this.lblPDFSelectedFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPDFSelectedFile.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblPDFSelectedFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPDFSelectedFile.Location = new System.Drawing.Point(24, 155);
            this.lblPDFSelectedFile.Name = "lblPDFSelectedFile";
            this.lblPDFSelectedFile.Size = new System.Drawing.Size(1148, 22);
            this.lblPDFSelectedFile.TabIndex = 3;
            this.lblPDFSelectedFile.Text = "Chưa chọn file PDF nào";
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
            this.btnSubmit.Location = new System.Drawing.Point(24, 200);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(1148, 44);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Lưu tệp PDF vào hồ sơ bệnh án";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // ucTechnicianUploadPdf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianUploadPdf";
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.ucTechnicianUploadPdf_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianUploadPdf_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlContainer;
        private System.Windows.Forms.Label lblSelectRequestTitle;
        private System.Windows.Forms.ComboBox cboPDFRequests;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblPDFSelectedFile;
        private System.Windows.Forms.Button btnSubmit;
    }
}
