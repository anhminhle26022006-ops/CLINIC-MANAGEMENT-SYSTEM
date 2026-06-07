using DAL.DataContext;
using DAL.Interfaces.ERM;
using DTO.Clinical.erm;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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
                Encounters = new List<EncounterHistoryDto>()
            };

            // 2. LOAD BASIC INFO
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy
                FROM Patients WHERE PatientID = @ID", conn))
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
                        patientDto.DOB = Convert.ToDateTime(r["DOB"]);
                        patientDto.Phone = r["Phone"].ToString();
                        patientDto.Address = r["Address"].ToString();
                        patientDto.BloodType = r["BloodType"].ToString();
                        patientDto.Allergy = r["Allergy"].ToString();
                    }
                }
            }

            // 3. GET ENCOUNTERS
            using (var conn = DatabaseHelper.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT EncounterID, StartTime
                FROM Encounters
                WHERE PatientID = @PID
                ORDER BY StartTime DESC", conn))
            {
                cmd.Parameters.AddWithValue("@PID", patientId);

                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        patientDto.Encounters.Add(new EncounterHistoryDto
                        {
                            EncounterId = Convert.ToInt32(r["EncounterID"]),
                            VisitDate = Convert.ToDateTime(r["StartTime"])
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
            }

            return patientDto;
        }

        private List<PrescriptionHistoryDto> LoadPrescriptions(int encounterId)
        {
            var list = new List<PrescriptionHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT PrescriptionID, CreatedAt
                FROM Prescriptions
                WHERE EncounterID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new PrescriptionHistoryDto
                {
                    PrescriptionCode = r["PrescriptionID"].ToString(),
                    CreatedAt = Convert.ToDateTime(r["CreatedAt"]),
                    DoctorName = "Doctor"
                });
            }

            return list;
        }

        private List<LabHistoryDto> LoadLabs(int encounterId)
        {
            var list = new List<LabHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT TestType, Status
                FROM LabRequests
                WHERE EncounterID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new LabHistoryDto
                {
                    TestType = r["TestType"].ToString(),
                    Status = r["Status"].ToString()
                });
            }

            return list;
        }

        private List<ImagingHistoryDto> LoadImaging(int encounterId)
        {
            var list = new List<ImagingHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT ir.BodyPart, ir.Status, ir.ImagingServiceID
                FROM ImagingRequests ir
                WHERE ir.EncounterID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new ImagingHistoryDto
                {
                    BodyPart = r["BodyPart"].ToString(),
                    Modality = "Unknown",
                    CreatedAt = DateTime.Now,
                    Conclusion = "",
                    ImageUrl = null,
                    PdfUrl = null
                });
            }

            return list;
        }

        private List<InvoiceHistoryDto> LoadInvoices(int encounterId)
        {
            var list = new List<InvoiceHistoryDto>();

            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
        SELECT Total, Status, CreatedAt
        FROM Invoices
        WHERE EncounterID = @ID", conn);

            cmd.Parameters.AddWithValue("@ID", encounterId);

            conn.Open();
            using var r = cmd.ExecuteReader();

            while (r.Read())
            {
                list.Add(new InvoiceHistoryDto
                {
                    TotalAmount = Convert.ToDecimal(r["Total"]),
                    Status = r["Status"].ToString(),
                    InvoiceDate = Convert.ToDateTime(r["CreatedAt"]),
                    PaymentMethod = "Cash",
                    Services = new List<ServiceItemDto>()
                });
            }

            return list;
        }

        private VitalSignDto LoadVitalSigns(int encounterId)
        {
            using var conn = DatabaseHelper.GetConnection();
            using var cmd = new SqlCommand(@"
                SELECT TOP 1 Temperature, BloodPressure, HeartRate, Weight
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
                    Temperature = Convert.ToDecimal(r["Temperature"]),
                    BloodPressure = r["BloodPressure"].ToString(),
                    HeartRate = Convert.ToInt32(r["HeartRate"]),
                    Weight = Convert.ToDecimal(r["Weight"])
                };
            }

            return new VitalSignDto();
        }
    }
}