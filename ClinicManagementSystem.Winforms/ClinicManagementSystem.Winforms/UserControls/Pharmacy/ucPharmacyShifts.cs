using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Services;
using CMS.Core.Constants;
using CMS.Core.Identity;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPharmacyShifts : PharmacyDashboardViewBase
    {
        private readonly EmployeeShiftBUS shiftBUS = new EmployeeShiftBUS();
        private List<EmployeeShiftDTO> pharmacyShifts = new List<EmployeeShiftDTO>();
        private DateTime currentWeekStart;

        public ucPharmacyShifts()
        {
            InitializeComponent();
        }

        private void ucPharmacyShifts_Load(object sender, EventArgs e)
        {
            currentWeekStart = StartOfWeek(DateTime.Today);
            btnPrev.Click += (s, ev) => MoveWeek(-1);
            btnNext.Click += (s, ev) => MoveWeek(1);
            btnToday.Click += (s, ev) => MoveToToday();
            LoadShifts();
        }

        private void ucPharmacyShifts_Resize(object sender, EventArgs e)
        {
            AdjustPharmacyShiftLayout();
        }

        private void MoveWeek(int weekDelta)
        {
            currentWeekStart = currentWeekStart.AddDays(weekDelta * 7);
            RenderWeek();
        }

        private void MoveToToday()
        {
            currentWeekStart = StartOfWeek(DateTime.Today);
            RenderWeek();
        }

        private void LoadShifts()
        {
            try
            {
                pharmacyShifts = currentUser != null && currentUser.EmployeeID > 0
                    ? shiftBUS.GetByEmployee(currentUser.EmployeeID)
                    : shiftBUS.GetByRole(Role.Pharmacist);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading pharmacy shifts: " + ex);
                pharmacyShifts = new List<EmployeeShiftDTO>();
            }

            int totalThisMonth = pharmacyShifts.Count(s => s.WorkDate.Month == DateTime.Today.Month && s.WorkDate.Year == DateTime.Today.Year);
            int approvedThisMonth = pharmacyShifts.Count(s =>
                s.WorkDate.Month == DateTime.Today.Month &&
                s.WorkDate.Year == DateTime.Today.Year &&
                (s.Status == ShiftStatus.Approved || string.IsNullOrWhiteSpace(s.Status)));

            BindShiftStats(totalThisMonth, 0, approvedThisMonth);
            RenderWeek();
        }

        private void RenderWeek()
        {
            BindWeekLabel(currentWeekStart);

            for (int i = 0; i < 7; i++)
            {
                DateTime day = currentWeekStart.AddDays(i);
                EmployeeShiftDTO shift = pharmacyShifts
                    .OrderBy(s => s.StartTime)
                    .FirstOrDefault(s => s.WorkDate.Date == day.Date);

                if (shift == null)
                {
                    BindShiftDay(i, day, string.Empty, string.Empty, string.Empty, false);
                    continue;
                }

                string code = "CA-DS-" + shift.EmployeeShiftID.ToString("D3");
                string time = shift.StartTime.ToString(@"hh\:mm") + " - " + shift.EndTime.ToString(@"hh\:mm");
                string place = string.IsNullOrWhiteSpace(shift.DepartmentName) ? "Nhà thuốc" : shift.DepartmentName;

                BindShiftDay(i, day, code, time, place, true);
            }
        }

        private static DateTime StartOfWeek(DateTime date)
        {
            int diff = ((int)date.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            return date.Date.AddDays(-diff);
        }
    }
}
