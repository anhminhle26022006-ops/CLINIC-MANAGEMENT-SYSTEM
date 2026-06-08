using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Admin
{
    public partial class ucShiftRequestManagement : UserControl
    {
        public ucShiftRequestManagement()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            ShowTabOverview();
        }

        private void btnTabOverview_Click(object sender, EventArgs e) => ShowTabOverview();

        private void btnTabApproval_Click(object sender, EventArgs e) => ShowTabApproval();

        private void btnTabSchedule_Click(object sender, EventArgs e) => ShowTabSchedule();

        private void btnWarningAction_Click(object sender, EventArgs e) => ShowTabApproval();

        private void panelHeader_Resize(object sender, EventArgs e)
        {
            if (btnCreate != null)
            {
                btnCreate.Location = new Point(panelHeader.Width - btnCreate.Width, 18);
            }
        }

        private void kpiFlow_Resize(object sender, EventArgs e)
        {
            Panel[] cards = { cardTotal, cardPending, cardApproved, cardRejected };
            int gap = 16;
            int cardWidth = (kpiFlow.Width - gap * 3) / 4;
            if (cardWidth <= 0) return;

            foreach (Panel card in cards)
            {
                card.Width = cardWidth;
                card.Height = 120;
                card.Margin = new Padding(0, 0, gap, 0);
            }
        }

        private void panelWarning_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(234, 179, 8), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, panelWarning.Width - 1, panelWarning.Height - 1);
        }

        private void panelWarning_Resize(object sender, EventArgs e)
        {
            if (btnWarningAction != null)
            {
                btnWarningAction.Location = new Point(panelWarning.Width - btnWarningAction.Width - 16, 10);
            }
        }

        private void panelTabs_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawLine(pen, 0, panelTabs.Height - 1, panelTabs.Width, panelTabs.Height - 1);

            foreach (Control control in panelTabs.Controls)
            {
                if (control is Button button && button.Tag?.ToString() == "active")
                {
                    using var blue = new Pen(Color.FromArgb(37, 99, 235), 2);
                    e.Graphics.DrawLine(blue, button.Left, panelTabs.Height - 2, button.Right, panelTabs.Height - 2);
                }
            }
        }

        private void KpiCard_Paint(object sender, PaintEventArgs e)
        {
            if (sender is not Panel card) return;

            using var pen = new Pen(Color.FromArgb(229, 231, 235), 1);
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        }

        private void SetActiveTab(Button active)
        {
            foreach (Control child in panelTabs.Controls)
            {
                if (child is Button button)
                {
                    button.BackColor = button == active ? Color.FromArgb(239, 246, 255) : Color.White;
                    button.ForeColor = button == active ? Color.FromArgb(37, 99, 235) : Color.FromArgb(71, 85, 105);
                }
            }
        }

        private void ShowTabOverview()
        {
            SetActiveTab(btnTabOverview);
            panelTabContent.Controls.Clear();
            panelTabContent.Controls.Add(BuildWhiteCard("Tong quan yeu cau ca truc", 260));
        }

        private void ShowTabApproval()
        {
            SetActiveTab(btnTabApproval);
            panelTabContent.Controls.Clear();
            panelTabContent.Controls.Add(BuildWhiteCard("Danh sach cho duyet", 260));
        }

        private void ShowTabSchedule()
        {
            SetActiveTab(btnTabSchedule);
            panelTabContent.Controls.Clear();
            panelTabContent.Controls.Add(BuildWhiteCard("Lich truc", 260));
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
    }
}
