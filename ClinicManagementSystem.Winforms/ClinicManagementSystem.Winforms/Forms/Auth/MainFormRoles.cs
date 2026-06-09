using System;
using System.Windows.Forms;
using DTO;
using ClinicManagementSystem.Winforms.Mainforms;
using ClinicManagementSystem.Winforms.UserControls;
using CMS.Core.Identity;
using CMS.Core.Session;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class MainformRole : Form
    {
        private readonly UserDTO currentUser;

        public MainformRole()
        {
            InitializeComponent();
        }

        public MainformRole(UserDTO user) : this()
        {
            currentUser = user;
        }

        private void TechnicianDashboardForm_Load(object sender, EventArgs e)
        {
            Form dashboard = CreateDashboardForCurrentUser();

            if (dashboard == null)
            {
                MessageBox.Show(
                    "Tài khoản chưa có vai trò hợp lệ để mở màn hình làm việc.",
                    "Không thể mở dashboard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                Close();
                return;
            }

            if (currentUser != null)
            {
                string role = RoleNormalizer.Normalize(currentUser.Role);
                string roleText = role switch
                {
                    Role.Admin => "Quản trị viên",
                    Role.Doctor => "Bác sĩ",
                    Role.Nurse => "Điều dưỡng",
                    Role.Pharmacist => "Dược sĩ",
                    Role.Receptionist => "Tiếp tân",
                    Role.Technician => "Kỹ thuật viên",
                    _ => role
                };
                this.Text = "HealthCare+ - " + roleText;
            }

            dashboard.Dock = DockStyle.Fill;

            // Wire up events dynamically
            try
            {
                var logoutEvent = dashboard.GetType().GetEvent("LogoutRequested");
                if (logoutEvent != null)
                {
                    EventHandler handler = Dashboard_LogoutRequested;
                    logoutEvent.AddEventHandler(dashboard, handler);
                }
            }
            catch { }

            try
            {
                var closeEvent = dashboard.GetType().GetEvent("CloseRequested");
                if (closeEvent != null)
                {
                    EventHandler handler = (s, ev) => Application.Exit();
                    closeEvent.AddEventHandler(dashboard, handler);
                }
            }
            catch { }

            dashboard.TopLevel = false;
            dashboard.FormBorderStyle = FormBorderStyle.None;
            dashboard.Dock = DockStyle.Fill;

            this.Controls.Add(dashboard);
            dashboard.Show();
        }

        private Form CreateDashboardForCurrentUser()
        {
            if (currentUser == null)
            {
                return null;
            }

            string role = RoleNormalizer.Normalize(currentUser.Role);
            switch (role)
            {
                case Role.Admin:
                    return new AdminMainform(currentUser);
                case Role.Doctor:
                    return new DoctorMainform(currentUser);
                case Role.Nurse:
                    return new NurseMainform(currentUser);
                case Role.Pharmacist:
                    return new PharmacyMainform(currentUser);
                case Role.Receptionist:
                    return new ReceptionistMainform(currentUser);
                case Role.Technician:
                    return new TechnicianMainform(currentUser);
                default:
                    return null;
            }
        }

        private void Dashboard_LogoutRequested(object sender, EventArgs e)
        {
            UserSession.Logout();
            Hide();
            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }
            Close();
        }
    }
}

