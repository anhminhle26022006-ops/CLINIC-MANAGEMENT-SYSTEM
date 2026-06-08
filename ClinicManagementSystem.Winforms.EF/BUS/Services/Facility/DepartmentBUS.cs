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
    }
}
