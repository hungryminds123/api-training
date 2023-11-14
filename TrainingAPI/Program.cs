using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TrainingAPI.Extensions;

namespace TrainingAPI
{
    /*
     * Database using Code First Approach
     * Entity Framework Migrations
     * Linq and ORM
     * Fluent Validations
     * Automapper
     * Repository Patterm
     * Dependency Injection in .Net Copre
     *
     *
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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<EFLearningContext>(x =>
            {
                x.UseSqlServer("Server=.;Database=EFLearning;Trusted_Connection=True;TrustServerCertificate=True");
            });


            builder.Services.ConfigurePersistenceServices();
            builder.Services.ConfigureCoreServices();
            
            
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}