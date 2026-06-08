namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmRegisterShift
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
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
            panelFooter = new System.Windows.Forms.Panel();
            btnCancel = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            panelDivider = new System.Windows.Forms.Panel();
            SuspendLayout();

            // ── Hằng số layout ────────────────────────────────────────
            // Form: 660 × 460  (FormBorderStyle.None — không có title bar Windows)
            // Padding: 32 hai bên | 2 cột bằng nhau, gap giữa 24
            // colW = (660 - 32 - 32 - 24) / 2 = 286
            const int formW = 660;
            const int formH = 460;
            const int padL = 32;
            const int padR = 32;
            const int colW = 286;
            const int gap = 24;
            const int colR = padL + colW + gap;   // 342
            const int ctlH = 40;   // control cao hơn cho giống Figma
            const int lblH = 18;
            const int iGap = 6;
            const int rGap = 24;

            // Header cao 56 + divider 1 → body bắt đầu từ Y=57
            const int bodyTop = 57;
            const int row1L = bodyTop + 20;
            const int row1C = row1L + lblH + iGap;
            const int row2L = row1C + ctlH + rGap;
            const int row2C = row2L + lblH + iGap;
            const int row3L = row2C + ctlH + rGap;
            const int row3C = row3L + lblH + iGap;

            // ── Form ──────────────────────────────────────────────────
            this.Text = "Thêm ca trực mới";
            this.ClientSize = new System.Drawing.Size(formW, formH);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;   // tự vẽ header
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Bo góc form (cần override OnPaint hoặc dùng Region nếu muốn,
            // ở đây chỉ flat trắng cho đơn giản)

            // ── Header: tiêu đề + nút X ───────────────────────────────
            var panelHeader = new System.Windows.Forms.Panel
            {
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(formW, 56),
                BackColor = System.Drawing.Color.White
            };

            lblTitle.Text = "Thêm ca trực mới";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            lblTitle.Location = new System.Drawing.Point(padL, 16);
            lblTitle.AutoSize = true;

            var btnClose = new System.Windows.Forms.Button
            {
                Text = "✕",
                Font = new System.Drawing.Font("Segoe UI", 11F),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.FromArgb(107, 114, 128),
                Size = new System.Drawing.Size(32, 32),
                Location = new System.Drawing.Point(formW - 44, 12),
                Cursor = System.Windows.Forms.Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += btnCancel_Click;

            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnClose);

            // ── Divider dưới header ───────────────────────────────────
            panelDivider.BackColor = System.Drawing.Color.FromArgb(229, 231, 235);
            panelDivider.Location = new System.Drawing.Point(0, 56);
            panelDivider.Size = new System.Drawing.Size(formW, 1);

            // ── Row 1: Nhân viên | Ngày trực ─────────────────────────
            lblEmpLabel.Text = "Nhân viên *";
            lblEmpLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEmpLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblEmpLabel.Location = new System.Drawing.Point(padL, row1L);
            lblEmpLabel.AutoSize = true;

            cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboEmployee.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboEmployee.Location = new System.Drawing.Point(padL, row1C);
            cboEmployee.Size = new System.Drawing.Size(colW, ctlH);

            lblDateLabel.Text = "Ngày trực *";
            lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblDateLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblDateLabel.Location = new System.Drawing.Point(colR, row1L);
            lblDateLabel.AutoSize = true;

            dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDate.Location = new System.Drawing.Point(colR, row1C);
            dtpDate.Size = new System.Drawing.Size(colW, ctlH);

            // ── Row 2: Ca trực | Phòng ────────────────────────────────
            lblShiftLabel.Text = "Ca trực *";
            lblShiftLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblShiftLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblShiftLabel.Location = new System.Drawing.Point(padL, row2L);
            lblShiftLabel.AutoSize = true;

            cboShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboShift.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cboShift.Location = new System.Drawing.Point(padL, row2C);
            cboShift.Size = new System.Drawing.Size(colW, ctlH);
            cboShift.SelectedIndexChanged += cboShift_SelectedIndexChanged;

            lblRoomLabel.Text = "Phòng *";
            lblRoomLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblRoomLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblRoomLabel.Location = new System.Drawing.Point(colR, row2L);
            lblRoomLabel.AutoSize = true;

            txtRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtRoom.Location = new System.Drawing.Point(colR, row2C);
            txtRoom.Size = new System.Drawing.Size(colW, ctlH);
            txtRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtRoom.PlaceholderText = "VD: P203, Lễ tân";

            // ── Row 3: Giờ bắt đầu | Giờ kết thúc ───────────────────
            lblStartLabel.Text = "Giờ bắt đầu";
            lblStartLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblStartLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblStartLabel.Location = new System.Drawing.Point(padL, row3L);
            lblStartLabel.AutoSize = true;

            txtStartTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtStartTime.Location = new System.Drawing.Point(padL, row3C);
            txtStartTime.Size = new System.Drawing.Size(colW, ctlH);
            txtStartTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtStartTime.ReadOnly = true;
            txtStartTime.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            txtStartTime.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);

            lblEndLabel.Text = "Giờ kết thúc";
            lblEndLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            lblEndLabel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            lblEndLabel.Location = new System.Drawing.Point(colR, row3L);
            lblEndLabel.AutoSize = true;

            txtEndTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEndTime.Location = new System.Drawing.Point(colR, row3C);
            txtEndTime.Size = new System.Drawing.Size(colW, ctlH);
            txtEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtEndTime.ReadOnly = true;
            txtEndTime.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            txtEndTime.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);

            // ── Footer ────────────────────────────────────────────────
            // Dùng Dock.Bottom — luôn sát đáy, không cần tính Y
            panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelFooter.Height = 72;
            panelFooter.BackColor = System.Drawing.Color.White;

            var footerLine = new System.Windows.Forms.Panel
            {
                Dock = System.Windows.Forms.DockStyle.Top,
                Height = 1,
                BackColor = System.Drawing.Color.FromArgb(229, 231, 235)
            };

            // Tính X nút: đo từ phải → trái trong panelFooter (width = formW)
            // [padR=32] [btnSave=150] [gap=12] [btnCancel=90] ...
            const int btnSaveW = 150;
            const int btnCancelW = 90;
            const int btnGap = 12;
            const int btnH = 40;
            const int btnY = 15;
            int btnSaveX = formW - padR - btnSaveW;              // 660-32-150 = 478
            int btnCancelX = btnSaveX - btnGap - btnCancelW;       // 478-12-90  = 376

            btnCancel.Text = "Hủy";
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(209, 213, 219);
            btnCancel.BackColor = System.Drawing.Color.White;
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            btnCancel.Size = new System.Drawing.Size(btnCancelW, btnH);
            btnCancel.Location = new System.Drawing.Point(btnCancelX, btnY);
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            btnSave.Text = "✓  Thêm ca trực";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSave.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Size = new System.Drawing.Size(btnSaveW, btnH);
            btnSave.Location = new System.Drawing.Point(btnSaveX, btnY);
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.Click += btnSave_Click;

            panelFooter.Controls.Add(btnCancel);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Controls.Add(footerLine);

            // ── Add controls ──────────────────────────────────────────
            this.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                panelHeader,
                panelDivider,
                lblEmpLabel,   cboEmployee,  lblDateLabel,  dtpDate,
                lblShiftLabel, cboShift,     lblRoomLabel,  txtRoom,
                lblStartLabel, txtStartTime, lblEndLabel,   txtEndTime,
                panelFooter
            });

            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle, lblEmpLabel, lblDateLabel;
        private System.Windows.Forms.Label lblShiftLabel, lblRoomLabel, lblStartLabel, lblEndLabel;
        private System.Windows.Forms.Panel panelFooter, panelDivider;
        private System.Windows.Forms.Button btnCancel, btnSave;
        private System.Windows.Forms.ComboBox cboEmployee, cboShift;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtRoom, txtStartTime, txtEndTime;
    }
}