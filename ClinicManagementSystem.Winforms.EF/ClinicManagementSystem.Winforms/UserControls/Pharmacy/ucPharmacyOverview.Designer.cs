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
            pnlQuickActions = new RoundedPanel();
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
            lblActionsTitle = new Label();
            pnlColumns = new TableLayoutPanel();
            pnlPendingPrescriptions = new RoundedPanel();
            pnlPrescriptionTwo = new RoundedPanel();
            lblStatusTwo = new Label();
            lblTimeTwo = new Label();
            lblDrugCountTwo = new Label();
            lblDoctorTwo = new Label();
            lblPatientTwo = new Label();
            pnlPrescriptionOne = new RoundedPanel();
            lblStatusOne = new Label();
            lblTimeOne = new Label();
            lblDrugCountOne = new Label();
            lblDoctorOne = new Label();
            lblPatientOne = new Label();
            lblViewAll = new Label();
            lblPrescriptionTitle = new Label();
            pnlInventoryAlerts = new RoundedPanel();
            pnlAlertTwo = new RoundedPanel();
            progressAlertTwo = new ProgressBar();
            lblAlertMinTwo = new Label();
            lblAlertStockTwo = new Label();
            lblAlertMedTwo = new Label();
            pnlAlertOne = new RoundedPanel();
            progressAlertOne = new ProgressBar();
            lblAlertMinOne = new Label();
            lblAlertStockOne = new Label();
            lblAlertMedOne = new Label();
            lblAlertIcon = new Label();
            lblAlertTitle = new Label();
            pnlShift = new RoundedPanel();
            lblShiftFooter = new Label();
            btnChangeShift = new Button();
            btnViewWeek = new Button();
            pnlShiftBox = new RoundedPanel();
            lblShiftDept = new Label();
            lblShiftRoom = new Label();
            lblShiftTime = new Label();
            lblShiftName = new Label();
            lblShiftBadge = new Label();
            lblShiftTitle = new Label();
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
            viewHostPanel.SuspendLayout();
            pnlQuickActions.SuspendLayout();
            pnlActionGrid.SuspendLayout();
            pnlActDispense.SuspendLayout();
            pnlActInventory.SuspendLayout();
            pnlActReports.SuspendLayout();
            pnlActStocktake.SuspendLayout();
            pnlColumns.SuspendLayout();
            pnlPendingPrescriptions.SuspendLayout();
            pnlPrescriptionTwo.SuspendLayout();
            pnlPrescriptionOne.SuspendLayout();
            pnlInventoryAlerts.SuspendLayout();
            pnlAlertTwo.SuspendLayout();
            pnlAlertOne.SuspendLayout();
            pnlShift.SuspendLayout();
            pnlShiftBox.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlStatPending.SuspendLayout();
            pnlStatMedicines.SuspendLayout();
            pnlStatLowStock.SuspendLayout();
            pnlStatDispensed.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = true;
            viewHostPanel.BackColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlQuickActions);
            viewHostPanel.Controls.Add(pnlColumns);
            viewHostPanel.Controls.Add(pnlShift);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(5, 6, 5, 6);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(2133, 2000);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlQuickActions
            // 
            pnlQuickActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuickActions.BackColor = Color.White;
            pnlQuickActions.BorderColor = Color.FromArgb(229, 231, 235);
            pnlQuickActions.BorderWidth = 1;
            pnlQuickActions.Controls.Add(pnlActionGrid);
            pnlQuickActions.Controls.Add(lblActionsTitle);
            pnlQuickActions.CornerRadius = 8;
            pnlQuickActions.FillColor = Color.White;
            pnlQuickActions.Location = new Point(41, 1608);
            pnlQuickActions.Margin = new Padding(5, 6, 5, 6);
            pnlQuickActions.Name = "pnlQuickActions";
            pnlQuickActions.Size = new Size(2050, 320);
            pnlQuickActions.TabIndex = 3;
            // 
            // pnlActionGrid
            // 
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
            pnlActionGrid.Location = new Point(38, 116);
            pnlActionGrid.Margin = new Padding(5, 6, 5, 6);
            pnlActionGrid.Name = "pnlActionGrid";
            pnlActionGrid.RowCount = 1;
            pnlActionGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlActionGrid.Size = new Size(1971, 164);
            pnlActionGrid.TabIndex = 0;
            // 
            // pnlActDispense
            // 
            pnlActDispense.BackColor = Color.FromArgb(239, 246, 255);
            pnlActDispense.BorderColor = Color.FromArgb(239, 246, 255);
            pnlActDispense.BorderWidth = 1;
            pnlActDispense.Controls.Add(lblActDispenseIcon);
            pnlActDispense.Controls.Add(lblActDispenseTitle);
            pnlActDispense.Controls.Add(lblActDispenseDesc);
            pnlActDispense.CornerRadius = 8;
            pnlActDispense.Cursor = Cursors.Hand;
            pnlActDispense.FillColor = Color.FromArgb(239, 246, 255);
            pnlActDispense.Location = new Point(0, 0);
            pnlActDispense.Margin = new Padding(0, 0, 24, 0);
            pnlActDispense.Name = "pnlActDispense";
            pnlActDispense.Size = new Size(343, 164);
            pnlActDispense.TabIndex = 0;
            // 
            // lblActDispenseIcon
            // 
            lblActDispenseIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActDispenseIcon.ForeColor = Color.FromArgb(47, 94, 240);
            lblActDispenseIcon.Location = new Point(34, 24);
            lblActDispenseIcon.Margin = new Padding(5, 0, 5, 0);
            lblActDispenseIcon.Name = "lblActDispenseIcon";
            lblActDispenseIcon.Size = new Size(62, 72);
            lblActDispenseIcon.TabIndex = 0;
            lblActDispenseIcon.Text = "◊";
            lblActDispenseIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActDispenseTitle
            // 
            lblActDispenseTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActDispenseTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActDispenseTitle.Location = new Point(117, 28);
            lblActDispenseTitle.Margin = new Padding(5, 0, 5, 0);
            lblActDispenseTitle.Name = "lblActDispenseTitle";
            lblActDispenseTitle.Size = new Size(309, 52);
            lblActDispenseTitle.TabIndex = 1;
            lblActDispenseTitle.Text = "Cấp phát thuốc";
            lblActDispenseTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActDispenseDesc
            // 
            lblActDispenseDesc.Font = new Font("Segoe UI", 9F);
            lblActDispenseDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActDispenseDesc.Location = new Point(117, 84);
            lblActDispenseDesc.Margin = new Padding(5, 0, 5, 0);
            lblActDispenseDesc.Name = "lblActDispenseDesc";
            lblActDispenseDesc.Size = new Size(309, 44);
            lblActDispenseDesc.TabIndex = 2;
            lblActDispenseDesc.Text = "Theo đơn";
            lblActDispenseDesc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlActInventory
            // 
            pnlActInventory.BackColor = Color.FromArgb(240, 253, 244);
            pnlActInventory.BorderColor = Color.FromArgb(240, 253, 244);
            pnlActInventory.BorderWidth = 1;
            pnlActInventory.Controls.Add(lblActInventoryIcon);
            pnlActInventory.Controls.Add(lblActInventoryTitle);
            pnlActInventory.Controls.Add(lblActInventoryDesc);
            pnlActInventory.CornerRadius = 8;
            pnlActInventory.Cursor = Cursors.Hand;
            pnlActInventory.FillColor = Color.FromArgb(240, 253, 244);
            pnlActInventory.Location = new Point(492, 0);
            pnlActInventory.Margin = new Padding(0, 0, 24, 0);
            pnlActInventory.Name = "pnlActInventory";
            pnlActInventory.Size = new Size(343, 164);
            pnlActInventory.TabIndex = 1;
            // 
            // lblActInventoryIcon
            // 
            lblActInventoryIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActInventoryIcon.ForeColor = Color.FromArgb(34, 139, 74);
            lblActInventoryIcon.Location = new Point(34, 24);
            lblActInventoryIcon.Margin = new Padding(5, 0, 5, 0);
            lblActInventoryIcon.Name = "lblActInventoryIcon";
            lblActInventoryIcon.Size = new Size(62, 72);
            lblActInventoryIcon.TabIndex = 0;
            lblActInventoryIcon.Text = "□";
            lblActInventoryIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActInventoryTitle
            // 
            lblActInventoryTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActInventoryTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActInventoryTitle.Location = new Point(117, 28);
            lblActInventoryTitle.Margin = new Padding(5, 0, 5, 0);
            lblActInventoryTitle.Name = "lblActInventoryTitle";
            lblActInventoryTitle.Size = new Size(309, 52);
            lblActInventoryTitle.TabIndex = 1;
            lblActInventoryTitle.Text = "Quản lý kho";
            lblActInventoryTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActInventoryDesc
            // 
            lblActInventoryDesc.Font = new Font("Segoe UI", 9F);
            lblActInventoryDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActInventoryDesc.Location = new Point(117, 84);
            lblActInventoryDesc.Margin = new Padding(5, 0, 5, 0);
            lblActInventoryDesc.Name = "lblActInventoryDesc";
            lblActInventoryDesc.Size = new Size(309, 44);
            lblActInventoryDesc.TabIndex = 2;
            lblActInventoryDesc.Text = "Nhập/Xuất";
            lblActInventoryDesc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlActReports
            // 
            pnlActReports.BackColor = Color.FromArgb(250, 245, 255);
            pnlActReports.BorderColor = Color.FromArgb(250, 245, 255);
            pnlActReports.BorderWidth = 1;
            pnlActReports.Controls.Add(lblActReportsIcon);
            pnlActReports.Controls.Add(lblActReportsTitle);
            pnlActReports.Controls.Add(lblActReportsDesc);
            pnlActReports.CornerRadius = 8;
            pnlActReports.Cursor = Cursors.Hand;
            pnlActReports.FillColor = Color.FromArgb(250, 245, 255);
            pnlActReports.Location = new Point(984, 0);
            pnlActReports.Margin = new Padding(0, 0, 24, 0);
            pnlActReports.Name = "pnlActReports";
            pnlActReports.Size = new Size(343, 164);
            pnlActReports.TabIndex = 2;
            // 
            // lblActReportsIcon
            // 
            lblActReportsIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActReportsIcon.ForeColor = Color.FromArgb(147, 51, 234);
            lblActReportsIcon.Location = new Point(34, 24);
            lblActReportsIcon.Margin = new Padding(5, 0, 5, 0);
            lblActReportsIcon.Name = "lblActReportsIcon";
            lblActReportsIcon.Size = new Size(62, 72);
            lblActReportsIcon.TabIndex = 0;
            lblActReportsIcon.Text = "▥";
            lblActReportsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActReportsTitle
            // 
            lblActReportsTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActReportsTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActReportsTitle.Location = new Point(117, 28);
            lblActReportsTitle.Margin = new Padding(5, 0, 5, 0);
            lblActReportsTitle.Name = "lblActReportsTitle";
            lblActReportsTitle.Size = new Size(309, 52);
            lblActReportsTitle.TabIndex = 1;
            lblActReportsTitle.Text = "Thống kê";
            lblActReportsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActReportsDesc
            // 
            lblActReportsDesc.Font = new Font("Segoe UI", 9F);
            lblActReportsDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActReportsDesc.Location = new Point(117, 84);
            lblActReportsDesc.Margin = new Padding(5, 0, 5, 0);
            lblActReportsDesc.Name = "lblActReportsDesc";
            lblActReportsDesc.Size = new Size(309, 44);
            lblActReportsDesc.TabIndex = 2;
            lblActReportsDesc.Text = "Báo cáo";
            lblActReportsDesc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlActStocktake
            // 
            pnlActStocktake.BackColor = Color.FromArgb(255, 247, 237);
            pnlActStocktake.BorderColor = Color.FromArgb(255, 247, 237);
            pnlActStocktake.BorderWidth = 1;
            pnlActStocktake.Controls.Add(lblActStocktakeIcon);
            pnlActStocktake.Controls.Add(lblActStocktakeTitle);
            pnlActStocktake.Controls.Add(lblActStocktakeDesc);
            pnlActStocktake.CornerRadius = 8;
            pnlActStocktake.Cursor = Cursors.Hand;
            pnlActStocktake.FillColor = Color.FromArgb(255, 247, 237);
            pnlActStocktake.Location = new Point(1476, 0);
            pnlActStocktake.Margin = new Padding(0);
            pnlActStocktake.Name = "pnlActStocktake";
            pnlActStocktake.Size = new Size(343, 164);
            pnlActStocktake.TabIndex = 3;
            // 
            // lblActStocktakeIcon
            // 
            lblActStocktakeIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblActStocktakeIcon.ForeColor = Color.FromArgb(234, 88, 12);
            lblActStocktakeIcon.Location = new Point(34, 24);
            lblActStocktakeIcon.Margin = new Padding(5, 0, 5, 0);
            lblActStocktakeIcon.Name = "lblActStocktakeIcon";
            lblActStocktakeIcon.Size = new Size(62, 72);
            lblActStocktakeIcon.TabIndex = 0;
            lblActStocktakeIcon.Text = "!";
            lblActStocktakeIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblActStocktakeTitle
            // 
            lblActStocktakeTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblActStocktakeTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActStocktakeTitle.Location = new Point(117, 28);
            lblActStocktakeTitle.Margin = new Padding(5, 0, 5, 0);
            lblActStocktakeTitle.Name = "lblActStocktakeTitle";
            lblActStocktakeTitle.Size = new Size(309, 52);
            lblActStocktakeTitle.TabIndex = 1;
            lblActStocktakeTitle.Text = "Kiểm kê";
            lblActStocktakeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActStocktakeDesc
            // 
            lblActStocktakeDesc.Font = new Font("Segoe UI", 9F);
            lblActStocktakeDesc.ForeColor = Color.FromArgb(107, 114, 128);
            lblActStocktakeDesc.Location = new Point(117, 84);
            lblActStocktakeDesc.Margin = new Padding(5, 0, 5, 0);
            lblActStocktakeDesc.Name = "lblActStocktakeDesc";
            lblActStocktakeDesc.Size = new Size(309, 44);
            lblActStocktakeDesc.TabIndex = 2;
            lblActStocktakeDesc.Text = "Hàng tồn";
            lblActStocktakeDesc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActionsTitle
            // 
            lblActionsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblActionsTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblActionsTitle.Location = new Point(31, 36);
            lblActionsTitle.Margin = new Padding(5, 0, 5, 0);
            lblActionsTitle.Name = "lblActionsTitle";
            lblActionsTitle.Size = new Size(720, 56);
            lblActionsTitle.TabIndex = 1;
            lblActionsTitle.Text = "Hành động nhanh";
            lblActionsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlColumns
            // 
            pnlColumns.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlColumns.ColumnCount = 2;
            pnlColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlColumns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlColumns.Controls.Add(pnlPendingPrescriptions, 0, 0);
            pnlColumns.Controls.Add(pnlInventoryAlerts, 1, 0);
            pnlColumns.Location = new Point(41, 948);
            pnlColumns.Margin = new Padding(5, 6, 5, 6);
            pnlColumns.Name = "pnlColumns";
            pnlColumns.RowCount = 1;
            pnlColumns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlColumns.Size = new Size(2050, 620);
            pnlColumns.TabIndex = 2;
            // 
            // pnlPendingPrescriptions
            // 
            pnlPendingPrescriptions.BackColor = Color.White;
            pnlPendingPrescriptions.BorderColor = Color.FromArgb(229, 231, 235);
            pnlPendingPrescriptions.BorderWidth = 1;
            pnlPendingPrescriptions.Controls.Add(pnlPrescriptionTwo);
            pnlPendingPrescriptions.Controls.Add(pnlPrescriptionOne);
            pnlPendingPrescriptions.Controls.Add(lblViewAll);
            pnlPendingPrescriptions.Controls.Add(lblPrescriptionTitle);
            pnlPendingPrescriptions.CornerRadius = 8;
            pnlPendingPrescriptions.Dock = DockStyle.Fill;
            pnlPendingPrescriptions.FillColor = Color.White;
            pnlPendingPrescriptions.Location = new Point(0, 0);
            pnlPendingPrescriptions.Margin = new Padding(0, 0, 24, 0);
            pnlPendingPrescriptions.Name = "pnlPendingPrescriptions";
            pnlPendingPrescriptions.Size = new Size(1001, 620);
            pnlPendingPrescriptions.TabIndex = 0;
            // 
            // pnlPrescriptionTwo
            // 
            pnlPrescriptionTwo.BackColor = Color.FromArgb(249, 250, 251);
            pnlPrescriptionTwo.BorderColor = Color.FromArgb(229, 231, 235);
            pnlPrescriptionTwo.BorderWidth = 1;
            pnlPrescriptionTwo.Controls.Add(lblStatusTwo);
            pnlPrescriptionTwo.Controls.Add(lblTimeTwo);
            pnlPrescriptionTwo.Controls.Add(lblDrugCountTwo);
            pnlPrescriptionTwo.Controls.Add(lblDoctorTwo);
            pnlPrescriptionTwo.Controls.Add(lblPatientTwo);
            pnlPrescriptionTwo.CornerRadius = 8;
            pnlPrescriptionTwo.FillColor = Color.FromArgb(249, 250, 251);
            pnlPrescriptionTwo.Location = new Point(38, 348);
            pnlPrescriptionTwo.Margin = new Padding(5, 6, 5, 6);
            pnlPrescriptionTwo.Name = "pnlPrescriptionTwo";
            pnlPrescriptionTwo.Size = new Size(926, 164);
            pnlPrescriptionTwo.TabIndex = 0;
            // 
            // lblStatusTwo
            // 
            lblStatusTwo.BackColor = Color.FromArgb(219, 234, 254);
            lblStatusTwo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStatusTwo.ForeColor = Color.FromArgb(47, 94, 240);
            lblStatusTwo.Location = new Point(703, 52);
            lblStatusTwo.Margin = new Padding(5, 0, 5, 0);
            lblStatusTwo.Name = "lblStatusTwo";
            lblStatusTwo.Size = new Size(189, 52);
            lblStatusTwo.TabIndex = 0;
            lblStatusTwo.Text = "Đang chuẩn bị";
            lblStatusTwo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTimeTwo
            // 
            lblTimeTwo.Font = new Font("Segoe UI", 8.5F);
            lblTimeTwo.ForeColor = Color.FromArgb(107, 114, 128);
            lblTimeTwo.Location = new Point(789, 112);
            lblTimeTwo.Margin = new Padding(5, 0, 5, 0);
            lblTimeTwo.Name = "lblTimeTwo";
            lblTimeTwo.Size = new Size(103, 40);
            lblTimeTwo.TabIndex = 1;
            lblTimeTwo.Text = "10:15";
            lblTimeTwo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDrugCountTwo
            // 
            lblDrugCountTwo.Font = new Font("Segoe UI", 9F);
            lblDrugCountTwo.ForeColor = Color.FromArgb(107, 114, 128);
            lblDrugCountTwo.Location = new Point(24, 112);
            lblDrugCountTwo.Margin = new Padding(5, 0, 5, 0);
            lblDrugCountTwo.Name = "lblDrugCountTwo";
            lblDrugCountTwo.Size = new Size(274, 40);
            lblDrugCountTwo.TabIndex = 2;
            lblDrugCountTwo.Text = "5 loại thuốc";
            lblDrugCountTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoctorTwo
            // 
            lblDoctorTwo.Font = new Font("Segoe UI", 9F);
            lblDoctorTwo.ForeColor = Color.FromArgb(107, 114, 128);
            lblDoctorTwo.Location = new Point(24, 64);
            lblDoctorTwo.Margin = new Padding(5, 0, 5, 0);
            lblDoctorTwo.Name = "lblDoctorTwo";
            lblDoctorTwo.Size = new Size(411, 44);
            lblDoctorTwo.TabIndex = 3;
            lblDoctorTwo.Text = "BS: BS. Phạm D";
            lblDoctorTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientTwo
            // 
            lblPatientTwo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientTwo.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientTwo.Location = new Point(24, 20);
            lblPatientTwo.Margin = new Padding(5, 0, 5, 0);
            lblPatientTwo.Name = "lblPatientTwo";
            lblPatientTwo.Size = new Size(377, 44);
            lblPatientTwo.TabIndex = 4;
            lblPatientTwo.Text = "Lê Thị C";
            lblPatientTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPrescriptionOne
            // 
            pnlPrescriptionOne.BackColor = Color.FromArgb(249, 250, 251);
            pnlPrescriptionOne.BorderColor = Color.FromArgb(229, 231, 235);
            pnlPrescriptionOne.BorderWidth = 1;
            pnlPrescriptionOne.Controls.Add(lblStatusOne);
            pnlPrescriptionOne.Controls.Add(lblTimeOne);
            pnlPrescriptionOne.Controls.Add(lblDrugCountOne);
            pnlPrescriptionOne.Controls.Add(lblDoctorOne);
            pnlPrescriptionOne.Controls.Add(lblPatientOne);
            pnlPrescriptionOne.CornerRadius = 8;
            pnlPrescriptionOne.FillColor = Color.FromArgb(249, 250, 251);
            pnlPrescriptionOne.Location = new Point(38, 156);
            pnlPrescriptionOne.Margin = new Padding(5, 6, 5, 6);
            pnlPrescriptionOne.Name = "pnlPrescriptionOne";
            pnlPrescriptionOne.Size = new Size(926, 164);
            pnlPrescriptionOne.TabIndex = 1;
            // 
            // lblStatusOne
            // 
            lblStatusOne.BackColor = Color.FromArgb(254, 249, 195);
            lblStatusOne.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblStatusOne.ForeColor = Color.FromArgb(161, 98, 7);
            lblStatusOne.Location = new Point(703, 52);
            lblStatusOne.Margin = new Padding(5, 0, 5, 0);
            lblStatusOne.Name = "lblStatusOne";
            lblStatusOne.Size = new Size(189, 52);
            lblStatusOne.TabIndex = 0;
            lblStatusOne.Text = "Chờ lấy thuốc";
            lblStatusOne.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTimeOne
            // 
            lblTimeOne.Font = new Font("Segoe UI", 8.5F);
            lblTimeOne.ForeColor = Color.FromArgb(107, 114, 128);
            lblTimeOne.Location = new Point(789, 112);
            lblTimeOne.Margin = new Padding(5, 0, 5, 0);
            lblTimeOne.Name = "lblTimeOne";
            lblTimeOne.Size = new Size(103, 40);
            lblTimeOne.TabIndex = 1;
            lblTimeOne.Text = "09:30";
            lblTimeOne.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblDrugCountOne
            // 
            lblDrugCountOne.Font = new Font("Segoe UI", 9F);
            lblDrugCountOne.ForeColor = Color.FromArgb(107, 114, 128);
            lblDrugCountOne.Location = new Point(24, 112);
            lblDrugCountOne.Margin = new Padding(5, 0, 5, 0);
            lblDrugCountOne.Name = "lblDrugCountOne";
            lblDrugCountOne.Size = new Size(274, 40);
            lblDrugCountOne.TabIndex = 2;
            lblDrugCountOne.Text = "3 loại thuốc";
            lblDrugCountOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoctorOne
            // 
            lblDoctorOne.Font = new Font("Segoe UI", 9F);
            lblDoctorOne.ForeColor = Color.FromArgb(107, 114, 128);
            lblDoctorOne.Location = new Point(24, 60);
            lblDoctorOne.Margin = new Padding(5, 0, 5, 0);
            lblDoctorOne.Name = "lblDoctorOne";
            lblDoctorOne.Size = new Size(411, 44);
            lblDoctorOne.TabIndex = 3;
            lblDoctorOne.Text = "BS: BS. Trần B";
            lblDoctorOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientOne
            // 
            lblPatientOne.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientOne.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientOne.Location = new Point(24, 14);
            lblPatientOne.Margin = new Padding(5, 0, 5, 0);
            lblPatientOne.Name = "lblPatientOne";
            lblPatientOne.Size = new Size(377, 44);
            lblPatientOne.TabIndex = 4;
            lblPatientOne.Text = "Nguyễn Văn A";
            lblPatientOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblViewAll
            // 
            lblViewAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblViewAll.ForeColor = Color.FromArgb(47, 94, 240);
            lblViewAll.Location = new Point(840, 48);
            lblViewAll.Margin = new Padding(5, 0, 5, 0);
            lblViewAll.Name = "lblViewAll";
            lblViewAll.Size = new Size(137, 44);
            lblViewAll.TabIndex = 2;
            lblViewAll.Text = "Xem tất cả";
            lblViewAll.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblPrescriptionTitle
            // 
            lblPrescriptionTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblPrescriptionTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblPrescriptionTitle.Location = new Point(31, 44);
            lblPrescriptionTitle.Margin = new Padding(5, 0, 5, 0);
            lblPrescriptionTitle.Name = "lblPrescriptionTitle";
            lblPrescriptionTitle.Size = new Size(549, 56);
            lblPrescriptionTitle.TabIndex = 3;
            lblPrescriptionTitle.Text = "Đơn thuốc chờ cấp";
            lblPrescriptionTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInventoryAlerts
            // 
            pnlInventoryAlerts.BackColor = Color.White;
            pnlInventoryAlerts.BorderColor = Color.FromArgb(229, 231, 235);
            pnlInventoryAlerts.BorderWidth = 1;
            pnlInventoryAlerts.Controls.Add(pnlAlertTwo);
            pnlInventoryAlerts.Controls.Add(pnlAlertOne);
            pnlInventoryAlerts.Controls.Add(lblAlertIcon);
            pnlInventoryAlerts.Controls.Add(lblAlertTitle);
            pnlInventoryAlerts.CornerRadius = 8;
            pnlInventoryAlerts.Dock = DockStyle.Fill;
            pnlInventoryAlerts.FillColor = Color.White;
            pnlInventoryAlerts.Location = new Point(1025, 0);
            pnlInventoryAlerts.Margin = new Padding(0);
            pnlInventoryAlerts.Name = "pnlInventoryAlerts";
            pnlInventoryAlerts.Size = new Size(1025, 620);
            pnlInventoryAlerts.TabIndex = 1;
            // 
            // pnlAlertTwo
            // 
            pnlAlertTwo.BackColor = Color.FromArgb(254, 242, 242);
            pnlAlertTwo.BorderColor = Color.FromArgb(254, 202, 202);
            pnlAlertTwo.BorderWidth = 1;
            pnlAlertTwo.Controls.Add(progressAlertTwo);
            pnlAlertTwo.Controls.Add(lblAlertMinTwo);
            pnlAlertTwo.Controls.Add(lblAlertStockTwo);
            pnlAlertTwo.Controls.Add(lblAlertMedTwo);
            pnlAlertTwo.CornerRadius = 8;
            pnlAlertTwo.FillColor = Color.FromArgb(254, 242, 242);
            pnlAlertTwo.Location = new Point(38, 368);
            pnlAlertTwo.Margin = new Padding(5, 6, 5, 6);
            pnlAlertTwo.Name = "pnlAlertTwo";
            pnlAlertTwo.Size = new Size(926, 199);
            pnlAlertTwo.TabIndex = 0;
            // 
            // progressAlertTwo
            // 
            progressAlertTwo.Location = new Point(20, 162);
            progressAlertTwo.Margin = new Padding(5, 6, 5, 6);
            progressAlertTwo.Name = "progressAlertTwo";
            progressAlertTwo.Size = new Size(857, 16);
            progressAlertTwo.TabIndex = 0;
            progressAlertTwo.Value = 52;
            // 
            // lblAlertMinTwo
            // 
            lblAlertMinTwo.Font = new Font("Segoe UI", 9F);
            lblAlertMinTwo.ForeColor = Color.FromArgb(55, 65, 81);
            lblAlertMinTwo.Location = new Point(24, 116);
            lblAlertMinTwo.Margin = new Padding(5, 0, 5, 0);
            lblAlertMinTwo.Name = "lblAlertMinTwo";
            lblAlertMinTwo.Size = new Size(857, 44);
            lblAlertMinTwo.TabIndex = 1;
            lblAlertMinTwo.Text = "Tối thiểu:                                150 viên";
            lblAlertMinTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlertStockTwo
            // 
            lblAlertStockTwo.Font = new Font("Segoe UI", 9F);
            lblAlertStockTwo.ForeColor = Color.FromArgb(220, 38, 38);
            lblAlertStockTwo.Location = new Point(20, 72);
            lblAlertStockTwo.Margin = new Padding(5, 0, 5, 0);
            lblAlertStockTwo.Name = "lblAlertStockTwo";
            lblAlertStockTwo.Size = new Size(857, 44);
            lblAlertStockTwo.TabIndex = 2;
            lblAlertStockTwo.Text = "Tồn kho:                                   78 viên";
            lblAlertStockTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlertMedTwo
            // 
            lblAlertMedTwo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlertMedTwo.ForeColor = Color.FromArgb(17, 24, 39);
            lblAlertMedTwo.Location = new Point(24, 24);
            lblAlertMedTwo.Margin = new Padding(5, 0, 5, 0);
            lblAlertMedTwo.Name = "lblAlertMedTwo";
            lblAlertMedTwo.Size = new Size(446, 48);
            lblAlertMedTwo.TabIndex = 3;
            lblAlertMedTwo.Text = "Amoxicillin 250mg";
            lblAlertMedTwo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAlertOne
            // 
            pnlAlertOne.BackColor = Color.FromArgb(254, 242, 242);
            pnlAlertOne.BorderColor = Color.FromArgb(254, 202, 202);
            pnlAlertOne.BorderWidth = 1;
            pnlAlertOne.Controls.Add(progressAlertOne);
            pnlAlertOne.Controls.Add(lblAlertMinOne);
            pnlAlertOne.Controls.Add(lblAlertStockOne);
            pnlAlertOne.Controls.Add(lblAlertMedOne);
            pnlAlertOne.CornerRadius = 8;
            pnlAlertOne.FillColor = Color.FromArgb(254, 242, 242);
            pnlAlertOne.Location = new Point(38, 156);
            pnlAlertOne.Margin = new Padding(5, 6, 5, 6);
            pnlAlertOne.Name = "pnlAlertOne";
            pnlAlertOne.Size = new Size(926, 200);
            pnlAlertOne.TabIndex = 1;
            // 
            // progressAlertOne
            // 
            progressAlertOne.Location = new Point(24, 166);
            progressAlertOne.Margin = new Padding(5, 6, 5, 6);
            progressAlertOne.Name = "progressAlertOne";
            progressAlertOne.Size = new Size(857, 16);
            progressAlertOne.TabIndex = 0;
            progressAlertOne.Value = 45;
            // 
            // lblAlertMinOne
            // 
            lblAlertMinOne.Font = new Font("Segoe UI", 9F);
            lblAlertMinOne.ForeColor = Color.FromArgb(55, 65, 81);
            lblAlertMinOne.Location = new Point(24, 116);
            lblAlertMinOne.Margin = new Padding(5, 0, 5, 0);
            lblAlertMinOne.Name = "lblAlertMinOne";
            lblAlertMinOne.Size = new Size(857, 44);
            lblAlertMinOne.TabIndex = 1;
            lblAlertMinOne.Text = "Tối thiểu:                                100 viên";
            lblAlertMinOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlertStockOne
            // 
            lblAlertStockOne.Font = new Font("Segoe UI", 9F);
            lblAlertStockOne.ForeColor = Color.FromArgb(220, 38, 38);
            lblAlertStockOne.Location = new Point(24, 72);
            lblAlertStockOne.Margin = new Padding(5, 0, 5, 0);
            lblAlertStockOne.Name = "lblAlertStockOne";
            lblAlertStockOne.Size = new Size(857, 44);
            lblAlertStockOne.TabIndex = 2;
            lblAlertStockOne.Text = "Tồn kho:                                   45 viên";
            lblAlertStockOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlertMedOne
            // 
            lblAlertMedOne.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAlertMedOne.ForeColor = Color.FromArgb(17, 24, 39);
            lblAlertMedOne.Location = new Point(24, 24);
            lblAlertMedOne.Margin = new Padding(5, 0, 5, 0);
            lblAlertMedOne.Name = "lblAlertMedOne";
            lblAlertMedOne.Size = new Size(446, 48);
            lblAlertMedOne.TabIndex = 3;
            lblAlertMedOne.Text = "Paracetamol 500mg";
            lblAlertMedOne.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAlertIcon
            // 
            lblAlertIcon.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAlertIcon.ForeColor = Color.FromArgb(239, 68, 68);
            lblAlertIcon.Location = new Point(939, 40);
            lblAlertIcon.Margin = new Padding(5, 0, 5, 0);
            lblAlertIcon.Name = "lblAlertIcon";
            lblAlertIcon.Size = new Size(51, 60);
            lblAlertIcon.TabIndex = 2;
            lblAlertIcon.Text = "!";
            lblAlertIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAlertTitle
            // 
            lblAlertTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAlertTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblAlertTitle.Location = new Point(31, 44);
            lblAlertTitle.Margin = new Padding(5, 0, 5, 0);
            lblAlertTitle.Name = "lblAlertTitle";
            lblAlertTitle.Size = new Size(549, 56);
            lblAlertTitle.TabIndex = 3;
            lblAlertTitle.Text = "Cảnh báo tồn kho";
            lblAlertTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlShift
            // 
            pnlShift.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShift.BackColor = Color.White;
            pnlShift.BorderColor = Color.FromArgb(229, 231, 235);
            pnlShift.BorderWidth = 1;
            pnlShift.Controls.Add(lblShiftFooter);
            pnlShift.Controls.Add(btnChangeShift);
            pnlShift.Controls.Add(btnViewWeek);
            pnlShift.Controls.Add(pnlShiftBox);
            pnlShift.Controls.Add(lblShiftBadge);
            pnlShift.Controls.Add(lblShiftTitle);
            pnlShift.CornerRadius = 8;
            pnlShift.FillColor = Color.White;
            pnlShift.Location = new Point(41, 388);
            pnlShift.Margin = new Padding(5, 6, 5, 6);
            pnlShift.Name = "pnlShift";
            pnlShift.Size = new Size(2050, 520);
            pnlShift.TabIndex = 1;
            // 
            // lblShiftFooter
            // 
            lblShiftFooter.Font = new Font("Segoe UI", 9F);
            lblShiftFooter.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftFooter.Location = new Point(0, 452);
            lblShiftFooter.Margin = new Padding(5, 0, 5, 0);
            lblShiftFooter.Name = "lblShiftFooter";
            lblShiftFooter.Size = new Size(2050, 48);
            lblShiftFooter.TabIndex = 0;
            lblShiftFooter.Text = "Còn 4 ca trong tuần này";
            lblShiftFooter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnChangeShift
            // 
            btnChangeShift.BackColor = Color.FromArgb(243, 244, 246);
            btnChangeShift.Cursor = Cursors.Hand;
            btnChangeShift.FlatAppearance.BorderSize = 0;
            btnChangeShift.FlatStyle = FlatStyle.Flat;
            btnChangeShift.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnChangeShift.ForeColor = Color.FromArgb(31, 41, 55);
            btnChangeShift.Location = new Point(1008, 360);
            btnChangeShift.Margin = new Padding(5, 6, 5, 6);
            btnChangeShift.Name = "btnChangeShift";
            btnChangeShift.Size = new Size(1001, 76);
            btnChangeShift.TabIndex = 1;
            btnChangeShift.Text = "Đổi ca";
            btnChangeShift.UseVisualStyleBackColor = false;
            // 
            // btnViewWeek
            // 
            btnViewWeek.BackColor = Color.FromArgb(239, 246, 255);
            btnViewWeek.Cursor = Cursors.Hand;
            btnViewWeek.FlatAppearance.BorderSize = 0;
            btnViewWeek.FlatStyle = FlatStyle.Flat;
            btnViewWeek.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnViewWeek.ForeColor = Color.FromArgb(47, 94, 240);
            btnViewWeek.Location = new Point(38, 360);
            btnViewWeek.Margin = new Padding(5, 6, 5, 6);
            btnViewWeek.Name = "btnViewWeek";
            btnViewWeek.Size = new Size(943, 76);
            btnViewWeek.TabIndex = 2;
            btnViewWeek.Text = "▣  Xem lịch tuần";
            btnViewWeek.UseVisualStyleBackColor = false;
            // 
            // pnlShiftBox
            // 
            pnlShiftBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlShiftBox.BackColor = Color.FromArgb(219, 234, 254);
            pnlShiftBox.BorderColor = Color.FromArgb(147, 197, 253);
            pnlShiftBox.BorderWidth = 1;
            pnlShiftBox.Controls.Add(lblShiftDept);
            pnlShiftBox.Controls.Add(lblShiftRoom);
            pnlShiftBox.Controls.Add(lblShiftTime);
            pnlShiftBox.Controls.Add(lblShiftName);
            pnlShiftBox.CornerRadius = 8;
            pnlShiftBox.FillColor = Color.FromArgb(219, 234, 254);
            pnlShiftBox.Location = new Point(38, 140);
            pnlShiftBox.Margin = new Padding(5, 6, 5, 6);
            pnlShiftBox.Name = "pnlShiftBox";
            pnlShiftBox.Size = new Size(1971, 180);
            pnlShiftBox.TabIndex = 2;
            // 
            // lblShiftDept
            // 
            lblShiftDept.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftDept.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftDept.Location = new Point(1063, 110);
            lblShiftDept.Margin = new Padding(5, 0, 5, 0);
            lblShiftDept.Name = "lblShiftDept";
            lblShiftDept.Size = new Size(309, 48);
            lblShiftDept.TabIndex = 0;
            lblShiftDept.Text = "⚕  Nội khoa";
            lblShiftDept.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftRoom
            // 
            lblShiftRoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftRoom.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftRoom.Location = new Point(31, 110);
            lblShiftRoom.Margin = new Padding(5, 0, 5, 0);
            lblShiftRoom.Name = "lblShiftRoom";
            lblShiftRoom.Size = new Size(274, 48);
            lblShiftRoom.TabIndex = 1;
            lblShiftRoom.Text = "⌖  P.101";
            lblShiftRoom.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftTime
            // 
            lblShiftTime.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftTime.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftTime.Location = new Point(202, 46);
            lblShiftTime.Margin = new Padding(5, 0, 5, 0);
            lblShiftTime.Name = "lblShiftTime";
            lblShiftTime.Size = new Size(274, 48);
            lblShiftTime.TabIndex = 2;
            lblShiftTime.Text = "(07:00 - 12:00)";
            lblShiftTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftName
            // 
            lblShiftName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblShiftName.ForeColor = Color.FromArgb(47, 94, 240);
            lblShiftName.Location = new Point(31, 36);
            lblShiftName.Margin = new Padding(5, 0, 5, 0);
            lblShiftName.Name = "lblShiftName";
            lblShiftName.Size = new Size(206, 60);
            lblShiftName.TabIndex = 3;
            lblShiftName.Text = "Sáng";
            lblShiftName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblShiftBadge
            // 
            lblShiftBadge.BackColor = Color.FromArgb(220, 252, 231);
            lblShiftBadge.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblShiftBadge.ForeColor = Color.FromArgb(34, 139, 74);
            lblShiftBadge.Location = new Point(1848, 36);
            lblShiftBadge.Margin = new Padding(5, 0, 5, 0);
            lblShiftBadge.Name = "lblShiftBadge";
            lblShiftBadge.Size = new Size(171, 56);
            lblShiftBadge.TabIndex = 3;
            lblShiftBadge.Text = "• Đang trực";
            lblShiftBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblShiftTitle
            // 
            lblShiftTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblShiftTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblShiftTitle.Location = new Point(31, 36);
            lblShiftTitle.Margin = new Padding(5, 0, 5, 0);
            lblShiftTitle.Name = "lblShiftTitle";
            lblShiftTitle.Size = new Size(720, 56);
            lblShiftTitle.TabIndex = 4;
            lblShiftTitle.Text = "◷  Ca làm việc hôm nay";
            lblShiftTitle.TextAlign = ContentAlignment.MiddleLeft;
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
            pnlStatsGrid.Location = new Point(41, 48);
            pnlStatsGrid.Margin = new Padding(5, 6, 5, 6);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(2050, 300);
            pnlStatsGrid.TabIndex = 0;
            // 
            // pnlStatPending
            // 
            pnlStatPending.BackColor = Color.FromArgb(239, 246, 255);
            pnlStatPending.BorderColor = Color.FromArgb(191, 219, 254);
            pnlStatPending.BorderWidth = 1;
            pnlStatPending.Controls.Add(lblPendingIcon);
            pnlStatPending.Controls.Add(lblPendingNumber);
            pnlStatPending.Controls.Add(lblPendingTitle);
            pnlStatPending.CornerRadius = 8;
            pnlStatPending.FillColor = Color.FromArgb(239, 246, 255);
            pnlStatPending.Location = new Point(0, 0);
            pnlStatPending.Margin = new Padding(0, 0, 24, 0);
            pnlStatPending.Name = "pnlStatPending";
            pnlStatPending.Size = new Size(343, 200);
            pnlStatPending.TabIndex = 0;
            // 
            // lblPendingIcon
            // 
            lblPendingIcon.BackColor = Color.White;
            lblPendingIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblPendingIcon.ForeColor = Color.FromArgb(47, 94, 240);
            lblPendingIcon.Location = new Point(38, 44);
            lblPendingIcon.Margin = new Padding(5, 0, 5, 0);
            lblPendingIcon.Name = "lblPendingIcon";
            lblPendingIcon.Size = new Size(82, 96);
            lblPendingIcon.TabIndex = 0;
            lblPendingIcon.Text = "◊";
            lblPendingIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPendingNumber
            // 
            lblPendingNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPendingNumber.ForeColor = Color.FromArgb(47, 94, 240);
            lblPendingNumber.Location = new Point(155, 44);
            lblPendingNumber.Margin = new Padding(5, 0, 5, 0);
            lblPendingNumber.Name = "lblPendingNumber";
            lblPendingNumber.Size = new Size(153, 76);
            lblPendingNumber.TabIndex = 1;
            lblPendingNumber.Text = "15";
            lblPendingNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPendingTitle
            // 
            lblPendingTitle.Font = new Font("Segoe UI", 9.5F);
            lblPendingTitle.ForeColor = Color.FromArgb(47, 94, 240);
            lblPendingTitle.Location = new Point(41, 236);
            lblPendingTitle.Margin = new Padding(5, 0, 5, 0);
            lblPendingTitle.Name = "lblPendingTitle";
            lblPendingTitle.Size = new Size(446, 48);
            lblPendingTitle.TabIndex = 2;
            lblPendingTitle.Text = "Đơn thuốc chờ";
            lblPendingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatMedicines
            // 
            pnlStatMedicines.BackColor = Color.FromArgb(240, 253, 244);
            pnlStatMedicines.BorderColor = Color.FromArgb(187, 247, 208);
            pnlStatMedicines.BorderWidth = 1;
            pnlStatMedicines.Controls.Add(lblMedicineIcon);
            pnlStatMedicines.Controls.Add(lblMedicineNumber);
            pnlStatMedicines.Controls.Add(lblMedicineTitle);
            pnlStatMedicines.CornerRadius = 8;
            pnlStatMedicines.FillColor = Color.FromArgb(240, 253, 244);
            pnlStatMedicines.Location = new Point(512, 0);
            pnlStatMedicines.Margin = new Padding(0, 0, 24, 0);
            pnlStatMedicines.Name = "pnlStatMedicines";
            pnlStatMedicines.Size = new Size(343, 200);
            pnlStatMedicines.TabIndex = 1;
            // 
            // lblMedicineIcon
            // 
            lblMedicineIcon.BackColor = Color.White;
            lblMedicineIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblMedicineIcon.ForeColor = Color.FromArgb(34, 139, 74);
            lblMedicineIcon.Location = new Point(38, 44);
            lblMedicineIcon.Margin = new Padding(5, 0, 5, 0);
            lblMedicineIcon.Name = "lblMedicineIcon";
            lblMedicineIcon.Size = new Size(82, 96);
            lblMedicineIcon.TabIndex = 0;
            lblMedicineIcon.Text = "□";
            lblMedicineIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblMedicineNumber
            // 
            lblMedicineNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMedicineNumber.ForeColor = Color.FromArgb(34, 139, 74);
            lblMedicineNumber.Location = new Point(173, 44);
            lblMedicineNumber.Margin = new Padding(5, 0, 5, 0);
            lblMedicineNumber.Name = "lblMedicineNumber";
            lblMedicineNumber.Size = new Size(145, 76);
            lblMedicineNumber.TabIndex = 1;
            lblMedicineNumber.Text = "248";
            lblMedicineNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMedicineTitle
            // 
            lblMedicineTitle.Font = new Font("Segoe UI", 9.5F);
            lblMedicineTitle.ForeColor = Color.FromArgb(34, 139, 74);
            lblMedicineTitle.Location = new Point(41, 236);
            lblMedicineTitle.Margin = new Padding(5, 0, 5, 0);
            lblMedicineTitle.Name = "lblMedicineTitle";
            lblMedicineTitle.Size = new Size(446, 48);
            lblMedicineTitle.TabIndex = 2;
            lblMedicineTitle.Text = "Loại thuốc trong kho";
            lblMedicineTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatLowStock
            // 
            pnlStatLowStock.BackColor = Color.FromArgb(254, 242, 242);
            pnlStatLowStock.BorderColor = Color.FromArgb(254, 202, 202);
            pnlStatLowStock.BorderWidth = 1;
            pnlStatLowStock.Controls.Add(lblLowStockIcon);
            pnlStatLowStock.Controls.Add(lblLowStockNumber);
            pnlStatLowStock.Controls.Add(lblLowStockTitle);
            pnlStatLowStock.CornerRadius = 8;
            pnlStatLowStock.FillColor = Color.FromArgb(254, 242, 242);
            pnlStatLowStock.Location = new Point(1024, 0);
            pnlStatLowStock.Margin = new Padding(0, 0, 24, 0);
            pnlStatLowStock.Name = "pnlStatLowStock";
            pnlStatLowStock.Size = new Size(343, 200);
            pnlStatLowStock.TabIndex = 2;
            // 
            // lblLowStockIcon
            // 
            lblLowStockIcon.BackColor = Color.White;
            lblLowStockIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblLowStockIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblLowStockIcon.Location = new Point(38, 44);
            lblLowStockIcon.Margin = new Padding(5, 0, 5, 0);
            lblLowStockIcon.Name = "lblLowStockIcon";
            lblLowStockIcon.Size = new Size(82, 96);
            lblLowStockIcon.TabIndex = 0;
            lblLowStockIcon.Text = "!";
            lblLowStockIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLowStockNumber
            // 
            lblLowStockNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblLowStockNumber.ForeColor = Color.FromArgb(220, 38, 38);
            lblLowStockNumber.Location = new Point(148, 44);
            lblLowStockNumber.Margin = new Padding(5, 0, 5, 0);
            lblLowStockNumber.Name = "lblLowStockNumber";
            lblLowStockNumber.Size = new Size(109, 76);
            lblLowStockNumber.TabIndex = 1;
            lblLowStockNumber.Text = "8";
            lblLowStockNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLowStockTitle
            // 
            lblLowStockTitle.Font = new Font("Segoe UI", 9.5F);
            lblLowStockTitle.ForeColor = Color.FromArgb(220, 38, 38);
            lblLowStockTitle.Location = new Point(41, 236);
            lblLowStockTitle.Margin = new Padding(5, 0, 5, 0);
            lblLowStockTitle.Name = "lblLowStockTitle";
            lblLowStockTitle.Size = new Size(446, 48);
            lblLowStockTitle.TabIndex = 2;
            lblLowStockTitle.Text = "Thuốc sắp hết";
            lblLowStockTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatDispensed
            // 
            pnlStatDispensed.BackColor = Color.FromArgb(250, 245, 255);
            pnlStatDispensed.BorderColor = Color.FromArgb(233, 213, 255);
            pnlStatDispensed.BorderWidth = 1;
            pnlStatDispensed.Controls.Add(lblDispensedIcon);
            pnlStatDispensed.Controls.Add(lblDispensedNumber);
            pnlStatDispensed.Controls.Add(lblDispensedTitle);
            pnlStatDispensed.CornerRadius = 8;
            pnlStatDispensed.FillColor = Color.FromArgb(250, 245, 255);
            pnlStatDispensed.Location = new Point(1536, 0);
            pnlStatDispensed.Margin = new Padding(0);
            pnlStatDispensed.Name = "pnlStatDispensed";
            pnlStatDispensed.Size = new Size(343, 200);
            pnlStatDispensed.TabIndex = 3;
            // 
            // lblDispensedIcon
            // 
            lblDispensedIcon.BackColor = Color.White;
            lblDispensedIcon.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDispensedIcon.ForeColor = Color.FromArgb(147, 51, 234);
            lblDispensedIcon.Location = new Point(38, 44);
            lblDispensedIcon.Margin = new Padding(5, 0, 5, 0);
            lblDispensedIcon.Name = "lblDispensedIcon";
            lblDispensedIcon.Size = new Size(82, 96);
            lblDispensedIcon.TabIndex = 0;
            lblDispensedIcon.Text = "↗";
            lblDispensedIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDispensedNumber
            // 
            lblDispensedNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDispensedNumber.ForeColor = Color.FromArgb(147, 51, 234);
            lblDispensedNumber.Location = new Point(153, 44);
            lblDispensedNumber.Margin = new Padding(5, 0, 5, 0);
            lblDispensedNumber.Name = "lblDispensedNumber";
            lblDispensedNumber.Size = new Size(115, 76);
            lblDispensedNumber.TabIndex = 1;
            lblDispensedNumber.Text = "45";
            lblDispensedNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDispensedTitle
            // 
            lblDispensedTitle.Font = new Font("Segoe UI", 9.5F);
            lblDispensedTitle.ForeColor = Color.FromArgb(147, 51, 234);
            lblDispensedTitle.Location = new Point(41, 236);
            lblDispensedTitle.Margin = new Padding(5, 0, 5, 0);
            lblDispensedTitle.Name = "lblDispensedTitle";
            lblDispensedTitle.Size = new Size(446, 48);
            lblDispensedTitle.TabIndex = 2;
            lblDispensedTitle.Text = "Đã cấp phát hôm nay";
            lblDispensedTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucPharmacyOverview
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Margin = new Padding(5, 6, 5, 6);
            Name = "ucPharmacyOverview";
            Size = new Size(2133, 2000);
            Load += ucPharmacyOverview_Load;
            viewHostPanel.ResumeLayout(false);
            pnlQuickActions.ResumeLayout(false);
            pnlActionGrid.ResumeLayout(false);
            pnlActDispense.ResumeLayout(false);
            pnlActInventory.ResumeLayout(false);
            pnlActReports.ResumeLayout(false);
            pnlActStocktake.ResumeLayout(false);
            pnlColumns.ResumeLayout(false);
            pnlPendingPrescriptions.ResumeLayout(false);
            pnlPrescriptionTwo.ResumeLayout(false);
            pnlPrescriptionOne.ResumeLayout(false);
            pnlInventoryAlerts.ResumeLayout(false);
            pnlAlertTwo.ResumeLayout(false);
            pnlAlertOne.ResumeLayout(false);
            pnlShift.ResumeLayout(false);
            pnlShiftBox.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlStatPending.ResumeLayout(false);
            pnlStatMedicines.ResumeLayout(false);
            pnlStatLowStock.ResumeLayout(false);
            pnlStatDispensed.ResumeLayout(false);
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
