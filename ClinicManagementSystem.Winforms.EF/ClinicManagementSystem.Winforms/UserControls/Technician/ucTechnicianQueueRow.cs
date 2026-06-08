using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianQueueRow : UserControl
    {
        public ucTechnicianQueueRow()
        {
            InitializeComponent();
        }

        public void Configure(string patientName, string serviceType, string doctorName, string badgeText, Color badgeBack, Color badgeFore)
        {
            lblPatientName.Text = patientName;
            lblServiceType.Text = serviceType;
            lblDoctor.Text = doctorName;
            lblBadge.Text = badgeText;
            lblBadge.BackColor = badgeBack;
            lblBadge.ForeColor = badgeFore;
        }
    }
}
