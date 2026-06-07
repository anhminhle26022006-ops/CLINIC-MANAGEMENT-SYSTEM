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
    public partial class ucFollowupCard : UserControl
    {
        public ucFollowupCard()
        {
            InitializeComponent();
        }
        public void SetStatus(string status)
        {
            lblStatus.Text = status;

            if (status == "Hoàn thành")
            {
                lblStatus.BackColor = Color.SeaGreen;
            }
            else
            {
                lblStatus.BackColor = Color.DarkOrange;
            }
        }
    }
}
