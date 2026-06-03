using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ClinicManagementSystem.Winforms;
using BUS.Services;
using DTO;
using DAL;
using ClinicManagementSystem.Winforms.UserControls.Technician;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ClinicManagementSystem.Winforms.Mainforms
{
    public partial class ucTechnicianDashboard : UserControl
    {
        private readonly Color primary = Color.FromArgb(47, 94, 240);
        private readonly Color surface = Color.White;
        private readonly Color pageBack = Color.FromArgb(247, 249, 252);
        private readonly Color textMain = Color.FromArgb(17, 24, 39);
        private readonly Color textMuted = Color.FromArgb(107, 114, 128);

        private readonly PatientBUS patientBUS = new PatientBUS();
        private readonly RequestBUS requestBUS = new RequestBUS();
        private readonly ShiftBUS shiftBUS = new ShiftBUS();
        private UserDTO currentUser;
        private bool layoutReady;

        // Custom Navigation Buttons
        private Button btnNavUploadMRI;
        private Button btnNavUploadPDF;
        private Button btnNavLabResult;
        private Button btnNavSeederTool;

        // Active request for processing transitions
        private int activeRequestId = 0;

        public event EventHandler LogoutRequested;
        public event EventHandler CloseRequested;

        public ucTechnicianDashboard()
        {
            InitializeComponent();
            layoutReady = true;
        }

        public ucTechnicianDashboard(UserDTO user) : this()
        {
            this.currentUser = user;
            lblUserName.Text = user.Name;
            lblUserEmail.Text = user.Email ?? user.Username;
            lblAvatar.Text = string.IsNullOrEmpty(user.Name) ? "K" : user.Name.Substring(0, 1).ToUpper();
            lblPageSubtitle.Text = "Xin chÃ o, " + user.Name;
        }

        private void ucTechnicianDashboard_Load(object sender, EventArgs e)
        {
            txtGlobalSearch.Text = "  TÃ¬m kiáº¿m...";
            txtGlobalSearch.ForeColor = Color.FromArgb(148, 163, 184);

            // Re-arrange default sidebar buttons
            btnNavOverview.Location = new Point(12, 78);
            btnNavRequests.Location = new Point(12, 124);

            // Add programmatically styled sidebar buttons for remaining tasks
            btnNavUploadMRI = CreateSidebarButton("Táº£i lÃªn MRI/X-Ray", new Point(12, 170), btnNavUploadMRI_Click);
            btnNavUploadPDF = CreateSidebarButton("Táº£i lÃªn PDF", new Point(12, 216), btnNavUploadPDF_Click);
            btnNavLabResult = CreateSidebarButton("Nháº­p káº¿t quáº£ Lab", new Point(12, 262), btnNavLabResult_Click);
            btnNavRecords.Location = new Point(12, 308);
            btnNavShifts.Location = new Point(12, 354);
            btnNavSeederTool = CreateSidebarButton("Seeder Tool (Test)", new Point(12, 400), btnNavSeederTool_Click);

            // Set Log Out click handler
            btnLogout.Click += (s, ev) =>
            {
                LogoutRequested?.Invoke(this, EventArgs.Empty);
            };

            // Close button click handler
            btnClose.Click += (s, ev) => CloseRequested?.Invoke(this, EventArgs.Empty);

            ShowOverview();
        }

        private Button CreateSidebarButton(string text, Point location, EventHandler onClick)
        {
            Button btn = new Button
            {
                Text = text,
                Location = location,
                Size = new Size(214, 44),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                Cursor = Cursors.Hand,
                BackColor = Color.White,
                ForeColor = Color.FromArgb(55, 65, 81),
                UseVisualStyleBackColor = false
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.Click += onClick;
            panelSidebar.Controls.Add(btn);
            return btn;
        }

        private void btnNavOverview_Click(object sender, EventArgs e) => ShowOverview();
        private void btnNavRequests_Click(object sender, EventArgs e) => ShowRequests();
        private void btnNavUploadMRI_Click(object sender, EventArgs e) => ShowUploadMRI();
        private void btnNavUploadPDF_Click(object sender, EventArgs e) => ShowUploadPDF();
        private void btnNavLabResult_Click(object sender, EventArgs e) => ShowLabResult();
        private void btnNavRecords_Click(object sender, EventArgs e) => ShowRecords();
        private void btnNavShifts_Click(object sender, EventArgs e) => ShowShifts();
        private void btnNavSeederTool_Click(object sender, EventArgs e) => ShowSeederTool();

        private void contentPanel_Resize(object sender, EventArgs e)
        {
            if (!layoutReady || contentPanel.Width < 400) return;
        }

        private void ShowOverview()
        {
            lblPageTitle.Text = "Tá»•ng quan";
            lblPageSubtitle.Text = "Xin chÃ o, " + (currentUser != null ? currentUser.Name : "Ká»¹ thuáº­t viÃªn");
            SetActiveNav(btnNavOverview);
            LoadContentView(new ucTechnicianOverview());
        }

        private void ShowRequests()
        {
            lblPageTitle.Text = "XÃ©t nghiá»‡m";
            lblPageSubtitle.Text = "Quáº£n lÃ½ yÃªu cáº§u xÃ©t nghiá»‡m vÃ  chá»¥p áº£nh tá»« BÃ¡c sÄ©";
            SetActiveNav(btnNavRequests);
            LoadContentView(new ucTechnicianRequests());
        }

        private void ShowUploadMRI(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Táº£i lÃªn MRI/X-Ray";
            lblPageSubtitle.Text = "LÆ°u vÃ  upload hÃ¬nh áº£nh phim chá»¥p cá»§a bá»‡nh nhÃ¢n";
            SetActiveNav(btnNavUploadMRI);
            LoadContentView(new ucTechnicianUploadMri(), preselectedId);
        }

        private void ShowUploadPDF(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Táº£i lÃªn káº¿t quáº£ PDF";
            lblPageSubtitle.Text = "Upload tá»‡p PDF káº¿t quáº£ xÃ©t nghiá»‡m tá»•ng há»£p";
            SetActiveNav(btnNavUploadPDF);
            LoadContentView(new ucTechnicianUploadPdf(), preselectedId);
        }

        private void ShowLabResult(int preselectedId = 0)
        {
            activeRequestId = preselectedId;
            lblPageTitle.Text = "Nháº­p káº¿t quáº£ Lab";
            lblPageSubtitle.Text = "Nháº­p chá»‰ sá»‘ xÃ©t nghiá»‡m sinh hÃ³a chi tiáº¿t";
            SetActiveNav(btnNavLabResult);
            LoadContentView(new ucTechnicianLabResult(), preselectedId);
        }

        private void ShowShifts()
        {
            lblPageTitle.Text = "Ca lÃ m viá»‡c";
            lblPageSubtitle.Text = "Quáº£n lÃ½ lá»‹ch trÃ¬nh lÃ m viá»‡c vÃ  lá»‹ch trá»±c";
            SetActiveNav(btnNavShifts);
            LoadContentView(new ucTechnicianShifts());
        }

        private void ShowRecords()
        {
            lblPageTitle.Text = "Há»“ sÆ¡ bá»‡nh Ã¡n";
            lblPageSubtitle.Text = "TÃ¬m kiáº¿m há»“ sÆ¡ bá»‡nh nhÃ¢n vÃ  lá»‹ch sá»­ káº¿t quáº£ xÃ©t nghiá»‡m";
            SetActiveNav(btnNavRecords);
            LoadContentView(new ucPatientRecords());
        }

        private void ShowSeederTool()
        {
            lblPageTitle.Text = "Seeder Tool";
            lblPageSubtitle.Text = "CÃ´ng cá»¥ táº¡o dá»¯ liá»‡u máº«u cho SQL Server";
            SetActiveNav(btnNavSeederTool);
            LoadContentView(new ucSeederTool());
        }

        private void LoadContentView(TechnicianDashboardViewBase view, int requestId = 0)
        {
            contentPanel.SuspendLayout();
            contentPanel.Controls.Clear();

            view.Initialize(currentUser, requestId);
            view.Dock = DockStyle.Fill;
            view.NavigateRequested += ContentView_NavigateRequested;

            contentPanel.Controls.Add(view);
            contentPanel.ResumeLayout();
        }

        private void ContentView_NavigateRequested(object sender, TechnicianNavigationEventArgs e)
        {
            switch (e.Target)
            {
                case TechnicianViewTarget.Requests:
                    ShowRequests();
                    break;
                case TechnicianViewTarget.UploadMRI:
                    ShowUploadMRI(e.RequestId);
                    break;
                case TechnicianViewTarget.UploadPDF:
                    ShowUploadPDF(e.RequestId);
                    break;
                case TechnicianViewTarget.LabResult:
                    ShowLabResult(e.RequestId);
                    break;
                case TechnicianViewTarget.Shifts:
                    ShowShifts();
                    break;
                case TechnicianViewTarget.Records:
                    ShowRecords();
                    break;
                case TechnicianViewTarget.SeederTool:
                    ShowSeederTool();
                    break;
                default:
                    ShowOverview();
                    break;
            }
        }

        private void SetActiveNav(Button activeButton)
        {
            Button[] buttons = {
                btnNavOverview, btnNavRequests, btnNavUploadMRI, btnNavUploadPDF,
                btnNavLabResult, btnNavRecords, btnNavShifts, btnNavSeederTool
            };

            foreach (Button button in buttons)
            {
                if (button != null)
                {
                    button.BackColor = Color.White;
                    button.ForeColor = Color.FromArgb(55, 65, 81);
                }
            }

            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(239, 246, 255);
                activeButton.ForeColor = primary;
            }
        }

    }
}

