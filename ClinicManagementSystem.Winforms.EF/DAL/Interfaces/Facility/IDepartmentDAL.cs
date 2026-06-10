using DTO;

namespace DAL.Interfaces.Facility
{
    public interface IDepartmentDAL : IReadOnlyRepository<DepartmentDTO, int>, IWriteRepository<DepartmentDTO>
    {
        Task<bool> Update(DepartmentDTO department);
        Task<bool> SetActive(int id, bool isActive);
        Task<bool> Delete(int id);
    }
}