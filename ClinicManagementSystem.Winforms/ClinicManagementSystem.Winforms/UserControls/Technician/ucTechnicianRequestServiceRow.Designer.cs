namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucTechnicianRequestServiceRow
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
            this.lblServiceType = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Button();
            this.pnlBottomLine = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblServiceType
            // 
            this.lblServiceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceType.AutoEllipsis = true;
            this.lblServiceType.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblServiceType.Location = new System.Drawing.Point(16, 18);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(320, 36);
            this.lblServiceType.TabIndex = 0;
            this.lblServiceType.Text = "Xét nghiệm máu tổng quát";
            this.lblServiceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNote.AutoEllipsis = true;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNote.Location = new System.Drawing.Point(350, 19);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(225, 34);
            this.lblNote.TabIndex = 1;
            this.lblNote.Text = "Không có ghi chú";
            this.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.lblPriority.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.lblPriority.Location = new System.Drawing.Point(594, 18);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(108, 34);
            this.lblPriority.TabIndex = 2;
            this.lblPriority.Text = "Thường";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.lblStatus.Location = new System.Drawing.Point(720, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(132, 34);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Hoàn thành";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAction
            // 
            this.btnAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(252)))), ((int)(((byte)(231)))));
            this.btnAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnAction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(74)))));
            this.btnAction.Location = new System.Drawing.Point(867, 18);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(120, 34);
            this.btnAction.TabIndex = 4;
            this.btnAction.Text = "Xem";
            this.btnAction.UseVisualStyleBackColor = false;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // pnlBottomLine
            // 
            this.pnlBottomLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottomLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlBottomLine.Location = new System.Drawing.Point(16, 77);
            this.pnlBottomLine.Name = "pnlBottomLine";
            this.pnlBottomLine.Size = new System.Drawing.Size(971, 1);
            this.pnlBottomLine.TabIndex = 5;
            // 
            // ucTechnicianRequestServiceRow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(250)))), ((int)(((byte)(251)))));
            this.Controls.Add(this.pnlBottomLine);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPriority);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lblServiceType);
            this.Name = "ucTechnicianRequestServiceRow";
            this.Size = new System.Drawing.Size(1004, 78);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Panel pnlBottomLine;
    }
}
