using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucPharmacyMedicineItemCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootPanel = new RoundedPanel();
            lblPrice = new Label();
            lblPriceTitle = new Label();
            lblBatch = new Label();
            lblQuantity = new Label();
            lblQuantityTitle = new Label();
            lblDosage = new Label();
            lblDosageTitle = new Label();
            lblMedicineName = new Label();
            lblIndex = new Label();
            rootPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.BorderColor = Color.FromArgb(226, 232, 240);
            rootPanel.BorderWidth = 1;
            rootPanel.Controls.Add(lblPrice);
            rootPanel.Controls.Add(lblPriceTitle);
            rootPanel.Controls.Add(lblBatch);
            rootPanel.Controls.Add(lblQuantity);
            rootPanel.Controls.Add(lblQuantityTitle);
            rootPanel.Controls.Add(lblDosage);
            rootPanel.Controls.Add(lblDosageTitle);
            rootPanel.Controls.Add(lblMedicineName);
            rootPanel.Controls.Add(lblIndex);
            rootPanel.CornerRadius = 8;
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.FillColor = Color.FromArgb(249, 250, 251);
            rootPanel.Location = new Point(0, 0);
            rootPanel.Margin = new Padding(0);
            rootPanel.Name = "rootPanel";
            rootPanel.Size = new Size(780, 102);
            rootPanel.TabIndex = 0;
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(22, 101, 52);
            lblPrice.Location = new Point(654, 36);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(96, 28);
            lblPrice.TabIndex = 8;
            lblPrice.Text = "5,000 đ";
            lblPrice.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPriceTitle
            // 
            lblPriceTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPriceTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPriceTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblPriceTitle.Location = new Point(666, 14);
            lblPriceTitle.Name = "lblPriceTitle";
            lblPriceTitle.Size = new Size(84, 22);
            lblPriceTitle.TabIndex = 7;
            lblPriceTitle.Text = "Đơn giá";
            lblPriceTitle.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBatch
            // 
            lblBatch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBatch.AutoEllipsis = true;
            lblBatch.Font = new Font("Segoe UI", 8.5F);
            lblBatch.ForeColor = Color.FromArgb(100, 116, 139);
            lblBatch.Location = new Point(548, 62);
            lblBatch.Name = "lblBatch";
            lblBatch.Size = new Size(100, 40);
            lblBatch.TabIndex = 6;
            lblBatch.Text = "Lô: LOT-01";
            lblBatch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblQuantity
            // 
            lblQuantity.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuantity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblQuantity.ForeColor = Color.FromArgb(17, 24, 39);
            lblQuantity.Location = new Point(548, 32);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 39);
            lblQuantity.TabIndex = 5;
            lblQuantity.Text = "10 viên";
            lblQuantity.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblQuantityTitle
            // 
            lblQuantityTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblQuantityTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblQuantityTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblQuantityTitle.Location = new Point(548, 10);
            lblQuantityTitle.Name = "lblQuantityTitle";
            lblQuantityTitle.Size = new Size(86, 22);
            lblQuantityTitle.TabIndex = 4;
            lblQuantityTitle.Text = "Số lượng";
            lblQuantityTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDosage
            // 
            lblDosage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDosage.AutoEllipsis = true;
            lblDosage.Font = new Font("Segoe UI", 9F);
            lblDosage.ForeColor = Color.FromArgb(55, 65, 81);
            lblDosage.Location = new Point(76, 62);
            lblDosage.Name = "lblDosage";
            lblDosage.Size = new Size(447, 40);
            lblDosage.TabIndex = 3;
            lblDosage.Text = "Ngày uống 2 lần, mỗi lần 1 viên sau ăn";
            lblDosage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDosageTitle
            // 
            lblDosageTitle.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblDosageTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDosageTitle.Location = new Point(76, 40);
            lblDosageTitle.Name = "lblDosageTitle";
            lblDosageTitle.Size = new Size(76, 31);
            lblDosageTitle.TabIndex = 2;
            lblDosageTitle.Text = "Cách dùng";
            lblDosageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMedicineName
            // 
            lblMedicineName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblMedicineName.AutoEllipsis = true;
            lblMedicineName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblMedicineName.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedicineName.Location = new Point(76, 10);
            lblMedicineName.Name = "lblMedicineName";
            lblMedicineName.Size = new Size(447, 39);
            lblMedicineName.TabIndex = 1;
            lblMedicineName.Text = "Paracetamol 500mg";
            lblMedicineName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIndex
            // 
            lblIndex.BackColor = Color.FromArgb(47, 94, 240);
            lblIndex.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblIndex.ForeColor = Color.White;
            lblIndex.Location = new Point(16, 16);
            lblIndex.Name = "lblIndex";
            lblIndex.Size = new Size(44, 44);
            lblIndex.TabIndex = 0;
            lblIndex.Text = "01";
            lblIndex.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucPharmacyMedicineItemCard
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Transparent;
            Controls.Add(rootPanel);
            Margin = new Padding(0, 0, 0, 12);
            Name = "ucPharmacyMedicineItemCard";
            Size = new Size(780, 102);
            Resize += ucPharmacyMedicineItemCard_Resize;
            rootPanel.ResumeLayout(false);
            ResumeLayout(false);
            ApplyMedicineCardBackColors();
        }

        private void ApplyMedicineCardBackColors()
        {
            Color cardBack = Color.FromArgb(249, 250, 251);
            lblMedicineName.BackColor = cardBack;
            lblDosageTitle.BackColor = cardBack;
            lblDosage.BackColor = cardBack;
            lblQuantityTitle.BackColor = cardBack;
            lblQuantity.BackColor = cardBack;
            lblBatch.BackColor = cardBack;
            lblPriceTitle.BackColor = cardBack;
            lblPrice.BackColor = cardBack;
        }

        private void ucPharmacyMedicineItemCard_Resize(object sender, System.EventArgs e)
        {
            AdjustMedicineCardLayout();
        }

        private void AdjustMedicineCardLayout()
        {
            int width = rootPanel.ClientSize.Width;
            if (width <= 0)
            {
                return;
            }

            int priceLeft = System.Math.Max(600, width - 126);
            int quantityLeft = System.Math.Max(480, priceLeft - 132);
            int textRight = quantityLeft - 24;

            lblMedicineName.Width = System.Math.Max(220, textRight - lblMedicineName.Left);
            lblDosage.Width = System.Math.Max(220, textRight - lblDosage.Left);
            lblQuantityTitle.Left = quantityLeft;
            lblQuantity.Left = quantityLeft;
            lblBatch.Left = quantityLeft;
            lblPriceTitle.Left = priceLeft;
            lblPrice.Left = priceLeft - 12;
        }

        private RoundedPanel rootPanel;
        private Label lblIndex;
        private Label lblMedicineName;
        private Label lblDosageTitle;
        private Label lblDosage;
        private Label lblQuantityTitle;
        private Label lblQuantity;
        private Label lblBatch;
        private Label lblPriceTitle;
        private Label lblPrice;
    }
}
