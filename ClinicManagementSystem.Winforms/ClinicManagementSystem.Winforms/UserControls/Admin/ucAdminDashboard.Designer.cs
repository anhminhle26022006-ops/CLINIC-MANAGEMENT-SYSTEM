using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucAdminDashboard
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            outerScroll = new Panel();
            mainFlow = new FlowLayoutPanel();
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnRefresh = new Button();
            kpiFlow = new Panel();
            cardPatients = new Panel();
            lblPatientsTitle = new Label();
            lblPatientsValue = new Label();
            lblPatientsIcon = new Label();
            cardAppointments = new Panel();
            lblAppointmentsTitle = new Label();
            lblAppointmentsValue = new Label();
            lblAppointmentsIcon = new Label();
            cardWaiting = new Panel();
            lblWaitingTitle = new Label();
            lblWaitingValue = new Label();
            lblWaitingIcon = new Label();
            cardEmployees = new Panel();
            lblEmployeesTitle = new Label();
            lblEmployeesValue = new Label();
            lblEmployeesIcon = new Label();
            cardMedicine = new Panel();
            lblMedicineKpiTitle = new Label();
            lblMedicineValue = new Label();
            lblMedicineIcon = new Label();
            apptCard = new Panel();
            dgvAppointments = new DataGridView();
            colTime = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colDoctor = new DataGridViewTextBoxColumn();
            colDept = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblApptTitle = new Label();
            medCard = new Panel();
            panelMedicineList = new FlowLayoutPanel();
            lblMedTitle = new Label();
            deptCard = new Panel();
            panelDeptCards = new FlowLayoutPanel();
            lblDeptTitle = new Label();
            queueCard = new Panel();
            panelQueueCards = new Panel();
            cardWaitingQ = new Panel();
            lblWaitingQTitle = new Label();
            lblWaitingQValue = new Label();
            cardInProgressQ = new Panel();
            lblInProgressQTitle = new Label();
            lblInProgressQValue = new Label();
            cardDoneQ = new Panel();
            lblDoneQTitle = new Label();
            lblDoneQValue = new Label();
            cardCancelledQ = new Panel();
            lblCancelledQTitle = new Label();
            lblCancelledQValue = new Label();
            lblQueueTitle = new Label();
            outerScroll.SuspendLayout();
            mainFlow.SuspendLayout();
            panelHeader.SuspendLayout();
            kpiFlow.SuspendLayout();
            cardPatients.SuspendLayout();
            cardAppointments.SuspendLayout();
            cardWaiting.SuspendLayout();
            cardEmployees.SuspendLayout();
            cardMedicine.SuspendLayout();
            apptCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            medCard.SuspendLayout();
            deptCard.SuspendLayout();
            queueCard.SuspendLayout();
            panelQueueCards.SuspendLayout();
            cardWaitingQ.SuspendLayout();
            cardInProgressQ.SuspendLayout();
            cardDoneQ.SuspendLayout();
            cardCancelledQ.SuspendLayout();
            SuspendLayout();
            // 
            // outerScroll
            // 
            outerScroll.AutoScroll = true;
            outerScroll.BackColor = Color.FromArgb(245, 247, 250);
            outerScroll.Controls.Add(mainFlow);
            outerScroll.Dock = DockStyle.Fill;
            outerScroll.Location = new Point(0, 0);
            outerScroll.Margin = new Padding(2);
            outerScroll.Name = "outerScroll";
            outerScroll.Size = new Size(1024, 720);
            outerScroll.TabIndex = 0;
            outerScroll.Resize += outerScroll_Resize;
            // 
            // mainFlow
            // 
            mainFlow.AutoSize = true;
            mainFlow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            mainFlow.BackColor = Color.FromArgb(245, 247, 250);
            mainFlow.Controls.Add(panelHeader);
            mainFlow.Controls.Add(kpiFlow);
            mainFlow.Controls.Add(apptCard);
            mainFlow.Controls.Add(medCard);
            mainFlow.Controls.Add(deptCard);
            mainFlow.Controls.Add(queueCard);
            mainFlow.Dock = DockStyle.Top;
            mainFlow.FlowDirection = FlowDirection.TopDown;
            mainFlow.Location = new Point(0, 0);
            mainFlow.Margin = new Padding(2);
            mainFlow.Name = "mainFlow";
            mainFlow.Padding = new Padding(22, 19, 22, 26);
            mainFlow.Size = new Size(1003, 1293);
            mainFlow.TabIndex = 0;
            mainFlow.WrapContents = false;
            mainFlow.Paint += mainFlow_Paint;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnRefresh);
            panelHeader.Location = new Point(22, 19);
            panelHeader.Margin = new Padding(0, 0, 0, 16);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(960, 82);
            panelHeader.TabIndex = 0;
            panelHeader.Resize += panelHeader_Resize;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(2, 0);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(264, 62);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tổng quan";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10.5F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(4, 56);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(190, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Xin chào, Quản trị viên";
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.White;
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9.5F);
            btnRefresh.ForeColor = Color.FromArgb(37, 99, 235);
            btnRefresh.Location = new Point(815, 18);
            btnRefresh.Margin = new Padding(2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(128, 44);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄  Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // kpiFlow
            // 
            kpiFlow.BackColor = Color.Transparent;
            kpiFlow.Controls.Add(cardPatients);
            kpiFlow.Controls.Add(cardAppointments);
            kpiFlow.Controls.Add(cardWaiting);
            kpiFlow.Controls.Add(cardEmployees);
            kpiFlow.Controls.Add(cardMedicine);
            kpiFlow.Location = new Point(22, 117);
            kpiFlow.Margin = new Padding(0, 0, 0, 16);
            kpiFlow.Name = "kpiFlow";
            kpiFlow.Size = new Size(960, 150);
            kpiFlow.TabIndex = 1;
            // 
            // cardPatients
            // 
            cardPatients.BackColor = Color.FromArgb(239, 246, 255);
            cardPatients.Controls.Add(lblPatientsTitle);
            cardPatients.Controls.Add(lblPatientsValue);
            cardPatients.Controls.Add(lblPatientsIcon);
            cardPatients.Location = new Point(0, 0);
            cardPatients.Margin = new Padding(0, 0, 14, 0);
            cardPatients.Name = "cardPatients";
            cardPatients.Size = new Size(180, 128);
            cardPatients.TabIndex = 0;
            cardPatients.Paint += Card_Paint;
            // 
            // lblPatientsTitle
            // 
            lblPatientsTitle.AutoEllipsis = true;
            lblPatientsTitle.Font = new Font("Segoe UI", 9F);
            lblPatientsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblPatientsTitle.Location = new Point(18, 16);
            lblPatientsTitle.Name = "lblPatientsTitle";
            lblPatientsTitle.Size = new Size(102, 24);
            lblPatientsTitle.TabIndex = 0;
            lblPatientsTitle.Text = "Tổng bệnh nhân";
            // 
            // lblPatientsValue
            // 
            lblPatientsValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPatientsValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblPatientsValue.Location = new Point(18, 53);
            lblPatientsValue.Name = "lblPatientsValue";
            lblPatientsValue.Size = new Size(120, 58);
            lblPatientsValue.TabIndex = 1;
            lblPatientsValue.Text = "0";
            lblPatientsValue.Click += lblPatientsValue_Click;
            // 
            // lblPatientsIcon
            // 
            lblPatientsIcon.BackColor = Color.White;
            lblPatientsIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPatientsIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblPatientsIcon.Location = new Point(120, 16);
            lblPatientsIcon.Name = "lblPatientsIcon";
            lblPatientsIcon.Size = new Size(48, 48);
            lblPatientsIcon.TabIndex = 2;
            lblPatientsIcon.Text = "BN";
            lblPatientsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardAppointments
            // 
            cardAppointments.BackColor = Color.FromArgb(236, 253, 245);
            cardAppointments.Controls.Add(lblAppointmentsTitle);
            cardAppointments.Controls.Add(lblAppointmentsValue);
            cardAppointments.Controls.Add(lblAppointmentsIcon);
            cardAppointments.Location = new Point(194, 0);
            cardAppointments.Margin = new Padding(0, 0, 14, 0);
            cardAppointments.Name = "cardAppointments";
            cardAppointments.Size = new Size(180, 128);
            cardAppointments.TabIndex = 1;
            cardAppointments.Paint += Card_Paint;
            // 
            // lblAppointmentsTitle
            // 
            lblAppointmentsTitle.AutoEllipsis = true;
            lblAppointmentsTitle.Font = new Font("Segoe UI", 9F);
            lblAppointmentsTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblAppointmentsTitle.Location = new Point(18, 16);
            lblAppointmentsTitle.Name = "lblAppointmentsTitle";
            lblAppointmentsTitle.Size = new Size(102, 24);
            lblAppointmentsTitle.TabIndex = 0;
            lblAppointmentsTitle.Text = "Lịch khám tháng này";
            // 
            // lblAppointmentsValue
            // 
            lblAppointmentsValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAppointmentsValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblAppointmentsValue.Location = new Point(18, 53);
            lblAppointmentsValue.Name = "lblAppointmentsValue";
            lblAppointmentsValue.Size = new Size(120, 58);
            lblAppointmentsValue.TabIndex = 1;
            lblAppointmentsValue.Text = "0";
            // 
            // lblAppointmentsIcon
            // 
            lblAppointmentsIcon.BackColor = Color.White;
            lblAppointmentsIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAppointmentsIcon.ForeColor = Color.FromArgb(5, 150, 105);
            lblAppointmentsIcon.Location = new Point(120, 16);
            lblAppointmentsIcon.Name = "lblAppointmentsIcon";
            lblAppointmentsIcon.Size = new Size(48, 48);
            lblAppointmentsIcon.TabIndex = 2;
            lblAppointmentsIcon.Text = "LK";
            lblAppointmentsIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardWaiting
            // 
            cardWaiting.BackColor = Color.FromArgb(255, 251, 235);
            cardWaiting.Controls.Add(lblWaitingTitle);
            cardWaiting.Controls.Add(lblWaitingValue);
            cardWaiting.Controls.Add(lblWaitingIcon);
            cardWaiting.Location = new Point(388, 0);
            cardWaiting.Margin = new Padding(0, 0, 14, 0);
            cardWaiting.Name = "cardWaiting";
            cardWaiting.Size = new Size(180, 128);
            cardWaiting.TabIndex = 2;
            cardWaiting.Paint += Card_Paint;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.AutoEllipsis = true;
            lblWaitingTitle.Font = new Font("Segoe UI", 9F);
            lblWaitingTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblWaitingTitle.Location = new Point(18, 16);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(102, 24);
            lblWaitingTitle.TabIndex = 0;
            lblWaitingTitle.Text = "Bệnh nhân đang chờ";
            // 
            // lblWaitingValue
            // 
            lblWaitingValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWaitingValue.ForeColor = Color.FromArgb(217, 119, 6);
            lblWaitingValue.Location = new Point(18, 53);
            lblWaitingValue.Name = "lblWaitingValue";
            lblWaitingValue.Size = new Size(120, 58);
            lblWaitingValue.TabIndex = 1;
            lblWaitingValue.Text = "0";
            // 
            // lblWaitingIcon
            // 
            lblWaitingIcon.BackColor = Color.White;
            lblWaitingIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblWaitingIcon.ForeColor = Color.FromArgb(217, 119, 6);
            lblWaitingIcon.Location = new Point(120, 16);
            lblWaitingIcon.Name = "lblWaitingIcon";
            lblWaitingIcon.Size = new Size(48, 48);
            lblWaitingIcon.TabIndex = 2;
            lblWaitingIcon.Text = "CD";
            lblWaitingIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardEmployees
            // 
            cardEmployees.BackColor = Color.FromArgb(240, 253, 250);
            cardEmployees.Controls.Add(lblEmployeesTitle);
            cardEmployees.Controls.Add(lblEmployeesValue);
            cardEmployees.Controls.Add(lblEmployeesIcon);
            cardEmployees.Location = new Point(582, 0);
            cardEmployees.Margin = new Padding(0, 0, 14, 0);
            cardEmployees.Name = "cardEmployees";
            cardEmployees.Size = new Size(180, 128);
            cardEmployees.TabIndex = 3;
            cardEmployees.Paint += Card_Paint;
            // 
            // lblEmployeesTitle
            // 
            lblEmployeesTitle.AutoEllipsis = true;
            lblEmployeesTitle.Font = new Font("Segoe UI", 9F);
            lblEmployeesTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblEmployeesTitle.Location = new Point(18, 16);
            lblEmployeesTitle.Name = "lblEmployeesTitle";
            lblEmployeesTitle.Size = new Size(102, 24);
            lblEmployeesTitle.TabIndex = 0;
            lblEmployeesTitle.Text = "Nhân sự hoạt động";
            // 
            // lblEmployeesValue
            // 
            lblEmployeesValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblEmployeesValue.ForeColor = Color.FromArgb(15, 118, 110);
            lblEmployeesValue.Location = new Point(18, 53);
            lblEmployeesValue.Name = "lblEmployeesValue";
            lblEmployeesValue.Size = new Size(120, 58);
            lblEmployeesValue.TabIndex = 1;
            lblEmployeesValue.Text = "0";
            // 
            // lblEmployeesIcon
            // 
            lblEmployeesIcon.BackColor = Color.White;
            lblEmployeesIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmployeesIcon.ForeColor = Color.FromArgb(15, 118, 110);
            lblEmployeesIcon.Location = new Point(120, 16);
            lblEmployeesIcon.Name = "lblEmployeesIcon";
            lblEmployeesIcon.Size = new Size(48, 48);
            lblEmployeesIcon.TabIndex = 2;
            lblEmployeesIcon.Text = "NS";
            lblEmployeesIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardMedicine
            // 
            cardMedicine.BackColor = Color.FromArgb(254, 242, 242);
            cardMedicine.Controls.Add(lblMedicineKpiTitle);
            cardMedicine.Controls.Add(lblMedicineValue);
            cardMedicine.Controls.Add(lblMedicineIcon);
            cardMedicine.Location = new Point(776, 0);
            cardMedicine.Margin = new Padding(0, 0, 14, 0);
            cardMedicine.Name = "cardMedicine";
            cardMedicine.Size = new Size(180, 128);
            cardMedicine.TabIndex = 4;
            cardMedicine.Paint += Card_Paint;
            // 
            // lblMedicineKpiTitle
            // 
            lblMedicineKpiTitle.AutoEllipsis = true;
            lblMedicineKpiTitle.Font = new Font("Segoe UI", 9F);
            lblMedicineKpiTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblMedicineKpiTitle.Location = new Point(18, 16);
            lblMedicineKpiTitle.Name = "lblMedicineKpiTitle";
            lblMedicineKpiTitle.Size = new Size(102, 24);
            lblMedicineKpiTitle.TabIndex = 0;
            lblMedicineKpiTitle.Text = "Thuốc sắp hết";
            // 
            // lblMedicineValue
            // 
            lblMedicineValue.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblMedicineValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblMedicineValue.Location = new Point(20, 53);
            lblMedicineValue.Name = "lblMedicineValue";
            lblMedicineValue.Size = new Size(120, 58);
            lblMedicineValue.TabIndex = 1;
            lblMedicineValue.Text = "0";
            // 
            // lblMedicineIcon
            // 
            lblMedicineIcon.BackColor = Color.White;
            lblMedicineIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblMedicineIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblMedicineIcon.Location = new Point(120, 16);
            lblMedicineIcon.Name = "lblMedicineIcon";
            lblMedicineIcon.Size = new Size(48, 48);
            lblMedicineIcon.TabIndex = 2;
            lblMedicineIcon.Text = "TH";
            lblMedicineIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // apptCard
            // 
            apptCard.BackColor = Color.White;
            apptCard.Controls.Add(dgvAppointments);
            apptCard.Controls.Add(lblApptTitle);
            apptCard.Location = new Point(22, 283);
            apptCard.Margin = new Padding(0, 0, 0, 16);
            apptCard.Name = "apptCard";
            apptCard.Size = new Size(960, 360);
            apptCard.TabIndex = 2;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 251, 252);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dgvAppointments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAppointments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAppointments.BackgroundColor = Color.White;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAppointments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(249, 250, 251);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(107, 114, 128);
            dataGridViewCellStyle2.Padding = new Padding(14, 0, 0, 0);
            dgvAppointments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAppointments.ColumnHeadersHeight = 44;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { colTime, colPatient, colDoctor, colDept, colStatus });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.5F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(55, 65, 81);
            dataGridViewCellStyle4.Padding = new Padding(14, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(239, 246, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 24, 39);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAppointments.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAppointments.Dock = DockStyle.Fill;
            dgvAppointments.EnableHeadersVisualStyles = false;
            dgvAppointments.GridColor = Color.FromArgb(243, 244, 246);
            dgvAppointments.Location = new Point(0, 43);
            dgvAppointments.Margin = new Padding(2);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.ReadOnly = true;
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowHeadersWidth = 51;
            dgvAppointments.RowTemplate.Height = 54;
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.Size = new Size(960, 317);
            dgvAppointments.TabIndex = 0;
            dgvAppointments.CellFormatting += dgvAppointments_CellFormatting;
            // 
            // colTime
            // 
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(17, 24, 39);
            colTime.DefaultCellStyle = dataGridViewCellStyle3;
            colTime.FillWeight = 10F;
            colTime.HeaderText = "GIỜ KHÁM";
            colTime.MinimumWidth = 6;
            colTime.Name = "colTime";
            colTime.ReadOnly = true;
            // 
            // colPatient
            // 
            colPatient.FillWeight = 24F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.MinimumWidth = 6;
            colPatient.Name = "colPatient";
            colPatient.ReadOnly = true;
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 24F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.MinimumWidth = 6;
            colDoctor.Name = "colDoctor";
            colDoctor.ReadOnly = true;
            // 
            // colDept
            // 
            colDept.FillWeight = 22F;
            colDept.HeaderText = "CHUYÊN KHOA";
            colDept.MinimumWidth = 6;
            colDept.Name = "colDept";
            colDept.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 15F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblApptTitle
            // 
            lblApptTitle.Dock = DockStyle.Top;
            lblApptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblApptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblApptTitle.Location = new Point(0, 0);
            lblApptTitle.Margin = new Padding(2, 0, 2, 0);
            lblApptTitle.Name = "lblApptTitle";
            lblApptTitle.Padding = new Padding(19, 13, 0, 0);
            lblApptTitle.Size = new Size(960, 43);
            lblApptTitle.TabIndex = 1;
            lblApptTitle.Text = "Lịch khám hôm nay";
            // 
            // medCard
            // 
            medCard.BackColor = Color.White;
            medCard.Controls.Add(panelMedicineList);
            medCard.Controls.Add(lblMedTitle);
            medCard.Location = new Point(22, 659);
            medCard.Margin = new Padding(0, 0, 0, 16);
            medCard.Name = "medCard";
            medCard.Size = new Size(960, 220);
            medCard.TabIndex = 3;
            // 
            // panelMedicineList
            // 
            panelMedicineList.BackColor = Color.White;
            panelMedicineList.Dock = DockStyle.Fill;
            panelMedicineList.FlowDirection = FlowDirection.TopDown;
            panelMedicineList.Location = new Point(0, 43);
            panelMedicineList.Margin = new Padding(2);
            panelMedicineList.Name = "panelMedicineList";
            panelMedicineList.Padding = new Padding(16, 3, 16, 10);
            panelMedicineList.Size = new Size(960, 177);
            panelMedicineList.TabIndex = 0;
            panelMedicineList.WrapContents = false;
            // 
            // lblMedTitle
            // 
            lblMedTitle.Dock = DockStyle.Top;
            lblMedTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblMedTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblMedTitle.Location = new Point(0, 0);
            lblMedTitle.Margin = new Padding(2, 0, 2, 0);
            lblMedTitle.Name = "lblMedTitle";
            lblMedTitle.Padding = new Padding(19, 13, 0, 0);
            lblMedTitle.Size = new Size(960, 43);
            lblMedTitle.TabIndex = 1;
            lblMedTitle.Text = "Thuốc sắp hết";
            // 
            // deptCard
            // 
            deptCard.BackColor = Color.White;
            deptCard.Controls.Add(panelDeptCards);
            deptCard.Controls.Add(lblDeptTitle);
            deptCard.Location = new Point(22, 895);
            deptCard.Margin = new Padding(0, 0, 0, 16);
            deptCard.Name = "deptCard";
            deptCard.Size = new Size(960, 170);
            deptCard.TabIndex = 4;
            // 
            // panelDeptCards
            // 
            panelDeptCards.BackColor = Color.White;
            panelDeptCards.Dock = DockStyle.Fill;
            panelDeptCards.Location = new Point(0, 43);
            panelDeptCards.Margin = new Padding(2);
            panelDeptCards.Name = "panelDeptCards";
            panelDeptCards.Padding = new Padding(16, 3, 16, 10);
            panelDeptCards.Size = new Size(960, 127);
            panelDeptCards.TabIndex = 0;
            panelDeptCards.WrapContents = false;
            panelDeptCards.Resize += panelDeptCards_Resize;
            // 
            // lblDeptTitle
            // 
            lblDeptTitle.Dock = DockStyle.Top;
            lblDeptTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblDeptTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblDeptTitle.Location = new Point(0, 0);
            lblDeptTitle.Margin = new Padding(2, 0, 2, 0);
            lblDeptTitle.Name = "lblDeptTitle";
            lblDeptTitle.Padding = new Padding(19, 13, 0, 0);
            lblDeptTitle.Size = new Size(960, 43);
            lblDeptTitle.TabIndex = 1;
            lblDeptTitle.Text = "Nhân viên theo chuyên khoa";
            // 
            // queueCard
            // 
            queueCard.BackColor = Color.White;
            queueCard.Controls.Add(panelQueueCards);
            queueCard.Controls.Add(lblQueueTitle);
            queueCard.Location = new Point(22, 1081);
            queueCard.Margin = new Padding(0, 0, 0, 16);
            queueCard.Name = "queueCard";
            queueCard.Size = new Size(960, 170);
            queueCard.TabIndex = 5;
            // 
            // panelQueueCards
            // 
            panelQueueCards.BackColor = Color.White;
            panelQueueCards.Controls.Add(cardWaitingQ);
            panelQueueCards.Controls.Add(cardInProgressQ);
            panelQueueCards.Controls.Add(cardDoneQ);
            panelQueueCards.Controls.Add(cardCancelledQ);
            panelQueueCards.Dock = DockStyle.Fill;
            panelQueueCards.Location = new Point(0, 43);
            panelQueueCards.Margin = new Padding(2);
            panelQueueCards.Name = "panelQueueCards";
            panelQueueCards.Padding = new Padding(16, 3, 16, 10);
            panelQueueCards.Size = new Size(960, 127);
            panelQueueCards.TabIndex = 0;
            // 
            // cardWaitingQ
            // 
            cardWaitingQ.BackColor = Color.FromArgb(239, 246, 255);
            cardWaitingQ.Controls.Add(lblWaitingQTitle);
            cardWaitingQ.Controls.Add(lblWaitingQValue);
            cardWaitingQ.Location = new Point(16, 3);
            cardWaitingQ.Margin = new Padding(0, 0, 12, 0);
            cardWaitingQ.Name = "cardWaitingQ";
            cardWaitingQ.Size = new Size(216, 120);
            cardWaitingQ.TabIndex = 0;
            cardWaitingQ.Paint += Card_Paint;
            // 
            // lblWaitingQTitle
            // 
            lblWaitingQTitle.Font = new Font("Segoe UI", 10F);
            lblWaitingQTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblWaitingQTitle.Location = new Point(18, 18);
            lblWaitingQTitle.Name = "lblWaitingQTitle";
            lblWaitingQTitle.Size = new Size(160, 24);
            lblWaitingQTitle.TabIndex = 0;
            lblWaitingQTitle.Text = "Chờ khám";
            // 
            // lblWaitingQValue
            // 
            lblWaitingQValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblWaitingQValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblWaitingQValue.Location = new Point(18, 50);
            lblWaitingQValue.Name = "lblWaitingQValue";
            lblWaitingQValue.Size = new Size(160, 58);
            lblWaitingQValue.TabIndex = 1;
            lblWaitingQValue.Text = "0";
            // 
            // cardInProgressQ
            // 
            cardInProgressQ.BackColor = Color.FromArgb(255, 251, 235);
            cardInProgressQ.Controls.Add(lblInProgressQTitle);
            cardInProgressQ.Controls.Add(lblInProgressQValue);
            cardInProgressQ.Location = new Point(244, 3);
            cardInProgressQ.Margin = new Padding(0, 0, 12, 0);
            cardInProgressQ.Name = "cardInProgressQ";
            cardInProgressQ.Size = new Size(216, 120);
            cardInProgressQ.TabIndex = 1;
            cardInProgressQ.Paint += Card_Paint;
            // 
            // lblInProgressQTitle
            // 
            lblInProgressQTitle.Font = new Font("Segoe UI", 10F);
            lblInProgressQTitle.ForeColor = Color.FromArgb(217, 119, 6);
            lblInProgressQTitle.Location = new Point(18, 18);
            lblInProgressQTitle.Name = "lblInProgressQTitle";
            lblInProgressQTitle.Size = new Size(160, 24);
            lblInProgressQTitle.TabIndex = 0;
            lblInProgressQTitle.Text = "Đang khám";
            // 
            // lblInProgressQValue
            // 
            lblInProgressQValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblInProgressQValue.ForeColor = Color.FromArgb(217, 119, 6);
            lblInProgressQValue.Location = new Point(18, 50);
            lblInProgressQValue.Name = "lblInProgressQValue";
            lblInProgressQValue.Size = new Size(160, 58);
            lblInProgressQValue.TabIndex = 1;
            lblInProgressQValue.Text = "0";
            // 
            // cardDoneQ
            // 
            cardDoneQ.BackColor = Color.FromArgb(236, 253, 245);
            cardDoneQ.Controls.Add(lblDoneQTitle);
            cardDoneQ.Controls.Add(lblDoneQValue);
            cardDoneQ.Location = new Point(472, 3);
            cardDoneQ.Margin = new Padding(0, 0, 12, 0);
            cardDoneQ.Name = "cardDoneQ";
            cardDoneQ.Size = new Size(216, 120);
            cardDoneQ.TabIndex = 2;
            cardDoneQ.Paint += Card_Paint;
            // 
            // lblDoneQTitle
            // 
            lblDoneQTitle.Font = new Font("Segoe UI", 10F);
            lblDoneQTitle.ForeColor = Color.FromArgb(5, 150, 105);
            lblDoneQTitle.Location = new Point(18, 18);
            lblDoneQTitle.Name = "lblDoneQTitle";
            lblDoneQTitle.Size = new Size(160, 24);
            lblDoneQTitle.TabIndex = 0;
            lblDoneQTitle.Text = "Hoàn thành";
            // 
            // lblDoneQValue
            // 
            lblDoneQValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblDoneQValue.ForeColor = Color.FromArgb(5, 150, 105);
            lblDoneQValue.Location = new Point(18, 50);
            lblDoneQValue.Name = "lblDoneQValue";
            lblDoneQValue.Size = new Size(160, 58);
            lblDoneQValue.TabIndex = 1;
            lblDoneQValue.Text = "0";
            // 
            // cardCancelledQ
            // 
            cardCancelledQ.BackColor = Color.FromArgb(254, 242, 242);
            cardCancelledQ.Controls.Add(lblCancelledQTitle);
            cardCancelledQ.Controls.Add(lblCancelledQValue);
            cardCancelledQ.Location = new Point(700, 3);
            cardCancelledQ.Margin = new Padding(0, 0, 12, 0);
            cardCancelledQ.Name = "cardCancelledQ";
            cardCancelledQ.Size = new Size(216, 120);
            cardCancelledQ.TabIndex = 3;
            cardCancelledQ.Paint += Card_Paint;
            // 
            // lblCancelledQTitle
            // 
            lblCancelledQTitle.Font = new Font("Segoe UI", 10F);
            lblCancelledQTitle.ForeColor = Color.FromArgb(220, 38, 38);
            lblCancelledQTitle.Location = new Point(18, 18);
            lblCancelledQTitle.Name = "lblCancelledQTitle";
            lblCancelledQTitle.Size = new Size(160, 24);
            lblCancelledQTitle.TabIndex = 0;
            lblCancelledQTitle.Text = "Đã hủy";
            // 
            // lblCancelledQValue
            // 
            lblCancelledQValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblCancelledQValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblCancelledQValue.Location = new Point(18, 50);
            lblCancelledQValue.Name = "lblCancelledQValue";
            lblCancelledQValue.Size = new Size(160, 58);
            lblCancelledQValue.TabIndex = 1;
            lblCancelledQValue.Text = "0";
            // 
            // lblQueueTitle
            // 
            lblQueueTitle.Dock = DockStyle.Top;
            lblQueueTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblQueueTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblQueueTitle.Location = new Point(0, 0);
            lblQueueTitle.Margin = new Padding(2, 0, 2, 0);
            lblQueueTitle.Name = "lblQueueTitle";
            lblQueueTitle.Padding = new Padding(19, 13, 0, 0);
            lblQueueTitle.Size = new Size(960, 43);
            lblQueueTitle.TabIndex = 1;
            lblQueueTitle.Text = "Bệnh nhân chờ khám";
            // 
            // ucAdminDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            Controls.Add(outerScroll);
            Margin = new Padding(2);
            Name = "ucAdminDashboard";
            Size = new Size(1024, 720);
            outerScroll.ResumeLayout(false);
            outerScroll.PerformLayout();
            mainFlow.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            kpiFlow.ResumeLayout(false);
            cardPatients.ResumeLayout(false);
            cardAppointments.ResumeLayout(false);
            cardWaiting.ResumeLayout(false);
            cardEmployees.ResumeLayout(false);
            cardMedicine.ResumeLayout(false);
            apptCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            medCard.ResumeLayout(false);
            deptCard.ResumeLayout(false);
            queueCard.ResumeLayout(false);
            panelQueueCards.ResumeLayout(false);
            cardWaitingQ.ResumeLayout(false);
            cardInProgressQ.ResumeLayout(false);
            cardDoneQ.ResumeLayout(false);
            cardCancelledQ.ResumeLayout(false);
            ResumeLayout(false);
        }

        // ════════════════════════════════════════════════════════════════
        //  Helpers
        // ════════════════════════════════════════════════════════════════

        private Control CreateLine(string title, string value)
        {
            Panel row = new Panel
            {
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 8),
                Size = new Size(520, 28)
            };

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(0, 2),
                Size = new Size(340, 24),
                Text = title
            });

            row.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(107, 114, 128),
                Location = new Point(348, 2),
                Size = new Size(160, 24),
                Text = value,
                TextAlign = ContentAlignment.MiddleRight
            });

            return row;
        }

        private Control CreateMiniCard(string title, string value, Color accent)
        {
            Panel card = new Panel
            {
                BackColor = Color.FromArgb(249, 250, 251),
                Margin = new Padding(0, 0, 12, 0),
                Size = new Size(180, 96)
            };
            card.Paint += Card_Paint;
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(14, 14),
                Size = new Size(150, 25),
                Text = title
            });
            card.Controls.Add(new Label
            {
                AutoEllipsis = true,
                Font = new Font("Segoe UI", 13F, FontStyle.Bold),
                ForeColor = accent,
                Location = new Point(14, 48),
                Size = new Size(150, 30),
                Text = value
            });
            return card;
        }

        // ════════════════════════════════════════════════════════════════
        //  Fields
        // ════════════════════════════════════════════════════════════════
        private Panel outerScroll;
        private FlowLayoutPanel mainFlow;
        private Panel kpiFlow;
        private Panel panelHeader;
        private Panel apptCard, medCard, deptCard, queueCard;
        private FlowLayoutPanel panelMedicineList, panelDeptCards;
        private Panel panelQueueCards;
        private Label lblTitle, lblSubtitle, lblApptTitle, lblMedTitle, lblDeptTitle, lblQueueTitle;
        private Button btnRefresh;
        private DataGridView dgvAppointments;
        private DataGridViewTextBoxColumn colTime, colPatient, colDoctor, colDept, colStatus;
        internal Panel cardPatients, cardAppointments, cardWaiting, cardEmployees, cardMedicine;
        internal Label lblPatientsTitle, lblPatientsValue, lblPatientsIcon;
        internal Label lblAppointmentsTitle, lblAppointmentsValue, lblAppointmentsIcon;
        internal Label lblWaitingTitle, lblWaitingValue, lblWaitingIcon;
        internal Label lblEmployeesTitle, lblEmployeesValue, lblEmployeesIcon;
        internal Label lblMedicineKpiTitle, lblMedicineValue, lblMedicineIcon;
        internal Panel cardWaitingQ, cardInProgressQ, cardDoneQ, cardCancelledQ;
        internal Label lblWaitingQTitle, lblWaitingQValue;
        internal Label lblInProgressQTitle, lblInProgressQValue;
        internal Label lblDoneQTitle, lblDoneQValue;
        internal Label lblCancelledQTitle, lblCancelledQValue;
    }
}
