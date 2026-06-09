using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftRequestManagement : UserControl
    {
        private readonly EmployeeShiftBUS _bus = new EmployeeShiftBUS();
        private readonly WorkShiftDAL _shiftDAL = new WorkShiftDAL();
        private readonly EmployeeDAL _empDAL = new EmployeeDAL();

        private List<EmployeeShiftDTO> _allShifts = new();
        private List<EmployeeShiftDTO> _todayShifts = new();

        public ucShiftRequestManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                _allShifts = _bus.GetAll();
                _todayShifts = _bus.GetByDateWithRoom(DateTime.Today);
                UpdateKPI();
                ShowTabOverview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── KPI ───────────────────────────────────────────────────────

        private void UpdateKPI()
        {
            int total = _allShifts.Count;
            int pending = 0;
            int approved = _allShifts.FindAll(s => s.Status == "Approved").Count;
            int rejected = 0;

            int thisMonth = _allShifts.FindAll(s =>
                s.WorkDate.Month == DateTime.Today.Month &&
                s.WorkDate.Year == DateTime.Today.Year).Count;

            SetKpi(cardTotal, total.ToString(), $"+{thisMonth} ca tháng này");
            SetKpi(cardPending, pending.ToString(), "Yêu cầu đổi ca cần xử lý");
            SetKpi(cardApproved, approved.ToString(), "Tháng này");
            SetKpi(cardRejected, rejected.ToString(), "Tháng này");

            lblBadge.Text = pending.ToString();
            lblBadge.Visible = pending > 0;
            panelWarning.Visible = pending > 0;
        }

        private static void SetKpi(Panel card, string value, string sub)
        {
            foreach (Control ctrl in card.Controls)
            {
                if (ctrl is Label lbl)
                {
                    if (lbl.Tag?.ToString() == "value") lbl.Text = value;
                    if (lbl.Tag?.ToString() == "sub") lbl.Text = sub;
                }
            }
        }

        // ── Tab navigation ────────────────────────────────────────────

        private void btnTabOverview_Click(object sender, EventArgs e) => ShowTabOverview();
        private void btnTabApproval_Click(object sender, EventArgs e) => ShowTabApproval();
        private void btnTabSchedule_Click(object sender, EventArgs e) => ShowTabSchedule();
        private void btnWarningAction_Click(object sender, EventArgs e) => ShowTabApproval();

        private void SetActiveTab(Button active)
        {
            btnTabOverview.Tag = null;
            btnTabApproval.Tag = null;
            btnTabSchedule.Tag = null;
            active.Tag = "active";

            foreach (Control c in panelTabs.Controls)
            {
                if (c is Button btn)
                {
                    btn.ForeColor = btn == active
                        ? Color.FromArgb(37, 99, 235)
                        : Color.FromArgb(107, 114, 128);
                }
            }
            panelTabs.Invalidate();
        }

        // ── Tab 1: Tổng quan ──────────────────────────────────────────

        private void ShowTabOverview()
        {
            SetActiveTab(btnTabOverview);
            panelTabContent.Controls.Clear();

            // ── Row 1: 2 stat cards ──
            var rowStats = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.Transparent,
                Padding = new Padding(0, 0, 0, 12)
            };

            int upcoming7 = 0;
            for (int i = 1; i <= 7; i++)
                upcoming7 += _bus.GetByDate(DateTime.Today.AddDays(i)).Count;

            var cardToday = MakeMiniStatCard(
                "Ca hôm nay", _todayShifts.Count.ToString(),
                "Đang hoạt động",
                Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            cardToday.Location = new Point(0, 0);
            cardToday.Size = new Size(280, 100);

            var cardUpcoming = MakeMiniStatCard(
                "Ca sắp tới", upcoming7.ToString(),
                "7 ngày tới",
                Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            cardUpcoming.Location = new Point(296, 0);
            cardUpcoming.Size = new Size(280, 100);

            int thisMonth = _allShifts.FindAll(s =>
                s.WorkDate.Month == DateTime.Today.Month &&
                s.WorkDate.Year == DateTime.Today.Year).Count;

            var cardMonth = MakeMiniStatCard(
                "Ca tháng này", thisMonth.ToString(),
                $"Tháng {DateTime.Today.Month}/{DateTime.Today.Year}",
                Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254));
            cardMonth.Location = new Point(592, 0);
            cardMonth.Size = new Size(280, 100);

            rowStats.Controls.AddRange(new Control[] { cardToday, cardUpcoming, cardMonth });
            panelTabContent.Controls.Add(rowStats);

            // ── Row 2: danh sách ca hôm nay ──
            var cardList = BuildShiftGrid("📋  Lịch trực hôm nay", _todayShifts);
            panelTabContent.Controls.Add(cardList);
        }

        // ── Tab 2: Duyệt đổi ca ───────────────────────────────────────

        private void ShowTabApproval()
        {
            SetActiveTab(btnTabApproval);
            panelTabContent.Controls.Clear();

            var card = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                BackColor = Color.White,
                Padding = new Padding(24)
            };

            card.Controls.Add(new Label
            {
                Text = "✅  Duyệt yêu cầu đổi ca",
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(24, 20),
                AutoSize = true
            });

            // Info box
            var infoBox = new Panel
            {
                Location = new Point(24, 60),
                Size = new Size(700, 80),
                BackColor = Color.FromArgb(239, 246, 255)
            };
            infoBox.Controls.Add(new Label
            {
                Text = "ℹ️  Hiện tại chưa có yêu cầu đổi ca nào đang chờ duyệt.",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(37, 99, 235),
                Location = new Point(16, 12),
                AutoSize = true
            });
            infoBox.Controls.Add(new Label
            {
                Text = "Khi nhân viên gửi yêu cầu đổi ca, danh sách sẽ hiện ở đây để bạn xem xét và phê duyệt.",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(55, 65, 81),
                Location = new Point(16, 38),
                AutoSize = true
            });

            card.Controls.Add(infoBox);
            panelTabContent.Controls.Add(card);
        }

        // ── Tab 3: Lịch làm việc ──────────────────────────────────────

        private void ShowTabSchedule()
        {
            SetActiveTab(btnTabSchedule);
            panelTabContent.Controls.Clear();

            // Filter bar
            var filterBar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 56,
                BackColor = Color.White,
                Padding = new Padding(16, 10, 16, 10)
            };

            var lblFilter = new Label
            {
                Text = "Chọn ngày:",
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(16, 18),
                AutoSize = true
            };

            var dtp = new DateTimePicker
            {
                Location = new Point(100, 12),
                Size = new Size(180, 32),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Today,
                Font = new Font("Segoe UI", 10F)
            };

            var btnFilter = new Button
            {
                Text = "🔍  Xem",
                Location = new Point(292, 10),
                Size = new Size(90, 34),
                BackColor = Color.FromArgb(37, 99, 235),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnFilter.FlatAppearance.BorderSize = 0;

            filterBar.Controls.AddRange(new Control[] { lblFilter, dtp, btnFilter });
            panelTabContent.Controls.Add(filterBar);

            // Grid container — dùng Panel có thể update
            var gridContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            panelTabContent.Controls.Add(gridContainer);

            // Load lần đầu
            RefreshScheduleGrid(gridContainer, DateTime.Today);

            // Khi bấm Xem
            btnFilter.Click += (s, e) =>
            {
                gridContainer.Controls.Clear();
                RefreshScheduleGrid(gridContainer, dtp.Value.Date);
            };
        }

        private void RefreshScheduleGrid(Panel container, DateTime date)
        {
            container.Controls.Clear();
            var shifts = _bus.GetByDateWithRoom(date);
            var grid = BuildShiftGrid(
                $"📅  Lịch làm việc ngày {date:dd/MM/yyyy}  ({shifts.Count} ca)",
                shifts);
            grid.Dock = DockStyle.Top;
            container.Controls.Add(grid);
        }

        // ── Shared UI helpers ─────────────────────────────────────────

        private static Panel MakeMiniStatCard(
            string title, string value, string sub,
            Color fg, Color bg)
        {
            var card = new Panel { BackColor = bg };
            card.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
                e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
            };
            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 9F),
                ForeColor = fg,
                Location = new Point(16, 12),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = fg,
                Location = new Point(16, 34),
                AutoSize = true
            });
            card.Controls.Add(new Label
            {
                Text = sub,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(16, 76),
                AutoSize = true
            });
            return card;
        }

        private Panel BuildShiftGrid(string title, List<EmployeeShiftDTO> shifts)
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Color.FromArgb(229, 231, 235),
                Font = new Font("Segoe UI", 9.5F),
                RowTemplate = { Height = 48 }
            };

            // Header style
            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(249, 250, 251),
                ForeColor = Color.FromArgb(107, 114, 128),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Padding = new Padding(12, 0, 0, 0)
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv.ColumnHeadersHeight = 44;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            // Row style
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                ForeColor = Color.FromArgb(55, 65, 81),
                SelectionBackColor = Color.FromArgb(239, 246, 255),
                SelectionForeColor = Color.FromArgb(17, 24, 39),
                Padding = new Padding(12, 0, 0, 0)
            };

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "NHÂN VIÊN",
                FillWeight = 22,
                DefaultCellStyle = { Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colRole", HeaderText = "VAI TRÒ", FillWeight = 12 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colDept", HeaderText = "CHUYÊN KHOA", FillWeight = 16 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colShift", HeaderText = "CA", FillWeight = 10 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTime", HeaderText = "GIỜ LÀM VIỆC", FillWeight = 14 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colRoom", HeaderText = "PHÒNG", FillWeight = 9 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colDate", HeaderText = "NGÀY", FillWeight = 11 });

            foreach (var s in shifts)
            {
                string time = $"{s.StartTime:hh\\:mm} - {s.EndTime:hh\\:mm}";
                dgv.Rows.Add(
                    s.EmployeeName,
                    s.RoleName,
                    s.DepartmentName,
                    s.ShiftName,
                    time,
                    string.IsNullOrEmpty(s.RoomCode) ? "—" : s.RoomCode,
                    s.WorkDate.ToString("dd/MM/yyyy")
                );
            }

            dgv.CellFormatting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (dgv.Columns[e.ColumnIndex].Name == "colShift")
                {
                    string val = e.Value?.ToString() ?? "";
                    if (val.Contains("sáng"))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                        e.CellStyle.BackColor = Color.FromArgb(209, 250, 229);
                    }
                    else if (val.Contains("chiều"))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);
                        e.CellStyle.BackColor = Color.FromArgb(254, 215, 170);
                    }
                    else if (val.Contains("tối"))
                    {
                        e.CellStyle.ForeColor = Color.FromArgb(124, 58, 237);
                        e.CellStyle.BackColor = Color.FromArgb(237, 233, 254);
                    }
                }
                if (dgv.Columns[e.ColumnIndex].Name == "colRole")
                {
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                }
            };

            int gridHeight = Math.Max(200, shifts.Count * 48 + 100);

            var card = new Panel
            {
                Dock = DockStyle.Top,
                Height = gridHeight,
                BackColor = Color.White,
                Padding = new Padding(0, 0, 0, 0),
                Margin = new Padding(0, 8, 0, 0)
            };

            card.Controls.Add(new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Dock = DockStyle.Top,
                Height = 44,
                Padding = new Padding(20, 12, 0, 0)
            });

            card.Controls.Add(dgv);
            return card;
        }

        // ── Paint events ──────────────────────────────────────────────

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnCreate != null)
                btnCreate.Location = new Point(panelHeader.Width - btnCreate.Width, 18);
        }

        private void kpiFlow_Resize(object sender, EventArgs e)
        {
            Panel[] cards = { cardTotal, cardPending, cardApproved, cardRejected };
            int gap = 16;
            int cardWidth = (kpiFlow.Width - gap * 3) / 4;
            if (cardWidth <= 0) return;

            foreach (Panel card in cards)
            {
                card.Width = cardWidth;
                card.Height = 130;  // ← tăng từ 120 lên 130
                card.Margin = new Padding(0, 0, gap, 0);
            }
        }

        private void panelWarning_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(234, 179, 8), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, panelWarning.Width - 1, panelWarning.Height - 1);
        }

        private void panelWarning_Resize(object sender, EventArgs e)
        {
            if (btnWarningAction != null)
                btnWarningAction.Location = new Point(panelWarning.Width - btnWarningAction.Width - 16, 10);
        }

        private void panelTabs_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawLine(pen, 0, panelTabs.Height - 1, panelTabs.Width, panelTabs.Height - 1);

            foreach (Control ctrl in panelTabs.Controls)
            {
                if (ctrl is Button btn && btn.Tag?.ToString() == "active")
                {
                    using var blue = new Pen(Color.FromArgb(37, 99, 235), 2);
                    e.Graphics.DrawLine(blue,
                        btn.Left, panelTabs.Height - 2,
                        btn.Right, panelTabs.Height - 2);
                }
            }
        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel card) return;
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        }
    }
}