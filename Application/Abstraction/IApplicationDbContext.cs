using domain = Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstraction
{
    public interface IApplicationDbContext : IUserProfileRepository
    {
        DbSet<domain.UserProfile> UserProfile { get; set; }
    }
}
