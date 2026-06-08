using System;
using System.Drawing;
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
        protected readonly Color primary = Color.FromArgb(47, 94, 240);
        protected readonly Color pageBack = Color.FromArgb(247, 249, 252);
        protected readonly Color textMain = Color.FromArgb(17, 24, 39);
        protected readonly Color textMuted = Color.FromArgb(107, 114, 128);

        protected UserDTO currentUser;

        protected PharmacyDashboardViewBase()
        {
            Font = new Font("Segoe UI", 9F);
        }

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
