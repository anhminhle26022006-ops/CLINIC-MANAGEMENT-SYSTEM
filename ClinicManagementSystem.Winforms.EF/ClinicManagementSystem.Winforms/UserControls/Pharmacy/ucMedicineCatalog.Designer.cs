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
            ConfigureCard(viewHostPanel, Color.FromArgb(247, 249, 252), Color.FromArgb(247, 249, 252));
            viewHostPanel.AutoScroll = true;
            viewHostPanel.Controls.Add(pnlTable);
            viewHostPanel.Controls.Add(pnlFilters);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Controls.Add(btnAddMedicine);
            viewHostPanel.Controls.Add(lblSubheading);
            viewHostPanel.Controls.Add(lblHeading);
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.Size = new Size(1244, 900);
            // 
            // heading
            // 
            SetupLabel(lblHeading, "Danh mục thuốc", 18F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 24, 24, 360, 40);
            SetupLabel(lblSubheading, "Quản lý kho thuốc", 10F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 24, 66, 360, 28);
            btnAddMedicine.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMedicine.BackColor = Color.FromArgb(47, 94, 240);
            btnAddMedicine.Cursor = Cursors.Hand;
            btnAddMedicine.FlatAppearance.BorderSize = 0;
            btnAddMedicine.FlatStyle = FlatStyle.Flat;
            btnAddMedicine.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddMedicine.ForeColor = Color.White;
            btnAddMedicine.Location = new Point(1068, 34);
            btnAddMedicine.Size = new Size(150, 42);
            btnAddMedicine.Text = "+  Thêm thuốc";
            btnAddMedicine.UseVisualStyleBackColor = false;
            // 
            // stats
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 4;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.Controls.Add(pnlTotal, 0, 0);
            pnlStatsGrid.Controls.Add(pnlAvailable, 1, 0);
            pnlStatsGrid.Controls.Add(pnlLow, 2, 0);
            pnlStatsGrid.Controls.Add(pnlOut, 3, 0);
            pnlStatsGrid.Location = new Point(24, 122);
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1196, 100);
            SetupMiniStat(pnlTotal, lblTotalTitle, lblTotalValue, "Tổng loại thuốc", "5", Color.FromArgb(47, 94, 240), new Padding(0, 0, 14, 0));
            SetupMiniStat(pnlAvailable, lblAvailableTitle, lblAvailableValue, "Còn hàng", "3", Color.FromArgb(34, 139, 74), new Padding(0, 0, 14, 0));
            SetupMiniStat(pnlLow, lblLowTitle, lblLowValue, "Sắp hết", "1", Color.FromArgb(202, 138, 4), new Padding(0, 0, 14, 0));
            SetupMiniStat(pnlOut, lblOutTitle, lblOutValue, "Hết hàng", "1", Color.FromArgb(220, 38, 38), new Padding(0));
            // 
            // filters
            // 
            ConfigureCard(pnlFilters, Color.White, Color.FromArgb(229, 231, 235));
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.Controls.Add(cboStatus);
            pnlFilters.Controls.Add(cboCategory);
            pnlFilters.Controls.Add(txtMedicineSearch);
            pnlFilters.Location = new Point(24, 246);
            pnlFilters.Size = new Size(1196, 82);
            txtMedicineSearch.Font = new Font("Segoe UI", 10F);
            txtMedicineSearch.ForeColor = Color.FromArgb(148, 163, 184);
            txtMedicineSearch.Location = new Point(18, 24);
            txtMedicineSearch.Size = new Size(380, 30);
            txtMedicineSearch.Text = "  Tìm kiếm tên thuốc, mã thuốc...";
            SetupCombo(cboCategory, 418, "Tất cả loại thuốc");
            SetupCombo(cboStatus, 790, "Tất cả trạng thái");
            // 
            // table
            // 
            ConfigureCard(pnlTable, Color.White, Color.FromArgb(229, 231, 235));
            pnlTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTable.Controls.Add(dgvMedicines);
            pnlTable.Location = new Point(24, 352);
            pnlTable.Size = new Size(1196, 360);
            dgvMedicines.AllowUserToAddRows = false;
            dgvMedicines.AllowUserToDeleteRows = false;
            dgvMedicines.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMedicines.BackgroundColor = Color.White;
            dgvMedicines.BorderStyle = BorderStyle.None;
            dgvMedicines.ColumnHeadersHeight = 48;
            dgvMedicines.Columns.AddRange(new DataGridViewColumn[] { colCode, colName, colCategory, colStock, colPrice, colStatus, colAction });
            dgvMedicines.EnableHeadersVisualStyles = false;
            dgvMedicines.GridColor = Color.FromArgb(229, 231, 235);
            dgvMedicines.Location = new Point(1, 1);
            dgvMedicines.ReadOnly = true;
            dgvMedicines.RowHeadersVisible = false;
            dgvMedicines.RowTemplate.Height = 52;
            dgvMedicines.Size = new Size(1194, 358);
            dgvMedicines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            colCode.HeaderText = "MÃ THUỐC";
            colCode.Width = 140;
            colName.HeaderText = "TÊN THUỐC";
            colName.Width = 230;
            colCategory.HeaderText = "LOẠI THUỐC";
            colCategory.Width = 180;
            colStock.HeaderText = "TỒN KHO";
            colStock.Width = 140;
            colPrice.HeaderText = "GIÁ";
            colPrice.Width = 130;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Width = 150;
            colAction.HeaderText = "THAO TÁC";
            colAction.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // ucMedicineCatalog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "ucMedicineCatalog";
            Size = new Size(1244, 900);
            Load += ucMedicineCatalog_Load;
            viewHostPanel.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
            pnlAvailable.ResumeLayout(false);
            pnlLow.ResumeLayout(false);
            pnlOut.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMedicines).EndInit();
            ResumeLayout(false);
        }

        private static void ConfigureCard(RoundedPanel panel, Color fill, Color border)
        {
            panel.BackColor = fill;
            panel.BorderColor = border;
            panel.CornerRadius = 8;
            panel.FillColor = fill;
        }

        private static void SetupLabel(Label label, string text, float size, FontStyle style, Color color, int x, int y, int width, int height)
        {
            label.Font = new Font("Segoe UI", size, style);
            label.ForeColor = color;
            label.Location = new Point(x, y);
            label.Size = new Size(width, height);
            label.Text = text;
        }

        private static void SetupMiniStat(RoundedPanel panel, Label title, Label value, string titleText, string valueText, Color accent, Padding margin)
        {
            ConfigureCard(panel, Color.White, Color.FromArgb(229, 231, 235));
            panel.Dock = DockStyle.Fill;
            panel.Margin = margin;
            panel.Controls.Add(value);
            panel.Controls.Add(title);
            SetupLabel(title, titleText, 9.5F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 18, 18, 220, 24);
            SetupLabel(value, valueText, 18F, FontStyle.Bold, accent, 18, 50, 120, 34);
        }

        private static void SetupCombo(ComboBox combo, int x, string firstItem)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Font = new Font("Segoe UI", 10F);
            combo.Items.AddRange(new object[] { firstItem, "Kháng sinh", "Giảm đau", "Kháng viêm", "Vitamin" });
            combo.Location = new Point(x, 24);
            combo.Size = new Size(360, 31);
            combo.SelectedIndex = 0;
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
