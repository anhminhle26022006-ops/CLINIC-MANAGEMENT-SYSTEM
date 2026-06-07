using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class MedicalRecordBUS
    {
        private readonly MedicalRecordDAL dal =
            new();

        public MedicalRecordDTO
            GetByEncounterId(
                int encounterId)
        {
            return dal.GetByEncounterId(
                encounterId);
        }
    }
}