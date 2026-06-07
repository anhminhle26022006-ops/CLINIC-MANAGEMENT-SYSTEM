using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface ITechnicianRequestDAL : IWriteRepository<TechnicianRequestDTO>
    {
        List<TechnicianRequestDTO> GetAll();
        List<TechnicianRequestDTO> GetByStatus(string status);
        List<TechnicianRequestDTO> Search(string term, string status);
        List<TechnicianRequestDTO> GetByPatient(int patientId);
        bool UpdateStatus(int requestId, string status);
        bool SaveImagingResult(int requestId, string resultFile, string note);
        bool SavePDFResult(int requestId, string resultPDF);
        bool SaveLabResult(int requestId, string labValues);
    }
}
