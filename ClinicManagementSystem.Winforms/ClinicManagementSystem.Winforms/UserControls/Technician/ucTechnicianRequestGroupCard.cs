using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianRequestGroupCard : UserControl
    {
        public ucTechnicianRequestGroupCard()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void ConfigureHeader(string patientName, string patientCode, string doctorName, DateTime requestDate, Color accentColor)
        {
            lblAvatar.Text = string.IsNullOrWhiteSpace(patientName) ? "?" : patientName.Substring(0, 1).ToUpper();
            lblPatientName.Text = patientName;
            lblMeta.Text = $"Mã BN: {patientCode} | Bác sĩ chỉ định: {doctorName}";
            lblDate.Text = requestDate.ToString("dd/MM/yyyy HH:mm");
            pnlAccent.BackColor = accentColor;
        }

        public void AddServiceRow(Control row)
        {
            row.Width = flpServiceRows.ClientSize.Width;
            row.Margin = new Padding(0);
            flpServiceRows.Controls.Add(row);
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            int rowsHeight = 0;
            foreach (Control row in flpServiceRows.Controls)
            {
                rowsHeight += row.Height + row.Margin.Vertical;
            }
            rowsHeight = Math.Max(78, rowsHeight);
            flpServiceRows.Height = rowsHeight;
            pnlServiceContainer.Height = rowsHeight;
            Height = pnlServiceContainer.Bottom + 24;
        }

        private void ucTechnicianRequestGroupCard_Resize(object sender, EventArgs e)
        {
            foreach (Control row in flpServiceRows.Controls)
            {
                row.Width = flpServiceRows.ClientSize.Width;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var pen = new Pen(Color.FromArgb(229, 231, 235)))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
