using DTO;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public partial class ucWeekView : UserControl
    {
        private DateTime currentWeekStart;

        private List<EmployeeShiftDTO> mockData =
            new List<EmployeeShiftDTO>();

        public ucWeekView()
        {
            InitializeComponent();

            currentWeekStart =
                DateTime.Today.AddDays(
                    -((int)DateTime.Today.DayOfWeek + 6) % 7);

            LoadMockData();

            BuildWeekView();
        }

        private void LoadMockData()
        {
            mockData.Add(new EmployeeShiftDTO
            {
                EmployeeShiftID = 1,
                EmployeeName = "Nguyễn Văn A",
                ShiftName = "CA SÁNG",
                WorkDate = currentWeekStart,
                StartTime = new TimeSpan(8, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                DepartmentName = "Khoa Nội"
            });

            mockData.Add(new EmployeeShiftDTO
            {
                EmployeeShiftID = 2,
                EmployeeName = "Nguyễn Văn A",
                ShiftName = "CA CHIỀU",
                WorkDate = currentWeekStart.AddDays(2),
                StartTime = new TimeSpan(13, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                DepartmentName = "Khoa Ngoại"
            });

            mockData.Add(new EmployeeShiftDTO
            {
                EmployeeShiftID = 3,
                EmployeeName = "Nguyễn Văn A",
                ShiftName = "CA TỐI",
                WorkDate = currentWeekStart.AddDays(4),
                StartTime = new TimeSpan(18, 0, 0),
                EndTime = new TimeSpan(22, 0, 0),
                DepartmentName = "Khoa Cấp cứu"
            });
        }

        private void BuildWeekView()
        {
            FlowLayoutPanel[] panels =
            {
                flowLayoutPanel1,
                flowLayoutPanel2,
                flowLayoutPanel3,
                flowLayoutPanel4,
                flowLayoutPanel5,
                flowLayoutPanel6,
                flowLayoutPanel7
            };

            Label[] labels =
            {
                label1,
                label2,
                label3,
                label4,
                label5,
                label6,
                label7
            };

            for (int i = 0; i < 7; i++)
            {
                panels[i].Controls.Clear();

                DateTime day =
                    currentWeekStart.AddDays(i);

                labels[i].Text =
                    $"T{i + 2}\n{day:dd/MM}";

                var shifts =
                    mockData.Where(x =>
                        x.WorkDate.Date == day.Date);

                foreach (var shift in shifts)
                {
                    ShiftCardControl card =
                        new ShiftCardControl();

                    card.Width = 130;
                    card.Height = 100;

                    card.SetData(
                        shift.ShiftName,
                        $"{shift.StartTime:hh\\:mm}-{shift.EndTime:hh\\:mm}",
                        shift.DepartmentName);

                    card.ShiftClicked += (s, e) =>
                    {
                        ShiftDetailForm frm =
                            new ShiftDetailForm(shift);

                        frm.ShowDialog();
                    };

                    panels[i].Controls.Add(card);
                }
            }
        }
    }
}