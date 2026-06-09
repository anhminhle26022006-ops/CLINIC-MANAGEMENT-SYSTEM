using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Doctor
{
    public interface IPatientRepository
    {
        List<PatientDTO> GetAll();
        PatientDTO GetById(int id);
        int Add(PatientDTO patient);
    }
}
