using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IEmployeeBUS : IReadOnlyService<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
        bool Add(EmployeeDTO dto);
        bool Update(EmployeeDTO dto);
        bool Delete(int id);
        List<EmployeeDTO> Search(string keyword, string roleName);
    }
}