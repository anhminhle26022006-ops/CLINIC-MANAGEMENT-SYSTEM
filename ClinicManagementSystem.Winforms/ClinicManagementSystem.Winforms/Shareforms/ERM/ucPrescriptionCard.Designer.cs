namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucPrescriptionCard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlHeader;

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblDate;

        private System.Windows.Forms.Label lblDoctorTitle;
        private System.Windows.Forms.Label lblDoctor;

        private System.Windows.Forms.Button btnPrint;

        private System.Windows.Forms.DataGridView dgvMedicines;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnPrint = new Button();
            lblDateTitle = new Label();
            lblDate = new Label();
            lblDoctorTitle = new Label();
            lblDoctor = new Label();
            dgvMedicines = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnPrint);
            pnlHeader.Controls.Add(lblDateTitle);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblDoctorTitle);
            pnlHeader.Controls.Add(lblDoctor);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1519, 110);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(126, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TOA THUỐC";
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.RoyalBlue;
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(1399, 15);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(100, 35);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "In toa";
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateTitle.Location = new Point(15, 65);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(50, 20);
            lblDateTitle.TabIndex = 2;
            lblDateTitle.Text = "Ngày:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(80, 65);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 3;
            lblDate.Text = "07/06/2026";
            // 
            // lblDoctorTitle
            // 
            lblDoctorTitle.AutoSize = true;
            lblDoctorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDoctorTitle.Location = new Point(250, 65);
            lblDoctorTitle.Name = "lblDoctorTitle";
            lblDoctorTitle.Size = new Size(53, 20);
            lblDoctorTitle.TabIndex = 4;
            lblDoctorTitle.Text = "Bác sĩ:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(320, 65);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(95, 20);
            lblDoctor.TabIndex = 5;
            lblDoctor.Text = "BS Trần Minh";
            // 
            // dgvMedicines
            // 
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AllowUserToDeleteRows = false;
            dgvMedicines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicines.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMedicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMedicines.ColumnHeadersHeight = 40;
            dgvMedicines.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvMedicines.Dock = DockStyle.Fill;
            dgvMedicines.EnableHeadersVisualStyles = false;
            dgvMedicines.Location = new Point(0, 110);
            dgvMedicines.Name = "dgvMedicines";
            dgvMedicines.ReadOnly = true;
            dgvMedicines.RowHeadersVisible = false;
            dgvMedicines.RowHeadersWidth = 51;
            dgvMedicines.RowTemplate.Height = 35;
            dgvMedicines.Size = new Size(1519, 268);
            dgvMedicines.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Tên thuốc";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Liều dùng";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Tần suất";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Số lượng";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Hướng dẫn";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // ucPrescriptionCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(dgvMedicines);
            Controls.Add(pnlHeader);
            Name = "ucPrescriptionCard";
            Size = new Size(1519, 378);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}