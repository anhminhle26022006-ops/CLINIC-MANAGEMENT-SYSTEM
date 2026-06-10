using DTO.Clinical.erm;

namespace DAL.Interfaces.Clinical
{
    public interface IERMRepository
    {
        Task<PatientERMDto> GetPatientERM(Guid patientUUID);
    }
}