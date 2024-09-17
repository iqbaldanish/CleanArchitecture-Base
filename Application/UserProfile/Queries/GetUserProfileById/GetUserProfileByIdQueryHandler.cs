using MediatR;
using Domain.Repositories;
using Domain.Exceptions;
using Application.Abstraction;

namespace Application.UserProfile.Queries.GetUserProfileById
{
    internal sealed class GetUserProfileByIdQueryHandler: IRequestHandler<GetUserProfileByIdQuery, Result<Domain.Entities.UserProfile>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
        }
       

        public async Task<Result<Domain.Entities.UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetByIdAsync(request.Id, cancellationToken);
            if (userProfile == null)
            {
                //return Result<UserProfileDto>.FailureResult("User profile not found.");
                return Result<Domain.Entities.UserProfile>.FailureResult("User profile not found.");
            }
            //return Result<UserProfileDto>.SuccessResult(userProfileDto);
            return Result<Domain.Entities.UserProfile>.SuccessResult(userProfile);
        }        
    }
}
