using System;

namespace DTO
{
    public class InventoryDTO
    {
        public Guid InventoryID { get; set; }

        public Guid MedicineID { get; set; }

        public int QuantityIn { get; set; }

        public int QuantityOut { get; set; }

        public string BatchNumber { get; set; }

        public DateTime ExpiredDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }
    }
}