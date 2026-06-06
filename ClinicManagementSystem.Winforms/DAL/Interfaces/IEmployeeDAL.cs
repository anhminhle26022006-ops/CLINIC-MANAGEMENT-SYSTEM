using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeDAL
    {
        List<EmployeeDTO> GetAll();
        EmployeeDTO GetById(int employeeId);
        bool Add(EmployeeDTO employee);
        bool Update(EmployeeDTO employee);
        bool Delete(int employeeId);
    }
}