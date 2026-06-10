using BUS;
using ClinicManagementSystem.Winforms.Forms;
using DAL.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucMedicineCatalog : PharmacyDashboardViewBase
    {
        private readonly InventoryBUS _inventoryBUS;
        private List<MedicineDTO> allMedicines = new List<MedicineDTO>();

        // Constructor mặc định (cho designer)
        public ucMedicineCatalog()
        {
            InitializeComponent();
        }

        // Constructor chính (dùng khi runtime)
        public ucMedicineCatalog(CMSDbContext context, UserDTO currentUser) : this()
        {
            _inventoryBUS = new InventoryBUS(context);
        }

        private void ucMedicineCatalog_Load(object sender, EventArgs e)
        {
            txtMedicineSearch.Enter += TxtMedicineSearch_Enter;
            txtMedicineSearch.Leave += TxtMedicineSearch_Leave;
            txtMedicineSearch.TextChanged += (s, ev) => FilterMedicines();
            cboCategory.SelectedIndexChanged += (s, ev) => FilterMedicines();
            cboStatus.SelectedIndexChanged += (s, ev) => FilterMedicines();
            btnAddMedicine.Click -= btnAddMedicine_Click;
            btnAddMedicine.Click += btnAddMedicine_Click;
            dgvMedicines.CellClick -= dgvMedicines_CellClick;
            dgvMedicines.CellClick += dgvMedicines_CellClick;

            LoadMedicines();
        }

        private void TxtMedicineSearch_Enter(object sender, EventArgs e)
        {
            if (txtMedicineSearch.Text.Contains("Tìm kiếm tên thuốc"))
            {
                txtMedicineSearch.Text = "";
                SetMedicineSearchActiveState();
            }
        }

        private void TxtMedicineSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMedicineSearch.Text))
            {
                txtMedicineSearch.Text = "  Tìm kiếm tên thuốc, mã thuốc...";
                SetMedicineSearchPlaceholderState();
            }
        }

        private void LoadMedicines()
        {
            try
            {
                allMedicines = _inventoryBUS.GetAllMedicines();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading medicines: " + ex.Message);
                allMedicines = new List<MedicineDTO>();
            }

            int total = allMedicines.Count;
            int available = allMedicines.Count(m => m.Stock > 100);
            int low = allMedicines.Count(m => m.Stock > 0 && m.Stock <= 100);
            int outOfStock = allMedicines.Count(m => m.Stock == 0);

            lblTotalValue.Text = total.ToString();
            lblAvailableValue.Text = available.ToString();
            lblLowValue.Text = low.ToString();
            lblOutValue.Text = outOfStock.ToString();

            FilterMedicines();
        }

        private void FilterMedicines()
        {
            string term = txtMedicineSearch.Text.Contains("Tìm kiếm") ? "" : txtMedicineSearch.Text.Trim().ToLower();
            string category = cboCategory.SelectedItem?.ToString() ?? "Tất cả loại thuốc";
            string status = cboStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            var filtered = allMedicines.Where(m =>
            {
                bool matchesSearch = string.IsNullOrEmpty(term) ||
                                     m.Name.ToLower().Contains(term) ||
                                     m.MedicineID.ToString().Contains(term) ||
                                     (m.BatchNumber?.ToLower().Contains(term) ?? false);

                string cat = GetCategory(m.Name);
                bool matchesCategory = category == "Tất cả loại thuốc" || cat == category;

                string stat = m.Stock == 0 ? "Hết hàng" : (m.Stock <= 100 ? "Sắp hết" : "Còn hàng");
                bool matchesStatus = status == "Tất cả trạng thái" || stat == status;

                return matchesSearch && matchesCategory && matchesStatus;
            }).ToList();

            dgvMedicines.Rows.Clear();
            foreach (var m in filtered)
            {
                string cat = GetCategory(m.Name);
                string stat = m.Stock == 0 ? "Hết hàng" : (m.Stock <= 100 ? "Sắp hết" : "Còn hàng");
                int rowIndex = dgvMedicines.Rows.Add(
                    "MED" + m.MedicineID.ToString("D3"),
                    m.Name,
                    cat,
                    m.Stock + " " + m.Unit,
                    m.Price.ToString("N0") + "đ",
                    stat,
                    "Xem | Sửa | Xóa"
                );
                dgvMedicines.Rows[rowIndex].Tag = m;
            }
        }

        private void dgvMedicines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvMedicines.Rows[e.RowIndex].Tag is not MedicineDTO medicine)
                return;

            if (IsActionColumn(e.ColumnIndex))
                ShowMedicineActionMenu(medicine);
        }

        private bool IsActionColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= dgvMedicines.Columns.Count)
                return false;

            DataGridViewColumn column = dgvMedicines.Columns[columnIndex];
            string columnName = column.Name ?? string.Empty;
            string headerText = column.HeaderText ?? string.Empty;

            return string.Equals(columnName, "colActions", StringComparison.OrdinalIgnoreCase)
                || string.Equals(columnName, "colAction", StringComparison.OrdinalIgnoreCase)
                || string.Equals(headerText, "THAO TÁC", StringComparison.OrdinalIgnoreCase)
                || columnIndex == dgvMedicines.Columns.Count - 1;
        }

        private void ShowMedicineActionMenu(MedicineDTO medicine)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Xem", null, (s, e) => OpenMedicineForm(medicine, true));
            menu.Items.Add("Sửa", null, (s, e) => OpenMedicineForm(medicine, false));
            menu.Items.Add("Xóa", null, (s, e) => DeleteMedicine(medicine));
            menu.Show(Cursor.Position);
        }

        private void OpenMedicineForm(MedicineDTO medicine, bool viewOnly)
        {
            using AddMedicineForm form = new AddMedicineForm(medicine, viewOnly);
            if (form.ShowDialog() == DialogResult.OK)
                LoadMedicines();
        }

        private void DeleteMedicine(MedicineDTO medicine)
        {
            DialogResult confirm = MessageBox.Show($"Xóa thuốc {medicine.Name}?",
                "Xóa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                if (_inventoryBUS.DeleteMedicine(medicine.MedicineID))
                    LoadMedicines();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa thuốc này vì đã có dữ liệu liên quan.\n" + ex.Message, "Xóa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetCategory(string name)
        {
            if (name.Contains("Paracetamol") || name.Contains("Ibuprofen")) return "Giảm đau";
            if (name.Contains("Amoxicillin") || name.Contains("Augmentin") || name.Contains("Cefixime")) return "Kháng sinh";
            if (name.Contains("Vitamin")) return "Vitamin";
            if (name.Contains("Medrol")) return "Kháng viêm";
            return "Dạ dày";
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            using (var form = new AddMedicineForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadMedicines();
            }
        }
    }
}