using DAL.Repositories.Doctor;
using DTO.Clinical.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Clinical.erm;

namespace BUS.Services.Doctor
{
    public class MedicalHistoryService
    {
        private readonly MedicalRecordRepository _repository;

        public MedicalHistoryService()
        {
            _repository = new MedicalRecordRepository();
        }

        public List<MedicalRecordDto> GetAll()
        {
            return _repository.GetAll();
        }
        public List<MedicalRecordDto> GetHistory(int encounterId)
        {
            return _repository.GetHistory(encounterId);
        }
    }
}
