using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO;
using DAL;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucInventoryManagement : PharmacyDashboardViewBase
    {
        private readonly MedicineDAL medicineDAL = new MedicineDAL();
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
                allMedicines = medicineDAL.GetAllMedicines();
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
                dgvInventory.Rows.Add(
                    m.Name,
                    cat,
                    string.IsNullOrEmpty(m.BatchNumber) ? "BATCH" + m.MedicineID.ToString("D3") : m.BatchNumber,
                    m.Stock + " " + m.Unit,
                    m.ExpiryDate == DateTime.MinValue ? "N/A" : m.ExpiryDate.ToString("dd/MM/yyyy"),
                    "Kệ " + GetLocation(cat),
                    "+  -"
                );
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
