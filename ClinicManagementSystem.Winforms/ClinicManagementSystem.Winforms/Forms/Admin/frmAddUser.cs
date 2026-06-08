using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmAddUser : Form
    {
        private readonly UserBUS _bus = new UserBUS();

        public frmAddUser() { InitializeComponent(); }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            { MessageBox.Show("Vui lòng nhập Username.", "Thiếu thông tin"); txtUsername.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtDisplayName.Text))
            { MessageBox.Show("Vui lòng nhập Tên hiển thị.", "Thiếu thông tin"); txtDisplayName.Focus(); return; }
            if (cboRole.SelectedIndex <= 0)
            { MessageBox.Show("Vui lòng chọn Vai trò.", "Thiếu thông tin"); cboRole.Focus(); return; }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            { MessageBox.Show("Vui lòng nhập Mật khẩu.", "Thiếu thông tin"); txtPassword.Focus(); return; }
            if (txtPassword.Text != txtConfirmPassword.Text)
            { MessageBox.Show("Mật khẩu xác nhận không khớp.", "Lỗi"); txtConfirmPassword.Focus(); return; }

            try
            {
                var user = new UserDTO
                {
                    Username = txtUsername.Text.Trim(),
                    Name = txtDisplayName.Text.Trim(),
                    Password = txtPassword.Text,
                    Role = cboRole.SelectedItem.ToString(),
                    Email = txtEmail.Text.Trim()
                };
                if (_bus.CreateUser(user))
                {
                    MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Thêm tài khoản thất bại. Username có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }
}