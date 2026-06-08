using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmViewUser : Form
    {
        private DataRow _row;

        public frmViewUser(DataRow row)
        {
            _row = row;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lblUsernameVal.Text = _row["Username"].ToString();
            lblDisplayNameVal.Text = _row["DisplayName"].ToString();
            lblRoleVal.Text = _row["RoleName"].ToString();
            lblEmailVal.Text = _row["Email"].ToString();
            lblCreatedAtVal.Text = _row["CreatedAtText"].ToString();

            bool active = _row["StatusText"].ToString() == "Hoạt động";

            lblStatusVal.Text = _row["StatusText"].ToString();

            lblStatusVal.ForeColor = active
                ? Color.FromArgb(22, 163, 74)
                : Color.FromArgb(220, 38, 38);

            lblStatusVal.BackColor = active
                ? Color.FromArgb(220, 252, 231)
                : Color.FromArgb(254, 226, 226);

            lblStatusVal.Font =
                new Font("Segoe UI", 9F, FontStyle.Bold);

            lblStatusVal.AutoSize = true;

            lblStatusVal.Padding =
                new Padding(12, 4, 12, 4);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}