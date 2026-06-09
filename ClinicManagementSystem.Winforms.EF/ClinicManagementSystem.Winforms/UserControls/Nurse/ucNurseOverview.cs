using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    public partial class ucNurseOverview : UserControl
    {
        private readonly WaitingListController waitingListController = new WaitingListController();
        private readonly EmployeeShiftBUS employeeShiftBUS = new EmployeeShiftBUS();
        private readonly NurseWorkspaceBUS workspaceBUS = new NurseWorkspaceBUS();
        private readonly UserDTO currentUser;

        public ucNurseOverview() : this(null)
        {
        }

        public ucNurseOverview(UserDTO user)
        {
            currentUser = user;
            InitializeComponent();
            NurseUiStyle.ApplyGrid(dgvAssignments);
            NurseUiStyle.ApplyGrid(dgvRooms);
            Load += ucNurseOverview_Load;
        }

        private void ucNurseOverview_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                lblWaitingVitalCount.Text = waitingListController.GetWaitingCount().ToString("N0");
                lblCompletedCount.Text = waitingListController.GetCompletedCount().ToString("N0");
                lblRoomsCount.Text = waitingListController.GetActiveRoomCount().ToString("N0");
                lblAlertCount.Text = waitingListController.GetExaminingCount().ToString("N0");

                BindTodayShift();
                BindAssignments();
                BindRooms();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading nurse overview: " + ex.Message);
                lblWaitingVitalCount.Text = "0";
                lblCompletedCount.Text = "0";
                lblRoomsCount.Text = "0";
                lblAlertCount.Text = "0";
                dgvAssignments.Rows.Clear();
                dgvRooms.Rows.Clear();
            }
        }

        private void BindTodayShift()
        {
            List<EmployeeShiftDTO> shifts = currentUser?.EmployeeID > 0
                ? employeeShiftBUS.GetByEmployee(currentUser.EmployeeID)
                : employeeShiftBUS.GetByRole("Nurse");

            EmployeeShiftDTO today = shifts
                .Where(s => s.WorkDate.Date == DateTime.Today)
                .OrderBy(s => s.StartTime)
                .FirstOrDefault();

            if (today == null)
            {
                lblTodayShift.Text = "Chưa phân ca";
                lblTodayTime.Text = "--";
                lblTodayRoom.Text = "Phòng: --";
                lblTodayDepartment.Text = "Khoa: --";
                return;
            }

            lblTodayShift.Text = string.IsNullOrWhiteSpace(today.ShiftName) ? "Ca trực" : today.ShiftName;
            lblTodayTime.Text = $"{today.StartTime:hh\\:mm} - {today.EndTime:hh\\:mm}";
            lblTodayRoom.Text = "Phòng: " + (string.IsNullOrWhiteSpace(today.RoomCode) ? "--" : today.RoomCode);
            lblTodayDepartment.Text = "Khoa: " + (string.IsNullOrWhiteSpace(today.DepartmentName) ? "--" : today.DepartmentName);
        }

        private void BindAssignments()
        {
            int employeeId = currentUser?.EmployeeID ?? 0;
            List<NurseWorkAssignmentDTO> assignments = workspaceBUS.GetAssignments(employeeId, DateTime.Today, DateTime.Today);
            int openCount = assignments.Count(a => !IsClosed(a.Status));
            lblAssignmentCount.Text = openCount.ToString("N0") + " việc đang mở";

            dgvAssignments.Rows.Clear();
            if (assignments.Count == 0)
            {
                dgvAssignments.Rows.Add("Chưa có phân công", "-", "-", "-", "Trống");
                dgvAssignments.ClearSelection();
                return;
            }

            foreach (NurseWorkAssignmentDTO assignment in assignments)
            {
                string scope = string.Join(" | ", new[]
                {
                    assignment.DepartmentName,
                    assignment.RoomCode
                }.Where(v => !string.IsNullOrWhiteSpace(v)));

                string patient = string.IsNullOrWhiteSpace(assignment.PatientName)
                    ? "-"
                    : $"{assignment.PatientName} ({assignment.PatientCode})";

                dgvAssignments.Rows.Add(
                    assignment.Title,
                    patient,
                    string.IsNullOrWhiteSpace(scope) ? "-" : scope,
                    string.IsNullOrWhiteSpace(assignment.Priority) ? "-" : assignment.Priority,
                    string.IsNullOrWhiteSpace(assignment.Status) ? "-" : assignment.Status);
            }

            dgvAssignments.ClearSelection();
        }

        private void BindRooms()
        {
            dgvRooms.Rows.Clear();
            foreach (DoctorQueueDTO queue in waitingListController.GetDoctorQueues())
            {
                string current = string.IsNullOrWhiteSpace(queue.CurrentPatient)
                    ? "-"
                    : $"{queue.CurrentPatient} ({queue.CurrentPatientCode})";

                dgvRooms.Rows.Add(
                    queue.DoctorName,
                    queue.DepartmentName,
                    queue.RoomCode,
                    queue.WaitingCount.ToString("N0"),
                    current);
            }

            if (dgvRooms.Rows.Count == 0)
            {
                dgvRooms.Rows.Add("Chưa có lịch phòng", "-", "-", "0", "-");
            }

            dgvRooms.ClearSelection();
        }

        private static bool IsClosed(string status)
        {
            return string.Equals(status, "Done", StringComparison.OrdinalIgnoreCase)
                || string.Equals(status, "Completed", StringComparison.OrdinalIgnoreCase)
                || string.Equals(status, "Cancelled", StringComparison.OrdinalIgnoreCase);
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
