using BUS.Services.Doctor;
using ClinicManagementSystem.Winforms.Controllers;
using CMS.Core.Session;
using DAL.Repositories.Doctor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class doctordashboard : UserControl
    {
        private readonly DoctorDashboardController _controller;
        public doctordashboard()
        {
            InitializeComponent();

            var repo =
                new DoctorDashboardRepository();

            var service =
                new DoctorDashboardService(repo);

            _controller =
                new DoctorDashboardController(service);

            LoadDashboard();
        }
        private void LoadDashboard()
        {
            int doctorId = UserSession.EmployeeID;

            var data =
                _controller.Load(doctorId);

            lblStatLabNum.Text =
                data.PendingLabs.ToString();

            lblStatScanNum.Text =
                data.WaitingPatients.ToString();

            lblStatCompletedNum.Text =
                data.CompletedToday.ToString();

            lblStatProcessingNum.Text =
                data.InProgress.ToString();

            lblShiftName.Text =
                data.TodayShift.ShiftName;

            lblShiftRoom.Text =
                $"Phòng: {data.TodayShift.RoomCode}";

            lblShiftDept.Text =
                data.TodayShift.DepartmentName;

            lblShiftBadge.Text =
                data.TodayShift.IsOnDuty
                    ? "Đang trực"
                    : "Không trực";
        }
        
    }
}
