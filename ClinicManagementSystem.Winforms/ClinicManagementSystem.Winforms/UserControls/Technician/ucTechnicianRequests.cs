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

            // Group requests by PatientID, DoctorID, and RequestDate (same day)
            var grouped = filteredList
                .GroupBy(r => new { r.PatientID, r.DoctorID, Date = r.RequestDate.Date })
                .ToList();

            foreach (var group in grouped)
            {
                var card = CreateGroupedRequestCard(group.ToList());
                flpRequests.Controls.Add(card);
            }
        }

        private RoundedPanel CreateGroupedRequestCard(List<RequestDTO> requests)
        {
            var first = requests.First();
            bool allCompleted = requests.All(r => r.Status == "Hoàn thành");
            bool anyProcessing = requests.Any(r => r.Status == "Đang xử lý");

            var borderColor = allCompleted ? Color.FromArgb(187, 247, 208) : (anyProcessing ? primary : Color.FromArgb(252, 165, 165));
            int cardHeight = 100 + (requests.Count * 56) + 16;

            var card = new RoundedPanel
            {
                BorderColor = borderColor,
                CornerRadius = 8,
                FillColor = Color.White,
                Size = new Size(flpRequests.Width - 25, cardHeight),
                Margin = new Padding(0, 0, 0, 16)
            };

            card.Controls.Add(CreateAvatar(first.PatientName.Substring(0, 1), 26, 26));
            card.Controls.Add(CreateLabel(first.PatientName, 13F, FontStyle.Bold, textMain, 78, 20, 280, 28));
            card.Controls.Add(CreateLabel($"Mã BN: {first.PatientCode} | Bác sĩ chỉ định: {first.DoctorName}", 9F, FontStyle.Regular, textMuted, 78, 48, 450, 22));
            card.Controls.Add(CreateLabel(first.RequestDate.ToString("dd/MM/yyyy HH:mm"), 8.5F, FontStyle.Regular, textMuted, card.Width - 250, 24, 220, 22, ContentAlignment.MiddleRight));

            // Details section containing the list of services in this order group
            var detail = new RoundedPanel
            {
                BorderColor = Color.FromArgb(243, 244, 246),
                CornerRadius = 8,
                FillColor = Color.FromArgb(249, 250, 251),
                Location = new Point(26, 88),
                Size = new Size(card.Width - 52, requests.Count * 56)
            };

            for (int i = 0; i < requests.Count; i++)
            {
                var req = requests[i];
                int y = i * 56;

                if (i > 0)
                {
                    var line = new Panel
                    {
                        BackColor = Color.FromArgb(229, 231, 235),
                        Location = new Point(16, y),
                        Size = new Size(detail.Width - 32, 1)
                    };
                    detail.Controls.Add(line);
                }

                // Service Name
                detail.Controls.Add(CreateLabel(req.ServiceType, 9.5F, FontStyle.Bold, primary, 16, y + 14, 240, 24));

                // Notes / Comments
                string noteText = string.IsNullOrEmpty(req.RequestNote) ? "Không có ghi chú" : req.RequestNote;
                detail.Controls.Add(CreateLabel(noteText, 8.5F, FontStyle.Regular, textMuted, 260, y + 16, 150, 20));

                // Priority Badge
                string priorityText = req.Priority;
                Color priorityBack = Color.FromArgb(254, 226, 226);
                Color priorityFore = Color.FromArgb(185, 28, 28);
                if (priorityText == "Thường")
                {
                    priorityBack = Color.FromArgb(243, 244, 246);
                    priorityFore = Color.FromArgb(75, 85, 99);
                }
                detail.Controls.Add(CreateBadge(priorityText, priorityBack, priorityFore, detail.Width - 280, y + 14, 76, 26));

                // Status Badge
                Color statusBack = Color.FromArgb(254, 249, 195);
                Color statusFore = Color.FromArgb(161, 98, 7);
                if (req.Status == "Đang xử lý")
                {
                    statusBack = Color.FromArgb(239, 246, 255);
                    statusFore = primary;
                }
                else if (req.Status == "Hoàn thành")
                {
                    statusBack = Color.FromArgb(220, 252, 231);
                    statusFore = Color.FromArgb(34, 139, 74);
                }
                detail.Controls.Add(CreateBadge(req.Status, statusBack, statusFore, detail.Width - 190, y + 14, 86, 26));

                // Action Button or Info
                if (req.Status == "Hoàn thành")
                {
                    var btnView = CreateFlatButton("Xem", Color.FromArgb(34, 139, 74), Color.FromArgb(220, 252, 231), detail.Width - 90, y + 12, 76, 28);
                    btnView.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                    btnView.Click += (s, ev) => NavigateTo(TechnicianViewTarget.Records);
                    detail.Controls.Add(btnView);
                }
                else
                {
                    string actionText = req.Status == "Đang xử lý" ? "Xử lý" : "Tiến hành";
                    var actionBtn = CreateFlatButton(actionText, Color.White, primary, detail.Width - 90, y + 12, 76, 28);
                    actionBtn.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                    actionBtn.Click += (s, ev) =>
                    {
                        if (req.Status == "Chờ xử lý")
                        {
                            requestBUS.StartProcessing(req.RequestID);
                            req.Status = "Đang xử lý";
                        }

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
                    detail.Controls.Add(actionBtn);
                }
            }

            card.Controls.Add(detail);
            return card;
        }
    }
}
