using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BUS.Services;
using CMS.Core.Identity;
using CMS.Core.Session;
using DAL.Models;
using DTO;
using Microsoft.Data.SqlClient;
using FileIO = System.IO.File; // Alias để tránh nhầm với DAL.Models.File

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserBUS _userBUS;

        public LoginForm()
        {
            InitializeComponent();
            // Khởi tạo UserBUS với DbContext (có thể dùng chung một context cho toàn form)
            var context = new CMSDbContext();
            _userBUS = new UserBUS(context);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
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
                UserDTO user = _userBUS.Login(username, password);

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

                    // Tạo DbContext riêng cho MainformRole (đảm bảo không dùng chung)
                    using (var dbContext = new CMSDbContext())
                    {
                        MainformRole dashboard = new MainformRole(dbContext, user);
                        this.Hide();
                        dashboard.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    ShowError("Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            catch (SqlException)
            {
                ShowError("Không thể kết nối đến SQL Server. Vui lòng kiểm tra lại cấu hình App.config hoặc chạy SQL Server.");
                var result = MessageBox.Show(
                    "Không kết nối được SQL Server. Bạn có muốn chạy chương trình mà không có database (sử dụng chế độ Demo tự tạo database tự động trên LocalDB hoặc SQL Server)?",
                    "Lỗi Kết Nối Cơ Sở Dữ Liệu",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
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
            string connString = ConfigurationManager.ConnectionStrings["DbConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(connString)) return;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connString);
            string dbName = builder.InitialCatalog;

            try
            {
                SqlConnectionStringBuilder masterBuilder = new SqlConnectionStringBuilder(connString);
                masterBuilder.InitialCatalog = "master";
                string masterConnStr = masterBuilder.ConnectionString;

                using (SqlConnection masterConn = new SqlConnection(masterConnStr))
                {
                    masterConn.Open();
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

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
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
                    // Continue
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
                if (FileIO.Exists(path1)) return path1;

                string path2 = System.IO.Path.Combine(current, "Database", fileName);
                if (FileIO.Exists(path2)) return path2;

                string path3 = System.IO.Path.Combine(current, "ClinicManagementSystem.Winforms", "Database", fileName);
                if (FileIO.Exists(path3)) return path3;

                string parent = System.IO.Path.GetDirectoryName(current);
                if (string.IsNullOrEmpty(parent) || parent == current) break;
                current = parent;
            }
            return null;
        }

        private void ExecuteSqlScript(string scriptPath, string connString)
        {
            if (!FileIO.Exists(scriptPath)) return;

            string scriptContent = FileIO.ReadAllText(scriptPath);
            string[] batches = Regex.Split(
                scriptContent,
                @"^\s*GO\s*$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                foreach (string batch in batches)
                {
                    if (string.IsNullOrWhiteSpace(batch)) continue;
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