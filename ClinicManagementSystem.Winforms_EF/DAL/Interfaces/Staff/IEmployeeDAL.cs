using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeDAL : IReadOnlyRepository<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
    }
}
