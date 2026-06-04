using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianUploadMri : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;
        private string selectedImagePath = "";

        public ucTechnicianUploadMri()
        {
            InitializeComponent();
        }

        private void ucTechnicianUploadMri_Load(object sender, EventArgs e)
        {
            LoadRequests();
            btnSelectFile.Click += BtnSelectFile_Click;
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void ucTechnicianUploadMri_Resize(object sender, EventArgs e)
        {
            // Anchored controls resize automatically.
        }

        private void LoadRequests()
        {
            cboMRIRequests.Items.Clear();
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
        }

        private void BtnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Ảnh kết quả (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    picMRIPreview.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
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
        }
    }
}
