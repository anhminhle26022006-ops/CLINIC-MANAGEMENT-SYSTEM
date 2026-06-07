using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucMedicineCatalog : PharmacyDashboardViewBase
    {
        public ucMedicineCatalog()
        {
            InitializeComponent();
        }

        private void ucMedicineCatalog_Load(object sender, EventArgs e)
        {
            dgvMedicines.Rows.Clear();
            dgvMedicines.Rows.Add("MED001", "Amoxicillin 500mg", "Kháng sinh", "150 viên", "2,000đ", "Còn hàng", "Xem | Sửa");
            dgvMedicines.Rows.Add("MED002", "Paracetamol 500mg", "Giảm đau", "45 viên", "1,000đ", "Sắp hết", "Xem | Sửa");
            dgvMedicines.Rows.Add("MED003", "Ibuprofen 400mg", "Kháng viêm", "0 viên", "3,000đ", "Hết hàng", "Xem | Sửa");
            dgvMedicines.Rows.Add("MED004", "Omeprazole 20mg", "Dạ dày", "200 viên", "5,000đ", "Còn hàng", "Xem | Sửa");
            dgvMedicines.Rows.Add("MED005", "Vitamin C", "Vitamin", "80 viên", "1,500đ", "Còn hàng", "Xem | Sửa");
        }
    }
}
