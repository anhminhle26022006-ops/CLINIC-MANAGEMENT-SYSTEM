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
    public partial class ucImagingCard : UserControl
    {
        private ImagingHistoryDto _data;

        public ucImagingCard()
        {
            InitializeComponent();
        }
        public void Bind(ImagingHistoryDto item)
        {
            if (item == null) return;

            _data = item;

            lblTitle.Text = item.Modality; // MRI, CT, X-ray...
            lblDate.Text = item.CreatedAt.ToString("dd/MM/yyyy");
            lblDoctor.Text = item.DoctorName;
            lblConclusion.Text = item.Conclusion;

            // preview nếu có ảnh
            if (item.ImageUrl != null)
                picPreview.Image = Image.FromFile(item.ImageUrl);
        }

        private void BtnViewImage_Click(object sender, EventArgs e)
        {
            if (_data == null) return;

            // mở PACS viewer (form mới)
            var viewer = new frmPacsViewer(_data);
            viewer.Show();
        }
    }
}
