using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPharmacyMedicineItemCard : UserControl
    {
        public ucPharmacyMedicineItemCard()
        {
            InitializeComponent();
        }

        public void Configure(PrescriptionItemDTO item, int displayIndex)
        {
            lblIndex.Text = displayIndex.ToString("00");
            lblMedicineName.Text = item.MedicineName;
            lblQuantity.Text = item.Quantity + " " + item.MedicineUnit;
            lblDosage.Text = string.IsNullOrWhiteSpace(item.Dosage) ? "Chưa có hướng dẫn dùng thuốc." : item.Dosage;
            lblBatch.Text = string.IsNullOrWhiteSpace(item.BatchNumber) ? "Lô: Chưa cập nhật" : "Lô: " + item.BatchNumber;
            lblPrice.Text = item.Price > 0 ? item.Price.ToString("N0") + " đ" : "Chưa có giá";
        }

        public void Clear()
        {
            lblIndex.Text = string.Empty;
            lblMedicineName.Text = string.Empty;
            lblQuantity.Text = string.Empty;
            lblDosage.Text = string.Empty;
            lblBatch.Text = string.Empty;
            lblPrice.Text = string.Empty;
        }
    }
}
