namespace Models
{
    public class PrescriptionDetail
    {
        public int DetailID { get; set; }
        public int? PrescriptionID { get; set; }
        public int? MedicineID { get; set; }
        public int? Quantity { get; set; }
        public string Dosage { get; set; }
    }
}
