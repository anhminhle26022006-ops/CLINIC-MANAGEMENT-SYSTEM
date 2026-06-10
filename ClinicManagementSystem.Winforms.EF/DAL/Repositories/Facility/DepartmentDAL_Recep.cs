using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Facility
{
    public class Department_RecepDAL
    {
        public async Task<List<DepartmentDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Departments
                .OrderBy(d => d.DepartmentName)
                .Select(d => new DepartmentDTO
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName ?? ""
                })
                .ToListAsync();
        }
    }
}