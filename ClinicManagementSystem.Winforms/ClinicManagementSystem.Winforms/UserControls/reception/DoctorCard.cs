using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class DoctorCard : UserControl
    {
        
        public DoctorCard()
        {
            InitializeComponent();
            label8.Font = new Font(
        "Segoe UI Emoji",
        24,
        FontStyle.Regular);
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
                "Sản phụ khoa" => "🤰",
                "Chẩn đoán hình ảnh" => "📷",
                "Xét nghiệm" => "🧪",
                _ => "🏥"
            };
        }

        public void SetupDoctorCard(
    DoctorQueueDTO doctor)
        {
            int processed =
                doctor.CompletedCount
                + doctor.ExaminingCount;

            progressBar1.Maximum =
                Math.Max(
                    doctor.TotalAppointments,
                    1);

            progressBar1.Value =
                Math.Min(
                    processed,
                    progressBar1.Maximum);

            label5.Text =
                $"{processed}/{doctor.TotalAppointments} bệnh nhân";

            label8.Text =
                GetDepartmentIcon(
                    doctor.DepartmentName);

            label1.Text =
                doctor.DoctorName;

            label2.Text =
                doctor.DepartmentName;

            label3.Text =
                $"📍 {doctor.RoomCode}";

            label4.Text =
                $"🕒 {doctor.Shift}";

            label12.Text =
                doctor.CompletedCount.ToString();

            label13.Text =
                doctor.WaitingCount.ToString();

            int remaining =
                Math.Max(
                    0,
                    doctor.TotalAppointments
                    - doctor.CompletedCount
                    - doctor.ExaminingCount
                    - doctor.WaitingCount);

            label14.Text =
                remaining.ToString();

            LoadCurrentPatient(doctor);
            LoadWaitingPatients(
    doctor.WaitingPatients);
        }

        private void LoadCurrentPatient(
    DoctorQueueDTO doctor)
        {
            if (doctor.CurrentQueueNumber == 0)
            {
                label15.Text = "-";
                label16.Text = "Chưa có bệnh nhân";
                label17.Text = "";

                return;
            }

            label15.Text =
                doctor.CurrentQueueNumber
                    .ToString();

            label16.Text =
                doctor.CurrentPatient;

            label17.Text =
                doctor.CurrentPatientCode;
        }

        private void LoadWaitingPatients(
    List<WaitingPatientDTO> patients)
        {
            flpWaitingPatients.Controls.Clear();

            if (patients == null)
                return;

            int stt = 1;

            foreach (var p in patients)
            {
                flpWaitingPatients.Controls.Add(
                    CreateWaitingPatientCard(
                        stt++,
                        p.PatientName,
                        p.PatientCode,
                        p.AppointmentTime.ToString("HH:mm")
                    ));
            }
        }

        private Panel CreateWaitingPatientCard(
    int stt,
    string name,
    string code,
    string time)
        {
            Panel card = new Panel
            {
                Width = flpWaitingPatients.Width - 25,
                Height = 70,
                BackColor = Color.White,
                Margin = new Padding(5)
            };

            Label lblStt = new Label
            {
                Text = stt.ToString(),
                Width = 40,
                Height = 40,
                Location = new Point(10, 15),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Gainsboro,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblName = new Label
            {
                Text = name,
                AutoSize = true,
                Location = new Point(65, 10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Label lblCode = new Label
            {
                Text = code,
                AutoSize = true,
                Location = new Point(65, 35)
            };

            Label lblTime = new Label
            {
                Text = $"🕒 {time}",
                AutoSize = true,
                Location = new Point(140, 35)
            };

            card.Controls.Add(lblStt);
            card.Controls.Add(lblName);
            card.Controls.Add(lblCode);
            card.Controls.Add(lblTime);

            return card;
        }
    }
}
