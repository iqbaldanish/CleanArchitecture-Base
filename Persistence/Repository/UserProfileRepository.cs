using Domain.Entities;
using Domain.Repositories;
using Persistence.Context;

namespace Persistence.Repository
{
    internal sealed class UserProfileRepository : IUserProfileRepository
    {             

        private readonly ApplicationDbContext _dbContext;

        public UserProfileRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Insert(UserProfile userProfile) => _dbContext.Set<UserProfile>().Add(userProfile);
        //await context.UserProfiles.AddAsync(product);
        //await context.SaveChangesAsync();

        public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return null;
        }
    }
}
