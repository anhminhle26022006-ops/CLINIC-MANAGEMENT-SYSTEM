using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Services;

namespace ClinicManagementSystem.Winforms.Forms.Integrations
{
    public partial class MockApiSyncForm : Form
    {
        private readonly ApiSyncBUS apiSyncBUS = new ApiSyncBUS();

        public MockApiSyncForm()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            await RunSyncAsync();
        }

        private async Task RunSyncAsync()
        {
            btnSync.Text = "Đang đồng bộ...";
            btnSync.Enabled = false;

            try
            {
                var result = await apiSyncBUS.SyncAsync();
                dgvPatients.DataSource = result.MergedPatients;
                dgvEmployees.DataSource = result.MergedEmployees;
                MessageBox.Show(result.ToUserMessage(), "Kết quả đồng bộ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (JsonException ex)
            {
                MessageBox.Show(
                    "LỖI JSON PARSE\n\n" +
                    "Có thể SheetDB/Supabase đang thiếu cột UUID, trả UUID rỗng sai kiểu, hoặc JSON không đúng dạng.\n\n" +
                    "Chi tiết:\n" + ex.Message,
                    "Debug: Lỗi JSON",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "LỖI HỆ THỐNG/API\n\n" +
                    "Message:\n" + ex.Message + "\n\n" +
                    "StackTrace:\n" + ex.StackTrace,
                    "Debug: Lỗi chung",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnSync.Text = "Đồng bộ API";
                btnSync.Enabled = true;
            }
        }
    }
}
