using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interfaces.Doctor
{
    public interface IPatientBUS
    {
        Task<List<ApiPatientDTO>> GetAllAsync();
        Task<ApiPatientDTO> AddAsync(ApiPatientDTO dto);
    }
}
