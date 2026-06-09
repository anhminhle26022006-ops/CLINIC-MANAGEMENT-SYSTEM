using DAL.Repositories.Doctor;
using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services.Doctor
{
    public class ERMService
    {
        private readonly MedicalRecordRepository _repo;

        public ERMService()
        {
            _repo = new MedicalRecordRepository();
        }

        public PatientERMDto GetPatientERM(Guid patientUuid)
        {
            return _repo.GetPatientERM(patientUuid);
        }
    }
}
