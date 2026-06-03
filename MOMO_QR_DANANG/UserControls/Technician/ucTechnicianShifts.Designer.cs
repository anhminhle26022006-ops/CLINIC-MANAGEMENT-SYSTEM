namespace MOMO_QR_DANANG.UserControls.Technician
{
    partial class ucTechnicianShifts
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
            this.viewHostPanel = new System.Windows.Forms.Panel();
            this.designPreviewPanel = new System.Windows.Forms.Panel();
            this.lblDesignTitle = new System.Windows.Forms.Label();
            this.lblDesignSubtitle = new System.Windows.Forms.Label();
            this.lblDesignBlock1 = new System.Windows.Forms.Label();
            this.lblDesignBlock2 = new System.Windows.Forms.Label();
            this.lblDesignBlock3 = new System.Windows.Forms.Label();
            this.viewHostPanel.SuspendLayout();
            this.designPreviewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.designPreviewPanel);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 744);
            this.viewHostPanel.TabIndex = 0;
            // 
            // designPreviewPanel
            // 
            this.designPreviewPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.designPreviewPanel.Controls.Add(this.lblDesignBlock3);
            this.designPreviewPanel.Controls.Add(this.lblDesignBlock2);
            this.designPreviewPanel.Controls.Add(this.lblDesignBlock1);
            this.designPreviewPanel.Controls.Add(this.lblDesignSubtitle);
            this.designPreviewPanel.Controls.Add(this.lblDesignTitle);
            this.designPreviewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.designPreviewPanel.Location = new System.Drawing.Point(0, 0);
            this.designPreviewPanel.Name = "designPreviewPanel";
            this.designPreviewPanel.Padding = new System.Windows.Forms.Padding(32);
            this.designPreviewPanel.Size = new System.Drawing.Size(1244, 744);
            this.designPreviewPanel.TabIndex = 0;
            // 
            // lblDesignTitle
            // 
            this.lblDesignTitle.AutoSize = false;
            this.lblDesignTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDesignTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblDesignTitle.Location = new System.Drawing.Point(32, 32);
            this.lblDesignTitle.Name = "lblDesignTitle";
            this.lblDesignTitle.Size = new System.Drawing.Size(760, 44);
            this.lblDesignTitle.TabIndex = 0;
            this.lblDesignTitle.Text = "Ca làm việc";
            // 
            // lblDesignSubtitle
            // 
            this.lblDesignSubtitle.AutoSize = false;
            this.lblDesignSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDesignSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblDesignSubtitle.Location = new System.Drawing.Point(34, 78);
            this.lblDesignSubtitle.Name = "lblDesignSubtitle";
            this.lblDesignSubtitle.Size = new System.Drawing.Size(900, 28);
            this.lblDesignSubtitle.TabIndex = 1;
            this.lblDesignSubtitle.Text = "Lịch trực và đăng ký ca làm của kỹ thuật viên";
            // 
            // lblDesignBlock1
            // 
            this.lblDesignBlock1.BackColor = System.Drawing.Color.White;
            this.lblDesignBlock1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesignBlock1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesignBlock1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblDesignBlock1.Location = new System.Drawing.Point(32, 150);
            this.lblDesignBlock1.Name = "lblDesignBlock1";
            this.lblDesignBlock1.Size = new System.Drawing.Size(360, 72);
            this.lblDesignBlock1.TabIndex = 3;
            this.lblDesignBlock1.Text = "Lịch tuần";
            this.lblDesignBlock1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;            // 
            // lblDesignBlock2
            // 
            this.lblDesignBlock2.BackColor = System.Drawing.Color.White;
            this.lblDesignBlock2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesignBlock2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesignBlock2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblDesignBlock2.Location = new System.Drawing.Point(32, 242);
            this.lblDesignBlock2.Name = "lblDesignBlock2";
            this.lblDesignBlock2.Size = new System.Drawing.Size(360, 72);
            this.lblDesignBlock2.TabIndex = 4;
            this.lblDesignBlock2.Text = "Danh sách ca";
            this.lblDesignBlock2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;            // 
            // lblDesignBlock3
            // 
            this.lblDesignBlock3.BackColor = System.Drawing.Color.White;
            this.lblDesignBlock3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesignBlock3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDesignBlock3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblDesignBlock3.Location = new System.Drawing.Point(32, 334);
            this.lblDesignBlock3.Name = "lblDesignBlock3";
            this.lblDesignBlock3.Size = new System.Drawing.Size(360, 72);
            this.lblDesignBlock3.TabIndex = 5;
            this.lblDesignBlock3.Text = "Đăng ký ca mới";
            this.lblDesignBlock3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;            // 
            // ucTechnicianShifts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucTechnicianShifts";
            this.Size = new System.Drawing.Size(1244, 744);
            this.Load += new System.EventHandler(this.ucTechnicianShifts_Load);
            this.Resize += new System.EventHandler(this.ucTechnicianShifts_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.designPreviewPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel viewHostPanel;
        private System.Windows.Forms.Panel designPreviewPanel;
        private System.Windows.Forms.Label lblDesignTitle;
        private System.Windows.Forms.Label lblDesignSubtitle;
        private System.Windows.Forms.Label lblDesignBlock1;
        private System.Windows.Forms.Label lblDesignBlock2;
        private System.Windows.Forms.Label lblDesignBlock3;
    }
}
