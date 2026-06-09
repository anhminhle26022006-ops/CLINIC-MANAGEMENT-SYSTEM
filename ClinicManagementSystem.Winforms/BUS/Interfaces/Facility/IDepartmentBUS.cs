using DTO;

namespace BUS.Interfaces
{
    public interface IDepartmentBUS : IReadOnlyService<DepartmentDTO, int>
    {
        bool Add(DepartmentDTO department);
        bool Update(DepartmentDTO department);
        bool SetActive(int id, bool isActive);
    }
}
