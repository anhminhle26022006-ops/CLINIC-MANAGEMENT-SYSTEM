using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BUS;
using DTO;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucInventoryManagement : PharmacyDashboardViewBase
    {
        private readonly InventoryBUS inventoryBUS = new InventoryBUS();
        private List<MedicineDTO> allMedicines = new List<MedicineDTO>();

        public ucInventoryManagement()
        {
            InitializeComponent();
        }

        private void ucInventoryManagement_Load(object sender, EventArgs e)
        {
            txtSearch.Enter += TxtSearch_Enter;
            txtSearch.Leave += TxtSearch_Leave;
            txtSearch.TextChanged += (s, ev) => FilterInventory();
            cboCategory.SelectedIndexChanged += (s, ev) => FilterInventory();
            cboStatus.SelectedIndexChanged += (s, ev) => FilterInventory();
            dgvInventory.CellClick -= dgvInventory_CellClick;
            dgvInventory.CellClick += dgvInventory_CellClick;

            LoadInventory();
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text.Contains("Tìm thuốc"))
            {
                txtSearch.Text = "";
                SetInventorySearchActiveState();
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "  Tìm thuốc, batch...";
                SetInventorySearchPlaceholderState();
            }
        }

        private void LoadInventory()
        {
            try
            {
                allMedicines = inventoryBUS.GetAllMedicines();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading inventory: " + ex.Message);
                allMedicines = new List<MedicineDTO>();
            }

            // Calculate stats
            decimal totalValueVal = allMedicines.Sum(m => m.Price * m.Stock);
            string totalValueStr = totalValueVal >= 1000000 
                ? (totalValueVal / 1000000m).ToString("N1") + "M"
                : totalValueVal.ToString("N0");

            int typesCount = allMedicines.Count;
            int lowStockCount = allMedicines.Count(m => m.Stock <= 100);
            int expiredCount = allMedicines.Count(m => m.ExpiryDate != DateTime.MinValue && m.ExpiryDate <= DateTime.Today.AddMonths(6));

            lblValueNumber.Text = totalValueStr;
            lblTypesNumber.Text = typesCount.ToString();
            lblLowNumber.Text = lowStockCount.ToString();
            lblExpiredNumber.Text = expiredCount.ToString();

            FilterInventory();
        }

        private void FilterInventory()
        {
            string term = txtSearch.Text.Contains("Tìm thuốc") ? "" : txtSearch.Text.Trim().ToLower();
            string category = cboCategory.SelectedItem?.ToString() ?? "Tất cả danh mục";
            string status = cboStatus.SelectedItem?.ToString() ?? "Tất cả trạng thái";

            var filtered = allMedicines.Where(m =>
            {
                bool matchesSearch = string.IsNullOrEmpty(term) || 
                                     m.Name.ToLower().Contains(term) || 
                                     m.BatchNumber.ToLower().Contains(term);

                string cat = GetCategory(m.Name);
                bool matchesCategory = category == "Tất cả danh mục" || cat == category;

                string stat = m.Stock == 0 ? "Hết hàng" : (m.Stock <= 100 ? "Sắp hết" : "Còn hàng");
                bool matchesStatus = status == "Tất cả trạng thái" || stat == status;

                return matchesSearch && matchesCategory && matchesStatus;
            }).ToList();

            dgvInventory.Rows.Clear();
            foreach (var m in filtered)
            {
                string cat = GetCategory(m.Name);
                int rowIndex = dgvInventory.Rows.Add(
                    m.Name,
                    cat,
                    string.IsNullOrEmpty(m.BatchNumber) ? "BATCH" + m.MedicineID.ToString("D3") : m.BatchNumber,
                    m.Stock + " " + m.Unit,
                    m.ExpiryDate == DateTime.MinValue ? "N/A" : m.ExpiryDate.ToString("dd/MM/yyyy"),
                    "Kệ " + GetLocation(cat),
                    "Xem | Nhập | Xuất | Sửa | Xóa"
                );
                dgvInventory.Rows[rowIndex].Tag = m;
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dgvInventory.Rows[e.RowIndex].Tag is not MedicineDTO medicine)
            {
                return;
            }

            if (IsActionColumn(e.ColumnIndex))
            {
                ShowInventoryActionMenu(medicine);
            }
        }

        private bool IsActionColumn(int columnIndex)
        {
            if (columnIndex < 0 || columnIndex >= dgvInventory.Columns.Count)
            {
                return false;
            }

            DataGridViewColumn column = dgvInventory.Columns[columnIndex];
            string columnName = column.Name ?? string.Empty;
            string headerText = column.HeaderText ?? string.Empty;

            return string.Equals(columnName, "colActions", StringComparison.OrdinalIgnoreCase)
                || string.Equals(columnName, "colAction", StringComparison.OrdinalIgnoreCase)
                || string.Equals(headerText, "THAO TÁC", StringComparison.OrdinalIgnoreCase)
                || columnIndex == dgvInventory.Columns.Count - 1;
        }

        private void ShowInventoryActionMenu(MedicineDTO medicine)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Xem thuốc", null, (s, e) => OpenMedicineForm(medicine, true));
            menu.Items.Add("Nhập kho", null, (s, e) => AdjustStock(medicine, true));
            menu.Items.Add("Xuất kho", null, (s, e) => AdjustStock(medicine, false));
            menu.Items.Add("Sửa thuốc", null, (s, e) => OpenMedicineForm(medicine, false));
            menu.Items.Add("Xóa thuốc", null, (s, e) => DeleteMedicine(medicine));
            menu.Show(Cursor.Position);
        }

        private void AdjustStock(MedicineDTO medicine, bool increase)
        {
            int quantity = PromptQuantity(increase ? "Nhập kho" : "Xuất kho", medicine);
            if (quantity <= 0)
            {
                return;
            }

            try
            {
                int delta = increase ? quantity : -quantity;
                if (inventoryBUS.AdjustStock(medicine.MedicineID, delta))
                {
                    LoadInventory();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, increase ? "Nhập kho" : "Xuất kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static int PromptQuantity(string title, MedicineDTO medicine)
        {
            using Form form = new Form
            {
                Text = title,
                StartPosition = FormStartPosition.CenterParent,
                Width = 360,
                Height = 190,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label label = new Label
            {
                Text = $"{medicine.Name}\nSố lượng ({medicine.Unit}):",
                AutoSize = false,
                Location = new System.Drawing.Point(18, 16),
                Size = new System.Drawing.Size(310, 48)
            };
            NumericUpDown number = new NumericUpDown
            {
                Minimum = 1,
                Maximum = 100000,
                Value = 1,
                Location = new System.Drawing.Point(18, 72),
                Width = 310
            };
            Button ok = new Button { Text = "Lưu", DialogResult = DialogResult.OK, Location = new System.Drawing.Point(124, 112), Width = 92 };
            Button cancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new System.Drawing.Point(236, 112), Width = 92 };

            form.Controls.Add(label);
            form.Controls.Add(number);
            form.Controls.Add(ok);
            form.Controls.Add(cancel);
            form.AcceptButton = ok;
            form.CancelButton = cancel;

            return form.ShowDialog() == DialogResult.OK ? (int)number.Value : 0;
        }

        private void OpenMedicineForm(MedicineDTO medicine, bool viewOnly)
        {
            using AddMedicineForm form = new AddMedicineForm(medicine, viewOnly);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadInventory();
            }
        }

        private void DeleteMedicine(MedicineDTO medicine)
        {
            if (MessageBox.Show($"Xóa thuốc {medicine.Name}?", "Xóa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (inventoryBUS.DeleteMedicine(medicine.MedicineID))
                {
                    LoadInventory();
                }
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

        private string GetLocation(string category)
        {
            switch (category)
            {
                case "Kháng sinh": return "A1";
                case "Giảm đau": return "B2";
                case "Vitamin": return "C1";
                case "Kháng viêm": return "B3";
                default: return "D1";
            }
        }

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            using (var form = new AddMedicineForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadInventory();
                }
            }
        }
    }
}
