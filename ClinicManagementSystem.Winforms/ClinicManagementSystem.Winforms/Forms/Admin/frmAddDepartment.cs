using BUS.Services;
using DTO;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmAddDepartment : Form
    {
        private readonly DepartmentBUS _bus = new DepartmentBUS();

        public frmAddDepartment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Vui lòng nhập tên chuyên khoa.", "Thiếu thông tin"); return; }

            try
            {
                var dto = new DepartmentDTO
                {
                    DepartmentName = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                    IsActive = chkActive.Checked
                };
                if (_bus.Add(dto))
                {
                    MessageBox.Show("Thêm chuyên khoa thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}