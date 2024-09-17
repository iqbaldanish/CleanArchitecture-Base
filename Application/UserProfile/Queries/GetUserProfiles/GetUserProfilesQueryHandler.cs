using Application.Abstraction;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfile.Queries.GetUserProfiles
{
    internal sealed class GetUserProfilesQueryHandler : IRequestHandler<GetUserProfilesQuery, Result<IEnumerable<Domain.Entities.UserProfile>>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfilesQueryHandler(IApplicationDbContext applicationDbContext, IUnitOfWork unitOfWork)
        {
            _applicationDbContext = applicationDbContext;
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<IEnumerable<Domain.Entities.UserProfile>>> Handle(GetUserProfilesQuery request, CancellationToken cancellationToken)
        {           

            var userProfile = _applicationDbContext.UserProfiles.AsEnumerable();  
            if (userProfile == null)
            {
                return Result<IEnumerable<Domain.Entities.UserProfile>>.FailureResult("No Domain.Entities.UserProfile found.");
            }
          
            return Result<IEnumerable<Domain.Entities.UserProfile>>.SuccessResult(userProfile.ToList());
        }
    }
}
