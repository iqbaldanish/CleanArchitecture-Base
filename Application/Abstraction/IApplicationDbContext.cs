using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction
{
    public interface IApplicationDbContext : IUserProfileRepository
    {
        DbSet<Domain.Entities.UserProfile> UserProfiles { get; set; }
    }
}
