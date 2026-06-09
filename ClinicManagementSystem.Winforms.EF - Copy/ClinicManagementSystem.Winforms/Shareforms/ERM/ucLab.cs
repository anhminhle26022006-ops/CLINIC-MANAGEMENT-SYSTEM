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
    public partial class ucLab : UserControl
    {
        public ucLab()
        {
            InitializeComponent();
        }
        public void Bind(List<LabHistoryDto> data)
        {
            flowLayoutPanel1.Controls.Clear();

            if (data == null) return;

            var sorted = data.OrderByDescending(x => x.CreatedAt).ToList();

            foreach (var item in sorted)
            {
                var card = new ucLabCard();
                card.Bind(item);
                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
