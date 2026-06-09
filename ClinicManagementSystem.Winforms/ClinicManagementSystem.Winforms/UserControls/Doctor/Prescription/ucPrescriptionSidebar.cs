using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class ucPrescriptionSidebar : UserControl
    {
        public ucPrescriptionSidebar()
        {
            InitializeComponent();
            BuildStats();

            Load += UcPrescriptionSidebar_Load;
            dgvPrescriptions.CellClick += dgvPrescriptions_CellClick;
        }
        private void BuildStats()
        {
            flpStats.Controls.Clear();

            // Tổng toa thuốc
            Panel pnlTotal = CreateStatPanel("Tổng toa thuốc", "135");
            Panel pnlToday = CreateStatPanel("Hôm nay", "3");
            Panel pnlWeek = CreateStatPanel("Tuần này", "21");
            Panel pnlTracking = CreateStatPanel("Đang theo", "11");

            flpStats.Controls.Add(pnlTotal);
            flpStats.Controls.Add(pnlToday);
            flpStats.Controls.Add(pnlWeek);
            flpStats.Controls.Add(pnlTracking);
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

        // ================= FAKE DATA MODEL =================
        public class PrescriptionDto
        {
            public DateTime Date { get; set; }
            public string PatientName { get; set; }
            public int MedicineCount { get; set; }
            public string Note { get; set; }

            public string Medicines { get; set; }
        }

        private List<PrescriptionDto> _data;

        // ================= LOAD FAKE DATA =================
        private void UcPrescriptionSidebar_Load(object sender, EventArgs e)
        {
            _data = new List<PrescriptionDto>
            {
                new PrescriptionDto
                {
                    Date = new DateTime(2026, 5, 17),
                    PatientName = "Nguyễn Văn A",
                    MedicineCount = 2,
                    Note = "Uống sau ăn, tái khám 5 ngày",
                    Medicines =
@"Amoxicillin 500mg
Liều dùng: 2 viên/ngày
Số lượng: 20 viên

Paracetamol 500mg
Liều dùng: 3 viên/ngày khi sốt
Số lượng: 10 viên"
                },
                new PrescriptionDto
                {
                    Date = new DateTime(2026, 5, 18),
                    PatientName = "Trần Thị B",
                    MedicineCount = 3,
                    Note = "Theo dõi huyết áp",
                    Medicines =
@"Amlodipine 5mg
Liều dùng: 1 viên/ngày
Số lượng: 30 viên"
                },
                new PrescriptionDto
                {
                    Date = DateTime.Now,
                    PatientName = "Lê Văn C",
                    MedicineCount = 1,
                    Note = "Kháng sinh nhẹ",
                    Medicines =
@"Cefixime 200mg
Liều dùng: 2 viên/ngày
Số lượng: 14 viên"
                }
            };

            BindGrid();
        }

        // ================= BIND GRID =================
        private void BindGrid()
        {
            dgvPrescriptions.Rows.Clear();

            foreach (var item in _data)
            {
                dgvPrescriptions.Rows.Add(
                    item.Date.ToString("dd/MM/yyyy"),
                    item.PatientName,
                    item.MedicineCount,
                    item.Note
                );
            }
        }

        // ================= CLICK VIEW =================
        private void dgvPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPrescriptions.Columns[e.ColumnIndex].Name == "btnView")
            {
                var item = _data[e.RowIndex];

                frmPrescriptionDetail frm = new frmPrescriptionDetail();

                frm.lblPatientName.Text = item.PatientName;
                frm.lblPrescriptionDate.Text = item.Date.ToString("dd/MM/yyyy");
                frm.rtbMedicines.Text = item.Medicines;
                frm.rtbNote.Text = item.Note;

                frm.ShowDialog();
            }
        }
    }
}