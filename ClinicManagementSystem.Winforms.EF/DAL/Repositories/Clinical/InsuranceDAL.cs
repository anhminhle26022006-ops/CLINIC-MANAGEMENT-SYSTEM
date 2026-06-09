using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataContext;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL.Repositories
{
    public class InsuranceDAL
    {
        public bool Add(PatientInsuranceDTO insurance)
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

            SqlParameter[] parameters =
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
