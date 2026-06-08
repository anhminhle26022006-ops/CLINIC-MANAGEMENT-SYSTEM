using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IServiceRequestBUS
    {
        List<ServiceRequestDTO> GetAll();
        List<ServiceRequestDTO> GetByStatus(string status);
        List<ServiceRequestDTO> GetByRequester(int employeeId);
        bool Create(ServiceRequestDTO request);
        bool UpdateStatus(int requestId, string status);
    }
}
