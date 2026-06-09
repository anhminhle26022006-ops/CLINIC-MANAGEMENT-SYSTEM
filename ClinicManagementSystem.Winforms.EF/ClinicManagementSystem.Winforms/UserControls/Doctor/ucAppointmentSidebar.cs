using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services.Doctor;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class ucAppointmentSidebar : UserControl
    {
        private readonly DoctorWorkspaceBUS doctorBUS = new();
        private readonly UserDTO currentUser;
        private readonly int doctorId;
        private List<DoctorAppointmentDTO> appointments = new();

        public ucAppointmentSidebar() : this(null)
        {
        }

        public ucAppointmentSidebar(UserDTO currentUser)
        {
            this.currentUser = currentUser;
            doctorId = doctorBUS.ResolveDoctorId(currentUser);

            InitializeComponent();
            NormalizeGridColumns();

            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            dgvAppointments.CellContentClick += dgvAppointments_CellContentClick;
            txtSearch.TextChanged += (_, __) => LoadData();
            dtpDate.ValueChanged += (_, __) => LoadData();

            LoadData();
        }

        private void NormalizeGridColumns()
        {
            string[] names = { "colTime", "colPatient", "colDepartment", "colVital", "colStatus", "btnExamine" };
            string[] headers = { "Giờ khám", "Bệnh nhân", "Chuyên khoa", "Chỉ số", "Trạng thái", "Thao tác" };

            for (int i = 0; i < dgvAppointments.Columns.Count && i < names.Length; i++)
            {
                dgvAppointments.Columns[i].Name = names[i];
                dgvAppointments.Columns[i].HeaderText = headers[i];
            }

            if (dgvAppointments.Columns["btnExamine"] is DataGridViewButtonColumn buttonColumn)
            {
                buttonColumn.Text = "Khám";
                buttonColumn.UseColumnTextForButtonValue = true;
            }
        }

        private void LoadData()
        {
            appointments = doctorBUS.GetAppointments(doctorId, dtpDate.Value.Date, txtSearch.Text);

            dgvAppointments.Rows.Clear();
            foreach (DoctorAppointmentDTO item in appointments)
            {
                dgvAppointments.Rows.Add(
                    item.AppointmentDate.ToString("HH:mm"),
                    item.PatientName,
                    item.DepartmentName,
                    item.VitalSummary,
                    DoctorWorkspaceBUS.ToDisplayStatus(item.Status));
            }

            lblTodayCount.Text = appointments.Count.ToString();
            lblWaitingCount.Text = appointments.Count(x => IsStatus(x.Status, "Waiting")).ToString();
            lblExaminingCount.Text = appointments.Count(x => IsStatus(x.Status, "Examining")).ToString();
            lblCompletedCount.Text = appointments.Count(x => IsStatus(x.Status, "Completed")).ToString();
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= appointments.Count)
            {
                return;
            }

            if (dgvAppointments.Columns[e.ColumnIndex].Name != "btnExamine")
            {
                return;
            }

            OpenExamination(appointments[e.RowIndex]);
        }

        private void OpenExamination(DoctorAppointmentDTO appointment)
        {
            try
            {
                doctorBUS.StartExamination(appointment.AppointmentID, appointment.EncounterID, doctorId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể bắt đầu khám: " + ex.Message, "Lịch khám", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucDoctorExaminationSidebar examSidebar = new(currentUser);
            examSidebar.LoadPatientByAppointment(appointment.AppointmentID);

            Form form = FindForm();
            Panel pnlContent = form?.Controls.Find("contentPanel", true).FirstOrDefault() as Panel;
            if (pnlContent == null)
            {
                MessageBox.Show("Không tìm thấy contentPanel!");
                return;
            }

            pnlContent.Controls.Clear();
            examSidebar.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(examSidebar);
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || dgvAppointments.Columns[e.ColumnIndex].Name != "colStatus")
            {
                return;
            }

            string status = e.Value?.ToString();
            if (string.IsNullOrWhiteSpace(status))
            {
                return;
            }

            if (status.Contains("Cho") || status.Contains("Chờ"))
            {
                e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
            }
            else if (status.Contains("Dang") || status.Contains("Đang"))
            {
                e.CellStyle.BackColor = Color.FromArgb(209, 250, 229);
                e.CellStyle.ForeColor = Color.FromArgb(4, 120, 87);
            }
            else if (status.Contains("Hoan") || status.Contains("Hoàn"))
            {
                e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);
                e.CellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            }
        }

        private static bool IsStatus(string actual, string expected)
        {
            return string.Equals(actual, expected, StringComparison.OrdinalIgnoreCase);
        }
    }
}
