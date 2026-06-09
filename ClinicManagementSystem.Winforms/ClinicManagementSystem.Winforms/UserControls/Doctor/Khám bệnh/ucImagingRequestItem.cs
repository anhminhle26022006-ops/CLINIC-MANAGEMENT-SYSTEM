using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucImagingRequestItem : UserControl
    {
        public event EventHandler DeleteRequested;

        public ucImagingRequestItem()
        {
            InitializeComponent();

            cboImagingType.Items.Clear();
            cboImagingType.Items.AddRange(new object[]
            {
                "X-quang nguc",
                "Sieu am bung",
                "CT so nao",
                "MRI cot song",
                "Sieu am tim"
            });
            if (cboImagingType.Items.Count > 0)
            {
                cboImagingType.SelectedIndex = 0;
            }

            btnDelete.Click += (_, __) => DeleteRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
