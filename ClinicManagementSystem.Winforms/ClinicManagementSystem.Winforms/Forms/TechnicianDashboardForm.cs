using System;
using System.Windows.Forms;
using DTO;
using ClinicManagementSystem.Winforms.Mainforms;
using ClinicManagementSystem.Winforms.UserControls;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class TechnicianDashboardForm : Form
    {
        private readonly UserDTO currentUser;

        public TechnicianDashboardForm()
        {
            InitializeComponent();
        }

        public TechnicianDashboardForm(UserDTO user) : this()
        {
            currentUser = user;
        }

        private void TechnicianDashboardForm_Load(object sender, EventArgs e)
        {
            Form dashboard = null;

            if (currentUser != null && !string.IsNullOrEmpty(currentUser.Role))
            {
                string role = currentUser.Role.Trim();
                if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new AdminMainform(currentUser);
                }
                else if (role.Equals("Doctor", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new DoctorMainform(currentUser);
                }
                else if (role.Equals("Nurse", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new NurseMainform(currentUser);
                }
                else if (role.Equals("Pharmacist", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new PharmacyMainform(currentUser);
                }
                else if (role.Equals("Receptionist", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new ReceptionistMainform(currentUser);
                }
                else if (role.Equals("Technician", StringComparison.OrdinalIgnoreCase))
                {
                    dashboard = new ucTechnicianDashboard(currentUser);
                }
            }

            if (dashboard == null)
            {
                dashboard = currentUser == null
                    ? new ucTechnicianDashboard()
                    : new ucTechnicianDashboard(currentUser);
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

        private void Dashboard_LogoutRequested(object sender, EventArgs e)
        {
            Hide();
            using (LoginForm login = new LoginForm())
            {
                login.ShowDialog();
            }
            Close();
        }
    }
}

