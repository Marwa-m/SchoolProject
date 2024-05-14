using System.Data.Common;

namespace CleanArchitecture.Infrastructure.Abstracts.Functions
{
    public interface IInstructorFunctionRepository
    {
        public decimal GetSalarySummationOfInstructor(string query, DbCommand cmd);
    }
}
