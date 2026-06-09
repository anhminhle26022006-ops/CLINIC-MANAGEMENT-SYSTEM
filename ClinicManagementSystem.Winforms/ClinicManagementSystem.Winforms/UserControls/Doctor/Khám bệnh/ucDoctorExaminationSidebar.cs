using ClinicManagementSystem.Winforms.Shareforms.ERM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucDoctorExaminationSidebar : UserControl
    {
        private ucExaminationTab _examTab;

        private ucPrescriptionTab _prescriptionTab;

        private ucLabTab _labTab;

        private ucImagingTab _imagingTab;
        private ucWaitingPatient _selectedPatient;
        public ucDoctorExaminationSidebar()
        {
            InitializeComponent();
            pnlTabContent.Dock = DockStyle.Fill;

            flpVitalSigns.Dock = DockStyle.Fill;
            flpWaitingPatients.Dock = DockStyle.Fill;
            flpHistory.Dock = DockStyle.Fill;

            InitializeTabs();

            LoadVitalSigns();

            LoadWaitingPatients();

            LoadHistory();
            btnExamination.Click += btnExam_Click;

            btnPrescription.Click += btnPrescription_Click;

            btnLab.Click += btnLab_Click;

            btnImaging.Click += btnImaging_Click;
            btnFollowUp.Click += BtnFollowUp_Click;

        }
        private void LoadHistory()
        {
            flpHistory.Controls.Clear();

            var visit =
                new ucPreviousVisitCard();

            visit.lblDate.Text =
                "15/05/2026";

            visit.lblDiagnosis.Text =
                "Tăng huyết áp độ I";

            visit.lblDoctor.Text =
                "BS Nguyễn Thành Nam";

            visit.lblMedicine.Text =
                "Amlodipine 5mg";

            flpHistory.Controls.Add(visit);
            var lab =
        new ucLabResultCard();

            lab.lblDate.Text =
                "15/05/2026";

            lab.lblStatus.Text =
                "Hoàn thành";

            lab.lblWBC.Text =
                "WBC : 7.2";

            lab.lblRBC.Text =
                "RBC : 5.1";

            lab.lblHGB.Text =
                "HGB : 15.2";

            flpHistory.Controls.Add(lab);
            var imaging =
       new ucImagingCard();

            imaging.lblTitle.Text =
                "X-Ray phổi";

            imaging.lblDate.Text =
                "14/05/2026";

            imaging.lblContent.Text =
                "Phổi trong, tim bình thường";

            imaging.picThumbnail.Click +=
                Imaging_Click;

            flpHistory.Controls.Add(imaging);
        }
        private void InitializeTabs()
        {
            _examTab = new ucExaminationTab();
            _prescriptionTab = new ucPrescriptionTab();
            _labTab = new ucLabTab();
            _imagingTab = new ucImagingTab();

            _examTab.Dock = DockStyle.Fill;
            _prescriptionTab.Dock = DockStyle.Fill;
            _labTab.Dock = DockStyle.Fill;
            _imagingTab.Dock = DockStyle.Fill;

            ShowTab(_examTab);
        }
        private void ShowTab(UserControl tab)
        {
            pnlTabContent.SuspendLayout();

            pnlTabContent.Controls.Clear();

            tab.Dock = DockStyle.Fill;

            tab.Margin = Padding.Empty;

            pnlTabContent.Controls.Add(tab);

            pnlTabContent.ResumeLayout();
        }
        private void LoadVitalSigns()
        {
            flpVitalSigns.Controls.Clear();

            AddVital(
                "Huyết áp",
                "118/75",
                "mmHg");

            AddVital(
                "Nhiệt độ",
                "36.5",
                "°C");

            AddVital(
                "Nhịp tim",
                "72",
                "bpm");

            AddVital(
                "Chiều cao",
                "160",
                "cm");

            AddVital(
                "Cân nặng",
                "55",
                "kg");
        }
        private void AddVital(
    string name,
    string value,
    string unit)
        {
            var card =
                new ucVitalSignCard1();

            card.lblTitle.Text =
                name;

            card.lblValue.Text =
                value;

            card.lblUnit.Text =
                unit;

            flpVitalSigns.Controls.Add(card);
        }
        private void LoadWaitingPatients()
        {
            flpWaitingPatients.Controls.Clear();

            for (int i = 1; i <= 10; i++)
            {
                var patient =
                    new ucWaitingPatient();

                patient.lblPatientName.Text =
                    $"Bệnh nhân {i}";

                patient.lblAppointmentTime.Text =
                    "08:30";

                patient.lblAgeGender.Text =
                    "32 tuổi • Nữ"; 

                patient.lblAllergy.Text =
                    "Dị ứng: Penicillin";

                patient.Click += WaitingPatient_Click;

                flpWaitingPatients.Controls.Add(
                    patient);
            }
        }
        private void Imaging_Click(
    object sender,
    EventArgs e)
        {
            var viewer =
                new frmPacsViewer();

            viewer.ShowDialog();
        }
        private void btnExam_Click(
    object sender,
    EventArgs e)
        {
            ShowTab(_examTab);
        }

        private void btnPrescription_Click(
            object sender,
            EventArgs e)
        {
            ShowTab(_prescriptionTab);
        }

        private void btnLab_Click(
            object sender,
            EventArgs e)
        {
            ShowTab(_labTab);
        }

        private void btnImaging_Click(
            object sender,
            EventArgs e)
        {
            ShowTab(_imagingTab);
        }
        private void WaitingPatient_Click(
    object sender,
    EventArgs e)
        {
            if (_selectedPatient != null)
            {
                _selectedPatient.BackColor =
                    Color.White;
            }

            _selectedPatient =
                sender as ucWaitingPatient;

            _selectedPatient.BackColor =
                Color.FromArgb(
                    219,
                    234,
                    254);

            LoadPatientInfo();
        }
        private void LoadPatientInfo()
        {
            lblPatientName.Text =
                "Trần Thị B";

            lblPatientInfo.Text =
                "BN001235 • 32 tuổi • Nữ • STT: A007";

            lblBMI.Text =
                "21.5";
        }
        private void BtnFollowUp_Click(object sender, EventArgs e)
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn bệnh nhân trước khi tạo lịch tái khám!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var form = new frmFollowUpSchedule();

            // truyền dữ liệu sang form (nếu bạn muốn)
            form.lblPatientName.Text = lblPatientName.Text;
            form.lblPatientCode.Text = lblPatientInfo.Text;

            form.StartPosition = FormStartPosition.CenterParent;

            form.ShowDialog();
        }

    }
}
