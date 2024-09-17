using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction
{
    public interface IApplicationDbContext 
    {
        DbSet<Domain.Entities.UserProfile> UserProfiles { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
