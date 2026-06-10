using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucPrescriptionTab : UserControl
    {
        private int encounterId;
        private int doctorId;
        private List<MedicineDTO> medicines = new();

        // Constructor mặc định (cho designer)
        public ucPrescriptionTab()
        {
            InitializeComponent();
            btnAddMedicine.Click += BtnAddMedicine_Click;
        }

        // Constructor có context và user (để đồng bộ, không dùng trực tiếp)
        public ucPrescriptionTab(CMSDbContext context, UserDTO currentUser) : this()
        {
            // Không cần xử lý thêm vì tab này không dùng database trực tiếp
        }

        public void SetContext(int encounterId, int doctorId, List<MedicineDTO> medicines)
        {
            this.encounterId = encounterId;
            this.doctorId = doctorId;
            this.medicines = medicines ?? new List<MedicineDTO>();

            foreach (Control control in flpMedicines.Controls)
            {
                if (control is ucPrescriptionItem item)
                {
                    item.BindMedicines(this.medicines);
                }
            }
        }

        public DoctorPrescriptionSaveDTO BuildPrescription()
        {
            DoctorPrescriptionSaveDTO prescription = new()
            {
                EncounterID = encounterId,
                DoctorID = doctorId
            };

            foreach (Control control in flpMedicines.Controls)
            {
                if (control is not ucPrescriptionItem item) continue;
                DoctorPrescriptionItemSaveDTO dto = item.BuildItem();
                if (dto.MedicineID > 0 && dto.Quantity > 0)
                    prescription.Items.Add(dto);
            }
            return prescription;
        }

        public void ClearPrescription()
        {
            flpMedicines.Controls.Clear();
        }

        private void BtnAddMedicine_Click(object sender, EventArgs e)
        {
            ucPrescriptionItem item = new();
            item.Width = Math.Max(300, flpMedicines.ClientSize.Width - 25);
            item.BindMedicines(medicines);
            item.DeleteRequested += (s, ev) =>
            {
                flpMedicines.Controls.Remove(item);
                item.Dispose();
            };
            flpMedicines.Controls.Add(item);
        }
    }
}