using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianUploadPdf : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;
        private string selectedPDFPath = "";

        public ucTechnicianUploadPdf()
        {
            InitializeComponent();
        }

        private void ucTechnicianUploadPdf_Load(object sender, EventArgs e)
        {
            LoadRequests();
            btnSelect.Click += BtnSelect_Click;
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void ucTechnicianUploadPdf_Resize(object sender, EventArgs e)
        {
            // Anchored controls resize automatically.
        }

        private void LoadRequests()
        {
            cboPDFRequests.Items.Clear();
            List<RequestDTO> list = new List<RequestDTO>();
            try
            {
                list = requestBUS.GetList().Where(r => r.Status != "Hoàn thành" && (r.ServiceType.Contains("Xét nghiệm máu tổng quát") || r.ServiceType.ToLower().Contains("pdf"))).ToList();
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
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Tệp PDF kết quả (*.pdf)|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedPDFPath = ofd.FileName;
                    lblPDFSelectedFile.Text = "Đã chọn: " + Path.GetFileName(selectedPDFPath);
                    lblPDFSelectedFile.ForeColor = primary;
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cboPDFRequests.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(selectedPDFPath))
            {
                MessageBox.Show("Vui lòng chọn tệp PDF kết quả.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Tải lên tệp PDF và lưu hồ sơ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
