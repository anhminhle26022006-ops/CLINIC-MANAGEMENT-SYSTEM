using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface ITechnicianRequestBUS
    {
        List<TechnicianRequestDTO> GetList();
        List<TechnicianRequestDTO> FilterList(string term, string status);
        List<TechnicianRequestDTO> GetRequestsByPatient(int patientId);
        bool StartProcessing(int requestId);
        bool SaveImagingResult(int requestId, string resultFile, string note);
        bool SavePDFResult(int requestId, string resultPDF);
        bool SaveLabResult(int requestId, string labValues);
        bool CreateRequest(TechnicianRequestDTO request);
        bool CreateServiceRequest(ServiceRequestDTO request);
    }
}
