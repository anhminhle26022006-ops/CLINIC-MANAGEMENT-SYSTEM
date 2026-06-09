using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucOverview : UserControl
    {
        public ucOverview()
        {
            InitializeComponent();
        }
        public void Bind(PatientERMDto patient)
        {
            if (patient == null) return;

            // Personal info
            lblNumphone.Text = patient.Phone;
            lblemail.Text = patient.Email;
            lbladdress.Text = patient.Address;
            lblBHYT.Text = patient.InsuranceNumber;

            // Emergency
            label3.Text = patient.EmergencyContact;

            // Allergy
            label5.Text = string.IsNullOrWhiteSpace(patient.Allergy)
    ? "Không có dị ứng"
    : patient.Allergy;
        }
       
    }
}
