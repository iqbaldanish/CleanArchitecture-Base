using Domain.Entities;
using Domain.Repositories;

namespace Persistence.Repository
{
    internal sealed class UserProfileRepository : IUserProfileRepository
    {
        public async Task<UserProfile?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            return null;
        }

        public void Insert(UserProfile userProfile)
        {
            throw new NotImplementedException();
        }
    }
}
