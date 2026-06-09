using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucPrescriptionCard : UserControl
    {
        public ucPrescriptionCard()
        {
            InitializeComponent();
            dgvMedicines.Rows.Add(
        "Paracetamol 500mg",
        "1 viên",
        "3 lần/ngày",
        "10",
        "Sau ăn");

            dgvMedicines.Rows.Add(
                "Vitamin C",
                "1 viên",
                "2 lần/ngày",
                "20",
                "Sau ăn");
        }
        public void SetData(PrescriptionHistoryDto dto)
        {
            lblDate.Text = dto.CreatedAt.ToString("dd/MM/yyyy");
            lblDoctor.Text = dto.DoctorName;

            dgvMedicines.Rows.Clear();

            if (dto.Medicines == null) return;

            foreach (var m in dto.Medicines)
            {
                dgvMedicines.Rows.Add(
                    m.MedicineName,
                    m.Dosage,
                    m.Frequency,
                    m.Quantity,
                    m.Instruction
                );
            }
        }
        public void Bind(PrescriptionHistoryDto dto)
        {
            if (dto == null) return;

            // Header
            lblDate.Text = dto.CreatedAt.ToString("dd/MM/yyyy");
            lblDoctor.Text = dto.DoctorName;

            // Clear grid
            dgvMedicines.Rows.Clear();

            // Fill medicines
            if (dto.Medicines != null)
            {
                foreach (var m in dto.Medicines)
                {
                    dgvMedicines.Rows.Add(
                        m.MedicineName,
                        m.Dosage,
                        m.Frequency,
                        m.Quantity,
                        m.Instruction
                    );
                }
            }
        }
    }
}
