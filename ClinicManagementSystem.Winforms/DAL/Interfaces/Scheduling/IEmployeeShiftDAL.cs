using System;
using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeShiftDAL : IWriteRepository<EmployeeShiftDTO>
    {
        bool SupportsEmployeeShiftSchema();
        List<EmployeeShiftDTO> GetAll();
        List<EmployeeShiftDTO> GetByEmployee(int employeeId);
        List<EmployeeShiftDTO> GetByDate(DateTime workDate);
        List<EmployeeShiftDTO> GetByRole(string roleName);
        bool HasConflict(int employeeId, DateTime workDate, int shiftId);
        bool Update(EmployeeShiftDTO shift);
        bool SetStatus(int employeeShiftId, string status);
        int EnsureMonthlySchedule(string roleName, int employeeId, DateTime startDate, int dayCount);
    }
}
