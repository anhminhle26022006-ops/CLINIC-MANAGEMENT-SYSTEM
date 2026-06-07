using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.ERM
{
    public interface IERMRepository
    {
        Task<PatientERMDto> GetPatientERM(Guid patientUUID);
    }
}
