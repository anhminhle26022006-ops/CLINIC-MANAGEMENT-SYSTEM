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
    public partial class ucFollowup : UserControl
    {
        public ucFollowup()
        {
            InitializeComponent();
        }
        public void Bind(List<FollowUpHistoryDto> followups)
        {
            flowLayoutPanel1.Controls.Clear();

            if (followups == null || followups.Count == 0)
                return;

            var sorted = followups
                .OrderByDescending(x => x.FollowUpDate)
                .ToList();

            foreach (var item in sorted)
            {
                var card = new ucFollowupCard();
                card.Bind(item);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
