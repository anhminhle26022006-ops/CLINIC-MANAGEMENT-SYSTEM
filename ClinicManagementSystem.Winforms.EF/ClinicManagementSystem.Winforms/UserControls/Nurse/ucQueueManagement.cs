using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    public partial class ucQueueManagement : UserControl
    {
        private readonly WaitingListController waitingListController = new WaitingListController();
        private List<DoctorQueueDTO> queues = new List<DoctorQueueDTO>();
        private bool loadingDepartments;

        public ucQueueManagement()
        {
            InitializeComponent();
            NurseUiStyle.ApplyGrid(dgvQueues);
            Load += ucQueueManagement_Load;
        }

        private void ucQueueManagement_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            LoadQueue();
        }

        private void LoadDepartments()
        {
            loadingDepartments = true;
            cboDepartment.Items.Clear();
            cboDepartment.Items.Add("Tất cả khoa");
            foreach (DepartmentDTO department in waitingListController.GetDepartments())
            {
                cboDepartment.Items.Add(department.DepartmentName);
            }

            cboDepartment.SelectedIndex = 0;
            loadingDepartments = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadQueue();
        }

        private void filter_Changed(object sender, EventArgs e)
        {
            if (!loadingDepartments)
            {
                BindQueueGrid();
            }
        }

        private void LoadQueue()
        {
            try
            {
                lblWaitingCount.Text = waitingListController.GetWaitingCount().ToString("N0");
                lblExaminingCount.Text = waitingListController.GetExaminingCount().ToString("N0");
                lblCompletedCount.Text = waitingListController.GetCompletedCount().ToString("N0");
                queues = waitingListController.GetDoctorQueues();
                BindQueueGrid();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading nurse queue: " + ex.Message);
                lblWaitingCount.Text = "0";
                lblExaminingCount.Text = "0";
                lblCompletedCount.Text = "0";
                queues.Clear();
                dgvQueues.Rows.Clear();
                lstWaitingPatients.Items.Clear();
                lblCurrentPatient.Text = "Đang khám: --";
            }
        }

        private void BindQueueGrid()
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            string department = cboDepartment.SelectedItem?.ToString() ?? "Tất cả khoa";

            List<DoctorQueueDTO> filtered = queues
                .Where(q => department == "Tất cả khoa" || string.Equals(q.DepartmentName, department, StringComparison.OrdinalIgnoreCase))
                .Where(q => string.IsNullOrWhiteSpace(term)
                    || (q.DoctorName ?? string.Empty).ToLowerInvariant().Contains(term)
                    || (q.DepartmentName ?? string.Empty).ToLowerInvariant().Contains(term)
                    || (q.RoomCode ?? string.Empty).ToLowerInvariant().Contains(term)
                    || (q.CurrentPatient ?? string.Empty).ToLowerInvariant().Contains(term))
                .OrderByDescending(q => q.WaitingCount)
                .ThenBy(q => q.DepartmentName)
                .ThenBy(q => q.DoctorName)
                .ToList();

            dgvQueues.Rows.Clear();
            foreach (DoctorQueueDTO queue in filtered)
            {
                string current = string.IsNullOrWhiteSpace(queue.CurrentPatient)
                    ? "-"
                    : $"{queue.CurrentPatient} ({queue.CurrentPatientCode})";

                int rowIndex = dgvQueues.Rows.Add(
                    queue.DoctorName,
                    queue.DepartmentName,
                    queue.RoomCode,
                    queue.WaitingCount.ToString("N0"),
                    queue.ExaminingCount.ToString("N0"),
                    queue.CompletedCount.ToString("N0"),
                    current);

                dgvQueues.Rows[rowIndex].Tag = queue;
            }

            if (dgvQueues.Rows.Count > 0)
            {
                dgvQueues.Rows[0].Selected = true;
                ShowQueueDetails(dgvQueues.Rows[0].Tag as DoctorQueueDTO);
            }
            else
            {
                lstWaitingPatients.Items.Clear();
                lblCurrentPatient.Text = "Đang khám: --";
            }
        }

        private void dgvQueues_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQueues.SelectedRows.Count == 0)
            {
                return;
            }

            ShowQueueDetails(dgvQueues.SelectedRows[0].Tag as DoctorQueueDTO);
        }

        private void ShowQueueDetails(DoctorQueueDTO queue)
        {
            lstWaitingPatients.Items.Clear();
            if (queue == null)
            {
                lblCurrentPatient.Text = "Đang khám: --";
                return;
            }

            lblCurrentPatient.Text = string.IsNullOrWhiteSpace(queue.CurrentPatient)
                ? "Đang khám: --"
                : $"Đang khám: {queue.CurrentPatient} ({queue.CurrentPatientCode})";

            if (queue.WaitingPatients.Count == 0)
            {
                lstWaitingPatients.Items.Add("Không còn bệnh nhân chờ");
                return;
            }

            foreach (WaitingPatientDTO patient in queue.WaitingPatients.OrderBy(p => p.QueueNumber))
            {
                lstWaitingPatients.Items.Add($"{patient.QueueNumber}. {patient.PatientName} ({patient.PatientCode}) - {patient.AppointmentTime:HH:mm}");
            }
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

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
