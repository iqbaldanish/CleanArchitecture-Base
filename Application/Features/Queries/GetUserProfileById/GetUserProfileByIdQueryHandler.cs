using MediatR;
using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Application.Features.Queries.GetUserProfileById
{
    internal sealed class GetUserProfileByIdQueryHandler (IApplicationDbContext context) : IRequestHandler<GetUserProfileByIdQuery, Result<UserProfile>>
    {
        public async Task<Result<UserProfile>> Handle(GetUserProfileByIdQuery query, CancellationToken cancellationToken)
        {
            UserProfile? userProfile = await context.UserProfiles
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync(up => up.Id == query.id, cancellationToken);

            if (userProfile == null)
            {
                return Result<UserProfile>.FailureResult("There is no profile available to show with this Id!");
            }

            return Result<UserProfile>.SuccessResult(userProfile); // Ensure proper wrapping
        }        
    }
}
