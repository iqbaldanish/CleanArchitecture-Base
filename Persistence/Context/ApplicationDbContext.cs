using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Abstraction;
using MediatR;


namespace Persistence.Context
{
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        DbSet<UserProfile> IApplicationDbContext.UserProfiles { get ; set ; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            Database.EnsureCreated();
        }        

        //protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>().HasKey(p => p.Id);
            modelBuilder.Entity<UserProfile>().HasData(
                new UserProfile(Guid.NewGuid(), "Murphy","Richard"),
                new UserProfile(Guid.NewGuid(), "Mohammad", "Ali"),
                new UserProfile(Guid.NewGuid(), "Krishnalal", "Kanhaiya")
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseInMemoryDatabase("cleanlearning");
        }
    }
}
