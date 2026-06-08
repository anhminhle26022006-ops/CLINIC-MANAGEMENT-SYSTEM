using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class Room_RecepBUS
    {
        private readonly Room_RecepDAL dal = new();

        public int CountRooms()
        {
            return dal.CountRooms();
        }

        public Room_RecepDTO GetRoomByDepartment(
            int departmentId)
        {
            return dal.GetRoomByDepartment(
                departmentId);
        }

        public Room_RecepDTO GetById(int roomId)
        {
            return dal.GetById(roomId);
        }
    }
}