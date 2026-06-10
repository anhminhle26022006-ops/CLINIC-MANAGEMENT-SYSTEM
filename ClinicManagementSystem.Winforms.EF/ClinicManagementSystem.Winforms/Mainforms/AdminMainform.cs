using ClinicManagementSystem.Winforms.UserControls.Admin;
using DAL.Models;
using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class AdminMainform : Form
    {
        private readonly CMSDbContext _context;

        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);

        private UserDTO currentUser;
        private bool layoutReady;
        private Button activeNavButton;
        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public AdminMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public AdminMainform(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            currentUser = user ?? throw new ArgumentNullException(nameof(user));

            string displayName = string.IsNullOrWhiteSpace(user.Name) ? "Quản trị viên" : user.Name.Trim();
            string displayEmail = !string.IsNullOrWhiteSpace(user.Email) ? user.Email.Trim() : user.Username ?? "admin";

            lblUserName.Text = displayName;
            lblUserEmail.Text = displayEmail;
            lblAvatar.Text = displayName.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + displayName;
        }

        private void AdminMainform_Load(object sender, EventArgs e)
        {
            btnStatitics.Text = "Thống kê";
            btnAdvancedAnalysis.Text = "Quản lý tài khoản";

            btnNavOverview.Click += (s, ev) => ShowAdminControl(new ucAdminDashboard(_context), "Tổng quan", btnNavOverview);
            btnEmployeeManagement.Click += (s, ev) => ShowAdminControl(new ucEmployeeManagement(_context), "Quản lý nhân viên", btnEmployeeManagement);
            btnDepartmentManagement.Click += (s, ev) => ShowAdminControl(new ucDepartmentManagement(_context), "Quản lý chuyên khoa", btnDepartmentManagement);

            // SỬA DÒNG NÀY: thêm currentUser làm tham số thứ hai
            btnShiftManagement.Click += (s, ev) => ShowAdminControl(new ucShiftManagement(_context, currentUser), "Quản lý ca trực", btnShiftManagement);

            btnNavShifts.Click += (s, ev) => ShowAdminControl(new ucShiftRequestManagement(_context), "Ca làm việc", btnNavShifts);
            btnStatitics.Click += (s, ev) => ShowAdminControl(new ucAdminStatistics(_context), "Thống kê", btnStatitics);
            btnAdvancedAnalysis.Click += (s, ev) => ShowAdminControl(new ucUserManagement(_context), "Quản lý tài khoản", btnAdvancedAnalysis);

            btnLogout.Click += (s, ev) => LogoutRequested?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            ShowAdminControl(new ucAdminDashboard(_context), "Tổng quan", btnNavOverview);
        }

        private Button CreateSidebarButton(string text, Point location, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(214, 44),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 65, 81),
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += onClick;
            panelSidebar.Controls.Add(btn);
            return btn;
        }


        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400) return;
        }




        private void ShowAdminControl(UserControl control, string title, Button navButton)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
            contentPanel.ResumeLayout();

            lblPageTitle.Text = title;
            SetActiveNavButton(navButton);
        }

        private void ShowPlaceholder(string title, Button navButton)
        {
            var placeholder = new UserControl
            {
                BackColor = pageBack,
                Dock = DockStyle.Fill
            };

            placeholder.Controls.Add(new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = textMain,
                Location = new Point(32, 32),
                Text = title
            });

            ShowAdminControl(placeholder, title, navButton);
        }

        private void SetActiveNavButton(Button button)
        {
            if (activeNavButton != null)
            {
                activeNavButton.BackColor = Color.White;
                activeNavButton.ForeColor = Color.FromArgb(55, 65, 81);
            }

            activeNavButton = button;
            activeNavButton.BackColor = Color.FromArgb(239, 246, 255);
            activeNavButton.ForeColor = primary;
        }
    }
}


