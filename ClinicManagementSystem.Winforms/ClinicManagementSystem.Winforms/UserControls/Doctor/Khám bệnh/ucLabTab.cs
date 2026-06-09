using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucLabTab : UserControl
    {
        public ucLabTab()
        {
            InitializeComponent();

            btnAddLab.Click += BtnAddLab_Click;
        }

        private void BtnAddLab_Click(
            object sender,
            EventArgs e)
        {
            var item =
                new ucLabRequestItem();

            item.Width =
                flpLabs.ClientSize.Width - 25;

            item.DeleteRequested += (s, ev) =>
            {
                flpLabs.Controls.Remove(item);

                item.Dispose();
            };

            flpLabs.Controls.Add(item);
        }
    }
}
