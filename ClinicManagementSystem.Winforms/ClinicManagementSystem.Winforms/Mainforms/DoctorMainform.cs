﻿using BUS.Services;
using CMS.Core.Identity;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.Shareforms;
using ClinicManagementSystem.Winforms.Shareforms.ERM;
using ClinicManagementSystem.Winforms.Shareforms.WorkingShifts;
using ClinicManagementSystem.Winforms.UserControls.Doctor;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription;
using DAL;
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

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class DoctorMainform : Form
    {
        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private ucMedicalRecordSidebar ucERM;

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly TechnicianRequestBUS requestBUS = new TechnicianRequestBUS();
        private readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();
        private readonly ApiSyncBUS apiSyncBUS = new ApiSyncBUS();
        private UserDTO currentUser;
        private bool layoutReady;

        private RoleShiftCalendar shiftControl;

        private Button btnERM;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public DoctorMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public DoctorMainform(UserDTO user) : this()
        {
            this.currentUser = user;
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void DoctorMainform_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

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
                ucERM = new ucMedicalRecordSidebar(currentUser);
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
                shiftControl = new RoleShiftCalendar(currentUser, Role.Doctor);
                shiftControl.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(shiftControl);

            contentPanel.ResumeLayout();
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

        private void ShowOverview()
        {
            lblPageTitle.Text = "Tổng quan";
            lblPageSubtitle.Text = "Xin chào, " + (currentUser != null ? currentUser.Name : "Bác sĩ");
            SetActiveNav(btnNavOverview);
            ShowControl(new doctordashboard(currentUser));
        }

        private void ShowAppointments()
        {
            lblPageTitle.Text = "Lịch khám";
            lblPageSubtitle.Text = "Danh sách lịch hẹn và bệnh nhân được phân công.";
            SetActiveNav(btnSchedule);
            ShowControl(new ucAppointmentSidebar(currentUser));
        }

        private void ShowExamination()
        {
            lblPageTitle.Text = "Khám bệnh";
            lblPageSubtitle.Text = "Xử lý hàng đợi khám, bệnh án, chỉ định và toa thuốc.";
            SetActiveNav(btnQueue);
            ShowControl(new ucDoctorExaminationSidebar(currentUser));
        }

        private void ShowPrescriptions()
        {
            lblPageTitle.Text = "Toa thuốc";
            lblPageSubtitle.Text = "Theo dõi toa thuốc đã kê và trạng thái cấp phát.";
            SetActiveNav(btnPharmacy);
            ShowControl(new ucPrescriptionSidebar(currentUser));
        }

        private void ShowControl(Control control)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
            contentPanel.ResumeLayout();
        }

        private void ShowOverviewPlaceholder()
        {
            ShowSection(
                "Tổng quan",
                "Xin chào, " + (currentUser != null ? currentUser.Name : "Bác sĩ"),
                btnNavOverview,
                "Bệnh nhân chờ khám: đang cập nhật",
                "Lịch khám hôm nay: đang cập nhật",
                "Hồ sơ cần cập nhật: đang cập nhật");
        }

        private void ShowSection(string title, string subtitle, Button activeButton, params string[] lines)
        {
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = subtitle;
            SetActiveNav(activeButton);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            Panel container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = pageBack,
                Padding = new Padding(28)
            };

            Label titleLabel = CreateLabel(title, 20F, FontStyle.Bold, textMain, DockStyle.Top, 44);
            Label subtitleLabel = CreateLabel(subtitle, 10.5F, FontStyle.Regular, textMuted, DockStyle.Top, 34);

            Panel body = new Panel
            {
                Dock = DockStyle.Top,
                Height = 190,
                BackColor = surface,
                Padding = new Padding(24),
                Margin = new Padding(0, 16, 0, 0)
            };

            int top = 18;
            foreach (string line in lines)
            {
                Label item = new Label
                {
                    AutoSize = false,
                    Text = "- " + line,
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = textMain,
                    Location = new Point(24, top),
                    Size = new Size(Math.Max(300, contentPanel.Width - 120), 28)
                };
                body.Controls.Add(item);
                top += 36;
            }

            container.Controls.Add(body);
            container.Controls.Add(subtitleLabel);
            container.Controls.Add(titleLabel);
            contentPanel.Controls.Add(container);
            contentPanel.ResumeLayout();
        }

        private Label CreateLabel(string text, float size, FontStyle style, Color color, DockStyle dock, int height)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                Dock = dock,
                Height = height,
                AutoEllipsis = true
            };
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] buttons =
            {
                btnNavOverview,
                btnSchedule,
                btnQueue,
                btnERM,
                btnPharmacy,
                btnNavShifts
            };

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

    }
}


