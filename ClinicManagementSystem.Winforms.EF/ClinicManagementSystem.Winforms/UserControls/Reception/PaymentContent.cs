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
            SetupModernUi();
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            Load += (s, e) => LoadWaitingPayments();
            flpPayment.Resize += (s, e) => ResizePaymentCards();
            textBox1.TextChanged += (s, e) => RenderPaymentCards(FilterPayments(textBox1.Text));
        }

        private void SetupModernUi()
        {
            panel1.BackColor = Color.FromArgb(247, 249, 252);
            panel1.Padding = new Padding(14);

            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.Padding = new Padding(14);
            tableLayoutPanel2.Margin = new Padding(0, 0, 14, 0);
            tableLayoutPanel2.RowStyles.Clear();
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(17, 24, 39);
            label1.Text = "Chờ thanh toán";

            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.PlaceholderText = "Tìm bệnh nhân, mã BN, bác sĩ...";
            textBox1.Margin = new Padding(0, 4, 0, 8);

            flpPayment.AutoScroll = true;
            flpPayment.WrapContents = false;
            flpPayment.FlowDirection = FlowDirection.TopDown;
            flpPayment.BackColor = Color.White;
            flpPayment.Padding = new Padding(0, 6, 8, 0);

            pnlDetails.BackColor = Color.White;
            pnlDetails.Padding = new Padding(16);
            tableLayoutPanel3.BackColor = Color.White;
            tableLayoutPanel3.RowStyles.Clear();
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            tableLayoutPanel4.BackColor = Color.FromArgb(248, 250, 252);
            tableLayoutPanel4.Padding = new Padding(12);
            foreach (Label label in new[] { label2, label3, label4, label5, label6 })
            {
                label.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                label.ForeColor = Color.FromArgb(55, 65, 81);
                label.AutoEllipsis = true;
            }

            panel2.BackColor = Color.White;
            ShowEmptyDetail();
        }

        private void LoadWaitingPayments()
        {
            waitingPayments =
    controller.GetWaitingPayments();
            RenderPaymentCards(FilterPayments(textBox1.Text));
        }

        private List<PaymentWaitingDTO> FilterPayments(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return waitingPayments;
            }

            return waitingPayments
                .Where(x =>
                    Contains(x.PatientName, keyword) ||
                    Contains(x.PatientCode, keyword) ||
                    Contains(x.DoctorName, keyword) ||
                    x.TotalAmount.ToString("N0").Contains(keyword))
                .ToList();
        }

        private void RenderPaymentCards(List<PaymentWaitingDTO> data)
        {
            flpPayment.SuspendLayout();
            flpPayment.Controls.Clear();
            selectedCard = null;

            if (data.Count == 0)
            {
                ShowEmptyDetail();
                flpPayment.Controls.Add(new Label
                {
                    Text = "Chưa có hồ sơ chờ thanh toán.",
                    AutoSize = false,
                    Width = Math.Max(340, flpPayment.ClientSize.Width - 28),
                    Height = 80,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    BackColor = Color.FromArgb(248, 250, 252),
                    Margin = new Padding(0, 6, 0, 10)
                });
                flpPayment.ResumeLayout();
                return;
            }

            Panel firstCard = null;

            foreach (PaymentWaitingDTO dto in data)
            {
                Panel card = CreatePaymentCard(dto);

                card.Click += WaitingCard_Click;

                foreach (Control c in card.Controls)
                {
                    c.Tag = dto.EncounterID;
                    c.Click += WaitingCard_Click;
                }

                flpPayment.Controls.Add(card);
                firstCard ??= card;
            }

            flpPayment.ResumeLayout();

            if (firstCard != null)
            {
                WaitingCard_Click(firstCard, EventArgs.Empty);
            }
        }

        private Panel CreatePaymentCard(PaymentWaitingDTO dto)
        {
            Panel card = new Panel
            {
                Width = Math.Max(340, flpPayment.ClientSize.Width - 28),
                Height = 112,
                BackColor = Color.FromArgb(248, 250, 252),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 12),
                Cursor = Cursors.Hand,
                Tag = dto.EncounterID
            };

            Label lblName = new Label
            {
                Name = "lblName",
                Text = dto.PatientName,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39),
                Location = new Point(16, 12),
                Size = new Size(card.Width - 155, 26),
                AutoEllipsis = true
            };

            Label lblAmount = new Label
            {
                Name = "lblAmount",
                Text = dto.TotalAmount.ToString("N0") + " đ",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(37, 99, 235),
                Location = new Point(card.Width - 132, 12),
                Size = new Size(112, 26),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label lblCode = new Label
            {
                Name = "lblCode",
                Text = dto.PatientCode,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location = new Point(16, 44),
                Size = new Size(card.Width - 150, 22),
                AutoEllipsis = true
            };

            Label lblDoctor = new Label
            {
                Name = "lblDoctor",
                Text = "BS. " + dto.DoctorName,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = Color.FromArgb(75, 85, 99),
                Location = new Point(16, 72),
                Size = new Size(card.Width - 145, 24),
                AutoEllipsis = true
            };

            Label lblStatus = new Label
            {
                Name = "lblStatus",
                Text = IsPending(dto.Status) ? "Chưa TT" : "Đã TT",
                Size = new Size(84, 28),
                Location = new Point(card.Width - 104, 58),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.FromArgb(255, 237, 213),
                ForeColor = Color.FromArgb(234, 88, 12),
                Font = new Font("Segoe UI", 8.5F, FontStyle.Bold)
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblCode);
            card.Controls.Add(lblDoctor);
            card.Controls.Add(lblAmount);
            card.Controls.Add(lblStatus);
            ApplyCardLayout(card);
            return card;
        }

        private void ResizePaymentCards()
        {
            int width = Math.Max(340, flpPayment.ClientSize.Width - 28);
            foreach (Control control in flpPayment.Controls)
            {
                control.Width = width;
                if (control is Panel card)
                {
                    ApplyCardLayout(card);
                }
            }
        }

        private void ApplyCardLayout(Panel card)
        {
            Control[] amount = card.Controls.Find("lblAmount", false);
            Control[] status = card.Controls.Find("lblStatus", false);
            Control[] name = card.Controls.Find("lblName", false);
            Control[] code = card.Controls.Find("lblCode", false);
            Control[] doctor = card.Controls.Find("lblDoctor", false);

            if (amount.Length > 0)
            {
                amount[0].Location = new Point(card.Width - 132, 12);
            }

            if (status.Length > 0)
            {
                status[0].Location = new Point(card.Width - 104, 58);
            }

            int textWidth = Math.Max(120, card.Width - 165);
            if (name.Length > 0) name[0].Size = new Size(textWidth, 26);
            if (code.Length > 0) code[0].Size = new Size(textWidth, 22);
            if (doctor.Length > 0) doctor[0].Size = new Size(textWidth, 24);
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
                    Color.FromArgb(248, 250, 252);
            }

            selectedCard = card;

            selectedCard.BackColor =
                Color.FromArgb(239, 246, 255);
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
    $"Bệnh nhân: {patient.PatientName}";

            label3.Text =
                $"Mã BN: {patient.PatientCode}";

            label4.Text =
                $"BS: {patient.DoctorName}";

            label5.Text =
                $"Tổng: {patient.TotalAmount:N0} đ";

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

        private void ShowEmptyDetail()
        {
            panel2.Controls.Clear();
            panel2.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = "Chọn một hồ sơ bên trái để xem chi tiết hóa đơn và thanh toán PayOS.",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                ForeColor = Color.FromArgb(107, 114, 128)
            });
        }

        private static bool Contains(string value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value)
                && value.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool IsPending(string status)
        {
            return string.IsNullOrWhiteSpace(status)
                || status.Equals("Pending", StringComparison.OrdinalIgnoreCase)
                || status.Equals("Unpaid", StringComparison.OrdinalIgnoreCase)
                || status.Equals("Chưa thanh toán", StringComparison.OrdinalIgnoreCase);
        }
    }
}
