using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserBUS userBUS = new UserBUS();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            try
            {
                UserDTO user = userBUS.Login(username, password);

                if (user == null)
                {
                    ShowError("Sai tài khoản hoặc mật khẩu.");
                    return;
                }

                OpenMainFormByRole(user);
            }
            catch (SqlException)
            {
                ShowError("Không thể kết nối database.");
            }
            catch (Exception ex)
            {
                ShowError("Lỗi: " + ex.Message);
            }
        }

        private void OpenMainFormByRole(UserDTO user)
        {
            Form mainForm;

            switch (user.Role)
            {
                case "Admin":
                    mainForm = new AdminMainform(user);
                    break;

                case "Receptionist":
                    mainForm = new ReceptionistMainform(user);
                    break;

                case "Doctor":
                    mainForm = new DoctorMainform(user);
                    break;

                case "Nurse":
                    mainForm = new NurseMainform(user);
                    break;

                case "Pharmacist":
                    mainForm = new PharmacyMainform(user);
                    break;

                case "Technician":
                    mainForm = new TechnicianMainform(user);
                    break;

                default:
                    ShowError("Role không hợp lệ.");
                    return;
            }

            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }
    }
}