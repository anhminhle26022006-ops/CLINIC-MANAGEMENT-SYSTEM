using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using ClinicManagementSystem.Winforms.Forms;
using ClinicManagementSystem.Winforms.Forms.reception;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class CreateAppointment : UserControl
    {
        private readonly CreateAppointmentController controller =
    new();
        private int selectedDepartmentId = -1;

        private int selectedDoctorId = -1;

        private TimeSpan? selectedTime = null;
        private DateTime selectedDate;
        private DoctorCardDTO selectedDoctor;

        public CreateAppointment()
        {
            InitializeComponent();
            ReceptionDemoDataSeeder.EnsureSeeded();
        }

        private void CreateAppointment_Load(
    object sender,
    EventArgs e)
        {
            panelInf.Visible = false;
            LoadPatients();

            LoadDepartments();

            dtpDate.MinDate =
                DateTime.Today;
            selectedDate = dtpDate.Value.Date;
            InitializeTimeSlots();
            SelectTimeSlot(btn0800);
        }

        private void TimeSlot_Click(
    object sender,
    EventArgs e)
        {
            Button btn =
                sender as Button;

            if (btn == null)
                return;

            SelectTimeSlot(btn);

            if (selectedDepartmentId > 0)
            {
                LoadDoctors(
                    selectedDepartmentId,
                    selectedDate,
                    selectedTime.Value);
                UpdateAppointmentInfo();
            }
        }

        private void InitializeTimeSlots()
        {
            foreach (Button button in GetTimeSlotButtons())
            {
                button.Tag = button.Text.Trim().PadLeft(5, '0');
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
            }
        }

        private Button[] GetTimeSlotButtons()
        {
            return new[]
            {
                btn0800, btn0830, btn0900, btn0930,
                btn1000, btn1030, btn1100, btn1130,
                btn1330, btn1400, btn1430, btn1500,
                btn1530, btn1600, btn1630, btn1700
            };
        }

        private void SelectTimeSlot(Button btn)
        {
            foreach (Button b in GetTimeSlotButtons())
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;
            }

            btn.BackColor = Color.FromArgb(59, 130, 246);
            btn.ForeColor = Color.White;

            string timeText = btn.Tag?.ToString();
            if (string.IsNullOrWhiteSpace(timeText))
            {
                timeText = btn.Text.Trim();
            }

            selectedTime = TimeSpan.Parse(timeText);
            selectedDoctorId = -1;
            selectedDoctor = null;
            panelInf.Visible = false;
        }

        private void dtpDate_ValueChanged(
    object sender,
    EventArgs e)
        {
            selectedDate = dtpDate.Value.Date;
            if (selectedDepartmentId > 0
                && selectedTime.HasValue)
            {
                LoadDoctors(
                    selectedDepartmentId,
                    selectedDate,
                    selectedTime.Value);
                UpdateAppointmentInfo();
            }
        }

        private void LoadPatients()
        {
            var patients = controller.GetPatients();

            cbPatient.DataSource = patients;

            cbPatient.DisplayMember = "Name";

            cbPatient.ValueMember = "PatientID";

            cbPatient.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cbPatient.SelectedIndex = -1;
        }

        private void LoadDepartments()
        {
            flpDepartments.Controls.Clear();

            var departments =
                controller.GetDepartments()
                    .Where(d => controller.GetDoctorsByDepartment(d.DepartmentID).Any())
                    .ToList();

            foreach (var department in departments)
            {
                flpDepartments.Controls.Add(
                    CreateDepartmentCard(
                        department));
            }
        }

        private string GetDepartmentIcon(
    string departmentName)
        {
            return departmentName switch
            {
                "Khám tổng quát" => "🩺",
                "Nhi khoa" => "👶",
                "Da liễu" => "🧴",
                "Mắt" => "👁",
                "Tai Mũi Họng" => "👂",
                "Răng Hàm Mặt" => "🦷",
                "Chẩn đoán hình ảnh" => "📷",
                _ => "🏥"
            };
        }

        private void UpdateAppointmentInfo()
        {
            if (selectedDoctor == null)
            {
                panelInf.Visible = false;
                return;
            }

            if (!selectedTime.HasValue)
            {
                panelInf.Visible = false;
                return;
            }

            panelInf.Visible = true;

            lbInf.Text =
                $"📅 Lịch khám: " +
                $"{selectedDate:dd/MM/yyyy} " +
                $"lúc {selectedTime:hh\\:mm} " +
                $"- Phòng {selectedDoctor.RoomCode}";
        }

        private Control CreateDepartmentCard(
    DepartmentDTO department)
        {
            RoundedPanel card = new RoundedPanel();

            card.Width = 170;
            card.Height = 100;

            card.FillColor = Color.FromArgb(248, 250, 252);

            card.BorderColor = Color.FromArgb(226, 232, 240);

            card.CornerRadius = 12;

            card.Margin = new Padding(8);

            card.Tag = department;

            Label lblIcon = new Label();

            lblIcon.Text = GetDepartmentIcon(department.DepartmentName);

            lblIcon.Font =
                new Font("Segoe UI Emoji", 20);

            lblIcon.AutoSize = false;

            lblIcon.Size =
                new Size(50, 40);

            lblIcon.Location =
                new Point(60, 10);

            lblIcon.TextAlign =
                ContentAlignment.MiddleCenter;

            Label lblName = new Label();

            lblName.Text =
                department.DepartmentName;

            lblName.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lblName.ForeColor =
                Color.FromArgb(31, 41, 55);

            lblName.Dock = DockStyle.Bottom;

            lblName.Height = 35;

            lblName.TextAlign =
                ContentAlignment.MiddleCenter;

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblName);

            card.Click += Department_Click;
            lblIcon.Click += Department_Click;
            lblName.Click += Department_Click;

            return card;
        }

        private void Department_Click(
    object sender,
    EventArgs e)
        {
            Control control =
                sender as Control;

            RoundedPanel card =
                control.Parent as RoundedPanel
                ?? control as RoundedPanel;

            if (card == null)
                return;

            foreach (RoundedPanel p
                in flpDepartments.Controls)
            {
                p.FillColor = Color.White;

                p.BorderColor =
                    Color.FromArgb(
                        229, 231, 235);

                p.Invalidate();
            }

            card.FillColor =
                Color.FromArgb(
                    239, 246, 255);

            card.BorderColor =
                Color.FromArgb(
                    59, 130, 246);

            card.Invalidate();

            DepartmentDTO department =
                (DepartmentDTO)card.Tag;

            selectedDepartmentId =
                department.DepartmentID;

            selectedDoctorId = -1;
            selectedDoctor = null;
            LoadDoctors(
                selectedDepartmentId,
                selectedDate,
                selectedTime.Value);
        }

        private void LoadDoctors(
    int departmentId,
    DateTime selectedDate,
    TimeSpan selectedTime)
        {
            flpDoctors.Controls.Clear();

            var doctors =
                controller.GetDoctorCards(
                    departmentId,
                    selectedDate,
                    selectedTime);

            if (doctors.Count == 0)
            {
                flpDoctors.Controls.Add(CreateEmptyDoctorPanel());
                return;
            }

            foreach (var doctor in doctors)
            {
                flpDoctors.Controls.Add(
                    CreateDoctorCard(
                        doctor));
            }
        }


        private Control CreateDoctorCard(DoctorCardDTO doctor)
        {
            RoundedPanel card = new RoundedPanel();

            card.Width = 500;
            card.Height = 220;

            card.FillColor = Color.White;

            card.BorderColor =
                Color.FromArgb(229, 231, 235);

            card.CornerRadius = 12;

            card.Margin = new Padding(10);

            card.Tag = doctor;

            // Avatar
            Label lblAvatar = new Label();

            lblAvatar.Text = "👨";

            lblAvatar.Font =
                new Font("Segoe UI Emoji", 28);

            lblAvatar.Size =
                new Size(60, 60);

            lblAvatar.Location =
                new Point(20, 25);

            // Tên bác sĩ
            Label lblName = new Label();

            lblName.Text =
                $"BS. {doctor.DoctorName}";

            lblName.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            lblName.Location =
                new Point(90, 20);

            lblName.AutoSize = true;

            // Phòng
            Label lblRoom = new Label();

            lblRoom.Text =
                $"📍 Phòng {doctor.RoomCode}";

            lblRoom.Font =
                new Font("Segoe UI", 9);

            lblRoom.ForeColor =
                Color.FromArgb(75, 85, 99);

            lblRoom.Location =
                new Point(90, 50);

            lblRoom.AutoSize = true;

            // Ca khám
            Label lblShift = new Label();

            lblShift.Text =
                $"🕒 {doctor.ShiftName}";

            lblShift.Font =
                new Font("Segoe UI", 9);

            lblShift.ForeColor =
                Color.FromArgb(75, 85, 99);

            lblShift.Location =
                new Point(90, 75);

            lblShift.AutoSize = true;

            // Bệnh nhân
            Label lblPatients = new Label();

            lblPatients.Text =
                $"👥 {doctor.CurrentPatients}/{doctor.MaxPatients} bệnh nhân";

            lblPatients.Font =
                new Font("Segoe UI", 9);

            lblPatients.ForeColor =
                Color.FromArgb(75, 85, 99);

            lblPatients.Location =
                new Point(90, 100);

            lblPatients.AutoSize = true;

            // Chỗ trống
            int available =
                doctor.MaxPatients -
                doctor.CurrentPatients;

            Label lblAvailable = new Label();

            lblAvailable.Text =
                $"Chỗ trống";

            lblAvailable.Font =
                new Font("Segoe UI", 9);

            lblAvailable.Location =
                new Point(90, 125);

            lblAvailable.AutoSize = true;

            Label lblAvailableCount = new Label();

            lblAvailableCount.Text =
                $"{available} chỗ";

            lblAvailableCount.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            lblAvailableCount.ForeColor =
                Color.OrangeRed;

            lblAvailableCount.Location =
                new Point(380, 125);

            lblAvailableCount.AutoSize = true;

            // ProgressBar
            ProgressBar progress =
                new ProgressBar();

            progress.Location =
                new Point(90, 145);

            progress.Size =
                new Size(300, 12);

            progress.Maximum =
                doctor.MaxPatients;

            progress.Value =
                Math.Min(
                    doctor.CurrentPatients,
                    doctor.MaxPatients);

            // Badge trạng thái
            Label lblStatus = new Label();

            lblStatus.Text =
                doctor.Status;

            lblStatus.BackColor =
                Color.FromArgb(
                    220, 252, 231);

            lblStatus.ForeColor =
                Color.FromArgb(
                    22, 163, 74);

            lblStatus.Location =
                new Point(90, 165);

            lblStatus.Padding =
                new Padding(10, 4, 10, 4);

            switch (doctor.Status)
            {
                case "Đang trực":
                    lblStatus.BackColor =
                        Color.FromArgb(220, 252, 231);

                    lblStatus.ForeColor =
                        Color.FromArgb(22, 163, 74);
                    break;

                case "Không trực":
                case "Ngoài ca":
                    lblStatus.BackColor =
                        Color.FromArgb(243, 244, 246);

                    lblStatus.ForeColor =
                        Color.FromArgb(107, 114, 128);
                    break;

                case "Đã đầy":
                    lblStatus.BackColor =
                        Color.FromArgb(254, 226, 226);

                    lblStatus.ForeColor =
                        Color.FromArgb(220, 38, 38);
                    break;
            }

            lblStatus.AutoSize = true;

            card.Controls.Add(lblAvatar);
            card.Controls.Add(lblName);
            card.Controls.Add(lblRoom);
            card.Controls.Add(lblShift);
            card.Controls.Add(lblPatients);
            card.Controls.Add(lblAvailable);
            card.Controls.Add(lblAvailableCount);
            card.Controls.Add(progress);
            card.Controls.Add(lblStatus);

            card.Click += Doctor_Click;
            lblAvatar.Click += Doctor_Click;
            lblName.Click += Doctor_Click;
            lblRoom.Click += Doctor_Click;
            lblShift.Click += Doctor_Click;
            lblPatients.Click += Doctor_Click;
            lblStatus.Click += Doctor_Click;

            return card;
        }

        private Control CreateEmptyDoctorPanel()
        {
            Panel panel = new Panel
            {
                Width = Math.Max(420, flpDoctors.ClientSize.Width - 30),
                Height = 90,
                BackColor = Color.White,
                Margin = new Padding(10)
            };

            Label label = new Label
            {
                Text = "Không có bác sĩ phù hợp với khoa và khung giờ đã chọn.",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(107, 114, 128)
            };
            panel.Controls.Add(label);
            return panel;
        }

        private void Doctor_Click(
    object sender,
    EventArgs e)
        {
            Control control =
                sender as Control;

            RoundedPanel card =
                control.Parent as RoundedPanel
                ?? control as RoundedPanel;

            if (card == null)
                return;

            foreach (RoundedPanel p
                in flpDoctors.Controls)
            {
                p.FillColor = Color.White;

                p.BorderColor =
                    Color.FromArgb(
                        229, 231, 235);

                p.Invalidate();
            }

            card.FillColor =
                Color.FromArgb(
                    239, 246, 255);

            card.BorderColor =
                Color.FromArgb(
                    59, 130, 246);

            card.Invalidate();

            DoctorCardDTO doctor =
    (DoctorCardDTO)card.Tag;

            selectedDoctorId =
                doctor.DoctorID;
            selectedDoctor = doctor;
            UpdateAppointmentInfo();
        }

        private void ClearForm()
        {
            cbPatient.SelectedIndex = -1;

            txtReason.Clear();

            selectedDepartmentId = -1;

            selectedDoctorId = -1;
            selectedDoctor = null;

            selectedTime = null;

            flpDoctors.Controls.Clear();
            panelInf.Visible = false;
            InitializeTimeSlots();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbPatient.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn bệnh nhân");
                return;
            }

            if (selectedDepartmentId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa");
                return;
            }

            if (!selectedTime.HasValue)
            {
                MessageBox.Show(
                    "Vui lòng chọn giờ khám");
                return;
            }

            if (selectedDoctorId <= 0)
            {
                MessageBox.Show(
                    "Vui lòng chọn bác sĩ");
                return;
            }

            int patientId =
                (int)cbPatient.SelectedValue;

            DateTime appointmentDate =
                dtpDate.Value.Date
                + selectedTime.Value;

            bool success =
                controller.CreateAppointment(
                    patientId,
                    selectedDepartmentId,
                    selectedDoctorId,
                    appointmentDate);

            if (success)
            {
                PatientDTO patient =
                    (PatientDTO)cbPatient.SelectedItem;

                DepartmentDTO department =
                    controller.GetDepartments()
                        .First(x =>
                            x.DepartmentID
                            == selectedDepartmentId);

                DoctorCardDTO doctor =
                    controller.GetDoctorCards(
                        selectedDepartmentId,
                        dtpDate.Value.Date,
                        selectedTime.Value)
                    .First(x =>
                        x.DoctorID
                        == selectedDoctorId);

                ConfirmAppointment frm =
                    new ConfirmAppointment(
                        patient.Name,
                        department.DepartmentName,
                        doctor.DoctorName,
                        doctor.RoomCode,
                        $"{dtpDate.Value:dd/MM/yyyy} - {selectedTime.Value:hh\\:mm}");

                frm.ShowDialog();

                ClearForm();
            }
            else
            {
                MessageBox.Show(
                    "Đặt lịch thất bại");
            }

        }

    }
}
