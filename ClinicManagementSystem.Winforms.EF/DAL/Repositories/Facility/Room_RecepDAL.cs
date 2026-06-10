using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Facility
{
    public class Room_RecepDAL
    {
        public async Task<int> CountRooms()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Rooms.CountAsync();
        }

        public async Task<Room_RecepDTO> GetRoomByDepartment(int departmentId)
        {
            using var context = DbContextProvider.CreateContext();
            var room = await context.Rooms
                .Where(r => r.DepartmentID == departmentId)
                .FirstOrDefaultAsync();

            if (room == null) return null;

            return new Room_RecepDTO
            {
                RoomID = room.RoomID,
                RoomCode = room.RoomCode ?? "",
                DepartmentID = room.DepartmentID,
                Status = room.Status ?? ""
            };
        }

        public async Task<Room_RecepDTO> GetById(int roomId)
        {
            using var context = DbContextProvider.CreateContext();
            var room = await context.Rooms
                .FirstOrDefaultAsync(r => r.RoomID == roomId);

            if (room == null) return null;

            return new Room_RecepDTO
            {
                RoomID = room.RoomID,
                RoomCode = room.RoomCode ?? "",
                DepartmentID = room.DepartmentID,
                Status = room.Status ?? ""
            };
        }
    }
}