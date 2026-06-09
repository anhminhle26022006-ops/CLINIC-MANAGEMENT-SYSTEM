using System;

namespace DTO
{
    public class PrescriptionItemDTO
    {
        public int DetailID { get; set; }
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Instruction { get; set; }

        // UI-bound properties populated via joins
        public string MedicineName { get; set; }
        public string MedicineUnit { get; set; }
        public string BatchNumber { get; set; }
        public decimal Price { get; set; }
    }
}
