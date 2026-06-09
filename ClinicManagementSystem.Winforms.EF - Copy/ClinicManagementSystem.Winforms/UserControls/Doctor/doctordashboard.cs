using System;
using System.Windows.Forms;
using BUS.Services.Doctor;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class doctordashboard : UserControl
    {
        private readonly DoctorWorkspaceBUS doctorBUS = new();
        private readonly int doctorId;
        private readonly UserDTO currentUser;

        public doctordashboard() : this(null)
        {
        }

        public doctordashboard(UserDTO currentUser)
        {
            this.currentUser = currentUser;
            doctorId = doctorBUS.ResolveDoctorId(currentUser);

            InitializeComponent();
            Load += (_, __) => LoadDashboard();
        }

        private void LoadDashboard()
        {
            DoctorDashboardDTO dashboard = doctorBUS.GetDashboard(doctorId, DateTime.Today);

            lblStatLabNum.Text = dashboard.PendingLabRequests.ToString();
            lblStatScanNum.Text = dashboard.WaitingCount.ToString();
            lblStatCompletedNum.Text = dashboard.CompletedCount.ToString();
            lblStatProcessingNum.Text = dashboard.ExaminingCount.ToString();

            lblShiftDept.Text = currentUser?.DepartmentName ?? "-";
            lblShiftRoom.Text = dashboard.OpenAssignments > 0
                ? dashboard.OpenAssignments + " viec can xu ly"
                : "Khong co viec mo";
            lblShiftName.Text = dashboard.TodayAppointments > 0 ? "Co lich" : "Trong";
        }
    }
}
