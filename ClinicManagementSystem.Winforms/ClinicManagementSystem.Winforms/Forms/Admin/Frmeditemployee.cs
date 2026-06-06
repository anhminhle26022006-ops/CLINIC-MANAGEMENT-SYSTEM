using System;
using System.Data;
using System.Windows.Forms;
using BUS.Services;
using DAL.DataContext;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmEditEmployee : Form
    {
        private readonly EmployeeBUS _bus = new EmployeeBUS();
        private readonly int _employeeId;
        private EmployeeDTO _emp;

        public frmEditEmployee(int employeeId)
        {
            _employeeId = employeeId;
            InitializeComponent();
            LoadRoles();
            LoadDepartments();
            LoadEmployee();
        }

        private void LoadRoles()
        {
            string query = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add(new ComboItem(0, "Chọn chức vụ"));
            foreach (DataRow row in dt.Rows)
                cboChucVu.Items.Add(new ComboItem(Convert.ToInt32(row["RoleID"]), row["RoleName"].ToString()));
            cboChucVu.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            string query = "SELECT DepartmentID, DepartmentName FROM Departments ORDER BY DepartmentName";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add(new ComboItem(0, "Chọn chuyên khoa"));
            foreach (DataRow row in dt.Rows)
                cboKhoa.Items.Add(new ComboItem(Convert.ToInt32(row["DepartmentID"]), row["DepartmentName"].ToString()));
            cboKhoa.SelectedIndex = 0;
        }

        private void LoadEmployee()
        {
            _emp = _bus.GetById(_employeeId);
            if (_emp == null) return;

            txtFullName.Text = _emp.FullName;
            txtPhone.Text = _emp.Phone;
            txtEmail.Text = _emp.Email;

            // Set gender
            cboGender.SelectedItem = _emp.Gender;

            // Set role
            foreach (var item in cboChucVu.Items)
                if (item is ComboItem ci && ci.Id == _emp.RoleID)
                { cboChucVu.SelectedItem = ci; break; }

            // Set department
            if (_emp.DepartmentID.HasValue)
                foreach (var item in cboKhoa.Items)
                    if (item is ComboItem ci && ci.Id == _emp.DepartmentID.Value)
                    { cboKhoa.SelectedItem = ci; break; }

            // Set status
            cboStatus.SelectedItem = _emp.Status == "Active" ? "Đang làm việc" : "Nghỉ việc";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { MessageBox.Show("Vui lòng nhập họ tên."); return; }

            try
            {
                int? deptId = null;
                if (cboKhoa.SelectedItem is ComboItem deptItem && deptItem.Id > 0)
                    deptId = deptItem.Id;

                int roleId = _emp?.RoleID ?? 0;
                if (cboChucVu.SelectedItem is ComboItem roleItem && roleItem.Id > 0)
                    roleId = roleItem.Id;

                string status = cboStatus.SelectedItem?.ToString() == "Đang làm việc" ? "Active" : "Inactive";

                var emp = new EmployeeDTO
                {
                    EmployeeID = _employeeId,
                    FullName = txtFullName.Text.Trim(),
                    Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RoleID = roleId,
                    DepartmentID = deptId,
                    Status = status
                };

                if (_bus.Update(emp))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}