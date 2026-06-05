using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    partial class ReceptionistMainform : UserControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel10 = new Panel();
            btnLogout = new Button();
            panel9 = new Panel();
            btnNavShifts = new Button();
            panel8 = new Panel();
            btnReminder = new Button();
            panel7 = new Panel();
            btnQueue = new Button();
            panel6 = new Panel();
            btnToday = new Button();
            panel5 = new Panel();
            btnPayment = new Button();
            panel4 = new Panel();
            btnAppointment = new Button();
            panel3 = new Panel();
            btnPatientManagement = new Button();
            panel2 = new Panel();
            btnNavOverview = new Button();
            panel1 = new Panel();
            lblLogo = new Label();
            lblBrand = new Label();
            btnClose = new Button();
            lblBrandSub = new Label();
            panelTopbar = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel11 = new Panel();
            lblPageTitle = new Label();
            lblPageSubtitle = new Label();
            panel12 = new Panel();
            lblBell = new Label();
            lblNotifDot = new Label();
            panel13 = new Panel();
            lblAvatar = new Label();
            lblUserName = new Label();
            lblUserEmail = new Label();
            contentPanel = new Panel();
            panelSidebar.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel10.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panelTopbar.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel13.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.White;
            panelSidebar.BorderStyle = BorderStyle.FixedSingle;
            panelSidebar.Controls.Add(tableLayoutPanel1);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Margin = new Padding(3, 4, 3, 4);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(290, 1046);
            panelSidebar.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel10, 0, 9);
            tableLayoutPanel1.Controls.Add(panel9, 0, 8);
            tableLayoutPanel1.Controls.Add(panel8, 0, 7);
            tableLayoutPanel1.Controls.Add(panel7, 0, 6);
            tableLayoutPanel1.Controls.Add(panel6, 0, 5);
            tableLayoutPanel1.Controls.Add(panel5, 0, 4);
            tableLayoutPanel1.Controls.Add(panel4, 0, 3);
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 101F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.Size = new Size(288, 1044);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // panel10
            // 
            panel10.Controls.Add(btnLogout);
            panel10.Dock = DockStyle.Fill;
            panel10.Location = new Point(3, 936);
            panel10.Name = "panel10";
            panel10.Size = new Size(282, 105);
            panel10.TabIndex = 9;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogout.BackColor = Color.White;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(220, 38, 38);
            btnLogout.Location = new Point(17, 25);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(245, 56);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "Đăng xuất";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnNavShifts);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(3, 832);
            panel9.Name = "panel9";
            panel9.Size = new Size(282, 98);
            panel9.TabIndex = 8;
            // 
            // btnNavShifts
            // 
            btnNavShifts.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnNavShifts.BackColor = Color.White;
            btnNavShifts.Cursor = Cursors.Hand;
            btnNavShifts.FlatAppearance.BorderSize = 0;
            btnNavShifts.FlatStyle = FlatStyle.Flat;
            btnNavShifts.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavShifts.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavShifts.Location = new Point(17, 16);
            btnNavShifts.Margin = new Padding(3, 4, 3, 4);
            btnNavShifts.Name = "btnNavShifts";
            btnNavShifts.Padding = new Padding(18, 0, 0, 0);
            btnNavShifts.Size = new Size(245, 59);
            btnNavShifts.TabIndex = 6;
            btnNavShifts.Text = "Ca làm việc";
            btnNavShifts.UseVisualStyleBackColor = false;
            // 
            // panel8
            // 
            panel8.Controls.Add(btnReminder);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 728);
            panel8.Name = "panel8";
            panel8.Size = new Size(282, 98);
            panel8.TabIndex = 7;
            // 
            // btnReminder
            // 
            btnReminder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnReminder.BackColor = Color.White;
            btnReminder.Cursor = Cursors.Hand;
            btnReminder.FlatAppearance.BorderSize = 0;
            btnReminder.FlatStyle = FlatStyle.Flat;
            btnReminder.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnReminder.ForeColor = Color.FromArgb(55, 65, 81);
            btnReminder.Location = new Point(17, 20);
            btnReminder.Margin = new Padding(3, 4, 3, 4);
            btnReminder.Name = "btnReminder";
            btnReminder.Padding = new Padding(18, 0, 0, 0);
            btnReminder.Size = new Size(245, 59);
            btnReminder.TabIndex = 8;
            btnReminder.Text = "Nhắc lịch tái khám";
            btnReminder.UseVisualStyleBackColor = false;
            btnReminder.Click += btnReminder_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(btnQueue);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(3, 624);
            panel7.Name = "panel7";
            panel7.Size = new Size(282, 98);
            panel7.TabIndex = 6;
            // 
            // btnQueue
            // 
            btnQueue.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnQueue.BackColor = Color.White;
            btnQueue.Cursor = Cursors.Hand;
            btnQueue.FlatAppearance.BorderSize = 0;
            btnQueue.FlatStyle = FlatStyle.Flat;
            btnQueue.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnQueue.ForeColor = Color.FromArgb(55, 65, 81);
            btnQueue.Location = new Point(17, 21);
            btnQueue.Margin = new Padding(3, 4, 3, 4);
            btnQueue.Name = "btnQueue";
            btnQueue.Padding = new Padding(18, 0, 0, 0);
            btnQueue.Size = new Size(245, 59);
            btnQueue.TabIndex = 8;
            btnQueue.Text = "Hàng chờ khám";
            btnQueue.UseVisualStyleBackColor = false;
            btnQueue.Click += btnQueue_Click;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnToday);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(3, 520);
            panel6.Name = "panel6";
            panel6.Size = new Size(282, 98);
            panel6.TabIndex = 5;
            // 
            // btnToday
            // 
            btnToday.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnToday.BackColor = Color.White;
            btnToday.Cursor = Cursors.Hand;
            btnToday.FlatAppearance.BorderSize = 0;
            btnToday.FlatStyle = FlatStyle.Flat;
            btnToday.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnToday.ForeColor = Color.FromArgb(55, 65, 81);
            btnToday.Location = new Point(17, 21);
            btnToday.Margin = new Padding(3, 4, 3, 4);
            btnToday.Name = "btnToday";
            btnToday.Padding = new Padding(18, 0, 0, 0);
            btnToday.Size = new Size(245, 59);
            btnToday.TabIndex = 8;
            btnToday.Text = "Lịch khám hôm nay";
            btnToday.UseVisualStyleBackColor = false;
            btnToday.Click += btnToday_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnPayment);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(3, 416);
            panel5.Name = "panel5";
            panel5.Size = new Size(282, 98);
            panel5.TabIndex = 4;
            // 
            // btnPayment
            // 
            btnPayment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnPayment.BackColor = Color.White;
            btnPayment.Cursor = Cursors.Hand;
            btnPayment.FlatAppearance.BorderSize = 0;
            btnPayment.FlatStyle = FlatStyle.Flat;
            btnPayment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPayment.ForeColor = Color.FromArgb(55, 65, 81);
            btnPayment.Location = new Point(17, 20);
            btnPayment.Margin = new Padding(3, 4, 3, 4);
            btnPayment.Name = "btnPayment";
            btnPayment.Padding = new Padding(18, 0, 0, 0);
            btnPayment.Size = new Size(245, 59);
            btnPayment.TabIndex = 8;
            btnPayment.Text = "Thanh toán";
            btnPayment.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnAppointment);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 312);
            panel4.Name = "panel4";
            panel4.Size = new Size(282, 98);
            panel4.TabIndex = 3;
            // 
            // btnAppointment
            // 
            btnAppointment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnAppointment.BackColor = Color.White;
            btnAppointment.Cursor = Cursors.Hand;
            btnAppointment.FlatAppearance.BorderSize = 0;
            btnAppointment.FlatStyle = FlatStyle.Flat;
            btnAppointment.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAppointment.ForeColor = Color.FromArgb(55, 65, 81);
            btnAppointment.Location = new Point(17, 20);
            btnAppointment.Margin = new Padding(3, 4, 3, 4);
            btnAppointment.Name = "btnAppointment";
            btnAppointment.Padding = new Padding(18, 0, 0, 0);
            btnAppointment.Size = new Size(245, 59);
            btnAppointment.TabIndex = 7;
            btnAppointment.Text = "Đặt lịch khám";
            btnAppointment.UseVisualStyleBackColor = false;
            btnAppointment.Click += btnAppointment_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnPatientManagement);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 208);
            panel3.Name = "panel3";
            panel3.Size = new Size(282, 98);
            panel3.TabIndex = 2;
            // 
            // btnPatientManagement
            // 
            btnPatientManagement.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnPatientManagement.BackColor = Color.White;
            btnPatientManagement.Cursor = Cursors.Hand;
            btnPatientManagement.FlatAppearance.BorderSize = 0;
            btnPatientManagement.FlatStyle = FlatStyle.Flat;
            btnPatientManagement.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnPatientManagement.ForeColor = Color.FromArgb(55, 65, 81);
            btnPatientManagement.Location = new Point(17, 20);
            btnPatientManagement.Margin = new Padding(3, 4, 3, 4);
            btnPatientManagement.Name = "btnPatientManagement";
            btnPatientManagement.Padding = new Padding(18, 0, 0, 0);
            btnPatientManagement.Size = new Size(245, 59);
            btnPatientManagement.TabIndex = 5;
            btnPatientManagement.Text = "Quản lý bệnh nhân";
            btnPatientManagement.UseVisualStyleBackColor = false;
            btnPatientManagement.Click += btnPatientManagement_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnNavOverview);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 104);
            panel2.Name = "panel2";
            panel2.Size = new Size(282, 98);
            panel2.TabIndex = 1;
            // 
            // btnNavOverview
            // 
            btnNavOverview.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnNavOverview.BackColor = Color.Transparent;
            btnNavOverview.Cursor = Cursors.Hand;
            btnNavOverview.FlatAppearance.BorderSize = 0;
            btnNavOverview.FlatStyle = FlatStyle.Flat;
            btnNavOverview.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNavOverview.ForeColor = Color.FromArgb(55, 65, 81);
            btnNavOverview.Location = new Point(17, 21);
            btnNavOverview.Margin = new Padding(3, 4, 3, 4);
            btnNavOverview.Name = "btnNavOverview";
            btnNavOverview.Padding = new Padding(18, 0, 0, 0);
            btnNavOverview.Size = new Size(245, 59);
            btnNavOverview.TabIndex = 4;
            btnNavOverview.Text = "Tổng quan";
            btnNavOverview.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblLogo);
            panel1.Controls.Add(lblBrand);
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(lblBrandSub);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(282, 95);
            panel1.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.BackColor = Color.FromArgb(47, 94, 240);
            lblLogo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(13, 21);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(43, 51);
            lblLogo.TabIndex = 1;
            lblLogo.Text = "H+";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblBrand.ForeColor = Color.FromArgb(17, 24, 39);
            lblBrand.Location = new Point(62, 10);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(164, 35);
            lblBrand.TabIndex = 2;
            lblBrand.Text = "HealthCare+";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 13F);
            btnClose.Location = new Point(232, 25);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 43);
            btnClose.TabIndex = 0;
            btnClose.Text = "x";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // lblBrandSub
            // 
            lblBrandSub.AutoSize = true;
            lblBrandSub.Font = new Font("Segoe UI", 8.5F);
            lblBrandSub.ForeColor = Color.FromArgb(107, 114, 128);
            lblBrandSub.Location = new Point(62, 52);
            lblBrandSub.Name = "lblBrandSub";
            lblBrandSub.Size = new Size(91, 20);
            lblBrandSub.TabIndex = 3;
            lblBrandSub.Text = "Phòng khám";
            // 
            // panelTopbar
            // 
            panelTopbar.BackColor = Color.White;
            panelTopbar.BorderStyle = BorderStyle.FixedSingle;
            panelTopbar.Controls.Add(tableLayoutPanel2);
            panelTopbar.Dock = DockStyle.Top;
            panelTopbar.Location = new Point(290, 0);
            panelTopbar.Margin = new Padding(3, 4, 3, 4);
            panelTopbar.Name = "panelTopbar";
            panelTopbar.Size = new Size(1388, 101);
            panelTopbar.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1018F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            tableLayoutPanel2.Controls.Add(panel11, 0, 0);
            tableLayoutPanel2.Controls.Add(panel12, 1, 0);
            tableLayoutPanel2.Controls.Add(panel13, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1386, 99);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel11
            // 
            panel11.Controls.Add(lblPageTitle);
            panel11.Controls.Add(lblPageSubtitle);
            panel11.Dock = DockStyle.Fill;
            panel11.Location = new Point(3, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(1012, 93);
            panel11.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            lblPageTitle.AutoSize = true;
            lblPageTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPageTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblPageTitle.Location = new Point(24, 13);
            lblPageTitle.Name = "lblPageTitle";
            lblPageTitle.Size = new Size(138, 32);
            lblPageTitle.TabIndex = 0;
            lblPageTitle.Text = "Tổng quan";
            // 
            // lblPageSubtitle
            // 
            lblPageSubtitle.Anchor = AnchorStyles.Left;
            lblPageSubtitle.AutoSize = true;
            lblPageSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblPageSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblPageSubtitle.Location = new Point(24, 51);
            lblPageSubtitle.Name = "lblPageSubtitle";
            lblPageSubtitle.Size = new Size(118, 21);
            lblPageSubtitle.TabIndex = 1;
            lblPageSubtitle.Text = "Xin chào, Lễ tân";
            // 
            // panel12
            // 
            panel12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel12.Controls.Add(lblBell);
            panel12.Controls.Add(lblNotifDot);
            panel12.Location = new Point(1021, 3);
            panel12.Name = "panel12";
            panel12.Size = new Size(85, 93);
            panel12.TabIndex = 1;
            // 
            // lblBell
            // 
            lblBell.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblBell.Font = new Font("Segoe UI", 16F);
            lblBell.ForeColor = Color.FromArgb(75, 85, 99);
            lblBell.Location = new Point(21, 29);
            lblBell.Name = "lblBell";
            lblBell.Size = new Size(39, 53);
            lblBell.TabIndex = 3;
            lblBell.Text = "!";
            lblBell.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNotifDot
            // 
            lblNotifDot.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblNotifDot.BackColor = Color.FromArgb(239, 68, 68);
            lblNotifDot.Location = new Point(51, 10);
            lblNotifDot.Name = "lblNotifDot";
            lblNotifDot.Size = new Size(9, 11);
            lblNotifDot.TabIndex = 4;
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel13.Controls.Add(lblAvatar);
            panel13.Controls.Add(lblUserName);
            panel13.Controls.Add(lblUserEmail);
            panel13.Location = new Point(1112, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(271, 93);
            panel13.TabIndex = 2;
            // 
            // lblAvatar
            // 
            lblAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblAvatar.BackColor = Color.FromArgb(47, 94, 240);
            lblAvatar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAvatar.ForeColor = Color.White;
            lblAvatar.Location = new Point(219, 17);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(43, 51);
            lblAvatar.TabIndex = 7;
            lblAvatar.Text = "K";
            lblAvatar.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(17, 24, 39);
            lblUserName.Location = new Point(18, 13);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(135, 27);
            lblUserName.TabIndex = 5;
            lblUserName.Text = "Lễ tân";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUserEmail
            // 
            lblUserEmail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserEmail.Font = new Font("Segoe UI", 8.5F);
            lblUserEmail.ForeColor = Color.FromArgb(107, 114, 128);
            lblUserEmail.Location = new Point(18, 52);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(195, 24);
            lblUserEmail.TabIndex = 6;
            lblUserEmail.Text = "reception@phongkham.vn";
            lblUserEmail.TextAlign = ContentAlignment.MiddleRight;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(247, 249, 252);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(290, 101);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1388, 945);
            contentPanel.TabIndex = 2;
            contentPanel.Resize += contentPanel_Resize;
            // 
            // ReceptionistMainform
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(contentPanel);
            Controls.Add(panelTopbar);
            Controls.Add(panelSidebar);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReceptionistMainform";
            Size = new Size(1678, 1046);
            Load += ReceptionistMainform_Load;
            panelSidebar.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelTopbar.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel13.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNavShifts;
        private System.Windows.Forms.Button btnPatientManagement;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelTopbar;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblNotifDot;
        private System.Windows.Forms.Label lblBell;
        private System.Windows.Forms.Label lblPageSubtitle;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Panel contentPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnNavOverview;
        private Panel panel10;
        private Panel panel9;
        private Panel panel8;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel11;
        private Panel panel12;
        private Panel panel13;
        private Button btnAppointment;
        private Button btnToday;
        private Button btnPayment;
        private Button btnQueue;
        private Button btnReminder;
    }
}



