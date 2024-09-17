using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public sealed class ApplicationDbContext:DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseInMemoryDatabase("learningcqrs");
        }
    }
}
