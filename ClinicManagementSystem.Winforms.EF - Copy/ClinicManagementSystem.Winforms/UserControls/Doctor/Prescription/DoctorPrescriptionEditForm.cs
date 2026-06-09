using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public class DoctorPrescriptionEditForm : Form
    {
        private readonly ComboBox cboEncounter = new();
        private readonly ComboBox cboMedicine = new();
        private readonly NumericUpDown numQuantity = new();
        private readonly TextBox txtDosage = new();
        private readonly TextBox txtFrequency = new();
        private readonly TextBox txtInstruction = new();
        private readonly TextBox txtStatus = new();
        private readonly PrescriptionDTO existing;

        public DoctorPrescriptionSaveDTO Result { get; private set; }

        public DoctorPrescriptionEditForm(
            IReadOnlyList<DoctorAppointmentDTO> appointments,
            IReadOnlyList<MedicineDTO> medicines,
            int doctorId,
            PrescriptionDTO existing = null)
        {
            this.existing = existing;

            Text = existing == null ? "Tao toa thuoc" : "Sua toa thuoc";
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(520, 430);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            TableLayoutPanel layout = new()
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(18),
                ColumnCount = 2,
                RowCount = 8
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            AddRow(layout, 0, "Benh nhan", cboEncounter);
            AddRow(layout, 1, "Thuoc", cboMedicine);
            AddRow(layout, 2, "So luong", numQuantity);
            AddRow(layout, 3, "Lieu dung", txtDosage);
            AddRow(layout, 4, "Tan suat", txtFrequency);
            AddRow(layout, 5, "Huong dan", txtInstruction);
            AddRow(layout, 6, "Trang thai", txtStatus);

            Button btnSave = new() { Text = "Luu", Dock = DockStyle.Right, Width = 110 };
            Button btnCancel = new() { Text = "Huy", Dock = DockStyle.Right, Width = 110 };
            FlowLayoutPanel buttons = new()
            {
                FlowDirection = FlowDirection.RightToLeft,
                Dock = DockStyle.Fill
            };
            buttons.Controls.Add(btnSave);
            buttons.Controls.Add(btnCancel);
            layout.Controls.Add(buttons, 1, 7);

            Controls.Add(layout);

            cboEncounter.DisplayMember = nameof(DoctorAppointmentDTO.PatientName);
            cboEncounter.ValueMember = nameof(DoctorAppointmentDTO.EncounterID);
            cboEncounter.DataSource = appointments?.Where(a => a.EncounterID > 0).ToList() ?? new List<DoctorAppointmentDTO>();

            cboMedicine.DisplayMember = nameof(MedicineDTO.Name);
            cboMedicine.ValueMember = nameof(MedicineDTO.MedicineID);
            cboMedicine.DataSource = medicines?.ToList() ?? new List<MedicineDTO>();

            numQuantity.Minimum = 1;
            numQuantity.Maximum = 999;
            numQuantity.Value = 10;
            txtDosage.Text = "1 vien/lần";
            txtFrequency.Text = "2 lan/ngay";
            txtInstruction.Text = "Uong sau an";
            txtStatus.Text = "Issued";

            if (existing != null)
            {
                BindExisting(existing);
            }

            btnSave.Click += (_, __) =>
            {
                Result = BuildResult(doctorId);
                DialogResult = DialogResult.OK;
                Close();
            };
            btnCancel.Click += (_, __) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
        }

        private void BindExisting(PrescriptionDTO prescription)
        {
            cboEncounter.Enabled = false;
            cboEncounter.DataSource = new List<DoctorAppointmentDTO>
            {
                new()
                {
                    EncounterID = prescription.EncounterID,
                    PatientName = prescription.PatientName
                }
            };

            PrescriptionItemDTO item = prescription.Items?.FirstOrDefault();
            if (item != null)
            {
                cboMedicine.SelectedValue = item.MedicineID;
                numQuantity.Value = Math.Max(1, Math.Min(numQuantity.Maximum, item.Quantity));
                txtDosage.Text = item.Dosage;
                txtFrequency.Text = item.Frequency;
                txtInstruction.Text = item.Instruction;
            }

            txtStatus.Text = string.IsNullOrWhiteSpace(prescription.Status) ? "Issued" : prescription.Status;
        }

        private DoctorPrescriptionSaveDTO BuildResult(int doctorId)
        {
            int encounterId = cboEncounter.SelectedValue is int id ? id : 0;
            int medicineId = cboMedicine.SelectedValue is int mid ? mid : 0;

            return new DoctorPrescriptionSaveDTO
            {
                PrescriptionID = existing?.PrescriptionID ?? 0,
                EncounterID = existing?.EncounterID ?? encounterId,
                DoctorID = existing?.DoctorID > 0 ? existing.DoctorID : doctorId,
                Note = txtStatus.Text.Trim(),
                Items = new List<DoctorPrescriptionItemSaveDTO>
                {
                    new()
                    {
                        MedicineID = medicineId,
                        Quantity = Convert.ToInt32(numQuantity.Value),
                        Dosage = txtDosage.Text.Trim(),
                        Frequency = txtFrequency.Text.Trim(),
                        Instruction = txtInstruction.Text.Trim()
                    }
                }
            };
        }

        private static void AddRow(TableLayoutPanel layout, int row, string label, Control editor)
        {
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
            Label lbl = new()
            {
                Text = label,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            editor.Dock = DockStyle.Fill;
            layout.Controls.Add(lbl, 0, row);
            layout.Controls.Add(editor, 1, row);
        }
    }
}
