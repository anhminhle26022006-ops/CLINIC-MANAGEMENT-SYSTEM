using ClinicManagementSystem.Winforms.Mainforms;
using ClinicManagementSystem.Winforms.UserControls;
using CMS.Core.Identity;
using CMS.Core.Session;
using DAL.Models;
using DTO;
using System;
using System.Windows.Forms;

// Dùng alias để tránh nhầm lẫn giữa Role constants và Role entity
using RoleConst = CMS.Core.Identity.Role;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class MainformRole : Form
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO currentUser;

        // Constructor cho designer (không dùng)
        public MainformRole()
        {
            InitializeComponent();
        }

        // Constructor chính: nhận context và user
        public MainformRole(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            currentUser = user ?? throw new ArgumentNullException(nameof(user));
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
                    RoleConst.Admin => "Quản trị viên",
                    RoleConst.Doctor => "Bác sĩ",
                    RoleConst.Nurse => "Điều dưỡng",
                    RoleConst.Pharmacist => "Dược sĩ",
                    RoleConst.Receptionist => "Tiếp tân",
                    RoleConst.Technician => "Kỹ thuật viên",
                    _ => role
                };
                this.Text = "HealthCare+ - " + roleText;
            }

            dashboard.Dock = DockStyle.Fill;

            // Gắn sự kiện động
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
            if (currentUser == null) return null;

            string role = RoleNormalizer.Normalize(currentUser.Role);
            switch (role)
            {
                case RoleConst.Admin:
                    return new AdminMainform(_context, currentUser);
                case RoleConst.Doctor:
                    return new DoctorMainform(_context, currentUser);
                case RoleConst.Nurse:
                    return new NurseMainform(_context, currentUser);
                case RoleConst.Pharmacist:
                    return new PharmacyMainform(_context, currentUser);
                case RoleConst.Receptionist:
                    return new ReceptionistMainform(_context, currentUser);
                case RoleConst.Technician:
                    return new TechnicianMainform(_context, currentUser);
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