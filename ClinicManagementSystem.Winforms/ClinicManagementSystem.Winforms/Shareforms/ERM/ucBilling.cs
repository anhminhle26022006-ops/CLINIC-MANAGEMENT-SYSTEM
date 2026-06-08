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
    public partial class ucBilling : UserControl
    {
        public ucBilling()
        {
            InitializeComponent();
        }
        // 🔥 NỐI DATA → CARD
        public void Bind(List<InvoiceHistoryDto> invoices)
        {
            flowLayoutPanel1.Controls.Clear();

            if (invoices == null || invoices.Count == 0)
                return;

            var sorted = invoices
                .OrderByDescending(x => x.InvoiceDate)
                .ToList();

            foreach (var invoice in sorted)
            {
                var card = new ucInvoiceCard(); // 🔥 TẠO CARD
                card.Bind(invoice);            // 🔥 ĐỔ DATA

                flowLayoutPanel1.Controls.Add(card); // 🔥 GẮN VÀO UI
            }
        }
    }
}
