namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucLabCard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;

        private System.Windows.Forms.Label lblTestType;

        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDate;

        private System.Windows.Forms.Label lblDoctorTitle;
        private System.Windows.Forms.Label lblDoctor;

        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblStatus;

        private System.Windows.Forms.Button btnDownload;

        private System.Windows.Forms.TableLayoutPanel tblResults;

        private System.Windows.Forms.Panel pnlWBC;
        private System.Windows.Forms.Panel pnlRBC;
        private System.Windows.Forms.Panel pnlHGB;
        private System.Windows.Forms.Panel pnlPLT;

        private System.Windows.Forms.Label lblWBCTitle;
        private System.Windows.Forms.Label lblWBCValue;

        private System.Windows.Forms.Label lblRBCTitle;
        private System.Windows.Forms.Label lblRBCValue;

        private System.Windows.Forms.Label lblHGBTitle;
        private System.Windows.Forms.Label lblHGBValue;

        private System.Windows.Forms.Label lblPLTTitle;
        private System.Windows.Forms.Label lblPLTValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTestType = new Label();
            btnDownload = new Button();
            lblDateTitle = new Label();
            lblDate = new Label();
            lblDoctorTitle = new Label();
            lblDoctor = new Label();
            lblStatusTitle = new Label();
            lblStatus = new Label();
            tblResults = new TableLayoutPanel();
            pnlWBC = new Panel();
            lblWBCTitle = new Label();
            lblWBCValue = new Label();
            pnlRBC = new Panel();
            lblRBCTitle = new Label();
            lblRBCValue = new Label();
            pnlHGB = new Panel();
            lblHGBTitle = new Label();
            lblHGBValue = new Label();
            pnlPLT = new Panel();
            lblPLTTitle = new Label();
            lblPLTValue = new Label();
            pnlHeader.SuspendLayout();
            tblResults.SuspendLayout();
            pnlWBC.SuspendLayout();
            pnlRBC.SuspendLayout();
            pnlHGB.SuspendLayout();
            pnlPLT.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTestType);
            pnlHeader.Controls.Add(btnDownload);
            pnlHeader.Controls.Add(lblDateTitle);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblDoctorTitle);
            pnlHeader.Controls.Add(lblDoctor);
            pnlHeader.Controls.Add(lblStatusTitle);
            pnlHeader.Controls.Add(lblStatus);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1150, 120);
            pnlHeader.TabIndex = 1;
            // 
            // lblTestType
            // 
            lblTestType.AutoSize = true;
            lblTestType.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTestType.Location = new Point(15, 15);
            lblTestType.Name = "lblTestType";
            lblTestType.Size = new Size(49, 28);
            lblTestType.TabIndex = 0;
            lblTestType.Text = "CBC";
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.RoyalBlue;
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(1010, 15);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(110, 35);
            btnDownload.TabIndex = 1;
            btnDownload.Text = "Tải về";
            btnDownload.UseVisualStyleBackColor = false;
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Location = new Point(15, 60);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(47, 20);
            lblDateTitle.TabIndex = 2;
            lblDateTitle.Text = "Ngày:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(68, 60);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "07/06/2026";
            // 
            // lblDoctorTitle
            // 
            lblDoctorTitle.AutoSize = true;
            lblDoctorTitle.Location = new Point(250, 60);
            lblDoctorTitle.Name = "lblDoctorTitle";
            lblDoctorTitle.Size = new Size(29, 20);
            lblDoctorTitle.TabIndex = 4;
            lblDoctorTitle.Text = "BS:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(285, 60);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(95, 20);
            lblDoctor.TabIndex = 5;
            lblDoctor.Text = "BS Trần Minh";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Location = new Point(500, 60);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(52, 20);
            lblStatusTitle.TabIndex = 6;
            lblStatusTitle.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(560, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(83, 20);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Completed";
            // 
            // tblResults
            // 
            tblResults.ColumnCount = 2;
            tblResults.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblResults.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblResults.Controls.Add(pnlWBC, 0, 0);
            tblResults.Controls.Add(pnlRBC, 1, 0);
            tblResults.Controls.Add(pnlHGB, 0, 1);
            tblResults.Controls.Add(pnlPLT, 1, 1);
            tblResults.Dock = DockStyle.Fill;
            tblResults.Location = new Point(0, 120);
            tblResults.Name = "tblResults";
            tblResults.Padding = new Padding(20);
            tblResults.RowCount = 2;
            tblResults.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblResults.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblResults.Size = new Size(1150, 349);
            tblResults.TabIndex = 0;
            // 
            // pnlWBC
            // 
            pnlWBC.BorderStyle = BorderStyle.FixedSingle;
            pnlWBC.Controls.Add(lblWBCTitle);
            pnlWBC.Controls.Add(lblWBCValue);
            pnlWBC.Dock = DockStyle.Fill;
            pnlWBC.Location = new Point(23, 23);
            pnlWBC.Name = "pnlWBC";
            pnlWBC.Size = new Size(549, 148);
            pnlWBC.TabIndex = 0;
            // 
            // lblWBCTitle
            // 
            lblWBCTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblWBCTitle.Location = new Point(15, 15);
            lblWBCTitle.Name = "lblWBCTitle";
            lblWBCTitle.Size = new Size(100, 23);
            lblWBCTitle.TabIndex = 0;
            lblWBCTitle.Text = "WBC";
            // 
            // lblWBCValue
            // 
            lblWBCValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblWBCValue.Location = new Point(15, 55);
            lblWBCValue.Name = "lblWBCValue";
            lblWBCValue.Size = new Size(100, 46);
            lblWBCValue.TabIndex = 1;
            lblWBCValue.Text = "8.5";
            // 
            // pnlRBC
            // 
            pnlRBC.BorderStyle = BorderStyle.FixedSingle;
            pnlRBC.Controls.Add(lblRBCTitle);
            pnlRBC.Controls.Add(lblRBCValue);
            pnlRBC.Dock = DockStyle.Fill;
            pnlRBC.Location = new Point(578, 23);
            pnlRBC.Name = "pnlRBC";
            pnlRBC.Size = new Size(549, 148);
            pnlRBC.TabIndex = 1;
            // 
            // lblRBCTitle
            // 
            lblRBCTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRBCTitle.Location = new Point(15, 15);
            lblRBCTitle.Name = "lblRBCTitle";
            lblRBCTitle.Size = new Size(100, 23);
            lblRBCTitle.TabIndex = 0;
            lblRBCTitle.Text = "RBC";
            // 
            // lblRBCValue
            // 
            lblRBCValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblRBCValue.Location = new Point(15, 55);
            lblRBCValue.Name = "lblRBCValue";
            lblRBCValue.Size = new Size(100, 46);
            lblRBCValue.TabIndex = 1;
            lblRBCValue.Text = "4.7";
            // 
            // pnlHGB
            // 
            pnlHGB.BorderStyle = BorderStyle.FixedSingle;
            pnlHGB.Controls.Add(lblHGBTitle);
            pnlHGB.Controls.Add(lblHGBValue);
            pnlHGB.Dock = DockStyle.Fill;
            pnlHGB.Location = new Point(23, 177);
            pnlHGB.Name = "pnlHGB";
            pnlHGB.Size = new Size(549, 149);
            pnlHGB.TabIndex = 2;
            // 
            // lblHGBTitle
            // 
            lblHGBTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHGBTitle.Location = new Point(15, 15);
            lblHGBTitle.Name = "lblHGBTitle";
            lblHGBTitle.Size = new Size(100, 23);
            lblHGBTitle.TabIndex = 0;
            lblHGBTitle.Text = "HGB";
            // 
            // lblHGBValue
            // 
            lblHGBValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblHGBValue.Location = new Point(15, 55);
            lblHGBValue.Name = "lblHGBValue";
            lblHGBValue.Size = new Size(100, 41);
            lblHGBValue.TabIndex = 1;
            lblHGBValue.Text = "14.2";
            // 
            // pnlPLT
            // 
            pnlPLT.BorderStyle = BorderStyle.FixedSingle;
            pnlPLT.Controls.Add(lblPLTTitle);
            pnlPLT.Controls.Add(lblPLTValue);
            pnlPLT.Dock = DockStyle.Fill;
            pnlPLT.Location = new Point(578, 177);
            pnlPLT.Name = "pnlPLT";
            pnlPLT.Size = new Size(549, 149);
            pnlPLT.TabIndex = 3;
            // 
            // lblPLTTitle
            // 
            lblPLTTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPLTTitle.Location = new Point(15, 15);
            lblPLTTitle.Name = "lblPLTTitle";
            lblPLTTitle.Size = new Size(100, 23);
            lblPLTTitle.TabIndex = 0;
            lblPLTTitle.Text = "PLT";
            // 
            // lblPLTValue
            // 
            lblPLTValue.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPLTValue.Location = new Point(15, 55);
            lblPLTValue.Name = "lblPLTValue";
            lblPLTValue.Size = new Size(100, 41);
            lblPLTValue.TabIndex = 1;
            lblPLTValue.Text = "250";
            // 
            // ucLabCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(tblResults);
            Controls.Add(pnlHeader);
            Name = "ucLabCard";
            Size = new Size(1150, 469);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tblResults.ResumeLayout(false);
            pnlWBC.ResumeLayout(false);
            pnlRBC.ResumeLayout(false);
            pnlHGB.ResumeLayout(false);
            pnlPLT.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}