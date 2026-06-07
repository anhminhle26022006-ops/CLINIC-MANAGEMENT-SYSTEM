namespace ClinicManagementSystem.Winforms.Forms.Integrations
{
    partial class MockApiSyncForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPatients = new DataGridView();
            dgvEmployees = new DataGridView();
            lblPatientsTitle = new Label();
            lblEmployeesTitle = new Label();
            btnSync = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            SuspendLayout();
            // 
            // dgvPatients
            // 
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPatients.Location = new Point(20, 60);
            dgvPatients.Margin = new Padding(3, 4, 3, 4);
            dgvPatients.Name = "dgvPatients";
            dgvPatients.RowHeadersWidth = 51;
            dgvPatients.RowTemplate.Height = 24;
            dgvPatients.Size = new Size(600, 600);
            dgvPatients.TabIndex = 0;
            // 
            // dgvEmployees
            // 
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(660, 60);
            dgvEmployees.Margin = new Padding(3, 4, 3, 4);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.RowTemplate.Height = 24;
            dgvEmployees.Size = new Size(600, 600);
            dgvEmployees.TabIndex = 1;
            // 
            // lblPatientsTitle
            // 
            lblPatientsTitle.AutoSize = true;
            lblPatientsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPatientsTitle.Location = new Point(20, 20);
            lblPatientsTitle.Name = "lblPatientsTitle";
            lblPatientsTitle.Size = new Size(311, 28);
            lblPatientsTitle.TabIndex = 2;
            lblPatientsTitle.Text = "Danh sách Bệnh nhân đồng bộ";
            // 
            // lblEmployeesTitle
            // 
            lblEmployeesTitle.AutoSize = true;
            lblEmployeesTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEmployeesTitle.Location = new Point(660, 20);
            lblEmployeesTitle.Name = "lblEmployeesTitle";
            lblEmployeesTitle.Size = new Size(393, 28);
            lblEmployeesTitle.TabIndex = 3;
            lblEmployeesTitle.Text = "Danh sách Bác sĩ / Nhân viên đồng bộ";
            // 
            // btnSync
            // 
            btnSync.Location = new Point(20, 685);
            btnSync.Margin = new Padding(3, 4, 3, 4);
            btnSync.Name = "btnSync";
            btnSync.Size = new Size(200, 45);
            btnSync.TabIndex = 4;
            btnSync.Text = "Đồng bộ API";
            btnSync.UseVisualStyleBackColor = true;
            btnSync.Click += btnSync_Click;
            // 
            // MockApiSyncForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1280, 760);
            Controls.Add(lblEmployeesTitle);
            Controls.Add(lblPatientsTitle);
            Controls.Add(btnSync);
            Controls.Add(dgvPatients);
            Controls.Add(dgvEmployees);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MockApiSyncForm";
            Text = "Mock API Sync Dashboard";
            Load += MockApiSyncForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPatients;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.Label lblPatientsTitle;
        private System.Windows.Forms.Label lblEmployeesTitle;
        private System.Windows.Forms.Button btnSync;
    }
}


