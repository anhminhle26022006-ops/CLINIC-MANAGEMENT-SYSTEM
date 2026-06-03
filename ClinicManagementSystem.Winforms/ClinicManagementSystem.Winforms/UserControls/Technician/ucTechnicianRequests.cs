﻿﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianRequests : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianRequests()
        {
            InitializeComponent();
        }

        private void ucTechnicianRequests_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianRequests_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderRequests();
        }

        // 2. REQUESTS VIEW (ImagingRequestForm)
        // ==========================================
        private ComboBox comboRequestStatusFilter;
        private TextBox txtRequestSearch;

        private void RenderRequests()
        {
            var page = BeginPage("Xét nghiệm & Chẩn đoán", "Quản lý danh sách yêu cầu thực hiện cận lâm sàng");

            var stats = CreateGrid(4, 90);
            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList();
            }
            catch { }

            int pending = list.Count(r => r.Status == "Chờ xử lý");
            int processing = list.Count(r => r.Status == "Đang xử lý");
            int completed = list.Count(r => r.Status == "Hoàn thành");

            stats.Controls.Add(CreateMiniStat("Chờ xử lý", pending.ToString(), Color.FromArgb(180, 83, 9)), 0, 0);
            stats.Controls.Add(CreateMiniStat("Đang xử lý", processing.ToString(), primary), 1, 0);
            stats.Controls.Add(CreateMiniStat("Hoàn thành", completed.ToString(), Color.FromArgb(34, 139, 74)), 2, 0);
            stats.Controls.Add(CreateMiniStat("Tổng yêu cầu", list.Count.ToString(), Color.FromArgb(126, 34, 206)), 3, 0);
            page.Controls.Add(stats);

            var filter = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 88,
                Margin = new Padding(0, 12, 0, 18),
                Width = PageWidth()
            };

            txtRequestSearch = CreateTextBox("Tìm kiếm bệnh nhân hoặc tên xét nghiệm...", 20, 24, (filter.Width - 64) / 2, 36);
            txtRequestSearch.TextChanged += (s, ev) => FilterRequestsList(page);

            comboRequestStatusFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(42 + (filter.Width - 64) / 2, 24),
                Size = new Size((filter.Width - 64) / 2, 36)
            };
            comboRequestStatusFilter.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ xử lý", "Đang xử lý", "Hoàn thành" });
            comboRequestStatusFilter.SelectedIndex = 0;
            comboRequestStatusFilter.SelectedIndexChanged += (s, ev) => FilterRequestsList(page);

            filter.Controls.Add(txtRequestSearch);
            filter.Controls.Add(comboRequestStatusFilter);
            page.Controls.Add(filter);

            RenderFilteredRequests(page, list);
        }

        private void FilterRequestsList(FlowLayoutPanel page)
        {
            string term = txtRequestSearch.Text.Contains("Tìm kiếm") ? "" : txtRequestSearch.Text.Trim();
            string status = comboRequestStatusFilter.SelectedItem.ToString();
            List<RequestDTO> filtered = requestBUS.FilterList(term, status);
            RenderFilteredRequests(page, filtered);
        }

        private void RenderFilteredRequests(FlowLayoutPanel page, List<RequestDTO> filteredList)
        {
            // Remove existing cards
            for (int i = page.Controls.Count - 1; i >= 3; i--)
            {
                page.Controls.RemoveAt(i);
            }

            foreach (var req in filteredList)
            {
                var card = CreateRequestCard(req);
                page.Controls.Add(card);
            }

            var note = new RoundedPanel
            {
                BorderColor = Color.FromArgb(191, 219, 254),
                CornerRadius = 8,
                FillColor = Color.FromArgb(239, 246, 255),
                Height = 130,
                Margin = new Padding(0, 10, 0, 20),
                Width = PageWidth()
            };
            note.Controls.Add(CreateLabel("Quy trình xử lý kết quả", 11F, FontStyle.Bold, Color.FromArgb(30, 64, 175), 18, 18, 400, 24));
            note.Controls.Add(CreateLabel("1. Nhận yêu cầu: Kỹ thuật viên nhấp 'Bắt đầu xử lý' để đổi trạng thái sang Đang xử lý.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 48, 760, 22));
            note.Controls.Add(CreateLabel("2. Thực hiện: Kỹ thuật viên tiến hành siêu âm/chụp chiếu hoặc phân tích mẫu sinh hóa.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 72, 760, 22));
            note.Controls.Add(CreateLabel("3. Hoàn thành: Tải lên hình ảnh phim (MRI/X-Ray), tệp PDF, hoặc điền số liệu Lab để hoàn thành.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 96, 760, 22));
            page.Controls.Add(note);
        }

        private RoundedPanel CreateRequestCard(RequestDTO req)
        {
            bool completed = req.Status == "Hoàn thành";
            bool processing = req.Status == "Đang xử lý";

            var borderColor = completed ? Color.FromArgb(187, 247, 208) : (processing ? primary : Color.FromArgb(252, 165, 165));
            var card = new RoundedPanel
            {
                BorderColor = borderColor,
                CornerRadius = 8,
                FillColor = Color.White,
                Height = 250,
                Margin = new Padding(0, 0, 0, 18),
                Width = PageWidth()
            };

            card.Controls.Add(CreateAvatar(req.PatientName.Substring(0, 1), 26, 26));
            card.Controls.Add(CreateLabel(req.PatientName, 13F, FontStyle.Bold, textMain, 78, 24, 280, 28));
            card.Controls.Add(CreateLabel($"Mã BN: {req.PatientCode} | Mã YC: {req.RequestCode}", 9F, FontStyle.Regular, textMuted, 78, 52, 350, 22));

            string priorityText = req.Priority;
            Color priorityBack = Color.FromArgb(254, 226, 226);
            Color priorityFore = Color.FromArgb(185, 28, 28);
            if (priorityText == "Thường")
            {
                priorityBack = Color.FromArgb(243, 244, 246);
                priorityFore = Color.FromArgb(75, 85, 99);
            }
            card.Controls.Add(CreateBadge(priorityText, priorityBack, priorityFore, card.Width - 116, 24, 92, 28));
            card.Controls.Add(CreateLabel(req.RequestDate.ToString("dd/MM/yyyy HH:mm"), 8.5F, FontStyle.Regular, textMuted, card.Width - 250, 60, 220, 22, ContentAlignment.MiddleRight));

            // Details section
            var detail = new RoundedPanel
            {
                BorderColor = Color.FromArgb(249, 250, 251),
                CornerRadius = 8,
                FillColor = Color.FromArgb(249, 250, 251),
                Location = new Point(26, 88),
                Size = new Size(card.Width - 52, 90)
            };
            detail.Controls.Add(CreateLabel("Bác sĩ chỉ định:", 8.5F, FontStyle.Regular, textMuted, 16, 12, 200, 20));
            detail.Controls.Add(CreateLabel(req.DoctorName, 9.5F, FontStyle.Bold, textMain, 16, 32, 250, 24));
            detail.Controls.Add(CreateLabel("Chẩn đoán / Ghi chú:", 8.5F, FontStyle.Regular, textMuted, 16, 56, 200, 20));
            detail.Controls.Add(CreateLabel(string.IsNullOrEmpty(req.RequestNote) ? "Không có" : req.RequestNote, 9.5F, FontStyle.Regular, textMain, 16, 72, 350, 24));
            detail.Controls.Add(CreateLabel("Loại dịch vụ:", 8.5F, FontStyle.Regular, textMuted, detail.Width / 2, 12, 200, 20));
            detail.Controls.Add(CreateLabel(req.ServiceType, 9.5F, FontStyle.Bold, primary, detail.Width / 2, 32, 300, 24));
            card.Controls.Add(detail);

            // Status action buttons
            if (completed)
            {
                card.Controls.Add(CreateBadge("Hoàn thành", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74), 26, 194, 120, 32));
                
                string resDetails = "Đã lưu kết quả thành công.";
                if (!string.IsNullOrEmpty(req.ResultFile)) resDetails = "Đã lưu phim: " + Path.GetFileName(req.ResultFile);
                else if (!string.IsNullOrEmpty(req.ResultPDF)) resDetails = "Đã lưu PDF: " + Path.GetFileName(req.ResultPDF);
                else if (!string.IsNullOrEmpty(req.LabValues)) resDetails = "Đã lưu thông số xét nghiệm.";
                card.Controls.Add(CreateLabel(resDetails, 9F, FontStyle.Italic, Color.FromArgb(34, 139, 74), 160, 194, 500, 32));
            }
            else
            {
                string statusText = req.Status;
                Color statusBack = Color.FromArgb(254, 249, 195);
                Color statusFore = Color.FromArgb(161, 98, 7);
                if (processing)
                {
                    statusBack = Color.FromArgb(239, 246, 255);
                    statusFore = primary;
                }
                card.Controls.Add(CreateBadge(statusText, statusBack, statusFore, 26, 194, 120, 32));

                string actionText = processing ? "Tải lên / Nhập kết quả" : "Bắt đầu xử lý";
                var actionBtn = CreateFlatButton(actionText, Color.White, primary, card.Width - 226, 194, 200, 36);
                actionBtn.Click += (s, ev) =>
                {
                    if (req.Status == "Chờ xử lý")
                    {
                        requestBUS.StartProcessing(req.RequestID);
                        req.Status = "Đang xử lý";
                    }

                    // Route Technician directly to the corresponding Form view
                    string type = req.ServiceType.ToLower();
                    if (type.Contains("mri") || type.Contains("x-quang") || type.Contains("siêu âm"))
                    {
                        NavigateTo(TechnicianViewTarget.UploadMRI, req.RequestID);
                    }
                    else if (type.Contains("xét nghiệm máu tổng quát") || type.Contains("pdf"))
                    {
                        NavigateTo(TechnicianViewTarget.UploadPDF, req.RequestID);
                    }
                    else
                    {
                        NavigateTo(TechnicianViewTarget.LabResult, req.RequestID);
                    }
                };
                card.Controls.Add(actionBtn);
            }

            return card;
        }

        // ==========================================

    }
}

