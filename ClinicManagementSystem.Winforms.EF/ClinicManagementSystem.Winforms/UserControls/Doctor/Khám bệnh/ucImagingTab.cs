using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucImagingTab : UserControl
    {
        private int encounterId;
        private int doctorId;

        // Constructor mặc định (cho designer)
        public ucImagingTab()
        {
            InitializeComponent();
            btnAddImaging.Click += BtnAddImaging_Click;
        }

        // Constructor có context và user (để đồng bộ, không dùng trực tiếp)
        public ucImagingTab(CMSDbContext context, UserDTO currentUser) : this()
        {
            // Không cần xử lý thêm vì tab này không dùng database trực tiếp
        }

        public void SetContext(int encounterId, int doctorId)
        {
            this.encounterId = encounterId;
            this.doctorId = doctorId;
        }

        public List<DoctorRequestSaveDTO> BuildRequests()
        {
            List<DoctorRequestSaveDTO> requests = new();
            foreach (Control control in flpImagings.Controls)
            {
                if (control is not ucImagingRequestItem item) continue;
                string serviceName = item.cboImagingType.Text.Trim();
                if (string.IsNullOrWhiteSpace(serviceName)) continue;
                requests.Add(new DoctorRequestSaveDTO
                {
                    EncounterID = encounterId,
                    DoctorID = doctorId,
                    RequestType = "Imaging",
                    ServiceName = serviceName,
                    Note = item.txtNote.Text.Trim(),
                    Priority = "Normal"
                });
            }
            return requests;
        }

        public void ClearRequests()
        {
            flpImagings.Controls.Clear();
        }

        private void BtnAddImaging_Click(object sender, EventArgs e)
        {
            ucImagingRequestItem item = new();
            item.Width = Math.Max(300, flpImagings.ClientSize.Width - 25);
            item.DeleteRequested += (s, ev) =>
            {
                flpImagings.Controls.Remove(item);
                item.Dispose();
            };
            flpImagings.Controls.Add(item);
        }
    }
}