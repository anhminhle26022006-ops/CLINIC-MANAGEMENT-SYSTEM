using BUS.Services;
using ClinicManagementSystem.Winforms.Forms;
using DAL.Repositories;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucEmployeeManagement : UserControl
    {
        private readonly EmployeeBUS employeeBUS = new EmployeeBUS(new EmployeeDAL());
        private List<EmployeeDTO> _allEmployees = new();

        public ucEmployeeManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                _allEmployees = employeeBUS.GetAll();
                BindGrid(_allEmployees);
                UpdateKPI(_allEmployees);
                lblPaging.Text = $"Tổng: {_allEmployees.Count} nhân viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            panelKPI_Resize(this, EventArgs.Empty);
        }

        private void BindGrid(List<EmployeeDTO> list)
        {
            dgvEmployees.Rows.Clear();
            foreach (var emp in list)
            {
                dgvEmployees.Rows.Add(
                    emp.EmployeeCode,
                    emp.FullName,
                    emp.RoleName,
                    emp.DepartmentName,
                    emp.Phone,
                    emp.Status,
                    "👁 Xem",
                    "✏ Sửa",
                    "🗑 Xóa"
                );
            }
        }

        private void UpdateKPI(List<EmployeeDTO> list)
        {
            SetKpiValue(cardBacSi, list.FindAll(e => e.RoleName == "Doctor").Count);
            SetKpiValue(cardYTa, list.FindAll(e => e.RoleName == "Nurse").Count);
            SetKpiValue(cardDuocSi, list.FindAll(e => e.RoleName == "Pharmacist").Count);
            SetKpiValue(cardKyThuat, list.FindAll(e => e.RoleName == "Technician").Count);
            SetKpiValue(cardLeTan, list.FindAll(e => e.RoleName == "Receptionist").Count);
        }

        private static void SetKpiValue(Panel card, int count)
        {
            foreach (Control ctrl in card.Controls)
            {
                if (ctrl is Label lbl && lbl.Tag?.ToString() == "value")
                {
                    lbl.Text = count.ToString();
                    break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string role = cboChucVu.SelectedItem?.ToString() ?? "Tất cả chức vụ";

            var filtered = _allEmployees.FindAll(emp =>
                (string.IsNullOrEmpty(keyword) ||
                 emp.FullName.ToLower().Contains(keyword) ||
                 emp.EmployeeCode.ToLower().Contains(keyword)) &&
                (role == "Tất cả chức vụ" || emp.RoleName == role)
            );

            BindGrid(filtered);
            lblPaging.Text = $"Hiển thị: {filtered.Count} / {_allEmployees.Count} nhân viên";
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Gọi constructor không tham số để Thêm mới
            frmEmployeeEdit frm = new frmEmployeeEdit();

            // Nếu lưu thành công (form trả về OK) thì load lại dữ liệu
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void panelHeader_Resize(object sender, EventArgs e) { }
        private void panelKPI_Resize(object sender, EventArgs e)
        {
            var cards = new[] { cardBacSi, cardYTa, cardDuocSi, cardKyThuat, cardLeTan };
            if (cards.Any(c => c == null)) return;

            int gap = 12;
            int totalWidth = panelKPI.ClientSize.Width - panelKPI.Padding.Horizontal;
            int cardWidth = (totalWidth - gap * (cards.Length - 1)) / cards.Length;
            if (cardWidth <= 0) return;

            int x = 0;
            foreach (var card in cards)
            {
                card.Location = new Point(x, 0);
                card.Size = new Size(cardWidth, 90);
                x += cardWidth + gap;
            }
        }
        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvEmployees.Columns[e.ColumnIndex].Name;
            if (colName != "colView" && colName != "colEdit" && colName != "colDelete") return;

            // Lấy EmployeeCode từ grid thay vì index
            string empCode = dgvEmployees.Rows[e.RowIndex].Cells["colCode"].Value?.ToString();
            var emp = _allEmployees.Find(x => x.EmployeeCode == empCode);
            if (emp == null) return;

            switch (colName)
            {
                case "colView":
                    ShowEmployeeDetail(emp); // Dùng hàm bạn đã viết sẵn ở dưới
                    break;

                case "colEdit":
                    // Gọi constructor có tham số để Sửa
                    frmEmployeeEdit frmEdit = new frmEmployeeEdit(emp);
                    if (frmEdit.ShowDialog(this) == DialogResult.OK)
                    {
                        LoadData(); // Load lại dữ liệu trên Grid và KPI sau khi sửa
                    }
                    break;

                case "colDelete":
                    if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {emp.FullName}?", "Xác nhận xóa",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            // Truyền ID vào hàm Delete của BUS
                            employeeBUS.Delete(emp.EmployeeID);

                            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData(); // Load lại giao diện sau khi xóa
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }
        private void dgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }
        private void dgvEmployees_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void PanelRoundedBorder(object sender, PaintEventArgs e)
        {
            if (sender is not Control c) return;
            using var pen = new Pen(Color.FromArgb(229, 231, 235));
            e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }
        private void ShowEmployeeDetail(EmployeeDTO emp)
        {
            new frmEmployeeDetail(emp).ShowDialog(this);
        }

    }
}