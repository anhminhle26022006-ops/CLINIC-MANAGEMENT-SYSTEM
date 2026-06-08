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

            // basic status color
            lblStatus.ForeColor =
                invoice.Status == "Đã thanh toán"
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Red;
        }

    }
}
