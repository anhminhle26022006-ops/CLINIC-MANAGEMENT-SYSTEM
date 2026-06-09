using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Doctor;

namespace BUS.Services.Doctor
{
    public class LabResultService
    {
        private readonly LabResultRepository _repo;

        public LabResultService(LabResultRepository repo)
        {
            _repo = repo;
        }

        public List<LabResultDto> GetByEncounter(int encounterId)
            => _repo.GetByEncounter(encounterId);
    }
}
