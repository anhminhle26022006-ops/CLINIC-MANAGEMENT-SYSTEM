using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public partial class ucDayView : UserControl
    {
        public ucDayView()
        {
            InitializeComponent();

            LoadDemoData();
        }

        private void LoadDemoData()
        {
            flpDayShifts.Controls.Clear();

            AddShiftCard(
                "CA001",
                "Ca sáng",
                "08:00 - 12:00",
                "Khoa Nội",
                "Phòng 101",
                "Đã lên lịch");

            AddShiftCard(
                "CA002",
                "Ca chiều",
                "13:00 - 17:00",
                "Khoa Ngoại",
                "Phòng 203",
                "Chờ đổi ca");
        }
        private void AddShiftCard(
    string shiftCode,
    string shiftName,
    string time,
    string department,
    string room,
    string status)
        {
            Panel card = new Panel();

            card.Width = flpDayShifts.ClientSize.Width - 35;
            card.Height = 160;

            card.BackColor = Color.White;
            card.BorderStyle = BorderStyle.FixedSingle;

            card.Margin = new Padding(10);
            Label lblTitle = new Label();

            lblTitle.Text = $"{shiftCode} - {shiftName}";

            lblTitle.Font =
                new Font("Segoe UI", 13, FontStyle.Bold);

            lblTitle.Location =
                new Point(20, 15);

            lblTitle.AutoSize = true;

            Label lblTime = new Label();

            lblTime.Text =
                $"Giờ làm: {time}";

            lblTime.Location =
                new Point(20, 55);

            lblTime.AutoSize = true;

            Label lblDepartment = new Label();

            lblDepartment.Text =
                $"Khoa: {department}";

            lblDepartment.Location =
                new Point(20, 85);

            lblDepartment.AutoSize = true;

            Label lblRoom = new Label();

            lblRoom.Text =
                $"Phòng: {room}";

            lblRoom.Location =
                new Point(20, 115);

            lblRoom.AutoSize = true;

            Label lblStatus = new Label();

            lblStatus.Text = status;

            lblStatus.Size =
                new Size(120, 35);

            lblStatus.TextAlign =
                ContentAlignment.MiddleCenter;

            lblStatus.Location =
                new Point(card.Width - 160, 15);

            switch (status)
            {
                case "Đã lên lịch":
                    lblStatus.BackColor = Color.LightBlue;
                    break;

                case "Chờ đổi ca":
                    lblStatus.BackColor = Color.Khaki;
                    break;

                case "Đã duyệt":
                    lblStatus.BackColor = Color.LightGreen;
                    break;

                default:
                    lblStatus.BackColor = Color.LightCoral;
                    break;
            }
            Button btnDetail = new Button();

            btnDetail.Text = "Chi tiết";

            btnDetail.Size =
                new Size(100, 35);

            btnDetail.Location =
                new Point(card.Width - 140, 80);
            Button btnChangeShift = new Button();

            btnChangeShift.Text = "Đổi ca";

            btnChangeShift.Size =
                new Size(100, 35);

            btnChangeShift.Location =
                new Point(card.Width - 260, 80);
            btnDetail.Click += (s, e) =>
            {
                MessageBox.Show(
                    $"Mã ca: {shiftCode}\n" +
                    $"Thời gian: {time}\n" +
                    $"Khoa: {department}\n" +
                    $"Phòng: {room}\n" +
                    $"Trạng thái: {status}",
                    "Chi tiết ca làm");
            };
            btnChangeShift.Click += (s, e) =>
            {
                MessageBox.Show(
                    $"Yêu cầu đổi ca {shiftCode}");
            };
            card.Controls.Add(lblTitle);
            card.Controls.Add(lblTime);
            card.Controls.Add(lblDepartment);
            card.Controls.Add(lblRoom);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnDetail);
            card.Controls.Add(btnChangeShift);

            flpDayShifts.Controls.Add(card);
        }
    }
}
        