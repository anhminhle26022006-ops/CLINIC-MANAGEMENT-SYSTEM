using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class RemindingList : UserControl
    {
        private readonly FollowUpController controller =
    new();
        private DataGridView dgvFollowUps;
        private bool showingProcessing = true;

        public RemindingList()
        {
            InitializeComponent();
            ReceptionDemoDataSeeder.EnsureSeeded();
            SetupGrid();
            Load += (s, e) => LoadProcessing();
        }

        private void SetupGrid()
        {
            label1.Text = "Nhắc lịch tái khám";
            label2.Text = "Theo dõi bệnh nhân cần tái khám và lịch sử đã xử lý";

            dgvFollowUps = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false
            };

            dgvFollowUps.EnableHeadersVisualStyles = false;
            dgvFollowUps.ColumnHeadersHeight = 44;
            dgvFollowUps.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvFollowUps.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81);
            dgvFollowUps.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvFollowUps.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvFollowUps.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(55, 65, 81);
            dgvFollowUps.DefaultCellStyle.BackColor = Color.White;
            dgvFollowUps.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvFollowUps.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvFollowUps.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.RowsDefaultCellStyle.BackColor = Color.White;
            dgvFollowUps.RowsDefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvFollowUps.RowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvFollowUps.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dgvFollowUps.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvFollowUps.GridColor = Color.FromArgb(241, 245, 249);
            dgvFollowUps.RowTemplate.Height = 46;
            dgvFollowUps.CellFormatting += dgvFollowUps_CellFormatting;
            dgvFollowUps.CellContentClick += dgvFollowUps_CellContentClick;

            panel14.Controls.Clear();
            panel14.Padding = new Padding(12);
            panel14.Controls.Add(dgvFollowUps);
        }

        private void LoadProcessing()
        {
            showingProcessing = true;
            StyleModeButtons();

            var data =
                controller.GetProcessingFollowUps();
            BindGrid(data);
        }

        private void LoadHistory()
        {
            showingProcessing = false;
            StyleModeButtons();

            var data =
                controller.GetCompletedFollowUps();
            BindGrid(data);
        }

        private void BindGrid(List<FollowUpCardDTO> data)
        {
            dgvFollowUps.Columns.Clear();
            dgvFollowUps.AutoGenerateColumns = true;
            dgvFollowUps.DataSource = data
                .Select(x => new
                {
                    x.FollowUpID,
                    MaBN = OrFallback(x.PatientCode, $"FU{x.FollowUpID:0000}"),
                    BenhNhan = OrFallback(x.PatientName, "Chưa có tên"),
                    BacSi = OrFallback(x.DoctorName, "Chưa phân bác sĩ"),
                    NgayTaiKham = x.FollowUpDate,
                    ChanDoan = OrFallback(x.Diagnosis, "Chưa có chẩn đoán"),
                    TrangThai = TranslateStatus(x.Status)
                })
                .ToList();

            if (dgvFollowUps.Columns.Contains("FollowUpID"))
            {
                dgvFollowUps.Columns["FollowUpID"].Visible = false;
            }

            if (dgvFollowUps.Columns.Contains("NgayTaiKham"))
            {
                dgvFollowUps.Columns["NgayTaiKham"].HeaderText = "Ngày tái khám";
                dgvFollowUps.Columns["NgayTaiKham"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            SetHeader("MaBN", "Mã BN");
            SetHeader("BenhNhan", "Bệnh nhân");
            SetHeader("BacSi", "Bác sĩ");
            SetHeader("ChanDoan", "Chẩn đoán");
            SetHeader("TrangThai", "Trạng thái");

            if (showingProcessing)
            {
                DataGridViewButtonColumn action = new DataGridViewButtonColumn
                {
                    Name = "colReminded",
                    HeaderText = "THAO TÁC",
                    Text = "Đã nhắc",
                    UseColumnTextForButtonValue = true,
                    Width = 110
                };
                action.DefaultCellStyle.BackColor = Color.White;
                action.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
                action.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
                action.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
                dgvFollowUps.Columns.Add(action);
            }

            ApplyReadableGridStyles();
            dgvFollowUps.ClearSelection();
        }

        private void ApplyReadableGridStyles()
        {
            foreach (DataGridViewColumn column in dgvFollowUps.Columns)
            {
                column.DefaultCellStyle.BackColor = Color.White;
                column.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
                column.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
                column.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            }

            foreach (DataGridViewRow row in dgvFollowUps.Rows)
            {
                row.DefaultCellStyle.BackColor = row.Index % 2 == 0
                    ? Color.White
                    : Color.FromArgb(248, 250, 252);
                row.DefaultCellStyle.ForeColor = Color.FromArgb(17, 24, 39);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
                row.DefaultCellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            }

            dgvFollowUps.Refresh();
        }

        private void SetHeader(string columnName, string headerText)
        {
            if (dgvFollowUps.Columns.Contains(columnName))
            {
                dgvFollowUps.Columns[columnName].HeaderText = headerText;
            }
        }

        private void RemindingList_Resize(
    object sender,
    EventArgs e)
        {
            ResizeCards();
        }

        private void ResizeCards()
        {
            dgvFollowUps?.ClearSelection();
        }

        private void btnProcessing_Click(
    object sender,
    EventArgs e)
        {
            LoadProcessing();
        }

        private void btnHistory_Click(
            object sender,
            EventArgs e)
        {
            LoadHistory();
        }

        private void dgvFollowUps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!showingProcessing || e.RowIndex < 0 || dgvFollowUps.Columns[e.ColumnIndex].Name != "colReminded")
            {
                return;
            }

            int followUpId = Convert.ToInt32(dgvFollowUps.Rows[e.RowIndex].Cells["FollowUpID"].Value);
            if (controller.UpdateStatus(followUpId, "Reminded"))
            {
                LoadProcessing();
            }
        }

        private void dgvFollowUps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            e.CellStyle.ForeColor = Color.FromArgb(17, 24, 39);
            e.CellStyle.SelectionForeColor = Color.FromArgb(17, 24, 39);
            e.CellStyle.SelectionBackColor = Color.FromArgb(239, 246, 255);
            e.CellStyle.BackColor = e.RowIndex % 2 == 0
                ? Color.White
                : Color.FromArgb(248, 250, 252);
        }

        private void StyleModeButtons()
        {
            StyleButton(btnProcessing, showingProcessing);
            StyleButton(btnHistory, !showingProcessing);
        }

        private static void StyleButton(Button button, bool active)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = active ? Color.FromArgb(37, 99, 235) : Color.White;
            button.ForeColor = active ? Color.White : Color.FromArgb(55, 65, 81);
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private static string TranslateStatus(string status)
        {
            return status switch
            {
                "Upcoming" => "Sắp tái khám",
                "Reminded" => "Đã nhắc",
                "Overdue" => "Quá hạn",
                "Completed" => "Hoàn thành",
                _ => status
            };
        }

        private static string OrFallback(string value, string fallback)
        {
            return string.IsNullOrWhiteSpace(value)
                ? fallback
                : value;
        }
    }
}
