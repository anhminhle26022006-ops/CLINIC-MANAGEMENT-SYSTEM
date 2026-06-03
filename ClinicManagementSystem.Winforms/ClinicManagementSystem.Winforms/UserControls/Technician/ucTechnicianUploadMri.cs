﻿﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DAL;
using DTO;
using Newtonsoft.Json.Linq;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
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
            var page = BeginPage("Tải lên phim MRI/X-Ray", "Chụp phim chẩn đoán và tải ảnh kết quả phim lên hệ thống");

            var panel = new RoundedPanel
            {
                BorderColor = Color.FromArgb(229, 231, 235),
                CornerRadius = 8,
                FillColor = surface,
                Height = 600,
                Width = PageWidth(),
                Margin = new Padding(0, 10, 0, 20)
            };

            panel.Controls.Add(CreateLabel("Chọn yêu cầu chụp phim:", 9.5F, FontStyle.Bold, textMain, 24, 24, 300, 22));

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
                list = requestBUS.GetList().Where(r => r.Status != "Hoàn thành" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("Siêu âm"))).ToList();
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
            var btnSelectFile = CreateFlatButton("Chọn tệp phim...", textMain, Color.FromArgb(243, 244, 246), 24, 100, 160, 36);
            btnSelectFile.Click += (s, ev) =>
            {
                using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Ảnh kết quả (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg" })
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

            panel.Controls.Add(CreateLabel("Kết luận / Ghi chú kỹ thuật viên:", 9.5F, FontStyle.Bold, textMain, 360, 100, 300, 22));
            txtMRINote = new TextBox
            {
                Multiline = true,
                Font = new Font("Segoe UI", 10F),
                Location = new Point(360, 130),
                Size = new Size(panel.Width - 384, 260),
                BorderStyle = BorderStyle.FixedSingle
            };
            panel.Controls.Add(txtMRINote);

            var btnSubmit = CreateFlatButton("Tải lên kết quả & Hoàn thành", Color.White, primary, 24, 420, panel.Width - 48, 44);
            btnSubmit.Click += (s, ev) =>
            {
                if (cboMRIRequests.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn yêu cầu thực hiện.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(selectedImagePath))
                {
                    MessageBox.Show("Vui lòng chọn tệp ảnh phim chụp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Tải lên kết quả phim và cập nhật hồ sơ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        activeRequestId = 0;
                        NavigateTo(TechnicianViewTarget.Requests);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            };
            panel.Controls.Add(btnSubmit);

            page.Controls.Add(panel);
        }

        // ==========================================

    }
}

