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
            ConfigureCard(viewHostPanel, Color.FromArgb(247, 249, 252), Color.FromArgb(247, 249, 252));
            viewHostPanel.AutoScroll = true;
            viewHostPanel.Controls.Add(pnlHistory);
            viewHostPanel.Controls.Add(pnlTable);
            viewHostPanel.Controls.Add(pnlFilters);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.Controls.Add(lblSubheading);
            viewHostPanel.Controls.Add(lblHeading);
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.Size = new Size(1244, 1000);
            SetupLabel(lblHeading, "Quản lý kho thuốc", 18F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 24, 24, 360, 40);
            SetupLabel(lblSubheading, "Theo dõi nhập xuất và tồn kho thuốc", 10F, FontStyle.Regular, Color.FromArgb(107, 114, 128), 24, 66, 420, 28);
            // 
            // stats
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 4;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.Controls.Add(pnlValue, 0, 0);
            pnlStatsGrid.Controls.Add(pnlTypes, 1, 0);
            pnlStatsGrid.Controls.Add(pnlLowAlert, 2, 0);
            pnlStatsGrid.Controls.Add(pnlExpired, 3, 0);
            pnlStatsGrid.Location = new Point(24, 120);
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1196, 130);
            SetupStat(pnlValue, lblValueTitle, lblValueNumber, lblValueUnit, "Tổng giá trị kho", "6.3M", "VNĐ", Color.FromArgb(47, 94, 240), Color.FromArgb(239, 246, 255), Color.FromArgb(191, 219, 254), new Padding(0, 0, 14, 0));
            SetupStat(pnlTypes, lblTypesTitle, lblTypesNumber, lblTypesUnit, "Tổng số loại thuốc", "6", "loại", Color.FromArgb(34, 139, 74), Color.FromArgb(240, 253, 244), Color.FromArgb(187, 247, 208), new Padding(0, 0, 14, 0));
            SetupStat(pnlLowAlert, lblLowTitle, lblLowNumber, lblLowUnit, "Cảnh báo sắp hết", "2", "loại thuốc", Color.FromArgb(220, 38, 38), Color.FromArgb(254, 242, 242), Color.FromArgb(254, 202, 202), new Padding(0, 0, 14, 0));
            SetupStat(pnlExpired, lblExpiredTitle, lblExpiredNumber, lblExpiredUnit, "Sắp hết hạn", "0", "loại thuốc", Color.FromArgb(234, 88, 12), Color.FromArgb(255, 247, 237), Color.FromArgb(254, 215, 170), new Padding(0));
            // 
            // filters
            // 
            ConfigureCard(pnlFilters, Color.White, Color.FromArgb(229, 231, 235));
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.Controls.Add(cboStatus);
            pnlFilters.Controls.Add(cboCategory);
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Location = new Point(24, 278);
            pnlFilters.Size = new Size(1196, 76);
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(148, 163, 184);
            txtSearch.Location = new Point(18, 24);
            txtSearch.Size = new Size(380, 30);
            txtSearch.Text = "  Tìm thuốc, batch...";
            SetupCombo(cboCategory, 418, "Tất cả danh mục");
            SetupCombo(cboStatus, 790, "Tất cả trạng thái");
            // 
            // table
            // 
            ConfigureCard(pnlTable, Color.White, Color.FromArgb(229, 231, 235));
            pnlTable.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTable.Controls.Add(dgvInventory);
            pnlTable.Location = new Point(24, 382);
            pnlTable.Size = new Size(1196, 420);
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeight = 48;
            dgvInventory.Columns.AddRange(new DataGridViewColumn[] { colName, colCategory, colBatch, colStock, colExpiry, colLocation, colActions });
            dgvInventory.EnableHeadersVisualStyles = false;
            dgvInventory.GridColor = Color.FromArgb(229, 231, 235);
            dgvInventory.Location = new Point(1, 1);
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.RowTemplate.Height = 58;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(1194, 418);
            colName.HeaderText = "TÊN THUỐC";
            colName.Width = 230;
            colCategory.HeaderText = "DANH MỤC";
            colCategory.Width = 190;
            colBatch.HeaderText = "BATCH";
            colBatch.Width = 170;
            colStock.HeaderText = "TỒN KHO";
            colStock.Width = 130;
            colExpiry.HeaderText = "HẠN SỬ DỤNG";
            colExpiry.Width = 150;
            colLocation.HeaderText = "VỊ TRÍ";
            colLocation.Width = 120;
            colActions.HeaderText = "THAO TÁC";
            colActions.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // 
            // history
            // 
            ConfigureCard(pnlHistory, Color.White, Color.FromArgb(229, 231, 235));
            pnlHistory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlHistory.Controls.Add(pnlHistoryThree);
            pnlHistory.Controls.Add(pnlHistoryTwo);
            pnlHistory.Controls.Add(pnlHistoryOne);
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Location = new Point(24, 830);
            pnlHistory.Size = new Size(1196, 300);
            SetupLabel(lblHistoryTitle, "Lịch sử nhập xuất gần đây", 14F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 22, 24, 360, 32);
            SetupHistory(pnlHistoryOne, lblHistoryOneIcon, lblHistoryOneText, lblHistoryOneQty, "↗", "Paracetamol 500mg\r\nNhập kho định kỳ\r\nDS. Trần Văn Hùng • 15/5/2026", "+500", Color.FromArgb(34, 139, 74), 22, 76);
            SetupHistory(pnlHistoryTwo, lblHistoryTwoIcon, lblHistoryTwoText, lblHistoryTwoQty, "↘", "Paracetamol 500mg\r\nPhát thuốc cho toa #HD001234\r\nDS. Nguyễn Thị Mai • 17/5/2026", "-50", Color.FromArgb(220, 38, 38), 22, 150);
            SetupHistory(pnlHistoryThree, lblHistoryThreeIcon, lblHistoryThreeText, lblHistoryThreeQty, "↗", "Augmentin 1g\r\nNhập kho từ nhà cung cấp mới\r\nDS. Trần Văn Hùng • 16/5/2026", "+200", Color.FromArgb(34, 139, 74), 22, 224);
            // 
            // ucInventoryManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Font = new Font("Segoe UI", 9F);
            Name = "ucInventoryManagement";
            Size = new Size(1244, 1000);
            Load += ucInventoryManagement_Load;
            viewHostPanel.ResumeLayout(false);
            pnlStatsGrid.ResumeLayout(false);
            pnlValue.ResumeLayout(false);
            pnlTypes.ResumeLayout(false);
            pnlLowAlert.ResumeLayout(false);
            pnlExpired.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            pnlHistory.ResumeLayout(false);
            pnlHistoryOne.ResumeLayout(false);
            pnlHistoryTwo.ResumeLayout(false);
            pnlHistoryThree.ResumeLayout(false);
            ResumeLayout(false);
        }

        private static void ConfigureCard(RoundedPanel panel, Color fill, Color border)
        {
            panel.BackColor = fill;
            panel.BorderColor = border;
            panel.CornerRadius = 8;
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

        private static void SetupStat(RoundedPanel panel, Label title, Label value, Label unit, string titleText, string valueText, string unitText, Color accent, Color fill, Color border, Padding margin)
        {
            ConfigureCard(panel, fill, border);
            panel.Dock = DockStyle.Fill;
            panel.Margin = margin;
            panel.Controls.Add(unit);
            panel.Controls.Add(value);
            panel.Controls.Add(title);
            SetupLabel(title, titleText, 10F, FontStyle.Regular, accent, 22, 24, 220, 24);
            SetupLabel(value, valueText, 24F, FontStyle.Bold, accent, 22, 54, 150, 42);
            SetupLabel(unit, unitText, 9F, FontStyle.Regular, accent, 22, 96, 160, 24);
        }

        private static void SetupCombo(ComboBox combo, int x, string firstItem)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.Font = new Font("Segoe UI", 10F);
            combo.Items.AddRange(new object[] { firstItem, "Kháng sinh", "Giảm đau", "Vitamin", "Sắp hết" });
            combo.Location = new Point(x, 24);
            combo.Size = new Size(360, 31);
            combo.SelectedIndex = 0;
        }

        private static void SetupHistory(Panel panel, Label icon, Label text, Label quantity, string iconText, string textValue, string qty, Color accent, int x, int y)
        {
            panel.BackColor = Color.FromArgb(249, 250, 251);
            panel.Controls.Add(quantity);
            panel.Controls.Add(text);
            panel.Controls.Add(icon);
            panel.Location = new Point(x, y);
            panel.Size = new Size(1152, 58);
            SetupLabel(icon, iconText, 18F, FontStyle.Bold, accent, 16, 10, 46, 38, ContentAlignment.MiddleCenter);
            icon.BackColor = accent == Color.FromArgb(34, 139, 74) ? Color.FromArgb(220, 252, 231) : Color.FromArgb(254, 226, 226);
            SetupLabel(text, textValue, 9.5F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 78, 6, 520, 50);
            SetupLabel(quantity, qty, 12F, FontStyle.Bold, accent, 1040, 16, 90, 28, ContentAlignment.MiddleRight);
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
    }
}
