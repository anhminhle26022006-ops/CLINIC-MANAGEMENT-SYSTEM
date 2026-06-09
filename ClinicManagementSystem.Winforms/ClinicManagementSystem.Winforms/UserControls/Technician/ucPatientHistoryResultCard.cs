using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DTO;
using Newtonsoft.Json.Linq;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucPatientHistoryResultCard : UserControl
    {
        private string resultPath;
        private string missingFileMessage;
        private string openErrorTitle;

        public ucPatientHistoryResultCard()
        {
            InitializeComponent();
        }

        public void Configure(TechnicianRequestDTO request)
        {
            lblServiceType.Text = request.ServiceType;
            lblMeta.Text = $"Bác sĩ chỉ định: {request.DoctorName} | Ngày: {request.RequestDate:dd/MM/yyyy HH:mm}";
            lblConclusion.Visible = false;
            btnOpenFile.Visible = false;

            if (!string.IsNullOrEmpty(request.ResultFile))
            {
                lblResult.Text = "Kết quả: Đã chụp phim MRI/X-Ray.";
                lblConclusion.Text = "Kết luận: " + (string.IsNullOrWhiteSpace(request.RequestNote) ? "Không có ghi chú" : request.RequestNote);
                lblConclusion.Visible = true;
                btnOpenFile.Text = "Xem hình phim";
                btnOpenFile.Visible = true;
                resultPath = request.ResultFile;
                missingFileMessage = "Không tìm thấy tệp ảnh phim gốc. Có thể tệp đã bị di chuyển hoặc bị xóa.";
                openErrorTitle = "Lỗi";
            }
            else if (!string.IsNullOrEmpty(request.ResultPDF))
            {
                lblResult.Text = "Kết quả: Báo cáo xét nghiệm PDF tổng hợp.";
                btnOpenFile.Text = "Mở file PDF";
                btnOpenFile.Visible = true;
                resultPath = request.ResultPDF;
                missingFileMessage = "Không tìm thấy file PDF chẩn đoán.";
                openErrorTitle = "Lỗi";
            }
            else if (!string.IsNullOrEmpty(request.LabValues))
            {
                lblResult.Text = "Kết quả: Các chỉ số sinh hóa máu đo được:";
                lblConclusion.Text = BuildLabValueText(request.LabValues);
                lblConclusion.Visible = true;
                resultPath = null;
            }
            else
            {
                lblResult.Text = "Kết quả: Chưa có tệp kết quả đính kèm.";
                resultPath = null;
            }
        }

        private static string BuildLabValueText(string labValues)
        {
            try
            {
                JObject vals = JObject.Parse(labValues);
                return $"RBC: {vals["RBC"]} T/L | WBC: {vals["WBC"]} G/L | Glucose: {vals["Glucose"]} mmol/L | Acid Uric: {vals["UricAcid"]} umol/L";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error parsing LabValues: " + ex);
                return "Dữ liệu chỉ số lab không đúng định dạng.";
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            bool isUrl = !string.IsNullOrEmpty(resultPath) &&
                         (resultPath.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                          resultPath.StartsWith("https://", StringComparison.OrdinalIgnoreCase));

            if (isUrl || File.Exists(resultPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(resultPath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error opening result file: " + ex);
                    MessageBox.Show("Không thể mở file kết quả: " + ex.Message, openErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }

            MessageBox.Show(missingFileMessage, openErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
