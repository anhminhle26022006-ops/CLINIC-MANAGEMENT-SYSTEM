using System;

namespace DTO
{
    public class MedicineDTO
    {
        public Guid MedicineID { get; set; }

        public string MedicineName { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string BatchNumber { get; set; }

        public bool IsArchived { get; set; }
    }
}
