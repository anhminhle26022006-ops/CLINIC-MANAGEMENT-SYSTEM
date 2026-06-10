using DTO;

namespace DAL.Interfaces.Clinical
{
    public interface IServiceRequestDAL : IWriteRepository<ServiceRequestDTO>
    {
        Task<List<ServiceRequestDTO>> GetAll();
        Task<List<ServiceRequestDTO>> GetByStatus(string status);
        Task<List<ServiceRequestDTO>> GetByRequester(int employeeId);
        Task<bool> UpdateStatus(int requestId, string status);
    }
}