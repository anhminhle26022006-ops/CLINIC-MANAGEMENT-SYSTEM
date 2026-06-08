using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BUS.Services;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucAdminDashboard : UserControl
    {
        private readonly DashboardBUS _bus = new DashboardBUS();

        public ucAdminDashboard()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        public void LoadData()
        {
            try
            {
                LoadKpiCards();
                LoadAppointmentTable();
                LoadMedicineList();
                LoadDeptStats();
                LoadQueueStats();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Dashboard error: " + ex.Message);
            }
        }

        // ── KPI ──────────────────────────────────────────────────────────────
        private void LoadKpiCards()
        {
            SetKpiVal(cardPatients, _bus.GetTotalPatients().ToString(), "Tổng bệnh nhân");
            SetKpiVal(cardAppointments, _bus.GetTodayAppointments().ToString(), "Lịch khám hôm nay");
            SetKpiVal(cardWaiting, _bus.GetWaitingPatients().ToString(), "Bệnh nhân chờ khám");
            SetKpiVal(cardEmployees, _bus.GetTotalActiveEmployees().ToString(), "Tổng nhân viên");
            SetKpiVal(cardMedicine, _bus.GetLowStockMedicines().ToString(), "Thuốc sắp hết");
        }

        private void SetKpiVal(Panel card, string value, string title)
        {
            if (card == null) return;
            foreach (Control c in card.Controls)
                if (c is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "value") lbl.Text = value;
                    if (lbl.Tag?.ToString() == "title") lbl.Text = title;
                }
        }

        // ── Appointment Table ────────────────────────────────────────────────
        private void LoadAppointmentTable()
        {
            DataTable dt = _bus.GetTodayAppointmentTable();
            dgvAppointments.DataSource = null;
            dgvAppointments.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                int r = dgvAppointments.Rows.Add();
                dgvAppointments.Rows[r].Cells["colTime"].Value = row["GioKham"].ToString();
                dgvAppointments.Rows[r].Cells["colPatient"].Value = row["BenhNhan"].ToString();
                dgvAppointments.Rows[r].Cells["colDoctor"].Value = row["BacSi"].ToString();
                dgvAppointments.Rows[r].Cells["colDept"].Value = row["ChuyenKhoa"].ToString();
                dgvAppointments.Rows[r].Cells["colStatus"].Value = MapStatus(row["Status"].ToString());
            }
        }

        private string MapStatus(string s)
        {
            switch (s)
            {
                case "Confirmed": return "Đã xác nhận";
                case "Pending": return "Chờ tiếp nhận";
                case "Completed": return "Hoàn thành";
                case "Cancelled": return "Đã hủy";
                case "InProgress": return "Đang khám";
                default: return s ?? "";
            }
        }

        // ── Medicine List ────────────────────────────────────────────────────
        private void LoadMedicineList()
        {
            DataTable dt = _bus.GetLowStockMedicineList();
            panelMedicineList.Controls.Clear();

            if (dt.Rows.Count == 0)
            {
                panelMedicineList.Controls.Add(new Label
                {
                    Text = "Không có thuốc sắp hết",
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Dock = DockStyle.Top,
                    Height = 48,
                    TextAlign = ContentAlignment.MiddleCenter
                });
                medCard.Height = 110;
                return;
            }

            Color[] bgColors = { Color.FromArgb(254, 242, 242), Color.FromArgb(255, 247, 237), Color.FromArgb(254, 252, 232) };
            Color[] fgColors = { Color.FromArgb(220, 38, 38), Color.FromArgb(234, 88, 12), Color.FromArgb(161, 98, 7) };
            Color[] borderColors = { Color.FromArgb(252, 165, 165), Color.FromArgb(253, 186, 116), Color.FromArgb(252, 211, 77) };

            int idx = 0;
            foreach (DataRow row in dt.Rows)
            {
                Color bg = bgColors[idx % 3];
                Color fg = fgColors[idx % 3];
                Color border = borderColors[idx % 3];

                // Tính toán độ rộng tạm thời ban đầu
                int initialWidth = panelMedicineList.ClientSize.Width - panelMedicineList.Padding.Horizontal - 6;

                Panel card = new Panel
                {
                    Width = initialWidth > 0 ? initialWidth : 200, // Đảm bảo không bị lỗi kích thước âm
                    Height = 82,
                    BackColor = bg,
                    Margin = new Padding(0, 0, 0, 8)
                };

                Label lblName = new Label
                {
                    Text = row["Name"].ToString(),
                    Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(17, 24, 39),
                    Location = new Point(18, 13),
                    AutoSize = true
                };
                Label lblSub = new Label
                {
                    Text = row["Unit"].ToString(),
                    Font = new Font("Segoe UI", 8.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    Location = new Point(18, 40),
                    AutoSize = true
                };
                Label lblStock = new Label
                {
                    Text = row["Stock"].ToString(),
                    Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                    ForeColor = fg,
                    TextAlign = ContentAlignment.MiddleRight,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    AutoSize = false,
                    Size = new Size(100, 42), // 🌟 TĂNG LÊN: Chiều cao 42px giúp hiển thị trọn vẹn font 22F
                    Location = new Point(card.Width - 118, 12) // Điều chỉnh lại Y bắt đầu từ 12
                };

                Label lblUnit = new Label
                {
                    Text = "viên còn lại",
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    TextAlign = ContentAlignment.MiddleRight,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    AutoSize = false,
                    Size = new Size(100, 18), // Tăng nhẹ chiều rộng lên 100 để chữ không bị xuống hàng
                    Location = new Point(card.Width - 118, 54) // 🌟 DỜI XUỐNG: Vị trí Y mới bằng Y của Stock + Height của Stock (12 + 42 = 54)
                };

                // Cập nhật lại sự kiện dịch chuyển vị trí khi Resize cho đồng bộ tọa độ mới
                card.Resize += (s, e2) =>
                {
                    var c = (Panel)s;
                    lblStock.Location = new Point(c.Width - 118, 12);
                    lblUnit.Location = new Point(c.Width - 118, 54);
                };

                card.Paint += (s, e2) =>
                {
                    var g = e2.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    using (var pen = new Pen(border, 1))
                        g.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                };

                card.Controls.Add(lblName);
                card.Controls.Add(lblSub);
                card.Controls.Add(lblStock);
                card.Controls.Add(lblUnit);
                panelMedicineList.Controls.Add(card);
                idx++;
            }

            // 🌟 ĐƯA RA NGOÀI: Đăng ký sự kiện co giãn chuẩn cho panel danh sách thuốc
            panelMedicineList.Resize += (s, e) =>
            {
                int targetWidth = panelMedicineList.ClientSize.Width - panelMedicineList.Padding.Horizontal - 6;
                if (targetWidth > 0)
                {
                    foreach (Control ctrl in panelMedicineList.Controls)
                    {
                        if (ctrl is Panel) ctrl.Width = targetWidth;
                    }
                }
            };

            // Ép các card con cập nhật đúng chiều rộng thực tế ngay lập tức sau khi load dữ liệu
            int finalWidth = panelMedicineList.ClientSize.Width - panelMedicineList.Padding.Horizontal - 6;
            if (finalWidth > 0)
            {
                foreach (Control ctrl in panelMedicineList.Controls)
                {
                    if (ctrl is Panel) ctrl.Width = finalWidth;
                }
            }

            // Tính toán lại chiều cao động cho medCard bao ngoài
            medCard.Height = 52 + (dt.Rows.Count * 90) + 20;
        }

        // ── Dept Stats ───────────────────────────────────────────────────────
        private void LoadDeptStats()
        {
            DataTable dt = _bus.GetEmployeesByDepartment();
            panelDeptCards.Controls.Clear();

            Color[] bgColors = { Color.FromArgb(239, 246, 255), Color.FromArgb(236, 253, 245), Color.FromArgb(245, 243, 255), Color.FromArgb(255, 247, 237) };
            Color[] fgColors = { Color.FromArgb(37, 99, 235), Color.FromArgb(5, 150, 105), Color.FromArgb(124, 58, 237), Color.FromArgb(234, 88, 12) };

            int idx = 0;
            foreach (DataRow row in dt.Rows)
            {
                Color bg = bgColors[idx % 4];
                Color fg = fgColors[idx % 4];
                int gap = 14;

                int cardWidth =
                (
                    panelDeptCards.ClientSize.Width
                    - panelDeptCards.Padding.Left
                    - panelDeptCards.Padding.Right
                    - gap * 3
                ) / 4;

                Panel card = new Panel
                {
                    Width = cardWidth,
                    Height = 100,
                    BackColor = bg,
                    Margin = new Padding(0, 0, 14, 0)
                };

                card.Controls.Add(new Label
                {
                    Text = row["EmpCount"].ToString(),
                    Font = new Font("Segoe UI", 26F, FontStyle.Bold),
                    ForeColor = fg,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Size = new Size(cardWidth, 50),
                    Location = new Point(0, 14)
                });

                card.Controls.Add(new Label
                {
                    Text = row["DepartmentName"].ToString(),
                    Font = new Font("Segoe UI", 9.5F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Size = new Size(cardWidth, 24),
                    Location = new Point(0, 66)
                });

                panelDeptCards.Controls.Add(card);
                idx++;
            }
            panelDeptCards.Resize += (s, e) =>
            {
                int w =
                    (panelDeptCards.ClientSize.Width
                     - panelDeptCards.Padding.Horizontal
                     - 42) / 4;

                foreach (Control c in panelDeptCards.Controls)
                {
                    c.Width = w;
                }
            };
            deptCard.Height = 52 + 100 + 28;
        }

        // ── Queue Stats ──────────────────────────────────────────────────────
        private void LoadQueueStats()
        {
            Dictionary<string, int> stats = _bus.GetQueueStats();
            SetQueueCard(cardWaitingQ, stats["Waiting"].ToString(), "Đang chờ", Color.FromArgb(234, 88, 12), Color.FromArgb(255, 247, 237));
            SetQueueCard(cardInProgressQ, stats["InProgress"].ToString(), "Đang khám", Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            SetQueueCard(cardDoneQ, stats["Done"].ToString(), "Hoàn thành", Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            SetQueueCard(cardCancelledQ, stats["Cancelled"].ToString(), "Hủy", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242));
        }

        private void SetQueueCard(Panel card, string value, string title, Color fg, Color bg)
        {
            if (card == null) return;
            card.BackColor = bg;
            foreach (Control c in card.Controls)
                if (c is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "value") { lbl.Text = value; lbl.ForeColor = fg; }
                    if (lbl.Tag?.ToString() == "title") { lbl.Text = title; lbl.ForeColor = fg; }
                }
        }

        // ── DataGridView cell formatting ─────────────────────────────────────
        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvAppointments.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                Color fg, bg;
                switch (e.Value.ToString())
                {
                    case "Đã xác nhận": fg = Color.FromArgb(37, 99, 235); bg = Color.FromArgb(219, 234, 254); break;
                    case "Chờ tiếp nhận": fg = Color.FromArgb(234, 88, 12); bg = Color.FromArgb(255, 237, 213); break;
                    case "Hoàn thành": fg = Color.FromArgb(5, 150, 105); bg = Color.FromArgb(209, 250, 229); break;
                    case "Đã hủy": fg = Color.FromArgb(220, 38, 38); bg = Color.FromArgb(254, 226, 226); break;
                    case "Đang khám": fg = Color.FromArgb(124, 58, 237); bg = Color.FromArgb(237, 233, 254); break;
                    default: fg = Color.FromArgb(107, 114, 128); bg = Color.FromArgb(243, 244, 246); break;
                }
                e.CellStyle.ForeColor = fg;
                e.CellStyle.BackColor = bg;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = fg;
                e.CellStyle.SelectionBackColor = bg;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => LoadData();
    }
}