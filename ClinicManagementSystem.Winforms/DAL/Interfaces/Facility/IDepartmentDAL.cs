using System.Collections.Generic;
using DTO;

namespace DAL.Interfaces
{
    public interface IDepartmentDAL
    {
        List<DepartmentDTO> GetAll();
        DepartmentDTO GetById(int departmentId);
        bool Exists(int departmentId);
        bool Insert(string departmentName);
        bool Update(int departmentId, string departmentName);
        bool Delete(int departmentId);
    }
}