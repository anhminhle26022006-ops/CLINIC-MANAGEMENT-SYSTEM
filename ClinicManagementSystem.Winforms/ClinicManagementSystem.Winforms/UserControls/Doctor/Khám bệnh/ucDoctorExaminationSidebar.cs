using BUS.Services.Doctor;
using ClinicManagementSystem.Winforms.Shareforms.ERM;
using DAL.Repositories.Doctor;
using DTO.Doctor;
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucDoctorExaminationSidebar : UserControl
    {
        // ================= SERVICES =================
        private readonly PatientQueueService _queueService;
        private readonly VitalSignsService _vitalService;
        private readonly MedicalHistoryService _historyService;
        private readonly LabResultService _labService;
        private readonly ImagingResultService _imagingService;

        // ================= STATE =================
        private PatientQueueDto _selectedPatient;

        // ================= TABS =================
        private ucExaminationTab _examTab;
        private ucPrescriptionTab _prescriptionTab;
        private ucLabTab _labTab;
        private ucImagingTab _imagingTab;

        public ucDoctorExaminationSidebar()
        {
            InitializeComponent();

            string conn = ConfigurationManager
                .ConnectionStrings["DbConnection"]
                .ConnectionString;

            _queueService = new PatientQueueService(new PatientQueueRepository(conn));
            _vitalService = new VitalSignsService(new VitalSignsRepository(conn));
            _historyService = new MedicalHistoryService();
            _labService = new LabResultService(new LabResultRepository(conn));
            _imagingService = new ImagingResultService(new ImagingResultRepository(conn));

            InitLayout();
            InitTabs();
            InitEvents();

            LoadWaitingPatients();
        }

        // ================= INIT =================
        private void InitLayout()
        {
            pnlTabContent.Dock = DockStyle.Fill;
            flpVitalSigns.Dock = DockStyle.Fill;
            flpWaitingPatients.Dock = DockStyle.Fill;
            flpHistory.Dock = DockStyle.Fill;
        }
        public void LoadPatient(string patientName, string patientInfo, string appointmentTime, string status)
        {
            lblPatientName.Text = patientName;
            lblPatientInfo.Text = $"{patientInfo} • {appointmentTime}";

            // optional status
            // bạn có thể thêm color theo status nếu muốn
        }
        private void InitTabs()
        {
            _examTab = new ucExaminationTab();
            _prescriptionTab = new ucPrescriptionTab();
            _labTab = new ucLabTab();
            _imagingTab = new ucImagingTab();

            ShowTab(_examTab);
        }

        private void InitEvents()
        {
            btnExamination.Click += (_, __) => ShowTab(_examTab);
            btnPrescription.Click += (_, __) => ShowTab(_prescriptionTab);
            btnLab.Click += (_, __) => ShowTab(_labTab);
            btnImaging.Click += (_, __) => ShowTab(_imagingTab);
            btnFollowUp.Click += BtnFollowUp_Click;
        }

        // ================= TAB CONTROL =================
        private void ShowTab(UserControl tab)
        {
            pnlTabContent.SuspendLayout();
            pnlTabContent.Controls.Clear();

            tab.Dock = DockStyle.Fill;
            pnlTabContent.Controls.Add(tab);

            pnlTabContent.ResumeLayout();
        }

        // ================= WAITING LIST =================
        private void LoadWaitingPatients()
        {
            flpWaitingPatients.Controls.Clear();

            int doctorId = 3; // TODO: replace auth later
            var list = _queueService.GetTodayQueue(doctorId);

            lblQueueCount.Text = $"Hàng chờ khám ({list.Count})";

            foreach (var item in list)
            {
                var uc = new ucWaitingPatient();

                uc.lblPatientName.Text = item.PatientName;
                uc.lblAppointmentTime.Text = item.AppointmentTime.ToString("HH:mm");
                uc.lblAgeGender.Text = item.AgeGender;
                uc.lblAllergy.Text = item.Allergy;

                uc.Tag = item;
                uc.Click += WaitingPatient_Click;

                flpWaitingPatients.Controls.Add(uc);
            }
        }

        // ================= SELECT PATIENT =================
        private void WaitingPatient_Click(object sender, EventArgs e)
        {
            var uc = sender as ucWaitingPatient;
            var data = uc?.Tag as PatientQueueDto;

            if (data == null) return;

            _selectedPatient = data;

            HighlightSelected(uc);

            LoadPatientInfo(data);
        }

        private void HighlightSelected(ucWaitingPatient selected)
        {
            foreach (Control c in flpWaitingPatients.Controls)
                c.BackColor = Color.White;

            selected.BackColor = Color.FromArgb(219, 234, 254);
        }

        // ================= PATIENT LOAD =================
        private void LoadPatientInfo(PatientQueueDto p)
        {
            lblPatientName.Text = p.PatientName;
            lblPatientInfo.Text = $"{p.PatientCode} • {p.AgeGender} • STT: {p.QueueNumber}";

            LoadVitalSigns(p.EncounterID);
            LoadHistory(p.EncounterID);
            LoadLab(p.EncounterID);
            LoadImaging(p.EncounterID);
        }
        public void LoadPatientByEncounter(int encounterId)
        {
            var p = _queueService.GetTodayQueue(3)
                .FirstOrDefault(x => x.EncounterID == encounterId);

            if (p == null) return;

            _selectedPatient = p;

            lblPatientName.Text = p.PatientName;
            lblPatientInfo.Text = $"{p.PatientCode} • {p.AgeGender} • STT {p.QueueNumber}";

            LoadVitalSigns(p.EncounterID);
            LoadHistory(p.EncounterID);
            LoadLab(p.EncounterID);
            LoadImaging(p.EncounterID);
        }
        public void LoadPatientByAppointment(int appointmentId)
        {
            // query DB để lấy EncounterID từ AppointmentID
            var queue = _queueService.GetTodayQueue(3)
                                      .FirstOrDefault(x => x.EncounterID > 0);

            if (queue == null) return;

            LoadPatientInfo(queue);
        }

        // ================= VITAL =================
        private void LoadVitalSigns(int encounterId)
        {
            flpVitalSigns.Controls.Clear();

            var vital = _vitalService.Get(encounterId);
            if (vital == null) return;

            AddVital("BMI", CalculateBMI(vital.Weight, vital.Height).ToString("0.0"), "");
        }

        private void AddVital(string name, string value, string unit)
        {
            var card = new ucVitalSignCard1();
            card.lblTitle.Text = name;
            card.lblValue.Text = value;
            card.lblUnit.Text = unit;

            flpVitalSigns.Controls.Add(card);
        }

        // ================= HISTORY =================
        private void LoadHistory(int encounterId)
        {
            flpHistory.Controls.Clear();

            var list = _historyService.GetHistory(encounterId);

            foreach (var item in list)
            {
                var card = new ucPreviousVisitCard();

                card.lblDate.Text =
                    item.Date.ToString("dd/MM/yyyy");

                card.lblDiagnosis.Text =
                    item.Diagnosis;

                card.lblDoctor.Text =
                    item.Doctor;

                card.lblMedicine.Text =
                    item.Status;

                flpHistory.Controls.Add(card);
            }
        }

        // ================= LAB =================
        private void LoadLab(int encounterId)
        {
            var list = _labService.GetByEncounter(encounterId);

            foreach (var lab in list)
            {
                var card = new ucLabResultCard();

                card.lblTitle.Text = "Xét nghiệm";
                card.lblStatus.Text = lab.Status;
                card.lblDate.Text = lab.CompletedAt.ToString("dd/MM/yyyy");

                card.lblWBC.Text = $"WBC: {lab.WBC}";
                card.lblRBC.Text = $"RBC: {lab.RBC}";
                card.lblHGB.Text = $"HGB: {lab.HGB}";

                flpHistory.Controls.Add(card);
            }
        }

        // ================= IMAGING =================
        private void LoadImaging(int encounterId)
        {
            var list = _imagingService.GetByEncounter(encounterId);

            foreach (var img in list)
            {
                var card = new ucImagingCard();

                card.lblTitle.Text = img.ServiceName;
                card.lblDate.Text = img.CompletedAt.ToString("dd/MM/yyyy");
                card.lblContent.Text = img.ResultText;

                if (!string.IsNullOrEmpty(img.ImageURL))
                    card.picThumbnail.Load(img.ImageURL);

                card.picThumbnail.Click += Imaging_Click;

                flpHistory.Controls.Add(card);
            }
        }

        private void Imaging_Click(object sender, EventArgs e)
        {
            new frmPacsViewer().ShowDialog();
        }

        // ================= FOLLOW UP =================
        private void BtnFollowUp_Click(object sender, EventArgs e)
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trước!");
                return;
            }

            var form = new frmFollowUpSchedule
            {
                StartPosition = FormStartPosition.CenterParent
            };

            form.lblPatientName.Text = lblPatientName.Text;
            form.lblPatientCode.Text = _selectedPatient.PatientCode;

            form.ShowDialog();
        }

        // ================= UTIL =================
        private double CalculateBMI(decimal weight, decimal heightCm)
        {
            if (heightCm <= 0) return 0;

            double h = (double)heightCm / 100.0;
            return (double)weight / (h * h);
        }
    }
}