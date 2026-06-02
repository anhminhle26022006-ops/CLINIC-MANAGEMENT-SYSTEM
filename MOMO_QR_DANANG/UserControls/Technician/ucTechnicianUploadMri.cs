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
    public partial class ucTechnicianUploadMri : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianUploadMri()
        {
            InitializeComponent();
        }

        private void ucTechnicianUploadMri_Load(object sender, EventArgs e)
        {
            RenderView();
        }

        private void ucTechnicianUploadMri_Resize(object sender, EventArgs e)
        {
            if (Width < 400) return;
            RenderView();
        }

        private void RenderView()
        {
            RenderUploadMRI();
        }

        // 3. UPLOAD MRI VIEW (UploadMRIForm)
        // ==========================================
        private ComboBox cboMRIRequests;
        private PictureBox picMRIPreview;
        private TextBox txtMRINote;
        private string selectedImagePath = "";

        private void RenderUploadMRI()
        {
            var page = BeginPage("Táº£i lÃªn phim MRI/X-Ray", "Chá»¥p phim cháº©n Ä‘oÃ¡n vÃ  táº£i áº£nh káº¿t quáº£ phim lÃªn há»‡ thá»‘ng");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 600,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Chá»n yÃªu cáº§u chá»¥p phim:", 9.5F, FontStyle.Bold, textMain, 24, 24, 300, 22));

            cboMRIRequests = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(24, 50),
                Size = new Size(panel.Width - 48, 30)
            };
            panel.Controls.Add(cboMRIRequests);

            // Populate combo
            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList().Where(r => r.Status != "HoÃ n thÃ nh" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("SiÃªu Ã¢m"))).ToList();
            }
            catch { }

            foreach (var req in list)
            {
                cboMRIRequests.Items.Add(new ComboBoxItem { Text = $"BN: {req.PatientName} ({req.PatientCode}) - {req.ServiceType}", Value = req.RequestID });
            }

            // Handle pre-selected request
            if (activeRequestId > 0)
            {
                try
                {
                    var activeReq = requestBUS.GetList().FirstOrDefault(r => r.RequestID == activeRequestId);
                    if (activeReq != null)
                    {
                        cboMRIRequests.Items.Clear();
                        cboMRIRequests.Items.Add(new ComboBoxItem { Text = $"BN: {activeReq.PatientName} ({activeReq.PatientCode}) - {activeReq.ServiceType}", Value = activeReq.RequestID });
                        cboMRIRequests.SelectedIndex = 0;
                        cboMRIRequests.Enabled = false;
                    }
                }
                catch { }
            }
            else if (cboMRIRequests.Items.Count > 0)
            {
                cboMRIRequests.SelectedIndex = 0;
            }

            // Image picker elements
            var btnSelectFile = CreateFlatButton("Chá»n tá»‡p phim...", textMain, Color.FromArgb(243, 244, 246), 24, 100, 160, 36);
            btnSelectFile.Click += (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog { Filter = "áº¢nh káº¿t quáº£ (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg" })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        selectedImagePath = ofd.FileName;
                        picMRIPreview.Image = Image.FromFile(selectedImagePath);
                    }
                }
            };
            panel.Controls.Add(btnSelectFile);

            picMRIPreview = new PictureBox
            {
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(24, 150),
                Size = new Size(300, 240),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.FromArgb(243, 244, 246)
            };
            panel.Controls.Add(picMRIPreview);

            panel.Controls.Add(CreateLabel("Káº¿t luáº­n / Ghi chÃº ká»¹ thuáº­t viÃªn:", 9.5F, FontStyle.Bold, textMain, 360, 100, 300, 22));
            txtMRINote = new TextBox
            {
                Multiline = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(360, 130),
                Size = new Size(panel.Width - 384, 260),
                BorderStyle = BorderStyle.FixedSingle
            };
            panel.Controls.Add(txtMRINote);

            var btnSubmit = CreateFlatButton("Táº£i lÃªn káº¿t quáº£ & HoÃ n thÃ nh", Color.White, primary, 24, 420, panel.Width - 48, 44);
            btnSubmit.Click += (s, ev) =>
            {
                if (cboMRIRequests.SelectedItem == null)
                {
                    MessageBox.Show("Vui lÃ²ng chá»n yÃªu cáº§u thá»±c hiá»‡n.", "Cáº£nh bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(selectedImagePath))
                {
                    MessageBox.Show("Vui lÃ²ng chá»n tá»‡p áº£nh phim chá»¥p.", "Cáº£nh bÃ¡o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    int reqId = ((ComboBoxItem)cboMRIRequests.SelectedItem).Value;
                    string uploadFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    string destFile = Path.Combine(uploadFolder, Guid.NewGuid().ToString() + Path.GetExtension(selectedImagePath));
                    File.Copy(selectedImagePath, destFile, true);

                    bool ok = requestBUS.SaveImagingResult(reqId, destFile, txtMRINote.Text.Trim());
                    if (ok)
                    {
                        MessageBox.Show("Táº£i lÃªn káº¿t quáº£ phim vÃ  cáº­p nháº­t há»“ sÆ¡ thÃ nh cÃ´ng!", "ThÃ nh cÃ´ng", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

