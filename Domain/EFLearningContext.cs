using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class EFLearningContext : DbContext
    {
        public EFLearningContext(DbContextOptions<EFLearningContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFLearningContext).Assembly);
        }
        
        public DbSet<Employee> Employees { get; set;}
    }
}
