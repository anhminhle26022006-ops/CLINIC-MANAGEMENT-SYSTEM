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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panelOuter = new Panel();
            lblPaging = new Label();
            dgvDepartments = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colDesc = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewTextBoxColumn();
            colDelete = new DataGridViewTextBoxColumn();
            panelToolbar = new Panel();
            txtSearch = new TextBox();
            panelKPI = new Panel();
            cardTotal = new Panel();
            lblDeptTotalTitle = new Label();
            lblDeptTotalValue = new Label();
            lblDeptTotalIcon = new Label();
            cardActive = new Panel();
            lblDeptActiveTitle = new Label();
            lblDeptActiveValue = new Label();
            lblDeptActiveIcon = new Label();
            cardInactive = new Panel();
            lblDeptInactiveTitle = new Label();
            lblDeptInactiveValue = new Label();
            lblDeptInactiveIcon = new Label();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnAdd = new Button();
            panelOuter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
            panelToolbar.SuspendLayout();
            panelKPI.SuspendLayout();
            cardTotal.SuspendLayout();
            cardActive.SuspendLayout();
            cardInactive.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelOuter
            // 
            panelOuter.BackColor = Color.FromArgb(247, 249, 252);
            panelOuter.Controls.Add(lblPaging);
            panelOuter.Controls.Add(dgvDepartments);
            panelOuter.Controls.Add(panelToolbar);
            panelOuter.Controls.Add(panelKPI);
            panelOuter.Controls.Add(panelHeader);
            panelOuter.Dock = DockStyle.Fill;
            panelOuter.Location = new Point(0, 0);
            panelOuter.Margin = new Padding(2);
            panelOuter.Name = "panelOuter";
            panelOuter.Padding = new Padding(24, 20, 24, 16);
            panelOuter.Size = new Size(960, 560);
            panelOuter.TabIndex = 0;
            // 
            // lblPaging
            // 
            lblPaging.Dock = DockStyle.Bottom;
            lblPaging.Font = new Font("Segoe UI", 9F);
            lblPaging.ForeColor = Color.FromArgb(107, 114, 128);
            lblPaging.Location = new Point(24, 518);
            lblPaging.Margin = new Padding(2, 0, 2, 0);
            lblPaging.Name = "lblPaging";
            lblPaging.Size = new Size(912, 26);
            lblPaging.TabIndex = 0;
            lblPaging.Text = "Đang tải...";
            lblPaging.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDepartments
            // 
            dgvDepartments.AllowUserToAddRows = false;
            dgvDepartments.AllowUserToDeleteRows = false;
            dgvDepartments.BackgroundColor = Color.White;
            dgvDepartments.BorderStyle = BorderStyle.None;
            dgvDepartments.ColumnHeadersHeight = 29;
            dgvDepartments.Columns.AddRange(new DataGridViewColumn[] { colID, colName, colDesc, colStatus, colEdit, colDelete });
            dgvDepartments.Dock = DockStyle.Fill;
            dgvDepartments.Font = new Font("Segoe UI", 9.5F);
            dgvDepartments.Location = new Point(24, 223);
            dgvDepartments.Margin = new Padding(2);
            dgvDepartments.Name = "dgvDepartments";
            dgvDepartments.ReadOnly = true;
            dgvDepartments.RowHeadersVisible = false;
            dgvDepartments.RowHeadersWidth = 51;
            dgvDepartments.RowTemplate.Height = 48;
            dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDepartments.Size = new Size(912, 321);
            dgvDepartments.TabIndex = 1;
            dgvDepartments.CellClick += dgvDepartments_CellClick;
            dgvDepartments.CellFormatting += dgvDepartments_CellFormatting;
            dgvDepartments.CellPainting += dgvDepartments_CellPainting;
            // 
            // colID
            // 
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            colID.Visible = false;
            colID.Width = 60;
            // 
            // colName
            // 
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            colName.DefaultCellStyle = dataGridViewCellStyle1;
            colName.HeaderText = "Tên chuyên khoa";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            colName.Width = 260;
            // 
            // colDesc
            // 
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(107, 114, 128);
            colDesc.DefaultCellStyle = dataGridViewCellStyle2;
            colDesc.HeaderText = "Mô tả";
            colDesc.MinimumWidth = 6;
            colDesc.Name = "colDesc";
            colDesc.ReadOnly = true;
            colDesc.Width = 380;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Trạng thái";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            colStatus.Width = 140;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "";
            colEdit.MinimumWidth = 6;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Width = 50;
            // 
            // colDelete
            // 
            colDelete.HeaderText = "";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Width = 50;
            // 
            // panelToolbar
            // 
            panelToolbar.BackColor = Color.White;
            panelToolbar.Controls.Add(txtSearch);
            panelToolbar.Dock = DockStyle.Top;
            panelToolbar.Location = new Point(24, 178);
            panelToolbar.Margin = new Padding(2);
            panelToolbar.Name = "panelToolbar";
            panelToolbar.Padding = new Padding(10, 8, 10, 8);
            panelToolbar.Size = new Size(912, 45);
            panelToolbar.TabIndex = 2;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.BackColor = Color.FromArgb(243, 244, 246);
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(107, 114, 128);
            txtSearch.Location = new Point(10, 11);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍  Tìm kiếm chuyên khoa...";
            txtSearch.Size = new Size(1040, 23);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // panelKPI
            // 
            panelKPI.BackColor = Color.Transparent;
            panelKPI.Controls.Add(cardTotal);
            panelKPI.Controls.Add(cardActive);
            panelKPI.Controls.Add(cardInactive);
            panelKPI.Dock = DockStyle.Top;
            panelKPI.Location = new Point(24, 90);
            panelKPI.Margin = new Padding(2);
            panelKPI.Name = "panelKPI";
            panelKPI.Size = new Size(912, 88);
            panelKPI.TabIndex = 3;
            panelKPI.Resize += panelKPI_Resize;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.FromArgb(219, 234, 254);
            cardTotal.Controls.Add(lblDeptTotalTitle);
            cardTotal.Controls.Add(lblDeptTotalValue);
            cardTotal.Controls.Add(lblDeptTotalIcon);
            cardTotal.Location = new Point(0, 8);
            cardTotal.Margin = new Padding(2);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(208, 72);
            cardTotal.TabIndex = 0;
            cardTotal.Paint += PanelRoundedBorder;
            // 
            // lblDeptTotalTitle
            // 
            lblDeptTotalTitle.Font = new Font("Segoe UI", 9F);
            lblDeptTotalTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblDeptTotalTitle.Location = new Point(10, 11);
            lblDeptTotalTitle.Margin = new Padding(2, 0, 2, 0);
            lblDeptTotalTitle.Name = "lblDeptTotalTitle";
            lblDeptTotalTitle.Size = new Size(120, 19);
            lblDeptTotalTitle.TabIndex = 0;
            lblDeptTotalTitle.Text = "Tổng số";
            lblDeptTotalTitle.Click += lblDeptTotalTitle_Click;
            // 
            // lblDeptTotalValue
            // 
            lblDeptTotalValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDeptTotalValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblDeptTotalValue.Location = new Point(10, 19);
            lblDeptTotalValue.Margin = new Padding(2, 0, 2, 0);
            lblDeptTotalValue.Name = "lblDeptTotalValue";
            lblDeptTotalValue.Size = new Size(60, 51);
            lblDeptTotalValue.TabIndex = 1;
            lblDeptTotalValue.Text = "0";
            // 
            // lblDeptTotalIcon
            // 
            lblDeptTotalIcon.BackColor = Color.White;
            lblDeptTotalIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeptTotalIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblDeptTotalIcon.Location = new Point(152, 16);
            lblDeptTotalIcon.Margin = new Padding(2, 0, 2, 0);
            lblDeptTotalIcon.Name = "lblDeptTotalIcon";
            lblDeptTotalIcon.Size = new Size(37, 37);
            lblDeptTotalIcon.TabIndex = 2;
            lblDeptTotalIcon.Text = "TS";
            lblDeptTotalIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardActive
            // 
            cardActive.BackColor = Color.FromArgb(209, 250, 229);
            cardActive.Controls.Add(lblDeptActiveTitle);
            cardActive.Controls.Add(lblDeptActiveValue);
            cardActive.Controls.Add(lblDeptActiveIcon);
            cardActive.Location = new Point(221, 8);
            cardActive.Margin = new Padding(2);
            cardActive.Name = "cardActive";
            cardActive.Size = new Size(208, 72);
            cardActive.TabIndex = 1;
            cardActive.Paint += PanelRoundedBorder;
            // 
            // lblDeptActiveTitle
            // 
            lblDeptActiveTitle.Font = new Font("Segoe UI", 9F);
            lblDeptActiveTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblDeptActiveTitle.Location = new Point(13, 11);
            lblDeptActiveTitle.Margin = new Padding(2, 0, 2, 0);
            lblDeptActiveTitle.Name = "lblDeptActiveTitle";
            lblDeptActiveTitle.Size = new Size(120, 19);
            lblDeptActiveTitle.TabIndex = 0;
            lblDeptActiveTitle.Text = "Đang hoạt động";
            // 
            // lblDeptActiveValue
            // 
            lblDeptActiveValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDeptActiveValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblDeptActiveValue.Location = new Point(13, 19);
            lblDeptActiveValue.Margin = new Padding(2, 0, 2, 0);
            lblDeptActiveValue.Name = "lblDeptActiveValue";
            lblDeptActiveValue.Size = new Size(96, 51);
            lblDeptActiveValue.TabIndex = 1;
            lblDeptActiveValue.Text = "0";
            // 
            // lblDeptActiveIcon
            // 
            lblDeptActiveIcon.BackColor = Color.White;
            lblDeptActiveIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeptActiveIcon.ForeColor = Color.FromArgb(5, 150, 105);
            lblDeptActiveIcon.Location = new Point(152, 16);
            lblDeptActiveIcon.Margin = new Padding(2, 0, 2, 0);
            lblDeptActiveIcon.Name = "lblDeptActiveIcon";
            lblDeptActiveIcon.Size = new Size(37, 37);
            lblDeptActiveIcon.TabIndex = 2;
            lblDeptActiveIcon.Text = "HD";
            lblDeptActiveIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardInactive
            // 
            cardInactive.BackColor = Color.FromArgb(254, 226, 226);
            cardInactive.Controls.Add(lblDeptInactiveTitle);
            cardInactive.Controls.Add(lblDeptInactiveValue);
            cardInactive.Controls.Add(lblDeptInactiveIcon);
            cardInactive.Location = new Point(442, 8);
            cardInactive.Margin = new Padding(2);
            cardInactive.Name = "cardInactive";
            cardInactive.Size = new Size(208, 72);
            cardInactive.TabIndex = 2;
            cardInactive.Paint += PanelRoundedBorder;
            // 
            // lblDeptInactiveTitle
            // 
            lblDeptInactiveTitle.Font = new Font("Segoe UI", 9F);
            lblDeptInactiveTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblDeptInactiveTitle.Location = new Point(13, 11);
            lblDeptInactiveTitle.Margin = new Padding(2, 0, 2, 0);
            lblDeptInactiveTitle.Name = "lblDeptInactiveTitle";
            lblDeptInactiveTitle.Size = new Size(128, 19);
            lblDeptInactiveTitle.TabIndex = 0;
            lblDeptInactiveTitle.Text = "Ngừng hoạt động";
            // 
            // lblDeptInactiveValue
            // 
            lblDeptInactiveValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDeptInactiveValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblDeptInactiveValue.Location = new Point(13, 19);
            lblDeptInactiveValue.Margin = new Padding(2, 0, 2, 0);
            lblDeptInactiveValue.Name = "lblDeptInactiveValue";
            lblDeptInactiveValue.Size = new Size(96, 51);
            lblDeptInactiveValue.TabIndex = 1;
            lblDeptInactiveValue.Text = "0";
            // 
            // lblDeptInactiveIcon
            // 
            lblDeptInactiveIcon.BackColor = Color.White;
            lblDeptInactiveIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeptInactiveIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblDeptInactiveIcon.Location = new Point(152, 16);
            lblDeptInactiveIcon.Margin = new Padding(2, 0, 2, 0);
            lblDeptInactiveIcon.Name = "lblDeptInactiveIcon";
            lblDeptInactiveIcon.Size = new Size(37, 37);
            lblDeptInactiveIcon.TabIndex = 2;
            lblDeptInactiveIcon.Text = "NH";
            lblDeptInactiveIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnAdd);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(24, 20);
            panelHeader.Margin = new Padding(2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(912, 70);
            panelHeader.TabIndex = 4;
            panelHeader.Resize += panelHeader_Resize;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý chuyên khoa";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(2, 38);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(364, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý danh sách chuyên khoa trong phòng khám";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.BackColor = Color.FromArgb(47, 94, 240);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1472, 14);
            btnAdd.Margin = new Padding(2);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(160, 40);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "+ Thêm chuyên khoa";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // ucDepartmentManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelOuter);
            Margin = new Padding(2);
            Name = "ucDepartmentManagement";
            Size = new Size(960, 560);
            panelOuter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
            panelToolbar.ResumeLayout(false);
            panelToolbar.PerformLayout();
            panelKPI.ResumeLayout(false);
            cardTotal.ResumeLayout(false);
            cardActive.ResumeLayout(false);
            cardInactive.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        private void panelHeader_Resize(object sender, System.EventArgs e)
        {
            if (btnAdd != null)
                btnAdd.Location = new System.Drawing.Point(panelHeader.Width - btnAdd.Width, 18);
        }

        private void PanelRoundedBorder(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (sender is not System.Windows.Forms.Control control) return;
            using var pen = new System.Drawing.Pen(System.Drawing.Color.FromArgb(229, 231, 235));
            e.Graphics.DrawRectangle(pen, 0, 0, control.Width - 1, control.Height - 1);
        }

        private System.Windows.Forms.Panel panelOuter, panelHeader, panelKPI, panelToolbar;
        private System.Windows.Forms.Label lblTitle, lblSubtitle, lblPaging;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID, colName, colDesc, colStatus, colEdit, colDelete;
        internal System.Windows.Forms.Panel cardTotal, cardActive, cardInactive;
        private System.Windows.Forms.Label lblDeptTotalTitle, lblDeptTotalValue, lblDeptTotalIcon;
        private System.Windows.Forms.Label lblDeptActiveTitle, lblDeptActiveValue, lblDeptActiveIcon;
        private System.Windows.Forms.Label lblDeptInactiveTitle, lblDeptInactiveValue, lblDeptInactiveIcon;
    }
}
