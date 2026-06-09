using System;
using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Controllers;
using ClinicManagementSystem.Winforms.Forms;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls
{
    public partial class PatientManagement : UserControl
    {
        private readonly PatientManaController controller = new();

        public PatientManagement()
        {
            InitializeComponent();
            Load += PatientManagement_Load;
        }

        private void PatientManagement_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadPatients();
            LoadFilters();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            lbpatienttotal.Text = controller.CountPatients().ToString();
            lbnewpatient.Text = controller.CountNewPatients().ToString();
            lbrevisitpatient.Text = controller.CountRevisitPatients().ToString();
            lbappointment.Text = controller.CountUpcomingAppointments().ToString();
        }

        private void SetupGrid()
        {
            Font gridFont = new Font("Segoe UI", 10);

            dgvPatientMana.BorderStyle = BorderStyle.None;
            dgvPatientMana.BackgroundColor = Color.White;

            dgvPatientMana.EnableHeadersVisualStyles = false;
            dgvPatientMana.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvPatientMana.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvPatientMana.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(55, 65, 81);
            dgvPatientMana.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvPatientMana.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPatientMana.ColumnHeadersHeight = 45;

            dgvPatientMana.DefaultCellStyle.Font = gridFont;
            dgvPatientMana.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(235, 245, 255);

            dgvPatientMana.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvPatientMana.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgvPatientMana.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgvPatientMana.RowTemplate.Height = 50;

            dgvPatientMana.RowHeadersVisible = false;
            dgvPatientMana.MultiSelect = false;

            dgvPatientMana.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvPatientMana.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.None;

            dgvPatientMana.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvPatientMana.GridColor =
                Color.FromArgb(235, 235, 235);

            dgvPatientMana.CellContentClick -= dgvPatientMana_CellContentClick;
            dgvPatientMana.CellClick -= dgvPatientMana_CellContentClick;
            dgvPatientMana.CellClick += dgvPatientMana_CellContentClick;
        }

        private void LoadPatients()
        {
            dgvPatientMana.DataSource = controller.GetPatients();

            AddActionColumns();
            FormatColumns();

            BeginInvoke(new Action(() =>
            {
                dgvPatientMana.ClearSelection();
            }));
        }

        private void LoadFilters()
        {
            cbGender.Items.AddRange(new[]
            {
        "Tất cả",
        "Nam",
        "Nữ"
    });

            cbAge.Items.AddRange(new[]
            {
        "Tất cả",
        "Dưới 18",
        "18 - 60",
        "Trên 60"
    });

            cbGender.SelectedIndex = 0;
            cbAge.SelectedIndex = 0;
        }

        private void FormatColumns()
        {
            dgvPatientMana.Columns["PatientID"].Visible = false;
            dgvPatientMana.Columns["BloodType"].Visible = false;
            dgvPatientMana.Columns["Allergy"].Visible = false;

            dgvPatientMana.Columns["PatientCode"].HeaderText = "MÃ BN";
            dgvPatientMana.Columns["Name"].HeaderText = "BỆNH NHÂN";
            dgvPatientMana.Columns["BirthDate"].HeaderText = "NGÀY SINH";
            dgvPatientMana.Columns["Gender"].HeaderText = "GIỚI TÍNH";
            dgvPatientMana.Columns["Phone"].HeaderText = "SỐ ĐIỆN THOẠI";
            dgvPatientMana.Columns["Address"].HeaderText = "ĐỊA CHỈ";
            dgvPatientMana.Columns["Age"].HeaderText = "TUỔI";

            foreach (DataGridViewColumn col in dgvPatientMana.Columns)
            {
                col.HeaderCell.Style.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            // Riêng tên bệnh nhân căn trái
            dgvPatientMana.Columns["Name"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            // Mã BN nổi bật
            dgvPatientMana.Columns["PatientCode"].DefaultCellStyle.ForeColor =
                Color.RoyalBlue;

            dgvPatientMana.Columns["PatientCode"].DefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // Width
            dgvPatientMana.Columns["PatientCode"].Width = 120;
            dgvPatientMana.Columns["Name"].Width = 230;
            dgvPatientMana.Columns["BirthDate"].Width = 140;
            dgvPatientMana.Columns["Gender"].Width = 120;
            dgvPatientMana.Columns["Phone"].Width = 170;
            dgvPatientMana.Columns["Age"].Width = 80;

            // Full phần còn lại
            dgvPatientMana.Columns["Address"].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            dgvPatientMana.Columns["PatientCode"].DisplayIndex = 0;
            dgvPatientMana.Columns["Name"].DisplayIndex = 1;
            dgvPatientMana.Columns["BirthDate"].DisplayIndex = 2;
            dgvPatientMana.Columns["Gender"].DisplayIndex = 3;
            dgvPatientMana.Columns["Phone"].DisplayIndex = 4;
            dgvPatientMana.Columns["Address"].DisplayIndex = 5;
            dgvPatientMana.Columns["Age"].DisplayIndex = 6;
            dgvPatientMana.Columns["View"].DisplayIndex = 7;
            dgvPatientMana.Columns["Edit"].DisplayIndex = 8;
            dgvPatientMana.Columns["Delete"].DisplayIndex = 9;
        }

        private void AddActionColumns()
        {
            if (!dgvPatientMana.Columns.Contains("View"))
            {
                var viewColumn = new DataGridViewButtonColumn
                {
                    Name = "View",
                    HeaderText = "XEM",
                    Text = "👁",
                    UseColumnTextForButtonValue = true,
                    Width = 70,
                    FlatStyle = FlatStyle.Flat
                };

                dgvPatientMana.Columns.Add(viewColumn);
            }

            if (!dgvPatientMana.Columns.Contains("Edit"))
            {
                var editColumn = new DataGridViewButtonColumn
                {
                    Name = "Edit",
                    HeaderText = "SỬA",
                    Text = "✏",
                    UseColumnTextForButtonValue = true,
                    Width = 70,
                    FlatStyle = FlatStyle.Flat
                };

                dgvPatientMana.Columns.Add(editColumn);
            }

            if (!dgvPatientMana.Columns.Contains("Delete"))
            {
                var deleteColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "XÓA",
                    Text = "Xóa",
                    UseColumnTextForButtonValue = true,
                    Width = 70,
                    FlatStyle = FlatStyle.Flat
                };

                dgvPatientMana.Columns.Add(deleteColumn);
            }

            dgvPatientMana.Columns["View"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPatientMana.Columns["Edit"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPatientMana.Columns["Delete"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
            
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvPatientMana.DataSource =
                controller.SearchPatients(txtSearch.Text.Trim());
            AddActionColumns();
            FormatColumns();

            BeginInvoke(new Action(() =>
            {
                dgvPatientMana.ClearSelection();
            }));
        }

        private void ApplyFilters()
        {
            var patients = controller.GetPatients();

            string keyword = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                patients = patients
                    .Where(p =>
                        p.Name.Contains(keyword,
                            StringComparison.OrdinalIgnoreCase)
                        ||
                        p.PatientCode.Contains(keyword,
                            StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (cbGender.SelectedIndex > 0)
            {
                string gender = cbGender.Text;

                patients = patients
                    .Where(p => p.Gender == gender)
                    .ToList();
            }

            switch (cbAge.Text)
            {
                case "Dưới 18":
                    patients = patients
                        .Where(p => p.Age < 18)
                        .ToList();
                    break;

                case "18 - 60":
                    patients = patients
                        .Where(p => p.Age >= 18 && p.Age <= 60)
                        .ToList();
                    break;

                case "Trên 60":
                    patients = patients
                        .Where(p => p.Age > 60)
                        .ToList();
                    break;
            }

            dgvPatientMana.DataSource = null;
            dgvPatientMana.DataSource = patients;

            AddActionColumns();
            FormatColumns();

            BeginInvoke(new Action(() =>
            {
                dgvPatientMana.ClearSelection();
            }));
        }

        private void dgvPatientMana_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string columnName =
                dgvPatientMana.Columns[e.ColumnIndex].Name;

            if (columnName != "View" && columnName != "Edit" && columnName != "Delete")
            {
                return;
            }

            int patientId = Convert.ToInt32(
                dgvPatientMana.Rows[e.RowIndex]
                .Cells["PatientID"].Value);

            if (columnName == "View")
            {
                PatientDTO patient = controller.GetPatientById(patientId);
                if (patient == null)
                {
                    return;
                }

                using CreateNewPatient frm = new CreateNewPatient(patient, true);
                frm.ShowDialog();
            }
            else if (columnName == "Edit")
            {
                PatientDTO patient = controller.GetPatientById(patientId);
                if (patient == null)
                {
                    return;
                }

                using CreateNewPatient frm = new CreateNewPatient(patient);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LoadPatients();
                    LoadStatistics();
                }
            }
            else if (columnName == "Delete")
            {
                string patientName = dgvPatientMana.Rows[e.RowIndex].Cells["Name"].Value?.ToString() ?? "bệnh nhân";
                if (MessageBox.Show($"Xóa {patientName}?", "Xóa bệnh nhân", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    if (controller.DeletePatient(patientId))
                    {
                        LoadPatients();
                        LoadStatistics();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa bệnh nhân này vì đã có lịch khám/hồ sơ/thanh toán liên quan.\n" + ex.Message, "Xóa bệnh nhân", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateNewPatient frm = new CreateNewPatient();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SetupGrid();
                LoadPatients();
                LoadFilters();
                LoadStatistics();
            }
        }
    }
}
