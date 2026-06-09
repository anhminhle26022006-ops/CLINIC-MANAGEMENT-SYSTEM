using System;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public enum PharmacyViewTarget
    {
        Overview,
        Prescriptions,
        Medicines,
        Inventory,
        Shifts
    }

    public sealed class PharmacyNavigationEventArgs : EventArgs
    {
        public PharmacyNavigationEventArgs(PharmacyViewTarget target)
        {
            Target = target;
        }

        public PharmacyViewTarget Target { get; }
    }

    public class PharmacyDashboardViewBase : UserControl
    {
        protected UserDTO currentUser;

        public event EventHandler<PharmacyNavigationEventArgs> NavigateRequested;

        public virtual void Initialize(UserDTO user)
        {
            currentUser = user;
        }

        protected void NavigateTo(PharmacyViewTarget target)
        {
            NavigateRequested?.Invoke(this, new PharmacyNavigationEventArgs(target));
        }
    }
}
