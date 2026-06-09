using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IEmployeeBUS : IReadOnlyService<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
        Task<List<ApiEmployeeDTO>> GetAllAsync();
        Task<ApiEmployeeDTO> AddAsync(ApiEmployeeDTO dto);
        bool Insert(EmployeeDTO emp);
        bool Update(EmployeeDTO emp);
        bool Delete(int employeeId);
    }
}
