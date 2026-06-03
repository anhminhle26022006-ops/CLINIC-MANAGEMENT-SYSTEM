using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;
using ClinicManagementSystem.Winforms.Forms.Integrations;
using DAL.DataContext;
using DTO;
using Newtonsoft.Json.Linq;

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
            RenderView();
        }

        private void ucSeederTool_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderSeederTool();
        }

        // 8. SEEDER TOOL VIEW (SeederToolForm)
        // ==========================================
        private TextBox txtSeederLog;

        private void RenderSeederTool()
        {
            var page = BeginPage("Công cụ Khởi tạo Cơ sở dữ liệu", "Hệ thống mock dữ liệu mẫu giúp chạy demo nhanh cho đồ án 3 lớp");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 520,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Bấm nút bên dưới để dọn sạch bảng và tạo dữ liệu mẫu bệnh nhân, bác sĩ, lịch trực & yêu cầu mới:", 10F, FontStyle.Regular, textMain, 24, 24, panel.Width - 48, 24));

            var btnRunSeed = CreateFlatButton("KHỞI TẠO LẠI DỮ LIỆU MẪU (SEED DATABASE)", Color.White, Color.FromArgb(239, 68, 68), 24, 60, panel.Width - 48, 48);
            btnRunSeed.Click += (s, ev) => RunDatabaseSeeder();
            panel.Controls.Add(btnRunSeed);

            var btnMockApi = CreateFlatButton("MOCK API SYNC", Color.White, Color.FromArgb(47, 94, 240), 24, 116, panel.Width - 48, 44);
            btnMockApi.Click += (s, ev) =>
            {
                using var form = new MockApiSyncForm();
                form.ShowDialog(this);
            };
            panel.Controls.Add(btnMockApi);

            panel.Controls.Add(CreateLabel("Log bảng điều khiển Seeder:", 9.5F, FontStyle.Bold, textMain, 24, 176, 300, 22));

            txtSeederLog = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.FromArgb(17, 24, 39),
                ForeColor = Color.FromArgb(34, 197, 94),
                Font = new Font("Consolas", 10F),
                Location = new Point(24, 200),
                Size = new Size(panel.Width - 48, 280),
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical
            };
            panel.Controls.Add(txtSeederLog);

            page.Controls.Add(panel);
        }

        private void RunDatabaseSeeder()
        {
            txtSeederLog.Clear();
            LogSeed("Đang bắt đầu khởi tạo lại cơ sở dữ liệu HealthCareDB...");

            try
            {
                // Clear existing tables
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Shifts;");
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

                // Seed Doctors
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS001', N'BS. Nguyễn Văn Minh', N'Khoa Nội');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS002', N'BS. Trần B', N'Chẩn đoán hình ảnh');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS003', N'BS. Phạm D', N'Khoa Nội');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS004', N'BS. Lê H', N'Khoa Tim mạch');");
                LogSeed("-> Đã nạp 4 hồ sơ Bác sĩ chỉ định.");

                // Seed Patients
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN001', N'Nguyễn Văn A', '1981-05-15', N'Nam', '0905111222', N'Hải Châu, Đà Nẵng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN002', N'Trần Thị B', '1994-08-22', N'Nữ', '0905333444', N'Sơn Trà, Đà Nẵng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN003', N'Lê Văn C', '1998-11-30', N'Nam', '0905555666', N'Liên Chiểu, Đà Nẵng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN004', N'Phạm Thị D', '1971-02-10', N'Nữ', '0905777888', N'Ngũ Hành Sơn, Đà Nẵng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN005', N'Hoàng Văn E', '1988-04-05', N'Nam', '0905999000', N'Thanh Khê, Đà Nẵng');");
                LogSeed("-> Đã nạp 5 bệnh nhân đăng ký.");

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
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon:yyyy-MM-dd}', N'Sáng', N'Phòng khám 101', N'Khoa Nội', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(1):yyyy-MM-dd}', N'Chiều', N'Phòng khám 102', N'Khoa Nội', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(2):yyyy-MM-dd}', N'Sáng', N'Phòng khám 201', N'Khoa Tim mạch', N'Đã đăng ký');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(3):yyyy-MM-dd}', N'Chiều', N'Phòng khám 103', N'Khoa Nội', N'Chờ xác nhận');");
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


