using BUS.Services;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RoleConst = CMS.Core.Identity.Role;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftManagement : UserControl
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;

        private EmployeeBUS employeeBUS;
        private EmployeeShiftBUS employeeShiftBUS;
        private WorkShiftBUS workShiftBUS;
        private DepartmentBUS departmentBUS;
        private RoomBUS roomBUS;

        private List<EmployeeDTO> employees = new List<EmployeeDTO>();
        private List<EmployeeShiftDTO> shifts = new List<EmployeeShiftDTO>();
        private List<WorkShiftDTO> workShifts = new List<WorkShiftDTO>();
        private List<DepartmentDTO> departments = new List<DepartmentDTO>();
        private List<RoomDTO> rooms = new List<RoomDTO>();

        public ucShiftManagement()
        {
            InitializeComponent();
            AdminUiStyle.ApplyGrid(dgvShifts);

            // Thêm các cột động (giữ nguyên logic cũ)
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmpName", HeaderText = "TÊN NHÂN VIÊN", FillWeight = 15 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRole", HeaderText = "VAI TRÒ", FillWeight = 10 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDept", HeaderText = "CHUYÊN KHOA", FillWeight = 15 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colShift", HeaderText = "CA TRỰC", FillWeight = 10 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTime", HeaderText = "THỜI GIAN", FillWeight = 15 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRoom", HeaderText = "PHÒNG TRỰC", FillWeight = 12 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "TRẠNG THÁI", FillWeight = 10 });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colView", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEdit", HeaderText = "", FillWeight = 5, ReadOnly = true });
            dgvShifts.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDelete", HeaderText = "", FillWeight = 5, ReadOnly = true });
        }

        public ucShiftManagement(CMSDbContext context, UserDTO currentUser) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            // Khởi tạo BUS với context (chỉ EmployeeBUS cần context)
            employeeBUS = new EmployeeBUS(new EmployeeDAL(_context));
            employeeShiftBUS = new EmployeeShiftBUS();
            workShiftBUS = new WorkShiftBUS();
            departmentBUS = new DepartmentBUS();
            roomBUS = new RoomBUS();

            if (!CMS.Core.Identity.RoleNormalizer.Normalize(_currentUser.Role).Equals(RoleConst.Admin, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.", "Không thể truy cập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
            }
            else
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            employees = employeeBUS.GetAll();
            shifts = employeeShiftBUS.GetAll();
            workShifts = workShiftBUS.GetAll();
            departments = departmentBUS.GetAll();
            rooms = roomBUS.GetAll();
            BindEmployeeFilter();
            ApplyFilters();
        }

        private void BindEmployeeFilter()
        {
            cboEmployee.SelectedIndexChanged -= cboEmployee_SelectedIndexChanged;
            cboEmployee.DisplayMember = "Text";
            cboEmployee.ValueMember = "Value";
            cboEmployee.DataSource = new[]
            {
                new { Text = "Tất cả nhân viên", Value = 0 }
            }
            .Concat(employees.Select(emp => new { Text = emp.FullName, Value = emp.EmployeeID }))
            .ToList();
            cboEmployee.SelectedIndexChanged += cboEmployee_SelectedIndexChanged;
        }

        private void ApplyFilters()
        {
            int employeeId = 0;
            if (cboEmployee.SelectedValue is int selectedId)
            {
                employeeId = selectedId;
            }

            DateTime selectedDate = dtpDate.Value.Date;
            var filtered = shifts.Where(shift =>
                shift.WorkDate.Date == selectedDate
                && (employeeId == 0 || shift.EmployeeID == employeeId))
                .OrderBy(shift => shift.StartTime)
                .ThenBy(shift => shift.EmployeeName)
                .ToList();

            BindKpiCards(selectedDate);
            dgvShifts.Rows.Clear();
            foreach (EmployeeShiftDTO shift in filtered)
            {
                bool isCancelled = string.Equals(shift.Status, "Cancelled", StringComparison.OrdinalIgnoreCase);
                int rowIndex = dgvShifts.Rows.Add(
                    shift.EmployeeName,
                    shift.RoleName,
                    shift.DepartmentName,
                    shift.ShiftName,
                    $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}",
                    string.IsNullOrWhiteSpace(shift.RoomCode) ? "Chưa phân phòng" : shift.RoomCode,
                    string.IsNullOrWhiteSpace(shift.Status) ? "Scheduled" : shift.Status,
                    "Xem",
                    "Sửa",
                    isCancelled ? "Mở" : "Hủy");
                dgvShifts.Rows[rowIndex].Tag = shift;
            }

            dgvShifts.ClearSelection();
            lblPaging.Text = $"Hiển thị {filtered.Count}/{shifts.Count} ca trực";
        }

        private void BindKpiCards(DateTime selectedDate)
        {
            var dayShifts = shifts.Where(shift => shift.WorkDate.Date == selectedDate).ToList();

            lblOnDutyValue.Text = AdminUiStyle.CountText(dayShifts.Count);
            lblMorningValue.Text = AdminUiStyle.CountText(dayShifts.Count(IsMorningShift));
            lblAfternoonValue.Text = AdminUiStyle.CountText(dayShifts.Count(IsAfternoonShift));
            lblNightValue.Text = AdminUiStyle.CountText(dayShifts.Count(IsNightShift));
        }

        private bool IsMorningShift(EmployeeShiftDTO shift)
        {
            string name = shift.ShiftName ?? string.Empty;
            return name.Contains("Sáng", StringComparison.OrdinalIgnoreCase)
                || name.Contains("Morning", StringComparison.OrdinalIgnoreCase)
                || shift.StartTime.Hours < 12;
        }

        private bool IsAfternoonShift(EmployeeShiftDTO shift)
        {
            string name = shift.ShiftName ?? string.Empty;
            return name.Contains("Chiều", StringComparison.OrdinalIgnoreCase)
                || name.Contains("Afternoon", StringComparison.OrdinalIgnoreCase)
                || (shift.StartTime.Hours >= 12 && shift.StartTime.Hours < 18);
        }

        private bool IsNightShift(EmployeeShiftDTO shift)
        {
            string name = shift.ShiftName ?? string.Empty;
            return name.Contains("Tối", StringComparison.OrdinalIgnoreCase)
                || name.Contains("Đêm", StringComparison.OrdinalIgnoreCase)
                || name.Contains("Night", StringComparison.OrdinalIgnoreCase)
                || shift.StartTime.Hours >= 18;
        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            EmployeeDTO employee = employees.FirstOrDefault();
            WorkShiftDTO workShift = workShifts.FirstOrDefault();
            DepartmentDTO department = employee != null
                ? departments.FirstOrDefault(item => item.DepartmentID == employee.DepartmentID)
                : departments.FirstOrDefault();

            EmployeeShiftDTO draft = new EmployeeShiftDTO
            {
                EmployeeID = employee?.EmployeeID ?? 0,
                ShiftID = workShift?.ShiftID ?? 0,
                WorkDate = dtpDate.Value.Date,
                DepartmentID = department?.DepartmentID,
                Status = "Approved"
            };

            if (AdminRecordDialogs.EditShift(draft, employees, workShifts, departments, rooms, true, out EmployeeShiftDTO created))
            {
                try
                {
                    if (employeeShiftBUS.RegisterShift(created))
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Không thể thêm ca trực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) => ApplyFilters();
        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();

        private void dgvShifts_CellClick(object sender, DataGridViewCellEventArgs e) => HandleShiftGridAction(e);

        private void dgvShifts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string columnName = dgvShifts.Columns[e.ColumnIndex].Name;
            if (columnName is "colView" or "colEdit" or "colDelete")
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                e.CellStyle.Font = new Font(dgvShifts.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }
        private void panelKPI_Resize(object sender, EventArgs e) { }
        private void dgvShifts_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void HandleShiftGridAction(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvShifts.Rows[e.RowIndex].Tag is not EmployeeShiftDTO shift)
                return;

            string columnName = dgvShifts.Columns[e.ColumnIndex].Name;
            if (columnName == "colView")
            {
                AdminRecordDialogs.ShowShift(shift);
                return;
            }

            if (columnName == "colEdit")
            {
                if (!CanEditShiftDate(shift.WorkDate)) return;
                if (AdminRecordDialogs.EditShift(shift, employees, workShifts, departments, rooms, false, out EmployeeShiftDTO edited))
                {
                    try
                    {
                        if (employeeShiftBUS.UpdateShift(edited)) LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Không thể sửa ca trực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                return;
            }

            if (columnName == "colDelete")
            {
                bool reopen = string.Equals(shift.Status, "Cancelled", StringComparison.OrdinalIgnoreCase);
                string nextStatus = reopen ? "Approved" : "Cancelled";
                string message = reopen
                    ? $"Mở lại ca trực của {shift.EmployeeName} ngày {shift.WorkDate:dd/MM/yyyy}?"
                    : $"Hủy ca trực của {shift.EmployeeName} ngày {shift.WorkDate:dd/MM/yyyy}?";

                if (MessageBox.Show(message, "Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    && employeeShiftBUS.SetStatus(shift.EmployeeShiftID, nextStatus))
                {
                    LoadData();
                }
            }
        }

        private static bool CanEditShiftDate(DateTime workDate)
        {
            if (workDate.Date >= DateTime.Today) return true;
            MessageBox.Show("Không thể sửa ca trực trong quá khứ.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }
    }
}