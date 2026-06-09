using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms
{
    partial class frmShiftEdit
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
            lblHeader = new Label();
            panelBody = new Panel();
            panelFooter = new Panel();
            btnSave = new Button();
            btnCancel = new Button();

            lblEmployee = new Label(); txtEmployee = new TextBox();
            lblDate = new Label(); dtpDate = new DateTimePicker();
            lblShift = new Label(); cboShift = new ComboBox();
            lblRoom = new Label(); txtRoom = new TextBox();
            lblStart = new Label(); dtpStart = new DateTimePicker();
            lblEnd = new Label(); dtpEnd = new DateTimePicker();

            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // ── Header ──
            panelHeader.BackColor = Color.FromArgb(37, 99, 235);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 56;
            panelHeader.Name = "panelHeader";
            panelHeader.Controls.Add(lblHeader);

            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(20, 14);
            lblHeader.Name = "lblHeader";
            lblHeader.Text = "Chỉnh sửa ca trực";

            // ── Body ──
            panelBody.Dock = DockStyle.Fill;
            panelBody.BackColor = Color.White;
            panelBody.Padding = new Padding(24, 16, 24, 0);
            panelBody.Name = "panelBody";

            // Row 1: Nhân viên (readonly) | Ngày trực
            SetLabel(lblEmployee, "Nhân viên", 0, 16);
            txtEmployee.Location = new Point(0, 38);
            txtEmployee.Size = new Size(260, 32);
            txtEmployee.Font = new Font("Segoe UI", 10F);
            txtEmployee.BorderStyle = BorderStyle.FixedSingle;
            txtEmployee.ReadOnly = true;
            txtEmployee.BackColor = Color.FromArgb(243, 244, 246);
            txtEmployee.Name = "txtEmployee";

            SetLabel(lblDate, "Ngày trực *", 280, 16);
            dtpDate.Location = new Point(280, 38);
            dtpDate.Size = new Size(260, 32);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Font = new Font("Segoe UI", 10F);
            dtpDate.Name = "dtpDate";

            // Row 2: Ca trực | Phòng
            SetLabel(lblShift, "Ca trực *", 0, 90);
            SetCombo(cboShift, 0, 112, 260);
            cboShift.Name = "cboShift";
            cboShift.SelectedIndexChanged += cboShift_SelectedIndexChanged;

            SetLabel(lblRoom, "Phòng", 280, 90);
            txtRoom.Location = new Point(280, 112);
            txtRoom.Size = new Size(260, 32);
            txtRoom.Font = new Font("Segoe UI", 10F);
            txtRoom.BorderStyle = BorderStyle.FixedSingle;
            txtRoom.Name = "txtRoom";

            // Row 3: Giờ bắt đầu | Giờ kết thúc
            SetLabel(lblStart, "Giờ bắt đầu", 0, 164);
            dtpStart.Location = new Point(0, 186);
            dtpStart.Size = new Size(260, 32);
            dtpStart.Format = DateTimePickerFormat.Time;
            dtpStart.ShowUpDown = true;
            dtpStart.Font = new Font("Segoe UI", 10F);
            dtpStart.Name = "dtpStart";

            SetLabel(lblEnd, "Giờ kết thúc", 280, 164);
            dtpEnd.Location = new Point(280, 186);
            dtpEnd.Size = new Size(260, 32);
            dtpEnd.Format = DateTimePickerFormat.Time;
            dtpEnd.ShowUpDown = true;
            dtpEnd.Font = new Font("Segoe UI", 10F);
            dtpEnd.Name = "dtpEnd";

            panelBody.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                lblEmployee, txtEmployee, lblDate,  dtpDate,
                lblShift,    cboShift,    lblRoom,  txtRoom,
                lblStart,    dtpStart,    lblEnd,   dtpEnd
            });

            // ── Footer ──
            panelFooter.BackColor = Color.FromArgb(249, 250, 251);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 64;
            panelFooter.Name = "panelFooter";

            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 38);
            btnCancel.Location = new Point(390, 13);
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnCancel.Font = new Font("Segoe UI", 10F);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Name = "btnCancel";
            btnCancel.Click += btnCancel_Click;

            btnSave.Text = "✔  Cập nhật";
            btnSave.Size = new Size(130, 38);
            btnSave.Location = new Point(500, 13);
            btnSave.BackColor = Color.FromArgb(37, 99, 235);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Name = "btnSave";
            btnSave.Click += btnSave_Click;

            panelFooter.Controls.AddRange(new System.Windows.Forms.Control[]
            {
                btnCancel, btnSave
            });

            // ── Form ──
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(620, 420);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chỉnh sửa ca trực";
            Name = "frmShiftEdit";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBody.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void SetLabel(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(107, 114, 128);
            lbl.Location = new Point(x, y);
            lbl.Text = text;
        }

        private static void SetCombo(ComboBox cbo, int x, int y, int w)
        {
            cbo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbo.Font = new Font("Segoe UI", 10F);
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.Location = new Point(x, y);
            cbo.Size = new Size(w, 32);
        }

        private Panel panelHeader, panelBody, panelFooter;
        private Label lblHeader;
        private Label lblEmployee, lblDate, lblShift, lblRoom, lblStart, lblEnd;
        private TextBox txtEmployee, txtRoom;
        private ComboBox cboShift;
        private DateTimePicker dtpDate, dtpStart, dtpEnd;
        private Button btnSave, btnCancel;
    }
}