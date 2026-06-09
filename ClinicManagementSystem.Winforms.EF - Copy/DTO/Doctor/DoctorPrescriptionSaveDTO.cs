using System.Collections.Generic;

namespace DTO.Doctor
{
    public class DoctorPrescriptionSaveDTO
    {
        public int PrescriptionID { get; set; }
        public int EncounterID { get; set; }
        public int DoctorID { get; set; }
        public string Note { get; set; }
        public List<DoctorPrescriptionItemSaveDTO> Items { get; set; } = new();
    }

    public class DoctorPrescriptionItemSaveDTO
    {
        public int MedicineID { get; set; }
        public int Quantity { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Instruction { get; set; }
    }
}
