using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using ClinicManagementSystem.Controllers;
using ClinicManagementSystem.Winforms.Controllers;
using CMS.Core.Identity;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public class ReceptionOverview : UserControl
    {
        private readonly PatientManaController patientController = new PatientManaController();
        private readonly ScheduleTodayController scheduleController = new ScheduleTodayController();
        private readonly PaymentController paymentController = new PaymentController();
        private readonly FollowUpController followUpController = new FollowUpController();
        private readonly EmployeeShiftBUS shiftBUS = new EmployeeShiftBUS();

        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);
        private readonly Color border = Color.FromArgb(229, 231, 235);

        private TableLayoutPanel stats;
        private DataGridView dgvToday;
        private Label lblShift;
        private Label lblReminder;

        public ReceptionOverview()
        {
            ReceptionDemoDataSeeder.EnsureSeeded();
            BuildUi();
            Load += (s, e) => LoadData();
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
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 58));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 126));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 118));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            Controls.Add(root);

            Label title = new Label
            {
                Text = "Tổng quan lễ tân",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = textMain,
                TextAlign = ContentAlignment.MiddleLeft
            };
            root.Controls.Add(title, 0, 0);

            stats = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 4 };
            for (int i = 0; i < 4; i++)
            {
                stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }
            root.Controls.Add(stats, 0, 1);

            TableLayoutPanel quick = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            quick.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            quick.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            lblShift = CreateInfoPanel(quick, "Ca làm việc hôm nay");
            lblReminder = CreateInfoPanel(quick, "Tái khám cần nhắc");
            root.Controls.Add(quick, 0, 2);

            Panel gridPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(16) };
            gridPanel.Paint += DrawBorder;
            Label gridTitle = new Label
            {
                Text = "Lịch khám hôm nay",
                Dock = DockStyle.Top,
                Height = 36,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = textMain
            };
            dgvToday = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            StyleGrid(dgvToday);
            gridPanel.Controls.Add(dgvToday);
            gridPanel.Controls.Add(gridTitle);
            root.Controls.Add(gridPanel, 0, 3);
        }

        private void LoadData()
        {
            stats.Controls.Clear();
            AddStat("Bệnh nhân", Safe(() => patientController.CountPatients()).ToString("N0"), Color.FromArgb(37, 99, 235));
            AddStat("Lịch hôm nay", Safe(() => scheduleController.GetTotalToday()).ToString("N0"), Color.FromArgb(22, 163, 74));
            AddStat("Chờ tiếp nhận", Safe(() => scheduleController.GetWaitingToday()).ToString("N0"), Color.FromArgb(217, 119, 6));
            AddStat("Chờ thanh toán", Safe(() => paymentController.GetWaitingPayments().Count).ToString("N0"), Color.FromArgb(147, 51, 234));

            lblShift.Text = BuildShiftText();
            List<FollowUpCardDTO> reminders = SafeList(() => followUpController.GetProcessingFollowUps());
            lblReminder.Text = reminders.Count == 0
                ? "Không có lịch tái khám cần xử lý"
                : $"{reminders.Count:N0} lịch đang xử lý";

            dgvToday.DataSource = scheduleController.GetAppointmentsToday();
            if (dgvToday.Columns.Contains("AppointmentID"))
            {
                dgvToday.Columns["AppointmentID"].Visible = false;
            }
            dgvToday.ClearSelection();
        }

        private string BuildShiftText()
        {
            List<EmployeeShiftDTO> today = SafeList(() => shiftBUS.GetByRole(Role.Receptionist))
                .Where(s => s.WorkDate.Date == DateTime.Today && !string.Equals(s.Status, "Cancelled", StringComparison.OrdinalIgnoreCase))
                .OrderBy(s => s.StartTime)
                .ToList();

            if (today.Count == 0)
            {
                return "Chưa có ca lễ tân hôm nay";
            }

            return string.Join(Environment.NewLine, today.Take(3).Select(s =>
                $"{Empty(s.EmployeeName)} - {Empty(s.ShiftName)} ({s.StartTime:hh\\:mm}-{s.EndTime:hh\\:mm})"));
        }

        private void AddStat(string title, string value, Color accent)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 12, 10), Padding = new Padding(16) };
            card.Paint += DrawBorder;
            Label lblTitle = new Label { Text = title, Dock = DockStyle.Top, Height = 28, Font = new Font("Segoe UI", 9.5F), ForeColor = textMuted };
            Label lblValue = new Label { Text = value, Dock = DockStyle.Fill, Font = new Font("Segoe UI", 22F, FontStyle.Bold), ForeColor = accent };
            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);
            stats.Controls.Add(card);
        }

        private Label CreateInfoPanel(TableLayoutPanel parent, string title)
        {
            Panel panel = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(0, 0, 12, 12), Padding = new Padding(16) };
            panel.Paint += DrawBorder;
            Label lblTitle = new Label { Text = title, Dock = DockStyle.Top, Height = 28, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = textMain };
            Label lblValue = new Label { Text = "-", Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F), ForeColor = textMuted };
            panel.Controls.Add(lblValue);
            panel.Controls.Add(lblTitle);
            parent.Controls.Add(panel);
            return lblValue;
        }

        private void DrawBorder(object sender, PaintEventArgs e)
        {
            using Pen pen = new Pen(border);
            e.Graphics.DrawRectangle(pen, 0, 0, ((Control)sender).Width - 1, ((Control)sender).Height - 1);
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 42;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81);
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.GridColor = Color.FromArgb(241, 245, 249);
        }

        private static int Safe(Func<int> action)
        {
            try { return action(); }
            catch { return 0; }
        }

        private static List<T> SafeList<T>(Func<List<T>> action)
        {
            try { return action(); }
            catch { return new List<T>(); }
        }

        private static string Empty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? "-" : value;
        }
    }
}
