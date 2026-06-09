using System.Windows.Forms;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucExaminationTab : UserControl
    {
        private int encounterId;

        public ucExaminationTab()
        {
            InitializeComponent();
        }

        public void LoadRecord(DoctorMedicalRecordSaveDTO record, int encounterId)
        {
            this.encounterId = encounterId;

            txtSymptom.Text = record?.Symptoms ?? "";
            txtDiagnosis.Text = record?.Diagnosis ?? "";
            txtConclusion.Text = record?.Conclusion ?? "";
            txtNote.Text = record?.Notes ?? "";
        }

        public DoctorMedicalRecordSaveDTO BuildRecord()
        {
            return new DoctorMedicalRecordSaveDTO
            {
                EncounterID = encounterId,
                ChiefComplaint = txtSymptom.Text.Trim(),
                Symptoms = txtSymptom.Text.Trim(),
                Diagnosis = txtDiagnosis.Text.Trim(),
                Conclusion = txtConclusion.Text.Trim(),
                Notes = txtNote.Text.Trim()
            };
        }
    }
}
