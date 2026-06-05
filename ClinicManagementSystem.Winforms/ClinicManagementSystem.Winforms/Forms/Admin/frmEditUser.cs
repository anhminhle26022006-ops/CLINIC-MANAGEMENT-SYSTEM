using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmEditUser : Form
    {
        private int _userId;
        private string _connectionString;

        public frmEditUser(int userId, string email, string roleName)
        {
            _userId = userId;
            _connectionString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString
                             ?? ConfigurationManager.ConnectionStrings["ClinicDB"]?.ConnectionString
                             ?? "Server=(localdb)\\MSSQLLocalDB;Database=CMS;Trusted_Connection=True;TrustServerCertificate=True;";
            InitializeComponent();
            txtEmail.Text = email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                string sql = string.IsNullOrWhiteSpace(txtPassword.Text)
                    ? "UPDATE Users SET Email=@e WHERE UserID=@id"
                    : "UPDATE Users SET Email=@e, PasswordHash=@p WHERE UserID=@id";
                using var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@e", string.IsNullOrEmpty(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@id", _userId);
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}