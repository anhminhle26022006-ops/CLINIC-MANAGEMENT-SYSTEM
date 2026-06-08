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
    public partial class ucImaging : UserControl
    {
        public ucImaging()
        {
            InitializeComponent();
        }
        public void Bind(List<ImagingHistoryDto> list)
        {
            flowLayoutPanel1.Controls.Clear();

            if (list == null || list.Count == 0)
                return;

            var sorted = list
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            foreach (var item in sorted)
            {
                var card = new ucImagingCard();

                card.Bind(item); // 🔥 nối data

                flowLayoutPanel1.Controls.Add(card);
            }
        }
    }
}
