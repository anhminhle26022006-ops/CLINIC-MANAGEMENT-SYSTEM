using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BUS.Services;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class frmEmployeeEdit : Form
    {
        private readonly EmployeeBUS _empBUS = new EmployeeBUS(new EmployeeDAL());
        private readonly DepartmentBUS _deptBUS = new DepartmentBUS();
        private readonly EmployeeDTO _emp;
        private readonly bool _isEdit;

        // Constructor Thêm mới
        public frmEmployeeEdit()
        {
            _emp = new EmployeeDTO { Status = "Active" };
            _isEdit = false;
            InitializeComponent();
            LoadDropdowns();
            lblTitle.Text = "Thêm nhân viên mới"; // ← thêm dòng này
        }


        // Constructor Sửa
        public frmEmployeeEdit(EmployeeDTO emp)
        {
            _emp = emp;
            _isEdit = true;
            InitializeComponent();
            LoadDropdowns();
            BindData();
            lblTitle.Text = "Chỉnh sửa nhân viên"; // ← thêm dòng này
        }

        private void LoadDropdowns()
        {
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new object[]
            {
                "Admin", "Doctor", "Nurse",
                "Pharmacist", "Technician", "Receptionist"
            });

            cboStatus.Items.Clear();
            cboStatus.Items.AddRange(new object[] { "Active", "Inactive" });

            cboDept.Items.Clear();
            List<DepartmentDTO> depts = _deptBUS.GetAll();
            foreach (var d in depts)
                cboDept.Items.Add(d);
            cboDept.DisplayMember = "DepartmentName";
            cboDept.ValueMember = "DepartmentID";
        }

        private void BindData()
        {
            txtFullName.Text = _emp.FullName ?? "";
            txtPhone.Text = _emp.Phone ?? "";
            txtEmail.Text = _emp.Email ?? "";
            txtCitizenId.Text = _emp.CitizenId ?? "";
            txtAddress.Text = _emp.Address ?? "";

            dtpDateOfBirth.Value = _emp.DateOfBirth ?? DateTime.Today;
            dtpHireDate.Value = _emp.HireDate ?? DateTime.Today;

            cboRole.Text = _emp.RoleName ?? "";
            cboStatus.Text = _emp.Status ?? "Active";

            foreach (DepartmentDTO item in cboDept.Items)
            {
                if (item.DepartmentID == _emp.DepartmentID)
                {
                    cboDept.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }
            if (cboRole.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn chức vụ.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboDept.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn chuyên khoa.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Map về DTO
            _emp.FullName = txtFullName.Text.Trim();
            _emp.Phone = txtPhone.Text.Trim();
            _emp.Email = txtEmail.Text.Trim();
            _emp.CitizenId = txtCitizenId.Text.Trim();
            _emp.Address = txtAddress.Text.Trim();
            _emp.DateOfBirth = dtpDateOfBirth.Value.Date;
            _emp.HireDate = dtpHireDate.Value.Date;
            _emp.RoleName = cboRole.Text;
            _emp.Status = cboStatus.Text;

            if (cboDept.SelectedItem is DepartmentDTO dept)
            {
                _emp.DepartmentID = dept.DepartmentID;
                _emp.DepartmentName = dept.DepartmentName;
            }

            // Tìm RoleID từ RoleName
            _emp.RoleID = cboRole.Text switch
            {
                "Admin" => 1,
                "Receptionist" => 2,
                "Doctor" => 3,
                "Nurse" => 4,
                "Pharmacist" => 5,
                "Technician" => 6,
                _ => _emp.RoleID
            };

            // Tạo EmployeeCode nếu thêm mới
            if (!_isEdit && string.IsNullOrEmpty(_emp.EmployeeCode))
                _emp.EmployeeCode = "EMP" + DateTime.Now.ToString("yyMMddHHmm");

            bool ok = _isEdit
                ? _empBUS.Update(_emp)
                : _empBUS.Insert(_emp);

            if (ok)
            {
                MessageBox.Show(
                    _isEdit ? "Cập nhật thành công!" : "Thêm nhân viên thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thao tác thất bại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}