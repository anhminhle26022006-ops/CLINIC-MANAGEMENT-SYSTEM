using DAL.Models;

namespace DAL.Entities
{
    public class Service
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}