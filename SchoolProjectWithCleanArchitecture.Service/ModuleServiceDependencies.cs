using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SchoolProjectWithCleanArchitecture.Infrastructure.Interfaces;
using SchoolProjectWithCleanArchitecture.Infrastructure.Repositories;
using SchoolProjectWithCleanArchitecture.Service.Abstract;
using SchoolProjectWithCleanArchitecture.Service.Implementation;

namespace SchoolProjectWithCleanArchitecture.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IInstructorService, InstructorService>();
            return services;
        }
    }
}