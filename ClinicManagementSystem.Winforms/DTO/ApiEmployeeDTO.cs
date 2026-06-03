using System;
using System.Text.Json.Serialization;

namespace DTO
{
    public class ApiEmployeeDTO
    {
        [JsonPropertyName("employeeid")]
        public Guid? EmployeeId { get; set; }

        [JsonPropertyName("doctorid")]
        public Guid? LegacyDoctorId { get; set; }

        [JsonPropertyName("employeeuuid")]
        public Guid? LegacyEmployeeUuid { get; set; }

        [JsonPropertyName("patientid")]
        public Guid? LegacyPatientId { get; set; }

        [JsonPropertyName("patientcode")]
        public string LegacyPatientCode { get; set; }

        [JsonPropertyName("employeecode")]
        public string EmployeeCode { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

        [JsonPropertyName("rolename")]
        public string RoleName { get; set; }

        [JsonPropertyName("departmentid")]
        public int? DepartmentID { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public Guid? SyncUuid
        {
            get => EmployeeId ?? LegacyDoctorId ?? LegacyEmployeeUuid ?? LegacyPatientId;
            set => EmployeeId = value;
        }

        [JsonIgnore]
        public string SyncCode
        {
            get => !string.IsNullOrWhiteSpace(EmployeeCode) ? EmployeeCode : (!string.IsNullOrWhiteSpace(LegacyPatientCode) ? LegacyPatientCode : "");
            set => EmployeeCode = value;
        }
    }
}
