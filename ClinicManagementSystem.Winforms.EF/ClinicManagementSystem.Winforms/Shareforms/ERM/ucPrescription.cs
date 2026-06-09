using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO.Clinical.erm;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucPrescription : UserControl
    {

        public ucPrescription()
        {
            InitializeComponent();
        }
        public void LoadPrescriptions(List<PrescriptionHistoryDto> list)
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (var item in list)
            {
                var card = new ucPrescriptionCard();
                card.Bind(item);

                flowLayoutPanel1.Controls.Add(card);
            }
        }
        public void Bind(List<EncounterHistoryDto> encounters)
        {
            flowLayoutPanel1.Controls.Clear();

            if (encounters == null) return;

            foreach (var encounter in encounters)
            {
                if (encounter.Prescriptions == null) continue;

                foreach (var p in encounter.Prescriptions)
                {
                    var card = new ucPrescriptionCard();

                    card.SetData(p); // quan trọng
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
        }
    }
}
