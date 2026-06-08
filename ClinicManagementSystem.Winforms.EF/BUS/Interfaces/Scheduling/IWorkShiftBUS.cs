using DTO;

namespace BUS.Interfaces
{
    public interface IWorkShiftBUS : IReadOnlyService<WorkShiftDTO, int>
    {
        int GetOrCreateShiftId(string shiftName);
    }
}
