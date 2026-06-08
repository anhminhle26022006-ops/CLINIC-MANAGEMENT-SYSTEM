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
            btnClose = new Button();
            sep1 = new Panel();
            panelBody = new Panel();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblDisplayName = new Label();
            txtDisplayName = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
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

            // ── Hằng số layout ────────────────────────────────────────
            // Form: 700 × 530, FormBorderStyle.None
            // padding: 32 hai bên | 2 cột, gap 24
            // colW = (700 - 32 - 32 - 24) / 2 = 306
            const int formW = 700;
            const int padL = 32;
            const int padR = 32;
            const int colW = 306;
            const int colGap = 24;
            const int col2 = padL + colW + colGap;   // 362
            const int fieldH = 42;
            const int lblH = 20;
            const int iGap = 8;   // label → control
            const int rowGap = 24;  // control → label bên dưới

            // Header 64px + divider 1px → body từ Y=65
            const int bodyTop = 65;
            const int row1L = bodyTop + 20;
            const int row1C = row1L + lblH + iGap;
            const int row2L = row1C + fieldH + rowGap;
            const int row2C = row2L + lblH + iGap;
            const int row3L = row2C + fieldH + rowGap;
            const int row3C = row3L + lblH + iGap;
            const int row4L = row3C + fieldH + rowGap;
            const int row4C = row4L + lblH + iGap;

            // formH = row4C + fieldH + footerH + gap
            const int footerH = 72;
            int bodyEnd = row4C + fieldH + 24;
            int formH = bodyEnd + footerH;   // ~530

            // ── Form ──────────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new System.Drawing.Size(formW, formH);
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            Name = "frmAddUser";
            Text = "Thêm tài khoản mới";
            Font = new Font("Segoe UI", 10F);

            // ── Header ────────────────────────────────────────────────
            panelTitle.Location = new System.Drawing.Point(0, 0);
            panelTitle.Size = new System.Drawing.Size(formW, 64);
            panelTitle.BackColor = Color.White;

            lblTitle.Text = "Thêm tài khoản mới";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new System.Drawing.Point(padL, 18);
            lblTitle.AutoSize = true;

            btnClose.Text = "✕";
            btnClose.Font = new Font("Segoe UI", 11F);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = Color.Transparent;
            btnClose.ForeColor = Color.FromArgb(107, 114, 128);
            btnClose.Size = new System.Drawing.Size(32, 32);
            btnClose.Location = new System.Drawing.Point(formW - 44, 16);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += btnCancel_Click;

            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(btnClose);

            // ── Divider dưới header ───────────────────────────────────
            sep1.Location = new System.Drawing.Point(0, 64);
            sep1.Size = new System.Drawing.Size(formW, 1);
            sep1.BackColor = Color.FromArgb(229, 231, 235);

            // ── panelBody (transparent — controls đặt thẳng vào form) ─
            // Không dùng panelBody.Dock để tránh offset toạ độ con
            panelBody.Location = new System.Drawing.Point(0, 65);
            panelBody.Size = new System.Drawing.Size(formW, bodyEnd - 65);
            panelBody.BackColor = Color.White;

            // Row 1: Username | Tên hiển thị
            AddLabel(panelBody, lblUsername, "Username *", padL, row1L - 65);
            AddField(panelBody, txtUsername, padL, row1C - 65, colW, fieldH, "Nhập username");

            AddLabel(panelBody, lblDisplayName, "Tên hiển thị *", col2, row1L - 65);
            AddField(panelBody, txtDisplayName, col2, row1C - 65, colW, fieldH, "Nhập tên hiển thị");

            // Row 2: Vai trò | Email
            AddLabel(panelBody, lblRole, "Vai trò *", padL, row2L - 65);
            cboRole.Location = new System.Drawing.Point(padL, row2C - 65);
            cboRole.Size = new System.Drawing.Size(colW, fieldH);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.Font = new Font("Segoe UI", 10F);
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.Items.AddRange(new object[] { "Chọn vai trò", "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" });
            cboRole.SelectedIndex = 0;
            panelBody.Controls.Add(cboRole);

            AddLabel(panelBody, lblEmail, "Email *", col2, row2L - 65);
            AddField(panelBody, txtEmail, col2, row2C - 65, colW, fieldH, "email@phongkham.vn");

            // Row 3: Mật khẩu | Xác nhận mật khẩu
            AddLabel(panelBody, lblPassword, "Mật khẩu *", padL, row3L - 65);
            txtPassword.PasswordChar = '●';
            AddField(panelBody, txtPassword, padL, row3C - 65, colW, fieldH, "Nhập mật khẩu");

            AddLabel(panelBody, lblConfirmPassword, "Xác nhận mật khẩu *", col2, row3L - 65);
            txtConfirmPassword.PasswordChar = '●';
            AddField(panelBody, txtConfirmPassword, col2, row3C - 65, colW, fieldH, "Nhập lại mật khẩu");

            // Row 4: Trạng thái (full width)
            AddLabel(panelBody, lblStatus, "Trạng thái", padL, row4L - 65);
            cboStatus.Location = new System.Drawing.Point(padL, row4C - 65);
            cboStatus.Size = new System.Drawing.Size(colW * 2 + colGap, fieldH);   // full width
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.Items.AddRange(new object[] { "Hoạt động", "Tạm khóa" });
            cboStatus.SelectedIndex = 0;
            panelBody.Controls.Add(cboStatus);

            // ── Divider trên footer ───────────────────────────────────
            sep2.Location = new System.Drawing.Point(0, formH - footerH - 1);
            sep2.Size = new System.Drawing.Size(formW, 1);
            sep2.BackColor = Color.FromArgb(229, 231, 235);

            // ── Footer ────────────────────────────────────────────────
            panelFooter.Location = new System.Drawing.Point(0, formH - footerH);
            panelFooter.Size = new System.Drawing.Size(formW, footerH);
            panelFooter.BackColor = Color.White;

            // Tính X nút từ phải: [padR] [btnSave=148] [gap=12] [btnCancel=90]
            const int btnSaveW = 148;
            const int btnCancelW = 90;
            const int btnGap = 12;
            const int btnH = 40;
            const int btnY = 16;
            int btnSaveX = formW - padR - btnSaveW;            // 700-32-148 = 520
            int btnCancelX = btnSaveX - btnGap - btnCancelW;     // 520-12-90  = 418

            btnCancel.Text = "Hủy";
            btnCancel.Size = new System.Drawing.Size(btnCancelW, btnH);
            btnCancel.Location = new System.Drawing.Point(btnCancelX, btnY);
            btnCancel.BackColor = Color.White;
            btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            btnSave.Text = "Thêm tài khoản";
            btnSave.Size = new System.Drawing.Size(btnSaveW, btnH);
            btnSave.Location = new System.Drawing.Point(btnSaveX, btnY);
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Click += btnSave_Click;

            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);

            // ── Add to form ───────────────────────────────────────────
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

        private void AddField(Panel p, TextBox tb, int x, int y, int w, int h, string placeholder = "")
        {
            tb.Location = new System.Drawing.Point(x, y);
            tb.Size = new System.Drawing.Size(w, h);
            tb.Font = new Font("Segoe UI", 10F);
            tb.BorderStyle = BorderStyle.FixedSingle;
            tb.PlaceholderText = placeholder;
            p.Controls.Add(tb);
        }

        private Panel panelTitle, panelBody, panelFooter, sep1, sep2;
        private Label lblTitle;
        private Button btnClose;
        private Label lblUsername, lblDisplayName, lblRole, lblEmail;
        private Label lblPassword, lblConfirmPassword, lblStatus;
        private TextBox txtUsername, txtDisplayName, txtEmail;
        private TextBox txtPassword, txtConfirmPassword;
        private ComboBox cboRole, cboStatus;
        private Button btnSave, btnCancel;
    }
}