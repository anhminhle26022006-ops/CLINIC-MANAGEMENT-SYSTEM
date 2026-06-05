using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmViewUser
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTitle = new Panel();
            lblTitle = new Label();
            separator1 = new Panel();
            panelContent = new Panel();
            // Row 1: Username | Tên hiển thị
            lblUsername = new Label();
            lblUsernameVal = new Label();
            lblDisplayName = new Label();
            lblDisplayNameVal = new Label();
            sep1 = new Panel();
            // Row 2: Vai trò | Email
            lblRole = new Label();
            lblRoleVal = new Label();
            lblEmail = new Label();
            lblEmailVal = new Label();
            sep2 = new Panel();
            // Row 3: Trạng thái | Ngày tạo
            lblStatus = new Label();
            lblStatusVal = new Label();
            lblCreatedAt = new Label();
            lblCreatedAtVal = new Label();
            separator2 = new Panel();
            panelFooter = new Panel();
            btnClose = new Button();

            panelTitle.SuspendLayout();
            panelContent.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new System.Drawing.Size(620, 420);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "frmViewUser";
            Text = "Chi tiết tài khoản";
            Font = new Font("Segoe UI", 10F);

            // panelTitle
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Height = 64;
            panelTitle.BackColor = Color.White;
            panelTitle.Controls.Add(lblTitle);
            panelTitle.Padding = new Padding(24, 0, 0, 0);

            lblTitle.Text = "Chi tiết tài khoản";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // separator1
            separator1.Dock = DockStyle.Top;
            separator1.Height = 1;
            separator1.BackColor = Color.FromArgb(229, 231, 235);

            // panelContent
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor = Color.White;
            panelContent.Padding = new Padding(24, 20, 24, 0);
            panelContent.AutoScroll = true;

            // Row 1
            SetFieldLabel(lblUsername, "Username", new Point(24, 24));
            SetValueLabel(lblUsernameVal, new Point(24, 48));
            SetFieldLabel(lblDisplayName, "Tên hiển thị", new Point(320, 24));
            SetValueLabel(lblDisplayNameVal, new Point(320, 48));

            sep1.Location = new Point(24, 88); sep1.Size = new System.Drawing.Size(572, 1);
            sep1.BackColor = Color.FromArgb(229, 231, 235);

            // Row 2
            SetFieldLabel(lblRole, "Vai trò", new Point(24, 104));
            SetValueLabel(lblRoleVal, new Point(24, 128));
            SetFieldLabel(lblEmail, "Email", new Point(320, 104));
            SetValueLabel(lblEmailVal, new Point(320, 128));

            sep2.Location = new Point(24, 168); sep2.Size = new System.Drawing.Size(572, 1);
            sep2.BackColor = Color.FromArgb(229, 231, 235);

            // Row 3
            SetFieldLabel(lblStatus, "Trạng thái", new Point(24, 184));
            // lblStatusVal — badge style
            lblStatusVal.Location = new Point(24, 210);
            lblStatusVal.AutoSize = true;
            lblStatusVal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusVal.Padding = new Padding(8, 3, 8, 3);

            SetFieldLabel(lblCreatedAt, "Ngày tạo", new Point(320, 184));
            SetValueLabel(lblCreatedAtVal, new Point(320, 210));

            panelContent.Controls.Add(lblUsername);
            panelContent.Controls.Add(lblUsernameVal);
            panelContent.Controls.Add(lblDisplayName);
            panelContent.Controls.Add(lblDisplayNameVal);
            panelContent.Controls.Add(sep1);
            panelContent.Controls.Add(lblRole);
            panelContent.Controls.Add(lblRoleVal);
            panelContent.Controls.Add(lblEmail);
            panelContent.Controls.Add(lblEmailVal);
            panelContent.Controls.Add(sep2);
            panelContent.Controls.Add(lblStatus);
            panelContent.Controls.Add(lblStatusVal);
            panelContent.Controls.Add(lblCreatedAt);
            panelContent.Controls.Add(lblCreatedAtVal);

            // separator2
            separator2.Dock = DockStyle.Bottom;
            separator2.Height = 1;
            separator2.BackColor = Color.FromArgb(229, 231, 235);

            // panelFooter
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 64;
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(btnClose);

            btnClose.Text = "Đóng";
            btnClose.Size = new System.Drawing.Size(90, 36);
            btnClose.Location = new Point(506, 14);
            btnClose.BackColor = Color.White;
            btnClose.ForeColor = Color.FromArgb(55, 65, 81);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.Click += new System.EventHandler(this.btnClose_Click);

            Controls.Add(panelContent);
            Controls.Add(separator2);
            Controls.Add(separator1);
            Controls.Add(panelTitle);
            Controls.Add(panelFooter);

            panelTitle.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetFieldLabel(Label lbl, string text, System.Drawing.Point loc)
        {
            lbl.Text = text;
            lbl.Location = loc;
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(107, 114, 128);
        }

        private void SetValueLabel(Label lbl, System.Drawing.Point loc)
        {
            lbl.Location = loc;
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(17, 24, 39);
        }

        private Panel panelTitle, panelContent, panelFooter;
        private Panel separator1, separator2, sep1, sep2;
        private Label lblTitle;
        private Label lblUsername, lblUsernameVal;
        private Label lblDisplayName, lblDisplayNameVal;
        private Label lblRole, lblRoleVal;
        private Label lblEmail, lblEmailVal;
        private Label lblStatus, lblStatusVal;
        private Label lblCreatedAt, lblCreatedAtVal;
        private Button btnClose;
    }
}