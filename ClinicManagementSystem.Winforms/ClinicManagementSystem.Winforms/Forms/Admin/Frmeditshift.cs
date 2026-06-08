using BUS.Services;
using DTO;
using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmEditShift : Form
    {
        private readonly int _shiftId;
        private readonly EmployeeBUS _empBus;
        private readonly WorkShiftBUS _wsBus;
        private readonly EmployeeShiftBUS _shiftBus;
        private EmployeeShiftDTO _shift;

        public frmEditShift(int shiftId, EmployeeBUS empBus, WorkShiftBUS wsBus, EmployeeShiftBUS shiftBus)
        {
            _shiftId = shiftId; _empBus = empBus; _wsBus = wsBus; _shiftBus = shiftBus;
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        private void LoadData()
        {
            // Load employees
            cboEmployee.Items.Clear();
            foreach (var e in _empBus.GetAll())
                if (e.Status == "Active")
                    cboEmployee.Items.Add(new ComboItem(e.EmployeeID,
                        e.FullName + " (" + MapRole(e.RoleName) + ")"));

            cboShift.Items.Clear();
            cboShift.Items.Add(new ComboItemShift("Sáng", "08:00", "12:00"));
            cboShift.Items.Add(new ComboItemShift("Chiều", "13:00", "17:00"));
            cboShift.Items.Add(new ComboItemShift("Tối", "17:00", "21:00"));
            cboShift.Items.Add(new ComboItemShift("Cả ngày", "08:00", "17:00"));

            // Load shift data
            _shift = _shiftBus.GetById(_shiftId);
            if (_shift == null) { this.Close(); return; }

            foreach (var item in cboEmployee.Items)
                if (item is ComboItem ci && ci.Id == _shift.EmployeeID)
                { cboEmployee.SelectedItem = ci; break; }

            dtpDate.Value = _shift.WorkDate;
            txtRoom.Text = _shift.RoomName ?? "";

            foreach (var item in cboShift.Items)
                if (item is ComboItemShift s && s.Name == _shift.ShiftName)
                { cboShift.SelectedItem = s; break; }

            if (cboShift.SelectedIndex < 0) cboShift.SelectedIndex = 0;
            UpdateTimes();
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e) => UpdateTimes();

        private void UpdateTimes()
        {
            if (cboShift.SelectedItem is ComboItemShift s)
            { txtStartTime.Text = s.Start; txtEndTime.Text = s.End; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cboEmployee.SelectedItem is ComboItem emp))
            { MessageBox.Show("Vui lòng chọn nhân viên."); return; }
            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            { MessageBox.Show("Vui lòng nhập phòng."); return; }

            try
            {
                var shiftItem = cboShift.SelectedItem as ComboItemShift;
                int shiftId = _wsBus.GetOrCreateShiftId(shiftItem?.Name ?? "Sáng");

                var dto = new EmployeeShiftDTO
                {
                    EmployeeShiftID = _shiftId,
                    EmployeeID = emp.Id,
                    ShiftID = shiftId,
                    WorkDate = dtpDate.Value.Date,
                    Status = "Approved",
                    RoomName = txtRoom.Text.Trim()
                };

                if (_shiftBus.UpdateShift(dto))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        { this.DialogResult = DialogResult.Cancel; this.Close(); }

        private string MapRole(string r) => r switch
        {
            "Doctor" => "Bác sĩ",
            "Nurse" => "Y tá",
            "Pharmacist" => "Dược sĩ",
            "Technician" => "Kỹ thuật viên",
            "Receptionist" => "Lễ tân",
            _ => r ?? ""
        };
    }
}