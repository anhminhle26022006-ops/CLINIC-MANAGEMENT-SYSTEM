using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Doctor
{
    public interface IPatientRepository
    {
        Task<List<ApiPatientDTO>> GetAllAsync();
        Task<ApiPatientDTO> GetByCodeAsync(string code);
        Task<int?> GetIdByCodeAsync(string code);

        Task<ApiPatientDTO> InsertAsync(ApiPatientDTO dto);
        Task<ApiPatientDTO> UpdateAsync(ApiPatientDTO dto);

        Task UpsertAsync(ApiPatientDTO dto);
    }
}
