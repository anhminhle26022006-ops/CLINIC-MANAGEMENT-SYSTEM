using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces.Doctor
{
    public interface IPatientBUS
    {
        List<PatientDTO> GetAll();
        int Add(PatientDTO p);
    }
}
