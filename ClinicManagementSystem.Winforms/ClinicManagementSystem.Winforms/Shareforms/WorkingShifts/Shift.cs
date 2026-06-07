using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms
{
    public partial class Shift : UserControl
    {
        private DateTime currentDate;

        public Shift()
        {
            InitializeComponent();

            currentDate = DateTime.Today;

            InitializeCards();
            InitializeEvents();

            ShowDayView();
            UpdateHeader();
        }

        private void InitializeEvents()
        {
            btnPrev.Click += btnPrev_Click;
            btnNext.Click += btnNext_Click;
            btnToday.Click += btnToday_Click;

            btnDay.Click += btnDay_Click;
            btnWeek.Click += btnWeek_Click;
            btnMonth.Click += btnMonth_Click;

            btnSchedule.Click += btnSchedule_Click;
            btnHistory.Click += btnHistory_Click;
        }

        private void InitializeCards()
        {
            lblTitle1.Text = "Tổng số ca";
            lblCount1.Text = "120";
            lblDescription1.Text = "Tháng này";

            lblTitle2.Text = "Yêu cầu đổi ca";
            lblCount2.Text = "15";
            lblDescription2.Text = "Đang chờ duyệt";

            lblTitle3.Text = "Đã được duyệt";
            lblCount3.Text = "10";
            lblDescription3.Text = "Tháng này";
        }

        private void UpdateHeader()
        {
            lblCurrentPeriod.Text =
                $"Tháng {currentDate.Month:00} năm {currentDate.Year}";
        }
        private void btnPrev_Click(object? sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(-1);

            UpdateHeader();

            // Sau này gọi LoadMonthView()
        }
        private void btnNext_Click(object? sender, EventArgs e)
        {
            currentDate = currentDate.AddMonths(1);

            UpdateHeader();

            // Sau này gọi LoadMonthView()
        }
        private void btnToday_Click(object? sender, EventArgs e)
        {
            currentDate = DateTime.Today;

            UpdateHeader();

            // Sau này gọi LoadMonthView()
        }
        private void ResetViewButtons()
        {
            btnDay.BackColor = Color.White;
            btnWeek.BackColor = Color.White;
            btnMonth.BackColor = Color.White;

            btnDay.ForeColor = Color.Black;
            btnWeek.ForeColor = Color.Black;
            btnMonth.ForeColor = Color.Black;
        }
        private void ShowDayView()
        {
            ResetViewButtons();

            btnDay.BackColor = Color.RoyalBlue;
            btnDay.ForeColor = Color.White;

            ucDayView1.BringToFront();
        }
        private void btnDay_Click(object? sender, EventArgs e)
        {
            ShowDayView();
        }
        private void ShowWeekView()
        {
            ResetViewButtons();

            btnWeek.BackColor = Color.RoyalBlue;
            btnWeek.ForeColor = Color.White;

            ucWeekView1.BringToFront();
        }
        private void ShowMonthView()
        {
            ResetViewButtons();

            btnMonth.BackColor = Color.RoyalBlue;
            btnMonth.ForeColor = Color.White;

            ucMonthView1.BringToFront();
        }
        private void btnWeek_Click(object? sender, EventArgs e)
        {
            ShowWeekView();
        }
        private void btnMonth_Click(object? sender, EventArgs e)
        {
            ShowMonthView();
        }
        private void btnSchedule_Click(object? sender, EventArgs e)
        {
            btnSchedule.BackColor = Color.RoyalBlue;
            btnSchedule.ForeColor = Color.White;

            btnHistory.BackColor = Color.White;
            btnHistory.ForeColor = Color.Black;

            pnlViewContainer.Visible = true;

            ShowDayView();
        }
        private void btnHistory_Click(object? sender, EventArgs e)
        {
            btnHistory.BackColor = Color.RoyalBlue;
            btnHistory.ForeColor = Color.White;

            btnSchedule.BackColor = Color.White;
            btnSchedule.ForeColor = Color.Black;

            ucShiftHistory1.BringToFront();
        }
    }
}