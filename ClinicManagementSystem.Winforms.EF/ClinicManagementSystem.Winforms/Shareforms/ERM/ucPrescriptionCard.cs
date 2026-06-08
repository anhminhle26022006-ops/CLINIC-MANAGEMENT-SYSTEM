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
    public partial class ucPrescriptionCard : UserControl
    {
        public ucPrescriptionCard()
        {
            InitializeComponent();
            dgvMedicines.Rows.Add(
        "Paracetamol 500mg",
        "1 viên",
        "3 lần/ngày",
        "10",
        "Sau ăn");

            dgvMedicines.Rows.Add(
                "Vitamin C",
                "1 viên",
                "2 lần/ngày",
                "20",
                "Sau ăn");
        }

    }
}
