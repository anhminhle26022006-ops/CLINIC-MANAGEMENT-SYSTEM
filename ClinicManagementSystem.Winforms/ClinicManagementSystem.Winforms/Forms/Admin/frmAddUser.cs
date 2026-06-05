using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmAddUser : Form
    {
        private string _connectionString;

        public frmAddUser()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString
                             ?? ConfigurationManager.ConnectionStrings["ClinicDB"]?.ConnectionString
                             ?? "Server=(localdb)\\MSSQLLocalDB;Database=CMS;Trusted_Connection=True;TrustServerCertificate=True;";
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
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
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                bool isActive = cboStatus.SelectedIndex == 0;
                using var cmd = new SqlCommand(@"
                    INSERT INTO Users (Username, PasswordHash, Email, RoleID, IsActive, CreatedAt)
                    VALUES (@u, @p, @e, (SELECT RoleID FROM Roles WHERE RoleName=@r), @active, GETDATE())", conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@e", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@r", cboRole.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@active", isActive ? 1 : 0);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Thêm tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}