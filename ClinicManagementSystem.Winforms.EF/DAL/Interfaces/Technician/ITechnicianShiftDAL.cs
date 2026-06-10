using DTO;

namespace DAL.Interfaces.Technician
{
    public interface ITechnicianShiftDAL : IWriteRepository<TechnicianShiftDTO>
    {
        Task<List<TechnicianShiftDTO>> GetAll();
        Task<int> GetCount();
        Task<bool> Update(TechnicianShiftDTO dto);
        Task<bool> Delete(int id);
    }
}