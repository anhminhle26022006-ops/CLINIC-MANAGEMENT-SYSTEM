using BUS.Services.Doctor;
using DAL.Repositories.Doctor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class ucPrescriptionSidebar : UserControl
    {
        private readonly PrescriptionService _service;
        public ucPrescriptionSidebar()
        {
            InitializeComponent();
            string connectionString =
        System.Configuration.ConfigurationManager
        .ConnectionStrings["DbConnection"]
        .ConnectionString;

            var repo =
                new PrescriptionRepository(connectionString);

            _service =
                new PrescriptionService(repo);

            Load += UcPrescriptionSidebar_Load;
           
        }

        private void UcPrescriptionSidebar_Load(
    object sender,
    EventArgs e)
        {
            LoadData();
            LoadStatistics();
        }
        private void LoadData()
        {
            dgvPrescriptions.Rows.Clear();

            var list = _service.GetAll();

            foreach (var item in list)
            {
                dgvPrescriptions.Rows.Add(
                    item.CreatedAt.ToString("dd/MM/yyyy"),
                    item.PatientName,
                    item.MedicineCount,
                    item.Note,
                    "👁"
                );

                dgvPrescriptions.Rows[
                    dgvPrescriptions.Rows.Count - 1
                ].Tag = item.PrescriptionId;
            }
        }
        private void LoadStatistics()
        {
            var stat = _service.GetStatistics();

            flpStats.Controls.Clear();

            flpStats.Controls.Add(
                CreateStatPanel(
                    "Tổng toa thuốc",
                    stat.Total.ToString()));

            flpStats.Controls.Add(
                CreateStatPanel(
                    "Hôm nay",
                    stat.Today.ToString()));

            flpStats.Controls.Add(
                CreateStatPanel(
                    "Tuần này",
                    stat.ThisWeek.ToString()));

            flpStats.Controls.Add(
                CreateStatPanel(
                    "Đang theo",
                    stat.Processing.ToString()));
        }
        
        private Panel CreateStatPanel(string title, string value)
        {
            Panel panel = new Panel
            {
                Width = 180,
                Height = 70,
                Margin = new Padding(8),
                BackColor = Color.FromArgb(240, 248, 255)
            };

            Label lblTitle = new Label
            {
                AutoSize = true,
                Text = title,
                Location = new Point(15, 12),
                Font = new Font("Segoe UI", 9F)
            };

            Label lblValue = new Label
            {
                AutoSize = true,
                Text = value,
                Location = new Point(15, 32),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);

            return panel;
        }

       

        // ================= CLICK VIEW =================
        private void dgvPrescriptions_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPrescriptions.Columns[e.ColumnIndex].Name != "btnView")
                return;

            int prescriptionId =
                Convert.ToInt32(
                    dgvPrescriptions.Rows[e.RowIndex].Tag);

            var detail =
                _service.GetDetail(prescriptionId);

            frmPrescriptionDetail frm =
                new frmPrescriptionDetail();

            frm.lblPatientName.Text =
                detail.PatientName;

            frm.lblPrescriptionDate.Text =
                detail.CreatedAt.ToString("dd/MM/yyyy");

            frm.rtbMedicines.Clear();

            foreach (var med in detail.Medicines)
            {
                frm.rtbMedicines.AppendText(
        $@"{med.MedicineName}

Liều dùng: {med.Dosage}

Tần suất: {med.Frequency}

Số lượng: {med.Quantity}

Hướng dẫn: {med.Instruction}

----------------------------

");
            }

            frm.rtbNote.Text =
                detail.Status;

            frm.ShowDialog();
        }
    }
}