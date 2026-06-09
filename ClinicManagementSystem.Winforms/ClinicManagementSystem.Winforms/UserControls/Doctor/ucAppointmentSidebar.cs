using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public ucAppointmentSidebar()
        {
            InitializeComponent();
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;

            LoadFakeData();
        }
        private void LoadFakeData()
        {
            dgvAppointments.Rows.Clear();

            string[,] data =
            {
        {"08:00","Nguyễn Văn An","Tim mạch","120/80","Chờ tiếp nhận"},
        {"08:30","Lê Thị Mai","Nội tổng quát","118/75","Đang khám"},
        {"09:00","Trần Văn Bình","Da liễu","122/82","Hoàn thành"},
        {"09:30","Phạm Minh Khôi","Tai Mũi Họng","115/78","Chờ tiếp nhận"},
        {"10:00","Nguyễn Ngọc Anh","Nhi khoa","110/70","Đang khám"},
        {"10:30","Hoàng Gia Hân","Mắt","118/76","Hoàn thành"},
        {"11:00","Đặng Quốc Huy","Tim mạch","130/85","Chờ tiếp nhận"},
        {"13:30","Bùi Thanh Tâm","Nội tiết","125/80","Đang khám"}
    };

            for (int i = 0; i < data.GetLength(0); i++)
            {
                dgvAppointments.Rows.Add(
                    data[i, 0],
                    data[i, 1],
                    data[i, 2],
                    data[i, 3],
                    data[i, 4]
                );
            }

            lblTodayCount.Text = "25";
            lblWaitingCount.Text = "8";
            lblExaminingCount.Text = "5";
            lblCompletedCount.Text = "12";
        }
        private void dgvAppointments_CellFormatting(
    object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAppointments.Columns[e.ColumnIndex].Name != "colStatus")
                return;

            string status = e.Value?.ToString();

            if (status == "Chờ tiếp nhận")
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(254, 243, 199);

                e.CellStyle.ForeColor =
                    Color.FromArgb(180, 83, 9);
            }
            else if (status == "Đang khám")
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(209, 250, 229);

                e.CellStyle.ForeColor =
                    Color.FromArgb(4, 120, 87);
            }
            else if (status == "Hoàn thành")
            {
                e.CellStyle.BackColor =
                    Color.FromArgb(229, 231, 235);

                e.CellStyle.ForeColor =
                    Color.FromArgb(75, 85, 99);
            }
        }
    }
}
