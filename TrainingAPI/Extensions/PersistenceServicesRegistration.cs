﻿using Persistence.Repositories.Concrete;
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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
