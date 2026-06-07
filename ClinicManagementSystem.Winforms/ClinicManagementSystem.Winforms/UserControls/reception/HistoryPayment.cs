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
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.EnableHeadersVisualStyles =
                false;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .BackColor = Color.RoyalBlue;

            dataGridView1.ColumnHeadersDefaultCellStyle
                .ForeColor = Color.White;
        }

        private void LoadHistory()
        {
            List<PaymentDTO> payments =
                controller
                .GetPaymentHistory();

            dataGridView1.DataSource =
                payments;
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
    }
}