using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL.DataContext;
using DTO;
using Newtonsoft.Json.Linq;
using ClinicManagementSystem.Winforms.Forms;
using ClinicManagementSystem.Winforms.Forms.Integrations;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucSeederTool : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucSeederTool()
        {
            InitializeComponent();
        }

        private void ucSeederTool_Load(object sender, EventArgs e)
        {
            btnRunSeed.Click += (s, ev) => RunDatabaseSeeder();
            btnTestPayOS.Click += (s, ev) =>
            {
                using (var paymentForm = new PayOsPaymentForm())
                {
                    paymentForm.ShowDialog();
                }
            };
            btnSyncApi.Click += (s, ev) =>
            {
                using (var syncForm = new MockApiSyncForm())
                {
                    syncForm.ShowDialog(this);
                }
            };
        }

        private void ucSeederTool_Resize(object sender, EventArgs e)
        {
            if (pnlContainer.Width < 200) return;
            int buttonWidth = (pnlContainer.Width - 64) / 2;
            btnRunSeed.Width = buttonWidth;
            btnTestPayOS.Width = buttonWidth;
            btnTestPayOS.Left = btnRunSeed.Right + 16;
        }

        private void RunDatabaseSeeder()
        {
            txtSeederLog.Clear();
            LogSeed("Đang bắt đầu khởi tạo lại cơ sở dữ liệu HealthCareDB...");

            try
            {
                string shiftTable = "Shifts";
                try
                {
                    int count = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM sys.tables WHERE name = 'TechnicianShifts'"));
                    if (count > 0) shiftTable = "TechnicianShifts";
                }
                catch { }

                // Detect if it is the CMS database schema
                bool isNewSchema = false;
                try
                {
                    int rolesCount = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U')"));
                    isNewSchema = rolesCount > 0;
                }
                catch { }

                if (isNewSchema)
                {
                    // Clear requests, doctors, and shifts (avoid deleting from Users/Patients because of foreign key constraints)
                    DatabaseHelper.ExecuteNonQuery($"DELETE FROM {shiftTable};");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Requests;");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Doctors;");
                    LogSeed("-> Đã xóa sạch dữ liệu cũ (Requests, Doctors, Shifts).");

                    // Ensure Roles exist or get RoleIDs
                    int techRoleId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT RoleID FROM Roles WHERE RoleName = 'Technician'") ?? 6);
                    int adminRoleId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT RoleID FROM Roles WHERE RoleName = 'Admin'") ?? 1);
                    int doctorRoleId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT RoleID FROM Roles WHERE RoleName = 'Doctor'") ?? 3);

                    // Ensure 'ktv'
                    if (Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Username = 'ktv'")) == 0)
                    {
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Users (Username, PasswordHash, Email, RoleID) VALUES ('ktv', '123', 'tech@phongkham.vn', {techRoleId});");
                        int userId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT UserID FROM Users WHERE Username = 'ktv'"));
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID) VALUES ('EMP_KTV', N'Lữ Võ Hoàng Phúc', {techRoleId}, (SELECT TOP 1 DepartmentID FROM Departments WHERE DepartmentName = N'Xét nghiệm' OR DepartmentName = N'Chẩn đoán hình ảnh'), 'Active', {userId});");
                    }
                    // Ensure 'admin'
                    if (Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Username = 'admin'")) == 0)
                    {
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Users (Username, PasswordHash, Email, RoleID) VALUES ('admin', 'admin123', 'admin@phongkham.vn', {adminRoleId});");
                        int userId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT UserID FROM Users WHERE Username = 'admin'"));
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID) VALUES ('EMP_ADM', N'Quản Trị Viên', {adminRoleId}, (SELECT TOP 1 DepartmentID FROM Departments WHERE DepartmentName = N'Hành chính'), 'Active', {userId});");
                    }
                    // Ensure 'bacsi'
                    if (Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT COUNT(*) FROM Users WHERE Username = 'bacsi'")) == 0)
                    {
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Users (Username, PasswordHash, Email, RoleID) VALUES ('bacsi', '123', 'doctor@phongkham.vn', {doctorRoleId});");
                        int userId = Convert.ToInt32(DatabaseHelper.ExecuteScalar("SELECT UserID FROM Users WHERE Username = 'bacsi'"));
                        DatabaseHelper.ExecuteNonQuery($"INSERT INTO Employees (EmployeeCode, FullName, RoleID, DepartmentID, Status, UserID) VALUES ('EMP_DOC', N'Bác sĩ Nguyễn Văn Minh', {doctorRoleId}, (SELECT TOP 1 DepartmentID FROM Departments WHERE DepartmentName = N'Khám tổng quát' OR DepartmentName = N'Khoa Nội'), 'Active', {userId});");
                    }
                    LogSeed("-> Đã kiểm tra và thêm tài khoản đăng nhập nếu chưa có.");

                    // Local helper to ensure patient exists in the database
                    void EnsurePatientExists(string code, string name, string dob, string gender, string phone, string address)
                    {
                        int cnt = Convert.ToInt32(DatabaseHelper.ExecuteScalar($"SELECT COUNT(*) FROM Patients WHERE PatientCode = '{code}'"));
                        if (cnt == 0)
                        {
                            DatabaseHelper.ExecuteNonQuery($"INSERT INTO Patients (PatientCode, FullName, DOB, Gender, Phone, Address) VALUES ('{code}', N'{name}', '{dob}', N'{gender}', '{phone}', N'{address}');");
                        }
                    }

                    EnsurePatientExists("BN001", "Nguyễn Văn A", "1981-05-15", "Nam", "0905111222", "Hải Châu, Đà Nẵng");
                    EnsurePatientExists("BN002", "Trần Thị B", "1994-08-22", "Nữ", "0905333444", "Sơn Trà, Đà Nẵng");
                    EnsurePatientExists("BN003", "Lê Văn C", "1998-11-30", "Nam", "0905555666", "Liên Chiểu, Đà Nẵng");
                    EnsurePatientExists("BN004", "Phạm Thị D", "1971-02-10", "Nữ", "0905777888", "Ngũ Hành Sơn, Đà Nẵng");
                    EnsurePatientExists("BN005", "Hoàng Văn E", "1988-04-05", "Nam", "0905999000", "Thanh Khê, Đà Nẵng");
                    LogSeed("-> Đã kiểm tra và nạp bệnh nhân mẫu nếu chưa có.");
                }
                else
                {
                    // Clear existing tables
                    DatabaseHelper.ExecuteNonQuery($"DELETE FROM {shiftTable};");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Requests;");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Patients;");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Doctors;");
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Users;");
                    LogSeed("-> Đã xóa sạch dữ liệu cũ.");

                    // Add default login accounts
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('ktv', '123', N'Lữ Võ Hoàng Phúc', 'Technician', 'tech@phongkham.vn');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('admin', 'admin123', N'Quản Trị Viên', 'Admin', 'admin@phongkham.vn');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('bacsi', '123', N'Bác sĩ Nguyễn Văn Minh', 'Doctor', 'doctor@phongkham.vn');");
                    LogSeed("-> Đã thêm 3 tài khoản đăng nhập (Kỹ thuật viên: 'ktv' | Bác sĩ: 'bacsi' | Admin: 'admin').");

                    // Seed Patients
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN001', N'Nguyễn Văn A', '1981-05-15', N'Nam', '0905111222', N'Hải Châu, Đà Nẵng');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN002', N'Trần Thị B', '1994-08-22', N'Nữ', '0905333444', N'Sơn Trà, Đà Nẵng');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN003', N'Lê Văn C', '1998-11-30', N'Nam', '0905555666', N'Liên Chiểu, Đà Nẵng');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN004', N'Phạm Thị D', '1971-02-10', N'Nữ', '0905777888', N'Ngũ Hành Sơn, Đà Nẵng');");
                    DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN005', N'Hoàng Văn E', '1988-04-05', N'Nam', '0905999000', N'Thanh Khê, Đà Nẵng');");
                    LogSeed("-> Đã nạp 5 bệnh nhân đăng ký.");
                }

                // Seed Doctors
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS001', N'BS. Nguyễn Văn Minh', N'Khoa Nội');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS002', N'BS. Trần B', N'Chẩn đoán hình ảnh');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS003', N'BS. Phạm D', N'Khoa Nội');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS004', N'BS. Lê H', N'Khoa Tim mạch');");
                LogSeed("-> Đã nạp 4 hồ sơ Bác sĩ chỉ định.");

                // Fetch IDs
                int p1 = (int)DatabaseHelper.ExecuteScalar("SELECT PatientID FROM Patients WHERE PatientCode = 'BN001'");
                int p2 = (int)DatabaseHelper.ExecuteScalar("SELECT PatientID FROM Patients WHERE PatientCode = 'BN002'");
                int p3 = (int)DatabaseHelper.ExecuteScalar("SELECT PatientID FROM Patients WHERE PatientCode = 'BN003'");
                int p4 = (int)DatabaseHelper.ExecuteScalar("SELECT PatientID FROM Patients WHERE PatientCode = 'BN004'");
                int p5 = (int)DatabaseHelper.ExecuteScalar("SELECT PatientID FROM Patients WHERE PatientCode = 'BN005'");

                int d1 = (int)DatabaseHelper.ExecuteScalar("SELECT DoctorID FROM Doctors WHERE DoctorCode = 'BS001'");
                int d2 = (int)DatabaseHelper.ExecuteScalar("SELECT DoctorID FROM Doctors WHERE DoctorCode = 'BS002'");
                int d3 = (int)DatabaseHelper.ExecuteScalar("SELECT DoctorID FROM Doctors WHERE DoctorCode = 'BS003'");
                int d4 = (int)DatabaseHelper.ExecuteScalar("SELECT DoctorID FROM Doctors WHERE DoctorCode = 'BS004'");

                // Seed Requests
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ001', {p3}, {d3}, N'Điện tâm đồ (ECG)', N'Đánh giá rối loạn nhịp tim', N'Ưu tiên cao', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chờ xử lý');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ002', {p3}, {d3}, N'Siêu âm tim', N'Đánh giá cấu trúc tim', N'Ưu tiên cao', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chờ xử lý');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ004', {p5}, {d2}, N'Chụp MRI cột sống', N'Nghi ngờ thoát vị đĩa đệm', N'Ưu tiên', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chờ xử lý');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ005', {p2}, {d4}, N'Xét nghiệm sinh hóa máu', N'Định lượng Glucose và Acid Uric', N'Thường', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chờ xử lý');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ006', {p4}, {d2}, N'Chụp X-quang phổi', N'Ho kéo dài, nghi ngờ viêm phổi', N'Thường', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Đang xử lý');");

                // Seed one completed request with PDF path
                string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);
                string dummyPdf = Path.Combine(uploadFolder, "sample_result.pdf");
                if (!File.Exists(dummyPdf)) File.WriteAllBytes(dummyPdf, new byte[] { 0x25, 0x50, 0x44, 0x46, 0x0A }); // dummy empty pdf header

                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status, ResultPDF) VALUES ('REQ003', {p1}, {d1}, N'Xét nghiệm máu tổng quát', N'Kiểm tra công thức máu', N'Thường', '{DateTime.Now.AddDays(-1):yyyy-MM-dd HH:mm:ss}', N'Hoàn thành', '{dummyPdf.Replace("\\", "\\\\")}');");

                LogSeed("-> Đã nạp 6 yêu cầu dịch vụ.");

                // Seed Shifts
                DateTime mon = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO {shiftTable} (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon:yyyy-MM-dd}', N'Sáng', N'Phòng khám 101', N'Khoa Nội', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO {shiftTable} (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(1):yyyy-MM-dd}', N'Chiều', N'Phòng khám 102', N'Khoa Nội', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO {shiftTable} (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(2):yyyy-MM-dd}', N'Sáng', N'Phòng khám 201', N'Khoa Tim mạch', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO {shiftTable} (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(3):yyyy-MM-dd}', N'Chiều', N'Phòng khám 103', N'Khoa Nội', N'Chờ xác nhận');");
                LogSeed("-> Đã nạp 4 ca trực hàng tuần của Kỹ thuật viên.");

                LogSeed("\n[HOÀN THÀNH] Khởi tạo dữ liệu mẫu thành công! Bạn có thể sử dụng các chức năng của Kỹ thuật viên ngay lập tức.");
                MessageBox.Show("Đã nạp toàn bộ dữ liệu mẫu vào SQL Server thành công!", "Seeder Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogSeed("\n[LỖI] Khởi tạo dữ liệu thất bại. Chi tiết lỗi:");
                LogSeed(ex.ToString());
                MessageBox.Show("Seed dữ liệu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogSeed(string msg)
        {
            txtSeederLog.AppendText(msg + "\r\n");
        }

        // ==========================================

    }
}

