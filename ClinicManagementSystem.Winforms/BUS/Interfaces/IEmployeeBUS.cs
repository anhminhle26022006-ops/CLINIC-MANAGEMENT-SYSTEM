using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IEmployeeBUS
    {
        List<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int employeeId);
        bool Add(EmployeeDTO employee);
        bool Update(EmployeeDTO employee);
        bool Delete(int employeeId);
        List<EmployeeDTO> Search(string keyword, string roleName);
    }
}