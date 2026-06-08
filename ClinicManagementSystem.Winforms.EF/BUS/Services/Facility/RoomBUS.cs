using System.Collections.Generic;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class RoomBUS : IRoomBUS
    {
        private readonly RoomDAL dal = new RoomDAL();

        public List<RoomDTO> GetAll()
        {
            return dal.GetAll();
        }

        public RoomDTO GetById(int roomId)
        {
            return dal.GetById(roomId);
        }

        public bool Exists(int roomId)
        {
            return dal.Exists(roomId);
        }
    }
}
