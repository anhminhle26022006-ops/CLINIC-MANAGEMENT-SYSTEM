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

            if (activeRequestId != 0)
            {
                try
                {
                    var req = requestBUS.GetList().FirstOrDefault(r => r.RequestID == activeRequestId);
                    if (req != null)
                    {
                        var patient = patientBUS.FilterList("").FirstOrDefault(p => p.PatientID == req.PatientID);
                        if (patient != null)
                        {
                            SelectRecordPatient(patient);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error in ucPatientRecords_Load activeRequestId: " + ex);
                }
            }
        }

        private void ucPatientRecords_Resize(object sender, EventArgs e)
        {
            ResizePatientRows();
            ResizeHistoryCards();
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error filtering patients: " + ex);
            }

            foreach (var pat in patients)
            {
                AddPatientRecordRow(pat);
            }
        }

        private void AddPatientRecordRow(PatientDTO pat)
        {
            var row = new ucPatientRecordRow
            {
                Width = PatientRowWidth(),
                Margin = new Padding(0, 0, 0, 12)
            };
            row.Configure(pat);
            row.PatientClicked += (s, ev) => SelectRecordPatient(pat);

            flpPatients.Controls.Add(row);
        }

        private int PatientRowWidth()
        {
            return Math.Max(420, flpPatients.ClientSize.Width - 10);
        }

        private void ResizePatientRows()
        {
            int width = PatientRowWidth();
            foreach (Control row in flpPatients.Controls)
            {
                row.Width = width;
            }
        }

        private int HistoryCardWidth()
        {
            return Math.Max(640, flpHistory.ClientSize.Width - 12);
        }

        private void ResizeHistoryCards()
        {
            int width = HistoryCardWidth();
            foreach (Control card in flpHistory.Controls)
            {
                card.Width = width;
            }
        }

        private void SelectRecordPatient(PatientDTO pat)
        {
            // Hide notices
            lblHeart.Visible = false;
            lblNotice1.Visible = false;
            lblNotice2.Visible = false;

            // Show and populate details
            lblPatientName.Text = pat.Name;
            lblPatientName.Width = Math.Max(420, pnlRight.ClientSize.Width - 48);
            lblPatientName.Visible = true;

            lblPatientMeta.Text = $"Mã BN: {pat.PatientCode} | Giới tính: {pat.Gender} | Tuổi: {pat.Age}";
            lblPatientMeta.Width = Math.Max(420, pnlRight.ClientSize.Width - 48);
            lblPatientMeta.Visible = true;

            lblPatientContact.Text = $"SĐT: {pat.Phone} | Địa chỉ: {pat.Address}";
            lblPatientContact.Width = Math.Max(420, pnlRight.ClientSize.Width - 48);
            lblPatientContact.Visible = true;

            lblHistoryTitle.Visible = true;
            flpHistory.Visible = true;

            flpHistory.Controls.Clear();

            // Load patient history
            List<TechnicianRequestDTO> history = new List<TechnicianRequestDTO>();
            try
            {
                history = requestBUS.GetRequestsByPatient(pat.PatientID).Where(r => r.Status == "Hoàn thành").ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting patient history: " + ex);
            }

            if (history.Count == 0)
            {
                var lblEmpty = CreateLabel("Bệnh nhân này chưa có kết quả xét nghiệm hoàn thành nào.", 9.5F, FontStyle.Italic, textMuted, 0, 0, flpHistory.Width - 10, 30);
                flpHistory.Controls.Add(lblEmpty);
                return;
            }

            int cardW = HistoryCardWidth();
            foreach (var req in history)
            {
                var card = new ucPatientHistoryResultCard
                {
                    Width = cardW,
                    Margin = new Padding(0, 0, 0, 16)
                };
                card.Configure(req);
                flpHistory.Controls.Add(card);
            }
        }
    }
}
