using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmAddEmployee
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
            panelBody = new Panel();
            lblFullName = new Label(); txtFullName = new TextBox();
            lblChucVu = new Label(); cboChucVu = new ComboBox();
            lblKhoa = new Label(); cboKhoa = new ComboBox();
            lblPhone = new Label(); txtPhone = new TextBox();
            lblEmail = new Label(); txtEmail = new TextBox();
            lblGender = new Label(); cboGender = new ComboBox();
            sep2 = new Panel();
            panelFooter = new Panel();
            btnCancel = new Button();
            btnSave = new Button();

            panelTitle.SuspendLayout();
            panelBody.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new System.Drawing.Size(680, 480);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm nhân viên mới";
            Font = new Font("Segoe UI", 10F);

            panelTitle.Dock = DockStyle.Top; panelTitle.Height = 64;
            panelTitle.BackColor = Color.White; panelTitle.Padding = new Padding(24, 0, 0, 0);
            panelTitle.Controls.Add(lblTitle);
            lblTitle.Text = "Thêm nhân viên mới";
            lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            sep1.Dock = DockStyle.Top; sep1.Height = 1; sep1.BackColor = Color.FromArgb(229, 231, 235);

            panelBody.Dock = DockStyle.Fill; panelBody.BackColor = Color.White;
            panelBody.Padding = new Padding(24, 16, 24, 0);

            int c1 = 24, c2 = 360, w = 280, h = 36;

            // Row 1: Họ tên | Chức vụ
            AddLbl(panelBody, lblFullName, "Họ và tên *", c1, 16);
            AddTxt(panelBody, txtFullName, "Nhập họ và tên", c1, 40, w, h);
            AddLbl(panelBody, lblChucVu, "Chức vụ *", c2, 16);
            cboChucVu.Location = new System.Drawing.Point(c2, 40); cboChucVu.Size = new System.Drawing.Size(w, h);
            cboChucVu.DropDownStyle = ComboBoxStyle.DropDownList; cboChucVu.Font = new Font("Segoe UI", 10F);
            cboChucVu.Items.AddRange(new object[] { "Chọn chức vụ", "Doctor", "Nurse", "Pharmacist", "Technician", "Receptionist" });
            cboChucVu.SelectedIndex = 0;
            panelBody.Controls.Add(cboChucVu);

            // Row 2: Chuyên khoa | Số điện thoại
            AddLbl(panelBody, lblKhoa, "Chuyên khoa", c1, 96);
            cboKhoa.Location = new System.Drawing.Point(c1, 120); cboKhoa.Size = new System.Drawing.Size(w, h);
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList; cboKhoa.Font = new Font("Segoe UI", 10F);
            panelBody.Controls.Add(cboKhoa);
            AddLbl(panelBody, lblPhone, "Số điện thoại *", c2, 96);
            AddTxt(panelBody, txtPhone, "Nhập số điện thoại", c2, 120, w, h);

            // Row 3: Email | Giới tính
            AddLbl(panelBody, lblEmail, "Email *", c1, 176);
            AddTxt(panelBody, txtEmail, "Nhập email", c1, 200, w, h);
            AddLbl(panelBody, lblGender, "Giới tính", c2, 176);
            cboGender.Location = new System.Drawing.Point(c2, 200); cboGender.Size = new System.Drawing.Size(w, h);
            cboGender.DropDownStyle = ComboBoxStyle.DropDownList; cboGender.Font = new Font("Segoe UI", 10F);
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SelectedIndex = 0;
            panelBody.Controls.Add(cboGender);

            sep2.Dock = DockStyle.Bottom; sep2.Height = 1; sep2.BackColor = Color.FromArgb(229, 231, 235);
            panelFooter.Dock = DockStyle.Bottom; panelFooter.Height = 64; panelFooter.BackColor = Color.White;

            btnCancel.Text = "Hủy"; btnCancel.Size = new System.Drawing.Size(90, 36);
            btnCancel.Location = new System.Drawing.Point(474, 14);
            btnCancel.BackColor = Color.White; btnCancel.ForeColor = Color.FromArgb(55, 65, 81);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            btnSave.Text = "Lưu thông tin"; btnSave.Size = new System.Drawing.Size(140, 36);
            btnSave.Location = new System.Drawing.Point(574, 14);
            btnSave.BackColor = Color.FromArgb(47, 94, 240); btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat; btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold); btnSave.Cursor = Cursors.Hand;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);

            Controls.Add(panelBody); Controls.Add(sep2); Controls.Add(sep1);
            Controls.Add(panelTitle); Controls.Add(panelFooter);

            panelTitle.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void AddLbl(Panel p, Label lbl, string text, int x, int y)
        {
            lbl.Text = text; lbl.Location = new System.Drawing.Point(x, y);
            lbl.AutoSize = true; lbl.Font = new Font("Segoe UI", 9.5F);
            lbl.ForeColor = Color.FromArgb(55, 65, 81);
            p.Controls.Add(lbl);
        }

        private void AddTxt(Panel p, TextBox tb, string placeholder, int x, int y, int w, int h)
        {
            tb.Location = new System.Drawing.Point(x, y); tb.Size = new System.Drawing.Size(w, h);
            tb.Font = new Font("Segoe UI", 10F); tb.BorderStyle = BorderStyle.FixedSingle;
            tb.PlaceholderText = placeholder;
            p.Controls.Add(tb);
        }

        private Panel panelTitle, panelBody, panelFooter, sep1, sep2;
        private Label lblTitle, lblFullName, lblChucVu, lblKhoa, lblPhone, lblEmail, lblGender;
        private TextBox txtFullName, txtPhone, txtEmail;
        private ComboBox cboChucVu, cboKhoa, cboGender;
        private Button btnSave, btnCancel;
    }
}