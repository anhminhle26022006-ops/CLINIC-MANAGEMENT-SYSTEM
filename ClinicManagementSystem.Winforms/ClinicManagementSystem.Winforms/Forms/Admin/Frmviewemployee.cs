using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    public partial class frmViewEmployee : Form
    {
        private readonly EmployeeDTO _emp;

        public frmViewEmployee(EmployeeDTO emp)
        {
            _emp = emp;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lblCodeVal.Text = _emp.EmployeeCode;
            lblNameVal.Text = _emp.FullName;
            lblChucVuVal.Text = MapChucVu(_emp.RoleName);
            lblKhoaVal.Text = _emp.DepartmentName;
            lblPhoneVal.Text = _emp.Phone;
            lblEmailVal.Text = _emp.Email;
            lblStatusVal.Text = _emp.StatusText;

            bool active = _emp.Status == "Active";
            lblStatusVal.ForeColor = active ? Color.FromArgb(22, 163, 74) : Color.FromArgb(220, 38, 38);
            lblStatusVal.BackColor = active ? Color.FromArgb(240, 253, 244) : Color.FromArgb(254, 242, 242);
        }

        private string MapChucVu(string cv) =>
            cv == "Doctor" ? "Bác sĩ" : cv == "Nurse" ? "Y tá" :
            cv == "Pharmacist" ? "Dược sĩ" : cv == "Technician" ? "Kỹ thuật viên" :
            cv == "Receptionist" ? "Lễ tân" : cv;

        private void btnClose_Click(object sender, System.EventArgs e) => this.Close();
    }
}