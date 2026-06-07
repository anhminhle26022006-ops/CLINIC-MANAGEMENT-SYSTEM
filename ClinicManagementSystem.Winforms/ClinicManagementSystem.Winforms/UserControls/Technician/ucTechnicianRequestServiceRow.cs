using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianRequestServiceRow : UserControl
    {
        public event EventHandler ViewClicked;
        public event EventHandler ActionClicked;

        public ucTechnicianRequestServiceRow()
        {
            InitializeComponent();
        }

        public void Configure(string serviceType, string note, string priority, string status)
        {
            lblServiceType.Text = serviceType;
            lblNote.Text = string.IsNullOrWhiteSpace(note) ? "Không có ghi chú" : note;

            string priorityText = string.IsNullOrWhiteSpace(priority) ? "Thường" : priority.Trim();
            lblPriority.Text = priorityText;
            if (priorityText == "Thường")
            {
                lblPriority.BackColor = Color.FromArgb(243, 244, 246);
                lblPriority.ForeColor = Color.FromArgb(75, 85, 99);
            }
            else
            {
                lblPriority.BackColor = Color.FromArgb(254, 226, 226);
                lblPriority.ForeColor = Color.FromArgb(185, 28, 28);
            }

            lblStatus.Text = status;
            lblStatus.BackColor = Color.FromArgb(254, 249, 195);
            lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
            if (status == "Đang xử lý")
            {
                lblStatus.BackColor = Color.FromArgb(239, 246, 255);
                lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
            }
            else if (status == "Hoàn thành")
            {
                lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                lblStatus.ForeColor = Color.FromArgb(34, 139, 74);
            }

            if (status == "Hoàn thành")
            {
                btnAction.Text = "Xem";
                btnAction.BackColor = Color.FromArgb(220, 252, 231);
                btnAction.ForeColor = Color.FromArgb(34, 139, 74);
            }
            else
            {
                btnAction.Text = status == "Đang xử lý" ? "Xử lý" : "Tiến hành";
                btnAction.BackColor = Color.FromArgb(37, 99, 235);
                btnAction.ForeColor = Color.White;
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Xem")
            {
                ViewClicked?.Invoke(this, EventArgs.Empty);
                return;
            }

            ActionClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
