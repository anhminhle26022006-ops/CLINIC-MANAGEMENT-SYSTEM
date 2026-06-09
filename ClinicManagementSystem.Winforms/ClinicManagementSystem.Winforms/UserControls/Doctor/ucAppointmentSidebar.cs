using BUS.Services;
using BUS.Services.Doctor;
using ClinicManagementSystem.Winforms.Controllers;
using ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh;
using DAL.Repositories;
using DAL.Repositories.Doctor;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor
{
    public partial class ucAppointmentSidebar : UserControl
    {
        private DoctorAppointmentController _controller;
       
        public ucAppointmentSidebar()
        {
            InitializeComponent();
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            dgvAppointments.CellContentClick += dgvAppointments_CellContentClick;
           
            string connStr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            var repo = new AppointmentRepository(connStr);
            var service = new AppointmentService(repo);
            _controller = new DoctorAppointmentController(service);

            LoadData();


        }
        
        private void LoadData()
        {
            var data = _controller.LoadToday();

            dgvAppointments.Rows.Clear();

            foreach (var item in data)
            {
                dgvAppointments.Rows.Add(
                    item.AppointmentDate.ToString("HH:mm"),
                    item.PatientName,
                    item.DepartmentName,
                    item.VitalSummary,
                    item.Status
                );
            }

            lblTodayCount.Text = data.Count.ToString();
            lblWaitingCount.Text = _controller.Waiting().ToString();
            lblExaminingCount.Text = _controller.Examining().ToString();
            lblCompletedCount.Text = _controller.Completed().ToString();
        }
        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvAppointments.Columns[e.ColumnIndex].Name != "btnExamine")
                return;

            var row = dgvAppointments.Rows[e.RowIndex];

            var patientName = row.Cells[1].Value?.ToString();
            var department = row.Cells[2].Value?.ToString();
            var time = row.Cells[0].Value?.ToString();
            var status = row.Cells[4].Value?.ToString();

            // mở form khám hoặc sidebar khám
            var appointmentId = _controller.LoadToday()[e.RowIndex].AppointmentID;

            OpenExamination(appointmentId);
        }
        private void OpenExamination(int appointmentId)
        {
            var examSidebar = new ucDoctorExaminationSidebar();

            examSidebar.LoadPatientByAppointment(appointmentId);

            var form = this.FindForm();

            var pnlContent = form.Controls.Find("contentPanel", true)
                                           .FirstOrDefault() as Panel;

            if (pnlContent == null)
            {
                MessageBox.Show("Không tìm thấy contentPanel!");
                return;
            }

            pnlContent.Controls.Clear();
            examSidebar.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(examSidebar);
        }

        private void dgvAppointments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointments.Columns[e.ColumnIndex].Name != "colStatus")
                return;

            var status = e.Value?.ToString();
            if (string.IsNullOrEmpty(status)) return;

            if (status == "Chờ tiếp nhận")
            {
                e.CellStyle.BackColor = Color.FromArgb(254, 243, 199);
                e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);
            }
            else if (status == "Đang khám")
            {
                e.CellStyle.BackColor = Color.FromArgb(209, 250, 229);
                e.CellStyle.ForeColor = Color.FromArgb(4, 120, 87);
            }
            else if (status == "Hoàn thành")
            {
                e.CellStyle.BackColor = Color.FromArgb(229, 231, 235);
                e.CellStyle.ForeColor = Color.FromArgb(75, 85, 99);
            }
        }
        
    }
}
