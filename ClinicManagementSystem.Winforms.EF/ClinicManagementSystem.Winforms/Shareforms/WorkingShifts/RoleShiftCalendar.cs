using BUS.Services;
using ClinicManagementSystem.Winforms.UserControls.Admin;
using DAL.Models;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public class RoleShiftCalendar : UserControl
    {
        private CMSDbContext _context;
        private UserDTO _currentUser;
        private string _role;

        private enum CalendarView
        {
            Day,
            Week,
            Month
        }

        private readonly EmployeeShiftBUS shiftBUS = new EmployeeShiftBUS();
        private EmployeeBUS employeeBUS;
        private readonly WorkShiftBUS workShiftBUS = new WorkShiftBUS();
        private readonly DepartmentBUS departmentBUS = new DepartmentBUS();
        private readonly RoomBUS roomBUS = new RoomBUS();

        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);
        private readonly Color border = Color.FromArgb(229, 231, 235);

        private DateTime currentDate = DateTime.Today;
        private CalendarView view = CalendarView.Week;
        private List<EmployeeShiftDTO> shifts = new List<EmployeeShiftDTO>();
        private List<EmployeeDTO> employees = new List<EmployeeDTO>();
        private List<WorkShiftDTO> workShifts = new List<WorkShiftDTO>();
        private List<DepartmentDTO> departments = new List<DepartmentDTO>();
        private List<RoomDTO> rooms = new List<RoomDTO>();

        private Label lblPeriod;
        private Label lblTotalValue;
        private Label lblTodayValue;
        private Label lblApprovedValue;
        private FlowLayoutPanel body;
        private Button btnDay;
        private Button btnWeek;
        private Button btnMonth;

        // Constructor mặc định (dùng cho designer)
        public RoleShiftCalendar()
        {
            BuildUi();
        }

        // Constructor 2 tham số (không context)
        public RoleShiftCalendar(UserDTO currentUser, string roleName) : this()
        {
            _currentUser = currentUser;
            _role = roleName;
            employeeBUS = new EmployeeBUS(new EmployeeDAL(_context));// Có thể dùng context nếu có
            LoadData();
        }

        // Constructor 3 tham số (có context) - dùng trong DoctorMainform
        public RoleShiftCalendar(CMSDbContext context, UserDTO currentUser, string role) : this(currentUser, role)
        {
            _context = context;
            // Tạo lại employeeBUS với context nếu có
            if (context != null)
                employeeBUS = new EmployeeBUS(new EmployeeDAL(context));
        }

        private void BuildUi()
        {
            BackColor = pageBack;
            Padding = new Padding(22);

            TableLayoutPanel root = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 4
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 64));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 96));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 54));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Controls.Add(root);

            Panel header = new Panel { Dock = DockStyle.Fill };
            Label title = new Label
            {
                Text = "Ca làm việc",
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = textMain,
                Location = new Point(0, 0),
                Size = new Size(280, 34)
            };
            lblPeriod = new Label
            {
                Font = new Font("Segoe UI", 10F),
                ForeColor = textMuted,
                Location = new Point(2, 36),
                Size = new Size(420, 24)
            };
            Button btnAdd = CreateButton("+ Thêm ca", primary, Color.White);
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(Width - 152, 9);
            btnAdd.Click += (s, e) => AddShift();
            header.Resize += (s, e) => btnAdd.Location = new Point(Math.Max(0, header.ClientSize.Width - 132), 9);
            header.Controls.Add(title);
            header.Controls.Add(lblPeriod);
            header.Controls.Add(btnAdd);
            root.Controls.Add(header, 0, 0);

            TableLayoutPanel stats = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 3, Padding = new Padding(0, 8, 0, 8) };
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            lblTotalValue = CreateStat(stats, "Tổng ca tháng");
            lblTodayValue = CreateStat(stats, "Ca hôm nay");
            lblApprovedValue = CreateStat(stats, "Đã duyệt");
            root.Controls.Add(stats, 0, 1);

            Panel toolbar = new Panel { Dock = DockStyle.Fill };
            Button btnPrev = CreateButton("‹", Color.White, textMain);
            Button btnToday = CreateButton("Hôm nay", Color.White, textMain);
            Button btnNext = CreateButton("›", Color.White, textMain);
            btnDay = CreateButton("Ngày", Color.White, textMain);
            btnWeek = CreateButton("Tuần", Color.White, textMain);
            btnMonth = CreateButton("Tháng", Color.White, textMain);

            btnPrev.Location = new Point(0, 6);
            btnToday.Location = new Point(50, 6);
            btnToday.Width = 98;
            btnNext.Location = new Point(154, 6);
            btnDay.Location = new Point(270, 6);
            btnWeek.Location = new Point(354, 6);
            btnMonth.Location = new Point(438, 6);
            btnPrev.Click += (s, e) => MovePeriod(-1);
            btnNext.Click += (s, e) => MovePeriod(1);
            btnToday.Click += (s, e) => { currentDate = DateTime.Today; Render(); };
            btnDay.Click += (s, e) => { view = CalendarView.Day; Render(); };
            btnWeek.Click += (s, e) => { view = CalendarView.Week; Render(); };
            btnMonth.Click += (s, e) => { view = CalendarView.Month; Render(); };
            toolbar.Controls.AddRange(new Control[] { btnPrev, btnToday, btnNext, btnDay, btnWeek, btnMonth });
            root.Controls.Add(toolbar, 0, 2);

            body = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = pageBack
            };
            body.Resize += (s, e) => ResizeBodyChildren();
            root.Controls.Add(body, 0, 3);
        }

        private Label CreateStat(TableLayoutPanel stats, string title)
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 12, 0), Padding = new Padding(16) };
            panel.Paint += DrawBorder;
            Label lblTitle = new Label { Text = title, Dock = DockStyle.Top, Height = 26, ForeColor = textMuted, Font = new Font("Segoe UI", 9.5F) };
            Label lblValue = new Label { Text = "0", Dock = DockStyle.Fill, ForeColor = textMain, Font = new Font("Segoe UI", 20F, FontStyle.Bold) };
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblTitle);
            stats.Controls.Add(panel);
            return lblValue;
        }

        private Button CreateButton(string text, Color back, Color fore)
        {
            Button button = new Button
            {
                Text = text,
                BackColor = back,
                ForeColor = fore,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Size = new Size(78, 36),
                Cursor = Cursors.Hand,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderColor = border;
            return button;
        }

        private void LoadData()
        {
            if (employeeBUS == null)
            {
                // Nếu chưa có employeeBUS (do constructor không có context), dùng mặc định
                employeeBUS = new EmployeeBUS(new EmployeeDAL(_context));
            }

            try
            {
                int employeeId = _currentUser?.EmployeeID ?? 0;
                shiftBUS.EnsureMonthlySchedule(_role, employeeId, DateTime.Today, 30);
                employees = employeeId > 0
                    ? employeeBUS.GetAll().Where(e => e.EmployeeID == employeeId).ToList()
                    : employeeBUS.GetByRole(_role);
                workShifts = workShiftBUS.GetAll();
                departments = departmentBUS.GetAll();
                rooms = roomBUS.GetAll();
                shifts = employeeId > 0 ? shiftBUS.GetByEmployee(employeeId) : shiftBUS.GetByRole(_role);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Load role shifts failed: " + ex);
                shifts = new List<EmployeeShiftDTO>();
            }

            Render();
        }

        private void MovePeriod(int direction)
        {
            currentDate = view switch
            {
                CalendarView.Day => currentDate.AddDays(direction),
                CalendarView.Week => currentDate.AddDays(direction * 7),
                _ => currentDate.AddMonths(direction)
            };
            Render();
        }

        private void Render()
        {
            UpdateStats();
            UpdateViewButtons();
            body.SuspendLayout();
            body.Controls.Clear();

            if (view == CalendarView.Day)
            {
                RenderDay(currentDate.Date);
            }
            else if (view == CalendarView.Week)
            {
                RenderWeek(StartOfWeek(currentDate));
            }
            else
            {
                RenderMonth(new DateTime(currentDate.Year, currentDate.Month, 1));
            }

            body.ResumeLayout();
            ResizeBodyChildren();
        }

        private void UpdateStats()
        {
            DateTime monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime nextMonth = monthStart.AddMonths(1);
            List<EmployeeShiftDTO> thisMonth = shifts
                .Where(s => s.WorkDate >= monthStart && s.WorkDate < nextMonth && !IsCancelled(s))
                .ToList();
            lblTotalValue.Text = thisMonth.Count.ToString("N0");
            lblTodayValue.Text = thisMonth.Count(s => s.WorkDate.Date == DateTime.Today).ToString("N0");
            lblApprovedValue.Text = thisMonth.Count(s => string.IsNullOrWhiteSpace(s.Status) || s.Status == "Approved").ToString("N0");
        }

        private void UpdateViewButtons()
        {
            Button[] buttons = { btnDay, btnWeek, btnMonth };
            foreach (Button button in buttons)
            {
                button.BackColor = Color.White;
                button.ForeColor = textMain;
            }

            Button active = view == CalendarView.Day ? btnDay : view == CalendarView.Week ? btnWeek : btnMonth;
            active.BackColor = primary;
            active.ForeColor = Color.White;

            lblPeriod.Text = view switch
            {
                CalendarView.Day => $"{currentDate:dddd, dd/MM/yyyy}",
                CalendarView.Week => $"{StartOfWeek(currentDate):dd/MM} - {StartOfWeek(currentDate).AddDays(6):dd/MM/yyyy}",
                _ => $"Tháng {currentDate:MM/yyyy}"
            };
        }

        private void RenderDay(DateTime day)
        {
            List<EmployeeShiftDTO> dayShifts = shifts
                .Where(s => s.WorkDate.Date == day && !IsCancelled(s))
                .OrderBy(s => s.StartTime)
                .ThenBy(s => s.EmployeeName)
                .ToList();

            if (dayShifts.Count == 0)
            {
                body.Controls.Add(CreateEmptyPanel("Chưa có ca làm việc trong ngày này."));
                return;
            }

            foreach (EmployeeShiftDTO shift in dayShifts)
            {
                body.Controls.Add(CreateShiftCard(shift, true));
            }
        }

        private void RenderWeek(DateTime weekStart)
        {
            TableLayoutPanel week = new TableLayoutPanel
            {
                ColumnCount = 7,
                RowCount = 1,
                Height = Math.Max(360, body.ClientSize.Height - 12),
                Margin = new Padding(0, 0, 0, 12)
            };
            for (int i = 0; i < 7; i++)
            {
                week.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285F));
            }

            for (int i = 0; i < 7; i++)
            {
                DateTime day = weekStart.AddDays(i);
                Panel dayPanel = CreateDayPanel(day);
                List<EmployeeShiftDTO> dayShifts = shifts
                    .Where(s => s.WorkDate.Date == day && !IsCancelled(s))
                    .OrderBy(s => s.StartTime)
                    .ThenBy(s => s.EmployeeName)
                    .ToList();

                int top = 48;
                if (dayShifts.Count == 0)
                {
                    Label empty = new Label { Text = "Trống", ForeColor = textMuted, Location = new Point(12, top), AutoSize = true };
                    dayPanel.Controls.Add(empty);
                }
                else
                {
                    foreach (EmployeeShiftDTO shift in dayShifts)
                    {
                        Control card = CreateShiftCard(shift, false);
                        card.Location = new Point(8, top);
                        card.Width = Math.Max(120, dayPanel.Width - 16);
                        card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                        dayPanel.Controls.Add(card);
                        top += card.Height + 8;
                    }
                }

                week.Controls.Add(dayPanel, i, 0);
            }

            body.Controls.Add(week);
        }

        private void RenderMonth(DateTime monthStart)
        {
            TableLayoutPanel month = new TableLayoutPanel
            {
                ColumnCount = 7,
                RowCount = 7,
                Height = 720,
                Margin = new Padding(0, 0, 0, 12)
            };
            for (int c = 0; c < 7; c++)
            {
                month.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285F));
            }
            month.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            for (int r = 1; r < 7; r++)
            {
                month.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            }

            string[] headers = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            for (int i = 0; i < headers.Length; i++)
            {
                month.Controls.Add(new Label
                {
                    Text = headers[i],
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    ForeColor = textMuted
                }, i, 0);
            }

            int startColumn = ((int)monthStart.DayOfWeek + 6) % 7;
            int days = DateTime.DaysInMonth(monthStart.Year, monthStart.Month);
            int row = 1;
            int col = startColumn;
            for (int day = 1; day <= days; day++)
            {
                DateTime date = new DateTime(monthStart.Year, monthStart.Month, day);
                Panel cell = CreateDayPanel(date);
                cell.AutoScroll = true;
                int top = 36;
                foreach (EmployeeShiftDTO shift in shifts.Where(s => s.WorkDate.Date == date && !IsCancelled(s)).OrderBy(s => s.StartTime).Take(3))
                {
                    Label item = new Label
                    {
                        Text = $"{shift.ShiftName} {shift.StartTime:hh\\:mm}",
                        BackColor = Color.FromArgb(239, 246, 255),
                        ForeColor = primary,
                        Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                        Location = new Point(8, top),
                        Size = new Size(120, 26),
                        AutoEllipsis = true,
                        Cursor = Cursors.Hand,
                        Tag = shift
                    };
                    item.Click += (s, e) => AdminRecordDialogs.ShowShift((EmployeeShiftDTO)((Control)s).Tag);
                    cell.Controls.Add(item);
                    top += 30;
                }
                month.Controls.Add(cell, col, row);
                col++;
                if (col > 6)
                {
                    col = 0;
                    row++;
                }
            }

            body.Controls.Add(month);
        }

        private Panel CreateDayPanel(DateTime day)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = day.Date == DateTime.Today ? Color.FromArgb(239, 246, 255) : Color.White,
                Margin = new Padding(4),
                Padding = new Padding(8)
            };
            panel.Paint += DrawBorder;
            Label label = new Label
            {
                Text = $"{day:dd/MM}",
                ForeColor = textMain,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(90, 26)
            };
            panel.Controls.Add(label);
            return panel;
        }

        private Control CreateShiftCard(EmployeeShiftDTO shift, bool wide)
        {
            Panel card = new Panel
            {
                Height = wide ? 92 : 86,
                Width = wide ? Math.Max(540, body.ClientSize.Width - 24) : 140,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 10),
                Cursor = Cursors.Hand,
                Tag = shift
            };
            card.Paint += DrawBorder;
            card.Click += (s, e) => AdminRecordDialogs.ShowShift((EmployeeShiftDTO)((Control)s).Tag);

            Label title = new Label
            {
                Text = $"{shift.ShiftName}  {shift.StartTime:hh\\:mm}-{shift.EndTime:hh\\:mm}",
                ForeColor = primary,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(12, 10),
                Size = new Size(Math.Max(120, card.Width - 24), 24),
                AutoEllipsis = true
            };
            Label meta = new Label
            {
                Text = wide
                    ? $"{shift.WorkDate:dd/MM/yyyy} | {shift.EmployeeName} | {Empty(shift.DepartmentName)} | Phòng {Empty(shift.RoomCode)}"
                    : $"{Empty(shift.RoomCode)}\n{Empty(shift.EmployeeName)}",
                ForeColor = textMain,
                Font = new Font("Segoe UI", 9F),
                Location = new Point(12, 38),
                Size = new Size(Math.Max(120, card.Width - 24), wide ? 24 : 42),
                AutoEllipsis = true
            };
            Label status = new Label
            {
                Text = Empty(shift.Status),
                ForeColor = textMuted,
                Font = new Font("Segoe UI", 8.5F),
                Location = new Point(12, wide ? 64 : 66),
                Size = new Size(Math.Max(120, card.Width - 24), 20)
            };

            card.Controls.Add(title);
            card.Controls.Add(meta);
            card.Controls.Add(status);
            return card;
        }

        private Panel CreateEmptyPanel(string text)
        {
            Panel panel = new Panel { Height = 120, BackColor = Color.White, Margin = new Padding(0, 0, 0, 12) };
            panel.Paint += DrawBorder;
            panel.Controls.Add(new Label
            {
                Text = text,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = textMuted,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold)
            });
            return panel;
        }

        private void AddShift()
        {
            if (employees.Count == 0 || workShifts.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu nhân viên hoặc ca làm việc để thêm ca.", "Ca làm việc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EmployeeDTO employee = employees.First();
            WorkShiftDTO workShift = workShifts.First();
            EmployeeShiftDTO draft = new EmployeeShiftDTO
            {
                EmployeeID = employee.EmployeeID,
                ShiftID = workShift.ShiftID,
                WorkDate = currentDate.Date < DateTime.Today ? DateTime.Today : currentDate.Date,
                DepartmentID = employee.DepartmentID,
                Status = "Approved"
            };

            if (AdminRecordDialogs.EditShift(draft, employees, workShifts, departments, rooms, true, out EmployeeShiftDTO created))
            {
                try
                {
                    if (shiftBUS.RegisterShift(created))
                    {
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thêm ca làm việc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ResizeBodyChildren()
        {
            int width = Math.Max(300, body.ClientSize.Width - 24);
            foreach (Control child in body.Controls)
            {
                child.Width = width;
            }
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            if (sender is not Control control) return;
            using Pen pen = new Pen(border);
            e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
        }

        private static DateTime StartOfWeek(DateTime date)
        {
            int diff = ((int)date.DayOfWeek + 6) % 7;
            return date.Date.AddDays(-diff);
        }

        private static bool IsCancelled(EmployeeShiftDTO shift)
        {
            return string.Equals(shift.Status, "Cancelled", StringComparison.OrdinalIgnoreCase);
        }

        private static string Empty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }
    }
}