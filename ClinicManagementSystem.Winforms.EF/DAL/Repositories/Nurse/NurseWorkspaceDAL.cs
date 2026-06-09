using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class NurseWorkspaceDAL
    {
        public List<NurseMedicalRecordDTO> SearchMedicalRecords(string term)
        {
            if (!SchemaHelper.TableExists("Patients") || !SchemaHelper.TableExists("Encounters"))
            {
                return new List<NurseMedicalRecordDTO>();
            }

            string like = "%" + (term ?? string.Empty).Trim() + "%";
            string query = @"
                SELECT TOP 200
                       e.EncounterID,
                       p.PatientID,
                       ISNULL(p.PatientCode, '') AS PatientCode,
                       ISNULL(p.FullName, '') AS PatientName,
                       ISNULL(p.Gender, '') AS Gender,
                       p.DOB AS BirthDate,
                       ISNULL(doc.FullName, '') AS DoctorName,
                       ISNULL(dep.DepartmentName, '') AS DepartmentName,
                       e.StartTime,
                       ISNULL(e.Status, '') AS EncounterStatus,
                       ISNULL(mr.Diagnosis, '') AS Diagnosis,
                       ISNULL(mr.Notes, '') AS NursingNote,
                       v.Temperature,
                       ISNULL(v.BloodPressure, '') AS BloodPressure,
                       v.HeartRate,
                       v.SPO2,
                       v.Weight,
                       v.CreatedAt AS VitalCreatedAt
                FROM Encounters e
                INNER JOIN Patients p ON e.PatientID = p.PatientID
                LEFT JOIN Employees doc ON e.DoctorID = doc.EmployeeID
                LEFT JOIN Departments dep ON doc.DepartmentID = dep.DepartmentID
                LEFT JOIN MedicalRecords mr ON e.EncounterID = mr.EncounterID
                OUTER APPLY
                (
                    SELECT TOP 1 Temperature, BloodPressure, HeartRate, SPO2, Weight, CreatedAt
                    FROM VitalSigns vs
                    WHERE vs.EncounterID = e.EncounterID
                    ORDER BY vs.CreatedAt DESC, vs.VitalID DESC
                ) v
                WHERE (@Term = ''
                       OR p.FullName LIKE @Like
                       OR p.PatientCode LIKE @Like
                       OR CAST(e.EncounterID AS varchar(20)) LIKE @Like)
                ORDER BY ISNULL(e.StartTime, e.CreatedAt) DESC, e.EncounterID DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@Term", (term ?? string.Empty).Trim()),
                new SqlParameter("@Like", like)
            };

            return MapMedicalRecords(DatabaseHelper.ExecuteQuery(query, parameters));
        }

        public List<NurseWorkAssignmentDTO> GetAssignments(int employeeId, DateTime fromDate, DateTime toDate)
        {
            if (!SchemaHelper.TableExists("WorkAssignments"))
            {
                return new List<NurseWorkAssignmentDTO>();
            }

            string employeeFilter = employeeId > 0 ? " AND wa.EmployeeID = @EmployeeID" : string.Empty;
            string query = @"
                SELECT wa.AssignmentID,
                       wa.EmployeeID,
                       ISNULL(emp.FullName, '') AS EmployeeName,
                       ISNULL(role.RoleName, '') AS RoleName,
                       wa.WorkDate,
                       wa.ShiftID,
                       ISNULL(shift.Name, '') AS ShiftName,
                       shift.StartTime,
                       shift.EndTime,
                       wa.DepartmentID,
                       ISNULL(dep.DepartmentName, '') AS DepartmentName,
                       wa.RoomID,
                       ISNULL(room.RoomCode, '') AS RoomCode,
                       wa.EncounterID,
                       ISNULL(patient.PatientCode, '') AS PatientCode,
                       ISNULL(patient.FullName, '') AS PatientName,
                       ISNULL(wa.AssignmentType, '') AS AssignmentType,
                       ISNULL(wa.Title, '') AS Title,
                       ISNULL(wa.Priority, '') AS Priority,
                       ISNULL(wa.Status, '') AS Status,
                       ISNULL(wa.Notes, '') AS Notes,
                       wa.CreatedAt,
                       wa.CompletedAt
                FROM WorkAssignments wa
                LEFT JOIN Employees emp ON wa.EmployeeID = emp.EmployeeID
                LEFT JOIN Roles role ON emp.RoleID = role.RoleID
                LEFT JOIN Shifts shift ON wa.ShiftID = shift.ShiftID
                LEFT JOIN Departments dep ON wa.DepartmentID = dep.DepartmentID
                LEFT JOIN Rooms room ON wa.RoomID = room.RoomID
                LEFT JOIN Encounters encounter ON wa.EncounterID = encounter.EncounterID
                LEFT JOIN Patients patient ON encounter.PatientID = patient.PatientID
                WHERE wa.WorkDate >= @FromDate
                  AND wa.WorkDate <= @ToDate" + employeeFilter + @"
                ORDER BY wa.WorkDate ASC, shift.StartTime ASC, wa.Priority DESC, wa.AssignmentID ASC";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@FromDate", fromDate.Date),
                new SqlParameter("@ToDate", toDate.Date)
            };

            if (employeeId > 0)
            {
                parameters.Add(new SqlParameter("@EmployeeID", employeeId));
            }

            return MapAssignments(DatabaseHelper.ExecuteQuery(query, parameters.ToArray()));
        }

        private static List<NurseMedicalRecordDTO> MapMedicalRecords(DataTable table)
        {
            List<NurseMedicalRecordDTO> list = new List<NurseMedicalRecordDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new NurseMedicalRecordDTO
                {
                    EncounterID = ToInt(row["EncounterID"]),
                    PatientID = ToInt(row["PatientID"]),
                    PatientCode = row["PatientCode"].ToString(),
                    PatientName = row["PatientName"].ToString(),
                    Gender = row["Gender"].ToString(),
                    BirthDate = ToDate(row["BirthDate"]),
                    DoctorName = row["DoctorName"].ToString(),
                    DepartmentName = row["DepartmentName"].ToString(),
                    StartTime = ToDate(row["StartTime"]),
                    EncounterStatus = row["EncounterStatus"].ToString(),
                    Diagnosis = row["Diagnosis"].ToString(),
                    NursingNote = row["NursingNote"].ToString(),
                    Temperature = ToDecimal(row["Temperature"]),
                    BloodPressure = row["BloodPressure"].ToString(),
                    HeartRate = ToNullableInt(row["HeartRate"]),
                    Spo2 = ToNullableInt(row["SPO2"]),
                    Weight = ToDecimal(row["Weight"]),
                    VitalCreatedAt = ToDate(row["VitalCreatedAt"])
                });
            }

            return list;
        }

        private static List<NurseWorkAssignmentDTO> MapAssignments(DataTable table)
        {
            List<NurseWorkAssignmentDTO> list = new List<NurseWorkAssignmentDTO>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new NurseWorkAssignmentDTO
                {
                    AssignmentID = ToInt(row["AssignmentID"]),
                    EmployeeID = ToInt(row["EmployeeID"]),
                    EmployeeName = row["EmployeeName"].ToString(),
                    RoleName = row["RoleName"].ToString(),
                    WorkDate = ToDate(row["WorkDate"]) ?? DateTime.MinValue,
                    ShiftID = ToNullableInt(row["ShiftID"]),
                    ShiftName = row["ShiftName"].ToString(),
                    StartTime = ToTime(row["StartTime"]),
                    EndTime = ToTime(row["EndTime"]),
                    DepartmentID = ToNullableInt(row["DepartmentID"]),
                    DepartmentName = row["DepartmentName"].ToString(),
                    RoomID = ToNullableInt(row["RoomID"]),
                    RoomCode = row["RoomCode"].ToString(),
                    EncounterID = ToNullableInt(row["EncounterID"]),
                    PatientCode = row["PatientCode"].ToString(),
                    PatientName = row["PatientName"].ToString(),
                    AssignmentType = row["AssignmentType"].ToString(),
                    Title = row["Title"].ToString(),
                    Priority = row["Priority"].ToString(),
                    Status = row["Status"].ToString(),
                    Notes = row["Notes"].ToString(),
                    CreatedAt = ToDate(row["CreatedAt"]),
                    CompletedAt = ToDate(row["CompletedAt"])
                });
            }

            return list;
        }

        private static int ToInt(object value)
        {
            return value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        private static int? ToNullableInt(object value)
        {
            return value == DBNull.Value ? null : Convert.ToInt32(value);
        }

        private static decimal? ToDecimal(object value)
        {
            return value == DBNull.Value ? null : Convert.ToDecimal(value);
        }

        private static DateTime? ToDate(object value)
        {
            return value == DBNull.Value ? null : Convert.ToDateTime(value);
        }

        private static TimeSpan? ToTime(object value)
        {
            return value == DBNull.Value ? null : (TimeSpan)value;
        }
    }
}
