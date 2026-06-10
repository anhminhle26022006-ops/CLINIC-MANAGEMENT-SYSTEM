using DAL.DataContext;
using DAL.Entities;
using DTO;

namespace DAL.Repositories.Clinical
{
    public class InsuranceDAL
    {
        public async Task<bool> Add(PatientInsuranceDTO insurance)
        {
            string query = @"
                INSERT INTO PatientInsurance
                (
                    PatientID,
                    InsuranceNumber,
                    Provider,
                    EffectiveDate,
                    ExpiryDate
                )
                VALUES
                (
                    @PatientID,
                    @InsuranceNumber,
                    @Provider,
                    @EffectiveDate,
                    @ExpiryDate
                )";

            var entity = new PatientInsurance
            {
                new SqlParameter("@PatientID", insurance.PatientID),
                new SqlParameter("@InsuranceNumber",
                    (object)insurance.InsuranceNumber ?? DBNull.Value),
                new SqlParameter("@Provider",
                    (object)insurance.Provider ?? DBNull.Value),
                new SqlParameter("@EffectiveDate",
                    insurance.EffectiveDate),
                new SqlParameter("@ExpiryDate",
                    insurance.ExpiryDate)
            };

            return DatabaseHelper.ExecuteNonQuery(
                query,
                parameters) > 0;
        }
    }
}