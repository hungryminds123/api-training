using Core.Concrete;
using Core.Interfaces;
using Microsoft.OpenApi.Models;
using TrainingAPI.OptionSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrainingAPI.Extensions;

public static class DependencyRegistration
{
    public static IServiceCollection RegisterJsonWebToken(this IServiceCollection services)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
        services.ConfigureOptions<JwtOptionSetup>();
        services.ConfigureOptions<JwtBearerOptionSetup>();
        return services;
    }


    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http
            });

            x.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    },
                    new List<string>()
                }
            });
        });
        return services;
    }
    
    public static IServiceCollection ConfigureCoreServices(
        this IServiceCollection services
    )
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}