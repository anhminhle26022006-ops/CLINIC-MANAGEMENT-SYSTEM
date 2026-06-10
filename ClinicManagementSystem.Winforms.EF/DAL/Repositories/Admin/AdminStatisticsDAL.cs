using System;
using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AdminStatisticsDAL : IAdminStatisticsDAL
    {
        private const int LowStockThreshold = 20;
        private readonly CMSDbContext _context;

        public AdminStatisticsDAL(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public AdminStatisticsDTO GetStatistics(DateTime referenceDate)
        {
            DateTime today = referenceDate.Date;
            DateTime tomorrow = today.AddDays(1);
            DateTime monthStart = new DateTime(today.Year, today.Month, 1);
            DateTime nextMonthStart = monthStart.AddMonths(1);
            DateTime previousMonthStart = monthStart.AddMonths(-1);

            int newPatientsThisMonth = CountByDateRange<Patient>(p => p.CreatedAt, monthStart, nextMonthStart);
            int newPatientsPreviousMonth = CountByDateRange<Patient>(p => p.CreatedAt, previousMonthStart, monthStart);
            int appointmentsThisMonth = CountByDateRange<Appointment>(a => a.AppointmentDate, monthStart, nextMonthStart);
            int appointmentsPreviousMonth = CountByDateRange<Appointment>(a => a.AppointmentDate, previousMonthStart, monthStart);
            decimal revenueThisMonth = GetRevenue(monthStart, nextMonthStart);
            decimal revenuePreviousMonth = GetRevenue(previousMonthStart, monthStart);

            return new AdminStatisticsDTO
            {
                TotalPatients = _context.Patients.Count(),
                NewPatientsThisMonth = newPatientsThisMonth,
                PatientGrowthPercent = CalculateGrowthPercent(newPatientsThisMonth, newPatientsPreviousMonth),
                MonthlyAppointmentCount = appointmentsThisMonth,
                AppointmentGrowthPercent = CalculateGrowthPercent(appointmentsThisMonth, appointmentsPreviousMonth),
                MonthlyRevenue = revenueThisMonth,
                RevenueGrowthPercent = CalculateGrowthPercent(revenueThisMonth, revenuePreviousMonth),
                TodayAppointmentCount = CountByDateRange<Appointment>(a => a.AppointmentDate, today, tomorrow),
                ActiveEmployeeCount = CountActiveEmployees(),
                LowStockMedicineCount = CountLowStockMedicines(),
                QueueSummary = GetQueueSummary(),
                PatientTrend = GetPatientTrend(monthStart),
                RevenueTrend = GetRevenueTrend(monthStart),
                DepartmentStatistics = GetDepartmentStatistics(monthStart, nextMonthStart),
                TodayAppointments = GetTodayAppointments(today, tomorrow),
                LowStockMedicines = GetLowStockMedicines()
            };
        }

        #region Private helper methods using EF Core

        private int CountByDateRange<TEntity>(
            Func<TEntity, DateTime?> dateSelector,
            DateTime start,
            DateTime end) where TEntity : class
        {
            var query = _context.Set<TEntity>().AsQueryable();
            return query.Count(entity => dateSelector(entity) >= start && dateSelector(entity) < end);
        }

        private int CountActiveEmployees()
        {
            var activeStatuses = new[] { "Active", "Đang làm việc" }; // tuỳ chỉnh theo dữ liệu thực tế
            return _context.Employees.Count(e => !string.IsNullOrEmpty(e.Status) && activeStatuses.Contains(e.Status));
        }

        private int CountLowStockMedicines()
        {
            return _context.Medicines.Count(m => (m.Stock ?? 0) <= LowStockThreshold);
        }

        private AdminQueueSummaryDTO GetQueueSummary()
        {
            var groups = _context.PatientQueues
                .GroupBy(q => q.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToList();

            var summary = new AdminQueueSummaryDTO();
            foreach (var g in groups)
            {
                string status = g.Status?.ToLower() ?? "";
                if (status.Contains("waiting") || status.Contains("chờ") || status == "pending")
                    summary.Waiting += g.Count;
                else if (status.Contains("inprogress") || status.Contains("processing") || status.Contains("đang khám"))
                    summary.InProgress += g.Count;
                else if (status.Contains("complete") || status.Contains("hoàn thành"))
                    summary.Completed += g.Count;
                else if (status.Contains("cancel") || status.Contains("hủy"))
                    summary.Cancelled += g.Count;
            }
            return summary;
        }

        private List<AdminChartPointDTO> GetPatientTrend(DateTime currentMonthStart)
        {
            var points = CreateEmptyTrend(currentMonthStart);
            for (int i = 0; i < points.Count; i++)
            {
                DateTime start = points[i].PeriodStart;
                DateTime end = start.AddMonths(1);
                points[i].Value = _context.Patients.Count(p => p.CreatedAt >= start && p.CreatedAt < end);
            }
            return points;
        }

        private List<AdminChartPointDTO> GetRevenueTrend(DateTime currentMonthStart)
        {
            var points = CreateEmptyTrend(currentMonthStart);
            for (int i = 0; i < points.Count; i++)
            {
                DateTime start = points[i].PeriodStart;
                DateTime end = start.AddMonths(1);
                points[i].Value = GetRevenue(start, end);
            }
            return points;
        }

        private List<AdminChartPointDTO> CreateEmptyTrend(DateTime currentMonthStart)
        {
            var points = new List<AdminChartPointDTO>();
            for (int i = 5; i >= 0; i--)
            {
                DateTime periodStart = currentMonthStart.AddMonths(-i);
                points.Add(new AdminChartPointDTO
                {
                    PeriodStart = periodStart,
                    Label = periodStart.ToString("MM/yyyy"),
                    Value = 0
                });
            }
            return points;
        }

        private decimal GetRevenue(DateTime start, DateTime end)
        {
            // Ưu tiên dùng bảng Payments nếu có dữ liệu, nếu không thì dùng Invoices
            var paymentRevenue = _context.Payments
                .Where(p => p.PaidAt >= start && p.PaidAt < end)
                .Where(p => !string.IsNullOrEmpty(p.Status) && !p.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                .Sum(p => p.Amount ?? 0);

            if (paymentRevenue > 0)
                return paymentRevenue;

            return _context.Invoices
                .Where(i => i.CreatedAt >= start && i.CreatedAt < end)
                .Where(i => !string.IsNullOrEmpty(i.Status) && !i.Status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
                .Sum(i => i.Total ?? 0);
        }

        private List<AdminDepartmentStatisticDTO> GetDepartmentStatistics(DateTime start, DateTime end)
        {
            var query = from d in _context.Departments
                        join e in _context.Employees on d.DepartmentId equals e.DepartmentId into empGroup
                        from e in empGroup.DefaultIfEmpty()
                        join a in _context.Appointments on d.DepartmentId equals a.DepartmentId into appGroup
                        from a in appGroup.Where(a => a.AppointmentDate >= start && a.AppointmentDate < end).DefaultIfEmpty()
                        group new { e, a } by d.DepartmentName into g
                        select new AdminDepartmentStatisticDTO
                        {
                            DepartmentName = g.Key,
                            EmployeeCount = g.Select(x => x.e.EmployeeId).Distinct().Count(),
                            MonthlyAppointmentCount = g.Select(x => x.a.AppointmentId).Distinct().Count()
                        };

            return query.OrderByDescending(d => d.MonthlyAppointmentCount)
                        .ThenByDescending(d => d.EmployeeCount)
                        .ThenBy(d => d.DepartmentName)
                        .Take(6)
                        .ToList();
        }

        private List<AdminAppointmentSummaryDTO> GetTodayAppointments(DateTime start, DateTime end)
        {
            var appointments = _context.Appointments
                .Where(a => a.AppointmentDate >= start && a.AppointmentDate < end)
                .Select(a => new AdminAppointmentSummaryDTO
                {
                    AppointmentDate = a.AppointmentDate ?? DateTime.MinValue,
                    TimeText = a.AppointmentDate.HasValue ? a.AppointmentDate.Value.ToString("HH:mm") : "",
                    PatientName = a.Patient != null ? a.Patient.FullName : "Chưa rõ",
                    DoctorName = a.Doctor != null ? a.Doctor.FullName : "Chưa phân công",
                    DepartmentName = a.Department != null ? a.Department.DepartmentName : "Chưa rõ",
                    Status = a.Status ?? "Chưa cập nhật"
                })
                .OrderBy(a => a.AppointmentDate)
                .Take(10)
                .ToList();

            return appointments;
        }

        private List<AdminLowStockMedicineDTO> GetLowStockMedicines()
        {
            return _context.Medicines
                .Where(m => (m.Stock ?? 0) <= LowStockThreshold)
                .OrderBy(m => m.Stock)
                .ThenBy(m => m.Name)
                .Take(6)
                .Select(m => new AdminLowStockMedicineDTO
                {
                    MedicineName = m.Name,
                    Unit = m.Unit,
                    Stock = m.Stock ?? 0,
                    ExpiryDate = m.ExpiryDate.HasValue
                        ? m.ExpiryDate.Value.ToDateTime(TimeOnly.MinValue)
                        : (DateTime?)null
                })
                .ToList();
        }

        private decimal CalculateGrowthPercent(decimal current, decimal previous)
        {
            if (previous <= 0)
                return current > 0 ? 100 : 0;
            return Math.Round((current - previous) / previous * 100, 1);
        }

        #endregion
    }
}