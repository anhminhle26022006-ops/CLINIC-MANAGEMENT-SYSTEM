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
            pnlPrescriptionCard = new RoundedPanel();
            btnDispense = new Button();
            pnlDoctorNote = new RoundedPanel();
            lblNoteContent = new Label();
            lblNoteTitle = new Label();
            pnlDrugThree = new RoundedPanel();
            pnlDrugTwo = new RoundedPanel();
            pnlDrugOne = new RoundedPanel();
            lblDrugListTitle = new Label();
            pnlWarnings = new RoundedPanel();
            lblChronic = new Label();
            lblAllergy = new Label();
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
            pnlStatsGrid = new TableLayoutPanel();
            pnlWaiting = new RoundedPanel();
            lblWaitingIcon = new Label();
            lblWaitingNumber = new Label();
            lblWaitingTitle = new Label();
            pnlDone = new RoundedPanel();
            lblDoneIcon = new Label();
            lblDoneNumber = new Label();
            lblDoneTitle = new Label();
            pnlTotal = new RoundedPanel();
            lblTotalIcon = new Label();
            lblTotalNumber = new Label();
            lblTotalTitle = new Label();
            lblDrugOneTitle = new Label();
            lblDrugOneLeft = new Label();
            lblDrugOneRight = new Label();
            lblDrugTwoTitle = new Label();
            lblDrugTwoLeft = new Label();
            lblDrugTwoRight = new Label();
            lblDrugThreeTitle = new Label();
            lblDrugThreeLeft = new Label();
            lblDrugThreeRight = new Label();
            viewHostPanel.SuspendLayout();
            pnlPrescriptionCard.SuspendLayout();
            pnlDoctorNote.SuspendLayout();
            pnlWarnings.SuspendLayout();
            pnlPrescriptionHeader.SuspendLayout();
            pnlFilters.SuspendLayout();
            pnlStatsGrid.SuspendLayout();
            pnlWaiting.SuspendLayout();
            pnlDone.SuspendLayout();
            pnlTotal.SuspendLayout();
            SuspendLayout();
            // 
            // viewHostPanel
            // 
            viewHostPanel.AutoScroll = true;
            viewHostPanel.BorderColor = Color.FromArgb(229, 231, 235);
            viewHostPanel.BorderWidth = 1;
            viewHostPanel.Controls.Add(pnlPrescriptionCard);
            viewHostPanel.Controls.Add(pnlFilters);
            viewHostPanel.Controls.Add(pnlStatsGrid);
            viewHostPanel.CornerRadius = 8;
            viewHostPanel.Dock = DockStyle.Fill;
            viewHostPanel.FillColor = Color.White;
            viewHostPanel.Location = new Point(0, 0);
            viewHostPanel.Margin = new Padding(3, 4, 3, 4);
            viewHostPanel.Name = "viewHostPanel";
            viewHostPanel.Size = new Size(1422, 1333);
            viewHostPanel.TabIndex = 0;
            // 
            // pnlPrescriptionCard
            // 
            pnlPrescriptionCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPrescriptionCard.BorderColor = Color.FromArgb(229, 231, 235);
            pnlPrescriptionCard.BorderWidth = 1;
            pnlPrescriptionCard.Controls.Add(btnDispense);
            pnlPrescriptionCard.Controls.Add(pnlDoctorNote);
            pnlPrescriptionCard.Controls.Add(pnlDrugThree);
            pnlPrescriptionCard.Controls.Add(pnlDrugTwo);
            pnlPrescriptionCard.Controls.Add(pnlDrugOne);
            pnlPrescriptionCard.Controls.Add(lblDrugListTitle);
            pnlPrescriptionCard.Controls.Add(pnlWarnings);
            pnlPrescriptionCard.Controls.Add(lblDiagnosis);
            pnlPrescriptionCard.Controls.Add(lblDiagnosisTitle);
            pnlPrescriptionCard.Controls.Add(pnlPrescriptionHeader);
            pnlPrescriptionCard.CornerRadius = 8;
            pnlPrescriptionCard.FillColor = Color.White;
            pnlPrescriptionCard.Location = new Point(27, 360);
            pnlPrescriptionCard.Margin = new Padding(3, 4, 3, 4);
            pnlPrescriptionCard.Name = "pnlPrescriptionCard";
            pnlPrescriptionCard.Size = new Size(1367, 1067);
            pnlPrescriptionCard.TabIndex = 0;
            // 
            // btnDispense
            // 
            btnDispense.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnDispense.BackColor = Color.FromArgb(52, 168, 83);
            btnDispense.Cursor = Cursors.Hand;
            btnDispense.FlatAppearance.BorderSize = 0;
            btnDispense.FlatStyle = FlatStyle.Flat;
            btnDispense.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDispense.ForeColor = Color.White;
            btnDispense.Location = new Point(25, 965);
            btnDispense.Margin = new Padding(3, 4, 3, 4);
            btnDispense.Name = "btnDispense";
            btnDispense.Size = new Size(1317, 64);
            btnDispense.TabIndex = 0;
            btnDispense.Text = "✓  Cấp phát thuốc";
            btnDispense.UseVisualStyleBackColor = false;
            // 
            // pnlDoctorNote
            // 
            pnlDoctorNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDoctorNote.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDoctorNote.BorderWidth = 1;
            pnlDoctorNote.Controls.Add(lblNoteContent);
            pnlDoctorNote.Controls.Add(lblNoteTitle);
            pnlDoctorNote.CornerRadius = 8;
            pnlDoctorNote.FillColor = Color.White;
            pnlDoctorNote.Location = new Point(25, 851);
            pnlDoctorNote.Margin = new Padding(3, 4, 3, 4);
            pnlDoctorNote.Name = "pnlDoctorNote";
            pnlDoctorNote.Size = new Size(1317, 93);
            pnlDoctorNote.TabIndex = 1;
            // 
            // lblNoteContent
            // 
            lblNoteContent.Location = new Point(0, 0);
            lblNoteContent.Name = "lblNoteContent";
            lblNoteContent.Size = new Size(114, 31);
            lblNoteContent.TabIndex = 0;
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.Location = new Point(0, 0);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(114, 31);
            lblNoteTitle.TabIndex = 1;
            // 
            // pnlDrugThree
            // 
            pnlDrugThree.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDrugThree.BorderWidth = 1;
            pnlDrugThree.CornerRadius = 8;
            pnlDrugThree.FillColor = Color.White;
            pnlDrugThree.Location = new Point(0, 0);
            pnlDrugThree.Margin = new Padding(3, 4, 3, 4);
            pnlDrugThree.Name = "pnlDrugThree";
            pnlDrugThree.Size = new Size(229, 133);
            pnlDrugThree.TabIndex = 2;
            // 
            // pnlDrugTwo
            // 
            pnlDrugTwo.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDrugTwo.BorderWidth = 1;
            pnlDrugTwo.CornerRadius = 8;
            pnlDrugTwo.FillColor = Color.White;
            pnlDrugTwo.Location = new Point(0, 0);
            pnlDrugTwo.Margin = new Padding(3, 4, 3, 4);
            pnlDrugTwo.Name = "pnlDrugTwo";
            pnlDrugTwo.Size = new Size(229, 133);
            pnlDrugTwo.TabIndex = 3;
            // 
            // pnlDrugOne
            // 
            pnlDrugOne.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDrugOne.BorderWidth = 1;
            pnlDrugOne.CornerRadius = 8;
            pnlDrugOne.FillColor = Color.White;
            pnlDrugOne.Location = new Point(0, 0);
            pnlDrugOne.Margin = new Padding(3, 4, 3, 4);
            pnlDrugOne.Name = "pnlDrugOne";
            pnlDrugOne.Size = new Size(229, 133);
            pnlDrugOne.TabIndex = 4;
            // 
            // lblDrugListTitle
            // 
            lblDrugListTitle.Location = new Point(0, 0);
            lblDrugListTitle.Name = "lblDrugListTitle";
            lblDrugListTitle.Size = new Size(114, 31);
            lblDrugListTitle.TabIndex = 5;
            // 
            // pnlWarnings
            // 
            pnlWarnings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlWarnings.BorderColor = Color.FromArgb(229, 231, 235);
            pnlWarnings.BorderWidth = 1;
            pnlWarnings.Controls.Add(lblChronic);
            pnlWarnings.Controls.Add(lblAllergy);
            pnlWarnings.CornerRadius = 8;
            pnlWarnings.FillColor = Color.White;
            pnlWarnings.Location = new Point(25, 259);
            pnlWarnings.Margin = new Padding(3, 4, 3, 4);
            pnlWarnings.Name = "pnlWarnings";
            pnlWarnings.Size = new Size(1317, 93);
            pnlWarnings.TabIndex = 6;
            // 
            // lblChronic
            // 
            lblChronic.Location = new Point(0, 0);
            lblChronic.Name = "lblChronic";
            lblChronic.Size = new Size(114, 31);
            lblChronic.TabIndex = 0;
            // 
            // lblAllergy
            // 
            lblAllergy.Location = new Point(0, 0);
            lblAllergy.Name = "lblAllergy";
            lblAllergy.Size = new Size(114, 31);
            lblAllergy.TabIndex = 1;
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.Location = new Point(0, 0);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(114, 31);
            lblDiagnosis.TabIndex = 7;
            // 
            // lblDiagnosisTitle
            // 
            lblDiagnosisTitle.Location = new Point(0, 0);
            lblDiagnosisTitle.Name = "lblDiagnosisTitle";
            lblDiagnosisTitle.Size = new Size(114, 31);
            lblDiagnosisTitle.TabIndex = 8;
            // 
            // pnlPrescriptionHeader
            // 
            pnlPrescriptionHeader.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlPrescriptionHeader.BackColor = Color.FromArgb(219, 234, 254);
            pnlPrescriptionHeader.Controls.Add(lblStatus);
            pnlPrescriptionHeader.Controls.Add(lblTime);
            pnlPrescriptionHeader.Controls.Add(lblDate);
            pnlPrescriptionHeader.Controls.Add(lblDoctor);
            pnlPrescriptionHeader.Controls.Add(lblPrescriptionCode);
            pnlPrescriptionHeader.Controls.Add(lblPatientMeta);
            pnlPrescriptionHeader.Controls.Add(lblPatientName);
            pnlPrescriptionHeader.Controls.Add(lblAvatar);
            pnlPrescriptionHeader.Location = new Point(0, 0);
            pnlPrescriptionHeader.Margin = new Padding(3, 4, 3, 4);
            pnlPrescriptionHeader.Name = "pnlPrescriptionHeader";
            pnlPrescriptionHeader.Size = new Size(1367, 123);
            pnlPrescriptionHeader.TabIndex = 9;
            // 
            // lblStatus
            // 
            lblStatus.BackColor = Color.FromArgb(254, 249, 195);
            lblStatus.Location = new Point(0, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(114, 31);
            lblStatus.TabIndex = 0;
            // 
            // lblTime
            // 
            lblTime.Location = new Point(0, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(114, 31);
            lblTime.TabIndex = 1;
            // 
            // lblDate
            // 
            lblDate.Location = new Point(0, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(114, 31);
            lblDate.TabIndex = 2;
            // 
            // lblDoctor
            // 
            lblDoctor.Location = new Point(0, 0);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(114, 31);
            lblDoctor.TabIndex = 3;
            // 
            // lblPrescriptionCode
            // 
            lblPrescriptionCode.BackColor = Color.FromArgb(47, 94, 240);
            lblPrescriptionCode.Location = new Point(0, 0);
            lblPrescriptionCode.Name = "lblPrescriptionCode";
            lblPrescriptionCode.Size = new Size(114, 31);
            lblPrescriptionCode.TabIndex = 4;
            // 
            // lblPatientMeta
            // 
            lblPatientMeta.BackColor = Color.FromArgb(229, 231, 235);
            lblPatientMeta.Location = new Point(0, 0);
            lblPatientMeta.Name = "lblPatientMeta";
            lblPatientMeta.Size = new Size(114, 31);
            lblPatientMeta.TabIndex = 5;
            // 
            // lblPatientName
            // 
            lblPatientName.Location = new Point(0, 0);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(114, 31);
            lblPatientName.TabIndex = 6;
            // 
            // lblAvatar
            // 
            lblAvatar.BackColor = Color.FromArgb(47, 94, 240);
            lblAvatar.Location = new Point(0, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(114, 31);
            lblAvatar.TabIndex = 7;
            // 
            // pnlFilters
            // 
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.BorderColor = Color.FromArgb(229, 231, 235);
            pnlFilters.BorderWidth = 1;
            pnlFilters.Controls.Add(cboStatus);
            pnlFilters.Controls.Add(txtPrescriptionSearch);
            pnlFilters.CornerRadius = 8;
            pnlFilters.FillColor = Color.White;
            pnlFilters.Location = new Point(27, 232);
            pnlFilters.Margin = new Padding(3, 4, 3, 4);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(1367, 99);
            pnlFilters.TabIndex = 1;
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Font = new Font("Segoe UI", 10F);
            cboStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Chờ cấp phát", "Đang chuẩn bị", "Đã cấp phát" });
            cboStatus.Location = new Point(699, 29);
            cboStatus.Margin = new Padding(3, 4, 3, 4);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(639, 31);
            cboStatus.TabIndex = 0;
            // 
            // txtPrescriptionSearch
            // 
            txtPrescriptionSearch.Font = new Font("Segoe UI", 10F);
            txtPrescriptionSearch.ForeColor = Color.FromArgb(148, 163, 184);
            txtPrescriptionSearch.Location = new Point(21, 29);
            txtPrescriptionSearch.Margin = new Padding(3, 4, 3, 4);
            txtPrescriptionSearch.Name = "txtPrescriptionSearch";
            txtPrescriptionSearch.Size = new Size(651, 30);
            txtPrescriptionSearch.TabIndex = 1;
            txtPrescriptionSearch.Text = "  Tìm kiếm theo tên BN hoặc số toa...";
            // 
            // pnlStatsGrid
            // 
            pnlStatsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlStatsGrid.ColumnCount = 3;
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            pnlStatsGrid.Controls.Add(pnlWaiting, 0, 0);
            pnlStatsGrid.Controls.Add(pnlDone, 1, 0);
            pnlStatsGrid.Controls.Add(pnlTotal, 2, 0);
            pnlStatsGrid.Location = new Point(27, 32);
            pnlStatsGrid.Margin = new Padding(3, 4, 3, 4);
            pnlStatsGrid.Name = "pnlStatsGrid";
            pnlStatsGrid.RowCount = 1;
            pnlStatsGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlStatsGrid.Size = new Size(1367, 173);
            pnlStatsGrid.TabIndex = 2;
            // 
            // pnlWaiting
            // 
            pnlWaiting.BorderColor = Color.FromArgb(229, 231, 235);
            pnlWaiting.BorderWidth = 1;
            pnlWaiting.Controls.Add(lblWaitingIcon);
            pnlWaiting.Controls.Add(lblWaitingNumber);
            pnlWaiting.Controls.Add(lblWaitingTitle);
            pnlWaiting.CornerRadius = 8;
            pnlWaiting.FillColor = Color.White;
            pnlWaiting.Location = new Point(0, 0);
            pnlWaiting.Margin = new Padding(0, 0, 21, 0);
            pnlWaiting.Name = "pnlWaiting";
            pnlWaiting.Size = new Size(229, 133);
            pnlWaiting.TabIndex = 0;
            // 
            // lblWaitingIcon
            // 
            lblWaitingIcon.Location = new Point(0, 0);
            lblWaitingIcon.Name = "lblWaitingIcon";
            lblWaitingIcon.Size = new Size(114, 31);
            lblWaitingIcon.TabIndex = 0;
            // 
            // lblWaitingNumber
            // 
            lblWaitingNumber.Location = new Point(0, 0);
            lblWaitingNumber.Name = "lblWaitingNumber";
            lblWaitingNumber.Size = new Size(114, 31);
            lblWaitingNumber.TabIndex = 1;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.Location = new Point(0, 0);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(114, 31);
            lblWaitingTitle.TabIndex = 2;
            // 
            // pnlDone
            // 
            pnlDone.BorderColor = Color.FromArgb(229, 231, 235);
            pnlDone.BorderWidth = 1;
            pnlDone.Controls.Add(lblDoneIcon);
            pnlDone.Controls.Add(lblDoneNumber);
            pnlDone.Controls.Add(lblDoneTitle);
            pnlDone.CornerRadius = 8;
            pnlDone.FillColor = Color.White;
            pnlDone.Location = new Point(455, 0);
            pnlDone.Margin = new Padding(0, 0, 21, 0);
            pnlDone.Name = "pnlDone";
            pnlDone.Size = new Size(229, 133);
            pnlDone.TabIndex = 1;
            // 
            // lblDoneIcon
            // 
            lblDoneIcon.Location = new Point(0, 0);
            lblDoneIcon.Name = "lblDoneIcon";
            lblDoneIcon.Size = new Size(114, 31);
            lblDoneIcon.TabIndex = 0;
            // 
            // lblDoneNumber
            // 
            lblDoneNumber.Location = new Point(0, 0);
            lblDoneNumber.Name = "lblDoneNumber";
            lblDoneNumber.Size = new Size(114, 31);
            lblDoneNumber.TabIndex = 1;
            // 
            // lblDoneTitle
            // 
            lblDoneTitle.Location = new Point(0, 0);
            lblDoneTitle.Name = "lblDoneTitle";
            lblDoneTitle.Size = new Size(114, 31);
            lblDoneTitle.TabIndex = 2;
            // 
            // pnlTotal
            // 
            pnlTotal.BorderColor = Color.FromArgb(229, 231, 235);
            pnlTotal.BorderWidth = 1;
            pnlTotal.Controls.Add(lblTotalIcon);
            pnlTotal.Controls.Add(lblTotalNumber);
            pnlTotal.Controls.Add(lblTotalTitle);
            pnlTotal.CornerRadius = 8;
            pnlTotal.FillColor = Color.White;
            pnlTotal.Location = new Point(910, 0);
            pnlTotal.Margin = new Padding(0);
            pnlTotal.Name = "pnlTotal";
            pnlTotal.Size = new Size(229, 133);
            pnlTotal.TabIndex = 2;
            // 
            // lblTotalIcon
            // 
            lblTotalIcon.Location = new Point(0, 0);
            lblTotalIcon.Name = "lblTotalIcon";
            lblTotalIcon.Size = new Size(114, 31);
            lblTotalIcon.TabIndex = 0;
            // 
            // lblTotalNumber
            // 
            lblTotalNumber.Location = new Point(0, 0);
            lblTotalNumber.Name = "lblTotalNumber";
            lblTotalNumber.Size = new Size(114, 31);
            lblTotalNumber.TabIndex = 1;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.Location = new Point(0, 0);
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(114, 31);
            lblTotalTitle.TabIndex = 2;
            // 
            // lblDrugOneTitle
            // 
            lblDrugOneTitle.Location = new Point(0, 0);
            lblDrugOneTitle.Name = "lblDrugOneTitle";
            lblDrugOneTitle.Size = new Size(100, 23);
            lblDrugOneTitle.TabIndex = 0;
            // 
            // lblDrugOneLeft
            // 
            lblDrugOneLeft.Location = new Point(0, 0);
            lblDrugOneLeft.Name = "lblDrugOneLeft";
            lblDrugOneLeft.Size = new Size(100, 23);
            lblDrugOneLeft.TabIndex = 0;
            // 
            // lblDrugOneRight
            // 
            lblDrugOneRight.Location = new Point(0, 0);
            lblDrugOneRight.Name = "lblDrugOneRight";
            lblDrugOneRight.Size = new Size(100, 23);
            lblDrugOneRight.TabIndex = 0;
            // 
            // lblDrugTwoTitle
            // 
            lblDrugTwoTitle.Location = new Point(0, 0);
            lblDrugTwoTitle.Name = "lblDrugTwoTitle";
            lblDrugTwoTitle.Size = new Size(100, 23);
            lblDrugTwoTitle.TabIndex = 0;
            // 
            // lblDrugTwoLeft
            // 
            lblDrugTwoLeft.Location = new Point(0, 0);
            lblDrugTwoLeft.Name = "lblDrugTwoLeft";
            lblDrugTwoLeft.Size = new Size(100, 23);
            lblDrugTwoLeft.TabIndex = 0;
            // 
            // lblDrugTwoRight
            // 
            lblDrugTwoRight.Location = new Point(0, 0);
            lblDrugTwoRight.Name = "lblDrugTwoRight";
            lblDrugTwoRight.Size = new Size(100, 23);
            lblDrugTwoRight.TabIndex = 0;
            // 
            // lblDrugThreeTitle
            // 
            lblDrugThreeTitle.Location = new Point(0, 0);
            lblDrugThreeTitle.Name = "lblDrugThreeTitle";
            lblDrugThreeTitle.Size = new Size(100, 23);
            lblDrugThreeTitle.TabIndex = 0;
            // 
            // lblDrugThreeLeft
            // 
            lblDrugThreeLeft.Location = new Point(0, 0);
            lblDrugThreeLeft.Name = "lblDrugThreeLeft";
            lblDrugThreeLeft.Size = new Size(100, 23);
            lblDrugThreeLeft.TabIndex = 0;
            // 
            // lblDrugThreeRight
            // 
            lblDrugThreeRight.Location = new Point(0, 0);
            lblDrugThreeRight.Name = "lblDrugThreeRight";
            lblDrugThreeRight.Size = new Size(100, 23);
            lblDrugThreeRight.TabIndex = 0;
            // 
            // ucPrescriptionDispense
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(viewHostPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucPrescriptionDispense";
            Size = new Size(1422, 1333);
            Load += ucPrescriptionDispense_Load;
            viewHostPanel.ResumeLayout(false);
            pnlPrescriptionCard.ResumeLayout(false);
            pnlDoctorNote.ResumeLayout(false);
            pnlWarnings.ResumeLayout(false);
            pnlPrescriptionHeader.ResumeLayout(false);
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            pnlStatsGrid.ResumeLayout(false);
            pnlWaiting.ResumeLayout(false);
            pnlDone.ResumeLayout(false);
            pnlTotal.ResumeLayout(false);
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

        private static void ConfigureDrugPanel(RoundedPanel panel, Label title, Label left, Label right, string titleText, string leftText, string rightText, int x, int y)
        {
            ConfigureCard(panel, Color.FromArgb(249, 250, 251), Color.FromArgb(229, 231, 235));
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel.Controls.Add(right);
            panel.Controls.Add(left);
            panel.Controls.Add(title);
            panel.Location = new Point(x, y);
            panel.Size = new Size(1152, 88);
            SetupLabel(title, titleText, 10.5F, FontStyle.Bold, Color.FromArgb(17, 24, 39), 14, 10, 360, 26);
            SetupLabel(left, leftText, 9.5F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 14, 42, 360, 42);
            SetupLabel(right, rightText, 9.5F, FontStyle.Regular, Color.FromArgb(55, 65, 81), 620, 42, 440, 42);
        }

        private RoundedPanel viewHostPanel;
        private TableLayoutPanel pnlStatsGrid;
        private RoundedPanel pnlWaiting;
        private Label lblWaitingIcon;
        private Label lblWaitingNumber;
        private Label lblWaitingTitle;
        private RoundedPanel pnlDone;
        private Label lblDoneIcon;
        private Label lblDoneNumber;
        private Label lblDoneTitle;
        private RoundedPanel pnlTotal;
        private Label lblTotalIcon;
        private Label lblTotalNumber;
        private Label lblTotalTitle;
        private RoundedPanel pnlFilters;
        private TextBox txtPrescriptionSearch;
        private ComboBox cboStatus;
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
        private Label lblDiagnosisTitle;
        private Label lblDiagnosis;
        private RoundedPanel pnlWarnings;
        private Label lblAllergy;
        private Label lblChronic;
        private Label lblDrugListTitle;
        private RoundedPanel pnlDrugOne;
        private Label lblDrugOneTitle;
        private Label lblDrugOneLeft;
        private Label lblDrugOneRight;
        private RoundedPanel pnlDrugTwo;
        private Label lblDrugTwoTitle;
        private Label lblDrugTwoLeft;
        private Label lblDrugTwoRight;
        private RoundedPanel pnlDrugThree;
        private Label lblDrugThreeTitle;
        private Label lblDrugThreeLeft;
        private Label lblDrugThreeRight;
        private RoundedPanel pnlDoctorNote;
        private Label lblNoteTitle;
        private Label lblNoteContent;
        private Button btnDispense;
    }
}
