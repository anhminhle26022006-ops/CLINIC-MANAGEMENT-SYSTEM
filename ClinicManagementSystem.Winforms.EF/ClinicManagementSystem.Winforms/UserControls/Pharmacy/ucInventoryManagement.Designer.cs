using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucInventoryManagement
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
            lblHeading = new Label();
            lblSubheading = new Label();
            btnAddMedicine = new Button();
            pnlStatsGrid = new TableLayoutPanel();
            pnlValue = new RoundedPanel();
            lblValueTitle = new Label();
            lblValueNumber = new Label();
            lblValueUnit = new Label();
            pnlTypes = new RoundedPanel();
            lblTypesTitle = new Label();
            lblTypesNumber = new Label();
            lblTypesUnit = new Label();
            pnlLowAlert = new RoundedPanel();
            lblLowTitle = new Label();
            lblLowNumber = new Label();
            lblLowUnit = new Label();
            pnlExpired = new RoundedPanel();
            lblExpiredTitle = new Label();
            lblExpiredNumber = new Label();
            lblExpiredUnit = new Label();
            pnlFilters = new RoundedPanel();
            txtSearch = new TextBox();
            cboCategory = new ComboBox();
            cboStatus = new ComboBox();
            pnlTable = new RoundedPanel();
            dgvInventory = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colBatch = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colExpiry = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colActions = new DataGridViewTextBoxColumn();
            pnlHistory = new RoundedPanel();
            lblHistoryTitle = new Label();
            pnlHistoryOne = new Panel();
            lblHistoryOneIcon = new Label();
            lblHistoryOneText = new Label();
            lblHistoryOneQty = new Label();
            pnlHistoryTwo = new Panel();
            lblHistoryTwoIcon = new Label();
            lblHistoryTwoText = new Label();
            lblHistoryTwoQty = new Label();
            pnlHistoryThree = new Panel();
            lblHistoryThreeIcon = new Label();
            lblHistoryThreeText = new Label();
            lblHistoryThreeQty = new Label();
            viewHostPanel.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlValue.SuspendLayout();
            pnlTypes.SuspendLayout();
            pnlLowAlert.SuspendLayout();
            pnlExpired.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            pnlHistory.SuspendLayout();
            pnlHistoryOne.SuspendLayout();
            pnlHistoryTwo.SuspendLayout();
            pnlHistoryThree.SuspendLayout();
            SuspendLayout();
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.CornerRadius = 8;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.AutoScroll = true;
            this.viewHostPanel.Controls.Add(this.btnAddMedicine);
            this.viewHostPanel.Controls.Add(this.pnlHistory);
            this.viewHostPanel.Controls.Add(this.pnlTable);
            this.viewHostPanel.Controls.Add(this.pnlFilters);
            this.viewHostPanel.Controls.Add(this.pnlStatsGrid);
            this.viewHostPanel.Controls.Add(this.lblSubheading);
            this.viewHostPanel.Controls.Add(this.lblHeading);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 1000);

            // 
            // btnAddMedicine
            // 
            this.btnAddMedicine.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnAddMedicine.BackColor = System.Drawing.Color.FromArgb(47, 94, 240);
            this.btnAddMedicine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMedicine.FlatAppearance.BorderSize = 0;
            this.btnAddMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMedicine.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddMedicine.ForeColor = System.Drawing.Color.White;
            this.btnAddMedicine.Location = new System.Drawing.Point(1068, 34);
            this.btnAddMedicine.Size = new System.Drawing.Size(150, 42);
            this.btnAddMedicine.Text = "+  Thêm thuốc";
            this.btnAddMedicine.UseVisualStyleBackColor = false;
            this.btnAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);

            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblHeading.Location = new System.Drawing.Point(24, 24);
            this.lblHeading.Size = new System.Drawing.Size(360, 40);
            this.lblHeading.Text = "Quản lý kho thuốc";

            this.lblSubheading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblSubheading.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubheading.Location = new System.Drawing.Point(24, 66);
            this.lblSubheading.Size = new System.Drawing.Size(420, 28);
            this.lblSubheading.Text = "Theo dõi nhập xuất và tồn kho thuốc";
            // 
            // stats
            // 
            this.pnlStatsGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlStatsGrid.ColumnCount = 4;
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.Controls.Add(this.pnlValue, 0, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlTypes, 1, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlLowAlert, 2, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlExpired, 3, 0);
            this.pnlStatsGrid.Location = new System.Drawing.Point(24, 120);
            this.pnlStatsGrid.RowCount = 1;
            this.pnlStatsGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatsGrid.Size = new System.Drawing.Size(1196, 130);

            // pnlValue
            this.pnlValue.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.pnlValue.BorderColor = System.Drawing.Color.FromArgb(191, 219, 254);
            this.pnlValue.CornerRadius = 8;
            this.pnlValue.FillColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.pnlValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlValue.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlValue.Controls.Add(this.lblValueUnit);
            this.pnlValue.Controls.Add(this.lblValueNumber);
            this.pnlValue.Controls.Add(this.lblValueTitle);
            this.lblValueTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblValueTitle.ForeColor = System.Drawing.Color.FromArgb(47, 94, 240);
            this.lblValueTitle.Location = new System.Drawing.Point(22, 24);
            this.lblValueTitle.Size = new System.Drawing.Size(220, 24);
            this.lblValueTitle.Text = "Tổng giá trị kho";
            this.lblValueNumber.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblValueNumber.ForeColor = System.Drawing.Color.FromArgb(47, 94, 240);
            this.lblValueNumber.Location = new System.Drawing.Point(22, 54);
            this.lblValueNumber.Size = new System.Drawing.Size(150, 42);
            this.lblValueNumber.Text = "6.3M";
            this.lblValueUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblValueUnit.ForeColor = System.Drawing.Color.FromArgb(47, 94, 240);
            this.lblValueUnit.Location = new System.Drawing.Point(22, 96);
            this.lblValueUnit.Size = new System.Drawing.Size(160, 24);
            this.lblValueUnit.Text = "VNĐ";

            // pnlTypes
            this.pnlTypes.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.pnlTypes.BorderColor = System.Drawing.Color.FromArgb(187, 247, 208);
            this.pnlTypes.CornerRadius = 8;
            this.pnlTypes.FillColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.pnlTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTypes.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlTypes.Controls.Add(this.lblTypesUnit);
            this.pnlTypes.Controls.Add(this.lblTypesNumber);
            this.pnlTypes.Controls.Add(this.lblTypesTitle);
            this.lblTypesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTypesTitle.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblTypesTitle.Location = new System.Drawing.Point(22, 24);
            this.lblTypesTitle.Size = new System.Drawing.Size(220, 24);
            this.lblTypesTitle.Text = "Tổng số loại thuốc";
            this.lblTypesNumber.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTypesNumber.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblTypesNumber.Location = new System.Drawing.Point(22, 54);
            this.lblTypesNumber.Size = new System.Drawing.Size(150, 42);
            this.lblTypesNumber.Text = "6";
            this.lblTypesUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblTypesUnit.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblTypesUnit.Location = new System.Drawing.Point(22, 96);
            this.lblTypesUnit.Size = new System.Drawing.Size(160, 24);
            this.lblTypesUnit.Text = "loại";

            // pnlLowAlert
            this.pnlLowAlert.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.pnlLowAlert.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.pnlLowAlert.CornerRadius = 8;
            this.pnlLowAlert.FillColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.pnlLowAlert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowAlert.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlLowAlert.Controls.Add(this.lblLowUnit);
            this.pnlLowAlert.Controls.Add(this.lblLowNumber);
            this.pnlLowAlert.Controls.Add(this.lblLowTitle);
            this.lblLowTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblLowTitle.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLowTitle.Location = new System.Drawing.Point(22, 24);
            this.lblLowTitle.Size = new System.Drawing.Size(220, 24);
            this.lblLowTitle.Text = "Cảnh báo sắp hết";
            this.lblLowNumber.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLowNumber.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLowNumber.Location = new System.Drawing.Point(22, 54);
            this.lblLowNumber.Size = new System.Drawing.Size(150, 42);
            this.lblLowNumber.Text = "2";
            this.lblLowUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblLowUnit.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLowUnit.Location = new System.Drawing.Point(22, 96);
            this.lblLowUnit.Size = new System.Drawing.Size(160, 24);
            this.lblLowUnit.Text = "loại thuốc";

            // pnlExpired
            this.pnlExpired.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.pnlExpired.BorderColor = System.Drawing.Color.FromArgb(254, 215, 170);
            this.pnlExpired.CornerRadius = 8;
            this.pnlExpired.FillColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.pnlExpired.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExpired.Margin = new System.Windows.Forms.Padding(0);
            this.pnlExpired.Controls.Add(this.lblExpiredUnit);
            this.pnlExpired.Controls.Add(this.lblExpiredNumber);
            this.pnlExpired.Controls.Add(this.lblExpiredTitle);
            this.lblExpiredTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblExpiredTitle.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblExpiredTitle.Location = new System.Drawing.Point(22, 24);
            this.lblExpiredTitle.Size = new System.Drawing.Size(220, 24);
            this.lblExpiredTitle.Text = "Sắp hết hạn";
            this.lblExpiredNumber.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblExpiredNumber.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblExpiredNumber.Location = new System.Drawing.Point(22, 54);
            this.lblExpiredNumber.Size = new System.Drawing.Size(150, 42);
            this.lblExpiredNumber.Text = "0";
            this.lblExpiredUnit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblExpiredUnit.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblExpiredUnit.Location = new System.Drawing.Point(22, 96);
            this.lblExpiredUnit.Size = new System.Drawing.Size(160, 24);
            this.lblExpiredUnit.Text = "loại thuốc";
            // 
            // filters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.White;
            this.pnlFilters.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlFilters.CornerRadius = 8;
            this.pnlFilters.FillColor = System.Drawing.Color.White;
            this.pnlFilters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlFilters.Controls.Add(this.cboStatus);
            this.pnlFilters.Controls.Add(this.cboCategory);
            this.pnlFilters.Controls.Add(this.txtSearch);
            this.pnlFilters.Location = new System.Drawing.Point(24, 278);
            this.pnlFilters.Size = new System.Drawing.Size(1196, 76);

            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtSearch.Location = new System.Drawing.Point(18, 24);
            this.txtSearch.Size = new System.Drawing.Size(380, 30);
            this.txtSearch.Text = "  Tìm thuốc, batch...";

            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Items.AddRange(new object[] { "Tất cả danh mục", "Kháng sinh", "Giảm đau", "Vitamin", "Sắp hết" });
            this.cboCategory.Location = new System.Drawing.Point(418, 24);
            this.cboCategory.Size = new System.Drawing.Size(360, 31);
            this.cboCategory.SelectedIndex = 0;

            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Kháng sinh", "Giảm đau", "Vitamin", "Sắp hết" });
            this.cboStatus.Location = new System.Drawing.Point(790, 24);
            this.cboStatus.Size = new System.Drawing.Size(360, 31);
            this.cboStatus.SelectedIndex = 0;
            // 
            // table
            // 
            this.pnlTable.BackColor = System.Drawing.Color.White;
            this.pnlTable.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlTable.CornerRadius = 8;
            this.pnlTable.FillColor = System.Drawing.Color.White;
            this.pnlTable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlTable.Controls.Add(this.dgvInventory);
            this.pnlTable.Location = new System.Drawing.Point(24, 382);
            this.pnlTable.Size = new System.Drawing.Size(1196, 420);

            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvInventory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvInventory.ColumnHeadersHeight = 48;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colCategory,
            this.colBatch,
            this.colStock,
            this.colExpiry,
            this.colLocation,
            this.colActions});
            this.dgvInventory.EnableHeadersVisualStyles = false;
            this.dgvInventory.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvInventory.Location = new System.Drawing.Point(1, 1);
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.RowTemplate.Height = 58;
            this.dgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventory.Size = new System.Drawing.Size(1194, 418);

            this.colName.HeaderText = "TÊN THUỐC";
            this.colName.Width = 230;

            this.colCategory.HeaderText = "DANH MỤC";
            this.colCategory.Width = 190;

            this.colBatch.HeaderText = "BATCH";
            this.colBatch.Width = 170;

            this.colStock.HeaderText = "TỒN KHO";
            this.colStock.Width = 130;

            this.colExpiry.HeaderText = "HẠN SỬ DỤNG";
            this.colExpiry.Width = 150;

            this.colLocation.HeaderText = "VỊ TRÍ";
            this.colLocation.Width = 120;

            this.colActions.HeaderText = "THAO TÁC";
            this.colActions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // history
            // 
            this.pnlHistory.BackColor = System.Drawing.Color.White;
            this.pnlHistory.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlHistory.CornerRadius = 8;
            this.pnlHistory.FillColor = System.Drawing.Color.White;
            this.pnlHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlHistory.Controls.Add(this.pnlHistoryThree);
            this.pnlHistory.Controls.Add(this.pnlHistoryTwo);
            this.pnlHistory.Controls.Add(this.pnlHistoryOne);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Location = new System.Drawing.Point(24, 830);
            this.pnlHistory.Size = new System.Drawing.Size(1196, 300);

            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblHistoryTitle.Location = new System.Drawing.Point(22, 24);
            this.lblHistoryTitle.Size = new System.Drawing.Size(360, 32);
            this.lblHistoryTitle.Text = "Lịch sử nhập xuất gần đây";

            // pnlHistoryOne
            this.pnlHistoryOne.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlHistoryOne.Location = new System.Drawing.Point(22, 76);
            this.pnlHistoryOne.Size = new System.Drawing.Size(1152, 58);
            this.pnlHistoryOne.Controls.Add(this.lblHistoryOneQty);
            this.pnlHistoryOne.Controls.Add(this.lblHistoryOneText);
            this.pnlHistoryOne.Controls.Add(this.lblHistoryOneIcon);

            this.lblHistoryOneIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHistoryOneIcon.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblHistoryOneIcon.Location = new System.Drawing.Point(16, 10);
            this.lblHistoryOneIcon.Size = new System.Drawing.Size(46, 38);
            this.lblHistoryOneIcon.Text = "↗";
            this.lblHistoryOneIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHistoryOneIcon.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);

            this.lblHistoryOneText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblHistoryOneText.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHistoryOneText.Location = new System.Drawing.Point(78, 6);
            this.lblHistoryOneText.Size = new System.Drawing.Size(520, 50);
            this.lblHistoryOneText.Text = "Paracetamol 500mg\r\nNhập kho định kỳ\r\nDS. Trần Văn Hùng • 15/5/2026";

            this.lblHistoryOneQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryOneQty.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblHistoryOneQty.Location = new System.Drawing.Point(1040, 16);
            this.lblHistoryOneQty.Size = new System.Drawing.Size(90, 28);
            this.lblHistoryOneQty.Text = "+500";
            this.lblHistoryOneQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlHistoryTwo
            this.pnlHistoryTwo.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlHistoryTwo.Location = new System.Drawing.Point(22, 150);
            this.pnlHistoryTwo.Size = new System.Drawing.Size(1152, 58);
            this.pnlHistoryTwo.Controls.Add(this.lblHistoryTwoQty);
            this.pnlHistoryTwo.Controls.Add(this.lblHistoryTwoText);
            this.pnlHistoryTwo.Controls.Add(this.lblHistoryTwoIcon);

            this.lblHistoryTwoIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTwoIcon.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblHistoryTwoIcon.Location = new System.Drawing.Point(16, 10);
            this.lblHistoryTwoIcon.Size = new System.Drawing.Size(46, 38);
            this.lblHistoryTwoIcon.Text = "↘";
            this.lblHistoryTwoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHistoryTwoIcon.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);

            this.lblHistoryTwoText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblHistoryTwoText.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHistoryTwoText.Location = new System.Drawing.Point(78, 6);
            this.lblHistoryTwoText.Size = new System.Drawing.Size(520, 50);
            this.lblHistoryTwoText.Text = "Paracetamol 500mg\r\nPhát thuốc cho toa #HD001234\r\nDS. Nguyễn Thị Mai • 17/5/2026";

            this.lblHistoryTwoQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTwoQty.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblHistoryTwoQty.Location = new System.Drawing.Point(1040, 16);
            this.lblHistoryTwoQty.Size = new System.Drawing.Size(90, 28);
            this.lblHistoryTwoQty.Text = "-50";
            this.lblHistoryTwoQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlHistoryThree
            this.pnlHistoryThree.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            this.pnlHistoryThree.Location = new System.Drawing.Point(22, 224);
            this.pnlHistoryThree.Size = new System.Drawing.Size(1152, 58);
            this.pnlHistoryThree.Controls.Add(this.lblHistoryThreeQty);
            this.pnlHistoryThree.Controls.Add(this.lblHistoryThreeText);
            this.pnlHistoryThree.Controls.Add(this.lblHistoryThreeIcon);

            this.lblHistoryThreeIcon.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHistoryThreeIcon.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblHistoryThreeIcon.Location = new System.Drawing.Point(16, 10);
            this.lblHistoryThreeIcon.Size = new System.Drawing.Size(46, 38);
            this.lblHistoryThreeIcon.Text = "↗";
            this.lblHistoryThreeIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHistoryThreeIcon.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);

            this.lblHistoryThreeText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblHistoryThreeText.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblHistoryThreeText.Location = new System.Drawing.Point(78, 6);
            this.lblHistoryThreeText.Size = new System.Drawing.Size(520, 50);
            this.lblHistoryThreeText.Text = "Augmentin 1g\r\nNhập kho từ nhà cung cấp mới\r\nDS. Trần Văn Hùng • 16/5/2026";

            this.lblHistoryThreeQty.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblHistoryThreeQty.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblHistoryThreeQty.Location = new System.Drawing.Point(1040, 16);
            this.lblHistoryThreeQty.Size = new System.Drawing.Size(90, 28);
            this.lblHistoryThreeQty.Text = "+200";
            this.lblHistoryThreeQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // 
            // ucInventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucInventoryManagement";
            this.Size = new System.Drawing.Size(1244, 1000);
            this.Load += new System.EventHandler(this.ucInventoryManagement_Load);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlStatsGrid.ResumeLayout(false);
            this.pnlValue.ResumeLayout(false);
            this.pnlTypes.ResumeLayout(false);
            this.pnlLowAlert.ResumeLayout(false);
            this.pnlExpired.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistoryOne.ResumeLayout(false);
            this.pnlHistoryTwo.ResumeLayout(false);
            this.pnlHistoryThree.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void SetInventorySearchActiveState()
        {
            txtSearch.ForeColor = Color.FromArgb(17, 24, 39);
        }

        private void SetInventorySearchPlaceholderState()
        {
            txtSearch.ForeColor = Color.FromArgb(148, 163, 184);
        }

        private RoundedPanel viewHostPanel;
        private Label lblHeading;
        private Label lblSubheading;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlValue;
        private Label lblValueTitle;
        private Label lblValueNumber;
        private Label lblValueUnit;
        private RoundedPanel pnlTypes;
        private Label lblTypesTitle;
        private Label lblTypesNumber;
        private Label lblTypesUnit;
        private RoundedPanel pnlLowAlert;
        private Label lblLowTitle;
        private Label lblLowNumber;
        private Label lblLowUnit;
        private RoundedPanel pnlExpired;
        private Label lblExpiredTitle;
        private Label lblExpiredNumber;
        private Label lblExpiredUnit;
        private RoundedPanel pnlFilters;
        private TextBox txtSearch;
        private ComboBox cboCategory;
        private ComboBox cboStatus;
        private RoundedPanel pnlTable;
        private DataGridView dgvInventory;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colBatch;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colExpiry;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colActions;
        private RoundedPanel pnlHistory;
        private Label lblHistoryTitle;
        private Panel pnlHistoryOne;
        private Label lblHistoryOneIcon;
        private Label lblHistoryOneText;
        private Label lblHistoryOneQty;
        private Panel pnlHistoryTwo;
        private Label lblHistoryTwoIcon;
        private Label lblHistoryTwoText;
        private Label lblHistoryTwoQty;
        private Panel pnlHistoryThree;
        private Label lblHistoryThreeIcon;
        private Label lblHistoryThreeText;
        private Label lblHistoryThreeQty;
        private Button btnAddMedicine;
    }
}
