namespace Models
{
    public class PatientIdentifier
    {
        public int IdentifierID { get; set; }
        public int? PatientID { get; set; }
        public string SourceSystem { get; set; }
        public string IdentifierType { get; set; }
        public string IdentifierValue { get; set; }
    }
}
