using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DepartmentBUS : IDepartmentBUS
    {
        private readonly DepartmentDAL dal = new DepartmentDAL();

        public List<DepartmentDTO> GetAll() => dal.GetAll();
        public DepartmentDTO GetById(int id) => dal.GetById(id);
        public bool Exists(int id) => dal.Exists(id);
        public bool Insert(string name) => dal.Insert(name);
        public bool Update(int id, string name) => dal.Update(id, name);
        public bool Delete(int id) => dal.Delete(id);
    }
}