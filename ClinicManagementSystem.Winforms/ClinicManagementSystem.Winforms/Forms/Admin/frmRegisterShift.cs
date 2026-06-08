using BUS.Services;
using DTO;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmRegisterShift : Form
    {
        private readonly EmployeeBUS _empBus;
        private readonly WorkShiftBUS _wsBus;
        private readonly EmployeeShiftBUS _shiftBus;

        public frmRegisterShift(EmployeeBUS empBus, WorkShiftBUS wsBus, EmployeeShiftBUS shiftBus)
        {
            _empBus = empBus; _wsBus = wsBus; _shiftBus = shiftBus;
            InitializeComponent();
            this.Load += (s, e) => Init();
        }

        private void Init()
        {
            cboEmployee.Items.Clear();
            cboEmployee.Items.Add(new ComboItem(0, "-- Chọn nhân viên --"));
            foreach (var e in _empBus.GetAll())
                if (e.Status == "Active")
                    cboEmployee.Items.Add(new ComboItem(e.EmployeeID,
                        e.FullName + " (" + MapRole(e.RoleName) + ")"));
            cboEmployee.SelectedIndex = 0;

            cboShift.Items.Clear();
            cboShift.Items.Add(new ComboItemShift("Sáng", "08:00", "12:00"));
            cboShift.Items.Add(new ComboItemShift("Chiều", "13:00", "17:00"));
            cboShift.Items.Add(new ComboItemShift("Tối", "17:00", "21:00"));
            cboShift.Items.Add(new ComboItemShift("Cả ngày", "08:00", "17:00"));
            cboShift.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;
            dtpDate.MinDate = DateTime.Today;
            UpdateTimes();
        }

        private void cboShift_SelectedIndexChanged(object sender, EventArgs e) => UpdateTimes();

        private void UpdateTimes()
        {
            if (cboShift.SelectedItem is ComboItemShift s)
            {
                txtStartTime.Text = s.Start;
                txtEndTime.Text = s.End;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(cboEmployee.SelectedItem is ComboItem emp) || emp.Id == 0)
            { MessageBox.Show("Vui lòng chọn nhân viên.", "Thiếu thông tin"); return; }
            if (cboShift.SelectedItem == null)
            { MessageBox.Show("Vui lòng chọn ca trực.", "Thiếu thông tin"); return; }
            if (string.IsNullOrWhiteSpace(txtRoom.Text))
            { MessageBox.Show("Vui lòng nhập phòng.", "Thiếu thông tin"); return; }

            try
            {
                var shiftItem = cboShift.SelectedItem as ComboItemShift;
                int shiftId = _wsBus.GetOrCreateShiftId(shiftItem.Name);

                var dto = new EmployeeShiftDTO
                {
                    EmployeeID = emp.Id,
                    ShiftID = shiftId,
                    WorkDate = dtpDate.Value.Date,
                    Status = "Approved",
                    RoomName = txtRoom.Text.Trim()
                };

                if (_shiftBus.RegisterShift(dto))
                {
                    MessageBox.Show("Thêm ca trực thành công!", "Thành công",
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