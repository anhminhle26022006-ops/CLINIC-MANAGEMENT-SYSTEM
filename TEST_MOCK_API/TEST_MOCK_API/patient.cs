using System;
using System.Text.Json.Serialization;

namespace TEST_MOCK_API
{
    public class PatientTest
    {
        [JsonPropertyName("patientid")]
        public Guid? PatientID { get; set; } // Đổi sang Guid? để hứng chuỗi UUID từ Supabase một cách an toàn

        [JsonPropertyName("patientcode")]
        public string PatientCode { get; set; }

        [JsonPropertyName("fullname")]
        public string FullName { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("dob")]
        public string DOB { get; set; } // Bổ sung trường Ngày sinh

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("bloodtype")]
        public string BloodType { get; set; }

        [JsonPropertyName("allergy")]
        public string Allergy { get; set; }
    }
}