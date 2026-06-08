using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BUS.Interfaces
{
    public interface IPatientService
    {
        List<PatientDTO> GetAllPatients();

        List<PatientDTO> SearchPatients(string term);

        PatientDTO GetPatientById(int id);

        bool AddPatient(PatientDTO patient);

        bool UpdatePatient(PatientDTO patient);

    }
}
