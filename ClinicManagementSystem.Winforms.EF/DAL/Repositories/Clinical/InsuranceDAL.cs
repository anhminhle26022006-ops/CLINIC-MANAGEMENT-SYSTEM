using DAL.DataContext;
using DAL.Entities;
using DTO;

namespace DAL.Repositories.Clinical
{
    public class InsuranceDAL
    {
        public async Task<bool> Add(PatientInsuranceDTO insurance)
        {
            using var context = DbContextProvider.CreateContext();

            var entity = new PatientInsurance
            {
                PatientID = insurance.PatientID,
                InsuranceNumber = insurance.InsuranceNumber,
                Provider = insurance.Provider,
                EffectiveDate = insurance.EffectiveDate,
                ExpiryDate = insurance.ExpiryDate
            };

            context.PatientInsurances.Add(entity);
            return await context.SaveChangesAsync() > 0;
        }
    }
}