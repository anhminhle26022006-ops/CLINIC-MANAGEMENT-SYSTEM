using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucInvoiceCard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlBottom;

        private Label lblTitle;

        private Label lblDateTitle;
        private Label lblDate;

        private Label lblAmountTitle;
        private Label lblAmount;

        private Label lblStatusTitle;
        private Label lblStatus;

        private GroupBox grpServices;
        private GroupBox grpPaymentMethod;

        private Label lblExam;
        private Label lblLab;
        private Label lblMedicine;

        private Label lblCash;
        private Label lblCard;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblDateTitle = new Label();
            lblDate = new Label();
            lblAmountTitle = new Label();
            lblAmount = new Label();
            lblStatusTitle = new Label();
            lblStatus = new Label();
            pnlBottom = new Panel();
            grpServices = new GroupBox();
            lblExam = new Label();
            lblLab = new Label();
            lblMedicine = new Label();
            grpPaymentMethod = new GroupBox();
            lblCash = new Label();
            lblCard = new Label();
            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            grpServices.SuspendLayout();
            grpPaymentMethod.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblDateTitle);
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblAmountTitle);
            pnlHeader.Controls.Add(lblAmount);
            pnlHeader.Controls.Add(lblStatusTitle);
            pnlHeader.Controls.Add(lblStatus);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1523, 90);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(94, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Hóa đơn";
            // 
            // lblDateTitle
            // 
            lblDateTitle.AutoSize = true;
            lblDateTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateTitle.Location = new Point(15, 50);
            lblDateTitle.Name = "lblDateTitle";
            lblDateTitle.Size = new Size(50, 20);
            lblDateTitle.TabIndex = 1;
            lblDateTitle.Text = "Ngày:";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(70, 50);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(85, 20);
            lblDate.TabIndex = 2;
            lblDate.Text = "14/05/2026";
            // 
            // lblAmountTitle
            // 
            lblAmountTitle.AutoSize = true;
            lblAmountTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmountTitle.Location = new Point(250, 50);
            lblAmountTitle.Name = "lblAmountTitle";
            lblAmountTitle.Size = new Size(61, 20);
            lblAmountTitle.TabIndex = 3;
            lblAmountTitle.Text = "Số tiền:";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmount.ForeColor = Color.DarkGreen;
            lblAmount.Location = new Point(320, 48);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(117, 23);
            lblAmount.TabIndex = 4;
            lblAmount.Text = "500,000 VNĐ";
            // 
            // lblStatusTitle
            // 
            lblStatusTitle.AutoSize = true;
            lblStatusTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusTitle.Location = new Point(550, 50);
            lblStatusTitle.Name = "lblStatusTitle";
            lblStatusTitle.Size = new Size(57, 20);
            lblStatusTitle.TabIndex = 5;
            lblStatusTitle.Text = "Status:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(620, 50);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(103, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Đã thanh toán";
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(grpServices);
            pnlBottom.Controls.Add(grpPaymentMethod);
            pnlBottom.Dock = DockStyle.Fill;
            pnlBottom.Location = new Point(0, 90);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(15);
            pnlBottom.Size = new Size(1523, 156);
            pnlBottom.TabIndex = 0;
            // 
            // grpServices
            // 
            grpServices.BackColor = Color.WhiteSmoke;
            grpServices.Controls.Add(lblExam);
            grpServices.Controls.Add(lblLab);
            grpServices.Controls.Add(lblMedicine);
            grpServices.Location = new Point(18, 18);
            grpServices.Name = "grpServices";
            grpServices.Size = new Size(708, 110);
            grpServices.TabIndex = 0;
            grpServices.TabStop = false;
            grpServices.Text = "Dịch vụ";
            // 
            // lblExam
            // 
            lblExam.AutoSize = true;
            lblExam.Font = new Font("Segoe UI", 10F);
            lblExam.Location = new Point(20, 35);
            lblExam.Name = "lblExam";
            lblExam.Size = new Size(110, 23);
            lblExam.TabIndex = 0;
            lblExam.Text = "• Khám bệnh";
            // 
            // lblLab
            // 
            lblLab.AutoSize = true;
            lblLab.Font = new Font("Segoe UI", 10F);
            lblLab.Location = new Point(20, 60);
            lblLab.Name = "lblLab";
            lblLab.Size = new Size(110, 23);
            lblLab.TabIndex = 1;
            lblLab.Text = "• Xét nghiệm";
            // 
            // lblMedicine
            // 
            lblMedicine.AutoSize = true;
            lblMedicine.Font = new Font("Segoe UI", 10F);
            lblMedicine.Location = new Point(20, 85);
            lblMedicine.Name = "lblMedicine";
            lblMedicine.Size = new Size(69, 23);
            lblMedicine.TabIndex = 2;
            lblMedicine.Text = "• Thuốc";
            // 
            // grpPaymentMethod
            // 
            grpPaymentMethod.BackColor = Color.WhiteSmoke;
            grpPaymentMethod.Controls.Add(lblCash);
            grpPaymentMethod.Controls.Add(lblCard);
            grpPaymentMethod.Location = new Point(845, 18);
            grpPaymentMethod.Name = "grpPaymentMethod";
            grpPaymentMethod.Size = new Size(660, 110);
            grpPaymentMethod.TabIndex = 1;
            grpPaymentMethod.TabStop = false;
            grpPaymentMethod.Text = "Phương thức";
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Font = new Font("Segoe UI", 10F);
            lblCash.Location = new Point(20, 40);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(89, 23);
            lblCash.TabIndex = 0;
            lblCash.Text = "• Tiền mặt";
            // 
            // lblCard
            // 
            lblCard.AutoSize = true;
            lblCard.Font = new Font("Segoe UI", 10F);
            lblCard.Location = new Point(20, 70);
            lblCard.Name = "lblCard";
            lblCard.Size = new Size(50, 23);
            lblCard.TabIndex = 1;
            lblCard.Text = "• Thẻ";
            // 
            // ucInvoiceCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            Name = "ucInvoiceCard";
            Size = new Size(1523, 246);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            grpServices.ResumeLayout(false);
            grpServices.PerformLayout();
            grpPaymentMethod.ResumeLayout(false);
            grpPaymentMethod.PerformLayout();
            ResumeLayout(false);
        }
    }
}