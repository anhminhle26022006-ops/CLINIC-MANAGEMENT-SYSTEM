using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface ITechnicianShiftBUS
    {
        List<TechnicianShiftDTO> GetList();
        bool RegisterShift(TechnicianShiftDTO shift);
        int GetShiftCount();
    }
}
