using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAL.Models;
using DTO;
using DTO.Doctor;

namespace ClinicManagementSystem.Winforms.UserControls.Doctor.Khám_bệnh
{
    public partial class ucLabTab : UserControl
    {
        private int encounterId;
        private int doctorId;

        // Constructor mặc định (cho designer)
        public ucLabTab()
        {
            InitializeComponent();
            btnAddLab.Click += BtnAddLab_Click;
        }

        // Constructor có context và user (để đồng bộ, không dùng trực tiếp)
        public ucLabTab(CMSDbContext context, UserDTO currentUser) : this()
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
            foreach (Control control in flpLabs.Controls)
            {
                if (control is not ucLabRequestItem item) continue;

                string serviceName = item.cboLabType.Text.Trim();
                if (string.IsNullOrWhiteSpace(serviceName)) continue;

                requests.Add(new DoctorRequestSaveDTO
                {
                    EncounterID = encounterId,
                    DoctorID = doctorId,
                    RequestType = "Lab",
                    ServiceName = serviceName,
                    Note = item.txtNote.Text.Trim(),
                    Priority = "Normal"
                });
            }
            return requests;
        }

        public void ClearRequests()
        {
            flpLabs.Controls.Clear();
        }

        private void BtnAddLab_Click(object sender, EventArgs e)
        {
            ucLabRequestItem item = new();
            item.Width = Math.Max(300, flpLabs.ClientSize.Width - 25);
            item.DeleteRequested += (s, ev) =>
            {
                flpLabs.Controls.Remove(item);
                item.Dispose();
            };
            flpLabs.Controls.Add(item);
        }
    }
}