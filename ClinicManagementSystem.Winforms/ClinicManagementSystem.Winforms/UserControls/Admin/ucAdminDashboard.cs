using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucAdminDashboard : UserControl
    {
        private readonly AdminStatisticsBUS statisticsBUS = new AdminStatisticsBUS();
        private readonly CultureInfo viCulture = new CultureInfo("vi-VN");
        private AdminStatisticsDTO currentStatistics = new AdminStatisticsDTO();

        public ucAdminDashboard()
        {
            InitializeComponent();
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
            kpiFlow.Controls.Clear();
            cardPatients = MakeKpi(
                FormatNumber(currentStatistics.TotalPatients),
                "Tổng bệnh nhân",
                "BN",
                Color.FromArgb(37, 99, 235),
                Color.FromArgb(239, 246, 255));
            cardAppointments = MakeKpi(
                FormatNumber(currentStatistics.MonthlyAppointmentCount),
                "Lịch khám tháng này",
                "LK",
                Color.FromArgb(5, 150, 105),
                Color.FromArgb(236, 253, 245));
            cardWaiting = MakeKpi(
                FormatNumber(currentStatistics.QueueSummary?.Waiting ?? 0),
                "Bệnh nhân đang chờ",
                "CD",
                Color.FromArgb(217, 119, 6),
                Color.FromArgb(255, 251, 235));
            cardEmployees = MakeKpi(
                FormatNumber(currentStatistics.ActiveEmployeeCount),
                "Nhân sự hoạt động",
                "NS",
                Color.FromArgb(15, 118, 110),
                Color.FromArgb(240, 253, 250));
            cardMedicine = MakeKpi(
                FormatNumber(currentStatistics.LowStockMedicineCount),
                "Thuốc sắp hết",
                "TH",
                Color.FromArgb(220, 38, 38),
                Color.FromArgb(254, 242, 242));

            kpiFlow.Controls.AddRange(new Control[]
            {
                cardPatients,
                cardAppointments,
                cardWaiting,
                cardEmployees,
                cardMedicine
            });
        }

        private void BindAppointments()
        {
            dgvAppointments.Rows.Clear();
            if (!currentStatistics.TodayAppointments.Any())
            {
                dgvAppointments.Rows.Add("--", "Chưa có lịch khám", string.Empty, string.Empty, "Trống");
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
            panelQueueCards.Controls.Clear();
            AdminQueueSummaryDTO queue = currentStatistics.QueueSummary ?? new AdminQueueSummaryDTO();
            cardWaitingQ = MakeQueue("Chờ khám", FormatNumber(queue.Waiting), Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            cardInProgressQ = MakeQueue("Đang khám", FormatNumber(queue.InProgress), Color.FromArgb(217, 119, 6), Color.FromArgb(255, 251, 235));
            cardDoneQ = MakeQueue("Hoàn thành", FormatNumber(queue.Completed), Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            cardCancelledQ = MakeQueue("Đã hủy", FormatNumber(queue.Cancelled), Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
            panelQueueCards.Controls.AddRange(new Control[] { cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ });
        }

        private Control CreateLine(string title, string value)
        {
            Panel row = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 8),
                Size = new Size(520, 28)
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(0, 2),
                Size = new Size(340, 24),
                Text = title
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(348, 2),
                Size = new Size(160, 24),
                Text = value,
                TextAlign = ContentAlignment.MiddleRight
            });

            return row;
        }

        private Control CreateMiniCard(string title, string value, Color accent)
        {
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(249, 250, 251),
                Margin = new Padding(0, 0, 12, 0),
                Size = new Size(180, 96)
            };
            card.Paint += Card_Paint;
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(14, 14),
                Size = new Size(150, 25),
                Text = title
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(14, 48),
                Size = new Size(150, 30),
                Text = value
            });
            return card;
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

            ResizeKpi(inner);
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
            Panel[] cards = { cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ };
            if (cards.Any(card => card == null)) return;

            int availableWidth = panelQueueCards.ClientSize.Width - panelQueueCards.Padding.Horizontal;
            int cardWidth = (availableWidth - 36) / 4;
            if (cardWidth <= 0) return;

            foreach (Panel card in cards)
            {
                card.Width = cardWidth;
                card.Height = 120;
                card.Margin = new Padding(0, 0, 12, 0);
            }
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
    }
}
