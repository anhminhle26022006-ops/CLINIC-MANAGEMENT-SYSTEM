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
    public partial class ucVitalSignCard1 : UserControl
    {
        public ucVitalSignCard1()
        {
            InitializeComponent();
        }
        public string VitalName
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public string Value
        {
            get => lblValue.Text;
            set => lblValue.Text = value;
        }

        public string Unit
        {
            get => lblUnit.Text;
            set => lblUnit.Text = value;
        }
    }
}
