using DTO;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public partial class ucMonthView : UserControl
    {
        private DateTime currentMonth;

        private List<EmployeeShiftDTO> mockData =
            new List<EmployeeShiftDTO>();

        public ucMonthView()
        {
            InitializeComponent();

            currentMonth = DateTime.Today;
            this.AutoScroll = true;

            mockData.Add(new EmployeeShiftDTO
            {
                EmployeeShiftID = 1,
                EmployeeName = "Nguyễn Văn A",
                ShiftName = "CA SÁNG",
                WorkDate = DateTime.Today,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                DepartmentName = "Khoa Nội",
                Status = "Scheduled"
            });

            mockData.Add(new EmployeeShiftDTO
            {
                EmployeeShiftID = 2,
                EmployeeName = "Nguyễn Văn A",
                ShiftName = "CA CHIỀU",
                WorkDate = DateTime.Today.AddDays(2),
                StartTime = new TimeSpan(13, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                DepartmentName = "Khoa Ngoại",
                Status = "Scheduled"
            });

            BuildMonthView(currentMonth);

        }

        private void BuildMonthView(DateTime month)
        {
            tblMonth.Controls.Clear();

            tblMonth.ColumnCount = 7;
            tblMonth.RowCount = 7;
            tblMonth.RowStyles.Clear();

            tblMonth.RowStyles.Add(
                new RowStyle(SizeType.Absolute, 30)); // Header

            for (int i = 1; i < 7; i++)
            {
                tblMonth.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, 70));
            }
            tblMonth.ColumnStyles.Clear();

            for (int i = 0; i < 7; i++)
            {
                tblMonth.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 14.285f));
            }


            string[] headers =
            {
        "T2","T3","T4",
        "T5","T6","T7","CN"
    };

            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label();

                lbl.Text = headers[i];

                lbl.Dock = DockStyle.Fill;

                lbl.TextAlign =
                    ContentAlignment.MiddleCenter;

                lbl.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                lbl.BackColor =
                    Color.LightGray;

                tblMonth.Controls.Add(lbl, i, 0);
            }

            DateTime firstDay =
                new DateTime(
                    month.Year,
                    month.Month,
                    1);

            int daysInMonth =
                DateTime.DaysInMonth(
                    month.Year,
                    month.Month);

            int startColumn =
                ((int)firstDay.DayOfWeek + 6) % 7;

            int row = 1;
            int col = startColumn;

            for (int day = 1; day <= daysInMonth; day++)
            {
                Panel cell = CreateDayCell(
                    new DateTime(
                        month.Year,
                        month.Month,
                        day));

                tblMonth.Controls.Add(
                    cell,
                    col,
                    row);

                col++;

                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }
        }
        private Panel CreateDayCell(DateTime date)
        {
            Panel cell = new Panel();

            cell.Dock = DockStyle.Fill;

            cell.BorderStyle =
                BorderStyle.FixedSingle;
            cell.Margin = new Padding(2);
            cell.BackColor = Color.White;
            cell.AutoScroll = true;

            Label lblDay = new Label();

            lblDay.Text = date.Day.ToString();

            lblDay.Location =
                new Point(5, 5);

            lblDay.AutoSize = true;

            cell.Controls.Add(lblDay);

            var shifts =
                mockData.Where(
                    x => x.WorkDate.Date ==
                         date.Date);

            int top = 25;

            foreach (var shift in shifts)
            {
                ShiftCardControl card =
                    new ShiftCardControl();

                card.Width = cell.Width - 10;
                card.Height = 70;

                card.Location =
                    new Point(
                        5,
                        top);

                card.SetData(
    shift.ShiftName,
    $"{shift.StartTime:hh\\:mm} - {shift.EndTime:hh\\:mm}",
    shift.DepartmentName
);

                card.ShiftClicked +=
                    (s, e) =>
                    {
                        ShiftDetailForm frm =
        new ShiftDetailForm(shift);

                        frm.ShowDialog();
                    };

                cell.Controls.Add(card);

                top += 80;
            }

            return cell;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            BuildMonthView(currentMonth);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            BuildMonthView(currentMonth);
        }

    }
}