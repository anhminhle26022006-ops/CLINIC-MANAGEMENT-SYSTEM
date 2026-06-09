using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucLabRequestItem : UserControl
    {
        public event EventHandler DeleteRequested;

        public ucLabRequestItem()
        {
            InitializeComponent();

            cboLabType.Items.Clear();
            cboLabType.Items.AddRange(new object[]
            {
                "Cong thuc mau",
                "Duong huyet",
                "Chuc nang gan",
                "Chuc nang than",
                "Tong phan tich nuoc tieu",
                "Dien tim ECG"
            });
            if (cboLabType.Items.Count > 0)
            {
                cboLabType.SelectedIndex = 0;
            }

            btnDelete.Click += (_, __) => DeleteRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
