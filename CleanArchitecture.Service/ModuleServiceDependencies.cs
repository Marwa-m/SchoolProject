using CleanArchitecture.Service.Abstracts;
using CleanArchitecture.Service.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
