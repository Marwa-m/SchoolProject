using CleanArchitecture.Data.Entities.Views;
using CleanArchitecture.Infrastructure.Abstracts;
using CleanArchitecture.Infrastructure.Abstracts.Functions;
using CleanArchitecture.Infrastructure.Abstracts.Procedures;
using CleanArchitecture.Infrastructure.Abstracts.Views;
using CleanArchitecture.Infrastructure.Bases;
using CleanArchitecture.Infrastructure.Repositories;
using CleanArchitecture.Infrastructure.Repositories.Functions;
using CleanArchitecture.Infrastructure.Repositories.Procedures;
using CleanArchitecture.Infrastructure.Repositories.Views;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {

            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorRepository, InstructorRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IViewRepository<ViewDepartment>, ViewDepartmentRepository>();
            services.AddTransient<IDepartmentStudentCountProcRepository, DepartmentStudentCountProcRepository>();
            services.AddTransient<IInstructorFunctionRepository, InstructorFunctionRepository>();

            return services;
        }
    }
}
