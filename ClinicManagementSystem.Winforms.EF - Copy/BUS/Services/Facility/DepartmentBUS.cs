using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DepartmentBUS : IDepartmentBUS
    {
        private readonly DepartmentDAL dal = new DepartmentDAL();

        public List<DepartmentDTO> GetAll()
        {
            return dal.GetAll();
        }

        public DepartmentDTO GetById(int departmentId)
        {
            return dal.GetById(departmentId);
        }

        public bool Exists(int departmentId)
        {
            return dal.Exists(departmentId);
        }

        public bool Add(DepartmentDTO department)
        {
            if (department == null || string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                return false;
            }

            return dal.Add(department);
        }

        public bool Update(DepartmentDTO department)
        {
            if (department == null || department.DepartmentID <= 0 || string.IsNullOrWhiteSpace(department.DepartmentName))
            {
                return false;
            }

            return dal.Update(department);
        }

        public bool SetActive(int id, bool isActive)
        {
            return id > 0 && dal.SetActive(id, isActive);
        }
    }
}
