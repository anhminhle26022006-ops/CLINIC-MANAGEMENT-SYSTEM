using System.Drawing;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Pharmacy
{
    partial class ucPrescriptionDispense
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
            lblEmptyDetail = new Label();
            tableContent = new TableLayoutPanel();
            pnlQueueCard = new RoundedPanel();
            flpPrescriptions = new FlowLayoutPanel();
            queueCard01 = new ucPharmacyPrescriptionQueueCard();
            queueCard02 = new ucPharmacyPrescriptionQueueCard();
            queueCard03 = new ucPharmacyPrescriptionQueueCard();
            queueCard04 = new ucPharmacyPrescriptionQueueCard();
            queueCard05 = new ucPharmacyPrescriptionQueueCard();
            queueCard06 = new ucPharmacyPrescriptionQueueCard();
            queueCard07 = new ucPharmacyPrescriptionQueueCard();
            queueCard08 = new ucPharmacyPrescriptionQueueCard();
            lblQueueEmpty = new Label();
            lblQueueSubtitle = new Label();
            lblQueueTitle = new Label();
            pnlPrescriptionCard = new RoundedPanel();
            btnDispense = new Button();
            flpMedicineCards = new FlowLayoutPanel();
            medicineCard01 = new ucPharmacyMedicineItemCard();
            medicineCard02 = new ucPharmacyMedicineItemCard();
            medicineCard03 = new ucPharmacyMedicineItemCard();
            medicineCard04 = new ucPharmacyMedicineItemCard();
            medicineCard05 = new ucPharmacyMedicineItemCard();
            lblMoreMedicine = new Label();
            lblDrugListTitle = new Label();
            pnlDoctorNote = new RoundedPanel();
            lblNoteContent = new Label();
            lblNoteTitle = new Label();
            pnlWarnings = new RoundedPanel();
            lblChronic = new Label();
            lblAllergy = new Label();
            lblWarningTitle = new Label();
            pnlDiagnosis = new RoundedPanel();
            lblDiagnosis = new Label();
            lblDiagnosisTitle = new Label();
            pnlPrescriptionHeader = new Panel();
            lblStatus = new Label();
            lblTime = new Label();
            lblDate = new Label();
            lblDoctor = new Label();
            lblPrescriptionCode = new Label();
            lblPatientMeta = new Label();
            lblPatientName = new Label();
            lblAvatar = new Label();
            pnlFilters = new RoundedPanel();
            cboStatus = new ComboBox();
            txtPrescriptionSearch = new TextBox();
            lblFilterTitle = new Label();
            pnlStatsGrid = new TableLayoutPanel();
            pnlWaiting = new RoundedPanel();
            lblWaitingNumber = new Label();
            lblWaitingTitle = new Label();
            pnlPreparing = new RoundedPanel();
            lblPreparingNumber = new Label();
            lblPreparingTitle = new Label();
            pnlDone = new RoundedPanel();
            lblDoneNumber = new Label();
            lblDoneTitle = new Label();
            pnlTotal = new RoundedPanel();
            lblTotalNumber = new Label();
            lblTotalTitle = new Label();
            viewHostPanel.SuspendLayout();
            tableContent.SuspendLayout();
            pnlQueueCard.SuspendLayout();
            flpPrescriptions.SuspendLayout();
            pnlPrescriptionCard.SuspendLayout();
            flpMedicineCards.SuspendLayout();
            pnlDoctorNote.SuspendLayout();
            pnlWarnings.SuspendLayout();
            pnlDiagnosis.SuspendLayout();
            pnlPrescriptionHeader.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlWaiting.SuspendLayout();
            pnlPreparing.SuspendLayout();
            pnlDone.SuspendLayout();
            pnlTotal.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = false;
            viewHostPanel.BorderColor = Color.FromArgb(226, 232, 240);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(lblEmptyDetail);
            viewHostPanel.Controls.Add(tableContent);
            viewHostPanel.Controls.Add(pnlFilters);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.FromArgb(247, 249, 252);
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1422, 920);
            viewHostPanel.TabIndex = 0;
            // 
            // lblEmptyDetail
            // 
            lblEmptyDetail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblEmptyDetail.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblEmptyDetail.ForeColor = Color.FromArgb(100, 116, 139);
            lblEmptyDetail.Location = new Point(456, 340);
            lblEmptyDetail.Name = "lblEmptyDetail";
            lblEmptyDetail.Size = new Size(934, 80);
            lblEmptyDetail.TabIndex = 4;
            lblEmptyDetail.Text = "Chọn một toa trong danh sách để xem chi tiết cấp phát.";
            lblEmptyDetail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableContent
            // 
            tableContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableContent.ColumnCount = 2;
            tableContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 390F));
            tableContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableContent.Controls.Add(pnlQueueCard, 0, 0);
            tableContent.Controls.Add(pnlPrescriptionCard, 1, 0);
            tableContent.Location = new Point(24, 244);
            tableContent.Name = "tableContent";
            tableContent.RowCount = 1;
            tableContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableContent.Size = new Size(1366, 820);
            tableContent.TabIndex = 3;
            // 
            // pnlQueueCard
            // 
            pnlQueueCard.BorderColor = Color.FromArgb(226, 232, 240);
            pnlQueueCard.BorderWidth = 1;
            pnlQueueCard.Controls.Add(flpPrescriptions);
            pnlQueueCard.Controls.Add(lblQueueSubtitle);
            pnlQueueCard.Controls.Add(lblQueueTitle);
            pnlQueueCard.CornerRadius = 8;
            pnlQueueCard.Dock = DockStyle.Fill;
            pnlQueueCard.FillColor = Color.White;
            pnlQueueCard.Location = new Point(0, 0);
            pnlQueueCard.Margin = new Padding(0, 0, 18, 0);
            pnlQueueCard.Name = "pnlQueueCard";
            pnlQueueCard.Size = new Size(372, 820);
            pnlQueueCard.TabIndex = 0;
            // 
            // flpPrescriptions
            // 
            flpPrescriptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpPrescriptions.AutoScroll = true;
            flpPrescriptions.BackColor = Color.Transparent;
            flpPrescriptions.Controls.Add(queueCard01);
            flpPrescriptions.Controls.Add(queueCard02);
            flpPrescriptions.Controls.Add(queueCard03);
            flpPrescriptions.Controls.Add(queueCard04);
            flpPrescriptions.Controls.Add(queueCard05);
            flpPrescriptions.Controls.Add(queueCard06);
            flpPrescriptions.Controls.Add(queueCard07);
            flpPrescriptions.Controls.Add(queueCard08);
            flpPrescriptions.Controls.Add(lblQueueEmpty);
            flpPrescriptions.FlowDirection = FlowDirection.TopDown;
            flpPrescriptions.Location = new Point(14, 82);
            flpPrescriptions.Name = "flpPrescriptions";
            flpPrescriptions.Size = new Size(354, 794);
            flpPrescriptions.TabIndex = 2;
            flpPrescriptions.WrapContents = false;
            // 
            // queueCard01
            // 
            queueCard01.BackColor = Color.Transparent;
            queueCard01.Margin = new Padding(0, 0, 0, 12);
            queueCard01.Name = "queueCard01";
            queueCard01.Size = new Size(340, 104);
            queueCard01.TabIndex = 0;
            // 
            // queueCard02
            // 
            queueCard02.BackColor = Color.Transparent;
            queueCard02.Margin = new Padding(0, 0, 0, 12);
            queueCard02.Name = "queueCard02";
            queueCard02.Size = new Size(340, 104);
            queueCard02.TabIndex = 1;
            // 
            // queueCard03
            // 
            queueCard03.BackColor = Color.Transparent;
            queueCard03.Margin = new Padding(0, 0, 0, 12);
            queueCard03.Name = "queueCard03";
            queueCard03.Size = new Size(340, 104);
            queueCard03.TabIndex = 2;
            // 
            // queueCard04
            // 
            queueCard04.BackColor = Color.Transparent;
            queueCard04.Margin = new Padding(0, 0, 0, 12);
            queueCard04.Name = "queueCard04";
            queueCard04.Size = new Size(340, 104);
            queueCard04.TabIndex = 3;
            // 
            // queueCard05
            // 
            queueCard05.BackColor = Color.Transparent;
            queueCard05.Margin = new Padding(0, 0, 0, 12);
            queueCard05.Name = "queueCard05";
            queueCard05.Size = new Size(340, 104);
            queueCard05.TabIndex = 4;
            // 
            // queueCard06
            // 
            queueCard06.BackColor = Color.Transparent;
            queueCard06.Margin = new Padding(0, 0, 0, 12);
            queueCard06.Name = "queueCard06";
            queueCard06.Size = new Size(340, 104);
            queueCard06.TabIndex = 5;
            // 
            // queueCard07
            // 
            queueCard07.BackColor = Color.Transparent;
            queueCard07.Margin = new Padding(0, 0, 0, 12);
            queueCard07.Name = "queueCard07";
            queueCard07.Size = new Size(340, 104);
            queueCard07.TabIndex = 6;
            // 
            // queueCard08
            // 
            queueCard08.BackColor = Color.Transparent;
            queueCard08.Margin = new Padding(0, 0, 0, 12);
            queueCard08.Name = "queueCard08";
            queueCard08.Size = new Size(340, 104);
            queueCard08.TabIndex = 7;
            // 
            // lblQueueEmpty
            // 
            lblQueueEmpty.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblQueueEmpty.ForeColor = Color.FromArgb(100, 116, 139);
            lblQueueEmpty.Location = new Point(0, 0);
            lblQueueEmpty.Margin = new Padding(0);
            lblQueueEmpty.Name = "lblQueueEmpty";
            lblQueueEmpty.Size = new Size(340, 90);
            lblQueueEmpty.TabIndex = 8;
            lblQueueEmpty.Text = "Không có toa phù hợp.";
            lblQueueEmpty.TextAlign = ContentAlignment.MiddleCenter;
            lblQueueEmpty.Visible = false;
            // 
            // lblQueueSubtitle
            // 
            lblQueueSubtitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblQueueSubtitle.AutoEllipsis = true;
            lblQueueSubtitle.Font = new Font("Segoe UI", 9F);
            lblQueueSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblQueueSubtitle.Location = new Point(18, 43);
            lblQueueSubtitle.Name = "lblQueueSubtitle";
            lblQueueSubtitle.Size = new Size(336, 23);
            lblQueueSubtitle.TabIndex = 1;
            lblQueueSubtitle.Text = "Toa chờ cấp phát và đang chuẩn bị";
            lblQueueSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblQueueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblQueueTitle.Location = new Point(18, 14);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Size = new Size(336, 28);
            lblQueueTitle.TabIndex = 0;
            lblQueueTitle.Text = "Danh sách toa";
            lblQueueTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPrescriptionCard
            // 
            pnlPrescriptionCard.BorderColor = Color.FromArgb(226, 232, 240);
            pnlPrescriptionCard.BorderWidth = 1;
            pnlPrescriptionCard.Controls.Add(btnDispense);
            pnlPrescriptionCard.Controls.Add(flpMedicineCards);
            pnlPrescriptionCard.Controls.Add(lblDrugListTitle);
            pnlPrescriptionCard.Controls.Add(pnlDoctorNote);
            pnlPrescriptionCard.Controls.Add(pnlWarnings);
            pnlPrescriptionCard.Controls.Add(pnlDiagnosis);
            pnlPrescriptionCard.Controls.Add(pnlPrescriptionHeader);
            pnlPrescriptionCard.CornerRadius = 8;
            pnlPrescriptionCard.Dock = DockStyle.Fill;
            pnlPrescriptionCard.FillColor = Color.White;
            pnlPrescriptionCard.Location = new Point(390, 0);
            pnlPrescriptionCard.Margin = new Padding(0);
            pnlPrescriptionCard.Name = "pnlPrescriptionCard";
            pnlPrescriptionCard.Size = new Size(976, 820);
            pnlPrescriptionCard.TabIndex = 1;
            pnlPrescriptionCard.Visible = false;
            // 
            // btnDispense
            // 
            btnDispense.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnDispense.BackColor = Color.FromArgb(34, 197, 94);
            btnDispense.Cursor = Cursors.Hand;
            btnDispense.Enabled = false;
            btnDispense.FlatAppearance.BorderSize = 0;
            btnDispense.FlatStyle = FlatStyle.Flat;
            btnDispense.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDispense.ForeColor = Color.White;
            btnDispense.Location = new Point(22, 748);
            btnDispense.Name = "btnDispense";
            btnDispense.Size = new Size(930, 48);
            btnDispense.TabIndex = 6;
            btnDispense.Text = "Cấp phát thuốc";
            btnDispense.UseVisualStyleBackColor = false;
            // 
            // flpMedicineCards
            // 
            flpMedicineCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpMedicineCards.AutoScroll = true;
            flpMedicineCards.BackColor = Color.Transparent;
            flpMedicineCards.Controls.Add(medicineCard01);
            flpMedicineCards.Controls.Add(medicineCard02);
            flpMedicineCards.Controls.Add(medicineCard03);
            flpMedicineCards.Controls.Add(medicineCard04);
            flpMedicineCards.Controls.Add(medicineCard05);
            flpMedicineCards.Controls.Add(lblMoreMedicine);
            flpMedicineCards.FlowDirection = FlowDirection.TopDown;
            flpMedicineCards.Location = new Point(22, 456);
            flpMedicineCards.Name = "flpMedicineCards";
            flpMedicineCards.Size = new Size(930, 286);
            flpMedicineCards.TabIndex = 5;
            flpMedicineCards.WrapContents = false;
            // 
            // medicineCard01
            // 
            medicineCard01.BackColor = Color.Transparent;
            medicineCard01.Margin = new Padding(0, 0, 0, 12);
            medicineCard01.Name = "medicineCard01";
            medicineCard01.Size = new Size(900, 112);
            medicineCard01.TabIndex = 0;
            // 
            // medicineCard02
            // 
            medicineCard02.BackColor = Color.Transparent;
            medicineCard02.Margin = new Padding(0, 0, 0, 12);
            medicineCard02.Name = "medicineCard02";
            medicineCard02.Size = new Size(900, 112);
            medicineCard02.TabIndex = 1;
            // 
            // medicineCard03
            // 
            medicineCard03.BackColor = Color.Transparent;
            medicineCard03.Margin = new Padding(0, 0, 0, 12);
            medicineCard03.Name = "medicineCard03";
            medicineCard03.Size = new Size(900, 112);
            medicineCard03.TabIndex = 2;
            // 
            // medicineCard04
            // 
            medicineCard04.BackColor = Color.Transparent;
            medicineCard04.Margin = new Padding(0, 0, 0, 12);
            medicineCard04.Name = "medicineCard04";
            medicineCard04.Size = new Size(900, 112);
            medicineCard04.TabIndex = 3;
            // 
            // medicineCard05
            // 
            medicineCard05.BackColor = Color.Transparent;
            medicineCard05.Margin = new Padding(0, 0, 0, 12);
            medicineCard05.Name = "medicineCard05";
            medicineCard05.Size = new Size(900, 112);
            medicineCard05.TabIndex = 4;
            // 
            // lblMoreMedicine
            // 
            lblMoreMedicine.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblMoreMedicine.ForeColor = Color.FromArgb(47, 94, 240);
            lblMoreMedicine.Location = new Point(0, 0);
            lblMoreMedicine.Margin = new Padding(0);
            lblMoreMedicine.Name = "lblMoreMedicine";
            lblMoreMedicine.Size = new Size(900, 34);
            lblMoreMedicine.TabIndex = 5;
            lblMoreMedicine.Text = "Còn thuốc khác trong toa.";
            lblMoreMedicine.TextAlign = ContentAlignment.MiddleLeft;
            lblMoreMedicine.Visible = false;
            // 
            // lblDrugListTitle
            // 
            lblDrugListTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDrugListTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDrugListTitle.ForeColor = Color.FromArgb(47, 94, 240);
            lblDrugListTitle.Location = new Point(22, 420);
            lblDrugListTitle.Name = "lblDrugListTitle";
            lblDrugListTitle.Size = new Size(930, 30);
            lblDrugListTitle.TabIndex = 4;
            lblDrugListTitle.Text = "Danh sách thuốc kê toa";
            lblDrugListTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDoctorNote
            // 
            pnlDoctorNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDoctorNote.BorderColor = Color.FromArgb(226, 232, 240);
            pnlDoctorNote.BorderWidth = 1;
            pnlDoctorNote.Controls.Add(lblNoteContent);
            pnlDoctorNote.Controls.Add(lblNoteTitle);
            pnlDoctorNote.CornerRadius = 8;
            pnlDoctorNote.FillColor = Color.White;
            pnlDoctorNote.Location = new Point(22, 328);
            pnlDoctorNote.Name = "pnlDoctorNote";
            pnlDoctorNote.Size = new Size(930, 78);
            pnlDoctorNote.TabIndex = 3;
            // 
            // lblNoteContent
            // 
            lblNoteContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblNoteContent.AutoEllipsis = true;
            lblNoteContent.Font = new Font("Segoe UI", 9.5F);
            lblNoteContent.ForeColor = Color.FromArgb(55, 65, 81);
            lblNoteContent.Location = new Point(16, 38);
            lblNoteContent.Name = "lblNoteContent";
            lblNoteContent.Size = new Size(894, 24);
            lblNoteContent.TabIndex = 1;
            lblNoteContent.Text = "Không có lời dặn đặc biệt.";
            lblNoteContent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblNoteTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblNoteTitle.Location = new Point(16, 12);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(180, 22);
            lblNoteTitle.TabIndex = 0;
            lblNoteTitle.Text = "Lời dặn của bác sĩ";
            lblNoteTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlWarnings
            // 
            pnlWarnings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlWarnings.BorderColor = Color.FromArgb(254, 202, 202);
            pnlWarnings.BorderWidth = 1;
            pnlWarnings.Controls.Add(lblChronic);
            pnlWarnings.Controls.Add(lblAllergy);
            pnlWarnings.Controls.Add(lblWarningTitle);
            pnlWarnings.CornerRadius = 8;
            pnlWarnings.FillColor = Color.FromArgb(254, 242, 242);
            pnlWarnings.Location = new Point(22, 235);
            pnlWarnings.Name = "pnlWarnings";
            pnlWarnings.Size = new Size(930, 78);
            pnlWarnings.TabIndex = 2;
            // 
            // lblChronic
            // 
            lblChronic.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblChronic.AutoEllipsis = true;
            lblChronic.Font = new Font("Segoe UI", 9.5F);
            lblChronic.ForeColor = Color.FromArgb(55, 65, 81);
            lblChronic.Location = new Point(16, 49);
            lblChronic.Name = "lblChronic";
            lblChronic.Size = new Size(894, 22);
            lblChronic.TabIndex = 2;
            lblChronic.Text = "Tiền sử bệnh án: Không có bệnh nền nguy hiểm.";
            lblChronic.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAllergy
            // 
            lblAllergy.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblAllergy.AutoEllipsis = true;
            lblAllergy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAllergy.ForeColor = Color.FromArgb(220, 38, 38);
            lblAllergy.Location = new Point(16, 27);
            lblAllergy.Name = "lblAllergy";
            lblAllergy.Size = new Size(894, 22);
            lblAllergy.TabIndex = 1;
            lblAllergy.Text = "Dị ứng: Chưa cập nhật";
            lblAllergy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWarningTitle
            // 
            lblWarningTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWarningTitle.ForeColor = Color.FromArgb(127, 29, 29);
            lblWarningTitle.Location = new Point(16, 6);
            lblWarningTitle.Name = "lblWarningTitle";
            lblWarningTitle.Size = new Size(180, 22);
            lblWarningTitle.TabIndex = 0;
            lblWarningTitle.Text = "Thông tin an toàn";
            lblWarningTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDiagnosis
            // 
            pnlDiagnosis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDiagnosis.BorderColor = Color.FromArgb(226, 232, 240);
            pnlDiagnosis.BorderWidth = 1;
            pnlDiagnosis.Controls.Add(lblDiagnosis);
            pnlDiagnosis.Controls.Add(lblDiagnosisTitle);
            pnlDiagnosis.CornerRadius = 8;
            pnlDiagnosis.FillColor = Color.FromArgb(248, 250, 252);
            pnlDiagnosis.Location = new Point(22, 144);
            pnlDiagnosis.Name = "pnlDiagnosis";
            pnlDiagnosis.Size = new Size(930, 76);
            pnlDiagnosis.TabIndex = 1;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDiagnosis.AutoEllipsis = true;
            lblDiagnosis.Font = new Font("Segoe UI", 10.5F);
            lblDiagnosis.ForeColor = Color.FromArgb(17, 24, 39);
            lblDiagnosis.Location = new Point(16, 36);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(894, 25);
            lblDiagnosis.TabIndex = 1;
            lblDiagnosis.Text = "Chưa cập nhật chẩn đoán.";
            lblDiagnosis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDiagnosisTitle
            // 
            lblDiagnosisTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDiagnosisTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDiagnosisTitle.Location = new Point(16, 12);
            lblDiagnosisTitle.Name = "lblDiagnosisTitle";
            lblDiagnosisTitle.Size = new Size(180, 22);
            lblDiagnosisTitle.TabIndex = 0;
            lblDiagnosisTitle.Text = "Chẩn đoán";
            lblDiagnosisTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPrescriptionHeader
            // 
            pnlPrescriptionHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPrescriptionHeader.BackColor = Color.FromArgb(239, 246, 255);
            pnlPrescriptionHeader.Controls.Add(lblStatus);
            pnlPrescriptionHeader.Controls.Add(lblTime);
            pnlPrescriptionHeader.Controls.Add(lblDate);
            pnlPrescriptionHeader.Controls.Add(lblDoctor);
            pnlPrescriptionHeader.Controls.Add(lblPrescriptionCode);
            pnlPrescriptionHeader.Controls.Add(lblPatientMeta);
            pnlPrescriptionHeader.Controls.Add(lblPatientName);
            pnlPrescriptionHeader.Controls.Add(lblAvatar);
            pnlPrescriptionHeader.Location = new Point(1, 1);
            pnlPrescriptionHeader.Name = "pnlPrescriptionHeader";
            pnlPrescriptionHeader.Size = new Size(974, 116);
            pnlPrescriptionHeader.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblStatus.BackColor = Color.FromArgb(219, 234, 254);
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
            lblStatus.Location = new Point(787, 22);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(136, 30);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "Đang chuẩn bị";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTime.Font = new Font("Segoe UI", 9.5F);
            lblTime.ForeColor = Color.FromArgb(71, 85, 105);
            lblTime.Location = new Point(787, 78);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(136, 24);
            lblTime.TabIndex = 6;
            lblTime.Text = "11:30";
            lblTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.ForeColor = Color.FromArgb(71, 85, 105);
            lblDate.Location = new Point(787, 55);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(136, 24);
            lblDate.TabIndex = 5;
            lblDate.Text = "08/06/2026";
            lblDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoctor
            // 
            lblDoctor.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDoctor.AutoEllipsis = true;
            lblDoctor.Font = new Font("Segoe UI", 9.5F);
            lblDoctor.ForeColor = Color.FromArgb(71, 85, 105);
            lblDoctor.Location = new Point(580, 60);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(186, 24);
            lblDoctor.TabIndex = 4;
            lblDoctor.Text = "Bác sĩ kê toa: BS Trần Minh";
            lblDoctor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrescriptionCode
            // 
            lblPrescriptionCode.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPrescriptionCode.BackColor = Color.FromArgb(47, 94, 240);
            lblPrescriptionCode.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPrescriptionCode.ForeColor = Color.White;
            lblPrescriptionCode.Location = new Point(580, 22);
            lblPrescriptionCode.Name = "lblPrescriptionCode";
            lblPrescriptionCode.Size = new Size(186, 32);
            lblPrescriptionCode.TabIndex = 3;
            lblPrescriptionCode.Text = "TOA THUỐC #2";
            lblPrescriptionCode.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPatientMeta
            // 
            lblPatientMeta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientMeta.AutoEllipsis = true;
            lblPatientMeta.BackColor = Color.FromArgb(239, 246, 255);
            lblPatientMeta.Font = new Font("Segoe UI", 10F);
            lblPatientMeta.ForeColor = Color.FromArgb(71, 85, 105);
            lblPatientMeta.Location = new Point(100, 62);
            lblPatientMeta.Name = "lblPatientMeta";
            lblPatientMeta.Size = new Size(462, 25);
            lblPatientMeta.TabIndex = 2;
            lblPatientMeta.Text = "Nam - 26 tuổi - Mã BN: PT001";
            lblPatientMeta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPatientName
            // 
            lblPatientName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPatientName.AutoEllipsis = true;
            lblPatientName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPatientName.ForeColor = Color.FromArgb(17, 24, 39);
            lblPatientName.Location = new Point(100, 24);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(462, 34);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Nguyễn Văn A";
            lblPatientName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(47, 94, 240);
            lblAvatar.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(22, 22);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(62, 62);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "N";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlFilters
            // 
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.BorderColor = Color.FromArgb(226, 232, 240);
            pnlFilters.BorderWidth = 1;
            pnlFilters.Controls.Add(cboStatus);
            pnlFilters.Controls.Add(txtPrescriptionSearch);
            pnlFilters.Controls.Add(lblFilterTitle);
            pnlFilters.CornerRadius = 8;
            pnlFilters.FillColor = Color.White;
            pnlFilters.Location = new Point(24, 144);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1366, 76);
            pnlFilters.TabIndex = 1;
            // 
            // cboStatus
            // 
            cboStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ cấp phát", "Đang chuẩn bị" });
            cboStatus.Location = new Point(1032, 26);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(314, 31);
            cboStatus.TabIndex = 2;
            // 
            // txtPrescriptionSearch
            // 
            txtPrescriptionSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrescriptionSearch.BorderStyle = BorderStyle.FixedSingle;
            txtPrescriptionSearch.Font = new Font("Segoe UI", 10F);
            txtPrescriptionSearch.ForeColor = Color.FromArgb(148, 163, 184);
            txtPrescriptionSearch.Location = new Point(186, 26);
            txtPrescriptionSearch.Name = "txtPrescriptionSearch";
            txtPrescriptionSearch.Size = new Size(806, 30);
            txtPrescriptionSearch.TabIndex = 1;
            txtPrescriptionSearch.Text = "Tìm kiếm theo tên BN hoặc số toa...";
            // 
            // lblFilterTitle
            // 
            lblFilterTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFilterTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblFilterTitle.Location = new Point(18, 26);
            lblFilterTitle.Name = "lblFilterTitle";
            lblFilterTitle.Size = new Size(146, 30);
            lblFilterTitle.TabIndex = 0;
            lblFilterTitle.Text = "Lọc toa thuốc";
            lblFilterTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 4;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlStatsGrid.Controls.Add(pnlWaiting, 0, 0);
            pnlStatsGrid.Controls.Add(pnlPreparing, 1, 0);
            pnlStatsGrid.Controls.Add(pnlDone, 2, 0);
            pnlStatsGrid.Controls.Add(pnlTotal, 3, 0);
            pnlStatsGrid.Location = new Point(24, 24);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1366, 96);
            pnlStatsGrid.TabIndex = 0;
            // 
            // pnlWaiting
            // 
            pnlWaiting.BorderColor = Color.FromArgb(253, 230, 138);
            pnlWaiting.BorderWidth = 1;
            pnlWaiting.Controls.Add(lblWaitingNumber);
            pnlWaiting.Controls.Add(lblWaitingTitle);
            pnlWaiting.CornerRadius = 8;
            pnlWaiting.Dock = DockStyle.Fill;
            pnlWaiting.FillColor = Color.FromArgb(255, 251, 235);
            pnlWaiting.Location = new Point(0, 0);
            pnlWaiting.Margin = new Padding(0, 0, 14, 0);
            pnlWaiting.Name = "pnlWaiting";
            pnlWaiting.Size = new Size(327, 96);
            pnlWaiting.TabIndex = 0;
            // 
            // lblWaitingNumber
            // 
            lblWaitingNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWaitingNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblWaitingNumber.ForeColor = Color.FromArgb(180, 83, 9);
            lblWaitingNumber.Location = new Point(18, 40);
            lblWaitingNumber.Name = "lblWaitingNumber";
            lblWaitingNumber.Size = new Size(288, 42);
            lblWaitingNumber.TabIndex = 1;
            lblWaitingNumber.Text = "0";
            lblWaitingNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblWaitingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWaitingTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblWaitingTitle.Location = new Point(18, 16);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(288, 24);
            lblWaitingTitle.TabIndex = 0;
            lblWaitingTitle.Text = "Chờ cấp phát";
            lblWaitingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPreparing
            // 
            pnlPreparing.BorderColor = Color.FromArgb(191, 219, 254);
            pnlPreparing.BorderWidth = 1;
            pnlPreparing.Controls.Add(lblPreparingNumber);
            pnlPreparing.Controls.Add(lblPreparingTitle);
            pnlPreparing.CornerRadius = 8;
            pnlPreparing.Dock = DockStyle.Fill;
            pnlPreparing.FillColor = Color.FromArgb(239, 246, 255);
            pnlPreparing.Location = new Point(341, 0);
            pnlPreparing.Margin = new Padding(0, 0, 14, 0);
            pnlPreparing.Name = "pnlPreparing";
            pnlPreparing.Size = new Size(327, 96);
            pnlPreparing.TabIndex = 1;
            // 
            // lblPreparingNumber
            // 
            lblPreparingNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPreparingNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblPreparingNumber.ForeColor = Color.FromArgb(37, 99, 235);
            lblPreparingNumber.Location = new Point(18, 40);
            lblPreparingNumber.Name = "lblPreparingNumber";
            lblPreparingNumber.Size = new Size(288, 42);
            lblPreparingNumber.TabIndex = 1;
            lblPreparingNumber.Text = "0";
            lblPreparingNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPreparingTitle
            // 
            lblPreparingTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPreparingTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPreparingTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblPreparingTitle.Location = new Point(18, 16);
            lblPreparingTitle.Name = "lblPreparingTitle";
            lblPreparingTitle.Size = new Size(288, 24);
            lblPreparingTitle.TabIndex = 0;
            lblPreparingTitle.Text = "Đang chuẩn bị cấp phát";
            lblPreparingTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDone
            // 
            pnlDone.BorderColor = Color.FromArgb(187, 247, 208);
            pnlDone.BorderWidth = 1;
            pnlDone.Controls.Add(lblDoneNumber);
            pnlDone.Controls.Add(lblDoneTitle);
            pnlDone.CornerRadius = 8;
            pnlDone.Dock = DockStyle.Fill;
            pnlDone.FillColor = Color.FromArgb(240, 253, 244);
            pnlDone.Location = new Point(682, 0);
            pnlDone.Margin = new Padding(0, 0, 14, 0);
            pnlDone.Name = "pnlDone";
            pnlDone.Size = new Size(327, 96);
            pnlDone.TabIndex = 2;
            // 
            // lblDoneNumber
            // 
            lblDoneNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDoneNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDoneNumber.ForeColor = Color.FromArgb(22, 101, 52);
            lblDoneNumber.Location = new Point(18, 40);
            lblDoneNumber.Name = "lblDoneNumber";
            lblDoneNumber.Size = new Size(288, 42);
            lblDoneNumber.TabIndex = 1;
            lblDoneNumber.Text = "0";
            lblDoneNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDoneTitle
            // 
            lblDoneTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDoneTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDoneTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblDoneTitle.Location = new Point(18, 16);
            lblDoneTitle.Name = "lblDoneTitle";
            lblDoneTitle.Size = new Size(288, 24);
            lblDoneTitle.TabIndex = 0;
            lblDoneTitle.Text = "Đã cấp phát hôm nay";
            lblDoneTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTotal
            // 
            pnlTotal.BorderColor = Color.FromArgb(226, 232, 240);
            pnlTotal.BorderWidth = 1;
            pnlTotal.Controls.Add(lblTotalNumber);
            pnlTotal.Controls.Add(lblTotalTitle);
            pnlTotal.CornerRadius = 8;
            pnlTotal.Dock = DockStyle.Fill;
            pnlTotal.FillColor = Color.White;
            pnlTotal.Location = new Point(1023, 0);
            pnlTotal.Margin = new Padding(0);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(343, 96);
            pnlTotal.TabIndex = 3;
            // 
            // lblTotalNumber
            // 
            lblTotalNumber.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalNumber.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalNumber.ForeColor = Color.FromArgb(17, 24, 39);
            lblTotalNumber.Location = new Point(18, 40);
            lblTotalNumber.Name = "lblTotalNumber";
            lblTotalNumber.Size = new Size(306, 42);
            lblTotalNumber.TabIndex = 1;
            lblTotalNumber.Text = "0";
            lblTotalNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTotalTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalTitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblTotalTitle.Location = new Point(18, 16);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(306, 24);
            lblTotalTitle.TabIndex = 0;
            lblTotalTitle.Text = "Tổng toa xử lý";
            lblTotalTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ucPrescriptionDispense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Name = "ucPrescriptionDispense";
            Size = new Size(1422, 920);
            Load += ucPrescriptionDispense_Load;
            Resize += ucPrescriptionDispense_Resize;
            viewHostPanel.ResumeLayout(false);
            tableContent.ResumeLayout(false);
            pnlQueueCard.ResumeLayout(false);
            flpPrescriptions.ResumeLayout(false);
            pnlPrescriptionCard.ResumeLayout(false);
            flpMedicineCards.ResumeLayout(false);
            pnlDoctorNote.ResumeLayout(false);
            pnlWarnings.ResumeLayout(false);
            pnlDiagnosis.ResumeLayout(false);
            pnlPrescriptionHeader.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlStatsGrid.ResumeLayout(false);
            pnlWaiting.ResumeLayout(false);
            pnlPreparing.ResumeLayout(false);
            pnlDone.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
            ResumeLayout(false);
            ApplyPrescriptionVisualPolish();
            AdjustPrescriptionLayout();
        }

        private void ApplyPrescriptionVisualPolish()
        {
            Color page = Color.FromArgb(247, 249, 252);
            Color white = Color.White;
            Color blueHeader = Color.FromArgb(239, 246, 255);
            Color diagnosisBack = Color.FromArgb(248, 250, 252);

            BackColor = page;
            viewHostPanel.BackColor = page;
            pnlStatsGrid.BackColor = page;
            tableContent.BackColor = page;
            pnlQueueCard.BackColor = white;
            pnlPrescriptionCard.BackColor = white;
            pnlFilters.BackColor = white;

            lblFilterTitle.BackColor = white;
            txtPrescriptionSearch.BackColor = white;
            cboStatus.BackColor = white;
            lblQueueTitle.BackColor = white;
            lblQueueSubtitle.BackColor = white;
            lblQueueEmpty.BackColor = white;
            lblEmptyDetail.BackColor = page;

            lblPatientName.BackColor = blueHeader;
            lblPatientMeta.BackColor = blueHeader;
            lblDoctor.BackColor = blueHeader;
            lblDate.BackColor = blueHeader;
            lblTime.BackColor = blueHeader;

            lblDiagnosisTitle.BackColor = diagnosisBack;
            lblDiagnosis.BackColor = diagnosisBack;
            lblNoteTitle.BackColor = white;
            lblNoteContent.BackColor = white;
            lblDrugListTitle.BackColor = white;
            lblMoreMedicine.BackColor = white;

            ApplyStatLabelBackColor(pnlWaiting, lblWaitingTitle, lblWaitingNumber);
            ApplyStatLabelBackColor(pnlPreparing, lblPreparingTitle, lblPreparingNumber);
            ApplyStatLabelBackColor(pnlDone, lblDoneTitle, lblDoneNumber);
            ApplyStatLabelBackColor(pnlTotal, lblTotalTitle, lblTotalNumber);
        }

        private void ApplyStatLabelBackColor(RoundedPanel panel, Label title, Label number)
        {
            title.BackColor = panel.FillColor;
            number.BackColor = panel.FillColor;
            title.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            number.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
        }

        private void ucPrescriptionDispense_Resize(object sender, System.EventArgs e)
        {
            AdjustPrescriptionLayout();
        }

        private void AdjustPrescriptionLayout()
        {
            if (viewHostPanel == null || viewHostPanel.ClientSize.Width <= 0 || viewHostPanel.ClientSize.Height <= 0)
            {
                return;
            }

            int pad = 16;
            int width = System.Math.Max(900, viewHostPanel.ClientSize.Width - pad * 2);
            int statsHeight = 78;
            int filtersHeight = 58;
            int gap = 14;

            pnlStatsGrid.Location = new Point(pad, pad);
            pnlStatsGrid.Size = new Size(width, statsHeight);

            pnlFilters.Location = new Point(pad, pnlStatsGrid.Bottom + gap);
            pnlFilters.Size = new Size(width, filtersHeight);
            lblFilterTitle.Location = new Point(18, 17);
            lblFilterTitle.Size = new Size(150, 30);
            txtPrescriptionSearch.Location = new Point(176, 17);
            txtPrescriptionSearch.Size = new Size(System.Math.Max(320, width - 520), 30);
            cboStatus.Location = new Point(width - 328, 17);
            cboStatus.Size = new Size(306, 31);

            int contentTop = pnlFilters.Bottom + gap;
            int contentHeight = System.Math.Max(500, viewHostPanel.ClientSize.Height - contentTop - pad);
            tableContent.Location = new Point(pad, contentTop);
            tableContent.Size = new Size(width, contentHeight);
            tableContent.ColumnStyles[0].Width = System.Math.Min(370, System.Math.Max(330, width / 4));

            lblEmptyDetail.Location = new Point(tableContent.Left + (int)tableContent.ColumnStyles[0].Width + 18, contentTop);
            lblEmptyDetail.Size = new Size(System.Math.Max(300, width - (int)tableContent.ColumnStyles[0].Width - 18), contentHeight);

            AdjustQueuePanelLayout();
            AdjustDetailPanelLayout();
        }

        private void AdjustQueuePanelLayout()
        {
            if (pnlQueueCard.ClientSize.Width <= 0 || pnlQueueCard.ClientSize.Height <= 0)
            {
                return;
            }

            int innerPad = 14;
            lblQueueTitle.Location = new Point(18, 12);
            lblQueueTitle.Size = new Size(System.Math.Max(180, pnlQueueCard.ClientSize.Width - 36), 28);
            lblQueueSubtitle.Location = new Point(18, 40);
            lblQueueSubtitle.Size = new Size(System.Math.Max(180, pnlQueueCard.ClientSize.Width - 36), 22);
            flpPrescriptions.Location = new Point(innerPad, 68);
            flpPrescriptions.Size = new Size(
                System.Math.Max(260, pnlQueueCard.ClientSize.Width - innerPad * 2),
                System.Math.Max(180, pnlQueueCard.ClientSize.Height - 80));

            int cardWidth = System.Math.Max(260, flpPrescriptions.ClientSize.Width - 6);
            foreach (var card in QueueCards)
            {
                card.Width = cardWidth;
                card.Height = 104;
            }

            lblQueueEmpty.Size = new Size(cardWidth, 90);
        }

        private void AdjustDetailPanelLayout()
        {
            if (pnlPrescriptionCard.ClientSize.Width <= 0 || pnlPrescriptionCard.ClientSize.Height <= 0)
            {
                return;
            }

            int w = pnlPrescriptionCard.ClientSize.Width;
            int h = pnlPrescriptionCard.ClientSize.Height;
            int pad = 20;

            pnlPrescriptionHeader.Location = new Point(1, 1);
            pnlPrescriptionHeader.Size = new Size(System.Math.Max(620, w - 2), 92);
            lblAvatar.Location = new Point(22, 18);
            lblAvatar.Size = new Size(54, 54);
            lblPatientName.Location = new Point(96, 16);
            lblPatientMeta.Location = new Point(96, 50);

            int rightArea = System.Math.Min(430, System.Math.Max(320, w / 3));
            int rx = System.Math.Max(430, w - rightArea - 26);
            lblPatientName.Size = new Size(System.Math.Max(260, rx - 116), 32);
            lblPatientMeta.Size = new Size(System.Math.Max(260, rx - 116), 25);
            lblPrescriptionCode.Location = new Point(rx, 18);
            lblPrescriptionCode.Size = new Size(190, 30);
            lblDoctor.Location = new Point(rx, 52);
            lblDoctor.Size = new Size(190, 24);
            lblStatus.Location = new Point(w - 166, 18);
            lblStatus.Size = new Size(136, 30);
            lblDate.Location = new Point(w - 166, 50);
            lblDate.Size = new Size(136, 23);
            lblTime.Location = new Point(w - 166, 70);
            lblTime.Size = new Size(136, 22);

            int infoW = System.Math.Max(520, w - pad * 2);
            pnlDiagnosis.Location = new Point(pad, 110);
            pnlDiagnosis.Size = new Size(infoW, 56);
            lblDiagnosis.Location = new Point(16, 30);
            lblDiagnosis.Size = new Size(System.Math.Max(300, pnlDiagnosis.ClientSize.Width - 32), 22);

            pnlWarnings.Location = new Point(pad, 176);
            pnlWarnings.Size = new Size(infoW, 64);
            lblAllergy.Size = new Size(System.Math.Max(300, pnlWarnings.ClientSize.Width - 32), 22);
            lblChronic.Size = new Size(System.Math.Max(300, pnlWarnings.ClientSize.Width - 32), 22);

            pnlDoctorNote.Location = new Point(pad, 250);
            pnlDoctorNote.Size = new Size(infoW, 58);
            lblNoteContent.Location = new Point(16, 34);
            lblNoteContent.Size = new Size(System.Math.Max(300, pnlDoctorNote.ClientSize.Width - 32), 22);

            lblDrugListTitle.Location = new Point(pad, 318);
            lblDrugListTitle.Size = new Size(infoW, 28);

            int buttonHeight = 46;
            btnDispense.Location = new Point(pad, System.Math.Max(392, h - buttonHeight - 18));
            btnDispense.Size = new Size(infoW, buttonHeight);

            int medicineTop = 350;
            int medicineBottom = btnDispense.Top - 12;
            flpMedicineCards.Location = new Point(pad, medicineTop);
            flpMedicineCards.Size = new Size(infoW, System.Math.Max(110, medicineBottom - medicineTop));

            int medicineWidth = System.Math.Max(520, flpMedicineCards.ClientSize.Width - 8);
            foreach (var card in MedicineCards)
            {
                card.Width = medicineWidth;
                card.Height = 96;
            }

            lblMoreMedicine.Size = new Size(medicineWidth, 30);
        }

        private ucPharmacyPrescriptionQueueCard[] QueueCards => new[]
        {
            queueCard01,
            queueCard02,
            queueCard03,
            queueCard04,
            queueCard05,
            queueCard06,
            queueCard07,
            queueCard08
        };

        private ucPharmacyMedicineItemCard[] MedicineCards => new[]
        {
            medicineCard01,
            medicineCard02,
            medicineCard03,
            medicineCard04,
            medicineCard05
        };

        private void SetSearchActiveState()
        {
            txtPrescriptionSearch.ForeColor = Color.FromArgb(17, 24, 39);
        }

        private void SetSearchPlaceholderState()
        {
            txtPrescriptionSearch.ForeColor = Color.FromArgb(148, 163, 184);
        }

        private void SetQueueState(int totalCount, int visibleCount)
        {
            lblQueueEmpty.Visible = totalCount == 0;
            lblQueueSubtitle.Text = totalCount <= visibleCount
                ? totalCount + " toa phù hợp"
                : "Hiển thị " + visibleCount + "/" + totalCount + " toa phù hợp";
        }

        private void SetSelectedQueueCard(int prescriptionId)
        {
            foreach (var card in QueueCards)
            {
                card.SetSelected(card.Visible && card.PrescriptionId == prescriptionId);
            }
        }

        private void SetDetailStatus(string status)
        {
            bool waiting = status == "Chờ cấp phát" || status == "Pending";
            bool completed = status == "Đã cấp phát" || status == "Completed" || status == "Dispensed";

            if (completed)
            {
                lblStatus.Text = "Đã cấp phát";
                lblStatus.BackColor = Color.FromArgb(220, 252, 231);
                lblStatus.ForeColor = Color.FromArgb(22, 101, 52);
                return;
            }

            if (waiting)
            {
                lblStatus.Text = "Chờ cấp phát";
                lblStatus.BackColor = Color.FromArgb(254, 249, 195);
                lblStatus.ForeColor = Color.FromArgb(161, 98, 7);
                return;
            }

            lblStatus.Text = "Đang chuẩn bị";
            lblStatus.BackColor = Color.FromArgb(219, 234, 254);
            lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
        }

        private void SetWarningState(bool hasAllergy)
        {
            if (hasAllergy)
            {
                pnlWarnings.FillColor = Color.FromArgb(254, 242, 242);
                pnlWarnings.BackColor = Color.FromArgb(254, 242, 242);
                pnlWarnings.BorderColor = Color.FromArgb(254, 202, 202);
                lblWarningTitle.ForeColor = Color.FromArgb(127, 29, 29);
                lblAllergy.ForeColor = Color.FromArgb(220, 38, 38);
                lblWarningTitle.BackColor = Color.FromArgb(254, 242, 242);
                lblAllergy.BackColor = Color.FromArgb(254, 242, 242);
                lblChronic.BackColor = Color.FromArgb(254, 242, 242);
                pnlWarnings.Invalidate();
                return;
            }

            pnlWarnings.FillColor = Color.FromArgb(248, 250, 252);
            pnlWarnings.BackColor = Color.FromArgb(248, 250, 252);
            pnlWarnings.BorderColor = Color.FromArgb(226, 232, 240);
            lblWarningTitle.ForeColor = Color.FromArgb(71, 85, 105);
            lblAllergy.ForeColor = Color.FromArgb(22, 101, 52);
            lblWarningTitle.BackColor = Color.FromArgb(248, 250, 252);
            lblAllergy.BackColor = Color.FromArgb(248, 250, 252);
            lblChronic.BackColor = Color.FromArgb(248, 250, 252);
            pnlWarnings.Invalidate();
        }

        private void SetMedicineListState(int totalCount, int visibleCount)
        {
            lblDrugListTitle.Text = "Danh sách thuốc kê toa (" + totalCount + ")";
            lblMoreMedicine.Visible = totalCount > visibleCount;
            lblMoreMedicine.Text = totalCount > visibleCount
                ? "Còn " + (totalCount - visibleCount) + " thuốc khác trong toa."
                : string.Empty;
            AdjustDetailPanelLayout();
        }

        private RoundedPanel viewHostPanel;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlWaiting;
        private Label lblWaitingNumber;
        private Label lblWaitingTitle;
        private RoundedPanel pnlPreparing;
        private Label lblPreparingNumber;
        private Label lblPreparingTitle;
        private RoundedPanel pnlDone;
        private Label lblDoneNumber;
        private Label lblDoneTitle;
        private RoundedPanel pnlTotal;
        private Label lblTotalNumber;
        private Label lblTotalTitle;
        private RoundedPanel pnlFilters;
        private Label lblFilterTitle;
        private TextBox txtPrescriptionSearch;
        private ComboBox cboStatus;
        private TableLayoutPanel tableContent;
        private RoundedPanel pnlQueueCard;
        private Label lblQueueTitle;
        private Label lblQueueSubtitle;
        private FlowLayoutPanel flpPrescriptions;
        private ucPharmacyPrescriptionQueueCard queueCard01;
        private ucPharmacyPrescriptionQueueCard queueCard02;
        private ucPharmacyPrescriptionQueueCard queueCard03;
        private ucPharmacyPrescriptionQueueCard queueCard04;
        private ucPharmacyPrescriptionQueueCard queueCard05;
        private ucPharmacyPrescriptionQueueCard queueCard06;
        private ucPharmacyPrescriptionQueueCard queueCard07;
        private ucPharmacyPrescriptionQueueCard queueCard08;
        private Label lblQueueEmpty;
        private RoundedPanel pnlPrescriptionCard;
        private Panel pnlPrescriptionHeader;
        private Label lblAvatar;
        private Label lblPatientName;
        private Label lblPatientMeta;
        private Label lblPrescriptionCode;
        private Label lblDoctor;
        private Label lblDate;
        private Label lblTime;
        private Label lblStatus;
        private RoundedPanel pnlDiagnosis;
        private Label lblDiagnosisTitle;
        private Label lblDiagnosis;
        private RoundedPanel pnlWarnings;
        private Label lblWarningTitle;
        private Label lblAllergy;
        private Label lblChronic;
        private RoundedPanel pnlDoctorNote;
        private Label lblNoteTitle;
        private Label lblNoteContent;
        private Label lblDrugListTitle;
        private FlowLayoutPanel flpMedicineCards;
        private ucPharmacyMedicineItemCard medicineCard01;
        private ucPharmacyMedicineItemCard medicineCard02;
        private ucPharmacyMedicineItemCard medicineCard03;
        private ucPharmacyMedicineItemCard medicineCard04;
        private ucPharmacyMedicineItemCard medicineCard05;
        private Label lblMoreMedicine;
        private Button btnDispense;
        private Label lblEmptyDetail;
    }
}
