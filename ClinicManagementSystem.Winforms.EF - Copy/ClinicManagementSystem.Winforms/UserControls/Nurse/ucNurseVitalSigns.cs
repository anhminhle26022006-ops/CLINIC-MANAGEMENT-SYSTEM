using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using BUS;
using DTO;
using ClinicalPatientBUS = BUS.Services.PatientBUS;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    public partial class ucNurseVitalSigns : UserControl
    {
        private readonly VitalSignsBUS vitalSignsBUS = new VitalSignsBUS();
        private readonly ClinicalPatientBUS patientBUS = new ClinicalPatientBUS();
        private List<PatientDTO> patients = new List<PatientDTO>();

        public ucNurseVitalSigns()
        {
            InitializeComponent();
            Load += ucNurseVitalSigns_Load;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            textBox7.TextChanged += (s, e) => UpdateBmi();
            textBox8.TextChanged += (s, e) => UpdateBmi();
            btnSaveAndSync.Click += btnSaveAndSync_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void ucNurseVitalSigns_Load(object sender, EventArgs e)
        {
            LoadPatients();
        }

        private void LoadPatients()
        {
            patients = patientBUS.GetList();
            comboBox1.DisplayMember = nameof(PatientDTO.Name);
            comboBox1.ValueMember = nameof(PatientDTO.PatientID);
            comboBox1.DataSource = patients;

            if (patients.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not PatientDTO patient)
            {
                return;
            }

            SetSingleItem(lstName, patient.Name);
            SetSingleItem(lstAge, patient.Age > 0 ? patient.Age.ToString() : "N/A");
            SetSingleItem(lstSex, patient.Gender);
            SetSingleItem(lstSTT, patient.PatientCode);
        }

        private static void SetSingleItem(ListBox listBox, string value)
        {
            listBox.Items.Clear();
            listBox.Items.Add(string.IsNullOrWhiteSpace(value) ? "N/A" : value);
        }

        private void btnSaveAndSync_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem is not PatientDTO patient)
                {
                    MessageBox.Show("Vui lòng chọn bệnh nhân.", "Nurse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int? encounterId = vitalSignsBUS.GetLatestEncounterIdByPatient(patient.PatientID);
                if (!encounterId.HasValue)
                {
                    MessageBox.Show("Bệnh nhân chưa có lượt khám/encounter để ghi sinh hiệu.", "Nurse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                VitalSignsDTO dto = new VitalSignsDTO
                {
                    EncounterID = encounterId.Value,
                    Temperature = ParseDouble(textBox1.Text, "nhiệt độ"),
                    BloodPressure = $"{textBox5.Text.Trim()}/{textBox6.Text.Trim()}",
                    HeartRate = ParseInt(textBox2.Text, "nhịp tim"),
                    SPO2 = ParseInt(textBox4.Text, "SpO2"),
                    Weight = ParseDouble(textBox8.Text, "cân nặng"),
                    Notes = textBox9.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                if (string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ huyết áp tâm thu/tâm trương.", "Nurse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool saved = vitalSignsBUS.SaveVitalSigns(dto);
                MessageBox.Show(saved ? "Đã lưu chỉ số sinh hiệu." : "Không lưu được chỉ số sinh hiệu.", "Nurse", MessageBoxButtons.OK, saved ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (saved)
                {
                    ClearVitalInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Nurse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static double ParseDouble(string value, string fieldName)
        {
            if (double.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out double result) ||
                double.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out result))
            {
                return result;
            }

            throw new ArgumentException($"Giá trị {fieldName} không hợp lệ.");
        }

        private static int ParseInt(string value, string fieldName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            throw new ArgumentException($"Giá trị {fieldName} không hợp lệ.");
        }

        private void UpdateBmi()
        {
            if (!double.TryParse(textBox7.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double heightCm) &&
                !double.TryParse(textBox7.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out heightCm))
            {
                lblBMI.Text = "BMI";
                return;
            }

            if (!double.TryParse(textBox8.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out double weightKg) &&
                !double.TryParse(textBox8.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out weightKg))
            {
                lblBMI.Text = "BMI";
                return;
            }

            if (heightCm <= 0 || weightKg <= 0)
            {
                lblBMI.Text = "BMI";
                return;
            }

            double heightM = heightCm / 100d;
            lblBMI.Text = $"BMI: {weightKg / (heightM * heightM):N1}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearVitalInputs();
        }

        private void ClearVitalInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            lblBMI.Text = "BMI";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox9_SizeChanged(object sender, EventArgs e)
        {
        }

        private void label21_Click(object sender, EventArgs e)
        {
        }

        private void label32_Click(object sender, EventArgs e)
        {
        }
    }
}
