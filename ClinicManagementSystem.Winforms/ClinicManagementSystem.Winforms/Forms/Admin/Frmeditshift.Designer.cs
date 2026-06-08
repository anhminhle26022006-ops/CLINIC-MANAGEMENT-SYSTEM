namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmEditShift
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelMain = new System.Windows.Forms.Panel();
            panelTitle = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            btnClose = new System.Windows.Forms.Button();
            panelBody = new System.Windows.Forms.Panel();
            panelFooter = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            lblEmpLabel = new System.Windows.Forms.Label();
            cboEmployee = new System.Windows.Forms.ComboBox();
            lblDateLabel = new System.Windows.Forms.Label();
            dtpDate = new System.Windows.Forms.DateTimePicker();
            lblShiftLabel = new System.Windows.Forms.Label();
            cboShift = new System.Windows.Forms.ComboBox();
            lblRoomLabel = new System.Windows.Forms.Label();
            txtRoom = new System.Windows.Forms.TextBox();
            lblStartLabel = new System.Windows.Forms.Label();
            txtStartTime = new System.Windows.Forms.TextBox();
            lblEndLabel = new System.Windows.Forms.Label();
            txtEndTime = new System.Windows.Forms.TextBox();

            panelMain.SuspendLayout();
            SuspendLayout();

            // ── Form ────────────────────────────────────────────────────────
            this.Text = "Chỉnh sửa ca trực";
            this.ClientSize = new Size(620, 380);          // vừa đủ 2 cột + padding
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;

            // ── panelMain ───────────────────────────────────────────────────
            panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Controls.Add(panelBody);
            panelMain.Controls.Add(panelFooter);
            panelMain.Controls.Add(panelTitle);

            // ── panelTitle ──────────────────────────────────────────────────
            panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            panelTitle.Height = 56;
            panelTitle.BackColor = System.Drawing.Color.FromArgb(21, 101, 192); // xanh đậm

            lblTitle.Text = "Chỉnh sửa ca trực";
            lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 13F);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 16);
            lblTitle.AutoSize = true;

            btnClose.Text = "✕";
            btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Size = new System.Drawing.Size(32, 32);
            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.Location = new System.Drawing.Point(576, 12);  // 620 - 32 - 12
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.Click += btnCancel_Click;

            panelTitle.Controls.Add(lblTitle);
            panelTitle.Controls.Add(btnClose);

            // ── panelBody ───────────────────────────────────────────────────
            // Hằng số layout
            const int colL = 24;   // cột trái X
            const int colR = 320;  // cột phải X
            const int colW = 272;  // chiều rộng mỗi cột  (colR + colW = 592 < 620-24)
            const int ctlH = 30;   // chiều cao control
            const int lblH = 18;   // chiều cao label
            const int rowGap = 16;  // khoảng cách giữa các nhóm hàng
            const int innerGap = 4; // khoảng cách label → control

            // Tọa độ Y từng hàng
            int row1Lbl = 16;
            int row1Ctl = row1Lbl + lblH + innerGap;
            int row2Lbl = row1Ctl + ctlH + rowGap;
            int row2Ctl = row2Lbl + lblH + innerGap;
            int row3Lbl = row2Ctl + ctlH + rowGap;
            int row3Ctl = row3Lbl + lblH + innerGap;

            panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            panelBody.BackColor = System.Drawing.Color.White;
            panelBody.Padding = new System.Windows.Forms.Padding(0);

            // Hàng 1: Nhân viên | Ngày trực
            lblEmpLabel.Text = "Nhân viên *";
            lblEmpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEmpLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblEmpLabel.Location = new System.Drawing.Point(colL, row1Lbl);
            lblEmpLabel.AutoSize = true;

            cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboEmployee.Location = new System.Drawing.Point(colL, row1Ctl);
            cboEmployee.Size = new System.Drawing.Size(colW, ctlH);

            lblDateLabel.Text = "Ngày trực *";
            lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDateLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblDateLabel.Location = new System.Drawing.Point(colR, row1Lbl);
            lblDateLabel.AutoSize = true;

            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDate.Location = new System.Drawing.Point(colR, row1Ctl);
            dtpDate.Size = new System.Drawing.Size(colW, ctlH);

            // Hàng 2: Ca trực | Phòng
            lblShiftLabel.Text = "Ca trực *";
            lblShiftLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblShiftLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblShiftLabel.Location = new System.Drawing.Point(colL, row2Lbl);
            lblShiftLabel.AutoSize = true;

            cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboShift.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboShift.Location = new System.Drawing.Point(colL, row2Ctl);
            cboShift.Size = new System.Drawing.Size(colW, ctlH);
            cboShift.SelectedIndexChanged += cboShift_SelectedIndexChanged;

            lblRoomLabel.Text = "Phòng *";
            lblRoomLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblRoomLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblRoomLabel.Location = new System.Drawing.Point(colR, row2Lbl);
            lblRoomLabel.AutoSize = true;

            txtRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtRoom.Location = new System.Drawing.Point(colR, row2Ctl);
            txtRoom.Size = new System.Drawing.Size(colW, ctlH);
            txtRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Hàng 3: Giờ bắt đầu | Giờ kết thúc
            lblStartLabel.Text = "Giờ bắt đầu";
            lblStartLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStartLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblStartLabel.Location = new System.Drawing.Point(colL, row3Lbl);
            lblStartLabel.AutoSize = true;

            txtStartTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtStartTime.Location = new System.Drawing.Point(colL, row3Ctl);
            txtStartTime.Size = new System.Drawing.Size(colW, ctlH);
            txtStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtStartTime.ReadOnly = true;
            txtStartTime.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);

            lblEndLabel.Text = "Giờ kết thúc";
            lblEndLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEndLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblEndLabel.Location = new System.Drawing.Point(colR, row3Lbl);
            lblEndLabel.AutoSize = true;

            txtEndTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEndTime.Location = new System.Drawing.Point(colR, row3Ctl);
            txtEndTime.Size = new System.Drawing.Size(colW, ctlH);
            txtEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtEndTime.ReadOnly = true;
            txtEndTime.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);

            panelBody.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblEmpLabel,  cboEmployee,
                lblDateLabel, dtpDate,
                lblShiftLabel, cboShift,
                lblRoomLabel,  txtRoom,
                lblStartLabel, txtStartTime,
                lblEndLabel,   txtEndTime
            });

            // ── panelFooter ─────────────────────────────────────────────────
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Height = 60;
            panelFooter.BackColor = System.Drawing.Color.White;

            // Đường kẻ phân cách footer
            var footerDivider = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 1,
                BackColor = System.Drawing.Color.FromArgb(229, 231, 235)
            };
            panelFooter.Controls.Add(footerDivider);

            btnCancel.Text = "Hủy";
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            btnCancel.BackColor = System.Drawing.Color.White;
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            btnCancel.Size = new System.Drawing.Size(90, 36);
            btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnCancel.Location = new System.Drawing.Point(400, 12);   // 620 - 24 - 106 - 90
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            btnSave.Text = "✓  Cập nhật";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Size = new System.Drawing.Size(120, 36);
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnSave.Location = new System.Drawing.Point(502, 12);     // 620 - 24 - 120 + 2 (gap 12)
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.Click += btnSave_Click;

            panelFooter.Controls.AddRange(new System.Windows.Forms.Control[] { btnCancel, btnSave });

            this.Controls.Add(panelMain);
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelMain, panelTitle, panelBody, panelFooter;
        private System.Windows.Forms.Label lblTitle, lblEmpLabel, lblDateLabel, lblShiftLabel,
                                           lblRoomLabel, lblStartLabel, lblEndLabel;
        private System.Windows.Forms.Button btnClose, btnCancel, btnSave;
        private System.Windows.Forms.ComboBox cboEmployee, cboShift;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtRoom, txtStartTime, txtEndTime;
    }
}