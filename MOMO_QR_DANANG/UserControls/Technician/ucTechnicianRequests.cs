using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MOMO_QR_DANANG.DataAccess;
using MOMO_QR_DANANG.Models;
using Newtonsoft.Json.Linq;

namespace MOMO_QR_DANANG.UserControls.Technician
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
            var page = BeginPage("XÃ©t nghiá»‡m & Cháº©n Ä‘oÃ¡n", "Quáº£n lÃ½ danh sÃ¡ch yÃªu cáº§u thá»±c hiá»‡n cáº­n lÃ¢m sÃ ng");

            var stats = CreateGrid(4, 90);
            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList();
            }
            catch { }

            int pending = list.Count(r => r.Status == "Chá» xá»­ lÃ½");
            int processing = list.Count(r => r.Status == "Äang xá»­ lÃ½");
            int completed = list.Count(r => r.Status == "HoÃ n thÃ nh");

            stats.Controls.Add(CreateMiniStat("Chá» xá»­ lÃ½", pending.ToString(), Color.FromArgb(180, 83, 9)), 0, 0);
            stats.Controls.Add(CreateMiniStat("Äang xá»­ lÃ½", processing.ToString(), primary), 1, 0);
            stats.Controls.Add(CreateMiniStat("HoÃ n thÃ nh", completed.ToString(), Color.FromArgb(34, 139, 74)), 2, 0);
            stats.Controls.Add(CreateMiniStat("Tá»•ng yÃªu cáº§u", list.Count.ToString(), Color.FromArgb(126, 34, 206)), 3, 0);
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

            txtRequestSearch = CreateTextBox("TÃ¬m kiáº¿m bá»‡nh nhÃ¢n hoáº·c tÃªn xÃ©t nghiá»‡m...", 20, 24, (filter.Width - 64) / 2, 36);
            txtRequestSearch.TextChanged += (s, ev) => FilterRequestsList(page);

            comboRequestStatusFilter = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(42 + (filter.Width - 64) / 2, 24),
                Size = new Size((filter.Width - 64) / 2, 36)
            };
            comboRequestStatusFilter.Items.AddRange(new object[] { "Táº¥t cáº£ tráº¡ng thÃ¡i", "Chá» xá»­ lÃ½", "Äang xá»­ lÃ½", "HoÃ n thÃ nh" });
            comboRequestStatusFilter.SelectedIndex = 0;
            comboRequestStatusFilter.SelectedIndexChanged += (s, ev) => FilterRequestsList(page);

            filter.Controls.Add(txtRequestSearch);
            filter.Controls.Add(comboRequestStatusFilter);
            page.Controls.Add(filter);

            RenderFilteredRequests(page, list);
        }

        private void FilterRequestsList(FlowLayoutPanel page)
        {
            string term = txtRequestSearch.Text.Contains("TÃ¬m kiáº¿m") ? "" : txtRequestSearch.Text.Trim();
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
            note.Controls.Add(CreateLabel("Quy trÃ¬nh xá»­ lÃ½ káº¿t quáº£", 11F, FontStyle.Bold, Color.FromArgb(30, 64, 175), 18, 18, 400, 24));
            note.Controls.Add(CreateLabel("1. Nháº­n yÃªu cáº§u: Ká»¹ thuáº­t viÃªn nháº¥p 'Báº¯t Ä‘áº§u xá»­ lÃ½' Ä‘á»ƒ Ä‘á»•i tráº¡ng thÃ¡i sang Äang xá»­ lÃ½.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 48, 760, 22));
            note.Controls.Add(CreateLabel("2. Thá»±c hiá»‡n: Ká»¹ thuáº­t viÃªn tiáº¿n hÃ nh siÃªu Ã¢m/chá»¥p chiáº¿u hoáº·c phÃ¢n tÃ­ch máº«u sinh hÃ³a.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 72, 760, 22));
            note.Controls.Add(CreateLabel("3. HoÃ n thÃ nh: Táº£i lÃªn hÃ¬nh áº£nh phim (MRI/X-Ray), tá»‡p PDF, hoáº·c Ä‘iá»n sá»‘ liá»‡u Lab Ä‘á»ƒ hoÃ n thÃ nh.", 9.5F, FontStyle.Regular, Color.FromArgb(30, 64, 175), 18, 96, 760, 22));
            page.Controls.Add(note);
        }

        private RoundedPanel CreateRequestCard(RequestDTO req)
        {
            bool completed = req.Status == "HoÃ n thÃ nh";
            bool processing = req.Status == "Äang xá»­ lÃ½";

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
            card.Controls.Add(CreateLabel($"MÃ£ BN: {req.PatientCode} | MÃ£ YC: {req.RequestCode}", 9F, FontStyle.Regular, textMuted, 78, 52, 350, 22));

            string priorityText = req.Priority;
            Color priorityBack = Color.FromArgb(254, 226, 226);
            Color priorityFore = Color.FromArgb(185, 28, 28);
            if (priorityText == "ThÆ°á»ng")
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
            detail.Controls.Add(CreateLabel("BÃ¡c sÄ© chá»‰ Ä‘á»‹nh:", 8.5F, FontStyle.Regular, textMuted, 16, 12, 200, 20));
            detail.Controls.Add(CreateLabel(req.DoctorName, 9.5F, FontStyle.Bold, textMain, 16, 32, 250, 24));
            detail.Controls.Add(CreateLabel("Cháº©n Ä‘oÃ¡n / Ghi chÃº:", 8.5F, FontStyle.Regular, textMuted, 16, 56, 200, 20));
            detail.Controls.Add(CreateLabel(string.IsNullOrEmpty(req.RequestNote) ? "KhÃ´ng cÃ³" : req.RequestNote, 9.5F, FontStyle.Regular, textMain, 16, 72, 350, 24));
            detail.Controls.Add(CreateLabel("Loáº¡i dá»‹ch vá»¥:", 8.5F, FontStyle.Regular, textMuted, detail.Width / 2, 12, 200, 20));
            detail.Controls.Add(CreateLabel(req.ServiceType, 9.5F, FontStyle.Bold, primary, detail.Width / 2, 32, 300, 24));
            card.Controls.Add(detail);

            // Status action buttons
            if (completed)
            {
                card.Controls.Add(CreateBadge("HoÃ n thÃ nh", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74), 26, 194, 120, 32));
                
                string resDetails = "ÄÃ£ lÆ°u káº¿t quáº£ thÃ nh cÃ´ng.";
                if (!string.IsNullOrEmpty(req.ResultFile)) resDetails = "ÄÃ£ lÆ°u phim: " + Path.GetFileName(req.ResultFile);
                else if (!string.IsNullOrEmpty(req.ResultPDF)) resDetails = "ÄÃ£ lÆ°u PDF: " + Path.GetFileName(req.ResultPDF);
                else if (!string.IsNullOrEmpty(req.LabValues)) resDetails = "ÄÃ£ lÆ°u thÃ´ng sá»‘ xÃ©t nghiá»‡m.";
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

                string actionText = processing ? "Táº£i lÃªn / Nháº­p káº¿t quáº£" : "Báº¯t Ä‘áº§u xá»­ lÃ½";
                var actionBtn = CreateFlatButton(actionText, Color.White, primary, card.Width - 226, 194, 200, 36);
                actionBtn.Click += (s, ev) =>
                {
                    if (req.Status == "Chá» xá»­ lÃ½")
                    {
                        requestBUS.StartProcessing(req.RequestID);
                        req.Status = "Äang xá»­ lÃ½";
                    }

                    // Route Technician directly to the corresponding Form view
                    string type = req.ServiceType.ToLower();
                    if (type.Contains("mri") || type.Contains("x-quang") || type.Contains("siÃªu Ã¢m"))
                    {
                        NavigateTo(TechnicianViewTarget.UploadMRI, req.RequestID);
                    }
                    else if (type.Contains("xÃ©t nghiá»‡m mÃ¡u tá»•ng quÃ¡t") || type.Contains("pdf"))
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

