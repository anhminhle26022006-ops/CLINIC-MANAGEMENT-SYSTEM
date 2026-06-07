using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class DepartmentDAL : IDepartmentDAL
    {
        public List<DepartmentDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return context.Departments
                .AsNoTracking()
                .OrderBy(d => d.DepartmentName)
                .Select(d => Map(d))
                .ToList();
        }

        public DepartmentDTO GetById(int departmentId)
        {
            if (departmentId <= 0)
            {
                return null;
            }

            using ClinicDbContext context = new ClinicDbContext();
            Department department = context.Departments
                .AsNoTracking()
                .FirstOrDefault(d => d.DepartmentID == departmentId);
            return department == null ? null : Map(department);
        }

        public bool Exists(int departmentId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return departmentId > 0 && context.Departments.Any(d => d.DepartmentID == departmentId);
        }

        private static DepartmentDTO Map(Department department)
        {
            return new DepartmentDTO
            {
                DepartmentID = department.DepartmentID,
                DepartmentName = department.DepartmentName,
                IsActive = true
            };
        }
    }
}
