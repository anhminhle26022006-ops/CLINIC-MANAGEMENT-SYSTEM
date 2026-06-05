using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmViewUser : Form
    {
        private DataRowView _drv;

        public frmViewUser(DataRowView drv)
        {
            _drv = drv;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lblUsernameVal.Text = _drv["Username"].ToString();
            lblDisplayNameVal.Text = _drv["DisplayName"].ToString();
            lblRoleVal.Text = _drv["RoleName"].ToString();
            lblEmailVal.Text = _drv["Email"].ToString();
            lblCreatedAtVal.Text = _drv["CreatedAtText"].ToString();

            bool active = _drv["StatusText"].ToString() == "Hoạt động";
            lblStatusVal.Text = _drv["StatusText"].ToString();
            lblStatusVal.ForeColor = active ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            lblStatusVal.BackColor = active ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}