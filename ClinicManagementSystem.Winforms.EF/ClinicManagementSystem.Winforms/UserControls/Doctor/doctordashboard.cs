using System;
using System.Windows.Forms;
using BUS.Services.Doctor;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class doctordashboard : UserControl
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;
        private readonly DoctorWorkspaceBUS _doctorBUS;

        // Constructor mặc định (cho designer)
        public doctordashboard()
        {
            InitializeComponent();
        }

        // Constructor chính (dùng khi runtime)
        public doctordashboard(CMSDbContext context, UserDTO currentUser) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _doctorBUS = new DoctorWorkspaceBUS(_context); // Giả sử DoctorWorkspaceBUS đã có constructor nhận context

            int doctorId = _doctorBUS.ResolveDoctorId(_currentUser);
            LoadDashboard(doctorId);
        }

        private void LoadDashboard(int doctorId)
        {
            DoctorDashboardDTO dashboard = _doctorBUS.GetDashboard(doctorId, DateTime.Today);

            lblStatLabNum.Text = dashboard.PendingLabRequests.ToString();
            lblStatScanNum.Text = dashboard.WaitingCount.ToString();
            lblStatCompletedNum.Text = dashboard.CompletedCount.ToString();
            lblStatProcessingNum.Text = dashboard.ExaminingCount.ToString();

            lblShiftDept.Text = _currentUser?.DepartmentName ?? "-";
            lblShiftRoom.Text = dashboard.OpenAssignments > 0
                ? dashboard.OpenAssignments + " viec can xu ly"
                : "Khong co viec mo";
            lblShiftName.Text = dashboard.TodayAppointments > 0 ? "Co lich" : "Trong";
        }
    }
}