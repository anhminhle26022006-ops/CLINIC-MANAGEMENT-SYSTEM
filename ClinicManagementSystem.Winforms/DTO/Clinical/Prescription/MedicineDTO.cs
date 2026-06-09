using System;

namespace DTO
{
    public class MedicineDTO
    {
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}