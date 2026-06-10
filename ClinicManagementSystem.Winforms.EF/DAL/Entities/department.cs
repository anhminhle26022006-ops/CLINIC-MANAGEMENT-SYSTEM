namespace DAL.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}