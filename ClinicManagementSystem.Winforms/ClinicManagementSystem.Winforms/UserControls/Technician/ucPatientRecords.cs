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
            var page = BeginPage("Hồ Sơ Bệnh Án", "Xem hồ sơ bệnh án, lịch sử chụp phim và kết quả xét nghiệm của bệnh nhân");

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

            txtRecordSearch = CreateTextBox("Tìm kiếm bệnh nhân...", 18, 22, leftWidth - 46, 38);
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

            string term = txtRecordSearch.Text.Contains("Tìm") ? "" : txtRecordSearch.Text.Trim();
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

            var lblAge = CreateLabel($"{pat.Age} tuổi - {pat.Gender}", 8.5F, FontStyle.Bold, textMuted, 70, 50, 180, 18);
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
            recordsRightPanel.Controls.Add(CreateLabel("♡", 52F, FontStyle.Regular, Color.FromArgb(156, 163, 175), 0, 100, width, 70, ContentAlignment.MiddleCenter));
            recordsRightPanel.Controls.Add(CreateLabel("Chọn bệnh nhân để xem lịch sử hồ sơ bệnh án", 13F, FontStyle.Regular, textMuted, 0, 180, width, 32, ContentAlignment.MiddleCenter));
            recordsRightPanel.Controls.Add(CreateLabel("Danh sách bệnh nhân đăng ký hiển thị phía bên trái", 10F, FontStyle.Regular, textMuted, 0, 218, width, 28, ContentAlignment.MiddleCenter));
        }

        private void SelectRecordPatient(PatientDTO pat)
        {
            recordsRightPanel.Controls.Clear();

            int panelW = recordsRightPanel.Width - 40;

            // Details panel
            recordsRightPanel.Controls.Add(CreateLabel(pat.Name, 14F, FontStyle.Bold, textMain, 24, 24, 400, 30));
            recordsRightPanel.Controls.Add(CreateLabel($"Mã BN: {pat.PatientCode} | Giới tính: {pat.Gender} | Tuổi: {pat.Age}", 9.5F, FontStyle.Bold, textMuted, 24, 58, 400, 22));
            recordsRightPanel.Controls.Add(CreateLabel($"SĐT: {pat.Phone} | Địa chỉ: {pat.Address}", 9.5F, FontStyle.Regular, textMuted, 24, 82, 450, 22));

            recordsRightPanel.Controls.Add(CreateLabel("LỊCH SỬ KẾT QUẢ XÉT NGHIỆM", 10F, FontStyle.Bold, primary, 24, 130, 400, 22));

            // Load patient history
            List<RequestDTO> history = new List<RequestDTO>();
            try
            {
                history = requestBUS.GetRequestsByPatient(pat.PatientID).Where(r => r.Status == "Hoàn thành").ToList();
            }
            catch { }

            if (history.Count == 0)
            {
                recordsRightPanel.Controls.Add(CreateLabel("Bệnh nhân này chưa có kết quả xét nghiệm hoàn thành nào.", 9.5F, FontStyle.Italic, textMuted, 24, 170, panelW, 30));
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
                card.Controls.Add(CreateLabel($"Bác sĩ chỉ định: {req.DoctorName} | Ngày: {req.RequestDate:dd/MM/yyyy HH:mm}", 8.5F, FontStyle.Regular, textMuted, 18, 38, 450, 20));

                if (!string.IsNullOrEmpty(req.ResultFile))
                {
                    card.Controls.Add(CreateLabel("Kết quả: Đã chụp phim MRI/X-Ray.", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 64, 400, 20));
                    card.Controls.Add(CreateLabel("Kết luận: " + req.RequestNote, 9F, FontStyle.Regular, textMain, 18, 86, 400, 20));

                    var btnViewImage = CreateFlatButton("Xem hình phim...", Color.White, primary, 18, 114, 150, 32);
                    btnViewImage.Click += (s, ev) =>
                    {
                        if (File.Exists(req.ResultFile))
                        {
                            Process.Start(new ProcessStartInfo(req.ResultFile) { UseShellExecute = true });
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tệp ảnh gốc. Có thể tệp đã bị di chuyển.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    card.Controls.Add(btnViewImage);
                }
                else if (!string.IsNullOrEmpty(req.ResultPDF))
                {
                    card.Controls.Add(CreateLabel("Kết quả: Báo cáo xét nghiệm tổng hợp định dạng PDF.", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 64, 400, 20));
                    
                    var btnViewPDF = CreateFlatButton("Mở file PDF...", Color.White, primary, 18, 114, 150, 32);
                    btnViewPDF.Click += (s, ev) =>
                    {
                        if (File.Exists(req.ResultPDF))
                        {
                            Process.Start(new ProcessStartInfo(req.ResultPDF) { UseShellExecute = true });
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy file PDF chẩn đoán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                    card.Controls.Add(btnViewPDF);
                }
                else if (!string.IsNullOrEmpty(req.LabValues))
                {
                    card.Controls.Add(CreateLabel("Kết quả: Các chỉ số sinh hóa máu đo được:", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 62, 400, 20));
                    try
                    {
                        JObject vals = JObject.Parse(req.LabValues);
                        string resStr = $"RBC: {vals["RBC"]} T/L | WBC: {vals["WBC"]} G/L | Glucose: {vals["Glucose"]} mmol/L | Acid Uric: {vals["UricAcid"]} umol/L";
                        card.Controls.Add(CreateLabel(resStr, 9F, FontStyle.Regular, textMain, 18, 84, 450, 20));
                    }
                    catch
                    {
                        card.Controls.Add(CreateLabel("Dữ liệu chỉ số lab không đúng định dạng.", 9F, FontStyle.Regular, textMain, 18, 84, 400, 20));
                    }
                }

                recordsRightPanel.Controls.Add(card);
                yPos += 176;
            }
        }

        // ==========================================

    }
}

