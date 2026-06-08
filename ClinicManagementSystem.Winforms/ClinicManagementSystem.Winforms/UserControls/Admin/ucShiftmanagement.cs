using BUS.Services;
using DAL.DataContext;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms.Admin;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftManagement : UserControl
    {
        private readonly EmployeeShiftBUS _shiftBus = new EmployeeShiftBUS();
        private readonly EmployeeBUS _empBus = new EmployeeBUS();
        private readonly WorkShiftBUS _wsBus = new WorkShiftBUS();
        private List<EmployeeShiftDTO> _all = new List<EmployeeShiftDTO>();

        public ucShiftManagement()
        {
            InitializeComponent();
            this.Load += (s, e) => Init();
        }

        // ── Init ─────────────────────────────────────────────────────
        private void Init()
        {
            cboEmployee.Items.Clear();
            cboEmployee.Items.Add(new ComboItem(0, "Tất cả vai trò"));
            cboEmployee.Items.Add(new ComboItem(-1, "Bác sĩ"));
            cboEmployee.Items.Add(new ComboItem(-2, "Y tá"));
            cboEmployee.Items.Add(new ComboItem(-3, "Dược sĩ"));
            cboEmployee.Items.Add(new ComboItem(-4, "Kỹ thuật viên"));
            cboEmployee.Items.Add(new ComboItem(-5, "Lễ tân"));
            cboEmployee.SelectedIndex = 0;

            dtpDate.Value = DateTime.Today;
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                if (!_shiftBus.SupportsEmployeeShiftSchema())
                    return;

                _all = _shiftBus.GetAll();
                UpdateKpiCards();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── KPI cards ────────────────────────────────────────────────
        private void UpdateKpiCards()
        {
            // Đếm theo ngày đang filter trên dtpDate
            var filterDate = dtpDate != null ? dtpDate.Value.Date : DateTime.Today;
            int onDuty = 0, morning = 0, afternoon = 0, night = 0;

            foreach (var s in _all)
            {
                if (s.WorkDate.Date != filterDate) continue;
                onDuty++;
                string name = (s.ShiftName ?? "").ToLower();
                if (name.Contains("sáng") || name.Contains("morning")) morning++;
                else if (name.Contains("chiều") || name.Contains("afternoon")) afternoon++;
                else if (name.Contains("tối") || name.Contains("night")) night++;
                else if (name.Contains("ngày") || name.Contains("full")) morning++;
            }

            // Nếu ngày đó không có data, đếm tổng toàn bộ
            if (onDuty == 0 && _all.Count > 0)
            {
                onDuty = _all.Count;
                foreach (var s in _all)
                {
                    string name = (s.ShiftName ?? "").ToLower();
                    if (name.Contains("sáng") || name.Contains("morning")) morning++;
                    else if (name.Contains("chiều") || name.Contains("afternoon")) afternoon++;
                    else if (name.Contains("tối") || name.Contains("night")) night++;
                    else if (name.Contains("ngày") || name.Contains("full")) morning++;
                }
            }

            SetKpi(cardOnDuty, onDuty.ToString());
            SetKpi(cardMorning, morning.ToString());
            SetKpi(cardAfternoon, afternoon.ToString());
            SetKpi(cardNight, night.ToString());
        }

        private void SetKpi(Panel card, string value)
        {
            if (card == null) return;
            foreach (Control c in card.Controls)
                if (c is Label lbl && lbl.Tag?.ToString() == "value")
                    lbl.Text = value;
        }

        // ── Filter ───────────────────────────────────────────────────
        private void ApplyFilter()
        {
            // roleFilter: Id < 0 = filter theo vai trò, Id = 0 = tất cả
            string roleFilter = "";
            if (cboEmployee.SelectedItem is ComboItem ci && ci.Id < 0)
                roleFilter = ci.Name;

            var filtered = new List<EmployeeShiftDTO>();
            foreach (var s in _all)
            {
                // Chỉ filter ngày khi user đã chọn ngày cụ thể (khác ngày mặc định init)
                bool matchDate = s.WorkDate.Date == dtpDate.Value.Date;
                bool matchRole = string.IsNullOrEmpty(roleFilter) || MapRole(s.RoleName) == roleFilter;
                if (matchDate && matchRole) filtered.Add(s);
            }

            // Nếu không có data ngày được chọn, hiện tất cả và thông báo
            if (filtered.Count == 0 && _all.Count > 0)
            {
                filtered = new List<EmployeeShiftDTO>(_all);
                foreach (var s in _all)
                {
                    bool matchRole = string.IsNullOrEmpty(roleFilter) || MapRole(s.RoleName) == roleFilter;
                    if (!matchRole) filtered.Remove(s);
                }
            }

            dgvShifts.DataSource = null;
            dgvShifts.Rows.Clear();

            foreach (var s in filtered)
            {
                
                int row = dgvShifts.Rows.Add();
                var r = dgvShifts.Rows[row];
                r.Cells["colEmpName"].Value = s.EmployeeName;
                r.Cells["colRole"].Value = MapRole(s.RoleName);
                r.Cells["colDept"].Value = s.DepartmentName;
                r.Cells["colShift"].Value = s.ShiftName;
                r.Cells["colTime"].Value = s.StartTime.ToString(@"hh\:mm") + " - " + s.EndTime.ToString(@"hh\:mm");
                r.Cells["colRoom"].Value = s.RoomName ?? "";
                r.Cells["colShiftStatus"].Value = MapStatus(s.Status);
                r.Tag = s.EmployeeShiftID;
            }

            // date shown in filter
            lblPaging.Text = $"Hiển thị {filtered.Count} / {_all.Count} ca trực";
        }

        private string MapRole(string r) => r switch
        {
            "Doctor" => "Bác sĩ",
            "Nurse" => "Y tá",
            "Pharmacist" => "Dược sĩ",
            "Technician" => "Kỹ thuật viên",
            "Receptionist" => "Lễ tân",
            _ => r ?? ""
        };

        private string MapStatus(string s) => s switch
        {
            "Approved" => "Đang trực",
            "Pending" => "Chờ duyệt",
            "Cancelled" => "Đã hủy",
            _ => s ?? ""
        };

        // ── Events ───────────────────────────────────────────────────
        private void btnAddShift_Click(object sender, EventArgs e)
        {
            using var frm = new Forms.Admin.frmRegisterShift(_empBus, _wsBus, _shiftBus);
            if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) => ApplyFilter();

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void dgvShifts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvShifts.Columns[e.ColumnIndex].Name;
            int shiftId = dgvShifts.Rows[e.RowIndex].Tag != null
                          ? (int)dgvShifts.Rows[e.RowIndex].Tag : 0;

            if (col == "colEdit")
            {
                using var frm = new Forms.Admin.frmEditShift(shiftId, _empBus, _wsBus, _shiftBus);
                if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            else if (col == "colDelete")
            {
                string name = dgvShifts.Rows[e.RowIndex].Cells["colEmpName"].Value?.ToString();
                if (MessageBox.Show($"Xóa ca trực của '{name}'?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _shiftBus.DeleteShift(shiftId);
                    LoadData();
                }
            }
        }

        private void dgvShifts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvShifts.Columns[e.ColumnIndex].Name;

            if (col == "colShiftStatus" && e.Value != null)
            {
                (Color fg, Color bg) = e.Value.ToString() switch
                {
                    "Đang trực" => (Color.FromArgb(22, 163, 74), Color.FromArgb(240, 253, 244)),
                    "Chờ duyệt" => (Color.FromArgb(234, 88, 12), Color.FromArgb(255, 237, 213)),
                    "Đã hủy" => (Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242)),
                    _ => (Color.FromArgb(107, 114, 128), Color.FromArgb(243, 244, 246))
                };
                e.CellStyle.ForeColor = fg; e.CellStyle.BackColor = bg;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = fg; e.CellStyle.SelectionBackColor = bg;
            }

            if (col == "colRole" && e.Value != null)
            {
                (Color fg, Color bg) = e.Value.ToString() switch
                {
                    "Bác sĩ" => (Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254)),
                    "Y tá" => (Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229)),
                    "Dược sĩ" => (Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254)),
                    "Kỹ thuật viên" => (Color.FromArgb(234, 88, 12), Color.FromArgb(254, 215, 170)),
                    _ => (Color.FromArgb(219, 39, 119), Color.FromArgb(252, 231, 243))
                };
                e.CellStyle.ForeColor = fg; e.CellStyle.BackColor = bg;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = fg; e.CellStyle.SelectionBackColor = bg;
            }

            if (col == "colShift" && e.Value != null)
            {
                (Color fg, Color bg) = e.Value.ToString().ToLower() switch
                {
                    var s when s.Contains("sáng") => (Color.FromArgb(5, 150, 105), Color.FromArgb(209, 250, 229)),
                    var s when s.Contains("chiều") => (Color.FromArgb(234, 88, 12), Color.FromArgb(255, 237, 213)),
                    var s when s.Contains("tối") => (Color.FromArgb(124, 58, 237), Color.FromArgb(237, 233, 254)),
                    _ => (Color.FromArgb(37, 99, 235), Color.FromArgb(219, 234, 254))
                };
                e.CellStyle.ForeColor = fg; e.CellStyle.BackColor = bg;
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = fg; e.CellStyle.SelectionBackColor = bg;
            }
        }

        private void dgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = e.ColumnIndex >= 0 ? dgvShifts.Columns[e.ColumnIndex].Name : "";
            if (col != "colEdit" && col != "colDelete") return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
            bool isEdit = col == "colEdit";
            Color bg = isEdit ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
            Color fg = isEdit ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            int sz = 28, x = e.CellBounds.X + (e.CellBounds.Width - sz) / 2,
                         y = e.CellBounds.Y + (e.CellBounds.Height - sz) / 2;
            using var bgBrush = new SolidBrush(bg);
            using var path = RoundedRect(new Rectangle(x, y, sz, sz), 6);
            e.Graphics.FillPath(bgBrush, path);
            string icon = isEdit ? "✎" : "🗑";
            using var fnt = new Font("Segoe UI", isEdit ? 12F : 10F);
            using var brush = new SolidBrush(fg);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(icon, fnt, brush, new RectangleF(x, y, sz, sz), sf);
            e.Handled = true;
        }

        private GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void panelKPI_Resize(object sender, EventArgs e)
        {
            if (cardOnDuty == null) return;
            int gap = 16, w = (panelKPI.Width - gap * 3) / 4;
            if (w <= 0) return;
            var cards = new[] { cardOnDuty, cardMorning, cardAfternoon, cardNight };
            for (int i = 0; i < cards.Length; i++)
            { cards[i].Size = new Size(w, 100); cards[i].Location = new Point(i * (w + gap), 0); }
        }
    }
}