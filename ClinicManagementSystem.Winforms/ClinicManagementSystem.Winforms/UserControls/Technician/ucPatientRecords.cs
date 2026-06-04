using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DTO;
using Newtonsoft.Json.Linq;
using ClinicManagementSystem.Winforms.Forms;

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
            txtRecordSearch.Enter += TxtRecordSearch_Enter;
            txtRecordSearch.Leave += TxtRecordSearch_Leave;
            txtRecordSearch.TextChanged += TxtRecordSearch_TextChanged;
            
            FilterRecordPatientsList();
        }

        private void ucPatientRecords_Resize(object sender, EventArgs e)
        {
            // Anchored layouts resize automatically.
        }

        private void TxtRecordSearch_Enter(object sender, EventArgs e)
        {
            if (txtRecordSearch.Text.Contains("Tìm kiếm bệnh nhân..."))
            {
                txtRecordSearch.Text = "";
                txtRecordSearch.ForeColor = textMain;
            }
        }

        private void TxtRecordSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecordSearch.Text))
            {
                txtRecordSearch.Text = "Tìm kiếm bệnh nhân...";
                txtRecordSearch.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        private void TxtRecordSearch_TextChanged(object sender, EventArgs e)
        {
            FilterRecordPatientsList();
        }

        private void FilterRecordPatientsList()
        {
            flpPatients.Controls.Clear();

            string term = txtRecordSearch.Text.Contains("Tìm kiếm bệnh nhân...") ? "" : txtRecordSearch.Text.Trim();
            List<PatientDTO> patients = new List<PatientDTO>();
            try
            {
                patients = patientBUS.FilterList(term);
            }
            catch { }

            foreach (var pat in patients)
            {
                AddPatientRecordRow(pat);
            }
        }

        private void AddPatientRecordRow(PatientDTO pat)
        {
            string init = pat.Name.Substring(0, 1).ToUpper();
            
            var row = new Panel
            {
                Size = new Size(flpPatients.Width - 25, 76),
                BackColor = Color.FromArgb(249, 250, 251),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 0, 0, 8)
            };

            // Set up clicks recursively for child controls
            Action<object, EventArgs> onClick = (s, ev) => SelectRecordPatient(pat);
            row.Click += new EventHandler(onClick);

            var avatar = CreateAvatar(init, 12, 14);
            avatar.Click += new EventHandler(onClick);
            row.Controls.Add(avatar);

            var lblName = CreateLabel(pat.Name, 10.5F, FontStyle.Bold, textMain, 70, 8, 180, 24);
            lblName.Click += new EventHandler(onClick);
            row.Controls.Add(lblName);

            var lblCode = CreateLabel(pat.PatientCode, 8.5F, FontStyle.Regular, textMuted, 70, 32, 180, 18);
            lblCode.Click += new EventHandler(onClick);
            row.Controls.Add(lblCode);

            var lblAge = CreateLabel($"{pat.Age} tuổi - {pat.Gender}", 8.5F, FontStyle.Bold, textMuted, 70, 50, 180, 18);
            lblAge.Click += new EventHandler(onClick);
            row.Controls.Add(lblAge);

            var lblChevron = CreateLabel(">", 16F, FontStyle.Regular, Color.FromArgb(156, 163, 175), row.Width - 36, 20, 24, 30, ContentAlignment.MiddleCenter);
            lblChevron.Click += new EventHandler(onClick);
            lblChevron.Anchor = AnchorStyles.Right;
            row.Controls.Add(lblChevron);

            flpPatients.Controls.Add(row);
        }

        private void SelectRecordPatient(PatientDTO pat)
        {
            // Hide notices
            lblHeart.Visible = false;
            lblNotice1.Visible = false;
            lblNotice2.Visible = false;

            // Show and populate details
            lblPatientName.Text = pat.Name;
            lblPatientName.Visible = true;

            lblPatientMeta.Text = $"Mã BN: {pat.PatientCode} | Giới tính: {pat.Gender} | Tuổi: {pat.Age}";
            lblPatientMeta.Visible = true;

            lblPatientContact.Text = $"SĐT: {pat.Phone} | Địa chỉ: {pat.Address}";
            lblPatientContact.Visible = true;

            lblHistoryTitle.Visible = true;
            flpHistory.Visible = true;

            flpHistory.Controls.Clear();

            // Load patient history
            List<RequestDTO> history = new List<RequestDTO>();
            try
            {
                history = requestBUS.GetRequestsByPatient(pat.PatientID).Where(r => r.Status == "Hoàn thành").ToList();
            }
            catch { }

            if (history.Count == 0)
            {
                var lblEmpty = CreateLabel("Bệnh nhân này chưa có kết quả xét nghiệm hoàn thành nào.", 9.5F, FontStyle.Italic, textMuted, 0, 0, flpHistory.Width - 10, 30);
                flpHistory.Controls.Add(lblEmpty);
                return;
            }

            int cardW = flpHistory.Width - 25;
            foreach (var req in history)
            {
                var card = new RoundedPanel
                {
                    BorderColor = Color.FromArgb(229, 231, 235),
                    CornerRadius = 8,
                    FillColor = Color.FromArgb(249, 250, 251),
                    Size = new Size(cardW, 160),
                    Margin = new Padding(0, 0, 0, 16)
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
                    card.Controls.Add(CreateLabel("Kết quả: Báo cáo xét nghiệm PDF tổng hợp.", 9F, FontStyle.Bold, Color.FromArgb(22, 101, 52), 18, 64, 400, 20));

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

                flpHistory.Controls.Add(card);
            }
        }
    }
}
