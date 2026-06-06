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

        public CreateAppointment()
        {
            InitializeComponent();
        }

        private void CreateAppointment_Load(
    object sender,
    EventArgs e)
        {
            LoadPatients();

            LoadDepartments();

            dtpDate.MinDate =
                DateTime.Today;

            btn0800.Tag = "08:00";
            btn0830.Tag = "08:30";
            btn0900.Tag = "09:00";
            btn0930.Tag = "09:30";
            btn1000.Tag = "10:00";
            btn1030.Tag = "10:30";
            btn1100.Tag = "11:00";
            btn1130.Tag = "11:30";

            btn0800.Click += TimeSlot_Click;
            btn0830.Click += TimeSlot_Click;
            btn0900.Click += TimeSlot_Click;
            btn0930.Click += TimeSlot_Click;
            btn1000.Click += TimeSlot_Click;
            btn1030.Click += TimeSlot_Click;
            btn1100.Click += TimeSlot_Click;
            btn1130.Click += TimeSlot_Click;
        }

        private void TimeSlot_Click(
    object sender,
    EventArgs e)
        {
            Button btn =
                sender as Button;

            if (btn == null)
                return;

            Button[] buttons =
            {
        btn0800,
        btn0830,
        btn0900,
        btn0930,
        btn1000,
        btn1030,
        btn1100,
        btn1130
    };

            foreach (Button b in buttons)
            {
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;
            }

            btn.BackColor =
                Color.FromArgb(59, 130, 246);

            btn.ForeColor =
                Color.White;

            selectedTime =
                TimeSpan.Parse(
                    btn.Tag.ToString());

            if (selectedDepartmentId > 0)
            {
                LoadDoctors(
                    selectedDepartmentId,
                    dtpDate.Value.Date,
                    selectedTime.Value);
            }
        }

        private void dtpDate_ValueChanged(
    object sender,
    EventArgs e)
        {
            if (selectedDepartmentId > 0
                && selectedTime.HasValue)
            {
                LoadDoctors(
                    selectedDepartmentId,
                    dtpDate.Value.Date,
                    selectedTime.Value);
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
                controller.GetDepartments();

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

            if (selectedTime.HasValue)
            {
                LoadDoctors(
                    selectedDepartmentId,
                    dtpDate.Value.Date,
                    selectedTime.Value);
            }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
