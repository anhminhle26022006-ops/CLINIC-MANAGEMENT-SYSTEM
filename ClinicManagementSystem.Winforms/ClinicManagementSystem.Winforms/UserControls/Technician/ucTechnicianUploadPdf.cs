using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianUploadPdf : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianUploadPdf()
        {
            InitializeComponent();
        }

        private void ucTechnicianUploadPdf_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianUploadPdf_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderUploadPDF();
        }

        // 4. UPLOAD PDF VIEW (UploadPDFForm)
        // ==========================================
        private ComboBox cboPDFRequests;
        private Label lblPDFSelectedFile;
        private string selectedPDFPath = "";

        private void RenderUploadPDF()
        {
            var page = BeginPage("Táº£i lÃªn káº¿t quáº£ xÃ©t nghiá»‡m PDF", "Táº£i tá»‡p PDF káº¿t quáº£ xÃ©t nghiá»‡m tá»•ng há»£p lÆ°u vÃ o há»“ sÆ¡ Ä‘iá»‡n tá»­");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 400,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Chá»n yÃªu cáº§u xÃ©t nghiá»‡m tá»•ng quÃ¡t:", 9.5F, FontStyle.Bold, textMain, 24, 24, 400, 22));

            cboPDFRequests = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(24, 50),
                Size = new Size(panel.Width - 48, 30)
            };
            panel.Controls.Add(cboPDFRequests);

            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList().Where(r => r.Status != "HoÃ n thÃ nh" && (r.ServiceType.Contains("XÃ©t nghiá»‡m mÃ¡u tá»•ng quÃ¡t") || r.ServiceType.ToLower().Contains("pdf"))).ToList();
            }
            catch { }

            foreach (var req in list)
            {
                cboPDFRequests.Items.Add(new ComboBoxItem { Text = $"BN: {req.PatientName} ({req.PatientCode}) - {req.ServiceType}", Value = req.RequestID });
            }

            if (activeRequestId > 0)
            {
                try
                {
                    var activeReq = requestBUS.GetList().FirstOrDefault(r => r.RequestID == activeRequestId);
                    if (activeReq != null)
                    {
                        cboPDFRequests.Items.Clear();
                        cboPDFRequests.Items.Add(new ComboBoxItem { Text = $"BN: {activeReq.PatientName} ({activeReq.PatientCode}) - {activeReq.ServiceType}", Value = activeReq.RequestID });
                        cboPDFRequests.SelectedIndex = 0;
                        cboPDFRequests.Enabled = false;
                    }
                }
                catch { }
            }
            else if (cboPDFRequests.Items.Count > 0)
            {
                cboPDFRequests.SelectedIndex = 0;
            }

            var btnSelect = CreateFlatButton("Chá»n tá»‡p PDF...", textMain, Color.FromArgb(243, 244, 246), 24, 105, 180, 38);
            btnSelect.Click += (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Tá»‡p PDF káº¿t quáº£ (*.pdf)|*.pdf" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        selectedPDFPath = ofd.FileName;
                        lblPDFSelectedFile.Text = "ÄÃ£ chá»n: " + Path.GetFileName(selectedPDFPath);
                        lblPDFSelectedFile.ForeColor = primary;
                    }
                }
            };
            panel.Controls.Add(btnSelect);

            lblPDFSelectedFile = CreateLabel("ChÆ°a chá»n file PDF nÃ o", 9.5F, FontStyle.Italic, textMuted, 24, 155, panel.Width - 48, 22);
            panel.Controls.Add(lblPDFSelectedFile);

            var btnSubmit = CreateFlatButton("LÆ°u tá»‡p PDF vÃ o há»“ sÆ¡ bá»‡nh Ã¡n", Color.White, primary, 24, 200, panel.Width - 48, 44);
            btnSubmit.Click += (s, ev) =>
            {
                if (cboPDFRequests.SelectedItem == null)
                {
                    MessageBox.Show("Vui lÃ²ng chá»n yÃªu cáº§u.", "Cáº£nh bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(selectedPDFPath))
                {
                    MessageBox.Show("Vui lÃ²ng chá»n tá»‡p PDF káº¿t quáº£.", "Cáº£nh bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int reqId = ((ComboBoxItem)cboPDFRequests.SelectedItem).Value;
                    string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    string destFile = Path.Combine(uploadFolder, Guid.NewGuid().ToString() + ".pdf");
                    File.Copy(selectedPDFPath, destFile, true);

                    bool ok = requestBUS.SavePDFResult(reqId, destFile);
                    if (ok)
                    {
                        MessageBox.Show("Táº£i lÃªn tá»‡p PDF vÃ  lÆ°u há»“ sÆ¡ thÃ nh cÃ´ng!", "ThÃ nh cÃ´ng", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

