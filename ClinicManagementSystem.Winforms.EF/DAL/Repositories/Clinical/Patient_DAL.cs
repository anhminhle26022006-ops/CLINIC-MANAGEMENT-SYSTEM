using DAL.DataContext;
using DAL.Entities;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.Clinical
{
    public class PatientDAL
    {
        private static readonly string[] ExcludedPrefixes = { "BS", "EMP", "KTV" };

        public async Task<List<PatientDTO>> GetAll()
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Patients
                .Where(p => !ExcludedPrefixes.Any(prefix => p.PatientCode.StartsWith(prefix)))
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientID,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.DOB,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? ""
                })
                .ToListAsync();
        }

        public async Task<List<PatientDTO>> Search(string term)
        {
            using var context = DbContextProvider.CreateContext();
            return await context.Patients
                .Where(p => !ExcludedPrefixes.Any(prefix => p.PatientCode.StartsWith(prefix))
                         && (p.FullName.Contains(term)
                          || p.PatientCode.Contains(term)
                          || p.Phone.Contains(term)))
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientID,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.DOB,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? ""
                })
                .ToListAsync();
        }

        public async Task<bool> Add(PatientDTO patient)
        {
            using var context = DbContextProvider.CreateContext();
            var entity = new Patient
            {
                PatientCode = patient.PatientCode,
                FullName = patient.Name,
                DOB = patient.BirthDate,
                Gender = patient.Gender,
                Phone = patient.Phone,
                Address = patient.Address
            };
            context.Patients.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}