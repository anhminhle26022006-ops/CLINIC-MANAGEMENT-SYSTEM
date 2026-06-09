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
    public partial class ucVisitCard : UserControl
    {
        public ucVisitCard()
        {
            InitializeComponent();
        }
        public void Bind(EncounterHistoryDto item)
        {
            if (item == null) return;

            lblVisitDate.Text = item.VisitDate.ToString("dd/MM/yyyy");
            lblDoctor.Text = item.DoctorName;
            lblDepartment.Text = item.DepartmentName;
            lblSymptoms.Text = item.Symptoms;
            lblDiagnosis.Text = item.Diagnosis;
            lblConclusion.Text = item.Conclusion;

            if (item.VitalSigns != null)
            {
                lblBP.Text = item.VitalSigns.BloodPressure;
                lblTemp.Text = item.VitalSigns.Temperature.ToString("0.0") + " °C";
                lblHeart.Text = item.VitalSigns.HeartRate + " bpm";
                lblHeight.Text = item.VitalSigns.Height.ToString("0") + " cm";
                lblWeight.Text = item.VitalSigns.Weight.ToString("0.0") + " kg";
            }
        }
    }
}
