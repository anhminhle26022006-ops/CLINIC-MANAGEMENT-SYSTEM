using DAL.Repositories.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Clinical.Patient;

namespace BUS.Services.Doctor
{
    public class VitalSignsService
    {
        private readonly VitalSignsRepository _repo;

        public VitalSignsService(VitalSignsRepository repo)
        {
            _repo = repo;
        }

        public VitalSignsDto Get(int encounterId)
            => _repo.GetByEncounter(encounterId);
    }
}
