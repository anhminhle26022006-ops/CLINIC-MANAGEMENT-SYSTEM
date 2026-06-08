using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IServiceRequestDAL : IWriteRepository<ServiceRequestDTO>
    {
        List<ServiceRequestDTO> GetAll();
        List<ServiceRequestDTO> GetByStatus(string status);
        List<ServiceRequestDTO> GetByRequester(int employeeId);
        bool UpdateStatus(int requestId, string status);
    }
}
