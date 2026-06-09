using DAL.Repositories.Doctor;
using DTO.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services.Doctor
{
    public class PrescriptionService
    {
        private readonly PrescriptionRepository _repo;

        public PrescriptionService(
            PrescriptionRepository repo)
        {
            _repo = repo;
        }

        public List<PrescriptionListDto> GetAll()
        {
            return _repo.GetAll();
        }

        public PrescriptionDetailDto GetDetail(int id)
        {
            return _repo.GetDetail(id);
        }

        public PrescriptionStatisticDto GetStatistics()
        {
            return _repo.GetStatistics();
        }
    }
}
