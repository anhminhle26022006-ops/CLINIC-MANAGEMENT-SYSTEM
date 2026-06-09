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

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class NurseMainform : Form
    {
        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);

        private UserDTO currentUser;
        private bool layoutReady;

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

            lblUserName.Text = user.Name;
            lblUserEmail.Text = string.IsNullOrEmpty(user.Email)
                ? user.Username
                : user.Email;

            lblAvatar.Text = string.IsNullOrEmpty(user.Name)
                ? "N"
                : user.Name.Substring(0, 1).ToUpper();

            lblPageSubtitle.Text = $"Xin chào, {user.Name}";
        }

        private void ReceptionistMainform_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            btnClose.Click += (s, ev) =>
            {
                CloseRequested?.Invoke(this, EventArgs.Empty);
            };

            btnNavOverview.Click += BtnNavOverview_Click;
            btnQueue.Click += BtnQueue_Click;
            btnVitalSigns.Click += BtnVitalSigns_Click;
            btnERM.Click += BtnERM_Click;
            btnNavShifts.Click += BtnNavShifts_Click;

            SetActiveButton(btnNavOverview);
        }

        private void SetActiveButton(Button activeButton)
        {
            Button[] buttons =
            {
                btnNavOverview,
                btnQueue,
                btnVitalSigns,
                btnERM,
                btnNavShifts
            };

            foreach (var btn in buttons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(55, 65, 81);
            }

            activeButton.BackColor = Color.FromArgb(239, 246, 255);
            activeButton.ForeColor = primary;
        }

        private void BtnNavOverview_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Tổng quan";
            SetActiveButton(btnNavOverview);

            // TODO:
            // LoadControl(new UCNurseDashboard());
        }

        private void BtnQueue_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Hàng chờ khám";
            SetActiveButton(btnQueue);

            // TODO:
            // LoadControl(new UCNurseQueue());
        }

        private void BtnVitalSigns_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Chỉ số sinh hiệu";
            SetActiveButton(btnVitalSigns);

            // TODO:
            // LoadControl(new UCNurseVitalSigns());
        }

        private void BtnERM_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Bệnh án";
            SetActiveButton(btnERM);

            // TODO:
            // LoadControl(new UCNurseMedicalRecord());
        }

        private void BtnNavShifts_Click(object sender, EventArgs e)
        {
            lblPageTitle.Text = "Ca làm việc";
            SetActiveButton(btnNavShifts);

            // TODO:
            // LoadControl(new UCNurseShifts());
        }

        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400)
                return;
        }

        private void LoadControl(UserControl control)
        {
            contentPanel.Controls.Clear();

            control.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(control);
            control.BringToFront();
        }
    }
}


