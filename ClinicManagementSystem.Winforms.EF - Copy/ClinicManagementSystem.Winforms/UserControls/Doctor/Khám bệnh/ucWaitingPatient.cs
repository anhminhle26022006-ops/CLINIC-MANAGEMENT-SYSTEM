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
    public partial class ucWaitingPatient : UserControl
    {
        
        public bool IsSelected { get; private set; }

        public ucWaitingPatient()
        {
            InitializeComponent();

            pnlContainer.Click += Patient_Click;

            foreach (Control c in pnlContainer.Controls)
                c.Click += Patient_Click;
        }

        private void Patient_Click(
            object sender,
            System.EventArgs e)
        {
            SelectCard();
        }

        public void SelectCard()
        {
            IsSelected = true;

            pnlContainer.BackColor =
                Color.FromArgb(219, 234, 254);
        }

        public void UnSelectCard()
        {
            IsSelected = false;

            pnlContainer.BackColor =
                Color.White;
        }
    }
}
