using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DTO;
using ClinicManagementSystem.Winforms.Forms;

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
            txtRequestSearch.Enter += TxtRequestSearch_Enter;
            txtRequestSearch.Leave += TxtRequestSearch_Leave;
            txtRequestSearch.TextChanged += TxtRequestSearch_TextChanged;
            comboRequestStatusFilter.SelectedIndexChanged += ComboRequestStatusFilter_SelectedIndexChanged;

            LoadRequests();
        }

        private void ucTechnicianRequests_Resize(object sender, EventArgs e)
        {
            // Anchored elements resize automatically.
        }

        private void TxtRequestSearch_Enter(object sender, EventArgs e)
        {
            if (txtRequestSearch.Text.Contains("Tìm kiếm bệnh nhân hoặc tên xét nghiệm..."))
            {
                txtRequestSearch.Text = "";
                txtRequestSearch.ForeColor = textMain;
            }
        }

        private void TxtRequestSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequestSearch.Text))
            {
                txtRequestSearch.Text = "Tìm kiếm bệnh nhân hoặc tên xét nghiệm...";
                txtRequestSearch.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        private void TxtRequestSearch_TextChanged(object sender, EventArgs e)
        {
            FilterRequestsList();
        }

        private void ComboRequestStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterRequestsList();
        }

        private void LoadRequests()
        {
            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList();
            }
            catch { }

            int pending = list.Count(r => r.Status == "Chờ xử lý");
            int processing = list.Count(r => r.Status == "Đang xử lý");
            int completed = list.Count(r => r.Status == "Hoàn thành");

            lblStatPendingNum.Text = pending.ToString();
            lblStatProcessingNum.Text = processing.ToString();
            lblStatCompletedNum.Text = completed.ToString();
            lblStatTotalNum.Text = list.Count.ToString();

            comboRequestStatusFilter.SelectedIndex = 0;
            RenderFilteredRequests(list);
        }

        private void FilterRequestsList()
        {
            string term = txtRequestSearch.Text.Contains("Tìm kiếm") ? "" : txtRequestSearch.Text.Trim();
            string status = comboRequestStatusFilter.SelectedItem != null ? comboRequestStatusFilter.SelectedItem.ToString() : "Tất cả trạng thái";
            List<RequestDTO> filtered = requestBUS.FilterList(term, status);
            RenderFilteredRequests(filtered);
        }

        private void RenderFilteredRequests(List<RequestDTO> filteredList)
        {
            flpRequests.Controls.Clear();

            foreach (var req in filteredList)
            {
                var card = CreateRequestCard(req);
                flpRequests.Controls.Add(card);
            }
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
                Size = new Size(flpRequests.Width - 25, 250),
                Margin = new Padding(0, 0, 0, 16)
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
    }
}
