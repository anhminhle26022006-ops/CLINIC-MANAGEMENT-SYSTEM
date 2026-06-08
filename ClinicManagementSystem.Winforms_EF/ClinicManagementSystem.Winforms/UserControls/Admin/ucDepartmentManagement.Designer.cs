namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucDepartmentManagement
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelOuter = new System.Windows.Forms.Panel();
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            btnAdd = new System.Windows.Forms.Button();
            panelKPI = new System.Windows.Forms.Panel();
            panelToolbar = new System.Windows.Forms.Panel();
            txtSearch = new System.Windows.Forms.TextBox();
            dgvDepartments = new System.Windows.Forms.DataGridView();
            colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colDelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblPaging = new System.Windows.Forms.Label();
            panelOuter.SuspendLayout();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            SuspendLayout();

            // panelOuter
            panelOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            panelOuter.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            panelOuter.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            panelOuter.Controls.Add(lblPaging);
            panelOuter.Controls.Add(dgvDepartments);
            panelOuter.Controls.Add(panelToolbar);
            panelOuter.Controls.Add(panelKPI);
            panelOuter.Controls.Add(panelHeader);

            // panelHeader
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Height = 88;
            panelHeader.BackColor = System.Drawing.Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAdd);
            panelHeader.Resize += panelHeader_Resize;

            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            lblTitle.Location = new System.Drawing.Point(0, 6);
            lblTitle.Text = "Quản lý chuyên khoa";

            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new System.Drawing.Point(2, 48);
            lblSubtitle.Text = "Quản lý danh sách chuyên khoa trong phòng khám";

            btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAdd.BackColor = System.Drawing.Color.FromArgb(47, 94, 240);
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAdd.Location = new System.Drawing.Point(900, 18);
            btnAdd.Size = new System.Drawing.Size(200, 50);
            btnAdd.Text = "+ Thêm chuyên khoa";
            btnAdd.Click += btnAdd_Click;

            // panelKPI
            panelKPI.Dock = System.Windows.Forms.DockStyle.Top;
            panelKPI.Height = 110;
            panelKPI.BackColor = System.Drawing.Color.Transparent;
            panelKPI.Resize += panelKPI_Resize;
            cardTotal = MakeKpiCard("Tổng số", "0", System.Drawing.Color.FromArgb(37, 99, 235), System.Drawing.Color.FromArgb(219, 234, 254));
            cardActive = MakeKpiCard("Đang hoạt động", "0", System.Drawing.Color.FromArgb(5, 150, 105), System.Drawing.Color.FromArgb(209, 250, 229));
            cardInactive = MakeKpiCard("Ngừng hoạt động", "0", System.Drawing.Color.FromArgb(220, 38, 38), System.Drawing.Color.FromArgb(254, 226, 226));
            panelKPI.Controls.Add(cardTotal);
            panelKPI.Controls.Add(cardActive);
            panelKPI.Controls.Add(cardInactive);

            // panelToolbar
            panelToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            panelToolbar.Height = 56;
            panelToolbar.BackColor = System.Drawing.Color.White;
            panelToolbar.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            panelToolbar.Controls.Add(txtSearch);

            txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtSearch.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            txtSearch.Location = new System.Drawing.Point(12, 14);
            txtSearch.Size = new System.Drawing.Size(360, 28);
            txtSearch.PlaceholderText = "🔍  Tìm kiếm chuyên khoa...";
            txtSearch.TextChanged += txtSearch_TextChanged;

            // dgvDepartments
            dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDepartments.BackgroundColor = System.Drawing.Color.White;
            dgvDepartments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvDepartments.RowHeadersVisible = false;
            dgvDepartments.AutoGenerateColumns = false;
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;
            dgvDepartments.ReadOnly = true;
            dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvDepartments.RowTemplate.Height = 48;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
            dgvDepartments.CellFormatting += dgvDepartments_CellFormatting;
            dgvDepartments.CellPainting += dgvDepartments_CellPainting;
            dgvDepartments.Columns.AddRange(colID, colName, colDesc, colStatus, colEdit, colDelete);

            colID.Name = "colID"; colID.HeaderText = "ID"; colID.Width = 60; colID.Visible = false;
            colName.Name = "colName"; colName.HeaderText = "Tên chuyên khoa"; colName.Width = 260; colName.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            colDesc.Name = "colDesc"; colDesc.HeaderText = "Mô tả"; colDesc.Width = 380; colDesc.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            colStatus.Name = "colStatus"; colStatus.HeaderText = "Trạng thái"; colStatus.Width = 140;
            colEdit.Name = "colEdit"; colEdit.HeaderText = ""; colEdit.Width = 50;
            colDelete.Name = "colDelete"; colDelete.HeaderText = ""; colDelete.Width = 50;

            // lblPaging
            lblPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblPaging.Height = 32;
            lblPaging.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPaging.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblPaging.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblPaging.Text = "Đang tải...";

            // ucDepartmentManagement
            Controls.Add(panelOuter);
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Size = new System.Drawing.Size(1200, 700);

            panelOuter.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel MakeKpiCard(string title, string value, System.Drawing.Color iconColor, System.Drawing.Color bgColor)
        {
            var card = new System.Windows.Forms.Panel
            {
                Size = new System.Drawing.Size(260, 90),
                BackColor = bgColor,
                Cursor = System.Windows.Forms.Cursors.Default
            };
            card.Controls.Add(new System.Windows.Forms.Label
            {
                Text = title,
                Font = new System.Drawing.Font("Segoe UI", 9F),
                ForeColor = iconColor,
                Location = new System.Drawing.Point(14, 14),
                AutoSize = true
            });
            var valLbl = new System.Windows.Forms.Label
            {
                Text = value,
                Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold),
                ForeColor = iconColor,
                Location = new System.Drawing.Point(14, 38),
                AutoSize = true,
                Tag = "value"
            };
            card.Controls.Add(valLbl);
            return card;
        }

        private void panelHeader_Resize(object sender, System.EventArgs e)
        {
            if (btnAdd != null)
                btnAdd.Location = new System.Drawing.Point(panelHeader.Width - btnAdd.Width, 18);
        }

        private System.Windows.Forms.Panel panelOuter, panelHeader, panelKPI, panelToolbar;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblPaging;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID, colName, colDesc, colStatus, colEdit, colDelete;
        internal System.Windows.Forms.Panel cardTotal, cardActive, cardInactive;
    }
}
