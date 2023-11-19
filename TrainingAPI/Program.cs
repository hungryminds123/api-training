using Core.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using TrainingAPI.Extensions;
using FluentValidation;
using Core.Validators;
using Serilog;
using AutoMapper;
using TrainingAPI.Middleware;

namespace TrainingAPI
{
    /*
     * Database using Code First Approach
     * Entity Framework Migrations
     * Linq and ORM
     * Fluent Validations
     * Automapper
     * Repository Patterm
     * Dependency Injection in .Net Copre  - Transient, Scoped and Sigleton
     * Reading Appsetting.json
     * CORS - Cross Orgin Resource Policy (http://localhost:4200 , http://localhost:4300
     *
     *
     *Middleware
     * Generic Exception Handler
     * Modify Swagger Response/ Explain Swagger
     * Request Pipeline .Net Core
     * Kestrel Server
     * Securing Web API  - Json Web Token
     * Serilog ---
     *
     *
     *
     *  
     * 
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Logging.ClearProviders();
            

            string? environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.{environmentName}.json")
                .Build();
            
            var serilog = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            builder.Services.AddSerilog(serilog);
            
            builder.Services.AddControllers();


           // builder.Services.AddCors();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://example.com",
                                                "http://www.contoso.com")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                                  });
            });
            
            builder.Services.AddValidatorsFromAssemblyContaining<EmployeeViewModelValidator>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            UserSpecificSettings userSpecificSettings = new UserSpecificSettings();
            builder.Configuration.GetSection("UserSpecificSettings").Bind(userSpecificSettings);
              

            builder.Services.AddDbContext<EFLearningContext>(
                x =>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("EFLearningConnectionString"));
            });

            builder.Services.ConfigurePersistenceServices();
            builder.Services.ConfigureCoreServices();

            //builder.Services.AddTransient<IValidator<EmployeeViewModel>, EmployeeViewModelValidator>();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAuthorization();
            builder.Services.RegisterJsonWebToken();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseCors(MyAllowSpecificOrigins);
            
            // Register Middlewares
            app.UseMiddleware<ReadJwtTokenMiddleware>();
            
            app.ConfigureExceptionHandler();    //Injected generic middle ware
            
            app.UseHttpsRedirection();
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}