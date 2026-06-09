using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucAdminStatistics : UserControl
    {
        private readonly AdminStatisticsBUS statisticsBUS = new AdminStatisticsBUS();
        private readonly CultureInfo viCulture = new CultureInfo("vi-VN");
        private AdminStatisticsDTO currentStatistics = new AdminStatisticsDTO();
        private bool isBinding;

        public ucAdminStatistics()
        {
            InitializeComponent();
            dtpMonth.Value = DateTime.Today;
        }

        public void LoadStatistics()
        {
            if (isBinding)
            {
                return;
            }

            try
            {
                isBinding = true;
                currentStatistics = statisticsBUS.GetStatistics(GetReferenceDate());
                BindStatistics();
            }
            catch (Exception ex)
            {
                currentStatistics = new AdminStatisticsDTO();
                BindStatistics();
                MessageBox.Show(
                    "Không thể tải dữ liệu thống kê: " + ex.Message,
                    "Thống kê",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                isBinding = false;
            }
        }

        private DateTime GetReferenceDate()
        {
            DateTime selected = dtpMonth.Value.Date;
            DateTime today = DateTime.Today;
            if (selected.Year == today.Year && selected.Month == today.Month)
            {
                return today;
            }

            return new DateTime(selected.Year, selected.Month, 1);
        }

        private void BindStatistics()
        {
            lblTotalPatientsValue.Text = FormatNumber(currentStatistics.TotalPatients);
            lblPatientTrend.Text = FormatTrend(currentStatistics.PatientGrowthPercent);

            lblMonthlyAppointmentsValue.Text = FormatNumber(currentStatistics.MonthlyAppointmentCount);
            lblAppointmentTrend.Text = FormatTrend(currentStatistics.AppointmentGrowthPercent);

            lblMonthlyRevenueValue.Text = FormatMoneyShort(currentStatistics.MonthlyRevenue);
            lblRevenueTrend.Text = FormatTrend(currentStatistics.RevenueGrowthPercent);

            lblTodayAppointmentsValue.Text = FormatNumber(currentStatistics.TodayAppointmentCount);
            lblTodayStatus.Text = currentStatistics.TodayAppointmentCount > 0
                ? "Đang diễn ra trong ngày"
                : "Chưa có lịch trong ngày";

            lblActiveStaffValue.Text = FormatNumber(currentStatistics.ActiveEmployeeCount);
            lblMedicineStatus.Text = currentStatistics.LowStockMedicineCount > 0
                ? FormatNumber(currentStatistics.LowStockMedicineCount) + " thuốc sắp hết"
                : "Kho thuốc ổn định";

            BindAppointments();
            BindQueueSummary();
            BindDepartments();
            BindMedicines();
            pnlPatientChart.Invalidate();
            pnlRevenueChart.Invalidate();
        }

        private void BindAppointments()
        {
            dgvAppointments.Rows.Clear();
            if (currentStatistics.TodayAppointments.Count == 0)
            {
                dgvAppointments.Rows.Add("--", "Chưa có lịch khám", string.Empty, string.Empty, "Trống");
                return;
            }

            foreach (AdminAppointmentSummaryDTO appointment in currentStatistics.TodayAppointments)
            {
                dgvAppointments.Rows.Add(
                    appointment.TimeText,
                    appointment.PatientName,
                    appointment.DoctorName,
                    appointment.DepartmentName,
                    appointment.Status);
            }
        }

        private void BindQueueSummary()
        {
            queueFlow.Controls.Clear();
            AdminQueueSummaryDTO queue = currentStatistics.QueueSummary ?? new AdminQueueSummaryDTO();
            AddQueueChip("Chờ", queue.Waiting, Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            AddQueueChip("Khám", queue.InProgress, Color.FromArgb(217, 119, 6), Color.FromArgb(255, 251, 235));
            AddQueueChip("Xong", queue.Completed, Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            AddQueueChip("Hủy", queue.Cancelled, Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
        }

        private void BindDepartments()
        {
            departmentFlow.Controls.Clear();
            IEnumerable<AdminDepartmentStatisticDTO> departments = currentStatistics.DepartmentStatistics.Take(3);
            if (!departments.Any())
            {
                departmentFlow.Controls.Add(CreateInfoRow("Chưa có dữ liệu chuyên khoa", string.Empty));
                return;
            }

            foreach (AdminDepartmentStatisticDTO department in departments)
            {
                string detail = department.MonthlyAppointmentCount + " lịch | " + department.EmployeeCount + " nhân sự";
                departmentFlow.Controls.Add(CreateInfoRow(department.DepartmentName, detail));
            }
        }

        private void BindMedicines()
        {
            medicineFlow.Controls.Clear();
            IEnumerable<AdminLowStockMedicineDTO> medicines = currentStatistics.LowStockMedicines.Take(3);
            if (!medicines.Any())
            {
                medicineFlow.Controls.Add(CreateInfoRow("Không có thuốc sắp hết", string.Empty));
                return;
            }

            foreach (AdminLowStockMedicineDTO medicine in medicines)
            {
                string detail = medicine.Stock + " " + medicine.Unit;
                medicineFlow.Controls.Add(CreateInfoRow(medicine.MedicineName, detail));
            }
        }

        private void AddQueueChip(string title, int value, Color valueColor, Color backgroundColor)
        {
            Panel chip = new Panel
            {
                BackColor = backgroundColor,
                Margin = new Padding(0, 0, 10, 0),
                Size = new Size(86, 58)
            };

            chip.Controls.Add(new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location = new Point(8, 6),
                Size = new Size(70, 18),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            });

            chip.Controls.Add(new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 15F, FontStyle.Bold),
                ForeColor = valueColor,
                Location = new Point(8, 24),
                Size = new Size(70, 28),
                Text = FormatNumber(value),
                TextAlign = ContentAlignment.MiddleLeft
            });

            queueFlow.Controls.Add(chip);
        }

        private Control CreateInfoRow(string title, string value)
        {
            Panel row = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 6),
                Size = new Size(360, 22)
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(0, 0),
                Size = new Size(230, 22),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(235, 0),
                Size = new Size(125, 22),
                Text = value,
                TextAlign = ContentAlignment.MiddleRight
            });

            return row;
        }

        private void ResizeLayout()
        {
            int contentWidth = Math.Max(700, outerScroll.ClientSize.Width - contentFlow.Padding.Horizontal - 24);
            headerPanel.Width = contentWidth;
            kpiFlow.Width = contentWidth;
            chartFlow.Width = contentWidth;
            insightFlow.Width = contentWidth;

            ResizeKpiCards(contentWidth);
            ResizeChartCards(contentWidth);
            ResizeInsightCards(contentWidth);
            ResizeInfoRows();
        }

        private void ResizeKpiCards(int contentWidth)
        {
            Panel[] cards = { cardPatients, cardAppointments, cardRevenue, cardToday, cardStaff };
            const int gap = 16;
            const int minWidth = 210;
            int cardsPerRow = Math.Max(1, Math.Min(cards.Length, (contentWidth + gap) / (minWidth + gap)));
            int cardWidth = (contentWidth - gap * (cardsPerRow - 1)) / cardsPerRow;
            int rowCount = (int)Math.Ceiling(cards.Length / (double)cardsPerRow);

            foreach (Panel card in cards)
            {
                card.Width = cardWidth;
                card.Height = 134;
                card.Margin = new Padding(0, 0, gap, 16);
            }

            kpiFlow.Height = rowCount * 150;
        }

        private void ResizeChartCards(int contentWidth)
        {
            bool twoColumns = contentWidth >= 920;
            int cardWidth = twoColumns ? (contentWidth - 20) / 2 : contentWidth;

            patientChartCard.Width = cardWidth;
            revenueChartCard.Width = cardWidth;
            patientChartCard.Height = 330;
            revenueChartCard.Height = 330;
            patientChartCard.Margin = twoColumns ? new Padding(0, 0, 20, 0) : new Padding(0, 0, 0, 20);
            revenueChartCard.Margin = new Padding(0);
            chartFlow.Height = twoColumns ? 330 : 680;
        }

        private void ResizeInsightCards(int contentWidth)
        {
            bool twoColumns = contentWidth >= 1020;
            int sideWidth = twoColumns ? 420 : contentWidth;
            int appointmentWidth = twoColumns ? contentWidth - sideWidth - 20 : contentWidth;

            appointmentCard.Width = appointmentWidth;
            appointmentCard.Height = 416;
            appointmentCard.Margin = twoColumns ? new Padding(0, 0, 20, 0) : new Padding(0, 0, 0, 20);

            sidePanel.Width = sideWidth;
            sidePanel.Height = 416;
            queueCard.Width = sideWidth;
            departmentCard.Width = sideWidth;
            medicineCard.Width = sideWidth;
            insightFlow.Height = twoColumns ? 416 : 852;
        }

        private void ResizeInfoRows()
        {
            ResizeRows(departmentFlow);
            ResizeRows(medicineFlow);
        }

        private static void ResizeRows(FlowLayoutPanel panel)
        {
            int width = Math.Max(220, panel.ClientSize.Width - panel.Padding.Horizontal - 8);
            foreach (Control row in panel.Controls)
            {
                row.Width = width;
                if (row.Controls.Count >= 2)
                {
                    row.Controls[0].Width = Math.Max(120, width - 130);
                    row.Controls[1].Left = row.Controls[0].Right + 5;
                    row.Controls[1].Width = Math.Max(90, width - row.Controls[1].Left);
                }
            }
        }

        private string FormatNumber(int value)
        {
            return value.ToString("N0", viCulture);
        }

        private string FormatMoneyShort(decimal value)
        {
            if (value >= 1_000_000_000)
            {
                return (value / 1_000_000_000m).ToString("0.#", viCulture) + " tỷ";
            }

            if (value >= 1_000_000)
            {
                return (value / 1_000_000m).ToString("0.#", viCulture) + " tr";
            }

            return value.ToString("N0", viCulture) + " đ";
        }

        private string FormatTrend(decimal percent)
        {
            if (percent > 0)
            {
                return "+" + percent.ToString("0.#", viCulture) + "% so với tháng trước";
            }

            if (percent < 0)
            {
                return percent.ToString("0.#", viCulture) + "% so với tháng trước";
            }

            return "Ổn định so với tháng trước";
        }

        private void DrawBarChart(Graphics graphics, Rectangle bounds, List<AdminChartPointDTO> points)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            Rectangle plot = new Rectangle(56, 18, bounds.Width - 82, bounds.Height - 58);
            DrawChartGrid(graphics, plot);

            if (points == null || points.Count == 0 || points.Max(p => p.Value) <= 0)
            {
                DrawEmptyChart(graphics, plot);
                return;
            }

            decimal max = points.Max(p => p.Value);
            float slot = plot.Width / (float)points.Count;
            float barWidth = Math.Min(42, slot * 0.58f);

            using SolidBrush barBrush = new SolidBrush(Color.FromArgb(59, 130, 246));
            using SolidBrush textBrush = new SolidBrush(Color.FromArgb(107, 114, 128));
            using Font labelFont = new Font("Segoe UI", 8F);

            for (int i = 0; i < points.Count; i++)
            {
                AdminChartPointDTO point = points[i];
                float height = (float)(point.Value / max) * (plot.Height - 8);
                float x = plot.Left + slot * i + (slot - barWidth) / 2;
                float y = plot.Bottom - height;
                graphics.FillRectangle(barBrush, x, y, barWidth, height);
                DrawCenteredText(graphics, point.PeriodStart.ToString("MM"), labelFont, textBrush, x + barWidth / 2, plot.Bottom + 10);
            }
        }

        private void DrawLineChart(Graphics graphics, Rectangle bounds, List<AdminChartPointDTO> points)
        {
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            Rectangle plot = new Rectangle(58, 18, bounds.Width - 84, bounds.Height - 58);
            DrawChartGrid(graphics, plot);

            if (points == null || points.Count == 0 || points.Max(p => p.Value) <= 0)
            {
                DrawEmptyChart(graphics, plot);
                return;
            }

            decimal max = points.Max(p => p.Value);
            PointF[] linePoints = new PointF[points.Count];
            float slot = points.Count == 1 ? 0 : plot.Width / (float)(points.Count - 1);

            for (int i = 0; i < points.Count; i++)
            {
                float x = plot.Left + slot * i;
                float y = plot.Bottom - (float)(points[i].Value / max) * (plot.Height - 8);
                linePoints[i] = new PointF(x, y);
            }

            using Pen linePen = new Pen(Color.FromArgb(16, 185, 129), 3);
            using SolidBrush pointBrush = new SolidBrush(Color.White);
            using Pen pointPen = new Pen(Color.FromArgb(16, 185, 129), 2);
            using SolidBrush textBrush = new SolidBrush(Color.FromArgb(107, 114, 128));
            using Font labelFont = new Font("Segoe UI", 8F);

            if (linePoints.Length > 1)
            {
                graphics.DrawLines(linePen, linePoints);
            }

            for (int i = 0; i < linePoints.Length; i++)
            {
                RectangleF dot = new RectangleF(linePoints[i].X - 4, linePoints[i].Y - 4, 8, 8);
                graphics.FillEllipse(pointBrush, dot);
                graphics.DrawEllipse(pointPen, dot);
                DrawCenteredText(graphics, points[i].PeriodStart.ToString("MM"), labelFont, textBrush, linePoints[i].X, plot.Bottom + 10);
            }
        }

        private static void DrawChartGrid(Graphics graphics, Rectangle plot)
        {
            using Pen gridPen = new Pen(Color.FromArgb(229, 231, 235));
            using Pen axisPen = new Pen(Color.FromArgb(156, 163, 175));
            for (int i = 0; i <= 4; i++)
            {
                float y = plot.Top + plot.Height * i / 4f;
                graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);
            }

            graphics.DrawLine(axisPen, plot.Left, plot.Top, plot.Left, plot.Bottom);
            graphics.DrawLine(axisPen, plot.Left, plot.Bottom, plot.Right, plot.Bottom);
        }

        private static void DrawEmptyChart(Graphics graphics, Rectangle plot)
        {
            using SolidBrush brush = new SolidBrush(Color.FromArgb(107, 114, 128));
            using Font font = new Font("Segoe UI", 9F);
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            graphics.DrawString("Chưa có dữ liệu", font, brush, plot, format);
        }

        private static void DrawCenteredText(Graphics graphics, string text, Font font, Brush brush, float centerX, float y)
        {
            SizeF size = graphics.MeasureString(text, font);
            graphics.DrawString(text, font, brush, centerX - size.Width / 2, y);
        }

        private void ucAdminStatistics_Load(object sender, EventArgs e)
        {
            ResizeLayout();
            LoadStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void dtpMonth_ValueChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated)
            {
                LoadStatistics();
            }
        }

        private void outerScroll_Resize(object sender, EventArgs e)
        {
            ResizeLayout();
            pnlPatientChart.Invalidate();
            pnlRevenueChart.Invalidate();
        }

        private void pnlPatientChart_Paint(object sender, PaintEventArgs e)
        {
            DrawBarChart(e.Graphics, pnlPatientChart.ClientRectangle, currentStatistics.PatientTrend);
        }

        private void pnlRevenueChart_Paint(object sender, PaintEventArgs e)
        {
            DrawLineChart(e.Graphics, pnlRevenueChart.ClientRectangle, currentStatistics.RevenueTrend);
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointments.Columns[e.ColumnIndex].Name != "colStatus" || e.Value == null)
            {
                return;
            }

            string status = e.Value.ToString();
            if (status.Contains("Hoàn", StringComparison.OrdinalIgnoreCase) ||
                status.Contains("Complete", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                e.CellStyle.Font = new Font(dgvAppointments.Font, FontStyle.Bold);
            }
            else if (status.Contains("Hủy", StringComparison.OrdinalIgnoreCase) ||
                     status.Contains("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                e.CellStyle.Font = new Font(dgvAppointments.Font, FontStyle.Bold);
            }
            else if (status.Contains("Đang", StringComparison.OrdinalIgnoreCase) ||
                     status.Contains("Process", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6);
                e.CellStyle.Font = new Font(dgvAppointments.Font, FontStyle.Bold);
            }
        }

        private void Card_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Control control)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using Pen borderPen = new Pen(Color.FromArgb(229, 231, 235));
            e.Graphics.DrawRectangle(borderPen, 0, 0, control.Width - 1, control.Height - 1);
        }
    }
}
