using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseMedicalRecords
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
            filterPanel = new Panel();
            txtSearch = new TextBox();
            btnRefresh = new Button();
            contentPanel = new Panel();
            recordsCard = new Panel();
            dgvRecords = new DataGridView();
            colEncounter = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colVisit = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colVitals = new DataGridViewTextBoxColumn();
            lblRecordsTitle = new Label();
            detailCard = new Panel();
            lblDetailTitle = new Label();
            lblPatientInfo = new Label();
            lblVisitInfo = new Label();
            lblVitalInfo = new Label();
            txtDiagnosis = new TextBox();
            txtNursingNote = new TextBox();
            lblDiagnosis = new Label();
            lblNursingNote = new Label();
            rootPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            recordsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecords).BeginInit();
            detailCard.SuspendLayout();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.BackColor = Color.FromArgb(246, 248, 252);
            rootPanel.Controls.Add(contentPanel);
            rootPanel.Controls.Add(filterPanel);
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Name = "rootPanel";
            rootPanel.Padding = new Padding(28, 22, 28, 28);
            rootPanel.Size = new Size(1180, 820);
            rootPanel.TabIndex = 0;
            // 
            // filterPanel
            // 
            filterPanel.BackColor = Color.White;
            filterPanel.Controls.Add(txtSearch);
            filterPanel.Controls.Add(btnRefresh);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(28, 22);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1124, 70);
            filterPanel.TabIndex = 0;
            filterPanel.Paint += Card_Paint;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(18, 19);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm bệnh nhân, mã hồ sơ, mã lượt khám...";
            txtSearch.Size = new Size(420, 30);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += txtSearch_TextChanged;
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
            btnRefresh.Location = new Point(986, 16);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(108, 38);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.Transparent;
            contentPanel.Controls.Add(recordsCard);
            contentPanel.Controls.Add(detailCard);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(28, 92);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(0, 18, 0, 0);
            contentPanel.Size = new Size(1124, 700);
            contentPanel.TabIndex = 1;
            // 
            // recordsCard
            // 
            recordsCard.BackColor = Color.White;
            recordsCard.Controls.Add(dgvRecords);
            recordsCard.Controls.Add(lblRecordsTitle);
            recordsCard.Dock = DockStyle.Fill;
            recordsCard.Location = new Point(0, 18);
            recordsCard.Name = "recordsCard";
            recordsCard.Size = new Size(704, 682);
            recordsCard.TabIndex = 0;
            recordsCard.Paint += Card_Paint;
            // 
            // dgvRecords
            // 
            dgvRecords.AllowUserToAddRows = false;
            dgvRecords.AllowUserToDeleteRows = false;
            dgvRecords.BackgroundColor = Color.White;
            dgvRecords.BorderStyle = BorderStyle.None;
            dgvRecords.ColumnHeadersHeight = 44;
            dgvRecords.Columns.AddRange(new DataGridViewColumn[] { colEncounter, colPatient, colVisit, colDoctor, colStatus, colVitals });
            dgvRecords.Dock = DockStyle.Fill;
            dgvRecords.Location = new Point(0, 54);
            dgvRecords.Name = "dgvRecords";
            dgvRecords.RowHeadersVisible = false;
            dgvRecords.RowHeadersWidth = 51;
            dgvRecords.RowTemplate.Height = 50;
            dgvRecords.Size = new Size(704, 628);
            dgvRecords.TabIndex = 1;
            dgvRecords.SelectionChanged += dgvRecords_SelectionChanged;
            // 
            // colEncounter
            // 
            colEncounter.FillWeight = 10F;
            colEncounter.HeaderText = "LƯỢT";
            colEncounter.Name = "colEncounter";
            // 
            // colPatient
            // 
            colPatient.FillWeight = 24F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.Name = "colPatient";
            // 
            // colVisit
            // 
            colVisit.FillWeight = 17F;
            colVisit.HeaderText = "NGÀY KHÁM";
            colVisit.Name = "colVisit";
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 19F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.Name = "colDoctor";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 14F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Name = "colStatus";
            // 
            // colVitals
            // 
            colVitals.FillWeight = 16F;
            colVitals.HeaderText = "SINH HIỆU";
            colVitals.Name = "colVitals";
            // 
            // lblRecordsTitle
            // 
            lblRecordsTitle.Dock = DockStyle.Top;
            lblRecordsTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRecordsTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblRecordsTitle.Location = new Point(0, 0);
            lblRecordsTitle.Name = "lblRecordsTitle";
            lblRecordsTitle.Padding = new Padding(22, 14, 0, 0);
            lblRecordsTitle.Size = new Size(704, 54);
            lblRecordsTitle.TabIndex = 0;
            lblRecordsTitle.Text = "Hồ sơ bệnh án";
            // 
            // detailCard
            // 
            detailCard.BackColor = Color.White;
            detailCard.Controls.Add(txtNursingNote);
            detailCard.Controls.Add(lblNursingNote);
            detailCard.Controls.Add(txtDiagnosis);
            detailCard.Controls.Add(lblDiagnosis);
            detailCard.Controls.Add(lblVitalInfo);
            detailCard.Controls.Add(lblVisitInfo);
            detailCard.Controls.Add(lblPatientInfo);
            detailCard.Controls.Add(lblDetailTitle);
            detailCard.Dock = DockStyle.Right;
            detailCard.Location = new Point(724, 18);
            detailCard.Name = "detailCard";
            detailCard.Size = new Size(400, 682);
            detailCard.TabIndex = 1;
            detailCard.Paint += Card_Paint;
            // 
            // lblDetailTitle
            // 
            lblDetailTitle.Dock = DockStyle.Top;
            lblDetailTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblDetailTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblDetailTitle.Location = new Point(0, 0);
            lblDetailTitle.Name = "lblDetailTitle";
            lblDetailTitle.Padding = new Padding(20, 14, 0, 0);
            lblDetailTitle.Size = new Size(400, 54);
            lblDetailTitle.TabIndex = 0;
            lblDetailTitle.Text = "Chi tiết chăm sóc";
            // 
            // lblPatientInfo
            // 
            lblPatientInfo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPatientInfo.ForeColor = Color.FromArgb(15, 23, 42);
            lblPatientInfo.Location = new Point(20, 66);
            lblPatientInfo.Name = "lblPatientInfo";
            lblPatientInfo.Size = new Size(360, 56);
            lblPatientInfo.TabIndex = 1;
            lblPatientInfo.Text = "Chọn hồ sơ để xem chi tiết";
            // 
            // lblVisitInfo
            // 
            lblVisitInfo.Font = new Font("Segoe UI", 9.5F);
            lblVisitInfo.ForeColor = Color.FromArgb(100, 116, 139);
            lblVisitInfo.Location = new Point(20, 126);
            lblVisitInfo.Name = "lblVisitInfo";
            lblVisitInfo.Size = new Size(360, 48);
            lblVisitInfo.TabIndex = 2;
            lblVisitInfo.Text = "Ngày khám: --";
            // 
            // lblVitalInfo
            // 
            lblVitalInfo.BackColor = Color.FromArgb(239, 246, 255);
            lblVitalInfo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblVitalInfo.ForeColor = Color.FromArgb(37, 99, 235);
            lblVitalInfo.Location = new Point(20, 186);
            lblVitalInfo.Name = "lblVitalInfo";
            lblVitalInfo.Padding = new Padding(12, 8, 12, 0);
            lblVitalInfo.Size = new Size(360, 82);
            lblVitalInfo.TabIndex = 3;
            lblVitalInfo.Text = "Sinh hiệu: chưa có";
            // 
            // txtDiagnosis
            // 
            txtDiagnosis.BackColor = Color.White;
            txtDiagnosis.BorderStyle = BorderStyle.FixedSingle;
            txtDiagnosis.Font = new Font("Segoe UI", 9.5F);
            txtDiagnosis.Location = new Point(20, 326);
            txtDiagnosis.Multiline = true;
            txtDiagnosis.Name = "txtDiagnosis";
            txtDiagnosis.ReadOnly = true;
            txtDiagnosis.Size = new Size(360, 106);
            txtDiagnosis.TabIndex = 5;
            // 
            // txtNursingNote
            // 
            txtNursingNote.BackColor = Color.White;
            txtNursingNote.BorderStyle = BorderStyle.FixedSingle;
            txtNursingNote.Font = new Font("Segoe UI", 9.5F);
            txtNursingNote.Location = new Point(20, 486);
            txtNursingNote.Multiline = true;
            txtNursingNote.Name = "txtNursingNote";
            txtNursingNote.ReadOnly = true;
            txtNursingNote.Size = new Size(360, 140);
            txtNursingNote.TabIndex = 7;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDiagnosis.ForeColor = Color.FromArgb(15, 23, 42);
            lblDiagnosis.Location = new Point(20, 296);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(240, 24);
            lblDiagnosis.TabIndex = 4;
            lblDiagnosis.Text = "Chẩn đoán";
            // 
            // lblNursingNote
            // 
            lblNursingNote.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNursingNote.ForeColor = Color.FromArgb(15, 23, 42);
            lblNursingNote.Location = new Point(20, 456);
            lblNursingNote.Name = "lblNursingNote";
            lblNursingNote.Size = new Size(240, 24);
            lblNursingNote.TabIndex = 6;
            lblNursingNote.Text = "Ghi chú điều dưỡng";
            // 
            // ucNurseMedicalRecords
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 252);
            Controls.Add(rootPanel);
            Name = "ucNurseMedicalRecords";
            Size = new Size(1180, 820);
            rootPanel.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            recordsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecords).EndInit();
            detailCard.ResumeLayout(false);
            detailCard.PerformLayout();
            ResumeLayout(false);
        }

        private Panel rootPanel;
        private Panel filterPanel;
        private TextBox txtSearch;
        private Button btnRefresh;
        private Panel contentPanel;
        private Panel recordsCard;
        private DataGridView dgvRecords;
        private DataGridViewTextBoxColumn colEncounter;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colVisit;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colVitals;
        private Label lblRecordsTitle;
        private Panel detailCard;
        private Label lblDetailTitle;
        private Label lblPatientInfo;
        private Label lblVisitInfo;
        private Label lblVitalInfo;
        private TextBox txtDiagnosis;
        private TextBox txtNursingNote;
        private Label lblDiagnosis;
        private Label lblNursingNote;
    }
}
