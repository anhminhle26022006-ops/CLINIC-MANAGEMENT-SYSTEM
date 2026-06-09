using BUS.Services.Doctor;
using ClinicManagementSystem.Winforms.Controllers;
using CMS.Core.Session;
using DAL.Repositories.Doctor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.UserControls.Doctor;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh;
using ClinicManagementSystem.Winforms.Shareforms.ERM;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class doctordashboard : UserControl
    {
        private readonly DoctorDashboardController _controller;

        public doctordashboard()
        {
            InitializeComponent();

            var repo = new DoctorDashboardRepository();
            var service = new DoctorDashboardService(repo);
            _controller = new DoctorDashboardController(service);

            // BUG FIX: Do NOT call LoadDashboard() here in the constructor.
            // UserSession.EmployeeID may not be set yet when the control is
            // being constructed (e.g. during designer init or form setup),
            // so doctorId would be 0 and every query returns nothing.
            // Wire up to the Load event instead — by then the session is ready.
            this.Load += doctordashboard_Load;

            btnViewWeek.Click += btnViewWeek_Click;
            btnChangeShift.Click += btnChangeShift_Click;

            pnlActLab.Click += (s, e) => SwitchToSidebar(new ucAppointmentSidebar());
            pnlActScan.Click += (s, e) => SwitchToSidebar(new ucDoctorExaminationSidebar());
            pnlActPdf.Click += (s, e) => SwitchToSidebar(new ucMedicalRecordSidebar());
            pnlActResult.Click += (s, e) => SwitchToSidebar(new ucPrescriptionSidebar());
        }

        private void doctordashboard_Load(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void SwitchToSidebar(UserControl sidebar)
        {
            var form = this.FindForm();
            if (form == null) return;

            var pnlContent = form.Controls.Find("contentPanel", true).FirstOrDefault() as Panel;
            if (pnlContent == null)
            {
                MessageBox.Show("Không tìm thấy contentPanel!", "Lỗi");
                return;
            }

            pnlContent.Controls.Clear();
            sidebar.Dock = DockStyle.Fill;   // fill vào panel chính
            pnlContent.Controls.Add(sidebar);
        }

        private void LoadDashboard()
        {
            int doctorId = UserSession.EmployeeID;

            // Guard: if session isn't set, don't query with ID=0
            if (doctorId <= 0)
            {
                lblStatLabNum.Text = "-";
                lblStatScanNum.Text = "-";
                lblStatCompletedNum.Text = "-";
                lblStatProcessingNum.Text = "-";
                lblShiftName.Text = "Chưa đăng nhập";
                lblShiftRoom.Text = "";
                lblShiftDept.Text = "";
                lblShiftBadge.Text = "";
                return;
            }

            var data = _controller.Load(doctorId);

            lblStatLabNum.Text = data.TodayAppointments.ToString(); // Sửa thành TodayAppointments
            lblStatScanNum.Text = data.WaitingPatients.ToString();
            lblStatCompletedNum.Text = data.CompletedToday.ToString();
            lblStatProcessingNum.Text = data.InProgress.ToString();

            lblShiftName.Text = data.TodayShift.ShiftName;
            lblShiftRoom.Text = $"Phòng: {data.TodayShift.RoomCode}";
            lblShiftDept.Text = data.TodayShift.DepartmentName;
            lblShiftBadge.Text = data.TodayShift.IsOnDuty ? "Đang trực" : "Không trực";
        }
    
    private void btnViewWeek_Click(object sender, EventArgs e)
        {
            // Sau này bạn có thể mở form lịch tuần, tạm thời hiển thị message
            MessageBox.Show("Chức năng xem lịch tuần đang được xây dựng.", "Lịch tuần");
        }

        private void btnChangeShift_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại chọn ca đơn giản
            Form shiftForm = new Form()
            {
                Text = "Đổi ca làm việc",
                Width = 300,
                Height = 200,
                StartPosition = FormStartPosition.CenterParent
            };

            ComboBox cboShift = new ComboBox()
            {
                Left = 20,
                Top = 20,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboShift.Items.Add(new { Text = "Ca sáng (07:00-11:00)", Value = 1 });
            cboShift.Items.Add(new { Text = "Ca chiều (13:00-17:00)", Value = 2 });
            cboShift.Items.Add(new { Text = "Ca tối (17:00-21:00)", Value = 3 });
            cboShift.DisplayMember = "Text";
            cboShift.SelectedIndex = 0;

            Button btnOK = new Button()
            {
                Text = "Xác nhận",
                Left = 20,
                Top = 60,
                Width = 100
            };
            btnOK.Click += (s2, ev2) =>
            {
                dynamic selected = cboShift.SelectedItem;
                int newShiftId = selected.Value;
                int doctorId = UserSession.EmployeeID;

                try
                {
                    _controller.ChangeShift(doctorId, newShiftId);
                    MessageBox.Show("Đổi ca thành công!", "Thành công");
                    shiftForm.Close();
                    LoadDashboard(); // Cập nhật lại giao diện
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
                }
            };

            shiftForm.Controls.Add(cboShift);
            shiftForm.Controls.Add(btnOK);
            shiftForm.ShowDialog();
        }
    }
}