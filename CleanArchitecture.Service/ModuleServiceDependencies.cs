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
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
