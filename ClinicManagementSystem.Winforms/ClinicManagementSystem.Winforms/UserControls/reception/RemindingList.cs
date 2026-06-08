using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class RemindingList : UserControl
    {
        private readonly FollowUpController controller =
    new();

        public RemindingList()
        {
            InitializeComponent();
            LoadProcessing();
        }

        private void LoadProcessing()
        {
            flowLayoutPanel1.Controls.Clear();

            var data =
                controller.GetProcessingFollowUps();

            int cardWidth =
                (flowLayoutPanel1.ClientSize.Width
                - SystemInformation.VerticalScrollBarWidth
                - 20) / 2;

            foreach (var item in data)
            {
                RemindingCard card =
                    new();

                card.Width =
                    cardWidth;

              //  card.Height = 450;

                card.Margin =
                    new Padding(5);

                card.BindData(item);

                flowLayoutPanel1.Controls
                    .Add(card);
            }
        }

        private void LoadHistory()
        {
            flowLayoutPanel1.Controls.Clear();

            var data =
                controller.GetCompletedFollowUps();

            foreach (var item in data)
            {
                RemindingCard card =
                    new();

                card.BindData(item);

                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void RemindingList_Resize(
    object sender,
    EventArgs e)
        {
            ResizeCards();
        }

        private void ResizeCards()
        {
            int cardWidth =
                (flowLayoutPanel1.ClientSize.Width
                - SystemInformation.VerticalScrollBarWidth
                - 20) / 2;

            foreach (Control control in
                     flowLayoutPanel1.Controls)
            {
                if (control is RemindingCard card)
                {
                    card.Width =
                        cardWidth;
                }
            }
        }

        private void btnProcessing_Click(
    object sender,
    EventArgs e)
        {
            LoadProcessing();
        }

        private void btnHistory_Click(
            object sender,
            EventArgs e)
        {
            LoadHistory();
        }
    }
}
