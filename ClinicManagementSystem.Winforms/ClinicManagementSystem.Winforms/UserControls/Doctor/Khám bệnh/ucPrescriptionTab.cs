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
    public partial class ucPrescriptionTab : UserControl
    {
        public ucPrescriptionTab()
        {
            InitializeComponent();

            btnAddMedicine.Click += BtnAddMedicine_Click;
        }

        private void BtnAddMedicine_Click(
            object sender,
            EventArgs e)
        {
            var item =
                new ucPrescriptionItem();

            item.Width =
                flpMedicines.ClientSize.Width - 25;

            item.DeleteRequested += (s, ev) =>
            {
                flpMedicines.Controls.Remove(item);

                item.Dispose();
            };

            flpMedicines.Controls.Add(item);
        }
    }
}
