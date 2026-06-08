using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Controllers;
using DTO;

namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    public partial class HistoryPayment : UserControl
    {
        private readonly PaymentController
            controller = new();

        public HistoryPayment()
        {
            InitializeComponent();

            ConfigureGrid();

            LoadHistory();
        }

        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Mã thanh toán",
                    DataPropertyName = "PaymentID"
                });

            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Mã khám",
                    DataPropertyName = "EncounterID"
                });

            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Tên bệnh nhân",
                    DataPropertyName = "PatientName"
                });

            dataGridView1.Columns.Add(
    new DataGridViewTextBoxColumn
    {
        Name = "PaidAt",
        HeaderText = "Ngày TT",
        DataPropertyName = "PaidAt"
    });

            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Phương thức",
                    DataPropertyName = "Method"
                });

            dataGridView1.Columns.Add(
    new DataGridViewTextBoxColumn
    {
        Name = "Amount",
        HeaderText = "Tổng tiền",
        DataPropertyName = "Amount"
    });

            dataGridView1.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    HeaderText = "Trạng thái",
                    DataPropertyName = "Status"
                });
        }

        private void LoadHistory()
        {
            var payments =
                controller.GetPaymentHistory();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = payments;

            if (dataGridView1.Columns["Amount"] != null)
            {
                dataGridView1.Columns["Amount"]
                    .DefaultCellStyle.Format = "N0";
            }

            if (dataGridView1.Columns["PaidAt"] != null)
            {
                dataGridView1.Columns["PaidAt"]
                    .DefaultCellStyle.Format =
                    "dd/MM/yyyy HH:mm";
            }
        }

        private void textBox1_TextChanged(
            object sender,
            EventArgs e)
        {
            string keyword =
                textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(
                keyword))
            {
                LoadHistory();

                return;
            }

            dataGridView1.DataSource =
                controller
                .SearchPaymentHistory(
                    keyword);
        }

        private void DataGridView1_CellFormatting(
    object sender,
    DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex]
                .DataPropertyName == "Status")
            {
                if (e.Value?.ToString() == "Paid")
                {
                    e.Value = "Đã thanh toán";

                    e.CellStyle.BackColor =
                        Color.FromArgb(220, 252, 231);

                    e.CellStyle.ForeColor =
                        Color.Green;

                    e.CellStyle.SelectionBackColor =
                        Color.FromArgb(220, 252, 231);
                }
            }

            if (dataGridView1.Columns[e.ColumnIndex]
                .DataPropertyName == "Method")
            {
                if (e.Value?.ToString() == "Tiền mặt")
                {
                    e.CellStyle.BackColor =
                        Color.FromArgb(220, 252, 231);

                    e.CellStyle.ForeColor =
                        Color.Green;
                }
                else if (e.Value?.ToString()
                         == "Chuyển khoản")
                {
                    e.CellStyle.BackColor =
                        Color.FromArgb(219, 234, 254);

                    e.CellStyle.ForeColor =
                        Color.RoyalBlue;
                }
            }
        }
    }
}