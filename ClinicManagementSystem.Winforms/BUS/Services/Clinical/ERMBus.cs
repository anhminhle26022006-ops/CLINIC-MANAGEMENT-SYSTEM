using DAL.Interfaces.ERM;
using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services.ERM
{
    public class ERMBus
    {
        private readonly IERMRepository _repository;

        public ERMBus(IERMRepository repository)
        {
            _repository = repository;
        }

        public async Task<PatientERMDto> GetPatientERM(Guid uuid)
        {
            return await _repository.GetPatientERM(uuid);
        }
    }
}
