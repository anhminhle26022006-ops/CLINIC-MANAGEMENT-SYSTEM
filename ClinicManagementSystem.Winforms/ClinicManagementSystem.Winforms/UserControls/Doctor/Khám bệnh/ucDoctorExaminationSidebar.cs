using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services.Doctor;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucDoctorExaminationSidebar : UserControl
    {
        private readonly DoctorWorkspaceBUS doctorBUS = new();
        private readonly UserDTO currentUser;
        private readonly int doctorId;

        private DoctorAppointmentDTO selectedPatient;
        private ucExaminationTab examTab;
        private ucPrescriptionTab prescriptionTab;
        private ucLabTab labTab;
        private ucImagingTab imagingTab;

        public ucDoctorExaminationSidebar() : this(null)
        {
        }

        public ucDoctorExaminationSidebar(UserDTO currentUser)
        {
            this.currentUser = currentUser;
            doctorId = doctorBUS.ResolveDoctorId(currentUser);

            InitializeComponent();
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

            lblDoctor.Text = string.IsNullOrWhiteSpace(currentUser?.Name)
                ? "Bac si"
                : currentUser.Name;
            lblDate.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void InitTabs()
        {
            examTab = new ucExaminationTab();
            prescriptionTab = new ucPrescriptionTab();
            labTab = new ucLabTab();
            imagingTab = new ucImagingTab();

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
            var list = doctorBUS.GetAppointments(doctorId, DateTime.Today)
                .Where(item => item.Status is "Waiting" or "Examining")
                .ToList();

            lblQueueCount.Text = "Hang cho kham (" + list.Count + ")";
            lblProgress.Text = "Da kham: " + doctorBUS.GetDashboard(doctorId, DateTime.Today).CompletedCount + "/" + Math.Max(list.Count, 1);

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

        public void LoadPatient(string patientName, string patientInfo, string appointmentTime, string status)
        {
            lblPatientName.Text = patientName;
            lblPatientInfo.Text = patientInfo + " - " + appointmentTime + " - " + status;
        }

        public void LoadPatientByAppointment(int appointmentId)
        {
            DoctorAppointmentDTO appointment = doctorBUS.GetByAppointment(doctorId, appointmentId);
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
            DoctorAppointmentDTO appointment = doctorBUS.GetByEncounter(doctorId, encounterId);
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
            if (sender is not ucWaitingPatient uc || uc.Tag is not DoctorAppointmentDTO data)
            {
                return;
            }

            try
            {
                doctorBUS.StartExamination(data.AppointmentID, data.EncounterID, doctorId);
                data = doctorBUS.GetByAppointment(doctorId, data.AppointmentID) ?? data;
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
            labTab.SetContext(encounterId, doctorId);
            imagingTab.SetContext(encounterId, doctorId);
            prescriptionTab.SetContext(encounterId, doctorId, doctorBUS.GetMedicines());
        }

        private void LoadRecord(int encounterId)
        {
            examTab.LoadRecord(doctorBUS.GetMedicalRecord(encounterId), encounterId);
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

            foreach (DoctorHistoryDTO item in doctorBUS.GetHistory(patientId, encounterId))
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

            foreach (DoctorLabResultDTO lab in doctorBUS.GetLabResults(encounterId))
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

            foreach (DoctorImagingResultDTO img in doctorBUS.GetImagingResults(encounterId))
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
                doctorBUS.SaveMedicalRecord(examTab.BuildRecord());
                doctorBUS.CreateLabRequests(labTab.BuildRequests());
                doctorBUS.CreateImagingRequests(imagingTab.BuildRequests());

                DoctorPrescriptionSaveDTO prescription = prescriptionTab.BuildPrescription();
                if (prescription.Items.Count > 0)
                {
                    doctorBUS.CreatePrescription(prescription);
                }

                doctorBUS.CompleteExamination(selectedPatient.AppointmentID, selectedPatient.EncounterID, doctorId);

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
            if (weight <= 0 || heightCm <= 0)
            {
                return 0;
            }

            double h = (double)heightCm / 100.0;
            return (double)weight / (h * h);
        }
    }
}
