using System.Collections.Generic;
using System.Linq;
using DAL.DataContext;
using DAL.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class RoomDAL : IRoomDAL
    {
        public List<RoomDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return (
                from room in context.Rooms.AsNoTracking()
                join department in context.Departments.AsNoTracking()
                    on room.DepartmentID equals department.DepartmentID into departments
                from department in departments.DefaultIfEmpty()
                orderby room.RoomCode
                select new RoomDTO
                {
                    RoomID = room.RoomID,
                    RoomCode = room.RoomCode,
                    DepartmentID = room.DepartmentID ?? 0,
                    DepartmentName = department != null ? department.DepartmentName : "",
                    Status = room.Status ?? ""
                }).ToList();
        }

        public RoomDTO GetById(int roomId)
        {
            if (roomId <= 0)
            {
                return null;
            }

            using ClinicDbContext context = new ClinicDbContext();
            return (
                from room in context.Rooms.AsNoTracking()
                join department in context.Departments.AsNoTracking()
                    on room.DepartmentID equals department.DepartmentID into departments
                from department in departments.DefaultIfEmpty()
                where room.RoomID == roomId
                select new RoomDTO
                {
                    RoomID = room.RoomID,
                    RoomCode = room.RoomCode,
                    DepartmentID = room.DepartmentID ?? 0,
                    DepartmentName = department != null ? department.DepartmentName : "",
                    Status = room.Status ?? ""
                }).FirstOrDefault();
        }

        public bool Exists(int roomId)
        {
            using ClinicDbContext context = new ClinicDbContext();
            return roomId > 0 && context.Rooms.Any(r => r.RoomID == roomId);
        }
    }
}
