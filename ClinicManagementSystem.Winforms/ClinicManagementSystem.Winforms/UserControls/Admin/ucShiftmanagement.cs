using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using ClinicManagementSystem.Winforms.Forms;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftManagement : UserControl
    {
        private readonly EmployeeShiftBUS _bus = new EmployeeShiftBUS();
        private readonly WorkShiftDAL _shiftDAL = new WorkShiftDAL();
        private readonly EmployeeDAL _empDAL = new EmployeeDAL();

        private List<EmployeeShiftDTO> _allShifts = new();
        private List<WorkShiftDTO> _workShifts = new();

        public ucShiftManagement()
        {
            InitializeComponent();
            LoadDropdowns();
            LoadData();
            WireViewButtons();
        }

        // ── Dropdowns ─────────────────────────────────────────────────

        private void LoadDropdowns()
        {
            cboEmployee.Items.Clear();
            cboEmployee.Items.AddRange(new object[]
            {
                "Tất cả vai trò", "Doctor", "Nurse",
                "Pharmacist", "Technician", "Receptionist"
            });
            cboEmployee.SelectedIndex = 0;
            _workShifts = _shiftDAL.GetAll();
        }

        // ── Load data ─────────────────────────────────────────────────

        public void LoadData()
        {
            try
            {
                DateTime selectedDate = dtpDate.Value.Date;
                _allShifts = _bus.GetByDateWithRoom(selectedDate);
                ApplyRoleFilter();
                UpdateKPI(_allShifts);
                lblPaging.Text = $"Tổng: {_allShifts.Count} ca trực ngày {selectedDate:dd/MM/yyyy}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid ──────────────────────────────────────────────────────

        private void BindGrid(List<EmployeeShiftDTO> list)
        {
            dgvShifts.Rows.Clear();
            foreach (var s in list)
            {
                string timeText = $"{s.StartTime:hh\\:mm} - {s.EndTime:hh\\:mm}";
                dgvShifts.Rows.Add(
                    s.EmployeeName,
                    s.RoleName,
                    s.DepartmentName,
                    s.ShiftName,
                    timeText,
                    string.IsNullOrEmpty(s.RoomCode) ? "—" : s.RoomCode,
                    s.Status ?? "Approved",
                    "✏ Sửa",
                    "🗑 Xóa"
                );
                dgvShifts.Rows[dgvShifts.Rows.Count - 1].Tag = s;
            }
        }

        // ── KPI ───────────────────────────────────────────────────────

        private void UpdateKPI(List<EmployeeShiftDTO> list)
        {
            int total = list.Count;
            int morning = list.FindAll(s => s.ShiftName.Contains("sáng")).Count;
            int afternoon = list.FindAll(s => s.ShiftName.Contains("chiều")).Count;
            int night = list.FindAll(s =>
                s.ShiftName.Contains("tối") || s.ShiftName.Contains("đêm")).Count;

            SetKpi(cardOnDuty, total);
            SetKpi(cardMorning, morning);
            SetKpi(cardAfternoon, afternoon);
            SetKpi(cardNight, night);
        }

        private static void SetKpi(Panel card, int value)
        {
            foreach (Control ctrl in card.Controls)
            {
                if (ctrl is Label lbl && lbl.Tag?.ToString() == "value")
                {
                    lbl.Text = value.ToString();
                    break;
                }
            }
        }

        private void panelKPI_Resize(object sender, EventArgs e)
        {
            var cards = new[] { cardOnDuty, cardMorning, cardAfternoon, cardNight };
            if (cards[0] == null) return;

            int gap = 14;
            int total = panelKPI.ClientSize.Width;
            int w = (total - gap * (cards.Length - 1)) / cards.Length;
            if (w <= 0) return;

            int x = 0;
            foreach (var c in cards)
            {
                c.Location = new Point(x, 8);
                c.Size = new Size(w, 100);
                x += w + gap;
            }
        }

        // ── Filter ────────────────────────────────────────────────────

        private void ApplyRoleFilter()
        {
            string role = cboEmployee.SelectedItem?.ToString() ?? "Tất cả vai trò";
            var filtered = role == "Tất cả vai trò"
                ? _allShifts
                : _allShifts.FindAll(s => s.RoleName == role);
            BindGrid(filtered);
            lblPaging.Text = $"Hiển thị: {filtered.Count} / {_allShifts.Count} ca trực";
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyRoleFilter();
        }

        // ── View buttons ──────────────────────────────────────────────

        private void WireViewButtons()
        {
            btnViewDay.Click += (s, e) =>
            {
                dtpDate.Value = DateTime.Today;
                LoadData();
            };
            btnViewWeek.Click += (s, e) =>
                MessageBox.Show("Chế độ xem tuần sẽ được phát triển sau.", "Thông báo");
            btnViewMonth.Click += (s, e) =>
                MessageBox.Show("Chế độ xem tháng sẽ được phát triển sau.", "Thông báo");
        }

        // ── CRUD ──────────────────────────────────────────────────────

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            var frm = new frmShiftAdd();
            frm.ShowDialog(this);
            if (frm.Saved) LoadData();
        }

        private void dgvShifts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = dgvShifts.Columns[e.ColumnIndex].Name;
            if (col != "colEdit" && col != "colDelete") return;

            if (dgvShifts.Rows[e.RowIndex].Tag is not EmployeeShiftDTO shift) return;

            if (col == "colEdit")
            {
                var frm = new frmShiftEdit(shift);
                frm.ShowDialog(this);
                if (frm.Saved) LoadData();
            }
            else if (col == "colDelete")
            {
                if (MessageBox.Show(
                    $"Xóa ca trực của {shift.EmployeeName}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

                if (_bus.Delete(shift.EmployeeShiftID))
                {
                    MessageBox.Show("Xóa thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvShifts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            switch (dgvShifts.Columns[e.ColumnIndex].Name)
            {
                case "colShiftStatus":
                    e.CellStyle.ForeColor = Color.FromArgb(5, 150, 105);
                    e.CellStyle.BackColor = Color.FromArgb(209, 250, 229);
                    break;
                case "colShift":
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
                    break;
                case "colRole":
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    e.CellStyle.BackColor = Color.FromArgb(219, 234, 254);
                    break;
                case "colEdit":
                    e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235);
                    break;
                case "colDelete":
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    break;
            }
        }

        private void dgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }
    }
}