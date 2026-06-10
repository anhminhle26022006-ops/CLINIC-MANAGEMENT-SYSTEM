using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using CMS.Core.Identity;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.Controllers;
using ClinicManagementSystem.Winforms.Shareforms.WorkingShifts;
using ClinicManagementSystem.Winforms.UserControls;
using ClinicManagementSystem.Winforms.UserControls.reception;
using DAL;
using DAL.Models;
using DTO;
using Newtonsoft.Json.Linq;

// Alias
using RoleConst = CMS.Core.Identity.Role;
// Alias cho UserControl ReceptionPayment để tránh nhầm với DAL.Models.Payment
using ReceptionPayment = ClinicManagementSystem.Winforms.UserControls.reception.Payment;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class ReceptionistMainform : Form
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
        private readonly ApiSyncBUS apiSyncBUS = new ApiSyncBUS();

        private bool layoutReady;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public ReceptionistMainform()
        {
            InitializeComponent();
            layoutReady = true;
            btnNavOverview.Click += btnNavOverview_Click;
            btnNavShifts.Click += btnNavShifts_Click;
        }

        public ReceptionistMainform(CMSDbContext context, UserDTO user) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = user ?? throw new ArgumentNullException(nameof(user));

            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private async void ReceptionistMainform_Load(object sender, EventArgs e)
        {
            try
            {
                await apiSyncBUS.SyncAsync();
                ReceptionDemoDataSeeder.EnsureSeeded();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            btnLogout.Click += (s, ev) => LogoutRequested?.Invoke(this, EventArgs.Empty);
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            LoadContent(new ReceptionOverview());
        }

        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400) return;
        }

        private void LoadContent(UserControl control)
        {
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);

            lblPageTitle.Text = control switch
            {
                ReceptionOverview => "Tổng quan",
                PatientManagement => "Quản lý bệnh nhân",
                CreateAppointment => "Đặt lịch khám",
                ReceptionPayment => "Thanh toán",
                ScheduleToday => "Lịch khám hôm nay",
                WaitingList => "Hàng chờ khám",
                RemindingList => "Nhắc lịch tái khám",
                RoleShiftCalendar => "Ca làm việc",
                _ => "Clinic Management System"
            };

            lblPageSubtitle.Text = control switch
            {
                ReceptionOverview => "Tình hình tiếp nhận trong ngày",
                PatientManagement => "Quản lý bệnh nhân",
                CreateAppointment => "Tạo lịch hẹn",
                ScheduleToday => "Lịch hẹn hôm nay",
                ReceptionPayment => "Thanh toán viện phí và PayOS",
                RemindingList => "Nhắc lịch tái khám",
                RoleShiftCalendar => "Ca làm việc lễ tân",
                _ => "Clinic Management System"
            };
        }

        private void btnNavOverview_Click(object sender, EventArgs e)
        {
            LoadContent(new ReceptionOverview());
        }

        private void btnPatientManagement_Click(object sender, EventArgs e)
        {
            LoadContent(new PatientManagement());
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            LoadContent(new CreateAppointment());
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            LoadContent(new ReceptionPayment());
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            LoadContent(new ScheduleToday());
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            LoadContent(new WaitingList());
        }

        private void btnReminder_Click(object sender, EventArgs e)
        {
            LoadContent(new RemindingList());
        }

        private void btnNavShifts_Click(object sender, EventArgs e)
        {
            // RoleShiftCalendar chỉ có constructor (UserDTO, string role)
            var shiftControl = new RoleShiftCalendar(_currentUser, RoleConst.Receptionist);
            LoadContent(shiftControl);
        }
    }
}