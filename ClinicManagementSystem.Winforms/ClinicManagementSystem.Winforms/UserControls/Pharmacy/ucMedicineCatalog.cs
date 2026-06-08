using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO;
using DAL;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucMedicineCatalog : PharmacyDashboardViewBase
    {
        private readonly MedicineDAL medicineDAL = new MedicineDAL();
        private List<MedicineDTO> allMedicines = new List<MedicineDTO>();

        public ucMedicineCatalog()
        {
            InitializeComponent();
        }

        private void ucMedicineCatalog_Load(object sender, EventArgs e)
        {
            txtMedicineSearch.Enter += TxtMedicineSearch_Enter;
            txtMedicineSearch.Leave += TxtMedicineSearch_Leave;
            txtMedicineSearch.TextChanged += (s, ev) => FilterMedicines();
            cboCategory.SelectedIndexChanged += (s, ev) => FilterMedicines();
            cboStatus.SelectedIndexChanged += (s, ev) => FilterMedicines();

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
                allMedicines = medicineDAL.GetAllMedicines();
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
                                     m.BatchNumber.ToLower().Contains(term);

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
                dgvMedicines.Rows.Add(
                    "MED" + m.MedicineID.ToString("D3"),
                    m.Name,
                    cat,
                    m.Stock + " " + m.Unit,
                    m.Price.ToString("N0") + "đ",
                    stat,
                    "Xem | Sửa"
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
    }
}
