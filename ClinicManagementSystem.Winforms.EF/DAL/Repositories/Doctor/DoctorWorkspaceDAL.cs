using System;
using System.Collections.Generic;
using System.Data;
using DAL.DataContext;
using DTO;
using DTO.Doctor;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories.Doctor
{
    public class DoctorWorkspaceDAL
    {
        public int ResolveDoctorId(UserDTO user)
        {
            if (user?.EmployeeID > 0)
            {
                return user.EmployeeID;
            }

            if (user?.UserID > 0)
            {
                object byUser = DatabaseHelper.ExecuteScalar(
                    "SELECT TOP 1 EmployeeID FROM Employees WHERE UserID = @UserID",
                    new[] { new SqlParameter("@UserID", user.UserID) });
                if (byUser != null && byUser != DBNull.Value)
                {
                    return Convert.ToInt32(byUser);
                }
            }

            object fallback = DatabaseHelper.ExecuteScalar(@"
                SELECT TOP 1 e.EmployeeID
                FROM Employees e
                INNER JOIN Roles r ON e.RoleID = r.RoleID
                WHERE r.RoleName = 'Doctor'
                ORDER BY e.EmployeeID");

            return fallback == null || fallback == DBNull.Value ? 0 : Convert.ToInt32(fallback);
        }

        public DoctorDashboardDTO GetDashboard(int doctorId, DateTime date)
        {
            EnsureDemoData(doctorId, date);

            SqlParameter[] parameters =
            {
                new("@DoctorID", doctorId),
                new("@Date", date.Date)
            };

            string query = @"
                SELECT
                    (SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND CAST(AppointmentDate AS date) = @Date) AS TodayAppointments,
                    (SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND CAST(AppointmentDate AS date) = @Date AND Status IN ('Waiting', N'Chờ tiếp nhận', N'Chờ khám')) AS WaitingCount,
                    (SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND CAST(AppointmentDate AS date) = @Date AND Status IN ('Examining', N'Đang khám', 'InProgress')) AS ExaminingCount,
                    (SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND CAST(AppointmentDate AS date) = @Date AND Status IN ('Completed', N'Hoàn thành')) AS CompletedCount,
                    (SELECT COUNT(*) FROM LabRequests WHERE DoctorID = @DoctorID AND Status NOT IN ('Completed', N'Hoàn thành')) AS PendingLabRequests,
                    (SELECT COUNT(*) FROM ImagingRequests WHERE DoctorID = @DoctorID AND Status NOT IN ('Completed', N'Hoàn thành')) AS PendingImagingRequests,
                    (SELECT COUNT(*) FROM Prescriptions WHERE DoctorID = @DoctorID AND Status NOT IN ('Completed', N'Đã cấp phát')) AS PendingPrescriptions,
                    (SELECT COUNT(*) FROM WorkAssignments WHERE EmployeeID = @DoctorID AND CAST(WorkDate AS date) = @Date AND Status IN ('Open', 'InProgress', N'Đang làm')) AS OpenAssignments";

            DataTable table = DatabaseHelper.ExecuteQuery(query, parameters);
            if (table.Rows.Count == 0)
            {
                return new DoctorDashboardDTO();
            }

            DataRow row = table.Rows[0];
            return new DoctorDashboardDTO
            {
                TodayAppointments = ToInt(row["TodayAppointments"]),
                WaitingCount = ToInt(row["WaitingCount"]),
                ExaminingCount = ToInt(row["ExaminingCount"]),
                CompletedCount = ToInt(row["CompletedCount"]),
                PendingLabRequests = ToInt(row["PendingLabRequests"]),
                PendingImagingRequests = ToInt(row["PendingImagingRequests"]),
                PendingPrescriptions = ToInt(row["PendingPrescriptions"]),
                OpenAssignments = ToInt(row["OpenAssignments"])
            };
        }

        public List<DoctorAppointmentDTO> GetAppointments(int doctorId, DateTime date)
        {
            EnsureDemoData(doctorId, date);

            string query = @"
                SELECT
                    a.AppointmentID,
                    ISNULL(en.EncounterID, 0) AS EncounterID,
                    a.PatientID,
                    a.DoctorID,
                    ISNULL(p.PatientCode, '') AS PatientCode,
                    ISNULL(p.FullName, '') AS PatientName,
                    ISNULL(p.Gender, '') AS Gender,
                    p.DOB,
                    ISNULL(p.Allergy, '') AS Allergy,
                    ISNULL(d.DepartmentName, '') AS DepartmentName,
                    ISNULL(r.RoomCode, '') AS RoomCode,
                    a.AppointmentDate,
                    ISNULL(a.Status, '') AS Status,
                    ISNULL(q.Status, '') AS QueueStatus,
                    ISNULL(q.CurrentStep, '') AS CurrentStep,
                    ISNULL(v.Temperature, 0) AS Temperature,
                    ISNULL(v.BloodPressure, '') AS BloodPressure,
                    ISNULL(v.HeartRate, 0) AS HeartRate,
                    ISNULL(v.SPO2, 0) AS SPO2,
                    ISNULL(v.Weight, 0) AS Weight,
                    ISNULL(v.Height, 0) AS Height
                FROM Appointments a
                INNER JOIN Patients p ON a.PatientID = p.PatientID
                LEFT JOIN Departments d ON a.DepartmentID = d.DepartmentID
                LEFT JOIN Rooms r ON a.RoomID = r.RoomID
                LEFT JOIN Encounters en ON a.AppointmentID = en.AppointmentID
                OUTER APPLY (
                    SELECT TOP 1 *
                    FROM PatientQueues pq
                    WHERE pq.EncounterID = en.EncounterID
                    ORDER BY pq.QueueID DESC
                ) q
                OUTER APPLY (
                    SELECT TOP 1 *
                    FROM VitalSigns vs
                    WHERE vs.EncounterID = en.EncounterID
                    ORDER BY vs.CreatedAt DESC, vs.VitalID DESC
                ) v
                WHERE a.DoctorID = @DoctorID
                  AND CAST(a.AppointmentDate AS date) = @Date
                ORDER BY a.AppointmentDate, a.AppointmentID";

            return MapAppointments(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@Date", date.Date)
            }));
        }

        public void EnsureDemoData(int doctorId, DateTime date)
        {
            if (doctorId <= 0)
            {
                return;
            }

            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                int existing = ToInt(ExecuteScalar(conn, tx,
                    "SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID AND CAST(AppointmentDate AS date) = @Date",
                    new SqlParameter("@DoctorID", doctorId),
                    new SqlParameter("@Date", date.Date)));

                int target = 14;
                if (existing >= target)
                {
                    tx.Commit();
                    return;
                }

                int departmentId = ToInt(ExecuteScalar(conn, tx,
                    "SELECT DepartmentID FROM Employees WHERE EmployeeID = @DoctorID",
                    new SqlParameter("@DoctorID", doctorId)));
                if (departmentId <= 0)
                {
                    departmentId = ToInt(ExecuteScalar(conn, tx, "SELECT TOP 1 DepartmentID FROM Departments ORDER BY DepartmentID"));
                }

                int roomId = ToInt(ExecuteScalar(conn, tx,
                    "SELECT TOP 1 RoomID FROM Rooms WHERE DepartmentID = @DepartmentID ORDER BY RoomID",
                    new SqlParameter("@DepartmentID", departmentId)));
                if (roomId <= 0)
                {
                    roomId = ToInt(ExecuteScalar(conn, tx, "SELECT TOP 1 RoomID FROM Rooms ORDER BY RoomID"));
                }

                List<int> medicineIds = GetDemoMedicineIds(conn, tx);
                string[] names =
                {
                    "Nguyen Van An", "Tran Thi Bich", "Le Minh Chau", "Pham Van Hung",
                    "Do Thi Kim", "Bui Quoc Huy", "Hoang Thanh Lam", "Vo Minh Quan",
                    "Dang Ngoc Mai", "Phan Gia Bao", "Truong Hai Nam", "Ly Thanh Truc",
                    "Mai Tuan Kiet", "Cao Minh Thu"
                };

                for (int i = existing; i < target; i++)
                {
                    string code = "GP1DEMO" + date.ToString("MMdd") + (i + 1).ToString("D2");
                    int patientId = EnsurePatient(conn, tx, code, names[i % names.Length], i);
                    DateTime appointmentTime = date.Date.AddHours(8).AddMinutes(i * 20);
                    string status = i < 7 ? "Waiting" : i < 10 ? "Examining" : "Completed";

                    int appointmentId = ToInt(ExecuteScalar(conn, tx, @"
                        INSERT INTO Appointments(PatientID, DoctorID, DepartmentID, RoomID, AppointmentDate, Status)
                        OUTPUT INSERTED.AppointmentID
                        VALUES(@PatientID, @DoctorID, @DepartmentID, @RoomID, @AppointmentDate, @Status)",
                        new SqlParameter("@PatientID", patientId),
                        new SqlParameter("@DoctorID", doctorId),
                        new SqlParameter("@DepartmentID", departmentId),
                        new SqlParameter("@RoomID", roomId),
                        new SqlParameter("@AppointmentDate", appointmentTime),
                        new SqlParameter("@Status", status)));

                    int encounterId = ToInt(ExecuteScalar(conn, tx, @"
                        INSERT INTO Encounters(AppointmentID, PatientID, DoctorID, StartTime, EndTime, Status)
                        OUTPUT INSERTED.EncounterID
                        VALUES(@AppointmentID, @PatientID, @DoctorID, @StartTime, @EndTime, @Status)",
                        new SqlParameter("@AppointmentID", appointmentId),
                        new SqlParameter("@PatientID", patientId),
                        new SqlParameter("@DoctorID", doctorId),
                        new SqlParameter("@StartTime", status == "Waiting" ? DBNull.Value : appointmentTime),
                        new SqlParameter("@EndTime", status == "Completed" ? appointmentTime.AddMinutes(25) : DBNull.Value),
                        new SqlParameter("@Status", status)));

                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO PatientQueues(EncounterID, Priority, Status, CurrentStep)
                        VALUES(@EncounterID, @Priority, @Status, @Step)",
                        new SqlParameter("@EncounterID", encounterId),
                        new SqlParameter("@Priority", i % 5 == 0 ? "High" : "Normal"),
                        new SqlParameter("@Status", status == "Waiting" ? "Waiting" : status == "Examining" ? "InProgress" : "Completed"),
                        new SqlParameter("@Step", status == "Waiting" ? "Cho kham" : status == "Examining" ? "Dang kham" : "Hoan thanh"));

                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO VitalSigns(EncounterID, Temperature, BloodPressure, HeartRate, SPO2, Weight, Height, Notes)
                        VALUES(@EncounterID, @Temperature, @BloodPressure, @HeartRate, @SPO2, @Weight, @Height, @Notes)",
                        new SqlParameter("@EncounterID", encounterId),
                        new SqlParameter("@Temperature", 36.4m + (i % 4) * 0.2m),
                        new SqlParameter("@BloodPressure", (118 + i % 8) + "/80"),
                        new SqlParameter("@HeartRate", 68 + i),
                        new SqlParameter("@SPO2", 96 + i % 4),
                        new SqlParameter("@Weight", 52 + i),
                        new SqlParameter("@Height", 158 + i % 12),
                        new SqlParameter("@Notes", "Sinh hieu demo GP1"));

                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO MedicalRecords(EncounterID, ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes, CreatedAt)
                        VALUES(@EncounterID, @ChiefComplaint, @Symptoms, @Diagnosis, @ICDCode, @Conclusion, @Notes, GETDATE())",
                        new SqlParameter("@EncounterID", encounterId),
                        new SqlParameter("@ChiefComplaint", "Dau dau, ho, met moi"),
                        new SqlParameter("@Symptoms", "Ho nhe, sot nhe, dau hong"),
                        new SqlParameter("@Diagnosis", i % 3 == 0 ? "Viem hong cap" : i % 3 == 1 ? "Cam cum mua" : "Roi loan tieu hoa nhe"),
                        new SqlParameter("@ICDCode", "J06.9"),
                        new SqlParameter("@Conclusion", "Dieu tri ngoai tru"),
                        new SqlParameter("@Notes", "Khong bien chung"));

                    if (i % 2 == 0)
                    {
                        CreateSeedLab(conn, tx, encounterId, doctorId, i);
                    }

                    if (i % 3 == 0)
                    {
                        CreateSeedImaging(conn, tx, encounterId, doctorId, i);
                    }

                    if (medicineIds.Count > 0 && i >= 4)
                    {
                        CreateSeedPrescription(conn, tx, encounterId, doctorId, medicineIds, i);
                    }

                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO WorkAssignments(EmployeeID, RoleID, DepartmentID, RoomID, EncounterID, WorkDate, ShiftID, AssignmentType, Title, Priority, Status, Notes)
                        SELECT @DoctorID, RoleID, @DepartmentID, @RoomID, @EncounterID, @Date, NULL,
                               N'Examination', N'Kham va cap nhat benh an', @Priority, @Status, N'Demo GP1'
                        FROM Employees WHERE EmployeeID = @DoctorID",
                        new SqlParameter("@DoctorID", doctorId),
                        new SqlParameter("@DepartmentID", departmentId),
                        new SqlParameter("@RoomID", roomId),
                        new SqlParameter("@EncounterID", encounterId),
                        new SqlParameter("@Date", date.Date),
                        new SqlParameter("@Priority", i % 5 == 0 ? "High" : "Normal"),
                        new SqlParameter("@Status", status == "Completed" ? "Completed" : status == "Examining" ? "InProgress" : "Open"));
                }

                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public DoctorAppointmentDTO GetAppointmentByAppointmentId(int doctorId, int appointmentId)
        {
            string query = @"
                SELECT TOP 1 *
                FROM (
                    SELECT
                        a.AppointmentID,
                        ISNULL(en.EncounterID, 0) AS EncounterID,
                        a.PatientID,
                        a.DoctorID,
                        ISNULL(p.PatientCode, '') AS PatientCode,
                        ISNULL(p.FullName, '') AS PatientName,
                        ISNULL(p.Gender, '') AS Gender,
                        p.DOB,
                        ISNULL(p.Allergy, '') AS Allergy,
                        ISNULL(d.DepartmentName, '') AS DepartmentName,
                        ISNULL(r.RoomCode, '') AS RoomCode,
                        a.AppointmentDate,
                        ISNULL(a.Status, '') AS Status,
                        ISNULL(q.Status, '') AS QueueStatus,
                        ISNULL(q.CurrentStep, '') AS CurrentStep,
                        ISNULL(v.Temperature, 0) AS Temperature,
                        ISNULL(v.BloodPressure, '') AS BloodPressure,
                        ISNULL(v.HeartRate, 0) AS HeartRate,
                        ISNULL(v.SPO2, 0) AS SPO2,
                        ISNULL(v.Weight, 0) AS Weight,
                        ISNULL(v.Height, 0) AS Height
                    FROM Appointments a
                    INNER JOIN Patients p ON a.PatientID = p.PatientID
                    LEFT JOIN Departments d ON a.DepartmentID = d.DepartmentID
                    LEFT JOIN Rooms r ON a.RoomID = r.RoomID
                    LEFT JOIN Encounters en ON a.AppointmentID = en.AppointmentID
                    OUTER APPLY (SELECT TOP 1 * FROM PatientQueues pq WHERE pq.EncounterID = en.EncounterID ORDER BY pq.QueueID DESC) q
                    OUTER APPLY (SELECT TOP 1 * FROM VitalSigns vs WHERE vs.EncounterID = en.EncounterID ORDER BY vs.CreatedAt DESC, vs.VitalID DESC) v
                    WHERE a.AppointmentID = @AppointmentID
                      AND (@DoctorID = 0 OR a.DoctorID = @DoctorID)
                ) x";

            List<DoctorAppointmentDTO> list = MapAppointments(DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@AppointmentID", appointmentId)
            }));
            return list.Count == 0 ? null : list[0];
        }

        public DoctorAppointmentDTO GetAppointmentByEncounterId(int doctorId, int encounterId)
        {
            string query = @"
                SELECT TOP 1 a.AppointmentID
                FROM Encounters en
                INNER JOIN Appointments a ON en.AppointmentID = a.AppointmentID
                WHERE en.EncounterID = @EncounterID
                  AND (@DoctorID = 0 OR en.DoctorID = @DoctorID)";

            object appointmentId = DatabaseHelper.ExecuteScalar(query, new[]
            {
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@EncounterID", encounterId)
            });

            return appointmentId == null || appointmentId == DBNull.Value
                ? null
                : GetAppointmentByAppointmentId(doctorId, Convert.ToInt32(appointmentId));
        }

        public DoctorMedicalRecordSaveDTO GetMedicalRecord(int encounterId)
        {
            string query = @"
                SELECT TOP 1 ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes
                FROM MedicalRecords
                WHERE EncounterID = @EncounterID
                ORDER BY CreatedAt DESC, RecordID DESC";

            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EncounterID", encounterId)
            });

            if (table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            return new DoctorMedicalRecordSaveDTO
            {
                EncounterID = encounterId,
                ChiefComplaint = Text(row["ChiefComplaint"]),
                Symptoms = Text(row["Symptoms"]),
                Diagnosis = Text(row["Diagnosis"]),
                ICDCode = Text(row["ICDCode"]),
                Conclusion = Text(row["Conclusion"]),
                Notes = Text(row["Notes"])
            };
        }

        public List<DoctorHistoryDTO> GetHistory(int patientId, int currentEncounterId)
        {
            string query = @"
                SELECT TOP 20
                    en.EncounterID,
                    ISNULL(en.StartTime, mr.CreatedAt) AS Date,
                    ISNULL(mr.Diagnosis, '') AS Diagnosis,
                    ISNULL(emp.FullName, '') AS DoctorName,
                    ISNULL(en.Status, '') AS Status,
                    ISNULL((
                        SELECT STRING_AGG(m.Name, ', ')
                        FROM Prescriptions p
                        INNER JOIN PrescriptionDetails pd ON p.PrescriptionID = pd.PrescriptionID
                        INNER JOIN Medicines m ON pd.MedicineID = m.MedicineID
                        WHERE p.EncounterID = en.EncounterID
                    ), '') AS PrescriptionSummary
                FROM Encounters en
                LEFT JOIN MedicalRecords mr ON en.EncounterID = mr.EncounterID
                LEFT JOIN Employees emp ON en.DoctorID = emp.EmployeeID
                WHERE en.PatientID = @PatientID
                  AND en.EncounterID <> @EncounterID
                ORDER BY ISNULL(en.StartTime, mr.CreatedAt) DESC";

            List<DoctorHistoryDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@PatientID", patientId),
                new SqlParameter("@EncounterID", currentEncounterId)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new DoctorHistoryDTO
                {
                    EncounterID = ToInt(row["EncounterID"]),
                    Date = row["Date"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["Date"]),
                    Diagnosis = Text(row["Diagnosis"]),
                    DoctorName = Text(row["DoctorName"]),
                    Status = Text(row["Status"]),
                    PrescriptionSummary = Text(row["PrescriptionSummary"])
                });
            }

            return list;
        }

        public List<DoctorLabResultDTO> GetLabResults(int encounterId)
        {
            string query = @"
                SELECT lr.LabID, lr.TestType, lr.Status, lres.ResultText, lres.FileURL, lres.CompletedAt
                FROM LabRequests lr
                LEFT JOIN LabResults lres ON lr.LabID = lres.LabID
                WHERE lr.EncounterID = @EncounterID
                ORDER BY lr.CreatedAt DESC, lr.LabID DESC";

            List<DoctorLabResultDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EncounterID", encounterId)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new DoctorLabResultDTO
                {
                    LabID = ToInt(row["LabID"]),
                    TestType = Text(row["TestType"]),
                    Status = Text(row["Status"]),
                    ResultText = Text(row["ResultText"]),
                    FileURL = Text(row["FileURL"]),
                    CompletedAt = row["CompletedAt"] == DBNull.Value ? null : Convert.ToDateTime(row["CompletedAt"])
                });
            }

            return list;
        }

        public List<DoctorImagingResultDTO> GetImagingResults(int encounterId)
        {
            string query = @"
                SELECT ir.ImagingRequestID,
                       COALESCE(s.ServiceName, s.Modality, N'Imaging') AS ServiceName,
                       ir.BodyPart,
                       ir.Status,
                       ires.ResultText,
                       ires.ImageURL,
                       ires.PDFURL,
                       ires.TechnicianNote,
                       ires.CompletedAt
                FROM ImagingRequests ir
                LEFT JOIN ImagingServices s ON ir.ImagingServiceID = s.ImagingServiceID
                LEFT JOIN ImagingResults ires ON ir.ImagingRequestID = ires.ImagingRequestID
                WHERE ir.EncounterID = @EncounterID
                ORDER BY ir.CreatedAt DESC, ir.ImagingRequestID DESC";

            List<DoctorImagingResultDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@EncounterID", encounterId)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new DoctorImagingResultDTO
                {
                    ImagingRequestID = ToInt(row["ImagingRequestID"]),
                    ServiceName = Text(row["ServiceName"]),
                    BodyPart = Text(row["BodyPart"]),
                    Status = Text(row["Status"]),
                    ResultText = Text(row["ResultText"]),
                    ImageURL = Text(row["ImageURL"]),
                    PDFURL = Text(row["PDFURL"]),
                    TechnicianNote = Text(row["TechnicianNote"]),
                    CompletedAt = row["CompletedAt"] == DBNull.Value ? null : Convert.ToDateTime(row["CompletedAt"])
                });
            }

            return list;
        }

        public List<MedicineDTO> GetMedicines()
        {
            string query = @"
                SELECT MedicineID, Name, Unit, Price, Stock, BatchNumber, ExpiryDate
                FROM Medicines
                WHERE ISNULL(Stock, 0) > 0
                ORDER BY Name";

            List<MedicineDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in table.Rows)
            {
                list.Add(new MedicineDTO
                {
                    MedicineID = ToInt(row["MedicineID"]),
                    Name = Text(row["Name"]),
                    Unit = Text(row["Unit"]),
                    Price = row["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Price"]),
                    Stock = ToInt(row["Stock"]),
                    BatchNumber = Text(row["BatchNumber"]),
                    ExpiryDate = row["ExpiryDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["ExpiryDate"])
                });
            }

            return list;
        }

        public List<PrescriptionDTO> GetDoctorPrescriptions(int doctorId)
        {
            string query = @"
                SELECT p.PrescriptionID,
                       p.EncounterID,
                       p.DoctorID,
                       p.Status,
                       p.CreatedAt,
                       ISNULL(pat.FullName, '') AS PatientName,
                       ISNULL(pat.Gender, '') AS PatientGender,
                       pat.DOB AS PatientDOB,
                       ISNULL(pat.PatientCode, '') AS PatientCode,
                       ISNULL(pat.Allergy, '') AS PatientAllergies,
                       ISNULL(doc.FullName, '') AS DoctorName,
                       ISNULL(mr.Diagnosis, '') AS Diagnosis,
                       ISNULL(mr.Notes, '') AS DoctorNotes
                FROM Prescriptions p
                INNER JOIN Encounters enc ON p.EncounterID = enc.EncounterID
                INNER JOIN Patients pat ON enc.PatientID = pat.PatientID
                LEFT JOIN Employees doc ON p.DoctorID = doc.EmployeeID
                LEFT JOIN MedicalRecords mr ON enc.EncounterID = mr.EncounterID
                WHERE (@DoctorID = 0 OR p.DoctorID = @DoctorID)
                ORDER BY p.CreatedAt DESC, p.PrescriptionID DESC";

            List<PrescriptionDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@DoctorID", doctorId)
            });

            foreach (DataRow row in table.Rows)
            {
                int prescriptionId = ToInt(row["PrescriptionID"]);
                list.Add(new PrescriptionDTO
                {
                    PrescriptionID = prescriptionId,
                    EncounterID = ToInt(row["EncounterID"]),
                    DoctorID = ToInt(row["DoctorID"]),
                    Status = Text(row["Status"]),
                    CreatedAt = row["CreatedAt"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["CreatedAt"]),
                    PatientName = Text(row["PatientName"]),
                    PatientGender = Text(row["PatientGender"]),
                    PatientDOB = row["PatientDOB"] == DBNull.Value ? null : Convert.ToDateTime(row["PatientDOB"]),
                    PatientCode = Text(row["PatientCode"]),
                    PatientAllergies = Text(row["PatientAllergies"]),
                    DoctorName = Text(row["DoctorName"]),
                    Diagnosis = Text(row["Diagnosis"]),
                    DoctorNotes = Text(row["DoctorNotes"]),
                    Items = GetPrescriptionItems(prescriptionId)
                });
            }

            return list;
        }

        public bool StartExamination(int appointmentId, int encounterId, int doctorId)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                if (encounterId <= 0)
                {
                    encounterId = ToInt(ExecuteScalar(conn, tx, @"
                        INSERT INTO Encounters (AppointmentID, PatientID, DoctorID, StartTime, Status)
                        OUTPUT INSERTED.EncounterID
                        SELECT AppointmentID, PatientID, DoctorID, GETDATE(), 'Examining'
                        FROM Appointments
                        WHERE AppointmentID = @AppointmentID",
                        new SqlParameter("@AppointmentID", appointmentId)));
                }
                else
                {
                    ExecuteNonQuery(conn, tx, @"
                        UPDATE Encounters
                        SET StartTime = COALESCE(StartTime, GETDATE()),
                            Status = 'Examining'
                        WHERE EncounterID = @EncounterID",
                        new SqlParameter("@EncounterID", encounterId));
                }

                ExecuteNonQuery(conn, tx, "UPDATE Appointments SET Status = 'Examining' WHERE AppointmentID = @AppointmentID",
                    new SqlParameter("@AppointmentID", appointmentId));

                ExecuteNonQuery(conn, tx, @"
                    IF EXISTS (SELECT 1 FROM PatientQueues WHERE EncounterID = @EncounterID)
                        UPDATE PatientQueues SET Status = 'InProgress', CurrentStep = N'Dang kham' WHERE EncounterID = @EncounterID
                    ELSE
                        INSERT INTO PatientQueues (EncounterID, Priority, Status, CurrentStep) VALUES (@EncounterID, 'Normal', 'InProgress', N'Dang kham')",
                    new SqlParameter("@EncounterID", encounterId));

                ExecuteNonQuery(conn, tx, @"
                    UPDATE WorkAssignments
                    SET Status = 'InProgress'
                    WHERE EncounterID = @EncounterID
                      AND EmployeeID = @DoctorID
                      AND AssignmentType = N'Examination'
                      AND Status IN ('Open', 'InProgress')",
                    new SqlParameter("@EncounterID", encounterId),
                    new SqlParameter("@DoctorID", doctorId));

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public bool SaveMedicalRecord(DoctorMedicalRecordSaveDTO record)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM MedicalRecords WHERE EncounterID = @EncounterID)
                    UPDATE MedicalRecords
                    SET ChiefComplaint = @ChiefComplaint,
                        Symptoms = @Symptoms,
                        Diagnosis = @Diagnosis,
                        ICDCode = @ICDCode,
                        Conclusion = @Conclusion,
                        Notes = @Notes
                    WHERE EncounterID = @EncounterID
                ELSE
                    INSERT INTO MedicalRecords (EncounterID, ChiefComplaint, Symptoms, Diagnosis, ICDCode, Conclusion, Notes, CreatedAt)
                    VALUES (@EncounterID, @ChiefComplaint, @Symptoms, @Diagnosis, @ICDCode, @Conclusion, @Notes, GETDATE())";

            return DatabaseHelper.ExecuteNonQuery(query, new[]
            {
                new SqlParameter("@EncounterID", record.EncounterID),
                new SqlParameter("@ChiefComplaint", Db(record.ChiefComplaint)),
                new SqlParameter("@Symptoms", Db(record.Symptoms)),
                new SqlParameter("@Diagnosis", Db(record.Diagnosis)),
                new SqlParameter("@ICDCode", Db(record.ICDCode)),
                new SqlParameter("@Conclusion", Db(record.Conclusion)),
                new SqlParameter("@Notes", Db(record.Notes))
            }) > 0;
        }

        public bool CreateLabRequest(DoctorRequestSaveDTO request)
        {
            object labId = DatabaseHelper.ExecuteScalar(@"
                INSERT INTO LabRequests (EncounterID, DoctorID, TestType, Status, CreatedAt)
                OUTPUT INSERTED.LabID
                VALUES (@EncounterID, @DoctorID, @TestType, 'Pending', GETDATE())",
                new[]
                {
                    new SqlParameter("@EncounterID", request.EncounterID),
                    new SqlParameter("@DoctorID", request.DoctorID),
                    new SqlParameter("@TestType", Db(request.ServiceName))
                });

            int id = ToInt(labId);
            if (id <= 0)
            {
                return false;
            }

            CreateTechnicianAssignment(request.EncounterID, "Lab", "Xu ly xet nghiem", "LabID: " + id + " - " + request.ServiceName, request.Priority, "Technician");
            return true;
        }

        public bool CreateImagingRequest(DoctorRequestSaveDTO request)
        {
            int serviceId = GetOrCreateImagingServiceId(request.ServiceName);
            object requestId = DatabaseHelper.ExecuteScalar(@"
                INSERT INTO ImagingRequests (EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status)
                OUTPUT INSERTED.ImagingRequestID
                VALUES (@EncounterID, @DoctorID, @ImagingServiceID, @BodyPart, GETDATE(), @Priority, 'Pending')",
                new[]
                {
                    new SqlParameter("@EncounterID", request.EncounterID),
                    new SqlParameter("@DoctorID", request.DoctorID),
                    new SqlParameter("@ImagingServiceID", serviceId),
                    new SqlParameter("@BodyPart", Db(request.Note)),
                    new SqlParameter("@Priority", Db(string.IsNullOrWhiteSpace(request.Priority) ? "Normal" : request.Priority))
                });

            int id = ToInt(requestId);
            if (id <= 0)
            {
                return false;
            }

            CreateTechnicianAssignment(request.EncounterID, "Imaging", "Xu ly chan doan hinh anh", "ImagingRequestID: " + id + " - " + request.ServiceName, request.Priority, "Technician");
            return true;
        }

        public int CreatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                int prescriptionId = ToInt(ExecuteScalar(conn, tx, @"
                    INSERT INTO Prescriptions (EncounterID, DoctorID, Status, CreatedAt)
                    OUTPUT INSERTED.PrescriptionID
                    VALUES (@EncounterID, @DoctorID, 'Issued', GETDATE())",
                    new SqlParameter("@EncounterID", prescription.EncounterID),
                    new SqlParameter("@DoctorID", prescription.DoctorID)));

                foreach (DoctorPrescriptionItemSaveDTO item in prescription.Items)
                {
                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO PrescriptionDetails (PrescriptionID, MedicineID, Quantity, Dosage, Frequency, Instruction)
                        VALUES (@PrescriptionID, @MedicineID, @Quantity, @Dosage, @Frequency, @Instruction)",
                        new SqlParameter("@PrescriptionID", prescriptionId),
                        new SqlParameter("@MedicineID", item.MedicineID),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@Dosage", Db(item.Dosage)),
                        new SqlParameter("@Frequency", Db(item.Frequency)),
                        new SqlParameter("@Instruction", Db(item.Instruction)));
                }

                ExecuteNonQuery(conn, tx, @"
                    INSERT INTO WorkAssignments(EmployeeID, RoleID, DepartmentID, RoomID, EncounterID, WorkDate, ShiftID, AssignmentType, Title, Priority, Status, Notes)
                    SELECT TOP 1 e.EmployeeID, e.RoleID, e.DepartmentID, NULL, @EncounterID, CAST(GETDATE() AS date), NULL,
                           N'Pharmacy', N'Cap phat don thuoc', 'Normal', 'Open', @Notes
                    FROM Employees e
                    INNER JOIN Roles r ON e.RoleID = r.RoleID
                    WHERE r.RoleName = 'Pharmacist'
                    ORDER BY e.EmployeeID",
                    new SqlParameter("@EncounterID", prescription.EncounterID),
                    new SqlParameter("@Notes", "PrescriptionID: " + prescriptionId));

                tx.Commit();
                return prescriptionId;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public bool UpdatePrescription(DoctorPrescriptionSaveDTO prescription)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                ExecuteNonQuery(conn, tx,
                    "UPDATE Prescriptions SET Status = @Status WHERE PrescriptionID = @PrescriptionID",
                    new SqlParameter("@Status", string.IsNullOrWhiteSpace(prescription.Note) ? "Issued" : prescription.Note.Trim()),
                    new SqlParameter("@PrescriptionID", prescription.PrescriptionID));

                ExecuteNonQuery(conn, tx,
                    "DELETE FROM PrescriptionDetails WHERE PrescriptionID = @PrescriptionID",
                    new SqlParameter("@PrescriptionID", prescription.PrescriptionID));

                foreach (DoctorPrescriptionItemSaveDTO item in prescription.Items)
                {
                    ExecuteNonQuery(conn, tx, @"
                        INSERT INTO PrescriptionDetails (PrescriptionID, MedicineID, Quantity, Dosage, Frequency, Instruction)
                        VALUES (@PrescriptionID, @MedicineID, @Quantity, @Dosage, @Frequency, @Instruction)",
                        new SqlParameter("@PrescriptionID", prescription.PrescriptionID),
                        new SqlParameter("@MedicineID", item.MedicineID),
                        new SqlParameter("@Quantity", item.Quantity),
                        new SqlParameter("@Dosage", Db(item.Dosage)),
                        new SqlParameter("@Frequency", Db(item.Frequency)),
                        new SqlParameter("@Instruction", Db(item.Instruction)));
                }

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public bool DeletePrescription(int prescriptionId)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                ExecuteNonQuery(conn, tx, "DELETE FROM Dispense WHERE PrescriptionID = @PrescriptionID",
                    new SqlParameter("@PrescriptionID", prescriptionId));
                ExecuteNonQuery(conn, tx, "DELETE FROM PrescriptionDetails WHERE PrescriptionID = @PrescriptionID",
                    new SqlParameter("@PrescriptionID", prescriptionId));
                int rows = ExecuteNonQuery(conn, tx, "DELETE FROM Prescriptions WHERE PrescriptionID = @PrescriptionID",
                    new SqlParameter("@PrescriptionID", prescriptionId));

                tx.Commit();
                return rows > 0;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        public bool CompleteExamination(int appointmentId, int encounterId, int doctorId)
        {
            using SqlConnection conn = DatabaseHelper.GetConnection();
            conn.Open();
            using SqlTransaction tx = conn.BeginTransaction();

            try
            {
                ExecuteNonQuery(conn, tx, "UPDATE Appointments SET Status = 'Completed' WHERE AppointmentID = @AppointmentID",
                    new SqlParameter("@AppointmentID", appointmentId));

                ExecuteNonQuery(conn, tx, @"
                    UPDATE Encounters
                    SET EndTime = GETDATE(),
                        Status = 'Completed'
                    WHERE EncounterID = @EncounterID",
                    new SqlParameter("@EncounterID", encounterId));

                ExecuteNonQuery(conn, tx, "UPDATE PatientQueues SET Status = 'Completed', CurrentStep = N'Hoan thanh' WHERE EncounterID = @EncounterID",
                    new SqlParameter("@EncounterID", encounterId));

                ExecuteNonQuery(conn, tx, @"
                    UPDATE WorkAssignments
                    SET Status = 'Completed',
                        CompletedAt = GETDATE()
                    WHERE EncounterID = @EncounterID
                      AND EmployeeID = @DoctorID
                      AND AssignmentType = N'Examination'",
                    new SqlParameter("@EncounterID", encounterId),
                    new SqlParameter("@DoctorID", doctorId));

                tx.Commit();
                return true;
            }
            catch
            {
                tx.Rollback();
                throw;
            }
        }

        private void CreateTechnicianAssignment(int encounterId, string type, string title, string notes, string priority, string roleName)
        {
            DatabaseHelper.ExecuteNonQuery(@"
                INSERT INTO WorkAssignments(EmployeeID, RoleID, DepartmentID, RoomID, EncounterID, WorkDate, ShiftID, AssignmentType, Title, Priority, Status, Notes)
                SELECT TOP 1 e.EmployeeID, e.RoleID, e.DepartmentID, NULL, @EncounterID, CAST(GETDATE() AS date), NULL,
                       @AssignmentType, @Title, @Priority, 'Open', @Notes
                FROM Employees e
                INNER JOIN Roles r ON e.RoleID = r.RoleID
                WHERE r.RoleName = @RoleName
                ORDER BY e.EmployeeID",
                new[]
                {
                    new SqlParameter("@EncounterID", encounterId),
                    new SqlParameter("@AssignmentType", type),
                    new SqlParameter("@Title", title),
                    new SqlParameter("@Priority", string.IsNullOrWhiteSpace(priority) ? "Normal" : priority),
                    new SqlParameter("@Notes", notes ?? ""),
                    new SqlParameter("@RoleName", roleName)
                });
        }

        private static int EnsurePatient(SqlConnection conn, SqlTransaction tx, string code, string fullName, int index)
        {
            object existing = ExecuteScalar(conn, tx,
                "SELECT PatientID FROM Patients WHERE PatientCode = @PatientCode",
                new SqlParameter("@PatientCode", code));
            if (existing != null && existing != DBNull.Value)
            {
                return Convert.ToInt32(existing);
            }

            return ToInt(ExecuteScalar(conn, tx, @"
                INSERT INTO Patients(PatientCode, FullName, Gender, DOB, Phone, Address, BloodType, Allergy)
                OUTPUT INSERTED.PatientID
                VALUES(@PatientCode, @FullName, @Gender, @DOB, @Phone, @Address, @BloodType, @Allergy)",
                new SqlParameter("@PatientCode", code),
                new SqlParameter("@FullName", fullName),
                new SqlParameter("@Gender", index % 2 == 0 ? "Nam" : "Nu"),
                new SqlParameter("@DOB", DateTime.Today.AddYears(-25 - index).AddDays(index * 11)),
                new SqlParameter("@Phone", "0909" + (100000 + index).ToString()),
                new SqlParameter("@Address", "Demo GP1"),
                new SqlParameter("@BloodType", index % 3 == 0 ? "A+" : index % 3 == 1 ? "O+" : "B+"),
                new SqlParameter("@Allergy", index % 4 == 0 ? "Hai san" : "Khong co")));
        }

        private static List<int> GetDemoMedicineIds(SqlConnection conn, SqlTransaction tx)
        {
            List<int> ids = new();
            using SqlCommand cmd = new("SELECT TOP 5 MedicineID FROM Medicines WHERE ISNULL(Stock, 0) > 0 ORDER BY MedicineID", conn, tx);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }

            return ids;
        }

        private static void CreateSeedLab(SqlConnection conn, SqlTransaction tx, int encounterId, int doctorId, int index)
        {
            int labId = ToInt(ExecuteScalar(conn, tx, @"
                INSERT INTO LabRequests(EncounterID, DoctorID, TestType, Status, CreatedAt)
                OUTPUT INSERTED.LabID
                VALUES(@EncounterID, @DoctorID, @TestType, @Status, GETDATE())",
                new SqlParameter("@EncounterID", encounterId),
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@TestType", index % 4 == 0 ? "Cong thuc mau" : "Duong huyet"),
                new SqlParameter("@Status", index % 4 == 0 ? "Completed" : "Pending")));

            if (index % 4 == 0)
            {
                ExecuteNonQuery(conn, tx,
                    "INSERT INTO LabResults(LabID, ResultText, CompletedAt) VALUES(@LabID, @ResultText, GETDATE())",
                    new SqlParameter("@LabID", labId),
                    new SqlParameter("@ResultText", "WBC binh thuong; RBC binh thuong; HGB 135 g/L"));
            }
        }

        private static void CreateSeedImaging(SqlConnection conn, SqlTransaction tx, int encounterId, int doctorId, int index)
        {
            int serviceId = GetOrCreateImagingServiceId(index % 2 == 0 ? "X-quang nguc" : "Sieu am bung");
            int requestId = ToInt(ExecuteScalar(conn, tx, @"
                INSERT INTO ImagingRequests(EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status)
                OUTPUT INSERTED.ImagingRequestID
                VALUES(@EncounterID, @DoctorID, @ServiceID, @BodyPart, GETDATE(), @Priority, @Status)",
                new SqlParameter("@EncounterID", encounterId),
                new SqlParameter("@DoctorID", doctorId),
                new SqlParameter("@ServiceID", serviceId),
                new SqlParameter("@BodyPart", index % 2 == 0 ? "Nguc" : "Bung"),
                new SqlParameter("@Priority", index % 6 == 0 ? "High" : "Normal"),
                new SqlParameter("@Status", index % 6 == 0 ? "Completed" : "Pending")));

            if (index % 6 == 0)
            {
                ExecuteNonQuery(conn, tx, @"
                    INSERT INTO ImagingResults(ImagingRequestID, ResultText, TechnicianNote, CompletedAt)
                    VALUES(@RequestID, @ResultText, @Note, GETDATE())",
                    new SqlParameter("@RequestID", requestId),
                    new SqlParameter("@ResultText", "Khong ghi nhan bat thuong cap tinh"),
                    new SqlParameter("@Note", "Anh dat chat luong demo"));
            }
        }

        private static void CreateSeedPrescription(SqlConnection conn, SqlTransaction tx, int encounterId, int doctorId, List<int> medicineIds, int index)
        {
            int prescriptionId = ToInt(ExecuteScalar(conn, tx, @"
                INSERT INTO Prescriptions(EncounterID, DoctorID, Status, CreatedAt)
                OUTPUT INSERTED.PrescriptionID
                VALUES(@EncounterID, @DoctorID, 'Issued', GETDATE())",
                new SqlParameter("@EncounterID", encounterId),
                new SqlParameter("@DoctorID", doctorId)));

            int first = medicineIds[index % medicineIds.Count];
            int second = medicineIds[(index + 1) % medicineIds.Count];

            ExecuteNonQuery(conn, tx, @"
                INSERT INTO PrescriptionDetails(PrescriptionID, MedicineID, Quantity, Dosage, Frequency, Instruction)
                VALUES
                (@PrescriptionID, @Medicine1, @Qty1, @Dosage1, @Frequency1, @Instruction1),
                (@PrescriptionID, @Medicine2, @Qty2, @Dosage2, @Frequency2, @Instruction2)",
                new SqlParameter("@PrescriptionID", prescriptionId),
                new SqlParameter("@Medicine1", first),
                new SqlParameter("@Qty1", 10 + index),
                new SqlParameter("@Dosage1", "1 vien/lần"),
                new SqlParameter("@Frequency1", "2 lan/ngay"),
                new SqlParameter("@Instruction1", "Uong sau an"),
                new SqlParameter("@Medicine2", second),
                new SqlParameter("@Qty2", 5 + index),
                new SqlParameter("@Dosage2", "1 vien/lần"),
                new SqlParameter("@Frequency2", "Khi can"),
                new SqlParameter("@Instruction2", "Dung khi sot hoac dau"));
        }

        private List<PrescriptionItemDTO> GetPrescriptionItems(int prescriptionId)
        {
            string query = @"
                SELECT pd.DetailID,
                       pd.PrescriptionID,
                       pd.MedicineID,
                       pd.Quantity,
                       pd.Dosage,
                       pd.Frequency,
                       pd.Instruction,
                       ISNULL(m.Name, '') AS MedicineName,
                       ISNULL(m.Unit, '') AS MedicineUnit,
                       ISNULL(m.BatchNumber, '') AS BatchNumber,
                       ISNULL(m.Price, 0) AS Price
                FROM PrescriptionDetails pd
                INNER JOIN Medicines m ON pd.MedicineID = m.MedicineID
                WHERE pd.PrescriptionID = @PrescriptionID";

            List<PrescriptionItemDTO> list = new();
            DataTable table = DatabaseHelper.ExecuteQuery(query, new[]
            {
                new SqlParameter("@PrescriptionID", prescriptionId)
            });

            foreach (DataRow row in table.Rows)
            {
                list.Add(new PrescriptionItemDTO
                {
                    DetailID = ToInt(row["DetailID"]),
                    PrescriptionID = ToInt(row["PrescriptionID"]),
                    MedicineID = ToInt(row["MedicineID"]),
                    Quantity = ToInt(row["Quantity"]),
                    Dosage = Text(row["Dosage"]),
                    Frequency = Text(row["Frequency"]),
                    Instruction = Text(row["Instruction"]),
                    MedicineName = Text(row["MedicineName"]),
                    MedicineUnit = Text(row["MedicineUnit"]),
                    BatchNumber = Text(row["BatchNumber"]),
                    Price = row["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Price"])
                });
            }

            return list;
        }

        private static int GetOrCreateImagingServiceId(string serviceName)
        {
            object existing = DatabaseHelper.ExecuteScalar(
                "SELECT TOP 1 ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName",
                new[] { new SqlParameter("@ServiceName", serviceName) });
            if (existing != null && existing != DBNull.Value)
            {
                return Convert.ToInt32(existing);
            }

            DatabaseHelper.ExecuteNonQuery(@"
                INSERT INTO ImagingServices(ServiceName, Modality, Price, IsActive)
                VALUES(@ServiceName, @Modality, 0, 1)",
                new[]
                {
                    new SqlParameter("@ServiceName", serviceName),
                    new SqlParameter("@Modality", InferModality(serviceName))
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT TOP 1 ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName ORDER BY ImagingServiceID DESC",
                new[] { new SqlParameter("@ServiceName", serviceName) }));
        }

        private static string InferModality(string serviceName)
        {
            string value = (serviceName ?? "").ToLowerInvariant();
            if (value.Contains("ct")) return "CT";
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("sieu am") || value.Contains("siêu âm")) return "Ultrasound";
            return "Imaging";
        }

        private static List<DoctorAppointmentDTO> MapAppointments(DataTable table)
        {
            List<DoctorAppointmentDTO> list = new();
            foreach (DataRow row in table.Rows)
            {
                DoctorAppointmentDTO item = new()
                {
                    AppointmentID = ToInt(row["AppointmentID"]),
                    EncounterID = ToInt(row["EncounterID"]),
                    PatientID = ToInt(row["PatientID"]),
                    DoctorID = ToInt(row["DoctorID"]),
                    PatientCode = Text(row["PatientCode"]),
                    PatientName = Text(row["PatientName"]),
                    Gender = Text(row["Gender"]),
                    DOB = row["DOB"] == DBNull.Value ? null : Convert.ToDateTime(row["DOB"]),
                    Allergy = Text(row["Allergy"]),
                    DepartmentName = Text(row["DepartmentName"]),
                    RoomCode = Text(row["RoomCode"]),
                    AppointmentDate = row["AppointmentDate"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["AppointmentDate"]),
                    Status = Text(row["Status"]),
                    QueueStatus = Text(row["QueueStatus"]),
                    CurrentStep = Text(row["CurrentStep"]),
                    Temperature = row["Temperature"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Temperature"]),
                    BloodPressure = Text(row["BloodPressure"]),
                    HeartRate = ToInt(row["HeartRate"]),
                    SpO2 = ToInt(row["SPO2"]),
                    Weight = row["Weight"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Weight"]),
                    Height = row["Height"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Height"])
                };

                item.VitalSummary = BuildVitalSummary(item);
                list.Add(item);
            }

            return list;
        }

        private static string BuildVitalSummary(DoctorAppointmentDTO item)
        {
            List<string> parts = new();
            if (item.Temperature > 0) parts.Add(item.Temperature.ToString("0.0") + " C");
            if (!string.IsNullOrWhiteSpace(item.BloodPressure)) parts.Add(item.BloodPressure);
            if (item.HeartRate > 0) parts.Add(item.HeartRate + " bpm");
            if (item.SpO2 > 0) parts.Add("SpO2 " + item.SpO2 + "%");
            return parts.Count == 0 ? "Chua co sinh hieu" : string.Join(" | ", parts);
        }

        private static object ExecuteScalar(SqlConnection conn, SqlTransaction tx, string query, params SqlParameter[] parameters)
        {
            using SqlCommand cmd = new(query, conn, tx);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }

        private static int ExecuteNonQuery(SqlConnection conn, SqlTransaction tx, string query, params SqlParameter[] parameters)
        {
            using SqlCommand cmd = new(query, conn, tx);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        private static object Db(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? DBNull.Value : value.Trim();
        }

        private static string Text(object value)
        {
            return value == null || value == DBNull.Value ? "" : value.ToString();
        }

        private static int ToInt(object value)
        {
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }
    }
}
