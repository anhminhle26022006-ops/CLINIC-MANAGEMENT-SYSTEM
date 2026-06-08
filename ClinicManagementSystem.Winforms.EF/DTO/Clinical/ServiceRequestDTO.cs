using System;

namespace DTO
{
    public class ServiceRequestDTO
    {
        public int RequestID { get; set; }
        public int SourceID { get; set; }
        public string SourceTable { get; set; }
        public string RequestCode { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public string PatientCode { get; set; }
        public int RequestedByEmployeeID { get; set; }
        public string RequestedByEmployeeName { get; set; }
        public int? AssignedToEmployeeID { get; set; }
        public string AssignedToEmployeeName { get; set; }
        public string ServiceType { get; set; }
        public string RequestType { get; set; }
        public string RequestNote { get; set; }
        public string Priority { get; set; }
        public DateTime RequestedAt { get; set; }
        public string Status { get; set; }
        public string ResultFile { get; set; }
        public string ResultPDF { get; set; }
        public string LabValues { get; set; }
    }
}
