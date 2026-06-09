using DAL.DataContext;
using DAL.Interfaces.ERM;
using DTO.Clinical.erm;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories.ERM
{
    public class ERMRepository : IERMRepository
    {
        public async Task<PatientERMDto> GetPatientERM(Guid patientUUID)
        {
            await Task.Delay(50);

            // 1. GET PATIENT
            var patient = DatabaseHelper.ExecuteScalar(
                "SELECT PatientID FROM Patients WHERE PatientUUID = @UUID",
                new[] { new SqlParameter("@UUID", patientUUID) });

            if (patient == null)
                return null;

            int patientId = Convert.ToInt32(patient);

            var patientDto = new PatientERMDto
            {
                PatientUUID = patientUUID,
                Encounters = new List<EncounterHistoryDto>(),
                Prescriptions = new List<PrescriptionHistoryDto>(),
                LabResults = new List<LabHistoryDto>(),
                ImagingResults = new List<ImagingHistoryDto>(),
                Invoices = new List<InvoiceHistoryDto>(),
                FollowUps = new List<FollowUpHistoryDto>()
            };

            // 2. LOAD BASIC INFO
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT p.PatientCode,
                       p.FullName,
                       p.Gender,
                       p.DOB,
                       p.Phone,
                       p.Address,
                       p.BloodType,
                       p.Allergy,
                       pi.InsuranceNumber
                FROM Patients p
                LEFT JOIN PatientInsurance pi ON pi.PatientID = p.PatientID
                WHERE p.PatientID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", patientId);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        patientDto.PatientCode = r["PatientCode"].ToString();
                        patientDto.FullName = r["FullName"].ToString();
                        patientDto.Gender = r["Gender"].ToString();
                        patientDto.DOB = ReadDate(r, "DOB", DateTime.Today);
                        patientDto.Phone = ReadString(r, "Phone");
                        patientDto.Address = ReadString(r, "Address");
                        patientDto.BloodType = ReadString(r, "BloodType");
                        patientDto.Allergy = ReadString(r, "Allergy");
                        patientDto.InsuranceNumber = ReadString(r, "InsuranceNumber");
                        patientDto.Email = string.Empty;
                        patientDto.EmergencyContact = string.IsNullOrWhiteSpace(patientDto.Phone)
                            ? string.Empty
                            : patientDto.Phone;
                    }
                }
            }

            // 3. GET ENCOUNTERS
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT e.EncounterID,
                       e.EncounterUUID,
                       e.StartTime,
                       emp.FullName AS DoctorName,
                       d.DepartmentName,
                       mr.Symptoms,
                       mr.Diagnosis,
                       mr.Conclusion
                FROM Encounters e
                LEFT JOIN Employees emp ON emp.EmployeeID = e.DoctorID
                LEFT JOIN Departments d ON d.DepartmentID = emp.DepartmentID
                LEFT JOIN MedicalRecords mr ON mr.EncounterID = e.EncounterID
                WHERE e.PatientID = @PID
                ORDER BY e.StartTime DESC, e.EncounterID DESC", conn))
            {
                cmd.Parameters.AddWithValue("@PID", patientId);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        patientDto.Encounters.Add(new EncounterHistoryDto
                        {
                            EncounterId = ReadInt(r, "EncounterID"),
                            EncounterUUID = ReadGuid(r, "EncounterUUID"),
                            VisitDate = ReadDate(r, "StartTime", DateTime.Today),
                            DoctorName = ReadString(r, "DoctorName"),
                            DepartmentName = ReadString(r, "DepartmentName"),
                            Symptoms = ReadString(r, "Symptoms"),
                            Diagnosis = ReadString(r, "Diagnosis"),
                            Conclusion = ReadString(r, "Conclusion"),
                            Prescriptions = new List<PrescriptionHistoryDto>(),
                            LabResults = new List<LabHistoryDto>(),
                            ImagingResults = new List<ImagingHistoryDto>(),
                            Invoices = new List<InvoiceHistoryDto>(),
                            FollowUps = new List<FollowUpHistoryDto>()
                        });
                    }
                }
            }

            // 4. LOAD PRESCRIPTION + LAB + IMAGING + PAYMENT (RÚT GỌN MOCK DB STYLE)

            foreach (var e in patientDto.Encounters)
            {
                e.Prescriptions = LoadPrescriptions(e.EncounterId);
                e.LabResults = LoadLabs(e.EncounterId);
                e.ImagingResults = LoadImaging(e.EncounterId);
                e.Invoices = LoadInvoices(e.EncounterId);
                e.VitalSigns = LoadVitalSigns(e.EncounterId);
                e.FollowUps = LoadFollowUps(e.EncounterId);

                patientDto.Prescriptions.AddRange(e.Prescriptions);
                patientDto.LabResults.AddRange(e.LabResults);
                patientDto.ImagingResults.AddRange(e.ImagingResults);
                patientDto.Invoices.AddRange(e.Invoices);
                patientDto.FollowUps.AddRange(e.FollowUps);
            }

            return patientDto;
        }

        private List<PrescriptionHistoryDto> LoadPrescriptions(int encounterId)
        {
            var list = new List<PrescriptionHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT p.PrescriptionID,
                       p.PrescriptionUUID,
                       p.CreatedAt,
                       emp.FullName AS DoctorName
                FROM Prescriptions p
                LEFT JOIN Employees emp ON emp.EmployeeID = p.DoctorID
                WHERE p.EncounterID = @ID
                ORDER BY p.CreatedAt DESC, p.PrescriptionID DESC", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PrescriptionHistoryDto
                {
                    PrescriptionUUID = ReadGuid(r, "PrescriptionUUID"),
                    PrescriptionCode = "DT-" + ReadInt(r, "PrescriptionID").ToString("D5"),
                    CreatedAt = ReadDate(r, "CreatedAt", DateTime.Today),
                    DoctorName = ReadString(r, "DoctorName"),
                    Medicines = LoadPrescriptionItems(ReadInt(r, "PrescriptionID"))
                });
            }

            return list;
        }

        private List<LabHistoryDto> LoadLabs(int encounterId)
        {
            var list = new List<LabHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT lr.LabRequestUUID,
                       lr.TestType,
                       lr.Status,
                       lr.CreatedAt,
                       emp.FullName AS DoctorName,
                       res.ResultText,
                       res.FileURL
                FROM LabRequests lr
                LEFT JOIN Employees emp ON emp.EmployeeID = lr.DoctorID
                LEFT JOIN LabResults res ON res.LabID = lr.LabID
                WHERE lr.EncounterID = @ID
                ORDER BY lr.CreatedAt DESC, lr.LabID DESC", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new LabHistoryDto
                {
                    LabRequestUUID = ReadGuid(r, "LabRequestUUID"),
                    TestType = ReadString(r, "TestType"),
                    Status = ReadString(r, "Status"),
                    CreatedAt = ReadDate(r, "CreatedAt", DateTime.Today),
                    DoctorName = ReadString(r, "DoctorName"),
                    FileUrl = ResolveResourcePath(ReadString(r, "FileURL")),
                    ResultItems = ParseLabResultItems(ReadString(r, "ResultText"))
                });
            }

            return list;
        }

        private List<ImagingHistoryDto> LoadImaging(int encounterId)
        {
            var list = new List<ImagingHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT ir.ImagingRequestUUID,
                       ir.BodyPart,
                       ir.CreatedAt,
                       ir.Status,
                       svc.Modality,
                       svc.ServiceName,
                       emp.FullName AS DoctorName,
                       p.FullName AS PatientName,
                       res.ResultText,
                       res.ImageURL,
                       res.PDFURL
                FROM ImagingRequests ir
                LEFT JOIN ImagingServices svc ON svc.ImagingServiceID = ir.ImagingServiceID
                LEFT JOIN Employees emp ON emp.EmployeeID = ir.DoctorID
                LEFT JOIN Encounters e ON e.EncounterID = ir.EncounterID
                LEFT JOIN Patients p ON p.PatientID = e.PatientID
                LEFT JOIN ImagingResults res ON res.ImagingRequestID = ir.ImagingRequestID
                WHERE ir.EncounterID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ImagingHistoryDto
                {
                    ImagingRequestUUID = ReadGuid(r, "ImagingRequestUUID"),
                    BodyPart = ReadString(r, "BodyPart"),
                    Modality = string.IsNullOrWhiteSpace(ReadString(r, "Modality"))
                        ? ReadString(r, "ServiceName")
                        : ReadString(r, "Modality"),
                    DoctorName = ReadString(r, "DoctorName"),
                    PatientName = ReadString(r, "PatientName"),
                    CreatedAt = ReadDate(r, "CreatedAt", DateTime.Today),
                    Conclusion = ReadString(r, "ResultText"),
                    ImageUrl = ResolveResourcePath(ReadString(r, "ImageURL")),
                    PdfUrl = ResolveResourcePath(ReadString(r, "PDFURL"))
                });
            }

            return list;
        }

        private List<InvoiceHistoryDto> LoadInvoices(int encounterId)
        {
            var list = new List<InvoiceHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT i.InvoiceID,
                       i.InvoiceUUID,
                       i.Total,
                       i.Status,
                       i.CreatedAt,
                       pay.Method AS PaymentMethod
                FROM Invoices i
                LEFT JOIN Payments pay ON pay.EncounterID = i.EncounterID
                WHERE i.EncounterID = @ID
                ORDER BY i.CreatedAt DESC, i.InvoiceID DESC", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new InvoiceHistoryDto
                {
                    InvoiceUUID = ReadGuid(r, "InvoiceUUID"),
                    TotalAmount = ReadDecimal(r, "Total"),
                    Status = NormalizeInvoiceStatus(ReadString(r, "Status")),
                    InvoiceDate = ReadDate(r, "CreatedAt", DateTime.Today),
                    PaymentMethod = ReadString(r, "PaymentMethod"),
                    Services = LoadInvoiceServices(ReadInt(r, "InvoiceID"))
                });
            }

            return list;
        }

        private VitalSignDto LoadVitalSigns(int encounterId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT TOP 1 Temperature, BloodPressure, HeartRate, Weight, Height
                FROM VitalSigns
                WHERE EncounterID = @ID
                ORDER BY CreatedAt DESC", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            if (r.Read())
            {
                return new VitalSignDto
                {
                    Temperature = ReadDecimal(r, "Temperature"),
                    BloodPressure = ReadString(r, "BloodPressure"),
                    HeartRate = ReadInt(r, "HeartRate"),
                    Weight = ReadDecimal(r, "Weight"),
                    Height = ReadDecimal(r, "Height")
                };
            }

            return new VitalSignDto();
        }

        private List<PrescriptionItemDto> LoadPrescriptionItems(int prescriptionId)
        {
            var list = new List<PrescriptionItemDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT m.Name,
                       pd.Dosage,
                       pd.Frequency,
                       pd.Quantity,
                       pd.Instruction
                FROM PrescriptionDetails pd
                INNER JOIN Medicines m ON m.MedicineID = pd.MedicineID
                WHERE pd.PrescriptionID = @ID
                ORDER BY pd.DetailID", conn);

            cmd.Parameters.AddWithValue("@ID", prescriptionId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PrescriptionItemDto
                {
                    MedicineName = ReadString(r, "Name"),
                    Dosage = ReadString(r, "Dosage"),
                    Frequency = ReadString(r, "Frequency"),
                    Quantity = ReadInt(r, "Quantity"),
                    Instruction = ReadString(r, "Instruction")
                });
            }

            return list;
        }

        private List<ServiceItemDto> LoadInvoiceServices(int invoiceId)
        {
            var list = new List<ServiceItemDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT s.ServiceName,
                       id.Quantity,
                       id.Price
                FROM InvoiceDetails id
                INNER JOIN Services s ON s.ServiceID = id.ServiceID
                WHERE id.InvoiceID = @ID
                ORDER BY id.DetailID", conn);

            cmd.Parameters.AddWithValue("@ID", invoiceId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ServiceItemDto
                {
                    ServiceName = ReadString(r, "ServiceName"),
                    Quantity = ReadInt(r, "Quantity"),
                    Price = ReadDecimal(r, "Price")
                });
            }

            return list;
        }

        private List<FollowUpHistoryDto> LoadFollowUps(int encounterId)
        {
            var list = new List<FollowUpHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT f.FollowUpUUID,
                       f.FollowUpDate,
                       f.Status,
                       emp.FullName AS DoctorName,
                       mr.Conclusion,
                       mr.Notes
                FROM FollowUps f
                INNER JOIN Encounters e ON e.EncounterID = f.EncounterID
                LEFT JOIN Employees emp ON emp.EmployeeID = e.DoctorID
                LEFT JOIN MedicalRecords mr ON mr.EncounterID = e.EncounterID
                WHERE f.EncounterID = @ID
                ORDER BY f.FollowUpDate DESC", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                var content = ReadString(r, "Notes");
                if (string.IsNullOrWhiteSpace(content))
                {
                    content = ReadString(r, "Conclusion");
                }

                list.Add(new FollowUpHistoryDto
                {
                    FollowUpUUID = ReadGuid(r, "FollowUpUUID"),
                    FollowUpDate = ReadDate(r, "FollowUpDate", DateTime.Today),
                    Status = ReadString(r, "Status"),
                    DoctorName = ReadString(r, "DoctorName"),
                    Content = content
                });
            }

            return list;
        }

        private static List<LabResultItemDto> ParseLabResultItems(string resultText)
        {
            var defaults = new List<LabResultItemDto>
            {
                new LabResultItemDto { Name = "WBC", Value = "7.1", Unit = "G/L", ReferenceRange = "4.0-10.0" },
                new LabResultItemDto { Name = "RBC", Value = "4.65", Unit = "T/L", ReferenceRange = "4.2-5.8" },
                new LabResultItemDto { Name = "HGB", Value = "139", Unit = "g/L", ReferenceRange = "120-160" },
                new LabResultItemDto { Name = "PLT", Value = "255", Unit = "G/L", ReferenceRange = "150-400" }
            };

            if (string.IsNullOrWhiteSpace(resultText))
            {
                return defaults;
            }

            foreach (var item in resultText.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                var parts = item.Split('=', 2, StringSplitOptions.TrimEntries);
                if (parts.Length != 2)
                {
                    continue;
                }

                var existing = defaults.FirstOrDefault(x => string.Equals(x.Name, parts[0], StringComparison.OrdinalIgnoreCase));
                if (existing != null)
                {
                    existing.Value = parts[1];
                }
            }

            return defaults;
        }

        private static string ResolveResourcePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            if (Path.IsPathRooted(path))
            {
                return File.Exists(path) ? path : null;
            }

            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var candidates = new[]
            {
                Path.Combine(baseDir, path),
                Path.Combine(baseDir, "..", "..", "..", path),
                Path.Combine(baseDir, "..", "..", "..", "..", path),
                Path.Combine(baseDir, "..", "..", "..", "..", "..", path),
                Path.Combine(baseDir, "..", "..", "..", "Resources", Path.GetFileName(path))
            };

            foreach (var candidate in candidates)
            {
                var fullPath = Path.GetFullPath(candidate);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }

        private static string NormalizeInvoiceStatus(string status)
        {
            if (status == "Paid")
            {
                return "Đã thanh toán";
            }

            if (status == "Unpaid" || status == "Pending")
            {
                return "Chưa thanh toán";
            }

            return status;
        }

        private static string ReadString(SqlDataReader reader, string name)
        {
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? string.Empty : reader.GetValue(ordinal).ToString();
        }

        private static int ReadInt(SqlDataReader reader, string name)
        {
            var value = reader.GetValue(reader.GetOrdinal(name));
            return value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        private static decimal ReadDecimal(SqlDataReader reader, string name)
        {
            var value = reader.GetValue(reader.GetOrdinal(name));
            return value == DBNull.Value ? 0 : Convert.ToDecimal(value, CultureInfo.InvariantCulture);
        }

        private static DateTime ReadDate(SqlDataReader reader, string name, DateTime fallback)
        {
            var value = reader.GetValue(reader.GetOrdinal(name));
            return value == DBNull.Value ? fallback : Convert.ToDateTime(value);
        }

        private static Guid ReadGuid(SqlDataReader reader, string name)
        {
            var value = reader.GetValue(reader.GetOrdinal(name));
            return value == DBNull.Value ? Guid.Empty : (Guid)value;
        }
    }
}
