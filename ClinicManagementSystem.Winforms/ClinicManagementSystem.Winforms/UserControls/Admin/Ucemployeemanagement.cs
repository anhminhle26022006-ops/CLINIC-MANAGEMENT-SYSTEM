using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucEmployeeManagement : UserControl
    {
        private readonly EmployeeBUS employeeBUS = new EmployeeBUS(new EmployeeDAL());
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private List<EmployeeDTO> employees = new List<EmployeeDTO>();

        public ucEmployeeManagement()
        {
            InitializeComponent();
            AdminUiStyle.ApplyGrid(dgvEmployees);
            EnsureColumns();
            LoadData();
        }

        private void EnsureColumns()
        {
            string[] names =
            {
                "colCode",
                "colName",
                "colRole",
                "colDepartment",
                "colContact",
                "colStatus",
                "colView",
                "colEdit",
                "colDelete"
            };

            string[] headers =
            {
                "MÃ NV",
                "HỌ TÊN",
                "VAI TRÒ",
                "KHOA/PHÒNG",
                "LIÊN HỆ",
                "TRẠNG THÁI",
                "XEM",
                "SỬA",
                "XÓA"
            };

            for (int i = 0; i < dgvEmployees.Columns.Count && i < names.Length; i++)
            {
                dgvEmployees.Columns[i].Name = names[i];
                dgvEmployees.Columns[i].HeaderText = headers[i];
                dgvEmployees.Columns[i].ReadOnly = true;
            }
        }

        public void LoadData()
        {
            employees = employeeBUS.GetAll();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            string role = cboChucVu.SelectedItem?.ToString() ?? "Tất cả chức vụ";

            var filtered = employees.Where(emp =>
                (string.IsNullOrWhiteSpace(term)
                    || (emp.EmployeeCode ?? "").ToLowerInvariant().Contains(term)
                    || (emp.FullName ?? "").ToLowerInvariant().Contains(term)
                    || (emp.Phone ?? "").ToLowerInvariant().Contains(term)
                    || (emp.Email ?? "").ToLowerInvariant().Contains(term))
                && (role == "Tất cả chức vụ" || string.Equals(emp.RoleName, role, StringComparison.OrdinalIgnoreCase)))
                .OrderBy(emp => emp.RoleName)
                .ThenBy(emp => emp.FullName)
                .ToList();

            BindKpiCards();
            dgvEmployees.Rows.Clear();
            foreach (EmployeeDTO emp in filtered)
            {
                bool isInactive = string.Equals(emp.Status, "Inactive", StringComparison.OrdinalIgnoreCase);
                int rowIndex = dgvEmployees.Rows.Add(
                    emp.EmployeeCode,
                    emp.FullName,
                    emp.RoleName,
                    emp.DepartmentName,
                    string.Join(" | ", new[] { emp.Phone, emp.Email }.Where(v => !string.IsNullOrWhiteSpace(v))),
                    string.IsNullOrWhiteSpace(emp.Status) ? "Active" : emp.Status,
                    "Xem",
                    "Sửa",
                    isInactive ? "Kích hoạt" : "Ngưng");
                dgvEmployees.Rows[rowIndex].Tag = emp;
            }

            dgvEmployees.ClearSelection();
            lblPaging.Text = $"Hiển thị {filtered.Count}/{employees.Count} nhân viên";
        }

        private void BindKpiCards()
        {
            lblBacSiValue.Text = AdminUiStyle.CountText(CountRole("Doctor", "Bác sĩ", "Bac si"));
            lblYTaValue.Text = AdminUiStyle.CountText(CountRole("Nurse", "Y tá", "Y ta"));
            lblDuocSiValue.Text = AdminUiStyle.CountText(CountRole("Pharmacist", "Dược sĩ", "Duoc si"));
            lblKyThuatValue.Text = AdminUiStyle.CountText(CountRole("Technician", "Kỹ thuật viên", "Ky thuat vien"));
            lblLeTanValue.Text = AdminUiStyle.CountText(CountRole("Receptionist", "Lễ tân", "Le tan"));
        }

        private int CountRole(params string[] roleNames)
        {
            return employees.Count(emp => roleNames.Any(role =>
                string.Equals(emp.RoleName, role, StringComparison.OrdinalIgnoreCase)));
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (AdminRecordDialogs.CreateEmployee(GetRoleOptions(), departmentBUS.GetAll(), out EmployeeDTO created))
            {
                try
                {
                    if (employeeBUS.Add(created))
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm nhân viên. Vui lòng kiểm tra mã nhân viên/email/CCCD có bị trùng không.\n" + ex.Message, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void panelHeader_Resize(object sender, EventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvEmployees.Rows[e.RowIndex].Tag is not EmployeeDTO employee)
            {
                return;
            }

            string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;
            if (columnName == "colView")
            {
                AdminRecordDialogs.ShowEmployee(employee);
                return;
            }

            if (columnName == "colEdit")
            {
                if (AdminRecordDialogs.EditEmployee(employee, GetRoleOptions(), departmentBUS.GetAll(), out EmployeeDTO edited) && employeeBUS.UpdateBasic(edited))
                {
                    LoadData();
                }
                return;
            }

            if (columnName == "colDelete")
            {
                bool activate = string.Equals(employee.Status, "Inactive", StringComparison.OrdinalIgnoreCase);
                string nextStatus = activate ? "Active" : "Inactive";
                string message = activate
                    ? $"Kích hoạt lại nhân viên {employee.FullName}?"
                    : $"Ngưng hoạt động nhân viên {employee.FullName}? Hồ sơ liên quan vẫn được giữ lại.";

                if (MessageBox.Show(message, "Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    && employeeBUS.SetStatus(employee.EmployeeID, nextStatus))
                {
                    LoadData();
                }
            }
        }

        private void dgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;
            if (columnName is "colView" or "colEdit" or "colDelete")
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                e.CellStyle.Font = new Font(dgvEmployees.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvEmployees_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private List<string> GetRoleOptions()
        {
            string[] defaultRoles = { "Doctor", "Nurse", "Pharmacist", "Technician", "Receptionist", "Admin" };
            return employees
                .Select(emp => emp.RoleName)
                .Where(role => !string.IsNullOrWhiteSpace(role))
                .Concat(defaultRoles)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(role => role)
                .ToList();
        }

        private void PanelRoundedBorder(object sender, PaintEventArgs e)
        {
            if (sender is not Control c) return;
            using var pen = new Pen(Color.FromArgb(229, 231, 235));
            e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }
    }
}
