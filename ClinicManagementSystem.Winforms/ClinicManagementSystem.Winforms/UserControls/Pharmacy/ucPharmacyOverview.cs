using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPharmacyOverview : PharmacyDashboardViewBase
    {
        public ucPharmacyOverview()
        {
            InitializeComponent();
        }

        private void ucPharmacyOverview_Load(object sender, EventArgs e)
        {
            btnViewWeek.Click += (s, ev) => NavigateTo(PharmacyViewTarget.Shifts);
            btnChangeShift.Click += (s, ev) => NavigateTo(PharmacyViewTarget.Shifts);

            BindNavigation(pnlActDispense, PharmacyViewTarget.Prescriptions);
            BindNavigation(pnlActInventory, PharmacyViewTarget.Inventory);
            BindNavigation(pnlActReports, PharmacyViewTarget.Medicines);
            BindNavigation(pnlActStocktake, PharmacyViewTarget.Inventory);
        }

        private void BindNavigation(Control parent, PharmacyViewTarget target)
        {
            parent.Click += (s, e) => NavigateTo(target);
            foreach (Control child in parent.Controls)
            {
                child.Click += (s, e) => NavigateTo(target);
            }
        }
    }
}
