using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPrescriptionDispense : PharmacyDashboardViewBase
    {
        private const string SearchPlaceholder = "Tìm kiếm theo tên BN hoặc số toa...";

        private readonly PrescriptionBUS prescriptionBUS = new PrescriptionBUS();
        private readonly List<PrescriptionDTO> visiblePrescriptions = new List<PrescriptionDTO>();

        private List<PrescriptionDTO> pendingPrescriptions = new List<PrescriptionDTO>();
        private PrescriptionDTO selectedPrescription;
        private int dispensedTodayCount;
        private bool eventsInitialized;

        public ucPrescriptionDispense()
        {
            InitializeComponent();
        }

        private void ucPrescriptionDispense_Load(object sender, EventArgs e)
        {
            InitializeRuntimeEvents();
            LoadPrescriptions();
        }

        private void InitializeRuntimeEvents()
        {
            if (eventsInitialized)
            {
                return;
            }

            txtPrescriptionSearch.Enter += TxtPrescriptionSearch_Enter;
            txtPrescriptionSearch.Leave += TxtPrescriptionSearch_Leave;
            txtPrescriptionSearch.TextChanged += (s, ev) => FilterPrescriptions();
            cboStatus.SelectedIndexChanged += (s, ev) => FilterPrescriptions();
            btnDispense.Click += BtnDispense_Click;

            foreach (var card in QueueCards)
            {
                card.CardSelected += QueueCard_Selected;
            }

            eventsInitialized = true;
        }

        private void TxtPrescriptionSearch_Enter(object sender, EventArgs e)
        {
            if (txtPrescriptionSearch.Text == SearchPlaceholder)
            {
                txtPrescriptionSearch.Text = string.Empty;
                SetSearchActiveState();
            }
        }

        private void TxtPrescriptionSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrescriptionSearch.Text))
            {
                txtPrescriptionSearch.Text = SearchPlaceholder;
                SetSearchPlaceholderState();
            }
        }

        private void LoadPrescriptions()
        {
            try
            {
                pendingPrescriptions = prescriptionBUS.GetPendingPrescriptions();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading prescriptions: " + ex);
                pendingPrescriptions = new List<PrescriptionDTO>();
            }

            cboStatus.SelectedIndex = cboStatus.SelectedIndex < 0 ? 0 : cboStatus.SelectedIndex;
            UpdateStats();
            FilterPrescriptions();
        }

        private void UpdateStats()
        {
            int waitingCount = pendingPrescriptions.Count(IsWaitingStatus);
            int preparingCount = pendingPrescriptions.Count(IsPreparingStatus);
            int totalCount = waitingCount + preparingCount + dispensedTodayCount;

            lblWaitingNumber.Text = waitingCount.ToString();
            lblPreparingNumber.Text = preparingCount.ToString();
            lblDoneNumber.Text = dispensedTodayCount.ToString();
            lblTotalNumber.Text = totalCount.ToString();
        }

        private void FilterPrescriptions()
        {
            string term = txtPrescriptionSearch.Text == SearchPlaceholder
                ? string.Empty
                : txtPrescriptionSearch.Text.Trim().ToLower();

            string status = cboStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            var filtered = pendingPrescriptions
                .Where(p => MatchesSearch(p, term) && MatchesStatus(p, status))
                .ToList();

            RenderPrescriptions(filtered);
        }

        private static bool MatchesSearch(PrescriptionDTO prescription, string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                return true;
            }

            return (prescription.PatientName ?? string.Empty).ToLower().Contains(term)
                || prescription.PrescriptionID.ToString().Contains(term)
                || (prescription.PatientCode ?? string.Empty).ToLower().Contains(term);
        }

        private static bool MatchesStatus(PrescriptionDTO prescription, string status)
        {
            if (status == "Tất cả trạng thái")
            {
                return true;
            }

            if (status == "Chờ cấp phát")
            {
                return IsWaitingStatus(prescription);
            }

            if (status == "Đang chuẩn bị")
            {
                return IsPreparingStatus(prescription);
            }

            return IsCompletedStatus(prescription.Status);
        }

        private void RenderPrescriptions(List<PrescriptionDTO> list)
        {
            visiblePrescriptions.Clear();
            visiblePrescriptions.AddRange(list.Take(QueueCards.Length));

            for (int i = 0; i < QueueCards.Length; i++)
            {
                if (i < visiblePrescriptions.Count)
                {
                    QueueCards[i].Configure(visiblePrescriptions[i]);
                    QueueCards[i].Visible = true;
                    continue;
                }

                QueueCards[i].Clear();
                QueueCards[i].Visible = false;
            }

            SetQueueState(list.Count, visiblePrescriptions.Count);

            if (visiblePrescriptions.Count == 0)
            {
                ClearDetails();
                return;
            }

            SelectPrescription(visiblePrescriptions[0]);
        }

        private void QueueCard_Selected(object sender, EventArgs e)
        {
            if (sender is not ucPharmacyPrescriptionQueueCard card)
            {
                return;
            }

            var prescription = visiblePrescriptions.FirstOrDefault(p => p.PrescriptionID == card.PrescriptionId);
            if (prescription != null)
            {
                SelectPrescription(prescription);
            }
        }

        private void SelectPrescription(PrescriptionDTO prescription)
        {
            selectedPrescription = prescription;
            pnlPrescriptionCard.Visible = true;
            lblEmptyDetail.Visible = false;

            lblPatientName.Text = prescription.PatientName;
            lblPatientMeta.Text = BuildPatientMeta(prescription);
            lblPrescriptionCode.Text = "TOA THUỐC #" + prescription.PrescriptionID;
            lblDoctor.Text = "Bác sĩ kê toa: " + prescription.DoctorName;
            lblDate.Text = prescription.CreatedAt.ToString("dd/MM/yyyy");
            lblTime.Text = prescription.CreatedAt.ToString("HH:mm");
            lblAvatar.Text = string.IsNullOrWhiteSpace(prescription.PatientName)
                ? "P"
                : prescription.PatientName.Substring(0, 1).ToUpper();

            lblDiagnosis.Text = string.IsNullOrWhiteSpace(prescription.Diagnosis)
                ? "Chưa cập nhật chẩn đoán."
                : prescription.Diagnosis;

            lblNoteContent.Text = string.IsNullOrWhiteSpace(prescription.DoctorNotes)
                ? "Không có lời dặn đặc biệt."
                : prescription.DoctorNotes;

            bool hasAllergy = HasAllergy(prescription.PatientAllergies);
            lblAllergy.Text = hasAllergy
                ? "Dị ứng: " + prescription.PatientAllergies
                : "Không phát hiện dị ứng thuốc.";
            lblChronic.Text = "Tiền sử bệnh án: Không có bệnh nền nguy hiểm.";

            SetDetailStatus(prescription.Status);
            SetWarningState(hasAllergy);
            BindMedicineCards(prescription.Items);
            SetSelectedQueueCard(prescription.PrescriptionID);

            btnDispense.Enabled = true;
        }

        private static string BuildPatientMeta(PrescriptionDTO prescription)
        {
            int age = 0;
            if (prescription.PatientDOB.HasValue)
            {
                DateTime dob = prescription.PatientDOB.Value;
                age = DateTime.Today.Year - dob.Year;
                if (dob.Date > DateTime.Today.AddYears(-age))
                {
                    age--;
                }
            }

            string gender = string.IsNullOrWhiteSpace(prescription.PatientGender)
                ? "Chưa cập nhật giới tính"
                : prescription.PatientGender;

            string patientCode = string.IsNullOrWhiteSpace(prescription.PatientCode)
                ? "Chưa có mã BN"
                : prescription.PatientCode;

            return gender + " - " + age + " tuổi - Mã BN: " + patientCode;
        }

        private void BindMedicineCards(List<PrescriptionItemDTO> items)
        {
            var medicineItems = items ?? new List<PrescriptionItemDTO>();
            int visibleCount = Math.Min(medicineItems.Count, MedicineCards.Length);

            for (int i = 0; i < MedicineCards.Length; i++)
            {
                if (i < visibleCount)
                {
                    MedicineCards[i].Configure(medicineItems[i], i + 1);
                    MedicineCards[i].Visible = true;
                    continue;
                }

                MedicineCards[i].Clear();
                MedicineCards[i].Visible = false;
            }

            SetMedicineListState(medicineItems.Count, visibleCount);
        }

        private void ClearDetails()
        {
            selectedPrescription = null;
            pnlPrescriptionCard.Visible = false;
            lblEmptyDetail.Visible = true;
            btnDispense.Enabled = false;
            SetSelectedQueueCard(0);
        }

        private void BtnDispense_Click(object sender, EventArgs e)
        {
            if (selectedPrescription == null)
            {
                return;
            }

            var result = MessageBox.Show(
                "Xác nhận cấp phát thuốc cho bệnh nhân " + selectedPrescription.PatientName + "?",
                "Cấp phát thuốc",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (var item in selectedPrescription.Items)
                {
                    prescriptionBUS.DispenseMedicine(item.MedicineID, item.Quantity);
                }

                prescriptionBUS.CompletePrescription(selectedPrescription.PrescriptionID);
                dispensedTodayCount++;

                MessageBox.Show(
                    "Đã cấp phát thành công đơn thuốc #" + selectedPrescription.PrescriptionID + ".",
                    "Cấp phát thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadPrescriptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể cấp phát đơn thuốc:\n" + ex.Message,
                    "Lỗi cấp phát",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private static bool HasAllergy(string allergy)
        {
            return !string.IsNullOrWhiteSpace(allergy)
                && allergy.Trim() != "Không"
                && allergy.Trim() != "None";
        }

        private static bool IsWaitingStatus(PrescriptionDTO prescription)
        {
            return prescription.Status == "Chờ cấp phát" || prescription.Status == "Pending";
        }

        private static bool IsPreparingStatus(PrescriptionDTO prescription)
        {
            return !IsWaitingStatus(prescription) && !IsCompletedStatus(prescription.Status);
        }

        private static bool IsCompletedStatus(string status)
        {
            return status == "Completed" || status == "Đã cấp phát" || status == "Dispensed";
        }
    }
}
