using BUS.Services;
using DAL.Repositories;
using DTO;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class frmShiftAdd : Form
    {
        private readonly EmployeeShiftBUS _bus = new EmployeeShiftBUS();
        private readonly WorkShiftDAL _shiftDAL = new WorkShiftDAL();
        private readonly EmployeeDAL _empDAL = new EmployeeDAL();

        public bool Saved { get; private set; } = false;

        public frmShiftAdd()
        {
            InitializeComponent();
            LoadDropdowns();
        }

        private void LoadDropdowns()
        {
            var emps = _empDAL.GetAll();
            cboEmployee.Items.Clear();
            foreach (var e in emps) cboEmployee.Items.Add(e);
            cboEmployee.DisplayMember = "FullName";
            if (cboEmployee.Items.Count > 0) cboEmployee.SelectedIndex = 0;

            var shifts = _shiftDAL.GetAll();
            cboShift.Items.Clear();
            foreach (var s in shifts) cboShift.Items.Add(s);
            cboShift.DisplayMember = "ShiftName";
            if (cboShift.Items.Count > 0) cboShift.SelectedIndex = 0;
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboShift.SelectedItem is not WorkShiftDTO shift) return;
            dtpStart.Value = DateTime.Today.Add(shift.StartTime);
            dtpEnd.Value = DateTime.Today.Add(shift.EndTime);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboEmployee.SelectedItem is not EmployeeDTO emp)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboShift.SelectedItem is not WorkShiftDTO shift)
            {
                MessageBox.Show("Vui lòng chọn ca trực.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var dto = new EmployeeShiftDTO
                {
                    EmployeeID = emp.EmployeeID,
                    ShiftID = shift.ShiftID,
                    WorkDate = dtpDate.Value.Date,
                    Status = "Approved"
                };
                _bus.RegisterShift(dto);
                MessageBox.Show("Thêm ca trực thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Saved = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}