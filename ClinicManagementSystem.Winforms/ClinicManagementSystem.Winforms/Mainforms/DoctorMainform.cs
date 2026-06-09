﻿using BUS.Services;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.Shareforms;
using ClinicManagementSystem.Winforms.Shareforms.ERM;
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

        private doctordashboard ucDashboard;
        private ucMedicalRecordSidebar ucERM;
        private ucAppointmentSidebar ucAppointment;
        private ucDoctorExaminationSidebar ucExamination;
        private ucPrescriptionSidebar ucPrescription;

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly TechnicianRequestBUS requestBUS = new TechnicianRequestBUS();
        private readonly TechnicianShiftBUS shiftBUS = new TechnicianShiftBUS();
        private UserDTO currentUser;
        private bool layoutReady;

        private Shift shiftControl;

        // Custom Navigation Buttons
        private Button btnERM;

        // Active request for processing transitions

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
            btnSchedule.Click += (s, ev) => ShowAppointment();
            btnQueue.Click += (s, ev) => ShowExamination();
            btnERM.Click += (s, ev) => ShowERM();
            btnPharmacy.Click += (s, ev) => ShowPrescription();
            btnNavShifts.Click += (s, ev) => ShowShiftScreen();

            ShowOverview();
        }
        private void ShowExamination()
        {
            lblPageTitle.Text = "Khám bệnh";
            lblPageSubtitle.Text = "Khám bệnh, kê toa, xét nghiệm và chẩn đoán hình ảnh";

            SetActiveNav(btnQueue);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (ucExamination == null)
            {
                ucExamination = new ucDoctorExaminationSidebar();
                ucExamination.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(ucExamination);

            contentPanel.ResumeLayout();
        }
        private void ShowAppointment()
        {
            lblPageTitle.Text = "Lịch khám";
            lblPageSubtitle.Text = "Quản lý lịch khám bệnh nhân";

            SetActiveNav(btnSchedule);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (ucAppointment == null)
            {
                ucAppointment = new ucAppointmentSidebar();
                ucAppointment.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(ucAppointment);

            contentPanel.ResumeLayout();
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
                ucERM = new ucMedicalRecordSidebar();
                ucERM.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(ucERM);

            contentPanel.ResumeLayout();
        }
        private void ShowPrescription()
        {
            lblPageTitle.Text = "Toa thuốc";
            lblPageSubtitle.Text = "Xem lại lịch sử toa thuốc đã kê";

            SetActiveNav(btnPharmacy);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (ucPrescription == null)
            {
                ucPrescription = new ucPrescriptionSidebar();
                ucPrescription.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(ucPrescription);

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
                shiftControl = new Shift();
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
            lblPageSubtitle.Text = "Dashboard bác sĩ";

            SetActiveNav(btnNavOverview);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            if (ucDashboard == null)
            {
                ucDashboard = new doctordashboard();
                ucDashboard.Dock = DockStyle.Fill;
            }

            contentPanel.Controls.Add(ucDashboard);

            contentPanel.ResumeLayout();
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


