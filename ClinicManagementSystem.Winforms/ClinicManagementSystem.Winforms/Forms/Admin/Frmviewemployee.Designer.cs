using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmViewEmployee
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTitle = new Panel();
            lblTitle = new Label();
            sep1 = new Panel();
            panelContent = new Panel();
            lblCode = new Label(); lblCodeVal = new Label();
            lblName = new Label(); lblNameVal = new Label();
            lblChucVu = new Label(); lblChucVuVal = new Label();
            lblKhoa = new Label(); lblKhoaVal = new Label();
            lblPhone = new Label(); lblPhoneVal = new Label();
            lblEmail = new Label(); lblEmailVal = new Label();
            lblStatus = new Label(); lblStatusVal = new Label();
            sep2 = new Panel();
            panelFooter = new Panel();
            btnClose = new Button();

            panelTitle.SuspendLayout();
            panelContent.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new System.Drawing.Size(620, 460);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết nhân viên";
            Font = new Font("Segoe UI", 10F);

            panelTitle.Dock = DockStyle.Top; panelTitle.Height = 64;
            panelTitle.BackColor = Color.White; panelTitle.Padding = new Padding(24, 0, 0, 0);
            panelTitle.Controls.Add(lblTitle);
            lblTitle.Text = "Chi tiết nhân viên";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            sep1.Dock = DockStyle.Top; sep1.Height = 1; sep1.BackColor = Color.FromArgb(229, 231, 235);

            panelContent.Dock = DockStyle.Fill; panelContent.BackColor = Color.White;

            int c1 = 24, c2 = 320, rh = 34;
            int y = 20;
            AddRow(panelContent, lblCode, "Mã nhân viên:", c1, y); AddVal(panelContent, lblCodeVal, c2, y); y += rh;
            AddRow(panelContent, lblName, "Họ tên:", c1, y); AddVal(panelContent, lblNameVal, c2, y); y += rh;
            AddRow(panelContent, lblChucVu, "Chức vụ:", c1, y); AddVal(panelContent, lblChucVuVal, c2, y); y += rh;
            AddRow(panelContent, lblKhoa, "Chuyên khoa:", c1, y); AddVal(panelContent, lblKhoaVal, c2, y); y += rh;
            AddRow(panelContent, lblPhone, "Số điện thoại:", c1, y); AddVal(panelContent, lblPhoneVal, c2, y); y += rh;
            AddRow(panelContent, lblEmail, "Email:", c1, y); AddVal(panelContent, lblEmailVal, c2, y); y += rh;
            AddRow(panelContent, lblStatus, "Trạng thái:", c1, y);
            lblStatusVal.Location = new System.Drawing.Point(c2, y);
            lblStatusVal.AutoSize = true;
            lblStatusVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusVal.Padding = new Padding(8, 3, 8, 3);
            panelContent.Controls.Add(lblStatusVal);

            sep2.Dock = DockStyle.Bottom; sep2.Height = 1; sep2.BackColor = Color.FromArgb(229, 231, 235);
            panelFooter.Dock = DockStyle.Bottom; panelFooter.Height = 64; panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnClose);

            btnClose.Text = "Đóng"; btnClose.Size = new System.Drawing.Size(90, 36);
            btnClose.Location = new System.Drawing.Point(506, 14);
            btnClose.BackColor = Color.White; btnClose.ForeColor = Color.FromArgb(55, 65, 81);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            Controls.Add(panelContent); Controls.Add(sep2); Controls.Add(sep1);
            Controls.Add(panelTitle); Controls.Add(panelFooter);

            panelTitle.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void AddRow(Panel p, Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true; lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(107, 114, 128);
            p.Controls.Add(lbl);
        }
        private void AddVal(Panel p, Label lbl, int x, int y)
        {
            lbl.Location = new System.Drawing.Point(x, y); lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(17, 24, 39);
            p.Controls.Add(lbl);
        }

        private Panel panelTitle, panelContent, panelFooter, sep1, sep2;
        private Label lblTitle;
        private Label lblCode, lblCodeVal, lblName, lblNameVal;
        private Label lblChucVu, lblChucVuVal, lblKhoa, lblKhoaVal;
        private Label lblPhone, lblPhoneVal, lblEmail, lblEmailVal;
        private Label lblStatus, lblStatusVal;
        private Button btnClose;
    }
}