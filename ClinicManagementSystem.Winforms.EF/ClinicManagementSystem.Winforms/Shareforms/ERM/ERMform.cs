using ClinicManagementSystem.Winforms.Controllers;
using DTO.Clinical.erm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicManagementSystem.Winforms.Shareforms.ERM
{
    public partial class ERMform : Form
    {
        private ERMController _controller;
        private PatientERMDto _patient;
        private Guid _patientId;
        public ERMform()
        {
            InitializeComponent();
        }
        public ERMform(ERMController controller, Guid patientId)
        {
            InitializeComponent();
            _controller = controller;
            _patientId = patientId;

            Load += ERMform_Load;
        }
        public void Bind(PatientERMDto patient)
        {
            lblPatientName.Text = patient.FullName;
            lblPatientCode.Text = patient.PatientCode;
            lblGender.Text = patient.Gender;
            lblBloodType.Text = patient.BloodType;
        }
        private async void ERMform_Load(object sender, EventArgs e)
        {
            if (_controller == null || _patientId == Guid.Empty)
            {
                MessageBox.Show("Không đủ dữ liệu để mở ERM.");
                Close();
                return;
            }
           
            _patient = await _controller.GetPatientERMAsync(_patientId);

            if (_patient == null)
            {
                MessageBox.Show("Không tìm thấy bệnh nhân");
                Close();
                return;
            }

            EnsureDemoSections();
            BindHeader();
            LoadDefaultTab();
        }
       
        private void BindHeader()
        {
            lblPatientName.Text = _patient.FullName;
            lblPatientCode.Text = _patient.PatientCode;

            lblGender.Text = _patient.Gender;

            lblAge.Text = $"{DateTime.Now.Year - _patient.DOB.Year} tuổi";

            lblBloodType.Text = $"Nhóm máu: {_patient.BloodType}";
        }
        private void ShowTab(UserControl control)
        {
            foreach (Control c in pnlContent.Controls)
                c.Visible = false;

            control.Visible = true;
            control.BringToFront();
        }
        private void LoadDefaultTab()
        {
            ShowTab(ucOverview1);

            ucOverview1.Bind(_patient);
        }
        private void btnOverview_Click(object sender, EventArgs e)
        {
            ShowTab(ucOverview1);
            ucOverview1.Bind(_patient);
        }
        private void btnHistory_Click(object sender, EventArgs e)
        {
            ShowTab(ucHistory1);
            ucHistory1.Bind(_patient.Encounters);
        }
        private void btnPrescription_Click(object sender, EventArgs e)
        {
            ShowTab(ucPrescription1);
            ucPrescription1.Bind(_patient.Encounters);
        }
        private void btnLab_Click(object sender, EventArgs e)
        {
            ShowTab(ucLab1);
            ucLab1.Bind(_patient.LabResults);
        }
        private void btnImaging_Click(object sender, EventArgs e)
        {
            ShowTab(ucImaging1);
            ucImaging1.Bind(_patient.ImagingResults);
        }
        private void btnBilling_Click(object sender, EventArgs e)
        {
            ShowTab(ucBilling1);
            ucBilling1.Bind(_patient.Invoices);
        }
        private void btnFollowup_Click(object sender, EventArgs e)
        {
            ShowTab(ucFollowup1);
            ucFollowup1.Bind(_patient.FollowUps);
        }

        private void EnsureDemoSections()
        {
            _patient.Encounters ??= new List<EncounterHistoryDto>();
            _patient.Prescriptions ??= new List<PrescriptionHistoryDto>();
            _patient.LabResults ??= new List<LabHistoryDto>();
            _patient.ImagingResults ??= new List<ImagingHistoryDto>();
            _patient.Invoices ??= new List<InvoiceHistoryDto>();
            _patient.FollowUps ??= new List<FollowUpHistoryDto>();

            if (_patient.Encounters.Count == 0)
            {
                _patient.Encounters.Add(new EncounterHistoryDto
                {
                    VisitDate = DateTime.Today,
                    DoctorName = "BS GP 1",
                    DepartmentName = "Khám tổng quát",
                    Symptoms = "Ho khan, đau họng, mệt nhẹ",
                    Diagnosis = "Viêm họng cấp",
                    Conclusion = "Điều trị ngoại trú, theo dõi triệu chứng",
                    VitalSigns = new VitalSignDto
                    {
                        BloodPressure = "120/80",
                        Temperature = 37.2m,
                        HeartRate = 82,
                        Height = 170,
                        Weight = 68
                    },
                    Prescriptions = new List<PrescriptionHistoryDto>(),
                    LabResults = new List<LabHistoryDto>(),
                    ImagingResults = new List<ImagingHistoryDto>(),
                    Invoices = new List<InvoiceHistoryDto>(),
                    FollowUps = new List<FollowUpHistoryDto>()
                });
            }

            var encounter = _patient.Encounters.First();
            encounter.Prescriptions ??= new List<PrescriptionHistoryDto>();
            encounter.LabResults ??= new List<LabHistoryDto>();
            encounter.ImagingResults ??= new List<ImagingHistoryDto>();
            encounter.Invoices ??= new List<InvoiceHistoryDto>();
            encounter.FollowUps ??= new List<FollowUpHistoryDto>();

            if (_patient.LabResults.Count == 0)
            {
                _patient.LabResults.Add(new LabHistoryDto
                {
                    TestType = "Công thức máu",
                    CreatedAt = DateTime.Today.AddHours(9),
                    DoctorName = string.IsNullOrWhiteSpace(encounter.DoctorName) ? "BS GP 1" : encounter.DoctorName,
                    Status = "Completed",
                    ResultItems = new List<LabResultItemDto>
                    {
                        new LabResultItemDto { Name = "WBC", Value = "8.2", Unit = "G/L", ReferenceRange = "4.0-10.0" },
                        new LabResultItemDto { Name = "RBC", Value = "4.72", Unit = "T/L", ReferenceRange = "4.2-5.8" },
                        new LabResultItemDto { Name = "HGB", Value = "143", Unit = "g/L", ReferenceRange = "120-160" },
                        new LabResultItemDto { Name = "PLT", Value = "268", Unit = "G/L", ReferenceRange = "150-400" }
                    }
                });
            }

            if (_patient.ImagingResults.Count == 0)
            {
                _patient.ImagingResults.Add(new ImagingHistoryDto
                {
                    Modality = "X-Ray",
                    BodyPart = "Phổi",
                    DoctorName = string.IsNullOrWhiteSpace(encounter.DoctorName) ? "BS GP 1" : encounter.DoctorName,
                    PatientName = _patient.FullName,
                    CreatedAt = DateTime.Today.AddHours(9).AddMinutes(30),
                    Conclusion = "Phế trường hai bên thông khí tốt, không ghi nhận tổn thương cấp tính",
                    ImageUrl = ResolveDemoResource("Resources", "Screenshot 2026-06-08 132926.png")
                });
            }

            if (_patient.Invoices.Count == 0)
            {
                _patient.Invoices.Add(new InvoiceHistoryDto
                {
                    InvoiceDate = DateTime.Today.AddHours(10),
                    TotalAmount = 430000,
                    Status = "Đã thanh toán",
                    PaymentMethod = "Cash",
                    Services = new List<ServiceItemDto>
                    {
                        new ServiceItemDto { ServiceName = "Khám tổng quát", Quantity = 1, Price = 100000 },
                        new ServiceItemDto { ServiceName = "Công thức máu", Quantity = 1, Price = 150000 },
                        new ServiceItemDto { ServiceName = "Chẩn đoán hình ảnh", Quantity = 1, Price = 180000 }
                    }
                });
            }

            if (_patient.FollowUps.Count == 0)
            {
                _patient.FollowUps.Add(new FollowUpHistoryDto
                {
                    FollowUpDate = DateTime.Today.AddDays(7).AddHours(8).AddMinutes(30),
                    DoctorName = string.IsNullOrWhiteSpace(encounter.DoctorName) ? "BS GP 1" : encounter.DoctorName,
                    Status = "Đã hẹn",
                    Content = "Tái khám sau 7 ngày hoặc quay lại sớm nếu sốt cao, khó thở, đau tăng."
                });
            }

            encounter.LabResults = _patient.LabResults;
            encounter.ImagingResults = _patient.ImagingResults;
            encounter.Invoices = _patient.Invoices;
            encounter.FollowUps = _patient.FollowUps;
        }

        private static string ResolveDemoResource(params string[] parts)
        {
            var relative = Path.Combine(parts);
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;
            var candidates = new[]
            {
                Path.Combine(baseDir, relative),
                Path.Combine(baseDir, "..", "..", "..", relative),
                Path.Combine(baseDir, "..", "..", "..", "..", relative),
                Path.Combine(baseDir, "..", "..", "..", "..", "..", relative)
            };

            foreach (var candidate in candidates)
            {
                var fullPath = Path.GetFullPath(candidate);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            return null;
        }
    }
}
