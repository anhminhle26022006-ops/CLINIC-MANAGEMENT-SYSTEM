﻿﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianOverview : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianOverview()
        {
            InitializeComponent();
        }

        private void ucTechnicianOverview_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianOverview_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderOverview();
        }

        // 1. OVERVIEW VIEW
        // ==========================================
        private void RenderOverview()
        {
            var page = BeginPage("", "");
            page.Controls[0].Visible = false;
            page.Controls[1].Visible = false;

            List<RequestDTO> requests = new List<RequestDTO>();
            int pendingLab = 0;
            int pendingScan = 0;
            int completedToday = 0;
            int processing = 0;

            try
            {
                requests = requestBUS.GetList();
                pendingLab = requests.Count(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("Xét nghiệm") || r.ServiceType.Contains("ECG") || r.ServiceType.Contains("Điện tâm đồ")));
                pendingScan = requests.Count(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("Siêu âm")));
                completedToday = requests.Count(r => r.Status == "Hoàn thành" && r.RequestDate.Date == DateTime.Today);
                processing = requests.Count(r => r.Status == "Đang xử lý");
            }
            catch { }

            // Statistics grid
            var stats = CreateGrid(4, 150);
            stats.Controls.Add(CreateStatCard(pendingLab.ToString(), "Yêu cầu XN chờ", "FILE", Color.FromArgb(250, 245, 255), Color.FromArgb(126, 34, 206)), 0, 0);
            stats.Controls.Add(CreateStatCard(pendingScan.ToString(), "Hàng đợi chụp ảnh", "IMG", Color.FromArgb(239, 246, 255), primary), 1, 0);
            stats.Controls.Add(CreateStatCard(completedToday.ToString(), "Đã hoàn thành hôm nay", "OK", Color.FromArgb(240, 253, 244), Color.FromArgb(34, 139, 74)), 2, 0);
            stats.Controls.Add(CreateStatCard(processing.ToString(), "Đang xử lý", "UP", Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12)), 3, 0);
            page.Controls.Add(stats);

            // Today's shift panel
            var shift = CreateSection("Ca làm việc hôm nay", 260);
            AddRightBadge(shift, "Đang trực", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74));

            string shiftName = "Trống";
            string room = "-";
            string dept = "-";
            try
            {
                var todayShift = shiftBUS.GetList().FirstOrDefault(s => s.ShiftDate.Date == DateTime.Today);
                if (todayShift != null)
                {
                    shiftName = todayShift.ShiftName;
                    room = todayShift.Room;
                    dept = todayShift.Department;
                }
            }
            catch { }

            var shiftBox = new RoundedPanel
            {
                BorderColor = Color.FromArgb(191, 219, 254),
                CornerRadius = 8,
                FillColor = Color.FromArgb(219, 234, 254),
                Location = new Point(22, 70),
                Size = new Size(shift.Width - 44, 88)
            };
            shiftBox.Controls.Add(CreateLabel(shiftName, 16F, FontStyle.Bold, primary, 18, 18, 90, 30));
            shiftBox.Controls.Add(CreateLabel($"(Hôm nay)", 10F, FontStyle.Bold, primary, 94, 24, 160, 22));
            shiftBox.Controls.Add(CreateLabel(room, 9F, FontStyle.Bold, primary, 22, 55, 180, 24));
            shiftBox.Controls.Add(CreateLabel(dept, 9F, FontStyle.Bold, primary, shiftBox.Width - 480, 55, 240, 24));
            shift.Controls.Add(shiftBox);

            var btnViewWeek = CreateFlatButton("Xem lịch tuần", primary, Color.FromArgb(239, 246, 255), 22, 174, (shift.Width - 54) / 2, 36);
            btnViewWeek.Click += (s, ev) => NavigateTo(TechnicianViewTarget.Shifts);
            var btnRegisterShift = CreateFlatButton("Đăng ký ca mới", textMain, Color.FromArgb(243, 244, 246), 34 + (shift.Width - 54) / 2, 174, (shift.Width - 54) / 2, 36);
            btnRegisterShift.Click += (s, ev) =>
            {
                RegisterShiftForm register = new RegisterShiftForm(currentUser != null ? currentUser.Name : "Lữ Võ Hoàng Phúc");
                if (register.ShowDialog() == DialogResult.OK) NavigateTo(TechnicianViewTarget.Shifts);
            };

            shift.Controls.Add(btnViewWeek);
            shift.Controls.Add(btnRegisterShift);
            shift.Controls.Add(CreateLabel("Quản lý ca làm việc nhanh chóng", 9F, FontStyle.Regular, textMuted, shift.Width / 2 - 90, 220, 210, 22));
            page.Controls.Add(shift);

            // Two columns layout for pending items
            var twoColumns = CreateGrid(2, 310);

            // Column 1: Lab pending
            var lab = CreateSection("Yêu cầu Xét nghiệm", 290, true);
            var pendingLabList = requests.Where(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("Xét nghiệm") || r.ServiceType.Contains("ECG"))).Take(2).ToList();
            int yPos = 64;
            foreach (var req in pendingLabList)
            {
                lab.Controls.Add(CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, req.Priority, Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28), yPos));
                yPos += 114;
            }
            twoColumns.Controls.Add(lab, 0, 0);

            // Column 2: Scans pending
            var imaging = CreateSection("Hàng đợi Chụp ảnh", 290, true);
            var pendingScanList = requests.Where(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("Siêu âm"))).Take(2).ToList();
            yPos = 64;
            foreach (var req in pendingScanList)
            {
                imaging.Controls.Add(CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, "Chờ chụp", Color.FromArgb(254, 249, 195), Color.FromArgb(161, 98, 7), yPos));
                yPos += 114;
            }
            twoColumns.Controls.Add(imaging, 1, 0);
            page.Controls.Add(twoColumns);

            // Quick actions
            var actions = CreateSection("Hành động nhanh", 180);
            var actionGrid = CreateGrid(4, 110, actions.Width - 44);
            actionGrid.Location = new Point(22, 58);

            var act1 = CreateActionCard("Nhận yêu cầu XN", "Xem danh sách", "FILE", Color.FromArgb(250, 245, 255), Color.FromArgb(126, 34, 206));
            act1.Click += (s, ev) => NavigateTo(TechnicianViewTarget.Requests);
            var act2 = CreateActionCard("Chụp ảnh", "Tải phim MRI/X-Ray", "IMG", Color.FromArgb(239, 246, 255), primary);
            act2.Click += (s, ev) => NavigateTo(TechnicianViewTarget.UploadMRI);
            var act3 = CreateActionCard("Tải kết quả", "Tải lên tệp PDF", "UP", Color.FromArgb(240, 253, 244), Color.FromArgb(34, 139, 74));
            act3.Click += (s, ev) => NavigateTo(TechnicianViewTarget.UploadPDF);
            var act4 = CreateActionCard("Duyệt kết quả", "Nhập kết quả chỉ số", "OK", Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12));
            act4.Click += (s, ev) => NavigateTo(TechnicianViewTarget.LabResult);

            actionGrid.Controls.Add(act1, 0, 0);
            actionGrid.Controls.Add(act2, 1, 0);
            actionGrid.Controls.Add(act3, 2, 0);
            actionGrid.Controls.Add(act4, 3, 0);
            actions.Controls.Add(actionGrid);
            page.Controls.Add(actions);
        }

        // ==========================================

    }
}

