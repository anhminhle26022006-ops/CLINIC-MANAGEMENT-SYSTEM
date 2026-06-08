using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class RemindingCard : UserControl
    {
        private FollowUpCardDTO currentData;

        private readonly
            FollowUpController controller =
                new();

        public RemindingCard()
        {
            InitializeComponent();
            lblPatientName.Font =
    new Font(
        "Segoe UI",
        12,
        FontStyle.Bold);

            lblPatientName.ForeColor =
                Color.FromArgb(
                    17, 24, 39);

            lblPatientCode.ForeColor =
                Color.FromArgb(
                    107, 114, 128);
            lblPatientName.ForeColor = Color.Black;
            lblPatientCode.ForeColor = Color.DimGray;

            lblPatientName.BackColor = Color.Transparent;
            lblPatientCode.BackColor = Color.Transparent;
        }

        private string GetInitials(string fullName)
        {
            string[] parts = fullName.Split(' ');

            return $"{parts[0][0]}{parts[^1][0]}"
                .ToUpper();
        }

        protected override void OnLoad(
    EventArgs e)
        {
            base.OnLoad(e);

        }


        public void BindData(
    FollowUpCardDTO data)
        {
            currentData = data;

            // Header
            lblPatientName.Text =
                  data.PatientName;

              lblPatientCode.Text =
                  data.PatientCode; 

            // Thông tin chính
            lblDate.Text =
                $"📅 {data.FollowUpDate:dd/MM/yyyy - HH:mm}";

            lblDoctorName.Text =
                $"👨‍⚕️ {data.DoctorName}";

            // DB hiện chưa có các field này
            lblReminder.Text =
                "⏰ 3 ngày";

            lblCreatedBy.Text =
                data.DoctorName;

            lblDiagnosis.Text =
                string.IsNullOrWhiteSpace(
                    data.Diagnosis)
                ? "Chưa có thông tin"
                : data.Diagnosis;

            lblNote.Text =
                "Chưa có ghi chú";

            SetupStatus(data.Status);
        }

        private void SetupStatus(
    string status)
        {
            btnAction.FlatStyle =
                FlatStyle.Flat;

            btnAction.FlatAppearance
                .BorderSize = 0;

            btnAction.ForeColor =
                Color.White;

            switch (status)
            {
                case "Upcoming":

                    lblStatus.Text =
                        "Sắp tới";

                    lblStatus.BackColor =
                        Color.FromArgb(
                            254, 243, 199);

                    lblStatus.ForeColor =
                        Color.FromArgb(
                            217, 119, 6);

                    btnAction.Text =
                        "📞 Gửi nhắc lịch";

                    btnAction.BackColor =
                        Color.FromArgb(
                            37, 99, 235);

                    break;

                case "Reminded":

                    lblStatus.Text =
                        "Đã nhắc";

                    lblStatus.BackColor =
                        Color.FromArgb(
                            219, 234, 254);

                    lblStatus.ForeColor =
                        Color.FromArgb(
                            37, 99, 235);

                    btnAction.Text =
                        "✔ Xác nhận hoàn thành";

                    btnAction.BackColor =
                        Color.FromArgb(
                            22, 163, 74);

                    break;

                case "Overdue":

                    lblStatus.Text =
                        "Quá hạn";

                    lblStatus.BackColor =
                        Color.FromArgb(
                            254, 226, 226);

                    lblStatus.ForeColor =
                        Color.FromArgb(
                            220, 38, 38);

                    btnAction.Text =
                        "📞 Liên hệ ngay";

                    btnAction.BackColor =
                        Color.FromArgb(
                            220, 38, 38);

                    break;

                case "Completed":

                    lblStatus.Text =
                        "Hoàn thành";

                    lblStatus.BackColor =
                        Color.FromArgb(
                            220, 252, 231);

                    lblStatus.ForeColor =
                        Color.FromArgb(
                            22, 163, 74);

                    btnAction.Visible =
                        false;

                    break;
            }
        }

        private void btnAction_Click(
    object sender,
    EventArgs e)
        {
            string nextStatus =
                currentData.Status;

            switch (currentData.Status)
            {
                case "Upcoming":
                    nextStatus = "Reminded";
                    break;

                case "Reminded":
                    nextStatus = "Completed";
                    break;

                case "Overdue":
                    nextStatus = "Completed";
                    break;

                default:
                    return;
            }

            bool success =
                controller.UpdateStatus(
                    currentData.FollowUpID,
                    nextStatus);

            if (!success)
            {
                MessageBox.Show(
                    "Cập nhật thất bại");
                return;
            }

            currentData.Status =
                nextStatus;

            SetupStatus(nextStatus);

            MessageBox.Show(
                "Cập nhật thành công");
        }
    }
}
