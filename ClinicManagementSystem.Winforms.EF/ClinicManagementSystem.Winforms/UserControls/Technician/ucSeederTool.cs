using System;
using System.Windows.Forms;
using BUS.Services.Technician;
using ClinicManagementSystem.Winforms.Forms;
using ClinicManagementSystem.Winforms.Forms.Integrations;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucSeederTool : TechnicianDashboardViewBase
    {
        private readonly TechnicianSeedBUS seedBUS = new TechnicianSeedBUS();

        protected override Panel ContentPanel => viewHostPanel;

        public ucSeederTool()
        {
            InitializeComponent();
        }

        private void ucSeederTool_Load(object sender, EventArgs e)
        {
            btnRunSeed.Click += (s, ev) => RunDatabaseSeeder();
            btnTestPayOS.Click += (s, ev) =>
            {
                using (var paymentForm = new PayOsPaymentForm())
                {
                    paymentForm.ShowDialog();
                }
            };
            btnSyncApi.Click += (s, ev) =>
            {
                using (var syncForm = new MockApiSyncForm())
                {
                    syncForm.ShowDialog(this);
                }
            };
        }

        private void ucSeederTool_Resize(object sender, EventArgs e)
        {
            if (pnlContainer.Width < 200) return;
            int buttonWidth = (pnlContainer.Width - 64) / 2;
            btnRunSeed.Width = buttonWidth;
            btnTestPayOS.Width = buttonWidth;
            btnTestPayOS.Left = btnRunSeed.Right + 16;
        }

        private void RunDatabaseSeeder()
        {
            txtSeederLog.Clear();

            try
            {
                seedBUS.Run(LogSeed);
                MessageBox.Show("Đã nạp dữ liệu mẫu theo schema CMS.sql thành công!", "Seeder Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogSeed("\n[LỖI] Khởi tạo dữ liệu thất bại. Chi tiết lỗi:");
                LogSeed(ex.ToString());
                MessageBox.Show("Seed dữ liệu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LogSeed(string msg)
        {
            txtSeederLog.AppendText(msg + "\r\n");
        }

        private void btnSyncApi_Click(object sender, EventArgs e)
        {
        }
    }
}
