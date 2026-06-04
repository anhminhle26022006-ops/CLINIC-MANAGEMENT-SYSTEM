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
            // Anchored layout adjusts itself nicely.
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
            List<RequestDTO> requests = new List<RequestDTO>();
            int pendingLab = 0;
            int pendingScan = 0;
            int completedToday = 0;
            int processing = 0;

            try
            {
                requests = requestBUS.GetList();
                pendingLab = requests.Count(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("Xét nghiệm") || r.ServiceType.Contains("ECG") || r.ServiceType.Contains("Điện tâm đồ")));
                pendingScan = requests.Count(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("Siêu âm")));
                completedToday = requests.Count(r => r.Status == "Hoàn thành" && r.RequestDate.Date == DateTime.Today);
                processing = requests.Count(r => r.Status == "Đang xử lý");
            }
            catch { }

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
            catch { }

            lblShiftName.Text = shiftName;
            lblShiftRoom.Text = room;
            lblShiftDept.Text = dept;

            // Load pending lists (taking up to 2 items)
            flpLabPending.Controls.Clear();
            var pendingLabList = requests.Where(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("Xét nghiệm") || r.ServiceType.Contains("ECG"))).Take(2).ToList();
            foreach (var req in pendingLabList)
            {
                var patientRow = CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, req.Priority, Color.FromArgb(254, 226, 226), Color.FromArgb(185, 28, 28), 0);
                // Adjust width to fit container FlowLayoutPanel
                patientRow.Width = flpLabPending.Width - 15;
                flpLabPending.Controls.Add(patientRow);
            }

            flpScanPending.Controls.Clear();
            var pendingScanList = requests.Where(r => r.Status == "Chờ xử lý" && (r.ServiceType.Contains("MRI") || r.ServiceType.Contains("X-quang") || r.ServiceType.Contains("Siêu âm"))).Take(2).ToList();
            foreach (var req in pendingScanList)
            {
                var patientRow = CreateSmallPatient(req.PatientName, req.ServiceType, "BS: " + req.DoctorName, "Chờ chụp", Color.FromArgb(254, 249, 195), Color.FromArgb(161, 98, 7), 0);
                patientRow.Width = flpScanPending.Width - 15;
                flpScanPending.Controls.Add(patientRow);
            }
        }
    }
}
