using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class DepartmentDAL_Recep
    {
        public List<DepartmentDTO> GetAll()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Departments
                    .AsNoTracking()
                    .Select(d => new DepartmentDTO
                    {
                        DepartmentID = d.DepartmentID,
                        DepartmentName = d.DepartmentName
                    })
                    .ToList();
            }
        }
    }
}
