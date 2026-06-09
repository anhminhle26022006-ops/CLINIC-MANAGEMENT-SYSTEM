using System;
using System.Drawing;
using System.Windows.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.Forms
{
    public partial class frmEmployeeDetail : Form
    {
        private readonly EmployeeDTO _emp;

        public frmEmployeeDetail(EmployeeDTO emp)
        {
            _emp = emp;
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            // Header
            lblName.Text = _emp.FullName;
            lblMeta.Text = $"Mã NV: {_emp.EmployeeCode}  •  {_emp.RoleName}  •  {_emp.Status}";

            // Thông tin cá nhân
            lblDOBValue.Text = _emp.DateOfBirth?.ToString("dd/MM/yyyy") ?? "—";
            lblGenderValue.Text = _emp.Gender ?? "—";
            lblCitizenValue.Text = _emp.CitizenId ?? "—";
            lblAddressValue.Text = _emp.Address ?? "—";
            lblPhoneValue.Text = _emp.Phone ?? "—";
            lblEmailValue.Text = _emp.Email ?? "—";

            // Thông tin công việc
            lblDeptValue.Text = _emp.DepartmentName ?? "—";
            lblRoleValue.Text = _emp.RoleName ?? "—";
            lblHireValue.Text = _emp.HireDate?.ToString("dd/MM/yyyy") ?? "—";
            lblStatusValue.Text = _emp.Status ?? "—";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}