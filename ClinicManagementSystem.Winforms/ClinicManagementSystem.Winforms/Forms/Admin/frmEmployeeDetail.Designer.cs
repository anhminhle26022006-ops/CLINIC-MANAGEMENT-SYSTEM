using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Forms
{
    partial class frmEmployeeDetail
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
            lblName = new Label();
            lblMeta = new Label();
            panelBody = new Panel();
            grpPersonal = new GroupBox();
            lblDOB = new Label();
            lblDOBValue = new Label();
            lblGender = new Label();
            lblGenderValue = new Label();
            lblCitizen = new Label();
            lblCitizenValue = new Label();
            lblAddress = new Label();
            lblAddressValue = new Label();
            lblPhone = new Label();
            lblPhoneValue = new Label();
            lblEmail = new Label();
            lblEmailValue = new Label();
            grpWork = new GroupBox();
            lblDept = new Label();
            lblDeptValue = new Label();
            lblRole = new Label();
            lblRoleValue = new Label();
            lblHire = new Label();
            lblHireValue = new Label();
            lblStatusL = new Label();
            lblStatusValue = new Label();
            panelFooter = new Panel();
            btnClose = new Button();

            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            grpPersonal.SuspendLayout();
            grpWork.SuspendLayout();
            panelFooter.SuspendLayout();
            SuspendLayout();

            // ── panelHeader ──
            panelHeader.BackColor = Color.FromArgb(37, 99, 235);
            panelHeader.Controls.Add(lblName);
            panelHeader.Controls.Add(lblMeta);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 80;
            panelHeader.Name = "panelHeader";

            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblName.ForeColor = Color.White;
            lblName.Location = new Point(20, 10);
            lblName.Name = "lblName";

            lblMeta.AutoSize = true;
            lblMeta.Font = new Font("Segoe UI", 9F);
            lblMeta.ForeColor = Color.FromArgb(191, 219, 254);
            lblMeta.Location = new Point(22, 52);
            lblMeta.Name = "lblMeta";

            // ── panelBody ──
            panelBody.AutoScroll = true;
            panelBody.BackColor = Color.FromArgb(245, 247, 250);
            panelBody.Controls.Add(grpWork);
            panelBody.Controls.Add(grpPersonal);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Padding = new Padding(16);
            panelBody.Name = "panelBody";

            // ── grpPersonal ──
            grpPersonal.Dock = DockStyle.Top;
            grpPersonal.Height = 220;
            grpPersonal.Text = "Thông tin cá nhân";
            grpPersonal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpPersonal.ForeColor = Color.FromArgb(37, 99, 235);
            grpPersonal.BackColor = Color.White;
            grpPersonal.Padding = new Padding(12);
            grpPersonal.Margin = new Padding(0, 0, 0, 12);
            grpPersonal.Name = "grpPersonal";
            grpPersonal.Controls.AddRange(new Control[]
            {
                lblDOB, lblDOBValue,
                lblGender, lblGenderValue,
                lblCitizen, lblCitizenValue,
                lblAddress, lblAddressValue,
                lblPhone, lblPhoneValue,
                lblEmail, lblEmailValue
            });

            // Row 1 — Ngày sinh | Giới tính
            SetLabel(lblDOB, "Ngày sinh", 20, 28);
            SetValue(lblDOBValue, "—", 20, 48);
            SetLabel(lblGender, "Giới tính", 290, 28);
            SetValue(lblGenderValue, "—", 290, 48);

            // Row 2 — CCCD | Địa chỉ
            SetLabel(lblCitizen, "CCCD", 20, 88);
            SetValue(lblCitizenValue, "—", 20, 108);
            SetLabel(lblAddress, "Địa chỉ", 290, 88);
            SetValue(lblAddressValue, "—", 290, 108);

            // Row 3 — Điện thoại | Email
            SetLabel(lblPhone, "Điện thoại", 20, 148);
            SetValue(lblPhoneValue, "—", 20, 168);
            SetLabel(lblEmail, "Email", 290, 148);
            SetValue(lblEmailValue, "—", 290, 168);

            // ── grpWork ──
            grpWork.Dock = DockStyle.Top;
            grpWork.Height = 160;
            grpWork.Text = "Thông tin công việc";
            grpWork.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpWork.ForeColor = Color.FromArgb(37, 99, 235);
            grpWork.BackColor = Color.White;
            grpWork.Padding = new Padding(12);
            grpWork.Margin = new Padding(0, 0, 0, 12);
            grpWork.Name = "grpWork";
            grpWork.Controls.AddRange(new Control[]
            {
                lblDept, lblDeptValue,
                lblRole, lblRoleValue,
                lblHire, lblHireValue,
                lblStatusL, lblStatusValue
            });

            // Row 1 — Chuyên khoa | Chức vụ
            SetLabel(lblDept, "Chuyên khoa", 20, 28);
            SetValue(lblDeptValue, "—", 20, 48);
            SetLabel(lblRole, "Chức vụ", 290, 28);
            SetValue(lblRoleValue, "—", 290, 48);

            // Row 2 — Ngày vào làm | Trạng thái
            SetLabel(lblHire, "Ngày vào làm", 20, 88);
            SetValue(lblHireValue, "—", 20, 108);
            SetLabel(lblStatusL, "Trạng thái", 290, 88);
            SetValue(lblStatusValue, "—", 290, 108);

            // ── panelFooter ──
            panelFooter.BackColor = Color.FromArgb(249, 250, 251);
            panelFooter.Controls.Add(btnClose);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Height = 55;
            panelFooter.Name = "panelFooter";

            btnClose.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnClose.BackColor = Color.White;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnClose.Font = new Font("Segoe UI", 10F);
            btnClose.ForeColor = Color.FromArgb(55, 65, 81);
            btnClose.Location = new Point(476, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(100, 36);
            btnClose.Text = "Đóng";
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += btnClose_Click;

            // ── Form ──
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(600, 520);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            Controls.Add(panelFooter);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmEmployeeDetail";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết nhân viên";

            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBody.ResumeLayout(false);
            grpPersonal.ResumeLayout(false);
            grpWork.ResumeLayout(false);
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

        private static void SetValue(Label lbl, string text, int x, int y)
        {
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(17, 24, 39);
            lbl.Location = new Point(x, y);
            lbl.Text = text;
        }

        private Panel panelHeader, panelBody, panelFooter;
        private Label lblName, lblMeta;
        private GroupBox grpPersonal, grpWork;
        private Label lblDOB, lblDOBValue;
        private Label lblGender, lblGenderValue;
        private Label lblCitizen, lblCitizenValue;
        private Label lblAddress, lblAddressValue;
        private Label lblPhone, lblPhoneValue;
        private Label lblEmail, lblEmailValue;
        private Label lblDept, lblDeptValue;
        private Label lblRole, lblRoleValue;
        private Label lblHire, lblHireValue;
        private Label lblStatusL, lblStatusValue;
        private Button btnClose;
    }
}