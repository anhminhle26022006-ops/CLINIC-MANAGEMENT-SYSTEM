using DTO;

namespace DAL.Interfaces.Staff
{
    public interface IEmployeeDAL : IReadOnlyRepository<EmployeeDTO, int>, IWriteRepository<EmployeeDTO>
    {
        // Query
        Task<List<EmployeeDTO>> GetByRole(string roleName);
        Task<EmployeeDTO> FindByName(string fullName);

        // API Sync (giữ nguyên vì đang dùng ApiEmployeeDTO)
        Task<List<ApiEmployeeDTO>> GetAllAsync();
        Task<ApiEmployeeDTO> GetByCodeAsync(string code);
        Task<int?> GetIdByCodeAsync(string code);
        Task<ApiEmployeeDTO> InsertAsync(ApiEmployeeDTO dto);
        Task<ApiEmployeeDTO> UpdateAsync(ApiEmployeeDTO dto);
        Task UpsertAsync(ApiEmployeeDTO dto);

        // CRUD
        Task<bool> UpdateBasic(EmployeeDTO employee);
        Task<bool> SetStatus(int id, string status);
        Task<bool> Delete(int id);
    }
}