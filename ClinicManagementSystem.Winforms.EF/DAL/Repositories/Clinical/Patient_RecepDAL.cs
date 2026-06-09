using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using DAL.Interfaces;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Patient_RecepDAL : IPatientRepository
    {
        public List<PatientDTO> GetAll()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Patients
                    .AsNoTracking()
                    .Select(p => new PatientDTO
                    {
                        PatientID = p.PatientID,
                        PatientCode = p.PatientCode ?? "",
                        Name = p.FullName ?? "",
                        BirthDate = p.DOB ?? DateTime.MinValue,
                        Gender = p.Gender ?? "",
                        Phone = p.Phone ?? "",
                        Address = p.Address ?? "",
                        BloodType = p.BloodType ?? "",
                        Allergy = p.Allergy ?? ""
                    })
                    .ToList();
            }
        }

        public List<PatientDTO> Search(string term)
        {
            using (var context = new ClinicDbContext())
            {
                if (string.IsNullOrWhiteSpace(term))
                    return GetAll();
                
                term = term.Trim().ToLower();
                return context.Patients
                    .AsNoTracking()
                    .Where(p => (p.FullName != null && p.FullName.ToLower().Contains(term))
                             || (p.PatientCode != null && p.PatientCode.ToLower().Contains(term))
                             || (p.Phone != null && p.Phone.Contains(term)))
                    .Select(p => new PatientDTO
                    {
                        PatientID = p.PatientID,
                        PatientCode = p.PatientCode ?? "",
                        Name = p.FullName ?? "",
                        BirthDate = p.DOB ?? DateTime.MinValue,
                        Gender = p.Gender ?? "",
                        Phone = p.Phone ?? "",
                        Address = p.Address ?? "",
                        BloodType = p.BloodType ?? "",
                        Allergy = p.Allergy ?? ""
                    })
                    .ToList();
            }
        }

        public int Add(PatientDTO patient)
        {
            using (var context = new ClinicDbContext())
            {
                var newPatient = new Patient
                {
                    PatientUUID = Guid.NewGuid(),
                    PatientCode = patient.PatientCode,
                    FullName = patient.Name,
                    Gender = patient.Gender,
                    DOB = patient.BirthDate,
                    Phone = patient.Phone,
                    Address = patient.Address,
                    BloodType = patient.BloodType,
                    Allergy = patient.Allergy,
                    CreatedAt = DateTime.Now
                };
                context.Patients.Add(newPatient);
                context.SaveChanges();
                return newPatient.PatientID;
            }
        }

        public PatientDTO GetById(int id)
        {
            using (var context = new ClinicDbContext())
            {
                var p = context.Patients.AsNoTracking().FirstOrDefault(x => x.PatientID == id);
                if (p == null) return null;
                return new PatientDTO
                {
                    PatientID = p.PatientID,
                    PatientCode = p.PatientCode ?? "",
                    Name = p.FullName ?? "",
                    BirthDate = p.DOB ?? DateTime.MinValue,
                    Gender = p.Gender ?? "",
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                };
            }
        }

        public bool Update(PatientDTO patient)
        {
            using (var context = new ClinicDbContext())
            {
                var p = context.Patients.FirstOrDefault(x => x.PatientID == patient.PatientID);
                if (p == null) return false;
                p.FullName = patient.Name;
                p.DOB = patient.BirthDate;
                p.Gender = patient.Gender;
                p.Phone = patient.Phone;
                p.Address = patient.Address;
                p.BloodType = patient.BloodType;
                p.Allergy = patient.Allergy;
                return context.SaveChanges() > 0;
            }
        }

        public int CountPatients()
        {
            using (var context = new ClinicDbContext())
            {
                return context.Patients.Count();
            }
        }

        public int GetNextPatientId()
        {
            using (var context = new ClinicDbContext())
            {
                return (context.Patients.Max(p => (int?)p.PatientID) ?? 0) + 1;
            }
        }
    }
}
