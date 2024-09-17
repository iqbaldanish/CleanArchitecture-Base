using Application.Abstraction;
using MediatR;
using Domain.Entities;
using System.Collections.Generic;


namespace Application.Features.Queries.GetUserProfiles
{
    internal sealed class GetUserProfilesQueryHandler (IApplicationDbContext context) : IRequestHandler<GetUserProfilesQuery, Result<IEnumerable<Domain.Entities.UserProfile>>>
    {
        public async Task<Result<IEnumerable<Domain.Entities.UserProfile>>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        { 
            var userProfile = context.UserProfiles.AsAsyncEnumerable();  
            if (userProfile == null)
            {
                return Result<IEnumerable<UserProfile>>.FailureResult("No Domain.Entities.UserProfile found.");
            }
          
            return Result<IEnumerable<UserProfile>>.SuccessResult((IEnumerable < UserProfile > )userProfile);
        }
    }
}
