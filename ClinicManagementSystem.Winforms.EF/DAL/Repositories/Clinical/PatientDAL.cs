using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Repositories
{
    public class PatientDAL
    {
        public List<PatientDTO> GetAll()
        {
            using ClinicDbContext context = new ClinicDbContext();
            return context.Patients
                .AsNoTracking()
                .Where(p => !p.PatientCode.StartsWith("BS")
                    && !p.PatientCode.StartsWith("EMP")
                    && !p.PatientCode.StartsWith("KTV"))
                .OrderBy(p => p.FullName)
                .Select(p => MapToDTO(p))
                .ToList();
        }

        public List<PatientDTO> Search(string term)
        {
            using ClinicDbContext context = new ClinicDbContext();
            term = term?.Trim() ?? "";

            IQueryable<Patient> query = context.Patients
                .AsNoTracking()
                .Where(p => !p.PatientCode.StartsWith("BS")
                    && !p.PatientCode.StartsWith("EMP")
                    && !p.PatientCode.StartsWith("KTV"));

            if (!string.IsNullOrWhiteSpace(term))
            {
                string pattern = "%" + term + "%";
                query = query.Where(p =>
                    EF.Functions.Like(p.FullName, pattern)
                    || EF.Functions.Like(p.PatientCode, pattern)
                    || EF.Functions.Like(p.Phone, pattern));
            }

            return query
                .OrderBy(p => p.FullName)
                .Select(p => MapToDTO(p))
                .ToList();
        }

        public bool Add(PatientDTO patient)
        {
            using ClinicDbContext context = new ClinicDbContext();
            context.Patients.Add(new Patient
            {
                PatientUUID = Guid.NewGuid(),
                PatientCode = patient.PatientCode,
                FullName = patient.Name,
                DOB = patient.BirthDate,
                Gender = patient.Gender,
                Phone = patient.Phone,
                Address = patient.Address,
                CreatedAt = DateTime.Now
            });
            return context.SaveChanges() > 0;
        }

        private static PatientDTO MapToDTO(Patient patient)
        {
            return new PatientDTO
            {
                PatientID = patient.PatientID,
                PatientCode = patient.PatientCode,
                Name = patient.FullName,
                BirthDate = patient.DOB,
                Gender = patient.Gender,
                Phone = patient.Phone ?? "",
                Address = patient.Address ?? ""
            };
        }
    }
}
