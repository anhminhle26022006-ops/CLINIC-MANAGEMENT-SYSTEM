using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IEmployeeBUS : IReadOnlyService<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
    }
}
