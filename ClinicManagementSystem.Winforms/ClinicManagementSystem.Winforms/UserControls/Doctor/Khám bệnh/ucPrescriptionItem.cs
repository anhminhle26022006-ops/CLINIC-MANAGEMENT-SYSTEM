using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucPrescriptionItem : UserControl
    {
        public event EventHandler DeleteRequested;

        public ucPrescriptionItem()
        {
            InitializeComponent();

            btnDelete.Click += (_, __) => DeleteRequested?.Invoke(this, EventArgs.Empty);
            cboFrequency.Items.Clear();
            cboFrequency.Items.AddRange(new object[]
            {
                "1 lan/ngay",
                "2 lan/ngay",
                "3 lan/ngay",
                "Khi can",
                "Theo chi dinh"
            });
            if (cboFrequency.Items.Count > 0)
            {
                cboFrequency.SelectedIndex = 0;
            }
        }

        public void BindMedicines(List<MedicineDTO> medicines)
        {
            cboMedicine.DataSource = null;
            cboMedicine.DisplayMember = nameof(MedicineDTO.Name);
            cboMedicine.ValueMember = nameof(MedicineDTO.MedicineID);
            cboMedicine.DataSource = medicines ?? new List<MedicineDTO>();
        }

        public DoctorPrescriptionItemSaveDTO BuildItem()
        {
            int medicineId = 0;
            if (cboMedicine.SelectedValue is int id)
            {
                medicineId = id;
            }
            else if (cboMedicine.SelectedItem is MedicineDTO medicine)
            {
                medicineId = medicine.MedicineID;
            }

            return new DoctorPrescriptionItemSaveDTO
            {
                MedicineID = medicineId,
                Quantity = Convert.ToInt32(numQuantity.Value),
                Dosage = txtDosage.Text.Trim(),
                Frequency = cboFrequency.Text.Trim(),
                Instruction = txtInstruction.Text.Trim()
            };
        }
    }
}
