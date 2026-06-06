using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucEmployeeManagement : UserControl
    {
        private readonly EmployeeBUS _bus = new EmployeeBUS();
        private List<EmployeeDTO> _allEmployees = new List<EmployeeDTO>();

        public ucEmployeeManagement()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        public void LoadData()
        {
            try
            {
                _allEmployees = _bus.GetAll();
                UpdateKpiCards();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateKpiCards()
        {
            if (cardBacSi == null) return;
            int bacSi = 0, yTa = 0, duocSi = 0, kyThuat = 0, leTan = 0;
            foreach (var e in _allEmployees)
            {
                switch (e.RoleName)
                {
                    case "Doctor": bacSi++; break;
                    case "Nurse": yTa++; break;
                    case "Pharmacist": duocSi++; break;
                    case "Technician": kyThuat++; break;
                    case "Receptionist": leTan++; break;
                }
            }
            SetKpiValue(cardBacSi, bacSi.ToString());
            SetKpiValue(cardYTa, yTa.ToString());
            SetKpiValue(cardDuocSi, duocSi.ToString());
            SetKpiValue(cardKyThuat, kyThuat.ToString());
            SetKpiValue(cardLeTan, leTan.ToString());
        }

        private void SetKpiValue(Panel card, string value)
        {
            if (card == null) return;
            foreach (Control c in card.Controls)
                if (c is Label lbl && lbl.Tag?.ToString() == "value")
                    lbl.Text = value;
        }

        private void ApplyFilter()
        {
            string search = txtSearch.Text.Trim().ToLower();
            string role = cboChucVu.SelectedIndex <= 0 ? "" : cboChucVu.SelectedItem.ToString();
            var filtered = _bus.Search(search, role);

            dgvEmployees.DataSource = null;
            dgvEmployees.Rows.Clear();

            foreach (var emp in filtered)
            {
                int row = dgvEmployees.Rows.Add();
                dgvEmployees.Rows[row].Cells["colCode"].Value = emp.EmployeeCode;
                dgvEmployees.Rows[row].Cells["colName"].Value = emp.FullName;
                dgvEmployees.Rows[row].Cells["colChucVu"].Value = MapChucVu(emp.RoleName);
                dgvEmployees.Rows[row].Cells["colKhoa"].Value = emp.DepartmentName;
                dgvEmployees.Rows[row].Cells["colContact"].Value = emp.Phone + "\n" + emp.Email;
                dgvEmployees.Rows[row].Cells["colStatus"].Value = emp.StatusText;
                dgvEmployees.Rows[row].Tag = emp.EmployeeID;
            }

            lblPaging.Text = $"Hiển thị {filtered.Count} / {_allEmployees.Count} nhân viên";
        }

        private string MapChucVu(string cv) =>
            cv == "Doctor" ? "Bác sĩ" : cv == "Nurse" ? "Y tá" :
            cv == "Pharmacist" ? "Dược sĩ" : cv == "Technician" ? "Kỹ thuật viên" :
            cv == "Receptionist" ? "Lễ tân" : cv;

        // ── EVENTS ────────────────────────────────────────────────
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Admin.frmAddEmployee();
            if (frm.ShowDialog(this) == DialogResult.OK)
                LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnAddEmployee != null)
                btnAddEmployee.Location = new Point(panelHeader.Width - btnAddEmployee.Width, 15);
        }

        private void panelKPI_Resize(object sender, EventArgs e)
        {
            if (cardBacSi == null) return;
            int gap = 12, w = (panelKPI.Width - gap * 4) / 5;
            if (w <= 0) return;
            var cards = new[] { cardBacSi, cardYTa, cardDuocSi, cardKyThuat, cardLeTan };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Size = new Size(w, 90);
                cards[i].Location = new Point(i * (w + gap), 10);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvEmployees.Columns[e.ColumnIndex].Name;
            int employeeId = (int)dgvEmployees.Rows[e.RowIndex].Tag;

            if (col == "colView")
            {
                var emp = _bus.GetById(employeeId);
                if (emp != null) new Forms.Admin.frmViewEmployee(emp).ShowDialog(this);
            }
            else if (col == "colEdit")
            {
                var frm = new Forms.Admin.frmEditEmployee(employeeId);
                if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            else if (col == "colDelete")
            {
                string name = dgvEmployees.Rows[e.RowIndex].Cells["colName"].Value?.ToString();
                if (MessageBox.Show($"Bạn có chắc muốn xóa nhân viên '{name}'?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _bus.Delete(employeeId);
                    LoadData();
                }
            }
        }

        private void dgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvEmployees.Columns[e.ColumnIndex].Name;

            if (col == "colChucVu" && e.Value != null)
            {
                string cv = e.Value.ToString();
                (Color fg, Color bg) = cv switch
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

            if (col == "colStatus" && e.Value != null)
            {
                bool active = e.Value.ToString() == "Đang làm việc";
                e.CellStyle.ForeColor = active ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
                e.CellStyle.BackColor = active ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            }
        }

        private void dgvEmployees_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = e.ColumnIndex >= 0 ? dgvEmployees.Columns[e.ColumnIndex].Name : "";
            if (col != "colView" && col != "colEdit" && col != "colDelete") return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
            Color bg = col == "colView" ? Color.FromArgb(239, 246, 255) :
                       col == "colEdit" ? Color.FromArgb(240, 253, 244) :
                                          Color.FromArgb(254, 242, 242);
            Color fg = col == "colView" ? Color.FromArgb(47, 94, 240) :
                       col == "colEdit" ? Color.FromArgb(22, 163, 74) :
                                          Color.FromArgb(220, 38, 38);
            int size = 30;
            int x = e.CellBounds.X + (e.CellBounds.Width - size) / 2;
            int y = e.CellBounds.Y + (e.CellBounds.Height - size) / 2;
            using var bgBrush = new SolidBrush(bg);
            e.Graphics.FillEllipse(bgBrush, x, y, size, size);
            string icon = col == "colView" ? "⊙" : col == "colEdit" ? "✎" : "✕";
            using var font = new Font("Segoe UI", 12F);
            using var brush = new SolidBrush(fg);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(icon, font, brush, new RectangleF(x, y, size, size), sf);
            e.Handled = true;
        }

        private void PanelRoundedBorder(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }
    }
}