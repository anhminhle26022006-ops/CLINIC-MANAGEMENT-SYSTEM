using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DTO;
using ClinicManagementSystem.Winforms.Forms;

namespace ClinicManagementSystem.Winforms.UserControls.Technician
{
    public partial class ucTechnicianOverview : TechnicianDashboardViewBase
    {
        protected override Panel ContentPanel => viewHostPanel;

        public ucTechnicianOverview()
        {
            InitializeComponent();
        }

        private void ucTechnicianOverview_Load(object sender, EventArgs e)
        {
            btnViewWeek.Click += (s, ev) => NavigateTo(TechnicianViewTarget.Shifts);
            btnRegisterShift.Click += BtnRegisterShift_Click;

            // Hook click handlers for Quick Action panels recursively
            Action<object, EventArgs> clickLab = (s, ev) => NavigateTo(TechnicianViewTarget.Requests);
            Action<object, EventArgs> clickScan = (s, ev) => NavigateTo(TechnicianViewTarget.UploadMRI);
            Action<object, EventArgs> clickPdf = (s, ev) => NavigateTo(TechnicianViewTarget.UploadPDF);
            Action<object, EventArgs> clickResult = (s, ev) => NavigateTo(TechnicianViewTarget.LabResult);

            pnlActLab.Click += new EventHandler(clickLab);
            lblActLabTitle.Click += new EventHandler(clickLab);
            lblActLabDesc.Click += new EventHandler(clickLab);

            pnlActScan.Click += new EventHandler(clickScan);
            lblActScanTitle.Click += new EventHandler(clickScan);
            lblActScanDesc.Click += new EventHandler(clickScan);

            pnlActPdf.Click += new EventHandler(clickPdf);
            lblActPdfTitle.Click += new EventHandler(clickPdf);
            lblActPdfDesc.Click += new EventHandler(clickPdf);

            pnlActResult.Click += new EventHandler(clickResult);
            lblActResultTitle.Click += new EventHandler(clickResult);
            lblActResultDesc.Click += new EventHandler(clickResult);

            LoadOverviewData();
        }

        private void ucTechnicianOverview_Resize(object sender, EventArgs e)
        {
            ResizePendingRows();
        }

        private void BtnRegisterShift_Click(object sender, EventArgs e)
        {
            RegisterShiftForm register = new RegisterShiftForm(currentUser != null ? currentUser.Name : "Lữ Võ Hoàng Phúc");
            if (register.ShowDialog() == DialogResult.OK)
            {
                NavigateTo(TechnicianViewTarget.Shifts);
            }
        }

        private void LoadOverviewData()
        {
            List<TechnicianRequestDTO> requests = new List<TechnicianRequestDTO>();
            int pendingLab = 0;
            int pendingScan = 0;
            int completedToday = 0;
            int processing = 0;

            try
            {
                requests = requestBUS.GetList();
                pendingLab = requests.Count(r => r.Status == "Chờ xử lý" && CMS.Core.Utils.ServiceTypeHelper.IsLabOrEcgService(r.ServiceType));
                pendingScan = requests.Count(r => r.Status == "Chờ xử lý" && CMS.Core.Utils.ServiceTypeHelper.IsImagingService(r.ServiceType));
                completedToday = requests.Count(r => r.Status == "Hoàn thành" && r.RequestDate.Date == DateTime.Today);
                processing = requests.Count(r => r.Status == "Đang xử lý");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading overview requests: " + ex);
            }

            // Update stats labels
            lblStatLabNum.Text = pendingLab.ToString();
            lblStatScanNum.Text = pendingScan.ToString();
            lblStatCompletedNum.Text = completedToday.ToString();
            lblStatProcessingNum.Text = processing.ToString();

            // Today's shift panel
            string shiftName = "Trống";
            string room = "-";
            string dept = "-";
            try
            {
                var todayShift = shiftBUS.GetList().FirstOrDefault(s => s.ShiftDate.Date == DateTime.Today);
                if (todayShift != null)
                {
                    shiftName = todayShift.ShiftName;
                    room = todayShift.Room;
                    dept = todayShift.Department;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading overview shifts: " + ex);
            }

            lblShiftName.Text = shiftName;
            lblShiftRoom.Text = room;
            lblShiftDept.Text = dept;

            // Load pending lists (taking up to 2 items)
            flpLabPending.Controls.Clear();
            var pendingLabList = requests.Where(r => r.Status == "Chờ xử lý" && CMS.Core.Utils.ServiceTypeHelper.IsLabOrEcgService(r.ServiceType)).Take(2).ToList();
            foreach (var req in pendingLabList)
            {
                string priority = string.IsNullOrWhiteSpace(req.Priority) ? "Thường" : req.Priority.Trim();
                Color priorityBack = priority == "Thường" ? Color.FromArgb(243, 244, 246) : Color.FromArgb(254, 226, 226);
                Color priorityFore = priority == "Thường" ? Color.FromArgb(75, 85, 99) : Color.FromArgb(185, 28, 28);
                var patientRow = CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, priority, priorityBack, priorityFore, 0);
                patientRow.Width = PendingRowWidth(flpLabPending);
                flpLabPending.Controls.Add(patientRow);
            }

            flpScanPending.Controls.Clear();
            var pendingScanList = requests.Where(r => r.Status == "Chờ xử lý" && CMS.Core.Utils.ServiceTypeHelper.IsImagingService(r.ServiceType)).Take(2).ToList();
            foreach (var req in pendingScanList)
            {
                var patientRow = CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, "Chờ chụp", Color.FromArgb(254, 249, 195), Color.FromArgb(161, 98, 7), 0);
                patientRow.Width = PendingRowWidth(flpScanPending);
                flpScanPending.Controls.Add(patientRow);
            }
        }

        private static int PendingRowWidth(FlowLayoutPanel host)
        {
            return Math.Max(260, host.ClientSize.Width - 12);
        }

        private void ResizePendingRows()
        {
            ResizeRows(flpLabPending);
            ResizeRows(flpScanPending);
        }

        private static void ResizeRows(FlowLayoutPanel host)
        {
            int width = PendingRowWidth(host);
            foreach (Control row in host.Controls)
            {
                row.Width = width;
            }
        }
    }
}
