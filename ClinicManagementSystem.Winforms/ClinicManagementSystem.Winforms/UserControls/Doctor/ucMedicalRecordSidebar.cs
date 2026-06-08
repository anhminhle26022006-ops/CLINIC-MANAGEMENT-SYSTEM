using DTO.Clinical.erm;
using System;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ucMedicalRecordSidebar : UserControl
    {
        public ucMedicalRecordSidebar()
        {
            InitializeComponent();
            LoadMockData();
        
        }
        private void LoadMockData()
        {
            _data = new List<MedicalRecordDto>
    {
        new()
        {
            Code = "BA001",
            Date = DateTime.Today,
            Patient = "Nguyễn Văn A",
            Diagnosis = "Viêm họng",
            Doctor = "BS. Trịnh Hồng My",
            Status = "Hoàn thành"
        },

        new()
        {
            Code = "BA002",
            Date = DateTime.Today.AddDays(-1),
            Patient = "Trần Thị B",
            Diagnosis = "Tăng huyết áp",
            Doctor = "BS. Tô Cẩm Anh",
            Status = "Đang theo dõi"
        },

        new()
        {
            Code = "BA003",
            Date = DateTime.Today.AddDays(-2),
            Patient = "Lê Văn C",
            Diagnosis = "Tiểu đường",
            Doctor = "BS. Tạ Anh Khôi",
            Status = "Hoàn thành"
        },

        new()
        {
            Code = "BA004",
            Date = DateTime.Today.AddDays(-3),
            Patient = "Phạm Thị D",
            Diagnosis = "Hen phế quản",
            Doctor = "BS. Nguyễn Minh",
            Status = "Đang theo dõi"
        }
    };

            LoadGrid(_data);

            lblTotal.Text = _data.Count.ToString();

            lblToday.Text =
                _data.Count(x => x.Date.Date == DateTime.Today)
                .ToString();

            lblWeek.Text =
                _data.Count(x => x.Date >= DateTime.Today.AddDays(-7))
                .ToString();

            lblTracking.Text =
                _data.Count(x => x.Status == "Đang theo dõi")
                .ToString();

            cboStatus.SelectedIndex = 0;
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

        private void dgvRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRecords.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                e.CellStyle.ForeColor = Color.White;

                if (status == "Hoàn thành")
                    e.CellStyle.BackColor = Color.SeaGreen;

                else if (status == "Đang theo dõi")
                    e.CellStyle.BackColor = Color.DarkOrange;

                else
                    e.CellStyle.BackColor = Color.Gray;
            }
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

        private void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvRecords.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var frm = new ERMform();
                frm.ShowDialog();
            }
        }
        private List<MedicalRecordDto> _data;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            var query = _data.AsEnumerable();

            // search text
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query = query.Where(x =>
                    x.Code.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                    x.Patient.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase));
            }

            // status
            if (cboStatus.SelectedIndex == 1)
                query = query.Where(x => x.Status == "Hoàn thành");

            if (cboStatus.SelectedIndex == 2)
                query = query.Where(x => x.Status == "Đang theo dõi");

            // date filter
            query = query.Where(x =>
                x.Date >= dtFrom.Value.Date &&
                x.Date <= dtTo.Value.Date);

            LoadGrid(query.ToList());
        }
        private void LoadGrid(List<MedicalRecordDto> list)
        {
            dgvRecords.Rows.Clear();

            foreach (var x in list)
            {
                dgvRecords.Rows.Add(
                    x.Code,
                    x.Date.ToString("dd/MM/yyyy"),
                    x.Patient,
                    x.Diagnosis,
                    x.Doctor,
                    x.Status
                );
            }
        }
    }
}