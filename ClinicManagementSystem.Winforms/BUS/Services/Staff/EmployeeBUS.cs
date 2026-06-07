using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class EmployeeBUS : IEmployeeBUS
    {
        private readonly EmployeeDAL dal = new EmployeeDAL();

        public List<EmployeeDTO> GetAll()
        {
            return dal.GetAll();
        }

        public List<EmployeeDTO> GetByRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return new List<EmployeeDTO>();
            }

            return dal.GetByRole(roleName.Trim());
        }

        public EmployeeDTO GetById(int employeeId)
        {
            return dal.GetById(employeeId);
        }

        public EmployeeDTO FindByName(string fullName)
        {
            return dal.FindByName(fullName);
        }

        public bool Exists(int employeeId)
        {
            return dal.Exists(employeeId);
        }
    }
}
