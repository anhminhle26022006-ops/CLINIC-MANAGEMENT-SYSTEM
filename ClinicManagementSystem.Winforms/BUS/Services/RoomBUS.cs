using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class RoomBUS
    {
        private readonly RoomDAL dal = new();

        public RoomDTO GetRoomByDepartment(
            int departmentId)
        {
            return dal.GetRoomByDepartment(
                departmentId);
        }

        public RoomDTO GetById(int roomId)
        {
            return dal.GetById(roomId);
        }
    }
}