using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.WorkingShifts
{
    public partial class ShiftCardControl : UserControl
    {
        public event EventHandler ShiftClicked;

        public ShiftCardControl()
        {
            InitializeComponent();

            Cursor = Cursors.Hand;

            Click += Card_Click;

            foreach (Control c in Controls)
                c.Click += Card_Click;
            this.Click += Card_Click;

            lblCode.Click += Card_Click;
            lblTime.Click += Card_Click;
            lblDepartment.Click += Card_Click;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            ShiftClicked?.Invoke(this, EventArgs.Empty);
        }

        public void SetData(
            string shiftCode,
            string time,
            string department)
        {
            lblCode.Text = shiftCode;
            lblTime.Text = time;
            lblDepartment.Text = department;
        }
    }
}