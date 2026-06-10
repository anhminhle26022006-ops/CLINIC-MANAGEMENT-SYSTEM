using DAL.DataContext;
using DAL.Entities;
using DAL.Interfaces.Clinical;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class Patient_RecepDAL : IPatientRepository
    {
        public async Task<List<PatientDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Patients
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
                .ToListAsync();
        }

        public async Task<List<PatientDTO>> Search(string term)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Patients
                .Where(p => p.FullName.Contains(term)
                         || p.PatientCode.Contains(term)
                         || p.Phone.Contains(term))
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
                .ToListAsync();
        }

        public async Task<int> Add(PatientDTO patient)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new Patient
            {
                PatientCode = patient.PatientCode,
                FullName = patient.Name,
                Gender = patient.Gender,
                DOB = patient.BirthDate == DateTime.MinValue ? null : patient.BirthDate,
                Phone = patient.Phone,
                Address = patient.Address,
                BloodType = patient.BloodType,
                Allergy = patient.Allergy
            };
            context.Patients.Add(entity);
            await context.SaveChangesAsync();
            return entity.PatientID;
        }

        public async Task<PatientDTO> GetById(int id)
        {
            using var context = DbContextProvider.CreateContext();
            var p = await context.Patients
                .FirstOrDefaultAsync(p => p.PatientID == id);

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

        public async Task<bool> Update(PatientDTO patient)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Patients
                .FirstOrDefaultAsync(p => p.PatientID == patient.PatientID);

            if (entity == null) return false;

            entity.FullName = patient.Name;
            entity.DOB = patient.BirthDate == DateTime.MinValue ? null : patient.BirthDate;
            entity.Gender = patient.Gender;
            entity.Phone = patient.Phone;
            entity.Address = patient.Address;
            entity.BloodType = patient.BloodType;
            entity.Allergy = patient.Allergy;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = await context.Patients
                .FirstOrDefaultAsync(p => p.PatientID == id);

            if (entity == null) return false;

            context.Patients.Remove(entity);
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> CountPatients()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Patients.CountAsync();
        }

        public async Task<int> GetNextPatientId()
        {
            using var context = DbContextProvider.CreateContext();
            int max = await context.Patients
                .MaxAsync(p => (int?)p.PatientID) ?? 0;
            return max + 1;
        }
    }
}