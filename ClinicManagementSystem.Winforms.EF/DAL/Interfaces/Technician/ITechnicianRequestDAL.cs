using DTO;

namespace DAL.Interfaces.Technician
{
    public interface ITechnicianRequestDAL : IWriteRepository<TechnicianRequestDTO>
    {
        Task<List<TechnicianRequestDTO>> GetAll();
        Task<List<TechnicianRequestDTO>> GetByStatus(string status);
        Task<List<TechnicianRequestDTO>> Search(string term, string status);
        Task<List<TechnicianRequestDTO>> GetByPatient(int patientId);
        Task<bool> UpdateStatus(int requestId, string status);
        Task<bool> SaveImagingResult(int requestId, string resultFile, string note);
        Task<bool> SavePDFResult(int requestId, string resultPDF);
        Task<bool> SaveLabResult(int requestId, string labValues);
    }
}