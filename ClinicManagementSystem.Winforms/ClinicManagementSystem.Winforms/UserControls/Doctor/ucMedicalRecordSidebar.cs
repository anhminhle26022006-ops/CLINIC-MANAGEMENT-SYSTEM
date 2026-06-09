using BUS.Services.ERM;
using ClinicManagementSystem.Winforms.Controllers;
using DAL.DataContext;
using DAL.Repositories.ERM;
using DTO;
using DTO.Clinical.erm;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucMedicalRecordSidebar : UserControl
    {
        private readonly UserDTO currentUser;
        private List<MedicalRecordDto> _data = new List<MedicalRecordDto>();

        public ucMedicalRecordSidebar() : this(null)
        {
        }

        public ucMedicalRecordSidebar(UserDTO user)
        {
            InitializeComponent();
            currentUser = user;
            LoadData();
        }

        private void LoadData()
        {
            _data = LoadRecordsFromDatabase();
            LoadGrid(_data);

            lblTotal.Text = _data.Count.ToString();
            lblToday.Text = _data.Count(x => x.Date.Date == DateTime.Today).ToString();
            lblWeek.Text = _data.Count(x => x.Date >= DateTime.Today.AddDays(-7)).ToString();
            lblTracking.Text = _data.Count(x => x.Status == "Đang theo dõi").ToString();

            cboStatus.SelectedIndex = 0;
        }

        private List<MedicalRecordDto> LoadRecordsFromDatabase()
        {
            List<MedicalRecordDto> records = new List<MedicalRecordDto>();
            if (!SchemaHelper.TableExists("Encounters") || !SchemaHelper.TableExists("Patients"))
            {
                return records;
            }

            string patientUuidExpression = SchemaHelper.ColumnExists("Patients", "PatientUUID")
                ? "p.PatientUUID"
                : "NULL";

            string query = $@"
                SELECT TOP 200
                    e.EncounterID,
                    {patientUuidExpression} AS PatientUUID,
                    COALESCE(e.StartTime, e.CreatedAt, GETDATE()) AS VisitDate,
                    ISNULL(p.FullName, '') AS PatientName,
                    ISNULL(emp.FullName, '') AS DoctorName,
                    ISNULL(NULLIF(mr.Diagnosis, ''), ISNULL(e.Status, '')) AS Diagnosis,
                    ISNULL(NULLIF(e.Status, ''), N'Đang theo dõi') AS Status
                FROM Encounters e
                INNER JOIN Patients p ON e.PatientID = p.PatientID
                LEFT JOIN Employees emp ON e.DoctorID = emp.EmployeeID
                LEFT JOIN MedicalRecords mr ON e.EncounterID = mr.EncounterID
                WHERE (@DoctorID = 0 OR e.DoctorID = @DoctorID)
                ORDER BY COALESCE(e.StartTime, e.CreatedAt, GETDATE()) DESC";

            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@DoctorID", currentUser?.EmployeeID ?? 0)
            });

            foreach (DataRow row in table.Rows)
            {
                int encounterId = Convert.ToInt32(row["EncounterID"]);
                records.Add(new MedicalRecordDto
                {
                    RecordID = encounterId,
                    PatientUUID = row["PatientUUID"] != DBNull.Value ? Guid.Parse(row["PatientUUID"].ToString()) : Guid.Empty,
                    Code = "ENC" + encounterId.ToString("D5"),
                    Date = Convert.ToDateTime(row["VisitDate"]),
                    Patient = row["PatientName"].ToString(),
                    Diagnosis = row["Diagnosis"].ToString(),
                    Doctor = row["DoctorName"].ToString(),
                    Status = row["Status"].ToString()
                });
            }

            return records;
        }

        private void dgvRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRecords.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                e.CellStyle.ForeColor = Color.White;

                if (status == "Hoàn thành")
                    e.CellStyle.BackColor = Color.SeaGreen;
                else if (status == "Đang theo dõi")
                    e.CellStyle.BackColor = Color.DarkOrange;
                else
                    e.CellStyle.BackColor = Color.Gray;
            }
        }

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvRecords.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if (dgvRecords.Rows[e.RowIndex].Tag is not MedicalRecordDto record || record.PatientUUID == Guid.Empty)
                {
                    MessageBox.Show("Hồ sơ này chưa có PatientUUID để mở ERM chi tiết.", "Bệnh án", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var controller = new ERMController(new ERMBus(new ERMRepository()));
                using var frm = new ERMform(controller, record.PatientUUID);
                frm.ShowDialog();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var query = _data.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query = query.Where(x =>
                    x.Code.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                    x.Patient.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase));
            }

            if (cboStatus.SelectedIndex == 1)
                query = query.Where(x => x.Status == "Hoàn thành");

            if (cboStatus.SelectedIndex == 2)
                query = query.Where(x => x.Status == "Đang theo dõi");

            query = query.Where(x =>
                x.Date >= dtFrom.Value.Date &&
                x.Date <= dtTo.Value.Date);

            LoadGrid(query.ToList());
        }

        private void LoadGrid(List<MedicalRecordDto> list)
        {
            dgvRecords.Rows.Clear();

            foreach (var x in list)
            {
                int rowIndex = dgvRecords.Rows.Add(
                    x.Code,
                    x.Date.ToString("dd/MM/yyyy"),
                    x.Patient,
                    x.Diagnosis,
                    x.Doctor,
                    x.Status
                );
                dgvRecords.Rows[rowIndex].Tag = x;
            }
        }
    }
}
