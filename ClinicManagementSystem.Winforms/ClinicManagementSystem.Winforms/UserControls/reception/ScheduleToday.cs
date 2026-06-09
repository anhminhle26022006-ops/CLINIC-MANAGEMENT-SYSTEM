using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.Services;
using ClinicManagementSystem.Winforms.Controllers;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class ScheduleToday : UserControl
    {
        private readonly ScheduleTodayController controller =
            new();

        public ScheduleToday()
        {
            InitializeComponent();
        }

        private void ScheduleToday_Load(object sender, EventArgs e)
        {
            SetupCards();
            SetupUI();
            LoadStatistics();
            LoadAppointments();
            dgvAppointment.ClearSelection();
            cbDepartment.Items.Clear();

            cbDepartment.Items.Add("Tất cả chuyên khoa");

            cbDepartment.Items.Add("Tim mạch");
            cbDepartment.Items.Add("Nhi khoa");
            cbDepartment.Items.Add("Da liễu");

            cbDepartment.SelectedIndex = 0;

            cbStatus.Items.Clear();

            cbStatus.Items.Add("Tất cả trạng thái");
            cbStatus.Items.Add("Chờ tiếp nhận");
            cbStatus.Items.Add("Đã tiếp nhận");
            cbStatus.Items.Add("Đang khám");
            cbStatus.Items.Add("Hoàn thành");

            cbStatus.SelectedIndex = 0;
            lbDate.Text =
                DateTime.Now.ToString("dd/MM/yyyy");
        }

        private string GetStatusValue()
        {
            return cbStatus.Text switch
            {
                "Chờ tiếp nhận" => "Waiting",
                "Đã tiếp nhận" => "Received",
                "Đang khám" => "Examining",
                "Hoàn thành" => "Completed",
                _ => ""
            };
        }

        private void dgvAppointment_CellFormatting(
    object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointment.Columns[e.ColumnIndex].Name == "Trạng thái")
            {
                switch (e.Value?.ToString())
                {
                    case "Waiting":
                        e.Value = "Chờ tiếp nhận";
                        break;

                    case "Received":
                        e.Value = "Đã tiếp nhận";
                        break;

                    case "Examining":
                        e.Value = "Đang khám";
                        break;

                    case "Completed":
                        e.Value = "Hoàn thành";
                        break;
                }
            }
            if (dgvAppointment.Columns[e.ColumnIndex].Name == "colAction")
            {
                string status =
                    dgvAppointment.Rows[e.RowIndex]
                    .Cells["Trạng thái"]
                    .Value?.ToString();

                if (status != "Waiting" &&
                    status != "Chờ tiếp nhận")
                {
                    e.Value = "";
                }
                else
                {
                    e.Value = "Tiếp nhận";
                }
            }
        }

        private void SetupCards()
        {
            panel5.BackColor = Color.FromArgb(239, 246, 255);
            panel7.BackColor = Color.FromArgb(254, 252, 232);
            panel9.BackColor = Color.FromArgb(240, 253, 244);
            panel11.BackColor = Color.FromArgb(250, 245, 255);
            panel13.BackColor = Color.White;

            StyleNumberLabel(lbTotal, Color.FromArgb(37, 99, 235));
            StyleNumberLabel(lbWait, Color.FromArgb(217, 119, 6));
            StyleNumberLabel(lbReceiv, Color.FromArgb(22, 163, 74));
            StyleNumberLabel(lbDoing, Color.FromArgb(147, 51, 234));
            StyleNumberLabel(lbDone, Color.FromArgb(75, 85, 99));
        }

        private void StyleNumberLabel(Label lbl, Color color)
        {
            lbl.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lbl.ForeColor = color;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void SetupUI()
        {
            label1.Font = new Font("Segoe UI", 18, FontStyle.Bold);

            label2.Font = new Font("Segoe UI", 10);
            label2.ForeColor = Color.Gray;

            lbDate.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            textBox1.Font = new Font("Segoe UI", 11);

            cbDepartment.Font = new Font("Segoe UI", 10);
            cbStatus.Font = new Font("Segoe UI", 10);

            panel18.BackColor = Color.White;

            dgvAppointment.BorderStyle = BorderStyle.None;
            dgvAppointment.BackgroundColor = Color.White;

            dgvAppointment.RowHeadersVisible = false;

            dgvAppointment.AllowUserToAddRows = false;
            dgvAppointment.AllowUserToDeleteRows = false;

            dgvAppointment.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAppointment.MultiSelect = false;

            dgvAppointment.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvAppointment.EnableHeadersVisualStyles = false;

            dgvAppointment.ColumnHeadersHeight = 50;

            dgvAppointment.ColumnHeadersDefaultCellStyle.BackColor =
                Color.White;

            dgvAppointment.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(71, 85, 105);

            dgvAppointment.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvAppointment.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvAppointment.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(239, 246, 255);

            dgvAppointment.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvAppointment.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAppointment.GridColor =
                Color.FromArgb(241, 245, 249);

            dgvAppointment.RowTemplate.Height = 55;
        }

        private void LoadStatistics()
        {
            lbTotal.Text =
                controller.GetTotalToday().ToString();

            lbWait.Text =
                controller.GetWaitingToday().ToString();

            lbReceiv.Text =
                controller.GetReceivedToday().ToString();

            lbDoing.Text =
                controller.GetExaminingToday().ToString();

            lbDone.Text =
                controller.GetCompletedToday().ToString();
        }

        private void LoadAppointments()
        {
            dgvAppointment.DataSource =
                controller.GetAppointmentsToday();

            SetupActionColumn();
        }

        private void SetupActionColumn()
        {
            if (dgvAppointment.Columns["colAction"] != null)
                return;

            DataGridViewButtonColumn btnAction =
                new DataGridViewButtonColumn();

            btnAction.Name = "colAction";
            btnAction.HeaderText = "THAO TÁC";

            btnAction.Text = "Tiếp nhận";

            btnAction.UseColumnTextForButtonValue = true;

            dgvAppointment.Columns.Add(btnAction);

            dgvAppointment.Columns["AppointmentID"].Visible = false;

            dgvAppointment.Columns["colAction"].FillWeight = 80;
            btnAction.DefaultCellStyle.ForeColor =
    Color.Black;

            btnAction.DefaultCellStyle.SelectionForeColor =
                Color.Black;
        }

        /*  private void UpdateActionButtons()
          {
              foreach (DataGridViewRow row in dgvAppointment.Rows)
              {
                  string status =
                      row.Cells["Trạng thái"]
                         .Value?.ToString();

                  if (status == "Waiting" ||
                      status == "Chờ tiếp nhận")
                  {
                      row.Cells["colAction"].Value =
                          "Tiếp nhận";

                      MessageBox.Show(
                          row.Cells["colAction"].Value?.ToString());
                  }
              }
          }*/

        private void dgvAppointment_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAppointment.Columns[e.ColumnIndex].Name
                == "colAction")
            {
                int appointmentId =
                    Convert.ToInt32(
                        dgvAppointment.Rows[e.RowIndex]
                        .Cells["AppointmentID"]
                        .Value);
                string status =
    dgvAppointment.Rows[e.RowIndex]
    .Cells["Trạng thái"]
    .Value.ToString();

                if (status != "Waiting" &&
    status != "Chờ tiếp nhận")
                {
                    return;
                }

                bool success =
                    controller.ReceiveAppointment(
                        appointmentId);

                if (success)
                {
                    LoadAppointments();
                    LoadStatistics();
                    dgvAppointment.ClearSelection();
                }
            }
        }

        private void FilterAppointments()
        {
            string keyword =
                textBox1.Text.Trim();

            string department =
                cbDepartment.SelectedIndex <= 0
                ? ""
                : cbDepartment.Text;

            string status = GetStatusValue();

            dgvAppointment.DataSource =
                controller.SearchAppointments(
                    keyword,
                    department,
                    status);

            SetupActionColumn();

            //   UpdateActionButtons();
        }

        private void textBox1_TextChanged(
    object sender,
    EventArgs e)
        {
            FilterAppointments();
        }

        private void cbDepartment_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            FilterAppointments();
        }

        private void cbStatus_SelectedIndexChanged(
    object sender,
    EventArgs e)
        {
            FilterAppointments();
        }
    }
}
