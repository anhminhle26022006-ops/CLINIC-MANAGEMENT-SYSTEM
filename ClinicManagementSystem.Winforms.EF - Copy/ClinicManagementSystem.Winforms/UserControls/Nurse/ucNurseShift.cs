using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    public partial class ucNurseShift : UserControl
    {
        private readonly EmployeeShiftBUS employeeShiftBUS = new EmployeeShiftBUS();
        private readonly NurseWorkspaceBUS workspaceBUS = new NurseWorkspaceBUS();
        private readonly UserDTO currentUser;
        private DateTime weekStart;

        public ucNurseShift() : this(null)
        {
        }

        public ucNurseShift(UserDTO user)
        {
            currentUser = user;
            InitializeComponent();
            NurseUiStyle.ApplyGrid(dgvShifts);
            NurseUiStyle.ApplyGrid(dgvAssignments);
            weekStart = StartOfWeek(DateTime.Today);
            dtpWeek.Value = DateTime.Today;
            Load += ucNurseShift_Load;
        }

        private void ucNurseShift_Load(object sender, EventArgs e)
        {
            LoadWeek();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWeek();
        }

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            weekStart = weekStart.AddDays(-7);
            dtpWeek.ValueChanged -= dtpWeek_ValueChanged;
            dtpWeek.Value = weekStart;
            dtpWeek.ValueChanged += dtpWeek_ValueChanged;
            LoadWeek();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            weekStart = weekStart.AddDays(7);
            dtpWeek.ValueChanged -= dtpWeek_ValueChanged;
            dtpWeek.Value = weekStart;
            dtpWeek.ValueChanged += dtpWeek_ValueChanged;
            LoadWeek();
        }

        private void dtpWeek_ValueChanged(object sender, EventArgs e)
        {
            weekStart = StartOfWeek(dtpWeek.Value.Date);
            LoadWeek();
        }

        private void LoadWeek()
        {
            DateTime weekEnd = weekStart.AddDays(6);
            List<EmployeeShiftDTO> shifts = currentUser?.EmployeeID > 0
                ? employeeShiftBUS.GetByEmployee(currentUser.EmployeeID)
                : employeeShiftBUS.GetByRole("Nurse");

            shifts = shifts
                .Where(s => s.WorkDate.Date >= weekStart && s.WorkDate.Date <= weekEnd)
                .OrderBy(s => s.WorkDate)
                .ThenBy(s => s.StartTime)
                .ToList();

            BindShiftStats(shifts);
            BindShiftGrid(shifts);
            BindAssignments(weekEnd);
        }

        private void BindShiftStats(List<EmployeeShiftDTO> shifts)
        {
            lblTotalShifts.Text = shifts.Count.ToString("N0");
            lblTodayShiftCount.Text = shifts.Count(s => s.WorkDate.Date == DateTime.Today).ToString("N0");

            double hours = shifts.Sum(s =>
            {
                TimeSpan duration = s.EndTime - s.StartTime;
                return duration.TotalHours > 0 ? duration.TotalHours : 0;
            });

            lblHours.Text = $"{hours:N0}h";
        }

        private void BindShiftGrid(List<EmployeeShiftDTO> shifts)
        {
            dgvShifts.Rows.Clear();
            if (shifts.Count == 0)
            {
                dgvShifts.Rows.Add($"{weekStart:dd/MM} - {weekStart.AddDays(6):dd/MM}", "Chưa phân ca", "-", "-", "-", "-");
                dgvShifts.ClearSelection();
                return;
            }

            foreach (EmployeeShiftDTO shift in shifts)
            {
                dgvShifts.Rows.Add(
                    $"{shift.WorkDate:dd/MM/yyyy}",
                    Empty(shift.ShiftName),
                    $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}",
                    Empty(shift.DepartmentName),
                    Empty(shift.RoomCode),
                    Empty(shift.Status));
            }

            dgvShifts.ClearSelection();
        }

        private void BindAssignments(DateTime weekEnd)
        {
            int employeeId = currentUser?.EmployeeID ?? 0;
            List<NurseWorkAssignmentDTO> assignments = workspaceBUS.GetAssignments(employeeId, weekStart, weekEnd);

            dgvAssignments.Rows.Clear();
            if (assignments.Count == 0)
            {
                dgvAssignments.Rows.Add("Chưa có phân công trong tuần", "-", "-", "-");
                dgvAssignments.ClearSelection();
                return;
            }

            foreach (NurseWorkAssignmentDTO item in assignments)
            {
                string patient = string.IsNullOrWhiteSpace(item.PatientName)
                    ? "-"
                    : $"{item.PatientName} ({item.PatientCode})";

                dgvAssignments.Rows.Add(
                    $"{item.WorkDate:dd/MM} - {item.Title}",
                    patient,
                    Empty(item.Priority),
                    Empty(item.Status));
            }

            dgvAssignments.ClearSelection();
        }

        private static DateTime StartOfWeek(DateTime date)
        {
            int diff = ((int)date.DayOfWeek + 6) % 7;
            return date.Date.AddDays(-diff);
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
