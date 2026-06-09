using DTO.Clinical.erm;
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
    public partial class ucInvoiceCard : UserControl
    {
        public ucInvoiceCard()
        {
            InitializeComponent();
        }
        public void Bind(InvoiceHistoryDto invoice)
        {
            if (invoice == null) return;

            lblDate.Text = invoice.InvoiceDate.ToString("dd/MM/yyyy");
            lblAmount.Text = invoice.TotalAmount.ToString("N0") + " VNĐ";
            lblStatus.Text = invoice.Status;
            BindServices(invoice);
            BindPaymentMethod(invoice.PaymentMethod);

            // basic status color
            lblStatus.ForeColor =
                invoice.Status == "Đã thanh toán"
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

        private void BindServices(InvoiceHistoryDto invoice)
        {
            var services = invoice.Services ?? new List<ServiceItemDto>();

            lblExam.Text = FormatService(services.ElementAtOrDefault(0), "Khám bệnh");
            lblLab.Text = FormatService(services.ElementAtOrDefault(1), "Xét nghiệm");
            lblMedicine.Text = FormatService(services.ElementAtOrDefault(2), "Thuốc / CĐHA");
        }

        private string FormatService(ServiceItemDto service, string fallback)
        {
            if (service == null)
            {
                return "• " + fallback;
            }

            return $"• {service.ServiceName} x{service.Quantity}: {service.Price:N0} VNĐ";
        }

        private void BindPaymentMethod(string method)
        {
            method = string.IsNullOrWhiteSpace(method) ? "Cash" : method;
            lblCash.Text = "• Phương thức: " + method;
            lblCard.Text = method.Equals("Cash", StringComparison.OrdinalIgnoreCase)
                ? "• Tiền mặt"
                : "• Không dùng tiền mặt";
        }

    }
}
