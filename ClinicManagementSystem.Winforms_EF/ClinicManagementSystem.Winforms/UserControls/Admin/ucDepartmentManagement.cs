using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BUS.Services;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucDepartmentManagement : UserControl
    {
        private readonly DepartmentBUS _bus = new DepartmentBUS();
        private List<DepartmentDTO> _all = new List<DepartmentDTO>();

        public ucDepartmentManagement()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        public void LoadData()
        {
            try
            {
                _all = _bus.GetAll();
                UpdateKpiCards();
                ApplyFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateKpiCards()
        {
            int total = _all.Count, active = 0;
            foreach (var d in _all) if (d.IsActive) active++;
            SetKpi(cardTotal, total.ToString());
            SetKpi(cardActive, active.ToString());
            SetKpi(cardInactive, (total - active).ToString());
        }

        private void SetKpi(Panel card, string value)
        {
            if (card == null) return;
            foreach (Control c in card.Controls)
                if (c is Label lbl && lbl.Tag?.ToString() == "value")
                    lbl.Text = value;
        }

        private void ApplyFilter()
        {
            string kw = txtSearch.Text.Trim();
            var filtered = string.IsNullOrWhiteSpace(kw) ? _all : _bus.Search(kw);

            dgvDepartments.DataSource = null;
            dgvDepartments.Rows.Clear();

            foreach (var d in filtered)
            {
                int row = dgvDepartments.Rows.Add();
                dgvDepartments.Rows[row].Cells["colID"].Value = d.DepartmentID;
                dgvDepartments.Rows[row].Cells["colName"].Value = d.DepartmentName;
                dgvDepartments.Rows[row].Cells["colDesc"].Value = d.Description;
                dgvDepartments.Rows[row].Cells["colStatus"].Value = d.IsActive ? "Hoạt động" : "Ngừng hoạt động";
                dgvDepartments.Rows[row].Tag = d.DepartmentID;
            }
            lblPaging.Text = $"Hiển thị {filtered.Count} / {_all.Count} chuyên khoa";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var frm = new Forms.Admin.frmAddDepartment();
            if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvDepartments.Columns[e.ColumnIndex].Name;
            int id = (int)dgvDepartments.Rows[e.RowIndex].Tag;

            if (col == "colEdit")
            {
                using var frm = new Forms.Admin.frmEditDepartment(id);
                if (frm.ShowDialog(this) == DialogResult.OK) LoadData();
            }
            else if (col == "colDelete")
            {
                string name = dgvDepartments.Rows[e.RowIndex].Cells["colName"].Value?.ToString();
                if (MessageBox.Show($"Xóa (vô hiệu hóa) chuyên khoa '{name}'?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try { _bus.Delete(id); LoadData(); }
                    catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi"); }
                }
            }
        }

        private void dgvDepartments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDepartments.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
            {
                bool active = e.Value.ToString() == "Hoạt động";
                e.CellStyle.ForeColor = active ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
                e.CellStyle.BackColor = active ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
            }
        }

        private void dgvDepartments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = e.ColumnIndex >= 0 ? dgvDepartments.Columns[e.ColumnIndex].Name : "";
            if (col != "colEdit" && col != "colDelete") return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.Background | DataGridViewPaintParts.Border);
            Color bg = col == "colEdit" ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
            Color fg = col == "colEdit" ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            int sz = 30, x = e.CellBounds.X + (e.CellBounds.Width - sz) / 2, y = e.CellBounds.Y + (e.CellBounds.Height - sz) / 2;
            using var bgBrush = new SolidBrush(bg);
            e.Graphics.FillEllipse(bgBrush, x, y, sz, sz);
            string icon = col == "colEdit" ? "✎" : "✕";
            using var fnt = new Font("Segoe UI", 12F); using var brush = new SolidBrush(fg);
            var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            e.Graphics.DrawString(icon, fnt, brush, new RectangleF(x, y, sz, sz), sf);
            e.Handled = true;
        }

        private void panelKPI_Resize(object sender, EventArgs e)
        {
            if (cardTotal == null) return;
            int gap = 16, w = (panelKPI.Width - gap * 2) / 3;
            if (w <= 0) return;
            var cards = new[] { cardTotal, cardActive, cardInactive };
            for (int i = 0; i < cards.Length; i++)
            { cards[i].Size = new Size(w, 90); cards[i].Location = new Point(i * (w + gap), 10); }
        }
    }
}