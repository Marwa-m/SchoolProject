using CleanArchitecture.Infrastructure.Abstracts.Functions;
using System.Data.Common;

namespace CleanArchitecture.Infrastructure.Repositories.Functions
{
    public class InstructorFunctionRepository : IInstructorFunctionRepository
    {
        #region Fields

        #endregion

        #region CTOR

        #endregion

        #region Function

        public decimal GetSalarySummationOfInstructor(string query, DbCommand cmd)
        {
            cmd.CommandText = query;
            var value = cmd.ExecuteScalar();

            if (!decimal.TryParse(value.ToString(), out decimal result))
                return 0;
            return result;
        }

        #endregion
    }
}
