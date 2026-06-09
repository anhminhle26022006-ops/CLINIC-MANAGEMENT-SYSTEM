using System.Collections.Generic;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class RoleBUS
    {
        private readonly RoleDAL dal = new();

        public List<RoleDTO> GetAll()
        {
            return dal.GetAll();
        }
    }
}