using System;
using System.Text.Json.Serialization;

namespace DTO
{
    // ==========================================
    // FLAT IMAGING REQUEST DETAILS DTO
    // ==========================================
    public class FlatImagingRequestDetail
    {
        [JsonPropertyName("detailid")]
        public int DetailID { get; set; }

        [JsonPropertyName("imagingid")]
        public string ImagingID { get; set; }

        [JsonPropertyName("serviceid")]
        public int ServiceID { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class FlatImagingRequest
    {
        [JsonPropertyName("imagingid")]
        public string ImagingID { get; set; }

        [JsonPropertyName("imagingcode")]
        public string ImagingCode { get; set; }

        [JsonPropertyName("encounterid")]
        public int EncounterID { get; set; }

        [JsonPropertyName("doctorid")]
        public string DoctorID { get; set; }

        [JsonPropertyName("createdat")]
        public string CreatedAt { get; set; }
    }

    public class FlatEncounter
    {
        [JsonPropertyName("encounterid")]
        public int EncounterID { get; set; }

        [JsonPropertyName("patientid")]
        public string PatientID { get; set; }
    }

    public class FlatService
    {
        [JsonPropertyName("serviceid")]
        public int ServiceID { get; set; }

        [JsonPropertyName("servicename")]
        public string ServiceName { get; set; }
    }

    public class FlatImagingResult
    {
        [JsonPropertyName("detailid")]
        public int DetailID { get; set; }

        [JsonPropertyName("imageurl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("pdfurl")]
        public string PdfUrl { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }
    }

    // ==========================================
    // FLAT LAB REQUESTS DTO
    // ==========================================
    public class FlatLabRequest
    {
        [JsonPropertyName("labid")]
        public int LabID { get; set; }

        [JsonPropertyName("encounterid")]
        public int EncounterID { get; set; }

        [JsonPropertyName("doctorid")]
        public string DoctorID { get; set; }

        [JsonPropertyName("testtype")]
        public string TestType { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class FlatLabResult
    {
        [JsonPropertyName("labid")]
        public int LabID { get; set; }

        [JsonPropertyName("resulttext")]
        public string ResultText { get; set; }

        [JsonPropertyName("fileurl")]
        public string FileUrl { get; set; }
    }
}
