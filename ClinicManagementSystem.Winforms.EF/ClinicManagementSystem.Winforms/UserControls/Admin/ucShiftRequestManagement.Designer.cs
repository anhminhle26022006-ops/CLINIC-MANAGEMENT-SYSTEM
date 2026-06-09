using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    partial class ucShiftRequestManagement
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            btnCreate = new Button();
            kpiFlow = new Panel();
            cardTotal = new Panel();
            lblShiftTotalTitle = new Label();
            lblShiftTotalValue = new Label();
            lblShiftTotalSub = new Label();
            lblShiftTotalIcon = new Label();
            cardPending = new Panel();
            lblShiftPendingTitle = new Label();
            lblShiftPendingValue = new Label();
            lblShiftPendingSub = new Label();
            lblShiftPendingIcon = new Label();
            cardApproved = new Panel();
            lblShiftApprovedTitle = new Label();
            lblShiftApprovedValue = new Label();
            lblShiftApprovedSub = new Label();
            lblShiftApprovedIcon = new Label();
            cardRejected = new Panel();
            lblShiftRejectedTitle = new Label();
            lblShiftRejectedValue = new Label();
            lblShiftRejectedSub = new Label();
            lblShiftRejectedIcon = new Label();
            panelWarning = new Panel();
            lblWarning = new Label();
            btnWarningAction = new Button();
            lblWarningSub = new Label();
            panelTabs = new Panel();
            btnTabOverview = new Button();
            btnTabApproval = new Button();
            btnTabSchedule = new Button();
            lblBadge = new Label();
            panelTabContent = new Panel();
            panelHeader.SuspendLayout();
            kpiFlow.SuspendLayout();
            cardTotal.SuspendLayout();
            cardPending.SuspendLayout();
            cardApproved.SuspendLayout();
            cardRejected.SuspendLayout();
            panelWarning.SuspendLayout();
            panelTabs.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.Transparent;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnCreate);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(24, 16);
            panelHeader.Margin = new Padding(2, 2, 2, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(976, 64);
            panelHeader.TabIndex = 4;
            panelHeader.Resize += panelHeader_Resize;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(17, 24, 39);
            lblTitle.Location = new Point(0, 3);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(282, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý ca làm việc";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new Point(0, 35);
            lblSubtitle.Margin = new Padding(2, 0, 2, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(284, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Phân ca và xét duyệt yêu cầu đổi ca";
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(37, 99, 235);
            btnCreate.Cursor = Cursors.Hand;
            btnCreate.FlatAppearance.BorderSize = 0;
            btnCreate.FlatStyle = FlatStyle.Flat;
            btnCreate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreate.ForeColor = Color.White;
            btnCreate.Location = new Point(720, 14);
            btnCreate.Margin = new Padding(2, 2, 2, 2);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(112, 35);
            btnCreate.TabIndex = 2;
            btnCreate.Text = "+ Tạo ca mới";
            btnCreate.UseVisualStyleBackColor = false;
            // 
            // kpiFlow
            // 
            kpiFlow.BackColor = Color.Transparent;
            kpiFlow.Controls.Add(cardTotal);
            kpiFlow.Controls.Add(cardPending);
            kpiFlow.Controls.Add(cardApproved);
            kpiFlow.Controls.Add(cardRejected);
            kpiFlow.Dock = DockStyle.Top;
            kpiFlow.Location = new Point(24, 80);
            kpiFlow.Margin = new Padding(0, 0, 0, 10);
            kpiFlow.Name = "kpiFlow";
            kpiFlow.Size = new Size(976, 112);
            kpiFlow.TabIndex = 3;
            kpiFlow.Resize += kpiFlow_Resize;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.White;
            cardTotal.Controls.Add(lblShiftTotalTitle);
            cardTotal.Controls.Add(lblShiftTotalValue);
            cardTotal.Controls.Add(lblShiftTotalSub);
            cardTotal.Controls.Add(lblShiftTotalIcon);
            cardTotal.Location = new Point(0, 0);
            cardTotal.Margin = new Padding(0, 0, 13, 0);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(224, 96);
            cardTotal.TabIndex = 0;
            cardTotal.Paint += KpiCard_Paint;
            // 
            // lblShiftTotalTitle
            // 
            lblShiftTotalTitle.Font = new Font("Segoe UI", 9F);
            lblShiftTotalTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftTotalTitle.Location = new Point(14, 13);
            lblShiftTotalTitle.Margin = new Padding(2, 0, 2, 0);
            lblShiftTotalTitle.Name = "lblShiftTotalTitle";
            lblShiftTotalTitle.Size = new Size(120, 19);
            lblShiftTotalTitle.TabIndex = 0;
            lblShiftTotalTitle.Text = "Tổng số ca";
            // 
            // lblShiftTotalValue
            // 
            lblShiftTotalValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblShiftTotalValue.ForeColor = Color.FromArgb(37, 99, 235);
            lblShiftTotalValue.Location = new Point(14, 32);
            lblShiftTotalValue.Margin = new Padding(2, 0, 2, 0);
            lblShiftTotalValue.Name = "lblShiftTotalValue";
            lblShiftTotalValue.Size = new Size(96, 42);
            lblShiftTotalValue.TabIndex = 1;
            lblShiftTotalValue.Text = "0";
            // 
            // lblShiftTotalSub
            // 
            lblShiftTotalSub.Font = new Font("Segoe UI", 8.5F);
            lblShiftTotalSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblShiftTotalSub.Location = new Point(14, 73);
            lblShiftTotalSub.Margin = new Padding(2, 0, 2, 0);
            lblShiftTotalSub.Name = "lblShiftTotalSub";
            lblShiftTotalSub.Size = new Size(168, 18);
            lblShiftTotalSub.TabIndex = 2;
            lblShiftTotalSub.Text = "+12% so với tháng trước";
            // 
            // lblShiftTotalIcon
            // 
            lblShiftTotalIcon.BackColor = Color.FromArgb(219, 234, 254);
            lblShiftTotalIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftTotalIcon.ForeColor = Color.FromArgb(37, 99, 235);
            lblShiftTotalIcon.Location = new Point(174, 16);
            lblShiftTotalIcon.Margin = new Padding(2, 0, 2, 0);
            lblShiftTotalIcon.Name = "lblShiftTotalIcon";
            lblShiftTotalIcon.Size = new Size(37, 37);
            lblShiftTotalIcon.TabIndex = 3;
            lblShiftTotalIcon.Text = "CA";
            lblShiftTotalIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.FromArgb(254, 249, 195);
            cardPending.Controls.Add(lblShiftPendingTitle);
            cardPending.Controls.Add(lblShiftPendingValue);
            cardPending.Controls.Add(lblShiftPendingSub);
            cardPending.Controls.Add(lblShiftPendingIcon);
            cardPending.Location = new Point(237, 0);
            cardPending.Margin = new Padding(0, 0, 13, 0);
            cardPending.Name = "cardPending";
            cardPending.Size = new Size(224, 96);
            cardPending.TabIndex = 1;
            cardPending.Paint += KpiCard_Paint;
            // 
            // lblShiftPendingTitle
            // 
            lblShiftPendingTitle.Font = new Font("Segoe UI", 9F);
            lblShiftPendingTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftPendingTitle.Location = new Point(14, 13);
            lblShiftPendingTitle.Margin = new Padding(2, 0, 2, 0);
            lblShiftPendingTitle.Name = "lblShiftPendingTitle";
            lblShiftPendingTitle.Size = new Size(120, 19);
            lblShiftPendingTitle.TabIndex = 0;
            lblShiftPendingTitle.Text = "Chờ duyệt";
            // 
            // lblShiftPendingValue
            // 
            lblShiftPendingValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblShiftPendingValue.ForeColor = Color.FromArgb(161, 98, 7);
            lblShiftPendingValue.Location = new Point(14, 32);
            lblShiftPendingValue.Margin = new Padding(2, 0, 2, 0);
            lblShiftPendingValue.Name = "lblShiftPendingValue";
            lblShiftPendingValue.Size = new Size(96, 42);
            lblShiftPendingValue.TabIndex = 1;
            lblShiftPendingValue.Text = "0";
            // 
            // lblShiftPendingSub
            // 
            lblShiftPendingSub.Font = new Font("Segoe UI", 8.5F);
            lblShiftPendingSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblShiftPendingSub.Location = new Point(14, 73);
            lblShiftPendingSub.Margin = new Padding(2, 0, 2, 0);
            lblShiftPendingSub.Name = "lblShiftPendingSub";
            lblShiftPendingSub.Size = new Size(168, 18);
            lblShiftPendingSub.TabIndex = 2;
            lblShiftPendingSub.Text = "Yêu cầu đổi ca cần xử lý";
            // 
            // lblShiftPendingIcon
            // 
            lblShiftPendingIcon.BackColor = Color.FromArgb(254, 240, 138);
            lblShiftPendingIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftPendingIcon.ForeColor = Color.FromArgb(161, 98, 7);
            lblShiftPendingIcon.Location = new Point(174, 16);
            lblShiftPendingIcon.Margin = new Padding(2, 0, 2, 0);
            lblShiftPendingIcon.Name = "lblShiftPendingIcon";
            lblShiftPendingIcon.Size = new Size(37, 37);
            lblShiftPendingIcon.TabIndex = 3;
            lblShiftPendingIcon.Text = "CD";
            lblShiftPendingIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardApproved
            // 
            cardApproved.BackColor = Color.White;
            cardApproved.Controls.Add(lblShiftApprovedTitle);
            cardApproved.Controls.Add(lblShiftApprovedValue);
            cardApproved.Controls.Add(lblShiftApprovedSub);
            cardApproved.Controls.Add(lblShiftApprovedIcon);
            cardApproved.Location = new Point(474, 0);
            cardApproved.Margin = new Padding(0, 0, 13, 0);
            cardApproved.Name = "cardApproved";
            cardApproved.Size = new Size(224, 96);
            cardApproved.TabIndex = 2;
            cardApproved.Paint += KpiCard_Paint;
            // 
            // lblShiftApprovedTitle
            // 
            lblShiftApprovedTitle.Font = new Font("Segoe UI", 9F);
            lblShiftApprovedTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftApprovedTitle.Location = new Point(14, 13);
            lblShiftApprovedTitle.Margin = new Padding(2, 0, 2, 0);
            lblShiftApprovedTitle.Name = "lblShiftApprovedTitle";
            lblShiftApprovedTitle.Size = new Size(120, 19);
            lblShiftApprovedTitle.TabIndex = 0;
            lblShiftApprovedTitle.Text = "Đã duyệt";
            // 
            // lblShiftApprovedValue
            // 
            lblShiftApprovedValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblShiftApprovedValue.ForeColor = Color.FromArgb(22, 163, 74);
            lblShiftApprovedValue.Location = new Point(14, 32);
            lblShiftApprovedValue.Margin = new Padding(2, 0, 2, 0);
            lblShiftApprovedValue.Name = "lblShiftApprovedValue";
            lblShiftApprovedValue.Size = new Size(96, 42);
            lblShiftApprovedValue.TabIndex = 1;
            lblShiftApprovedValue.Text = "0";
            // 
            // lblShiftApprovedSub
            // 
            lblShiftApprovedSub.Font = new Font("Segoe UI", 8.5F);
            lblShiftApprovedSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblShiftApprovedSub.Location = new Point(14, 73);
            lblShiftApprovedSub.Margin = new Padding(2, 0, 2, 0);
            lblShiftApprovedSub.Name = "lblShiftApprovedSub";
            lblShiftApprovedSub.Size = new Size(168, 18);
            lblShiftApprovedSub.TabIndex = 2;
            lblShiftApprovedSub.Text = "Tháng này";
            // 
            // lblShiftApprovedIcon
            // 
            lblShiftApprovedIcon.BackColor = Color.FromArgb(220, 252, 231);
            lblShiftApprovedIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftApprovedIcon.ForeColor = Color.FromArgb(22, 163, 74);
            lblShiftApprovedIcon.Location = new Point(174, 16);
            lblShiftApprovedIcon.Margin = new Padding(2, 0, 2, 0);
            lblShiftApprovedIcon.Name = "lblShiftApprovedIcon";
            lblShiftApprovedIcon.Size = new Size(37, 37);
            lblShiftApprovedIcon.TabIndex = 3;
            lblShiftApprovedIcon.Text = "DU";
            lblShiftApprovedIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cardRejected
            // 
            cardRejected.BackColor = Color.White;
            cardRejected.Controls.Add(lblShiftRejectedTitle);
            cardRejected.Controls.Add(lblShiftRejectedValue);
            cardRejected.Controls.Add(lblShiftRejectedSub);
            cardRejected.Controls.Add(lblShiftRejectedIcon);
            cardRejected.Location = new Point(710, 0);
            cardRejected.Margin = new Padding(0, 0, 13, 0);
            cardRejected.Name = "cardRejected";
            cardRejected.Size = new Size(224, 96);
            cardRejected.TabIndex = 3;
            cardRejected.Paint += KpiCard_Paint;
            // 
            // lblShiftRejectedTitle
            // 
            lblShiftRejectedTitle.Font = new Font("Segoe UI", 9F);
            lblShiftRejectedTitle.ForeColor = Color.FromArgb(107, 114, 128);
            lblShiftRejectedTitle.Location = new Point(14, 13);
            lblShiftRejectedTitle.Margin = new Padding(2, 0, 2, 0);
            lblShiftRejectedTitle.Name = "lblShiftRejectedTitle";
            lblShiftRejectedTitle.Size = new Size(120, 19);
            lblShiftRejectedTitle.TabIndex = 0;
            lblShiftRejectedTitle.Text = "Từ chối";
            // 
            // lblShiftRejectedValue
            // 
            lblShiftRejectedValue.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblShiftRejectedValue.ForeColor = Color.FromArgb(220, 38, 38);
            lblShiftRejectedValue.Location = new Point(14, 32);
            lblShiftRejectedValue.Margin = new Padding(2, 0, 2, 0);
            lblShiftRejectedValue.Name = "lblShiftRejectedValue";
            lblShiftRejectedValue.Size = new Size(96, 42);
            lblShiftRejectedValue.TabIndex = 1;
            lblShiftRejectedValue.Text = "0";
            // 
            // lblShiftRejectedSub
            // 
            lblShiftRejectedSub.Font = new Font("Segoe UI", 8.5F);
            lblShiftRejectedSub.ForeColor = Color.FromArgb(100, 116, 139);
            lblShiftRejectedSub.Location = new Point(14, 73);
            lblShiftRejectedSub.Margin = new Padding(2, 0, 2, 0);
            lblShiftRejectedSub.Name = "lblShiftRejectedSub";
            lblShiftRejectedSub.Size = new Size(168, 18);
            lblShiftRejectedSub.TabIndex = 2;
            lblShiftRejectedSub.Text = "Tháng này";
            // 
            // lblShiftRejectedIcon
            // 
            lblShiftRejectedIcon.BackColor = Color.FromArgb(254, 226, 226);
            lblShiftRejectedIcon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblShiftRejectedIcon.ForeColor = Color.FromArgb(220, 38, 38);
            lblShiftRejectedIcon.Location = new Point(174, 16);
            lblShiftRejectedIcon.Margin = new Padding(2, 0, 2, 0);
            lblShiftRejectedIcon.Name = "lblShiftRejectedIcon";
            lblShiftRejectedIcon.Size = new Size(37, 37);
            lblShiftRejectedIcon.TabIndex = 3;
            lblShiftRejectedIcon.Text = "TC";
            lblShiftRejectedIcon.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelWarning
            // 
            panelWarning.BackColor = Color.FromArgb(254, 252, 232);
            panelWarning.Controls.Add(lblWarning);
            panelWarning.Controls.Add(btnWarningAction);
            panelWarning.Controls.Add(lblWarningSub);
            panelWarning.Dock = DockStyle.Top;
            panelWarning.Location = new Point(24, 192);
            panelWarning.Margin = new Padding(0, 0, 0, 6);
            panelWarning.Name = "panelWarning";
            panelWarning.Size = new Size(976, 48);
            panelWarning.TabIndex = 2;
            panelWarning.Visible = false;
            panelWarning.Paint += panelWarning_Paint;
            panelWarning.Resize += panelWarning_Resize;
            // 
            // lblWarning
            // 
            lblWarning.AutoSize = true;
            lblWarning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblWarning.ForeColor = Color.FromArgb(161, 98, 7);
            lblWarning.Location = new Point(13, 8);
            lblWarning.Margin = new Padding(2, 0, 2, 0);
            lblWarning.Name = "lblWarning";
            lblWarning.Size = new Size(314, 23);
            lblWarning.TabIndex = 0;
            lblWarning.Tag = "main";
            lblWarning.Text = "⚠  Có yêu cầu đổi ca đang chờ duyệt";
            // 
            // btnWarningAction
            // 
            btnWarningAction.BackColor = Color.FromArgb(161, 98, 7);
            btnWarningAction.Cursor = Cursors.Hand;
            btnWarningAction.FlatAppearance.BorderSize = 0;
            btnWarningAction.FlatStyle = FlatStyle.Flat;
            btnWarningAction.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnWarningAction.ForeColor = Color.White;
            btnWarningAction.Location = new Point(720, 8);
            btnWarningAction.Margin = new Padding(2, 2, 2, 2);
            btnWarningAction.Name = "btnWarningAction";
            btnWarningAction.Size = new Size(72, 30);
            btnWarningAction.TabIndex = 1;
            btnWarningAction.Text = "Xem ngay";
            btnWarningAction.UseVisualStyleBackColor = false;
            btnWarningAction.Click += btnWarningAction_Click;
            // 
            // lblWarningSub
            // 
            lblWarningSub.Location = new Point(0, 0);
            lblWarningSub.Margin = new Padding(2, 0, 2, 0);
            lblWarningSub.Name = "lblWarningSub";
            lblWarningSub.Size = new Size(80, 18);
            lblWarningSub.TabIndex = 2;
            // 
            // panelTabs
            // 
            panelTabs.BackColor = Color.White;
            panelTabs.Controls.Add(btnTabOverview);
            panelTabs.Controls.Add(btnTabApproval);
            panelTabs.Controls.Add(btnTabSchedule);
            panelTabs.Controls.Add(lblBadge);
            panelTabs.Dock = DockStyle.Top;
            panelTabs.Location = new Point(24, 240);
            panelTabs.Margin = new Padding(2, 2, 2, 2);
            panelTabs.Name = "panelTabs";
            panelTabs.Size = new Size(976, 42);
            panelTabs.TabIndex = 1;
            panelTabs.Paint += panelTabs_Paint;
            // 
            // btnTabOverview
            // 
            btnTabOverview.BackColor = Color.White;
            btnTabOverview.Cursor = Cursors.Hand;
            btnTabOverview.FlatAppearance.BorderSize = 0;
            btnTabOverview.FlatStyle = FlatStyle.Flat;
            btnTabOverview.Font = new Font("Segoe UI", 10F);
            btnTabOverview.ForeColor = Color.FromArgb(37, 99, 235);
            btnTabOverview.Location = new Point(0, 0);
            btnTabOverview.Margin = new Padding(2, 2, 2, 2);
            btnTabOverview.Name = "btnTabOverview";
            btnTabOverview.Size = new Size(128, 40);
            btnTabOverview.TabIndex = 0;
            btnTabOverview.Tag = "active";
            btnTabOverview.Text = "👥  Tổng quan";
            btnTabOverview.UseVisualStyleBackColor = false;
            btnTabOverview.Click += btnTabOverview_Click;
            // 
            // btnTabApproval
            // 
            btnTabApproval.BackColor = Color.White;
            btnTabApproval.Cursor = Cursors.Hand;
            btnTabApproval.FlatAppearance.BorderSize = 0;
            btnTabApproval.FlatStyle = FlatStyle.Flat;
            btnTabApproval.Font = new Font("Segoe UI", 10F);
            btnTabApproval.ForeColor = Color.FromArgb(107, 114, 128);
            btnTabApproval.Location = new Point(131, 0);
            btnTabApproval.Margin = new Padding(2, 2, 2, 2);
            btnTabApproval.Name = "btnTabApproval";
            btnTabApproval.Size = new Size(128, 40);
            btnTabApproval.TabIndex = 1;
            btnTabApproval.Text = "✅  Duyệt đổi ca";
            btnTabApproval.UseVisualStyleBackColor = false;
            btnTabApproval.Click += btnTabApproval_Click;
            // 
            // btnTabSchedule
            // 
            btnTabSchedule.BackColor = Color.White;
            btnTabSchedule.Cursor = Cursors.Hand;
            btnTabSchedule.FlatAppearance.BorderSize = 0;
            btnTabSchedule.FlatStyle = FlatStyle.Flat;
            btnTabSchedule.Font = new Font("Segoe UI", 10F);
            btnTabSchedule.ForeColor = Color.FromArgb(107, 114, 128);
            btnTabSchedule.Location = new Point(262, 0);
            btnTabSchedule.Margin = new Padding(2, 2, 2, 2);
            btnTabSchedule.Name = "btnTabSchedule";
            btnTabSchedule.Size = new Size(128, 40);
            btnTabSchedule.TabIndex = 2;
            btnTabSchedule.Text = "📅  Lịch làm việc";
            btnTabSchedule.UseVisualStyleBackColor = false;
            btnTabSchedule.Click += btnTabSchedule_Click;
            // 
            // lblBadge
            // 
            lblBadge.BackColor = Color.FromArgb(220, 38, 38);
            lblBadge.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblBadge.ForeColor = Color.White;
            lblBadge.Location = new Point(245, 6);
            lblBadge.Margin = new Padding(2, 0, 2, 0);
            lblBadge.Name = "lblBadge";
            lblBadge.Size = new Size(14, 14);
            lblBadge.TabIndex = 3;
            lblBadge.Text = "0";
            lblBadge.TextAlign = ContentAlignment.MiddleCenter;
            lblBadge.Visible = false;
            // 
            // panelTabContent
            // 
            panelTabContent.BackColor = Color.FromArgb(247, 249, 252);
            panelTabContent.Dock = DockStyle.Fill;
            panelTabContent.Location = new Point(24, 282);
            panelTabContent.Margin = new Padding(2, 2, 2, 2);
            panelTabContent.Name = "panelTabContent";
            panelTabContent.Size = new Size(976, 438);
            panelTabContent.TabIndex = 0;
            // 
            // ucShiftRequestManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            Controls.Add(panelTabContent);
            Controls.Add(panelTabs);
            Controls.Add(panelWarning);
            Controls.Add(kpiFlow);
            Controls.Add(panelHeader);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ucShiftRequestManagement";
            Padding = new Padding(24, 16, 24, 0);
            Size = new Size(1024, 720);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            kpiFlow.ResumeLayout(false);
            cardTotal.ResumeLayout(false);
            cardPending.ResumeLayout(false);
            cardApproved.ResumeLayout(false);
            cardRejected.ResumeLayout(false);
            panelWarning.ResumeLayout(false);
            panelWarning.PerformLayout();
            panelTabs.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel BuildWhiteCard(string title, int height)
        {
            var card = new Panel
            {
                BackColor = Color.White,
                Dock = DockStyle.Top,
                Height = height,
                Padding = new Padding(24),
                Margin = new Padding(0, 0, 0, 16)
            };

            card.Controls.Add(new Label
            {
                AutoSize = true,
                Text = title,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(17, 24, 39)
            });

            return card;
        }

        // Fields
        private Panel panelHeader, panelWarning, panelTabs, panelTabContent, kpiFlow;
        private Label lblTitle, lblSubtitle, lblWarning, lblBadge;
        private Button btnCreate, btnWarningAction;
        private Button btnTabOverview, btnTabApproval, btnTabSchedule;
        internal Panel cardTotal, cardPending, cardApproved, cardRejected;
        private Label lblShiftTotalTitle, lblShiftTotalValue, lblShiftTotalSub, lblShiftTotalIcon;
        private Label lblShiftPendingTitle, lblShiftPendingValue, lblShiftPendingSub, lblShiftPendingIcon;
        private Label lblShiftApprovedTitle, lblShiftApprovedValue, lblShiftApprovedSub, lblShiftApprovedIcon;
        private Label lblShiftRejectedTitle, lblShiftRejectedValue, lblShiftRejectedSub, lblShiftRejectedIcon;
        private Label lblWarningSub;
    }
}
