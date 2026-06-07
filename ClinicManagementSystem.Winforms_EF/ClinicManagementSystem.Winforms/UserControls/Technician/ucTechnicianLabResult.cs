using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
using Newtonsoft.Json.Linq;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
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
            LoadRequests();
            btnSubmit.Click += BtnSubmit_Click;
        }

        private void ucTechnicianLabResult_Resize(object sender, EventArgs e)
        {
            // Controls are anchored inside the designer, so they resize automatically.
        }

        private void LoadRequests()
        {
            cboLabRequests.Items.Clear();
            List<TechnicianRequestDTO> list = new List<TechnicianRequestDTO>();
            try
            {
                list = requestBUS.GetList().Where(r => r.Status != "Hoàn thành" && !CMS.Core.Utils.ServiceTypeHelper.IsImagingService(r.ServiceType) && !CMS.Core.Utils.ServiceTypeHelper.IsPdfUploadService(r.ServiceType)).ToList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading Lab requests: " + ex);
            }

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
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error loading active Lab request: " + ex);
                }
            }
            else if (cboLabRequests.Items.Count > 0)
            {
                cboLabRequests.SelectedIndex = 0;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (cboLabRequests.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn yêu cầu xét nghiệm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check floats
            if (!double.TryParse(txtRBC.Text, out _) || !double.TryParse(txtWBC.Text, out _) ||
                !double.TryParse(txtGlucose.Text, out _) || !double.TryParse(txtUricAcid.Text, out _))
            {
                MessageBox.Show("Vui lòng điền đúng thông số kết quả (phải là số thực).", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Lưu kết quả xét nghiệm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    activeRequestId = 0;
                    NavigateTo(TechnicianViewTarget.Requests);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error submitting Lab result: " + ex);
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
