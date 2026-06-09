using BUS.Interfaces.Doctor;
using DAL.Interfaces.Doctor;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services.Doctor
{
    public class PatientBUS : IPatientBUS
    {
        private readonly IPatientRepository _repo;

        public PatientBUS(IPatientRepository repo)
        {
            _repo = repo;
        }

        public List<PatientDTO> GetAll()
            => _repo.GetAll();

        public int Add(PatientDTO p)
            => _repo.Add(p);
    }
}
