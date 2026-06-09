using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using ClinicManagementSystem.Winforms.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class PaymentDetail : UserControl
    {
        private readonly int encounterId;

        private readonly PaymentController
            controller = new();
        private decimal totalAmount;
        private string patientName;

        public PaymentDetail(
    int encounterId)
        {
            InitializeComponent();

            this.encounterId =
                encounterId;

            SetupUI();

            LoadInvoice();
        }

        private void SetupUI()
        {
            BackColor =
                Color.White;

            dataGridView1.BorderStyle =
                BorderStyle.None;

            dataGridView1.BackgroundColor =
                Color.White;

            dataGridView1.RowHeadersVisible =
                false;

            dataGridView1.AllowUserToAddRows =
                false;

            dataGridView1.AllowUserToDeleteRows =
                false;

            dataGridView1.ReadOnly =
                true;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersHeight =
                40;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .BackColor =
                Color.RoyalBlue;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .ForeColor =
                Color.White;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            dataGridView1.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10);

            dataGridView1.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    230,
                    240,
                    255);

            dataGridView1.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            lblTotal.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold);

            lblTotal.ForeColor =
                Color.Gold;

            lblPaymentMethod.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            button1.FlatStyle =
                FlatStyle.Flat;

            button1.BackColor =
                Color.WhiteSmoke;

            button1.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            btnQR.FlatStyle =
                FlatStyle.Flat;

            btnQR.BackColor =
                Color.WhiteSmoke;

            btnQR.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            button2.FlatStyle =
                FlatStyle.Flat;

            button2.BackColor =
                Color.FromArgb(
                    34,
                    197,
                    94);

            button2.ForeColor =
                Color.White;

            button2.Font =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);
        }

        private void LoadInvoice()
        {
            List<PaymentDetailDTO> details =
                controller.GetInvoiceDetails(encounterId);

            dataGridView1.DataSource = details;

            totalAmount = details.Sum(x => x.Amount);
            controller.UpdateAmount(encounterId, totalAmount);

            lblTotal.Text =
                totalAmount.ToString("N0") + " đ";

            lblInvoiceID.Text =
                encounterId.ToString();

            patientName =
        details.FirstOrDefault()?.PatientName ?? "";


            lblPaymentMethod.Text =
                "Phương thức thanh toán:";
        }

        private string paymentMethod =
    "";

        private void button1_Click(object sender, EventArgs e)
        {
            paymentMethod =
        "Tiền mặt";

            lblPaymentMethod.Text =
                "Phương thức thanh toán: Tiền mặt";

            MessageBox.Show(
                "Đã chọn thanh toán tiền mặt");
        }

        private void btnQR_Click(
    object sender,
    EventArgs e)
        {
            if (totalAmount <= 0)
            {
                MessageBox.Show("Chưa có chi phí thanh toán cho bệnh nhân này.", "PayOS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            paymentMethod = "Chuyển khoản";

            lblPaymentMethod.Text =
                "Phương thức thanh toán: Chuyển khoản";

            using PayOsPaymentForm frm =
                new PayOsPaymentForm(
                    encounterId,
                    patientName,
                    totalAmount);

            if (frm.ShowDialog() == DialogResult.OK && frm.IsPaymentPaid)
            {
                CompletePayment("Chuyển khoản", "Thanh toán PayOS thành công");
            }
        }

        private void button2_Click(
    object sender,
    EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(
                paymentMethod))
            {
                MessageBox.Show(
                    "Vui lòng chọn phương thức thanh toán");

                return;
            }

            CompletePayment(paymentMethod, "Thanh toán thành công");
        }

        private void CompletePayment(string method, string successMessage)
        {
            bool result =
                controller.UpdatePaymentStatus(
                    encounterId,
                    method);

            if (result)
            {
                MessageBox.Show(
                    successMessage);

                this.Dispose();
            }
            else
            {
                MessageBox.Show(
                    "Thanh toán thất bại");
            }
        }
    }
}
