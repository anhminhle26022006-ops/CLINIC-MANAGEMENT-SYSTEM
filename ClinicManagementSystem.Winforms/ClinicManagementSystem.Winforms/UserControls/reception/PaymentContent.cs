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
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class PaymentContent : UserControl
    {
        private readonly PaymentController
    controller = new();
        private List<PaymentWaitingDTO>
    waitingPayments =
    new();
        private Panel? selectedCard;

        public PaymentContent()
        {
            InitializeComponent();

            LoadWaitingPayments();
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
        }
        private void LoadWaitingPayments()
        {
            flpPayment.Controls.Clear();

            waitingPayments =
    controller.GetWaitingPayments();

            foreach (PaymentWaitingDTO dto
                in waitingPayments)
            {
                Panel card = new Panel();

                card.Width =
                    flpPayment.ClientSize.Width
                    - 25;

                card.Height = 85;

                card.BackColor =
    Color.FromArgb(
        240,
        245,
        252);

                card.BorderStyle =
                    BorderStyle.FixedSingle;

                card.Margin =
                    new Padding(5);

                card.Cursor =
                    Cursors.Hand;

                Label lblName = new Label();

                lblName.Text = dto.PatientName;

                lblName.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                lblName.Location =
                    new Point(10, 10);

                lblName.AutoSize = true;

                Label lblCode = new Label();

                lblCode.Text =
                    dto.PatientCode;

                lblCode.Location =
                    new Point(10, 35);

                lblCode.AutoSize = true;

                Label lblDoctor =
                    new Label();

                lblDoctor.Text =
                    "BS. " + dto.DoctorName;

                lblDoctor.Location =
                    new Point(10, 60);

                lblDoctor.AutoSize = false;

                lblDoctor.Width =
                    card.Width - 90;

                lblDoctor.Height = 20;

                Label lblAmount = new Label();

                lblAmount.Text =
                    dto.TotalAmount.ToString("N0")
                    + " đ";

                lblAmount.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold);

                lblAmount.ForeColor =
                    Color.RoyalBlue;

                lblAmount.AutoSize = false;

                lblAmount.Size =
                    new Size(90, 25);

                lblAmount.TextAlign =
                    ContentAlignment.MiddleRight;

                lblAmount.Location =
                    new Point(
                        card.Width - 95,
                        8);

                Label lblStatus = new Label();

                lblStatus.Text =
                    dto.Status == "Pending"
                        ? "Chưa TT"
                        : "Đã TT";

                lblStatus.Size =
                    new Size(60, 25);

                lblStatus.Location =
                    new Point(
                        card.Width - 75,
                        45);

                lblStatus.TextAlign =
                    ContentAlignment.MiddleCenter;

                lblStatus.BackColor =
                    Color.FromArgb(
                        255,
                        237,
                        213);

                lblStatus.ForeColor =
                    Color.OrangeRed;

                lblStatus.Font =
                    new Font(
                        "Segoe UI",
                        8,
                        FontStyle.Bold);

                card.Controls.Add(lblName);
                card.Controls.Add(lblCode);
                card.Controls.Add(lblDoctor);
                card.Controls.Add(lblAmount);
                card.Controls.Add(lblStatus);

                card.Tag = dto.EncounterID;

                card.Click += WaitingCard_Click;

                foreach (Control c in card.Controls)
                {
                    c.Tag = dto.EncounterID;
                    c.Click += WaitingCard_Click;
                }

                flpPayment.Controls.Add(card);
            }
        }

        private void WaitingCard_Click(
    object sender,
    EventArgs e)
        {
            Panel card =
    sender as Panel
    ?? ((Control)sender).Parent as Panel;

            if (selectedCard != null)
            {
                selectedCard.BackColor =
                    Color.FromArgb(
                        240,
                        245,
                        252);
            }

            selectedCard = card;

            selectedCard.BackColor =
                Color.FromArgb(
                    220,
                    235,
                    255);
            Control control =
                (Control)sender;

            int encounterId =
                Convert.ToInt32(
                    control.Tag);

            PaymentWaitingDTO patient =
                waitingPayments
                .First(
                    x => x.EncounterID
                    == encounterId);

            label2.Text =
    $"BN: {patient.PatientName}";

            label3.Text =
                $"Mã BN: {patient.PatientCode}";

            label4.Text =
                $"BS: {patient.DoctorName}";

            label6.Text =
                $"Phiếu khám: {encounterId}";

            LoadPaymentDetail(
                encounterId);
        }

        private void LoadPaymentDetail(
    int encounterId)
        {
            panel2.Controls.Clear();

            PaymentDetail detail =
                new PaymentDetail(
                    encounterId);

            detail.Dock =
                DockStyle.Fill;

            panel2.Controls.Add(
                detail);
        }
    }
}
