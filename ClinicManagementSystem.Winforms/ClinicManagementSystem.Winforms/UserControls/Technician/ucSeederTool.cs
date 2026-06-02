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
            var page = BeginPage("CÃ´ng cá»¥ Khá»Ÿi táº¡o CÆ¡ sá»Ÿ dá»¯ liá»‡u", "Há»‡ thá»‘ng mock dá»¯ liá»‡u máº«u giÃºp cháº¡y demo nhanh cho Ä‘á»“ Ã¡n 3 lá»›p");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 520,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Báº¥m nÃºt bÃªn dÆ°á»›i Ä‘á»ƒ dá»n sáº¡ch báº£ng vÃ  táº¡o dá»¯ liá»‡u máº«u bá»‡nh nhÃ¢n, bÃ¡c sÄ©, lá»‹ch trá»±c & yÃªu cáº§u má»›i:", 10F, FontStyle.Regular, textMain, 24, 24, panel.Width - 48, 24));

            var btnRunSeed = CreateFlatButton("KHá»žI Táº O Láº I Dá»® LIá»†U MáºªU (SEED DATABASE)", Color.White, Color.FromArgb(239, 68, 68), 24, 60, panel.Width - 48, 48);
            btnRunSeed.Click += (s, ev) => RunDatabaseSeeder();
            panel.Controls.Add(btnRunSeed);

            panel.Controls.Add(CreateLabel("Log báº£ng Ä‘iá»u khiá»ƒn Seeder:", 9.5F, FontStyle.Bold, textMain, 24, 126, 300, 22));

            txtSeederLog = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.FromArgb(17, 24, 39),
                ForeColor = Color.FromArgb(34, 197, 94),
                Font = new Font("Consolas", 10F),
                Location = new Point(24, 150),
                Size = new Size(panel.Width - 48, 330),
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Vertical
            };
            panel.Controls.Add(txtSeederLog);

            page.Controls.Add(panel);
        }

        private void RunDatabaseSeeder()
        {
            txtSeederLog.Clear();
            LogSeed("Äang báº¯t Ä‘áº§u khá»Ÿi táº¡o láº¡i cÆ¡ sá»Ÿ dá»¯ liá»‡u HealthCareDB...");

            try
            {
                // Clear existing tables
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Shifts;");
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Requests;");
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Patients;");
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Doctors;");
                DatabaseHelper.ExecuteNonQuery("DELETE FROM Users;");
                LogSeed("-> ÄÃ£ xÃ³a sáº¡ch dá»¯ liá»‡u cÅ©.");

                // Add default login accounts
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('ktv', '123', N'Lá»¯ VÃµ HoÃ ng PhÃºc', 'Technician', 'tech@phongkham.vn');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('admin', 'admin123', N'Quáº£n Trá»‹ ViÃªn', 'Admin', 'admin@phongkham.vn');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Users (Username, Password, Name, Role, Email) VALUES ('bacsi', '123', N'BÃ¡c sÄ© Nguyá»…n VÄƒn Minh', 'Doctor', 'doctor@phongkham.vn');");
                LogSeed("-> ÄÃ£ thÃªm 3 tÃ i khoáº£n Ä‘Äƒng nháº­p (Ká»¹ thuáº­t viÃªn: 'ktv' | BÃ¡c sÄ©: 'bacsi' | Admin: 'admin').");

                // Seed Doctors
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS001', N'BS. Nguyá»…n VÄƒn Minh', N'Khoa Ná»™i');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS002', N'BS. Tráº§n B', N'Cháº©n Ä‘oÃ¡n hÃ¬nh áº£nh');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS003', N'BS. Pháº¡m D', N'Khoa Ná»™i');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Doctors (DoctorCode, Name, Department) VALUES ('BS004', N'BS. LÃª H', N'Khoa Tim máº¡ch');");
                LogSeed("-> ÄÃ£ náº¡p 4 há»“ sÆ¡ BÃ¡c sÄ© chá»‰ Ä‘á»‹nh.");

                // Seed Patients
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN001', N'Nguyá»…n VÄƒn A', '1981-05-15', N'Nam', '0905111222', N'Háº£i ChÃ¢u, ÄÃ  Náºµng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN002', N'Tráº§n Thá»‹ B', '1994-08-22', N'Ná»¯', '0905333444', N'SÆ¡n TrÃ , ÄÃ  Náºµng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN003', N'LÃª VÄƒn C', '1998-11-30', N'Nam', '0905555666', N'LiÃªn Chiá»ƒu, ÄÃ  Náºµng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN004', N'Pháº¡m Thá»‹ D', '1971-02-10', N'Ná»¯', '0905777888', N'NgÅ© HÃ nh SÆ¡n, ÄÃ  Náºµng');");
                DatabaseHelper.ExecuteNonQuery("INSERT INTO Patients (PatientCode, Name, BirthDate, Gender, Phone, Address) VALUES ('BN005', N'HoÃ ng VÄƒn E', '1988-04-05', N'Nam', '0905999000', N'Thanh KhÃª, ÄÃ  Náºµng');");
                LogSeed("-> ÄÃ£ náº¡p 5 bá»‡nh nhÃ¢n Ä‘Äƒng kÃ½.");

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
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ001', {p3}, {d3}, N'Äiá»‡n tÃ¢m Ä‘á»“ (ECG)', N'ÄÃ¡nh giÃ¡ rá»‘i loáº¡n nhá»‹p tim', N'Æ¯u tiÃªn cao', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chá» xá»­ lÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ002', {p3}, {d3}, N'SiÃªu Ã¢m tim', N'ÄÃ¡nh giÃ¡ cáº¥u trÃºc tim', N'Æ¯u tiÃªn cao', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chá» xá»­ lÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ004', {p5}, {d2}, N'Chá»¥p MRI cá»™t sá»‘ng', N'Nghi ngá» thoÃ¡t vá»‹ Ä‘Ä©a Ä‘á»‡m', N'Æ¯u tiÃªn', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chá» xá»­ lÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ005', {p2}, {d4}, N'XÃ©t nghiá»‡m sinh hÃ³a mÃ¡u', N'Äá»‹nh lÆ°á»£ng Glucose vÃ  Acid Uric', N'ThÆ°á»ng', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Chá» xá»­ lÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status) VALUES ('REQ006', {p4}, {d2}, N'Chá»¥p X-quang phá»•i', N'Ho kÃ©o dÃ i, nghi ngá» viÃªm phá»•i', N'ThÆ°á»ng', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}', N'Äang xá»­ lÃ½');");

                // Seed one completed request with PDF path
                string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);
                string dummyPdf = Path.Combine(uploadFolder, "sample_result.pdf");
                if (!File.Exists(dummyPdf)) File.WriteAllBytes(dummyPdf, new byte[] { 0x25, 0x50, 0x44, 0x46, 0x0A }); // dummy empty pdf header

                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Requests (RequestCode, PatientID, DoctorID, ServiceType, RequestNote, Priority, RequestDate, Status, ResultPDF) VALUES ('REQ003', {p1}, {d1}, N'XÃ©t nghiá»‡m mÃ¡u tá»•ng quÃ¡t', N'Kiá»ƒm tra cÃ´ng thá»©c mÃ¡u', N'ThÆ°á»ng', '{DateTime.Now.AddDays(-1):yyyy-MM-dd HH:mm:ss}', N'HoÃ n thÃ nh', '{dummyPdf.Replace("\\", "\\\\")}');");

                LogSeed("-> ÄÃ£ náº¡p 6 yÃªu cáº§u dá»‹ch vá»¥.");

                // Seed Shifts
                DateTime mon = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon:yyyy-MM-dd}', N'SÃ¡ng', N'PhÃ²ng khÃ¡m 101', N'Khoa Ná»™i', N'ÄÃ£ Ä‘Äƒng kÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(1):yyyy-MM-dd}', N'Chiá»u', N'PhÃ²ng khÃ¡m 102', N'Khoa Ná»™i', N'ÄÃ£ Ä‘Äƒng kÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(2):yyyy-MM-dd}', N'SÃ¡ng', N'PhÃ²ng khÃ¡m 201', N'Khoa Tim máº¡ch', N'ÄÃ£ Ä‘Äƒng kÃ½');");
                DatabaseHelper.ExecuteNonQuery($"INSERT INTO Shifts (ShiftDate, ShiftName, Room, Department, Status) VALUES ('{mon.AddDays(3):yyyy-MM-dd}', N'Chiá»u', N'PhÃ²ng khÃ¡m 103', N'Khoa Ná»™i', N'Chá» xÃ¡c nháº­n');");
                LogSeed("-> ÄÃ£ náº¡p 4 ca trá»±c hÃ ng tuáº§n cá»§a Ká»¹ thuáº­t viÃªn.");

                LogSeed("\n[HOÃ€N THÃ€NH] Khá»Ÿi táº¡o dá»¯ liá»‡u máº«u thÃ nh cÃ´ng! Báº¡n cÃ³ thá»ƒ sá»­ dá»¥ng cÃ¡c chá»©c nÄƒng cá»§a Ká»¹ thuáº­t viÃªn ngay láº­p tá»©c.");
                MessageBox.Show("ÄÃ£ náº¡p toÃ n bá»™ dá»¯ liá»‡u máº«u vÃ o SQL Server thÃ nh cÃ´ng!", "Seeder Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogSeed("\n[Lá»–I] Khá»Ÿi táº¡o dá»¯ liá»‡u tháº¥t báº¡i. Chi tiáº¿t lá»—i:");
                LogSeed(ex.ToString());
                MessageBox.Show("Seed dá»¯ liá»‡u tháº¥t báº¡i: " + ex.Message, "Lá»—i", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogSeed(string msg)
        {
            txtSeederLog.AppendText(msg + "\r\n");
        }

        // ==========================================

    }
}

