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
                new UserProfile(777, "Murphy","Richard"),
                new UserProfile(888, "Mohammad", "Ali"),
                new UserProfile(999, "Krishnalal", "Kanhaiya")
            );
        }

        //We can do this in "Program.cs" of the WebAPI Layer
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{            
        //    optionsBuilder.UseInMemoryDatabase("cleanlearning");
        //}        
    }
}
