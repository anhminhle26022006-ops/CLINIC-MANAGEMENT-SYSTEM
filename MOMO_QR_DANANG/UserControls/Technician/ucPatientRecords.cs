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
    public partial class ucPatientRecords : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucPatientRecords()
        {
            InitializeComponent();
        }

        private void ucPatientRecords_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucPatientRecords_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderRecords();
        }

        // 6. RECORDS VIEW (ResultArchiveForm)
        // ==========================================
        private RoundedPanel recordsRightPanel;
        private TextBox txtRecordSearch;
        private RoundedPanel recordPatientListPanel;

        private void RenderRecords()
        {
            var page = BeginPage("Há»“ SÆ¡ Bá»‡nh Ãn", "Xem há»“ sÆ¡ bá»‡nh Ã¡n, lá»‹ch sá»­ chá»¥p phim vÃ  káº¿t quáº£ xÃ©t nghiá»‡m cá»§a bá»‡nh nhÃ¢n");

            int leftWidth = Math.Max(320, (int)(PageWidth() * 0.32F));
            int rightWidth = Math.Max(500, PageWidth() - leftWidth - 20);

            var split = new TableLayoutPanel
            {
                ColumnCount = 2,
                Height = 600,
                Margin = new Padding(0, 14, 0, 0),
                RowCount = 1,
                Width = PageWidth()
            };
            split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            split.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            split.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            recordPatientListPanel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 16, 0)
            };

            txtRecordSearch = CreateTextBox("TÃ¬m kiáº¿m bá»‡nh nhÃ¢n...", 18, 22, leftWidth - 46, 38);
            txtRecordSearch.TextChanged += (s, ev) => FilterRecordPatientsList();
            recordPatientListPanel.Controls.Add(txtRecordSearch);

            FilterRecordPatientsList();

            split.Controls.Add(recordPatientListPanel, 0, 0);

            recordsRightPanel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0),
                AutoScroll = true
            };

            RenderRecordRightEmpty(rightWidth);
            split.Controls.Add(recordsRightPanel, 1, 0);

            page.Controls.Add(split);
        }

        private void FilterRecordPatientsList()
        {
            // Remove lines
            for (int i = recordPatientListPanel.Controls.Count - 1; i >= 1; i--)
            {
                recordPatientListPanel.Controls.RemoveAt(i);
            }

            string term = txtRecordSearch.Text.Contains("TÃ¬m") ? "" : txtRecordSearch.Text.Trim();
            List<PatientDTO> patients = new List<PatientDTO>();
            try
            {
                patients = patientBUS.FilterList(term);
            }
            catch { }

            int y = 88;
            foreach (var pat in patients)
            {
                AddPatientRecordRow(recordPatientListPanel, pat, y);
                y += 84;
            }
        }

        private void AddPatientRecordRow(RoundedPanel container, PatientDTO pat, int y)
        {
            string init = pat.Name.Substring(0, 1).ToUpper();
            var row = new Panel
            {
                Location = new Point(10, y),
                Size = new Size(container.Width - 20, 76),
                BackColor = Color.FromArgb(249, 250, 251),
                Cursor = Cursors.Hand
            };
            row.Click += (s, ev) => SelectRecordPatient(pat);

            var avatar = CreateAvatar(init, 12, 14);
            avatar.Click += (s, ev) => SelectRecordPatient(pat);
            row.Controls.Add(avatar);

            var lblName = CreateLabel(pat.Name, 10.5F, FontStyle.Bold, textMain, 70, 8, 180, 24);
            lblName.Click += (s, ev) => SelectRecordPatient(pat);
            row.Controls.Add(lblName);

            var lblCode = CreateLabel(pat.PatientCode, 8.5F, FontStyle.Regular, textMuted, 70, 32, 180, 18);
            lblCode.Click += (s, ev) => SelectRecordPatient(pat);
            row.Controls.Add(lblCode);

            var lblAge = CreateLabel($"{pat.Age} tuá»•i - {pat.Gender}", 8.5F, FontStyle.Bold, textMuted, 70, 50, 180, 18);
            lblAge.Click += (s, ev) => SelectRecordPatient(pat);
            row.Controls.Add(lblAge);

            var lblChevron = CreateLabel(">", 16F, FontStyle.Regular, Color.FromArgb(156, 163, 175), row.Width - 36, 20, 24, 30, ContentAlignment.MiddleCenter);
            lblChevron.Click += (s, ev) => SelectRecordPatient(pat);
            row.Controls.Add(lblChevron);

            container.Controls.Add(row);
        }

        private void RenderRecordRightEmpty(int width)
        {
            recordsRightPanel.Controls.Clear();
            recordsRightPanel.Controls.Add(CreateLabel("â™¡", 52F, FontStyle.Regular, Color.FromArgb(156, 163, 175), 0, 100, width, 70, ContentAlignment.MiddleCenter));
            recordsRightPanel.Controls.Add(CreateLabel("Chá»n bá»‡nh nhÃ¢n Ä‘á»ƒ xem lá»‹ch sá»­ há»“ sÆ¡ bá»‡nh Ã¡n", 13F, FontStyle.Regular, textMuted, 0, 180, width, 32, ContentAlignment.MiddleCenter));
            recordsRightPanel.Controls.Add(CreateLabel("Danh sÃ¡ch bá»‡nh nhÃ¢n Ä‘Äƒng kÃ½ hiá»ƒn thá»‹ phÃ­a bÃªn trÃ¡i", 10F, FontStyle.Regular, textMuted, 0, 218, width, 28, ContentAlignment.MiddleCenter));
        }

        private void SelectRecordPatient(PatientDTO pat)
        {
            recordsRightPanel.Controls.Clear();

            int panelW = recordsRightPanel.Width - 40;

            // Details panel
            recordsRightPanel.Controls.Add(CreateLabel(pat.Name, 14F, FontStyle.Bold, textMain, 24, 24, 400, 30));
            recordsRightPanel.Controls.Add(CreateLabel($"MÃ£ BN: {pat.PatientCode} | Giá»›i tÃ­nh: {pat.Gender} | Tuá»•i: {pat.Age}", 9.5F, FontStyle.Bold, textMuted, 24, 58, 400, 22));
            recordsRightPanel.Controls.Add(CreateLabel($"SÄT: {pat.Phone} | Äá»‹a chá»‰: {pat.Address}", 9.5F, FontStyle.Regular, textMuted, 24, 82, 450, 22));

            recordsRightPanel.Controls.Add(CreateLabel("Lá»ŠCH Sá»¬ Káº¾T QUáº¢ XÃ‰T NGHIá»†M", 10F, FontStyle.Bold, primary, 24, 130, 400, 22));

            // Load patient history
            List<RequestDTO> history = new List<RequestDTO>();
            try
            {
                history = requestBUS.GetRequestsByPatient(pat.PatientID).Where(r => r.Status == "HoÃ n thÃ nh").ToList();
            }
            catch { }

            if (history.Count == 0)
            {
                recordsRightPanel.Controls.Add(CreateLabel("Bá»‡nh nhÃ¢n nÃ y chÆ°a cÃ³ káº¿t quáº£ xÃ©t nghiá»‡m hoÃ n thÃ nh nÃ o.", 9.5F, FontStyle.Italic, textMuted, 24, 170, panelW, 30));
                return;
            }

            int yPos = 170;
            foreach (var req in history)
            {
                var card = new RoundedPanel
                {
                    BorderColor = Color.FromArgb(229, 231, 235),
                    CornerRadius = 8,
                    FillColor = Color.FromArgb(249, 250, 251),
                    Location = new Point(24, yPos),
                    Size = new Size(panelW - 10, 160)
                };

                card.Controls.Add(CreateLabel(req.ServiceType, 11F, FontStyle.Bold, textMain, 18, 12, 350, 24));
                card.Controls.Add(CreateLabel($"BÃ¡c sÄ© chá»‰ Ä‘á»‹nh: {req.DoctorName} | NgÃ y: {req.RequestDate:dd/MM/yyyy HH:mm}", 8.5F, FontStyle.Regular, textMuted, 18, 38, 450, 20));

                if (!string.IsNullOrEmpty(req.ResultFile))
                {
                    card.Controls.Add(CreateLabel("Káº¿t quáº£: ÄÃ£ chá»¥p phim MRI/X-Ray.", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 64, 400, 20));
                    card.Controls.Add(CreateLabel("Káº¿t luáº­n: " + req.RequestNote, 9F, FontStyle.Regular, textMain, 18, 86, 400, 20));

                    var btnViewImage = CreateFlatButton("Xem hÃ¬nh phim...", Color.White, primary, 18, 114, 150, 32);
                    btnViewImage.Click += (s, ev) =>
                    {
                        if (File.Exists(req.ResultFile))
                        {
                            Process.Start(new ProcessStartInfo(req.ResultFile) { UseShellExecute = true });
                        }
                        else
                        {
                            MessageBox.Show("KhÃ´ng tÃ¬m tháº¥y tá»‡p áº£nh gá»‘c. CÃ³ thá»ƒ tá»‡p Ä‘Ã£ bá»‹ di chuyá»ƒn.", "Lá»—i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    card.Controls.Add(btnViewImage);
                }
                else if (!string.IsNullOrEmpty(req.ResultPDF))
                {
                    card.Controls.Add(CreateLabel("Káº¿t quáº£: BÃ¡o cÃ¡o xÃ©t nghiá»‡m tá»•ng há»£p Ä‘á»‹nh dáº¡ng PDF.", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 64, 400, 20));
                    
                    var btnViewPDF = CreateFlatButton("Má»Ÿ file PDF...", Color.White, primary, 18, 114, 150, 32);
                    btnViewPDF.Click += (s, ev) =>
                    {
                        if (File.Exists(req.ResultPDF))
                        {
                            Process.Start(new ProcessStartInfo(req.ResultPDF) { UseShellExecute = true });
                        }
                        else
                        {
                            MessageBox.Show("KhÃ´ng tÃ¬m tháº¥y file PDF cháº©n Ä‘oÃ¡n.", "Lá»—i", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    card.Controls.Add(btnViewPDF);
                }
                else if (!string.IsNullOrEmpty(req.LabValues))
                {
                    card.Controls.Add(CreateLabel("Káº¿t quáº£: CÃ¡c chá»‰ sá»‘ sinh hÃ³a mÃ¡u Ä‘o Ä‘Æ°á»£c:", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 62, 400, 20));
                    try
                    {
                        JObject vals = JObject.Parse(req.LabValues);
                        string resStr = $"RBC: {vals["RBC"]} T/L | WBC: {vals["WBC"]} G/L | Glucose: {vals["Glucose"]} mmol/L | Acid Uric: {vals["UricAcid"]} umol/L";
                        card.Controls.Add(CreateLabel(resStr, 9F, FontStyle.Regular, textMain, 18, 84, 450, 20));
                    }
                    catch
                    {
                        card.Controls.Add(CreateLabel("Dá»¯ liá»‡u chá»‰ sá»‘ lab khÃ´ng Ä‘Ãºng Ä‘á»‹nh dáº¡ng.", 9F, FontStyle.Regular, textMain, 18, 84, 400, 20));
                    }
                }

                recordsRightPanel.Controls.Add(card);
                yPos += 176;
            }
        }

        // ==========================================

    }
}

