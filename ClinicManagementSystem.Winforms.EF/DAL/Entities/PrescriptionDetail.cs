using DAL.Models;

namespace DAL.Entities
{
    public class PrescriptionDetail
    {
        public int DetailID { get; set; }
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Instruction { get; set; }
        public Prescription Prescription { get; set; }
        public Medicine Medicine { get; set; }
    }
}