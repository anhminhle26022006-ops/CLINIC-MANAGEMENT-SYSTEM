using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IPatientRepository
    {
        List<PatientDTO> GetAll();

        List<PatientDTO> Search(string term);

        int Add(PatientDTO patient);

        PatientDTO GetById(int id);

        bool Update(PatientDTO patient);
    }
}
