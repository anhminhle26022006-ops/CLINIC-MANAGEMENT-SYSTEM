using System;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class RegisterShiftForm : Form
    {
        private readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();
        private readonly string technicianName;

        public RegisterShiftForm(string name)
        {
            InitializeComponent();
            this.technicianName = name;
        }

        private void RegisterShiftForm_Load(object sender, EventArgs e)
        {
            cboShift.SelectedIndex = 0;
            cboDept.SelectedIndex = 0;
            cboRoom.SelectedIndex = 0;
            dtpDate.MinDate = DateTime.Now;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                TechnicianShiftDTO shift = new TechnicianShiftDTO
                {
                    ShiftDate = dtpDate.Value.Date,
                    ShiftName = cboShift.SelectedItem.ToString(),
                    Department = cboDept.SelectedItem.ToString(),
                    Room = cboRoom.SelectedItem.ToString(),
                    TechnicianName = technicianName,
                    Status = "Đã đăng ký"
                };

                bool success = shiftBUS.RegisterShift(shift);
                if (success)
                {
                    MessageBox.Show("Đăng ký ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể đăng ký ca làm việc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
