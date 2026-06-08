using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucEmployeeManagement : UserControl
    {
        public ucEmployeeManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dgvEmployees.Rows.Clear();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chuc nang se duoc noi voi logic hien tai sau.", "Admin", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) { }

        private void cboChucVu_SelectedIndexChanged(object sender, EventArgs e) { }

        private void panelHeader_Resize(object sender, EventArgs e) { }

        private void panelKPI_Resize(object sender, EventArgs e) { }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgvEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) { }

        private void dgvEmployees_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void PanelRoundedBorder(object sender, PaintEventArgs e)
        {
            if (sender is not Control c) return;
            using var pen = new Pen(Color.FromArgb(229, 231, 235));
            e.Graphics.DrawRectangle(pen, 0, 0, c.Width - 1, c.Height - 1);
        }
    }
}
