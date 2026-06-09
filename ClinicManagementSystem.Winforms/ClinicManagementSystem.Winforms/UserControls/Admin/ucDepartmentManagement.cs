using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using BUS.Services;
using DAL.Repositories;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucDepartmentManagement : UserControl
    {
        private readonly DepartmentBUS _bus = new DepartmentBUS();
        private readonly EmployeeBUS _empBUS = new EmployeeBUS(new EmployeeDAL());
        private readonly AppointmentBUS _apptBUS = new AppointmentBUS();

        private List<DepartmentDTO> _allDepts = new();

        // emoji map theo tên chuyên khoa
        private static readonly Dictionary<string, string> EmojiMap = new()
        {
            { "Nhi khoa",           "👶" },
            { "Sản phụ khoa",       "🤰" },
            { "Tai Mũi Họng",       "👂" },
            { "Răng Hàm Mặt",       "🦷" },
            { "Da liễu",            "✨" },
            { "Mắt",                "👁" },
            { "Xét nghiệm",         "🧪" },
            { "Chẩn đoán hình ảnh", "🩻" },
            { "Nhà thuốc",          "💊" },
            { "Hành chính",         "📋" },
            { "Tiếp nhận",          "🏥" },
            { "Khám tổng quát",     "🩺" },
        };

        public ucDepartmentManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                _allDepts = _bus.GetAll();
                UpdateKPI(_allDepts);
                BuildCards(_allDepts);
                lblPaging.Text = $"Tổng: {_allDepts.Count} chuyên khoa";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── KPI ──────────────────────────────────────────────────────────

        private void UpdateKPI(List<DepartmentDTO> list)
        {
            int totalDept = list.Count;
            int totalDoctors = _empBUS.GetByRole("Doctor").Count;
            int totalPatients = Convert.ToInt32(
                DAL.DataContext.DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM Patients"));
            int todayAppts = _apptBUS.CountAppointmentsToday();

            SetKpi(cardTotal, totalDept);
            SetKpi(cardDoctors, totalDoctors);
            SetKpi(cardPatients, totalPatients);
            SetKpi(cardToday, todayAppts);
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
            var cards = new[] { cardTotal, cardDoctors, cardPatients, cardToday };
            if (cards[0] == null) return;

            int gap = 16;
            int total = panelKPI.ClientSize.Width;
            int w = (total - gap * (cards.Length - 1)) / cards.Length;
            if (w <= 0) return;

            int x = 0;
            foreach (var c in cards)
            {
                c.Location = new Point(x, 8);
                c.Size = new Size(w, 90);
                x += w + gap;
            }
        }

        // ── Cards ─────────────────────────────────────────────────────────

        private void BuildCards(List<DepartmentDTO> list)
        {
            panelCards.Controls.Clear();

            // Lấy 1 lần, tránh gọi DB nhiều lần
            var allDoctors = _empBUS.GetByRole("Doctor");

            foreach (var dept in list)
            {
                int doctorCount = allDoctors
                    .FindAll(e => e.DepartmentID == dept.DepartmentID).Count;

                int todayAppts = Convert.ToInt32(
                    DAL.DataContext.DatabaseHelper.ExecuteScalar(
                        @"SELECT COUNT(*) FROM Appointments 
                  WHERE DepartmentID = @DeptID
                  AND CAST(AppointmentDate AS DATE) = CAST(GETDATE() AS DATE)",
                        new Microsoft.Data.SqlClient.SqlParameter[]
                        {
                    new("@DeptID", dept.DepartmentID)
                        }));

                string emoji = EmojiMap.TryGetValue(dept.DepartmentName, out string e2)
                    ? e2 : "🏥";

                var card = MakeDeptCard(dept, emoji, doctorCount, todayAppts, 320, 180);
                panelCards.Controls.Add(card);
            }
        }

        private Panel MakeDeptCard(DepartmentDTO dept, string emoji,
            int doctorCount, int todayAppts, int w, int h)
        {
            var card = new Panel
            {
                Size = new Size(w, h),
                BackColor = Color.White,
                Margin = new Padding(0, 0, 16, 16),
                Cursor = Cursors.Hand,
                Tag = dept
            };
            card.Paint += CardPaint;

            // Emoji
            card.Controls.Add(new Label
            {
                Text = emoji,
                Font = new Font("Segoe UI", 22F),
                Location = new Point(16, 16),
                Size = new Size(48, 48),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });

            // Tên chuyên khoa
            card.Controls.Add(new Label
            {
                Text = dept.DepartmentName,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(72, 18),
                Size = new Size(w - 110, 28),
                AutoEllipsis = true
            });

            // Bác sĩ
            var panelStats = new Panel
            {
                Location = new Point(16, 72),
                Size = new Size(w - 32, 52),
                BackColor = Color.Transparent
            };

            var pDoc = MakeStatBox("👨‍⚕️ Bác sĩ", doctorCount.ToString(),
                Color.FromArgb(37, 99, 235), Color.FromArgb(239, 246, 255));
            pDoc.Location = new Point(0, 0);
            pDoc.Size = new Size((w - 48) / 2, 48);

            var pAppt = MakeStatBox("📅 Hôm nay", todayAppts.ToString(),
                Color.FromArgb(5, 150, 105), Color.FromArgb(236, 253, 245));
            pAppt.Location = new Point((w - 48) / 2 + 16, 0);
            pAppt.Size = new Size((w - 48) / 2, 48);

            panelStats.Controls.Add(pDoc);
            panelStats.Controls.Add(pAppt);
            card.Controls.Add(panelStats);

            // Nút Sửa + Xóa
            var btnEdit = new Button
            {
                Text = "✏",
                Size = new Size(32, 28),
                Location = new Point(w - 76, 16),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(239, 246, 255),
                ForeColor = Color.FromArgb(37, 99, 235),
                Cursor = Cursors.Hand,
                Tag = dept
            };
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += BtnEdit_Click;

            var btnDel = new Button
            {
                Text = "🗑",
                Size = new Size(32, 28),
                Location = new Point(w - 40, 16),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(254, 226, 226),
                ForeColor = Color.FromArgb(220, 38, 38),
                Cursor = Cursors.Hand,
                Tag = dept
            };
            btnDel.FlatAppearance.BorderSize = 0;
            btnDel.Click += BtnDelete_Click;

            card.Controls.Add(btnEdit);
            card.Controls.Add(btnDel);

            return card;
        }

        private static Panel MakeStatBox(string label, string value, Color fg, Color bg)
        {
            var p = new Panel { BackColor = bg };
            p.Controls.Add(new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 8F),
                ForeColor = fg,
                AutoSize = true,
                Location = new Point(8, 6)
            });
            p.Controls.Add(new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = fg,
                AutoSize = true,
                Location = new Point(8, 22)
            });
            return p;
        }

        private static void CardPaint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        // ── Search ────────────────────────────────────────────────────────

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            var filtered = _allDepts.FindAll(d =>
                string.IsNullOrEmpty(kw) ||
                d.DepartmentName.ToLower().Contains(kw));
            BuildCards(filtered);
            lblPaging.Text = $"Hiển thị: {filtered.Count} / {_allDepts.Count} chuyên khoa";
        }

        // ── CRUD ──────────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Nhập tên chuyên khoa mới:", "Thêm chuyên khoa", "");
            if (string.IsNullOrWhiteSpace(name)) return;

            if (_bus.Insert(name.Trim()))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not DepartmentDTO dept) return;

            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Tên chuyên khoa mới:", "Sửa chuyên khoa", dept.DepartmentName);
            if (string.IsNullOrWhiteSpace(newName) || newName.Trim() == dept.DepartmentName) return;

            if (_bus.Update(dept.DepartmentID, newName.Trim()))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not DepartmentDTO dept) return;

            if (MessageBox.Show($"Xóa chuyên khoa '{dept.DepartmentName}'?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) != DialogResult.Yes) return;

            if (_bus.Delete(dept.DepartmentID))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Chuyên khoa đang được sử dụng.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Unused stubs (giữ để tránh lỗi Designer) ─────────────────────
        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvDepartments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgvDepartments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }
    }
}