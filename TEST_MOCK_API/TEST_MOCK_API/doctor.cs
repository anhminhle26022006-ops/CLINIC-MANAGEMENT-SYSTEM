using System;
using System.Text.Json.Serialization;

namespace TEST_MOCK_API
{
    public class DoctorTest
    {
        [JsonPropertyName("employeeid")]
        public Guid? EmployeeID { get; set; }

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
    }
}