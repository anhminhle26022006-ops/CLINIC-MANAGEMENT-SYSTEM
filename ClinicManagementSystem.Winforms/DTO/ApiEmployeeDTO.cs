using System;
using System.Text.Json.Serialization;

namespace DTO
{
    public class ApiEmployeeDTO
    {
        [JsonPropertyName("employeeid")]
        public Guid? EmployeeId { get; set; }

        [JsonPropertyName("employeecode")]
        public string EmployeeCode { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

        [JsonPropertyName("rolename")]
        public string RoleName { get; set; }

        [JsonPropertyName("departmentid")]
        public int? DepartmentID { get; set; }

        [JsonPropertyName("departmentname")]
        public string DepartmentName { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonIgnore]
        public Guid? SyncUuid
        {
            get => EmployeeId;
            set => EmployeeId = value;
        }

        [JsonIgnore]
        public string SyncCode
        {
            get => EmployeeCode ?? "";
            set => EmployeeCode = value;
        }
    }
}
