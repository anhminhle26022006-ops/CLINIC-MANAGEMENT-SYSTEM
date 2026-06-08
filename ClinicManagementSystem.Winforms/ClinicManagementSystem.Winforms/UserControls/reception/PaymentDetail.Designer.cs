namespace ClinicManagementSystem.Winforms.UserControls.reception
{
    partial class PaymentDetail
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            lblInvoiceID = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            tableLayoutPanel4 = new TableLayoutPanel();
            lblPaymentMethod = new Label();
            lblTotal = new Label();
            label2 = new Label();
            btnCash = new TableLayoutPanel();
            button2 = new Button();
            btnQR = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            btnCash.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(604, 570);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 2);
            tableLayoutPanel1.Controls.Add(btnCash, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 110F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.Size = new Size(574, 540);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.34507F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.65493F));
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(lblInvoiceID, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(568, 36);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 36);
            label1.TabIndex = 0;
            label1.Text = "Chi tiết hóa đơn";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblInvoiceID
            // 
            lblInvoiceID.AutoSize = true;
            lblInvoiceID.Dock = DockStyle.Fill;
            lblInvoiceID.Location = new Point(164, 0);
            lblInvoiceID.Name = "lblInvoiceID";
            lblInvoiceID.Size = new Size(401, 36);
            lblInvoiceID.TabIndex = 1;
            lblInvoiceID.Text = "NHĐ";
            lblInvoiceID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(568, 322);
            dataGridView1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.MediumBlue;
            panel2.Controls.Add(tableLayoutPanel4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 373);
            panel2.Name = "panel2";
            panel2.Size = new Size(568, 104);
            panel2.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(lblPaymentMethod, 0, 2);
            tableLayoutPanel4.Controls.Add(lblTotal, 0, 1);
            tableLayoutPanel4.Controls.Add(label2, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel4.Size = new Size(568, 104);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Dock = DockStyle.Fill;
            lblPaymentMethod.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPaymentMethod.ForeColor = Color.White;
            lblPaymentMethod.Location = new Point(3, 73);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(562, 31);
            lblPaymentMethod.TabIndex = 4;
            lblPaymentMethod.Text = "Phương thức thanh toán:";
            lblPaymentMethod.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Dock = DockStyle.Fill;
            lblTotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.Gold;
            lblTotal.Location = new Point(3, 24);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(562, 49);
            lblTotal.TabIndex = 3;
            lblTotal.Text = "NHĐ";
            lblTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(562, 24);
            label2.TabIndex = 2;
            label2.Text = "Tổng tiền phải thanh toán";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnCash
            // 
            btnCash.ColumnCount = 3;
            btnCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            btnCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            btnCash.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            btnCash.Controls.Add(button2, 2, 0);
            btnCash.Controls.Add(btnQR, 1, 0);
            btnCash.Controls.Add(button1, 0, 0);
            btnCash.Dock = DockStyle.Fill;
            btnCash.Location = new Point(3, 483);
            btnCash.Name = "btnCash";
            btnCash.RowCount = 1;
            btnCash.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            btnCash.Size = new Size(568, 54);
            btnCash.TabIndex = 3;
            // 
            // button2
            // 
            button2.BackColor = Color.Honeydew;
            button2.Dock = DockStyle.Fill;
            button2.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(381, 3);
            button2.Name = "button2";
            button2.Size = new Size(184, 48);
            button2.TabIndex = 2;
            button2.Text = "Xác nhận thanh toán";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnQR
            // 
            btnQR.BackColor = Color.SeaShell;
            btnQR.Dock = DockStyle.Fill;
            btnQR.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQR.Location = new Point(192, 3);
            btnQR.Name = "btnQR";
            btnQR.Size = new Size(183, 48);
            btnQR.TabIndex = 1;
            btnQR.Text = "Chuyển khoản";
            btnQR.UseVisualStyleBackColor = false;
            btnQR.Click += btnQR_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.MistyRose;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(183, 48);
            button1.TabIndex = 0;
            button1.Text = "Tiền mặt";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // PaymentDetail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "PaymentDetail";
            Size = new Size(604, 570);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            btnCash.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dataGridView1;
        private Panel panel2;
        private TableLayoutPanel btnCash;
        private Label label1;
        private Label lblInvoiceID;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnQR;
        private Button button1;
        private Label lblPaymentMethod;
        private Label lblTotal;
        private Label label2;
        private Button button2;
    }
}
