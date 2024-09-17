using Domain.Repositories;

namespace Persistence.Repository
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return (Task<int>)Task.CompletedTask;
        }
    }
}
