using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class frmPrescriptionDetail : Form
    {
        public frmPrescriptionDetail()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
