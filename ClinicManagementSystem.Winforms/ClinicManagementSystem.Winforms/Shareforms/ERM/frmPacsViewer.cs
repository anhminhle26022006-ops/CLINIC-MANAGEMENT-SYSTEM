using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{

    public partial class frmPacsViewer : Form
    {
        private ImagingHistoryDto _data;
        public frmPacsViewer()
        {
            InitializeComponent();
        }
        public frmPacsViewer(ImagingHistoryDto data)
        {
            InitializeComponent();
            _data = data;

            Load += FrmPacsViewer_Load;
        }

        private void FrmPacsViewer_Load(object sender, EventArgs e)
        {
            if (_data == null) return;

            // bind info
            lblPatientName.Text = _data.PatientName;
            lblTechnicianValue.Text = _data.DoctorName;
            lblStudyDate.Text = _data.CreatedAt.ToString("dd/MM/yyyy");

            if (!string.IsNullOrWhiteSpace(_data.ImageUrl) && File.Exists(_data.ImageUrl))
            {
                try
                {
                    picImage.Image = Image.FromFile(_data.ImageUrl);
                    return;
                }
                catch
                {
                    // Fall through to the user-facing message below.
                }
            }

            MessageBox.Show("Không có ảnh để hiển thị");
        }
    }
}
