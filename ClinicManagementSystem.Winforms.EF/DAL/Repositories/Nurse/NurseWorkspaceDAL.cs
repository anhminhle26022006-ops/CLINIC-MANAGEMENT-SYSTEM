using DAL.DataContext;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class NurseWorkspaceDAL
    {
        public async Task<List<NurseMedicalRecordDTO>> SearchMedicalRecords(string term)
        {
            using var context = DbContextProvider.CreateContext();
            string search = (term ?? "").Trim();

            return await context.Encounters
                .OrderByDescending(e => e.StartTime ?? e.CreatedAt)
                .ThenByDescending(e => e.EncounterID)
                .Take(200)
                .Where(e => search == ""
                         || e.Patient.FullName.Contains(search)
                         || e.Patient.PatientCode.Contains(search)
                         || e.EncounterID.ToString().Contains(search))
                .Select(e => new NurseMedicalRecordDTO
                {
                    EncounterID = e.EncounterID,
                    PatientID = e.PatientID,
                    PatientCode = e.Patient.PatientCode ?? "",
                    PatientName = e.Patient.FullName ?? "",
                    Gender = e.Patient.Gender ?? "",
                    BirthDate = e.Patient.DOB,
                    DoctorName = e.Doctor.FullName ?? "",
                    DepartmentName = e.Doctor.Department.DepartmentName ?? "",
                    StartTime = e.StartTime,
                    EncounterStatus = e.Status ?? "",
                    Diagnosis = e.MedicalRecord.Diagnosis ?? "",
                    NursingNote = e.MedicalRecord.Notes ?? "",
                    Temperature = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => v.Temperature)
                                       .FirstOrDefault(),
                    BloodPressure = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => v.BloodPressure)
                                       .FirstOrDefault() ?? "",
                    HeartRate = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => v.HeartRate)
                                       .FirstOrDefault(),
                    Spo2 = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => v.SPO2)
                                       .FirstOrDefault(),
                    Weight = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => v.Weight)
                                       .FirstOrDefault(),
                    VitalCreatedAt = e.VitalSigns
                                       .OrderByDescending(v => v.CreatedAt)
                                       .ThenByDescending(v => v.VitalID)
                                       .Select(v => (DateTime?)v.CreatedAt)
                                       .FirstOrDefault()
                })
                .ToListAsync();
        }

        public async Task<List<NurseWorkAssignmentDTO>> GetAssignments(
            int employeeId, DateTime fromDate, DateTime toDate)
        {
            using var context = DbContextProvider.CreateContext();

            var query = context.WorkAssignments
                .Where(wa => wa.WorkDate >= fromDate.Date && wa.WorkDate <= toDate.Date);

            if (employeeId > 0)
                query = query.Where(wa => wa.EmployeeID == employeeId);

            return await query
                .OrderBy(wa => wa.WorkDate)
                .ThenBy(wa => wa.Employee.EmployeeShifts
                    .Where(es => es.ShiftID == wa.ShiftID)
                    .Select(es => es.Shift.StartTime)
                    .FirstOrDefault())
                .ThenByDescending(wa => wa.Priority)
                .ThenBy(wa => wa.AssignmentID)
                .Select(wa => new NurseWorkAssignmentDTO
                {
                    AssignmentID = wa.AssignmentID,
                    EmployeeID = wa.EmployeeID,
                    EmployeeName = wa.Employee.FullName ?? "",
                    RoleName = wa.Employee.Role.RoleName ?? "",
                    WorkDate = wa.WorkDate,
                    ShiftID = wa.ShiftID,
                    ShiftName = wa.ShiftID != null
                                     ? context.Shifts
                                         .Where(s => s.ShiftID == wa.ShiftID)
                                         .Select(s => s.Name)
                                         .FirstOrDefault() ?? ""
                                     : "",
                    StartTime = wa.ShiftID != null
                                     ? context.Shifts
                                         .Where(s => s.ShiftID == wa.ShiftID)
                                         .Select(s => (TimeSpan?)s.StartTime)
                                         .FirstOrDefault()
                                     : null,
                    EndTime = wa.ShiftID != null
                                     ? context.Shifts
                                         .Where(s => s.ShiftID == wa.ShiftID)
                                         .Select(s => (TimeSpan?)s.EndTime)
                                         .FirstOrDefault()
                                     : null,
                    DepartmentID = wa.DepartmentID,
                    DepartmentName = wa.DepartmentID != null
                                     ? context.Departments
                                         .Where(d => d.DepartmentID == wa.DepartmentID)
                                         .Select(d => d.DepartmentName)
                                         .FirstOrDefault() ?? ""
                                     : "",
                    RoomID = wa.RoomID,
                    RoomCode = wa.RoomID != null
                                     ? context.Rooms
                                         .Where(r => r.RoomID == wa.RoomID)
                                         .Select(r => r.RoomCode)
                                         .FirstOrDefault() ?? ""
                                     : "",
                    EncounterID = wa.EncounterID,
                    PatientCode = wa.EncounterID != null
                                     ? wa.Encounter.Patient.PatientCode ?? ""
                                     : "",
                    PatientName = wa.EncounterID != null
                                     ? wa.Encounter.Patient.FullName ?? ""
                                     : "",
                    AssignmentType = wa.AssignmentType ?? "",
                    Title = wa.Title ?? "",
                    Priority = wa.Priority ?? "",
                    Status = wa.Status ?? "",
                    Notes = wa.Notes ?? "",
                    CreatedAt = wa.CreatedAt,
                    CompletedAt = wa.CompletedAt
                })
                .ToListAsync();
        }
    }
}