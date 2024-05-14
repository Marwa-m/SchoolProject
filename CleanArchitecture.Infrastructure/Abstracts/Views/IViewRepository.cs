using CleanArchitecture.Infrastructure.Bases;

namespace CleanArchitecture.Infrastructure.Abstracts.Views
{
    public interface IViewRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}
