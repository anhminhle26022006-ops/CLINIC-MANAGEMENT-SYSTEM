using System;

namespace DTO
{
    public class InventoryDTO
    {
        public int InventoryID { get; set; }
        public int MedicineID { get; set; }
        public int QuantityIn { get; set; }
        public int QuantityOut { get; set; }
        public string BatchNumber { get; set; }
        public DateTime ExpiredDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
    }
}