using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
