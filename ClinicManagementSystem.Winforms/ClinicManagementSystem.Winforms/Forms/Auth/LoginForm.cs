using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserBUS userBUS = new UserBUS();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Auto initialize database if missing
            AutoInitializeDatabase();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            lblError.Visible = false;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowError("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            try
            {
                UserDTO user = userBUS.Login(username, password);

                if (user != null)
                {
                    // Open Dashboard Form which dynamically hosts the correct role control
                    TechnicianDashboardForm dashboard = new TechnicianDashboardForm(user);
                    this.Hide();
                    dashboard.ShowDialog();
                    this.Close();
                }
                else
                {
                    ShowError("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            catch (SqlException)
            {
                // SQL Server connection error
                ShowError("Không thể kết nối đến SQL Server. Vui lòng kiểm tra lại cấu hình App.config hoặc chạy SQL Server.");
                var result = MessageBox.Show(
                    "Không kết nối được SQL Server. Bạn có muốn chạy chương trình mà không có database (sử dụng chế độ Demo tự tạo database tự động trên LocalDB hoặc SQL Server)?",
                    "Lỗi Kết Nối Cơ Sở Dữ Liệu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Attempt to auto-create database if possible, or run mock setup
                    TryCreateLocalDatabase();
                }
            }
            catch (Exception ex)
            {
                ShowError("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
        }

        private void AutoInitializeDatabase()
        {
            // Run in background / quietly check if connection works and users table exists.
            // If the database connection works, but tables are missing, we will create them.
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString;
                if (string.IsNullOrEmpty(connString)) return;

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
                string dbName = builder.InitialCatalog;
                builder.InitialCatalog = "master";
                string masterConnStr = builder.ConnectionString;

                using (SqlConnection masterConn = new SqlConnection(masterConnStr))
                {
                    masterConn.Open();
                    // Create DB if not exists
                    string createDbQuery = $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{dbName}') CREATE DATABASE [{dbName}];";
                    using (SqlCommand cmd = new SqlCommand(createDbQuery, masterConn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Now connect to target DB and create tables if not exist
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Create Users table
                    string createUsersTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Users] (
                                [UserID] INT IDENTITY(1,1) PRIMARY KEY,
                                [Username] VARCHAR(100) NOT NULL UNIQUE,
                                [Password] VARCHAR(100) NOT NULL,
                                [Name] NVARCHAR(100) NOT NULL,
                                [Role] VARCHAR(50) NOT NULL,
                                [Email] VARCHAR(100) NULL
                            );
                            -- Insert seed technician and admin
                            INSERT INTO [dbo].[Users] (Username, Password, Name, Role, Email) VALUES ('ktv', '123', N'Lữ Võ Hoàng Phúc', 'Technician', 'tech@phongkham.vn');
                            INSERT INTO [dbo].[Users] (Username, Password, Name, Role, Email) VALUES ('admin', 'admin123', N'Quản Trị Viên', 'Admin', 'admin@phongkham.vn');
                            INSERT INTO [dbo].[Users] (Username, Password, Name, Role, Email) VALUES ('bacsi', '123', N'Bác sĩ Nguyễn Văn Minh', 'Doctor', 'doctor@phongkham.vn');
                        END";
                    using (SqlCommand cmd = new SqlCommand(createUsersTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Patients
                    string createPatientsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Patients]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Patients] (
                                [PatientID] INT IDENTITY(1,1) PRIMARY KEY,
                                [PatientCode] VARCHAR(50) NOT NULL UNIQUE,
                                [Name] NVARCHAR(100) NOT NULL,
                                [BirthDate] DATE NOT NULL,
                                [Gender] NVARCHAR(20) NOT NULL,
                                [Phone] VARCHAR(20) NULL,
                                [Address] NVARCHAR(250) NULL
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createPatientsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Doctors
                    string createDoctorsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Doctors]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Doctors] (
                                [DoctorID] INT IDENTITY(1,1) PRIMARY KEY,
                                [DoctorCode] VARCHAR(50) NOT NULL UNIQUE,
                                [Name] NVARCHAR(100) NOT NULL,
                                [Department] NVARCHAR(100) NOT NULL
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createDoctorsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create Requests
                    string createRequestsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Requests]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[Requests] (
                                [RequestID] INT IDENTITY(1,1) PRIMARY KEY,
                                [RequestCode] VARCHAR(50) NOT NULL UNIQUE,
                                [PatientID] INT NOT NULL,
                                [DoctorID] INT NOT NULL,
                                [ServiceType] NVARCHAR(100) NOT NULL,
                                [RequestNote] NVARCHAR(500) NULL,
                                [Priority] NVARCHAR(50) NOT NULL DEFAULT N'Thường',
                                [RequestDate] DATETIME NOT NULL DEFAULT GETDATE(),
                                [Status] NVARCHAR(50) NOT NULL DEFAULT N'Chờ xử lý',
                                [ResultFile] VARCHAR(500) NULL,
                                [ResultPDF] VARCHAR(500) NULL,
                                [LabValues] NVARCHAR(MAX) NULL
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createRequestsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create TechnicianShifts
                    string createShiftsTable = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TechnicianShifts]') AND type in (N'U'))
                        BEGIN
                            CREATE TABLE [dbo].[TechnicianShifts] (
                                [ShiftID] INT IDENTITY(1,1) PRIMARY KEY,
                                [ShiftDate] DATE NOT NULL,
                                [ShiftName] NVARCHAR(50) NOT NULL,
                                [Room] NVARCHAR(50) NOT NULL,
                                [Department] NVARCHAR(100) NOT NULL,
                                [Status] NVARCHAR(50) NOT NULL DEFAULT N'Đã đăng ký',
                                [TechnicianName] NVARCHAR(100) NOT NULL DEFAULT N'Lữ Võ Hoàng Phúc'
                            );
                        END";
                    using (SqlCommand cmd = new SqlCommand(createShiftsTable, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                // Silent catch, user will see error on login if database connection still fails.
            }
        }

        private void TryCreateLocalDatabase()
        {
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connString)) return;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
            string dbName = builder.InitialCatalog;

            // Try connecting to master on SQLEXPRESS or default instance to create DB and tables
            string[] instances = new string[] {
                "Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;",
                "Server=.\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;"
            };
            foreach (var inst in instances)
            {
                try
                {
                    using (SqlConnection masterConn = new SqlConnection(inst))
                    {
                        masterConn.Open();
                        string createDbQuery = $"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{dbName}') CREATE DATABASE [{dbName}];";
                        using (SqlCommand cmd = new SqlCommand(createDbQuery, masterConn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show($"Đã tự động cấu hình và tạo cơ sở dữ liệu {dbName} thành công trên SQL Server!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AutoInitializeDatabase();
                    return;
                }
                catch
                {
                    // Continue trying next instance
                }
            }
        }

    }
}

