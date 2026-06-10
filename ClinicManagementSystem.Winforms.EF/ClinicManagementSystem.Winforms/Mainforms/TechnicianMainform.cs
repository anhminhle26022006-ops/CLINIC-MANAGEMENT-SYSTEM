using BUS.Services;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.Shareforms.WorkingShifts;
using ClinicManagementSystem.Winforms.UserControls.Technician;
using CMS.Core.Identity;
using DAL;
using DAL.Models;
using DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
// Alias để tránh nhầm lẫn Role
using RoleConst = CMS.Core.Identity.Role;

namespace ClinicManagementSystem.Winforms.UserControls
{
    public partial class TechnicianMainform : Form
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;

        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly TechnicianRequestBUS requestBUS = new TechnicianRequestBUS();
        private readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();
        private UserDTO currentUser;
        private bool layoutReady;



        // Active request for processing transitions
        private int activeRequestId = 0;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public TechnicianMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public TechnicianMainform(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void ucTechnicianDashboard_Load(object sender, EventArgs e)
        {
            txtGlobalSearch.Text = "  Tìm kiếm...";
            txtGlobalSearch.ForeColor = Color.FromArgb(148, 163, 184);

            // Set Log Out click handler
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            // Close button click handler
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            ShowOverview();
        }

        private void btnNavOverview_Click(object sender, EventArgs e) => ShowOverview();
        private void btnNavRequests_Click(object sender, EventArgs e) => ShowRequests();
        private void btnNavUploadMRI_Click(object sender, EventArgs e) => ShowUploadMRI();
        private void btnNavUploadPDF_Click(object sender, EventArgs e) => ShowUploadPDF();
        private void btnNavLabResult_Click(object sender, EventArgs e) => ShowLabResult();
        private void btnNavRecords_Click(object sender, EventArgs e) => ShowRecords();
        private void btnNavShifts_Click(object sender, EventArgs e) => ShowShifts();
        private void btnNavSeederTool_Click(object sender, EventArgs e) => ShowSeederTool();

        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400) return;
        }

        private void ShowOverview()
        {
            lblPageTitle.Text = "Tổng quan";
            lblPageSubtitle.Text = "Xin chào, " + (currentUser != null ? currentUser.Name : "Kỹ thuật viên");
            SetActiveNav(btnNavOverview);
            LoadContentView(new ucTechnicianOverview());
        }

        private void ShowRequests()
        {
            lblPageTitle.Text = "Xét nghiệm";
            lblPageSubtitle.Text = "Quản lý yêu cầu xét nghiệm và chụp ảnh từ Bác sĩ";
            SetActiveNav(btnNavRequests);
            LoadContentView(new ucTechnicianRequests());
        }

        private void ShowUploadMRI(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Tải lên MRI/X-Ray";
            lblPageSubtitle.Text = "Lưu và upload hình ảnh phim chụp của bệnh nhân";
            SetActiveNav(btnNavUploadMRI);
            LoadContentView(new ucTechnicianUploadMri(), preselectedId);
        }

        private void ShowUploadPDF(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Tải lên kết quả PDF";
            lblPageSubtitle.Text = "Upload tệp PDF kết quả xét nghiệm tổng hợp";
            SetActiveNav(btnNavUploadPDF);
            LoadContentView(new ucTechnicianUploadPdf(), preselectedId);
        }

        private void ShowLabResult(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Nhập kết quả Lab";
            lblPageSubtitle.Text = "Nhập chỉ số xét nghiệm sinh hóa chi tiết";
            SetActiveNav(btnNavLabResult);
            LoadContentView(new ucTechnicianLabResult(), preselectedId);
        }

        private void ShowShifts()
        {
            lblPageTitle.Text = "Ca làm việc";
            lblPageSubtitle.Text = "Quản lý lịch trình làm việc và lịch trực";
            SetActiveNav(btnNavShifts);
            LoadContentControl(new RoleShiftCalendar(_currentUser, RoleConst.Technician));
        }

        private void ShowRecords(int preselectedRequestId = 0)
        {
            lblPageTitle.Text = "Hồ sơ bệnh án";
            lblPageSubtitle.Text = "Tìm kiếm hồ sơ bệnh nhân và lịch sử kết quả xét nghiệm";
            SetActiveNav(btnNavRecords);
            LoadContentView(new ucPatientRecords(), preselectedRequestId);
        }

        private void ShowSeederTool()
        {
            lblPageTitle.Text = "Seeder Tool";
            lblPageSubtitle.Text = "Công cụ tạo dữ liệu mẫu cho SQL Server";
            SetActiveNav(btnNavSeederTool);
            LoadContentView(new ucSeederTool());
        }

        private void LoadContentView(TechnicianDashboardViewBase view, int requestId = 0)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            view.Initialize(currentUser, requestId);
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

        private void ContentView_NavigateRequested(object sender, TechnicianNavigationEventArgs e)
        {
            switch (e.Target)
            {
                case TechnicianViewTarget.Requests:
                    ShowRequests();
                    break;
                case TechnicianViewTarget.UploadMRI:
                    ShowUploadMRI(e.RequestId);
                    break;
                case TechnicianViewTarget.UploadPDF:
                    ShowUploadPDF(e.RequestId);
                    break;
                case TechnicianViewTarget.LabResult:
                    ShowLabResult(e.RequestId);
                    break;
                case TechnicianViewTarget.Shifts:
                    ShowShifts();
                    break;
                case TechnicianViewTarget.Records:
                    ShowRecords(e.RequestId);
                    break;
                case TechnicianViewTarget.SeederTool:
                    ShowSeederTool();
                    break;
                default:
                    ShowOverview();
                    break;
            }
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] buttons = {
                btnNavOverview, btnNavRequests, btnNavUploadMRI, btnNavUploadPDF,
                btnNavLabResult, btnNavRecords, btnNavShifts, btnNavSeederTool
            };

            foreach (Button button in buttons)
            {
                if (button != null)
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.FromArgb(55, 65, 81);
                }
            }

            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(239, 246, 255);
                activeButton.ForeColor = primary;
            }
        }

    }
}

