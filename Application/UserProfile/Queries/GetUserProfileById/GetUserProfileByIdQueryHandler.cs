using MediatR;
using domain = Domain.Entities;
using Domain.Repositories;
using Domain.Exceptions;
using Application.Abstraction;

namespace Application.UserProfile.Queries.GetUserProfileById
{
    internal sealed class GetUserProfileByIdQueryHandler: IRequestHandler<GetUserProfileByIdQuery, Result<domain.UserProfile>>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GetUserProfileByIdQueryHandler(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
        }
       

        public async Task<Result<domain.UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var userProfile = await _userProfileRepository.GetByIdAsync(request.Id, cancellationToken);
            if (userProfile == null)
            {
                //return Result<UserProfileDto>.FailureResult("User profile not found.");
                return Result<domain.UserProfile>.FailureResult("User profile not found.");
            }
            //return Result<UserProfileDto>.SuccessResult(userProfileDto);
            return Result<domain.UserProfile>.SuccessResult(userProfile);
        }        
    }
}
