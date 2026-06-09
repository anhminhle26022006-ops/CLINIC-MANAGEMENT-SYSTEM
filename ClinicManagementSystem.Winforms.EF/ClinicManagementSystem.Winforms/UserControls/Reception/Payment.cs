using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class Payment : UserControl
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            PaymentContent content =
                new PaymentContent();

            content.Dock =
                DockStyle.Fill;

            pnlContent.Controls.Add(
                content);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            HistoryPayment content =
                new HistoryPayment();

            content.Dock =
                DockStyle.Fill;

            pnlContent.Controls.Add(
                content);
        }
    }
}
