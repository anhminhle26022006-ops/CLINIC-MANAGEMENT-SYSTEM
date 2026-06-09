using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO.Clinical.erm;
using DAL.Interfaces.ERM;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.ERM
{
    public class ERMRepository : IERMRepository
    {
        public async Task<PatientERMDto> GetPatientERM(Guid patientUUID)
        {
            using (var context = new ClinicDbContext())
            {
                var patient = await context.Patients
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.PatientUUID == patientUUID);

                if (patient == null) return null;

                var patientDto = new PatientERMDto
                {
                    PatientUUID = patientUUID,
                    PatientCode = patient.PatientCode,
                    FullName = patient.FullName,
                    Gender = patient.Gender,
                    DOB = patient.DOB ?? DateTime.MinValue,
                    Phone = patient.Phone ?? "",
                    Address = patient.Address ?? "",
                    BloodType = patient.BloodType ?? "",
                    Allergy = patient.Allergy ?? "",
                    Encounters = new List<EncounterHistoryDto>()
                };

                var encounters = await context.Encounters
                    .AsNoTracking()
                    .Where(e => e.PatientID == patient.PatientID)
                    .OrderByDescending(e => e.StartTime)
                    .Select(e => new { e.EncounterID, e.StartTime })
                    .ToListAsync();

                foreach (var enc in encounters)
                {
                    var encounterDto = new EncounterHistoryDto
                    {
                        EncounterId = enc.EncounterID,
                        VisitDate = enc.StartTime ?? DateTime.MinValue
                    };
                    
                    encounterDto.Prescriptions = await context.Prescriptions
                        .AsNoTracking()
                        .Where(p => p.EncounterID == enc.EncounterID)
                        .Select(p => new PrescriptionHistoryDto
                        {
                            PrescriptionCode = p.PrescriptionID.ToString(),
                            CreatedAt = p.CreatedAt,
                            DoctorName = "Doctor"
                        })
                        .ToListAsync();

                    encounterDto.LabResults = await context.LabRequests
                        .AsNoTracking()
                        .Where(l => l.EncounterID == enc.EncounterID)
                        .Select(l => new LabHistoryDto
                        {
                            TestType = l.TestType,
                            Status = l.Status
                        })
                        .ToListAsync();

                    encounterDto.ImagingResults = await context.ImagingRequests
                        .AsNoTracking()
                        .Where(i => i.EncounterID == enc.EncounterID)
                        .Select(i => new ImagingHistoryDto
                        {
                            BodyPart = i.BodyPart,
                            Modality = "Unknown",
                            CreatedAt = i.CreatedAt,
                            Conclusion = "",
                            ImageUrl = null,
                            PdfUrl = null
                        })
                        .ToListAsync();

                    encounterDto.Invoices = await context.Invoices
                        .AsNoTracking()
                        .Where(inv => inv.EncounterID == enc.EncounterID)
                        .Select(inv => new InvoiceHistoryDto
                        {
                            TotalAmount = inv.Total ?? 0,
                            Status = inv.Status,
                            InvoiceDate = inv.CreatedAt,
                            PaymentMethod = "Cash",
                            Services = new List<ServiceItemDto>()
                        })
                        .ToListAsync();

                    var vs = await context.VitalSigns
                        .AsNoTracking()
                        .Where(v => v.EncounterID == enc.EncounterID)
                        .OrderByDescending(v => v.CreatedAt)
                        .FirstOrDefaultAsync();

                    if (vs != null)
                    {
                        encounterDto.VitalSigns = new VitalSignDto
                        {
                            Temperature = vs.Temperature ?? 0,
                            BloodPressure = vs.BloodPressure ?? "",
                            HeartRate = vs.HeartRate ?? 0,
                            Weight = vs.Weight ?? 0
                        };
                    }
                    else
                    {
                        encounterDto.VitalSigns = new VitalSignDto();
                    }

                    patientDto.Encounters.Add(encounterDto);
                }

                return patientDto;
            }
        }
    }
}
