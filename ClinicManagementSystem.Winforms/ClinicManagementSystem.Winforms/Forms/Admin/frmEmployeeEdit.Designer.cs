using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms
{
    partial class frmEmployeeEdit
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            panelBody = new Panel();
            panelFooter = new Panel();
            btnSave = new Button();
            btnCancel = new Button();

            lblFullName = new Label(); txtFullName = new TextBox();
            lblPhone = new Label(); txtPhone = new TextBox();
            lblEmail = new Label(); txtEmail = new TextBox();
            lblCitizenId = new Label(); txtCitizenId = new TextBox();
            lblAddress = new Label(); txtAddress = new TextBox();
            lblDOB = new Label(); dtpDateOfBirth = new DateTimePicker();
            lblHire = new Label(); dtpHireDate = new DateTimePicker();
            lblRole = new Label(); cboRole = new ComboBox();
            lblDept = new Label(); cboDept = new ComboBox();
            lblStatus = new Label(); cboStatus = new ComboBox();

            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // ── Header ──
            panelHeader.BackColor = Color.FromArgb(37, 99, 235);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 60;
            panelHeader.Name = "panelHeader";
            panelHeader.Controls.Add(lblTitle);

            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Nhân viên";

            // ── Body ──
            panelBody.AutoScroll = true;
            panelBody.BackColor = Color.White;
            panelBody.Dock = DockStyle.Fill;
            panelBody.Padding = new Padding(24, 16, 24, 0);
            panelBody.Name = "panelBody";

            // Row 1: Họ tên | Điện thoại
            Place(lblFullName, "Họ và tên *", 20, 20);
            Place(txtFullName, null, 20, 42, 260, 32);
            Place(lblPhone, "Điện thoại *", 310, 20);
            Place(txtPhone, null, 310, 42, 260, 32);

            // Row 2: Email | CCCD
            Place(lblEmail, "Email", 20, 94);
            Place(txtEmail, null, 20, 116, 260, 32);
            Place(lblCitizenId, "CCCD", 310, 94);
            Place(txtCitizenId, null, 310, 116, 260, 32);

            // Row 3: Địa chỉ (full width)
            Place(lblAddress, "Địa chỉ", 20, 168);
            Place(txtAddress, null, 20, 190, 550, 32);

            // Row 4: Ngày sinh | Ngày vào làm
            Place(lblDOB, "Ngày sinh", 20, 242);
            PlaceDtp(dtpDateOfBirth, 20, 264, 260);
            Place(lblHire, "Ngày vào làm", 310, 242);
            PlaceDtp(dtpHireDate, 310, 264, 260);

            // Row 5: Chức vụ | Chuyên khoa
            Place(lblRole, "Chức vụ *", 20, 316);
            PlaceCbo(cboRole, 20, 338, 260);
            Place(lblDept, "Chuyên khoa *", 310, 316);
            PlaceCbo(cboDept, 310, 338, 260);

            // Row 6: Trạng thái
            Place(lblStatus, "Trạng thái", 20, 390);
            PlaceCbo(cboStatus, 20, 412, 260);

            panelBody.Controls.AddRange(new Control[]
            {
                lblFullName, txtFullName, lblPhone, txtPhone,
                lblEmail, txtEmail, lblCitizenId, txtCitizenId,
                lblAddress, txtAddress,
                lblDOB, dtpDateOfBirth, lblHire, dtpHireDate,
                lblRole, cboRole, lblDept, cboDept,
                lblStatus, cboStatus
            });

            // ── Footer ──
            panelFooter.BackColor = Color.FromArgb(249, 250, 251);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 60;
            panelFooter.Name = "panelFooter";

            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 38);
            btnCancel.Location = new Point(370, 11);
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Name = "btnCancel";
            btnCancel.Click += btnCancel_Click;

            btnSave.Text = "💾  Lưu";
            btnSave.Size = new Size(120, 38);
            btnSave.Location = new Point(480, 11);
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Name = "btnSave";
            btnSave.Click += btnSave_Click;

            panelFooter.Controls.AddRange(new Control[] { btnCancel, btnSave });

            // ── Form ──
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(630, 560);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhân viên";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBody.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ── Helpers ──
        private static void Place(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(107, 114, 128);
            lbl.Location = new Point(x, y);
            lbl.Text = text ?? "";
        }

        private static void Place(Control ctrl, string text, int x, int y, int w, int h)
        {
            ctrl.Font = new Font("Segoe UI", 10F);
            ctrl.Location = new Point(x, y);
            ctrl.Size = new Size(w, h);
            if (ctrl is TextBox tb) tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void PlaceDtp(DateTimePicker dtp, int x, int y, int w)
        {
            dtp.Font = new Font("Segoe UI", 10F);
            dtp.Location = new Point(x, y);
            dtp.Size = new Size(w, 32);
            dtp.Format = DateTimePickerFormat.Short;
        }

        private static void PlaceCbo(ComboBox cbo, int x, int y, int w)
        {
            cbo.Font = new Font("Segoe UI", 10F);
            cbo.Location = new Point(x, y);
            cbo.Size = new Size(w, 32);
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.FlatStyle = FlatStyle.Flat;
        }

        // ── Fields ──
        private Panel panelHeader, panelBody, panelFooter;
        private Label lblTitle;
        private Label lblFullName, lblPhone, lblEmail, lblCitizenId;
        private Label lblAddress, lblDOB, lblHire;
        private Label lblRole, lblDept, lblStatus;
        private TextBox txtFullName, txtPhone, txtEmail, txtCitizenId, txtAddress;
        private DateTimePicker dtpDateOfBirth, dtpHireDate;
        private ComboBox cboRole, cboDept, cboStatus;
        private Button btnSave, btnCancel;
    }
}