namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianLabResult
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
            this.cboLabRequests = new System.Windows.Forms.ComboBox();
            this.lblRBC = new System.Windows.Forms.Label();
            this.txtRBC = new System.Windows.Forms.TextBox();
            this.lblWBC = new System.Windows.Forms.Label();
            this.txtWBC = new System.Windows.Forms.TextBox();
            this.lblGlucose = new System.Windows.Forms.Label();
            this.txtGlucose = new System.Windows.Forms.TextBox();
            this.lblUricAcid = new System.Windows.Forms.Label();
            this.txtUricAcid = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Text = "Nhập kết quả chỉ số Lab";
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
            this.lblSubtitle.Text = "Nhập các chỉ số sinh hóa máu của bệnh nhân từ phòng Lab";
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlContainer.CornerRadius = 8;
            this.pnlContainer.Controls.Add(this.btnSubmit);
            this.pnlContainer.Controls.Add(this.txtUricAcid);
            this.pnlContainer.Controls.Add(this.lblUricAcid);
            this.pnlContainer.Controls.Add(this.txtGlucose);
            this.pnlContainer.Controls.Add(this.lblGlucose);
            this.pnlContainer.Controls.Add(this.txtWBC);
            this.pnlContainer.Controls.Add(this.lblWBC);
            this.pnlContainer.Controls.Add(this.txtRBC);
            this.pnlContainer.Controls.Add(this.lblRBC);
            this.pnlContainer.Controls.Add(this.cboLabRequests);
            this.pnlContainer.Controls.Add(this.lblSelectRequestTitle);
            this.pnlContainer.FillColor = System.Drawing.Color.White;
            this.pnlContainer.Location = new System.Drawing.Point(24, 96);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1196, 450);
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
            this.lblSelectRequestTitle.Text = "Chọn yêu cầu xét nghiệm sinh hóa:";
            // 
            // cboLabRequests
            // 
            this.cboLabRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboLabRequests.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLabRequests.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLabRequests.FormattingEnabled = true;
            this.cboLabRequests.Location = new System.Drawing.Point(24, 50);
            this.cboLabRequests.Name = "cboLabRequests";
            this.cboLabRequests.Size = new System.Drawing.Size(1148, 28);
            this.cboLabRequests.TabIndex = 1;
            // 
            // lblRBC
            // 
            this.lblRBC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblRBC.Location = new System.Drawing.Point(24, 100);
            this.lblRBC.Name = "lblRBC";
            this.lblRBC.Size = new System.Drawing.Size(300, 22);
            this.lblRBC.TabIndex = 2;
            this.lblRBC.Text = "Hồng cầu (RBC) - T.chuẩn: 3.8 - 5.8 T/L";
            // 
            // txtRBC
            // 
            this.txtRBC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRBC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRBC.Location = new System.Drawing.Point(24, 125);
            this.txtRBC.Name = "txtRBC";
            this.txtRBC.Size = new System.Drawing.Size(280, 25);
            this.txtRBC.TabIndex = 3;
            this.txtRBC.Text = "4.5";
            // 
            // lblWBC
            // 
            this.lblWBC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWBC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblWBC.Location = new System.Drawing.Point(360, 100);
            this.lblWBC.Name = "lblWBC";
            this.lblWBC.Size = new System.Drawing.Size(300, 22);
            this.lblWBC.TabIndex = 4;
            this.lblWBC.Text = "Bạch cầu (WBC) - T.chuẩn: 4.0 - 10.0 G/L";
            // 
            // txtWBC
            // 
            this.txtWBC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWBC.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtWBC.Location = new System.Drawing.Point(360, 125);
            this.txtWBC.Name = "txtWBC";
            this.txtWBC.Size = new System.Drawing.Size(280, 25);
            this.txtWBC.TabIndex = 5;
            this.txtWBC.Text = "7.2";
            // 
            // lblGlucose
            // 
            this.lblGlucose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGlucose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblGlucose.Location = new System.Drawing.Point(24, 180);
            this.lblGlucose.Name = "lblGlucose";
            this.lblGlucose.Size = new System.Drawing.Size(300, 22);
            this.lblGlucose.TabIndex = 6;
            this.lblGlucose.Text = "Đường huyết (Glucose) - T.chuẩn: 3.9 - 6.4 mmol/L";
            // 
            // txtGlucose
            // 
            this.txtGlucose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGlucose.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGlucose.Location = new System.Drawing.Point(24, 205);
            this.txtGlucose.Name = "txtGlucose";
            this.txtGlucose.Size = new System.Drawing.Size(280, 25);
            this.txtGlucose.TabIndex = 7;
            this.txtGlucose.Text = "5.6";
            // 
            // lblUricAcid
            // 
            this.lblUricAcid.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUricAcid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblUricAcid.Location = new System.Drawing.Point(360, 180);
            this.lblUricAcid.Name = "lblUricAcid";
            this.lblUricAcid.Size = new System.Drawing.Size(300, 22);
            this.lblUricAcid.TabIndex = 8;
            this.lblUricAcid.Text = "Acid Uric - T.chuẩn: 140 - 420 umol/L";
            // 
            // txtUricAcid
            // 
            this.txtUricAcid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUricAcid.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUricAcid.Location = new System.Drawing.Point(360, 205);
            this.txtUricAcid.Name = "txtUricAcid";
            this.txtUricAcid.Size = new System.Drawing.Size(280, 25);
            this.txtUricAcid.TabIndex = 9;
            this.txtUricAcid.Text = "310";
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
            this.btnSubmit.Location = new System.Drawing.Point(24, 290);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(1148, 44);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Lưu chỉ số xét nghiệm & Xác nhận kết quả";
            this.btnSubmit.UseVisualStyleBackColor = false;
            // 
            // ucTechnicianLabResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianLabResult";
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.ucTechnicianLabResult_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianLabResult_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlContainer;
        private System.Windows.Forms.Label lblSelectRequestTitle;
        private System.Windows.Forms.ComboBox cboLabRequests;
        private System.Windows.Forms.Label lblRBC;
        private System.Windows.Forms.TextBox txtRBC;
        private System.Windows.Forms.Label lblWBC;
        private System.Windows.Forms.TextBox txtWBC;
        private System.Windows.Forms.Label lblGlucose;
        private System.Windows.Forms.TextBox txtGlucose;
        private System.Windows.Forms.Label lblUricAcid;
        private System.Windows.Forms.TextBox txtUricAcid;
        private System.Windows.Forms.Button btnSubmit;
    }
}
