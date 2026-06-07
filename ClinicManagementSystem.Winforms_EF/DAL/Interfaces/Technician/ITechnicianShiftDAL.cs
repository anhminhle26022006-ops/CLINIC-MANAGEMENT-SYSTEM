using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface ITechnicianShiftDAL : IWriteRepository<TechnicianShiftDTO>
    {
        List<TechnicianShiftDTO> GetAll();
        int GetCount();
    }
}
