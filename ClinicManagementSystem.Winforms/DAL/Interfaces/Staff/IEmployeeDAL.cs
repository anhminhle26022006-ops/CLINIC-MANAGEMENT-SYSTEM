using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeDAL : IReadOnlyRepository<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
        bool Add(EmployeeDTO dto);
        bool Update(EmployeeDTO dto);
        bool Delete(int id);
    }
}