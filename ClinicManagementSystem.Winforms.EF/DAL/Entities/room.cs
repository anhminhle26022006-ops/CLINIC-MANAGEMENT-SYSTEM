using DAL.Models;

namespace DAL.Entities
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomCode { get; set; }
        public int DepartmentID { get; set; }
        public string Status { get; set; }
        public Department Department { get; set; }
    }
}
