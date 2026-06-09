using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucMedicineCatalog
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
            btnAddMedicine = new Button();
            lblHeading = new Label();
            lblSubheading = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlTotal = new RoundedPanel();
            lblTotalTitle = new Label();
            lblTotalValue = new Label();
            pnlAvailable = new RoundedPanel();
            lblAvailableTitle = new Label();
            lblAvailableValue = new Label();
            pnlLow = new RoundedPanel();
            lblLowTitle = new Label();
            lblLowValue = new Label();
            pnlOut = new RoundedPanel();
            lblOutTitle = new Label();
            lblOutValue = new Label();
            pnlFilters = new RoundedPanel();
            txtMedicineSearch = new TextBox();
            cboCategory = new ComboBox();
            cboStatus = new ComboBox();
            pnlTable = new RoundedPanel();
            dgvMedicines = new DataGridView();
            colCode = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colPrice = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAction = new DataGridViewTextBoxColumn();
            viewHostPanel.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlTotal.SuspendLayout();
            pnlAvailable.SuspendLayout();
            pnlLow.SuspendLayout();
            pnlOut.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).BeginInit();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            this.viewHostPanel.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.BorderColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.CornerRadius = 8;
            this.viewHostPanel.FillColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.viewHostPanel.AutoScroll = true;
            this.viewHostPanel.Controls.Add(this.pnlTable);
            this.viewHostPanel.Controls.Add(this.pnlFilters);
            this.viewHostPanel.Controls.Add(this.pnlStatsGrid);
            this.viewHostPanel.Controls.Add(this.btnAddMedicine);
            this.viewHostPanel.Controls.Add(this.lblSubheading);
            this.viewHostPanel.Controls.Add(this.lblHeading);
            this.viewHostPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewHostPanel.Size = new System.Drawing.Size(1244, 900);
            // 
            // heading
            // 
            this.lblHeading.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblHeading.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblHeading.Location = new System.Drawing.Point(24, 24);
            this.lblHeading.Size = new System.Drawing.Size(360, 40);
            this.lblHeading.Text = "Danh mục thuốc";
            this.lblSubheading.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblSubheading.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubheading.Location = new System.Drawing.Point(24, 66);
            this.lblSubheading.Size = new System.Drawing.Size(360, 28);
            this.lblSubheading.Text = "Quản lý kho thuốc";
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
            // 
            // stats
            // 
            this.pnlStatsGrid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlStatsGrid.ColumnCount = 4;
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlStatsGrid.Controls.Add(this.pnlTotal, 0, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlAvailable, 1, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlLow, 2, 0);
            this.pnlStatsGrid.Controls.Add(this.pnlOut, 3, 0);
            this.pnlStatsGrid.Location = new System.Drawing.Point(24, 122);
            this.pnlStatsGrid.RowCount = 1;
            this.pnlStatsGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlStatsGrid.Size = new System.Drawing.Size(1196, 100);
            // pnlTotal
            this.pnlTotal.BackColor = System.Drawing.Color.White;
            this.pnlTotal.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlTotal.CornerRadius = 8;
            this.pnlTotal.FillColor = System.Drawing.Color.White;
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTotal.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlTotal.Controls.Add(this.lblTotalValue);
            this.pnlTotal.Controls.Add(this.lblTotalTitle);
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblTotalTitle.Location = new System.Drawing.Point(18, 18);
            this.lblTotalTitle.Size = new System.Drawing.Size(220, 24);
            this.lblTotalTitle.Text = "Tổng loại thuốc";
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(47, 94, 240);
            this.lblTotalValue.Location = new System.Drawing.Point(18, 50);
            this.lblTotalValue.Size = new System.Drawing.Size(120, 34);
            this.lblTotalValue.Text = "5";
            // pnlAvailable
            this.pnlAvailable.BackColor = System.Drawing.Color.White;
            this.pnlAvailable.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlAvailable.CornerRadius = 8;
            this.pnlAvailable.FillColor = System.Drawing.Color.White;
            this.pnlAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailable.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlAvailable.Controls.Add(this.lblAvailableValue);
            this.pnlAvailable.Controls.Add(this.lblAvailableTitle);
            this.lblAvailableTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblAvailableTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblAvailableTitle.Location = new System.Drawing.Point(18, 18);
            this.lblAvailableTitle.Size = new System.Drawing.Size(220, 24);
            this.lblAvailableTitle.Text = "Còn hàng";
            this.lblAvailableValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblAvailableValue.ForeColor = System.Drawing.Color.FromArgb(34, 139, 74);
            this.lblAvailableValue.Location = new System.Drawing.Point(18, 50);
            this.lblAvailableValue.Size = new System.Drawing.Size(120, 34);
            this.lblAvailableValue.Text = "3";
            // pnlLow
            this.pnlLow.BackColor = System.Drawing.Color.White;
            this.pnlLow.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlLow.CornerRadius = 8;
            this.pnlLow.FillColor = System.Drawing.Color.White;
            this.pnlLow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLow.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.pnlLow.Controls.Add(this.lblLowValue);
            this.pnlLow.Controls.Add(this.lblLowTitle);
            this.lblLowTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblLowTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblLowTitle.Location = new System.Drawing.Point(18, 18);
            this.lblLowTitle.Size = new System.Drawing.Size(220, 24);
            this.lblLowTitle.Text = "Sắp hết";
            this.lblLowValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblLowValue.ForeColor = System.Drawing.Color.FromArgb(202, 138, 4);
            this.lblLowValue.Location = new System.Drawing.Point(18, 50);
            this.lblLowValue.Size = new System.Drawing.Size(120, 34);
            this.lblLowValue.Text = "1";
            // pnlOut
            this.pnlOut.BackColor = System.Drawing.Color.White;
            this.pnlOut.BorderColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.pnlOut.CornerRadius = 8;
            this.pnlOut.FillColor = System.Drawing.Color.White;
            this.pnlOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOut.Margin = new System.Windows.Forms.Padding(0);
            this.pnlOut.Controls.Add(this.lblOutValue);
            this.pnlOut.Controls.Add(this.lblOutTitle);
            this.lblOutTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblOutTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblOutTitle.Location = new System.Drawing.Point(18, 18);
            this.lblOutTitle.Size = new System.Drawing.Size(220, 24);
            this.lblOutTitle.Text = "Hết hàng";
            this.lblOutValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblOutValue.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblOutValue.Location = new System.Drawing.Point(18, 50);
            this.lblOutValue.Size = new System.Drawing.Size(120, 34);
            this.lblOutValue.Text = "1";
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
            this.pnlFilters.Controls.Add(this.txtMedicineSearch);
            this.pnlFilters.Location = new System.Drawing.Point(24, 246);
            this.pnlFilters.Size = new System.Drawing.Size(1196, 82);
            this.txtMedicineSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMedicineSearch.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.txtMedicineSearch.Location = new System.Drawing.Point(18, 24);
            this.txtMedicineSearch.Size = new System.Drawing.Size(380, 30);
            this.txtMedicineSearch.Text = "  Tìm kiếm tên thuốc, mã thuốc...";
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.Items.AddRange(new object[] { "Tất cả loại thuốc", "Kháng sinh", "Giảm đau", "Kháng viêm", "Vitamin" });
            this.cboCategory.Location = new System.Drawing.Point(418, 24);
            this.cboCategory.Size = new System.Drawing.Size(360, 31);
            this.cboCategory.SelectedIndex = 0;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Còn hàng",
            "Sắp hết",
            "Hết hàng"});
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
            this.pnlTable.Controls.Add(this.dgvMedicines);
            this.pnlTable.Location = new System.Drawing.Point(24, 352);
            this.pnlTable.Size = new System.Drawing.Size(1196, 360);
            this.dgvMedicines.AllowUserToAddRows = false;
            this.dgvMedicines.AllowUserToDeleteRows = false;
            this.dgvMedicines.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicines.ColumnHeadersHeight = 48;
            this.dgvMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colName,
            this.colCategory,
            this.colStock,
            this.colPrice,
            this.colStatus,
            this.colAction});
            this.dgvMedicines.EnableHeadersVisualStyles = false;
            this.dgvMedicines.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvMedicines.Location = new System.Drawing.Point(1, 1);
            this.dgvMedicines.ReadOnly = true;
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.RowTemplate.Height = 52;
            this.dgvMedicines.Size = new System.Drawing.Size(1194, 358);
            this.dgvMedicines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.colCode.HeaderText = "MÃ THUỐC";
            this.colCode.Width = 140;
            this.colName.HeaderText = "TÊN THUỐC";
            this.colName.Width = 230;
            this.colCategory.HeaderText = "LOẠI THUỐC";
            this.colCategory.Width = 180;
            this.colStock.HeaderText = "TỒN KHO";
            this.colStock.Width = 140;
            this.colPrice.HeaderText = "GIÁ";
            this.colPrice.Width = 130;
            this.colStatus.HeaderText = "TRẠNG THÁI";
            this.colStatus.Width = 150;
            this.colAction.HeaderText = "THAO TÁC";
            this.colAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // ucMedicineCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.Controls.Add(this.viewHostPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "ucMedicineCatalog";
            this.Size = new System.Drawing.Size(1244, 900);
            this.Load += new System.EventHandler(this.ucMedicineCatalog_Load);
            this.viewHostPanel.ResumeLayout(false);
            this.pnlStatsGrid.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlAvailable.ResumeLayout(false);
            this.pnlLow.ResumeLayout(false);
            this.pnlOut.ResumeLayout(false);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetMedicineSearchActiveState()
        {
            txtMedicineSearch.ForeColor = Color.FromArgb(17, 24, 39);
        }

        private void SetMedicineSearchPlaceholderState()
        {
            txtMedicineSearch.ForeColor = Color.FromArgb(148, 163, 184);
        }

        private RoundedPanel viewHostPanel;
        private Button btnAddMedicine;
        private Label lblHeading;
        private Label lblSubheading;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlTotal;
        private Label lblTotalTitle;
        private Label lblTotalValue;
        private RoundedPanel pnlAvailable;
        private Label lblAvailableTitle;
        private Label lblAvailableValue;
        private RoundedPanel pnlLow;
        private Label lblLowTitle;
        private Label lblLowValue;
        private RoundedPanel pnlOut;
        private Label lblOutTitle;
        private Label lblOutValue;
        private RoundedPanel pnlFilters;
        private TextBox txtMedicineSearch;
        private ComboBox cboCategory;
        private ComboBox cboStatus;
        private RoundedPanel pnlTable;
        private DataGridView dgvMedicines;
        private DataGridViewTextBoxColumn colCode;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAction;
    }
}
