using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories.Doctor;

namespace BUS.Services.Doctor
{
    public class ImagingResultService
    {
        private readonly ImagingResultRepository _repo;

        public ImagingResultService(ImagingResultRepository repo)
        {
            _repo = repo;
        }

        public List<ImagingResultDto> GetByEncounter(int encounterId)
            => _repo.GetByEncounter(encounterId);
    }
}
