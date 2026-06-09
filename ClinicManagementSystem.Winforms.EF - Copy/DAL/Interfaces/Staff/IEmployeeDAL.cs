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
        bool Add(EmployeeDTO employee);
        bool UpdateBasic(EmployeeDTO employee);
        bool SetStatus(int id, string status);
        bool Delete(int id);
    }
}
