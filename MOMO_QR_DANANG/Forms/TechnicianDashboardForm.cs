using System;
using System.Windows.Forms;
using MOMO_QR_DANANG.Models;
using MOMO_QR_DANANG.UserControls;

namespace MOMO_QR_DANANG
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
            var dashboard = currentUser == null
                ? new ucTechnicianDashboard()
                : new ucTechnicianDashboard(currentUser);

            dashboard.Dock = DockStyle.Fill;

            dashboard.LogoutRequested += Dashboard_LogoutRequested;
            dashboard.CloseRequested += (s, ev) => Application.Exit();

            Controls.Add(dashboard);
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

