namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    partial class ucVisitCard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlHeader;
        private Panel pnlVitalSigns;

        private Label lblTitle;
        private Label lblDiagnosis;

        private Label lblVisitDateTitle;
        private Label lblVisitDate;

        private Label lblDoctorTitle;
        private Label lblDoctor;

        private Label lblDepartmentTitle;
        private Label lblDepartment;

        private Label lblSymptomsTitle;
        private Label lblSymptoms;

        private Label lblConclusionTitle;
        private Label lblConclusion;

        private TableLayoutPanel tblVital;

        private Label lblBPTitle;
        private Label lblTempTitle;
        private Label lblHeartTitle;
        private Label lblHeightTitle;
        private Label lblWeightTitle;

        private Label lblBP;
        private Label lblTemp;
        private Label lblHeart;
        private Label lblHeight;
        private Label lblWeight;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblDiagnosis = new Label();
            lblVisitDateTitle = new Label();
            lblVisitDate = new Label();
            lblDoctorTitle = new Label();
            lblDoctor = new Label();
            lblDepartmentTitle = new Label();
            lblDepartment = new Label();
            lblSymptomsTitle = new Label();
            lblSymptoms = new Label();
            lblConclusionTitle = new Label();
            lblConclusion = new Label();
            pnlVitalSigns = new Panel();
            tblVital = new TableLayoutPanel();
            lblBPTitle = new Label();
            lblTempTitle = new Label();
            lblHeartTitle = new Label();
            lblHeightTitle = new Label();
            lblWeightTitle = new Label();
            lblBP = new Label();
            lblTemp = new Label();
            lblHeart = new Label();
            lblHeight = new Label();
            lblWeight = new Label();
            pnlHeader.SuspendLayout();
            pnlVitalSigns.SuspendLayout();
            tblVital.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblDiagnosis);
            pnlHeader.Controls.Add(lblVisitDateTitle);
            pnlHeader.Controls.Add(lblVisitDate);
            pnlHeader.Controls.Add(lblDoctorTitle);
            pnlHeader.Controls.Add(lblDoctor);
            pnlHeader.Controls.Add(lblDepartmentTitle);
            pnlHeader.Controls.Add(lblDepartment);
            pnlHeader.Controls.Add(lblSymptomsTitle);
            pnlHeader.Controls.Add(lblSymptoms);
            pnlHeader.Controls.Add(lblConclusionTitle);
            pnlHeader.Controls.Add(lblConclusion);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15);
            pnlHeader.Size = new Size(1527, 285);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Chuẩn đoán";
            // 
            // lblDiagnosis
            // 
            lblDiagnosis.AutoSize = true;
            lblDiagnosis.Font = new Font("Segoe UI", 12F);
            lblDiagnosis.Location = new Point(15, 45);
            lblDiagnosis.Name = "lblDiagnosis";
            lblDiagnosis.Size = new Size(143, 28);
            lblDiagnosis.TabIndex = 1;
            lblDiagnosis.Text = "Viêm họng cấp";
            // 
            // lblVisitDateTitle
            // 
            lblVisitDateTitle.AutoSize = true;
            lblVisitDateTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVisitDateTitle.Location = new Point(15, 90);
            lblVisitDateTitle.Name = "lblVisitDateTitle";
            lblVisitDateTitle.Size = new Size(93, 20);
            lblVisitDateTitle.TabIndex = 2;
            lblVisitDateTitle.Text = "Ngày khám:";
            // 
            // lblVisitDate
            // 
            lblVisitDate.AutoSize = true;
            lblVisitDate.Location = new Point(100, 90);
            lblVisitDate.Name = "lblVisitDate";
            lblVisitDate.Size = new Size(85, 20);
            lblVisitDate.TabIndex = 3;
            lblVisitDate.Text = "12/05/2026";
            // 
            // lblDoctorTitle
            // 
            lblDoctorTitle.AutoSize = true;
            lblDoctorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDoctorTitle.Location = new Point(350, 90);
            lblDoctorTitle.Name = "lblDoctorTitle";
            lblDoctorTitle.Size = new Size(53, 20);
            lblDoctorTitle.TabIndex = 4;
            lblDoctorTitle.Text = "Bác sĩ:";
            // 
            // lblDoctor
            // 
            lblDoctor.AutoSize = true;
            lblDoctor.Location = new Point(410, 90);
            lblDoctor.Name = "lblDoctor";
            lblDoctor.Size = new Size(95, 20);
            lblDoctor.TabIndex = 5;
            lblDoctor.Text = "BS Trần Minh";
            // 
            // lblDepartmentTitle
            // 
            lblDepartmentTitle.AutoSize = true;
            lblDepartmentTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDepartmentTitle.Location = new Point(15, 120);
            lblDepartmentTitle.Name = "lblDepartmentTitle";
            lblDepartmentTitle.Size = new Size(49, 20);
            lblDepartmentTitle.TabIndex = 6;
            lblDepartmentTitle.Text = "Khoa:";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(100, 120);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(102, 20);
            lblDepartment.TabIndex = 7;
            lblDepartment.Text = "Nội tổng quát";
            // 
            // lblSymptomsTitle
            // 
            lblSymptomsTitle.AutoSize = true;
            lblSymptomsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSymptomsTitle.Location = new Point(15, 160);
            lblSymptomsTitle.Name = "lblSymptomsTitle";
            lblSymptomsTitle.Size = new Size(96, 20);
            lblSymptomsTitle.TabIndex = 8;
            lblSymptomsTitle.Text = "Triệu chứng:";
            // 
            // lblSymptoms
            // 
            lblSymptoms.Location = new Point(15, 185);
            lblSymptoms.Name = "lblSymptoms";
            lblSymptoms.Size = new Size(800, 35);
            lblSymptoms.TabIndex = 9;
            lblSymptoms.Text = "Ho, sốt";
            // 
            // lblConclusionTitle
            // 
            lblConclusionTitle.AutoSize = true;
            lblConclusionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblConclusionTitle.Location = new Point(15, 225);
            lblConclusionTitle.Name = "lblConclusionTitle";
            lblConclusionTitle.Size = new Size(71, 20);
            lblConclusionTitle.TabIndex = 10;
            lblConclusionTitle.Text = "Kết luận:";
            // 
            // lblConclusion
            // 
            lblConclusion.Location = new Point(15, 250);
            lblConclusion.Name = "lblConclusion";
            lblConclusion.Size = new Size(1000, 30);
            lblConclusion.TabIndex = 11;
            lblConclusion.Text = "Kê thuốc, tái khám sau 7 ngày";
            // 
            // pnlVitalSigns
            // 
            pnlVitalSigns.BackColor = Color.RoyalBlue;
            pnlVitalSigns.Controls.Add(tblVital);
            pnlVitalSigns.Dock = DockStyle.Bottom;
            pnlVitalSigns.Location = new Point(0, 285);
            pnlVitalSigns.Name = "pnlVitalSigns";
            pnlVitalSigns.Size = new Size(1527, 80);
            pnlVitalSigns.TabIndex = 1;
            // 
            // tblVital
            // 
            tblVital.ColumnCount = 5;
            tblVital.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblVital.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblVital.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblVital.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblVital.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tblVital.Controls.Add(lblBPTitle, 0, 0);
            tblVital.Controls.Add(lblTempTitle, 1, 0);
            tblVital.Controls.Add(lblHeartTitle, 2, 0);
            tblVital.Controls.Add(lblHeightTitle, 3, 0);
            tblVital.Controls.Add(lblWeightTitle, 4, 0);
            tblVital.Controls.Add(lblBP, 0, 1);
            tblVital.Controls.Add(lblTemp, 1, 1);
            tblVital.Controls.Add(lblHeart, 2, 1);
            tblVital.Controls.Add(lblHeight, 3, 1);
            tblVital.Controls.Add(lblWeight, 4, 1);
            tblVital.Dock = DockStyle.Fill;
            tblVital.Location = new Point(0, 0);
            tblVital.Name = "tblVital";
            tblVital.RowCount = 2;
            tblVital.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblVital.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblVital.Size = new Size(1527, 80);
            tblVital.TabIndex = 0;
            // 
            // lblBPTitle
            // 
            lblBPTitle.Dock = DockStyle.Fill;
            lblBPTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBPTitle.ForeColor = Color.White;
            lblBPTitle.Location = new Point(3, 0);
            lblBPTitle.Name = "lblBPTitle";
            lblBPTitle.Size = new Size(299, 40);
            lblBPTitle.TabIndex = 0;
            lblBPTitle.Text = "Huyết áp";
            lblBPTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTempTitle
            // 
            lblTempTitle.Dock = DockStyle.Fill;
            lblTempTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTempTitle.ForeColor = Color.White;
            lblTempTitle.Location = new Point(308, 0);
            lblTempTitle.Name = "lblTempTitle";
            lblTempTitle.Size = new Size(299, 40);
            lblTempTitle.TabIndex = 1;
            lblTempTitle.Text = "Nhiệt độ";
            lblTempTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeartTitle
            // 
            lblHeartTitle.Dock = DockStyle.Fill;
            lblHeartTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeartTitle.ForeColor = Color.White;
            lblHeartTitle.Location = new Point(613, 0);
            lblHeartTitle.Name = "lblHeartTitle";
            lblHeartTitle.Size = new Size(299, 40);
            lblHeartTitle.TabIndex = 2;
            lblHeartTitle.Text = "Nhịp tim";
            lblHeartTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeightTitle
            // 
            lblHeightTitle.Dock = DockStyle.Fill;
            lblHeightTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHeightTitle.ForeColor = Color.White;
            lblHeightTitle.Location = new Point(918, 0);
            lblHeightTitle.Name = "lblHeightTitle";
            lblHeightTitle.Size = new Size(299, 40);
            lblHeightTitle.TabIndex = 3;
            lblHeightTitle.Text = "Chiều cao";
            lblHeightTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWeightTitle
            // 
            lblWeightTitle.Dock = DockStyle.Fill;
            lblWeightTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWeightTitle.ForeColor = Color.White;
            lblWeightTitle.Location = new Point(1223, 0);
            lblWeightTitle.Name = "lblWeightTitle";
            lblWeightTitle.Size = new Size(301, 40);
            lblWeightTitle.TabIndex = 4;
            lblWeightTitle.Text = "Cân nặng";
            lblWeightTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBP
            // 
            lblBP.Dock = DockStyle.Fill;
            lblBP.Font = new Font("Segoe UI", 10F);
            lblBP.ForeColor = Color.White;
            lblBP.Location = new Point(3, 40);
            lblBP.Name = "lblBP";
            lblBP.Size = new Size(299, 40);
            lblBP.TabIndex = 5;
            lblBP.Text = "120/80";
            lblBP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTemp
            // 
            lblTemp.Dock = DockStyle.Fill;
            lblTemp.Font = new Font("Segoe UI", 10F);
            lblTemp.ForeColor = Color.White;
            lblTemp.Location = new Point(308, 40);
            lblTemp.Name = "lblTemp";
            lblTemp.Size = new Size(299, 40);
            lblTemp.TabIndex = 6;
            lblTemp.Text = "37°C";
            lblTemp.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeart
            // 
            lblHeart.Dock = DockStyle.Fill;
            lblHeart.Font = new Font("Segoe UI", 10F);
            lblHeart.ForeColor = Color.White;
            lblHeart.Location = new Point(613, 40);
            lblHeart.Name = "lblHeart";
            lblHeart.Size = new Size(299, 40);
            lblHeart.TabIndex = 7;
            lblHeart.Text = "80";
            lblHeart.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblHeight
            // 
            lblHeight.Dock = DockStyle.Fill;
            lblHeight.Font = new Font("Segoe UI", 10F);
            lblHeight.ForeColor = Color.White;
            lblHeight.Location = new Point(918, 40);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(299, 40);
            lblHeight.TabIndex = 8;
            lblHeight.Text = "170 cm";
            lblHeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblWeight
            // 
            lblWeight.Dock = DockStyle.Fill;
            lblWeight.Font = new Font("Segoe UI", 10F);
            lblWeight.ForeColor = Color.White;
            lblWeight.Location = new Point(1223, 40);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(301, 40);
            lblWeight.TabIndex = 9;
            lblWeight.Text = "65 kg";
            lblWeight.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ucVisitCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pnlHeader);
            Controls.Add(pnlVitalSigns);
            Name = "ucVisitCard";
            Size = new Size(1527, 365);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlVitalSigns.ResumeLayout(false);
            tblVital.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}