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
    public partial class ucHistory : UserControl
    {
        public ucHistory()
        {
            InitializeComponent();
        }
        public void Bind(List<EncounterHistoryDto> encounters)
        {
            flowLayoutPanel1.Controls.Clear();

            if (encounters == null || encounters.Count == 0)
                return;

            var sorted = encounters
                .OrderByDescending(x => x.VisitDate)
                .ToList();

            foreach (var item in sorted)
            {
                var card = new ucVisitCard();
                card.Bind(item);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
