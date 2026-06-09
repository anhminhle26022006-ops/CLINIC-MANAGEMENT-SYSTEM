using DAL.Repositories.Doctor;
using DTO.Doctor;
using System.Collections.Generic;

namespace BUS.Services.Doctor
{
    public class PatientQueueService
    {
        private readonly PatientQueueRepository _repo;

        public PatientQueueService(PatientQueueRepository repo)
        {
            _repo = repo;
        }

        public List<PatientQueueDto> GetTodayQueue(int doctorId)
            => _repo.GetTodayQueue(doctorId);
    }
}