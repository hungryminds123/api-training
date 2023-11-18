using Core.Concrete;
using Core.Interfaces;
using Persistence.Repositories.Concrete;
using Persistence.Repositories.Interface;

namespace TrainingAPI.Extensions
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(
            this IServiceCollection services
            )
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            return services;
        }

        public static IServiceCollection ConfigureCoreServices(
           this IServiceCollection services
           )
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }

    }
}
