using System;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucPatientRecordRow : UserControl
    {
        public event EventHandler PatientClicked;

        public ucPatientRecordRow()
        {
            InitializeComponent();
            RegisterClickHandlers(this);
        }

        public void Configure(PatientDTO patient)
        {
            string initial = string.IsNullOrWhiteSpace(patient.Name) ? "?" : patient.Name.Substring(0, 1).ToUpper();
            lblAvatar.Text = initial;
            lblPatientName.Text = patient.Name;
            lblPatientCode.Text = patient.PatientCode;
            lblPatientAgeGender.Text = $"{patient.Age} tuổi - {patient.Gender}";
        }

        private void RegisterClickHandlers(Control parent)
        {
            parent.Click += (s, e) => PatientClicked?.Invoke(this, EventArgs.Empty);
            foreach (Control child in parent.Controls)
            {
                RegisterClickHandlers(child);
            }
        }
    }
}
