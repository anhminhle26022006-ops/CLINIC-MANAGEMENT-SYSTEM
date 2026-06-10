using BUS.Services;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucDepartmentManagement : UserControl
    {
        private readonly CMSDbContext _context;
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private List<DepartmentDTO> departments = new List<DepartmentDTO>();

        public ucDepartmentManagement()
        {
            InitializeComponent();
            AdminUiStyle.ApplyGrid(dgvDepartments);
            dgvDepartments.CellDoubleClick += dgvDepartments_CellDoubleClick;
            LoadData();
        }
        public ucDepartmentManagement(CMSDbContext context) : this()
        {
            _context = context;
            // Khởi tạo thêm nếu cần, ví dụ load dữ liệu
        }

        public void LoadData()
        {
            departments = departmentBUS.GetAll();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            var filtered = departments.Where(dept =>
                string.IsNullOrWhiteSpace(term)
                || (dept.DepartmentName ?? "").ToLowerInvariant().Contains(term)
                || (dept.Description ?? "").ToLowerInvariant().Contains(term))
                .OrderBy(dept => dept.DepartmentName)
                .ToList();

            BindKpiCards();
            dgvDepartments.Rows.Clear();
            foreach (DepartmentDTO dept in filtered)
            {
                int rowIndex = dgvDepartments.Rows.Add(
                    dept.DepartmentID,
                    dept.DepartmentName,
                    string.IsNullOrWhiteSpace(dept.Description) ? "Chưa có mô tả" : dept.Description,
                    dept.IsActive ? "Đang hoạt động" : "Tạm ngưng",
                    "Sửa",
                    dept.IsActive ? "Ngưng" : "Kích hoạt");
                dgvDepartments.Rows[rowIndex].Tag = dept;
            }

            dgvDepartments.ClearSelection();
            lblPaging.Text = $"Hiển thị {filtered.Count}/{departments.Count} chuyên khoa";
        }

        private void BindKpiCards()
        {
            int activeCount = departments.Count(dept => dept.IsActive);
            int inactiveCount = departments.Count - activeCount;

            lblDeptTotalValue.Text = AdminUiStyle.CountText(departments.Count);
            lblDeptActiveValue.Text = AdminUiStyle.CountText(activeCount);
            lblDeptInactiveValue.Text = AdminUiStyle.CountText(inactiveCount);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AdminRecordDialogs.EditDepartment(null, true, out DepartmentDTO department) && departmentBUS.Add(department))
            {
                LoadData();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvDepartments.Rows[e.RowIndex].Tag is not DepartmentDTO department)
            {
                return;
            }

            string action = dgvDepartments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
            if (action == "Sửa")
            {
                if (AdminRecordDialogs.EditDepartment(department, false, out DepartmentDTO edited) && departmentBUS.Update(edited))
                {
                    LoadData();
                }
                return;
            }

            if (action is "Ngưng" or "Kích hoạt")
            {
                bool nextActive = !department.IsActive;
                if (MessageBox.Show($"{action} chuyên khoa {department.DepartmentName}?", "Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                if (departmentBUS.SetActive(department.DepartmentID, nextActive))
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Database hiện chưa có cột IsActive cho Departments, nên không thể đổi trạng thái chuyên khoa. Bạn vẫn có thể sửa tên chuyên khoa.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvDepartments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string action = dgvDepartments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? "";
            if (action is "Sửa" or "Ngưng" or "Kích hoạt")
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                e.CellStyle.Font = new Font(dgvDepartments.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvDepartments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }

        private void lblDeptTotalTitle_Click(object sender, EventArgs e)
        {

        }

        private void dgvDepartments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDepartments.Rows[e.RowIndex].Tag is DepartmentDTO department)
            {
                MessageBox.Show(
                    $"Mã khoa: {department.DepartmentID}\nTên chuyên khoa: {department.DepartmentName}\nTrạng thái: {(department.IsActive ? "Đang hoạt động" : "Tạm ngưng")}",
                    "Chi tiết chuyên khoa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
