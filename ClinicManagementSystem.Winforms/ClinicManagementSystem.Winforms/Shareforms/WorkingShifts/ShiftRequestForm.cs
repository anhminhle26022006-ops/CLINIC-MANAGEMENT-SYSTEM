using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public partial class ShiftRequestForm : Form
    {
        private EmployeeShiftDTO shift;
        public ShiftRequestForm()
        {
            InitializeComponent();
            AutoScroll = true;
            ClientSize = new Size(789, 1087);
        }
        public ShiftRequestForm(
        EmployeeShiftDTO shift)
        {
            InitializeComponent();

            this.shift = shift;

            LoadData();
            btnCancel.Click += (s, e) =>
            {
                Close();
            };
        }

        private void LoadData()
        {
            lblCode.Text =
                shift.ShiftName;

            lblStaff.Text =
                shift.EmployeeName;

            lblDate.Text =
                shift.WorkDate.ToString("dd/MM/yyyy");

            lblDepartment.Text =
                shift.DepartmentName;

            label8.Text =
                $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}";

            label11.Text =
                shift.RoomCode;
        }
        private void btnRequest_Click(
    object sender,
    EventArgs e)
        {
            if (cbsamerolestaff.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn đồng nghiệp");

                return;
            }

            if (string.IsNullOrWhiteSpace(
                txtReason.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập lý do");

                return;
            }

            MessageBox.Show(
                "Gửi yêu cầu đổi ca thành công");

            Close();
        }
    }


}

