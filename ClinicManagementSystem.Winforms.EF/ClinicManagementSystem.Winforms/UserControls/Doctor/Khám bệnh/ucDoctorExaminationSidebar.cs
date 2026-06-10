using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services.Doctor;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucDoctorExaminationSidebar : UserControl
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;
        private readonly DoctorWorkspaceBUS _doctorBUS;
        private readonly int _doctorId;

        private DoctorAppointmentDTO selectedPatient;
        private ucExaminationTab examTab;
        private ucPrescriptionTab prescriptionTab;
        private ucLabTab labTab;
        private ucImagingTab imagingTab;

        // Constructor mặc định (cho designer)
        public ucDoctorExaminationSidebar()
        {
            InitializeComponent();
        }

        // Constructor chính (dùng khi runtime)
        public ucDoctorExaminationSidebar(CMSDbContext context, UserDTO currentUser) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _doctorBUS = new DoctorWorkspaceBUS(_context);
            _doctorId = _doctorBUS.ResolveDoctorId(_currentUser);

            InitLayout();
            InitTabs();
            InitEvents();
            LoadWaitingPatients();
        }

        private void InitLayout()
        {
            pnlTabContent.Dock = DockStyle.Fill;
            flpVitalSigns.Dock = DockStyle.Fill;
            flpWaitingPatients.Dock = DockStyle.Fill;
            flpHistory.Dock = DockStyle.Fill;

            lblDoctor.Text = string.IsNullOrWhiteSpace(_currentUser?.Name) ? "Bac si" : _currentUser.Name;
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void InitTabs()
        {
            // Truyền context xuống các tab nếu chúng cần (giả sử các tab đã có constructor nhận context)
            examTab = new ucExaminationTab(_context, _currentUser);
            prescriptionTab = new ucPrescriptionTab(_context, _currentUser);
            labTab = new ucLabTab(_context, _currentUser);
            imagingTab = new ucImagingTab(_context, _currentUser);

            ShowTab(examTab);
        }

        private void InitEvents()
        {
            btnExamination.Click += (_, __) => ShowTab(examTab);
            btnPrescription.Click += (_, __) => ShowTab(prescriptionTab);
            btnLab.Click += (_, __) => ShowTab(labTab);
            btnImaging.Click += (_, __) => ShowTab(imagingTab);
            btnFollowUp.Click += BtnFollowUp_Click;
            btnComplete.Click += BtnComplete_Click;
            btnCancel.Click += (_, __) => LoadWaitingPatients();
        }

        private void ShowTab(UserControl tab)
        {
            pnlTabContent.SuspendLayout();
            pnlTabContent.Controls.Clear();
            tab.Dock = DockStyle.Fill;
            pnlTabContent.Controls.Add(tab);
            pnlTabContent.ResumeLayout();
        }

        private void LoadWaitingPatients()
        {
            flpWaitingPatients.Controls.Clear();
            var list = _doctorBUS.GetAppointments(_doctorId, DateTime.Today)
                .Where(item => item.Status is "Waiting" or "Examining")
                .ToList();

            lblQueueCount.Text = "Hang cho kham (" + list.Count + ")";
            lblProgress.Text = "Da kham: " + _doctorBUS.GetDashboard(_doctorId, DateTime.Today).CompletedCount + "/" + Math.Max(list.Count, 1);

            int index = 1;
            foreach (DoctorAppointmentDTO item in list)
            {
                ucWaitingPatient uc = new();
                uc.lblPatientName.Text = item.PatientName;
                uc.lblAppointmentTime.Text = item.AppointmentDate.ToString("HH:mm");
                uc.lblAgeGender.Text = item.AgeGender;
                uc.lblAllergy.Text = string.IsNullOrWhiteSpace(item.Allergy) ? "Khong di ung" : item.Allergy;
                uc.Tag = item;
                uc.Click += WaitingPatient_Click;
                uc.Margin = new Padding(4);

                flpWaitingPatients.Controls.Add(uc);
                index++;
            }

            if (list.Count > 0)
            {
                selectedPatient = list[0];
                LoadPatientInfo(selectedPatient);
                if (flpWaitingPatients.Controls.Count > 0 && flpWaitingPatients.Controls[0] is ucWaitingPatient first)
                {
                    HighlightSelected(first);
                }
            }
            else
            {
                selectedPatient = null;
                lblPatientName.Text = "Chua co benh nhan";
                lblPatientInfo.Text = "Khong co lich kham trong ngay";
                lblBMI.Text = "-";
                flpVitalSigns.Controls.Clear();
                flpHistory.Controls.Clear();
            }
        }

        public void LoadPatientByAppointment(int appointmentId)
        {
            DoctorAppointmentDTO appointment = _doctorBUS.GetByAppointment(_doctorId, appointmentId);
            if (appointment == null)
            {
                MessageBox.Show("Không tìm thấy lịch khám.");
                return;
            }

            selectedPatient = appointment;
            LoadPatientInfo(appointment);
        }

        public void LoadPatientByEncounter(int encounterId)
        {
            DoctorAppointmentDTO appointment = _doctorBUS.GetByEncounter(_doctorId, encounterId);
            if (appointment == null)
            {
                MessageBox.Show("Không tìm thấy ca khám.");
                return;
            }

            selectedPatient = appointment;
            LoadPatientInfo(appointment);
        }

        private void WaitingPatient_Click(object sender, EventArgs e)
        {
            if (sender is not ucWaitingPatient uc || uc.Tag is not DoctorAppointmentDTO data) return;

            try
            {
                _doctorBUS.StartExamination(data.AppointmentID, data.EncounterID, _doctorId);
                data = _doctorBUS.GetByAppointment(_doctorId, data.AppointmentID) ?? data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể bắt đầu khám: " + ex.Message, "Khám bệnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            selectedPatient = data;
            HighlightSelected(uc);
            LoadPatientInfo(data);
        }

        private void HighlightSelected(ucWaitingPatient selected)
        {
            foreach (Control control in flpWaitingPatients.Controls)
            {
                control.BackColor = Color.White;
            }
            selected.BackColor = Color.FromArgb(219, 234, 254);
        }

        private void LoadPatientInfo(DoctorAppointmentDTO appointment)
        {
            selectedPatient = appointment;
            lblPatientName.Text = appointment.PatientName;
            lblPatientInfo.Text = appointment.PatientCode + " - " + appointment.AgeGender + " - " + appointment.AppointmentDate.ToString("HH:mm");

            LoadVitalSigns(appointment);
            LoadRecord(appointment.EncounterID);
            LoadHistory(appointment.PatientID, appointment.EncounterID);
            SetTabContext(appointment.EncounterID);
        }

        private void SetTabContext(int encounterId)
        {
            labTab.SetContext(encounterId, _doctorId);
            imagingTab.SetContext(encounterId, _doctorId);
            prescriptionTab.SetContext(encounterId, _doctorId, _doctorBUS.GetMedicines());
        }

        private void LoadRecord(int encounterId)
        {
            examTab.LoadRecord(_doctorBUS.GetMedicalRecord(encounterId), encounterId);
        }

        private void LoadVitalSigns(DoctorAppointmentDTO appointment)
        {
            flpVitalSigns.Controls.Clear();

            AddVital("Nhiet do", appointment.Temperature > 0 ? appointment.Temperature.ToString("0.0") : "-", "C");
            AddVital("Huyet ap", string.IsNullOrWhiteSpace(appointment.BloodPressure) ? "-" : appointment.BloodPressure, "");
            AddVital("Mach", appointment.HeartRate > 0 ? appointment.HeartRate.ToString() : "-", "bpm");
            AddVital("SpO2", appointment.SpO2 > 0 ? appointment.SpO2.ToString() : "-", "%");

            double bmi = CalculateBMI(appointment.Weight, appointment.Height);
            lblBMI.Text = bmi > 0 ? bmi.ToString("0.0") : "-";
        }

        private void AddVital(string name, string value, string unit)
        {
            ucVitalSignCard1 card = new();
            card.lblTitle.Text = name;
            card.lblValue.Text = value;
            card.lblUnit.Text = unit;
            flpVitalSigns.Controls.Add(card);
        }

        private void LoadHistory(int patientId, int encounterId)
        {
            flpHistory.Controls.Clear();

            foreach (DoctorHistoryDTO item in _doctorBUS.GetHistory(patientId, encounterId))
            {
                ucPreviousVisitCard card = new();
                card.lblDate.Text = item.Date == DateTime.MinValue ? "-" : item.Date.ToString("dd/MM/yyyy");
                card.lblDiagnosis.Text = item.Diagnosis;
                card.lblDoctor.Text = item.DoctorName;
                card.lblMedicine.Text = string.IsNullOrWhiteSpace(item.PrescriptionSummary)
                    ? DoctorWorkspaceBUS.ToDisplayStatus(item.Status)
                    : item.PrescriptionSummary;
                flpHistory.Controls.Add(card);
            }

            foreach (DoctorLabResultDTO lab in _doctorBUS.GetLabResults(encounterId))
            {
                ucLabResultCard card = new();
                card.lblTitle.Text = lab.TestType;
                card.lblStatus.Text = DoctorWorkspaceBUS.ToDisplayStatus(lab.Status);
                card.lblDate.Text = lab.CompletedAt.HasValue ? lab.CompletedAt.Value.ToString("dd/MM/yyyy") : "-";
                card.lblWBC.Text = lab.ResultText;
                card.lblRBC.Text = "";
                card.lblHGB.Text = lab.FileURL;
                flpHistory.Controls.Add(card);
            }

            foreach (DoctorImagingResultDTO img in _doctorBUS.GetImagingResults(encounterId))
            {
                ucImagingCard card = new();
                card.lblTitle.Text = img.ServiceName;
                card.lblDate.Text = img.CompletedAt.HasValue ? img.CompletedAt.Value.ToString("dd/MM/yyyy") : "-";
                card.lblContent.Text = string.IsNullOrWhiteSpace(img.ResultText)
                    ? DoctorWorkspaceBUS.ToDisplayStatus(img.Status)
                    : img.ResultText;
                flpHistory.Controls.Add(card);
            }
        }

        private void BtnFollowUp_Click(object sender, EventArgs e)
        {
            if (selectedPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trước!");
                return;
            }

            frmFollowUpSchedule form = new()
            {
                StartPosition = FormStartPosition.CenterParent
            };
            form.lblPatientName.Text = selectedPatient.PatientName;
            form.lblPatientCode.Text = selectedPatient.PatientCode;
            form.ShowDialog();
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (selectedPatient == null)
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân trước!");
                return;
            }

            try
            {
                _doctorBUS.SaveMedicalRecord(examTab.BuildRecord());
                _doctorBUS.CreateLabRequests(labTab.BuildRequests());
                _doctorBUS.CreateImagingRequests(imagingTab.BuildRequests());

                var prescription = prescriptionTab.BuildPrescription();
                if (prescription.Items.Count > 0)
                {
                    _doctorBUS.CreatePrescription(prescription);
                }

                _doctorBUS.CompleteExamination(selectedPatient.AppointmentID, selectedPatient.EncounterID, _doctorId);

                labTab.ClearRequests();
                imagingTab.ClearRequests();
                prescriptionTab.ClearPrescription();
                LoadWaitingPatients();
                MessageBox.Show("Đã hoàn thành ca khám.", "Khám bệnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể hoàn thành khám: " + ex.Message, "Khám bệnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static double CalculateBMI(decimal weight, decimal heightCm)
        {
            if (weight <= 0 || heightCm <= 0) return 0;
            double h = (double)heightCm / 100.0;
            return (double)weight / (h * h);
        }
    }
}