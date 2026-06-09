using System;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPharmacyPrescriptionQueueCard : UserControl
    {
        public ucPharmacyPrescriptionQueueCard()
        {
            InitializeComponent();
        }

        public int PrescriptionId { get; private set; }

        public event EventHandler CardSelected;

        public void Configure(PrescriptionDTO prescription)
        {
            PrescriptionId = prescription.PrescriptionID;
            lblPatientName.Text = prescription.PatientName;
            lblDoctor.Text = "BS: " + prescription.DoctorName;
            lblPrescriptionCode.Text = "Mã toa: #" + prescription.PrescriptionID;
            lblTime.Text = prescription.CreatedAt.ToString("HH:mm");
            lblItemCount.Text = prescription.Items.Count + " thuốc";
            SetStatus(prescription.Status);
            SetSelected(false);
        }

        public void Clear()
        {
            PrescriptionId = 0;
            lblPatientName.Text = string.Empty;
            lblDoctor.Text = string.Empty;
            lblPrescriptionCode.Text = string.Empty;
            lblTime.Text = string.Empty;
            lblItemCount.Text = string.Empty;
            lblStatus.Text = string.Empty;
            SetSelected(false);
        }

        public void SetSelected(bool selected)
        {
            ApplySelectedState(selected);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            CardSelected?.Invoke(this, EventArgs.Empty);
        }
    }
}
