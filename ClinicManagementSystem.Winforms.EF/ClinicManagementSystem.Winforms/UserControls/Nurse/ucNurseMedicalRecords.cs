using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    public partial class ucNurseMedicalRecords : UserControl
    {
        private readonly NurseWorkspaceBUS workspaceBUS = new NurseWorkspaceBUS();
        private readonly UserDTO currentUser;
        private List<NurseMedicalRecordDTO> records = new List<NurseMedicalRecordDTO>();

        public ucNurseMedicalRecords() : this(null)
        {
        }

        public ucNurseMedicalRecords(UserDTO user)
        {
            currentUser = user;
            InitializeComponent();
            NurseUiStyle.ApplyGrid(dgvRecords);
            Load += ucNurseMedicalRecords_Load;
        }

        private void ucNurseMedicalRecords_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void LoadRecords()
        {
            try
            {
                records = workspaceBUS.SearchMedicalRecords(string.Empty);
                BindGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading nurse medical records: " + ex.Message);
                records.Clear();
                dgvRecords.Rows.Clear();
                ClearDetail();
            }
        }

        private void BindGrid()
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            IEnumerable<NurseMedicalRecordDTO> filtered = records.Where(record =>
                string.IsNullOrWhiteSpace(term)
                || (record.PatientName ?? string.Empty).ToLowerInvariant().Contains(term)
                || (record.PatientCode ?? string.Empty).ToLowerInvariant().Contains(term)
                || record.EncounterID.ToString().Contains(term));

            dgvRecords.Rows.Clear();
            foreach (NurseMedicalRecordDTO record in filtered.OrderByDescending(r => r.StartTime ?? DateTime.MinValue))
            {
                int rowIndex = dgvRecords.Rows.Add(
                    record.EncounterID,
                    $"{record.PatientName} ({record.PatientCode})",
                    record.StartTime?.ToString("dd/MM/yyyy HH:mm") ?? "--",
                    string.IsNullOrWhiteSpace(record.DoctorName) ? "-" : record.DoctorName,
                    string.IsNullOrWhiteSpace(record.EncounterStatus) ? "-" : record.EncounterStatus,
                    HasVital(record) ? "Đã đo" : "Chưa đo");

                dgvRecords.Rows[rowIndex].Tag = record;
            }

            if (dgvRecords.Rows.Count > 0)
            {
                dgvRecords.Rows[0].Selected = true;
                ShowDetail(dgvRecords.Rows[0].Tag as NurseMedicalRecordDTO);
            }
            else
            {
                ClearDetail();
            }
        }

        private void dgvRecords_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecords.SelectedRows.Count == 0)
            {
                return;
            }

            ShowDetail(dgvRecords.SelectedRows[0].Tag as NurseMedicalRecordDTO);
        }

        private void ShowDetail(NurseMedicalRecordDTO record)
        {
            if (record == null)
            {
                ClearDetail();
                return;
            }

            lblPatientInfo.Text = $"{record.PatientName} ({record.PatientCode})\n{record.Gender} - {record.Age} tuổi";
            lblVisitInfo.Text = $"Lượt khám: {record.EncounterID}\nBác sĩ: {Empty(record.DoctorName)} | Khoa: {Empty(record.DepartmentName)}";
            lblVitalInfo.Text = HasVital(record)
                ? $"Sinh hiệu gần nhất\nNhiệt: {record.Temperature:N1}°C | HA: {Empty(record.BloodPressure)} | Mạch: {record.HeartRate} | SpO2: {record.Spo2}%"
                : "Sinh hiệu: chưa có";
            txtDiagnosis.Text = Empty(record.Diagnosis);
            txtNursingNote.Text = Empty(record.NursingNote);
        }

        private void ClearDetail()
        {
            lblPatientInfo.Text = "Chọn hồ sơ để xem chi tiết";
            lblVisitInfo.Text = "Ngày khám: --";
            lblVitalInfo.Text = "Sinh hiệu: chưa có";
            txtDiagnosis.Clear();
            txtNursingNote.Clear();
        }

        private static bool HasVital(NurseMedicalRecordDTO record)
        {
            return record.Temperature.HasValue
                || !string.IsNullOrWhiteSpace(record.BloodPressure)
                || record.HeartRate.HasValue
                || record.Spo2.HasValue;
        }

        private static string Empty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Control control)
            {
                return;
            }

            using Pen pen = new Pen(NurseUiStyle.Border);
            e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
        }
    }
}
