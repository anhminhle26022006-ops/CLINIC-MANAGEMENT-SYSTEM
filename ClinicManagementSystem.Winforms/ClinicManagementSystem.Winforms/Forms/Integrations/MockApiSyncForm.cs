using System;
using System.Drawing;
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

        private void MockApiSyncForm_Load(object sender, EventArgs e)
        {
            btnSync.Text = "Đồng bộ API";
            StyleButton(btnSync);
            StyleDataGridView(dgvPatients);
            StyleDataGridView(dgvEmployees);
        }

        private void StyleButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(37, 99, 235);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(229, 231, 235);

            // Header styles
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 130, 246);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 35;

            // Row styles
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(31, 41, 55);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138);

            // Alternating rows
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);

            // General options
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 30;
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
