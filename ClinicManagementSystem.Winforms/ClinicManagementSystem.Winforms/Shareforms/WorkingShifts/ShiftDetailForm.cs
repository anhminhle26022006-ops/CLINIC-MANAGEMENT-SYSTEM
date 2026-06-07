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
    public partial class ShiftDetailForm : Form
    {
        private EmployeeShiftDTO shift;
        public ShiftDetailForm()
        {
            InitializeComponent();
            btnClose.Click += BtnClose_Click;
            btnChangeShiftRequest.Click += BtnChangeShiftRequest_Click;
        }
        public ShiftDetailForm(EmployeeShiftDTO shift)
        {
            InitializeComponent();

            this.shift = shift;

            LoadData();
        }

        private void LoadData()
        {
            lblCode.Text = shift.ShiftName;

            lblStatus.Text =
                string.IsNullOrEmpty(shift.Status)
                ? "Đã lên lịch"
                : shift.Status;

            lblDate.Text =
                shift.WorkDate.ToString("dd/MM/yyyy");

            label4.Text =
                $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}";

            lblDepartment.Text =
                shift.DepartmentName;

            lblLocation.Text =
                shift.RoomCode;
        }
        private void BtnClose_Click(
    object sender,
    EventArgs e)
        {
            Close();
        }
        private void BtnChangeShiftRequest_Click(
    object sender,
    EventArgs e)
        {
            ShiftRequestForm frm =
                new ShiftRequestForm(shift);

            frm.ShowDialog();
        }
    }
}
