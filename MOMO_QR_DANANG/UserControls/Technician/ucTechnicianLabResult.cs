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
    public partial class ucTechnicianLabResult : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianLabResult()
        {
            InitializeComponent();
        }

        private void ucTechnicianLabResult_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianLabResult_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderLabResult();
        }

        // 5. LAB RESULT VIEW (LabResultForm)
        // ==========================================
        private ComboBox cboLabRequests;
        private TextBox txtRBC, txtWBC, txtGlucose, txtUricAcid;

        private void RenderLabResult()
        {
            var page = BeginPage("Nháº­p káº¿t quáº£ chá»‰ sá»‘ Lab", "Nháº­p cÃ¡c chá»‰ sá»‘ sinh hÃ³a mÃ¡u cá»§a bá»‡nh nhÃ¢n tá»« phÃ²ng Lab");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 450,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Chá»n yÃªu cáº§u xÃ©t nghiá»‡m sinh hÃ³a:", 9.5F, FontStyle.Bold, textMain, 24, 24, 300, 22));

            cboLabRequests = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(24, 50),
                Size = new Size(panel.Width - 48, 30)
            };
            panel.Controls.Add(cboLabRequests);

            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList().Where(r => r.Status != "HoÃ n thÃ nh" && !r.ServiceType.Contains("MRI") && !r.ServiceType.Contains("X-quang") && !r.ServiceType.Contains("SiÃªu Ã¢m") && !r.ServiceType.Contains("xÃ©t nghiá»‡m mÃ¡u tá»•ng quÃ¡t")).ToList();
            }
            catch { }

            foreach (var req in list)
            {
                cboLabRequests.Items.Add(new ComboBoxItem { Text = $"BN: {req.PatientName} ({req.PatientCode}) - {req.ServiceType}", Value = req.RequestID });
            }

            if (activeRequestId > 0)
            {
                try
                {
                    var activeReq = requestBUS.GetList().FirstOrDefault(r => r.RequestID == activeRequestId);
                    if (activeReq != null)
                    {
                        cboLabRequests.Items.Clear();
                        cboLabRequests.Items.Add(new ComboBoxItem { Text = $"BN: {activeReq.PatientName} ({activeReq.PatientCode}) - {activeReq.ServiceType}", Value = activeReq.RequestID });
                        cboLabRequests.SelectedIndex = 0;
                        cboLabRequests.Enabled = false;
                    }
                }
                catch { }
            }
            else if (cboLabRequests.Items.Count > 0)
            {
                cboLabRequests.SelectedIndex = 0;
            }

            // Input Fields
            int x1 = 24, x2 = 360;
            panel.Controls.Add(CreateLabel("Há»“ng cáº§u (RBC) - T.chuáº©n: 3.8 - 5.8 T/L", 9F, FontStyle.Bold, textMain, x1, 100, 300, 22));
            txtRBC = new TextBox { Font = new Font("Segoe UI", 10F), Location = new Point(x1, 125), Size = new Size(280, 28), BorderStyle = BorderStyle.FixedSingle, Text = "4.5" };
            panel.Controls.Add(txtRBC);

            panel.Controls.Add(CreateLabel("Báº¡ch cáº§u (WBC) - T.chuáº©n: 4.0 - 10.0 G/L", 9F, FontStyle.Bold, textMain, x2, 100, 300, 22));
            txtWBC = new TextBox { Font = new Font("Segoe UI", 10F), Location = new Point(x2, 125), Size = new Size(280, 28), BorderStyle = BorderStyle.FixedSingle, Text = "7.2" };
            panel.Controls.Add(txtWBC);

            panel.Controls.Add(CreateLabel("ÄÆ°á»ng huyáº¿t (Glucose) - T.chuáº©n: 3.9 - 6.4 mmol/L", 9F, FontStyle.Bold, textMain, x1, 180, 300, 22));
            txtGlucose = new TextBox { Font = new Font("Segoe UI", 10F), Location = new Point(x1, 205), Size = new Size(280, 28), BorderStyle = BorderStyle.FixedSingle, Text = "5.6" };
            panel.Controls.Add(txtGlucose);

            panel.Controls.Add(CreateLabel("Acid Uric - T.chuáº©n: 140 - 420 umol/L", 9F, FontStyle.Bold, textMain, x2, 180, 300, 22));
            txtUricAcid = new TextBox { Font = new Font("Segoe UI", 10F), Location = new Point(x2, 205), Size = new Size(280, 28), BorderStyle = BorderStyle.FixedSingle, Text = "310" };
            panel.Controls.Add(txtUricAcid);

            var btnSubmit = CreateFlatButton("LÆ°u chá»‰ sá»‘ xÃ©t nghiá»‡m & XÃ¡c nháº­n káº¿t quáº£", Color.White, primary, 24, 290, panel.Width - 48, 44);
            btnSubmit.Click += (s, ev) =>
            {
                if (cboLabRequests.SelectedItem == null)
                {
                    MessageBox.Show("Vui lÃ²ng chá»n yÃªu cáº§u xÃ©t nghiá»‡m.", "Cáº£nh bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check floats
                if (!double.TryParse(txtRBC.Text, out _) || !double.TryParse(txtWBC.Text, out _) ||
                    !double.TryParse(txtGlucose.Text, out _) || !double.TryParse(txtUricAcid.Text, out _))
                {
                    MessageBox.Show("Vui lÃ²ng Ä‘iá»n Ä‘Ãºng thÃ´ng sá»‘ káº¿t quáº£ (pháº£i lÃ  sá»‘ thá»±c).", "Lá»—i dá»¯ liá»‡u", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    int reqId = ((ComboBoxItem)cboLabRequests.SelectedItem).Value;

                    // Build JSON object
                    JObject json = new JObject();
                    json["RBC"] = txtRBC.Text.Trim();
                    json["WBC"] = txtWBC.Text.Trim();
                    json["Glucose"] = txtGlucose.Text.Trim();
                    json["UricAcid"] = txtUricAcid.Text.Trim();

                    bool ok = requestBUS.SaveLabResult(reqId, json.ToString());
                    if (ok)
                    {
                        MessageBox.Show("LÆ°u káº¿t quáº£ xÃ©t nghiá»‡m thÃ nh cÃ´ng!", "ThÃ nh cÃ´ng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        activeRequestId = 0;
                        NavigateTo(TechnicianViewTarget.Requests);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lá»—i: " + ex.Message);
                }
            };
            panel.Controls.Add(btnSubmit);

            page.Controls.Add(panel);
        }

        // ==========================================

    }
}

