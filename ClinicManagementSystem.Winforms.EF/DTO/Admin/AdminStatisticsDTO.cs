using System;
using System.Collections.Generic;

namespace DTO
{
    public class AdminStatisticsDTO
    {
        public int TotalPatients { get; set; }
        public int NewPatientsThisMonth { get; set; }
        public decimal PatientGrowthPercent { get; set; }
        public int MonthlyAppointmentCount { get; set; }
        public decimal AppointmentGrowthPercent { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal RevenueGrowthPercent { get; set; }
        public int TodayAppointmentCount { get; set; }
        public int ActiveEmployeeCount { get; set; }
        public int LowStockMedicineCount { get; set; }
        public AdminQueueSummaryDTO QueueSummary { get; set; } = new AdminQueueSummaryDTO();
        public List<AdminChartPointDTO> PatientTrend { get; set; } = new List<AdminChartPointDTO>();
        public List<AdminChartPointDTO> RevenueTrend { get; set; } = new List<AdminChartPointDTO>();
        public List<AdminDepartmentStatisticDTO> DepartmentStatistics { get; set; } = new List<AdminDepartmentStatisticDTO>();
        public List<AdminAppointmentSummaryDTO> TodayAppointments { get; set; } = new List<AdminAppointmentSummaryDTO>();
        public List<AdminLowStockMedicineDTO> LowStockMedicines { get; set; } = new List<AdminLowStockMedicineDTO>();
    }

    public class AdminQueueSummaryDTO
    {
        public int Waiting { get; set; }
        public int InProgress { get; set; }
        public int Completed { get; set; }
        public int Cancelled { get; set; }
    }

    public class AdminChartPointDTO
    {
        public DateTime PeriodStart { get; set; }
        public string Label { get; set; }
        public decimal Value { get; set; }
    }

    public class AdminDepartmentStatisticDTO
    {
        public string DepartmentName { get; set; }
        public int EmployeeCount { get; set; }
        public int MonthlyAppointmentCount { get; set; }
    }

    public class AdminAppointmentSummaryDTO
    {
        public DateTime AppointmentDate { get; set; }
        public string TimeText { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string DepartmentName { get; set; }
        public string Status { get; set; }
    }

    public class AdminLowStockMedicineDTO
    {
        public string MedicineName { get; set; }
        public string Unit { get; set; }
        public int Stock { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
