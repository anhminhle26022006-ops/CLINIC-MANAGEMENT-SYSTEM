using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucUserManagement : UserControl
    {
        private DataTable _allUsers = new DataTable();
        private string _connectionString;

        public ucUserManagement()
        {
            _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CMS;Trusted_Connection=True;TrustServerCertificate=True;";
            InitializeComponent();
            this.Load += (s, e) => LoadData();
        }

        public void LoadData()
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                string sql = @"
                    SELECT u.UserID, u.Username,
                           ISNULL(e.FullName, u.Username) AS DisplayName,
                           r.RoleName, ISNULL(u.Email,'') AS Email,
                           u.IsActive, u.CreatedAt
                    FROM Users u
                    LEFT JOIN Roles r ON u.RoleID = r.RoleID
                    LEFT JOIN Employees e ON u.UserID = e.UserID
                    ORDER BY u.CreatedAt DESC";
                var da = new SqlDataAdapter(sql, conn);
                _allUsers = new DataTable();
                da.Fill(_allUsers);
                if (!_allUsers.Columns.Contains("StatusText"))
                    _allUsers.Columns.Add("StatusText", typeof(string));
                if (!_allUsers.Columns.Contains("CreatedAtText"))
                    _allUsers.Columns.Add("CreatedAtText", typeof(string));
                foreach (DataRow row in _allUsers.Rows)
                {
                    row["StatusText"] = Convert.ToBoolean(row["IsActive"]) ? "Hoạt động" : "Tạm khóa";
                    row["CreatedAtText"] = Convert.ToDateTime(row["CreatedAt"]).ToString("d/M/yyyy");
                }
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
            if (cardTotal == null || cardActive == null || cardLocked == null || cardNew == null) return;
            int total = _allUsers.Rows.Count, active = 0, locked = 0, newMonth = 0;
            var now = DateTime.Now;
            foreach (DataRow row in _allUsers.Rows)
            {
                if (Convert.ToBoolean(row["IsActive"])) active++; else locked++;
                var dt = Convert.ToDateTime(row["CreatedAt"]);
                if (dt.Year == now.Year && dt.Month == now.Month) newMonth++;
            }
            SetKpiValue(cardTotal, total.ToString());
            SetKpiValue(cardActive, active.ToString());
            SetKpiValue(cardLocked, locked.ToString());
            SetKpiValue(cardNew, newMonth.ToString());
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
            string role = cboRole.SelectedIndex <= 0 ? "" : cboRole.SelectedItem.ToString();
            var filtered = _allUsers.Clone();
            foreach (DataRow row in _allUsers.Rows)
            {
                bool matchSearch = string.IsNullOrEmpty(search)
                    || row["Username"].ToString().ToLower().Contains(search)
                    || row["DisplayName"].ToString().ToLower().Contains(search)
                    || row["Email"].ToString().ToLower().Contains(search);
                bool matchRole = string.IsNullOrEmpty(role) || row["RoleName"].ToString() == role;
                if (matchSearch && matchRole) filtered.ImportRow(row);
            }
            dgvUsers.DataSource = filtered;
            lblPaging.Text = $"Hiển thị {filtered.Rows.Count} / {_allUsers.Rows.Count} tài khoản";
        }

        private void ToggleUserStatus(int userId, bool newStatus)
        {
            try
            {
                using var conn = new SqlConnection(_connectionString);
                conn.Open();
                using var cmd = new SqlCommand("UPDATE Users SET IsActive=@s WHERE UserID=@id", conn);
                cmd.Parameters.AddWithValue("@s", newStatus ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── EVENTS ────────────────────────────────────────────────
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new Forms.Admin.frmAddUser();
            frm.ShowDialog(this);
            LoadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnAddUser != null)
                btnAddUser.Location = new Point(panelHeader.Width - btnAddUser.Width, 15);
        }

        private void panelKPI_Resize(object sender, EventArgs e)
        {
            if (cardTotal == null || cardActive == null || cardLocked == null || cardNew == null) return;
            int gap = 16, w = (panelKPI.Width - gap * 3) / 4;
            if (w <= 0) return;
            var cards = new[] { cardTotal, cardActive, cardLocked, cardNew };
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].Size = new Size(w, 90);
                cards[i].Location = new Point(i * (w + gap), 10);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dgvUsers.Columns[e.ColumnIndex].Name;
            var drv = dgvUsers.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (drv == null) return;
            int userId = Convert.ToInt32(drv["UserID"]);

            if (col == "colView")
            {
                var frm = new Forms.Admin.frmViewUser(drv);
                frm.ShowDialog(this);
            }
            else if (col == "colEdit")
            {
                var frm = new Forms.Admin.frmEditUser(userId, drv["Email"].ToString(), drv["RoleName"].ToString());
                frm.ShowDialog(this);
                LoadData();
            }
            else if (col == "colDelete")
            {
                bool isActive = drv["StatusText"].ToString() == "Hoạt động";
                string action = isActive ? "khóa" : "mở khóa";
                if (MessageBox.Show($"Bạn có chắc muốn {action} tài khoản '{drv["Username"]}'?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ToggleUserStatus(userId, !isActive);
            }
        }

        private void dgvUsers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvUsers.Columns[e.ColumnIndex].Name == "colStatus" && e.Value != null)
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

        private void dgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = e.ColumnIndex >= 0 ? dgvUsers.Columns[e.ColumnIndex].Name : "";
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