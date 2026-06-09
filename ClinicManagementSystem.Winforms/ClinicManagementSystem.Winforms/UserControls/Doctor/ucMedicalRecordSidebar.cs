using ClinicManagementSystem.Winforms.Controllers;
using DTO.Clinical.erm;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucMedicalRecordSidebar : UserControl
    {
        private readonly MedicalRecordController _controller;
        private List<MedicalRecordDto> _data;
        public ucMedicalRecordSidebar()
        {
            InitializeComponent();
            _controller = new MedicalRecordController();

            InitializeGrid();

            LoadData();

        }
       

        private void LoadData()
        {
            _data = _controller.GetAll();

            LoadGrid(_data);

            UpdateDashboard();
        }
        private void UpdateDashboard()
        {
            lblTotal.Text =
                _data.Count.ToString();

            lblToday.Text =
                _data.Count(x =>
                    x.Date.Date == DateTime.Today)
                .ToString();

            lblWeek.Text =
                _data.Count(x =>
                    x.Date >= DateTime.Today.AddDays(-7))
                .ToString();

            lblTracking.Text =
                _data.Count(x =>
                    x.Status == "Đang theo dõi")
                .ToString();
        }
        private void InitializeGrid()
        {
            dgvRecords.Rows.Clear();
            dgvRecords.Columns.Clear();

            dgvRecords.AutoGenerateColumns = false;

            dgvRecords.EnableHeadersVisualStyles = false;

            dgvRecords.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(37, 99, 235);

            dgvRecords.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvRecords.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvRecords.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvRecords.RowTemplate.Height = 40;

            dgvRecords.Columns.Add("Code", "Mã bệnh án");
            dgvRecords.Columns.Add("Date", "Ngày khám");
            dgvRecords.Columns.Add("Patient", "Bệnh nhân");
            dgvRecords.Columns.Add("Diagnosis", "Chuẩn đoán");
            dgvRecords.Columns.Add("Doctor", "Bác sĩ");
            dgvRecords.Columns.Add("Status", "Trạng thái");

            DataGridViewButtonColumn btnView =
                new DataGridViewButtonColumn();

            btnView.Name = "btnView";
            btnView.HeaderText = "Thao tác";
            btnView.Text = "Xem ERM";
            btnView.UseColumnTextForButtonValue = true;

            dgvRecords.Columns.Add(btnView);
        }
        private void LoadGrid(List<MedicalRecordDto> records)
        {
            dgvRecords.Rows.Clear();

            foreach (var item in records)
            {
                dgvRecords.Rows.Add(
                    item.Code,
                    item.Date.ToString("dd/MM/yyyy"),
                    item.Patient,
                    item.Diagnosis,
                    item.Doctor,
                    item.Status
                );
            }
        }
        private void dgvRecords_CellFormatting(
    object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRecords.Columns[e.ColumnIndex].Name != "Status")
                return;

            string status = e.Value?.ToString();

            if (status == "Hoàn thành")
            {
                e.CellStyle.BackColor = Color.SeaGreen;
                e.CellStyle.ForeColor = Color.White;
            }
            else if (status == "Đang theo dõi")
            {
                e.CellStyle.BackColor = Color.DarkOrange;
                e.CellStyle.ForeColor = Color.White;
            }
        }
        private void ApplyFilter()
        {
            IEnumerable<MedicalRecordDto> query = _data;

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query = query.Where(x =>
                    x.Code.Contains(txtSearch.Text) ||
                    x.Patient.Contains(txtSearch.Text));
            }

            if (cboStatus.SelectedIndex == 1)
                query = query.Where(x =>
                    x.Status == "Hoàn thành");

            if (cboStatus.SelectedIndex == 2)
                query = query.Where(x =>
                    x.Status == "Đang theo dõi");

            query = query.Where(x =>
                x.Date.Date >= dtFrom.Value.Date &&
                x.Date.Date <= dtTo.Value.Date);

            LoadGrid(query.ToList());
        }
        private void dgvRecords_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRecords.Columns[e.ColumnIndex].Name == "btnView")
            {
                ERMform frm = new ERMform();
                frm.ShowDialog();
            }
        }
        
        private Label CreateStatusChip(string status)
        {
            var lbl = new Label();
            lbl.AutoSize = true;
            lbl.Padding = new Padding(10, 3, 10, 3);
            lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.White;

            if (status == "Hoàn thành")
                lbl.BackColor = Color.SeaGreen;
            else if (status == "Đang theo dõi")
                lbl.BackColor = Color.DarkOrange;
            else
                lbl.BackColor = Color.Gray;

            lbl.Text = status;
            return lbl;
        }

        
        private void AddHoverEffect(Panel pnl)
        {
            pnl.MouseEnter += (s, e) =>
            {
                pnl.BackColor = Color.FromArgb(235, 245, 255);
                pnl.Cursor = Cursors.Hand;
            };

            pnl.MouseLeave += (s, e) =>
            {
                pnl.BackColor = Color.White;
            };
        }

        

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
       
        
        
    }
}