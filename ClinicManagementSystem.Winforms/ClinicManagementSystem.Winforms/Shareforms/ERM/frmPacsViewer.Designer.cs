using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class frmPacsViewer
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlToolbar;

        private GroupBox grpPatientInfo;
        private GroupBox grpStudyInfo;

        private Label lblPatientTitle;
        private Label lblPatientName;

        private Label lblTypeTitle;
        private Label lblType;

        private Label lblStudyDateTitle;
        private Label lblStudyDate;

        private Label lblModalityTitle;
        private Label lblModalityValue;

        private Label lblBodyPartTitle;
        private Label lblBodyPartValue;

        private Label lblTechnicianTitle;
        private Label lblTechnicianValue;

        private Label lblNoteTitle;
        private Label lblNote;

        private Label lblBrightness;
        private Label lblContrast;
        private Label lblZoomControl;

        private TrackBar tbBrightness;
        private TrackBar tbContrast;

        private Button btnZoomInLeft;
        private Button btnZoomOutLeft;

        private Button btnReset;
        private Button btnDownload;

        private Label lblViewerTitle;
        private Label lblZoomPercent;

        private Button btnZoomIn;
        private Button btnZoomOut;
        private Button btnRotate;
        private Button btnFlip;
        private Button btnPan;
        private Button btnClose;

        private PictureBox picImage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlLeft = new Panel();
            grpPatientInfo = new GroupBox();
            lblPatientTitle = new Label();
            lblPatientName = new Label();
            lblTypeTitle = new Label();
            lblType = new Label();
            lblStudyDateTitle = new Label();
            lblStudyDate = new Label();
            grpStudyInfo = new GroupBox();
            lblModalityTitle = new Label();
            lblModalityValue = new Label();
            lblBodyPartTitle = new Label();
            lblBodyPartValue = new Label();
            lblTechnicianTitle = new Label();
            lblTechnicianValue = new Label();
            lblNoteTitle = new Label();
            lblNote = new Label();
            lblBrightness = new Label();
            tbBrightness = new TrackBar();
            lblContrast = new Label();
            tbContrast = new TrackBar();
            lblZoomControl = new Label();
            btnZoomOutLeft = new Button();
            btnZoomInLeft = new Button();
            btnReset = new Button();
            btnDownload = new Button();
            pnlRight = new Panel();
            picImage = new PictureBox();
            pnlToolbar = new Panel();
            lblViewerTitle = new Label();
            lblZoomPercent = new Label();
            btnZoomIn = new Button();
            btnZoomOut = new Button();
            btnRotate = new Button();
            btnFlip = new Button();
            btnPan = new Button();
            btnClose = new Button();
            pnlLeft.SuspendLayout();
            grpPatientInfo.SuspendLayout();
            grpStudyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbBrightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).BeginInit();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picImage).BeginInit();
            pnlToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.MidnightBlue;
            pnlLeft.Controls.Add(grpPatientInfo);
            pnlLeft.Controls.Add(grpStudyInfo);
            pnlLeft.Controls.Add(lblBrightness);
            pnlLeft.Controls.Add(tbBrightness);
            pnlLeft.Controls.Add(lblContrast);
            pnlLeft.Controls.Add(tbContrast);
            pnlLeft.Controls.Add(lblZoomControl);
            pnlLeft.Controls.Add(btnZoomOutLeft);
            pnlLeft.Controls.Add(btnZoomInLeft);
            pnlLeft.Controls.Add(btnReset);
            pnlLeft.Controls.Add(btnDownload);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(10);
            pnlLeft.Size = new Size(350, 900);
            pnlLeft.TabIndex = 1;
            // 
            // grpPatientInfo
            // 
            grpPatientInfo.Controls.Add(lblPatientTitle);
            grpPatientInfo.Controls.Add(lblPatientName);
            grpPatientInfo.Controls.Add(lblTypeTitle);
            grpPatientInfo.Controls.Add(lblType);
            grpPatientInfo.Controls.Add(lblStudyDateTitle);
            grpPatientInfo.Controls.Add(lblStudyDate);
            grpPatientInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpPatientInfo.ForeColor = Color.White;
            grpPatientInfo.Location = new Point(10, 18);
            grpPatientInfo.Name = "grpPatientInfo";
            grpPatientInfo.Size = new Size(320, 150);
            grpPatientInfo.TabIndex = 0;
            grpPatientInfo.TabStop = false;
            grpPatientInfo.Text = "Thông tin bệnh nhân";
            // 
            // lblPatientTitle
            // 
            lblPatientTitle.AutoSize = true;
            lblPatientTitle.Location = new Point(15, 35);
            lblPatientTitle.Name = "lblPatientTitle";
            lblPatientTitle.Size = new Size(88, 20);
            lblPatientTitle.TabIndex = 0;
            lblPatientTitle.Text = "Bệnh nhân:";
            // 
            // lblPatientName
            // 
            lblPatientName.AutoSize = true;
            lblPatientName.Location = new Point(120, 35);
            lblPatientName.Name = "lblPatientName";
            lblPatientName.Size = new Size(109, 20);
            lblPatientName.TabIndex = 1;
            lblPatientName.Text = "Nguyễn Văn A";
            // 
            // lblTypeTitle
            // 
            lblTypeTitle.AutoSize = true;
            lblTypeTitle.Location = new Point(15, 70);
            lblTypeTitle.Name = "lblTypeTitle";
            lblTypeTitle.Size = new Size(42, 20);
            lblTypeTitle.TabIndex = 2;
            lblTypeTitle.Text = "Loại:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(120, 70);
            lblType.Name = "lblType";
            lblType.Size = new Size(86, 20);
            lblType.TabIndex = 3;
            lblType.Text = "X-Ray phổi";
            // 
            // lblStudyDateTitle
            // 
            lblStudyDateTitle.AutoSize = true;
            lblStudyDateTitle.Location = new Point(15, 105);
            lblStudyDateTitle.Name = "lblStudyDateTitle";
            lblStudyDateTitle.Size = new Size(88, 20);
            lblStudyDateTitle.TabIndex = 4;
            lblStudyDateTitle.Text = "Ngày chụp:";
            // 
            // lblStudyDate
            // 
            lblStudyDate.AutoSize = true;
            lblStudyDate.Location = new Point(120, 105);
            lblStudyDate.Name = "lblStudyDate";
            lblStudyDate.Size = new Size(95, 20);
            lblStudyDate.TabIndex = 5;
            lblStudyDate.Text = "14/05/2026";
            // 
            // grpStudyInfo
            // 
            grpStudyInfo.Controls.Add(lblModalityTitle);
            grpStudyInfo.Controls.Add(lblModalityValue);
            grpStudyInfo.Controls.Add(lblBodyPartTitle);
            grpStudyInfo.Controls.Add(lblBodyPartValue);
            grpStudyInfo.Controls.Add(lblTechnicianTitle);
            grpStudyInfo.Controls.Add(lblTechnicianValue);
            grpStudyInfo.Controls.Add(lblNoteTitle);
            grpStudyInfo.Controls.Add(lblNote);
            grpStudyInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grpStudyInfo.ForeColor = Color.White;
            grpStudyInfo.Location = new Point(10, 199);
            grpStudyInfo.Name = "grpStudyInfo";
            grpStudyInfo.Size = new Size(320, 230);
            grpStudyInfo.TabIndex = 1;
            grpStudyInfo.TabStop = false;
            grpStudyInfo.Text = "Chi tiết chụp ảnh";
            // 
            // lblModalityTitle
            // 
            lblModalityTitle.AutoSize = true;
            lblModalityTitle.Location = new Point(15, 35);
            lblModalityTitle.Name = "lblModalityTitle";
            lblModalityTitle.Size = new Size(75, 20);
            lblModalityTitle.TabIndex = 0;
            lblModalityTitle.Text = "Modality:";
            // 
            // lblModalityValue
            // 
            lblModalityValue.AutoSize = true;
            lblModalityValue.Location = new Point(120, 35);
            lblModalityValue.Name = "lblModalityValue";
            lblModalityValue.Size = new Size(54, 20);
            lblModalityValue.TabIndex = 1;
            lblModalityValue.Text = "X-RAY";
            // 
            // lblBodyPartTitle
            // 
            lblBodyPartTitle.AutoSize = true;
            lblBodyPartTitle.Location = new Point(15, 70);
            lblBodyPartTitle.Name = "lblBodyPartTitle";
            lblBodyPartTitle.Size = new Size(71, 20);
            lblBodyPartTitle.TabIndex = 2;
            lblBodyPartTitle.Text = "Bộ phận:";
            // 
            // lblBodyPartValue
            // 
            lblBodyPartValue.AutoSize = true;
            lblBodyPartValue.Location = new Point(120, 70);
            lblBodyPartValue.Name = "lblBodyPartValue";
            lblBodyPartValue.Size = new Size(40, 20);
            lblBodyPartValue.TabIndex = 3;
            lblBodyPartValue.Text = "Phổi";
            // 
            // lblTechnicianTitle
            // 
            lblTechnicianTitle.AutoSize = true;
            lblTechnicianTitle.Location = new Point(15, 105);
            lblTechnicianTitle.Name = "lblTechnicianTitle";
            lblTechnicianTitle.Size = new Size(106, 20);
            lblTechnicianTitle.TabIndex = 4;
            lblTechnicianTitle.Text = "Kỹ thuật viên:";
            // 
            // lblTechnicianValue
            // 
            lblTechnicianValue.AutoSize = true;
            lblTechnicianValue.Location = new Point(120, 105);
            lblTechnicianValue.Name = "lblTechnicianValue";
            lblTechnicianValue.Size = new Size(143, 20);
            lblTechnicianValue.TabIndex = 5;
            lblTechnicianValue.Text = "KTV. Nguyễn Văn X";
            // 
            // lblNoteTitle
            // 
            lblNoteTitle.AutoSize = true;
            lblNoteTitle.Location = new Point(15, 140);
            lblNoteTitle.Name = "lblNoteTitle";
            lblNoteTitle.Size = new Size(66, 20);
            lblNoteTitle.TabIndex = 6;
            lblNoteTitle.Text = "Ghi chú:";
            // 
            // lblNote
            // 
            lblNote.Location = new Point(120, 140);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(180, 67);
            lblNote.TabIndex = 7;
            lblNote.Text = "Phổi trong, tim bình thường";
            // 
            // lblBrightness
            // 
            lblBrightness.AutoSize = true;
            lblBrightness.ForeColor = Color.White;
            lblBrightness.Location = new Point(15, 455);
            lblBrightness.Name = "lblBrightness";
            lblBrightness.Size = new Size(64, 20);
            lblBrightness.TabIndex = 2;
            lblBrightness.Text = "Độ sáng";
            // 
            // tbBrightness
            // 
            tbBrightness.Location = new Point(15, 478);
            tbBrightness.Maximum = 100;
            tbBrightness.Minimum = -100;
            tbBrightness.Name = "tbBrightness";
            tbBrightness.Size = new Size(300, 56);
            tbBrightness.TabIndex = 3;
            tbBrightness.TickFrequency = 10;
            // 
            // lblContrast
            // 
            lblContrast.AutoSize = true;
            lblContrast.ForeColor = Color.White;
            lblContrast.Location = new Point(15, 537);
            lblContrast.Name = "lblContrast";
            lblContrast.Size = new Size(110, 20);
            lblContrast.TabIndex = 4;
            lblContrast.Text = "Độ tương phản";
            // 
            // tbContrast
            // 
            tbContrast.Location = new Point(15, 571);
            tbContrast.Maximum = 100;
            tbContrast.Minimum = -100;
            tbContrast.Name = "tbContrast";
            tbContrast.Size = new Size(300, 56);
            tbContrast.TabIndex = 5;
            tbContrast.TickFrequency = 10;
            // 
            // lblZoomControl
            // 
            lblZoomControl.AutoSize = true;
            lblZoomControl.ForeColor = Color.White;
            lblZoomControl.Location = new Point(15, 630);
            lblZoomControl.Name = "lblZoomControl";
            lblZoomControl.Size = new Size(49, 20);
            lblZoomControl.TabIndex = 6;
            lblZoomControl.Text = "Zoom";
            // 
            // btnZoomOutLeft
            // 
            btnZoomOutLeft.BackColor = Color.DimGray;
            btnZoomOutLeft.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnZoomOutLeft.ForeColor = Color.White;
            btnZoomOutLeft.Location = new Point(25, 660);
            btnZoomOutLeft.Name = "btnZoomOutLeft";
            btnZoomOutLeft.Size = new Size(145, 52);
            btnZoomOutLeft.TabIndex = 7;
            btnZoomOutLeft.Text = "-";
            btnZoomOutLeft.UseVisualStyleBackColor = false;
            // 
            // btnZoomInLeft
            // 
            btnZoomInLeft.BackColor = Color.DimGray;
            btnZoomInLeft.ForeColor = Color.White;
            btnZoomInLeft.Location = new Point(176, 660);
            btnZoomInLeft.Name = "btnZoomInLeft";
            btnZoomInLeft.Size = new Size(134, 52);
            btnZoomInLeft.TabIndex = 8;
            btnZoomInLeft.Text = "+";
            btnZoomInLeft.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = Color.RoyalBlue;
            btnReset.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReset.ForeColor = Color.White;
            btnReset.Location = new Point(25, 730);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(290, 71);
            btnReset.TabIndex = 9;
            btnReset.Text = "Đặt lại mặc định";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // btnDownload
            // 
            btnDownload.BackColor = Color.MediumSeaGreen;
            btnDownload.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDownload.ForeColor = Color.White;
            btnDownload.Location = new Point(25, 817);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(290, 58);
            btnDownload.TabIndex = 10;
            btnDownload.Text = "Tải xuống";
            btnDownload.UseVisualStyleBackColor = false;
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.Black;
            pnlRight.Controls.Add(picImage);
            pnlRight.Controls.Add(pnlToolbar);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(350, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1250, 900);
            pnlRight.TabIndex = 0;
            // 
            // picImage
            // 
            picImage.BackColor = Color.Black;
            picImage.Dock = DockStyle.Fill;
            picImage.Location = new Point(0, 60);
            picImage.Name = "picImage";
            picImage.Size = new Size(1250, 840);
            picImage.SizeMode = PictureBoxSizeMode.Zoom;
            picImage.TabIndex = 0;
            picImage.TabStop = false;
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.MidnightBlue;
            pnlToolbar.Controls.Add(lblViewerTitle);
            pnlToolbar.Controls.Add(lblZoomPercent);
            pnlToolbar.Controls.Add(btnZoomIn);
            pnlToolbar.Controls.Add(btnZoomOut);
            pnlToolbar.Controls.Add(btnRotate);
            pnlToolbar.Controls.Add(btnFlip);
            pnlToolbar.Controls.Add(btnPan);
            pnlToolbar.Controls.Add(btnClose);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 0);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Size = new Size(1250, 60);
            pnlToolbar.TabIndex = 1;
            // 
            // lblViewerTitle
            // 
            lblViewerTitle.AutoSize = true;
            lblViewerTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblViewerTitle.ForeColor = Color.White;
            lblViewerTitle.Location = new Point(15, 18);
            lblViewerTitle.Name = "lblViewerTitle";
            lblViewerTitle.Size = new Size(125, 25);
            lblViewerTitle.TabIndex = 0;
            lblViewerTitle.Text = "PACS Viewer";
            // 
            // lblZoomPercent
            // 
            lblZoomPercent.AutoSize = true;
            lblZoomPercent.ForeColor = Color.White;
            lblZoomPercent.Location = new Point(180, 20);
            lblZoomPercent.Name = "lblZoomPercent";
            lblZoomPercent.Size = new Size(92, 20);
            lblZoomPercent.TabIndex = 1;
            lblZoomPercent.Text = "Zoom: 100%";
            // 
            // btnZoomIn
            // 
            btnZoomIn.BackColor = Color.DimGray;
            btnZoomIn.ForeColor = Color.White;
            btnZoomIn.Location = new Point(320, 12);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(45, 35);
            btnZoomIn.TabIndex = 2;
            btnZoomIn.Text = "+";
            btnZoomIn.UseVisualStyleBackColor = false;
            // 
            // btnZoomOut
            // 
            btnZoomOut.BackColor = Color.DimGray;
            btnZoomOut.ForeColor = Color.White;
            btnZoomOut.Location = new Point(370, 12);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(45, 35);
            btnZoomOut.TabIndex = 3;
            btnZoomOut.Text = "-";
            btnZoomOut.UseVisualStyleBackColor = false;
            // 
            // btnRotate
            // 
            btnRotate.BackColor = Color.DimGray;
            btnRotate.ForeColor = Color.White;
            btnRotate.Location = new Point(430, 12);
            btnRotate.Name = "btnRotate";
            btnRotate.Size = new Size(80, 35);
            btnRotate.TabIndex = 4;
            btnRotate.Text = "Rotate";
            btnRotate.UseVisualStyleBackColor = false;
            // 
            // btnFlip
            // 
            btnFlip.BackColor = Color.DimGray;
            btnFlip.ForeColor = Color.White;
            btnFlip.Location = new Point(520, 12);
            btnFlip.Name = "btnFlip";
            btnFlip.Size = new Size(80, 35);
            btnFlip.TabIndex = 5;
            btnFlip.Text = "Flip";
            btnFlip.UseVisualStyleBackColor = false;
            // 
            // btnPan
            // 
            btnPan.BackColor = Color.DimGray;
            btnPan.ForeColor = Color.White;
            btnPan.Location = new Point(606, 12);
            btnPan.Name = "btnPan";
            btnPan.Size = new Size(80, 35);
            btnPan.TabIndex = 6;
            btnPan.Text = "Pan";
            btnPan.UseVisualStyleBackColor = false;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Red;
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1158, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(80, 35);
            btnClose.TabIndex = 7;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // frmPacsViewer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 900);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Name = "frmPacsViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PACS Viewer";
            WindowState = FormWindowState.Maximized;
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            grpPatientInfo.ResumeLayout(false);
            grpPatientInfo.PerformLayout();
            grpStudyInfo.ResumeLayout(false);
            grpStudyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbBrightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbContrast).EndInit();
            pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picImage).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlToolbar.PerformLayout();
            ResumeLayout(false);
        }
    }
}