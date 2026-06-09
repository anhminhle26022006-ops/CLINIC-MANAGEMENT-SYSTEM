using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucDepartmentManagement : UserControl
    {
        public ucDepartmentManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvDepartments.Rows.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuc nang se duoc noi voi logic hien tai sau.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvDepartments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }

        private void dgvDepartments_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }
    }
}
