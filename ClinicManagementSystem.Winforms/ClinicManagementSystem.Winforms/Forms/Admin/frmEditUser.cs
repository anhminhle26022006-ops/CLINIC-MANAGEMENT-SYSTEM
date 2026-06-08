using System;
using System.Windows.Forms;
using BUS.Services;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmEditUser : Form
    {
        private readonly int _userId;
        private readonly UserBUS _bus = new UserBUS();

        public frmEditUser(int userId, string email, string roleName)
        {
            _userId = userId;
            InitializeComponent();
            txtEmail.Text = email;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _bus.UpdateUser(_userId, txtEmail.Text.Trim(), txtPassword.Text);
                MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }
    }
}