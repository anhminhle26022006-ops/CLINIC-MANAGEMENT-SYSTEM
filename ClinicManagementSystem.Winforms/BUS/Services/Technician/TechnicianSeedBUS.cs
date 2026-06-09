using System;
using System.IO;
using DAL.DataContext;
using Microsoft.Data.SqlClient;

namespace BUS.Services.Technician
{
    public class TechnicianSeedBUS
    {
        public void Run(Action<string> log)
        {
            log ??= _ => { };
            log("Đang khởi tạo dữ liệu mẫu theo schema CMS.sql...");

            EnsureCmsSchema();

            int adminRoleId = EnsureRole("Admin");
            int doctorRoleId = EnsureRole("Doctor");
            int technicianRoleId = EnsureRole("Technician");

            int adminDepartmentId = EnsureDepartment("Hành chính");
            int labDepartmentId = EnsureDepartment("Xét nghiệm");
            int imagingDepartmentId = EnsureDepartment("Chẩn đoán hình ảnh");
            int generalDepartmentId = EnsureDepartment("Khám tổng quát");
            int cardiologyDepartmentId = EnsureDepartment("Tim mạch");

            int technicianId = EnsureUserEmployee("ktv", "123", "tech@phongkham.vn", technicianRoleId, "EMP_KTV", "Lữ Võ Hoàng Phúc", labDepartmentId);
            EnsureUserEmployee("admin", "admin123", "admin@phongkham.vn", adminRoleId, "EMP_ADM", "Quản Trị Viên", adminDepartmentId);
            int doctor1 = EnsureUserEmployee("doctor", "123456", "doctor@phongkham.vn", doctorRoleId, "BS001", "BS. Nguyễn Văn Minh", generalDepartmentId);
            int doctor2 = EnsureEmployee("BS002", "BS. Trần B", doctorRoleId, imagingDepartmentId);
            int doctor3 = EnsureEmployee("BS003", "BS. Phạm D", doctorRoleId, generalDepartmentId);
            int doctor4 = EnsureEmployee("BS004", "BS. Lê H", doctorRoleId, cardiologyDepartmentId);
            log("-> Đã đồng bộ tài khoản và nhân sự qua Users/Employees/Roles.");

            int p1 = EnsurePatient("BN001", "Nguyễn Văn A", "1981-05-15", "Nam", "0905111222", "Hải Châu, Đà Nẵng");
            int p2 = EnsurePatient("BN002", "Trần Thị B", "1994-08-22", "Nữ", "0905333444", "Sơn Trà, Đà Nẵng");
            int p3 = EnsurePatient("BN003", "Lê Văn C", "1998-11-30", "Nam", "0905555666", "Liên Chiểu, Đà Nẵng");
            int p4 = EnsurePatient("BN004", "Phạm Thị D", "1971-02-10", "Nữ", "0905777888", "Ngũ Hành Sơn, Đà Nẵng");
            int p5 = EnsurePatient("BN005", "Hoàng Văn E", "1988-04-05", "Nam", "0905999000", "Thanh Khê, Đà Nẵng");
            log("-> Đã đồng bộ bệnh nhân mẫu qua Patients.");

            ClearSampleTechnicianData(technicianId);

            SeedLabRequest(p3, doctor3, "Điện tâm đồ (ECG)", "Chờ xử lý");
            SeedImagingRequest(p3, doctor3, "Siêu âm tim", "Tim", "Ưu tiên cao", "Chờ xử lý");
            SeedImagingRequest(p5, doctor2, "Chụp MRI cột sống", "Cột sống", "Ưu tiên", "Chờ xử lý");
            SeedLabRequest(p2, doctor4, "Xét nghiệm sinh hóa máu", "Chờ xử lý");
            SeedImagingRequest(p4, doctor2, "Chụp X-quang phổi", "Phổi", "Thường", "Đang xử lý");

            int completedLabId = SeedLabRequest(p1, doctor1, "Xét nghiệm máu tổng quát", "Hoàn thành");
            string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string dummyPdf = Path.Combine(uploadFolder, "sample_result.pdf");
            if (!File.Exists(dummyPdf))
            {
                File.WriteAllBytes(dummyPdf, new byte[] { 0x25, 0x50, 0x44, 0x46, 0x0A });
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO LabResults (LabID, ResultText, FileURL, CompletedAt) VALUES (@LabID, @ResultText, @FileURL, @CompletedAt)",
                new[]
                {
                    new SqlParameter("@LabID", completedLabId),
                    new SqlParameter("@ResultText", "Công thức máu trong giới hạn theo dữ liệu mẫu."),
                    new SqlParameter("@FileURL", dummyPdf),
                    new SqlParameter("@CompletedAt", DateTime.Now.AddDays(-1))
                });
            log("-> Đã nạp yêu cầu kỹ thuật qua LabRequests/ImagingRequests và bảng kết quả tương ứng.");

            DateTime monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            SeedEmployeeShift(technicianId, "Sáng", "08:00", "12:00", monday);
            SeedEmployeeShift(technicianId, "Chiều", "13:00", "17:00", monday.AddDays(1));
            SeedEmployeeShift(technicianId, "Sáng", "08:00", "12:00", monday.AddDays(2));
            SeedEmployeeShift(technicianId, "Chiều", "13:00", "17:00", monday.AddDays(3));
            log("-> Đã nạp ca kỹ thuật viên qua Shifts/EmployeeShifts.");

            log("\n[HOÀN THÀNH] Dữ liệu mẫu đã đồng nhất với CMS.sql.");
        }

        private static void EnsureCmsSchema()
        {
            int rolesCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U')"));
            int diagnosticsCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LabRequests]') AND type in (N'U')"));

            if (rolesCount == 0 || diagnosticsCount == 0)
            {
                throw new InvalidOperationException("Database hiện tại chưa phải schema CMS.sql. Hãy chạy Database/CMS.sql trước.");
            }
        }

        private static int EnsureRole(string roleName)
        {
            object roleId = DatabaseHelper.ExecuteScalar(
                "SELECT RoleID FROM Roles WHERE RoleName = @RoleName",
                new[] { new SqlParameter("@RoleName", roleName) });

            if (roleId != null && roleId != DBNull.Value)
            {
                return Convert.ToInt32(roleId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Roles (RoleName, Description) VALUES (@RoleName, @Description)",
                new[]
                {
                    new SqlParameter("@RoleName", roleName),
                    new SqlParameter("@Description", roleName)
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT RoleID FROM Roles WHERE RoleName = @RoleName",
                new[] { new SqlParameter("@RoleName", roleName) }));
        }

        private static int EnsureDepartment(string departmentName)
        {
            object departmentId = DatabaseHelper.ExecuteScalar(
                "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName",
                new[] { new SqlParameter("@DepartmentName", departmentName) });

            if (departmentId != null && departmentId != DBNull.Value)
            {
                return Convert.ToInt32(departmentId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName)",
                new[] { new SqlParameter("@DepartmentName", departmentName) });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT DepartmentID FROM Departments WHERE DepartmentName = @DepartmentName",
                new[] { new SqlParameter("@DepartmentName", departmentName) }));
        }

        private static int EnsureUserEmployee(string username, string password, string email, int roleId, string employeeCode, string fullName, int departmentId)
        {
            object userId = DatabaseHelper.ExecuteScalar(
                "SELECT UserID FROM Users WHERE Username = @Username",
                new[] { new SqlParameter("@Username", username) });

            if (userId == null || userId == DBNull.Value)
            {
                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Users (Username, PasswordHash, Email, RoleID, IsActive) VALUES (@Username, @PasswordHash, @Email, @RoleID, 1)",
                    new[]
                    {
                        new SqlParameter("@Username", username),
                        new SqlParameter("@PasswordHash", password),
                        new SqlParameter("@Email", email),
                        new SqlParameter("@RoleID", roleId)
                    });
                userId = DatabaseHelper.ExecuteScalar(
                    "SELECT UserID FROM Users WHERE Username = @Username",
                    new[] { new SqlParameter("@Username", username) });
            }
            else
            {
                DatabaseHelper.ExecuteNonQuery(
                    "UPDATE Users SET PasswordHash = @PasswordHash, Email = @Email, RoleID = @RoleID, IsActive = 1 WHERE UserID = @UserID",
                    new[]
                    {
                        new SqlParameter("@PasswordHash", password),
                        new SqlParameter("@Email", email),
                        new SqlParameter("@RoleID", roleId),
                        new SqlParameter("@UserID", Convert.ToInt32(userId))
                    });
            }

            return EnsureEmployee(employeeCode, fullName, roleId, departmentId, Convert.ToInt32(userId));
        }

        private static int EnsureEmployee(string employeeCode, string fullName, int roleId, int departmentId, int? userId = null)
        {
            object employeeId = DatabaseHelper.ExecuteScalar(
                "SELECT EmployeeID FROM Employees WHERE EmployeeCode = @EmployeeCode",
                new[] { new SqlParameter("@EmployeeCode", employeeCode) });

            if (employeeId != null && employeeId != DBNull.Value)
            {
                if (userId.HasValue)
                {
                    DatabaseHelper.ExecuteNonQuery(
                        "UPDATE Employees SET FullName = @FullName, RoleID = @RoleID, DepartmentID = @DepartmentID, Status = @Status, UserID = @UserID WHERE EmployeeCode = @EmployeeCode",
                        new[]
                        {
                            new SqlParameter("@EmployeeCode", employeeCode),
                            new SqlParameter("@FullName", fullName),
                            new SqlParameter("@RoleID", roleId),
                            new SqlParameter("@DepartmentID", departmentId),
                            new SqlParameter("@Status", "Active"),
                            new SqlParameter("@UserID", userId.Value)
                        });
                }

                return Convert.ToInt32(employeeId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID) VALUES (@EmployeeCode, @FullName, @RoleID, @DepartmentID, @Status, @UserID)",
                new[]
                {
                    new SqlParameter("@EmployeeCode", employeeCode),
                    new SqlParameter("@FullName", fullName),
                    new SqlParameter("@RoleID", roleId),
                    new SqlParameter("@DepartmentID", departmentId),
                    new SqlParameter("@Status", "Active"),
                    new SqlParameter("@UserID", (object)userId ?? DBNull.Value)
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT EmployeeID FROM Employees WHERE EmployeeCode = @EmployeeCode",
                new[] { new SqlParameter("@EmployeeCode", employeeCode) }));
        }

        private static int EnsurePatient(string code, string name, string dob, string gender, string phone, string address)
        {
            object patientId = DatabaseHelper.ExecuteScalar(
                "SELECT PatientID FROM Patients WHERE PatientCode = @PatientCode",
                new[] { new SqlParameter("@PatientCode", code) });

            if (patientId != null && patientId != DBNull.Value)
            {
                return Convert.ToInt32(patientId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Patients (PatientCode, FullName, DOB, Gender, Phone, Address) VALUES (@PatientCode, @FullName, @DOB, @Gender, @Phone, @Address)",
                new[]
                {
                    new SqlParameter("@PatientCode", code),
                    new SqlParameter("@FullName", name),
                    new SqlParameter("@DOB", dob),
                    new SqlParameter("@Gender", gender),
                    new SqlParameter("@Phone", phone),
                    new SqlParameter("@Address", address)
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT PatientID FROM Patients WHERE PatientCode = @PatientCode",
                new[] { new SqlParameter("@PatientCode", code) }));
        }

        private static void ClearSampleTechnicianData(int technicianId)
        {
            DatabaseHelper.ExecuteNonQuery("DELETE FROM ImagingFiles");
            DatabaseHelper.ExecuteNonQuery("DELETE FROM ImagingResults");
            DatabaseHelper.ExecuteNonQuery("DELETE FROM LabResults");
            DatabaseHelper.ExecuteNonQuery("DELETE FROM ImagingRequests");
            DatabaseHelper.ExecuteNonQuery("DELETE FROM LabRequests");
            DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM EmployeeShifts WHERE EmployeeID = @EmployeeID",
                new[] { new SqlParameter("@EmployeeID", technicianId) });
        }

        private static int CreateEncounter(int patientId, int doctorId)
        {
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "INSERT INTO Encounters (PatientID, DoctorID, StartTime, Status) VALUES (@PatientID, @DoctorID, @StartTime, @Status); SELECT CAST(SCOPE_IDENTITY() AS int);",
                new[]
                {
                    new SqlParameter("@PatientID", patientId),
                    new SqlParameter("@DoctorID", doctorId),
                    new SqlParameter("@StartTime", DateTime.Now),
                    new SqlParameter("@Status", "Open")
                }));
        }

        private static int SeedLabRequest(int patientId, int doctorId, string testType, string status)
        {
            int encounterId = CreateEncounter(patientId, doctorId);
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "INSERT INTO LabRequests (EncounterID, DoctorID, TestType, Status, CreatedAt) VALUES (@EncounterID, @DoctorID, @TestType, @Status, @CreatedAt); SELECT CAST(SCOPE_IDENTITY() AS int);",
                new[]
                {
                    new SqlParameter("@EncounterID", encounterId),
                    new SqlParameter("@DoctorID", doctorId),
                    new SqlParameter("@TestType", testType),
                    new SqlParameter("@Status", status),
                    new SqlParameter("@CreatedAt", DateTime.Now)
                }));
        }

        private static void SeedImagingRequest(int patientId, int doctorId, string serviceName, string bodyPart, string priority, string status)
        {
            int encounterId = CreateEncounter(patientId, doctorId);
            int serviceId = EnsureImagingService(serviceName);
            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO ImagingRequests (EncounterID, DoctorID, ImagingServiceID, BodyPart, CreatedAt, Priority, Status) VALUES (@EncounterID, @DoctorID, @ServiceID, @BodyPart, @CreatedAt, @Priority, @Status)",
                new[]
                {
                    new SqlParameter("@EncounterID", encounterId),
                    new SqlParameter("@DoctorID", doctorId),
                    new SqlParameter("@ServiceID", serviceId),
                    new SqlParameter("@BodyPart", bodyPart),
                    new SqlParameter("@CreatedAt", DateTime.Now),
                    new SqlParameter("@Priority", priority),
                    new SqlParameter("@Status", status)
                });
        }

        private static int EnsureImagingService(string serviceName)
        {
            object serviceId = DatabaseHelper.ExecuteScalar(
                "SELECT ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName",
                new[] { new SqlParameter("@ServiceName", serviceName) });

            if (serviceId != null && serviceId != DBNull.Value)
            {
                return Convert.ToInt32(serviceId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO ImagingServices (ServiceName, Modality, Price, IsActive) VALUES (@ServiceName, @Modality, 0, 1)",
                new[]
                {
                    new SqlParameter("@ServiceName", serviceName),
                    new SqlParameter("@Modality", InferModality(serviceName))
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT ImagingServiceID FROM ImagingServices WHERE ServiceName = @ServiceName",
                new[] { new SqlParameter("@ServiceName", serviceName) }));
        }

        private static void SeedEmployeeShift(int employeeId, string shiftName, string startTime, string endTime, DateTime workDate)
        {
            int shiftId = EnsureShift(shiftName, startTime, endTime);
            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO EmployeeShifts (EmployeeID, ShiftID, WorkDate) VALUES (@EmployeeID, @ShiftID, @WorkDate)",
                new[]
                {
                    new SqlParameter("@EmployeeID", employeeId),
                    new SqlParameter("@ShiftID", shiftId),
                    new SqlParameter("@WorkDate", workDate.Date)
                });
        }

        private static int EnsureShift(string name, string startTime, string endTime)
        {
            object shiftId = DatabaseHelper.ExecuteScalar(
                "SELECT ShiftID FROM Shifts WHERE Name = @Name",
                new[] { new SqlParameter("@Name", name) });

            if (shiftId != null && shiftId != DBNull.Value)
            {
                return Convert.ToInt32(shiftId);
            }

            DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO Shifts (Name, StartTime, EndTime) VALUES (@Name, @StartTime, @EndTime)",
                new[]
                {
                    new SqlParameter("@Name", name),
                    new SqlParameter("@StartTime", startTime),
                    new SqlParameter("@EndTime", endTime)
                });

            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(
                "SELECT ShiftID FROM Shifts WHERE Name = @Name",
                new[] { new SqlParameter("@Name", name) }));
        }

        private static string InferModality(string serviceName)
        {
            string value = (serviceName ?? "").ToLowerInvariant();
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("siêu âm") || value.Contains("sieu am")) return "Ultrasound";
            return "Imaging";
        }
    }
}
