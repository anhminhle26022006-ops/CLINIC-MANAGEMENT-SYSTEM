using DTO;

namespace DAL.Interfaces
{
    public interface IDepartmentDAL : IReadOnlyRepository<DepartmentDTO, int>
    {
    }
}
