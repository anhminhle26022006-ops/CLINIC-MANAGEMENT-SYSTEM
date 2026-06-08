using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class EncounterBUS
    {
        private readonly EncounterDAL dal =
            new();

        public EncounterDTO GetById(
            int encounterId)
        {
            return dal.GetById(
                encounterId);
        }
    }
}