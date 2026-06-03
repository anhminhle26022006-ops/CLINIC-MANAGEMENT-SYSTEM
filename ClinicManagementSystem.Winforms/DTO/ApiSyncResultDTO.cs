using System.Collections.Generic;

namespace DTO
{
    public class ApiSyncResultDTO
    {
        public int InsertedPatientsToSupabase { get; set; }
        public int InsertedEmployeesToSupabase { get; set; }
        public int PatchedPatientUuidToSupabase { get; set; }
        public int PatchedEmployeeUuidToSupabase { get; set; }
        public int InsertedPatientsToLocal { get; set; }
        public int InsertedEmployeesToLocal { get; set; }
        public int GeneratedPatientUuidInLocal { get; set; }
        public int GeneratedEmployeeUuidInLocal { get; set; }
        public int PatchedPatientUuidToSheet { get; set; }
        public int PatchedEmployeeUuidToSheet { get; set; }
        public int LinkedExistingPatientByCode { get; set; }
        public int LinkedExistingEmployeeByCode { get; set; }
        public int InsertedPatientsToSheet { get; set; }
        public int InsertedEmployeesToSheet { get; set; }
        public int SkippedPatientRows { get; set; }
        public int SkippedEmployeeRows { get; set; }
        public List<ApiPatientDTO> MergedPatients { get; set; } = new List<ApiPatientDTO>();

        public string ToUserMessage()
        {
            return
                "ĐỒNG BỘ HOÀN TẤT!\n\n" +
                "--- SHEETDB/SUPABASE -> SQL SERVER LOCAL ---\n" +
                $"+ Bệnh nhân insert mới vào local: {InsertedPatientsToLocal}\n" +
                $"+ Bác sĩ/nhân viên insert mới vào local: {InsertedEmployeesToLocal}\n" +
                $"+ Patient UUID sinh tại local: {GeneratedPatientUuidInLocal}\n" +
                $"+ Employee UUID sinh tại local: {GeneratedEmployeeUuidInLocal}\n\n" +
                "--- SHEETDB -> SUPABASE ---\n" +
                $"+ Bệnh nhân insert mới lên Supabase: {InsertedPatientsToSupabase}\n" +
                $"+ Bác sĩ/nhân viên insert mới lên Supabase: {InsertedEmployeesToSupabase}\n" +
                $"+ Patient UUID patch vào Supabase record cũ: {PatchedPatientUuidToSupabase}\n" +
                $"+ Employee UUID patch vào Supabase record cũ: {PatchedEmployeeUuidToSupabase}\n\n" +
                "--- GHI UUID NGƯỢC VỀ SHEETDB ---\n" +
                $"+ Patient UUID đã ghi vào cột patientid: {PatchedPatientUuidToSheet}\n" +
                $"+ Employee UUID đã ghi vào cột employeeid: {PatchedEmployeeUuidToSheet}\n" +
                $"+ PatientCode cũ được liên kết lại: {LinkedExistingPatientByCode}\n" +
                $"+ EmployeeCode cũ được liên kết lại: {LinkedExistingEmployeeByCode}\n\n" +
                "--- SUPABASE -> SHEETDB ---\n" +
                $"+ Bệnh nhân mới từ Supabase ghi xuống Sheet: {InsertedPatientsToSheet}\n" +
                $"+ Bác sĩ/nhân viên mới từ Supabase ghi xuống Sheet: {InsertedEmployeesToSheet}\n\n" +
                "--- DÒNG BỊ BỎ QUA ---\n" +
                $"+ Sheet bệnh nhân thiếu mã hoặc tên: {SkippedPatientRows}\n" +
                $"+ Sheet bác sĩ/nhân viên thiếu mã hoặc tên: {SkippedEmployeeRows}\n\n" +
                $"=> Grid đang hiển thị: {MergedPatients.Count} bệnh nhân.";
        }
    }
}
