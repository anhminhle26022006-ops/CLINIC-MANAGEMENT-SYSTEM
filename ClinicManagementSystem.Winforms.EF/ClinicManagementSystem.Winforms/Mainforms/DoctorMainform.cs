using BUS.Services;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.Shareforms;
using ClinicManagementSystem.Winforms.Shareforms.ERM;
using ClinicManagementSystem.Winforms.Shareforms.WorkingShifts;
using ClinicManagementSystem.Winforms.UserControls.Doctor;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription;
using CMS.Core.Identity;
using DAL;
using DAL.Models;
using DTO;
using DTO.Clinical.erm;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

// Alias để tránh nhầm lẫn giữa Role constants và Role entity
using RoleConst = CMS.Core.Identity.Role;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class DoctorMainform : Form
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;

        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private ucMedicalRecordSidebar ucERM;
        private RoleShiftCalendar shiftControl;

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly TechnicianRequestBUS requestBUS = new TechnicianRequestBUS();
        private readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();
        private readonly ApiSyncBUS apiSyncBUS = new ApiSyncBUS();

        private bool layoutReady;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public DoctorMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public DoctorMainform(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));

            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void DoctorMainform_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) => LogoutRequested?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            btnNavOverview.Click += (s, ev) => ShowOverview();
            btnSchedule.Click += (s, ev) => ShowAppointments();
            btnQueue.Click += (s, ev) => ShowExamination();
            btnERM.Click += (s, ev) => ShowERM();
            btnPharmacy.Click += (s, ev) => ShowPrescriptions();
            btnNavShifts.Click += (s, ev) => ShowShiftScreen();

            ShowOverview();
        }

        private async void btnSyncCloud_Click(object sender, EventArgs e)
        {
            await RunCloudSyncAsync();
        }

        private async System.Threading.Tasks.Task RunCloudSyncAsync()
        {
            btnSyncCloud.Enabled = false;
            string oldText = btnSyncCloud.Text;
            btnSyncCloud.Text = "Đang đồng bộ...";

            try
            {
                string resultMessage = await apiSyncBUS.SyncRequestsFromSupabaseAsync();
                MessageBox.Show(resultMessage, "Đồng bộ Doctor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (contentPanel.Controls.Count > 0)
                {
                    Control current = contentPanel.Controls[0];
                    if (current == ucERM)
                    {
                        ucERM = null;
                        ShowERM();
                    }
                    else if (current == shiftControl)
                    {
                        shiftControl = null;
                        ShowShiftScreen();
                    }
                    else
                    {
                        ShowOverview();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đồng bộ thất bại: " + ex.Message, "Đồng bộ Doctor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSyncCloud.Text = oldText;
                btnSyncCloud.Enabled = true;
            }
        }

        private void ShowERM()
        {
            lblPageTitle.Text = "Bệnh án";
            lblPageSubtitle.Text = "Tra cứu và cập nhật hồ sơ bệnh án của bệnh nhân";
            SetActiveNav(btnERM);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (ucERM == null)
            {
                ucERM = new ucMedicalRecordSidebar(_context, _currentUser);
                ucERM.Dock = DockStyle.Fill;
            }
            contentPanel.Controls.Add(ucERM);
            contentPanel.ResumeLayout();
        }

        private void ShowShiftScreen()
        {
            lblPageTitle.Text = "Ca làm việc";
            lblPageSubtitle.Text = "Lịch trực và thông tin phân ca của bác sĩ";
            SetActiveNav(btnNavShifts);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (shiftControl == null)
            {
                shiftControl = new RoleShiftCalendar(_context, _currentUser, RoleConst.Doctor);
                shiftControl.Dock = DockStyle.Fill;
            }
            contentPanel.Controls.Add(shiftControl);
            contentPanel.ResumeLayout();
        }

        private void ShowOverview()
        {
            lblPageTitle.Text = "Tổng quan";
            lblPageSubtitle.Text = "Xin chào, " + (_currentUser != null ? _currentUser.Name : "Bác sĩ");
            SetActiveNav(btnNavOverview);
            ShowControl(new doctordashboard(_context, _currentUser));
        }

        private void ShowAppointments()
        {
            lblPageTitle.Text = "Lịch khám";
            lblPageSubtitle.Text = "Danh sách lịch hẹn và bệnh nhân được phân công.";
            SetActiveNav(btnSchedule);
            ShowControl(new ucAppointmentSidebar(_context, _currentUser));
        }

        private void ShowExamination()
        {
            lblPageTitle.Text = "Khám bệnh";
            lblPageSubtitle.Text = "Xử lý hàng đợi khám, bệnh án, chỉ định và toa thuốc.";
            SetActiveNav(btnQueue);
            ShowControl(new ucDoctorExaminationSidebar(_context, _currentUser));
        }

        private void ShowPrescriptions()
        {
            lblPageTitle.Text = "Toa thuốc";
            lblPageSubtitle.Text = "Theo dõi toa thuốc đã kê và trạng thái cấp phát.";
            SetActiveNav(btnPharmacy);
            ShowControl(new ucPrescriptionSidebar(_context, _currentUser));
        }

        private void ShowControl(Control control)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
            contentPanel.ResumeLayout();
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] buttons = { btnNavOverview, btnSchedule, btnQueue, btnERM, btnPharmacy, btnNavShifts };
            foreach (Button button in buttons)
            {
                if (button == null) continue;
                button.BackColor = Color.White;
                button.ForeColor = Color.FromArgb(55, 65, 81);
            }
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(239, 246, 255);
                activeButton.ForeColor = primary;
            }
        }
        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400) return;
            // Không cần xử lý thêm, chỉ để tránh lỗi
        }

        // Các phương thức phụ trợ (CreateSidebarButton, contentPanel_Resize, ShowOverviewPlaceholder, ShowSection, CreateLabel)
        // giữ nguyên như cũ, không thay đổi.
    }
}