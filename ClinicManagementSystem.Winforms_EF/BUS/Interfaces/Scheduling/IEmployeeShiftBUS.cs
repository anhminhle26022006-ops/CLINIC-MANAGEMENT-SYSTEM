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
    }
}
