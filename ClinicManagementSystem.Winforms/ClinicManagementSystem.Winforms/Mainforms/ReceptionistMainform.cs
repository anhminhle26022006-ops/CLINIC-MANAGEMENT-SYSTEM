using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
﻿﻿using BUS.Services;
using ClinicManagementSystem.Winforms;
using ClinicManagementSystem.Winforms.UserControls;
using ClinicManagementSystem.Winforms.UserControls.reception;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class ReceptionistMainform : UserControl
    {
        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly RequestBUS requestBUS = new RequestBUS();
        private readonly ShiftBUS shiftBUS = new ShiftBUS();
        private UserDTO currentUser;
        private bool layoutReady;

        // Custom Navigation Buttons

        // Active request for processing transitions

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public ReceptionistMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public ReceptionistMainform(UserDTO user) : this()
        {
            this.currentUser = user;
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void ReceptionistMainform_Load(object sender, EventArgs e)
        {
            // Re-arrange default sidebar buttons
            btnNavOverview.Location = new Point(12, 78);
            btnPatientManagement.Location = new Point(12, 124);

            // Set Log Out click handler
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            // Close button click handler
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);


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

        private void LoadContent(UserControl control)
        {
            contentPanel.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(control);
            lblPageTitle.Text = control.GetType().Name switch
            {
                nameof(PatientManagement) => "Quản lý bệnh nhân",
                nameof(CreateAppointment) => "Tạo lịch hẹn",
                nameof(ScheduleToday) => "Lịch hẹn hôm nay",
                _ => "Clinic Management System"
            };
        }

        private void btnPatientManagement_Click(object sender, EventArgs e)
        {
            LoadContent(new PatientManagement());
        }

        private void btnAppointment_Click(object sender, EventArgs e)
        {
            LoadContent(new CreateAppointment());
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
    }
}


