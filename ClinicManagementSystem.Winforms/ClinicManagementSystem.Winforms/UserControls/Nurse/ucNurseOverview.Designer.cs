using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Nurse
{
    partial class ucNurseOverview
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
            DataGridViewCellStyle headerStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle headerStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle rowStyle2 = new DataGridViewCellStyle();
            rootPanel = new Panel();
            kpiPanel = new Panel();
            cardWaiting = new Panel();
            lblWaitingTitle = new Label();
            lblWaitingVitalCount = new Label();
            lblWaitingSub = new Label();
            cardCompleted = new Panel();
            lblCompletedTitle = new Label();
            lblCompletedCount = new Label();
            lblCompletedSub = new Label();
            cardRooms = new Panel();
            lblRoomsTitle = new Label();
            lblRoomsCount = new Label();
            lblRoomsSub = new Label();
            cardAlert = new Panel();
            lblAlertTitle = new Label();
            lblAlertCount = new Label();
            lblAlertSub = new Label();
            shiftCard = new Panel();
            lblShiftTitle = new Label();
            lblTodayShift = new Label();
            lblTodayTime = new Label();
            lblTodayRoom = new Label();
            lblTodayDepartment = new Label();
            lblAssignmentCount = new Label();
            btnRefresh = new Button();
            assignmentCard = new Panel();
            lblAssignmentTitle = new Label();
            dgvAssignments = new DataGridView();
            colTask = new DataGridViewTextBoxColumn();
            colPatient = new DataGridViewTextBoxColumn();
            colScope = new DataGridViewTextBoxColumn();
            colPriority = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            roomCard = new Panel();
            lblRoomTitle = new Label();
            dgvRooms = new DataGridView();
            colDoctor = new DataGridViewTextBoxColumn();
            colDepartment = new DataGridViewTextBoxColumn();
            colRoom = new DataGridViewTextBoxColumn();
            colWaiting = new DataGridViewTextBoxColumn();
            colCurrent = new DataGridViewTextBoxColumn();
            rootPanel.SuspendLayout();
            kpiPanel.SuspendLayout();
            cardWaiting.SuspendLayout();
            cardCompleted.SuspendLayout();
            cardRooms.SuspendLayout();
            cardAlert.SuspendLayout();
            shiftCard.SuspendLayout();
            assignmentCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).BeginInit();
            roomCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRooms).BeginInit();
            SuspendLayout();
            // 
            // rootPanel
            // 
            rootPanel.AutoScroll = true;
            rootPanel.BackColor = Color.FromArgb(246, 248, 252);
            rootPanel.Controls.Add(roomCard);
            rootPanel.Controls.Add(assignmentCard);
            rootPanel.Controls.Add(shiftCard);
            rootPanel.Controls.Add(kpiPanel);
            rootPanel.Dock = DockStyle.Fill;
            rootPanel.Location = new Point(0, 0);
            rootPanel.Name = "rootPanel";
            rootPanel.Padding = new Padding(28, 24, 28, 28);
            rootPanel.Size = new Size(1180, 820);
            rootPanel.TabIndex = 0;
            // 
            // kpiPanel
            // 
            kpiPanel.BackColor = Color.Transparent;
            kpiPanel.Controls.Add(cardWaiting);
            kpiPanel.Controls.Add(cardCompleted);
            kpiPanel.Controls.Add(cardRooms);
            kpiPanel.Controls.Add(cardAlert);
            kpiPanel.Dock = DockStyle.Top;
            kpiPanel.Location = new Point(28, 24);
            kpiPanel.Name = "kpiPanel";
            kpiPanel.Size = new Size(1124, 128);
            kpiPanel.TabIndex = 0;
            // 
            // cardWaiting
            // 
            cardWaiting.BackColor = Color.FromArgb(239, 246, 255);
            cardWaiting.Controls.Add(lblWaitingTitle);
            cardWaiting.Controls.Add(lblWaitingVitalCount);
            cardWaiting.Controls.Add(lblWaitingSub);
            cardWaiting.Location = new Point(0, 0);
            cardWaiting.Name = "cardWaiting";
            cardWaiting.Size = new Size(260, 112);
            cardWaiting.TabIndex = 0;
            cardWaiting.Paint += Card_Paint;
            // 
            // lblWaitingTitle
            // 
            lblWaitingTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblWaitingTitle.ForeColor = Color.FromArgb(37, 99, 235);
            lblWaitingTitle.Location = new Point(18, 16);
            lblWaitingTitle.Name = "lblWaitingTitle";
            lblWaitingTitle.Size = new Size(200, 24);
            lblWaitingTitle.TabIndex = 0;
            lblWaitingTitle.Text = "Chờ đo sinh hiệu";
            // 
            // lblWaitingVitalCount
            // 
            lblWaitingVitalCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblWaitingVitalCount.ForeColor = Color.FromArgb(37, 99, 235);
            lblWaitingVitalCount.Location = new Point(18, 42);
            lblWaitingVitalCount.Name = "lblWaitingVitalCount";
            lblWaitingVitalCount.Size = new Size(120, 48);
            lblWaitingVitalCount.TabIndex = 1;
            lblWaitingVitalCount.Text = "0";
            // 
            // lblWaitingSub
            // 
            lblWaitingSub.Font = new Font("Segoe UI", 8.5F);
            lblWaitingSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblWaitingSub.Location = new Point(18, 88);
            lblWaitingSub.Name = "lblWaitingSub";
            lblWaitingSub.Size = new Size(220, 20);
            lblWaitingSub.TabIndex = 2;
            lblWaitingSub.Text = "Bệnh nhân đang chờ xử lý";
            // 
            // cardCompleted
            // 
            cardCompleted.BackColor = Color.FromArgb(240, 253, 244);
            cardCompleted.Controls.Add(lblCompletedTitle);
            cardCompleted.Controls.Add(lblCompletedCount);
            cardCompleted.Controls.Add(lblCompletedSub);
            cardCompleted.Location = new Point(278, 0);
            cardCompleted.Name = "cardCompleted";
            cardCompleted.Size = new Size(260, 112);
            cardCompleted.TabIndex = 1;
            cardCompleted.Paint += Card_Paint;
            // 
            // lblCompletedTitle
            // 
            lblCompletedTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCompletedTitle.ForeColor = Color.FromArgb(22, 163, 74);
            lblCompletedTitle.Location = new Point(18, 16);
            lblCompletedTitle.Name = "lblCompletedTitle";
            lblCompletedTitle.Size = new Size(200, 24);
            lblCompletedTitle.TabIndex = 0;
            lblCompletedTitle.Text = "Hoàn thành hôm nay";
            // 
            // lblCompletedCount
            // 
            lblCompletedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblCompletedCount.ForeColor = Color.FromArgb(22, 163, 74);
            lblCompletedCount.Location = new Point(18, 42);
            lblCompletedCount.Name = "lblCompletedCount";
            lblCompletedCount.Size = new Size(120, 48);
            lblCompletedCount.TabIndex = 1;
            lblCompletedCount.Text = "0";
            // 
            // lblCompletedSub
            // 
            lblCompletedSub.Font = new Font("Segoe UI", 8.5F);
            lblCompletedSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblCompletedSub.Location = new Point(18, 88);
            lblCompletedSub.Name = "lblCompletedSub";
            lblCompletedSub.Size = new Size(220, 20);
            lblCompletedSub.TabIndex = 2;
            lblCompletedSub.Text = "Lượt khám đã xong";
            // 
            // cardRooms
            // 
            cardRooms.BackColor = Color.FromArgb(240, 253, 250);
            cardRooms.Controls.Add(lblRoomsTitle);
            cardRooms.Controls.Add(lblRoomsCount);
            cardRooms.Controls.Add(lblRoomsSub);
            cardRooms.Location = new Point(556, 0);
            cardRooms.Name = "cardRooms";
            cardRooms.Size = new Size(260, 112);
            cardRooms.TabIndex = 2;
            cardRooms.Paint += Card_Paint;
            // 
            // lblRoomsTitle
            // 
            lblRoomsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblRoomsTitle.ForeColor = Color.FromArgb(15, 118, 110);
            lblRoomsTitle.Location = new Point(18, 16);
            lblRoomsTitle.Name = "lblRoomsTitle";
            lblRoomsTitle.Size = new Size(200, 24);
            lblRoomsTitle.TabIndex = 0;
            lblRoomsTitle.Text = "Phòng đang hỗ trợ";
            // 
            // lblRoomsCount
            // 
            lblRoomsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblRoomsCount.ForeColor = Color.FromArgb(15, 118, 110);
            lblRoomsCount.Location = new Point(18, 42);
            lblRoomsCount.Name = "lblRoomsCount";
            lblRoomsCount.Size = new Size(120, 48);
            lblRoomsCount.TabIndex = 1;
            lblRoomsCount.Text = "0";
            // 
            // lblRoomsSub
            // 
            lblRoomsSub.Font = new Font("Segoe UI", 8.5F);
            lblRoomsSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblRoomsSub.Location = new Point(18, 88);
            lblRoomsSub.Name = "lblRoomsSub";
            lblRoomsSub.Size = new Size(220, 20);
            lblRoomsSub.TabIndex = 2;
            lblRoomsSub.Text = "Bác sĩ có lịch hôm nay";
            // 
            // cardAlert
            // 
            cardAlert.BackColor = Color.FromArgb(254, 242, 242);
            cardAlert.Controls.Add(lblAlertTitle);
            cardAlert.Controls.Add(lblAlertCount);
            cardAlert.Controls.Add(lblAlertSub);
            cardAlert.Location = new Point(834, 0);
            cardAlert.Name = "cardAlert";
            cardAlert.Size = new Size(260, 112);
            cardAlert.TabIndex = 3;
            cardAlert.Paint += Card_Paint;
            // 
            // lblAlertTitle
            // 
            lblAlertTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAlertTitle.ForeColor = Color.FromArgb(220, 38, 38);
            lblAlertTitle.Location = new Point(18, 16);
            lblAlertTitle.Name = "lblAlertTitle";
            lblAlertTitle.Size = new Size(210, 24);
            lblAlertTitle.TabIndex = 0;
            lblAlertTitle.Text = "Đang khám/cần theo dõi";
            // 
            // lblAlertCount
            // 
            lblAlertCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblAlertCount.ForeColor = Color.FromArgb(220, 38, 38);
            lblAlertCount.Location = new Point(18, 42);
            lblAlertCount.Name = "lblAlertCount";
            lblAlertCount.Size = new Size(120, 48);
            lblAlertCount.TabIndex = 1;
            lblAlertCount.Text = "0";
            // 
            // lblAlertSub
            // 
            lblAlertSub.Font = new Font("Segoe UI", 8.5F);
            lblAlertSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblAlertSub.Location = new Point(18, 88);
            lblAlertSub.Name = "lblAlertSub";
            lblAlertSub.Size = new Size(220, 20);
            lblAlertSub.TabIndex = 2;
            lblAlertSub.Text = "Lượt khám đang diễn ra";
            // 
            // shiftCard
            // 
            shiftCard.BackColor = Color.White;
            shiftCard.Controls.Add(lblShiftTitle);
            shiftCard.Controls.Add(lblTodayShift);
            shiftCard.Controls.Add(lblTodayTime);
            shiftCard.Controls.Add(lblTodayRoom);
            shiftCard.Controls.Add(lblTodayDepartment);
            shiftCard.Controls.Add(lblAssignmentCount);
            shiftCard.Controls.Add(btnRefresh);
            shiftCard.Dock = DockStyle.Top;
            shiftCard.Location = new Point(28, 152);
            shiftCard.Margin = new Padding(0, 0, 0, 18);
            shiftCard.Name = "shiftCard";
            shiftCard.Size = new Size(1124, 150);
            shiftCard.TabIndex = 1;
            shiftCard.Paint += Card_Paint;
            // 
            // lblShiftTitle
            // 
            lblShiftTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblShiftTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblShiftTitle.Location = new Point(24, 18);
            lblShiftTitle.Name = "lblShiftTitle";
            lblShiftTitle.Size = new Size(280, 34);
            lblShiftTitle.TabIndex = 0;
            lblShiftTitle.Text = "Ca làm việc hôm nay";
            // 
            // lblTodayShift
            // 
            lblTodayShift.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTodayShift.ForeColor = Color.FromArgb(37, 99, 235);
            lblTodayShift.Location = new Point(24, 62);
            lblTodayShift.Name = "lblTodayShift";
            lblTodayShift.Size = new Size(190, 36);
            lblTodayShift.TabIndex = 1;
            lblTodayShift.Text = "Chưa phân ca";
            // 
            // lblTodayTime
            // 
            lblTodayTime.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTodayTime.ForeColor = Color.FromArgb(15, 23, 42);
            lblTodayTime.Location = new Point(24, 102);
            lblTodayTime.Name = "lblTodayTime";
            lblTodayTime.Size = new Size(190, 24);
            lblTodayTime.TabIndex = 2;
            lblTodayTime.Text = "--";
            // 
            // lblTodayRoom
            // 
            lblTodayRoom.Font = new Font("Segoe UI", 10F);
            lblTodayRoom.ForeColor = Color.FromArgb(100, 116, 139);
            lblTodayRoom.Location = new Point(280, 62);
            lblTodayRoom.Name = "lblTodayRoom";
            lblTodayRoom.Size = new Size(240, 28);
            lblTodayRoom.TabIndex = 3;
            lblTodayRoom.Text = "Phòng: --";
            // 
            // lblTodayDepartment
            // 
            lblTodayDepartment.Font = new Font("Segoe UI", 10F);
            lblTodayDepartment.ForeColor = Color.FromArgb(100, 116, 139);
            lblTodayDepartment.Location = new Point(280, 98);
            lblTodayDepartment.Name = "lblTodayDepartment";
            lblTodayDepartment.Size = new Size(300, 28);
            lblTodayDepartment.TabIndex = 4;
            lblTodayDepartment.Text = "Khoa: --";
            // 
            // lblAssignmentCount
            // 
            lblAssignmentCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAssignmentCount.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAssignmentCount.ForeColor = Color.FromArgb(217, 119, 6);
            lblAssignmentCount.Location = new Point(720, 42);
            lblAssignmentCount.Name = "lblAssignmentCount";
            lblAssignmentCount.Size = new Size(210, 70);
            lblAssignmentCount.TabIndex = 5;
            lblAssignmentCount.Text = "0 việc đang mở";
            lblAssignmentCount.TextAlign = ContentAlignment.MiddleRight;
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
            btnRefresh.Location = new Point(952, 54);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(142, 42);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // assignmentCard
            // 
            assignmentCard.BackColor = Color.White;
            assignmentCard.Controls.Add(dgvAssignments);
            assignmentCard.Controls.Add(lblAssignmentTitle);
            assignmentCard.Dock = DockStyle.Top;
            assignmentCard.Location = new Point(28, 302);
            assignmentCard.Name = "assignmentCard";
            assignmentCard.Size = new Size(1124, 280);
            assignmentCard.TabIndex = 2;
            assignmentCard.Paint += Card_Paint;
            // 
            // lblAssignmentTitle
            // 
            lblAssignmentTitle.Dock = DockStyle.Top;
            lblAssignmentTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblAssignmentTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblAssignmentTitle.Location = new Point(0, 0);
            lblAssignmentTitle.Name = "lblAssignmentTitle";
            lblAssignmentTitle.Padding = new Padding(22, 14, 0, 0);
            lblAssignmentTitle.Size = new Size(1124, 54);
            lblAssignmentTitle.TabIndex = 0;
            lblAssignmentTitle.Text = "Phân công điều dưỡng";
            // 
            // dgvAssignments
            // 
            dgvAssignments.AllowUserToAddRows = false;
            dgvAssignments.AllowUserToDeleteRows = false;
            dgvAssignments.BackgroundColor = Color.White;
            dgvAssignments.BorderStyle = BorderStyle.None;
            dgvAssignments.ColumnHeadersDefaultCellStyle = headerStyle1;
            dgvAssignments.ColumnHeadersHeight = 44;
            dgvAssignments.Columns.AddRange(new DataGridViewColumn[] { colTask, colPatient, colScope, colPriority, colStatus });
            dgvAssignments.DefaultCellStyle = rowStyle1;
            dgvAssignments.Dock = DockStyle.Fill;
            dgvAssignments.Location = new Point(0, 54);
            dgvAssignments.Name = "dgvAssignments";
            dgvAssignments.RowHeadersVisible = false;
            dgvAssignments.RowHeadersWidth = 51;
            dgvAssignments.RowTemplate.Height = 48;
            dgvAssignments.Size = new Size(1124, 226);
            dgvAssignments.TabIndex = 1;
            // 
            // colTask
            // 
            colTask.FillWeight = 28F;
            colTask.HeaderText = "CÔNG VIỆC";
            colTask.Name = "colTask";
            // 
            // colPatient
            // 
            colPatient.FillWeight = 18F;
            colPatient.HeaderText = "BỆNH NHÂN";
            colPatient.Name = "colPatient";
            // 
            // colScope
            // 
            colScope.FillWeight = 22F;
            colScope.HeaderText = "KHOA/PHÒNG";
            colScope.Name = "colScope";
            // 
            // colPriority
            // 
            colPriority.FillWeight = 12F;
            colPriority.HeaderText = "ƯU TIÊN";
            colPriority.Name = "colPriority";
            // 
            // colStatus
            // 
            colStatus.FillWeight = 14F;
            colStatus.HeaderText = "TRẠNG THÁI";
            colStatus.Name = "colStatus";
            // 
            // roomCard
            // 
            roomCard.BackColor = Color.White;
            roomCard.Controls.Add(dgvRooms);
            roomCard.Controls.Add(lblRoomTitle);
            roomCard.Dock = DockStyle.Top;
            roomCard.Location = new Point(28, 582);
            roomCard.Margin = new Padding(0, 18, 0, 0);
            roomCard.Name = "roomCard";
            roomCard.Size = new Size(1124, 280);
            roomCard.TabIndex = 3;
            roomCard.Paint += Card_Paint;
            // 
            // lblRoomTitle
            // 
            lblRoomTitle.Dock = DockStyle.Top;
            lblRoomTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblRoomTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblRoomTitle.Location = new Point(0, 0);
            lblRoomTitle.Name = "lblRoomTitle";
            lblRoomTitle.Padding = new Padding(22, 14, 0, 0);
            lblRoomTitle.Size = new Size(1124, 54);
            lblRoomTitle.TabIndex = 0;
            lblRoomTitle.Text = "Phòng khám đang hỗ trợ";
            // 
            // dgvRooms
            // 
            dgvRooms.AllowUserToAddRows = false;
            dgvRooms.AllowUserToDeleteRows = false;
            dgvRooms.BackgroundColor = Color.White;
            dgvRooms.BorderStyle = BorderStyle.None;
            dgvRooms.ColumnHeadersDefaultCellStyle = headerStyle2;
            dgvRooms.ColumnHeadersHeight = 44;
            dgvRooms.Columns.AddRange(new DataGridViewColumn[] { colDoctor, colDepartment, colRoom, colWaiting, colCurrent });
            dgvRooms.DefaultCellStyle = rowStyle2;
            dgvRooms.Dock = DockStyle.Fill;
            dgvRooms.Location = new Point(0, 54);
            dgvRooms.Name = "dgvRooms";
            dgvRooms.RowHeadersVisible = false;
            dgvRooms.RowHeadersWidth = 51;
            dgvRooms.RowTemplate.Height = 48;
            dgvRooms.Size = new Size(1124, 226);
            dgvRooms.TabIndex = 1;
            // 
            // colDoctor
            // 
            colDoctor.FillWeight = 22F;
            colDoctor.HeaderText = "BÁC SĨ";
            colDoctor.Name = "colDoctor";
            // 
            // colDepartment
            // 
            colDepartment.FillWeight = 20F;
            colDepartment.HeaderText = "KHOA";
            colDepartment.Name = "colDepartment";
            // 
            // colRoom
            // 
            colRoom.FillWeight = 12F;
            colRoom.HeaderText = "PHÒNG";
            colRoom.Name = "colRoom";
            // 
            // colWaiting
            // 
            colWaiting.FillWeight = 12F;
            colWaiting.HeaderText = "ĐANG CHỜ";
            colWaiting.Name = "colWaiting";
            // 
            // colCurrent
            // 
            colCurrent.FillWeight = 26F;
            colCurrent.HeaderText = "ĐANG KHÁM";
            colCurrent.Name = "colCurrent";
            // 
            // ucNurseOverview
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(246, 248, 252);
            Controls.Add(rootPanel);
            Name = "ucNurseOverview";
            Size = new Size(1180, 820);
            rootPanel.ResumeLayout(false);
            kpiPanel.ResumeLayout(false);
            cardWaiting.ResumeLayout(false);
            cardCompleted.ResumeLayout(false);
            cardRooms.ResumeLayout(false);
            cardAlert.ResumeLayout(false);
            shiftCard.ResumeLayout(false);
            assignmentCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAssignments).EndInit();
            roomCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRooms).EndInit();
            ResumeLayout(false);
        }

        private Panel rootPanel;
        private Panel kpiPanel;
        private Panel cardWaiting;
        private Panel cardCompleted;
        private Panel cardRooms;
        private Panel cardAlert;
        private Label lblWaitingTitle;
        private Label lblWaitingVitalCount;
        private Label lblWaitingSub;
        private Label lblCompletedTitle;
        private Label lblCompletedCount;
        private Label lblCompletedSub;
        private Label lblRoomsTitle;
        private Label lblRoomsCount;
        private Label lblRoomsSub;
        private Label lblAlertTitle;
        private Label lblAlertCount;
        private Label lblAlertSub;
        private Panel shiftCard;
        private Label lblShiftTitle;
        private Label lblTodayShift;
        private Label lblTodayTime;
        private Label lblTodayRoom;
        private Label lblTodayDepartment;
        private Label lblAssignmentCount;
        private Button btnRefresh;
        private Panel assignmentCard;
        private Label lblAssignmentTitle;
        private DataGridView dgvAssignments;
        private DataGridViewTextBoxColumn colTask;
        private DataGridViewTextBoxColumn colPatient;
        private DataGridViewTextBoxColumn colScope;
        private DataGridViewTextBoxColumn colPriority;
        private DataGridViewTextBoxColumn colStatus;
        private Panel roomCard;
        private Label lblRoomTitle;
        private DataGridView dgvRooms;
        private DataGridViewTextBoxColumn colDoctor;
        private DataGridViewTextBoxColumn colDepartment;
        private DataGridViewTextBoxColumn colRoom;
        private DataGridViewTextBoxColumn colWaiting;
        private DataGridViewTextBoxColumn colCurrent;
    }
}
