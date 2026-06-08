using System;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using ClinicManagementSystem.Winforms.UserControls.Admin;
using DTO;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class AdminMainform : Form
    {
        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private UserDTO currentUser;
        private bool layoutReady;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public AdminMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public AdminMainform(UserDTO user) : this()
        {
            currentUser = user;
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "A" : user.Name[0].ToString().ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void ucTechnicianDashboard_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) => LogoutRequested?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            btnNavOverview.Click += (s, ev) => ShowDashboard();
            btnEmployeeManagement.Click += (s, ev) => LoadPage(new ucEmployeeManagement(), "Quản lý nhân viên");
            btnUserManagement.Click += (s, ev) => LoadPage(new ucUserManagement(), "Quản lý tài khoản");
            btnDepartmentManagement.Click += (s, ev) => LoadPage(new ucDepartmentManagement(), "Quản lý chuyên khoa");
            btnNavShifts.Click += (s, ev) => LoadPage(new ucShiftManagement(), "Ca làm việc");
            btnShiftManagement.Click += (s, ev) => LoadPage(new ucShiftRequestManagement(), "Quản lý ca trực");
            btnStatitics.Click += (s, ev) => ShowStatistics();
            btnAdvancedAnalysis.Click += (s, ev) => ShowAdvanced();

            ShowDashboard();
        }

        // ── Navigation ──────────────────────────────────────────────
        private void ShowDashboard()
        {
            lblPageTitle.Text = "Tổng quan";
            lblPageSubtitle.Text = "Xin chào, " + (currentUser?.Name ?? "Quản trị viên");
            SetActiveNav(btnNavOverview);
            LoadContent(new ucAdminDashboard());
        }

        private void ShowStatistics()
        {
            lblPageTitle.Text = "Thống kê";
            lblPageSubtitle.Text = "Báo cáo và số liệu thống kê hệ thống";
            SetActiveNav(btnStatitics);
            LoadContent(BuildStatisticsPanel());
        }

        private void ShowAdvanced()
        {
            lblPageTitle.Text = "Phân tích nâng cao";
            lblPageSubtitle.Text = "Phân tích dữ liệu chuyên sâu";
            SetActiveNav(btnAdvancedAnalysis);
            LoadContent(BuildComingSoonPanel("Phân tích nâng cao – sắp ra mắt"));
        }

        private void LoadPage(UserControl uc, string title)
        {
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = "";
            SetActiveNav(GetNavButton(title));
            LoadContent(uc);
        }

        private void LoadContent(Control ctrl)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            ctrl.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(ctrl);
            contentPanel.ResumeLayout();
        }

        private Button GetNavButton(string title) => title switch
        {
            "Quản lý nhân viên" => btnEmployeeManagement,
            "Quản lý tài khoản" => btnUserManagement,
            "Quản lý chuyên khoa" => btnDepartmentManagement,
            "Ca làm việc" => btnNavShifts,
            "Quản lý ca trực" => btnShiftManagement,
            _ => null
        };

        private void SetActiveNav(Button active)
        {
            Button[] all = {
                btnNavOverview, btnEmployeeManagement, btnUserManagement,
                btnDepartmentManagement, btnNavShifts, btnStatitics,
                btnShiftManagement, btnAdvancedAnalysis
            };
            foreach (var b in all)
            {
                if (b == null) continue;
                b.BackColor = Color.White;
                b.ForeColor = Color.FromArgb(55, 65, 81);
            }
            if (active != null)
            {
                active.BackColor = Color.FromArgb(239, 246, 255);
                active.ForeColor = primary;
            }
        }

        private void contentPanel_Resize(object sender, EventArgs e) { }

        private void btnDepartmentManagement_Click(object sender, EventArgs e)
        {
            // Handled via Load event above; kept to satisfy Designer
        }

        // ── Statistics panel (inline) ────────────────────────────────
        private Panel BuildStatisticsPanel()
        {
            var outer = new Panel { Dock = DockStyle.Fill, BackColor = pageBack, Padding = new Padding(30, 20, 30, 20) };

            // Quick stat cards pulled live
            var bus = new EmployeeBUS();
            var deptBus = new DepartmentBUS();
            var employees = bus.GetAll();
            int totalEmp = employees.Count, activeEmp = 0, doctor = 0, nurse = 0, pharma = 0;
            foreach (var e in employees)
            {
                if (e.Status == "Active") activeEmp++;
                switch (e.RoleName)
                {
                    case "Doctor": doctor++; break;
                    case "Nurse": nurse++; break;
                    case "Pharmacist": pharma++; break;
                }
            }
            int totalDept = deptBus.GetAll().Count;

            var grid = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 150,
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false
            };

            grid.Controls.Add(StatCard("Tổng nhân viên", totalEmp.ToString(), Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254)));
            grid.Controls.Add(StatCard("Đang làm việc", activeEmp.ToString(), Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229)));
            grid.Controls.Add(StatCard("Bác sĩ", doctor.ToString(), Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254)));
            grid.Controls.Add(StatCard("Y tá / Điều dưỡng", nurse.ToString(), Color.FromArgb(234, 88, 12), Color.FromArgb(255, 237, 213)));
            grid.Controls.Add(StatCard("Chuyên khoa", totalDept.ToString(), Color.FromArgb(219, 39, 119), Color.FromArgb(252, 231, 243)));

            outer.Controls.Add(grid);
            outer.Controls.Add(new Label
            {
                Text = "Thống kê nhân sự",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Top,
                Height = 44
            });
            return outer;
        }

        private Panel StatCard(string title, string value, Color accent, Color bg)
        {
            var p = new Panel { Size = new Size(180, 110), BackColor = bg, Margin = new Padding(0, 0, 16, 0) };
            p.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 8.5F), ForeColor = accent, Location = new Point(14, 14), AutoSize = true });
            p.Controls.Add(new Label { Text = value, Font = new Font("Segoe UI", 26F, FontStyle.Bold), ForeColor = accent, Location = new Point(14, 36), AutoSize = true });
            return p;
        }

        private Panel BuildComingSoonPanel(string msg)
        {
            var p = new Panel { Dock = DockStyle.Fill, BackColor = pageBack };
            p.Controls.Add(new Label
            {
                Text = msg,
                Font = new Font("Segoe UI", 14F),
                ForeColor = textMuted,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            });
            return p;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}