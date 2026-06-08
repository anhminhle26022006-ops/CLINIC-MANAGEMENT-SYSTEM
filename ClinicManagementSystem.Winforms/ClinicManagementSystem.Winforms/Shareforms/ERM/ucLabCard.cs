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
    public partial class ucLabCard : UserControl
    {
        public ucLabCard()
        {
            InitializeComponent();
        }
        public void Bind(LabHistoryDto dto)
        {
            lblDate.Text = dto.CreatedAt.ToString("dd/MM/yyyy");
            lblDoctor.Text = dto.DoctorName;
            lblStatus.Text = dto.Status;

            lblWBCValue.Text = GetValue(dto.ResultItems, "WBC");
            lblRBCValue.Text = GetValue(dto.ResultItems, "RBC");
            lblHGBValue.Text = GetValue(dto.ResultItems, "HGB");
            lblPLTValue.Text = GetValue(dto.ResultItems, "PLT");
        }

        private string GetValue(List<LabResultItemDto> items, string name)
        {
            return items?
                .FirstOrDefault(x => x.Name == name)?
                .Value ?? "N/A";
        }
    }
}
