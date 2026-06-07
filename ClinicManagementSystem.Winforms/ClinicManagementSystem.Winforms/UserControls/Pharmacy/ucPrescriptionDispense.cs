using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPrescriptionDispense : PharmacyDashboardViewBase
    {
        public ucPrescriptionDispense()
        {
            InitializeComponent();
        }

        private void ucPrescriptionDispense_Load(object sender, EventArgs e)
        {
            btnDispense.Click += (s, ev) =>
            {
                MessageBox.Show("UI cấp phát thuốc đã sẵn sàng để nối nghiệp vụ.", "Pharmacy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }
    }
}
