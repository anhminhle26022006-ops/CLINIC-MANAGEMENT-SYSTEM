using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IEmployeeDAL : IReadOnlyRepository<EmployeeDTO, int>
    {
        List<EmployeeDTO> GetByRole(string roleName);
        EmployeeDTO FindByName(string fullName);
        Task<List<ApiEmployeeDTO>> GetAllAsync();
        Task<ApiEmployeeDTO> GetByCodeAsync(string code);
        Task<int?> GetIdByCodeAsync(string code);

        Task<ApiEmployeeDTO> InsertAsync(ApiEmployeeDTO dto);
        Task<ApiEmployeeDTO> UpdateAsync(ApiEmployeeDTO dto);

        Task UpsertAsync(ApiEmployeeDTO dto);
        bool Insert(EmployeeDTO emp);
        bool Update(EmployeeDTO emp);
        bool Delete(int employeeId);
    }
}
