﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms;
using BUS.Services;
using DTO;
using DAL;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class AdminMainform : Form
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

        // Active request for processing transitions

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public AdminMainform()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public AdminMainform(UserDTO user) : this()
        {
            this.currentUser = user;
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chào, " + user.Name;
        }

        private void ucTechnicianDashboard_Load(object sender, EventArgs e)
        {
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            btnNavOverview.Click += (s, ev) => ShowOverview();
            btnEmployeeManagement.Click += (s, ev) => ShowSection(
                "Quản lý nhân viên",
                "Theo dõi hồ sơ nhân sự, vai trò và trạng thái làm việc.",
                btnEmployeeManagement,
                "Nhân viên hoạt động: đang cập nhật",
                "Tài khoản cần rà soát: đang cập nhật");
            btnDepartmentManagement.Click += (s, ev) => ShowSection(
                "Quản lý chuyên khoa",
                "Quản lý khoa phòng, phòng khám và phân công bộ phận.",
                btnDepartmentManagement,
                "Chuyên khoa hoạt động: đang cập nhật",
                "Phòng khám sẵn sàng: đang cập nhật");
            btnShiftManagement.Click += (s, ev) => ShowSection(
                "Quản lý ca trực",
                "Tổng hợp lịch trực và phân ca nhân viên.",
                btnShiftManagement,
                "Ca đã phân công: đang cập nhật",
                "Nhân sự thiếu ca: đang cập nhật");
            btnNavShifts.Click += (s, ev) => ShowSection(
                "Ca làm việc",
                "Theo dõi lịch làm việc theo ngày và theo bộ phận.",
                btnNavShifts,
                "Ca sáng: đang cập nhật",
                "Ca chiều: đang cập nhật");
            btnStatitics.Click += (s, ev) => ShowSection(
                "Thống kê",
                "Xem nhanh số liệu vận hành phòng khám.",
                btnStatitics,
                "Lượt khám hôm nay: đang cập nhật",
                "Thanh toán hoàn tất: đang cập nhật");
            btnAdvancedAnalysis.Click += (s, ev) => ShowSection(
                "Phân tích nâng cao",
                "Khu vực dành cho báo cáo chuyên sâu và đối soát dữ liệu.",
                btnAdvancedAnalysis,
                "Báo cáo theo chuyên khoa: đang cập nhật",
                "Đối soát dữ liệu: đang cập nhật");

            ShowOverview();
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
            ShowSection(
                "Tổng quan",
                "Xin chào, " + (currentUser != null ? currentUser.Name : "Quản trị viên"),
                btnNavOverview,
                "Nhân viên hoạt động: đang cập nhật",
                "Lịch hẹn hôm nay: đang cập nhật",
                "Yêu cầu cần xử lý: đang cập nhật");
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
                btnEmployeeManagement,
                btnDepartmentManagement,
                btnShiftManagement,
                btnNavShifts,
                btnStatitics,
                btnAdvancedAnalysis
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


