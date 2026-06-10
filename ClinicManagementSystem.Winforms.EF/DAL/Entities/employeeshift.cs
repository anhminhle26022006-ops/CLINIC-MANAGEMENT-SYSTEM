using DAL.Models;

namespace DAL.Entities
{
    public class EmployeeShift
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
        public DateTime WorkDate { get; set; }
        public int? DepartmentID { get; set; }
        public int? RoomID { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}