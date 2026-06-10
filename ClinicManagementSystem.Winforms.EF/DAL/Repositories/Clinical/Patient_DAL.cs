using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class PatientDAL
    {
        public List<PatientDTO> GetAll()
        {
            using var db = new CMSDbContext();

            return db.Patients
                .Where(p =>
                    !p.PatientCode.StartsWith("BS") &&
                    !p.PatientCode.StartsWith("EMP") &&
                    !p.PatientCode.StartsWith("KTV"))
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientId,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.Dob.HasValue
                        ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
                        : null,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? ""
                })
                .ToList();
        }

        public List<PatientDTO> Search(string term)
        {
            using var db = new CMSDbContext();

            return db.Patients
                .Where(p =>
                    (p.FullName.Contains(term) ||
                     p.PatientCode.Contains(term) ||
                     p.Phone.Contains(term))
                    &&
                    !p.PatientCode.StartsWith("BS")
                    &&
                    !p.PatientCode.StartsWith("EMP")
                    &&
                    !p.PatientCode.StartsWith("KTV"))
                .Select(p => new PatientDTO
                {
                    PatientID = p.PatientId,
                    PatientCode = p.PatientCode,
                    Name = p.FullName,
                    BirthDate = p.Dob.HasValue
                        ? p.Dob.Value.ToDateTime(TimeOnly.MinValue)
                        : null,
                    Gender = p.Gender,
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? ""
                })
                .ToList();
        }

        public bool Add(PatientDTO patient)
        {
            using var db = new CMSDbContext();

            db.Patients.Add(new Patient
            {
                PatientCode = patient.PatientCode,
                FullName = patient.Name,
                Dob = patient.BirthDate.HasValue
                    ? DateOnly.FromDateTime(patient.BirthDate.Value)
                    : null,
                Gender = patient.Gender,
                Phone = patient.Phone,
                Address = patient.Address
            });

            return db.SaveChanges() > 0;
        }
    }
}