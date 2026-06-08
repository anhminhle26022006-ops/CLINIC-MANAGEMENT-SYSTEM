namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    partial class ucPatientRecords
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
            this.tblSplit = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLeft = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.txtRecordSearch = new System.Windows.Forms.TextBox();
            this.flpPatients = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRight = new ClinicManagementSystem.Winforms.Forms.RoundedPanel();
            this.lblHeart = new System.Windows.Forms.Label();
            this.lblNotice1 = new System.Windows.Forms.Label();
            this.lblNotice2 = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPatientMeta = new System.Windows.Forms.Label();
            this.lblPatientContact = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.flpHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.viewHostPanel.SuspendLayout();
            this.tblSplit.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.AutoScroll = true;
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Controls.Add(this.tblSplit);
            this.viewHostPanel.Controls.Add(this.lblSubtitle);
            this.viewHostPanel.Controls.Add(this.lblTitle);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.viewHostPanel.Location = new System.Drawing.Point(0, 0);
            this.viewHostPanel.Name = "viewHostPanel";
            this.viewHostPanel.Size = new System.Drawing.Size(1500, 900);
            this.viewHostPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hồ Sơ Bệnh Án";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblSubtitle.Location = new System.Drawing.Point(24, 56);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(1320, 34);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Xem hồ sơ bệnh án, lịch sử chụp phim và kết quả xét nghiệm của bệnh nhân";
            // 
            // tblSplit
            // 
            this.tblSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblSplit.ColumnCount = 2;
            this.tblSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblSplit.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblSplit.Controls.Add(this.pnlLeft, 0, 0);
            this.tblSplit.Controls.Add(this.pnlRight, 1, 0);
            this.tblSplit.Location = new System.Drawing.Point(24, 96);
            this.tblSplit.Name = "tblSplit";
            this.tblSplit.RowCount = 1;
            this.tblSplit.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSplit.Size = new System.Drawing.Size(1452, 760);
            this.tblSplit.TabIndex = 2;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlLeft.Controls.Add(this.flpPatients);
            this.pnlLeft.Controls.Add(this.txtRecordSearch);
            this.pnlLeft.CornerRadius = 8;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.FillColor = System.Drawing.Color.White;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(564, 760);
            this.pnlLeft.TabIndex = 0;
            // 
            // txtRecordSearch
            // 
            this.txtRecordSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecordSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecordSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecordSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.txtRecordSearch.Location = new System.Drawing.Point(18, 22);
            this.txtRecordSearch.Name = "txtRecordSearch";
            this.txtRecordSearch.Size = new System.Drawing.Size(528, 25);
            this.txtRecordSearch.TabIndex = 0;
            this.txtRecordSearch.Text = "Tìm kiếm bệnh nhân...";
            // 
            // flpPatients
            // 
            this.flpPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpPatients.AutoScroll = true;
            this.flpPatients.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPatients.Location = new System.Drawing.Point(18, 64);
            this.flpPatients.Name = "flpPatients";
            this.flpPatients.Size = new System.Drawing.Size(528, 678);
            this.flpPatients.TabIndex = 1;
            this.flpPatients.WrapContents = false;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.pnlRight.Controls.Add(this.flpHistory);
            this.pnlRight.Controls.Add(this.lblHistoryTitle);
            this.pnlRight.Controls.Add(this.lblPatientContact);
            this.pnlRight.Controls.Add(this.lblPatientMeta);
            this.pnlRight.Controls.Add(this.lblPatientName);
            this.pnlRight.Controls.Add(this.lblNotice2);
            this.pnlRight.Controls.Add(this.lblNotice1);
            this.pnlRight.Controls.Add(this.lblHeart);
            this.pnlRight.CornerRadius = 8;
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.FillColor = System.Drawing.Color.White;
            this.pnlRight.Location = new System.Drawing.Point(596, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(856, 760);
            this.pnlRight.TabIndex = 1;
            // 
            // lblHeart
            // 
            this.lblHeart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeart.Font = new System.Drawing.Font("Segoe UI", 52F);
            this.lblHeart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblHeart.Location = new System.Drawing.Point(0, 100);
            this.lblHeart.Name = "lblHeart";
            this.lblHeart.Size = new System.Drawing.Size(856, 70);
            this.lblHeart.TabIndex = 0;
            this.lblHeart.Text = "♡";
            this.lblHeart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotice1
            // 
            this.lblNotice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotice1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblNotice1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblNotice1.Location = new System.Drawing.Point(0, 180);
            this.lblNotice1.Name = "lblNotice1";
            this.lblNotice1.Size = new System.Drawing.Size(856, 32);
            this.lblNotice1.TabIndex = 1;
            this.lblNotice1.Text = "Chọn bệnh nhân để xem lịch sử hồ sơ bệnh án";
            this.lblNotice1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNotice2
            // 
            this.lblNotice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotice2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNotice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblNotice2.Location = new System.Drawing.Point(0, 218);
            this.lblNotice2.Name = "lblNotice2";
            this.lblNotice2.Size = new System.Drawing.Size(856, 28);
            this.lblNotice2.TabIndex = 2;
            this.lblNotice2.Text = "Danh sách bệnh nhân đăng ký hiển thị phía bên trái";
            this.lblNotice2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientName
            // 
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblPatientName.Location = new System.Drawing.Point(24, 24);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(808, 34);
            this.lblPatientName.TabIndex = 3;
            this.lblPatientName.Text = "Tên Bệnh Nhân";
            this.lblPatientName.Visible = false;
            // 
            // lblPatientMeta
            // 
            this.lblPatientMeta.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPatientMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPatientMeta.Location = new System.Drawing.Point(24, 58);
            this.lblPatientMeta.Name = "lblPatientMeta";
            this.lblPatientMeta.Size = new System.Drawing.Size(808, 26);
            this.lblPatientMeta.TabIndex = 4;
            this.lblPatientMeta.Text = "Mã BN: - | Giới tính: - | Tuổi: -";
            this.lblPatientMeta.Visible = false;
            // 
            // lblPatientContact
            // 
            this.lblPatientContact.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPatientContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblPatientContact.Location = new System.Drawing.Point(24, 82);
            this.lblPatientContact.Name = "lblPatientContact";
            this.lblPatientContact.Size = new System.Drawing.Size(808, 26);
            this.lblPatientContact.TabIndex = 5;
            this.lblPatientContact.Text = "SĐT: - | Địa chỉ: -";
            this.lblPatientContact.Visible = false;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(94)))), ((int)(((byte)(240)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(24, 130);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(808, 24);
            this.lblHistoryTitle.TabIndex = 6;
            this.lblHistoryTitle.Text = "LỊCH SỬ KẾT QUẢ XÉT NGHIỆM";
            this.lblHistoryTitle.Visible = false;
            // 
            // flpHistory
            // 
            this.flpHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpHistory.AutoScroll = true;
            this.flpHistory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpHistory.Location = new System.Drawing.Point(24, 170);
            this.flpHistory.Name = "flpHistory";
            this.flpHistory.Size = new System.Drawing.Size(808, 570);
            this.flpHistory.TabIndex = 7;
            this.flpHistory.Visible = false;
            this.flpHistory.WrapContents = false;
            // 
            // ucPatientRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucPatientRecords";
            this.Size = new System.Drawing.Size(1500, 900);
            this.Load += new System.EventHandler(this.ucPatientRecords_Load);
            this.Resize += new System.EventHandler(this.ucPatientRecords_Resize);
            this.viewHostPanel.ResumeLayout(false);
            this.tblSplit.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private ClinicManagementSystem.Winforms.Forms.RoundedPanel viewHostPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel tblSplit;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlLeft;
        private System.Windows.Forms.TextBox txtRecordSearch;
        private System.Windows.Forms.FlowLayoutPanel flpPatients;
        private ClinicManagementSystem.Winforms.Forms.RoundedPanel pnlRight;
        private System.Windows.Forms.Label lblHeart;
        private System.Windows.Forms.Label lblNotice1;
        private System.Windows.Forms.Label lblNotice2;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientMeta;
        private System.Windows.Forms.Label lblPatientContact;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.FlowLayoutPanel flpHistory;
    }
}
