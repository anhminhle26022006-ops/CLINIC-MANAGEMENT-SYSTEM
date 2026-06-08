using DTO;

namespace DAL.Interfaces
{
    public interface IWorkShiftDAL : IReadOnlyRepository<WorkShiftDTO, int>
    {
        WorkShiftDTO GetByName(string shiftName);
        int GetOrCreateShiftId(string shiftName);
    }
}
