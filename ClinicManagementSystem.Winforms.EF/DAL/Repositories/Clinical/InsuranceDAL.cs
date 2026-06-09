using DAL.Models;
using DTO;

namespace DAL.Repositories
{
    public class InsuranceDAL
    {
        public bool Add(PatientInsuranceDTO insurance)
        {
            using var db = new CMSDbContext();

            var entity = new PatientInsurance
            {
                PatientId = insurance.PatientID,
                InsuranceNumber = insurance.InsuranceNumber,
                Provider = insurance.Provider,
                EffectiveDate = DateOnly.FromDateTime(
        insurance.EffectiveDate),

                ExpiryDate = DateOnly.FromDateTime(
        insurance.ExpiryDate)
            };

            db.PatientInsurances.Add(entity);

            return db.SaveChanges() > 0;
        }
    }
}