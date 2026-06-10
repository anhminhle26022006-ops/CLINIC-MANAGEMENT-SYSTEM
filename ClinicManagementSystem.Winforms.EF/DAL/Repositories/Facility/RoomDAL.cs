using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces.Facility;
using DTO;
using Microsoft.EntityFrameworkCore;
namespace DAL.Repositories.Facility
{
    public class RoomDAL : IRoomDAL
    {
        public async Task<List<RoomDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Rooms
                .OrderBy(r => r.RoomCode)
                .Select(r => new RoomDTO
                {
                    RoomID = r.RoomID,
                    RoomCode = r.RoomCode ?? "",
                    DepartmentID = r.DepartmentID,
                    DepartmentName = r.Department.DepartmentName ?? "",
                    Status = r.Status ?? ""
                })
                .ToListAsync();
        }

        public async Task<RoomDTO> GetById(int roomId)
        {
            if (roomId <= 0) return null;

            using var context = DbContextProvider.CreateContext();
            var r = await context.Rooms
                .Include(r => r.Department)
                .FirstOrDefaultAsync(r => r.RoomID == roomId);

            if (r == null) return null;

            return new RoomDTO
            {
                RoomID = r.RoomID,
                RoomCode = r.RoomCode ?? "",
                DepartmentID = r.DepartmentID,
                DepartmentName = r.Department?.DepartmentName ?? "",
                Status = r.Status ?? ""
            };
        }

        public async Task<bool> Exists(int roomId)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Rooms.AnyAsync(r => r.RoomID == roomId);
        }
        public async Task<bool> Delete(object id)
        {
            return await Delete(Convert.ToInt32(id));
        }

        public async Task<bool> Update(RoomDTO room)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Rooms
                .FirstOrDefaultAsync(r => r.RoomID == room.RoomID);

            if (entity == null) return false;

            entity.RoomCode = room.RoomCode;
            entity.DepartmentID = room.DepartmentID;
            entity.Status = room.Status;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(RoomDTO room)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new DAL.Entities.Room
            {
                RoomCode = room.RoomCode,
                DepartmentID = room.DepartmentID,
                Status = room.Status
            };
            context.Rooms.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Rooms
                .FirstOrDefaultAsync(r => r.RoomID == id);

            if (entity == null) return false;

            context.Rooms.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}