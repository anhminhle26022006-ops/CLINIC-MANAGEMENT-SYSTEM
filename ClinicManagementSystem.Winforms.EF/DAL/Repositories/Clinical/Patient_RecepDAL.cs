using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class Patient_RecepDAL : IPatientRepository
    {
        public List<PatientDTO> GetAll()
        {
            using var db = new CMSDbContext();

            return db.Patients
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientId,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.Dob.HasValue
                        ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.MinValue,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                })
                .ToList();
        }

        public List<PatientDTO> Search(string term)
        {
            using var db = new CMSDbContext();

            return db.Patients
                .Where(p =>
                    (p.FullName != null &&
                     p.FullName.Contains(term))
                    ||
                    (p.PatientCode != null &&
                     p.PatientCode.Contains(term))
                    ||
                    (p.Phone != null &&
                     p.Phone.Contains(term)))
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientId,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.Dob.HasValue
                        ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.MinValue,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                })
                .ToList();
        }

        public int Add(PatientDTO patient)
        {
            using var db = new CMSDbContext();

            var entity = new Patient
            {
                PatientCode = patient.PatientCode,
                FullName = patient.Name,
                Gender = patient.Gender,
                Dob = patient.BirthDate == null ||
                      patient.BirthDate == DateTime.MinValue
                    ? null
                    : DateOnly.FromDateTime(patient.BirthDate.Value),
                Phone = patient.Phone,
                Address = patient.Address,
                BloodType = patient.BloodType,
                Allergy = patient.Allergy
            };

            db.Patients.Add(entity);

            db.SaveChanges();

            return entity.PatientId;
        }

        public PatientDTO GetById(int id)
        {
            using var db = new CMSDbContext();

            return db.Patients
                .Where(p => p.PatientId == id)
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientId,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.Dob.HasValue
                        ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
                        : DateTime.MinValue,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                })
                .FirstOrDefault();
        }

        public bool Update(PatientDTO patient)
        {
            using var db = new CMSDbContext();

            var entity = db.Patients
                .FirstOrDefault(p =>
                    p.PatientId == patient.PatientID);

            if (entity == null)
                return false;

            entity.FullName = patient.Name;
            entity.Gender = patient.Gender;
            entity.Phone = patient.Phone;
            entity.Address = patient.Address;
            entity.BloodType = patient.BloodType;
            entity.Allergy = patient.Allergy;

            entity.Dob =
                patient.BirthDate == null ||
                patient.BirthDate == DateTime.MinValue
                    ? null
                    : DateOnly.FromDateTime(
                        patient.BirthDate.Value);

            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            using var db = new CMSDbContext();

            var entity = db.Patients
                .FirstOrDefault(p =>
                    p.PatientId == id);

            if (entity == null)
                return false;

            db.Patients.Remove(entity);

            return db.SaveChanges() > 0;
        }

        public int CountPatients()
        {
            using var db = new CMSDbContext();

            return db.Patients.Count();
        }

        public int GetNextPatientId()
        {
            using var db = new CMSDbContext();

            return (db.Patients
                       .Max(p => (int?)p.PatientId) ?? 0)
                   + 1;
        }
    }
}