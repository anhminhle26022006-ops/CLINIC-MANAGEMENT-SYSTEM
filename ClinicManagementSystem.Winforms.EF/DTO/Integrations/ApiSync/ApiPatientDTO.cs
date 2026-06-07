using System;
using System.Text.Json.Serialization;

namespace DTO
{
    public class ApiPatientDTO
    {
        [JsonPropertyName("patientid")]
        public Guid? PatientId { get; set; }

        [JsonPropertyName("patientuuid")]
        public Guid? LegacyPatientUuid { get; set; }

        [JsonPropertyName("patientcode")]
        public string PatientCode { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("dob")]
        public string DOB { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("bloodtype")]
        public string BloodType { get; set; }

        [JsonPropertyName("allergy")]
        public string Allergy { get; set; }

        [JsonIgnore]
        public Guid? SyncUuid
        {
            get => PatientId ?? LegacyPatientUuid;
            set => PatientId = value;
        }
    }
}
