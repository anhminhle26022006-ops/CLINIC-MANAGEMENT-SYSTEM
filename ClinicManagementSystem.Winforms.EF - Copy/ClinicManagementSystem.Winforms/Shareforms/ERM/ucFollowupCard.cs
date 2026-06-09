using DTO.Clinical.erm;
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
        public void Bind(FollowUpHistoryDto item)
        {
            if (item == null) return;

            lblDate.Text = item.FollowUpDate.ToString("dd/MM/yyyy");
            lblDoctor.Text = item.DoctorName;
            lblContent.Text = item.Content;

            lblStatus.Text = item.Status;

            // đổi màu trạng thái
            lblStatus.BackColor =
                item.Status == "Hoàn thành"
                ? System.Drawing.Color.Green
                : System.Drawing.Color.Orange;
        }
    }
}
