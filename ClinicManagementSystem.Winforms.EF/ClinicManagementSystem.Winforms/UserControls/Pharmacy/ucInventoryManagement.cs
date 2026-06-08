using System;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucInventoryManagement : PharmacyDashboardViewBase
    {
        public ucInventoryManagement()
        {
            InitializeComponent();
        }

        private void ucInventoryManagement_Load(object sender, EventArgs e)
        {
            dgvInventory.Rows.Clear();
            dgvInventory.Rows.Add("Paracetamol 500mg", "Giảm đau - Hạ sốt", "BATCH2024001", "450 viên", "31/12/2027", "Kệ A1", "+  -");
            dgvInventory.Rows.Add("Augmentin 1g", "Kháng sinh", "BATCH2024002", "120 viên", "15/8/2026", "Kệ B2", "+  -");
            dgvInventory.Rows.Add("Vitamin C", "Vitamin", "BATCH2024003", "850 viên", "30/6/2027", "Kệ C1", "+  -");
            dgvInventory.Rows.Add("Medrol 16mg", "Kháng viêm", "BATCH2024004", "45 viên", "20/11/2026", "Kệ B3", "+  -");
            dgvInventory.Rows.Add("Omeprazole 20mg", "Tiêu hóa", "BATCH2024005", "25 viên", "25/5/2026", "Kệ D1", "+  -");
            dgvInventory.Rows.Add("Cefixime 200mg", "Kháng sinh", "BATCH2024006", "180 viên", "10/3/2027", "Kệ B1", "+  -");
        }
    }
}
