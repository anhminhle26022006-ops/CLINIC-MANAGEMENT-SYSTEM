using System;
using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IEmployeeShiftBUS
    {
        bool SupportsEmployeeShiftSchema();
        List<EmployeeShiftDTO> GetAll();
        List<EmployeeShiftDTO> GetByEmployee(int employeeId);
        List<EmployeeShiftDTO> GetByDate(DateTime workDate);
        List<EmployeeShiftDTO> GetByRole(string roleName);
        bool RegisterShift(EmployeeShiftDTO shift);
        bool RegisterLegacyShift(TechnicianShiftDTO shift);
        bool UpdateShift(EmployeeShiftDTO shift);
        bool SetStatus(int employeeShiftId, string status);
        int EnsureMonthlySchedule(string roleName, int employeeId, DateTime startDate, int dayCount = 30);
    }
}
