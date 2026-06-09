using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DTO;
using BUS;
using DAL;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    public partial class ucPharmacyOverview : PharmacyDashboardViewBase
    {
        private readonly PrescriptionBUS prescriptionBUS = new PrescriptionBUS();
        private readonly MedicineDAL medicineDAL = new MedicineDAL();

        public ucPharmacyOverview()
        {
            InitializeComponent();
        }

        private void ucPharmacyOverview_Load(object sender, EventArgs e)
        {
            btnViewWeek.Click += (s, ev) => NavigateTo(PharmacyViewTarget.Shifts);
            btnChangeShift.Click += (s, ev) => NavigateTo(PharmacyViewTarget.Shifts);

            BindNavigation(pnlActDispense, PharmacyViewTarget.Prescriptions);
            BindNavigation(pnlActInventory, PharmacyViewTarget.Inventory);
            BindNavigation(pnlActReports, PharmacyViewTarget.Medicines);
            BindNavigation(pnlActStocktake, PharmacyViewTarget.Inventory);

            LoadOverviewData();
        }

        private void BindNavigation(Control parent, PharmacyViewTarget target)
        {
            parent.Click += (s, ev) => NavigateTo(target);
            foreach (Control child in parent.Controls)
            {
                child.Click += (s, ev) => NavigateTo(target);
            }
        }

        private void LoadOverviewData()
        {
            try
            {
                // 1. Fetch data from DB
                var pendingPrescs = prescriptionBUS.GetPendingPrescriptions();
                var medicines = medicineDAL.GetAllMedicines();

                // 2. Set stats
                int pendingCount = pendingPrescs.Count;
                int medicineTypesCount = medicines.Count;
                int lowStockCount = medicines.Count(m => m.Stock <= 100);
                int dispensedCount = 5; // local tracking mockup

                lblPendingNumber.Text = pendingCount.ToString();
                lblMedicineNumber.Text = medicineTypesCount.ToString();
                lblLowStockNumber.Text = lowStockCount.ToString();
                lblDispensedNumber.Text = dispensedCount.ToString();

                // 3. Load top 2 pending prescriptions
                if (pendingPrescs.Count > 0)
                {
                    pnlPrescriptionOne.Visible = true;
                    var p1 = pendingPrescs[0];
                    lblPatientOne.Text = p1.PatientName;
                    lblDoctorOne.Text = "BS: " + p1.DoctorName;
                    lblDrugCountOne.Text = $"{p1.Items.Count} loại thuốc";
                    lblTimeOne.Text = p1.CreatedAt.ToString("HH:mm");
                    lblStatusOne.Text = p1.Status;
                }
                else
                {
                    pnlPrescriptionOne.Visible = false;
                }

                if (pendingPrescs.Count > 1)
                {
                    pnlPrescriptionTwo.Visible = true;
                    var p2 = pendingPrescs[1];
                    lblPatientTwo.Text = p2.PatientName;
                    lblDoctorTwo.Text = "BS: " + p2.DoctorName;
                    lblDrugCountTwo.Text = $"{p2.Items.Count} loại thuốc";
                    lblTimeTwo.Text = p2.CreatedAt.ToString("HH:mm");
                    lblStatusTwo.Text = p2.Status;
                }
                else
                {
                    pnlPrescriptionTwo.Visible = false;
                }

                // 4. Load top 2 lowest stock medicines for inventory alerts
                var sortedMeds = medicines.OrderBy(m => m.Stock).ToList();
                if (sortedMeds.Count > 0)
                {
                    pnlAlertOne.Visible = true;
                    var m1 = sortedMeds[0];
                    lblAlertMedOne.Text = m1.Name;
                    lblAlertStockOne.Text = $"Tồn kho:                                   {m1.Stock} {m1.Unit}";
                    lblAlertMinOne.Text = $"Tối thiểu:                                100 {m1.Unit}";
                    progressAlertOne.Value = Math.Min(100, Math.Max(0, (m1.Stock * 100) / 100));
                }
                else
                {
                    pnlAlertOne.Visible = false;
                }

                if (sortedMeds.Count > 1)
                {
                    pnlAlertTwo.Visible = true;
                    var m2 = sortedMeds[1];
                    lblAlertMedTwo.Text = m2.Name;
                    lblAlertStockTwo.Text = $"Tồn kho:                                   {m2.Stock} {m2.Unit}";
                    lblAlertMinTwo.Text = $"Tối thiểu:                                150 {m2.Unit}";
                    progressAlertTwo.Value = Math.Min(100, Math.Max(0, (m2.Stock * 100) / 150));
                }
                else
                {
                    pnlAlertTwo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading overview details: " + ex.Message);
            }
        }
    }
}
