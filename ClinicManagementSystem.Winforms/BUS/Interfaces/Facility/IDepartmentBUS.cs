using System.Collections.Generic;
using DTO;

namespace BUS.Interfaces
{
    public interface IDepartmentBUS : IReadOnlyService<DepartmentDTO, int>
    {
        bool Add(DepartmentDTO dto);
        bool Update(DepartmentDTO dto);
        bool Delete(int id);
        List<DepartmentDTO> Search(string keyword);
    }
}