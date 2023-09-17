using Microsoft.Extensions.DependencyInjection;
using SchoolProjectWithCleanArchitecture.Infrastructure.InfrastructureBases;
using SchoolProjectWithCleanArchitecture.Infrastructure.Interfaces;
using SchoolProjectWithCleanArchitecture.Infrastructure.Repositories;


namespace SchoolProjectWithCleanArchitecture.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IInstructorsRepository, InstructorsRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));


            return services; ;
        }

    }
}