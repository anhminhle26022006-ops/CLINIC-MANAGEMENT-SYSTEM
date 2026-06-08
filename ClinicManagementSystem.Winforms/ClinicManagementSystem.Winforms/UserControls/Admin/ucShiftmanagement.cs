using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftManagement : UserControl
    {
        public ucShiftManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvShifts.Rows.Clear();
        }

        private void btnAddShift_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuc nang se duoc noi voi logic hien tai sau.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e) { }

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dgvShifts_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvShifts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }

        private void dgvShifts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }

    }
}
