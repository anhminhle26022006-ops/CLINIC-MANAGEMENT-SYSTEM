using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmAddUser
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
            sep1 = new Panel();
            panelBody = new Panel();
            // Row 1
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblDisplayName = new Label();
            txtDisplayName = new TextBox();
            // Row 2
            lblRole = new Label();
            cboRole = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            // Row 3
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            // Row 4
            lblStatus = new Label();
            cboStatus = new ComboBox();
            sep2 = new Panel();
            panelFooter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();

            panelTitle.SuspendLayout();
            panelBody.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new System.Drawing.Size(680, 500);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Name = "frmAddUser";
            Text = "Thêm tài khoản mới";
            Font = new Font("Segoe UI", 10F);

            // panelTitle
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Height = 64;
            panelTitle.BackColor = Color.White;
            panelTitle.Padding = new Padding(24, 0, 0, 0);
            panelTitle.Controls.Add(lblTitle);

            lblTitle.Text = "Thêm tài khoản mới";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // sep1
            sep1.Dock = DockStyle.Top;
            sep1.Height = 1;
            sep1.BackColor = Color.FromArgb(229, 231, 235);

            // panelBody
            panelBody.Dock = DockStyle.Fill;
            panelBody.BackColor = Color.White;
            panelBody.Padding = new Padding(24, 16, 24, 0);

            int col1 = 24, col2 = 348;
            int row1 = 16, row2 = 104, row3 = 192, row4 = 280;
            int fieldW = 296, fieldH = 40;

            // Row 1: Username | Tên hiển thị
            AddLabel(panelBody, lblUsername, "Username *", col1, row1);
            AddTextBox(panelBody, txtUsername, col1, row1 + 24, fieldW, fieldH);
            AddLabel(panelBody, lblDisplayName, "Tên hiển thị *", col2, row1);
            AddTextBox(panelBody, txtDisplayName, col2, row1 + 24, fieldW, fieldH);

            // Row 2: Vai trò | Email
            AddLabel(panelBody, lblRole, "Vai trò *", col1, row2);
            cboRole.Location = new System.Drawing.Point(col1, row2 + 24);
            cboRole.Size = new System.Drawing.Size(fieldW, fieldH);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.Items.AddRange(new object[] { "Chọn vai trò", "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" });
            cboRole.SelectedIndex = 0;
            panelBody.Controls.Add(cboRole);

            AddLabel(panelBody, lblEmail, "Email *", col2, row2);
            txtEmail.PlaceholderText = "email@phongkham.vn";
            AddTextBox(panelBody, txtEmail, col2, row2 + 24, fieldW, fieldH);

            // Row 3: Mật khẩu | Xác nhận mật khẩu
            AddLabel(panelBody, lblPassword, "Mật khẩu *", col1, row3);
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "Nhập mật khẩu";
            AddTextBox(panelBody, txtPassword, col1, row3 + 24, fieldW, fieldH);

            AddLabel(panelBody, lblConfirmPassword, "Xác nhận mật khẩu *", col2, row3);
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.PlaceholderText = "Nhập lại mật khẩu";
            AddTextBox(panelBody, txtConfirmPassword, col2, row3 + 24, fieldW, fieldH);

            // Row 4: Trạng thái
            AddLabel(panelBody, lblStatus, "Trạng thái", col1, row4);
            cboStatus.Location = new System.Drawing.Point(col1, row4 + 24);
            cboStatus.Size = new System.Drawing.Size(fieldW * 2 + 28, fieldH);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.Items.AddRange(new object[] { "Hoạt động", "Tạm khóa" });
            cboStatus.SelectedIndex = 0;
            panelBody.Controls.Add(cboStatus);

            // sep2
            sep2.Dock = DockStyle.Bottom;
            sep2.Height = 1;
            sep2.BackColor = Color.FromArgb(229, 231, 235);

            // panelFooter
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 64;
            panelFooter.BackColor = Color.White;

            btnCancel.Text = "Hủy";
            btnCancel.Size = new System.Drawing.Size(90, 36);
            btnCancel.Location = new System.Drawing.Point(474, 14);
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            btnSave.Text = "Thêm tài khoản";
            btnSave.Size = new System.Drawing.Size(140, 36);
            btnSave.Location = new System.Drawing.Point(574, 14);
            btnSave.BackColor = Color.FromArgb(47, 94, 240);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);

            Controls.Add(panelBody);
            Controls.Add(sep2);
            Controls.Add(sep1);
            Controls.Add(panelTitle);
            Controls.Add(panelFooter);

            panelTitle.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void AddLabel(Panel p, Label lbl, string text, int x, int y)
        {
            lbl.Text = text;
            lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9.5F);
            lbl.ForeColor = Color.FromArgb(55, 65, 81);
            p.Controls.Add(lbl);
        }

        private void AddTextBox(Panel p, TextBox tb, int x, int y, int w, int h)
        {
            tb.Location = new System.Drawing.Point(x, y);
            tb.Size = new System.Drawing.Size(w, h);
            tb.Font = new Font("Segoe UI", 10F);
            tb.BorderStyle = BorderStyle.FixedSingle;
            p.Controls.Add(tb);
        }

        private Panel panelTitle, panelBody, panelFooter, sep1, sep2;
        private Label lblTitle;
        private Label lblUsername, lblDisplayName, lblRole, lblEmail;
        private Label lblPassword, lblConfirmPassword, lblStatus;
        private TextBox txtUsername, txtDisplayName, txtEmail;
        private TextBox txtPassword, txtConfirmPassword;
        private ComboBox cboRole, cboStatus;
        private Button btnSave, btnCancel;
    }
}