using System;

namespace DTO
{
    public class PrescriptionItemDTO
    {
        public Guid PrescriptionItemID { get; set; }

        public Guid PrescriptionID { get; set; }

        public Guid MedicineID { get; set; }

        public int Quantity { get; set; }

        public string Dosage { get; set; }

        public string Instructions { get; set; }
    }
}