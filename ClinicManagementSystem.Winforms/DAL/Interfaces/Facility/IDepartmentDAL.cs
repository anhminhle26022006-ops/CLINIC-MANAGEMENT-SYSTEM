using DTO;

namespace DAL.Interfaces
{
    public interface IDepartmentDAL : IReadOnlyRepository<DepartmentDTO, int>
    {
        bool Add(DepartmentDTO dto);
        bool Update(DepartmentDTO dto);
        bool Delete(int id);
        bool NameExists(string name, int excludeId = 0);
    }
}