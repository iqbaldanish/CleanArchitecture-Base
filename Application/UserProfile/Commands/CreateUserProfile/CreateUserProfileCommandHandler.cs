using MediatR;
using domain = Domain.Entities;
using Domain.Repositories;

namespace Application.UserProfile.Commands.CreateUserProfile
{
    internal sealed class CreateUserProfileCommandHandler: IRequestHandler<CreateUserProfileCommand, Guid>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IUnitOfWork unitOfWork)
        {
            _userProfileRepository = userProfileRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
           var userProfile = new domain.UserProfile(Guid.NewGuid(), request.firstName, request.lastName);
            _userProfileRepository.Insert(userProfile);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return userProfile.Id;
        }       
    }
}
