using BUS.Services;
using DAL.Models;
using DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucAdminDashboard : UserControl
    {
        private readonly AdminStatisticsBUS statisticsBUS;
        private readonly CultureInfo viCulture = new CultureInfo("vi-VN");
        private AdminStatisticsDTO currentStatistics = new AdminStatisticsDTO();

        public ucAdminDashboard(CMSDbContext context)
        {
            InitializeComponent();
            statisticsBUS = new AdminStatisticsBUS(context);
            AdminUiStyle.ApplyGrid(dgvAppointments);
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                currentStatistics = statisticsBUS.GetStatistics(DateTime.Today);
            }
            catch
            {
                currentStatistics = new AdminStatisticsDTO();
            }

            BindDashboard();
        }

        private void BindDashboard()
        {
            BindKpiCards();
            BindAppointments();
            BindMedicines();
            BindDepartments();
            BindQueueCards();
            outerScroll_Resize(this, EventArgs.Empty);
        }

        private void BindKpiCards()
        {
            lblPatientsValue.Text = FormatNumber(currentStatistics.TotalPatients);
            lblAppointmentsValue.Text = FormatNumber(currentStatistics.MonthlyAppointmentCount);
            lblWaitingValue.Text = FormatNumber(currentStatistics.QueueSummary?.Waiting ?? 0);
            lblEmployeesValue.Text = FormatNumber(currentStatistics.ActiveEmployeeCount);
            lblMedicineValue.Text = FormatNumber(currentStatistics.LowStockMedicineCount);
        }

        private void BindAppointments()
        {
            dgvAppointments.Rows.Clear();
            if (!currentStatistics.TodayAppointments.Any())
            {
                dgvAppointments.Rows.Add("--", "Chưa có lịch khám", string.Empty, string.Empty, "Trống");
                dgvAppointments.ClearSelection();
                return;
            }

            foreach (AdminAppointmentSummaryDTO appointment in currentStatistics.TodayAppointments.Take(6))
            {
                dgvAppointments.Rows.Add(
                    appointment.TimeText,
                    appointment.PatientName,
                    appointment.DoctorName,
                    appointment.DepartmentName,
                    appointment.Status);
            }

            dgvAppointments.ClearSelection();
        }

        private void BindMedicines()
        {
            panelMedicineList.Controls.Clear();
            if (!currentStatistics.LowStockMedicines.Any())
            {
                panelMedicineList.Controls.Add(CreateLine("Không có thuốc sắp hết", "Kho ổn định"));
                return;
            }

            foreach (AdminLowStockMedicineDTO medicine in currentStatistics.LowStockMedicines.Take(5))
            {
                panelMedicineList.Controls.Add(CreateLine(
                    medicine.MedicineName,
                    medicine.Stock + " " + medicine.Unit));
            }
        }

        private void BindDepartments()
        {
            panelDeptCards.Controls.Clear();
            if (!currentStatistics.DepartmentStatistics.Any())
            {
                panelDeptCards.Controls.Add(CreateMiniCard("Chưa có dữ liệu", "0 lịch", Color.FromArgb(107, 114, 128)));
                return;
            }

            foreach (AdminDepartmentStatisticDTO department in currentStatistics.DepartmentStatistics.Take(4))
            {
                panelDeptCards.Controls.Add(CreateMiniCard(
                    department.DepartmentName,
                    department.MonthlyAppointmentCount + " lịch | " + department.EmployeeCount + " NV",
                    Color.FromArgb(37, 99, 235)));
            }
        }

        private void BindQueueCards()
        {
            AdminQueueSummaryDTO queue = currentStatistics.QueueSummary ?? new AdminQueueSummaryDTO();
            lblWaitingQValue.Text = FormatNumber(queue.Waiting);
            lblInProgressQValue.Text = FormatNumber(queue.InProgress);
            lblDoneQValue.Text = FormatNumber(queue.Completed);
            lblCancelledQValue.Text = FormatNumber(queue.Cancelled);
        }

        private string FormatNumber(int value)
        {
            return value.ToString("N0", viCulture);
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null) return;
            var text = e.Value.ToString();
            if (string.Equals(text, "Hoan thanh", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(22, 101, 52);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();

        private void outerScroll_Resize(object sender, EventArgs e)
        {
            int inner = outerScroll.ClientSize.Width - mainFlow.Padding.Left - mainFlow.Padding.Right - 20;

            foreach (Control control in mainFlow.Controls)
            {
                control.Width = inner;
            }

        }

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnRefresh != null)
            {
                btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width, 16);
            }
        }

        private void panelDeptCards_Resize(object sender, EventArgs e)
        {
            int availableWidth = panelDeptCards.ClientSize.Width - panelDeptCards.Padding.Horizontal;
            int cardWidth = (availableWidth - 36) / 4;

            foreach (Control control in panelDeptCards.Controls)
            {
                control.Width = cardWidth;
                control.Height = 105;
                control.Margin = new Padding(0, 0, 12, 0);
            }
        }

        private void panelQueueCards_Resize(object sender, EventArgs e)
        {
            // Cards are positioned in the Designer so they remain drag-editable.
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel panel) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
        }

        private void mainFlow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPatientsValue_Click(object sender, EventArgs e)
        {

        }
    }
}
