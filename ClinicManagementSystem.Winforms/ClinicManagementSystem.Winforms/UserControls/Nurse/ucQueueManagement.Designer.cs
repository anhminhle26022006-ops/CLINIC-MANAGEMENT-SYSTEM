using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucQueueManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootPanel = new Panel();
            statsPanel = new Panel();
            cardWaiting = new Panel();
            lblWaitingTitle = new Label();
            lblWaitingCount = new Label();
            cardExamining = new Panel();
            lblExaminingTitle = new Label();
            lblExaminingCount = new Label();
            cardCompleted = new Panel();
            lblCompletedTitle = new Label();
            lblCompletedCount = new Label();
            filterPanel = new Panel();
            txtSearch = new TextBox();
            cboDepartment = new ComboBox();
            btnRefresh = new Button();
            contentPanel = new Panel();
            queueCard = new Panel();
            dgvQueues = new DataGridView();
            colDoctor = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colWaiting = new DataGridViewTextBoxColumn();
            colExamining = new DataGridViewTextBoxColumn();
            colCompleted = new DataGridViewTextBoxColumn();
            colCurrent = new DataGridViewTextBoxColumn();
            lblQueueTitle = new Label();
            detailCard = new Panel();
            lstWaitingPatients = new ListBox();
            lblDetailTitle = new Label();
            lblCurrentPatient = new Label();
            rootPanel.SuspendLayout();
            statsPanel.SuspendLayout();
            cardWaiting.SuspendLayout();
            cardExamining.SuspendLayout();
            cardCompleted.SuspendLayout();
            filterPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            queueCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQueues).BeginInit();
            detailCard.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.BackColor = Color.FromArgb(246, 248, 252);
            rootPanel.Controls.Add(contentPanel);
            rootPanel.Controls.Add(filterPanel);
            rootPanel.Controls.Add(statsPanel);
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Name = "rootPanel";
            rootPanel.Padding = new Padding(28, 22, 28, 28);
            rootPanel.Size = new Size(1180, 820);
            rootPanel.TabIndex = 0;
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.Transparent;
            statsPanel.Controls.Add(cardWaiting);
            statsPanel.Controls.Add(cardExamining);
            statsPanel.Controls.Add(cardCompleted);
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Location = new Point(28, 22);
            statsPanel.Name = "statsPanel";
            statsPanel.Size = new Size(1124, 104);
            statsPanel.TabIndex = 0;
            // 
            // cardWaiting
            // 
            cardWaiting.BackColor = Color.FromArgb(255, 247, 237);
            cardWaiting.Controls.Add(lblWaitingTitle);
            cardWaiting.Controls.Add(lblWaitingCount);
            cardWaiting.Location = new Point(0, 0);
            cardWaiting.Name = "cardWaiting";
            cardWaiting.Size = new Size(260, 86);
            cardWaiting.TabIndex = 0;
            cardWaiting.Paint += Card_Paint;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWaitingTitle.ForeColor = Color.FromArgb(217, 119, 6);
            lblWaitingTitle.Location = new Point(18, 14);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(180, 22);
            lblWaitingTitle.TabIndex = 0;
            lblWaitingTitle.Text = "Đang chờ";
            // 
            // lblWaitingCount
            // 
            lblWaitingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWaitingCount.ForeColor = Color.FromArgb(217, 119, 6);
            lblWaitingCount.Location = new Point(18, 34);
            lblWaitingCount.Name = "lblWaitingCount";
            lblWaitingCount.Size = new Size(120, 48);
            lblWaitingCount.TabIndex = 1;
            lblWaitingCount.Text = "0";
            // 
            // cardExamining
            // 
            cardExamining.BackColor = Color.FromArgb(239, 246, 255);
            cardExamining.Controls.Add(lblExaminingTitle);
            cardExamining.Controls.Add(lblExaminingCount);
            cardExamining.Location = new Point(278, 0);
            cardExamining.Name = "cardExamining";
            cardExamining.Size = new Size(260, 86);
            cardExamining.TabIndex = 1;
            cardExamining.Paint += Card_Paint;
            // 
            // lblExaminingTitle
            // 
            lblExaminingTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblExaminingTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblExaminingTitle.Location = new Point(18, 14);
            lblExaminingTitle.Name = "lblExaminingTitle";
            lblExaminingTitle.Size = new Size(180, 22);
            lblExaminingTitle.TabIndex = 0;
            lblExaminingTitle.Text = "Đang khám";
            // 
            // lblExaminingCount
            // 
            lblExaminingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblExaminingCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblExaminingCount.Location = new Point(18, 34);
            lblExaminingCount.Name = "lblExaminingCount";
            lblExaminingCount.Size = new Size(120, 48);
            lblExaminingCount.TabIndex = 1;
            lblExaminingCount.Text = "0";
            // 
            // cardCompleted
            // 
            cardCompleted.BackColor = Color.FromArgb(240, 253, 244);
            cardCompleted.Controls.Add(lblCompletedTitle);
            cardCompleted.Controls.Add(lblCompletedCount);
            cardCompleted.Location = new Point(556, 0);
            cardCompleted.Name = "cardCompleted";
            cardCompleted.Size = new Size(260, 86);
            cardCompleted.TabIndex = 2;
            cardCompleted.Paint += Card_Paint;
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCompletedTitle.ForeColor = Color.FromArgb(22, 163, 74);
            lblCompletedTitle.Location = new Point(18, 14);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(180, 22);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Text = "Hoàn thành hôm nay";
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCompletedCount.ForeColor = Color.FromArgb(22, 163, 74);
            lblCompletedCount.Location = new Point(18, 34);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(120, 48);
            lblCompletedCount.TabIndex = 1;
            lblCompletedCount.Text = "0";
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.White;
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(cboDepartment);
            filterPanel.Controls.Add(btnRefresh);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(28, 126);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1124, 68);
            filterPanel.TabIndex = 1;
            filterPanel.Paint += Card_Paint;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(18, 18);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm bác sĩ, phòng, bệnh nhân...";
            txtSearch.Size = new Size(330, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += filter_Changed;
            // 
            // cboDepartment
            // 
            cboDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDepartment.Font = new Font("Segoe UI", 10F);
            cboDepartment.Location = new Point(366, 18);
            cboDepartment.Name = "cboDepartment";
            cboDepartment.Size = new Size(260, 31);
            cboDepartment.TabIndex = 1;
            cboDepartment.SelectedIndexChanged += filter_Changed;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(37, 99, 235);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(986, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(108, 36);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Controls.Add(detailCard);
            contentPanel.Controls.Add(queueCard);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(28, 194);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(0, 18, 0, 0);
            contentPanel.Size = new Size(1124, 598);
            contentPanel.TabIndex = 2;
            // 
            // queueCard
            // 
            queueCard.BackColor = Color.White;
            queueCard.Controls.Add(dgvQueues);
            queueCard.Controls.Add(lblQueueTitle);
            queueCard.Dock = DockStyle.Fill;
            queueCard.Location = new Point(0, 18);
            queueCard.Name = "queueCard";
            queueCard.Size = new Size(754, 580);
            queueCard.TabIndex = 0;
            queueCard.Paint += Card_Paint;
            // 
            // dgvQueues
            // 
            dgvQueues.AllowUserToAddRows = false;
            dgvQueues.AllowUserToDeleteRows = false;
            dgvQueues.BackgroundColor = Color.White;
            dgvQueues.BorderStyle = BorderStyle.None;
            dgvQueues.ColumnHeadersHeight = 44;
            dgvQueues.Columns.AddRange(new DataGridViewColumn[] { colDoctor, colDepartment, colRoom, colWaiting, colExamining, colCompleted, colCurrent });
            dgvQueues.Dock = DockStyle.Fill;
            dgvQueues.Location = new Point(0, 54);
            dgvQueues.Name = "dgvQueues";
            dgvQueues.RowHeadersVisible = false;
            dgvQueues.RowHeadersWidth = 51;
            dgvQueues.RowTemplate.Height = 48;
            dgvQueues.Size = new Size(754, 526);
            dgvQueues.TabIndex = 1;
            dgvQueues.SelectionChanged += dgvQueues_SelectionChanged;
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 19F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.Name = "colDoctor";
            // 
            // colDepartment
            // 
            colDepartment.FillWeight = 17F;
            colDepartment.HeaderText = "KHOA";
            colDepartment.Name = "colDepartment";
            // 
            // colRoom
            // 
            colRoom.FillWeight = 10F;
            colRoom.HeaderText = "PHÒNG";
            colRoom.Name = "colRoom";
            // 
            // colWaiting
            // 
            colWaiting.FillWeight = 10F;
            colWaiting.HeaderText = "CHỜ";
            colWaiting.Name = "colWaiting";
            // 
            // colExamining
            // 
            colExamining.FillWeight = 10F;
            colExamining.HeaderText = "KHÁM";
            colExamining.Name = "colExamining";
            // 
            // colCompleted
            // 
            colCompleted.FillWeight = 10F;
            colCompleted.HeaderText = "XONG";
            colCompleted.Name = "colCompleted";
            // 
            // colCurrent
            // 
            colCurrent.FillWeight = 24F;
            colCurrent.HeaderText = "ĐANG KHÁM";
            colCurrent.Name = "colCurrent";
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.Dock = DockStyle.Top;
            lblQueueTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblQueueTitle.Location = new Point(0, 0);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Padding = new Padding(22, 14, 0, 0);
            lblQueueTitle.Size = new Size(754, 54);
            lblQueueTitle.TabIndex = 0;
            lblQueueTitle.Text = "Danh sách phòng khám";
            // 
            // detailCard
            // 
            detailCard.BackColor = Color.White;
            detailCard.Controls.Add(lstWaitingPatients);
            detailCard.Controls.Add(lblCurrentPatient);
            detailCard.Controls.Add(lblDetailTitle);
            detailCard.Dock = DockStyle.Right;
            detailCard.Location = new Point(774, 18);
            detailCard.Name = "detailCard";
            detailCard.Size = new Size(350, 580);
            detailCard.TabIndex = 1;
            detailCard.Paint += Card_Paint;
            // 
            // lstWaitingPatients
            // 
            lstWaitingPatients.BorderStyle = BorderStyle.None;
            lstWaitingPatients.Dock = DockStyle.Fill;
            lstWaitingPatients.Font = new Font("Segoe UI", 10F);
            lstWaitingPatients.ItemHeight = 23;
            lstWaitingPatients.Location = new Point(0, 116);
            lstWaitingPatients.Name = "lstWaitingPatients";
            lstWaitingPatients.Size = new Size(350, 464);
            lstWaitingPatients.TabIndex = 2;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Dock = DockStyle.Top;
            lblDetailTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblDetailTitle.Location = new Point(0, 0);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Padding = new Padding(20, 14, 0, 0);
            lblDetailTitle.Size = new Size(350, 54);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Bệnh nhân chờ";
            // 
            // lblCurrentPatient
            // 
            lblCurrentPatient.Dock = DockStyle.Top;
            lblCurrentPatient.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCurrentPatient.ForeColor = Color.FromArgb(37, 99, 235);
            lblCurrentPatient.Location = new Point(0, 54);
            lblCurrentPatient.Name = "lblCurrentPatient";
            lblCurrentPatient.Padding = new Padding(20, 8, 20, 0);
            lblCurrentPatient.Size = new Size(350, 62);
            lblCurrentPatient.TabIndex = 1;
            lblCurrentPatient.Text = "Đang khám: --";
            // 
            // ucQueueManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 252);
            Controls.Add(rootPanel);
            Name = "ucQueueManagement";
            Size = new Size(1180, 820);
            rootPanel.ResumeLayout(false);
            statsPanel.ResumeLayout(false);
            cardWaiting.ResumeLayout(false);
            cardExamining.ResumeLayout(false);
            cardCompleted.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            queueCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQueues).EndInit();
            detailCard.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel rootPanel;
        private Panel statsPanel;
        private Panel cardWaiting;
        private Panel cardExamining;
        private Panel cardCompleted;
        private Label lblWaitingTitle;
        private Label lblWaitingCount;
        private Label lblExaminingTitle;
        private Label lblExaminingCount;
        private Label lblCompletedTitle;
        private Label lblCompletedCount;
        private Panel filterPanel;
        private TextBox txtSearch;
        private ComboBox cboDepartment;
        private Button btnRefresh;
        private Panel contentPanel;
        private Panel queueCard;
        private DataGridView dgvQueues;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colWaiting;
        private DataGridViewTextBoxColumn colExamining;
        private DataGridViewTextBoxColumn colCompleted;
        private DataGridViewTextBoxColumn colCurrent;
        private Label lblQueueTitle;
        private Panel detailCard;
        private ListBox lstWaitingPatients;
        private Label lblDetailTitle;
        private Label lblCurrentPatient;
    }
}
