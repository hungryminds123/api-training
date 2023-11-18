using Core.Models;
using Domain;
using Microsoft.EntityFrameworkCore;
using TrainingAPI.Extensions;
using FluentValidation;
using Core.Validators;
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
     *Middlware
     * Generic Exception Handler
     * Modify Swagger Response/ Explain Swagger
     * Request Pipeline .Net Core
     * Kestrel Server
     * Securing Web API  - Json Web Token
     *
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Add services to the container.

            builder.Services.AddControllers();


            builder.Services.AddCors();

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
            app.UseAuthorization();
            app.MapControllers();
            
            
            
            app.Run();
        }
    }
}