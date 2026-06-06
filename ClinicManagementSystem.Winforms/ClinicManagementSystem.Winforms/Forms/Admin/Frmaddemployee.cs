using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BUS.Services;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmAddEmployee : Form
    {
        private readonly EmployeeBUS _bus = new EmployeeBUS();

        public frmAddEmployee()
        {
            InitializeComponent();
            LoadDepartments();
            LoadRoles();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            { MessageBox.Show("Vui lòng nhập họ tên.", "Thiếu thông tin"); return; }
            if (!(cboChucVu.SelectedItem is ComboItem roleItem) || roleItem.Id == 0)
            { MessageBox.Show("Vui lòng chọn chức vụ.", "Thiếu thông tin"); return; }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            { MessageBox.Show("Vui lòng nhập số điện thoại.", "Thiếu thông tin"); return; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            { MessageBox.Show("Vui lòng nhập email.", "Thiếu thông tin"); return; }

            try
            {
                int? deptId = null;
                if (cboKhoa.SelectedItem is ComboItem deptItem && deptItem.Id > 0)
                    deptId = deptItem.Id;

                var emp = new EmployeeDTO
                {
                    FullName = txtFullName.Text.Trim(),
                    Gender = cboGender.SelectedItem?.ToString() ?? "Nam",
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    RoleID = roleItem.Id,
                    DepartmentID = deptId,
                    Status = "Active"
                };

                bool result = _bus.Add(emp);
                if (result)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công",
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

    public class ComboItem
    {
        public int Id { get; }
        public string Name { get; }
        public ComboItem(int id, string name) { Id = id; Name = name; }
        public override string ToString() => Name;
    }
}