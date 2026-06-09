using BUS.Services;
using DAL.Repositories;
using DTO;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class frmShiftEdit : Form
    {
        private readonly EmployeeShiftBUS _bus = new EmployeeShiftBUS();
        private readonly WorkShiftDAL _shiftDAL = new WorkShiftDAL();

        private readonly EmployeeShiftDTO _shift;
        public bool Saved { get; private set; } = false;

        public frmShiftEdit(EmployeeShiftDTO shift)
        {
            _shift = shift;
            InitializeComponent();
            LoadDropdowns();
            BindData();
        }

        private void LoadDropdowns()
        {
            var shifts = _shiftDAL.GetAll();
            cboShift.Items.Clear();
            foreach (var s in shifts) cboShift.Items.Add(s);
            cboShift.DisplayMember = "ShiftName";
        }

        private void BindData()
        {
            txtEmployee.Text = $"{_shift.EmployeeName} ({_shift.RoleName})";
            dtpDate.Value = _shift.WorkDate;
            txtRoom.Text = _shift.RoomCode ?? "";
            dtpStart.Value = DateTime.Today.Add(_shift.StartTime);
            dtpEnd.Value = DateTime.Today.Add(_shift.EndTime);

            foreach (WorkShiftDTO item in cboShift.Items)
            {
                if (item.ShiftID == _shift.ShiftID)
                {
                    cboShift.SelectedItem = item;
                    break;
                }
            }
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShift.SelectedItem is not WorkShiftDTO shift) return;
            dtpStart.Value = DateTime.Today.Add(shift.StartTime);
            dtpEnd.Value = DateTime.Today.Add(shift.EndTime);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboShift.SelectedItem is not WorkShiftDTO shift)
            {
                MessageBox.Show("Vui lòng chọn ca trực.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_bus.Update(_shift.EmployeeShiftID, shift.ShiftID, dtpDate.Value.Date))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Saved = true;
                Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void lblEmployee_Click(object sender, EventArgs e)
        {

        }
    }
}