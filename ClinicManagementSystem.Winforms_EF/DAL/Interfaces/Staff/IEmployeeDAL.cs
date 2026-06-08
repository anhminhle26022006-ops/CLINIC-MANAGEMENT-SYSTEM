using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeDAL : IReadOnlyRepository<EmployeeDTO, int>, IWriteRepository<EmployeeDTO>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
        bool Update(EmployeeDTO employee);
        bool Delete(int employeeId);
    }
}