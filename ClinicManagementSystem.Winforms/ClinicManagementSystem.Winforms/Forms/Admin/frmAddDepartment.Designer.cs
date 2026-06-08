namespace ClinicManagementSystem.Winforms.Forms.Admin
{
    partial class frmAddDepartment
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            lblName = new System.Windows.Forms.Label();
            txtName = new System.Windows.Forms.TextBox();
            lblDesc = new System.Windows.Forms.Label();
            txtDesc = new System.Windows.Forms.TextBox();
            chkActive = new System.Windows.Forms.CheckBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();

            lblTitle.Text = "Thêm chuyên khoa mới";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            lblTitle.Location = new System.Drawing.Point(30, 20);
            lblTitle.Size = new System.Drawing.Size(380, 40);

            lblName.Text = "Tên chuyên khoa *";
            lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblName.Location = new System.Drawing.Point(30, 76);
            lblName.AutoSize = true;

            txtName.Location = new System.Drawing.Point(30, 100);
            txtName.Size = new System.Drawing.Size(400, 30);
            txtName.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            lblDesc.Text = "Mô tả";
            lblDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblDesc.Location = new System.Drawing.Point(30, 148);
            lblDesc.AutoSize = true;

            txtDesc.Location = new System.Drawing.Point(30, 172);
            txtDesc.Size = new System.Drawing.Size(400, 80);
            txtDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDesc.Multiline = true;
            txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            chkActive.Text = "Đang hoạt động";
            chkActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            chkActive.Location = new System.Drawing.Point(30, 268);
            chkActive.Checked = true;
            chkActive.AutoSize = true;

            btnSave.Text = "Lưu";
            btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSave.BackColor = System.Drawing.Color.FromArgb(47, 94, 240);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Size = new System.Drawing.Size(120, 44);
            btnSave.Location = new System.Drawing.Point(200, 308);
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Hủy";
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Size = new System.Drawing.Size(100, 44);
            btnCancel.Location = new System.Drawing.Point(332, 308);
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            btnCancel.Click += btnCancel_Click;

            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(464, 376);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false; MinimizeBox = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Thêm chuyên khoa";
            Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblName, txtName, lblDesc, txtDesc, chkActive, btnSave, btnCancel });
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle, lblName, lblDesc;
        private System.Windows.Forms.TextBox txtName, txtDesc;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave, btnCancel;
    }
}
