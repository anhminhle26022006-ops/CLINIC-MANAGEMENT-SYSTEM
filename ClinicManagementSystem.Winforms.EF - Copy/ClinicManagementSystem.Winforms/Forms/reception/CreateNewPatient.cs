using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class CreateNewPatient : Form
    {
        private readonly PatientManaController controller = new();
        private readonly PatientDTO editingPatient;
        private readonly bool viewOnly;
        public CreateNewPatient()
        {
            InitializeComponent();
            SetupDatePickers();
            LoadBloodTypes();
            LoadGender();
        }

        public CreateNewPatient(PatientDTO patient, bool viewOnly = false) : this()
        {
            editingPatient = patient;
            this.viewOnly = viewOnly;
            BindPatient();
            ApplyMode();
        }

        private void SetupDatePickers()
        {
            dtpBirthday.Format = DateTimePickerFormat.Custom;
            dtpBirthday.CustomFormat = "dd/MM/yyyy";

            dtpEffective.Format = DateTimePickerFormat.Custom;
            dtpEffective.CustomFormat = "dd/MM/yyyy";

            dtpExpired.Format = DateTimePickerFormat.Custom;
            dtpExpired.CustomFormat = "dd/MM/yyyy";
        }

        private void LoadBloodTypes()
        {
            cbBlood.Items.Clear();

            cbBlood.Items.AddRange(new string[]
            {
        "A+",
        "A-",
        "B+",
        "B-",
        "AB+",
        "AB-",
        "O+",
        "O-"
            });

            cbBlood.SelectedIndex = 0;
        }

        private void LoadGender()
        {
            cbGender.Items.Clear();

            cbGender.Items.Add("Nam");
            cbGender.Items.Add("Nữ");
            cbGender.Items.Add("Khác");

            cbGender.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PatientDTO patient = new PatientDTO
                {
                    PatientID = editingPatient?.PatientID ?? 0,
                    PatientCode = editingPatient?.PatientCode ?? controller.GenerateNewPatientCode(),
                    Name = txtname.Text.Trim(),
                    BirthDate = dtpBirthday.Value.Date,
                    Gender = cbGender.Text,
                    Phone = txtsdt.Text.Trim(),
                    Address = txtaddress.Text.Trim(),
                    BloodType = cbBlood.Text,
                    Allergy = txtDiung.Text.Trim()
                };

                PatientInsuranceDTO insurance =
                    new PatientInsuranceDTO
                    {
                        InsuranceNumber =
                            txtBHYT.Text.Trim(),

                        Provider =
                            txtDonvi.Text.Trim(),

                        EffectiveDate =
                            dtpEffective.Value.Date,

                        ExpiryDate =
                            dtpExpired.Value.Date
                    };

                bool success = editingPatient == null
                    ? controller.CreatePatient(patient, insurance)
                    : controller.UpdatePatient(patient);

                if (success)
                {
                    MessageBox.Show(
                        editingPatient == null ? "Thêm bệnh nhân thành công!" : "Cập nhật bệnh nhân thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Không thể thêm bệnh nhân!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindPatient()
        {
            if (editingPatient == null)
            {
                return;
            }

            Text = viewOnly ? "Xem bệnh nhân" : "Sửa bệnh nhân";
            txtname.Text = editingPatient.Name;
            txtsdt.Text = editingPatient.Phone;
            txtaddress.Text = editingPatient.Address;
            txtDiung.Text = editingPatient.Allergy;
            if (editingPatient.BirthDate.HasValue && editingPatient.BirthDate.Value > DateTimePicker.MinimumDateTime)
            {
                dtpBirthday.Value = editingPatient.BirthDate.Value.Date;
            }

            if (!string.IsNullOrWhiteSpace(editingPatient.Gender) && cbGender.Items.Contains(editingPatient.Gender))
            {
                cbGender.SelectedItem = editingPatient.Gender;
            }

            if (!string.IsNullOrWhiteSpace(editingPatient.BloodType) && cbBlood.Items.Contains(editingPatient.BloodType))
            {
                cbBlood.SelectedItem = editingPatient.BloodType;
            }
        }

        private void ApplyMode()
        {
            if (editingPatient == null)
            {
                return;
            }

            txtBHYT.Enabled = false;
            txtDonvi.Enabled = false;
            dtpEffective.Enabled = false;
            dtpExpired.Enabled = false;

            if (!viewOnly)
            {
                return;
            }

            txtname.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtaddress.ReadOnly = true;
            txtDiung.ReadOnly = true;
            cbGender.Enabled = false;
            cbBlood.Enabled = false;
            dtpBirthday.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Text = "Đóng";
        }
    }
}
