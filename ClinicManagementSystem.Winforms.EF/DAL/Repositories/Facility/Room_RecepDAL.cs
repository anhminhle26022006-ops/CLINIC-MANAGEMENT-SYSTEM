using System;
using System.Linq;
using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Room_RecepDAL
    {
        public int CountRooms()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Rooms.Count();
            }
        }

        public Room_RecepDTO GetRoomByDepartment(int departmentId)
        {
            using (var context = new ClinicDbContext())
            {
                var r = context.Rooms
                    .AsNoTracking()
                    .FirstOrDefault(x => x.DepartmentID == departmentId);

                if (r == null) return null;

                return new Room_RecepDTO
                {
                    RoomID = r.RoomID,
                    RoomCode = r.RoomCode,
                    DepartmentID = r.DepartmentID ?? 0,
                    Status = r.Status
                };
            }
        }

        public Room_RecepDTO GetById(int roomId)
        {
            using (var context = new ClinicDbContext())
            {
                var r = context.Rooms
                    .AsNoTracking()
                    .FirstOrDefault(x => x.RoomID == roomId);

                if (r == null) return null;

                return new Room_RecepDTO
                {
                    RoomID = r.RoomID,
                    RoomCode = r.RoomCode,
                    DepartmentID = r.DepartmentID ?? 0,
                    Status = r.Status
                };
            }
        }
    }
}
