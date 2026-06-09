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
        bool Add(EmployeeDTO employee);
        bool UpdateBasic(EmployeeDTO employee);
        bool SetStatus(int id, string status);
        bool Delete(int id);
    }
}
