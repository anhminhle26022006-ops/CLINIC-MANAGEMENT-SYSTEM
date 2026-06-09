namespace DTO.Doctor
{
    public class DoctorRequestSaveDTO
    {
        public int EncounterID { get; set; }
        public int DoctorID { get; set; }
        public string RequestType { get; set; }
        public string ServiceName { get; set; }
        public string Note { get; set; }
        public string Priority { get; set; }
    }
}
