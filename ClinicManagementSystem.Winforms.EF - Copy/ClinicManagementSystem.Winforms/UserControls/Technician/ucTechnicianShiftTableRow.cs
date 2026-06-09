using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianShiftTableRow : UserControl
    {
        public ucTechnicianShiftTableRow()
        {
            InitializeComponent();
        }

        public void Configure(string date, string shift, string department, string room, string status, bool header)
        {
            lblDate.Text = date;
            lblShift.Text = shift;
            lblDepartment.Text = department;
            lblRoom.Text = room;
            lblStatus.Text = status;

            BackColor = header ? Color.FromArgb(249, 250, 251) : Color.White;

            FontStyle style = header ? FontStyle.Bold : FontStyle.Regular;
            Color fore = header ? Color.FromArgb(100, 116, 139) : Color.FromArgb(15, 23, 42);
            foreach (Label label in new[] { lblDate, lblShift, lblDepartment, lblRoom, lblStatus })
            {
                label.Font = new Font("Segoe UI", 9F, style);
                label.ForeColor = fore;
            }

            if (header)
            {
                lblStatus.BackColor = Color.Transparent;
                lblStatus.TextAlign = ContentAlignment.MiddleCenter;
                return;
            }

            string text = string.IsNullOrWhiteSpace(status) ? "Approved" : status.Trim();
            bool approved = text.Equals("Approved", StringComparison.OrdinalIgnoreCase) ||
                            text.Contains("Duyệt") ||
                            text.Contains("duyệt");
            lblStatus.Text = text;
            lblStatus.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStatus.BackColor = approved ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 249, 195);
            lblStatus.ForeColor = approved ? Color.FromArgb(34, 139, 74) : Color.FromArgb(161, 98, 7);
        }
    }
}
