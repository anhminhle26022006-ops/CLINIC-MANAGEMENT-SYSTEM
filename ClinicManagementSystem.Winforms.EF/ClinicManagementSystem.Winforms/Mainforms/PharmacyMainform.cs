using System;
using System.Drawing;
using System.Windows.Forms;
using CMS.Core.Identity;
using ClinicManagementSystem.Winforms.Shareforms.WorkingShifts;
using ClinicManagementSystem.Winforms.UserControls.Pharmacy;
using DTO;
using DAL.Models; // Thêm để dùng CMSDbContext

// Alias để tránh ambiguous reference
using RoleConst = CMS.Core.Identity.Role;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class PharmacyMainform : Form
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;

        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color navDefaultBack = Color.White;
        private readonly Color navDefaultFore = Color.FromArgb(55, 65, 81);
        private readonly Color navActiveBack = Color.FromArgb(239, 246, 255);

        private bool layoutReady;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public PharmacyMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public PharmacyMainform(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrWhiteSpace(user.Name) ? "D" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void PharmacyMainform_Load(object sender, EventArgs e)
        {
            txtGlobalSearch.Text = "  Tìm kiếm...";
            txtGlobalSearch.ForeColor = Color.FromArgb(148, 163, 184);

            btnLogout.Click += (s, ev) => LogoutRequested?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            ShowOverview();
        }

        private void btnNavOverview_Click(object sender, EventArgs e) => ShowOverview();
        private void btnNavPrescriptions_Click(object sender, EventArgs e) => ShowPrescriptions();
        private void btnNavMedicines_Click(object sender, EventArgs e) => ShowMedicines();
        private void btnNavInventory_Click(object sender, EventArgs e) => ShowInventory();
        private void btnNavShifts_Click(object sender, EventArgs e) => ShowShifts();

        private void txtGlobalSearch_Enter(object sender, EventArgs e)
        {
            if (txtGlobalSearch.Text.Trim() == "Tìm kiếm...")
            {
                txtGlobalSearch.Text = string.Empty;
                txtGlobalSearch.ForeColor = Color.FromArgb(17, 24, 39);
            }
        }

        private void txtGlobalSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGlobalSearch.Text))
            {
                txtGlobalSearch.Text = "  Tìm kiếm...";
                txtGlobalSearch.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400)
                return;
        }

        private void ShowOverview()
        {
            SetHeader("Tổng quan", "Xin chào, " + DisplayName());
            SetActiveNav(btnNavOverview);
            LoadContentView(new ucPharmacyOverview(_context, _currentUser));
        }

        private void ShowPrescriptions()
        {
            SetHeader("Toa thuốc", "Theo dõi toa chờ cấp phát và lịch sử cấp phát");
            SetActiveNav(btnNavPrescriptions);
            LoadContentView(new ucPrescriptionDispense(_context, _currentUser));
        }

        private void ShowMedicines()
        {
            SetHeader("Danh mục thuốc", "Quản lý danh sách thuốc và thông tin tồn kho");
            SetActiveNav(btnNavMedicines);
            LoadContentView(new ucMedicineCatalog(_context, _currentUser));
        }

        private void ShowInventory()
        {
            SetHeader("Quản lý kho", "Theo dõi nhập xuất, batch, hạn dùng và cảnh báo tồn kho");
            SetActiveNav(btnNavInventory);
            LoadContentView(new ucInventoryManagement(_context, _currentUser));
        }

        private void ShowShifts()
        {
            SetHeader("Ca làm việc", "Xem lịch làm việc và yêu cầu đổi ca");
            SetActiveNav(btnNavShifts);
            // Nếu RoleShiftCalendar có constructor 2 tham số, dùng như sau:
            var shiftControl = new RoleShiftCalendar(_currentUser, RoleConst.Pharmacist);
            // Nếu có constructor 3 tham số (context, user, role) thì dùng:
            // var shiftControl = new RoleShiftCalendar(_context, _currentUser, RoleConst.Pharmacist);
            LoadContentControl(shiftControl);
        }

        private void SetHeader(string title, string subtitle)
        {
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = subtitle;
        }

        private string DisplayName()
        {
            return _currentUser != null && !string.IsNullOrWhiteSpace(_currentUser.Name)
                ? _currentUser.Name
                : "Dược sĩ";
        }

        private void LoadContentView(PharmacyDashboardViewBase view)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            view.Initialize(_currentUser);
            view.Dock = DockStyle.Fill;
            view.NavigateRequested += ContentView_NavigateRequested;

            contentPanel.Controls.Add(view);
            contentPanel.ResumeLayout();
        }

        private void LoadContentControl(UserControl view)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);
            contentPanel.ResumeLayout();
        }

        private void ContentView_NavigateRequested(object sender, PharmacyNavigationEventArgs e)
        {
            switch (e.Target)
            {
                case PharmacyViewTarget.Prescriptions:
                    ShowPrescriptions();
                    break;
                case PharmacyViewTarget.Medicines:
                    ShowMedicines();
                    break;
                case PharmacyViewTarget.Inventory:
                    ShowInventory();
                    break;
                case PharmacyViewTarget.Shifts:
                    ShowShifts();
                    break;
                default:
                    ShowOverview();
                    break;
            }
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] buttons = { btnNavOverview, btnNavPrescriptions, btnNavMedicines, btnNavInventory, btnNavShifts };
            foreach (Button button in buttons)
            {
                button.BackColor = navDefaultBack;
                button.ForeColor = navDefaultFore;
            }
            activeButton.BackColor = navActiveBack;
            activeButton.ForeColor = primary;
        }
    }
}