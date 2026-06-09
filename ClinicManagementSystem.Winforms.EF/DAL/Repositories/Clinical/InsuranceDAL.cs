using System;
using System.Linq;
using DAL.DataContext;
using DTO;
using Models;

namespace DAL.Repositories
{
    public class InsuranceDAL
    {
        public bool Add(PatientInsuranceDTO insurance)
        {
            using (var context = new ClinicDbContext())
            {
                var pi = new PatientInsurance
                {
                    PatientID = insurance.PatientID,
                    InsuranceNumber = insurance.InsuranceNumber,
                    Provider = insurance.Provider,
                    EffectiveDate = insurance.EffectiveDate,
                    ExpiryDate = insurance.ExpiryDate
                };
                context.PatientInsurances.Add(pi);
                return context.SaveChanges() > 0;
            }
        }
    }
}
