using ClinicManagementSystem.Winforms.Controllers;
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
    public partial class ERMform : Form
    {
        private ERMController _controller;
        private PatientERMDto _patient;
        private Guid _patientId;
        public ERMform()
        {
            InitializeComponent();
        }
        public ERMform(ERMController controller, Guid patientId)
        {
            InitializeComponent();
            _controller = controller;
            _patientId = patientId;

            Load += ERMform_Load;
        }
        public void Bind(PatientERMDto patient)
        {
            lblPatientName.Text = patient.FullName;
            lblPatientCode.Text = patient.PatientCode;
            lblGender.Text = patient.Gender;
            lblBloodType.Text = patient.BloodType;
        }
        private async void ERMform_Load(object sender, EventArgs e)
        {
           
            _patient = await _controller.GetPatientERMAsync(_patientId);

            if (_patient == null)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân");
                Close();
                return;
            }

            BindHeader();
            LoadDefaultTab();
        }
       
        private void BindHeader()
        {
            lblPatientName.Text = _patient.FullName;
            lblPatientCode.Text = _patient.PatientCode;

            lblGender.Text = _patient.Gender;

            lblAge.Text = $"{DateTime.Now.Year - _patient.DOB.Year} tuổi";

            lblBloodType.Text = $"Nhóm máu: {_patient.BloodType}";
        }
        private void ShowTab(UserControl control)
        {
            foreach (Control c in pnlContent.Controls)
                c.Visible = false;

            control.Visible = true;
            control.BringToFront();
        }
        private void LoadDefaultTab()
        {
            ShowTab(ucOverview1);

            ucOverview1.Bind(_patient);
        }
        private void btnOverview_Click(object sender, EventArgs e)
        {
            ShowTab(ucOverview1);
            ucOverview1.Bind(_patient);
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            ShowTab(ucHistory1);
            ucHistory1.Bind(_patient.Encounters);
        }
        private void btnPrescription_Click(object sender, EventArgs e)
        {
            ShowTab(ucPrescription1);
            ucPrescription1.Bind(_patient.Encounters);
        }
        private void btnLab_Click(object sender, EventArgs e)
        {
            ShowTab(ucLab1);
            ucLab1.Bind(_patient.LabResults);
        }
        private void btnImaging_Click(object sender, EventArgs e)
        {
            ShowTab(ucImaging1);
            ucImaging1.Bind(_patient.ImagingResults);
        }
        private void btnBilling_Click(object sender, EventArgs e)
        {
            ShowTab(ucBilling1);
            ucBilling1.Bind(_patient.Invoices);
        }
        private void btnFollowup_Click(object sender, EventArgs e)
        {
            ShowTab(ucFollowup1);
            ucFollowup1.Bind(_patient.FollowUps);
        }
    }
}
