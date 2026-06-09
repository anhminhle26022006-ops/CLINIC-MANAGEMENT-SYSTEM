using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class frmPrescriptionDetail : Form
    {
        public frmPrescriptionDetail()
        {
            InitializeComponent();

           
            btnClose.Click += BtnClose_Click;
        }


        // ================= FAKE DATA =================
        private void FrmPrescriptionDetail_Load(object sender, EventArgs e)
        {
            // nếu chưa được bind từ ngoài -> set data giả
            if (string.IsNullOrWhiteSpace(lblPatientName.Text) ||
                lblPatientName.Text == "Nguyễn Văn A")
            {
                LoadFakeData();
            }
        }

        private void LoadFakeData()
        {
            lblPatientName.Text = "Nguyễn Văn A";
            lblPrescriptionDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            rtbMedicines.Text =
@"Amoxicillin 500mg
Liều dùng: 2 viên/ngày
Số lượng: 20 viên

Paracetamol 500mg
Liều dùng: 3 viên/ngày khi sốt
Số lượng: 10 viên

Vitamin C 1000mg
Liều dùng: 1 viên/ngày
Số lượng: 10 viên";

            rtbNote.Text = "Uống sau ăn, tái khám sau 5 ngày";
        }

        // ================= CLOSE =================
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}