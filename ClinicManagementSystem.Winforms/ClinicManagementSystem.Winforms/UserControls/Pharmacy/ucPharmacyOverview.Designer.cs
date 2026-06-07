using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucPharmacyOverview
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
            viewHostPanel = new RoundedPanel();
            pnlStatsGrid = new TableLayoutPanel();
            pnlStatPending = new RoundedPanel();
            lblPendingIcon = new Label();
            lblPendingNumber = new Label();
            lblPendingTitle = new Label();
            pnlStatMedicines = new RoundedPanel();
            lblMedicineIcon = new Label();
            lblMedicineNumber = new Label();
            lblMedicineTitle = new Label();
            pnlStatLowStock = new RoundedPanel();
            lblLowStockIcon = new Label();
            lblLowStockNumber = new Label();
            lblLowStockTitle = new Label();
            pnlStatDispensed = new RoundedPanel();
            lblDispensedIcon = new Label();
            lblDispensedNumber = new Label();
            lblDispensedTitle = new Label();
            pnlShift = new RoundedPanel();
            lblShiftTitle = new Label();
            lblShiftBadge = new Label();
            pnlShiftBox = new RoundedPanel();
            lblShiftName = new Label();
            lblShiftTime = new Label();
            lblShiftRoom = new Label();
            lblShiftDept = new Label();
            btnViewWeek = new Button();
            btnChangeShift = new Button();
            lblShiftFooter = new Label();
            pnlColumns = new TableLayoutPanel();
            pnlPendingPrescriptions = new RoundedPanel();
            lblPrescriptionTitle = new Label();
            lblViewAll = new Label();
            pnlPrescriptionOne = new RoundedPanel();
            lblPatientOne = new Label();
            lblDoctorOne = new Label();
            lblDrugCountOne = new Label();
            lblTimeOne = new Label();
            lblStatusOne = new Label();
            pnlPrescriptionTwo = new RoundedPanel();
            lblPatientTwo = new Label();
            lblDoctorTwo = new Label();
            lblDrugCountTwo = new Label();
            lblTimeTwo = new Label();
            lblStatusTwo = new Label();
            pnlInventoryAlerts = new RoundedPanel();
            lblAlertTitle = new Label();
            lblAlertIcon = new Label();
            pnlAlertOne = new RoundedPanel();
            lblAlertMedOne = new Label();
            lblAlertStockOne = new Label();
            lblAlertMinOne = new Label();
            progressAlertOne = new ProgressBar();
            pnlAlertTwo = new RoundedPanel();
            lblAlertMedTwo = new Label();
            lblAlertStockTwo = new Label();
            lblAlertMinTwo = new Label();
            progressAlertTwo = new ProgressBar();
            pnlQuickActions = new RoundedPanel();
            lblActionsTitle = new Label();
            pnlActionGrid = new TableLayoutPanel();
            pnlActDispense = new RoundedPanel();
            lblActDispenseIcon = new Label();
            lblActDispenseTitle = new Label();
            lblActDispenseDesc = new Label();
            pnlActInventory = new RoundedPanel();
            lblActInventoryIcon = new Label();
            lblActInventoryTitle = new Label();
            lblActInventoryDesc = new Label();
            pnlActReports = new RoundedPanel();
            lblActReportsIcon = new Label();
            lblActReportsTitle = new Label();
            lblActReportsDesc = new Label();
            pnlActStocktake = new RoundedPanel();
            lblActStocktakeIcon = new Label();
            lblActStocktakeTitle = new Label();
            lblActStocktakeDesc = new Label();
            viewHostPanel.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlStatPending.SuspendLayout();
            pnlStatMedicines.SuspendLayout();
            pnlStatLowStock.SuspendLayout();
            pnlStatDispensed.SuspendLayout();
            pnlShift.SuspendLayout();
            pnlShiftBox.SuspendLayout();
            pnlColumns.SuspendLayout();
            pnlPendingPrescriptions.SuspendLayout();
            pnlPrescriptionOne.SuspendLayout();
            pnlPrescriptionTwo.SuspendLayout();
            pnlInventoryAlerts.SuspendLayout();
            pnlAlertOne.SuspendLayout();
            pnlAlertTwo.SuspendLayout();
            pnlQuickActions.SuspendLayout();
            pnlActionGrid.SuspendLayout();
            pnlActDispense.SuspendLayout();
            pnlActInventory.SuspendLayout();
            pnlActReports.SuspendLayout();
            pnlActStocktake.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = true;
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Controls.Add(pnlQuickActions);
            viewHostPanel.Controls.Add(pnlColumns);
            viewHostPanel.Controls.Add(pnlShift);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1244, 920);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 4;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.Controls.Add(pnlStatPending, 0, 0);
            pnlStatsGrid.Controls.Add(pnlStatMedicines, 1, 0);
            pnlStatsGrid.Controls.Add(pnlStatLowStock, 2, 0);
            pnlStatsGrid.Controls.Add(pnlStatDispensed, 3, 0);
            pnlStatsGrid.Location = new Point(24, 24);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1196, 150);
            pnlStatsGrid.TabIndex = 0;
            // 
            // stat cards
            // 
            ConfigureCard(pnlStatPending, Color.FromArgb(239, 246, 255), Color.FromArgb(191, 219, 254));
            ConfigureCard(pnlStatMedicines, Color.FromArgb(240, 253, 244), Color.FromArgb(187, 247, 208));
            ConfigureCard(pnlStatLowStock, Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202));
            ConfigureCard(pnlStatDispensed, Color.FromArgb(250, 245, 255), Color.FromArgb(233, 213, 255));
            pnlStatPending.Margin = new Padding(0, 0, 14, 0);
            pnlStatMedicines.Margin = new Padding(0, 0, 14, 0);
            pnlStatLowStock.Margin = new Padding(0, 0, 14, 0);
            pnlStatDispensed.Margin = new Padding(0);
            pnlStatPending.Controls.Add(lblPendingIcon);
            pnlStatPending.Controls.Add(lblPendingNumber);
            pnlStatPending.Controls.Add(lblPendingTitle);
            pnlStatMedicines.Controls.Add(lblMedicineIcon);
            pnlStatMedicines.Controls.Add(lblMedicineNumber);
            pnlStatMedicines.Controls.Add(lblMedicineTitle);
            pnlStatLowStock.Controls.Add(lblLowStockIcon);
            pnlStatLowStock.Controls.Add(lblLowStockNumber);
            pnlStatLowStock.Controls.Add(lblLowStockTitle);
            pnlStatDispensed.Controls.Add(lblDispensedIcon);
            pnlStatDispensed.Controls.Add(lblDispensedNumber);
            pnlStatDispensed.Controls.Add(lblDispensedTitle);
            SetupIcon(lblPendingIcon, "◊", Color.FromArgb(47, 94, 240));
            SetupIcon(lblMedicineIcon, "□", Color.FromArgb(34, 139, 74));
            SetupIcon(lblLowStockIcon, "!", Color.FromArgb(220, 38, 38));
            SetupIcon(lblDispensedIcon, "↗", Color.FromArgb(147, 51, 234));
            SetupStatText(lblPendingNumber, "15", Color.FromArgb(47, 94, 240), 82);
            SetupStatTitle(lblPendingTitle, "Đơn thuốc chờ", Color.FromArgb(47, 94, 240));
            SetupStatText(lblMedicineNumber, "248", Color.FromArgb(34, 139, 74), 82);
            SetupStatTitle(lblMedicineTitle, "Loại thuốc trong kho", Color.FromArgb(34, 139, 74));
            SetupStatText(lblLowStockNumber, "8", Color.FromArgb(220, 38, 38), 82);
            SetupStatTitle(lblLowStockTitle, "Thuốc sắp hết", Color.FromArgb(220, 38, 38));
            SetupStatText(lblDispensedNumber, "45", Color.FromArgb(147, 51, 234), 82);
            SetupStatTitle(lblDispensedTitle, "Đã cấp phát hôm nay", Color.FromArgb(147, 51, 234));
            // 
            // pnlShift
            // 
            ConfigureCard(pnlShift, Color.White, Color.FromArgb(229, 231, 235));
            pnlShift.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShift.Controls.Add(lblShiftFooter);
            pnlShift.Controls.Add(btnChangeShift);
            pnlShift.Controls.Add(btnViewWeek);
            pnlShift.Controls.Add(pnlShiftBox);
            pnlShift.Controls.Add(lblShiftBadge);
            pnlShift.Controls.Add(lblShiftTitle);
            pnlShift.Location = new Point(24, 194);
            pnlShift.Name = "pnlShift";
            pnlShift.Size = new Size(1196, 260);
            pnlShift.TabIndex = 1;
            SetupLabel(lblShiftTitle, "◷  Ca làm việc hôm nay", 13F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 18, 18, 420, 28);
            SetupBadge(lblShiftBadge, "• Đang trực", Color.FromArgb(220, 252, 231), Color.FromArgb(34, 139, 74), 1078, 18, 100, 28);
            ConfigureCard(pnlShiftBox, Color.FromArgb(219, 234, 254), Color.FromArgb(147, 197, 253));
            pnlShiftBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShiftBox.Controls.Add(lblShiftDept);
            pnlShiftBox.Controls.Add(lblShiftRoom);
            pnlShiftBox.Controls.Add(lblShiftTime);
            pnlShiftBox.Controls.Add(lblShiftName);
            pnlShiftBox.Location = new Point(22, 70);
            pnlShiftBox.Name = "pnlShiftBox";
            pnlShiftBox.Size = new Size(1150, 90);
            pnlShiftBox.TabIndex = 2;
            SetupLabel(lblShiftName, "Sáng", 18F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 18, 18, 120, 30);
            SetupLabel(lblShiftTime, "(07:00 - 12:00)", 9F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 118, 23, 160, 24);
            SetupLabel(lblShiftRoom, "⌖  P.101", 9F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 18, 55, 160, 24);
            SetupLabel(lblShiftDept, "⚕  Nội khoa", 9F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 620, 55, 180, 24);
            SetupButton(btnViewWeek, "▣  Xem lịch tuần", Color.FromArgb(239, 246, 255), Color.FromArgb(47, 94, 240), 22, 180, 550, 38);
            SetupButton(btnChangeShift, "Đổi ca", Color.FromArgb(243, 244, 246), Color.FromArgb(31, 41, 55), 588, 180, 584, 38);
            SetupLabel(lblShiftFooter, "Còn 4 ca trong tuần này", 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 0, 226, 1196, 24, ContentAlignment.MiddleCenter);
            // 
            // pnlColumns
            // 
            pnlColumns.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlColumns.ColumnCount = 2;
            pnlColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlColumns.Controls.Add(pnlPendingPrescriptions, 0, 0);
            pnlColumns.Controls.Add(pnlInventoryAlerts, 1, 0);
            pnlColumns.Location = new Point(24, 474);
            pnlColumns.Name = "pnlColumns";
            pnlColumns.RowCount = 1;
            pnlColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlColumns.Size = new Size(1196, 310);
            pnlColumns.TabIndex = 2;
            // 
            // pending prescriptions
            // 
            ConfigureCard(pnlPendingPrescriptions, Color.White, Color.FromArgb(229, 231, 235));
            pnlPendingPrescriptions.Controls.Add(pnlPrescriptionTwo);
            pnlPendingPrescriptions.Controls.Add(pnlPrescriptionOne);
            pnlPendingPrescriptions.Controls.Add(lblViewAll);
            pnlPendingPrescriptions.Controls.Add(lblPrescriptionTitle);
            pnlPendingPrescriptions.Dock = DockStyle.Fill;
            pnlPendingPrescriptions.Margin = new Padding(0, 0, 14, 0);
            SetupLabel(lblPrescriptionTitle, "Đơn thuốc chờ cấp", 13F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 18, 22, 320, 28);
            SetupLabel(lblViewAll, "Xem tất cả", 9F, FontStyle.Bold, Color.FromArgb(47, 94, 240), 490, 24, 80, 22, ContentAlignment.MiddleRight);
            ConfigureCard(pnlPrescriptionOne, Color.FromArgb(249, 250, 251), Color.FromArgb(229, 231, 235));
            pnlPrescriptionOne.Controls.Add(lblStatusOne);
            pnlPrescriptionOne.Controls.Add(lblTimeOne);
            pnlPrescriptionOne.Controls.Add(lblDrugCountOne);
            pnlPrescriptionOne.Controls.Add(lblDoctorOne);
            pnlPrescriptionOne.Controls.Add(lblPatientOne);
            pnlPrescriptionOne.Location = new Point(22, 78);
            pnlPrescriptionOne.Size = new Size(540, 82);
            SetupLabel(lblPatientOne, "Nguyễn Văn A", 10F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 14, 14, 220, 22);
            SetupLabel(lblDoctorOne, "BS: BS. Trần B", 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 14, 38, 240, 22);
            SetupLabel(lblDrugCountOne, "3 loại thuốc", 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 14, 62, 160, 20);
            SetupLabel(lblTimeOne, "09:30", 8.5F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 460, 56, 60, 20, ContentAlignment.MiddleRight);
            SetupBadge(lblStatusOne, "Chờ lấy thuốc", Color.FromArgb(254, 249, 195), Color.FromArgb(161, 98, 7), 410, 26, 110, 26);
            ConfigureCard(pnlPrescriptionTwo, Color.FromArgb(249, 250, 251), Color.FromArgb(229, 231, 235));
            pnlPrescriptionTwo.Controls.Add(lblStatusTwo);
            pnlPrescriptionTwo.Controls.Add(lblTimeTwo);
            pnlPrescriptionTwo.Controls.Add(lblDrugCountTwo);
            pnlPrescriptionTwo.Controls.Add(lblDoctorTwo);
            pnlPrescriptionTwo.Controls.Add(lblPatientTwo);
            pnlPrescriptionTwo.Location = new Point(22, 174);
            pnlPrescriptionTwo.Size = new Size(540, 82);
            SetupLabel(lblPatientTwo, "Lê Thị C", 10F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 14, 14, 220, 22);
            SetupLabel(lblDoctorTwo, "BS: BS. Phạm D", 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 14, 38, 240, 22);
            SetupLabel(lblDrugCountTwo, "5 loại thuốc", 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 14, 62, 160, 20);
            SetupLabel(lblTimeTwo, "10:15", 8.5F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 460, 56, 60, 20, ContentAlignment.MiddleRight);
            SetupBadge(lblStatusTwo, "Đang chuẩn bị", Color.FromArgb(219, 234, 254), Color.FromArgb(47, 94, 240), 410, 26, 110, 26);
            // 
            // inventory alerts
            // 
            ConfigureCard(pnlInventoryAlerts, Color.White, Color.FromArgb(229, 231, 235));
            pnlInventoryAlerts.Controls.Add(pnlAlertTwo);
            pnlInventoryAlerts.Controls.Add(pnlAlertOne);
            pnlInventoryAlerts.Controls.Add(lblAlertIcon);
            pnlInventoryAlerts.Controls.Add(lblAlertTitle);
            pnlInventoryAlerts.Dock = DockStyle.Fill;
            pnlInventoryAlerts.Margin = new Padding(0);
            SetupLabel(lblAlertTitle, "Cảnh báo tồn kho", 13F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 18, 22, 320, 28);
            SetupLabel(lblAlertIcon, "!", 16F, FontStyle.Bold, Color.FromArgb(239, 68, 68), 548, 20, 30, 30, ContentAlignment.MiddleCenter);
            ConfigureCard(pnlAlertOne, Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202));
            pnlAlertOne.Controls.Add(progressAlertOne);
            pnlAlertOne.Controls.Add(lblAlertMinOne);
            pnlAlertOne.Controls.Add(lblAlertStockOne);
            pnlAlertOne.Controls.Add(lblAlertMedOne);
            pnlAlertOne.Location = new Point(22, 78);
            pnlAlertOne.Size = new Size(540, 92);
            SetupLabel(lblAlertMedOne, "Paracetamol 500mg", 10F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 14, 12, 260, 24);
            SetupLabel(lblAlertStockOne, "Tồn kho:                                   45 viên", 9F, FontStyle.Regular, Color.FromArgb(220, 38, 38), 14, 42, 500, 22);
            SetupLabel(lblAlertMinOne, "Tối thiểu:                                100 viên", 9F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 14, 62, 500, 22);
            SetupProgress(progressAlertOne, 14, 78, 500, 8, 45);
            ConfigureCard(pnlAlertTwo, Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202));
            pnlAlertTwo.Controls.Add(progressAlertTwo);
            pnlAlertTwo.Controls.Add(lblAlertMinTwo);
            pnlAlertTwo.Controls.Add(lblAlertStockTwo);
            pnlAlertTwo.Controls.Add(lblAlertMedTwo);
            pnlAlertTwo.Location = new Point(22, 184);
            pnlAlertTwo.Size = new Size(540, 92);
            SetupLabel(lblAlertMedTwo, "Amoxicillin 250mg", 10F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 14, 12, 260, 24);
            SetupLabel(lblAlertStockTwo, "Tồn kho:                                   78 viên", 9F, FontStyle.Regular, Color.FromArgb(220, 38, 38), 14, 42, 500, 22);
            SetupLabel(lblAlertMinTwo, "Tối thiểu:                                150 viên", 9F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 14, 62, 500, 22);
            SetupProgress(progressAlertTwo, 14, 78, 500, 8, 52);
            // 
            // quick actions
            // 
            ConfigureCard(pnlQuickActions, Color.White, Color.FromArgb(229, 231, 235));
            pnlQuickActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuickActions.Controls.Add(pnlActionGrid);
            pnlQuickActions.Controls.Add(lblActionsTitle);
            pnlQuickActions.Location = new Point(24, 804);
            pnlQuickActions.Name = "pnlQuickActions";
            pnlQuickActions.Size = new Size(1196, 160);
            pnlQuickActions.TabIndex = 3;
            SetupLabel(lblActionsTitle, "Hành động nhanh", 13F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 18, 18, 420, 28);
            pnlActionGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActionGrid.ColumnCount = 4;
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlActionGrid.Controls.Add(pnlActDispense, 0, 0);
            pnlActionGrid.Controls.Add(pnlActInventory, 1, 0);
            pnlActionGrid.Controls.Add(pnlActReports, 2, 0);
            pnlActionGrid.Controls.Add(pnlActStocktake, 3, 0);
            pnlActionGrid.Location = new Point(22, 58);
            pnlActionGrid.Name = "pnlActionGrid";
            pnlActionGrid.RowCount = 1;
            pnlActionGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlActionGrid.Size = new Size(1150, 82);
            ConfigureAction(pnlActDispense, lblActDispenseIcon, lblActDispenseTitle, lblActDispenseDesc, "◊", "Cấp phát thuốc", "Theo đơn", Color.FromArgb(239, 246, 255), Color.FromArgb(47, 94, 240), new Padding(0, 0, 14, 0));
            ConfigureAction(pnlActInventory, lblActInventoryIcon, lblActInventoryTitle, lblActInventoryDesc, "□", "Quản lý kho", "Nhập/Xuất", Color.FromArgb(240, 253, 244), Color.FromArgb(34, 139, 74), new Padding(0, 0, 14, 0));
            ConfigureAction(pnlActReports, lblActReportsIcon, lblActReportsTitle, lblActReportsDesc, "▥", "Thống kê", "Báo cáo", Color.FromArgb(250, 245, 255), Color.FromArgb(147, 51, 234), new Padding(0, 0, 14, 0));
            ConfigureAction(pnlActStocktake, lblActStocktakeIcon, lblActStocktakeTitle, lblActStocktakeDesc, "!", "Kiểm kê", "Hàng tồn", Color.FromArgb(255, 247, 237), Color.FromArgb(234, 88, 12), new Padding(0));
            // 
            // ucPharmacyOverview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "ucPharmacyOverview";
            Size = new Size(1244, 1000);
            Load += ucPharmacyOverview_Load;
            viewHostPanel.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlStatPending.ResumeLayout(false);
            pnlStatMedicines.ResumeLayout(false);
            pnlStatLowStock.ResumeLayout(false);
            pnlStatDispensed.ResumeLayout(false);
            pnlShift.ResumeLayout(false);
            pnlShiftBox.ResumeLayout(false);
            pnlColumns.ResumeLayout(false);
            pnlPendingPrescriptions.ResumeLayout(false);
            pnlPrescriptionOne.ResumeLayout(false);
            pnlPrescriptionTwo.ResumeLayout(false);
            pnlInventoryAlerts.ResumeLayout(false);
            pnlAlertOne.ResumeLayout(false);
            pnlAlertTwo.ResumeLayout(false);
            pnlQuickActions.ResumeLayout(false);
            pnlActionGrid.ResumeLayout(false);
            pnlActDispense.ResumeLayout(false);
            pnlActInventory.ResumeLayout(false);
            pnlActReports.ResumeLayout(false);
            pnlActStocktake.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureCard(RoundedPanel panel, Color fill, Color border)
        {
            panel.BackColor = fill;
            panel.BorderColor = border;
            panel.CornerRadius = 8;
            panel.Dock = DockStyle.Fill;
            panel.FillColor = fill;
        }

        private static void SetupLabel(Label label, string text, float size, FontStyle style, Color color, int x, int y, int width, int height, ContentAlignment align = ContentAlignment.MiddleLeft)
        {
            label.Font = new Font("Segoe UI", size, style);
            label.ForeColor = color;
            label.Location = new Point(x, y);
            label.Size = new Size(width, height);
            label.Text = text;
            label.TextAlign = align;
        }

        private static void SetupIcon(Label label, string text, Color color)
        {
            SetupLabel(label, text, 18F, FontStyle.Bold, color, 22, 22, 48, 48, ContentAlignment.MiddleCenter);
            label.BackColor = Color.White;
        }

        private static void SetupStatText(Label label, string text, Color color, int y)
        {
            SetupLabel(label, text, 22F, FontStyle.Bold, color, 24, y, 120, 38);
        }

        private static void SetupStatTitle(Label label, string text, Color color)
        {
            SetupLabel(label, text, 9.5F, FontStyle.Regular, color, 24, 118, 260, 24);
        }

        private static void SetupBadge(Label label, string text, Color back, Color fore, int x, int y, int width, int height)
        {
            SetupLabel(label, text, 8.5F, FontStyle.Bold, fore, x, y, width, height, ContentAlignment.MiddleCenter);
            label.BackColor = back;
        }

        private static void SetupButton(Button button, string text, Color back, Color fore, int x, int y, int width, int height)
        {
            button.BackColor = back;
            button.Cursor = Cursors.Hand;
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.ForeColor = fore;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private static void SetupProgress(ProgressBar progressBar, int x, int y, int width, int height, int value)
        {
            progressBar.Location = new Point(x, y);
            progressBar.Size = new Size(width, height);
            progressBar.Value = value;
        }

        private static void ConfigureAction(RoundedPanel panel, Label icon, Label title, Label desc, string iconText, string titleText, string descText, Color fill, Color accent, Padding margin)
        {
            ConfigureCard(panel, fill, fill);
            panel.Cursor = Cursors.Hand;
            panel.Margin = margin;
            SetupLabel(icon, iconText, 18F, FontStyle.Bold, accent, 20, 12, 36, 36, ContentAlignment.MiddleCenter);
            SetupLabel(title, titleText, 10.5F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 68, 14, 180, 26);
            SetupLabel(desc, descText, 9F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 68, 42, 180, 22);
            panel.Controls.Add(icon);
            panel.Controls.Add(title);
            panel.Controls.Add(desc);
        }

        private RoundedPanel viewHostPanel;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlStatPending;
        private Label lblPendingIcon;
        private Label lblPendingNumber;
        private Label lblPendingTitle;
        private RoundedPanel pnlStatMedicines;
        private Label lblMedicineIcon;
        private Label lblMedicineNumber;
        private Label lblMedicineTitle;
        private RoundedPanel pnlStatLowStock;
        private Label lblLowStockIcon;
        private Label lblLowStockNumber;
        private Label lblLowStockTitle;
        private RoundedPanel pnlStatDispensed;
        private Label lblDispensedIcon;
        private Label lblDispensedNumber;
        private Label lblDispensedTitle;
        private RoundedPanel pnlShift;
        private Label lblShiftTitle;
        private Label lblShiftBadge;
        private RoundedPanel pnlShiftBox;
        private Label lblShiftName;
        private Label lblShiftTime;
        private Label lblShiftRoom;
        private Label lblShiftDept;
        private Button btnViewWeek;
        private Button btnChangeShift;
        private Label lblShiftFooter;
        private TableLayoutPanel pnlColumns;
        private RoundedPanel pnlPendingPrescriptions;
        private Label lblPrescriptionTitle;
        private Label lblViewAll;
        private RoundedPanel pnlPrescriptionOne;
        private Label lblPatientOne;
        private Label lblDoctorOne;
        private Label lblDrugCountOne;
        private Label lblTimeOne;
        private Label lblStatusOne;
        private RoundedPanel pnlPrescriptionTwo;
        private Label lblPatientTwo;
        private Label lblDoctorTwo;
        private Label lblDrugCountTwo;
        private Label lblTimeTwo;
        private Label lblStatusTwo;
        private RoundedPanel pnlInventoryAlerts;
        private Label lblAlertTitle;
        private Label lblAlertIcon;
        private RoundedPanel pnlAlertOne;
        private Label lblAlertMedOne;
        private Label lblAlertStockOne;
        private Label lblAlertMinOne;
        private ProgressBar progressAlertOne;
        private RoundedPanel pnlAlertTwo;
        private Label lblAlertMedTwo;
        private Label lblAlertStockTwo;
        private Label lblAlertMinTwo;
        private ProgressBar progressAlertTwo;
        private RoundedPanel pnlQuickActions;
        private Label lblActionsTitle;
        private TableLayoutPanel pnlActionGrid;
        private RoundedPanel pnlActDispense;
        private Label lblActDispenseIcon;
        private Label lblActDispenseTitle;
        private Label lblActDispenseDesc;
        private RoundedPanel pnlActInventory;
        private Label lblActInventoryIcon;
        private Label lblActInventoryTitle;
        private Label lblActInventoryDesc;
        private RoundedPanel pnlActReports;
        private Label lblActReportsIcon;
        private Label lblActReportsTitle;
        private Label lblActReportsDesc;
        private RoundedPanel pnlActStocktake;
        private Label lblActStocktakeIcon;
        private Label lblActStocktakeTitle;
        private Label lblActStocktakeDesc;
    }
}
