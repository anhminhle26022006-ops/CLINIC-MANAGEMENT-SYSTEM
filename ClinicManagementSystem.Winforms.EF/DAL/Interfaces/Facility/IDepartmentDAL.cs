using DTO;

namespace DAL.Interfaces
{
    public interface IDepartmentDAL : IReadOnlyRepository<DepartmentDTO, int>
    {
        bool Add(DepartmentDTO department);
        bool Update(DepartmentDTO department);
        bool SetActive(int id, bool isActive);
        bool Delete(int id);
    }
}
