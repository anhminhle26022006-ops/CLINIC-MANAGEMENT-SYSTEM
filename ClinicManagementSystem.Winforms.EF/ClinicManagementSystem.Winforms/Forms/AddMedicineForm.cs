using System;
using System.Windows.Forms;
using DTO;
using DAL;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class AddMedicineForm : Form
    {
        private readonly MedicineDAL medicineDAL = new MedicineDAL();

        public AddMedicineForm()
        {
            InitializeComponent();
        }

        private void AddMedicineForm_Load(object sender, EventArgs e)
        {
            // Set date format
            dtpExpiryDate.Format = DateTimePickerFormat.Custom;
            dtpExpiryDate.CustomFormat = "dd/MM/yyyy";
            dtpExpiryDate.Value = DateTime.Today.AddYears(1);

            // Seed unit options
            cboUnit.Items.Clear();
            cboUnit.Items.AddRange(new string[] { "Viên", "Chai", "Hộp", "Ống", "Vỉ", "Tuýp", "Gói" });
            cboUnit.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtMedicineName.Text.Trim();
            string unit = cboUnit.SelectedItem?.ToString() ?? "";
            decimal price = numPrice.Value;
            int stock = (int)numStock.Value;
            string batch = txtBatchNumber.Text.Trim();
            DateTime expiry = dtpExpiryDate.Value.Date;

            // Simple validation
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMedicineName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(unit))
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUnit.Focus();
                return;
            }

            if (price <= 0)
            {
                MessageBox.Show("Đơn giá thuốc phải lớn hơn 0 VNĐ.", "Giá trị không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return;
            }

            if (stock < 0)
            {
                MessageBox.Show("Số lượng nhập không được nhỏ hơn 0.", "Giá trị không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numStock.Focus();
                return;
            }

            if (string.IsNullOrEmpty(batch))
            {
                MessageBox.Show("Vui lòng nhập số lô (Batch Number).", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBatchNumber.Focus();
                return;
            }

            try
            {
                var newMedicine = new MedicineDTO
                {
                    Name = name,
                    Unit = unit,
                    Price = price,
                    Stock = stock,
                    BatchNumber = batch,
                    ExpiryDate = expiry
                };

                bool isSuccess = medicineDAL.InsertMedicine(newMedicine);

                if (isSuccess)
                {
                    MessageBox.Show("Thêm thuốc mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thêm thuốc mới thất bại. Vui lòng kiểm tra lại.", "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
