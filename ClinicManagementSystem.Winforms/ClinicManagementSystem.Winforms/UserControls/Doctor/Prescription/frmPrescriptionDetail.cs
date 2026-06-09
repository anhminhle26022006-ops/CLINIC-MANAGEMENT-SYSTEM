using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class frmPrescriptionDetail : Form
    {
        public frmPrescriptionDetail()
        {
            InitializeComponent();

           
            
        }


      
        // ================= CLOSE =================
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}