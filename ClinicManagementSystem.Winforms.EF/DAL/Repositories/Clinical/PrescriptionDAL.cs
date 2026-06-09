using System;
using System.Collections.Generic;
using System.Data;
using DTO;
using Microsoft.Data.SqlClient;
using DAL.DataContext;

namespace DAL
{
    public class PrescriptionDAL
    {
        public List<PrescriptionDTO> GetPendingPrescriptions()
        {
            SeedSamplePrescriptionsIfEmpty();

            List<PrescriptionDTO> list = new List<PrescriptionDTO>();
            string query = @"
                SELECT p.PrescriptionID,
                       p.EncounterID,
                       p.DoctorID,
                       p.Status,
                       p.CreatedAt,
                       pat.FullName AS PatientName,
                       pat.Gender AS PatientGender,
                       pat.DOB AS PatientDOB,
                       pat.PatientCode AS PatientCode,
                       pat.Allergy AS PatientAllergies,
                       doc.FullName AS DoctorName,
                       mr.Diagnosis AS Diagnosis,
                       mr.Notes AS DoctorNotes
                FROM Prescriptions p
                JOIN Encounters enc ON p.EncounterID = enc.EncounterID
                JOIN Patients pat ON enc.PatientID = pat.PatientID
                JOIN Employees doc ON p.DoctorID = doc.EmployeeID
                LEFT JOIN MedicalRecords mr ON enc.EncounterID = mr.EncounterID
                WHERE p.Status != 'Completed' AND p.Status != N'Đã cấp phát'
                ORDER BY p.CreatedAt DESC";

            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var dto = new PrescriptionDTO
                {
                    PrescriptionID = Convert.ToInt32(row["PrescriptionID"]),
                    EncounterID = Convert.ToInt32(row["EncounterID"]),
                    DoctorID = Convert.ToInt32(row["DoctorID"]),
                    Status = row["Status"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    PatientName = row["PatientName"].ToString(),
                    PatientGender = row["PatientGender"].ToString(),
                    PatientDOB = row["PatientDOB"] != DBNull.Value ? Convert.ToDateTime(row["PatientDOB"]) : (DateTime?)null,
                    PatientCode = row["PatientCode"].ToString(),
                    PatientAllergies = row["PatientAllergies"] != DBNull.Value ? row["PatientAllergies"].ToString() : "Không",
                    DoctorName = row["DoctorName"].ToString(),
                    Diagnosis = row["Diagnosis"] != DBNull.Value ? row["Diagnosis"].ToString() : "Khám sức khỏe tổng quát",
                    DoctorNotes = row["DoctorNotes"] != DBNull.Value ? row["DoctorNotes"].ToString() : ""
                };

                dto.Items = GetPrescriptionItems(dto.PrescriptionID);
                list.Add(dto);
            }
            return list;
        }

        public List<PrescriptionItemDTO> GetPrescriptionItems(int prescriptionId)
        {
            List<PrescriptionItemDTO> list = new List<PrescriptionItemDTO>();
            string query = @"
                SELECT pd.DetailID,
                       pd.PrescriptionID,
                       pd.MedicineID,
                       pd.Quantity,
                       pd.Dosage,
                       m.Name AS MedicineName,
                       m.Unit AS MedicineUnit,
                       m.BatchNumber AS BatchNumber,
                       m.Price AS Price
                FROM PrescriptionDetails pd
                JOIN Medicines m ON pd.MedicineID = m.MedicineID
                WHERE pd.PrescriptionID = @PrescriptionID";

            SqlParameter[] parameters = {
                new SqlParameter("@PrescriptionID", prescriptionId)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new PrescriptionItemDTO
                {
                    DetailID = Convert.ToInt32(row["DetailID"]),
                    PrescriptionID = Convert.ToInt32(row["PrescriptionID"]),
                    MedicineID = Convert.ToInt32(row["MedicineID"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Dosage = row["Dosage"].ToString(),
                    MedicineName = row["MedicineName"].ToString(),
                    MedicineUnit = row["MedicineUnit"].ToString(),
                    BatchNumber = row["BatchNumber"] != DBNull.Value ? row["BatchNumber"].ToString() : "",
                    Price = Convert.ToDecimal(row["Price"])
                });
            }
            return list;
        }

        public bool UpdatePrescriptionStatus(int prescriptionId, string status)
        {
            string query = @"
                UPDATE Prescriptions
                SET Status = @Status
                WHERE PrescriptionID = @PrescriptionID";

            SqlParameter[] parameters = {
                new SqlParameter("@Status", status),
                new SqlParameter("@PrescriptionID", prescriptionId)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        private void SeedSamplePrescriptionsIfEmpty()
        {
            try
            {
                object countObj = DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Prescriptions");
                int count = Convert.ToInt32(countObj);
                if (count > 0) return;

                object patientIdObj = DatabaseHelper.ExecuteScalar("SELECT TOP 1 PatientID FROM Patients ORDER BY PatientID");
                object doctorIdObj = DatabaseHelper.ExecuteScalar(
                    "SELECT TOP 1 EmployeeID FROM Employees WHERE RoleID = (SELECT RoleID FROM Roles WHERE RoleName = 'Doctor') ORDER BY EmployeeID");
                object medicineIdObj = DatabaseHelper.ExecuteScalar("SELECT TOP 1 MedicineID FROM Medicines ORDER BY MedicineID");

                if (patientIdObj == null || doctorIdObj == null || medicineIdObj == null)
                {
                    return; 
                }

                int patientId = Convert.ToInt32(patientIdObj);
                int doctorId = Convert.ToInt32(doctorIdObj);
                int medicineId = Convert.ToInt32(medicineIdObj);

                int encounterId1 = InsertEncounter(patientId, doctorId, "Chờ cấp thuốc");
                int encounterId2 = InsertEncounter(patientId, doctorId, "Chờ cấp thuốc");

                DatabaseHelper.ExecuteNonQuery(@"
                    INSERT INTO MedicalRecords (EncounterID, Diagnosis, Notes)
                    VALUES 
                    (@E1, N'Viêm họng cấp', N'Uống nước ấm, nghỉ ngơi đầy đủ'),
                    (@E2, N'Suy nhược cơ thể', N'Hạn chế thức khuya, uống nhiều nước')",
                    new[] {
                        new SqlParameter("@E1", encounterId1),
                        new SqlParameter("@E2", encounterId2)
                    });

                int prescId1 = InsertPrescription(encounterId1, doctorId, "Chờ cấp phát");
                int prescId2 = InsertPrescription(encounterId2, doctorId, "Đang chuẩn bị");

                object secondMedObj = DatabaseHelper.ExecuteScalar("SELECT TOP 1 MedicineID FROM Medicines WHERE MedicineID != @MID ORDER BY MedicineID", new[] { new SqlParameter("@MID", medicineId) });
                int secondMedId = secondMedObj != null ? Convert.ToInt32(secondMedObj) : medicineId;

                DatabaseHelper.ExecuteNonQuery(@"
                    INSERT INTO PrescriptionDetails (PrescriptionID, MedicineID, Quantity, Dosage)
                    VALUES 
                    (@P1, @M1, 10, N'Ngày uống 2 lần, mỗi lần 1 viên sau ăn'),
                    (@P1, @M2, 15, N'Ngày uống 1 lần, mỗi lần 1 viên sáng'),
                    (@P2, @M1, 20, N'Ngày uống 2 lần, mỗi lần 1 viên sau ăn')",
                    new[] {
                        new SqlParameter("@P1", prescId1),
                        new SqlParameter("@P2", prescId2),
                        new SqlParameter("@M1", medicineId),
                        new SqlParameter("@M2", secondMedId)
                    });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error seeding prescriptions: " + ex.Message);
            }
        }

        private int InsertEncounter(int patientId, int doctorId, string status)
        {
            object idObj = DatabaseHelper.ExecuteScalar(@"
                INSERT INTO Encounters (PatientID, DoctorID, StartTime, Status)
                OUTPUT INSERTED.EncounterID
                VALUES (@PID, @DID, GETDATE(), @Status)",
                new[] {
                    new SqlParameter("@PID", patientId),
                    new SqlParameter("@DID", doctorId),
                    new SqlParameter("@Status", status)
                });
            return Convert.ToInt32(idObj);
        }

        private int InsertPrescription(int encounterId, int doctorId, string status)
        {
            object idObj = DatabaseHelper.ExecuteScalar(@"
                INSERT INTO Prescriptions (EncounterID, DoctorID, Status, CreatedAt)
                OUTPUT INSERTED.PrescriptionID
                VALUES (@EID, @DID, @Status, GETDATE())",
                new[] {
                    new SqlParameter("@EID", encounterId),
                    new SqlParameter("@DID", doctorId),
                    new SqlParameter("@Status", status)
                });
            return Convert.ToInt32(idObj);
        }
    }
}