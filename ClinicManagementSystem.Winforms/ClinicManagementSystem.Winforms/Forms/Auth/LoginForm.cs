using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using DTO;
using System.IO;
using System.Text.RegularExpressions;
using CMS.Core.Identity;
using CMS.Core.Session;

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
                    UserSession.Login(
                        user.UserID,
                        user.EmployeeID,
                        user.EmployeeUUID,
                        user.DepartmentID,
                        user.Username,
                        user.Name,
                        RoleNormalizer.Normalize(user.Role),
                        user.DepartmentName);

                    MainformRole dashboard = new MainformRole(user);
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
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connString)) return;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
            string dbName = builder.InitialCatalog;

            // 1. Try to create the database via master connection if missing.
            try
            {
                SqlConnectionStringBuilder masterBuilder = new SqlConnectionStringBuilder(connString);
                masterBuilder.InitialCatalog = "master";
                string masterConnStr = masterBuilder.ConnectionString;

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
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Database auto-creation on master skipped or failed: " + ex.Message);
            }

            // 2. Connect to the target DB and create tables if not exist.
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // Check if Roles table exists (new CMS schema)
                    bool hasRolesTable = false;
                    try
                    {
                        using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type in (N'U')", conn))
                        {
                            hasRolesTable = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        }
                    }
                    catch { }

                    if (dbName.Equals("CMS", StringComparison.OrdinalIgnoreCase))
                    {
                        if (!hasRolesTable)
                        {
                            // If CMS database exists but doesn't have the roles table, we try to run CMS.sql
                            string scriptPath = FindSqlScriptPath("CMS.sql");
                            if (!string.IsNullOrEmpty(scriptPath))
                            {
                                try
                                {
                                    ExecuteSqlScript(scriptPath, connString);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine("CMS.sql execution failed: " + ex.Message);
                                }
                            }
                        }
                    }

                    // Schema bootstrap is handled by CMS.sql. Avoid creating legacy demo tables
                    // such as Doctors, Requests, or TechnicianShifts because DAL/BUS now use the CMS schema.
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Target DB connection error: " + ex.Message);
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

        private string FindSqlScriptPath(string fileName)
        {
            string startPath = AppDomain.CurrentDomain.BaseDirectory;
            string current = startPath;
            for (int i = 0; i < 5; i++)
            {
                string path1 = System.IO.Path.Combine(current, fileName);
                if (System.IO.File.Exists(path1)) return path1;

                string path2 = System.IO.Path.Combine(current, "Database", fileName);
                if (System.IO.File.Exists(path2)) return path2;

                string path3 = System.IO.Path.Combine(current, "ClinicManagementSystem.Winforms", "Database", fileName);
                if (System.IO.File.Exists(path3)) return path3;

                string parent = System.IO.Path.GetDirectoryName(current);
                if (string.IsNullOrEmpty(parent) || parent == current) break;
                current = parent;
            }
            return null;
        }

        private void ExecuteSqlScript(string scriptPath, string connString)
        {
            if (!System.IO.File.Exists(scriptPath)) return;

            string scriptContent = System.IO.File.ReadAllText(scriptPath);

            // Split script into batches by 'GO'
            string[] batches = System.Text.RegularExpressions.Regex.Split(
                scriptContent,
                @"^\s*GO\s*$",
                System.Text.RegularExpressions.RegexOptions.Multiline | System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (string batch in batches)
                {
                    if (string.IsNullOrWhiteSpace(batch)) continue;

                    // Skip database creation commands to avoid errors
                    if (batch.Contains("CREATE DATABASE") || batch.Contains("USE "))
                    {
                        continue;
                    }

                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(batch, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("SQL Batch Error: " + ex.Message);
                    }
                }
            }
        }

    }
}

