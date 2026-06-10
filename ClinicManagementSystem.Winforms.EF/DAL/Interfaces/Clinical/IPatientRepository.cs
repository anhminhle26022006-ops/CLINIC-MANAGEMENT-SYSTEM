using DTO;

namespace DAL.Interfaces.Clinical
{
    public interface IPatientRepository
    {
        Task<List<PatientDTO>> GetAll();
        Task<List<PatientDTO>> Search(string term);
        Task<int> Add(PatientDTO patient);
        Task<PatientDTO> GetById(int id);
        Task<bool> Update(PatientDTO patient);
    }
}