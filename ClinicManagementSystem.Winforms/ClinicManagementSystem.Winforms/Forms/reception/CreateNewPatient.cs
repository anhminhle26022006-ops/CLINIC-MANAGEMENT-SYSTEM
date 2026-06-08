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
        public CreateNewPatient()
        {
            InitializeComponent();
            SetupDatePickers();
            LoadBloodTypes();
            LoadGender();
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
                    PatientCode = controller.GenerateNewPatientCode(),
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

                bool success =
                    controller.CreatePatient(
                        patient,
                        insurance);

                if (success)
                {
                    MessageBox.Show(
                        "Thêm bệnh nhân thành công!",
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
    }
}
