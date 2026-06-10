using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS.Services.Doctor;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Prescription
{
    public partial class ucPrescriptionSidebar : UserControl
    {
        private readonly CMSDbContext _context;
        private readonly UserDTO _currentUser;
        private readonly DoctorWorkspaceBUS _doctorBUS;
        private readonly int _doctorId;
        private List<PrescriptionDTO> data = new();
        private List<PrescriptionDTO> filtered = new();

        // Constructor mặc định (dùng cho designer)
        public ucPrescriptionSidebar()
        {
            InitializeComponent();
        }

        // Constructor chính (dùng khi runtime)
        public ucPrescriptionSidebar(CMSDbContext context, UserDTO currentUser) : this()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _doctorBUS = new DoctorWorkspaceBUS(_context);
            _doctorId = _doctorBUS.ResolveDoctorId(_currentUser);

            SetupCrudUi();

            Load += (_, __) => ReloadData();
            txtSearch.TextChanged += (_, __) => ApplyFilter();
            dtFrom.ValueChanged += (_, __) => ApplyFilter();
            dtTo.ValueChanged += (_, __) => ApplyFilter();
            dgvPrescriptions.CellClick += dgvPrescriptions_CellClick;
        }

        private void SetupCrudUi()
        {
            Button btnAdd = new()
            {
                Text = "Tạo toa",
                BackColor = Color.FromArgb(47, 94, 240),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(110, 34),
                Location = new Point(1120, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += (_, __) => CreatePrescription();
            Controls.Add(btnAdd);
            btnAdd.BringToFront();

            AddButtonColumn("btnEdit", "Sửa", "Sửa");
            AddButtonColumn("btnDelete", "Xóa", "Xóa");
        }

        private void AddButtonColumn(string name, string header, string text)
        {
            if (dgvPrescriptions.Columns.Contains(name)) return;
            DataGridViewButtonColumn column = new()
            {
                Name = name,
                HeaderText = header,
                Text = text,
                UseColumnTextForButtonValue = true,
                MinimumWidth = 70
            };
            dgvPrescriptions.Columns.Add(column);
        }

        private void ReloadData()
        {
            data = _doctorBUS.GetPrescriptions(_doctorId);
            BuildStats();
            ApplyFilter();
        }

        private void BuildStats()
        {
            flpStats.Controls.Clear();
            flpStats.Controls.Add(CreateStatPanel("Tong toa thuoc", data.Count.ToString()));
            flpStats.Controls.Add(CreateStatPanel("Hom nay", data.Count(x => x.CreatedAt.Date == DateTime.Today).ToString()));
            flpStats.Controls.Add(CreateStatPanel("Tuan nay", data.Count(x => x.CreatedAt.Date >= DateTime.Today.AddDays(-7)).ToString()));
            flpStats.Controls.Add(CreateStatPanel("Dang theo", data.Count(x => !IsCompleted(x.Status)).ToString()));
        }

        private Panel CreateStatPanel(string title, string value)
        {
            Panel panel = new()
            {
                Width = 180,
                Height = 70,
                Margin = new Padding(8),
                BackColor = Color.FromArgb(240, 248, 255)
            };
            Label lblTitle = new()
            {
                AutoSize = true,
                Text = title,
                Location = new Point(15, 12),
                Font = new Font("Segoe UI", 9F)
            };
            Label lblValue = new()
            {
                AutoSize = true,
                Text = value,
                Location = new Point(15, 32),
                Font = new Font("Segoe UI", 16F, FontStyle.Bold)
            };
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblValue);
            return panel;
        }

        private void ApplyFilter()
        {
            string term = txtSearch.Text.Trim();
            filtered = data
                .Where(item => item.CreatedAt.Date >= dtFrom.Value.Date && item.CreatedAt.Date <= dtTo.Value.Date)
                .Where(item => string.IsNullOrWhiteSpace(term) ||
                               (item.PatientName ?? "").IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0 ||
                               (item.PatientCode ?? "").IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
            BindGrid();
        }

        private void BindGrid()
        {
            dgvPrescriptions.Rows.Clear();
            foreach (PrescriptionDTO item in filtered)
            {
                int row = dgvPrescriptions.Rows.Add(
                    item.CreatedAt.ToString("dd/MM/yyyy"),
                    item.PatientName,
                    item.Items?.Count ?? 0,
                    string.IsNullOrWhiteSpace(item.DoctorNotes) ? DoctorWorkspaceBUS.ToDisplayStatus(item.Status) : item.DoctorNotes);
                dgvPrescriptions.Rows[row].Tag = item;
            }
        }

        private void dgvPrescriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvPrescriptions.Rows[e.RowIndex].Tag is not PrescriptionDTO item) return;
            string column = dgvPrescriptions.Columns[e.ColumnIndex].Name;
            if (column == "btnView") ViewPrescription(item);
            else if (column == "btnEdit") EditPrescription(item);
            else if (column == "btnDelete") DeletePrescription(item);
        }

        private void CreatePrescription()
        {
            List<DoctorAppointmentDTO> appointments = _doctorBUS.GetAppointments(_doctorId, DateTime.Today);
            using DoctorPrescriptionEditForm form = new(appointments, _doctorBUS.GetMedicines(), _doctorId);
            if (form.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                _doctorBUS.CreatePrescription(form.Result);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tạo toa: " + ex.Message, "Toa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPrescription(PrescriptionDTO item)
        {
            using DoctorPrescriptionEditForm form = new(
                _doctorBUS.GetAppointments(_doctorId, DateTime.Today),
                _doctorBUS.GetMedicines(),
                _doctorId,
                item);
            if (form.ShowDialog(this) != DialogResult.OK) return;
            try
            {
                _doctorBUS.UpdatePrescription(form.Result);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể sửa toa: " + ex.Message, "Toa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeletePrescription(PrescriptionDTO item)
        {
            DialogResult confirm = MessageBox.Show("Xóa toa thuốc của " + item.PatientName + "?", "Toa thuốc", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                _doctorBUS.DeletePrescription(item.PrescriptionID);
                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa toa: " + ex.Message, "Toa thuốc", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ViewPrescription(PrescriptionDTO item)
        {
            frmPrescriptionDetail frm = new();
            frm.lblPatientName.Text = item.PatientName;
            frm.lblPrescriptionDate.Text = item.CreatedAt.ToString("dd/MM/yyyy");
            frm.rtbMedicines.Text = BuildMedicineText(item);
            frm.rtbNote.Text = BuildNoteText(item);
            frm.ShowDialog();
        }

        private static string BuildMedicineText(PrescriptionDTO prescription)
        {
            StringBuilder sb = new();
            foreach (PrescriptionItemDTO item in prescription.Items ?? new List<PrescriptionItemDTO>())
            {
                sb.AppendLine(item.MedicineName);
                sb.AppendLine("Lieu dung: " + item.Dosage);
                if (!string.IsNullOrWhiteSpace(item.Frequency)) sb.AppendLine("Tan suat: " + item.Frequency);
                sb.AppendLine("So luong: " + item.Quantity + " " + item.MedicineUnit);
                if (!string.IsNullOrWhiteSpace(item.Instruction)) sb.AppendLine("Huong dan: " + item.Instruction);
                sb.AppendLine();
            }
            return sb.ToString().Trim();
        }

        private static string BuildNoteText(PrescriptionDTO prescription)
        {
            string diagnosis = string.IsNullOrWhiteSpace(prescription.Diagnosis) ? "" : "Chan doan: " + prescription.Diagnosis;
            string note = prescription.DoctorNotes ?? "";
            return string.Join(Environment.NewLine, new[] { diagnosis, note }.Where(x => !string.IsNullOrWhiteSpace(x)));
        }

        private static bool IsCompleted(string status)
        {
            return string.Equals(status, "Completed", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(status, "Da cap phat", StringComparison.OrdinalIgnoreCase) ||
                   status?.Contains("Đã") == true;
        }
    }
}