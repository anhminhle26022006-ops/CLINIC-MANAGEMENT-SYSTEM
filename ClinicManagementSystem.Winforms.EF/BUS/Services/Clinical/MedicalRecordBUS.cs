using System.Collections.Generic;
using DAL.Repositories;
using DTO;
using DTO.Clinical.erm;

namespace BUS.Services
{
    public class MedicalRecordBUS
    {
        private readonly MedicalRecordDAL dal = new();

        public MedicalRecordDTO GetByEncounterId(int encounterId)
        {
            return dal.GetByEncounterId(encounterId);
        }

        public List<MedicalRecordDto> GetAllErmRecords()
        {
            return dal.GetAllErmRecords();
        }
    }
}
