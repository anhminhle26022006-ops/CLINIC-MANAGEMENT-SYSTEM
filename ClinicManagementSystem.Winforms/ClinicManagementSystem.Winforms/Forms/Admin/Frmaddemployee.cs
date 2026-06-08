using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmAddEmployee : Form
    {
        private readonly EmployeeBUS _bus = new EmployeeBUS();
        private readonly DepartmentBUS _deptBus = new DepartmentBUS();

        public frmAddEmployee()
        {
            InitializeComponent();
            this.Load += (s, e) => { LoadDepartments(); LoadRoles(); };
        }

        private void LoadRoles()
        {
            cboChucVu.Items.Clear();
            cboChucVu.Items.Add(new ComboItem(0, "Chọn chức vụ"));
            foreach (var r in _bus.GetAvailableRoles())
                cboChucVu.Items.Add(new ComboItem(r.Key, r.Value));
            cboChucVu.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add(new ComboItem(0, "Chọn chuyên khoa"));
            foreach (var dept in _deptBus.GetAll())
                cboKhoa.Items.Add(new ComboItem(dept.DepartmentID, dept.DepartmentName));
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

                if (_bus.Add(emp))
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.DialogResult = DialogResult.Cancel; this.Close(); }
    }

}