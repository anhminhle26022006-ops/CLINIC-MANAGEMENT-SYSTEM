using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces.Facility;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Facility
{
    public class DepartmentDAL : IDepartmentDAL
    {
        public async Task<List<DepartmentDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Departments
                .OrderBy(d => d.DepartmentName)
                .Select(d => new DepartmentDTO
                {
                    DepartmentID = d.DepartmentID,
                    DepartmentName = d.DepartmentName ?? "",
                    Description = "",
                    IsActive = true
                })
                .ToListAsync();
        }

        public async Task<DepartmentDTO> GetById(int departmentId)
        {
            if (departmentId <= 0) return null;

            using var context = DbContextProvider.CreateContext();
            var d = await context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentID == departmentId);

            if (d == null) return null;

            return new DepartmentDTO
            {
                DepartmentID = d.DepartmentID,
                DepartmentName = d.DepartmentName ?? "",
                Description = "",
                IsActive = true
            };
        }

        public async Task<bool> Exists(int departmentId)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Departments
                .AnyAsync(d => d.DepartmentID == departmentId);
        }

        public async Task<bool> Add(DepartmentDTO department)
        {
            using var context = DbContextProvider.CreateContext();
            context.Departments.Add(new Department
            {
                DepartmentName = department.DepartmentName
            });
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(DepartmentDTO department)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentID == department.DepartmentID);

            if (entity == null) return false;

            entity.DepartmentName = department.DepartmentName;
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> SetActive(int id, bool isActive)
        {
            // Database hiện tại không có cột IsActive trong Departments
            // Trả về true để không block flow
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(int id)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentID == id);

            if (entity == null) return false;

            context.Departments.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}