﻿using BUS.Services;
using ClinicManagementSystem.Winforms;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.UserControls.Nurse;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class NurseMainform : Form
    {
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

        // Custom Navigation Buttons
        private Button btnERM;

        // Active request for processing transitions

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public NurseMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public NurseMainform(UserDTO user) : this()
        {
            currentUser = user;
            string displayName = string.IsNullOrWhiteSpace(user?.Name) ? "Y tá" : user.Name.Trim();
            string displayEmail = !string.IsNullOrWhiteSpace(user?.Email)
                ? user.Email.Trim()
                : user?.Username ?? "nurse";

            lblUserName.Text = displayName;
            lblUserEmail.Text = displayEmail;
            lblAvatar.Text = displayName.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + displayName;
        }

        private void NurseMainform_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            btnNavOverview.Click += (s, ev) => ShowNurseControl(new ucNurseOverview(), "Tổng quan", btnNavOverview);
            btnQueue.Click += (s, ev) => ShowNurseControl(new ucQueueManagement(), "Hàng chờ khám", btnQueue);
            btnVitalSigns.Click += (s, ev) => ShowNurseControl(new ucNurseVitalSigns(), "Chỉ số sinh hiệu", btnVitalSigns);
            btnERM.Click += (s, ev) => ShowPlaceholder("Bệnh án", "Theo dõi hồ sơ bệnh án và ghi chú điều dưỡng.", btnERM);
            btnNavShifts.Click += (s, ev) => ShowNurseControl(new ucNurseShift(), "Ca làm việc", btnNavShifts);

            ShowNurseControl(new ucNurseOverview(), "Tổng quan", btnNavOverview);
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

        private void ShowNurseControl(UserControl control, string title, Button navButton)
        {
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = "Xin chào, " + (string.IsNullOrWhiteSpace(currentUser?.Name) ? "Y tá" : currentUser.Name);
            SetActiveNavButton(navButton);

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
            contentPanel.ResumeLayout();
        }

        private void ShowPlaceholder(string title, string subtitle, Button navButton)
        {
            lblPageTitle.Text = title;
            lblPageSubtitle.Text = subtitle;
            SetActiveNavButton(navButton);

            Panel panel = new Panel
            {
                BackColor = pageBack,
                Dock = DockStyle.Fill,
                Padding = new Padding(32)
            };

            panel.Controls.Add(new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 11F),
                ForeColor = textMuted,
                Height = 34,
                Text = subtitle
            });

            panel.Controls.Add(new Label
            {
                AutoSize = false,
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textMain,
                Height = 54,
                Text = title
            });

            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(panel);
            contentPanel.ResumeLayout();
        }

        private void SetActiveNavButton(Button activeButton)
        {
            Button[] buttons =
            {
                btnNavOverview,
                btnQueue,
                btnVitalSigns,
                btnERM,
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


