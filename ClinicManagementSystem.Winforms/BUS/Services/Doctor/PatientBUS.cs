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

        public async Task<List<ApiPatientDTO>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<ApiPatientDTO> AddAsync(ApiPatientDTO dto)
        {
            return await _repo.InsertAsync(dto);
        }
    }
}
