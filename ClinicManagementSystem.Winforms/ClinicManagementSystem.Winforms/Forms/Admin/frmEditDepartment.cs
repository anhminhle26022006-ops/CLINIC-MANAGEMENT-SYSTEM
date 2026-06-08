using BUS.Services;
using DTO;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmEditDepartment : Form
    {
        private readonly DepartmentBUS _bus = new DepartmentBUS();
        private readonly int _id;

        public frmEditDepartment(int id)
        {
            _id = id;
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            var dto = _bus.GetById(_id);
            if (dto == null) { MessageBox.Show("Không tìm thấy chuyên khoa."); this.Close(); return; }
            txtName.Text = dto.DepartmentName;
            txtDesc.Text = dto.Description;
            chkActive.Checked = dto.IsActive;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            { MessageBox.Show("Vui lòng nhập tên chuyên khoa.", "Thiếu thông tin"); return; }

            try
            {
                var dto = new DepartmentDTO
                {
                    DepartmentID = _id,
                    DepartmentName = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                    IsActive = chkActive.Checked
                };
                if (_bus.Update(dto))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công",
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
