using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucUserManagement : UserControl
    {
        private readonly UserBUS userBUS = new UserBUS();
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private List<UserDTO> users = new List<UserDTO>();

        public ucUserManagement()
        {
            InitializeComponent();
            AdminUiStyle.ApplyGrid(dgvUsers);
            EnsureColumns();
            LoadData();
        }

        private void EnsureColumns()
        {
            AddColumn("colUsername", "USERNAME", 13);
            AddColumn("colFullName", "HỌ TÊN", 18);
            AddColumn("colRole", "VAI TRÒ", 11);
            AddColumn("colDepartment", "KHOA/PHÒNG", 13);
            AddColumn("colEmail", "EMAIL", 18);
            AddColumn("colStatus", "TRẠNG THÁI", 10);
            AddColumn("colView", "", 5, true);
            AddColumn("colEdit", "", 5, true);
            AddColumn("colLock", "THAO TÁC", 7, true);
        }

        private void AddColumn(string name, string headerText, float fillWeight, bool readOnly = false)
        {
            if (dgvUsers.Columns.Contains(name))
            {
                return;
            }

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                FillWeight = fillWeight,
                ReadOnly = readOnly
            });
        }

        public void LoadData()
        {
            users = userBUS.GetAllUsers();
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string term = txtSearch.Text.Trim().ToLowerInvariant();
            string role = cboRole.SelectedItem?.ToString() ?? "Tất cả vai trò";

            var filtered = users.Where(user =>
                (string.IsNullOrWhiteSpace(term)
                    || (user.Username ?? "").ToLowerInvariant().Contains(term)
                    || (user.Name ?? "").ToLowerInvariant().Contains(term)
                    || (user.Email ?? "").ToLowerInvariant().Contains(term))
                && (role == "Tất cả vai trò" || string.Equals(user.Role, role, StringComparison.OrdinalIgnoreCase)))
                .OrderBy(user => user.Role)
                .ThenBy(user => user.Name)
                .ToList();

            BindKpiCards();
            dgvUsers.Rows.Clear();
            foreach (UserDTO user in filtered)
            {
                int rowIndex = dgvUsers.Rows.Add(
                    user.Username,
                    user.Name,
                    user.Role,
                    user.DepartmentName,
                    user.Email,
                    user.IsActive ? "Đang hoạt động" : "Đã khóa",
                    "Xem",
                    "Sửa",
                    user.IsActive ? "Khóa" : "Mở");
                dgvUsers.Rows[rowIndex].Tag = user;
            }

            int activeCount = users.Count(user => user.IsActive);
            int lockedCount = users.Count - activeCount;
            dgvUsers.ClearSelection();
            lblPaging.Text = $"Hiển thị {filtered.Count}/{users.Count} tài khoản | Active: {activeCount} | Locked: {lockedCount}";
        }

        private void BindKpiCards()
        {
            int activeCount = users.Count(user => user.IsActive);
            int lockedCount = users.Count - activeCount;

            lblTotalValue.Text = AdminUiStyle.CountText(users.Count);
            lblActiveValue.Text = AdminUiStyle.CountText(activeCount);
            lblLockedValue.Text = AdminUiStyle.CountText(lockedCount);
            lblNewValue.Text = "0";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (AdminRecordDialogs.CreateUser(GetRoleOptions(), departmentBUS.GetAll(), out UserDTO created))
            {
                try
                {
                    if (userBUS.CreateUser(created))
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm tài khoản. Vui lòng kiểm tra username/email có bị trùng không.\n" + ex.Message, "Admin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void panelHeader_Resize(object sender, EventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvUsers.Rows[e.RowIndex].Tag is not UserDTO user)
            {
                return;
            }

            string columnName = dgvUsers.Columns[e.ColumnIndex].Name;
            if (columnName == "colView")
            {
                AdminRecordDialogs.ShowUser(user);
                return;
            }

            if (columnName == "colEdit")
            {
                string[] roles = GetRoleOptions().ToArray();
                if (AdminRecordDialogs.EditUser(user, roles, out UserDTO edited) && userBUS.UpdateUser(edited))
                {
                    LoadData();
                }
                return;
            }

            if (columnName == "colLock")
            {
                bool nextActive = !user.IsActive;
                string message = nextActive
                    ? $"Mở khóa tài khoản {user.Username}?"
                    : $"Khóa tài khoản {user.Username}? Người dùng sẽ không thể đăng nhập.";
                if (MessageBox.Show(message, "Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                    && userBUS.SetActive(user.UserID, nextActive))
                {
                    LoadData();
                }
            }
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string columnName = dgvUsers.Columns[e.ColumnIndex].Name;
            if (columnName is "colView" or "colEdit" or "colLock")
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                e.CellStyle.Font = new Font(dgvUsers.Font, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private List<string> GetRoleOptions()
        {
            string[] defaultRoles = { "Admin", "Receptionist", "Doctor", "Nurse", "Pharmacist", "Technician" };
            return users
                .Select(user => user.Role)
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
