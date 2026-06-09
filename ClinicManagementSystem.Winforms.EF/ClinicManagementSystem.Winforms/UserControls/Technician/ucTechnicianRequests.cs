using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DTO;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianRequests : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianRequests()
        {
            InitializeComponent();
        }

        private void ucTechnicianRequests_Load(object sender, EventArgs e)
        {
            txtRequestSearch.Enter += TxtRequestSearch_Enter;
            txtRequestSearch.Leave += TxtRequestSearch_Leave;
            txtRequestSearch.TextChanged += TxtRequestSearch_TextChanged;
            comboRequestStatusFilter.SelectedIndexChanged += ComboRequestStatusFilter_SelectedIndexChanged;
            btnSyncCloud.Click += BtnSyncCloud_Click;

            LoadRequests();
        }

        private void ucTechnicianRequests_Resize(object sender, EventArgs e)
        {
            ResizeRequestCards();
        }

        private void TxtRequestSearch_Enter(object sender, EventArgs e)
        {
            if (txtRequestSearch.Text.Contains("Tìm kiếm bệnh nhân hoặc tên xét nghiệm..."))
            {
                txtRequestSearch.Text = "";
                txtRequestSearch.ForeColor = textMain;
            }
        }

        private void TxtRequestSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequestSearch.Text))
            {
                txtRequestSearch.Text = "Tìm kiếm bệnh nhân hoặc tên xét nghiệm...";
                txtRequestSearch.ForeColor = Color.FromArgb(148, 163, 184);
            }
        }

        private void TxtRequestSearch_TextChanged(object sender, EventArgs e)
        {
            FilterRequestsList();
        }

        private void ComboRequestStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterRequestsList();
        }

        private void LoadRequests()
        {
            List<TechnicianRequestDTO> list = new List<TechnicianRequestDTO>();
            try
            {
                list = requestBUS.GetList();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading requests list: " + ex);
            }

            int pending = list.Count(r => r.Status == "Chờ xử lý");
            int processing = list.Count(r => r.Status == "Đang xử lý");
            int completed = list.Count(r => r.Status == "Hoàn thành");

            lblStatPendingNum.Text = pending.ToString();
            lblStatProcessingNum.Text = processing.ToString();
            lblStatCompletedNum.Text = completed.ToString();
            lblStatTotalNum.Text = list.Count.ToString();

            comboRequestStatusFilter.SelectedIndex = 0;
            RenderFilteredRequests(list);
        }

        private void FilterRequestsList()
        {
            string term = txtRequestSearch.Text.Contains("Tìm kiếm") ? "" : txtRequestSearch.Text.Trim();
            string status = comboRequestStatusFilter.SelectedItem != null ? comboRequestStatusFilter.SelectedItem.ToString() : "Tất cả trạng thái";
            List<TechnicianRequestDTO> filtered = new List<TechnicianRequestDTO>();
            try
            {
                filtered = requestBUS.FilterList(term, status);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error filtering requests: " + ex);
            }
            RenderFilteredRequests(filtered);
        }

        private void RenderFilteredRequests(List<TechnicianRequestDTO> filteredList)
        {
            flpRequests.Controls.Clear();

            // Group requests by PatientID, DoctorID, and RequestDate (same day)
            var grouped = filteredList
                .GroupBy(r => new { r.PatientID, r.DoctorID, Date = r.RequestDate.Date })
                .ToList();

            foreach (var group in grouped)
            {
                var card = CreateGroupedRequestCard(group.ToList());
                flpRequests.Controls.Add(card);
            }
        }

        private Control CreateGroupedRequestCard(List<TechnicianRequestDTO> requests)
        {
            var first = requests.First();
            bool allCompleted = requests.All(r => r.Status == "Hoàn thành");
            bool anyProcessing = requests.Any(r => r.Status == "Đang xử lý");

            var borderColor = allCompleted ? Color.FromArgb(187, 247, 208) : (anyProcessing ? primary : Color.FromArgb(252, 165, 165));
            int cardWidth = RequestCardWidth();
            var card = new ucTechnicianRequestGroupCard
            {
                Size = new Size(cardWidth, 198),
                Margin = new Padding(0, 0, 0, 18)
            };
            card.ConfigureHeader(first.PatientName, first.PatientCode, first.DoctorName, first.RequestDate, borderColor);

            foreach (var req in requests)
            {
                var row = new ucTechnicianRequestServiceRow();
                row.Configure(req.ServiceType, req.RequestNote, req.Priority, req.Status);
                row.ViewClicked += (s, ev) => NavigateTo(TechnicianViewTarget.Records, req.RequestID);
                row.ActionClicked += (s, ev) =>
                {
                    try
                    {
                        if (req.Status == "Chờ xử lý")
                        {
                            requestBUS.StartProcessing(req.RequestID);
                            req.Status = "Đang xử lý";
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error StartProcessing: " + ex);
                    }

                    if (CMS.Core.Utils.ServiceTypeHelper.IsImagingService(req.ServiceType))
                    {
                        NavigateTo(TechnicianViewTarget.UploadMRI, req.RequestID);
                    }
                    else if (CMS.Core.Utils.ServiceTypeHelper.IsPdfUploadService(req.ServiceType))
                    {
                        NavigateTo(TechnicianViewTarget.UploadPDF, req.RequestID);
                    }
                    else
                    {
                        NavigateTo(TechnicianViewTarget.LabResult, req.RequestID);
                    }
                };
                card.AddServiceRow(row);
            }

            return card;
        }

        private int RequestCardWidth()
        {
            return Math.Max(720, flpRequests.ClientSize.Width - 12);
        }

        private void ResizeRequestCards()
        {
            int width = RequestCardWidth();
            foreach (Control card in flpRequests.Controls)
            {
                card.Width = width;
            }
        }

        private async void BtnSyncCloud_Click(object sender, EventArgs e)
        {
            btnSyncCloud.Enabled = false;
            string originalText = btnSyncCloud.Text;
            btnSyncCloud.Text = "Đang đồng bộ...";

            try
            {
                var apiSyncBUS = new BUS.Services.ApiSyncBUS();
                string resultMessage = await apiSyncBUS.SyncRequestsFromSupabaseAsync();
                LoadRequests();
                MessageBox.Show(resultMessage, "Đồng bộ thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error during requests sync: " + ex);
                MessageBox.Show("Có lỗi xảy ra khi đồng bộ yêu cầu:\n" + ex.Message, "Lỗi đồng bộ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSyncCloud.Text = originalText;
                btnSyncCloud.Enabled = true;
            }
        }
    }
}
